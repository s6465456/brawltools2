﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Textures;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct REFT
    {
        //Header + string is aligned to 4 bytes

        public const uint Tag = 0x54464552;

        public NW4RCommonHeader _header;
        public uint _tag; //Same as header
        public bint _dataLength; //Size of second REFT block. (file size - 0x18)
        public bint _dataOffset; //Offset from itself. Begins first entry
        public bint _linkPrev; //0
        public bint _linkNext; //0
        public bshort _stringLen;
        public bshort _padding; //0

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public string IdString
        {
            get { return new String((sbyte*)Address + 0x28); }
            set
            {
                int len = value.Length + 1;
                _stringLen = (short)len;

                byte* dPtr = (byte*)Address + 0x28;
                fixed (char* sPtr = value)
                {
                    for (int i = 0; i < len; i++)
                        *dPtr++ = (byte)sPtr[i];
                }

                //Align to 4 bytes
                while ((len++ & 3) != 0)
                    *dPtr++ = 0;
            }
        }

        public REFTypeObjectTable* Table { get { return (REFTypeObjectTable*)(Address + 0x18 + _dataOffset); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct REFTImageHeader
    {
        public buint _unknown;
        public bushort _width;
        public bushort _height;
        public buint _imagelen;
        public byte _format;
        public byte _pltFormat;
        public bushort _colorCount;

        public buint _pltSize;
        public byte _mipmap;
        public byte _min_filt;
        public byte _mag_filt;
        public byte _reserved;
        public bfloat _lod_bias;
        
        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public REFTImageHeader(ushort width, ushort height, byte format, byte pltFormat, ushort colors, uint imgSize, byte lod)
        {
            _unknown = 0;
            _width = width;
            _height = height;
            _imagelen = imgSize;
            _format = format;
            _pltFormat = pltFormat;
            _colorCount = colors;
            _pltSize = (uint)colors * 2;
            _mipmap = lod;
            _min_filt = 0;
            _mag_filt = 0;
            _reserved = 0;
            _lod_bias = 0;
        }

        public void Set(byte min, byte mag, float lodBias)
        {
            _min_filt = min;
            _mag_filt = mag;
            _lod_bias = lodBias;
        }

        //From here starts the image.

        public VoidPtr PaletteData { get { return Address + 0x20 + _imagelen; } }
    }
}
