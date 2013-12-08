﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using BrawlLib.IO;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.OpenGL;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class DataCommonSection : ExternalEntry
    {
        CommonHeader hdr;
        
        [Category("Data Offsets")]
        public int GlobalICBasics { get { return hdr.GlobalICs; } }
        [Category("Data Offsets")]
        public int GlobalICBasicsSSE { get { return hdr.SSEGlobalICs; } }
        [Category("Data Offsets")]
        public int ICBasics { get { return hdr.ICs; } }
        [Category("Data Offsets")]
        public int ICBasicsSSE { get { return hdr.SSEICs; } }
        [Category("Data Offsets")]
        public int EntryActions { get { return hdr.EntryActions; } }
        [Category("Data Offsets")]
        public int ExitActions { get { return hdr.ExitActions; } }
        [Category("Data Offsets")]
        public int FlashOverlaysList { get { return hdr.FlashOverlayArray; } }
        [Category("Data Offsets")]
        public int Unk7 { get { return hdr.Unknown7; } }
        [Category("Data Offsets")]
        public int Unk8 { get { return hdr.Unknown8; } }
        [Category("Data Offsets")]
        public int Unk9 { get { return hdr.Unknown9; } }
        [Category("Data Offsets")]
        public int Unk10 { get { return hdr.Unknown10; } }
        [Category("Data Offsets")]
        public int Unk11 { get { return hdr.Unknown11; } }
        [Category("Data Offsets")]
        public int Unk12 { get { return hdr.Unknown12; } }
        [Category("Data Offsets")]
        public int Unk13 { get { return hdr.Unknown13; } }
        [Category("Data Offsets")]
        public int Unk14 { get { return hdr.Unknown14; } }
        [Category("Data Offsets")]
        public int Unk15 { get { return hdr.Unknown15; } }
        [Category("Data Offsets")]
        public int Unk16 { get { return hdr.Unknown16; } }
        [Category("Data Offsets")]
        public int Unk17 { get { return hdr.Unknown17; } }
        [Category("Data Offsets")]
        public int Unk18 { get { return hdr.Unknown18; } }
        [Category("Data Offsets")]
        public int FlashOverlayOffset { get { return hdr.FlashOverlays; } }
        [Category("Data Offsets")]
        public int ScreenTintOffset { get { return hdr.ScreenTints; } }
        [Category("Data Offsets")]
        public int LegBoneNames { get { return hdr.LegBones; } }
        [Category("Data Offsets")]
        public int Unk22 { get { return hdr.Unknown22; } }
        [Category("Data Offsets")]
        public int Unk23 { get { return hdr.Unknown23; } }
        [Category("Data Offsets")]
        public int Unk24 { get { return hdr.Unknown24; } }
        [Category("Data Offsets")]
        public int Unk25 { get { return hdr.Unknown25; } }
        
        public BindingList<CommonAction> ScreenTints { get { return _screenTints; } }
        public BindingList<CommonAction> FlashOverlays { get { return _flashOverlays; } }
        private BindingList<CommonAction> _flashOverlays, _screenTints;
        public EntryList<CommonUnk7Entry> _unknown7;
        public CommonLegBones _legBones;
        public PatternPowerMul _ppMul;

        public RawParamList _globalICs;
        public RawParamList _globalsseICs;
        public RawParamList _ICs;
        public RawParamList _sseICs;
        
        public override void Parse(VoidPtr address)
        {
            hdr = *(CommonHeader*)address;
            bint* v = (bint*)address;
            int[] sizes = MovesetFile.CalculateSizes(_root._dataSize, v, 26, false);
            ParseScripts(v, sizes);

            //These ICs need to be sorted into int and float arrays
            //Right now they're just a mess of values
            //The indices in the IC variable storage class
            _globalICs = Parse<RawParamList>(v[0], 188);
            _globalsseICs = Parse<RawParamList>(v[1], 188);
            _ICs = Parse<RawParamList>(v[2], 2204);
            _sseICs = Parse<RawParamList>(v[3], 2204);

            //_unknown7 = Parse<EntryList<CommonUnk7Entry>>(v[7], 8);
            _legBones = Parse<CommonLegBones>(v[21]);
            _ppMul = Parse<PatternPowerMul>(v[17]);
        }

        private void ParseScripts(bint* hdr, int[] sizes)
        {
            Script s = null;
            int size, count;
            bint* actionOffset;
            List<List<int>> list;

            //Collect offsets first

            size = sizes[4];
            for (int i = 4; i < 6; i++)
            {
                if (hdr[i] < 0) continue;
                actionOffset = (bint*)Address(hdr[i]);
                for (int x = 0; x < size / 4; x++)
                    _root._scriptOffsets[0][i - 4].Add(actionOffset[x]);
            }
            List<uint> flags1 = new List<uint>(), flags2 = new List<uint>();
            size = _root.GetSize(hdr[6]);
            if (hdr[6] > 0)
            {
                actionOffset = (bint*)Address(hdr[6]);
                for (int x = 0; x < size / 8; x++)
                {
                    _root._scriptOffsets[3][0].Add(actionOffset[x * 2]);
                    flags1.Add((uint)(int)actionOffset[x * 2 + 1]);
                }
            }
            size = _root.GetSize(hdr[20]);
            if (hdr[20] > 0)
            {
                actionOffset = (bint*)Address(hdr[20]);
                for (int x = 0; x < size / 8; x++)
                {
                    _root._scriptOffsets[4][0].Add(actionOffset[x * 2]);
                    flags2.Add((uint)(int)actionOffset[x * 2 + 1]);
                }
            }

            //Now parse scripts

            ActionEntry ag;
            list = _root._scriptOffsets[0];
            count = list[0].Count;
            _root.Actions = new BindingList<ActionEntry>();
            for (int i = 0; i < count; i++)
            {
                _root.Actions.Add(ag = new ActionEntry(new sActionFlags(), i, i));
                for (int x = 0; x < 2; x++)
                {
                    if (i < list[x].Count && list[x][i] > 0)
                        s = Parse<Script>(list[x][i]);
                    else
                        s = new Script();
                    ag.SetWithType(x, s);
                }
            }

            _flashOverlays = new BindingList<CommonAction>();
            _screenTints = new BindingList<CommonAction>();

            CommonAction ca;
            list = _root._scriptOffsets[3];
            count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                if (i < list[0].Count && list[0][i] > 0)
                    ca = Parse<CommonAction>(list[0][i], flags1[i]);
                else
                    ca = new CommonAction(flags1[i]);
                ca._index = i;
                _flashOverlays.Add(ca);
            }
            list = _root._scriptOffsets[4];
            count = list[0].Count;
            for (int i = 0; i < count; i++)
            {
                if (i < list[0].Count && list[0][i] > 0)
                    ca = Parse<CommonAction>(list[0][i], flags2[i]);
                else
                    ca = new CommonAction(flags2[i]);
                ca._index = i;
                _screenTints.Add(ca);
            }
        }

        /*
        public VoidPtr dataHeaderAddr;
        public override void Parse(VoidPtr address)
        {
            #region Populate
            //if (ARCNode.SpecialName.Contains(RootNode.Name))
            //{
                MoveDefGroupNode g;
                List<int> ActionOffsets;

                MoveDefActionListNode actions = new MoveDefActionListNode() { _name = "Action Scripts", _parent = this };

                bint* actionOffset;

                //Parse offsets first
                for (int i = 4; i < 6; i++)
                {
                    actionOffset = (bint*)(BaseAddress + specialOffsets[i].Offset);
                    ActionOffsets = new List<int>();
                    for (int x = 0; x < specialOffsets[i].Size / 4; x++)
                        ActionOffsets.Add(actionOffset[x]);
                    actions.ActionOffsets.Add(ActionOffsets);
                }

                int r = 0;
                foreach (SpecialOffset s in specialOffsets)
                {
                    if (r != 4 && r != 5 && r != 6 && r != 7 && r != 11 && r != 17 && r != 19 && r != 20 && r != 21 && r != 22 && r != 23)
                    {
                        string name = "Params" + r;
                        if (r < 4) name = (r == 0 || r == 2 ? "" : "SSE ") + (r < 2 ? "Global " : "") + "IC-Basics";
                        
                        //Value at 0x64 in Global IC-Basics is not an IC; it is the offset to Unknown32's data.
                        //Value at 0x72C in IC-Basics is not an IC; it is the value of Params24.

                        new RawParamList(r) { _name = name }.Initialize(this, BaseAddress + s.Offset, 0);
                    }
                    r++;
                }

                //Copy list of offset 19?
                //if (specialOffsets[6].Size != 0)
                //    new MoveDefActionsNode("Flash Overlay Actions") { offsetID = 6 }.Initialize(this, BaseAddress + specialOffsets[6].Offset, 0);

                if (specialOffsets[7].Size != 0)
                    new MoveDefCommonUnk7ListNode() { _name = "Unknown7", _offsetID = 7 }.Initialize(this, BaseAddress + specialOffsets[7].Offset, 0);

                if (specialOffsets[11].Size != 0)
                    new MoveDefUnk11Node() { _name = "Unknown11", _offsetID = 11 }.Initialize(this, BaseAddress + specialOffsets[11].Offset, 0);

                if (specialOffsets[19].Size != 0)
                    (_flashOverlay = new MoveDefActionsSkipNode("Flash Overlay Actions") { _offsetID = 19 }).Initialize(this, BaseAddress + specialOffsets[19].Offset, 0);

                if (specialOffsets[20].Size != 0)
                    (_screenTint = new MoveDefActionsSkipNode("Screen Tint Actions") { _offsetID = 20 }).Initialize(this, BaseAddress + specialOffsets[20].Offset, 0);

                if (specialOffsets[21].Size != 0)
                    new MoveDefCommonUnk21Node() { _offsetID = 21 }.Initialize(this, BaseAddress + specialOffsets[21].Offset, 0);

                if (specialOffsets[22].Size != 0)
                    new MoveDefParamListNode() { _name = "Unknown22", _offsetID = 22 }.Initialize(this, BaseAddress + specialOffsets[22].Offset, 0);

                if (specialOffsets[23].Size != 0)
                    new MoveDefParamsOffsetNode() { _name = "Unknown23", _offsetID = 23 }.Initialize(this, BaseAddress + specialOffsets[23].Offset, 0);

                if (specialOffsets[17].Size != 0)
                    new MoveDefPatternPowerMulNode() { _name = "Unknown17", _offsetID = 17 }.Initialize(this, BaseAddress + specialOffsets[17].Offset, 0);

                if (specialOffsets[4].Size != 0 || specialOffsets[5].Size != 0)
                {
                    int count;
                    if (specialOffsets[4].Size == 0)
                        count = specialOffsets[5].Size / 4;
                    else
                        count = specialOffsets[4].Size / 4;

                    //Initialize using first offset so the node is sorted correctly
                    actions.Initialize(this, BaseAddress + specialOffsets[4].Offset, 0);
                    
                    //Set up groups
                    for (int i = 0; i < count; i++)
                        actions.AddChild(new ActionGroup() { _name = "Action" + i }, false);

                    //Add children
                    for (int i = 0; i < 2; i++)
                        if (specialOffsets[i + 4].Size != 0)
                            PopulateActionGroup(actions, actions.ActionOffsets[i], false, i);

                    //Add to children (because the parent was set before initialization)
                    Children.Add(actions);

                    _root._actions = actions;
                }
            //}
            #endregion
        }
         */
    }
    
    public unsafe class CommonLegBones : MovesetEntry
    {
        List<string> _left, _right;
        public override void Parse(VoidPtr address)
        {
            _left = new List<string>();
            _right = new List<string>();

            sListOffset* hdr = (sListOffset*)address;
            bint* addr = (bint*)Address(hdr[0]._startOffset);
            for (int i = 0; i < hdr[0]._listCount; i++)
                _left.Add(new String((sbyte*)(Address(addr[i]))));
            addr = (bint*)Address(hdr[1]._startOffset);
            for (int i = 0; i < hdr[1]._listCount; i++)
                _right.Add(new String((sbyte*)(Address(addr[i]))));
        }
    }

    public unsafe class CommonAction : Script
    {
        public byte Unk1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [TypeConverter(typeof(Bin8StringConverter))]
        public Bin8 Flags { get { return new Bin8(_unk2); } set { _unk2 = (byte)value._data; SignalPropertyChange(); } }
        public byte Unk3 { get { return _unk3; } set { _unk3 = value; SignalPropertyChange(); } }
        public byte Unk4 { get { return _unk4; } set { _unk4 = value; SignalPropertyChange(); } }
        
        public byte _unk1, _unk2, _unk3, _unk4;

        public CommonAction(uint flags)
        {
            _unk1 = (byte)((flags >> 24) & 0xFF);
            _unk2 = (byte)((flags >> 16) & 0xFF);
            _unk3 = (byte)((flags >> 8) & 0xFF);
            _unk4 = (byte)((flags >> 0) & 0xFF);
        }
    }

    public unsafe class CommonUnk7Entry : MovesetEntry
    {
        public List<CommonUnk7EntryListEntry> _children;

        public int unk1, unk2;
        public short unk3, unk4;

        [Category("Unknown 7 Entry")]
        public int DataOffset { get { return unk1; } }
        [Category("Unknown 7 Entry")]
        public int Count { get { return unk2; } }
        [Category("Unknown 7 Entry")]
        public short Unknown1 { get { return unk3; } set { unk3 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public short Unknown2 { get { return unk4; } set { unk4 = value; SignalPropertyChange(); } }

        public override void Parse(VoidPtr address)
        {
            _children = new List<CommonUnk7EntryListEntry>();

            sCommonUnk7Entry* hdr = (sCommonUnk7Entry*)address;
            unk2 = hdr->_list._startOffset;
            unk1 = hdr->_list._listCount;
            unk3 = hdr->_unk3;
            unk4 = hdr->_unk4;
            for (int i = 0; i < Count; i++)
                _children.Add(Parse<CommonUnk7EntryListEntry>(DataOffset + i * 8));
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 12;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;
            sCommonUnk7Entry* data = (sCommonUnk7Entry*)address;
            data->_list._startOffset = unk1;
            data->_list._listCount = _children.Count;
            data->_unk3 = unk3;
            data->_unk4 = unk4;
        }
    }

    public unsafe class CommonUnk7EntryListEntry : MovesetEntry
    {
        public float unk1, unk2;

        [Category("Unknown 7 Entry")]
        public float Unknown1 { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public float Unknown2 { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }

        public override void Parse(VoidPtr address)
        {
            sCommonUnk7EntryListEntry* hdr = (sCommonUnk7EntryListEntry*)address;
            unk1 = hdr->_unk1;
            unk2 = hdr->_unk2;
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 12;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;
            sCommonUnk7EntryListEntry* data = (sCommonUnk7EntryListEntry*)address;
            data->_unk1 = unk1;
            data->_unk2 = unk2;
        }
    }
    /*
    public unsafe class MoveDefActionsSkipNode : MovesetEntry
    {
        internal buint* Header { get { return (buint*)WorkingUncompressed.Address; } }

        internal List<uint> ActionOffsets = new List<uint>();
        internal List<uint> Flags = new List<uint>();

        public MoveDefActionsSkipNode(string name) { _name = name; }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            for (int i = 0; i < WorkingUncompressed.Length / 8; i++)
            {
                ActionOffsets.Add(Header[i * 2]);
                Flags.Add(Header[i * 2 + 1]);
            }
            return true;
        }

        public override void Parse(VoidPtr address)
        {
            int i = 0;
            foreach (int offset in ActionOffsets)
            {
                if (offset > 0)
                    new CommonAction("Action" + i, false, this, Flags[i]).Initialize(this, new DataSource(BaseAddress + offset, 0));
                else
                    Children.Add(new CommonAction("Action" + i, true, this, Flags[i]));

                i++;
            }
        }
    }

    public unsafe class MoveDefParamsOffsetNode : MoveDefCharSpecificNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        internal int i = 0;

        [Category("List Offset")]
        public int DataOffset { get { return Header[0]; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return true;
        }

        public override void Parse(VoidPtr address)
        {
            new RawParamList(0) { _name = "Data" }.Initialize(this, BaseAddress + DataOffset, 168);
        }
    }
    */
}