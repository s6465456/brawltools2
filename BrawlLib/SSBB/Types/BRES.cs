﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BRESHeader// : IEnumerable<VoidPtr>
    {
        public const string Tag = "bres";
        public const int Size = 16;

        public BinTag _tag;
        public bushort _endian;
        public bushort _version;
        public buint _fileSize; //Total size of resource package file
        public bushort _rootOffset; //Offset to root entry
        public bushort _numSections;

        public ROOTHeader* First { get { fixed (BRESHeader* p = &this) return (ROOTHeader*)((uint)p + _rootOffset); } }

        public BRESHeader(int size, int numSections)
        {
            _tag = Tag;
            _endian = 0xFEFF;
            _version = 0;
            _fileSize = (uint)size;
            _rootOffset = 0x10;
            _numSections = (ushort)numSections;
        }

        //public IEnumerator<VoidPtr> GetEnumerator() { return new StructEnumerator(this.First, this._numSections, BRESEntry.GetNext); }
        //IEnumerator IEnumerable.GetEnumerator(){return this.GetEnumerator();}
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public unsafe struct BRESEntry
    //{
    //    public const uint StructSize = 8;

    //    public uint _tag;
    //    public buint _size;

    //    BRESEntry* Address { get { fixed (BRESEntry* ptr = &this)return ptr; } }

    //    //public static VoidPtr GetNext(VoidPtr ptr) { return Util.Align((uint)ptr + ((BRESEntry*)ptr)->_size, 32); }
    //}

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ROOTHeader
    {
        public const string Tag = "root";

        public BinTag _tag;
        public bint _size;
        public ResourceGroup _master;

        public ROOTHeader(int size, int numEntries)
        {
            _tag = Tag;
            _size = size;
            _master = new ResourceGroup(numEntries);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BRESCommonHeader
    {
        public const uint Size = 0x10;

        public BinTag _tag;
        public bint _size;
        public bint _version;
        public bint _bresOffset;

        BRESCommonHeader* Address { get { fixed (BRESCommonHeader* ptr = &this) return ptr; } }
        public BRESHeader* BRESHeader
        {
            get { return (BRESHeader*)((uint)this.Address + _bresOffset); }
            set { _bresOffset = (int)value - (int)this.Address; }
        }

        public ResourceEntry* GetRootEntry()
        {
            VoidPtr addr = Address;

            BRESHeader* header = BRESHeader;
            ResourceGroup* master = &header->First->_master;

            for (int i = 0; i < master->_numEntries; i++)
            {
                ResourceGroup* group = (ResourceGroup*)master->First[i].DataAddress;
                for (int y = 0; y < group->_numEntries; y++)
                {
                    if (addr == group->First[y].DataAddress)
                        return &group->First[y];
                }
            }
            return null;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BRESString
    {
        public bint _length;
        public sbyte _data;

        private void* Address { get { fixed (void* p = &this)return p; } }
        public sbyte* Data { get { return (sbyte*)Address + 4; } }

        public int Length { get { return _length; } }

        public string Value
        {
            get { return new String(Data); }
            set
            {
                if (value == null)
                    value = "";

                int len = _length = value.Length;
                int ceil = (len + 1).Align(4);

                sbyte* ptr = Data;

                for (int i = 0; i < len; )
                    ptr[i] = (sbyte)value[i++];

                for (int i = len; i < ceil; )
                    ptr[i++] = 0;
            }
        }
        public BRESString* Next { get { return (BRESString*)((byte*)Address + (_length + 5).Align(4)); } }
        public BRESString* End { get { BRESString* p = (BRESString*)Address; while (p->_length != 0) p = p->Next; return p; } }
    }
}
