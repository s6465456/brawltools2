using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefActionFlagsNode : MoveDefEntryNode
    {
        internal FDefActionFlags* First { get { return (FDefActionFlags*)WorkingUncompressed.Address; } }
        int Count = 0;
        public MoveDefActionFlagsNode(string name, int count) { _name = name; Count = count; }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return Count > 0;
        }

        public override void OnPopulate()
        {
            FDefActionFlags* addr = First;
            for (int i = 0; i < Count; i++)
                new MoveDefActionFlagsEntryNode().Initialize(this, addr++, 16);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 16;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;

            FDefActionFlags* data = (FDefActionFlags*)address;
            foreach (MoveDefActionFlagsEntryNode e in Children)
                e.Rebuild(data++, 16, true);
        }
    }

    public unsafe class MoveDefActionFlagsEntryNode : MoveDefEntryNode
    {
        internal FDefActionFlags* Header { get { return (FDefActionFlags*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public int flags1, flags2, flags3;
        public uint flags4;

        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags1b { get { return new Bin32((uint)flags1); } set { flags1 = (int)value._data; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags2b { get { return new Bin32((uint)flags2); } set { flags2 = (int)value._data; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags3b { get { return new Bin32((uint)flags3); } set { flags3 = (int)value._data; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags4b { get { return new Bin32(flags4); } set { flags4 = value._data; SignalPropertyChange(); } }

        [Category("Raw Flags Int")]
        public int Flags1i { get { return flags1; } set { flags1 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Int")]
        public int Flags2i { get { return flags2; } set { flags2 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Int")]
        public int Flags3i { get { return flags3; } set { flags3 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Int")]
        public int Flags4i { get { return (int)flags4; } set { flags4 = (uint)value; SignalPropertyChange(); } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            _name = "Action" + (Index + (Parent.Name == "Action Flags" ? 274 : 0));
            flags1 = Header->_flags1;
            flags2 = Header->_flags2;
            flags3 = Header->_flags3;
            flags4 = Header->_flags4;
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 16;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefActionFlags* header = (FDefActionFlags*)address;
            header->_flags1 = flags1;
            header->_flags2 = flags2;
            header->_flags3 = flags3;
            header->_flags4 = flags4;
        }
    }

    public unsafe class MoveDefFlagsNode : MoveDefEntryNode
    {
        internal FDefSubActionFlag* Header { get { return (FDefSubActionFlag*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        //public Dictionary<string, FDefSubActionFlag> Flags { get { return flags; } set { flags = value; } }

        public List<FDefSubActionFlag> FlagsList { get { return _flags; } set { _flags = value; } }
        public List<string> NamesList { get { return _names; } set { _names = value; } }

        //internal Dictionary<string, FDefSubActionFlag> flags = new Dictionary<string, FDefSubActionFlag>();

        public List<string> _names = new List<string>();
        public List<FDefSubActionFlag> _flags = new List<FDefSubActionFlag>();

        public override bool OnInitialize()
        {
            base.OnInitialize();
            _name = "SubAction Flags";
            for (int i = 0; i < WorkingUncompressed.Length / 8; i++)
            {
                string name = null;

                if (Header[i]._stringOffset > 0)
                    name = new String((sbyte*)BaseAddress + Header[i]._stringOffset);
                else
                    name = "<null>";

                //if (!flags.ContainsKey(name) && Header[i]._stringOffset > 0)
                //    flags.Add(name, Header[i]);

                //These are used for naming the subactions in order.
                _names.Add(name);
                _flags.Add(Header[i]);
            }
            return false;
        }
    }
}
