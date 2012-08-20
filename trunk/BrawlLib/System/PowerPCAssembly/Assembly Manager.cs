using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPcAssembly
{
    public unsafe struct ASM
    {
        private VoidPtr address;
        public VoidPtr Address { get { return address; } }

        private int count;
        public int Count { get { return count; } }

        public ASM(VoidPtr address, int count)
        {
            this.address = address;
            this.count = count;
        }

        private buint this[int i]
        {
            get
            {
                if (i >= Count) throw new IndexOutOfRangeException();
                return (uint)Address[i, sizeof(buint)];
            }
        }
        public uint AddressOf(int i) { return this[i]; }
        public PPCOpCode Opcode(int i) { return PPCOpCode.Disassemble(*(buint*)(uint)this[i], this[i]); }

        public PPCOpCode[] ToCollection()
        {
            PPCOpCode[] collection = new PPCOpCode[count];

            for (int i = 0; i < count; i++)
                collection[i] = Opcode(i);

            return collection;
        }
    }
}