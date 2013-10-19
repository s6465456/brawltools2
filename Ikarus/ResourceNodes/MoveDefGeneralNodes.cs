using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefActionListNode : MoveDefEntry
    {
        public List<List<int>> ActionOffsets = new List<List<int>>();

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* addr = (bint*)address;
            int count = 0;
            if (Children.Count > 0) count = Children[0].Children.Count;
            for (int i = 0; i < count; i++)
                foreach (MoveDefEntry g in Children)
                {
                    ActionScript a = (ActionScript)g.Children[i];
                    addr[g.Index + Children.Count * count] = a.RebuildOffset;
                }
        }

        public override int OnCalculateSize(bool force)
        {
            int s = 0;
            foreach (MoveDefEntry g in Children)
                s += g.Children.Count * 4;
            return s;
        }
    }
    public class MoveDefSubRoutineListNode : MoveDefEntry
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefSubroutineList; } }
    }
    public class MoveDefGroupNode : MoveDefEntry
    {
        public override ResourceType ResourceType { get { return ResourceType.NoEdit; } }
    }

    public unsafe class MoveDefRawDataNode : ReferenceEntry
    {
        internal byte* Header { get { return (byte*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal byte[] data;

        public MoveDefRawDataNode(string name) { _name = name; }

        public override bool OnInitialize()
        {
            if ((Parent as MoveDefEntry)._offset != _offset)
                base.OnInitialize();

            _dataOffsets = new List<int>();
            _dataOffsets.Add(_offset);

            data = new byte[WorkingUncompressed.Length];
            
            for (int i = 0; i < data.Length; i++)
                data[i] = Header[i];

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return _entryLength = WorkingUncompressed.Length;
        }

        //public override unsafe void Export(string outPath)
        //{
        //    using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.SequentialScan))
        //    {
        //        stream.SetLength(data.Length);
        //        using (FileMap map = FileMap.FromStream(stream))
        //        {
        //            for (int i = 0; i < data.Length; i++)
        //                ((byte*)map.Address)[i] = data[i];
        //        }
        //    }
        //}

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            byte* header = (byte*)address;
            if (data != null)
                for (int i = 0; i < data.Length; i++)
                    header[i] = data[i];
            else base.OnRebuild(address, length, force);
        }
    }

    public unsafe class MoveDefBoneIndicesNode : MoveDefEntry
    {
        internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefBoneIndicesNode(string nameType, int count) { Count = count; _name = "[" + Count + "] " + nameType; }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return Count > 0;
        }

        public override void OnPopulate()
        {
            bint* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefBoneIndexNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            bint* addr = (bint*)address;
            foreach (MoveDefBoneIndexNode b in Children)
            {
                b._rebuildAddr = addr;
                *addr++ = b.boneIndex;
            }
        }
    }

    public unsafe class MoveDefBoneIndexNode : MoveDefEntry
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int boneIndex = 0;

        [Browsable(false)]
        public MDL0BoneNode BoneNode
        {
            get 
            { 
                if (ParentArticle == null && Model == null) 
                    return null;

                MDL0Node model;
                if (ParentArticle != null && ParentArticle._info != null)
                    model = ParentArticle._info._model;
                else
                    model = Model;

                if (boneIndex >= model._linker.BoneCache.Length || boneIndex < 0) 
                    return null;

                return (MDL0BoneNode)model._linker.BoneCache[boneIndex];
            }
            set
            {
                boneIndex = value.BoneIndex; 
                Name = value.Name; 
            }
        }

        [Category("Bone Index Entry"), Browsable(true), TypeConverter(typeof(DropDownListBonesMDef))]
        public string Bone { get { return BoneNode == null ? boneIndex.ToString() : BoneNode.Name; } set { if (Model == null) { boneIndex = Convert.ToInt32(value); Name = boneIndex.ToString(); } else { BoneNode = String.IsNullOrEmpty(value) ? BoneNode : Model.FindBone(value); } SignalPropertyChange(); } }

        public override string Name
        {
            get { return Bone; }
            //set { base.Name = value; }
        }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            boneIndex = *Header;
            if (_name == null)
                _name = Bone;
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            *(bint*)address = boneIndex;
        }
    }

    public unsafe class MoveDefIndicesNode : MoveDefEntry
    {
        internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefIndicesNode(string nameType, int count) { Count = count; _name = "[" + Count + "] " + nameType; }

        public override bool OnInitialize()
        {
            _extOverride = true;
            base.OnInitialize();
            return Count > 0;
        }

        public override void OnPopulate()
        {
            bint* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefIndexNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            bint* addr = (bint*)address;
            foreach (MoveDefIndexNode b in Children)
            {
                b._rebuildAddr = addr;
                *addr++ = b.ItemIndex;
            }
        }
    }

    public unsafe class MoveDefIndexNode : MoveDefEntry
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int i = 0;

        [Category("Index Entry")]
        public int ItemIndex { get { return i; } set { i = value; SignalPropertyChange(); } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Index" + Index;
            i = *Header;
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            *(bint*)address = i;
        }
    }

    public unsafe class MoveDefOffsetNode : MoveDefEntry
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int i = 0;

        [Category("Offset Entry")]
        public int DataOffset { get { return i; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            i = *Header;
            if (_name == null)
            {
                _externalEntry = _root.TryGetExternal(DataOffset);
                if (_externalEntry != null && !_extOverride)
                {
                    _name = _externalEntry.Name;
                    _externalEntry._refs.Add(this);
                }
            }

            if (_name == null)
                _name = "Offset" + Index;

            return false;
        }
    }

    public unsafe class MoveDefListOffsetNode : MoveDefEntry
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        internal int i = 0;

        FDefListOffset hdr;

        [Category("List Offset")]
        public int DataOffset { get { return hdr._startOffset; } }
        [Category("List Offset")]
        public int Count { get { return hdr._listCount; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            hdr = *Header;
            return false;
        }
    }
}
