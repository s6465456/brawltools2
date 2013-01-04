using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSDHeader
    {
        public const uint Tag = 0x44535752;
        public const int Size = 0x20;

        public NW4RCommonHeader _header;

        public bint _dataOffset;
        public bint _dataLength;
        public bint _waveOffset;
        public bint _waveLength;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public RWSD_DATAHeader* Data { get { return (RWSD_DATAHeader*)(Address + _dataOffset); } }
        public WAVEHeader* Wave { get { return (WAVEHeader*)(Address + _waveOffset); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_DATAHeader
    {
        public const uint Tag = 0x41544144;

        public uint _tag;
        public bint _length;
        public RuintList _list; //control = 0x0100

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_DATAEntry
    {
        //Base of these offsets is the address of _list in the main data header

        public const int Size = 24;

        public ruint _wsdInfo;
        public ruint _trackTable;
        public ruint _noteTable;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        
        public RWSD_WSDEntry* GetWsdInfo(VoidPtr offset) { return (RWSD_WSDEntry*)_wsdInfo.Offset(offset); }
        public RuintList* GetTrackTable(VoidPtr offset) { return (RuintList*)_trackTable.Offset(offset); }
        public RuintList* GetNoteTable(VoidPtr offset) { return (RuintList*)_noteTable.Offset(offset); }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RWSD_WSDEntry
    {
        public const int Size = 0x20;

        public bfloat _pitch;
        public byte _pan;
        public byte _surroundPan;
        public byte _fxSendA;
        public byte _fxSendB;
        public byte _fxSendC;
        public byte _mainSend;
        public byte _pad1;
        public byte _pad2;
        public ruint _graphEnvTablevRef;
        public ruint _randomizerTableRef;
        public bint _reserved;
    }

    //These entries are embedded in a list of lists, using RuintList
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RWSD_NoteEvent
    {
        public const int Size = 0x10;

        public bfloat position;
        public bfloat length;
        public buint noteIndex;
        public buint reserved;
    }

    //These entries are embedded in a list, using RuintList
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RWSD_NoteInfo
    {
        public const int Size = 0x30;

        public bint _waveIndex;
        public byte _attack;
        public byte _decay;
        public byte _sustain;
        public byte _release;
        public byte _hold;
        public byte _pad1;
        public byte _pad2;
        public byte _pad3;
        public byte _originalKey;
        public byte _volume;
        public byte _pan;
        public byte _surroundPan;
        public bfloat _pitch; //1.0
        public ruint _lfoTableRef;
        public ruint _graphEnvTablevRef;
        public ruint _randomizerTableRef;
        public bint _reserved; //0
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct WAVEHeader
    {
        public const uint Tag = 0x45564157;

        public uint _tag;
        public bint _length;
        public bint _numEntries;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public bint* Entries { get { return (bint*)(Address + 12); } }

        public WaveInfo* GetEntry(int index) { return (WaveInfo*)(Address + Entries[index]); }
    }

    enum WaveDataLocationType
    {
        Offset = 0,
        Address = 1
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct WaveInfo
    {
        public const int Size = 0x1C;

        public AudioFormatInfo _format;

        public bushort _sampleRate;
        public byte _dataLocationType; //WaveDataLocationType
        public byte _pad;
        public buint _loopStartSample;
        public bint _nibbles; //Includes ALL data, not just samples
        public buint _channelInfoTableOffset; //0x1C, offset to bint offset array for each channel
        public buint _dataLocation;
        public buint _reserved; //0

        public buint* OffsetTable { get { return (buint*)(Address + _channelInfoTableOffset); } }
        public ChannelInfo* GetChannelInfo(int index) { return (ChannelInfo*)(Address + OffsetTable[index]); }
        public ADPCMInfo* GetADPCMInfo(int index) { return (ADPCMInfo*)(Address + GetChannelInfo(index)->_adpcmInfoOffset); }
        
        public int NumSamples { get { return (_nibbles / 16 * 14) + ((_nibbles % 16) - 2); } }
        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ChannelInfo
    {
        public const int Size = 0x1C;

        public bint _channelDataOffset; //offset to samples to read
        public bint _adpcmInfoOffset; //offset to ADPCMInfo from start of WaveInfo struct
        public int _volFrontLeft; //1
        public int _volFrontRight; //1
        public int _volBackLeft; //1
        public int _volBackRight; //1
        public bint _reserved; //0

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
