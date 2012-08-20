using System;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSDHeader
    {
        public const uint Tag = 0x44535752;
        public const int Size = 0x20;

        public SSBBCommonHeader _header;

        public bint _dataOffset;
        public bint _dataLength;
        public bint _waveOffset;
        public bint _waveLength;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public RWSD_DATAHeader* Data { get { return (RWSD_DATAHeader*)(Address + _dataOffset); } }
        public RWSD_WAVEHeader* Wave { get { return (RWSD_WAVEHeader*)(Address + _waveOffset); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_DATAHeader
    {
        public const uint Tag = 0x41514144;

        public uint _tag;
        public bint _length;
        public RuintList _list;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_DATAEntry
    {
        public ruint _wsdInfo;
        public ruint _trackTable;
        public ruint _noteTable;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public RWSD_WSDEntry* GetPart1(VoidPtr offset) { return (RWSD_WSDEntry*)_wsdInfo.Offset(offset); }
        public RuintList* GetPart2(VoidPtr offset) { return (RuintList*)_trackTable.Offset(offset); }
        public RuintList* GetPart3(VoidPtr offset) { return (RuintList*)_noteTable.Offset(offset); }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_WSDEntry
    {
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
        public bfloat position;
        public bfloat length;
        public buint noteIndex;
        public buint reserved;
    }

    //These entries are embedded in a list, using RuintList
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RWSD_NoteInfo
    {
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
    unsafe struct RWSD_WAVEHeader
    {
        public const uint Tag = 0x45564157;

        public buint _tag;
        public buint _length;
        public bint _entries;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public bint* Entries { get { return (bint*)(Address + 12); } }

        public RWSD_WAVEEntry* GetEntry(int index) { return (RWSD_WAVEEntry*)(Address + Entries[index]); }
    }

    enum WaveDataLocationType
    {
        WAVE_DATA_LOCATION_OFFSET = 0,
        WAVE_DATA_LOCATION_ADDRESS = 1
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RWSD_WAVEEntry
    {
        public const int Size = 0x3C + 0x2E;

        public AudioFormatInfo _format;

        public bushort _sampleRate;
        public byte _dataLocationType; //WaveDataLocationType
        public byte _pad;
        public buint _loopStartSample;
        public bint _nibbles; //Includes ALL data, not just samples
        public bint _channelInfoTableOffset; //0x1C
        public bint _offset; //Data offset from beginning of sample block
        public bint _reserved; //0

        public bint _unk6; //0x20
        public bint _unk7; //0
        public bint _unk8; //0x3C
        public int _unk9; //1
        public int _unk10; //1
        public int _unk11; //1
        public int _unk12; //1
        public int _unk13; //0

        public ADPCMInfo _adpcInfo;

        public ADPCMInfo* Info { get { return (ADPCMInfo*)(Address + 0x3C); } }
        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public int NumSamples { get { return (_nibbles / 16 * 14) + ((_nibbles % 16) - 2); } }
    }
}
