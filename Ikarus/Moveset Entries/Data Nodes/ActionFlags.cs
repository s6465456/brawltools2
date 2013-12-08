﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class ActionFlags : MovesetEntry
    {
        public Bin32 flags1, flags2, flags3, flags4;

        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags1b { get { return flags1; } set { flags1 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags2b { get { return flags2; } set { flags2 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags3b { get { return flags3; } set { flags3 = value; SignalPropertyChange(); } }
        [Category("Raw Flags Binary"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags4b { get { return flags4; } set { flags4 = value; SignalPropertyChange(); } }

        public override void Parse(VoidPtr address)
        {
            sActionFlags* hdr = (sActionFlags*)address;
            flags1 = new Bin32((uint)hdr->_flags1);
            flags2 = new Bin32((uint)hdr->_flags2);
            flags3 = new Bin32((uint)hdr->_flags3);
            flags4 = new Bin32((uint)hdr->_flags4);
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 16;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;

            sActionFlags* header = (sActionFlags*)address;
            header->_flags1 = (int)(uint)flags1;
            header->_flags2 = (int)(uint)flags2;
            header->_flags3 = (int)(uint)flags3;
            header->_flags4 = (int)(uint)flags4;
        }
    }
}
