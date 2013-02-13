﻿using System;
using BrawlLib.SSBBTypes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RWSDDataNode : RSARFileEntryNode
    {
        internal RWSD_DATAEntry* Header { get { return (RWSD_DATAEntry*)WorkingUncompressed.Address; } }

        //private List<RWSD_NoteEvent> _part2 = new List<RWSD_NoteEvent>();
        //private List<RWSD_NoteInfo> _part3 = new List<RWSD_NoteInfo>();

        public RWSD_WSDEntry _part1;
        public RWSD_NoteEvent _part2;
        public RWSD_NoteInfo _part3;

        public List<RSARSoundNode> _refs = new List<RSARSoundNode>();
        public string[] References { get { return _refs.Select(x => x.TreePath).ToArray(); } }

        [Category("WSD Info")]
        public float Pitch { get { return _part1._pitch; } set { _part1._pitch = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte Pan { get { return _part1._pan; } set { _part1._pan = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte SurroundPan { get { return _part1._surroundPan; } set { _part1._surroundPan = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte FxSendA { get { return _part1._fxSendA; } set { _part1._fxSendA = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte FxSendB { get { return _part1._fxSendB; } set { _part1._fxSendB = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte FxSendC { get { return _part1._fxSendC; } set { _part1._fxSendC = value; SignalPropertyChange(); } }
        [Category("WSD Info")]
        public byte MainSend { get { return _part1._mainSend; } set { _part1._mainSend = value; SignalPropertyChange(); } }

        [Category("Note Event")]
        public float Position { get { return _part2.position; } set { _part2.position = value; } }
        [Category("Note Event")]
        public float Length { get { return _part2.length; } set { _part2.length = value; } }
        [Category("Note Event")]
        public uint Decay { get { return _part2.noteIndex; } set { _part2.noteIndex = value; } }

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
        [Category("Note Info"), Browsable(true), TypeConverter(typeof(DropDownListRWSDSounds))]
        public string Wave
        {
            get { return _soundNode == null ? null : _soundNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    Sound = null;
                else
                {
                    RSARFileAudioNode node = null;
                    int t = 0;
                    foreach (RSARFileAudioNode r in Parent.Parent.Children[1].Children)
                    {
                        if (r.Name == value) { node = r; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        Sound = node;
                        _part3._waveIndex = t;
                        SignalPropertyChange();
                    }
                }
            }
        }
        //[Category("Note Info")]
        //public int WaveIndex { get { return _part3._waveIndex; } set { _part3._waveIndex = value; } }
        [Category("Note Info")]
        public byte Attack { get { return _part3._attack; } set { _part3._attack = value; } }
        [Category("Note Info")]
        public byte InfoDecay { get { return _part3._decay; } set { _part3._decay = value; } }
        [Category("Note Info")]
        public byte Sustain { get { return _part3._sustain; } set { _part3._sustain = value; } }
        [Category("Note Info")]
        public byte Release { get { return _part3._release; } set { _part3._release = value; } }
        [Category("Note Info")]
        public byte Hold { get { return _part3._hold; } set { _part3._hold = value; } }
        [Category("Note Info")]
        public byte OriginalKey { get { return _part3._originalKey; } set { _part3._originalKey = value; } }
        [Category("Note Info")]
        public byte Volume { get { return _part3._volume; } set { _part3._volume = value; } }
        [Category("Note Info")]
        public byte InfoPan { get { return _part3._pan; } set { _part3._pan = value; } }
        [Category("Note Info")]
        public byte InfoSurroundPan { get { return _part3._surroundPan; } set { _part3._surroundPan = value; } }
        [Category("Note Info")]
        public float InfoPitch { get { return _part3._pitch; } set { _part3._pitch = value; } }

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

        //[Category("Data Note Event")]
        //public List<RWSD_NoteEvent> Part2 { get { return _part2; } }
        //[Category("Data Note Info")]
        //public List<RWSD_NoteInfo> Part3 { get { return _part3; } }

        protected override bool OnInitialize()
        {
            RuintList* list;
            
            _part1 = *Header->GetWsdInfo(_offset);

            list = Header->GetTrackTable(_offset); //Count is always 1
            ruint* r = (ruint*)list->Get(_offset, 0);
            RuintList* l = (RuintList*)r->Offset(_offset);
            _part2 = *(RWSD_NoteEvent*)l->Get(_offset, 0);

            list = Header->GetNoteTable(_offset); //Count is always 1
            _part3 = *(RWSD_NoteInfo*)list->Get(_offset, 0);

            if (_name == null)
                _name = String.Format("Sound[{0}]", Index);

            if (Parent.Parent.Children.Count > 1 && _part3._waveIndex < Parent.Parent.Children[1].Children.Count)
                _soundNode = Parent.Parent.Children[1].Children[_part3._waveIndex] as RSARFileAudioNode;

            SetSizeInternal((RWSD_DATAEntry.Size + RWSD_WSDEntry.Size + 0x20 + RWSD_NoteEvent.Size + 12 + RWSD_NoteInfo.Size));

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return (RWSD_DATAEntry.Size + RWSD_WSDEntry.Size + 0x20 + RWSD_NoteEvent.Size + 12 + RWSD_NoteInfo.Size);
        }
        public VoidPtr _baseAddr;
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;

            RWSD_DATAEntry* header = (RWSD_DATAEntry*)addr;

            addr += RWSD_DATAEntry.Size;

            header->_wsdInfo = (int)(addr - _baseAddr);
            RWSD_WSDEntry* wsd = (RWSD_WSDEntry*)addr;
            *wsd = _part1;
            addr += RWSD_WSDEntry.Size;

            header->_trackTable = (int)(addr - _baseAddr);
            RuintList* list = (RuintList*)addr;
            addr += 12;

            list->_numEntries = 1;
            list->Entries[0] = (int)(addr - _baseAddr);

            ruint* r = (ruint*)addr;
            addr += 8;

            *r = (int)(addr - _baseAddr);

            RuintList* list2 = (RuintList*)addr;
            addr += 12;

            list2->_numEntries = 1;
            list2->Entries[0] = (int)(addr - _baseAddr);

            RWSD_NoteEvent* ev = (RWSD_NoteEvent*)addr;
            *ev = _part2;
            addr += RWSD_NoteEvent.Size;

            header->_noteTable = (int)(addr - _baseAddr);
            RuintList* list3 = (RuintList*)addr;
            addr += 12;

            list3->_numEntries = 1;
            list3->Entries[0] = (int)(addr - _baseAddr);

            RWSD_NoteInfo* info = (RWSD_NoteInfo*)addr;
            *info = _part3;
            addr += RWSD_NoteInfo.Size;
        }

        public override void Remove()
        {
            foreach (RSARSoundNode n in _refs)
                n.SoundDataNode = null;

            base.Remove();
        }
    }
}
