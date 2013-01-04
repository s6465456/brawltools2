﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefActionListNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefActionList; } }
        public List<List<int>> ActionOffsets = new List<List<int>>();

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* addr = (bint*)address;
            int count = 0;
            if (Children.Count > 0) count = Children[0].Children.Count;
            for (int i = 0; i < count; i++)
                foreach (MoveDefEntryNode g in Children)
                {
                    MoveDefActionNode a = (MoveDefActionNode)g.Children[i];
                    addr[g.Index + Children.Count * count] = a._rebuildOffset;
                }
        }

        protected override int OnCalculateSize(bool force)
        {
            int s = 0;
            foreach (MoveDefEntryNode g in Children)
                s += g.Children.Count * 4;
            return s;
        }
    }
    public class MoveDefSubRoutineListNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefSubroutineList; } }
    }
    public class MoveDefGroupNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.NoEdit; } }
    }

    public unsafe class MoveDefRawDataNode : MoveDefExternalNode
    {
        internal byte* Header { get { return (byte*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal byte[] data;

        public MoveDefRawDataNode(string name) { _name = name; }

        protected override bool OnInitialize()
        {
            if ((Parent as MoveDefEntryNode)._offset != _offset)
                base.OnInitialize();

            _offsets = new List<int>();
            _offsets.Add(_offset);

            data = new byte[WorkingUncompressed.Length];
            
            for (int i = 0; i < data.Length; i++)
                data[i] = Header[i];

            return false;
        }

        protected override int OnCalculateSize(bool force)
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

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            byte* header = (byte*)address;
            if (data != null)
                for (int i = 0; i < data.Length; i++)
                    header[i] = data[i];
            else base.OnRebuild(address, length, force);
        }
    }

    public unsafe class MoveDefBoneIndicesNode : MoveDefEntryNode
    {
        internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefBoneIndicesNode(string nameType, int count) { Count = count; _name = "[" + Count + "] " + nameType; }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            return Count > 0;
        }

        protected override void OnPopulate()
        {
            bint* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefBoneIndexNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 4;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            bint* addr = (bint*)address;
            foreach (MoveDefBoneIndexNode b in Children)
            {
                b._entryOffset = addr;
                *addr++ = b.boneIndex;
            }
        }
    }

    public unsafe class MoveDefBoneIndexNode : MoveDefEntryNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int boneIndex = 0;

        [Browsable(false)]
        public MDL0BoneNode BoneNode
        {
            get { if (Model == null) return null; if (boneIndex >= Model._linker.BoneCache.Length || boneIndex < 0) return null; return (MDL0BoneNode)Model._linker.BoneCache[boneIndex]; }
            set { boneIndex = value.BoneIndex; Name = value.Name; }
        }

        [Category("Bone Index Entry"), Browsable(true), TypeConverter(typeof(DropDownListBonesMDef))]
        public string Bone { get { return BoneNode == null ? boneIndex.ToString() : BoneNode.Name; } set { if (Model == null) { boneIndex = Convert.ToInt32(value); Name = boneIndex.ToString(); } else { BoneNode = String.IsNullOrEmpty(value) ? BoneNode : Model.FindBone(value); } SignalPropertyChange(); } }

        public override string Name
        {
            get { return Bone; }
            //set { base.Name = value; }
        }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            boneIndex = *Header;
            if (_name == null)
                _name = Bone;
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 4;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            *(bint*)address = boneIndex;
        }
    }

    public unsafe class MoveDefIndicesNode : MoveDefEntryNode
    {
        internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefIndicesNode(string nameType, int count) { Count = count; _name = "[" + Count + "] " + nameType; }

        protected override bool OnInitialize()
        {
            _extOverride = true;
            base.OnInitialize();
            return Count > 0;
        }

        protected override void OnPopulate()
        {
            bint* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefIndexNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 4;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            bint* addr = (bint*)address;
            foreach (MoveDefIndexNode b in Children)
            {
                b._entryOffset = addr;
                *addr++ = b.ItemIndex;
            }
        }
    }

    public unsafe class MoveDefIndexNode : MoveDefEntryNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int i = 0;

        [Category("Index Entry")]
        public int ItemIndex { get { return i; } set { i = value; SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Index" + Index;
            i = *Header;
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 4;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _entryOffset = address;
            *(bint*)address = i;
        }
    }

    public unsafe class MoveDefOffsetNode : MoveDefEntryNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int i = 0;

        [Category("Offset Entry")]
        public int DataOffset { get { return i; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            i = *Header;
            if (_name == null)
            {
                _extNode = Root.IsExternal(DataOffset);
                if (_extNode != null && !_extOverride)
                {
                    _name = _extNode.Name;
                    _extNode._refs.Add(this);
                }
            }

            if (_name == null)
                _name = "Offset" + Index;

            return false;
        }
    }

    public unsafe class MoveDefListOffsetNode : MoveDefEntryNode
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        internal int i = 0;

        FDefListOffset hdr;

        [Category("List Offset")]
        public int DataOffset { get { return hdr._startOffset; } }
        [Category("List Offset")]
        public int Count { get { return hdr._listCount; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            hdr = *Header;
            return false;
        }
    }
}
