using System;
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

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefDataCommonNode : MoveDefEntryNode
    {
        internal CommonMovesetHeader* Header { get { return (CommonMovesetHeader*)WorkingUncompressed.Address; } }

        public List<SpecialOffset> specialOffsets = new List<SpecialOffset>();
        internal uint DataLen;

        [Category("Data Offsets")]
        public int GlobalICBasics { get { return Header->Unknown0; } }
        [Category("Data Offsets")]
        public int GlobalICBasicsSSE { get { return Header->Unknown1; } }
        [Category("Data Offsets")]
        public int ICBasics { get { return Header->Unknown2; } }
        [Category("Data Offsets")]
        public int ICBasicsSSE { get { return Header->Unknown3; } }
        [Category("Data Offsets")]
        public int EntryActions { get { return Header->ActionsStart; } }
        [Category("Data Offsets")]
        public int ExitActions { get { return Header->Actions2Start; } }
        [Category("Data Offsets")]
        public int FlashOverlaysList { get { return Header->Unknown6; } }
        [Category("Data Offsets")]
        public int Unk7 { get { return Header->Unknown7; } }
        [Category("Data Offsets")]
        public int Unk8 { get { return Header->Unknown8; } }
        [Category("Data Offsets")]
        public int Unk9 { get { return Header->Unknown9; } }
        [Category("Data Offsets")]
        public int Unk10 { get { return Header->Unknown10; } }
        [Category("Data Offsets")]
        public int Unk11 { get { return Header->Unknown11; } }
        [Category("Data Offsets")]
        public int Unk12 { get { return Header->Unknown12; } }
        [Category("Data Offsets")]
        public int Unk13 { get { return Header->Unknown13; } }
        [Category("Data Offsets")]
        public int Unk14 { get { return Header->Unknown14; } }
        [Category("Data Offsets")]
        public int Unk15 { get { return Header->Unknown15; } }
        [Category("Data Offsets")]
        public int Unk16 { get { return Header->Unknown16; } }
        [Category("Data Offsets")]
        public int Unk17 { get { return Header->Unknown17; } }
        [Category("Data Offsets")]
        public int RGBAColor { get { return Header->Unknown18; } }
        [Category("Data Offsets")]
        public int FlashOverlays { get { return Header->Unknown19; } }
        [Category("Data Offsets")]
        public int ScreenTints { get { return Header->Unknown20; } }
        [Category("Data Offsets")]
        public int LegBoneNames { get { return Header->Unknown21; } }
        [Category("Data Offsets")]
        public int Unk22 { get { return Header->Unknown22; } }
        [Category("Data Offsets")]
        public int Unk23 { get { return Header->Unknown23; } }
        [Category("Data Offsets")]
        public int Unk24 { get { return Header->Unknown24; } }
        [Category("Data Offsets")]
        public int Unk25 { get { return Header->Unknown25; } }

        [Category("Special Offsets Node")]
        public SpecialOffset[] Offsets { get { return specialOffsets.ToArray(); } }

        public MoveDefDataCommonNode(uint dataLen, string name) { DataLen = dataLen; _name = name; }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            bint* current = (bint*)Header;
            for (int i = 0; i < 25; i++)
                specialOffsets.Add(new SpecialOffset() { Index = i, Offset = *current++ });
            CalculateDataLen();

            return true;
        }
        public VoidPtr dataHeaderAddr;
        protected override void OnPopulate()
        {
            #region Populate
            if (ARCNode.SpecialName.Contains(RootNode.Name))
            {
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

                //unk18 == ColorF4

                /*
                 * 4 -
                 * 5 -
                 * 6 -
                 * 7 -
                 * 11 -
                 * 17 -
                 * 19 -
                 * 20 -
                 * 21 -
                 * 22 -
                */

                int r = 0;
                foreach (SpecialOffset s in specialOffsets)
                {
                    if (r != 4 && r != 5 && r != 6 && r != 7 && r != 11 && r != 17 && r != 19 && r != 20 && r != 21 && r != 22)
                    {
                        string name = "Params" + r;
                        if (r < 4) name = (r == 0 || r == 2 ? "" : "SSE ") + (r < 2 ? "Global " : "") + "IC-Basics";
                        new MoveDefSectionParamNode() { _name = name, offsetID = r }.Initialize(this, BaseAddress + s.Offset, 0);
                    }
                    r++;
                }

                //Copy list of offset 19?
                //if (specialOffsets[6].Size != 0)
                //    new MoveDefActionsNode("Flash Overlay Actions") { offsetID = 6 }.Initialize(this, BaseAddress + specialOffsets[6].Offset, 0);

                if (specialOffsets[7].Size != 0)
                    new MoveDefCommonUnk7ListNode() { _name = "Unknown7", offsetID = 7 }.Initialize(this, BaseAddress + specialOffsets[7].Offset, 0);

                //if (specialOffsets[11].Size != 0)
                //    new MoveDefCommonUnk11Node() { _name = "Unknown11", offsetID = 11 }.Initialize(this, BaseAddress + specialOffsets[11].Offset, 0);

                //if (specialOffsets[19].Size != 0)
                //    new MoveDefActionsSkipNode("Flash Overlay Actions") { offsetID = 19 }.Initialize(this, BaseAddress + specialOffsets[19].Offset, 0);

                //if (specialOffsets[20].Size != 0)
                //    new MoveDefActionsSkipNode("Screen Tint Actions") { offsetID = 20 }.Initialize(this, BaseAddress + specialOffsets[20].Offset, 0);

                if (specialOffsets[21].Size != 0)
                    new MoveDefCommonUnk21Node() { offsetID = 21 }.Initialize(this, BaseAddress + specialOffsets[21].Offset, 0);

                if (specialOffsets[22].Size != 0)
                    new MoveDefParamListNode() { _name = "Unknown22", offsetID = 22 }.Initialize(this, BaseAddress + specialOffsets[22].Offset, 0);

                if (specialOffsets[17].Size != 0)
                    new MoveDefPatternPowerMulNode() { _name = "Unknown17", offsetID = 17 }.Initialize(this, BaseAddress + specialOffsets[17].Offset, 0);

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
                        actions.AddChild(new MoveDefActionGroupNode() { _name = "Action" + i }, false);

                    //Add children
                    for (int i = 0; i < 2; i++)
                        if (specialOffsets[i + 4].Size != 0)
                            PopulateActionGroup(actions, actions.ActionOffsets[i], false, i);

                    //Add to children (because the parent was set before initialization)
                    Children.Add(actions);

                    Root._actions = actions;
                }
            }
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
                    new MoveDefActionNode(innerName, false, g.Children[i]).Initialize(g.Children[i], new DataSource(BaseAddress + offset, 0));
                else
                    g.Children[i].Children.Add(new MoveDefActionNode(innerName, true, g.Children[i]));
                i++;
            }
        }
    }

    public unsafe class MoveDefCommonUnk21Node : MoveDefEntryNode
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

        protected override bool OnInitialize()
        {
            _name = "Leg Bones";
            base.OnInitialize();
            return DataOffset1 > 0 || DataOffset2 > 0;
        }

        protected override void OnPopulate()
        {
            if (DataOffset1 > 0)
                new MoveDefRawDataNode("Left") { offsetID = 0 }.Initialize(this, BaseAddress + DataOffset1, 0);
            if (DataOffset2 > 0)
                new MoveDefRawDataNode("Right") { offsetID = 1 }.Initialize(this, BaseAddress + DataOffset2, 0);

            foreach (MoveDefRawDataNode d in Children)
            {
                bint* addr = (bint*)d.Header;
                for (int i = 0; i < d.Size / 4; i++)
                    new MoveDefRawDataNode(new String((sbyte*)(BaseAddress + addr[i]))).Initialize(d, d.Header + i * 4, 4);
            }
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = Children.Count;
            int size = 24;
            foreach (MoveDefHitDataListNode p in Children)
                if (!p.External)
                    size += p.CalculateSize(true);
            return size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
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
            _entryOffset = addr;
            FDefListOffset* header = (FDefListOffset*)addr;
            foreach (MoveDefHitDataListNode d in Children)
            {
                (&header[d.offsetID])->_listCount = d.Children.Count;
                (&header[d.offsetID])->_startOffset = (int)d._entryOffset - (int)_rebuildBase;
                _lookupOffsets.Add((&header[d.offsetID])->_startOffset.Address - (int)_rebuildBase);
            }
        }
    }

    public unsafe class MoveDefCommonUnk7ListNode : MoveDefEntryNode
    {
        internal FDefCommonUnk7Entry* First { get { return (FDefCommonUnk7Entry*)WorkingUncompressed.Address; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            return Size / 12 > 0;
        }

        protected override void OnPopulate()
        {
            for (int i = 0; i < Size / 12; i++)
                new MoveDefCommonUnk7EntryNode() { _extOverride = true }.Initialize(this, First + i, 12);
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return _entryLength = 12 * Children.Count;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            FDefCommonUnk7Entry* data = (FDefCommonUnk7Entry*)address;
            foreach (MoveDefCommonUnk7EntryNode h in Children)
                h.Rebuild(data++, 12, true);
        }
    }

    public unsafe class MoveDefCommonUnk7EntryNode : MoveDefEntryNode
    {
        internal FDefCommonUnk7Entry* Header { get { return (FDefCommonUnk7Entry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public int unk1, unk2;
        public short unk3, unk4;

        [Category("Unknown 7 Entry")]
        public int Unknown1 { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public int Unknown2 { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public short Unknown3 { get { return unk3; } set { unk3 = value; SignalPropertyChange(); } }
        [Category("Unknown 7 Entry")]
        public short Unknown4 { get { return unk4; } set { unk4 = value; SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            if (_name == null)
                _name = "Entry" + Index;

            unk1 = Header->_unk1;
            unk2 = Header->_unk2;
            unk3 = Header->_unk3;
            unk4 = Header->_unk4;
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 12;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            FDefCommonUnk7Entry* data = (FDefCommonUnk7Entry*)address;
            data->_unk1 = unk1;
            data->_unk2 = unk2;
            data->_unk3 = unk3;
            data->_unk4 = unk4;
        }
    }
}