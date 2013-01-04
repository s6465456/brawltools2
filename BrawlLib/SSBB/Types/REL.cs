﻿using System;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RELHeader
    {
        public const int Size = 0x4C;
        
        public ModuleInfo _info;

        //0x20
        public buint _bssSize; //Size of command list for this module
        public buint _relOffset; //Offset to relocations
        public buint _impOffset; //Offset to imports
        public buint _impSize; //Size of import entry headers

        //0x30

        //IDs of sections that contain these
        public byte _prologSection; //1
        public byte _epilogSection; //1
        public byte _unresolvedSection; //1
        public byte _bssSection; //0

        //Offsets into certain sections specified above
        public buint _prologOffset;
        public buint _epilogOffset;
        public buint _unresolvedOffset;

        //0x40
        public buint _moduleAlign; //Alignment of this module (32 bytes)
        public buint _bssAlign; //Alignment of the command list for this module (8 bytes)
        public buint _fixSize; //Pointer to the command list for this module

        //Data Order

        //Header
        //Section Info
        //Section Data
        //Imports
        //Relocations

        //Imports order
        //Smallest to largest module IDs
        //This module
        //Static module 0

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public RELSection* SectionInfo { get { return (RELSection*)(Address + _info._sectionInfoOffset); } }
        public RELImport* Imports { get { return (RELImport*)(Address + _impOffset); } }
        
        public int ImportListCount { get { return (int)(_impSize / RELImport.Size); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RELSection
    {
        public const int Size = 8;

        public buint _offset;
        public buint _size;

        public bool IsCodeSection { get { return (_offset & 1) != 0; } set { _offset = (uint)(_offset & ~1) | (uint)(value ? 1 : 0); } }
        
        //Base is start of file
        public int Offset { get { return (int)_offset & ~1; } set { _offset = (uint)(value & ~1) | (_offset & 1); } }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RELImport
    {
        public const int Size = 8;

        public buint _moduleId;

        //Base is start of file
        public buint _offset;

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RELLink
    {
        public const int Size = 8;

        public bushort _prevOffset; //Size of previous
        public byte _type;
        public byte _section;
        public buint _value;

        public RELLinkType Type { get { return (RELLinkType)_type; } }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [Flags]
    public enum RELLinkType : byte
    {
        NOP1 = 0xC9, //Increment offset6
        NOP2 = 0x0,
        WriteWord = 0x1,
        SetBranchOffset = 0x2,
        WriteLowerHalf1 = 0x3,
        WriteLowerHalf2 = 0x4,
        WriteUpperHalf = 0x5,
        WriteUpperHalfandBit1 = 0x6,
        SetBranchConditionOffset1 = 0x7,
        SetBranchConditionOffset2 = 0x8,
        SetBranchConditionOffset3 = 0x9,
        SetBranchDestination = 0xA,
        SetBranchConditionDestination1 = 0xB,
        SetBranchConditionDestination2 = 0xC,
        SetBranchConditionDestination3 = 0xD,
        Section = 0xCA, //Set current section
        End = 0xCB,
        MrkRef = 0xCC
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ModuleLink
    {
        public const int Size = 8;

        public bint _linkNext;
        public bint _linkPrev;

        public ModuleInfo* Next { get { return (ModuleInfo*)(Address + _linkNext); } }
        public ModuleInfo* Prev { get { return (ModuleInfo*)(Address + _linkPrev); } }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ModuleInfo
    {
        public const int Size = 0x20;

        public buint _id;                 // Unique identifier for the module
        public ModuleLink _link;          // Doubly linked list of modules
        public buint _numSections;        // # of sections
        public buint _sectionInfoOffset;  // Offset to section info table
        public buint _nameOffset;         // Offset to module name
        public buint _nameSize;           // Size of module name
        public buint _version;            // Version number

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct VirtualFunctionTable
    {
        public buint _declaration;
        public bint _scopeLevel;

        public buint* Functions { get { return (buint*)(Address + 8); } } 
        //(no termination)

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Declaration
    {
        public buint _nameOffset;
        public bint _inheritanceOffset;

        public string Name { get { return new String((sbyte*)Address + _nameOffset); } }
        public Inheritance* Inheritance { get { return (Inheritance*)(Address + _inheritanceOffset); } }
        //(0x00000000 terminated)

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Inheritance
    {
        public buint _declaration;
        public bint _scopeLevel;

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }
}
