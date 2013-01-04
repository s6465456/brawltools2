﻿using System;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin32
    {
        public uint _data;

        public Bin32(uint val) { _data = val; }

        public static implicit operator uint(Bin32 val) { return val._data; }
        public static implicit operator Bin32(uint val) { return new Bin32(val); }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 32)
            {
                val += (_data >> (32 - i)) & 1;
                if (i % 4 == 0 && i != 32)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (_data >> index & 1) != 0; }
            set
            {
                if (value)
                    _data |= (uint)(1 << index);
                else
                    _data &= ~(uint)(1 << index);
            }
        }

        //public uint this[int shift, int mask]
        //{
        //    get { return (uint)(data >> shift & mask); }
        //    set { data = (uint)((data & ~(mask << shift)) | ((value & mask) << shift)); }
        //}

        public uint this[int shift, int bitCount]
        {
            get
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                return (uint)((_data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                _data = (uint)((_data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin16
    {
        public ushort _data;

        public Bin16(ushort val) { _data = val; }

        public static implicit operator ushort(Bin16 val) { return val._data; }
        public static implicit operator Bin16(ushort val) { return new Bin16(val); }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 16)
            {
                val += (_data >> (16 - i)) & 1;
                if (i % 4 == 0 && i != 16)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (_data >> index & 1) != 0; }
            set
            {
                if (value)
                    _data |= (ushort)(1 << index);
                else
                    _data &= (ushort)~(1 << index);
            }
        }

        //public ushort this[int shift, int mask]
        //{
        //    get { return (ushort)(data >> shift & mask); }
        //    set { data = (ushort)((data & ~(mask << shift)) | ((value & mask) << shift)); }
        //}

        public ushort this[int shift, int bitCount]
        {
            get
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                return (ushort)((_data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                _data = (ushort)((_data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin8
    {
        public byte _data;

        public Bin8(byte val) { _data = val; }

        public static implicit operator byte(Bin8 val) { return val._data; }
        public static implicit operator Bin8(byte val) { return new Bin8(val); }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 8)
            {
                val += (_data >> (8 - i)) & 1;
                if (i % 4 == 0 && i != 8)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (_data >> index & 1) != 0; }
            set
            {
                if (value)
                    _data |= (byte)(1 << index);
                else
                    _data &= (byte)~(1 << index);
            }
        }

        //public byte this[int shift, int mask]
        //{
        //    get { return (byte)(data >> shift & mask); }
        //    set { data = (byte)((data & ~(mask << shift)) | ((value & mask) << shift)); }
        //}

        public byte this[int shift, int bitCount]
        {
            get
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                return (byte)((_data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                _data = (byte)((_data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
}
