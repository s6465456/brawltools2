using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefPatternPowerMulNode : MoveDefEntryNode
    {
        internal patternPowerMul* Header { get { return (patternPowerMul*)WorkingUncompressed.Address; } }
        
        public float _unk1;
        public float _unk2;
        public float _unk3;
        public float _unk4;
        public float _unk5;
        public float _unk6;
        public float _unk7;
        public float _unk8;
        public float _unk9;
        public float _unk10;

        [Category("Pattern Power Mul")]
        public float Unknown1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown2 { get { return _unk2; } set { _unk2 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown3 { get { return _unk3; } set { _unk3 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown4 { get { return _unk4; } set { _unk4 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown5 { get { return _unk5; } set { _unk5 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown6 { get { return _unk6; } set { _unk6 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown7 { get { return _unk7; } set { _unk7 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown8 { get { return _unk8; } set { _unk8 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown9 { get { return _unk9; } set { _unk9 = value; SignalPropertyChange(); } }
        [Category("Pattern Power Mul")]
        public float Unknown10 { get { return _unk10; } set { _unk10 = value; SignalPropertyChange(); } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            _unk1 = Header->_unk1;
            _unk2 = Header->_unk2;
            _unk3 = Header->_unk3;
            _unk4 = Header->_unk4;
            _unk5 = Header->_unk5;
            _unk6 = Header->_unk6;
            _unk7 = Header->_unk7;
            _unk8 = Header->_unk8;
            _unk9 = Header->_unk9;
            _unk10 = Header->_unk10;
            return true;
        }

        public override void OnPopulate()
        {
            MoveDefActionNode prev;
            VoidPtr addr = &Header->_first;

            //Event parameters for events in this node are built elsewhere
            (prev = new MoveDefActionNode("", false, this)).Initialize(this, addr, 0);
            for (int i = 0; i < 3; i++)
            {
                addr += prev.Children.Count * 8 + 8;
                (prev = new MoveDefActionNode("", false, this)).Initialize(this, addr, 0);
            }
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            _entryLength = 40;
            _childLength = 0;
            foreach (MoveDefActionNode p in Children)
            {
                _childLength += p.CalculateSize(true);
                _lookupCount += p._lookupCount;
            }
            return _entryLength + _childLength;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;
            _rebuildAddr = addr;
            patternPowerMul* header = (patternPowerMul*)addr;
            _unk1 = Header->_unk1;
            _unk2 = Header->_unk2;
            _unk3 = Header->_unk3;
            _unk4 = Header->_unk4;
            _unk5 = Header->_unk5;
            _unk6 = Header->_unk6;
            _unk7 = Header->_unk7;
            _unk8 = Header->_unk8;
            _unk9 = Header->_unk9;
            _unk10 = Header->_unk10;
            foreach (MoveDefActionNode p in Children)
            {
                p.Rebuild(addr, p._calcSize, true);
                _lookupOffsets.AddRange(p._lookupOffsets);
                addr += p._calcSize;
            }
        }
    }

    public unsafe class MoveDefPatternPowerMulEntryNode : MoveDefEntryNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            return true;
        }

        public override void OnPopulate()
        {
            new MoveDefActionNode("1", false, this).Initialize(this, &Header[0], 8);
            new MoveDefActionNode("2", false, this).Initialize(this, &Header[2], 8);
            new MoveDefActionNode("3", false, this).Initialize(this, &Header[4], 8);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            _entryLength = 8;
            _childLength = 0;
            foreach (MoveDefSectionParamNode p in Children)
                _childLength += p.CalculateSize(true);
            return _entryLength + _childLength;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;
            foreach (MoveDefSectionParamNode p in Children)
            {
                p.Rebuild(addr, p._calcSize, true);
                addr += p._calcSize;
            }
            _rebuildAddr = addr;
            FDefListOffset* header = (FDefListOffset*)addr;
            if (Children.Count > 0)
            {
                header->_startOffset = (int)address - (int)RebuildBase;
                _lookupOffsets.Add(header->_startOffset.Address);
            }
            header->_listCount = Children.Count;
        }
    }
}
