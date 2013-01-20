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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public unsafe class Relocation
    {
        public Relocation(ModuleDataNode d, int i)
        {
            _data = d;
            _index = i;
        }

        public ModuleDataNode _data;
        public int _index;

        public RelCommand Command { get { return _command; } set { SetCommand(value); } }
        private RelCommand _command;

        public PPCOpCode Code { get { return FormalValue; } }

        public Relocation Target { get { return _target; } set { SetTarget(value); } }
        private Relocation _target;

        public VoidPtr Address { get { return &_data.OrigAddress[_index]; } }

        public uint RawValue { get { return _data.BufferAddress[_index]; } set { _data.BufferAddress[_index] = value; } }
        public uint FormalValue { get { return (Command != null ? Command.Apply(RawValue) : RawValue); } }
        public uint OffsetValue { get { return (Command != null ? Command.Apply(RawValue, true) : RawValue); } }
        
        public Relocation Next { get { return NextAt(1); } }
        public Relocation Previous { get { return NextAt(-1); } }

        public Relocation NextAt(int count)
        {
            int newIndex = _index + count;
            if (newIndex < 0 || newIndex >= _data._relocations.Length)
                return null;
            else
                return _data[newIndex];
        }

        private void SetCommand(RelCommand command)
        {
            if (_command == command)
                return;

            if (_command != null)
                SetTarget(null);

            _command = command;

            if (_command != null)
                SetTarget(_command.TargetRelocation);
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

        private List<Relocation> _linked = new List<Relocation>();
        internal void Link(Relocation rel) { _linked.Add(rel); }
        internal void Unlink(Relocation rel) { _linked.Remove(rel); }

        private List<object> _Tags = new List<object>();
        public List<object> Tags { get { return _Tags; } }
        public string Notes { get { return string.Join(", ", _Tags.OfType<string>().ToArray()); ; } }
        public string Description
        {
            get
            {
                return (_command == null ? "" :
                    (_command._moduleID != 0 ? String.Format("m{0}[{1}]", _command._moduleID, _command._targetSectionId) : "") +
                    ((_target == null || _target.Notes == "") ? "0x" + _command.Addend.ToString("X2") : String.Format("[{0}]", _target.Notes)));
            }
        }
    }

    public unsafe class ModuleDataNode : ModuleEntryNode
    {
        [Browsable(false)]
        public bool HasNoCode { get { return _code == null; } }
        [Browsable(false)]
        public RelCommand First { get { return _firstCommand; } }

        public ASM _code;
        internal UnsafeBuffer _dataBuffer;
        public List<string>[] _tags;
        public RelCommand _firstCommand;
        internal VoidPtr _initAddr;

        public Relocation[] _relocations;

        [Browsable(false)]
        public buint* BufferAddress { get { return (buint*)_dataBuffer.Address; } }
        [Browsable(false)]
        public buint* OrigAddress { get { return (buint*)_initAddr; } }

        public Relocation this[int index] { get { if (index < _relocations.Length && index >= 0) return _relocations[index]; return null; } }

        public void Init(uint size, bool codeSection, VoidPtr address)
        {
            _initAddr = address;
            _dataBuffer = new UnsafeBuffer((int)size.RoundUp(4));
            _relocations = new Relocation[_dataBuffer.Length / 4];

            for (int x = 0; x < _relocations.Length; x++)
                _relocations[x] = new Relocation(this, x);

            byte* pOut = (byte*)_dataBuffer.Address;
            byte* pIn = (byte*)address;

            int i = 0;
            for (; i < size; i++) *pOut++ = *pIn++;
            for (; i < size.RoundUp(4); i++) *pOut++ = 0;

            if (codeSection)
                _code = new ASM(_dataBuffer.Address, _dataBuffer.Length / 4);
            else
                _code = null;
        }

        public void GetFirstCommand() { _firstCommand = GetCommandAfter(-1); }

        public RelCommand GetCommandAfter(int startIndex)
        {
            int i = GetIndexOfCommandAfter(startIndex);
            if (i >= 0 && i < _relocations.Length)
                return _relocations[i].Command;
            return null;
        }

        public RelCommand GetCommandBefore(int startIndex)
        {
            int i = GetIndexOfCommandBefore(startIndex);
            if (i >= 0 && i < _relocations.Length)
                return _relocations[i].Command;
            return null;
        }

        public int GetIndexOfCommandBefore(int startIndex)
        {
            if (startIndex < 0)
                return -1;

            if (startIndex > _relocations.Length)
                startIndex = _relocations.Length;

            for (int i = startIndex - 1; i >= 0; i--)
                if (i < _relocations.Length && _relocations[i].Command != null)
                    return i;

            return -1;
        }

        public int GetIndexOfCommandAfter(int startIndex)
        {
            if (startIndex >= _relocations.Length || startIndex < -1)
                return -1;

            for (int i = startIndex + 1; i < _relocations.Length - 1; i++)
                if (i < _relocations.Length && _relocations[i].Command != null)
                    return i;

            return -1;
        }

        public RelCommand GetCommandFromAddress(VoidPtr address) { return GetCommandFromOffset((int)(address - _dataBuffer.Address)); }
        public RelCommand GetCommandFromOffset(int offset) { return GetCommandFromIndex(offset.RoundDown(4) / 4); }
        public RelCommand GetCommandFromIndex(int index) { if (index < _relocations.Length && index >= 0) return _relocations[index].Command; return null; }

        public void SetCommandAtAddress(VoidPtr address, RelCommand cmd) { SetCommandAtOffset((int)(address - _dataBuffer.Address), cmd); }
        public void SetCommandAtOffset(int offset, RelCommand cmd) { SetCommandAtIndex(offset.RoundDown(4) / 4, cmd); }
        public void SetCommandAtIndex(int index, RelCommand cmd)
        {
            if (index >= _relocations.Length || index < 0)
                return;

            if (_relocations[index].Command != null)
                _relocations[index].Command.Remove();

            _relocations[index].Command = cmd;

            RelCommand c = GetCommandBefore(index);
            if (c != null)
                cmd.InsertAfter(c);
            else
            {
                c = GetCommandAfter(index);
                if (c != null)
                    cmd.InsertBefore(c);
            }
            GetFirstCommand();
        }

        public Relocation Relocations(VoidPtr address) { return Relocations((int)(address - _dataBuffer.Address)); }
        public Relocation Relocations(int offset) { return this[offset.RoundDown(4) / 4]; }
        
        public static Color clrNotRelocated = Color.FromArgb(255, 255, 255);
        public static Color clrRelocated = Color.FromArgb(200, 255, 200);
        public static Color clrBadRelocate = Color.FromArgb(255, 200, 200);
        public static Color clrBlr = Color.FromArgb(255, 255, 0);

        public Color GetStatusColorFromAddress(VoidPtr address) { return GetStatusColor(GetCommandFromAddress(address)); }
        public Color GetStatusColorFromOffset(int offset) { return GetStatusColor(GetCommandFromOffset(offset)); }
        public Color GetStatusColorFromIndex(int index) 
        {
            if (this[index].Code is OpBlr)
                return clrBlr;
            return GetStatusColor(GetCommandFromIndex(index)); 
        }
        public Color GetStatusColor(RelCommand c)
        {
            if (c == null) 
                return clrNotRelocated;
            //if (c._initialized) 
                return clrRelocated;
            //return clrBadRelocate;
        }
    }
}
