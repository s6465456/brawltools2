using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.IO;
using System.ComponentModel;
using System.PowerPcAssembly;
using System.Drawing;

namespace BrawlLib.SSBB.ResourceNodes
{   
    ///<summary>Represents 4 bytes in a module memory section.</summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public unsafe class Relocation
    {
        public Relocation(ModuleDataNode d, int i)
        {
            _section = d;
            _index = i;
        }

        public ModuleDataNode _section;
        public int _index;

        [Category("Relocation Data"), Browsable(false)]
        public RelCommand Command { get { return _command; } set { SetCommand(value); } }
        private RelCommand _command;

        [Browsable(false)]
        public PPCOpCode Code { get { return RelOffset; } }

        [Browsable(false)]
        public Relocation Target { get { return _target; } set { SetTarget(value); } }
        private Relocation _target;

        [Browsable(false)]
        public VoidPtr Address { get { return _section.WorkingUncompressed.Address[_index, 4]; } }

        [Browsable(false)]
        public uint RawValue { get { return _section.BufferAddress[_index]; } set { _section.BufferAddress[_index] = value; } }
        [Browsable(false)]
        public uint RelOffset { get { return (Command != null ? Command.Apply(true) : RawValue); } }
        [Browsable(false)]
        public uint SectionOffset { get { return (Command != null ? Command.Apply(false) : RawValue); } }

        [Browsable(false)]
        public Relocation Next { get { return NextAt(1); } }
        [Browsable(false)]
        public Relocation Previous { get { return NextAt(-1); } }

        public Relocation NextAt(int count)
        {
            int newIndex = _index + count;
            if (newIndex < 0 || newIndex >= _section._relocations.Length)
                return null;
            else
                return _section[newIndex];
        }

        private void SetCommand(RelCommand command)
        {
            if (_command == command)
                return;

            if (_command != null)
            {
                SetTarget(null);
                _command.SetRelocationParent(null);
            }

            if ((_command = command) != null)
            {
                _command.SetRelocationParent(this);
                SetTarget(_command._targetRelocation);
            }
        }

        private void SetTarget(Relocation target)
        {
            if (_target == target)
                return;

            if (_target != null)
                _target.Unlink(this);

            _target = target;

            if (_target != null)
                _target.Link(this);
        }

        [Category("Relocation Data"), Browsable(true)]
        public BindingList<Relocation> Linked { get { return _linked; } }
        private BindingList<Relocation> _linked = new BindingList<Relocation>();

        internal void Link(Relocation rel) { _linked.Add(rel); }
        internal void Unlink(Relocation rel) { _linked.Remove(rel); }

        private List<object> _tags = new List<object>();
        public List<object> Tags { get { return _tags; } }

        [Browsable(false)]
        public string Notes { get { return string.Join(", ", _tags.OfType<string>().ToArray()); ; } }
        [Browsable(false)]
        public string Description
        {
            get
            {
                if (_command == null && Notes == "")
                    return "";

                if (_command != null)
                {
                    string id;
                    //if (_command._moduleID == _data.Root.ModuleID)
                    //    id = _data.Root.Name;
                    //else
                    if (RELNode._idNames.ContainsKey((int)_command._moduleID))
                        id = RELNode._idNames[(int)_command._moduleID];
                    else
                        id = "m" + _command._moduleID.ToString();

                    return
                        (_command._moduleID != 0 ? String.Format("{0}[{1}]", id, _command._targetSectionId.ToString()) : "") +
                        ((_target == null || _target.Notes == "") ? "0x" + _command._addend.ToString("X2") : String.Format("[{0}]", _target.Notes));
                }
                else
                    return Notes;
            }
        }

        public override string ToString()
        {
            int i = (int)(_section.Root as ModuleNode).ID;
            string id = RELNode._idNames.ContainsKey(i) ? RELNode._idNames[i] : "m" + i.ToString();
            return String.Format("{0}[{1}]0x{2}", id, _section.Index, (_index * 4).ToString("X"));
        }
    }
}
