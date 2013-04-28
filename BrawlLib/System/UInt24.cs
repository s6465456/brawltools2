﻿using System;
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
        public static explicit operator BUInt24(int val) { return new BUInt24((uint)val); }
        public static explicit operator uint(BUInt24 val) { return (uint)val.Value; }
        public static explicit operator BUInt24(uint val) { return new BUInt24(val); }

        public BUInt24(uint value)
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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UInt24
    {
        public byte _dat2, _dat1, _dat0;
        
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

        public static explicit operator int(UInt24 val) { return (int)val.Value; }
        public static explicit operator UInt24(int val) { return new UInt24((uint)val); }
        public static explicit operator uint(UInt24 val) { return (uint)val.Value; }
        public static explicit operator UInt24(uint val) { return new UInt24(val); }

        public UInt24(uint value)
        {
            _dat2 = (byte)((value) & 0xFF);
            _dat1 = (byte)((value >> 8) & 0xFF);
            _dat0 = (byte)((value >> 16) & 0xFF);
        }

        public UInt24(byte v0, byte v1, byte v2)
        {
            _dat2 = v2;
            _dat1 = v1;
            _dat0 = v0;
        }

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
