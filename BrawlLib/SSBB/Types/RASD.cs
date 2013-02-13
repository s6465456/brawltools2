﻿using System;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    unsafe struct RASD //Align all data to 0x20
    {
        public const uint Tag = 0x44534152;
        public const uint Size = 0x10;

        public NW4RCommonHeader _header;
        public buint _dataBlockOffset;
        public buint _dataBlockSize;
        
        //Align to 0x20

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public DataBlock DataBlock { get { return new DataBlock(Address, Size); } }
        public DataBlockCollection Entries { get { return new DataBlockCollection(DataBlock); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RASDDataBlock
    {
        public const uint Tag = 0x41544144;

        public uint _tag;
        public bint _length;
        public bint _frameSize;
        public ruint _eventTableOffset;

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RASDEventTable
    {
        public buint _count;

        AnimEventRef* Entries { get { return (AnimEventRef*)(Address + 4); } }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct AnimEventRef
    {
        AnimEventFrameInfo _frameInfo;
        public ruint _animEventOffset;

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct AnimEvent
    {
        public buint _optionFlag;
        public buint _soundId;
        public ruint _soundNameRef;
        public byte _volume;
        public fixed byte _reserved1[3];
        public bfloat _pitch;
        public buint _reserved2;
        public buint _userParam;
        
        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct AnimEventFrameInfo
    {
        public int _startFrame;     // event start frame
        public int _endFrame;       // event end frame
        public byte _frameFlag;     // frame processing option flag
        public sbyte _loopOffset;   // number of playback loops
        public byte _loopInterval;  // playback loop interval after loopCount
        public byte _reserved;

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    public enum FrameFlag
    {
        TriggerEvent = 1, // trigger-type event
        EndFrameInfinite = 2, // end frame is infinitely large
        StartFrameInfinite = 4 // start frame is infinitely large negative number
    }
}
