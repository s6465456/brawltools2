using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.PowerPcAssembly
{
    public unsafe class ASM
    {
        private buint* _address;
        public int _count;

        public ASM(VoidPtr address, int count)
        {
            _address = (buint*)address;
            _count = count;
        }

        private buint* this[int i] { get { if (i < _count) return &_address[i]; return null; } }
        
        public PPCOpCode Opcode(int i) { return PPCOpCode.Disassemble(this[i]); }
        
        public PPCOpCode[] ToCollection()
        {
            PPCOpCode[] collection = new PPCOpCode[_count];

            for (int i = 0; i < _count; i++)
                collection[i] = Opcode(i);

            return collection;
        }
    }
}