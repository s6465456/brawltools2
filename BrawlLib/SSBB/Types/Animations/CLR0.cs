﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct CLR0v3
    {
        public const int Size = 0x24;
        public const string Tag = "CLR0";

        public BRESCommonHeader _header;
        public bint _dataOffset;
        public bint _stringOffset;
        public bint _origPathOffset;
        public bushort _frames;
        public bushort _entries;
        public bint _loop;

        public CLR0v3(int size, int frames, int entries, int loop)
        {
            _header._tag = Tag;
            _header._size = size;
            _header._bresOffset = 0;
            _header._version = 3;
            
            _dataOffset = Size;
            _stringOffset = 0;
            _origPathOffset = 0;
            _frames = (ushort)frames;
            _entries = (ushort)entries;
            _loop = loop;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceGroup* Group { get { return (ResourceGroup*)(Address + _dataOffset); } }

        public string OrigPath { get { return new String((sbyte*)OrigPathAddress); } }
        public VoidPtr OrigPathAddress
        {
            get { return Address + _origPathOffset; }
            set { _origPathOffset = (int)value - (int)Address; }
        }

        public string ResourceString { get { return new String((sbyte*)this.ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct CLR0v4
    {
        public const int Size = 0x28;
        public const string Tag = "CLR0";

        public BRESCommonHeader _header;
        public bint _dataOffset;
        public bint _userDataOffset;
        public bint _stringOffset;
        public bint _origPathOffset;
        public bushort _frames;
        public bushort _entries;
        public bint _loop;

        public CLR0v4(int size, int frames, int entries, int loop)
        {
            _header._tag = Tag;
            _header._size = size;
            _header._bresOffset = 0;
            _header._version = 4;

            _userDataOffset = 0;
            _dataOffset = Size;
            _stringOffset = 0;
            _origPathOffset = 0;
            _frames = (ushort)frames;
            _entries = (ushort)entries;
            _loop = loop;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceGroup* Group { get { return (ResourceGroup*)(Address + _dataOffset); } }

        public VoidPtr UserData
        {
            get { return _userDataOffset == 0 ? null : Address + _userDataOffset; }
            set { _userDataOffset = (int)(VoidPtr)value - (int)Address; }
        }

        public string OrigPath { get { return new String((sbyte*)OrigPathAddress); } }
        public VoidPtr OrigPathAddress
        {
            get { return Address + _origPathOffset; }
            set { _origPathOffset = (int)value - (int)Address; }
        }

        public string ResourceString { get { return new String((sbyte*)this.ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [Flags]
    public enum CLR0EntryFlags : uint
    {
        Material0Exists = 0x1,
        Material0Constant = 0x2,
        Material1Exists = 0x4,
        Material1Constant = 0x8,
        Ambient0Exists = 0x10,
        Ambient0Constant = 0x20,
        Ambient1Exists = 0x40,
        Ambient1Constant = 0x80,
        TevReg0Exists = 0x100,
        TevReg0Constant = 0x200,
        TevReg1Exists = 0x400,
        TevReg1Constant = 0x800,
        TevReg2Exists = 0x1000,
        TevReg2Constant = 0x2000,
        TevKonst0Exists = 0x4000,
        TevKonst0Constant = 0x8000,
        TevKonst1Exists = 0x10000,
        TevKonst1Constant = 0x20000,
        TevKonst2Exists = 0x40000,
        TevKonst2Constant = 0x80000,
        TevKonst3Exists = 0x100000,
        TevKonst3Constant = 0x200000,
    }

    public enum EntryTarget
    {
        Color0,        // GX_COLOR0A0
        Color1,        // GX_COLOR1A1
        Ambient0,      // GX_COLOR0A0
        Ambient1,      // GX_COLOR1A1
        TevColorReg0,  // GX_TEVREG0
        TevColorReg1,  // GX_TEVREG1
        TevColorReg2,  // GX_TEVREG2
        TevKonstReg0,  // GX_KCOLOR0
        TevKonstReg1,  // GX_KCOLOR1
        TevKonstReg2,  // GX_KCOLOR2
        TevKonstReg3,  // GX_KCOLOR3
    }

    [Flags]
    public enum EntryFlag
    {
        Exists = 0x1,
        Constant = 0x2
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct CLR0Material
    {
        public const int Size = 8;

        public bint _stringOffset;
        public buint _flags;

        public CLR0Material(CLR0EntryFlags flags, ABGRPixel mask, int offset)
        {
            _stringOffset = 0;
            _flags = (uint)flags;
        }
        public CLR0Material(CLR0EntryFlags flags, ABGRPixel mask, ABGRPixel color)
        {
            _stringOffset = 0;
            _flags = (uint)flags;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public CLR0EntryFlags Flags { get { return (CLR0EntryFlags)(uint)_flags; } set { _flags = (uint)value; } }

        public string ResourceString { get { return new String((sbyte*)this.ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)this.Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct CLR0MaterialEntry
    {
        public ABGRPixel _colorMask; //Used as a mask for source color before applying frames
        public bint _data;

        public ABGRPixel SolidColor { get { return *(ABGRPixel*)(Address + 4); } set { *(ABGRPixel*)(Address + 4) = value; } }
        public ABGRPixel* Data { get { return (ABGRPixel*)(Address + _data + 4); } }

        public CLR0MaterialEntry(ABGRPixel mask, ABGRPixel color) 
        {
            _colorMask = mask;
            _data._data = *(int*)&color;
        }

        public CLR0MaterialEntry(ABGRPixel mask, int offset)
        {
            _colorMask = mask;
            _data = offset;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
