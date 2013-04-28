﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RASDNode : U8EntryNode
    {
        internal RASD* Header { get { return (RASD*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        //[Category("RASD")]
        //public int Entries { get { return Header->_numEntries; } }

        //RASD is found in "External" bres group nodes
        protected override bool OnInitialize()
        {
            base.OnInitialize();
            //SetSizeInternal(Header->_header._length);
            _name = "RASD" + Index;
            return false;
        }

        protected override void OnPopulate()
        {
            //DATA Entries
        }

        protected override int OnCalculateSize(bool force)
        {
            return base.OnCalculateSize(force);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);
        }

        internal static ResourceNode TryParse(DataSource source) { return ((RASD*)source.Address)->_header._tag == RASD.Tag ? new RASDNode() : null; }
    }

    //public unsafe class RASDEntryNode : ResourceNode
    //{
    //    internal RASDDataEntry* Header { get { return (RASDDataEntry*)WorkingUncompressed.Address; } }
        
    //    protected override bool OnInitialize()
    //    {
    //        return false;
    //    }
    //}
}
