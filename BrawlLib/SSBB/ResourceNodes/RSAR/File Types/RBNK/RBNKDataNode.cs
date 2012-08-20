﻿using System;
using BrawlLib.SSBBTypes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RBNKDataNode : RBNKEntryNode
    {
        internal RBNK_DATAEntry* Header { get { return (RBNK_DATAEntry*)WorkingUncompressed.Address; } }

        private RWSD_WSDEntry part1;
        //RWSD_DATAEntryPart2 part2;
        //RWSD_DATAEntryPart3 part3;

        private List<RWSD_NoteEvent> _part2 = new List<RWSD_NoteEvent>();
        private List<RWSD_NoteInfo> _part3 = new List<RWSD_NoteInfo>();

        public string offset { get { return ((uint)Header - (uint)((RBNKNode)Parent.Parent).Header).ToString("X"); } }

        internal int _soundIndex;

        //[Category("Data Part1")]
        //public float Unknown1 { get { return part1._unk1; } set { part1._unk1 = value; } }
        //[Category("Data Part1")]
        //public float Unknown2 { get { return part1._unk2; } set { part1._unk2 = value; } }
        //[Category("Data Part1")]
        //public short Unknown3 { get { return part1._unk3; } set { part1._unk3 = value; } }
        //[Category("Data Part1")]
        //public short Unknown4 { get { return part1._unk4; } set { part1._unk4 = value; } }
        //[Category("Data Part1")]
        //public int Unknown5 { get { return part1._unk5; } set { part1._unk5 = value; } }
        //[Category("Data Part1")]
        //public int Unknown6 { get { return part1._unk6; } set { part1._unk6 = value; } }
        //[Category("Data Part1")]
        //public int Unknown7 { get { return part1._unk7; } set { part1._unk7 = value; } }
        //[Category("Data Part1")]
        //public int Unknown8 { get { return part1._unk8; } set { part1._unk8 = value; } }
        //[Category("Data Part1")]
        //public int Unknown9 { get { return part1._unk9; } set { part1._unk9 = value; } }

        [Category("Data Part2")]
        public List<RWSD_NoteEvent> Part2 { get { return _part2; } }
        [Category("Data Part3")]
        public List<RWSD_NoteInfo> Part3 { get { return _part3; } }

        protected override bool OnInitialize()
        {
            //RWSDHeader* rwsd = ((RWSDNode)_parent).Header;
            //VoidPtr offset = &rwsd->Data->_list;
            RuintList* list;
            int count;

            //part1 = *Header->GetPart1(_offset);

            //list = Header->GetPart2(_offset);
            //count = list->_numEntries;
            //if (count > 1)
            //    MessageBox.Show("RWSD pt2 - " + _parent.Name + " - " + Name + " " + count);
            //for (int i = 0; i < count; i++)
            //    _part2.Add(*(RWSD_DATAEntryPart2*)list->Get(_offset, i));

            //list = Header->GetPart3(_offset);
            //count = list->_numEntries;
            //if (count > 1)
            //    MessageBox.Show("RWSD pt3 - " + _parent.Name + " - " + Name + " " + count);
            //for (int i = 0; i < count; i++)
            //    _part3.Add(*(RWSD_DATAEntryPart3*)list->Get(_offset, i));

            if (_name == null)
                _name = String.Format("Sound[{0:X2}]", Index);

            return false;
        }
    }
}
