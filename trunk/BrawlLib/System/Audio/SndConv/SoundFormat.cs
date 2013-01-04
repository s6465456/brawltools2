using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.Audio.SndConv
{
    public unsafe partial class SndConv
    {
        /*--------------------------------------------------------------------------*
            combine 8 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoCombine8Bit(sbyte* dest, sbyte* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
                *dest++ = (sbyte)((((short)((short)(*source++) + (short)(*source++))) >> 1) & 0xFF);
        }

        /*--------------------------------------------------------------------------*
            combine 16 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoCombine16Bit(short* dest, short* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
                *dest++ = (short)((short)(*source++ >> 1) + (short)(*source++ >> 1));
        }

        /*--------------------------------------------------------------------------*
            left 8 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoLeft8Bit(sbyte* dest, sbyte* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
            {
                *dest++ = *source++; 
                source++;
            }
        }

        /*--------------------------------------------------------------------------*
            left 16 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoLeft16Bit(short* dest, short* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
            {
                *dest++ = *source++;
                source++;
            }
        }

        /*--------------------------------------------------------------------------*
            right 8 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoRight8Bit(sbyte* dest, sbyte* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
            {
                source++;
                *dest++ = *source++;
            }
        }

        /*--------------------------------------------------------------------------*
            right 16 bit stereo samples    
         *--------------------------------------------------------------------------*/
        public static void soundStereoRight16Bit(short* dest, short* source, uint samples)
        {
            for (uint i = 0; i < samples; i++)
            {
                source++;
                *dest++ = *source++;
            }
        }

        /*--------------------------------------------------------------------------*
            convert 8 bit to 16 bit    
         *--------------------------------------------------------------------------*/
        public static void soundConvert8to16Bit(short* dest, sbyte* source, uint samples)
        {
            for (uint i = 0; i < samples; i++) *dest++ = (short)(*source++ << 8);
        }

        /*--------------------------------------------------------------------------*
            convert 16 bit to 8 bit    
         *--------------------------------------------------------------------------*/
        public static void soundConvert16to8Bit(sbyte* dest, short* source, uint samples)
        {
            for (uint i = 0; i < samples; i++) *dest++ = (sbyte)((*source++ >> 8) & 0xFF);
        }

        /*--------------------------------------------------------------------------*
            convert 16 bit to ADPCM    
         *--------------------------------------------------------------------------*/
        public static void soundConvert16BitToAdpcm(void* dest, short* source, ADPCMInfo* adpcminfo, uint samples)
        {
            //encode(source, dest, adpcminfo, samples);
        }

        /*--------------------------------------------------------------------------*
            convert 16 bit to ADPCM with loop context   
         *--------------------------------------------------------------------------*/
        public static void soundConvert16BitToAdpcmLoop(void* dest, short* source, ADPCMInfo* adpcminfo, uint samples, uint loopStart)
        {
            //encode(source, dest, adpcminfo, samples);
            //getLoopContext(dest, adpcminfo, loopStart);
        }

        /*--------------------------------------------------------------------------*
            convert 8 bit to ADPCM    
         *--------------------------------------------------------------------------*/
        public static void soundConvert8BitToAdpcmLoop(void* dest, sbyte* source, ADPCMInfo* adpcminfo, uint samples)
        {
            UnsafeBuffer p = new UnsafeBuffer((int)(samples * 2));

            soundConvert8to16Bit((short*)p.Address, source, samples);
            soundConvert16BitToAdpcm(dest, (short*)p.Address, adpcminfo, samples);
        }

        /*--------------------------------------------------------------------------*
            convert 8 bit to ADPCM with loop   
         *--------------------------------------------------------------------------*/
        public static void soundConvert8BitToAdpcmLoop(void* dest, sbyte* source, ADPCMInfo* adpcminfo, uint samples, uint loopStart)
        {
            UnsafeBuffer p = new UnsafeBuffer((int)(samples * 2));

            soundConvert8to16Bit((short*)p.Address, source, samples);
            soundConvert16BitToAdpcmLoop(dest, (short*)p.Address, adpcminfo, samples, loopStart);
        }
    }
}
