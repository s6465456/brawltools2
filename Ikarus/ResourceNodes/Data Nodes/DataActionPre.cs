using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefActionPreNode : MoveDefEntry
    {
        internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefActionPreNode(int count) { Count = count; }

        public override bool OnInitialize()
        {
            _extOverride = true;
            base.OnInitialize();
            _name = "Action Pre";
            return Count > 0;
        }

        public override void OnPopulate()
        {
            bint* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefActionPreEntryNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            bint* addr = (bint*)address;
            foreach (MoveDefActionPreEntryNode b in Children)
            {
                b._rebuildAddr = addr;
                *addr++ = (b.External ? -1 : 0);
            }
        }
    }

    public unsafe class MoveDefActionPreEntryNode : MoveDefEntry
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int i = 0;

        [Category("Action Pre")]
        public int Value { get { return i; } }
        [Category("Action Pre"), Browsable(true), TypeConverter(typeof(DropDownListExtNodesMDef))]
        public string ExternalNode
        {
            get { return _externalEntry != null ? _externalEntry.Name : null; }
            set
            {
                if (_externalEntry != null)
                    if (_externalEntry.Name != value)
                        _externalEntry._refs.Remove(this);
                
                foreach (ReferenceEntry e in _root._referenceList)
                    if (e.Name == value)
                    {
                        _externalEntry = e;
                        e._references.Add(this);
                        Name = e.Name;
                    }

                if (_externalEntry == null)
                    Name = "Action" + Index;
            }
        }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Action" + Index;
            i = *Header;
            return false;
        }

        //-1 if external, 0 if none.
        //offsets to the next ref of the same name until -1. Last ref is always -1

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            *(bint*)address = i;
        }
    }
}
