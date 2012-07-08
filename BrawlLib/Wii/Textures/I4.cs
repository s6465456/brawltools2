﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;

namespace BrawlLib.Wii.Textures
{
    unsafe class I4 : TextureConverter
    {
        public override int BitsPerPixel { get { return 4; } }
        public override int BlockWidth { get { return 8; } }
        public override int BlockHeight { get { return 8; } }
        //public override PixelFormat DecodedFormat { get { return PixelFormat.Format24bppRgb; } }
        public override WiiPixelFormat RawFormat { get { return WiiPixelFormat.I4; } }


        protected override void DecodeBlock(VoidPtr blockAddr, ARGBPixel* dPtr, int width)
        {
            I4Pixel* sPtr = (I4Pixel*)blockAddr; 
            //RGBPixel* dPtr = (RGBPixel*)destAddr;
            for (int y = 0; y < BlockHeight; y++, dPtr += width)
                for (int x = 0; x < BlockWidth; )
                {
                    dPtr[x++] = (ARGBPixel)(*sPtr)[0];
                    dPtr[x++] = (ARGBPixel)(*sPtr++)[1];
                }
        }

        protected override void EncodeBlock(ARGBPixel* sPtr, VoidPtr blockAddr, int width)
        {
            I4Pixel* dPtr = (I4Pixel*)blockAddr;
            for (int y = 0; y < BlockHeight; y++, sPtr += width)
                for (int x = 0; x < BlockWidth; )
                {
                    (*dPtr)[0] = sPtr[x++];
                    (*dPtr++)[1] = sPtr[x++];
                }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct I4Pixel
    {
        public byte _data;

        public ARGBPixel this[int index]
        {
            get
            {
                byte c = (index % 2 == 0) ? (byte)((_data & 0xF0) | (_data >> 4)) : (byte)((_data & 0x0F) | (_data << 4));
                return new ARGBPixel() {A = 0xFF, R = c, G = c, B = c };
            }
            set
            {
                int c = (value.R + value.G + value.B) / 3;
                _data = (index % 2 == 0) ? (byte)((c & 0xF0) | (_data & 0x0F)) : (byte)((c >> 4) | (_data & 0xF0));
            }
        }


        public static explicit operator I4Pixel(ARGBPixel p)
        {
            int value = (p.R + p.G + p.B) / 3;
            return new I4Pixel() { _data = (byte)((value >> 4) | (value & 0xF0)) };
        }
    }
}
