using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.PowerPcAssembly
{
    public abstract unsafe class PPCOpCode
    {
        protected PPCOpCode(uint value) { _data = new PPCData(value); }

        public PPCOpCode Copy() { return (PPCOpCode)MemberwiseClone(); }

        protected List<string> _names { get { return PPCInfo.NameOf(this); } }
        protected PPCData _data = new PPCData(0);
        protected VoidPtr _address = 0;

        public string Name { get { return _names[0]; } }
        public int this[int operand] { get { return _data[operand]; } set { _data[operand] = value; } }

        public VoidPtr Address { get { return _address; } set { _address = value; } }

        public static implicit operator uint(PPCOpCode op1) { return op1._data._value; }
        public static implicit operator PPCOpCode(uint op1) { return Disassemble(op1); }

        public virtual string FormName() { return Name; }
        public virtual string FormOps()
        {
            string formal = "";
            for (int i = 0; i < _data.Count; i++)
                if (_data.Formal(i) != "")
                {
                    formal += _data.Formal(i);
                    formal += (i < _data.Count - 1 ? "," : "");
                }
            return formal;
        }

        public static PPCOpCode Disassemble(uint value)
        {
            switch (value & 0xFC000000)
            {
                case PPCInfo.vaddubm: return new OpVaddubm(value);
                case PPCInfo.mulli: return new OpMulli(value);
                case PPCInfo.subfic: return new OpSubfic(value);
                case PPCInfo.cmpli: return new OpCmpli(value);
                case PPCInfo.cmpi: return new OpCmpi(value);
                case PPCInfo.addic: return new OpAddic(value);
                case PPCInfo.addic_D: return new OpAddic(value);
                case PPCInfo.addi: return new OpAddi(value);
                case PPCInfo.addis: return new OpAddi(value);
                case PPCInfo.bc: return new OpBc(value);
                case PPCInfo.b: return new OpB(value);
                case PPCInfo.grp4C:
                    switch (value & 0xFC0007FE)
                    {
                        case PPCInfo.blr: return new OpBlr(value);
                        case PPCInfo.bctr: return new OpBctr(value);
                    }
                    break;
                case PPCInfo.rlwimi: return new OpRlwimi(value);
                case PPCInfo.rlwinm: return new OpRlwinm(value);
                case PPCInfo.ori: return new OpOri(value);
                case PPCInfo.oris: return new OpOri(value);
                case PPCInfo.xori: return new OpOri(value);
                case PPCInfo.xoris: return new OpOri(value);
                case PPCInfo.andi_D: return new OpAndiSCR(value);
                case PPCInfo.andis_D: return new OpAndiSCR(value);
                case PPCInfo.rldicl: return new OpRldicl(value);
                case PPCInfo.grp7C:
                    switch (value & 0xFC0007FE)
                    {
                        case PPCInfo.addze: return new OpAddi(value);
                        case PPCInfo.addme: return new OpAddi(value);
                        case PPCInfo.mfspr: return new OpMfspr(value);
                        case PPCInfo.xor: return new OpOr(value);
                        case PPCInfo.or: return new OpOr(value);
                        case PPCInfo.mtspr: return new OpMtspr(value);
                        case PPCInfo.extsh: return new OpExtsh(value);
                        case PPCInfo.extsb: return new OpExtsb(value);
                    }
                    break;
                case PPCInfo.lwz: return new OpLwz(value);
                case PPCInfo.lwzu: return new OpLwz(value);
                case PPCInfo.lbz: return new OpLwz(value);
                case PPCInfo.lbzu: return new OpLwz(value);
                case PPCInfo.stw: return new OpStw(value);
                case PPCInfo.stwu: return new OpStw(value);
                case PPCInfo.stb: return new OpStw(value);
                case PPCInfo.stbu: return new OpStw(value);
                case PPCInfo.lhz: return new OpLwz(value);
                case PPCInfo.lhzu: return new OpLwz(value);
                case PPCInfo.lha: return new OpLwz(value);
                case PPCInfo.lhau: return new OpLwz(value);
                case PPCInfo.sth: return new OpStw(value);
                case PPCInfo.sthu: return new OpStw(value);
                case PPCInfo.lmw: return new OpLwz(value);
                case PPCInfo.stmw: return new OpStw(value);
                case PPCInfo.lfs: return new OpLfs(value);
                case PPCInfo.lfsu: return new OpLfs(value);
                case PPCInfo.lfd: return new OpLfs(value);
                case PPCInfo.lfdu: return new OpLfs(value);
                case PPCInfo.stfs: return new OpStfs(value);
                case PPCInfo.stfsu: return new OpStfs(value);
                case PPCInfo.stfd: return new OpStfs(value);
                case PPCInfo.stfdu: return new OpStfs(value);
                case PPCInfo.ld: return new OpLwz(value);
                case PPCInfo.std: return new OpStw(value);
                case PPCInfo.fcmpu: return new OpFcmpu(value);
            }
            return new OpWord(value);
        }

        public static PPCOpCode Disassemble(buint* data)
        {
            PPCOpCode opcode = (uint)*data;
            opcode.Address = data;
            return opcode;
        }

        public static uint Assemble(PPCOpCode opcode)
        {
            return opcode._data._value;
        }
    }
}