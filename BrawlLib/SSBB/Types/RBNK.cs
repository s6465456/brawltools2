using System;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RBNKHeader
    {
        public const uint Tag = 0x4B4E4252;

        public SSBBCommonHeader _header;

        public bint _dataOffset;
        public bint _dataLength;
        public bint _waveOffset;
        public bint _waveLength;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public RBNK_DATAHeader* Data { get { return (RBNK_DATAHeader*)(Address + _dataOffset); } }
        public RWSD_WAVEHeader* Wave { get { return (RWSD_WAVEHeader*)(Address + _waveOffset); } } //Uses same format as RWSD
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RBNK_DATAHeader
    {
        public const uint Tag = 0x41544144;

        public uint _tag;
        public bint _length;
        public RuintList _list; //control == 0x0102

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    public enum WaveDataLocation
    {
        WAVE_DATA_LOCATION_INDEX = 0,
        WAVE_DATA_LOCATION_ADDRESS = 1,
        WAVE_DATA_LOCATION_CALLBACK = 2
    }

    public enum NoteOffType
    {
        NOTE_OFF_TYPE_RELEASE = 0,
        NOTE_OFF_TYPE_IGNORE = 1
    }

    //These entries are embedded in a list, using RuintList
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RBNK_InstParam
    {
        public bint _waveIndex;
        public byte _attack;
        public byte _decay;
        public byte _sustain;
        public byte _release;
        public byte _hold;
        public byte _waveDataLocationType;
        public byte _noteOffType;
        public byte _alternateAssign;
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
    unsafe struct RBNK_DATAEntry
    {

    }
}
