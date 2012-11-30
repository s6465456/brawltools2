using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerPcAssembly
{
    public abstract unsafe class PPCOpCode : ICloneable
    {
        protected PPCOpCode(uint value) { data = new PPCData(value); }
        public PPCOpCode Copy() { return (PPCOpCode)this.Clone(); }
        public object Clone() { return this.MemberwiseClone(); }

        protected List<string> _names { get { return PPCInfo.NameOf(this); } }
        protected PPCData data = new PPCData(0x00000000);
        protected uint address = 0;

        public string Name { get { return _names[0]; } }
        public int this[int operand] { get { return data[operand]; } set { data[operand] = value; } }
        public uint Address { get { return address; } set { address = value; } }

        public static implicit operator uint(PPCOpCode op1) { return op1.data._value; }
        public static implicit operator PPCOpCode(uint op1) { return Disassemble(op1); }

        public virtual string FormName() { return Name; }
        public virtual string FormOps()
        {
            string formal = "";
            for (int i = 0; i < data.Count; i++)
                if (data.Formal(i) != "")
                {
                    formal += data.Formal(i);
                    formal += (i < data.Count - 1 ? "," : "");
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

        public static PPCOpCode Disassemble(uint value, uint address)
        {
            PPCOpCode opcode = value;
            opcode.Address = address;
            return opcode;
        }
    }

    //  .word
    public unsafe class OpWord : PPCOpCode
    {
        public OpWord(uint value)
            : base(value)
        {

        }

        public override string FormOps() { return "0x" + PPCFormat.Word(this); }

    }

    //  vaddubm
    public unsafe class OpVaddubm : PPCOpCode
    {
        public OpVaddubm(uint value)
            : base(value)
        {

        }

        public override string FormOps() { return "0x" + PPCFormat.Word(this); }
    }

    //  mulli
    public unsafe class OpMulli : PPCOpCode
    {
        public OpMulli(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }
    }

    //  subfic
    public unsafe class OpSubfic : PPCOpCode
    {
        public OpSubfic(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value            
        }
    }

    //  cmplwi, cmpldi
    public unsafe class OpCmpli : PPCOpCode
    {
        public OpCmpli(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 22, 0x1));                   //  [-] Unknown
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x1));                   //  [-] Is Double
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));               //  [1] Left Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));         //  [2] Immediate Value
        }

        public override string FormName()
        {
            if (IsDouble)
                return _names[1];

            return _names[0];
        }

        bool IsDouble { get { return (this & 0x00200000) != 0; } }
    }

    //  cmpwi, cmpdi
    public unsafe class OpCmpi : PPCOpCode
    {
        public OpCmpi(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 22, 0x1));                   //  [-] Unknown
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x1));                   //  [-] Is Double
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));               //  [1] Left Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));         //  [2] Immediate Value
        }

        public override string FormName()
        {
            if (IsDouble)
                return _names[1];

            return _names[0];
        }

        bool IsDouble { get { return (this & 0x00200000) != 0; } }
    }

    //  addic, subic, addic., subic.
    public unsafe class OpAddic : PPCOpCode
    {
        public OpAddic(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value      
        }

        bool SetCr { get { return (this & 0xFC000000) == 0x34000000; } }

        public override string FormName()
        {
            if (data[2] < 0)
                return _names[1];

            return _names[0];
        }

    }

    //  addi, addis, subi, subis, li, lis
    public unsafe class OpAddi : PPCOpCode
    {
        public OpAddi(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool shifted { get { return (this & 0xFC000000) == 0x3C000000; } }

        public override string FormName()
        {
            if (data[1] != 0)
                if (data[2] < 0)
                    return _names[1];
                else
                    return _names[0];

            return _names[2];
        }

        public override string FormOps()
        {
            if (data[1] == 0)
                //return data.Formal(0) + "," + data.Formal(2);
                return data.Formal(0) + " = " + data.Formal(2);

            return data.Formal(0) + " = " + data.Formal(1) + " + " + data.Formal(2);

            //return base.FormOps();
        }
    }

    //  Branch Opcode base class
    public abstract unsafe class BranchOpcode : PPCOpCode
    {
        protected BranchOpcode(uint value) : base(value) { }

        protected const uint AbsoluteAddr = 0x7FFFCF00;
        protected uint MaxDistance = 0;

        protected bool badDestination = false;
        public bool BadDestination { get { return badDestination; } }

        protected uint destination = 0;
        public uint Destination
        {
            get
            {
                uint baseAddr = Address;
                if (Absolute) baseAddr = AbsoluteAddr;

                if (BadDestination)
                    return destination;
                else
                    return (uint)(baseAddr + data[0]);
            }
            set
            {
                uint baseAddr = Address;
                if (Absolute) baseAddr = AbsoluteAddr;

                destination = value.RoundDown(4);
                badDestination = false;

                if (destination < baseAddr + MaxDistance && destination >= baseAddr - MaxDistance)
                    data[0] = (int)destination - (int)baseAddr;
                else
                {
                    badDestination = true;
                    data[0] = 0;
                }
            }
        }

        protected bool Link { get { return (this & 0x1) != 0; } }
        protected bool Absolute { get { return (this & 0x2) != 0; } }
    }

    //  bc, bdnz, bdnzf, bdnzt, bdz, bdzf, bdzt, beq, bne, bgt, blt, bge, ble
    public unsafe class OpBc : BranchOpcode
    {
        public OpBc(uint value)
            : base(value)
        {
            //data.Add(new OperandLocator(OperandType.VAL, 25, 0x1));               //  [-] Unknown
            //data.Add(new OperandLocator(OperandType.VAL, 24, 0x1));               //  [-] Not
            //data.Add(new OperandLocator(OperandType.VAL, 23, 0x1));               //  [-] Value Compare
            //data.Add(new OperandLocator(OperandType.VAL, 22, 0x1));               //  [-] cr Conditional Not
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x1));               //  [-] Reverse
            data.Add(new OperandLocator(OperandType.Offset, 0, 0x7FFC, 0x8000));    //  [0] Offset
            data.Add(new OperandLocator(OperandType.ConditionRegister, 18, 0x7));   //  [1] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 16, 0x3));               //  [-] Value Compare Type
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));                //  [-] Link
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x2));                //  [-] Absolute

            MaxDistance = 0x8000;
        }

        bool Unknown { get { return (this & 0x2000000) != 0; } }
        bool Not { get { return (this & 0x1000000) != 0; } }
        bool ValCompare { get { return (this & 0x800000) != 0; } }
        bool CRCNot { get { return (this & 0x400000) != 0; } }
        bool Reverse { get { return (this & 0x200000) != 0; } }
        int ValCmpType { get { return ((int)(uint)this >> 16) & 0x3; } }

        public override string FormName()
        {
            if (Unknown)
                return base.FormName();

            if (!ValCompare)
                return _names[1 + (CRCNot ? 1 : 0)] + (Not ? "t" : "f") + (data[0] < 0 ^ Reverse ? "+" : "-");
            else
                return _names[3 + (ValCmpType * 2) + (Not ? 1 : 0)] + (data[0] < 0 ^ Reverse ? "+" : "-");
        }

        public override string FormOps()
        {
            if (Unknown)
                return "0x" + PPCFormat.Word(this);

            if (Address == 0 && !Absolute)
                return (data.Formal(1) != "" ? data.Formal(1) + "," : "") + PPCFormat.SOffset((int)Destination);

            return (data.Formal(1) != "" ? data.Formal(1) + "," : "") + PPCFormat.Offset(Destination);
        }
    }

    //  b, bl, ba, bla
    public unsafe class OpB : BranchOpcode
    {
        public OpB(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Offset, 0, 0x3FFFFFC, 0x2000000));    //  [0] Offset
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));                      //  [-] Link
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x2));                      //  [-] Absolute

            MaxDistance = 0x2000000;
        }

        public override string FormName()
        {
            return base.FormName() + (Link ? "l" : "") + (Absolute ? "a" : "");
        }

        public override string FormOps()
        {
            if (Address == 0 && !Absolute)
                return "Go to " + (Link ? "subroutine " : "") + PPCFormat.SOffset((int)Destination);

            return "Go to " + (Link ? "subroutine " : "") + PPCFormat.Offset(Destination);
        }
    }

    //  blr
    public unsafe class OpBlr : PPCOpCode
    {
        public OpBlr(uint value)
            : base(value)
        {

        }

        public override string FormOps()
        {
            return "return to address in link register.";
        }
    }

    //  bctr
    public unsafe class OpBctr : PPCOpCode
    {
        public OpBctr(uint value)
            : base(value)
        {

        }
    }

    //  rlwimi
    public unsafe class OpRlwimi : PPCOpCode
    {
        public OpRlwimi(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            data.Add(new OperandLocator(OperandType.Value, 11, 0x1F));          // [2] Roll Left
            data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));            // [-] Set Cr
        }
    }

    //  rlwinm
    public unsafe class OpRlwinm : PPCOpCode
    {
        public OpRlwinm(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            data.Add(new OperandLocator(OperandType.Value, 11, 0x1F));          // [2] Roll Left
            data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));            // [-] Set Cr
        }
    }

    //  rlwmn
    public unsafe class OpRlwmn : PPCOpCode
    {
        public OpRlwmn(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            data.Add(new OperandLocator(OperandType.Register, 11, 0x1F));       // [2] Right Register 2
            data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));            // [-] Set Cr      
        }
    }

    //  or, xor, mr
    public unsafe class OpOr : PPCOpCode
    {
        public OpOr(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));        //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));        //  [1] Right Register 1
            data.Add(new OperandLocator(OperandType.Register, 11, 0x1F));        //  [2] Right Register 2
        }

        bool Exclusive { get { return (this & 0x7FE) == 0xA78; } }

        public override string FormName()
        {
            if (!Exclusive)
                if (data[1] == data[2])
                    return _names[1];

            return base.FormName();
        }

        public override string FormOps()
        {
            if (!Exclusive)
                if (data[1] == data[2])
                    return data.Formal(0) + "," + data.Formal(1);

            return base.FormOps();
        }
    }

    //  ori, oris, xori, xoris, nop
    public unsafe class OpOri : PPCOpCode
    {
        public OpOri(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }

        bool Shifted { get { return (this & 0xFC000000) == PPCInfo.oris || (this & 0xFC000000) == PPCInfo.xoris; } }
        bool Exclusive { get { return (this & 0xFC000000) == PPCInfo.xori || (this & 0xFC000000) == PPCInfo.xoris; } }

        public override string FormName()
        {
            if (!Exclusive)
                if (data[0] == 0 && data[1] == 0 && data[2] == 0)
                    return _names[1];

            return base.FormName();
        }

        public override string FormOps()
        {
            if (!Exclusive)
                if (data[0] == 0 && data[1] == 0 && data[2] == 0)
                    return "";

            return base.FormOps();
        }
    }

    //  andi., andis.
    public unsafe class OpAndiSCR : PPCOpCode
    {
        public OpAndiSCR(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }

        bool Shifted { get { return (this & 0xFC000000) == PPCInfo.andis_D; } }
    }

    //  rldicl
    public unsafe class OpRldicl : PPCOpCode
    {
        public OpRldicl(uint value)
            : base(value)
        {

        }

        public override string FormOps() { return "0x" + PPCFormat.Word(this); }
    }

    //  mfspr
    public unsafe class OpMfspr : PPCOpCode
    {
        public OpMfspr(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));             //  [0] Left Register
            data.Add(new OperandLocator(OperandType.SpecialRegister, 16, 0x1F));      //  [1] Right Register
        }

        public override string FormOps()
        {
            return data.Formal(0) + " = " + data.Formal(1);
        }
    }

    //  mtspr
    public unsafe class OpMtspr : PPCOpCode
    {
        public OpMtspr(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.SpecialRegister, 16, 0x1F));    //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));           //  [1] Right Register
        }

        public override string FormOps()
        {
            return data.Formal(0) + " = " + data.Formal(1);
        }
    }

    //  lwz, lwzu, lbz, lbzu, lhz, lhzu, lha, lhau, ld
    public unsafe class OpLwz : PPCOpCode
    {
        public OpLwz(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC000000) == PPCInfo.lwzu || (this & 0xFC000000) == PPCInfo.lbzu || (this & 0xFC000000) == PPCInfo.lhzu || (this & 0xFC000000) == PPCInfo.lhau; } }
        bool Multiple { get { return (this & 0xFC000000) == PPCInfo.lmw; } }
        bool Algebraic { get { return (this & 0xFC000000) == PPCInfo.lha || (this & 0xFC000000) == PPCInfo.lhau; } }
        DataSize Size
        {
            get
            {
                switch (this & 0xFC000000)
                {
                    case PPCInfo.lwz:
                    case PPCInfo.lwzu:
                    case PPCInfo.lmw:
                        return DataSize.Word;
                    case PPCInfo.lbz:
                    case PPCInfo.lbzu:
                        return DataSize.Byte;
                    case PPCInfo.lhz:
                    case PPCInfo.lhzu:
                    case PPCInfo.lha:
                    case PPCInfo.lhau:
                        return DataSize.Half;
                    case PPCInfo.ld:
                        return DataSize.Double;
                    default:
                        return DataSize.Undefined;
                }
            }
        }

        public override string FormOps()
        {
            //return data.Formal(0) + "," + data.Formal(2) + "(" + data.Formal(1) + ")";
            return data.Formal(0) + " = *(" + data.Formal(1) + " +" + (Update ? "= " : " ") + data.Formal(2) + ")";
        }
    }

    //  stw, stwu, stb, stbu, sth, sthu, std
    public unsafe class OpStw : PPCOpCode
    {
        public OpStw(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC000000) == PPCInfo.stwu || (this & 0xFC000000) == PPCInfo.stbu || (this & 0xFC000000) == PPCInfo.sthu; } }
        bool Multiple { get { return (this & 0xFC000000) == PPCInfo.stmw; } }
        DataSize Size
        {
            get
            {
                switch (this & 0xFC000000)
                {
                    case PPCInfo.stw:
                    case PPCInfo.stwu:
                    case PPCInfo.stmw:
                        return DataSize.Word;
                    case PPCInfo.stb:
                    case PPCInfo.stbu:
                        return DataSize.Byte;
                    case PPCInfo.sth:
                    case PPCInfo.sthu:
                        return DataSize.Half;
                    case PPCInfo.std:
                        return DataSize.Double;
                    default:
                        return DataSize.Undefined;
                }
            }
        }

        public override string FormOps()
        {
            //return data.Formal(0) + "," + data.Formal(2) + "(" + data.Formal(1) + ")";
            return "*(" + data.Formal(1) + " + " + data.Formal(2) + ") = " + data.Formal(0);
        }
    }

    //  lfs, lfsu, lfd, lfdu
    public unsafe class OpLfs : PPCOpCode
    {
        public OpLfs(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.FloatRegister, 21, 0x1F));      //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));           //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));     //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC0000000) == PPCInfo.lfsu || (this & 0xFC000000) == PPCInfo.lfdu; } }
        bool IsDouble { get { return (this & 0xFC000000) == PPCInfo.lfd || (this & 0xFC000000) == PPCInfo.lfdu; } }

        public override string FormOps()
        {
            return data.Formal(0) + "," + data.Formal(2) + "(" + data.Formal(1) + ")";
        }
    }

    //  stfs, stfsu, stfd, stfdu
    public unsafe class OpStfs : PPCOpCode
    {
        public OpStfs(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.FloatRegister, 21, 0x1F));  //  [0] Left Register
            data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC000000) == PPCInfo.stfsu || (this & 0xFC000000) == PPCInfo.stfdu; } }
        bool IsDouble { get { return (this & 0xFC000000) == PPCInfo.stfd || (this & 0xFC000000) == PPCInfo.stfdu; } }

        public override string FormOps()
        {
            return data.Formal(0) + "," + data.Formal(2) + "(" + data.Formal(1) + ")";
        }
    }

    //  fcmpu
    public unsafe class OpFcmpu : PPCOpCode
    {
        public OpFcmpu(uint value)
            : base(value)
        {
            data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x3));                   //  [-] Unknown
            data.Add(new OperandLocator(OperandType.FloatRegister, 16, 0x1F));              //  [1] Left Register
            data.Add(new OperandLocator(OperandType.FloatRegister, 11, 0x1F));              //  [2] Right Register
        }
    }

    public enum DataSize { Byte, Half, Word, Double, Undefined }
    public enum OperandType { Value, UnsignedValue, Offset, UnsignedOffset, Register, FloatRegister, ConditionRegister, VRegister, SpecialRegister }
    public struct OperandLocator
    {
        public OperandLocator(OperandType type, int shift, uint bits) : this(type, shift, bits, 0x0) { }
        public OperandLocator(OperandType type, int shift, uint bits, uint neg_bit)
        {
            _type = type;
            _shift = shift;
            _bits = bits & ~(uint)neg_bit;
            _negBit = neg_bit;
        }

        public OperandType _type;
        public int _shift;

        public uint _bits;
        public uint _negBit;
    }

    public class PPCData
    {
        protected List<OperandLocator> operands = new List<OperandLocator>();
        public PPCData(buint value) { _value = value; }
        public buint _value = 0x00000000;

        public void Add(OperandLocator locator) { operands.Add(locator); }
        public int Count { get { return operands.Count; } }
        public int this[int i]
        {
            get
            {
                if (i >= operands.Count())
                    throw new IndexOutOfRangeException();

                if ((_value & operands[i]._negBit) == 0)
                    return (int)((_value >> operands[i]._shift) & operands[i]._bits);
                else
                    return (int)((_value >> operands[i]._shift) & operands[i]._bits) - (int)operands[i]._negBit;
            }
            set
            {
                if (i >= operands.Count())
                    throw new IndexOutOfRangeException();

                _value &= ~(operands[i]._bits << operands[i]._shift);
                if (value > 0)
                {
                    _value |= (uint)((value & operands[i]._bits) << operands[i]._shift);
                    _value &= ~(operands[i]._negBit);
                }
                else
                {
                    _value |= (uint)(((value + operands[i]._negBit) & operands[i]._bits) << operands[i]._shift);
                    _value |= (uint)operands[i]._negBit;
                }
            }
        }

        public string Formal(int i)
        {
            switch (operands[i]._type)
            {
                case OperandType.Value:
                    switch (PPCFormat.disassemblerDisplay)
                    {
                        case DisplayType.UnsignedHex: return PPCFormat.Word(this[i]);
                        case DisplayType.Hex: return PPCFormat.SWord(this[i]);
                        default: return this[i].ToString();
                    }
                case OperandType.UnsignedValue: return ((uint)this[i]).ToString();
                case OperandType.Offset: return PPCFormat.SOffset(this[i]);
                case OperandType.UnsignedOffset: return PPCFormat.Offset(this[i]);
                case OperandType.Register: return "r" + this[i].ToString();
                case OperandType.FloatRegister: return "f" + this[i].ToString();
                case OperandType.ConditionRegister: return (this[i] != 0 ? "cr" + this[i].ToString() : "");
                case OperandType.VRegister: return "v" + this[i].ToString();
                case OperandType.SpecialRegister:
                    switch (this[i])
                    {
                        case 1: return "xer"; //Exception Register
                        case 8: return "lr"; //Link Register
                        case 9: return "ctr"; //Counter Register
                        case 18: return "sisr";
                        case 19: return "dar";
                        case 22: return "dec";
                        case 25: return "sdr1";
                        case 26: return "srr0";
                        case 27: return "srr1";
                        default: return "sp" + this[i];
                    }
                default:
                    return "";
            }
        }
    }

    public class PPCOpCodeInfo
    {
        public PPCOpCodeInfo(uint id, string name)
        {
            _name = name;
            _id = id;
        }

        public PPCOpCodeInfo(uint id, string name, string description)
        {
            _name = name;
            _description = description;
            _id = id;
        }

        public string _name;
        public string _description;
        public uint _id;
    }

    public class PPCInfo
    {
        private static List<PPCOpCodeInfo> info = new List<PPCOpCodeInfo>();
        private static List<PPCOpCodeInfo> info4C = new List<PPCOpCodeInfo>();
        private static List<PPCOpCodeInfo> info7C = new List<PPCOpCodeInfo>();
        static PPCInfo()
        {
            info.Add(new PPCOpCodeInfo(0x00000000, ".word"));
            info.Add(new PPCOpCodeInfo(0x10000000, "vaddubm"));
            info.Add(new PPCOpCodeInfo(0x1C000000, "mulli", "Multiply Load Immediate"));
            info.Add(new PPCOpCodeInfo(0x20000000, "subfic"));
            info.Add(new PPCOpCodeInfo(0x28000000, "cmplwi", "Compare Logical (Unsigned) Word Immed"));
            info.Add(new PPCOpCodeInfo(0x28000000, "cmpldi", "Compare Logical (Unsigned) Double Immed"));
            info.Add(new PPCOpCodeInfo(0x2C000000, "cmpwi", "Compare Word Immed"));
            info.Add(new PPCOpCodeInfo(0x2C000000, "cmpdi", "Compare Double Immed"));
            info.Add(new PPCOpCodeInfo(0x30000000, "addic", "Add Immediate Carrying"));
            info.Add(new PPCOpCodeInfo(0x30000000, "subic", "Subtract Immediate Carrying"));
            info.Add(new PPCOpCodeInfo(0x34000000, "addic.", "Add Immediate Carrying Conditional"));
            info.Add(new PPCOpCodeInfo(0x34000000, "subic.", "Subtract Immediate Carrying Conditional"));
            info.Add(new PPCOpCodeInfo(0x38000000, "addi", "Add Immediate"));
            info.Add(new PPCOpCodeInfo(0x38000000, "subi", "Subtract Immediate"));
            info.Add(new PPCOpCodeInfo(0x38000000, "li", "Load Immediate"));
            info.Add(new PPCOpCodeInfo(0x3C000000, "addis", "Add Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x3C000000, "subis", "Subtract Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x3C000000, "lis", "Load Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bc"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bdnz"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bdz"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bge"));
            info.Add(new PPCOpCodeInfo(0x40000000, "blt"));
            info.Add(new PPCOpCodeInfo(0x40000000, "ble"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bgt"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bne"));
            info.Add(new PPCOpCodeInfo(0x40000000, "beq"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bns"));
            info.Add(new PPCOpCodeInfo(0x40000000, "bso"));
            info.Add(new PPCOpCodeInfo(0x48000000, "b", "Branch: start executing code at the offset."));
            info.Add(new PPCOpCodeInfo(0x50000000, "rlwimi"));
            info.Add(new PPCOpCodeInfo(0x54000000, "rlwinm"));
            info.Add(new PPCOpCodeInfo(0x5C000000, "rlwnm"));
            info.Add(new PPCOpCodeInfo(0x60000000, "ori", "Logical OR Immediate"));
            info.Add(new PPCOpCodeInfo(0x60000000, "nop"));
            info.Add(new PPCOpCodeInfo(0x64000000, "oris", "Logical OR Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x64000000, "nop"));
            info.Add(new PPCOpCodeInfo(0x68000000, "xori"));
            info.Add(new PPCOpCodeInfo(0x6C000000, "xoris"));
            info.Add(new PPCOpCodeInfo(0x70000000, "andi.", "Logical AND Immediate"));
            info.Add(new PPCOpCodeInfo(0x74000000, "andis.", "Logical AND Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x78000000, "rldicl"));
            info.Add(new PPCOpCodeInfo(0x80000000, "lwz", "Load Word Z"));
            info.Add(new PPCOpCodeInfo(0x84000000, "lwzu", "Load Word Z and Update"));
            info.Add(new PPCOpCodeInfo(0x88000000, "lbz", "Load Byte Z"));
            info.Add(new PPCOpCodeInfo(0x8C000000, "lbzu", "Load Byte Z and Update"));
            info.Add(new PPCOpCodeInfo(0x90000000, "stw", "Store Word: src, off(ptr). *(ptr + off) = src."));
            info.Add(new PPCOpCodeInfo(0x94000000, "stwu", "Store Word and Update"));
            info.Add(new PPCOpCodeInfo(0x98000000, "stb", "Store Byte"));
            info.Add(new PPCOpCodeInfo(0x9C000000, "stbu", "Store Byte and Update"));
            info.Add(new PPCOpCodeInfo(0xA0000000, "lhz", "Load Half Z"));
            info.Add(new PPCOpCodeInfo(0xA4000000, "lhzu", "Load Half Z and Update"));
            info.Add(new PPCOpCodeInfo(0xA8000000, "lha", "Load Half Algebraic"));
            info.Add(new PPCOpCodeInfo(0xAC000000, "lhau", "Load Half Algebraic and Update"));
            info.Add(new PPCOpCodeInfo(0xB0000000, "sth", "Store Half"));
            info.Add(new PPCOpCodeInfo(0xB4000000, "sthu", "Store Half and Update"));
            info.Add(new PPCOpCodeInfo(0xB8000000, "lmw", "Load Multiple Words"));
            info.Add(new PPCOpCodeInfo(0xBC000000, "stmw", "Store Multiple Words"));
            info.Add(new PPCOpCodeInfo(0xC0000000, "lfs", "Load Floating-point Single"));
            info.Add(new PPCOpCodeInfo(0xC4000000, "lfsu", "Load Floating-point Single and Update"));
            info.Add(new PPCOpCodeInfo(0xC8000000, "lfd", "Load Floating-point Double"));
            info.Add(new PPCOpCodeInfo(0xCC000000, "lfdu", "Load Floating-point Double and Update"));
            info.Add(new PPCOpCodeInfo(0xD0000000, "stfs", "Store Floating-point Single"));
            info.Add(new PPCOpCodeInfo(0xD4000000, "stfsu", "Store Floating-point Single and Update"));
            info.Add(new PPCOpCodeInfo(0xD8000000, "stfd", "Store Floating-point Double"));
            info.Add(new PPCOpCodeInfo(0xDC000000, "stfdu", "Store Floating-point Double and Update"));
            info.Add(new PPCOpCodeInfo(0xE8000000, "ld", "Load Double"));
            info.Add(new PPCOpCodeInfo(0xF8000000, "std", "Store Double"));
            info.Add(new PPCOpCodeInfo(0xFC000000, "fcmpu", "Floating-point Compare and Update"));

            info4C.Add(new PPCOpCodeInfo(0x020, "blr", "Branch on Link Register: returns to the address stored in the link register. Used to end subroutines."));
            info4C.Add(new PPCOpCodeInfo(0x420, "bctr", "Branch on Counter Register: returns to the address stored in the counter register."));

            info7C.Add(new PPCOpCodeInfo(0x194, "addze", "Add to 0 Extended"));
            info7C.Add(new PPCOpCodeInfo(0x1D4, "addme", "Add to -1 Extended"));
            info7C.Add(new PPCOpCodeInfo(0x2A6, "mfspr", "Move From Special Register: moves a special register value to a register."));
            info7C.Add(new PPCOpCodeInfo(0x278, "xor", "Bit-wise Exclusive OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "or", "Bit-wise OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "mr", "Move Register: moves data from register to register."));
            info7C.Add(new PPCOpCodeInfo(0x3A6, "mtspr", "Move To Special Register: moves a register value to a special register."));
        }

        public const uint base_op = 0x00000000;

        public const uint word = 0x00000000;
        public const uint vaddubm = 0x10000000;
        public const uint mulli = 0x1C000000;
        public const uint subfic = 0x20000000;
        public const uint cmpli = 0x28000000;
        public const uint cmpi = 0x2C000000;
        public const uint addic = 0x30000000;
        public const uint addic_D = 0x34000000;
        public const uint addi = 0x38000000;
        public const uint addis = 0x3C000000;
        public const uint bc = 0x40000000;
        public const uint b = 0x48000000;

        //Special
        public const uint grp4C = 0x4C000000;
        public const uint blr = 0x4C000020;
        public const uint bctr = 0x4C000420;

        public const uint rlwimi = 0x50000000;
        public const uint rlwinm = 0x54000000;
        public const uint rlwnm = 0x5C000000;
        public const uint ori = 0x60000000;
        public const uint oris = 0x64000000;
        public const uint xori = 0x68000000;
        public const uint xoris = 0x6C000000;
        public const uint andi_D = 0x70000000;
        public const uint andis_D = 0x74000000;
        public const uint rldicl = 0x78000000;

        //Special
        public const uint grp7C = 0x7C000000;
        public const uint slw = 0x7C000030; //todo: Shift Left Word
        public const uint addze = 0x7C000194; //todo
        public const uint addme = 0x7C0001D4; //todo
        public const uint mfspr = 0x7C0002A6;
        public const uint xor = 0x7C000278;
        public const uint or = 0x7C000378;
        public const uint mtspr = 0x7C0003A6;
        public const uint sraw = 0x7C000630; //todo: Shift Right Algebraic Word
        public const uint srawi = 0x7C000670; //todo: Shift Right Algebraic Word Immediate

        public const uint lwz = 0x80000000;
        public const uint lwzu = 0x84000000;
        public const uint lbz = 0x88000000;
        public const uint lbzu = 0x8C000000;
        public const uint stw = 0x90000000;
        public const uint stwu = 0x94000000;
        public const uint stb = 0x98000000;
        public const uint stbu = 0x9C000000;
        public const uint lhz = 0xA0000000;
        public const uint lhzu = 0xA4000000;
        public const uint lha = 0xA8000000;
        public const uint lhau = 0xAC000000;
        public const uint sth = 0xB0000000;
        public const uint sthu = 0xB4000000;
        public const uint lmw = 0xB8000000;
        public const uint stmw = 0xBC000000;
        public const uint lfs = 0xC0000000;
        public const uint lfsu = 0xC4000000;
        public const uint lfd = 0xC8000000;
        public const uint lfdu = 0xCC000000;
        public const uint stfs = 0xD0000000;
        public const uint stfsu = 0xD4000000;
        public const uint stfd = 0xD8000000;
        public const uint stfdu = 0xDC000000;
        public const uint ld = 0xE8000000;
        public const uint std = 0xF8000000;
        public const uint fcmpu = 0xFC000000;

        public static List<string> NameOf(uint value)
        {
            List<string> result = new List<string>();
            List<PPCOpCodeInfo> search = info;

            uint compare = 0xFC000000;

            if ((value & 0xFC000000) == grp4C)
                search = info4C;

            if ((value & 0xFC000000) == grp7C)
                search = info7C;

            if ((value & 0xFC000000) == grp4C || (value & 0xFC000000) == grp7C)
                compare = 0x7FE;

            bool found = false;
            for (int i = 0; i < search.Count; i++)
            {
                if ((value & compare) == search[i]._id)
                {
                    result.Add(search[i]._name);
                    found = true;
                }
                else if (found == true)
                    break;
            }

            if (result.Count == 0)
                result.Add(info[0]._name);

            return result;
        }

        public static List<string> DescOf(uint value)
        {
            List<string> result = new List<string>();
            List<PPCOpCodeInfo> search = info;

            uint compare = 0xFC000000;

            if ((value & 0xFC000000) == grp4C)
                search = info4C;

            if ((value & 0xFC000000) == grp7C)
                search = info7C;

            if ((value & 0xFC000000) == grp4C || (value & 0xFC000000) == grp7C)
                compare = 0x7FE;

            bool found = false;
            for (int i = 0; i < search.Count; i++)
            {
                if ((value & compare) == search[i]._id)
                {
                    result.Add(search[i]._description);
                    found = true;
                }
                else if (found == true)
                    break;
            }

            if (result.Count == 0)
                result.Add(info[0]._description);

            return result;
        }
    }
}