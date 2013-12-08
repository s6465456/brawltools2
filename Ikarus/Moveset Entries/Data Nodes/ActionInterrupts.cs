﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class ActionInterrupts : ListOffset
    {
        public List<IndexValue> _indices;
        public override void Parse(VoidPtr address)
        {
            base.Parse(address);

            _indices = new List<IndexValue>();
            bint* entry = (bint*)(BaseAddress + DataOffset);
            for (int i = 0; i < Count; i++)
                _indices.Add(Parse<IndexValue>(entry++));
        }

        protected override int OnGetSize()
        {
            _lookupCount = (_indices.Count > 0 ? 1 : 0);
            return _indices.Count * 4 + 8;
        }

        protected override void OnWrite(VoidPtr address)
        {
            bint* addr = (bint*)address;
            foreach (IndexValue b in _indices)
            {
                b._rebuildAddr = addr;
                *addr++ = -1;
            }

            sListOffset* header = (sListOffset*)addr;
            _rebuildAddr = addr;

            if (_indices.Count > 0)
            {
                header->_startOffset = Offset(address);
                _lookupOffsets.Add(header->_startOffset.Address);
            }

            header->_listCount = _indices.Count;
        }
    }
}
