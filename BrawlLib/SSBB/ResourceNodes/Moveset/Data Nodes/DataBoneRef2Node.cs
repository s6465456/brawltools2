﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefBoneRef2Node : MoveDefEntryNode
    {
        internal FDefBoneRef2* Header { get { return (FDefBoneRef2*)WorkingUncompressed.Address; } }

        int _handNBoneIndex1, _handNBoneIndex2, _handNBoneIndex3, _handNBoneIndex4;

        [Category("Bone References")]
        public int HandNBoneIndex1 { get { return _handNBoneIndex1; } set { _handNBoneIndex1 = value; SignalPropertyChange(); } }
        [Category("Bone References")]
        public int HandNBoneIndex2 { get { return _handNBoneIndex2; } set { _handNBoneIndex2 = value; SignalPropertyChange(); } }
        [Category("Bone References")]
        public int HandNBoneIndex3 { get { return _handNBoneIndex3; } set { _handNBoneIndex3 = value; SignalPropertyChange(); } }
        [Category("Bone References")]
        public int HandNBoneIndex4 { get { return _handNBoneIndex4; } set { _handNBoneIndex4 = value; SignalPropertyChange(); } }
        [Category("Bone References")]
        public int EntryOffset { get { return Header->_offset; } }
        [Category("Bone References")]
        public int EntryCount { get { return Header->_count; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            _name = "Hand Bones";

            _handNBoneIndex1 = Header->_handNBoneIndex1;
            _handNBoneIndex2 = Header->_handNBoneIndex2;
            _handNBoneIndex3 = Header->_handNBoneIndex3;
            _handNBoneIndex4 = Header->_handNBoneIndex4;

            return EntryOffset > 0;
        }

        protected override void OnPopulate()
        {
            bint* addr = (bint*)(BaseAddress + EntryOffset);
            for (int i = 0; i < EntryCount; i++)
                new MoveDefBoneIndexNode().Initialize(this, addr++, 4);
        }

        protected override int OnCalculateSize(bool force)
        {
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            return 24 + Children.Count * 4;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* addr = (bint*)address;

            foreach (MoveDefBoneIndexNode b in Children)
                b.Rebuild(addr++, 4, true);

            _entryOffset = addr;

            FDefBoneRef2* header = (FDefBoneRef2*)addr;
            header->_handNBoneIndex1 = HandNBoneIndex1;
            header->_handNBoneIndex2 = HandNBoneIndex2;
            header->_handNBoneIndex3 = HandNBoneIndex3;
            header->_handNBoneIndex4 = HandNBoneIndex4;
            header->_count = Children.Count;

            if (Children.Count > 0)
            {
                header->_offset = (int)address - (int)_rebuildBase;
                _lookupOffsets.Add((int)header->_offset.Address - (int)_rebuildBase);
            }
        }
    }
}
