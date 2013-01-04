using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Audio;
using BrawlLib.Wii.Audio;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARSoundNode : RSAREntryNode, IAudioSource
    {
        internal INFOSoundEntry* Header { get { return (INFOSoundEntry*)WorkingUncompressed.Address; } }
        
        [Browsable(false)]
        internal override int StringId { get { return Header->_stringId; } }

        public override ResourceType ResourceType { get { return ResourceType.RSARSound; } }

        [Browsable(false)]
        public int volume { get { return _volume; } set { _volume = (byte)value; } }
        [Browsable(false)]
        public int pan { get { return _panCurve; } set { _panCurve = (byte)value; } }

        Sound3DParam _sound3dParam;
        WaveSoundInfo _waveInfo = new WaveSoundInfo();
        StrmSoundInfo _strmInfo = new StrmSoundInfo();
        SeqSoundInfo _seqInfo = new SeqSoundInfo();

        public enum SndType
        {
            //Invalid = 0,

            SEQ = 1,
            STRM = 2,
            WAVE = 3
        }

        public int _fileId;
        public int _playerId;
        public byte _volume;
        public byte _playerPriority;
        public byte _soundType;
        public byte _remoteFilter;
        public byte _panMode;
        public byte _panCurve;
        public byte _actorPlayerId;

        ResourceNode _soundNode;

        //internal VoidPtr _dataAddr;

        [Browsable(false)]
        public ResourceNode SoundNode
        {
            get { return _soundNode; }
            set
            {
                if (_soundNode != value)
                    _soundNode = value;
            }
        }
        [Category("a RSAR Sound"), Browsable(true), TypeConverter(typeof(DropDownListRSARFiles))]
        public string SoundFile
        {
            get { return _soundNode == null ? "<null>" : _soundNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    SoundNode = null;
                else
                {
                    Type e;
                    switch (SoundType)
                    {
                        //case SndType.Invalid: 
                        default: return;
                        case SndType.SEQ: e = typeof(RSEQNode); break;
                        case SndType.STRM: e = typeof(RSTMNode); break;
                        case SndType.WAVE: e = typeof(RWSDNode); break;
                    }
                    ResourceNode node = null; int t = 0;
                    foreach (ResourceNode r in RSARNode.Files)
                    {
                        if (r.Name == value) { node = r; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        SoundNode = node;
                        _fileId = t;
                        SignalPropertyChange();
                    }
                }
            }
        }
        RSARBankNode _rbnk 
        {
            get
            {
                if (SoundType == SndType.SEQ && _seqInfo._bankId < RSARNode._infoCache[1].Count)
                    return RSARNode._infoCache[1][_seqInfo._bankId] as RSARBankNode;
                else return null;
            }
        }
        [Category("a RSAR Sound")]
        public int PlayerId { get { return _playerId; } set { _playerId = value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public byte Volume { get { return _volume; } set { _volume = value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public byte PlayerPriority { get { return _playerPriority; } set { _playerPriority = value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public SndType SoundType { get { return (SndType)_soundType; } set { _soundType = ((byte)value).Clamp(1, 3); SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public byte RemoteFilter { get { return _remoteFilter; } set { _remoteFilter = value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public PanMode PanMode { get { return (PanMode)_panMode; } set { _panMode = (byte)value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public PanCurve PanCurve { get { return (PanCurve)_panCurve; } set { _panCurve = (byte)value; SignalPropertyChange(); } }
        [Category("a RSAR Sound")]
        public byte ActorPlayerId { get { return _actorPlayerId; } set { _actorPlayerId = value; SignalPropertyChange(); } }

        [Flags]
        public enum Sound3DFlags
        {        
            NotVolume = 1,
            NotPan = 2,
            NotSurroundPan = 4,
            NotPriority = 8,
            Filter = 16
        }

        [Category("b RSAR Sound 3D Param")]
        public Sound3DFlags Flags { get { return (Sound3DFlags)(uint)_sound3dParam._flags; } set { _sound3dParam._flags = (uint)value; SignalPropertyChange(); } }
        [Category("b RSAR Sound 3D Param")]
        public DecayCurve DecayCurve { get { return (DecayCurve)_sound3dParam._decayCurve; } set { _sound3dParam._decayCurve = (byte)value; SignalPropertyChange(); } }
        [Category("b RSAR Sound 3D Param")]
        public byte DecayRatio { get { return _sound3dParam._decayRatio; } set { _sound3dParam._decayRatio = value; SignalPropertyChange(); } }
        [Category("b RSAR Sound 3D Param")]
        public byte DopplerFactor { get { return _sound3dParam._dopplerFactor; } set { _sound3dParam._dopplerFactor = value; SignalPropertyChange(); } }

        RSEQLabelNode labl;

        [Category("c RSAR Seq Sound Info"), Browsable(true), TypeConverter(typeof(DropDownListRSARInfoSeqLabls))]
        public string SeqLabelEntry
        {
            get { return labl == null ? "<null>" : labl._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    _seqInfo._dataOffset = 0;
                else
                {
                    if (SoundNode is RSEQNode)
                        foreach (RSEQLabelNode r in SoundNode.Children)
                            if (r.Name == value)
                            {
                                _seqInfo._dataOffset = r.Id;
                                SignalPropertyChange(); 
                                break;
                            }
                }
            }
        }

        //[Category("c RSAR Seq Sound Info")]
        //public uint SeqEntryId { get { return _seqInfo._dataOffset; } set { _seqInfo._dataOffset = value; SignalPropertyChange(); } }
        //[Category("c RSAR Seq Sound Info")]
        //public uint BankId { get { return _seqInfo._bankId; } set { _seqInfo._bankId = value; SignalPropertyChange(); } }
        [Category("c RSAR Seq Sound Info"), Browsable(true), TypeConverter(typeof(DropDownListRSARFiles))]
        public string BankFile
        {
            get { return _rbnk == null ? "<null>" : _rbnk.TreePath; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    _seqInfo._bankId = -1;
                else
                {
                    RSARBankNode node = null; int t = 0;
                    foreach (ResourceNode r in RSARNode._infoCache[1])
                    {
                        if (r.Name == value && r is RSARBankNode) { node = r as RSARBankNode; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        _seqInfo._bankId = t;
                        SignalPropertyChange();
                    }
                }
            }
        }
        [Category("c RSAR Seq Sound Info"), TypeConverter(typeof(Bin32StringConverter))]
        public Bin32 SeqAllocTrack { get { return new Bin32(_seqInfo._allocTrack); } set { _seqInfo._allocTrack = value._data; SignalPropertyChange(); } }
        [Category("c RSAR Seq Sound Info")]
        public byte SeqChannelPriority { get { return _seqInfo._channelPriority; } set { _seqInfo._channelPriority = value; SignalPropertyChange(); } }
        [Category("c RSAR Seq Sound Info")]
        public byte SeqReleasePriorityFix { get { return _seqInfo._releasePriorityFix; } set { _seqInfo._releasePriorityFix = value; SignalPropertyChange(); } }
        
        [Category("d RSAR Strm Sound Info")]
        public uint StartPosition { get { return _strmInfo._startPosition; } set { _strmInfo._startPosition = value; SignalPropertyChange(); } }
        [Category("d RSAR Strm Sound Info")]
        public ushort AllocChannelCount { get { return _strmInfo._allocChannelCount; } set { _strmInfo._allocChannelCount = value; SignalPropertyChange(); } }
        [Category("d RSAR Strm Sound Info")]
        public ushort AllocTrackFlag { get { return _strmInfo._allocTrackFlag; } set { _strmInfo._allocTrackFlag = value; SignalPropertyChange(); } }

        ResourceNode _dataNode
        {
            get
            {
                if (SoundType == SndType.WAVE && _soundNode != null && !(_soundNode is RSARExtFileNode) && _soundNode.Children[0].Children.Count > _waveInfo._soundIndex && _waveInfo._soundIndex >= 0)
                    return _soundNode.Children[0].Children[_waveInfo._soundIndex] as RWSDDataNode;
                else 
                    return null;
            }
        }
        [Category("e RSAR Wave Sound Info"), Browsable(true), TypeConverter(typeof(DropDownListRSARInfoSound))]
        public string SoundDataNode
        {
            get { return _dataNode == null ? "<null>" : _dataNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    _waveInfo._soundIndex = -1;
                else
                {
                    if (SoundNode == null) return;

                    ResourceNode node = null; int t = 0;
                    foreach (ResourceNode r in SoundNode.Children[0].Children)
                    {
                        if (r.Name == value) { node = r; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        _waveInfo._soundIndex = t;
                        SignalPropertyChange();
                    }
                }
            }
        }
        //[Category("e RSAR Wave Sound Info")]
        //public int PackIndex { get { return _waveInfo._soundIndex; } set { _waveInfo._soundIndex = value; SignalPropertyChange(); } }
        [Category("e RSAR Wave Sound Info")]
        public uint AllocTrack { get { return _waveInfo._allocTrack; } set { _waveInfo._allocTrack = value; SignalPropertyChange(); } }
        [Category("e RSAR Wave Sound Info")]
        public byte ChannelPriority { get { return _waveInfo._channelPriority; } set { _waveInfo._channelPriority = value; SignalPropertyChange(); } }
        [Category("e RSAR Wave Sound Info")]
        public byte ReleasePriorityFix { get { return _waveInfo._releasePriorityFix; } set { _waveInfo._releasePriorityFix = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _fileId = Header->_fileId;
            _playerId = Header->_playerId;
            _volume = Header->_volume;
            _playerPriority = Header->_playerPriority;
            _soundType = Header->_soundType;
            _remoteFilter = Header->_remoteFilter;
            _panMode = Header->_panMode;
            _panCurve = Header->_panCurve;
            _actorPlayerId = Header->_actorPlayerId;

            INFOHeader* info = RSARNode.Header->INFOBlock;
            _sound3dParam = *Header->GetParam3dRef(&info->_collection);

            VoidPtr addr = Header->GetSoundInfoRef(&info->_collection);
            switch (Header->_soundInfoRef._dataType)
            {
                case 1:
                    _seqInfo = *(SeqSoundInfo*)addr;
                    break;
                case 2:
                    _strmInfo = *(StrmSoundInfo*)addr;
                    break;
                case 3:
                    _waveInfo = *(WaveSoundInfo*)addr;
                    break;
            }

            _soundNode = RSARNode.Files[_fileId];

            if (SoundNode is RSEQNode)
                foreach (RSEQLabelNode r in SoundNode.Children)
                    if (_seqInfo._dataOffset == r.Id) { labl = r; break; }

            return false;
        }

        public IAudioStream CreateStream()
        {
            if (_soundNode is RWSDNode)
            {
                RWSDDataNode d = _dataNode as RWSDDataNode;
                if (d == null) return null;
                WAVESoundNode s = _soundNode.Children[1].Children[d._part3._waveIndex] as WAVESoundNode;
                IAudioStream stream = s.CreateStream();
                
                return stream;
            }
            else
                return null;
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = INFOSoundEntry.Size + Sound3DParam.Size;
            switch (SoundType)
            {
                case RSARSoundNode.SndType.SEQ:
                    size += SeqSoundInfo.Size;
                    break;
                case RSARSoundNode.SndType.STRM:
                    size += StrmSoundInfo.Size;
                    break;
                case RSARSoundNode.SndType.WAVE:
                    size += WaveSoundInfo.Size;
                    break;
            }
            return size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            INFOSoundEntry* header = (INFOSoundEntry*)address;
            VoidPtr addr = address + INFOSoundEntry.Size;
            header->_stringId = _rebuildStringId;
            header->_fileId = _fileId;
            header->_playerId = _playerId;
            header->_volume = _volume;
            header->_playerPriority = _playerPriority;
            header->_soundType = _soundType;
            header->_remoteFilter = _remoteFilter;
            header->_panMode = _panMode;
            header->_panCurve = _panCurve;
            header->_actorPlayerId = _actorPlayerId;
            header->_soundInfoRef = (uint)(addr - _rebuildBase);
            switch (SoundType)
            {
                case RSARSoundNode.SndType.SEQ:
                    *(SeqSoundInfo*)addr = _seqInfo;
                    header->_soundInfoRef._dataType = 1;
                    addr += SeqSoundInfo.Size;
                    break;
                case RSARSoundNode.SndType.STRM:
                    *(StrmSoundInfo*)addr = _strmInfo;
                    header->_soundInfoRef._dataType = 2;
                    addr += StrmSoundInfo.Size;
                    break;
                case RSARSoundNode.SndType.WAVE:
                    *(WaveSoundInfo*)addr = _waveInfo;
                    header->_soundInfoRef._dataType = 3;
                    addr += WaveSoundInfo.Size;
                    break;
            }
            header->_param3dRefOffset = (uint)(addr - _rebuildBase);
            *(Sound3DParam*)addr = _sound3dParam;
        }

        public override unsafe void Export(string outPath)
        {
            if (outPath.EndsWith(".wav"))
                WAV.ToFile(CreateStream(), outPath);
            else
                base.Export(outPath);
        }
    }
}
