using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Graphics;
using BrawlLib.Imaging;
using BrawlLib.OpenGL;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MDL0ShaderNode : MDL0EntryNode
    {
        internal MDL0Shader* Header { get { return (MDL0Shader*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.MDL0Shader; } }

        //Konstant Alpha Selection Swap table
        KSelSwapBlock _swapBlock = KSelSwapBlock.Default;

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap0Red { get { return (ColorChannel)_swapBlock._Value01.XRB; } set { _swapBlock._Value01.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap0Green { get { return (ColorChannel)_swapBlock._Value01.XGA; } set { _swapBlock._Value01.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap0Blue { get { return (ColorChannel)_swapBlock._Value03.XRB; } set { _swapBlock._Value03.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap0Alpha { get { return (ColorChannel)_swapBlock._Value03.XGA; } set { _swapBlock._Value03.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap1Red { get { return (ColorChannel)_swapBlock._Value05.XRB; } set { _swapBlock._Value05.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap1Green { get { return (ColorChannel)_swapBlock._Value05.XGA; } set { _swapBlock._Value05.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap1Blue { get { return (ColorChannel)_swapBlock._Value07.XRB; } set { _swapBlock._Value07.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap1Alpha { get { return (ColorChannel)_swapBlock._Value07.XGA; } set { _swapBlock._Value07.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap2Red { get { return (ColorChannel)_swapBlock._Value09.XRB; } set { _swapBlock._Value09.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap2Green { get { return (ColorChannel)_swapBlock._Value09.XGA; } set { _swapBlock._Value09.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap2Blue { get { return (ColorChannel)_swapBlock._Value11.XRB; } set { _swapBlock._Value11.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap2Alpha { get { return (ColorChannel)_swapBlock._Value11.XGA; } set { _swapBlock._Value11.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap3Red { get { return (ColorChannel)_swapBlock._Value13.XRB; } set { _swapBlock._Value13.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap3Green { get { return (ColorChannel)_swapBlock._Value13.XGA; } set { _swapBlock._Value13.XGA = (int)value; SignalPropertyChange(); } }

        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap3Blue { get { return (ColorChannel)_swapBlock._Value15.XRB; } set { _swapBlock._Value15.XRB = (int)value; SignalPropertyChange(); } }
        [Category("Swap Mode Table"), Browsable(true)]
        public ColorChannel Swap3Alpha { get { return (ColorChannel)_swapBlock._Value15.XGA; } set { _swapBlock._Value15.XGA = (int)value; SignalPropertyChange(); } }

        //Used by Alpha Env to retrieve what values to swap
        public string[] swapModeTable = new string[4];

        private void BuildSwapModeTable()
        {
	        string swapColors = "rgba";

            //Iterate through the swaps
	        for (int i = 0; i < 4; i++)
	        {
                switch (i)
                {
                    case 0:
                        swapModeTable[i] = new string(new char[] {
                        swapColors[(int)Swap0Red],
                        swapColors[(int)Swap0Green],
                        swapColors[(int)Swap0Blue],
                        swapColors[(int)Swap0Alpha]});
                        break;
                    case 1:
                        swapModeTable[i] = new string(new char[] {
                        swapColors[(int)Swap1Red],
                        swapColors[(int)Swap1Green],
                        swapColors[(int)Swap1Blue],
                        swapColors[(int)Swap1Alpha]});
                        break;
                    case 2:
                        swapModeTable[i] = new string(new char[] {
                        swapColors[(int)Swap2Red],
                        swapColors[(int)Swap2Green],
                        swapColors[(int)Swap2Blue],
                        swapColors[(int)Swap2Alpha]});
                        break;
                    case 3:
                        swapModeTable[i] = new string(new char[] {
                        swapColors[(int)Swap3Red],
                        swapColors[(int)Swap3Green],
                        swapColors[(int)Swap3Blue],
                        swapColors[(int)Swap3Alpha]});
                        break;
                }
	        }
        }

        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexMapID IndTex0MapID { get { return (TexMapID)bi0; } set { bi0 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexCoordID IndTex0Coord { get { return (TexCoordID)bc0; } set { bc0 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexMapID IndTex1MapID { get { return (TexMapID)bi1; } set { bi1 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexCoordID IndTex1Coord { get { return (TexCoordID)bc1; } set { bc1 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexMapID IndTex2MapID { get { return (TexMapID)bi2; } set { bi2 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexCoordID IndTex2Coord { get { return (TexCoordID)bc2; } set { bc2 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexMapID IndTex3MapID { get { return (TexMapID)bi3; } set { bi3 = (int)value; getRawIRef(); } }
        [Category("TEV RAS1 IRef"), Browsable(true)]
        public TexCoordID IndTex3Coord { get { return (TexCoordID)bc3; } set { bc3 = (int)value; getRawIRef(); } }

        public int bc0 = 7, bi0 = 7, bc1 = 7, bi1 = 7, bc2 = 7, bi2 = 7, bc3 = 7, bi3 = 7;

        private void getRawIRef()
        {
            _swapBlock._Value16 = (Int24)RAS1_IRef.Shift(bi0, bc0, bi1, bc1, bi2, bc2, bi3, bc3);
            SignalPropertyChange();
        }
        public void getIRefValues()
        {
            RAS1_IRef _rawIRef = new RAS1_IRef(_swapBlock._Value16);
            bi0 = _rawIRef.TexMap0;
            bc0 = _rawIRef.TexCoord0;
            bi1 = _rawIRef.TexMap1;
            bc1 = _rawIRef.TexCoord1;
            bi2 = _rawIRef.TexMap2;
            bc2 = _rawIRef.TexCoord2;
            bi3 = _rawIRef.TexMap3;
            bc3 = _rawIRef.TexCoord3;
        }

        public MDL0MaterialNode[] Materials { get { return _materials.ToArray(); } }
        public List<MDL0MaterialNode> _materials = new List<MDL0MaterialNode>();

        public sbyte ref0, ref1, ref2, ref3, ref4, ref5, ref6, ref7;
        public byte stages, res0, res1, res2;
        int _datalen, _mdl0offset, pad0, pad1;

        [Category("Shader Data"), Browsable(false)]
        public int DataLength { get { return _datalen; } }
        [Category("Shader Data"), Browsable(false)]
        public int MDL0Offset { get { return _mdl0offset; } }

        [Category("Shader Data"), Browsable(false)]
        public byte Stages { get { return stages; } } //Max 16 (2 stages per group - 8 groups)
        [Browsable(false)]
        public byte STGs 
        { 
            get { return stages; } 
            set 
            { 
                stages = value; 
                SignalPropertyChange();

                foreach (MDL0MaterialNode m in Materials)
                {
                    m.updating = true;
                    m.ActiveShaderStages = value;
                    m.updating = false;
                }
            } 
        }
        
        //[Category("Shader Data"), Browsable(true)]
        //public byte Res0 { get { return res0; } set { res0 = value; SignalPropertyChange(); } }
        //[Category("Shader Data"), Browsable(true)]
        //public byte Res1 { get { return res1; } set { res1 = value; SignalPropertyChange(); } }
        //[Category("Shader Data"), Browsable(true)]
        //public byte Res2 { get { return res2; } set { res2 = value; SignalPropertyChange(); } }

        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef0 { get { return ref0 != -1; } set { ref0 = (sbyte)(value ? 0 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef1 { get { return ref1 != -1; } set { ref1 = (sbyte)(value ? 1 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef2 { get { return ref2 != -1; } set { ref2 = (sbyte)(value ? 2 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef3 { get { return ref3 != -1; } set { ref3 = (sbyte)(value ? 3 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef4 { get { return ref4 != -1; } set { ref4 = (sbyte)(value ? 4 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef5 { get { return ref5 != -1; } set { ref5 = (sbyte)(value ? 5 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef6 { get { return ref6 != -1; } set { ref6 = (sbyte)(value ? 6 : -1); SignalPropertyChange(); } }
        [Category("Shader Data"), Browsable(true)]
        public bool TextureRef7 { get { return ref7 != -1; } set { ref7 = (sbyte)(value ? 7 : -1); SignalPropertyChange(); } }

        //[Category("Shader Data"), Browsable(true)]
        //public int Pad0 { get { return pad0; } }
        //[Category("Shader Data"), Browsable(true)]
        //public int Pad1 { get { return pad1; } }

        public bool _renderUpdate = false;
        public void SignalPropertyChange()
        {
            _renderUpdate = true;
            base.SignalPropertyChange();
        }

        public bool _enabled = true;

        public bool _autoMetal = false;
        public int texCount = -1;
        public bool rendered = false;

        public void Default()
        {
            Name = String.Format("Shader{0}", Index);
            _datalen = 512;
            ref0 =
            ref1 =
            ref2 =
            ref3 =
            ref4 =
            ref5 =
            ref6 =
            ref7 = -1;

            stages = 1;

            TEVStage stage = new TEVStage(Children.Count);
            AddChild(stage, true);
            stage.Default();
        }

        public void DefaultAsMetal(int texcount)
        {
            Name = String.Format("Shader{0}", Index);
            _datalen = 512;
            _autoMetal = true;

            ref0 =
            ref1 =
            ref2 =
            ref3 =
            ref4 =
            ref5 =
            ref6 =
            ref7 = -1;

            switch ((texCount = texcount) - 1)
            {
                case 0: ref0 = 0; break;
                case 1: ref1 = 1; break;
                case 2: ref2 = 2; break;
                case 3: ref3 = 3; break;
                case 4: ref4 = 4; break;
                case 5: ref5 = 5; break;
                case 6: ref6 = 6; break;
                case 7: ref7 = 7; break;
            }

            stages = 4;

            Children.Clear();

            int i = 0;
            TEVStage s;
            while (i++ < 4)
            {
                AddChild(s = new TEVStage(i));
                s.DefaultAsMetal(texcount - 1);
            }
        }

        internal override void GetStrings(StringTable table)
        {
            //We DO NOT want to add the name to the string table!
        }

        protected override bool OnInitialize()
        {
            MDL0Shader* header = Header;

            _datalen = header->_dataLength;
            _mdl0offset = header->_mdl0Offset;

            stages = header->_stages;

            res0 = header->_res0;
            res1 = header->_res1;
            res2 = header->_res2;

            ref0 = header->_ref0;
            ref1 = header->_ref1;
            ref2 = header->_ref2;
            ref3 = header->_ref3;
            ref4 = header->_ref4;
            ref5 = header->_ref5;
            ref6 = header->_ref6;
            ref7 = header->_ref7;

            pad0 = header->_pad0;
            pad1 = header->_pad1;
            
            if (_name == null)
                _name = String.Format("Shader{0}", Index);

            //Attach to materials
            byte* pHeader = (byte*)Header;
            if ((Model != null) && (Model._matList != null))
                foreach (MDL0MaterialNode mat in Model._matList)
                {
                    MDL0Material* mHeader = mat.Header;
                    if (((byte*)mHeader + mHeader->_shaderOffset) == pHeader)
                    {
                        mat._shader = this;
                        _materials.Add(mat);
                    }
                }

            _swapBlock = *header->SwapBlock;
            getIRefValues();

            Populate();
            return true;
        }

        protected override void OnPopulate()
        {
            StageGroup* grp = Header->First;
            int offset = 0x80; //There are 8 groups max
            for (int r = 0; r < 8; r++, grp = grp->Next, offset += 0x30)
                if (((byte*)Header)[offset] == 0x61)
                {
                    TEVStage s0 = new TEVStage(r * 2);

                    KSel KSEL = new KSel(grp->ksel.Data.Value);
                    RAS1_TRef TREF = new RAS1_TRef(grp->tref.Data.Value);

                    s0.rawColEnv = grp->eClrEnv.Data.Value;
                    s0.rawAlphaEnv = grp->eAlpEnv.Data.Value;
                    s0.rawCMD = grp->eCMD.Data.Value;

                    s0.kcsel = KSEL.KCSEL0;
                    s0.kasel = KSEL.KASEL0;

                    s0.ti = TREF.TI0;
                    s0.tc = TREF.TC0;
                    s0.cc = TREF.CC0;
                    s0.te = TREF.TE0;

                    s0.getValues();
                    AddChild(s0, false);

                    if (grp->oClrEnv.Reg == 0x61 && grp->oAlpEnv.Reg == 0x61 && grp->oCMD.Reg == 0x61)
                    {
                        TEVStage s1 = new TEVStage(r * 2 + 1);

                        s1.rawColEnv = grp->oClrEnv.Data.Value;
                        s1.rawAlphaEnv = grp->oAlpEnv.Data.Value;
                        s1.rawCMD = grp->oCMD.Data.Value;

                        s1.kcsel = KSEL.KCSEL1;
                        s1.kasel = KSEL.KASEL1;

                        s1.ti = TREF.TI1;
                        s1.tc = TREF.TC1;
                        s1.cc = TREF.CC1;
                        s1.te = TREF.TE1;

                        s1.getValues();
                        AddChild(s1, false);
                    }
                }
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            MDL0Shader* header = (MDL0Shader*)address;

            if (Model._isImport)
            {
                ref1 =
                ref2 =
                ref3 =
                ref4 =
                ref5 =
                ref6 =
                ref7 = -1;

                if (Model._importOptions._mdlType == 0)
                    stages = 3;
                else
                    stages = 1;
            }

            header->_dataLength = length;
            header->_index = Index;

            header->_stages = Model._isImport ? stages : (byte)Children.Count;

            header->_res0 = 0;
            header->_res1 = 0;
            header->_res2 = 0;

            header->_ref0 = ref0;
            header->_ref1 = ref1;
            header->_ref2 = ref2;
            header->_ref3 = ref3;
            header->_ref4 = ref4;
            header->_ref5 = ref5;
            header->_ref6 = ref6;
            header->_ref7 = ref7;

            header->_pad0 = 0;
            header->_pad1 = 0;

            *header->SwapBlock = _swapBlock;

            StageGroup* grp = (StageGroup*)(address + 0x80);
            for (int i = 0; i < Children.Count; i++)
            {
                TEVStage c = (TEVStage)Children[i]; //Current Stage

                if (i % 2 == 0) //Even Stage
                {
                    *grp = StageGroup.Default;

                    grp->SetGroup(i / 2);
                    grp->SetStage(i);

                    grp->eClrEnv.Data.Value = c.rawColEnv;
                    grp->eAlpEnv.Data.Value = c.rawAlphaEnv;
                    grp->eCMD.Data.Value = c.rawCMD;

                    if (i == Children.Count - 1) //Last stage is even, odd stage isn't used
                    {
                        grp->ksel.Data.Value = KSel.Shift(0, 0, c.kcsel, c.kasel, 0, 0);
                        grp->tref.Data.Value = RAS1_TRef.Shift(c.ti, c.tc, c.te ? 1 : 0, c.cc, 7, 7, 0, 7);
                    }
                }
                else //Odd Stage
                {
                    TEVStage p = (TEVStage)Children[i - 1]; //Previous Stage

                    grp->SetStage(i);

                    grp->oClrEnv.Data.Value = c.rawColEnv;
                    grp->oAlpEnv.Data.Value = c.rawAlphaEnv;
                    grp->oCMD.Data.Value = c.rawCMD;

                    grp->ksel.Data.Value = KSel.Shift(0, 0, p.kcsel, p.kasel, c.kcsel, c.kasel);
                    grp->tref.Data.Value = RAS1_TRef.Shift(p.ti, p.tc, p.te ? 1 : 0, p.cc, c.ti, c.tc, c.te ? 1 : 0, c.cc);

                    grp = grp->Next;
                }
            }

            if (Model._isImport)
            {
                StageGroup* struct0 = header->First;
                *struct0 = StageGroup.Default;
                struct0->SetGroup(0);

                switch (Model._importOptions._mdlType)
                {
                    case 0: //Character

                        struct0->SetStage(0);
                        struct0->SetStage(1);

                        struct0->mask.Data.Value = 0xFFFFF0;
                        struct0->ksel.Data.Value = 0xE378C0;
                        struct0->tref.Data.Value = 0x03F040;
                        struct0->eClrEnv.Data.Value = 0x28F8AF;
                        struct0->oClrEnv.Data.Value = 0x08FEB0;
                        struct0->eAlpEnv.Data.Value = 0x08F2F0;
                        struct0->oAlpEnv.Data.Value = 0x081FF0;

                        StageGroup* struct1 = struct0->Next;
                        *struct1 = StageGroup.Default;

                        struct1->SetGroup(1);
                        struct1->SetStage(2);

                        struct1->mask.Data.Value = 0xFFFFF0;
                        struct1->ksel.Data.Value = 0x0038C0;
                        struct1->tref.Data.Value = 0x3BF3BF;
                        struct1->eClrEnv.Data.Value = 0x0806EF;
                        struct1->eAlpEnv.Data.Value = 0x081FF0;

                        break;

                    case 1: //Stage/Item

                        struct0->SetStage(0);

                        struct0->mask.Data.Value = 0xFFFFF0;
                        struct0->ksel.Data.Value = 0x0038C0;
                        struct0->tref.Data.Value = 0x3BF040;
                        struct0->eClrEnv.Data.Value = 0x28F8AF;
                        struct0->eAlpEnv.Data.Value = 0x08F2F0;

                        break;
                }
            }
        }

        protected override int OnCalculateSize(bool force)
        {
            return 512; //Shaders are always 0x200 in length!
        }

        internal override void Bind(TKContext ctx)
        {
            BuildSwapModeTable();
        }
    }
}
