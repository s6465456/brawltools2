﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBBTypes
{
    struct DataBlock
    {
        private VoidPtr _address;
        private uint _length;

        public VoidPtr Address { get { return _address; } set { _address = value; } }
        public uint Length { get { return _length; } set { _length = value; } }
        public VoidPtr EndAddress { get { return _address + _length; } }

        public DataBlock(VoidPtr address, uint length)
        {
            _address = address;
            _length = length;
        }
    }

    unsafe struct DataBlockCollection
    {
        private DataBlock _block;

        public DataBlockCollection(DataBlock block) { _block = block; }

        private buint* Data { get { return (buint*)_block.EndAddress; } }

        public DataBlock this[int index]
        {
            get { return new DataBlock(_block.Address + Data[index << 1], Data[(index << 1) + 1]); }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct NW4RCommonHeader
    {
        public const uint Size = 0x10;

        public uint _tag;
        public short _endian;
        public bshort _version;
        public bint _length;
        public bushort _firstOffset;
        public bushort _numEntries;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public DataBlock DataBlock { get { return new DataBlock(Address, Size); } }

        public byte VersionMajor { get { return ((byte*)_version.Address)[0]; } set { ((byte*)_version.Address)[0] = value; } }
        public byte VersionMinor { get { return ((byte*)_version.Address)[1]; } set { ((byte*)_version.Address)[1] = value; } }

        public DataBlockCollection Entries { get { return new DataBlockCollection(DataBlock); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ruint
    {
        public enum RefType
        {
            Address = 0,
            Offset = 1
        }

        public byte _refType;

        public byte _dataType; 
        //Specifies which struct to get, ex
        //DataRef<T, T1, T2, T3>
        //if dataType == 2, return T2 struct at address

        public bushort _reserved;
        public bint _dataOffset;

        public ruint(RefType refType, byte dataType, int data)
        {
            _refType = (byte)refType;
            _dataType = dataType;
            _reserved = 0;
            _dataOffset = data;
        }

        public VoidPtr Offset(VoidPtr baseAddr) { return baseAddr + _dataOffset; }

        public static implicit operator ruint(int r) { return new ruint() { _refType = 1, _dataOffset = r }; }
        public static implicit operator int(ruint r) { return r._dataOffset; }
        public static implicit operator ruint(uint r) { return new ruint() { _refType = 1, _dataOffset = (int)r }; }
        public static implicit operator uint(ruint r) { return (uint)r._dataOffset; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RuintList
    {
        //This address is the base of all ruint entry offsets

        public bint _numEntries;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ruint* Entries { get { return (ruint*)(Address + 4); } }
        public VoidPtr Data { get { return Address + _numEntries * 8 + 4; } }

        public VoidPtr this[int index]
        {
            get { return (int)Entries[index]; }
            set { Entries[index] = (int)value; }
        }

        public VoidPtr Get(VoidPtr offset, int index) { return offset + Entries[index]; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct RuintCollection
    {
        private ruint _first;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ruint* Entries { get { return (ruint*)Address; } }

        public VoidPtr this[int index] 
        { 
            get { return Address + Entries[index]; }
            set { Entries[index] = (int)(value - Address); }
        }

        public VoidPtr Offset(VoidPtr offset) { return Address + offset; }

        public VoidPtr Get(int index) { return Address + Entries[index]; }

        public void Set(int index, ruint.RefType refType, byte dataType, VoidPtr address)
        {
            *((ruint*)Address + index) = new ruint(refType, dataType, (int)address - Address);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct SSBBEntryHeader
    {
        public const uint Size = 0x08;

        public uint _tag;
        public bint _length;

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public DataBlock DataBlock { get { return new DataBlock(Address, Size); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ResourceGroup : IEnumerable<ResourcePair>
    {
        public bint _totalSize;
        public bint _numEntries;
        public ResourceEntry _first;

        public ResourceGroup(int numEntries)
        {
            _totalSize = (numEntries * 0x10) + 0x18;
            _numEntries = numEntries;
            _first = new ResourceEntry(0xFFFF, 0, 0, 0, 0);
        }
        
        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceEntry* First { get { return (ResourceEntry*)(Address + 0x18); } }
        public VoidPtr EndAddress { get { return Address + _totalSize; } }

        public IEnumerator<ResourcePair> GetEnumerator() { return new ResourceEnumerator((ResourceGroup*)Address); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return new ResourceEnumerator((ResourceGroup*)Address); }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ResourcePair
    {
        public PString Name;
        public VoidPtr Data;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ResourceEnumerator : IEnumerator<ResourcePair>
    {
        ResourceGroup* pGroup;
        ResourceEntry* pEntry;
        int count, index;

        public ResourceEnumerator(ResourceGroup* group)
        {
            pGroup = group;
            count = pGroup->_numEntries;
            index = 0;
            pEntry = &pGroup->_first;
        }

        public ResourcePair Current
        {
            get { return new ResourcePair() { Name = (sbyte*)pGroup + pEntry->_stringOffset, Data = (byte*)pGroup + pEntry->_dataOffset }; }
        }

        public void Dispose() { }

        object System.Collections.IEnumerator.Current { get { return (VoidPtr)pEntry; } }
        public bool MoveNext()
        {
            if (index == count)
                return false;

            pEntry++;
            index++;
            return true;
        }

        public void Reset()
        {
            index = 0;
            pEntry = &pGroup->_first;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ResourceEntry
    {
        public const uint Size = 0x10;

        public bushort _id;
        public bushort _flag;
        public bushort _leftIndex;
        public bushort _rightIndex;
        public bint _stringOffset;
        public bint _dataOffset;

        public int CharIndex { get { return _id >> 3; } set { _id = (ushort)((value << 3) | (_id & 0x7)); } }
        public int CharShift { get { return _id & 0x7; } set { _id = (ushort)((value & 0x7) | (_id & 0xFFF8)); } }

        public ResourceEntry(int id, int left, int right) : this(id, left, right, 0, 0) { }
        public ResourceEntry(int id, int left, int right, int dataOffset) : this(id, left, right, dataOffset, 0){ }
        public ResourceEntry(int id, int left, int right, int dataOffset, int stringOffset)
        {
            _id = (ushort)id;
            _flag = 0;
            _leftIndex = (ushort)left;
            _rightIndex = (ushort)right;
            _stringOffset = stringOffset;
            _dataOffset = dataOffset;
        }

        private ResourceEntry* Address { get { fixed (ResourceEntry* ptr = &this)return ptr; } }

        public VoidPtr DataAddress { get { return (VoidPtr)Parent + _dataOffset; } }
        public VoidPtr StringAddress { get { return (VoidPtr)Parent + _stringOffset; } set { _stringOffset = (int)value - (int)Parent; } }

        public string GetName() { return new String((sbyte*)StringAddress); }

        public static void Build(ResourceGroup* group, int index, VoidPtr dataAddress, BRESString* pString)
        {
            //Get the first entry in the group, which is empty
            ResourceEntry* list = &group->_first;
            //Get the entry that will be modified
            ResourceEntry* entry = &list[index];
            //Get the first entry again
            ResourceEntry* prev = &list[0];
            //Get the entry that the first entry's left index points to
            ResourceEntry* current = &list[prev->_leftIndex];
            //The index of the current entry
            ushort currentIndex = prev->_leftIndex;
            
            bool isRight = false;

            //Get the length of the string
            int strLen = pString->_length;
            
            //Create a byte pointer to the struct's string data
            byte* pChar = (byte*)pString + 4, sChar;

            int eIndex = strLen - 1, eBits = pChar[eIndex].CompareBits(0), val;
            *entry = new ResourceEntry((eIndex << 3) | eBits, index, index, (int)dataAddress - (int)group, (int)pChar - (int)group);

            //Continue while the previous id is greater than the current. Loop backs will stop the processing.
            //Continue while the entry id is less than or equal the current id. Being higher than the current id means we've found a place to insert.
            while ((entry->_id <= current->_id) && (prev->_id > current->_id))
            {
                if (entry->_id == current->_id)
                {
                    sChar = (byte*)group + current->_stringOffset;

                    //Rebuild new id relative to current entry
                    for (eIndex = strLen; (eIndex-- > 0) && (pChar[eIndex] == sChar[eIndex]); ) ;
                    eBits = pChar[eIndex].CompareBits(sChar[eIndex]);

                    entry->_id = (ushort)((eIndex << 3) | eBits);

                    if (((sChar[eIndex] >> eBits) & 1) != 0)
                    {
                        entry->_leftIndex = (ushort)index;
                        entry->_rightIndex = currentIndex;
                    }
                    else
                    {
                        entry->_leftIndex = currentIndex;
                        entry->_rightIndex = (ushort)index;
                    }
                }

                //Is entry to the right or left of current?
                isRight = ((val = current->_id >> 3) < strLen) && (((pChar[val] >> (current->_id & 7)) & 1) != 0);

                prev = current;
                current = &list[currentIndex = (isRight) ? current->_rightIndex : current->_leftIndex];
            }

            sChar = (current->_stringOffset == 0) ? null : (byte*)group + current->_stringOffset;
            val = sChar == null ? 0 : (int)(*(bint*)(sChar - 4));

            if ((val == strLen) && (((sChar[eIndex] >> eBits) & 1) != 0))
                entry->_rightIndex = currentIndex;
            else
                entry->_leftIndex = currentIndex;

            if (isRight)
                prev->_rightIndex = (ushort)index;
            else
                prev->_leftIndex = (ushort)index;
        }

        public ResourceGroup* Parent
        {
            get
            {
                ResourceEntry* entry = Address;
                while (entry->_id != 0xFFFF) entry--;
                return (ResourceGroup*)((uint)entry - 8);
            }
        }
    }
    
    public enum WaveEncoding
    {
        PCM8 = 0,
        PCM16 = 1,
        ADPCM = 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioFormatInfo
    {
        public byte _encoding;
        public byte _looped;
        public byte _channels;
        public byte _sampleRate24;

        public AudioFormatInfo(byte encoding, byte looped, byte channels, byte unk)
        { _encoding = encoding; _looped = looped; _channels = channels; _sampleRate24 = unk; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ADPCMInfo
    {
        public const int Size = 0x30;

        public fixed short _coefs[16];

        public bushort _gain;
        public bshort _ps; //Predictor and scale. This will be initialized to the predictor and scale value of the sample's first frame.
        public bshort _yn1; //History data; used to maintain decoder state during sample playback.
        public bshort _yn2; //History data; used to maintain decoder state during sample playback.
        public bshort _lps; //Predictor/scale for the loop point frame. If the sample does not loop, this value is zero.
        public bshort _lyn1; //History data for the loop point. If the sample does not loop, this value is zero.
        public bshort _lyn2; //History data for the loop point. If the sample does not loop, this value is zero.

        public short[] Coefs
        {
            get
            {
                short[] arr = new short[16];
                fixed (short* ptr = _coefs)
                {
                    bshort* sPtr = (bshort*)ptr;
                    for (int i = 0; i < 16; i++)
                        arr[i] = sPtr[i];
                }
                return arr;
            }
        }
    }
}
