﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefUnk7Node : MoveDefEntry
    {
        internal long* Start { get { return (long*)WorkingUncompressed.Address; } }
        internal int Count = 0;

        public MoveDefUnk7Node(int count) { Count = count; }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Unknown 7";
            return Count > 0;
        }

        public override void OnPopulate()
        {
            long* entry = Start;
            for (int i = 0; i < Count; i++)
                new MoveDefUnk7EntryNode().Initialize(this, new DataSource((VoidPtr)(entry++), 8));
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 8;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;

            long* addr = (long*)(address);
            foreach (MoveDefUnk7EntryNode b in Children)
                b.Rebuild(addr++, 8, true);
        }
    }

    public unsafe class MoveDefUnk7EntryNode : MoveDefEntry
    {
        internal buint* _value1 { get { return (buint*)WorkingUncompressed.Address; } }
        internal buint* _value2 { get { return (buint*)(WorkingUncompressed.Address + 4); } }
        
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        Bin32 v1, v2;

        internal int i = 0;

        [Category("Unk 7 Entry"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags1 { get { return v1; } set { v1 = value; SignalPropertyChange(); } }
        [Category("Unk 7 Entry"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 Flags2 { get { return v2; } set { v2 = value; SignalPropertyChange(); } }
        
        public override bool OnInitialize()
        {
            base.OnInitialize();
            if (_name == null)
                _name = "Action" + Index;
            v1 = new Bin32(*_value1);
            v2 = new Bin32(*_value2);
            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 8;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            *(buint*)address = v1._data;
            *(buint*)(address + 4) = v2._data;
        }
    }
}
