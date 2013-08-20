using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using BrawlLib.OpenGL;
using System.Windows.Forms;
using Ikarus;
using OpenTK.Graphics.OpenGL;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefArticleNode : MoveDefEntryNode
    {
        internal Article* Header { get { return (Article*)WorkingUncompressed.Address; } }

        [Browsable(false)]
        public MDL0BoneNode CharBoneNode
        {
            get { if (Root._model == null) return null; if (charBone > Root._model._linker.BoneCache.Length || charBone < 0) return null; return (MDL0BoneNode)Root._model._linker.BoneCache[charBone]; }
            set { charBone = value.BoneIndex; }
        }

        [Browsable(false)]
        public MDL0BoneNode ArticleBoneNode
        {
            get { if (_info == null || _info._model == null) return null; if (articleBone > _info._model._linker.BoneCache.Length || articleBone < 0) return null; return (MDL0BoneNode)_info._model._linker.BoneCache[articleBone]; }
            set { articleBone = value.BoneIndex; }
        }
        
        [Category("Article")]
        public int ID { get { return Index; } }
        [Category("Article")]
        public int ARCGroupID { get { return id; } set { id = value; SignalPropertyChange(); } }
        [Category("Article"), Browsable(true), TypeConverter(typeof(DropDownListBonesMDef))]
        public string ArticleBone { get { return ArticleBoneNode == null ? articleBone.ToString() : ArticleBoneNode.Name; } set { if (Model == null) { articleBone = Convert.ToInt32(value); } else { ArticleBoneNode = String.IsNullOrEmpty(value) ? ArticleBoneNode : _info._model.FindBone(value); } SignalPropertyChange(); } }
        [Category("Article"), Browsable(true), TypeConverter(typeof(DropDownListBonesMDef))]
        public string CharacterBone { get { return CharBoneNode == null ? charBone.ToString() : CharBoneNode.Name; } set { if (Model == null) { charBone = Convert.ToInt32(value); } else { CharBoneNode = String.IsNullOrEmpty(value) ? CharBoneNode : Model.FindBone(value); } SignalPropertyChange(); } }
        [Category("Article"), Browsable(false)]
        public int ActionFlagsStart { get { return aFlags; } }
        [Category("Article"), Browsable(false)]
        public int SubactionFlagsStart { get { return sFlags; } }
        [Category("Article"), Browsable(false)]
        public int ActionsStart { get { return aStart; } }
        [Category("Article"), Browsable(false)]
        public int SubactionMainStart { get { return sMStart; } }
        [Category("Article"), Browsable(false)]
        public int SubactionGFXStart { get { return sGStart; } }
        [Category("Article"), Browsable(false)]
        public int SubactionSFXStart { get { return sSStart; } }
        [Category("Article"), Browsable(false)]
        public int ModelVisibility { get { return visStart; } }
        [Category("Article"), Browsable(false)]
        public int CollisionData { get { return off1; } }
        [Category("Article"), Browsable(false)]
        public int DataOffset2 { get { return off2; } }
        [Category("Article"), Browsable(false)]
        public int DataOffset3 { get { return off3; } }

        public string ArticleStringID { get { return "ArticleType" + (Static ? "2_" : "1_") + (Name == "Entry Article" ? "Entry" : (Parent.Name == "Static Articles" ? "Static" + Index : offsetID.ToString())); } }

        public int id, articleBone, charBone, aFlags, sFlags, aStart, sMStart, sGStart, sSStart, visStart, off1, off2, off3;

        [Browsable(false)]
        public bool pikmin { get { return ArticleStringID == "ArticleType1_10" && RootNode.Name == "FitPikmin"; } }
        [Browsable(false)]
        public bool dedede { get { return ArticleStringID == "ArticleType1_14" && RootNode.Name == "FitDedede"; } }
        
        public bool Static = false;
        public bool extraOffset = false;
        public override bool OnInitialize()
        {
            base.OnInitialize();

            //return false;

            id = Header->_id;
            articleBone = Header->_arcGroup;
            charBone = Header->_boneID;
            aFlags = Header->_actionFlagsStart;
            sFlags = Header->_subactionFlagsStart;
            aStart = Header->_actionsStart;
            sMStart = Header->_subactionMainStart;
            sGStart = Header->_subactionGFXStart;
            sSStart = Header->_subactionSFXStart;
            visStart = Header->_modelVisibility;
            off1 = Header->_collisionData;
            off2 = Header->_unknownD2;
            off3 = Header->_unknownD3;

            bool extra = false;
            _extraOffsets = new List<int>();
            _extraEntries = new List<MoveDefEntryNode>();
            bint* extraAddr = (bint*)((VoidPtr)Header + 52);
            for (int i = 0; i < (Size - 52) / 4; i++)
            {
                _extraOffsets.Add(extraAddr[i]);
                if (extraAddr[i] > 0)
                    extra = true;
            }

            Static = Size > 52 && _extraOffsets[0] < 1480 && _extraOffsets[0] >= 0;

            if (_name == null)
                _name = "Article" + ID;

            return SubactionFlagsStart > 0 || extra || ActionsStart > 0 || ActionFlagsStart > 0 || CollisionData > 0 || DataOffset2 > 0 || DataOffset3 > 0;
        }

        public MoveDefActionFlagsNode _actionFlags;
        public MoveDefActionListNode _actions;
        public MoveDefFlagsNode _subActionFlags;
        public MoveDefEntryNode _subActions;
        public MoveDefModelVisibilityNode _mdlVis;
        public CollisionDataNode _data1;
        public Data2ListNode _data2;
        public MoveDefSectionParamNode _data3;

        [Category("Article")]
        public List<int> ExtraOffsets { get { return _extraOffsets; } }
        public List<int> _extraOffsets;
        [Category("Article"), Browsable(false)]
        public List<MoveDefEntryNode> ExtraEntries { get { return _extraEntries; } }
        public List<MoveDefEntryNode> _extraEntries;

        public override void OnPopulate()
        {
            int off = 0;
            int actionCount = 0;
            int subactions = Static ? _extraOffsets[0] : (_offset - SubactionFlagsStart) / 8;
            if (ActionFlagsStart > 0)
                actionCount = Root.GetSize(ActionFlagsStart) / 16;
            if (SubactionFlagsStart > 0)
                subactions = Root.GetSize(SubactionFlagsStart) / 8;

            if (actionCount > 0)
            {
                (_actionFlags = new MoveDefActionFlagsNode("ActionFlags", actionCount)).Initialize(this, BaseAddress + ActionFlagsStart, actionCount * 16);
                if (ActionsStart > 0 || (dedede && _extraOffsets[0] > 0))
                {
                    _actions = new MoveDefActionListNode() { _name = "Actions" };
                    _actions.Parent = this;
                    for (int i = 0; i < actionCount; i++)
                    {
                        if (pikmin)
                        {
                            _actions.AddChild(new MoveDefActionGroupNode() { _name = "Action" + i }, false);

                            off = *((bint*)(BaseAddress + ActionsStart) + i);
                            if (off > 0)
                                new MoveDefActionNode("Entry", false, _actions.Children[i]).Initialize(_actions.Children[i], BaseAddress + off, 0);
                            else
                                _actions.Children[i].Children.Add(new MoveDefActionNode("Entry", true, _actions.Children[i]));
                            off = *((bint*)(BaseAddress + _extraOffsets[0]) + i);
                            if (off > 0)
                                new MoveDefActionNode("Exit", false, _actions.Children[i]).Initialize(_actions.Children[i], BaseAddress + off, 0);
                            else
                                _actions.Children[i].Children.Add(new MoveDefActionNode("Exit", true, _actions.Children[i]));
                        }
                        else
                        {
                            off = *((bint*)(BaseAddress + ActionsStart) + i);
                            if (off > 0)
                                new MoveDefActionNode("Action" + i, false, _actions).Initialize(_actions, BaseAddress + off, 0);
                            else
                                _actions.Children.Add(new MoveDefActionNode("Action" + i, true, _actions));
                        }
                    }
                }
            }

            if (SubactionFlagsStart > 0)
            {
                _subActionFlags = new MoveDefFlagsNode() { _parent = this };
                _subActionFlags.Initialize(this, BaseAddress + SubactionFlagsStart, subactions * 8);
                
                if (subactions == 0)
                    subactions = _subActionFlags._names.Count;

                int populateCount = 1;
                bool child = false;
                int bias = 0;

                if (dedede)
                {
                    _subActions = new MoveDefGroupNode() { Name = "SubActions" };
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Waddle Dee" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Waddle Doo" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Gyro" }, false);
                    populateCount = 3;
                    child = true;
                }
                else if (pikmin)
                {
                    _subActions = new MoveDefGroupNode() { Name = "SubActions" };
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Red" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Yellow" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Blue" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Purple" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "White" }, false);
                    populateCount = 5;
                    child = true;
                    bias = 1;
                }
                else if (ArticleStringID == "ArticleType1_61" && RootNode.Name == "FitKirby")
                {
                    _subActions = new MoveDefGroupNode() { Name = "SubActions" };
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "100 Ton Stone" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Thwomp Stone" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Spike Ball" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Stone Kirby" }, false);
                    _subActions.AddChild(new MoveDefActionListNode() { _name = "Happy Stone" }, false);
                    populateCount = 5;
                    child = true;
                }
                else
                    _subActions = new MoveDefActionListNode() { _name = "SubActions" };

                _subActions.Parent = this;

                for (int x = 0; x < populateCount; x++)
                {
                    ResourceNode Base = _subActions;
                    int main = SubactionMainStart,
                        gfx = SubactionGFXStart,
                        sfx = SubactionSFXStart;
                    if (child)
                    {
                        Base = _subActions.Children[x];
                        main = _extraOffsets[x + bias];
                        gfx = _extraOffsets[x + populateCount + bias];
                        sfx = _extraOffsets[x + populateCount * 2 + bias];
                    }

                    for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                        Base.AddChild(new MoveDefSubActionGroupNode() { _name = _subActionFlags._names[i], _flags = _subActionFlags._flags[i]._Flags, _inTransTime = _subActionFlags._flags[i]._InTranslationTime }, false);

                    if (main > 0)
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                        {
                            off = *((bint*)(BaseAddress + main) + i);
                            if (off > 0)
                                new MoveDefActionNode("Main", false, Base.Children[i]).Initialize(Base.Children[i], BaseAddress + off, 0);
                            else
                                Base.Children[i].Children.Add(new MoveDefActionNode("Main", true, Base.Children[i]));
                        }
                    else
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                            Base.Children[i].Children.Add(new MoveDefActionNode("Main", true, Base.Children[i]));

                    if (gfx > 0)
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                        {
                            off = *((bint*)(BaseAddress + gfx) + i);
                            if (off > 0)
                                new MoveDefActionNode("GFX", false, Base.Children[i]).Initialize(Base.Children[i], BaseAddress + off, 0);
                            else
                                Base.Children[i].Children.Add(new MoveDefActionNode("GFX", true, Base.Children[i]));
                        }
                    else
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                            Base.Children[i].Children.Add(new MoveDefActionNode("GFX", true, Base.Children[i]));

                    if (sfx > 0)
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                        {
                            off = *((bint*)(BaseAddress + sfx) + i);
                            if (off > 0)
                                new MoveDefActionNode("SFX", false, Base.Children[i]).Initialize(Base.Children[i], BaseAddress + off, 0);
                            else
                                Base.Children[i].Children.Add(new MoveDefActionNode("SFX", true, Base.Children[i]));
                        }
                    else
                        for (int i = 0; i < subactions && i < _subActionFlags._names.Count; i++)
                            Base.Children[i].Children.Add(new MoveDefActionNode("SFX", true, Base.Children[i]));
                }
            }

            if (ModelVisibility != 0)
                (_mdlVis = new MoveDefModelVisibilityNode()).Initialize(this, BaseAddress + ModelVisibility, 16);

            if (CollisionData != 0)
                (_data1 = new CollisionDataNode() { _name = "Collision Data" }).Initialize(this, BaseAddress + CollisionData, 8);

            if (DataOffset2 != 0)
                (_data2 = new Data2ListNode() { _name = "Data2" }).Initialize(this, BaseAddress + DataOffset2, 8);

            if (DataOffset3 != 0)
                (_data3 = new MoveDefSectionParamNode(3) { _name = "Data3" }).Initialize(this, BaseAddress + DataOffset3, 0);

            //Extra offsets.
            //Dedede:
            //Waddle Dee, Waddle Doo, and Gyro subactions main, gfx, sfx for first 9 offsets.
            //Pikmin:
            //Actions 2 is 1st offset.
            //Red, Yellow, Blue, Purple, and White subactions main, gfx, sfx for next 15 offsets.

            int index = 0;
            foreach (int i in _extraOffsets)
            {
                MoveDefEntryNode entry = null;
                if (index < 9 && dedede) { }
                else if (index < 16 && pikmin) { }
                else if (ArticleStringID == "ArticleType1_61" && RootNode.Name == "FitKirby" && index < 15) { }
                else if (index == 0 && ArticleStringID == "ArticleType1_6" && RootNode.Name == "FitGameWatch")
                {
                    GameWatchArticle6 p = new GameWatchArticle6();
                    p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (index == 1 && (
                    (ArticleStringID == "ArticleType1_8" && (RootNode.Name == "FitLucas" || RootNode.Name == "FitNess")) || 
                    (ArticleStringID == "ArticleType1_11" && RootNode.Name == "FitGameWatch") || 
                    (ArticleStringID == "ArticleType1_4" && RootNode.Name == "FitWario") ||
                    (ArticleStringID == "ArticleType1_5" && RootNode.Name == "FitWarioMan")))
                {
                    MoveDefParamListNode p = new MoveDefParamListNode() { _name = "ParamList" + index };
                    p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (index > 0 && ArticleStringID == "ArticleType1_46" && RootNode.Name == "FitKirby")
                {
                    MoveDefEntryNode p = null;
                    switch (index)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            p = new MoveDefKirbyArticleP1Node() { offsetID = index };
                            break;
                        case 6:
                        case 8:
                            //List of bytes - 1 or 0.
                            //7 & 9 are the index of the last 1 + 1
                            break;
                        case 9: break;
                    }
                    if (p != null)
                        p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (index > 0 && ((ArticleStringID == "ArticleType1_11" && RootNode.Name == "FitFox") || (ArticleStringID == "ArticleType1_9" && RootNode.Name == "FitFalco") || (ArticleStringID == "ArticleType1_11" && RootNode.Name == "FitWolf")))
                {
                    MoveDefEntryNode p = null;
                    switch (index)
                    {
                        case 1:
                            p = new MoveDefItemAnchorListNode() { _name = "Bone Floats" };
                            break;
                        case 2:
                            p = new HitDataListOffsetNode() { _name = "HitDataList" + index };
                            break;
                        case 3:
                            p = new Fox11Falco9Wolf11Article3Node();
                            break;
                        case 4:
                            p = new ActionOffsetNode() { _name = "Data" + index };
                            break;
                        case 5:
                            p = new SecondaryActionOffsetNode() { _name = "Data" + index };
                            break;
                        case 6:
                            p = new Fox11Falco9Wolf11PopoArticle63Node() { offsetID = index };
                            break;
                    }
                    if (p != null)
                        p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if ((index == 23 || index == 24) && ArticleStringID == "ArticleType1_10" && RootNode.Name == "FitPikmin")
                {
                    MoveDefEntryNode p = null;
                    switch (index)
                    {
                        case 23:
                            p = new ActionOffsetNode() { _name = "Data" + index };
                            break;
                        case 24:
                            p = new SecondaryActionOffsetNode() { _name = "Data" + index };
                            break;
                    }
                    if (p != null)
                        p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (index == 3 && ArticleStringID == "ArticleType1_14" && RootNode.Name == "FitPopo")
                {
                    Fox11Falco9Wolf11PopoArticle63Node p = new Fox11Falco9Wolf11PopoArticle63Node() { offsetID = index };
                    p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (index > 4 && ArticleStringID == "ArticleType1_7" && RootNode.Name == "FitSonic")
                {
                    MoveDefEntryNode p = null;
                    switch (index)
                    {
                        case 5:
                            p = new ActionOffsetNode() { _name = "Data" + index };
                            break;
                        case 6:
                            p = new SecondaryActionOffsetNode() { _name = "Data" + index };
                            break;
                    }
                    if (p != null)
                        p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if (dedede && index == 11)
                {
                    DededeHitDataList p = new DededeHitDataList();
                    p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else if ((index == 3 && ArticleStringID == "ArticleType1_4" && RootNode.Name == "FitGanon") || (index == 1 && ArticleStringID == "ArticleType1_7" && RootNode.Name == "FitSonic"))
                {
                    MoveDefHitDataListNode p = new MoveDefHitDataListNode() { _name = "HitData" };
                    p.Initialize(this, BaseAddress + i, 0);
                    entry = p;
                }
                else
                {
                    if (i > 1480 && i < Root.dataSize)
                    {
                        MoveDefExternalNode e = Root.IsExternal(i);
                        if (e != null && e.Name.Contains("hitData"))
                        {
                            MoveDefHitDataListNode p = new MoveDefHitDataListNode() { _name = e.Name };
                            p.Initialize(this, new DataSource(BaseAddress + i, 0));
                            entry = p;
                        }
                        else
                            if (index < _extraOffsets.Count - 1 && _extraOffsets[index + 1] < 1480 && _extraOffsets[index + 1] > 1)
                            {
                                int count = _extraOffsets[index + 1];
                                int size = Root.GetSize(i);
                                if (size > 0 && count > 0)
                                {
                                    size /= count;
                                    MoveDefRawDataNode d = new MoveDefRawDataNode("ExtraParams" + index);
                                    entry = d;
                                    d.Initialize(this, BaseAddress + i, 0);
                                    for (int x = 0; x < count; x++)
                                        new MoveDefSectionParamNode(x) { _name = "Part" + x }.Initialize(d, BaseAddress + i + x * size, size);
                                }
                            }
                            else
                            {
                                if (e != null && e.Name.Contains("hitData"))
                                {
                                    MoveDefHitDataListNode p = new MoveDefHitDataListNode() { _name = e.Name };
                                    entry = p;
                                    p.Initialize(this, new DataSource(BaseAddress + i, 0));
                                }
                                else
                                    (entry = new MoveDefSectionParamNode(index) { _name = "ExtraParams" + index }).Initialize(this, BaseAddress + i, 0);
                            }
                    }
                }
                _extraEntries.Add(entry);
                index++;
            }
        }

        public FDefSubActionStringTable subActionStrings;
        public VoidPtr actionAddr;
        public override int OnCalculateSize(bool force)
        {
            _buildHeader = true;
            _lookupCount = 0;
            subActionStrings = new FDefSubActionStringTable();
            _entryLength = 52 + _extraOffsets.Count * 4;

            int size = 0;

            if (_actionFlags != null)
            {
                _lookupCount++; //action flags offset
                size += 16 * _actionFlags.Children.Count;
            }

            if (_actions != null)
            {
                if (pikmin)
                {
                    //false for now
                    bool actions1Null = false, actions2Null = false;
                    foreach (MoveDefActionGroupNode grp in _actions.Children)
                        foreach (MoveDefActionNode a in grp.Children)
                            if (a.Children.Count > 0)
                                if (a.Index == 0)
                                    actions1Null = false;
                                else if (a.Index == 1)
                                    actions2Null = false;
                    _lookupCount += 2; //actions offsets
                    if (!actions1Null || !actions2Null)
                    {
                        foreach (MoveDefActionGroupNode grp in _actions.Children)
                            foreach (MoveDefActionNode a in grp.Children)
                                if (a.Children.Count > 0)
                                    _lookupCount++; //action offset
                        size += _actions.Children.Count * 8;
                    }
                }
                else
                {
                    bool actionsNull = true;
                    foreach (MoveDefActionNode a in _actions.Children)
                        if (a.Children.Count > 0) actionsNull = false;

                    if (!actionsNull)
                    {
                        _lookupCount++; //actions offsets
                        foreach (MoveDefActionNode a in _actions.Children)
                            if (a.Children.Count > 0)
                                _lookupCount++; //action offset
                        size += _actions.Children.Count * 4;
                    }
                }
            }

            if (_subActions != null)
            {
                if (_subActions.Children.Count > 0)
                    _lookupCount++; //subaction flags offset

                bool mainNull = true, gfxNull = true, sfxNull = true;
                MoveDefEntryNode e = _subActions;
                int populateCount = 1;
                bool children = false;
                if (_subActions.Children[0] is MoveDefActionListNode)
                {
                    populateCount = _subActions.Children.Count;
                    children = true;
                }
                for (int i = 0; i < populateCount; i++)
                {
                    if (children)
                        e = _subActions.Children[i] as MoveDefEntryNode;

                    foreach (MoveDefSubActionGroupNode g in e.Children)
                    {
                        if (i == 0)
                        {
                            subActionStrings.Add(g.Name);
                            _lookupCount++; //subaction name offset
                            size += 8;
                        }

                        //bool write = true;
                        //if (!Static)
                        //{
                        //    write = false;
                        //    foreach (MoveDefActionNode a in g.Children)
                        //        if (a.Children.Count > 0 || a._actionRefs.Count > 0)
                        //            write = true;
                        //}
                        foreach (MoveDefActionNode a in g.Children)
                        {
                            //if ((Static && a.Children.Count > 0) || (!Static && write))
                            if (a.Children.Count > 0 || a._actionRefs.Count > 0 || a._build)
                            {
                                switch (a.Index)
                                {
                                    case 0: mainNull = false; break;
                                    case 1: gfxNull = false; break;
                                    case 2: sfxNull = false; break;
                                }
                                _lookupCount++; //action offset
                            }
                        }
                    }
                }
                size += subActionStrings.TotalSize;
                for (int i = 0; i < populateCount; i++)
                {
                    if (children)
                        e = _subActions.Children[i] as MoveDefEntryNode;

                    if (!(mainNull && Static))
                    {
                        _lookupCount++; //main actions offset
                        size += e.Children.Count * 4;
                    }
                    if (!(gfxNull && Static))
                    {
                        _lookupCount++; //gfx actions offset
                        size += e.Children.Count * 4;
                    }
                    if (!(sfxNull && Static))
                    {
                        _lookupCount++; //sfx actions offset
                        size += e.Children.Count * 4;
                    }
                }
            }

            if (_mdlVis != null)
            {
                _lookupCount++; //model vis offset
                size += _mdlVis.CalculateSize(true);
                _lookupCount += _mdlVis._lookupCount;
            }

            if (_data1 != null)
            {
                _lookupCount++; //data 1 offset
                if (!_data1.External)
                {
                    size += _data1.CalculateSize(true);
                    _lookupCount += _data1._lookupCount;
                }
            }

            if (_data2 != null)
            {
                _lookupCount++; //data 2 offset
                if (!_data2.External)
                {
                    size += _data2.CalculateSize(true);
                    _lookupCount += _data2._lookupCount;
                }
            }

            if (_data3 != null)
            {
                _lookupCount++; //data 3 offset
                if (!_data3.External)
                    size += _data3.CalculateSize(true);
            }

            foreach (MoveDefEntryNode e in _extraEntries)
            {
                if (e != null)
                {
                    if (!e.External)
                    {
                        size += e.CalculateSize(true);
                        _lookupCount += e._lookupCount;
                    }
                    _lookupCount++;
                }
            }

            _childLength = size;

            return _childLength + _entryLength;
        }

        public bool _buildHeader = true;
        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            aFlags = sFlags = aStart = sMStart = sGStart = sSStart = visStart = off1 = off2 = off3 = 0;

            int a2Start = 0;

            List<int> mainStarts = null, gfxStarts = null, sfxStarts = null;

            VoidPtr addr = address;

            if (_subActions != null)
            {
                subActionStrings.WriteTable(addr);
                addr += subActionStrings.TotalSize;
            }

            if (_actionFlags != null)
            {
                FDefActionFlags* actionFlagsAddr = (FDefActionFlags*)addr;
                aFlags = (int)actionFlagsAddr - (int)RebuildBase;

                foreach (MoveDefActionFlagsEntryNode a in _actionFlags.Children)
                    a.Rebuild(actionFlagsAddr++, 16, true);

                addr = (VoidPtr)actionFlagsAddr;
            }

            if (_actions != null)
            {
                if (pikmin)
                {
                    //false for now
                    bool actions1Null = false, actions2Null = false;
                    foreach (MoveDefActionGroupNode grp in _actions.Children)
                        foreach (MoveDefActionNode a in grp.Children)
                            if (a.Children.Count > 0)
                                if (a.Index == 0)
                                    actions1Null = false;
                                else if (a.Index == 1)
                                    actions2Null = false;
                    if (!actions1Null || !actions2Null)
                    {
                        bint* action1Offsets = (bint*)addr;
                        aStart = (int)action1Offsets - (int)RebuildBase;
                        bint* action2Offsets = (bint*)(addr + _actions.Children.Count * 4);
                        a2Start = (int)action2Offsets - (int)RebuildBase;

                        foreach (MoveDefActionGroupNode grp in _actions.Children)
                            foreach (MoveDefActionNode a in grp.Children)
                            {
                                if (a.Index == 0)
                                {
                                    if (a.Children.Count > 0)
                                    {
                                        *action1Offsets = (int)a._rebuildAddr - (int)a.RebuildBase;
                                        _lookupOffsets.Add(action1Offsets);
                                    }
                                    action1Offsets++;
                                }
                                else if (a.Index == 1)
                                {
                                    if (a.Children.Count > 0)
                                    {
                                        *action2Offsets = (int)a._rebuildAddr - (int)a.RebuildBase;
                                        _lookupOffsets.Add(action2Offsets);
                                    }
                                    action2Offsets++;
                                }
                            }
                        addr = (VoidPtr)action2Offsets;
                        
                    }
                }
                else
                {
                    bool actionsNull = true;
                    foreach (MoveDefActionNode a in _actions.Children)
                        if (a.Children.Count > 0) actionsNull = false;

                    if (!actionsNull)
                    {
                        bint* actionOffsets = (bint*)addr;
                        aStart = (int)actionOffsets - (int)RebuildBase;

                        foreach (MoveDefActionNode a in _actions.Children)
                        {
                            if (a.Children.Count > 0)
                            {
                                *actionOffsets = (int)a._rebuildAddr - (int)a.RebuildBase;
                                _lookupOffsets.Add(actionOffsets);
                            }
                            actionOffsets++;
                        }
                        addr = (VoidPtr)actionOffsets;
                    }
                }
            }
            if (_mdlVis != null)
            {
                _mdlVis.Rebuild(addr, _mdlVis._calcSize, true);
                visStart = (int)_mdlVis.RebuildOffset;
                _lookupOffsets.AddRange(_mdlVis._lookupOffsets);
                addr += _mdlVis._calcSize;
            }

            if (_data1 != null)
            {
                if (!_data1.External)
                {
                    _data1.Rebuild(addr, _data1._calcSize, true);
                    _lookupOffsets.AddRange(_data1._lookupOffsets);
                    addr += _data1._calcSize;
                }
                off1 = (int)_data1._rebuildAddr - (int)RebuildBase;
            }

            if (_data2 != null)
            {
                if (!_data2.External)
                {
                    _data2.Rebuild(addr, _data2._calcSize, true);
                    _lookupOffsets.AddRange(_data2._lookupOffsets);
                    addr += _data2._calcSize;
                }
                off2 = (int)_data2._rebuildAddr - (int)RebuildBase;
            }

            if (_data3 != null)
            {
                if (_data3.External)
                    off3 = (int)_data3._rebuildAddr - (int)RebuildBase;
                else
                {
                    off3 = (int)addr - (int)RebuildBase;
                    _data3.Rebuild(addr, _data3._calcSize, true);
                    addr += _data3._calcSize;
                }
            }

            if (_subActions != null && _subActions.Children.Count > 0)
            {
                bint* lastOffsets = null, mainOffsets, GFXOffsets, SFXOffsets;
                FDefSubActionFlag* subActionFlagsAddr = null;
                bool mainNull = true, gfxNull = true, sfxNull = true;
                MoveDefEntryNode e = _subActions;
                int populateCount = 1;
                bool children = false;
                if (_subActions.Children[0] is MoveDefActionListNode)
                {
                    populateCount = _subActions.Children.Count;
                    children = true;
                    mainStarts = new List<int>();
                    gfxStarts = new List<int>();
                    sfxStarts = new List<int>();
                    sMStart = 0;
                    sGStart = 0;
                    sSStart = 0;
                }
                for (int i = 0; i < populateCount; i++)
                {
                    if (children)
                        e = _subActions.Children[i] as MoveDefEntryNode;

                    foreach (MoveDefSubActionGroupNode g in e.Children)
                    {
                        foreach (MoveDefActionNode a in g.Children)
                            if (a.Children.Count > 0 || a._actionRefs.Count > 0 || a._build)
                                switch (a.Index)
                                {
                                    case 0: mainNull = false; break;
                                    case 1: gfxNull = false; break;
                                    case 2: sfxNull = false; break;
                                }
                    }

                    if (i == 0)
                    {
                        subActionFlagsAddr = (FDefSubActionFlag*)addr;
                        sFlags = (int)subActionFlagsAddr - (int)RebuildBase;
                        lastOffsets = (bint*)((VoidPtr)subActionFlagsAddr + e.Children.Count * 8);
                    }

                    mainOffsets = lastOffsets;

                    if (!(mainNull && Static))
                    {
                        if (!children)
                            sMStart = (int)mainOffsets - (int)RebuildBase;
                        else
                            mainStarts.Add((int)mainOffsets - (int)RebuildBase);
                        GFXOffsets = (bint*)((VoidPtr)mainOffsets + e.Children.Count * 4);
                    }
                    else GFXOffsets = mainOffsets;
                    if (!(gfxNull && Static))
                    {
                        if (!children)
                            sGStart = (int)GFXOffsets - (int)RebuildBase;
                        else
                            gfxStarts.Add((int)GFXOffsets - (int)RebuildBase);
                        SFXOffsets = (bint*)((VoidPtr)GFXOffsets + e.Children.Count * 4);
                    }
                    else SFXOffsets = GFXOffsets;

                    if (!(sfxNull && Static))
                    {
                        if (!children)
                            sSStart = (int)SFXOffsets - (int)RebuildBase;
                        else
                            sfxStarts.Add((int)SFXOffsets - (int)RebuildBase);
                        addr = ((VoidPtr)SFXOffsets + e.Children.Count * 4);
                    }
                    else addr = (VoidPtr)SFXOffsets;

                    lastOffsets = (bint*)addr;

                    int x = 0; //bool write = true;
                    foreach (MoveDefSubActionGroupNode grp in e.Children)
                    {
                        if (i == 0)
                        {
                            *subActionFlagsAddr = new FDefSubActionFlag() { _Flags = grp._flags, _InTranslationTime = grp._inTransTime, _stringOffset = (int)subActionStrings[grp.Name] - (int)RebuildBase };

                            if (subActionFlagsAddr->_stringOffset > 0)
                                _lookupOffsets.Add(subActionFlagsAddr->_stringOffset.Address);

                            subActionFlagsAddr++;
                        }

                        //if (!Static)
                        //{
                        //    write = false;
                        //    foreach (MoveDefActionNode a in grp.Children)
                        //        if (a.Children.Count > 0 || a._actionRefs.Count > 0)
                        //            write = true;
                        //}
                        //if ((Static && grp.Children[0].Children.Count > 0) || (!Static && write))
                        if (grp.Children[0].Children.Count > 0 || (grp.Children[0] as MoveDefActionNode)._actionRefs.Count > 0 || (grp.Children[0] as MoveDefActionNode)._build)
                        {
                            mainOffsets[x] = (int)(grp.Children[0] as MoveDefActionNode)._rebuildAddr - (int)RebuildBase;
                            _lookupOffsets.Add(&mainOffsets[x]);
                        }

                        //if ((Static && grp.Children[1].Children.Count > 0) || (!Static && write))
                        if (grp.Children[1].Children.Count > 0 || (grp.Children[1] as MoveDefActionNode)._actionRefs.Count > 0 || (grp.Children[1] as MoveDefActionNode)._build)
                        {
                            GFXOffsets[x] = (int)(grp.Children[1] as MoveDefActionNode)._rebuildAddr - (int)RebuildBase;
                            _lookupOffsets.Add(&GFXOffsets[x]);
                        }

                        //if ((Static && grp.Children[2].Children.Count > 0) || (!Static && write))
                        if (grp.Children[2].Children.Count > 0 || (grp.Children[2] as MoveDefActionNode)._actionRefs.Count > 0 || (grp.Children[2] as MoveDefActionNode)._build)
                        {
                            SFXOffsets[x] = (int)(grp.Children[2] as MoveDefActionNode)._rebuildAddr - (int)RebuildBase;
                            _lookupOffsets.Add(&SFXOffsets[x]);
                        }

                        x++;
                    }
                }
                addr = lastOffsets;
            }

            foreach (MoveDefEntryNode e in _extraEntries)
            {
                if (e != null)
                {
                    if (!e.External)
                    {
                        e.Rebuild(addr, e._calcSize, true);
                        _lookupOffsets.AddRange(e._lookupOffsets);
                        if (e._lookupOffsets.Count != e._lookupCount)
                            Console.WriteLine(e._lookupCount - e._lookupOffsets.Count);
                        addr += e._calcSize;
                    }
                }
            }

            if (_buildHeader)
            {
                _rebuildAddr = addr;

                Article* article = (Article*)addr;

                article->_id = id;
                article->_boneID = charBone;
                article->_arcGroup = articleBone;

                article->_actionsStart = aStart;
                article->_actionFlagsStart = aFlags;
                article->_subactionFlagsStart = sFlags;
                article->_subactionMainStart = sMStart;
                article->_subactionGFXStart = sGStart;
                article->_subactionSFXStart = sSStart;
                article->_modelVisibility = visStart;
                article->_collisionData = off1;
                article->_unknownD2 = off2;
                article->_unknownD3 = off3;

                bint* ext = (bint*)(addr + 52);
                int index = 0;
                if (_extraEntries.Count > 0)
                foreach (int i in _extraOffsets)
                {
                    MoveDefEntryNode e = _extraEntries[index];
                    if (e != null)
                    {
                        ext[index] = (int)e._rebuildAddr - (int)RebuildBase;
                        _lookupOffsets.Add(&ext[index]);
                    }
                    else if (index == 0 && Static)
                        ext[index] = (_subActions == null ? 0 : _subActions.Children.Count);
                    else
                        ext[index] = i;
                    index++;
                }

                index = 0;

                if (pikmin)
                {
                    ext[0] = a2Start;
                    _lookupOffsets.Add(&ext[0]);
                }

                int bias = (pikmin ? 1 : 0);
                if (mainStarts != null)
                    foreach (int i in mainStarts)
                    {
                        ext[index + bias] = i;
                        _lookupOffsets.Add(&ext[index + bias]);
                        index++;
                    }
                if (gfxStarts != null)
                    foreach (int i in gfxStarts)
                    {
                        ext[index + bias] = i;
                        _lookupOffsets.Add(&ext[index + bias]);
                        index++;
                    }
                if (sfxStarts != null)
                    foreach (int i in sfxStarts)
                    {
                        ext[index + bias] = i;
                        _lookupOffsets.Add(&ext[index + bias]);
                        index++;
                    }

                if ((int)(addr + 52 + _extraOffsets.Count * 4) - (int)address != _calcSize)
                    Console.WriteLine(_calcSize - ((int)(addr + 52 + _extraOffsets.Count * 4) - (int)address));

                //Add all header offsets
                bint* off = (bint*)((VoidPtr)article + 12);
                for (int i = 0; i < 10; i++)
                    if (off[i] > 1480 && off[i] < Root.dataSize)
                        _lookupOffsets.Add(&off[i]);
                
                if (_lookupOffsets.Count != _lookupCount)
                    Console.WriteLine(_lookupCount - _lookupOffsets.Count);
            }
            else
            {
                if ((int)addr - (int)address != _childLength)
                    Console.WriteLine((int)addr - (int)address);
            }
        }

        public int currentSubAction = 0;
        public ArticleInfo _info;
    }

    public unsafe class CollDataType0 : MoveDefEntryNode
    {
        internal collData0* Header { get { return (collData0*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public int type, offset, count;
        public float unk1, unk2, unk3;

        [Category("Collision Data Type 0")]
        public int Type { get { return type; } }
        [Category("Collision Data Type 0")]
        public int Offset { get { return offset; } }
        [Category("Collision Data Type 0")]
        public int Count { get { return count; } }
        [Category("Collision Data Type 0")]
        public float Unknown1 { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 0")]
        public float Unknown2 { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 0")]
        public float Unknown3 { get { return unk3; } set { unk3 = value; SignalPropertyChange(); } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            type = Header->type;
            offset = Header->_list._startOffset;
            count = Header->_list._listCount;
            unk1 = Header->unk1;
            unk2 = Header->unk2;
            unk3 = Header->unk3;
            return Offset > 0 && Count > 0;
        }

        public override void OnPopulate()
        {
            VoidPtr addr = BaseAddress + Offset;
            for (int i = 0; i < count; i++)
                new MoveDefBoneIndexNode().Initialize(this, addr + i * 4, 4);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            return 24 + Children.Count * 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* addr = (bint*)address;
            foreach (MoveDefBoneIndexNode b in Children)
            {
                b._rebuildAddr = addr;
                *addr++ = b.boneIndex;
            }
            _rebuildAddr = addr;
            collData0* data = (collData0*)addr;
            data->type = 0;
            data->unk1 = unk1;
            data->unk2 = unk2;
            data->unk3 = unk3;
            if (Children.Count > 0)
            {
                data->_list._startOffset = (int)address - (int)RebuildBase;
                _lookupOffsets.Add(data->_list._startOffset.Address);
            }
            data->_list._listCount = Children.Count;
        }
    }

    public unsafe class CollisionDataNode : MoveDefEntryNode
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        //public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        FDefListOffset hdr;
        [Category("List Offset")]
        public int DataOffset { get { return hdr._startOffset; } }
        [Category("List Offset")]
        public int Count { get { return hdr._listCount; } }
        public override void OnPopulate()
        {
            if (DataOffset > 0)
            {
                MoveDefOffsetNode o;
                bint* addr = (bint*)(BaseAddress + DataOffset);
                for (int i = 0; i < Count; i++)
                {
                    (o = new MoveDefOffsetNode() { _name = "Entry" }).Initialize(this, addr++, 4);
                    if (o.DataOffset > 0)
                    {
                        int value = *((int*)(BaseAddress + o.DataOffset));
                        switch (value)
                        {
                            case 0: new CollDataType0() { _name = "Data" }.Initialize(o, BaseAddress + o.DataOffset, 0); break;
                            case 1: new CollDataType1() { _name = "Data" }.Initialize(o, BaseAddress + o.DataOffset, 0); break;
                            case 2: new CollDataType2() { _name = "Data" }.Initialize(o, BaseAddress + o.DataOffset, 0); break;
                            default:
                                Console.WriteLine(value);
                                new MoveDefSectionParamNode(0) { _name = "Data" }.Initialize(o, BaseAddress + o.DataOffset, 0);
                                break;
                        }
                    }
                }
            }
        }
        public override bool OnInitialize()
        {
            base.OnInitialize();
            hdr = *Header;
            return hdr._startOffset > 0;
        }
        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* offsets = (bint*)address;
            VoidPtr dataAddr = address;
            if (Children.Count > 0)
            {
                foreach (MoveDefOffsetNode o in Children)
                    if (o.Children.Count > 0 && !(o.Children[0] as MoveDefEntryNode).External)
                    {
                        o.Children[0].Rebuild(dataAddr, o.Children[0]._calcSize, true);
                        _lookupOffsets.AddRange((o.Children[0] as MoveDefEntryNode)._lookupOffsets);
                        dataAddr += o.Children[0]._calcSize;
                    }
                offsets = (bint*)dataAddr;
                foreach (MoveDefOffsetNode o in Children)
                {
                    if (o.Children.Count > 0)
                    {
                        *offsets = (int)(o.Children[0] as MoveDefEntryNode)._rebuildAddr - (int)RebuildBase;
                        _lookupOffsets.Add(offsets); //offset to child
                    }
                    offsets++;
                }
            }

            _rebuildAddr = offsets;
            FDefListOffset* header = (FDefListOffset*)offsets;

            header->_listCount = Children.Count;
            if (Children.Count > 0)
            {
                header->_startOffset = (int)dataAddr - (int)RebuildBase;
                _lookupOffsets.Add(header->_startOffset.Address);
            }
        }
        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            _entryLength = 8;
            _childLength = 0;
            if (Children.Count > 0)
            {
                _lookupCount++; //offset to children
                foreach (MoveDefOffsetNode o in Children)
                {
                    _childLength += 4;
                    if (o.Children.Count > 0)
                    {
                        _lookupCount++; //offset to child
                        if (!(o.Children[0] as MoveDefEntryNode).External)
                        {
                            _childLength += o.Children[0].CalculateSize(true);
                            _lookupCount += (o.Children[0] as MoveDefEntryNode)._lookupCount;
                        }
                    }
                }
            }
            return _childLength + _entryLength;
        }
    }

    public unsafe class CollDataType1 : MoveDefEntryNode
    {
        internal collData1* Header { get { return (collData1*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public int type;
        public float unk1, unk2, unk3;

        [Category("Collision Data Type 1")]
        public int Type { get { return type; } }
        [Category("Collision Data Type 1")]
        public float Length { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 1")]
        public float Width { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 1")]
        public float Height { get { return unk3; } set { unk3 = value; SignalPropertyChange(); } }
        
        public override bool OnInitialize()
        {
            base.OnInitialize();
            type = Header->type;
            unk1 = Header->unk1;
            unk2 = Header->unk2;
            unk3 = Header->unk3;
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 16;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            collData1* data = (collData1*)address;
            data->type = 1;
            data->unk1 = unk1;
            data->unk2 = unk2;
            data->unk3 = unk3;
        }
    }

    public unsafe class CollDataType2 : MoveDefEntryNode
    {
        internal collData2* Header { get { return (collData2*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public int type, flags;
        public float unk1, unk2, unk3, unk4;

        [Category("Collision Data Type 2")]
        public int Type { get { return type; } }
        [Category("Collision Data Type 2")]
        public int Flags { get { return flags; } set { flags = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 2")]
        public float Unknown1 { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 2")]
        public float Unknown2 { get { return unk2; } set { unk2 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 2")]
        public float Unknown3 { get { return unk3; } set { unk3 = value; SignalPropertyChange(); } }
        [Category("Collision Data Type 2")]
        public float Unknown4 { get { return unk4; } set { unk4 = value; SignalPropertyChange(); } }
        
        public override bool OnInitialize()
        {
            base.OnInitialize();
            type = Header->type;
            flags = Header->flags;
            unk1 = Header->unk1;
            unk2 = Header->unk2;
            unk3 = Header->unk3;

            if ((flags & 2) == 2)
                unk4 = Header->unk4;

            if (Size != 24 && Size != 20)
                Console.WriteLine(Size);

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return ((flags & 2) == 2 ? 24 : 20);
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            collData2* data = (collData2*)address;
            data->type = 2;
            data->flags = flags;
            data->unk1 = unk1;
            data->unk2 = unk2;
            data->unk3 = unk3;
            if ((flags & 2) == 2)
                data->unk4 = unk4;
        }
    }
}
