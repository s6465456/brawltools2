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
    public unsafe class MoveDefDataCommonNode : SectionEntry
    {
        CommonMovesetHeader hdr;
        
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
        public int RGBAColor { get { return hdr.Unknown18; } }
        [Category("Data Offsets")]
        public int FlashOverlays { get { return hdr.Unknown19; } }
        [Category("Data Offsets")]
        public int ScreenTints { get { return hdr.ScreenTints; } }
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

        public List<CommonAction> _flashOverlays, _screenTints;

        public RawParamList _globalICs;
        public RawParamList _globalsseICs;
        public RawParamList _ICs;
        public RawParamList _sseICs;
        
        public override void Parse(VoidPtr address)
        {
            hdr = *(CommonMovesetHeader*)address;
            bint* h = (bint*)address;
            for (int x = 0; x < 27; x++)
            {
                if (h[x] > 0)
                    switch (x)
                    {
                        case 0:
                            _globalICs = Parse<RawParamList>(_root, h[x]);
                            break;
                        case 1:
                            _globalsseICs = Parse<RawParamList>(_root, h[x]);
                            break;
                        case 2:
                            _ICs = Parse<RawParamList>(_root, h[x]);
                            break;
                        case 3:
                            _sseICs = Parse<RawParamList>(_root, h[x]);
                            break;
                        case 4:
                        case 5:
                            int i = x - 4;

                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:

                            break;
                        case 9:

                            break;
                        case 10:

                            break;

                        case 20: //Screen tints

                            break;
                    }
                for (int i = 0; i < WorkingUncompressed.Length / 8; i++)
                {
                    ActionOffsets.Add(h[i * 2]);
                    Flags.Add(h[i * 2 + 1]);
                }
            }
        }

        public VoidPtr dataHeaderAddr;
        public override void OnPopulate()
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

            SortChildren();
        }

        private void CalculateDataLen()
        {
            List<SpecialOffset> sorted = specialOffsets.OrderBy(x => x.Offset).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                if (i < sorted.Count - 1)
                    sorted[i].Size = (int)(sorted[i + 1].Offset - sorted[i].Offset);
                else
                    sorted[i].Size = (int)(DataLen - sorted[i].Offset);

                //Console.WriteLine(sorted[i].ToString());
            }
        }
        public void PopulateActionGroup(ResourceNode g, List<int> ActionOffsets, bool subactions, int index)
        {
            string innerName = "";
            if (subactions)
                if (index == 0)
                    innerName = "Main";
                else if (index == 1)
                    innerName = "GFX";
                else if (index == 2)
                    innerName = "SFX";
                else if (index == 3)
                    innerName = "Other";
                else return;
            else
                if (index == 0)
                    innerName = "Entry";
                else if (index == 1)
                    innerName = "Exit";

            int i = 0;
            foreach (int offset in ActionOffsets)
            {
                //if (i >= g.Children.Count)
                //    if (subactions)
                //        g.Children.Add(new MoveDefSubActionGroupNode() { _name = "Extra" + i, _flags = new AnimationFlags(), _inTransTime = 0, _parent = g });
                //    else
                //        g.Children.Add(new MoveDefGroupNode() { _name = "Extra" + i, _parent = g });

                if (offset > 0)
                    new ActionScript(innerName, false, g.Children[i]).Initialize(g.Children[i], new DataSource(BaseAddress + offset, 0));
                else
                    g.Children[i].Children.Add(new ActionScript(innerName, true, g.Children[i]));
                i++;
            }
        }
    }

    public unsafe class MoveDefCommonUnk21Node : MoveDefEntry
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        internal int i = 0;

        [Category("List Offset")]
        public int DataOffset1 { get { return Header[0]._startOffset; } }
        [Category("List Offset")]
        public int Count1 { get { return Header[0]._listCount; } }
        [Category("List Offset")]
        public int DataOffset2 { get { return Header[1]._startOffset; } }
        [Category("List Offset")]
        public int Count2 { get { return Header[1]._listCount; } }

        public override bool OnInitialize()
        {
            _name = "Leg Bones";
            base.OnInitialize();
            return DataOffset1 > 0 || DataOffset2 > 0;
        }

        public override void OnPopulate()
        {
            if (DataOffset1 > 0)
                new MoveDefRawDataNode("Left") { _offsetID = 0 }.Initialize(this, BaseAddress + DataOffset1, 0);
            if (DataOffset2 > 0)
                new MoveDefRawDataNode("Right") { _offsetID = 1 }.Initialize(this, BaseAddress + DataOffset2, 0);

            foreach (MoveDefRawDataNode d in Children)
            {
                bint* addr = (bint*)d.Header;
                for (int i = 0; i < d.Size / 4; i++)
                    new MoveDefRawDataNode(new String((sbyte*)(BaseAddress + addr[i]))).Initialize(d, d.Header + i * 4, 4);
            }
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = Children.Count;
            int size = 24;
            foreach (MoveDefHitDataListNode p in Children)
                if (!p.External)
                    size += p.CalculateSize(true);
            return size;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;
            foreach (MoveDefHitDataListNode p in Children)
            {
                if (!p.External)
                {
                    p.Rebuild(addr, p._calcSize, true);
                    addr += p._calcSize;
                }
            }
            _rebuildAddr = addr;
            FDefListOffset* header = (FDefListOffset*)addr;
            foreach (MoveDefHitDataListNode d in Children)
            {
                (&header[d._offsetID])->_listCount = d.Children.Count;
                (&header[d._offsetID])->_startOffset = (int)d._rebuildAddr - (int)RebuildBase;
                _lookupOffsets.Add((&header[d._offsetID])->_startOffset.Address);
            }
        }
    }

    public unsafe class MoveDefCommonUnk7ListNode : MoveDefEntry
    {
        internal FDefCommonUnk7Entry* First { get { return (FDefCommonUnk7Entry*)WorkingUncompressed.Address; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return Size / 12 > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Size / 12; i++)
                new MoveDefCommonUnk7EntryNode() { _extOverride = true }.Initialize(this, First + i, 12);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return _entryLength = 12 * Children.Count;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefCommonUnk7Entry* data = (FDefCommonUnk7Entry*)address;
            foreach (MoveDefCommonUnk7EntryNode h in Children)
                h.Rebuild(data++, 12, true);
        }
    }

    public unsafe class MoveDefCommonUnk7EntryNode : MoveDefEntry
    {
        internal FDefCommonUnk7Entry* Header { get { return (FDefCommonUnk7Entry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

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
        
        public override bool OnInitialize()
        {
            base.OnInitialize();

            if (_name == null)
                _name = "Data" + Index;

            unk1 = Header->_list._startOffset;
            unk2 = Header->_list._listCount;
            unk3 = Header->_unk3;
            unk4 = Header->_unk4;
            return DataOffset > 0 && Count > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Count; i++)
                new MoveDefCommonUnk7EntryListEntryNode() { _name = "Entry" + i }.Initialize(this, BaseAddress + DataOffset + i * 8, 8);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 12;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefCommonUnk7Entry* data = (FDefCommonUnk7Entry*)address;
            data->_list._startOffset = unk1;
            data->_list._listCount = Children.Count;
            data->_unk3 = unk3;
            data->_unk4 = unk4;
        }
    }

    public unsafe class MoveDefCommonUnk7EntryListEntryNode : MoveDefEntry
    {
        internal FDefCommonUnk7EntryListEntry* Header { get { return (FDefCommonUnk7EntryListEntry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public float unk1, unk2;

        [Category("Unknown 7 Entry")]
        public float Unknown1 { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public float Unknown2 { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }
        
        public override bool OnInitialize()
        {
            base.OnInitialize();

            if (_name == null)
                _name = "Entry" + Index;

            unk1 = Header->_unk1;
            unk2 = Header->_unk2;
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 12;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefCommonUnk7EntryListEntry* data = (FDefCommonUnk7EntryListEntry*)address;
            data->_unk1 = unk1;
            data->_unk2 = unk2;
        }
    }

    public unsafe class MoveDefUnk11Node : MoveDefEntry
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        internal int i = 0;

        [Category("List Offset")]
        public int DataOffset { get { return Header->_startOffset; } }
        [Category("List Offset")]
        public int Count { get { return Header->_listCount; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return Count > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Count; i++)
                new MoveDefUnk11EntryNode() { _name = "Entry" + i }.Initialize(this, BaseAddress + DataOffset + i * 12, 12);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            _entryLength = 8;
            _childLength = 0;
            foreach (RawParamList p in Children)
                _childLength += p.CalculateSize(true);
            return _entryLength + _childLength;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;
            foreach (RawParamList p in Children)
            {
                p.Rebuild(addr, p._calcSize, true);
                addr += p._calcSize;
            }
            _rebuildAddr = addr;
            FDefListOffset* header = (FDefListOffset*)addr;
            if (Children.Count > 0)
            {
                header->_startOffset = (int)address - (int)RebuildBase;
                _lookupOffsets.Add(header->_startOffset.Address);
            }
            header->_listCount = Children.Count;
        }
    }

    public unsafe class MoveDefUnk11EntryNode : MoveDefEntry
    {
        internal FDefCommonUnk11Entry* Header { get { return (FDefCommonUnk11Entry*)WorkingUncompressed.Address; } }
        internal int unk;

        [Category("List Offset")]
        public int Unknown { get { return unk; } set { unk = value; SignalPropertyChange(); } }
        [Category("List Offset")]
        public int DataOffset { get { return Header->_list._startOffset; } }
        [Category("List Offset")]
        public int Count { get { return Header->_list._listCount; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            unk = Header->_unk1;
            return Count > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Count; i++)
                new MoveDefIndexNode() { _name = "Index" + i }.Initialize(this, BaseAddress + DataOffset + i * 4, 4);
        }
    }

    public unsafe class MoveDefActionsSkipNode : MoveDefEntry
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

        public override void OnPopulate()
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

        public override void OnPopulate()
        {
            new RawParamList(0) { _name = "Data" }.Initialize(this, BaseAddress + DataOffset, 168);
        }
    }

    public unsafe class CommonAction : ActionScript
    {
        public byte Unk1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [TypeConverter(typeof(Bin8StringConverter))]
        public Bin8 Flags { get { return new Bin8(_unk2); } set { _unk2 = (byte)value._data; SignalPropertyChange(); } }
        public byte Unk3 { get { return _unk3; } set { _unk3 = value; SignalPropertyChange(); } }
        public byte Unk4 { get { return _unk4; } set { _unk4 = value; SignalPropertyChange(); } }
        
        public byte _unk1, _unk2, _unk3, _unk4;

        public CommonAction(string name, bool blank, ResourceNode parent, uint flags) : base(name, blank, parent) 
        {
            _unk1 = (byte)((flags >> 24) & 0xFF);
            _unk2 = (byte)((flags >> 16) & 0xFF);
            _unk3 = (byte)((flags >> 8) & 0xFF);
            _unk4 = (byte)((flags >> 0) & 0xFF);
        }
    }
}