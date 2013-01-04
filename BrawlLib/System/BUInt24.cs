using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BUInt24
    {
        public byte _dat0, _dat1, _dat2;

        public uint Value
        {
            get { return ((uint)_dat0 << 16) | ((uint)_dat1 << 8) | ((uint)_dat2); }
            set
            {
                _dat2 = (byte)((value) & 0xFF);
                _dat1 = (byte)((value >> 8) & 0xFF);
                _dat0 = (byte)((value >> 16) & 0xFF);
            }
        }

        public static explicit operator int(BUInt24 val) { return (int)val.Value; }
        public static explicit operator BUInt24(int val) { return new BUInt24(val); }
        public static explicit operator uint(BUInt24 val) { return (uint)val.Value; }
        public static explicit operator BUInt24(uint val) { return new BUInt24((int)val); }

        public BUInt24(int value)
        {
            _dat2 = (byte)((value) & 0xFF);
            _dat1 = (byte)((value >> 8) & 0xFF);
            _dat0 = (byte)((value >> 16) & 0xFF);
        }

        public BUInt24(byte v0, byte v1, byte v2)
        {
            _dat2 = v2;
            _dat1 = v1;
            _dat0 = v0;
        }

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
