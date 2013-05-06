﻿using System;
using BrawlLib.SSBBTypes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RBNKDataInstParamNode : RBNKDataEntryNode
    {
        internal RBNKInstParam* Header { get { return (RBNKInstParam*)WorkingUncompressed.Address; } }

        public RBNKInstParam hdr = new RBNKInstParam();

        RSARFileAudioNode _soundNode;
        [Browsable(false)]
        public RSARFileAudioNode Sound
        {
            get { return _soundNode; }
            set
            {
                if (_soundNode != value)
                    _soundNode = value;
            }
        }
        [Category("Bank Data Entry"), Browsable(true), TypeConverter(typeof(DropDownListRBNKSounds))]
        public string Wave
        {
            get { return _soundNode == null ? null : _soundNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    Sound = null;
                else
                {
                    WAVESoundNode node = null;
                    int t = 0;
                    foreach (WAVESoundNode r in RBNKNode.Children[1].Children)
                    {
                        if (r.Name == value) { node = r; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        Sound = node;
                        hdr._waveIndex = t;
                        SignalPropertyChange();
                    }
                }
            }
        }

        //[Category("Bank Data Entry")]
        //public int WaveIndex { get { return hdr._waveIndex; } set { hdr._waveIndex = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Attack { get { return hdr._attack; } set { hdr._attack = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Decay { get { return hdr._decay; } set { hdr._decay = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Sustain { get { return hdr._sustain; } set { hdr._sustain = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Release { get { return hdr._release; } set { hdr._release = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Hold { get { return hdr._hold; } set { hdr._hold = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public WaveDataLocation WaveDataLocationType { get { return (WaveDataLocation)hdr._waveDataLocationType; } set { hdr._waveDataLocationType = (byte)value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public NoteOffType NoteOffType { get { return (NoteOffType)hdr._noteOffType; } set { hdr._noteOffType = (byte)value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte AlternateAssign { get { return hdr._alternateAssign; } set { hdr._alternateAssign = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte OriginalKey { get { return hdr._originalKey; } set { hdr._originalKey = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Volume { get { return hdr._volume; } set { hdr._volume = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte Pan { get { return hdr._pan; } set { hdr._pan = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public byte SurroundPan { get { return hdr._surroundPan; } set { hdr._surroundPan = value; SignalPropertyChange(); } }
        [Category("Bank Data Entry")]
        public float Pitch { get { return hdr._pitch; } set { hdr._pitch = value; SignalPropertyChange(); } }

        [Category("Audio Stream")]
        public WaveEncoding Encoding { get { return _soundNode == null ? WaveEncoding.ADPCM : _soundNode.Encoding; } }
        [Category("Audio Stream")]
        public int Channels { get { return _soundNode == null ? 0 : _soundNode.Channels; } }
        [Category("Audio Stream")]
        public bool IsLooped { get { return _soundNode == null ? false : _soundNode.IsLooped; } }
        [Category("Audio Stream")]
        public int SampleRate { get { return _soundNode == null ? 0 : _soundNode.SampleRate; } }
        [Category("Audio Stream")]
        public int LoopStartSample { get { return _soundNode == null ? 0 : _soundNode.LoopStartSample; } }
        [Category("Audio Stream")]
        public int NumSamples { get { return _soundNode == null ? 0 : _soundNode.NumSamples; } }

        protected override bool OnInitialize()
        {
            hdr = *Header;

            if (_name == null)
                _name = String.Format("[{0}] InstParams", Index);

            SetSizeInternal(0x30);

            if (RBNKNode.Children.Count > 1 && hdr._waveIndex < RBNKNode.Children[1].Children.Count)
                _soundNode = RBNKNode.Children[1].Children[hdr._waveIndex] as RSARFileAudioNode;

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return RBNKInstParam.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            *(RBNKInstParam*)address = hdr;
        }
    }

    public unsafe class RBNKDataRangeTableNode : RBNKTableNode
    {
        internal RangeTable* Header { get { return (RangeTable*)WorkingUncompressed.Address; } }
        
        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = String.Format("[{0}] Group", Index);

            _keys = new byte[Header->_tableCount];

            SetSizeInternal((1 + _keys.Length).Align(4) + _keys.Length * 8);

            for (int i = 0; i < _keys.Length; i++)
                _keys[i] = Header->GetKey(i);

            return _keys.Length > 0;
        }

        protected override void OnPopulate()
        {
            RuintCollection* c = Header->Collection;
            for (int i = 0; i < _keys.Length; i++)
            {
                VoidPtr addr = _offset + c->Entries[i];
                RBNKEntryNode e = null;
                switch (c->Entries[i]._dataType) //RegionTableType
                {
                    default:
                        e = new RBNKNullNode();
                        (e as RBNKDataEntryNode)._key = _keys[i];
                        (e as RBNKNullNode)._invalid = true;
                        break;
                    case 1: //InstParam
                        e = new RBNKDataInstParamNode();
                        (e as RBNKDataEntryNode)._key = _keys[i];
                        break;
                    case 2: //RangeTable
                        e = new RBNKDataRangeTableNode();
                        break;
                    case 3: //IndexTable
                        e = new RBNKDataIndexTableNode();
                        break;
                    case 4:
                        e = new RBNKNullNode();
                        (e as RBNKNullNode)._key = _keys[i];
                        break;
                }
                if (e != null)
                    e.Initialize(this, addr, 0);
            }
        }
    }

    public unsafe class RBNKDataIndexTableNode : RBNKTableNode
    {
        internal IndexTable* Header { get { return (IndexTable*)WorkingUncompressed.Address; } }

        IndexTable hdr = new IndexTable();

        [Browsable(false)]
        public byte Min { get { return hdr._min; } set { hdr._min = value; SignalPropertyChange(); } }
        [Browsable(false)]
        public byte Max { get { return hdr._max; } set { hdr._max = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            hdr = *Header;

            if (_name == null)
                _name = String.Format("[{0}] Group", Index);

            SetSizeInternal(4 + (Max - Min + 1) * 8);

            return Max > Min;
        }

        protected override void OnPopulate()
        {
            for (byte i = Min; i <= Max; i++)
            {
                VoidPtr addr = _offset + Header->_collection.Entries[i - Min];
                RBNKEntryNode e = null;
                switch (Header->_collection.Entries[i - Min]._dataType) //RegionTableType
                {
                    default:
                        e = new RBNKNullNode();
                        (e as RBNKNullNode)._key = i;
                        (e as RBNKNullNode)._invalid = true;
                        break;
                    case 1: //InstParam
                        e = new RBNKDataInstParamNode();
                        (e as RBNKDataInstParamNode)._key = i;
                        break;
                    case 2: //RangeTable
                        e = new RBNKDataRangeTableNode();
                        break;
                    case 3: //IndexTable
                        e = new RBNKDataIndexTableNode();
                        break;
                    case 4:
                        e = new RBNKNullNode();
                        (e as RBNKNullNode)._key = i;
                        break;
                }
                if (e != null)
                    e.Initialize(this, addr, 0);
            }
        }
    }

    public class RBNKDataEntryNode : RBNKEntryNode
    {
        public byte _key;
        public byte Key { get { return _key; } set { _key = value; SignalPropertyChange(); } }
    }

    public unsafe class RBNKTableNode : RBNKEntryNode
    {
        [Browsable(false)]
        public byte[] Keys { get { return _keys; } }
        public byte[] _keys = new byte[0];
        
        bool _rebuildType = false; //true is range, false is index

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            byte* addr = (byte*)address;
            RuintCollection* collection;
            if (_rebuildType)
            {
                *addr = (byte)_keys.Length;
                for (int i = 0; i < _keys.Length; i++)
                    addr[i + 1] = (byte)_keys[i];
                addr += (1 + _keys.Length).Align(4);
                collection = (RuintCollection*)addr;
            }
            else
            {
                IndexTable* table = (IndexTable*)addr;
                table->_min = _keys[0];
                table->_max = _keys[_keys.Length - 1];
                table->_reserved = 0;
                collection = (RuintCollection*)table->_collection.Address;
            }
            addr = (byte*)collection + 8 * Children.Count;
            foreach (RBNKDataEntryNode e in Children)
            {
                collection->Entries[e.Index] = (uint)((VoidPtr)addr - _rebuildBase);
                if (e is RBNKNullNode)
                    collection->Entries[e.Index]._dataType = 4;
                else
                {
                    collection->Entries[e.Index]._dataType = 1;
                    
                    e.Rebuild(addr, e._calcSize, true);
                    addr += e._calcSize;
                }
            }
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = 0;
            _rebuildType = false;

            //Determine whether to use a RangeTable or IndexTable
            _keys = new byte[Children.Count];
            int prevKey = 0, currKey;
            foreach (RBNKDataEntryNode e in Children)
            {
                _keys[e.Index] = e._key;

                if (e.Index == 0)
                {
                    prevKey = e._key;
                    continue;
                }

                currKey = e._key;

                if (currKey != prevKey + 1)
                    _rebuildType = true;

                prevKey = e._key; 
            }

            if (_rebuildType)
                size = (1 + _keys.Length).Align(4) + _keys.Length * 8;
            else
                size = 4 + _keys.Length * 8;

            foreach (RBNKEntryNode e in Children)
                size += e.CalculateSize(true);

            return size;
        }
    }

    public unsafe class RBNKNullNode : RBNKDataEntryNode
    {
        public bool _invalid = false;
        protected override bool OnInitialize()
        {
            SetSizeInternal(0);
            _name = "[" + Index + "] " + (_invalid ? "Invalid" : "Null");
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return 0;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            
        }
    }
}
