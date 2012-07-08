﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using BrawlLib.Imaging;

namespace BrawlLib.Wii.Textures
{
    unsafe class IA8 : TextureConverter
    {
        public override int BitsPerPixel { get { return 16; } }
        public override int BlockWidth { get { return 4; } }
        public override int BlockHeight { get { return 4; } }
        //public override PixelFormat DecodedFormat { get { return PixelFormat.Format32bppArgb; } }
        public override WiiPixelFormat RawFormat { get { return WiiPixelFormat.IA8; } }

        protected override void DecodeBlock(VoidPtr blockAddr, ARGBPixel* dPtr, int width)
        {
            IA8Pixel* sPtr = (IA8Pixel*)blockAddr;
            //ARGBPixel* dPtr = (ARGBPixel*)destAddr;
            for (int y = 0; y < BlockHeight; y++, dPtr += width)
                for (int x = 0; x < BlockWidth; )
                    dPtr[x++] = *sPtr++;
        }

        protected override void EncodeBlock(ARGBPixel* sPtr, VoidPtr blockAddr, int width)
        {
            IA8Pixel* dPtr = (IA8Pixel*)blockAddr;
            for (int y = 0; y < BlockHeight; y++, sPtr += width)
                for (int x = 0; x < BlockWidth; )
                    *dPtr++ = sPtr[x++];
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct IA8Pixel
    {
        public byte intensity;
        public byte alpha;

        public static implicit operator ARGBPixel(IA8Pixel p)
        {
            return new ARGBPixel() { A = p.alpha, R = p.intensity, G = p.intensity, B = p.intensity };
        }
        public static implicit operator IA8Pixel(ARGBPixel p)
        {
            return new IA8Pixel() { intensity = (byte)((p.R + p.G + p.B) / 3), alpha = p.A };
        }
        public static explicit operator Color(IA8Pixel p)
        {
            return Color.FromArgb(p.alpha, p.intensity, p.intensity, p.intensity);
        }
        public static explicit operator IA8Pixel(Color p)
        {
            return new IA8Pixel() { intensity = (byte)((p.R + p.G + p.B) / 3), alpha = p.A };
        }
    }
}
