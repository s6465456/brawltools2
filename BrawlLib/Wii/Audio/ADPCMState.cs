using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BrawlLib.Wii.Audio
{
    public class ADPCMState2
    {
        public short[] _coefs = new short[0x10];
        public short _lps;
        public short _lyn1;
        public short _lyn2;
        public short _ps;
        public int _sampleIndex;
        public short[] _samples = new short[14];
        public short _sps;
        public unsafe byte* _srcPtr;
        public short _syn1;
        public short _syn2;
        public short _yn1;
        public short[] _yn1Cache;
        public short _yn2;
        public short[] _yn2Cache;

        public ADPCMState2(short[] coefs, short lyn1, short lyn2, short[] yn1cache, short[] yn2cache)
        {

        }

        public unsafe short ReadSample()
        {
            int num;
            if ((((uint)_srcPtr) & 7) == 0)
            {
                byte* numPtr = _srcPtr;
                _srcPtr = numPtr + 1;
                _ps = numPtr[0];
            }
            if ((_sampleIndex++ & 1) == 0)
                num = _srcPtr[0] >> 4;
            else
            {
                byte* numPtr2;
                _srcPtr = (numPtr2 = _srcPtr) + 1;
                num = numPtr2[0] & 15;
            }
            if (num >= 8)
                num -= 0x10;
            int num2 = ((int)1) << (_ps & 15);
            int num3 = _ps >> 4;
            num = (((0x400 + ((num2 * num) << 11)) + (_coefs[2 * num3] * _yn1)) + (_coefs[(2 * num3) + 1] * _yn2)) >> 11;
            if (num > 0x7fff)
                num = 0x7fff;
            if (num < -32768)
                num = -32768;
            _yn2 = _yn1;
            return (_yn1 = (short)num);
        }

        public unsafe void InitBlock(int index, byte* sPtr)
        {
            _yn1 = _yn1Cache[index];
            _yn2 = _yn2Cache[index];
            _sampleIndex = 0;
            _srcPtr = sPtr;
        }

        public unsafe void InitLoop(byte* sPtr)
        {
            _ps = _lps;
            _yn1 = _lyn1;
            _yn2 = _lyn2;
            _sampleIndex = 0;
            _srcPtr = sPtr + 1;
        }

        public unsafe void InitStart(byte* sPtr)
        {
            _ps = _sps;
            _yn1 = _syn1;
            _yn2 = _syn2;
            _sampleIndex = 0;
            _srcPtr = sPtr + 1;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct ADPCMState
    {
        public byte* _srcPtr;
        public int _sampleIndex;
        public short _cps, _cyn1, _cyn2, _ps, _yn1, _yn2, _lps, _lyn1, _lyn2;
        public short[] _coefs;

        public ADPCMState(byte* srcPtr, short yn1, short yn2, short[] coefs)
        {
            _srcPtr = srcPtr;
            _sampleIndex = 0;
            _cps = _ps = _lps = 0;
            _cyn1 = _lyn1 = _yn1 = yn1;
            _cyn2 = _lyn2 = _yn2 = yn2;
            _coefs = coefs;
        }
        public ADPCMState(byte* srcPtr, short ps, short yn1, short yn2, short[] coefs)
        {
            _srcPtr = srcPtr;
            _sampleIndex = 0;
            _cps = _ps = ps;
            _lps = ps;
            _cyn1 = _yn1 = yn1;
            _cyn2 = _yn2 = yn2;
            _lyn1 = yn1;
            _lyn2 = yn2;
            _coefs = coefs;
        }
        public ADPCMState(byte* srcPtr, short ps, short yn1, short yn2, short lps, short lyn1, short lyn2, short[] coefs)
        {
            _srcPtr = srcPtr;
            _sampleIndex = 0;
            _cps = _ps = ps;
            _lps = lps;
            _cyn1 = _yn1 = yn1;
            _cyn2 = _yn2 = yn2;
            _lyn1 = lyn1;
            _lyn2 = lyn2;
            _coefs = coefs;
        }

        public void InitBlock()
        {
            _cps = _ps;
            _cyn1 = _yn1;
            _cyn2 = _yn2;
        }
        public void InitLoop()
        {
            _cps = _lps;
            _cyn1 = _lyn1;
            _cyn2 = _lyn2;
        }

        public short ReadSample()
        {
            int outSample, scale, cIndex;

            if (_sampleIndex % 14 == 0)
                _cps = *_srcPtr++;

            if ((_sampleIndex++ & 1) == 0)
                outSample = *_srcPtr >> 4;
            else
                outSample = *_srcPtr++ & 0x0F;

            if (outSample >= 8)
                outSample -= 16;

            scale = 1 << (_cps & 0x0F);
            cIndex = (_cps >> 4) << 1;

            outSample = (0x400 + (scale * outSample << 11) + (_coefs[cIndex] * _cyn1) + (_coefs[(cIndex + 1)] * _cyn2)) >> 11;

            _cyn2 = _cyn1;
            return _cyn1 = (short)outSample.Clamp(-32768, 32767);
        }
    }
}
