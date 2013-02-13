﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Textures;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PLT0v1
    {
        public const int Size = 0x40;
        public const uint Tag = 0x30544C50;

        public BRESCommonHeader _bresEntry;
        public buint _headerLen;
        public buint _stringOffset;
        public buint _pixelFormat;
        public bshort _numEntries;
        public bushort _pad;
        public bint _origPathOffset;

        private PLT0v1* Address { get { fixed (PLT0v1* ptr = &this)return ptr; } }

        public string OrigPath { get { return new String((sbyte*)OrigPathAddress); } }
        public VoidPtr OrigPathAddress
        {
            get { return Address + _origPathOffset; }
            set { _origPathOffset = (int)value - (int)Address; }
        }
        public string ResourceString { get { return new String((sbyte*)this.ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)this.Address + _stringOffset; }
            set { _stringOffset = (uint)value - (uint)this.Address; }
        }
        public VoidPtr PaletteData { get { return (VoidPtr)this.Address + _headerLen; } }
        public WiiPaletteFormat PaletteFormat
        {
            get { return (WiiPaletteFormat)(uint)_pixelFormat; }
            set { _pixelFormat = (uint)value; }
        }

        public PLT0v1(int length, WiiPaletteFormat format)
        {
            _bresEntry._tag = Tag;
            _bresEntry._size = (length * 2) + Size;
            _bresEntry._version = 1;
            _bresEntry._bresOffset = 0;

            _headerLen = 0x40;
            _stringOffset = 0;
            _pixelFormat = (uint)format;
            _numEntries = (short)length;
            _pad = 0;
            _origPathOffset = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PLT0v3
    {
        public const int Size = 0x44;
        public const uint Tag = 0x30544C50;

        public BRESCommonHeader _bresEntry;
        public buint _headerLen;
        public buint _stringOffset;
        public buint _pixelFormat;
        public bshort _numEntries;
        public bushort _pad;
        public bint _origPathOffset;
        public bint _userDataOffset;

        //User Data comes before palette data. Align to 0x20

        private PLT0v3* Address { get { fixed (PLT0v3* ptr = &this)return ptr; } }

        public string OrigPath { get { return new String((sbyte*)OrigPathAddress); } }
        public VoidPtr OrigPathAddress
        {
            get { return Address + _origPathOffset; }
            set { _origPathOffset = (int)value - (int)Address; }
        }
        public UserData* UserData
        {
            get { return (UserData*)(Address + _userDataOffset); }
            set { _userDataOffset = (int)(VoidPtr)value - (int)Address; }
        }

        public string ResourceString { get { return new String((sbyte*)this.ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)this.Address + _stringOffset; }
            set { _stringOffset = (uint)value - (uint)this.Address; }
        }
        public VoidPtr PaletteData { get { return (VoidPtr)this.Address + _headerLen; } }
        public WiiPaletteFormat PaletteFormat
        {
            get { return (WiiPaletteFormat)(uint)_pixelFormat; }
            set { _pixelFormat = (uint)value; }
        }

        public PLT0v3(int length, WiiPaletteFormat format)
        {
            _bresEntry._tag = Tag;
            _bresEntry._size = (length * 2) + Size;
            _bresEntry._version = 1;
            _bresEntry._bresOffset = 0;

            _headerLen = Size;
            _stringOffset = 0;
            _pixelFormat = (uint)format;
            _numEntries = (short)length;
            _pad = 0;
            _origPathOffset = 0;
            _userDataOffset = 0;
        }
    }
}
