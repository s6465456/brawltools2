using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.PowerPcAssembly
{
    public abstract unsafe class PPCOpCode
    {
        protected PPCOpCode(uint value) { _data = new PPCData(value); }

        public PPCOpCode Copy() { return (PPCOpCode)this.MemberwiseClone(); }

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
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }
    }

    //  subfic
    public unsafe class OpSubfic : PPCOpCode
    {
        public OpSubfic(uint value)
            : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value            
        }
    }

    //  cmplwi, cmpldi
    public unsafe class OpCmpli : PPCOpCode
    {
        public OpCmpli(uint value)
            : base(value)
        {
            _data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 22, 0x1));                    //  [-] Unknown
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x1));                    //  [-] Is Double
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));               //  [1] Left Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));         //  [2] Immediate Value
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
            _data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 22, 0x1));                    //  [-] Unknown
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x1));                    //  [-] Is Double
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));               //  [1] Left Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));         //  [2] Immediate Value
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
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value      
        }

        bool SetCr { get { return (this & 0xFC000000) == 0x34000000; } }

        public override string FormName()
        {
            if (_data[2] < 0)
                return _names[1];

            return _names[0];
        }

    }

    //  addi, addis, subi, subis, li, lis
    public unsafe class OpAddi : PPCOpCode
    {
        public OpAddi(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool shifted { get { return (this & 0xFC000000) == 0x3C000000; } }

        public override string FormName()
        {
            if (_data[1] != 0)
                if (_data[2] < 0)
                    return _names[1];
                else
                    return _names[0];

            return _names[Math.Min(2, _names.Count - 1)];
        }

        public override string FormOps()
        {
            if (_data[1] == 0)
                //return data.Formal(0) + "," + data.Formal(2);
                return _data.Formal(0) + " = " + _data.Formal(2);

            if (_data.Formal(0) == _data.Formal(1))
            {
                string s = _data.Formal(2);
                if (s.StartsWith("-"))
                    return _data.Formal(0) + " -= " + s;
                else
                    return _data.Formal(0) + " += " + s;
            }
            else
            {
                string s = _data.Formal(2);
                if (s.StartsWith("-"))
                    return _data.Formal(0) + " = " + _data.Formal(1) + " - " + s.Substring(1);
                else
                    return _data.Formal(0) + " = " + _data.Formal(1) + " + " + s;
            }

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
                    return (uint)(baseAddr + _data[0]);
            }
            set
            {
                uint baseAddr = Address;
                if (Absolute) baseAddr = AbsoluteAddr;

                destination = value.RoundDown(4);
                badDestination = false;

                if (destination < baseAddr + MaxDistance && destination >= baseAddr - MaxDistance)
                    _data[0] = (int)destination - (int)baseAddr;
                else
                {
                    badDestination = true;
                    _data[0] = 0;
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
            _data.Add(new OperandLocator(OperandType.Offset, 0, 0x7FFC, 0x8000));   //  [0] Offset
            _data.Add(new OperandLocator(OperandType.ConditionRegister, 18, 0x7));  //  [1] Condition Register
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
                return _names[1 + (CRCNot ? 1 : 0)] + (Not ? "t" : "f") + (_data[0] < 0 ^ Reverse ? "+" : "-");
            else
                return _names[3 + (ValCmpType * 2) + (Not ? 1 : 0)] + (_data[0] < 0 ^ Reverse ? "+" : "-");
        }

        public override string FormOps()
        {
            if (Unknown)
                return "0x" + PPCFormat.Word(this);

            if (Address == 0 && !Absolute)
                return (_data.Formal(1) != "" ? _data.Formal(1) + "," : "") + PPCFormat.SOffset((int)Destination);

            return (_data.Formal(1) != "" ? _data.Formal(1) + "," : "") + PPCFormat.Offset(Destination);
        }
    }

    //  b, bl, ba, bla
    public unsafe class OpB : BranchOpcode
    {
        public OpB(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Offset, 0, 0x3FFFFFC, 0x2000000));    //  [0] Offset
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));                       //  [-] Link
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x2));                       //  [-] Absolute

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
        public OpBlr(uint value) : base(value)
        {

        }
    }

    //  bctr
    public unsafe class OpBctr : PPCOpCode
    {
        public OpBctr(uint value) : base(value)
        {

        }
    }

    //  rlwimi
    public unsafe class OpRlwimi : PPCOpCode
    {
        public OpRlwimi(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 11, 0x1F));          // [2] Roll Left
            _data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));             // [-] Set Cr
        }
    }

    //  rlwinm
    public unsafe class OpRlwinm : PPCOpCode
    {
        public OpRlwinm(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 11, 0x1F));          // [2] Roll Left
            _data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));             // [-] Set Cr
        }
    }

    //  rlwmn
    public unsafe class OpRlwmn : PPCOpCode
    {
        public OpRlwmn(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       // [1] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       // [0] Right Register
            _data.Add(new OperandLocator(OperandType.Register, 11, 0x1F));       // [2] Right Register 2
            _data.Add(new OperandLocator(OperandType.Value, 6, 0x1F));           // [3] NAND Mask
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x3E));           // [4] AND Mask
            //data.Add(new OperandLocator(OperandType.VAL, 0, 0x1));             // [-] Set Cr      
        }
    }

    //  or, xor, mr
    public unsafe class OpOr : PPCOpCode
    {
        public OpOr(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));        //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));        //  [1] Right Register 1
            _data.Add(new OperandLocator(OperandType.Register, 11, 0x1F));        //  [2] Right Register 2
        }

        bool Exclusive { get { return (this & 0x7FE) == 0xA78; } }

        public override string FormName()
        {
            if (!Exclusive)
                if (_data[1] == _data[2])
                    return _names[1];

            return base.FormName();
        }

        public override string FormOps()
        {
            if (!Exclusive)
                if (_data[1] == _data[2])
                    return _data.Formal(0) + "," + _data.Formal(1);

            return base.FormOps();
        }
    }

    //  ori, oris, xori, xoris, nop
    public unsafe class OpOri : PPCOpCode
    {
        public OpOri(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }

        bool Shifted { get { return (this & 0xFC000000) == PPCInfo.oris || (this & 0xFC000000) == PPCInfo.xoris; } }
        bool Exclusive { get { return (this & 0xFC000000) == PPCInfo.xori || (this & 0xFC000000) == PPCInfo.xoris; } }

        public override string FormName()
        {
            if (!Exclusive)
                if (_data[0] == 0 && _data[1] == 0 && _data[2] == 0)
                    return _names[1];

            return base.FormName();
        }

        public override string FormOps()
        {
            if (!Exclusive)
                if (_data[0] == 0 && _data[1] == 0 && _data[2] == 0)
                    return "";

            return base.FormOps();
        }
    }

    //  andi., andis.
    public unsafe class OpAndiSCR : PPCOpCode
    {
        public OpAndiSCR(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value
        }

        bool Shifted { get { return (this & 0xFC000000) == PPCInfo.andis_D; } }
    }

    //  rldicl
    public unsafe class OpRldicl : PPCOpCode
    {
        public OpRldicl(uint value) : base(value)
        {

        }

        public override string FormOps() { return "0x" + PPCFormat.Word(this); }
    }

    //  mfspr
    public unsafe class OpMfspr : PPCOpCode
    {
        public OpMfspr(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));             //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.SpecialRegister, 16, 0x1F));      //  [1] Right Register
        }

        public override string FormOps()
        {
            return _data.Formal(0) + " = " + _data.Formal(1);
        }
    }

    //  mtspr
    public unsafe class OpMtspr : PPCOpCode
    {
        public OpMtspr(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.SpecialRegister, 16, 0x1F));    //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));           //  [1] Right Register
        }

        public override string FormOps()
        {
            return _data.Formal(0) + " = " + _data.Formal(1);
        }
    }

    //  lwz, lwzu, lbz, lbzu, lhz, lhzu, lha, lhau, ld
    public unsafe class OpLwz : PPCOpCode
    {
        public OpLwz(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
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
            return _data.Formal(0) + " = *(" + _data.Formal(1) + " +" + (Update ? "= " : " ") + _data.Formal(2) + ")";
        }
    }

    //  stw, stwu, stb, stbu, sth, sthu, std
    public unsafe class OpStw : PPCOpCode
    {
        public OpStw(uint value)
            : base(value)
        {
            _data.Add(new OperandLocator(OperandType.Register, 21, 0x1F));       //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
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
            if (_data.Formal(2) == "0" || _data.Formal(2) == "-0")
                return _data.Formal(1) + " = " + _data.Formal(0);
            else
            {
                string s = _data.Formal(2);
                if (s.StartsWith("-"))
                    return "*(" + _data.Formal(1) + " - " + s.Substring(1) + ") = " + _data.Formal(0);
                else
                    return "*(" + _data.Formal(1) + " + " + s + ") = " + _data.Formal(0);
            }
        }
    }

    //  lfs, lfsu, lfd, lfdu
    public unsafe class OpLfs : PPCOpCode
    {
        public OpLfs(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.FloatRegister, 21, 0x1F));      //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));           //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000));     //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC0000000) == PPCInfo.lfsu || (this & 0xFC000000) == PPCInfo.lfdu; } }
        bool IsDouble { get { return (this & 0xFC000000) == PPCInfo.lfd || (this & 0xFC000000) == PPCInfo.lfdu; } }

        public override string FormOps()
        {
            return _data.Formal(0) + "," + _data.Formal(2) + "(" + _data.Formal(1) + ")";
        }
    }

    //  stfs, stfsu, stfd, stfdu
    public unsafe class OpStfs : PPCOpCode
    {
        public OpStfs(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.FloatRegister, 21, 0x1F));  //  [0] Left Register
            _data.Add(new OperandLocator(OperandType.Register, 16, 0x1F));       //  [1] Right Register
            _data.Add(new OperandLocator(OperandType.Value, 0, 0x7FFF, 0x8000)); //  [2] Immediate Value 
        }

        bool Update { get { return (this & 0xFC000000) == PPCInfo.stfsu || (this & 0xFC000000) == PPCInfo.stfdu; } }
        bool IsDouble { get { return (this & 0xFC000000) == PPCInfo.stfd || (this & 0xFC000000) == PPCInfo.stfdu; } }

        public override string FormOps()
        {
            return _data.Formal(0) + "," + _data.Formal(2) + "(" + _data.Formal(1) + ")";
        }
    }

    //  fcmpu
    public unsafe class OpFcmpu : PPCOpCode
    {
        public OpFcmpu(uint value) : base(value)
        {
            _data.Add(new OperandLocator(OperandType.ConditionRegister, 23, 0x7));       //  [0] Condition Register
            //data.Add(new OperandLocator(OperandType.VAL, 21, 0x3));                    //  [-] Unknown
            _data.Add(new OperandLocator(OperandType.FloatRegister, 16, 0x1F));          //  [1] Left Register
            _data.Add(new OperandLocator(OperandType.FloatRegister, 11, 0x1F));          //  [2] Right Register
        }
    }

    public enum DataSize { Byte, Half, Word, Double, Undefined }
    public enum OperandType { Value, UnsignedValue, Offset, UnsignedOffset, Register, FloatRegister, ConditionRegister, VRegister, SpecialRegister }
    public struct OperandLocator
    {
        public OperandLocator(OperandType type, int shift, uint bits) : this(type, shift, bits, 0) { }
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

        public PPCData(uint value) { _value = value; }
        public Bin32 _value = 0;

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
                        case 18: return "dsisr";
                        case 19: return "dar";
                        case 22: return "dec";
                        case 25: return "sdr1";
                        case 26: return "srr0";
                        case 27: return "srr1";
                        case 272: return "sprg0";
                        case 273: return "sprg1";
                        case 274: return "sprg2";
                        case 275: return "sprg3";
                        case 282: return "ear";
                        case 284: return "tbl";
                        case 285: return "tbu";
                        case 528: return "ibat0u";
                        case 529: return "ibat0l";
                        case 530: return "ibat1u";
                        case 531: return "ibat1l";
                        case 532: return "ibat2u";
                        case 533: return "ibat2l";
                        case 534: return "ibat3u";
                        case 535: return "ibat3l";
                        case 536: return "dbat0u";
                        case 537: return "dbat0l";
                        case 538: return "dbat1u";
                        case 539: return "dbat1l";
                        case 540: return "dbat2u";
                        case 541: return "dbat2l";
                        case 542: return "dbat3u";
                        case 543: return "dbat3l";
                        default: return "sp" + this[i];
                    }
                default:
                    return "";
            }
        }
    }

    public class ppcId
    {
        public static implicit operator uint(ppcId val) { return val._data; }
        public static implicit operator ppcId(uint val) { return new ppcId(val); }

        public uint Id { get { return _data[26, 6]; } }
        public uint ExtendedId { get { return _data[1, 10]; } }
        
        public Bin32 _data = 0;
        public ppcId() { }
        public ppcId(uint id)
        {
            _data[26, 6] = id;
        }
        public ppcId(uint id, uint extId)
        {
            _data[26, 6] = id;
            _data[1, 10] = extId;
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
            info.Add(new PPCOpCodeInfo(0x80000000, "lwz", "Load Word and Zero"));
            info.Add(new PPCOpCodeInfo(0x84000000, "lwzu", "Load Word and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0x88000000, "lbz", "Load Byte and Zero"));
            info.Add(new PPCOpCodeInfo(0x8C000000, "lbzu", "Load Byte and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0x90000000, "stw", "Store Word: src, off(ptr). *(ptr + off) = src."));
            info.Add(new PPCOpCodeInfo(0x94000000, "stwu", "Store Word with Update"));
            info.Add(new PPCOpCodeInfo(0x98000000, "stb", "Store Byte"));
            info.Add(new PPCOpCodeInfo(0x9C000000, "stbu", "Store Byte with Update"));
            info.Add(new PPCOpCodeInfo(0xA0000000, "lhz", "Load Half and Zero"));
            info.Add(new PPCOpCodeInfo(0xA4000000, "lhzu", "Load Half and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0xA8000000, "lha", "Load Half Algebraic"));
            info.Add(new PPCOpCodeInfo(0xAC000000, "lhau", "Load Half Algebraic with Update"));
            info.Add(new PPCOpCodeInfo(0xB0000000, "sth", "Store Half"));
            info.Add(new PPCOpCodeInfo(0xB4000000, "sthu", "Store Half with Update"));
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
            info.Add(new PPCOpCodeInfo(0xFC000000, "fcmpu", "Floating-point Compare with Update"));

            info4C.Add(new PPCOpCodeInfo(0x020, "blr", "Branch on Link Register: returns to the address stored in the link register. Used to end subroutines."));
            info4C.Add(new PPCOpCodeInfo(0x420, "bctr", "Branch on Counter Register: returns to the address stored in the counter register."));

            info7C.Add(new PPCOpCodeInfo(0x194, "addze", "Add to Zero Extended"));
            info7C.Add(new PPCOpCodeInfo(0x1D4, "addme", "Add to Negative One Extended"));
            info7C.Add(new PPCOpCodeInfo(0x2A6, "mfspr", "Move From Special Register: moves a special register value to a register."));
            info7C.Add(new PPCOpCodeInfo(0x278, "xor", "Bit-wise Exclusive OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "or", "Bit-wise OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "mr", "Move Register: moves data from register to register."));
            info7C.Add(new PPCOpCodeInfo(0x3A6, "mtspr", "Move To Special Register: moves a register value to a special register."));
        
            //info.Add(new PPCOpCodeInfo(0x00000000, "abs", "Absolute"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "add", "Add"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addc", "Add Carrying"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "adde", "Add Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addi", "Add Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addic", "Add Immediate Carrying"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addic.", "Add Immediate Carrying and Record"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addis", "Add Immediate Shifted"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addme", "Add to Minus One Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "addze", "Add to Zero Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "and", "AND"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "andc", "AND with Complement"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "andi.", "AND Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "andis.", "AND Immediate Shifted"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "b", "Branch"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "bc", "Branch Conditional"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "bcctr", "Branch Conditional to Count Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "bclr", "Branch Conditional Link Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "clcs", "Cache Line Compute Size"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "clf", "Cache Line Flush"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cli", "Cache Line Invalidate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cmp", "Compare"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cmpi", "Compare Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cmpl", "Compare Logical"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cmpli", "Compare Logical Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cntlzd", "Count Leading Zeros Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cntlzw", "Count Leading Zeros Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crand", "Condition Register AND"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crandc", "Condition Register AND with Complement"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "creqv", "Condition Register Equivalent"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crnand", "Condition Register NAND"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crnor", "Condition Register NOR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "cror", "Condition Register OR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crorc", "Condition Register OR with Complement"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "crxor", "Condition Register XOR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbf", "Data Cache Block Flush"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbi", "Data Cache Block Invalidate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbst", "Data Cache Block Store"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbt", "Data Cache Block Touch"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbtst", "Data Cache Block Touch for Store"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dcbz", "Data Cache Block Set to Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dclst", "Data Cache Line Store"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "div", "Divide"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "divd", "Divide Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "divdu", "Divide Double Word Unsigned"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "divs", "Divide Short"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "divw", "Divide Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "divwu", "Divide Word Unsigned"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "doz", "Difference or Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "dozi", "Difference or Zero Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "eciwx", "External Control In Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ecowx", "External Control Out Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "eieio", "Enforce In-Order Execution of I/O"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "extsw", "Extend Sign Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "eqv", "Equivalent"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "extsb", "Extend Sign Byte"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "extsh", "Extend Sign Halfword"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fabs", "Floating Absolute Value"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fadd", "Floating Add"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fcfid", "Floating Convert from Integer Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fcmpo", "Floating Compare Ordered"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fcmpu", "Floating Compare Unordered"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fctid", "Floating Convert to Integer Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fctidz", "Floating Convert to Integer Double Word with Round toward Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fctiw", "Floating Convert to Integer Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fctiwz", "Floating Convert to Integer Word with Round to Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fdiv", "Floating Divide"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fmadd", "Floating Multiply-Add"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fmr", "Floating Move Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fmsub", "Floating Multiply-Subtract"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fmul", "Floating Multiply"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fnabs", "Floating Negative Absolute Value"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fneg", "Floating Negate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fnmadd", "Floating Negative Multiply-Add"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fnmsub", "Floating Negative Multiply-Subtract"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fres", "Floating Reciprocal Estimate Single"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "frsp", "Floating Round to Single Precision"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "frsqrte", "Floating Reciprocal Square Root Estimate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fsel", "Floating-Point Select"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fsqrt", "Floating Square Root, Double-Precision"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fsqrts", "Floating Square Root Single"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "fsub", "Floating Subtract"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "icbi", "Instruction Cache Block Invalidate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "isync or ics", "Instruction Synchronize"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lbz", "Load Byte and Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lbzu", "Load Byte and Zero with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lbzux", "Load Byte and Zero with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lbzx", "Load Byte and Zero Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ld", "Load Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ldarx", "Store Double Word Reserve Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ldu", "Store Double Word with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ldux", "Store Double Word with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ldx", "Store Double Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfd", "Load Floating-Point Double"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfdu", "Load Floating-Point Double with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfdux", "Load Floating-Point Double with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfdx", "Load Floating-Point Double-Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfq", "Load Floating-Point Quad"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfqu", "Load Floating-Point Quad with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfqux", "Load Floating-Point Quad with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfqx", "Load Floating-Point Quad Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfs", "Load Floating-Point Single"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfsu", "Load Floating-Point Single with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfsux", "Load Floating-Point Single with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lfsx", "Load Floating-Point Single Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lha", "Load Half Algebraic"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhau", "Load Half Algebraic with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhaux", "Load Half Algebraic with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhax", "Load Half Algebraic Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhbrx", "Load Half Byte-Reverse Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhz", "Load Half and Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhzu", "Load Half and Zero with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhzux", "Load Half and Zero with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lhzx", "Load Half and Zero Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lmw", "Load Multiple Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lq", "Load Quad Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lscbx", "Load String and Compare Byte Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lswi", "Load String Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lswx", "Load String Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwa", "Load Word Algebraic"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwarx", "Load Word and Reserve Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwaux", "Load Word Algebraic with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwax", "Load Word Algebraic Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwbrx", "Load Word Byte-Reverse Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwz", "Load Word and Zero"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwzu", "Load Word with Zero Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwzux", "Load Word and Zero with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "lwzx", "Load Word and Zero Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "maskg", "Mask Generate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "maskir", "Mask Insert from Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mcrf", "Move Condition Register Field"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mcrfs", "Move to Condition Register from FPSCR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mcrxr", "Move to Condition Register from XER"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfcr", "Move from Condition Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mffs", "Move from FPSCR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfmsr", "Move from Machine State Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfocrf", "Move from One Condition Register Field"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfspr", "Move from Special-Purpose Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfsr", "Move from Segment Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfsri", "Move from Segment Register Indirect"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mfsrin", "Move from Segment Register Indirect"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtcrf", "Move to Condition Register Fields"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtfsb0", "Move to FPSCR Bit 0"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtfsb1", "Move to FPSCR Bit 1"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtfsf", "Move to FPSCR Fields"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtfsfi", "Move to FPSCR Field Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtocrf", "Move to One Condition Register Field"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mtspr", "Move to Special-Purpose Register"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mul", "Multiply"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulhd", "Multiply High Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulhdu", "Multiply High Double Word Unsigned"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulhw", "Multiply High Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulhwu", "Multiply High Word Unsigned"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulld", "Multiply Low Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mulli or muli", "Multiply Low Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "mullw or muls", "Multiply Low Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "nabs", "Negative Absolute"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "nand", "NAND"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "neg", "Negate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "nor", "NOR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "or", "OR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "orc", "OR with Complement"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "ori", "OR Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "oris", "OR Immediate Shifted"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "popcntbd", "Population Count Byte Doubleword"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rac", "Real Address Compute"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rfi", "Return from Interrupt"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rfid", "Return from Interrupt Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rfsvc", "Return from SVC"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldcl", "Rotate Left Double Word then Clear Left"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldicl", "Rotate Left Double Word Immediate then Clear Left"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldcr", "Rotate Left Double Word then Clear Right"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldic", "Rotate Left Double Word Immediate then Clear"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldicl", "Rotate Left Double Word Immediate then Clear Left"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldicr", "Rotate Left Double Word Immediate then Clear Right"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rldimi", "Rotate Left Double Word Immediate then Mask Insert"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rlmi", "Rotate Left Then Mask Insert"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rlwimi", "Rotate Left Word Immediate Then Mask Insert"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rlwinm", "Rotate Left Word Immediate Then AND with Mask"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rlwnm", "Rotate Left Word Then AND with Mask"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "rrib", "Rotate Right and Insert Bit"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sc", "System Call"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "scv", "System Call Vectored"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "si", "Subtract Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "si.", "Subtract Immediate and Record"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sld", "Shift Left Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sle", "Shift Left Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sleq", "Shift Left Extended with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sliq", "Shift Left Immediate with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "slliq", "Shift Left Long Immediate with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sllq", "Shift Left Long with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "slq", "Shift Left with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "slw", "Shift Left Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srad", "Shift Right Algebraic Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sradi", "Shift Right Algebraic Double Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sraiq", "Shift Right Algebraic Immediate with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sraq", "Shift Right Algebraic with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sraw", "Shift Right Algebraic Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srawi", "Shift Right Algebraic Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srd", "Shift Right Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sre", "Shift Right Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srea", "Shift Right Extended Algebraic"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sreq", "Shift Right Extended with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sriq", "Shift Right Immediate with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srliq", "Shift Right Long Immediate with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srlq", "Shift Right Long with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srq", "Shift Right with MQ"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "srw", "Shift Right Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stb", "Store Byte"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stbu", "Store Byte with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stbux", "Store Byte with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stbx", "Store Byte Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "std", "Store Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stdcx.", "Store Double Word Conditional Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stdu", "Store Double Word with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stdux", "Store Double Word with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stdx", "Store Double Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfd", "Store Floating-Point Double"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfdu", "Store Floating-Point Double with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfdux", "Store Floating-Point Double with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfdx", "Store Floating-Point Double Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfiwx", "Store Floating-Point as Integer Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfq", "Store Floating-Point Quad"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfqu", "Store Floating-Point Quad with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfqux", "Store Floating-Point Quad with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfqx", "Store Floating-Point Quad Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfs", "Store Floating-Point Single"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfsu", "Store Floating-Point Single with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfsux", "Store Floating-Point Single with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stfsx", "Store Floating-Point Single Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sth", "Store Half"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sthbrx", "Store Half Byte-Reverse Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sthu", "Store Half with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sthux", "Store Half with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sthx", "Store Half Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stmw", "Store Multiple Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stq", "Store Quad Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stswi", "Store String Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stswx", "Store String Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stw", "Store"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stwbrx", "Store Word Byte-Reverse Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stwcx.", "Store Word Conditional Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stwu", "Store Word with Update"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stwux", "Store Word with Update Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "stwx", "Store Word Indexed"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subf", "Subtract From"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subfc", "Subtract from Carrying"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subfe", "Subtract from Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subfic", "Subtract from Immediate Carrying"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subfme", "Subtract from Minus One Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "subfze", "Subtract from Zero Extended"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "svc", "Supervisor Call"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "sync", "Synchronize"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "td", "Trap Double Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tdi", "Trap Double Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tlbie or tlbi", "Translation Look-Aside Buffer Invalidate Entry"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tlbld", "Load Data TLB Entry"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tlbli", "Load Instruction TLB Entry"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tlbsync", "Translation Look-Aside Buffer Synchronize"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "tw", "Trap Word"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "twi", "Trap Word Immediate"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "xor", "XOR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "xori", "XOR Immediate"));
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

        //public const uint abs = new ppcId(31, 360);
        //public const uint add = new ppcId(31, 266);
        //public const uint addc = new ppcId(31, 10);
        //public const uint adde = new ppcId(31, 138);
        //public const uint addi = new ppcId(14);
        //public const uint addic = new ppcId(12);
        //public const uint addicD = new ppcId(13);
        //public const uint addis = new ppcId(15);
        //public const uint addme = new ppcId(31, 234);
        //public const uint addze = new ppcId(31, 202);
        //public const uint and = new ppcId(31, 28);
        //public const uint andc = new ppcId(31, 60);
        //public const uint andiD = new ppcId(28);
        //public const uint andisD = new ppcId(29);
        //public const uint b = new ppcId(18);
        //public const uint bc = new ppcId(16);
        //public const uint bcctr = new ppcId(19, 528);
        //public const uint bclr = new ppcId(19, 16);
        //public const uint clcs = new ppcId(31, 531);
        //public const uint clf = new ppcId(31, 118);
        //public const uint cli = new ppcId(31, 502);
        //public const uint cmp = new ppcId(31);
        //public const uint cmpi = new ppcId(11);
        //public const uint cmpl = new ppcId(31, 32);
        //public const uint cmpli = new ppcId(10);
        //public const uint cntlzd = new ppcId(31, 58);
        //public const uint cntlzw = new ppcId(31, 26);
        //public const uint crand = new ppcId(19, 257);
        //public const uint crandc = new ppcId(19, 129);
        //public const uint creqv = new ppcId(19, 289);
        //public const uint crnand = new ppcId(19, 225);
        //public const uint crnor = new ppcId(19, 33);
        //public const uint cror = new ppcId(19, 449);
        //public const uint crorc = new ppcId(19, 417);
        //public const uint crxor = new ppcId(19, 193);
        //public const uint dcbf = new ppcId(19, 16);
        //public const uint dcbi = new ppcId(19, 16);
        //public const uint dcbst = new ppcId(19, 16);
        //public const uint dcbt = new ppcId(19, 16);
        //public const uint dcbtst = new ppcId(19, 16);
        //public const uint dcbz = new ppcId(19, 16);
        //public const uint dclst = new ppcId(19, 16);
        //public const uint div = new ppcId(19, 16);
        //public const uint divd = new ppcId(19, 16);
        //public const uint divdu = new ppcId(19, 16);
        //public const uint divs = new ppcId(19, 16);
        //public const uint divw = new ppcId(19, 16);
        //public const uint divwu = new ppcId(19, 16);
        //public const uint doz = new ppcId(19, 16);
        //public const uint dozi = new ppcId(19, 16);
        //public const uint eciwx = new ppcId(19, 16);
        //public const uint ecowx = new ppcId(19, 16);
        //public const uint eieio = new ppcId(19, 16);
        //public const uint extsw = new ppcId(19, 16);
        //public const uint eqv = new ppcId(19, 16);
        //public const uint extsb = new ppcId(19, 16);
        //public const uint extsh = new ppcId(19, 16);
        //public const uint fabs = new ppcId(19, 16);
        //public const uint fadd = new ppcId(19, 16);
        //public const uint fcfid = new ppcId(19, 16);
        //public const uint fcmpo = new ppcId(19, 16);
        //public const uint fcmpu = new ppcId(19, 16);
        //public const uint fctid = new ppcId(19, 16);
        //public const uint fctidz = new ppcId(19, 16);
        //public const uint fctiw = new ppcId(19, 16);
        //public const uint fctiwz = new ppcId(19, 16);
        //public const uint fdiv = new ppcId(19, 16);
        //public const uint fmadd = new ppcId(19, 16);
        //public const uint fmr = new ppcId(19, 16);
        //public const uint fmsub = new ppcId(19, 16);
        //public const uint fmul = new ppcId(19, 16);
        //public const uint fnabs = new ppcId(19, 16);
        //public const uint fneg = new ppcId(19, 16);
        //public const uint fnmadd = new ppcId(19, 16);
        //public const uint fnmsub = new ppcId(19, 16);
        //public const uint fres = new ppcId(19, 16);
        //public const uint frsp = new ppcId(19, 16);
        //public const uint frsqrte = new ppcId(19, 16);
        //public const uint fsel = new ppcId(19, 16);
        //public const uint fsqrt = new ppcId(19, 16);
        //public const uint fsqrts = new ppcId(19, 16);
        //public const uint fsub = new ppcId(19, 16);
        //public const uint icbi = new ppcId(19, 16);
        //public const uint isync = new ppcId(19, 16);
        //public const uint lbz = new ppcId(19, 16);
        //public const uint lbzu = new ppcId(19, 16);
        //public const uint lbzux = new ppcId(19, 16);
        //public const uint lbzx = new ppcId(19, 16);
        //public const uint ld = new ppcId(19, 16);
        //public const uint ldarx = new ppcId(19, 16);
        //public const uint ldu = new ppcId(19, 16);
        //public const uint ldux = new ppcId(19, 16);
        //public const uint ldx = new ppcId(19, 16);
        //public const uint lfd = new ppcId(19, 16);
        //public const uint lfdu = new ppcId(19, 16);
        //public const uint lfdux = new ppcId(19, 16);
        //public const uint lfdx = new ppcId(19, 16);
        //public const uint lfq = new ppcId(19, 16);
        //public const uint lfqu = new ppcId(19, 16);
        //public const uint lfqux = new ppcId(19, 16);
        //public const uint lfqx = new ppcId(19, 16);
        //public const uint lfs = new ppcId(19, 16);
        //public const uint lfsu = new ppcId(19, 16);
        //public const uint lfsux = new ppcId(19, 16);
        //public const uint lfsx = new ppcId(19, 16);
        //public const uint lha = new ppcId(19, 16);
        //public const uint lhau = new ppcId(19, 16);
        //public const uint lhaux = new ppcId(19, 16);
        //public const uint lhax = new ppcId(19, 16);
        //public const uint lhbrx = new ppcId(19, 16);
        //public const uint lhz = new ppcId(19, 16);
        //public const uint lhzu = new ppcId(19, 16);
        //public const uint lhzux = new ppcId(19, 16);
        //public const uint lhzx = new ppcId(19, 16);
        //public const uint lmw = new ppcId(19, 16);
        //public const uint lq = new ppcId(19, 16);
        //public const uint lscbx = new ppcId(19, 16);
        //public const uint lswi = new ppcId(19, 16);
        //public const uint lswx = new ppcId(19, 16);
        //public const uint lwa = new ppcId(19, 16);
        //public const uint lwarx = new ppcId(19, 16);
        //public const uint lwaux = new ppcId(19, 16);
        //public const uint lwax = new ppcId(19, 16);
        //public const uint lwbrx = new ppcId(19, 16);
        //public const uint lwz = new ppcId(19, 16);
        //public const uint lwzu = new ppcId(19, 16);
        //public const uint lwzux = new ppcId(19, 16);
        //public const uint lwzx = new ppcId(19, 16);
        //public const uint maskg = new ppcId(19, 16);
        //public const uint maskir = new ppcId(19, 16);
        //public const uint mcrf = new ppcId(19, 16);
        //public const uint mcrfs = new ppcId(19, 16);
        //public const uint mcrxr = new ppcId(19, 16);
        //public const uint mfcr = new ppcId(19, 16);
        //public const uint mffs = new ppcId(19, 16);
        //public const uint mfmsr = new ppcId(19, 16);
        //public const uint mfocrf = new ppcId(19, 16);
        //public const uint mfspr = new ppcId(19, 16);
        //public const uint mfsr = new ppcId(19, 16);
        //public const uint mfsri = new ppcId(19, 16);
        //public const uint mfsrin = new ppcId(19, 16);
        //public const uint mtcrf = new ppcId(19, 16);
        //public const uint mtfsb0 = new ppcId(19, 16);
        //public const uint mtfsb1 = new ppcId(19, 16);
        //public const uint mtfsf = new ppcId(19, 16);
        //public const uint mtfsfi = new ppcId(19, 16);
        //public const uint mtocrf = new ppcId(19, 16);
        //public const uint mtspr = new ppcId(19, 16);
        //public const uint mul = new ppcId(19, 16);
        //public const uint mulhd = new ppcId(19, 16);
        //public const uint mulhdu = new ppcId(19, 16);
        //public const uint mulhw = new ppcId(19, 16);
        //public const uint mulhwu = new ppcId(19, 16);
        //public const uint mulld = new ppcId(19, 16);
        //public const uint mulli = new ppcId(19, 16);
        //public const uint mullw = new ppcId(19, 16);
        //public const uint nabs = new ppcId(19, 16);
        //public const uint nand = new ppcId(19, 16);
        //public const uint neg = new ppcId(19, 16);
        //public const uint nor = new ppcId(19, 16);
        //public const uint or = new ppcId(19, 16);
        //public const uint orc = new ppcId(19, 16);
        //public const uint ori = new ppcId(19, 16);
        //public const uint oris = new ppcId(19, 16);
        //public const uint popcntbd = new ppcId(19, 16);
        //public const uint rac = new ppcId(19, 16);
        //public const uint rfi = new ppcId(19, 16);
        //public const uint rfid = new ppcId(19, 16);
        //public const uint rfsvc = new ppcId(19, 16);
        //public const uint rldcl = new ppcId(19, 16);
        //public const uint rldicl = new ppcId(19, 16);
        //public const uint rldcr = new ppcId(19, 16);
        //public const uint rldic = new ppcId(19, 16);
        //public const uint rldicl = new ppcId(19, 16);
        //public const uint rldicr = new ppcId(19, 16);
        //public const uint rldimi = new ppcId(19, 16);
        //public const uint rlmi = new ppcId(19, 16);
        //public const uint rlwimi = new ppcId(19, 16);
        //public const uint rlwinm = new ppcId(19, 16);
        //public const uint rlwnm = new ppcId(19, 16);
        //public const uint rrib = new ppcId(19, 16);
        //public const uint sc = new ppcId(19, 16);
        //public const uint scv = new ppcId(19, 16);
        //public const uint si = new ppcId(19, 16);
        //public const uint siD = new ppcId(19, 16);
        //public const uint sld = new ppcId(19, 16);
        //public const uint sle = new ppcId(19, 16);
        //public const uint sleq = new ppcId(19, 16);
        //public const uint sliq = new ppcId(19, 16);
        //public const uint slliq = new ppcId(19, 16);
        //public const uint sllq = new ppcId(19, 16);
        //public const uint slq = new ppcId(19, 16);
        //public const uint slw = new ppcId(19, 16);
        //public const uint srad = new ppcId(19, 16);
        //public const uint sradi = new ppcId(19, 16);
        //public const uint sraiq = new ppcId(19, 16);
        //public const uint sraq = new ppcId(19, 16);
        //public const uint sraw = new ppcId(19, 16);
        //public const uint srawi = new ppcId(19, 16);
        //public const uint srd = new ppcId(19, 16);
        //public const uint sre = new ppcId(19, 16);
        //public const uint srea = new ppcId(19, 16);
        //public const uint sreq = new ppcId(19, 16);
        //public const uint sriq = new ppcId(19, 16);
        //public const uint srliq = new ppcId(19, 16);
        //public const uint srlq = new ppcId(19, 16);
        //public const uint srq = new ppcId(19, 16);
        //public const uint srw = new ppcId(19, 16);
        //public const uint stb = new ppcId(19, 16);
        //public const uint stbu = new ppcId(19, 16);
        //public const uint stbux = new ppcId(19, 16);
        //public const uint stbx = new ppcId(19, 16);
        //public const uint std = new ppcId(19, 16);
        //public const uint stdcxD = new ppcId(19, 16);
        //public const uint stdu = new ppcId(19, 16);
        //public const uint stdux = new ppcId(19, 16);
        //public const uint stdx = new ppcId(19, 16);
        //public const uint stfd = new ppcId(19, 16);
        //public const uint stfdu = new ppcId(19, 16);
        //public const uint stfdux = new ppcId(19, 16);
        //public const uint stfdx = new ppcId(19, 16);
        //public const uint stfiwx = new ppcId(19, 16);
        //public const uint stfq = new ppcId(19, 16);
        //public const uint stfqu = new ppcId(19, 16);
        //public const uint stfqux = new ppcId(19, 16);
        //public const uint stfqx = new ppcId(19, 16);
        //public const uint stfs = new ppcId(19, 16);
        //public const uint stfsu = new ppcId(19, 16);
        //public const uint stfsux = new ppcId(19, 16);
        //public const uint stfsx = new ppcId(19, 16);
        //public const uint sth = new ppcId(19, 16);
        //public const uint sthbrx = new ppcId(19, 16);
        //public const uint sthu = new ppcId(19, 16);
        //public const uint sthux = new ppcId(19, 16);
        //public const uint sthx = new ppcId(19, 16);
        //public const uint stmw = new ppcId(19, 16);
        //public const uint stq = new ppcId(19, 16);
        //public const uint stswi = new ppcId(19, 16);
        //public const uint stswx = new ppcId(19, 16);
        //public const uint stw = new ppcId(19, 16);
        //public const uint stwbrx = new ppcId(19, 16);
        //public const uint stwcxD = new ppcId(19, 16);
        //public const uint stwu = new ppcId(19, 16);
        //public const uint stwux = new ppcId(19, 16);
        //public const uint stwx = new ppcId(19, 16);
        //public const uint subf = new ppcId(19, 16);
        //public const uint subfc = new ppcId(19, 16);
        //public const uint subfe = new ppcId(19, 16);
        //public const uint subfic = new ppcId(19, 16);
        //public const uint subfme = new ppcId(19, 16);
        //public const uint subfze = new ppcId(19, 16);
        //public const uint svc = new ppcId(19, 16);
        //public const uint sync = new ppcId(19, 16);
        //public const uint td = new ppcId(19, 16);
        //public const uint tdi = new ppcId(19, 16);
        //public const uint tlbie = new ppcId(19, 16);
        //public const uint tlbld = new ppcId(19, 16);
        //public const uint tlbli = new ppcId(19, 16);
        //public const uint tlbsync = new ppcId(19, 16);
        //public const uint tw = new ppcId(19, 16);
        //public const uint twi = new ppcId(19, 16);
        //public const uint xor = new ppcId(19, 16);
        //public const uint xori = new ppcId(19, 16);

        public static List<string> NameOf(uint value)
        {
            List<string> result = new List<string>();
            List<PPCOpCodeInfo> search = info;

            uint compare = 0xFC000000;

            if ((value & 0xFC000000) == grp4C)
            {
                search = info4C;
                compare = 0x7FE;
            }

            if ((value & 0xFC000000) == grp7C)
            {
                search = info7C;
                compare = 0x7FE;
            }

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