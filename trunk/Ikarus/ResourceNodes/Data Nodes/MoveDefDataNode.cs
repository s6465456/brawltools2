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
using System.Windows.Forms;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefDataNode : SectionEntry
    {
        public List<SpecialOffset> specialOffsets = new List<SpecialOffset>();
        internal uint DataLen;

        MovesetHeader hdr;

        [Category("Data Offsets")]
        public int SubactionFlagsStart { get { return hdr.SubactionFlagsStart; } }
        [Category("Data Offsets")]
        public int ModelVisibilityStart { get { return hdr.ModelVisibilityStart; } }
        [Category("Data Offsets")]
        public int AttributeStart { get { return hdr.AttributeStart; } }
        [Category("Data Offsets")]
        public int SSEAttributeStart { get { return hdr.SSEAttributeStart; } }
        [Category("Data Offsets")]
        public int MiscSectionOffset { get { return hdr.MiscSectionOffset; } }
        [Category("Data Offsets")]
        public int CommonActionFlagsStart { get { return hdr.CommonActionFlagsStart; } }
        [Category("Data Offsets")]
        public int ActionFlagsStart { get { return hdr.ActionFlagsStart; } }
        [Category("Data Offsets")]
        public int Unknown7 { get { return hdr.Unknown7; } }
        [Category("Data Offsets")]
        public int ActionInterrupts { get { return hdr.ActionInterrupts; } }
        [Category("Data Offsets")]
        public int EntryActionsStart { get { return hdr.EntryActionsStart; } }
        [Category("Data Offsets")]
        public int ExitActionsStart { get { return hdr.ExitActionsStart; } }
        [Category("Data Offsets")]
        public int ActionPreStart { get { return hdr.ActionPreStart; } }
        [Category("Data Offsets")]
        public int SubactionMainStart { get { return hdr.SubactionMainStart; } }
        [Category("Data Offsets")]
        public int SubactionGFXStart { get { return hdr.SubactionGFXStart; } }
        [Category("Data Offsets")]
        public int SubactionSFXStart { get { return hdr.SubactionSFXStart; } }
        [Category("Data Offsets")]
        public int SubactionOtherStart { get { return hdr.SubactionOtherStart; } }
        [Category("Data Offsets")]
        public int BoneFloats1 { get { return hdr.BoneFloats1; } }
        [Category("Data Offsets")]
        public int BoneFloats2 { get { return hdr.BoneFloats2; } }
        [Category("Data Offsets")]
        public int BoneRef1 { get { return hdr.BoneRef1; } }
        [Category("Data Offsets")]
        public int BoneRef2 { get { return hdr.BoneRef2; } }
        [Category("Data Offsets")]
        public int EntryActionOverrides { get { return hdr.EntryActionOverrides; } }
        [Category("Data Offsets")]
        public int ExitActionOverrides { get { return hdr.ExitActionOverrides; } }
        [Category("Data Offsets")]
        public int Unknown22 { get { return hdr.Unknown22; } }
        [Category("Data Offsets")]
        public int BoneFloats3 { get { return hdr.BoneFloats3; } }
        [Category("Data Offsets")]
        public int Unknown24 { get { return hdr.Unknown24; } }
        [Category("Data Offsets")]
        public int StaticArticles { get { return hdr.StaticArticlesStart; } }
        [Category("Data Offsets")]
        public int EntryArticleStart { get { return hdr.EntryArticleStart; } }

        int unk27, unk28, flags2;
        uint flags1;

        //The following aren't offsets 
        [Category("Data Flags")]
        public int Unknown27 { get { return unk27; } set { unk27 = value; SignalPropertyChange(); } }
        [Category("Data Flags")]
        public int Unknown28 { get { return unk28; } set { unk28 = value; SignalPropertyChange(); } }

        [Category("Data Flags"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags1bin { get { return new Bin32(flags1); } set { flags1 = value._data; SignalPropertyChange(); } }
        [Category("Data Flags")]
        public uint Flags1uint { get { return flags1; } set { flags1 = value; SignalPropertyChange(); } }

        [Category("Data Flags"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags2bin { get { return new Bin32((uint)flags2); } set { flags2 = (int)value._data; SignalPropertyChange(); } }
        [Category("Data Flags")]
        public int Flags2int { get { return flags2; } set { flags2 = value; SignalPropertyChange(); } }

        [Category("Special Offsets Node")]
        public SpecialOffset[] Offsets { get { return specialOffsets.ToArray(); } }

        public MoveDefDataNode(uint dataLen, string name) { DataLen = dataLen; _name = name; }

        public MoveDefGroupNode _articleGroup = null;

        public MoveDefFlagsNode _animFlags;
        public MoveDefAttributeNode _attributes, _sseAttributes;
        public MoveDefMiscNode _misc;
        public MoveDefActionOverrideNode _override1;
        public MoveDefActionOverrideNode _override2;
        public MoveDefActionFlagsNode _commonActionFlags, _actionFlags;
        public MoveDefUnk7Node _unk7;
        public MoveDefActionPreNode _actionPre;
        public MoveDefUnk22Node _unk22;
        public MoveDefModelVisibilityNode mdlVisibility;
        public MoveDefItemAnchorListNode boneFloats1, boneFloats2, boneFloats3;
        public MoveDefArticleNode entryArticle;
        public MoveDefStaticArticleGroupNode staticArticles;
        public MoveDefActionInterruptsNode actionInterrupts;
        public MoveDefUnk24Node unk24;
        public MoveDefBoneIndicesNode boneRef1;
        public MoveDefBoneRef2Node boneRef2;

        public List<SubActionGroup> _subActions;

        //Character Specific Nodes
        //Popo
        public MoveDefActionListNode nanaSubActions;
        public MoveDefSoundDatasNode nanaSoundData;
        //ZSS
        public SZerosuitExtraParams8Node zssParams8;
        public int zssFirstOffset = -1;
        //Wario
        public Wario8 warioParams8;
        public Wario6 warioParams6;
        public int warioSwing4StringOffset = -1;

        public List<MoveDefEntry> _extraEntries;
        public SortedList<int, MoveDefEntry> _articles;

        public override bool OnInitialize()
        {
            unk27 = Header->Unknown27;
            unk28 = Header->Unknown28;
            flags1 = Header->Flags1;
            flags2 = Header->Flags2;
            hdr = *Header;
            _extraEntries = new List<MoveDefEntry>();
            _articles = new SortedList<int, MoveDefEntry>();
            
            bint* current = (bint*)Header;
            for (int i = 0; i < 27; i++)
                specialOffsets.Add(new SpecialOffset() { Index = i, Offset = (*(current++) + (i == 2 ? 1 : 0)) });
            CalculateDataLen();

            return true;
        }

        public override void OnPopulate()
        {
            #region Populate
            int commonActionFlagsCount = 0;
            int actionFlagsCount = 0;
            int totalActionCount = 0;
            List<int> ActionOffsets;

            MoveDefActionListNode subActions = new MoveDefActionListNode() { _name = "SubAction Scripts", _parent = this }, actions = new MoveDefActionListNode() { _name = "Action Scripts", _parent = this };

            bint* actionOffset;

            //Parse offsets first
            for (int i = 9; i < 11; i++)
            {
                actionOffset = (bint*)(BaseAddress + specialOffsets[i].Offset);
                ActionOffsets = new List<int>();
                for (int x = 0; x < specialOffsets[i].Size / 4; x++)
                    ActionOffsets.Add(actionOffset[x]);
                actions.ActionOffsets.Add(ActionOffsets);
            }
            for (int i = 12; i < 16; i++)
            {
                actionOffset = (bint*)(BaseAddress + specialOffsets[i].Offset);
                ActionOffsets = new List<int>();
                for (int x = 0; x < specialOffsets[i].Size / 4; x++)
                    ActionOffsets.Add(actionOffset[x]);
                subActions.ActionOffsets.Add(ActionOffsets);
            }

            if (specialOffsets[4].Size != 0)
                (_misc = new MoveDefMiscNode("Misc Section") { _offsetID = 4 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[4].Offset, 0));

            CharFolder character = (CharFolder)(int)_root._character;

            //The only way to compute the amount of extra offsets is broken by PSA.
            //Using the exact amount will work for now until REL editing is available.
            //switch (character)
            //{
            //    case CharFolder.ZakoBall:
            //    case CharFolder.ZakoBoy:
            //    case CharFolder.ZakoGirl:
            //    case CharFolder.ZakoChild:
            //        ExtraDataOffsets._count = 1; break;
            //    case CharFolder.Purin:
            //        ExtraDataOffsets._count = 3; break;
            //    case CharFolder.Koopa:
            //    case CharFolder.Metaknight:
            //        ExtraDataOffsets._count = 5; break;
            //    case CharFolder.Ganon:
            //    case CharFolder.GKoopa:
            //    case CharFolder.Marth:
            //        ExtraDataOffsets._count = 6; break;
            //    case CharFolder.PokeFushigisou:
            //        ExtraDataOffsets._count = 7; break;
            //    case CharFolder.Captain:
            //    case CharFolder.Ike:
            //    case CharFolder.Luigi:
            //    case CharFolder.PokeLizardon:
            //    case CharFolder.PokeTrainer:
            //    case CharFolder.PokeZenigame:
            //    case CharFolder.Sonic:
            //        ExtraDataOffsets._count = 8; break;
            //    case CharFolder.Donkey:
            //    case CharFolder.Sheik:
            //    case CharFolder.WarioMan:
            //        ExtraDataOffsets._count = 9; break;
            //    case CharFolder.Mario:
            //    case CharFolder.Wario:
            //    case CharFolder.Zelda:
            //        ExtraDataOffsets._count = 10; break;
            //    case CharFolder.Falco:
            //    case CharFolder.Lucario:
            //    case CharFolder.Pikachu:
            //        ExtraDataOffsets._count = 11; break;
            //    case CharFolder.SZerosuit:
            //        ExtraDataOffsets._count = 12; break;
            //    case CharFolder.Diddy:
            //    case CharFolder.Fox:
            //    case CharFolder.Lucas:
            //    case CharFolder.Pikmin:
            //    case CharFolder.Pit:
            //    case CharFolder.Wolf:
            //    case CharFolder.Yoshi:
            //        ExtraDataOffsets._count = 13; break;
            //    case CharFolder.Ness:
            //    case CharFolder.Peach:
            //    case CharFolder.Robot:
            //        ExtraDataOffsets._count = 14; break;
            //    case CharFolder.Dedede:
            //    case CharFolder.Gamewatch:
            //        ExtraDataOffsets._count = 16; break;
            //    case CharFolder.Popo:
            //        ExtraDataOffsets._count = 18; break;
            //    case CharFolder.Link:
            //    case CharFolder.Snake:
            //    case CharFolder.ToonLink:
            //        ExtraDataOffsets._count = 20; break;
            //    case CharFolder.Samus:
            //        ExtraDataOffsets._count = 22; break;
            //    case CharFolder.Kirby:
            //        ExtraDataOffsets._count = 68; break;
            //    default: //Only works on movesets untouched by PSA
            //        ExtraDataOffsets._count = (Size - 124) / 4; break;
            //}

            (_attributes = new MoveDefAttributeNode("Attributes") { _offsetID = 2 }).Initialize(this, new DataSource(BaseAddress + 0, 0x2E4));
            (_sseAttributes = new MoveDefAttributeNode("SSE Attributes") { _offsetID = 3 }).Initialize(this, new DataSource(BaseAddress + 0x2E4, 0x2E4));
            if (specialOffsets[5].Size != 0)
                (_commonActionFlags = new MoveDefActionFlagsNode("Common Action Flags", commonActionFlagsCount = ((Unknown7 - CommonActionFlagsStart) / 16)) { _offsetID = 5 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[5].Offset, commonActionFlagsCount * 16));
            if (specialOffsets[6].Size != 0)
                (_actionFlags = new MoveDefActionFlagsNode("Action Flags", actionFlagsCount = ((EntryActionsStart - ActionFlagsStart) / 16)) { _offsetID = 6 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[6].Offset, actionFlagsCount * 16));
            totalActionCount = commonActionFlagsCount + actionFlagsCount;
            if (specialOffsets[7].Size != 0)
                (_unk7 = new MoveDefUnk7Node(totalActionCount) { _offsetID = 7 }).Initialize(this, BaseAddress + specialOffsets[7].Offset, totalActionCount * 8);
            if (specialOffsets[9].Size != 0 || specialOffsets[10].Size != 0)
            {
                int count;
                if (specialOffsets[9].Size == 0)
                    count = specialOffsets[10].Size / 4;
                else
                    count = specialOffsets[9].Size / 4;

                if (_root.GetSize(specialOffsets[10].Offset) != _root.GetSize(specialOffsets[9].Offset))
                    Console.WriteLine(_root.GetSize(specialOffsets[10].Offset) + " " + _root.GetSize(specialOffsets[9].Offset));

                //Initialize using first offset so the node is sorted correctly
                actions.Initialize(this, BaseAddress + specialOffsets[9].Offset, 0);

                //Set up groups
                for (int i = 0; i < count; i++)
                    actions.AddChild(new ActionGroup() { _name = "Action" + (i + 274), _offsetID = i }, false);

                //Add children
                for (int i = 0; i < 2; i++)
                    if (specialOffsets[i + 9].Size != 0)
                        PopulateActionGroup(actions, actions.ActionOffsets[i], false, i);

                //Add to children (because the parent was set before initialization)
                Children.Add(actions);

                //actions.Children.Sort(MoveDefEntryNode.ActionCompare);

                _root._actions = actions;
            }
            if (specialOffsets[11].Size != 0)
                (_actionPre = new MoveDefActionPreNode(totalActionCount)).Initialize(this, new DataSource(BaseAddress + specialOffsets[11].Offset, totalActionCount * 4));
            if (specialOffsets[0].Size != 0)
                (_animFlags = new MoveDefFlagsNode() { _offsetID = 0, _parent = this }).Initialize(this, BaseAddress + specialOffsets[0].Offset, specialOffsets[0].Size);
            if (specialOffsets[12].Size != 0 || specialOffsets[13].Size != 0 || specialOffsets[14].Size != 0 || specialOffsets[15].Size != 0)
            {
                string name;
                int count = 0;
                for (int i = 0; i < 4; i++)
                    if (specialOffsets[i + 12].Size != 0)
                    {
                        count = specialOffsets[i + 12].Size / 4;
                        break;
                    }

                //Initialize using first offset so the node is sorted correctly
                subActions.Initialize(this, BaseAddress + specialOffsets[12].Offset, 0);

                //Set up groups
                for (int i = 0; i < count; i++)
                {
                    if (_animFlags._names.Count > i && _animFlags._flags[i]._stringOffset > 0)
                        name = _animFlags._names[i];
                    else
                        name = "<null>";
                    subActions.AddChild(new SubActionGroup() { _name = name, _flags = _animFlags._flags[i]._Flags, _inTransTime = _animFlags._flags[i]._InTranslationTime }, false);
                }

                //Add children
                for (int i = 0; i < 4; i++)
                    if (specialOffsets[i + 12].Size != 0)
                        PopulateActionGroup(subActions, subActions.ActionOffsets[i], true, i);

                //Add to children (because the parent was set before initialization)
                Children.Add(subActions);

                _root._subActions = subActions;
            }
            if (specialOffsets[1].Size != 0)
                (mdlVisibility = new MoveDefModelVisibilityNode() { _offsetID = 1 }).Initialize(this, BaseAddress + specialOffsets[1].Offset, 0);
            if (specialOffsets[19].Size != 0)
                (boneRef2 = new MoveDefBoneRef2Node() { _offsetID = 19 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[19].Offset, 0));
            if (specialOffsets[24].Size != 0)
                (unk24 = new MoveDefUnk24Node() { _offsetID = 24 }).Initialize(this, BaseAddress + specialOffsets[24].Offset, 8);
            if (specialOffsets[22].Size != 0)
                (_unk22 = new MoveDefUnk22Node() { _offsetID = 22 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[22].Offset, 0));
            if (specialOffsets[25].Size != 0)
                (staticArticles = new MoveDefStaticArticleGroupNode() { _name = "Static Articles", _offsetID = 25 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[25].Offset, 8));
            if (specialOffsets[26].Size != 0)
                (entryArticle = new MoveDefArticleNode() { Static = true, _name = "Entry Article", _offsetID = 26 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[26].Offset, 0));
            if (specialOffsets[8].Size != 0)
                (actionInterrupts = new MoveDefActionInterruptsNode() { _offsetID = 8 }).Initialize(this, BaseAddress + specialOffsets[8].Offset, 8);
            if (specialOffsets[16].Size != 0)
                (boneFloats1 = new MoveDefItemAnchorListNode() { _name = "Anchored Item Placements", _offsetID = 16 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[16].Offset, 0));
            if (specialOffsets[17].Size != 0)
                (boneFloats2 = new MoveDefItemAnchorListNode() { _name = "Gooey Bomb Placements", _offsetID = 17 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[17].Offset, 0));
            if (specialOffsets[23].Size != 0)
                (boneFloats3 = new MoveDefItemAnchorListNode() { _name = "Bone Floats 3", _offsetID = 23 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[23].Offset, 0));
            if (specialOffsets[18].Size != 0)
                (boneRef1 = new MoveDefBoneIndicesNode("Bone References", (_misc.BoneRefOffset - specialOffsets[18].Offset) / 4) { _offsetID = 18 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[18].Offset, 0));
            if (specialOffsets[20].Size != 0)
                (_override1 = new MoveDefActionOverrideNode() { _offsetID = 20 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[20].Offset, 0));
            if (specialOffsets[21].Size != 0)
                (_override2 = new MoveDefActionOverrideNode() { _offsetID = 21 }).Initialize(this, new DataSource(BaseAddress + specialOffsets[21].Offset, 0));

            if (_articleGroup == null)
                AddChild(_articleGroup = new MoveDefGroupNode() { _name = "Articles" });

            ExtraDataOffsets.GetOffsets((CharName)(int)character).Parse(this, Data + 124);

            ////These offsets follow no patterns
            //int y = 0;
            //MoveDefExternalNode ext = null;
            //foreach (int DataOffset in _extraOffsets)
            //{
            //    if (y == 2 && character == CharFolder.poketrainer)
            //    {
            //        MoveDefSoundDatasNode p = new MoveDefSoundDatasNode() { isExtra = true, seperate = true, _name = "Sound Data 2" };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y == 49 && character == CharFolder.kirby)
            //    {
            //        MoveDefKirbyParamList49Node p = new MoveDefKirbyParamList49Node() { isExtra = true, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y == 50 && character == CharFolder.kirby)
            //    {
            //        //6 offsets
            //        //that point to:
            //        //offset
            //        //count
            //        //align to 0x10
            //        //that points to list of:
            //        //offset
            //        //align list to 0x10
            //        //that points to:
            //        //offset
            //        //count
            //        //offset (sometimes 0)
            //        //count (sometimes 0)
            //        //that points to list of:
            //        //offset
            //        //count
            //        //align list to 0x10
            //        //that points to:
            //        //int value
            //    }
            //    else if ((y == 51 || y == 52) && character == CharFolder.kirby)
            //    {
            //        MoveDefKirbyParamList5152Node p = new MoveDefKirbyParamList5152Node() { isExtra = true, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if ((y == 7 && character == CharFolder.pit) || (y == 13 && character == CharFolder.robot))
            //    {
            //        Pit7Robot13Node p = new Pit7Robot13Node() { isExtra = true, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y == 8 && character == CharFolder.lucario)
            //    {
            //        HitDataListOffsetNode p = new HitDataListOffsetNode() { isExtra = true, _name = "HitDataList" + y, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y > 9 && character == CharFolder.yoshi)
            //    {
            //        Yoshi9 p = new Yoshi9() { isExtra = true, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y == 15 && character == CharFolder.dedede)
            //    {
            //        Data2ListNode p = new Data2ListNode() { isExtra = true, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (
            //        (y == 56 && character == CharFolder.kirby) ||
            //        (y == 7 && character == CharFolder.link) ||
            //        (y == 8 && character == CharFolder.peach) ||
            //        (y == 4 && character == CharFolder.pit) ||
            //        (y == 7 && character == CharFolder.toonlink))
            //    {
            //        MoveDefHitDataListNode p = new MoveDefHitDataListNode() { isExtra = true, _name = "HitDataList" + y, offsetID = y };
            //        p.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(p);
            //    }
            //    else if (y == 6 && character == CharFolder.wario)
            //    {
            //        warioParams6 = new Wario6() { isExtra = true, offsetID = y };
            //        warioParams6.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(warioParams6);
            //    }
            //    else if (y == 8 && character == CharFolder.wario)
            //    {
            //        warioParams8 = new Wario8() { isExtra = true, offsetID = y };
            //        warioParams8.Initialize(this, new DataSource(BaseAddress + DataOffset, 0));
            //        _extraEntries.Add(warioParams8);
            //    }
            //    else if (y == 8 && character == CharFolder.szerosuit)
            //    {
            //        (zssParams8 = new SZerosuitExtraParams8Node() { isExtra = true, offsetID = y }).Initialize(this, BaseAddress + DataOffset, 32);
            //        _extraEntries.Add(zssParams8);
            //    }
            //    else if (y < 4 && character == CharFolder.popo)
            //    {
            //        _extraEntries.Add(null);

            //        if (y == 0)
            //            nanaSubActions = new MoveDefActionListNode() { _name = "Nana SubAction Scripts", isExtra = true };

            //        actionOffset = (bint*)(BaseAddress + DataOffset);
            //        ActionOffsets = new List<int>();
            //        for (int x = 0; x < Root.GetSize(DataOffset) / 4; x++)
            //            ActionOffsets.Add(actionOffset[x]);
            //        nanaSubActions.ActionOffsets.Add(ActionOffsets);

            //        if (y == 3)
            //        {
            //            string name;
            //            int count = 0;
            //            for (int i = 0; i < 4; i++)
            //                if ((count = Root.GetSize(DataOffset) / 4) > 0)
            //                    break;

            //            //Initialize using first offset so the node is sorted correctly
            //            nanaSubActions.Initialize(this, BaseAddress + _extraOffsets[0], 0);

            //            //Set up groups
            //            for (int i = 0; i < count; i++)
            //            {
            //                if (_animFlags._names.Count > i && _animFlags._flags[i]._stringOffset > 0)
            //                    name = _animFlags._names[i];
            //                else
            //                    name = "<null>";
            //                nanaSubActions.AddChild(new MoveDefSubActionGroupNode() { _name = name, _flags = _animFlags._flags[i]._Flags, _inTransTime = _animFlags._flags[i]._InTranslationTime }, false);
            //            }

            //            //Add children
            //            for (int i = 0; i < 4; i++)
            //                PopulateActionGroup(nanaSubActions, nanaSubActions.ActionOffsets[i], true, i);
            //        }
            //    }
            //    else if (y == 10 && character == CharFolder.popo)
            //    {
            //        (nanaSoundData = new MoveDefSoundDatasNode() { _name = "Nana Sound Data", isExtra = true }).Initialize(this, (VoidPtr)Header + 124 + y * 4, 8);
            //        _extraEntries.Add(null);
            //    }
            //    else
            //    {
            //        if (DataOffset > Root.dataSize) //probably flags or float
            //            continue;

            //        ext = null;
            //        if (DataOffset > 1480) //I don't think a count would be greater than this
            //        {
            //            MoveDefEntryNode entry = null;
            //            if ((ext = Root.IsExternal(DataOffset)) != null)
            //            {
            //                if (ext.Name.StartsWith("param"))
            //                {
            //                    int o = 0;
            //                    if (y < _extraOffsets.Count - 1 && (o = _extraOffsets[y + 1]) < 1480 && o > 1)
            //                    {
            //                        MoveDefRawDataNode d = new MoveDefRawDataNode("ExtraParams" + y) { offsetID = y, isExtra = true };
            //                        d.Initialize(this, BaseAddress + DataOffset, 0);
            //                        for (int i = 0; i < o; i++)
            //                            new MoveDefSectionParamNode() { _name = "Part" + i, _extOverride = i == 0 }.Initialize(d, BaseAddress + DataOffset + ((d.Size / o) * i), (d.Size / o));
            //                        entry = d;
            //                    }
            //                    else
            //                    {
            //                        MoveDefSectionParamNode p = new MoveDefSectionParamNode() { _name = "ExtraParams" + y, isExtra = true, offsetID = y };
            //                        p.Initialize(this, BaseAddress + DataOffset, 0);
            //                        entry = p;
            //                    }
            //                }
            //                else
            //                {
            //                    Article* test = (Article*)(BaseAddress + DataOffset);
            //                    if (Root.GetSize(DataOffset) < 52 ||
            //                        test->_actionsStart > Root.dataSize || test->_actionsStart % 4 != 0 ||
            //                        test->_subactionFlagsStart > Root.dataSize || test->_subactionFlagsStart % 4 != 0 ||
            //                        test->_subactionGFXStart > Root.dataSize || test->_subactionGFXStart % 4 != 0 ||
            //                        test->_subactionSFXStart > Root.dataSize || test->_subactionSFXStart % 4 != 0 ||
            //                        test->_modelVisibility > Root.dataSize || test->_modelVisibility % 4 != 0 ||
            //                        test->_arcGroup > byte.MaxValue || test->_boneID > short.MaxValue || test->_id > 1480)
            //                    {
            //                        int o = 0;
            //                        if (y < _extraOffsets.Count - 1 && (o = _extraOffsets[y + 1]) < 1480 && o > 1)
            //                        {
            //                            MoveDefRawDataNode d = new MoveDefRawDataNode("ExtraParams" + y) { offsetID = y, isExtra = true };
            //                            d.Initialize(this, BaseAddress + DataOffset, 0);
            //                            for (int i = 0; i < o; i++)
            //                                new MoveDefSectionParamNode() { _name = "Part" + i, _extOverride = i == 0 }.Initialize(d, BaseAddress + DataOffset + ((d.Size / o) * i), (d.Size / o));
            //                            entry = d;
            //                        }
            //                        else
            //                        {
            //                            MoveDefSectionParamNode p = new MoveDefSectionParamNode() { _name = "ExtraParams" + y, isExtra = true, offsetID = y };
            //                            p.Initialize(this, BaseAddress + DataOffset, 0);
            //                            entry = p;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (_articleGroup == null)
            //                        {
            //                            _articleGroup = new MoveDefGroupNode() { _name = "Articles" };
            //                            _articleGroup.Initialize(this, BaseAddress + DataOffset, 0);
            //                        }

            //                        (entry = new MoveDefArticleNode() { offsetID = y, Static = true, isExtra = true, extraOffset = true }).Initialize(_articleGroup, BaseAddress + DataOffset, 0);
            //                        _articles.Add(entry._offset, entry);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                Article* test = (Article*)(BaseAddress + DataOffset);
            //                if (Root.GetSize(DataOffset) < 52 ||
            //                    test->_actionsStart > Root.dataSize || test->_actionsStart % 4 != 0 ||
            //                    test->_subactionFlagsStart > Root.dataSize || test->_subactionFlagsStart % 4 != 0 ||
            //                    test->_subactionGFXStart > Root.dataSize || test->_subactionGFXStart % 4 != 0 ||
            //                    test->_subactionSFXStart > Root.dataSize || test->_subactionSFXStart % 4 != 0 ||
            //                    test->_modelVisibility > Root.dataSize || test->_modelVisibility % 4 != 0 ||
            //                    test->_arcGroup > byte.MaxValue || test->_boneID > short.MaxValue || test->_id > 1480)
            //                {
            //                    int o = 0;
            //                    if (y < _extraOffsets.Count - 1 && (o = _extraOffsets[y + 1]) < 1480 && o > 1)
            //                    {
            //                        MoveDefRawDataNode d = new MoveDefRawDataNode("ExtraParams" + y) { offsetID = y, isExtra = true };
            //                        d.Initialize(this, BaseAddress + DataOffset, 0);
            //                        for (int i = 0; i < o; i++)
            //                            new MoveDefSectionParamNode() { _name = "Part" + i, _extOverride = i == 0 }.Initialize(d, BaseAddress + DataOffset + ((d.Size / o) * i), (d.Size / o));
            //                        entry = d;
            //                    }
            //                    else
            //                    {
            //                        MoveDefSectionParamNode p = new MoveDefSectionParamNode() { _name = "ExtraParams" + y, isExtra = true, offsetID = y };
            //                        p.Initialize(this, BaseAddress + DataOffset, 0);
            //                        entry = p;
            //                    }
            //                }
            //                else
            //                {
            //                    if (_articleGroup == null)
            //                    {
            //                        _articleGroup = new MoveDefGroupNode() { _name = "Articles" };
            //                        _articleGroup.Initialize(this, BaseAddress + DataOffset, 0);
            //                    }

            //                    (entry = new MoveDefArticleNode() { offsetID = y, isExtra = true, Static = true, extraOffset = true }).Initialize(_articleGroup, BaseAddress + DataOffset, 0);
            //                    _articles.Add(entry._offset, entry);
            //                }
            //            }
            //            _extraEntries.Add(entry);
            //        }
            //        else { } //Probably a count
            //    }
            //    y++;
            //}

            _misc.Populate(0);

            //if (_extraEntries.Count > 0)
            //{
            //    if (!Directory.Exists(Application.StartupPath + "/MovesetData/CharSpecific"))
            //        Directory.CreateDirectory(Application.StartupPath + "/MovesetData/CharSpecific");
            //    string events = Application.StartupPath + "/MovesetData/CharSpecific/" + Root.Parent.Name + ".txt";
            //    using (StreamWriter file = new StreamWriter(events))
            //    {
            //        foreach (MoveDefEntryNode e in _extraEntries)
            //        {
            //            if (e is MoveDefSectionParamNode)
            //            {
            //                MoveDefSectionParamNode p = e as MoveDefSectionParamNode;
            //                file.WriteLine(p.Name);
            //                file.WriteLine(p.Name); //Replaced name
            //                foreach (AttributeInfo i in p._info)
            //                {
            //                    file.WriteLine(i._name);
            //                    file.WriteLine(i._description);
            //                    file.WriteLine(i._type == false ? 0 : 1);
            //                    file.WriteLine();
            //                }
            //                file.WriteLine();
            //            }
            //        }
            //    }
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
                {
                    if (sorted[i + 1].Index == 2)
                        sorted[i].Size = (int)((sorted[i + 1].Offset -= 1) - sorted[i].Offset);
                    else
                        sorted[i].Size = (int)(sorted[i + 1].Offset - sorted[i].Offset);
                }
                else sorted[i].Size = (int)(DataLen - sorted[i].Offset);
                //Console.WriteLine(sorted[i].ToString());
            }
        }
        public void PopulateActionGroup(ResourceNode g, List<int> ActionOffsets, bool subactions, int index)
        {
            string name = "";
            if (subactions)
                if (index == 0)
                    name = "Main";
                else if (index == 1)
                    name = "GFX";
                else if (index == 2)
                    name = "SFX";
                else if (index == 3)
                    name = "Other";
                else return;
            else
                if (index == 0)
                    name = "Entry";
                else if (index == 1)
                    name = "Exit";

            int i = 0;
            foreach (int offset in ActionOffsets)
            {
                if (offset > 0)
                    new ActionScript(name, false, g.Children[i]).Initialize(g.Children[i], new DataSource(BaseAddress + offset, 0));
                else
                    g.Children[i].Children.Add(new ActionScript(name, true, g.Children[i]));
                i++;

                if ((subactions && i == _animFlags._names.Count) || i == g.Children.Count)
                    break;
            }
        }

        public FDefSubActionStringTable subActionTable;
        public VoidPtr dataHeaderAddr;
        public int 
            part1Len = 0,
            part2Len = 0,
            part3Len = 0,
            part4Len = 0,
            part5Len = 0,
            part6Len = 0,
            part7Len = 0,
            part8Len = 0;

        public override int OnCalculateSize(bool force)
        {
            zssFirstOffset = warioSwing4StringOffset = -1;
            _entryLength = 124 + ExtraDataOffsets.GetOffsets(_root._character).Count * 4;
            _childLength = MoveDefNode.Builder.CalcDataSize(this);
            return (_entryLength + _childLength);
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            MoveDefNode.Builder.BuildData(this, (MovesetHeader*)dataHeaderAddr, address, length, force);
        }
    }
}