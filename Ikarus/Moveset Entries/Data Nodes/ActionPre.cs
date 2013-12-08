﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    //public unsafe class MoveDefActionPreNode : MovesetEntry
    //{
    //    internal bint* Start { get { return (bint*)WorkingUncompressed.Address; } }
    //    internal int Count = 0;

    //    public MoveDefActionPreNode(int count) { Count = count; }

    //    public override bool OnInitialize()
    //    {
    //        _extOverride = true;
    //        base.OnInitialize();
    //        _name = "Action Pre";
    //        return Count > 0;
    //    }

    //    public override void Parse(VoidPtr address)
    //    {
    //        bint* entry = Start;
    //        for (int i = 0; i < Count; i++)
    //            new MoveDefActionPreEntryNode().Initialize(this, new DataSource((VoidPtr)(entry++), 0x4));
    //    }

    //    public override int GetSize()
    //    {
    //        _lookupCount = 0;
    //        return Children.Count * 4;
    //    }

    //    protected override void Write(VoidPtr address)
    //    {
    //        _rebuildAddr = address;
    //        bint* addr = (bint*)address;
    //        foreach (MoveDefActionPreEntryNode b in Children)
    //        {
    //            b._rebuildAddr = addr;
    //            *addr++ = (b.External ? -1 : 0);
    //        }
    //    }
    //}

    public unsafe class ActionPre : MovesetEntry
    {
        private int val = 0;

        [Category("Action Pre")]
        public int Value { get { return val; } }
        [Category("Action Pre"), Browsable(true), TypeConverter(typeof(DropDownListExtNodesMDef))]
        public string ExternalNode
        {
            get { return _externalEntry != null ? _externalEntry.Name : null; }
            set
            {
                if (_externalEntry != null && _externalEntry.Name != value)
                    _externalEntry.References.Remove(this);
                
                foreach (ExternalEntry e in _root.ReferenceList)
                    if (e.Name == value)
                    {
                        _externalEntry = e;
                        e.References.Add(this);
                    }
            }
        }

        public override string Name { get { return "Action" + Index; } }

        //-1 if external, 0 if none.
        //offsets to the next ref of the same name until -1. Last ref is always -1

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 4;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;
            *(bint*)address = val;
        }
    }
}
