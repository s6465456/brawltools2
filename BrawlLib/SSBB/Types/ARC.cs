﻿using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ARCHeader
    {
        public const int Size = 0x40;
        public const uint Tag = 0x00435241;

        public uint _tag; //ARC
        public ushort _version; //0x0101
        public bushort _numFiles;
        uint _unk1;
        uint _unk2;
        fixed sbyte _name[48];

        internal VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public string Name 
        { 
            get { return new String((sbyte*)Address + 0x10); }
            set
            {
                if (value == null) 
                    value = "";

                fixed (sbyte* ptr = _name)
                {
                    int i = 0;
                    while ((i < 47) && (i < value.Length))
                        ptr[i] = (sbyte)value[i++];

                    while (i < 48) ptr[i++] = 0;
                }
            }
        }

        public ARCFileHeader* First { get { return (ARCFileHeader*)(Address + Size); } }

        public ARCHeader(ushort numFiles, string name)
        {
            _tag = Tag;
            _version = 0x0101;
            _numFiles = numFiles;
            _unk1 = 0;
            _unk2 = 0;
            Name = name;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ARCFileHeader
    {
        public const int Size = 0x20;

        internal bshort _type;
        internal bshort _index;
        internal bint _size;
        internal byte _groupIndex;
        internal byte _unk1;
        internal bshort _id;
        internal bint _pad1;
        internal bint _pad2;
        internal bint _pad3;
        internal bint _pad4;
        internal bint _pad5;

        public ARCFileHeader(ARCFileType type, int index, int size, byte groupIndex, byte unk1, short id)
        {
            _type = (short)type;
            _index = (short)index;
            _size = size;
            _groupIndex = groupIndex;
            _unk1 = unk1;
            _id = id;
            _pad1 = _pad2 = _pad3 = _pad4 = _pad5 = 0;
        }

        private ARCFileHeader* Address { get { fixed (ARCFileHeader* ptr = &this)return ptr; } }

        public VoidPtr Data { get { return (VoidPtr)Address + Size; } }
        public ARCFileHeader* Next { get { return (ARCFileHeader*)((uint)(Data + _size)).Align(Size); } }

        public ARCFileType FileType
        {
            get { return (ARCFileType)(short)_type; }
            set { _type = (short)value; }
        }
        public short Index { get { return _index; } set { _index = value; } }
        public int Length { get { return _size; } set { _size = value; } }
        public byte GroupIndex { get { return _groupIndex; } set { _groupIndex = value; } }
        public byte Unknown { get { return _unk1; } set { _unk1 = value; } }
        public short ID { get { return _id; } set { _id = value; } }
    }

    public enum ARCFileType : short
    {
        None = 0x0,
        MiscData = 0x1,
        ModelData = 0x2,
        TextureData = 0x3,
        AnimationData = 0x4,
        SceneData = 0x5,
        Type6 = 0x6,
        Type7 = 0x7,
        ARChive = 0x8
    }
}