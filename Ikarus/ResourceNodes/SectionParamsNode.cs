using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefSectionParamNode : MoveDefCharSpecificNode
    {
        internal byte* Header { get { return (byte*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public List<AttributeInfo> _info;
        public string OldName;

        public MoveDefSectionParamNode(int index) { offsetID = index; }

        public override string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
                if (Parent is MoveDefArticleNode)
                    Root.Params[(Parent as MoveDefArticleNode).ArticleStringID]._newName = value;
                else if (Parent is MoveDefSectionParamNode)
                    Root.Params[TreePath]._newName = value;
                else
                    Root.Params[OldName]._newName = value;
                FileManager._dictionaryChanged = true;
            }
        }

        private UnsafeBuffer attributeBuffer;

        [Browsable(false)]
        public UnsafeBuffer AttributeBuffer { get { if (attributeBuffer != null) return attributeBuffer; else return attributeBuffer = new UnsafeBuffer(0x2E4); } }

        public Dictionary<int, FDefListOffset> offsets;

        public override bool OnInitialize()
        {
            offsets = new Dictionary<int, FDefListOffset>();

            if (_name == null)
                if (isExtra)
                    _name = "ExtraParams" + offsetID;
                else
                    _name = "Params" + offsetID;

            OldName = _name;

            base.OnInitialize();

            if (Size == 0)
                SetSizeInternal(4);

            CharacterInfo cInfo = FileManager.SelectedInfo;

            SectionParamInfo data = null;
            if (Parent is MoveDefArticleNode)
            {
                if (cInfo.FileCollection._parameters.ContainsKey((Parent as MoveDefArticleNode).ArticleStringID + "/" + _name))
                {
                    data = cInfo.FileCollection._parameters[(Parent as MoveDefArticleNode).ArticleStringID + "/" + _name];
                    _info = data._attributes;
                    if (!String.IsNullOrEmpty(data._newName))
                        _name = data._newName;
                }
                else _info = new List<AttributeInfo>();
            }
            else if (Parent is MoveDefSectionParamNode)
            {
                if (cInfo.FileCollection._parameters.ContainsKey(TreePath))
                {
                    data = cInfo.FileCollection._parameters[TreePath];
                    _info = data._attributes;
                    if (!String.IsNullOrEmpty(data._newName))
                        _name = data._newName;
                }
                else _info = new List<AttributeInfo>();
            }
            else if (cInfo.FileCollection._parameters.ContainsKey(Name))
            {
                data = cInfo.FileCollection._parameters[Name];
                _info = data._attributes;
                if (!String.IsNullOrEmpty(data._newName))
                    _name = data._newName;
            }
            else _info = new List<AttributeInfo>();

            attributeBuffer = new UnsafeBuffer(Size);
            byte* pOut = (byte*)attributeBuffer.Address;
            byte* pIn = (byte*)Header;

            for (int i = 0; i < Size; i++)
            {
                if (i % 4 == 0)
                {
                    if (data == null)
                    {
                        AttributeInfo info = new AttributeInfo();
                        
                        //Guess
                        if (((((uint)*((buint*)pIn)) >> 24) & 0xFF) != 0 && *((bint*)pIn) != -1 && !float.IsNaN(((float)*((bfloat*)pIn))))
                            info._type = 0;
                        else
                            info._type = 1;

                        info._name = (info._type == 1 ? "*" : "" + (info._type > 3 ? "+" : "")) + "0x" + i.ToString("X");
                        info._description = "No Description Available.";

                        _info.Add(info);
                    }

                    //if (_info.Count == i / 4)
                    //    break;

                    //AttributeInfo n = _info[i / 4];
                    //if (n._type == 3)
                    //{
                    //    int id = 0;
                    //    if (!int.TryParse(n._description, out id))
                    //        id = i / 4;
                    //    if (!offsets.ContainsKey(id))
                    //        offsets.Add(id, new FDefListOffset() { _startOffset = *(bint*)pIn, _listCount = 1 });
                    //    else
                    //    {
                    //        FDefListOffset d = offsets[id];
                    //        d._startOffset = *(bint*)pIn;
                    //        offsets[id] = d;
                    //    }
                    //}
                    //else if (n._type == 4)
                    //{
                    //    int id = int.Parse(n._description);
                    //    if (!offsets.ContainsKey(id))
                    //        offsets.Add(id, new FDefListOffset() { _listCount = *(bint*)pIn });
                    //    else
                    //    {
                    //        FDefListOffset d = offsets[id];
                    //        d._listCount = *(bint*)pIn;
                    //        offsets[id] = d;
                    //    }
                    //}
                }
                *pOut++ = *pIn++;
            }

            //if (Parent is MoveDefArticleNode)
            //{
            //    string id = (Parent as MoveDefArticleNode).ArticleStringID + "/" + _name;
            //    if (!Root.Params.ContainsKey(id))
            //    {
            //        Root.Params.Add(id, new SectionParamInfo());
            //        Root.Params[id].Attributes = _info;
            //        Root.Params[id].NewName = _name;
            //        data = Root.Params[id];
            //    }
            //}
            //else if (Parent is MoveDefSectionParamNode)
            //{
            //    if (!Root.Params.ContainsKey(TreePath))
            //    {
            //        Root.Params.Add(TreePath, new SectionParamInfo());
            //        Root.Params[TreePath].Attributes = _info;
            //        Root.Params[TreePath].NewName = _name;
            //        data = Root.Params[TreePath];
            //    }
            //}

            return false;
        }

        public override string TreePathAbsolute 
        {
            get 
            {
                return _parent == null || !(_parent is MoveDefSectionParamNode || _parent is MoveDefRawDataNode) ? OldName : _parent.TreePathAbsolute + "/" + OldName; 
            }
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            byte* pIn = (byte*)attributeBuffer.Address;
            byte* pOut = (byte*)address;
            for (int i = 0; i < attributeBuffer.Length; i++)
                *pOut++ = *pIn++;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            _entryLength = attributeBuffer.Length;
            return _entryLength;
        }
    }

    public class SectionDataGroupNode : MoveDefEntryNode
    {
        internal VoidPtr First { get { return (VoidPtr)WorkingUncompressed.Address; } }
        public int Count = 0, EntrySize = 0, ID = 0;

        SectionDataGroupNode(int count, int size, int id) { Count = count; EntrySize = size; ID = id; }

        [Browsable(false)]
        int levelIndex
        {
            get
            {
                int i = 1;
                ResourceNode n = _parent;
                while ((n is MoveDefSectionParamNode || n is SectionDataGroupNode) && (n != null))
                {
                    n = n._parent;
                    if (n is SectionDataGroupNode)
                        i++;
                }
                return i;
            }
        }

        public override bool OnInitialize()
        {
            _name = "Data" + ID;
            return Count > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Count; i++)
                new MoveDefSectionParamNode(i) { _name = "Part" + i }.Initialize(this, First + i * EntrySize, EntrySize);
        }

        public override int OnCalculateSize(bool force)
        {
            int size = 0;

            foreach (MoveDefSectionParamNode p in Children)
                size += p.CalculateSize(true);

            return size;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            base.OnRebuild(address, length, force);
        }
    }

    public unsafe class MoveDefHitDataListNode : MoveDefCharSpecificNode
    {
        internal FDefHurtBox* First { get { return (FDefHurtBox*)WorkingUncompressed.Address; } }
        
        public override bool OnInitialize()
        {
            base.OnInitialize();
            _offsets.Add(_offset);
            return Size / 32 > 0;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < Size / 32; i++)
                new MoveDefHurtBoxNode() { _extOverride = true }.Initialize(this, First + i, 32);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return _entryLength = 32 * Children.Count;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefHurtBox* data = (FDefHurtBox*)address;
            foreach (MoveDefHurtBoxNode h in Children)
                h.Rebuild(data++, 32, true);
        }
    }
}
