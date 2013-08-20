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
    public unsafe class ModuleDataNode : RELEntryNode
    {
        [Browsable(false)]
        public virtual bool HasCode { get { return true; } }
        [Browsable(false)]
        public RelCommand First { get { return _firstCommand; } }
        [Browsable(false)]
        public virtual uint ASMOffset { get { return _offset; } }

        internal UnsafeBuffer _dataBuffer;
        public List<string>[] _tags;
        public RelCommand _firstCommand = null;

        public override void Dispose()
        {
            if (_dataBuffer != null)
            {
                _dataBuffer.Dispose();
                _dataBuffer = null;
            }
            base.Dispose();
        }

        public Relocation[] _relocations;

        [Browsable(false)]
        public buint* BufferAddress { get { return (buint*)_dataBuffer.Address; } }

        public Relocation this[int index] 
        {
            get
            {
                if (index < _relocations.Length && index >= 0) 
                    return _relocations[index]; 
                return null;
            }
            set
            {
                if (index < _relocations.Length && index >= 0)
                    _relocations[index] = value;
            }
        }

        public void InitBuffer(uint size, VoidPtr address)
        {
            _dataBuffer = new UnsafeBuffer((int)size.RoundUp(4));
            _relocations = new Relocation[_dataBuffer.Length / 4];

            for (int x = 0; x < _relocations.Length; x++)
                _relocations[x] = new Relocation(this, x);

            Memory.Move(_dataBuffer.Address, address, size);
        }
        public void InitBuffer(uint size)
        {
            _dataBuffer = new UnsafeBuffer((int)size.RoundUp(4));
            _relocations = new Relocation[_dataBuffer.Length / 4];

            for (int x = 0; x < _relocations.Length; x++)
                _relocations[x] = new Relocation(this, x);

            Memory.Fill(_dataBuffer.Address, size, 0);
        }

        public byte[] GetInitializedBuffer()
        {
            List<byte> bytes = new List<byte>();
            uint value;
            foreach (Relocation loc in _relocations)
            {
                value = loc.SectionOffset;
                bytes.Add((byte)((value >> 24) & 0xFF));
                bytes.Add((byte)((value >> 16) & 0xFF));
                bytes.Add((byte)((value >> 08) & 0xFF));
                bytes.Add((byte)((value >> 00) & 0xFF));
            }
            return bytes.ToArray();
        }

        private void ApplyTags()
        {
            if (HasCode)
            {
                int i = 0;
                foreach (Relocation r in _relocations)
                {
                    PPCOpCode op = r.Code;
                    if (op is BranchOpcode)
                    {
                        BranchOpcode b = op as BranchOpcode;
                        if (!b.Absolute)
                        {
                            int offset = b.Offset;
                            int iOff = offset.RoundDown(4) / 4;
                            int index = i + iOff;
                            if (index >= 0 && index < _relocations.Length)
                                _relocations[index].Tags.Add(String.Format("Sub 0x{0}", PPCFormat.Hex(ASMOffset + (uint)i * 4)));
                        }
                    }
                    i++;
                }
            }
        }

        public void Resize(int newSize)
        {
            int count = newSize.RoundDown(4) / 4;
            Array.Resize(ref _relocations, count);
            UnsafeBuffer newBuffer = new UnsafeBuffer(newSize);
            int max = Math.Min(_dataBuffer.Length, newBuffer.Length);
            if (max > 0)
                Memory.Move(newBuffer.Address, _dataBuffer.Address, (uint)max);
            _dataBuffer.Dispose();
            _dataBuffer = newBuffer;
        }

        #region Command Functions

        public void ClearCommands()
        {
            
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

        #endregion

        public Relocation GetRelocationAtAddress(VoidPtr address) { return GetRelocationAtOffset((int)(address - _dataBuffer.Address)); }
        public Relocation GetRelocationAtOffset(int offset) { return this[offset.RoundDown(4) / 4]; }
        public Relocation GetRelocationAtIndex(int index) { return this[index]; }

        public void SetRelocationAtAddress(VoidPtr address, Relocation value) { SetRelocationAtOffset((int)(address - _dataBuffer.Address), value); }
        public void SetRelocationAtOffset(int offset, Relocation value) { this[offset.RoundDown(4) / 4] = value; }
        public void SetRelocationAtIndex(int index, Relocation value) { this[index] = value; }

        public static Color clrNotRelocated = Color.FromArgb(255, 255, 255);
        public static Color clrRelocated = Color.FromArgb(200, 255, 200);
        public static Color clrBadRelocate = Color.FromArgb(255, 200, 200);
        public static Color clrBlr = Color.FromArgb(255, 255, 0);

        public Color GetStatusColorFromAddress(VoidPtr address) { return GetStatusColorFromOffset(address - _dataBuffer.Address); }
        public Color GetStatusColorFromOffset(int offset) { return GetStatusColorFromIndex(offset.RoundDown(4) / 4); }
        public Color GetStatusColorFromIndex(int index) 
        {
            if (this[index].Code is OpBlr)
                return clrBlr;
            return GetStatusColor(_relocations[index]); 
        }
        public Color GetStatusColor(Relocation c)
        {
            if (c.Command == null)
                return clrNotRelocated;
            return clrRelocated;
        }
    }
}
