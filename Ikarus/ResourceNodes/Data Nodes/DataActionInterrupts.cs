using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefActionInterruptsNode : MoveDefEntry
    {
        internal FDefListOffset* Header { get { return (FDefListOffset*)WorkingUncompressed.Address; } }
        internal int i = 0;

        public int DataOffset { get { return Header->_startOffset; } }
        public int Count { get { return Header->_listCount; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Action Interrupts";
            return Count > 0;
        }

        public override void OnPopulate()
        {
            bint* entry = (bint*)(BaseAddress + DataOffset);
            for (int i = 0; i < Count; i++)
                new MoveDefIndexNode().Initialize(this, new DataSource((VoidPtr)(entry++), 4));
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            return 8 + Children.Count * 4;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            bint* addr = (bint*)address;
            foreach (MoveDefIndexNode b in Children)
            {
                b._rebuildAddr = addr;
                *addr++ = -1; //Always external
            }

            FDefListOffset* header = (FDefListOffset*)addr;

            _rebuildAddr = header;

            if (Children.Count > 0)
            {
                header->_startOffset = (int)address - (int)RebuildBase;
                _lookupOffsets.Add(header->_startOffset.Address);
            }

            header->_listCount = Children.Count;
        }
    }
}
