using System;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin32
    {
        public uint data;

        public Bin32(uint val) { data = val; }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 32)
            {
                val += (data >> (32 - i)) & 1;
                if (i % 4 == 0 && i != 32)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (data >> index & 1) != 0; }
            set
            {
                if (value)
                    data |= (uint)(1 << index);
                else
                    data &= ~(uint)(1 << index);
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
                return (uint)((data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                data = (uint)((data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin16
    {
        public ushort data;

        public Bin16(ushort val) { data = val; }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 16)
            {
                val += (data >> (16 - i)) & 1;
                if (i % 4 == 0 && i != 16)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (data >> index & 1) != 0; }
            set
            {
                if (value)
                    data |= (ushort)(1 << index);
                else
                    data &= (ushort)~(1 << index);
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
                return (ushort)((data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                data = (ushort)((data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Bin8
    {
        public byte data;

        public Bin8(byte val) { data = val; }

        public override string ToString()
        {
            int i = 0;
            string val = "";
            while (i++ < 8)
            {
                val += (data >> (8 - i)) & 1;
                if (i % 4 == 0 && i != 8)
                    val += " ";
            }
            return val;
        }

        public bool this[int index]
        {
            get { return (data >> index & 1) != 0; }
            set
            {
                if (value)
                    data |= (byte)(1 << index);
                else
                    data &= (byte)~(1 << index);
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
                return (byte)((data >> shift) & mask);
            }
            set
            {
                int mask = 0;
                for (int i = 0; i < bitCount; i++)
                    mask |= 1 << i;
                data = (byte)((data & ~(mask << shift)) | ((value & mask) << shift));
            }
        }
    }
}
