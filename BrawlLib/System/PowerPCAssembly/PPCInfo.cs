using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.PowerPcAssembly
{
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

        #region OpCode Info Initialization
        static PPCInfo()
        {
            #region Regular

            info.Add(new PPCOpCodeInfo(0x00, ".word"));
            info.Add(new PPCOpCodeInfo(0x10, "vaddubm"));
            info.Add(new PPCOpCodeInfo(0x1C, "mulli", "Multiply Load Immediate"));
            info.Add(new PPCOpCodeInfo(0x20, "subfic"));
            info.Add(new PPCOpCodeInfo(0x28, "cmplwi", "Compare Logical (Unsigned) Word Immed"));
            info.Add(new PPCOpCodeInfo(0x28, "cmpldi", "Compare Logical (Unsigned) Double Immed"));
            info.Add(new PPCOpCodeInfo(0x2C, "cmpwi", "Compare Word Immed"));
            info.Add(new PPCOpCodeInfo(0x2C, "cmpdi", "Compare Double Immed"));
            info.Add(new PPCOpCodeInfo(0x30, "addic", "Add Immediate Carrying"));
            info.Add(new PPCOpCodeInfo(0x30, "subic", "Subtract Immediate Carrying"));
            info.Add(new PPCOpCodeInfo(0x34, "addic.", "Add Immediate Carrying Conditional"));
            info.Add(new PPCOpCodeInfo(0x34, "subic.", "Subtract Immediate Carrying Conditional"));
            info.Add(new PPCOpCodeInfo(0x38, "addi", "Add Immediate"));
            info.Add(new PPCOpCodeInfo(0x38, "subi", "Subtract Immediate"));
            info.Add(new PPCOpCodeInfo(0x38, "li", "Load Immediate"));
            info.Add(new PPCOpCodeInfo(0x3C, "addis", "Add Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x3C, "subis", "Subtract Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x3C, "lis", "Load Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x40, "bc"));
            info.Add(new PPCOpCodeInfo(0x40, "bdnz"));
            info.Add(new PPCOpCodeInfo(0x40, "bdz"));
            info.Add(new PPCOpCodeInfo(0x40, "bge"));
            info.Add(new PPCOpCodeInfo(0x40, "blt"));
            info.Add(new PPCOpCodeInfo(0x40, "ble"));
            info.Add(new PPCOpCodeInfo(0x40, "bgt"));
            info.Add(new PPCOpCodeInfo(0x40, "bne"));
            info.Add(new PPCOpCodeInfo(0x40, "beq"));
            info.Add(new PPCOpCodeInfo(0x40, "bns"));
            info.Add(new PPCOpCodeInfo(0x40, "bso"));
            info.Add(new PPCOpCodeInfo(0x48, "b", "Branch: start executing code at the offset."));
            info.Add(new PPCOpCodeInfo(0x50, "rlwimi"));
            info.Add(new PPCOpCodeInfo(0x54, "rlwinm"));
            info.Add(new PPCOpCodeInfo(0x5C, "rlwnm"));
            info.Add(new PPCOpCodeInfo(0x60, "ori", "Logical OR Immediate"));
            info.Add(new PPCOpCodeInfo(0x60, "nop"));
            info.Add(new PPCOpCodeInfo(0x64, "oris", "Logical OR Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x64, "nop"));
            info.Add(new PPCOpCodeInfo(0x68, "xori"));
            info.Add(new PPCOpCodeInfo(0x6C, "xoris"));
            info.Add(new PPCOpCodeInfo(0x70, "andi.", "Logical AND Immediate"));
            info.Add(new PPCOpCodeInfo(0x74, "andis.", "Logical AND Immediate Shifted"));
            info.Add(new PPCOpCodeInfo(0x78, "rldicl"));
            info.Add(new PPCOpCodeInfo(0x80, "lwz", "Load Word and Zero"));
            info.Add(new PPCOpCodeInfo(0x84, "lwzu", "Load Word and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0x88, "lbz", "Load Byte and Zero"));
            info.Add(new PPCOpCodeInfo(0x8C, "lbzu", "Load Byte and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0x90, "stw", "Store Word: src, off(ptr). *(ptr + off) = src."));
            info.Add(new PPCOpCodeInfo(0x94, "stwu", "Store Word with Update"));
            info.Add(new PPCOpCodeInfo(0x98, "stb", "Store Byte"));
            info.Add(new PPCOpCodeInfo(0x9C, "stbu", "Store Byte with Update"));
            info.Add(new PPCOpCodeInfo(0xA0, "lhz", "Load Half and Zero"));
            info.Add(new PPCOpCodeInfo(0xA4, "lhzu", "Load Half and Zero with Update"));
            info.Add(new PPCOpCodeInfo(0xA8, "lha", "Load Half Algebraic"));
            info.Add(new PPCOpCodeInfo(0xAC, "lhau", "Load Half Algebraic with Update"));
            info.Add(new PPCOpCodeInfo(0xB0, "sth", "Store Half"));
            info.Add(new PPCOpCodeInfo(0xB4, "sthu", "Store Half with Update"));
            info.Add(new PPCOpCodeInfo(0xB8, "lmw", "Load Multiple Words"));
            info.Add(new PPCOpCodeInfo(0xBC, "stmw", "Store Multiple Words"));
            info.Add(new PPCOpCodeInfo(0xC0, "lfs", "Load Floating-point Single"));
            info.Add(new PPCOpCodeInfo(0xC4, "lfsu", "Load Floating-point Single and Update"));
            info.Add(new PPCOpCodeInfo(0xC8, "lfd", "Load Floating-point Double"));
            info.Add(new PPCOpCodeInfo(0xCC, "lfdu", "Load Floating-point Double and Update"));
            info.Add(new PPCOpCodeInfo(0xD0, "stfs", "Store Floating-point Single"));
            info.Add(new PPCOpCodeInfo(0xD4, "stfsu", "Store Floating-point Single and Update"));
            info.Add(new PPCOpCodeInfo(0xD8, "stfd", "Store Floating-point Double"));
            info.Add(new PPCOpCodeInfo(0xDC, "stfdu", "Store Floating-point Double and Update"));
            info.Add(new PPCOpCodeInfo(0xE8, "ld", "Load Double"));
            info.Add(new PPCOpCodeInfo(0xF8, "std", "Store Double"));
            info.Add(new PPCOpCodeInfo(0xFC, "fcmpu", "Floating-point Compare with Update"));

            #endregion

            #region 0x4C

            info4C.Add(new PPCOpCodeInfo(0x020, "blr", "Branch on Link Register: returns to the address stored in the link register. Used to end subroutines."));
            info4C.Add(new PPCOpCodeInfo(0x420, "bctr", "Branch on Counter Register: returns to the address stored in the counter register."));

            #endregion

            #region 0x7C

            info7C.Add(new PPCOpCodeInfo(0x194, "addze", "Add to Zero Extended"));
            info7C.Add(new PPCOpCodeInfo(0x1D4, "addme", "Add to Negative One Extended"));
            info7C.Add(new PPCOpCodeInfo(0x2A6, "mfspr", "Move From Special Register: moves a special register value to a register."));
            info7C.Add(new PPCOpCodeInfo(0x278, "xor", "Bit-wise Exclusive OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "or", "Bit-wise OR"));
            info7C.Add(new PPCOpCodeInfo(0x378, "mr", "Move Register: moves data from register to register."));
            info7C.Add(new PPCOpCodeInfo(0x3A6, "mtspr", "Move To Special Register: moves a register value to a special register."));
            info7C.Add(new PPCOpCodeInfo(0x734, "extsh"));
            info7C.Add(new PPCOpCodeInfo(0x734, "extsh."));
            info7C.Add(new PPCOpCodeInfo(0x774, "extsb"));
            info7C.Add(new PPCOpCodeInfo(0x774, "extsb."));
            info7C.Add(new PPCOpCodeInfo(0x034, "cntlzw"));
            info7C.Add(new PPCOpCodeInfo(0x034, "cntlzw."));
            info7C.Add(new PPCOpCodeInfo(0x074, "cntlzd"));
            info7C.Add(new PPCOpCodeInfo(0x074, "cntlzd."));

            #endregion

            #region To do

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
            //info.Add(new PPCOpCodeInfo(0x00000000, "xor", "Exclusive OR"));
            //info.Add(new PPCOpCodeInfo(0x00000000, "xori", "Exclusive OR Immediate"));

            #endregion
        }
        #endregion

        #region OpCode IDs

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

        #region 0x4C
        public const uint grp4C = 0x4C000000;
        public const uint blr = 0x4C000020;
        public const uint bctr = 0x4C000420;
        #endregion

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

        #region 0x7C
        public const uint grp7C = 0x7C000000;
        public const uint slw = 0x7C000030;
        public const uint cntlzw = 0x7C000034;
        public const uint cntlzd = 0x7C000074;
        public const uint addze = 0x7C000194; 
        public const uint addme = 0x7C0001D4;
        public const uint mfspr = 0x7C0002A6;
        public const uint xor = 0x7C000278;
        public const uint or = 0x7C000378;
        public const uint mtspr = 0x7C0003A6;
        public const uint sraw = 0x7C000630;
        public const uint srawi = 0x7C000670;
        public const uint extsh = 0x7C000734;
        public const uint extsb = 0x7C000774;
        #endregion

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
        //public const uint dcbf = new ppcId(31, 86);
        //public const uint dcbi = new ppcId(31, 470);
        //public const uint dcbst = new ppcId(31, 54);
        //public const uint dcbt = new ppcId(31, 278);
        //public const uint dcbtst = new ppcId(31, 246);
        //public const uint dcbz = new ppcId(31, 1014);
        //public const uint dclst = new ppcId(31, 640);
        //public const uint div = new ppcId(31, 331);
        //public const uint divd = new ppcId(31, 489);
        //public const uint divdu = new ppcId(0, 0);
        //public const uint divs = new ppcId(0, 0);
        //public const uint divw = new ppcId(0, 0);
        //public const uint divwu = new ppcId(0, 0);
        //public const uint doz = new ppcId(0, 0);
        //public const uint dozi = new ppcId(0, 0);
        //public const uint eciwx = new ppcId(0, 0);
        //public const uint ecowx = new ppcId(0, 0);
        //public const uint eieio = new ppcId(0, 0);
        //public const uint extsw = new ppcId(0, 0);
        //public const uint eqv = new ppcId(0, 0);
        //public const uint extsb = new ppcId(0, 0);
        //public const uint extsh = new ppcId(0, 0);
        //public const uint fabs = new ppcId(0, 0);
        //public const uint fadd = new ppcId(0, 0);
        //public const uint fcfid = new ppcId(0, 0);
        //public const uint fcmpo = new ppcId(0, 0);
        //public const uint fcmpu = new ppcId(0, 0);
        //public const uint fctid = new ppcId(0, 0);
        //public const uint fctidz = new ppcId(0, 0);
        //public const uint fctiw = new ppcId(0, 0);
        //public const uint fctiwz = new ppcId(0, 0);
        //public const uint fdiv = new ppcId(0, 0);
        //public const uint fmadd = new ppcId(0, 0);
        //public const uint fmr = new ppcId(0, 0);
        //public const uint fmsub = new ppcId(0, 0);
        //public const uint fmul = new ppcId(0, 0);
        //public const uint fnabs = new ppcId(0, 0);
        //public const uint fneg = new ppcId(0, 0);
        //public const uint fnmadd = new ppcId(0, 0);
        //public const uint fnmsub = new ppcId(0, 0);
        //public const uint fres = new ppcId(0, 0);
        //public const uint frsp = new ppcId(0, 0);
        //public const uint frsqrte = new ppcId(0, 0);
        //public const uint fsel = new ppcId(0, 0);
        //public const uint fsqrt = new ppcId(0, 0);
        //public const uint fsqrts = new ppcId(0, 0);
        //public const uint fsub = new ppcId(0, 0);
        //public const uint icbi = new ppcId(0, 0);
        //public const uint isync = new ppcId(0, 0);
        //public const uint lbz = new ppcId(0, 0);
        //public const uint lbzu = new ppcId(0, 0);
        //public const uint lbzux = new ppcId(0, 0);
        //public const uint lbzx = new ppcId(0, 0);
        //public const uint ld = new ppcId(0, 0);
        //public const uint ldarx = new ppcId(0, 0);
        //public const uint ldu = new ppcId(0, 0);
        //public const uint ldux = new ppcId(0, 0);
        //public const uint ldx = new ppcId(0, 0);
        //public const uint lfd = new ppcId(0, 0);
        //public const uint lfdu = new ppcId(0, 0);
        //public const uint lfdux = new ppcId(0, 0);
        //public const uint lfdx = new ppcId(0, 0);
        //public const uint lfq = new ppcId(0, 0);
        //public const uint lfqu = new ppcId(0, 0);
        //public const uint lfqux = new ppcId(0, 0);
        //public const uint lfqx = new ppcId(0, 0);
        //public const uint lfs = new ppcId(0, 0);
        //public const uint lfsu = new ppcId(0, 0);
        //public const uint lfsux = new ppcId(0, 0);
        //public const uint lfsx = new ppcId(0, 0);
        //public const uint lha = new ppcId(0, 0);
        //public const uint lhau = new ppcId(0, 0);
        //public const uint lhaux = new ppcId(0, 0);
        //public const uint lhax = new ppcId(0, 0);
        //public const uint lhbrx = new ppcId(0, 0);
        //public const uint lhz = new ppcId(0, 0);
        //public const uint lhzu = new ppcId(0, 0);
        //public const uint lhzux = new ppcId(0, 0);
        //public const uint lhzx = new ppcId(0, 0);
        //public const uint lmw = new ppcId(0, 0);
        //public const uint lq = new ppcId(0, 0);
        //public const uint lscbx = new ppcId(0, 0);
        //public const uint lswi = new ppcId(0, 0);
        //public const uint lswx = new ppcId(0, 0);
        //public const uint lwa = new ppcId(0, 0);
        //public const uint lwarx = new ppcId(0, 0);
        //public const uint lwaux = new ppcId(0, 0);
        //public const uint lwax = new ppcId(0, 0);
        //public const uint lwbrx = new ppcId(0, 0);
        //public const uint lwz = new ppcId(0, 0);
        //public const uint lwzu = new ppcId(0, 0);
        //public const uint lwzux = new ppcId(0, 0);
        //public const uint lwzx = new ppcId(0, 0);
        //public const uint maskg = new ppcId(0, 0);
        //public const uint maskir = new ppcId(0, 0);
        //public const uint mcrf = new ppcId(0, 0);
        //public const uint mcrfs = new ppcId(0, 0);
        //public const uint mcrxr = new ppcId(0, 0);
        //public const uint mfcr = new ppcId(0, 0);
        //public const uint mffs = new ppcId(0, 0);
        //public const uint mfmsr = new ppcId(0, 0);
        //public const uint mfocrf = new ppcId(0, 0);
        //public const uint mfspr = new ppcId(0, 0);
        //public const uint mfsr = new ppcId(0, 0);
        //public const uint mfsri = new ppcId(0, 0);
        //public const uint mfsrin = new ppcId(0, 0);
        //public const uint mtcrf = new ppcId(0, 0);
        //public const uint mtfsb0 = new ppcId(0, 0);
        //public const uint mtfsb1 = new ppcId(0, 0);
        //public const uint mtfsf = new ppcId(0, 0);
        //public const uint mtfsfi = new ppcId(0, 0);
        //public const uint mtocrf = new ppcId(0, 0);
        //public const uint mtspr = new ppcId(0, 0);
        //public const uint mul = new ppcId(0, 0);
        //public const uint mulhd = new ppcId(0, 0);
        //public const uint mulhdu = new ppcId(0, 0);
        //public const uint mulhw = new ppcId(0, 0);
        //public const uint mulhwu = new ppcId(0, 0);
        //public const uint mulld = new ppcId(0, 0);
        //public const uint mulli = new ppcId(0, 0);
        //public const uint mullw = new ppcId(0, 0);
        //public const uint nabs = new ppcId(0, 0);
        //public const uint nand = new ppcId(0, 0);
        //public const uint neg = new ppcId(0, 0);
        //public const uint nor = new ppcId(0, 0);
        //public const uint or = new ppcId(0, 0);
        //public const uint orc = new ppcId(0, 0);
        //public const uint ori = new ppcId(0, 0);
        //public const uint oris = new ppcId(0, 0);
        //public const uint popcntbd = new ppcId(0, 0);
        //public const uint rac = new ppcId(0, 0);
        //public const uint rfi = new ppcId(0, 0);
        //public const uint rfid = new ppcId(0, 0);
        //public const uint rfsvc = new ppcId(0, 0);
        //public const uint rldcl = new ppcId(0, 0);
        //public const uint rldicl = new ppcId(0, 0);
        //public const uint rldcr = new ppcId(0, 0);
        //public const uint rldic = new ppcId(0, 0);
        //public const uint rldicl = new ppcId(0, 0);
        //public const uint rldicr = new ppcId(0, 0);
        //public const uint rldimi = new ppcId(0, 0);
        //public const uint rlmi = new ppcId(0, 0);
        //public const uint rlwimi = new ppcId(0, 0);
        //public const uint rlwinm = new ppcId(0, 0);
        //public const uint rlwnm = new ppcId(0, 0);
        //public const uint rrib = new ppcId(0, 0);
        //public const uint sc = new ppcId(0, 0);
        //public const uint scv = new ppcId(0, 0);
        //public const uint si = new ppcId(0, 0);
        //public const uint siD = new ppcId(0, 0);
        //public const uint sld = new ppcId(0, 0);
        //public const uint sle = new ppcId(0, 0);
        //public const uint sleq = new ppcId(0, 0);
        //public const uint sliq = new ppcId(0, 0);
        //public const uint slliq = new ppcId(0, 0);
        //public const uint sllq = new ppcId(0, 0);
        //public const uint slq = new ppcId(0, 0);
        //public const uint slw = new ppcId(0, 0);
        //public const uint srad = new ppcId(0, 0);
        //public const uint sradi = new ppcId(0, 0);
        //public const uint sraiq = new ppcId(0, 0);
        //public const uint sraq = new ppcId(0, 0);
        //public const uint sraw = new ppcId(0, 0);
        //public const uint srawi = new ppcId(0, 0);
        //public const uint srd = new ppcId(0, 0);
        //public const uint sre = new ppcId(0, 0);
        //public const uint srea = new ppcId(0, 0);
        //public const uint sreq = new ppcId(0, 0);
        //public const uint sriq = new ppcId(0, 0);
        //public const uint srliq = new ppcId(0, 0);
        //public const uint srlq = new ppcId(0, 0);
        //public const uint srq = new ppcId(0, 0);
        //public const uint srw = new ppcId(0, 0);
        //public const uint stb = new ppcId(0, 0);
        //public const uint stbu = new ppcId(0, 0);
        //public const uint stbux = new ppcId(0, 0);
        //public const uint stbx = new ppcId(0, 0);
        //public const uint std = new ppcId(0, 0);
        //public const uint stdcxD = new ppcId(0, 0);
        //public const uint stdu = new ppcId(0, 0);
        //public const uint stdux = new ppcId(0, 0);
        //public const uint stdx = new ppcId(0, 0);
        //public const uint stfd = new ppcId(0, 0);
        //public const uint stfdu = new ppcId(0, 0);
        //public const uint stfdux = new ppcId(0, 0);
        //public const uint stfdx = new ppcId(0, 0);
        //public const uint stfiwx = new ppcId(0, 0);
        //public const uint stfq = new ppcId(0, 0);
        //public const uint stfqu = new ppcId(0, 0);
        //public const uint stfqux = new ppcId(0, 0);
        //public const uint stfqx = new ppcId(0, 0);
        //public const uint stfs = new ppcId(0, 0);
        //public const uint stfsu = new ppcId(0, 0);
        //public const uint stfsux = new ppcId(0, 0);
        //public const uint stfsx = new ppcId(0, 0);
        //public const uint sth = new ppcId(0, 0);
        //public const uint sthbrx = new ppcId(0, 0);
        //public const uint sthu = new ppcId(0, 0);
        //public const uint sthux = new ppcId(0, 0);
        //public const uint sthx = new ppcId(0, 0);
        //public const uint stmw = new ppcId(0, 0);
        //public const uint stq = new ppcId(0, 0);
        //public const uint stswi = new ppcId(0, 0);
        //public const uint stswx = new ppcId(0, 0);
        //public const uint stw = new ppcId(0, 0);
        //public const uint stwbrx = new ppcId(0, 0);
        //public const uint stwcxD = new ppcId(0, 0);
        //public const uint stwu = new ppcId(0, 0);
        //public const uint stwux = new ppcId(0, 0);
        //public const uint stwx = new ppcId(0, 0);
        //public const uint subf = new ppcId(0, 0);
        //public const uint subfc = new ppcId(0, 0);
        //public const uint subfe = new ppcId(0, 0);
        //public const uint subfic = new ppcId(0, 0);
        //public const uint subfme = new ppcId(0, 0);
        //public const uint subfze = new ppcId(0, 0);
        //public const uint svc = new ppcId(0, 0);
        //public const uint sync = new ppcId(0, 0);
        //public const uint td = new ppcId(0, 0);
        //public const uint tdi = new ppcId(0, 0);
        //public const uint tlbie = new ppcId(0, 0);
        //public const uint tlbld = new ppcId(0, 0);
        //public const uint tlbli = new ppcId(0, 0);
        //public const uint tlbsync = new ppcId(0, 0);
        //public const uint tw = new ppcId(0, 0);
        //public const uint twi = new ppcId(0, 0);
        //public const uint xor = new ppcId(0, 0);
        //public const uint xori = new ppcId(0, 0);

        #endregion

        public static List<PPCOpCodeInfo> InfoFor(uint value)
        {
            List<PPCOpCodeInfo> result = new List<PPCOpCodeInfo>();
            List<PPCOpCodeInfo> search = info;

            uint compare = 0xFC;
            int shift = 24;

            if ((value & 0xFC000000) == grp4C)
            {
                search = info4C;
                compare = 0x7FE;
                shift = 0;
            }

            if ((value & 0xFC000000) == grp7C)
            {
                search = info7C;
                compare = 0x7FE;
                shift = 0;
            }

            bool found = false;
            for (int i = 0; i < search.Count; i++)
            {
                if (((value >> shift) & compare) == search[i]._id)
                {
                    result.Add(search[i]);
                    found = true;
                }
                else if (found == true)
                    break;
            }

            if (result.Count == 0)
                result.Add(info[0]);

            return result;
        }

        public static List<string> NameOf(uint value)
        {
            return InfoFor(value).Select(x => x._name).ToList();
        }

        public static List<string> DescOf(uint value)
        {
            return InfoFor(value).Select(x => x._description).ToList();
        }
    }
}