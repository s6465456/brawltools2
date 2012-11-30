using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using BrawlLib.SSBBTypes;

namespace BrawlLib.Wii.Compression
{
    public unsafe class RunLength : IDisposable
    {
        public const int WindowMask = 0xFFF;
        public const int WindowLength = 4096; //12 bits - 1, 1 - 4096
        public const int PatternLength = 18; //4 bits + 3, 3 - 18
        public const int MinMatch = 3;

        VoidPtr _dataAddr;

        ushort* _Next;
        ushort* _First;
        ushort* _Last;

        int _wIndex;
        int _wLength;

        private RunLength()
        {
            _dataAddr = Marshal.AllocHGlobal((0x1000 + 0x10000 + 0x10000) * 2);

            _Next = (ushort*)_dataAddr;
            _First = _Next + WindowLength;
            _Last = _First + 0x10000;

        }

        ~RunLength() { Dispose(); }
        public void Dispose()
        {
            if (_dataAddr) { Marshal.FreeHGlobal(_dataAddr); _dataAddr = 0; }
            GC.SuppressFinalize(this);
        }

        public int CompressYAZ0(VoidPtr srcAddr, int srcLen, Stream outStream, IProgressTracker progress)
        {
            //uint secure_size = 0x40;
            int dstLen = 4, bitCount;
            byte control = 0;

            //Write header
            YAZ0 header = new YAZ0();
            header._tag = YAZ0.Tag;
            header._unCompDataLen = (uint)srcLen;
            outStream.Write(&header, 0x20);

            byte* src = (byte*)(srcAddr + 0x20);
            byte* src_end = (byte*)(src + srcLen);

            int lastUpdate = srcLen;
            int remaining = srcLen;
 	        uint range = /*
                opt_norm
 	            ? 0x1000
 	            : !opt_compr
 	            ? 0
 	            : opt_compr < 9
 	            ? 0x10e0 * opt_compr / 9 - 0x0e0
 	            : */0x1000;

            byte[] blockBuffer = new byte[17];
            int dInd = 0;

            if (progress != null)
                progress.Begin(0, remaining, 0);

            byte mask = 0;
 	        //byte* code_byte = dest;
 	        while (src < src_end)
 	        {
                //if (dest > dest_end)
                //{
                //    uint dest_pos = (uint)(dest - dest_buf);
                //    uint code_pos = (uint)(code_byte - dest_buf);

                //    dest_len *= 2;
                //    if (dest_buf == (byte*)iobuf)
                //    {
                //        dest_buf = MALLOC( dest_len + secure_size );
                //        memcpy(dest_buf,iobuf,dest_pos);
                //    }
                //    else
                //    {
                //        dest_buf = REALLOC( dest_buf, dest_len + secure_size );
                //    }
                //    dest = dest_buf + dest_pos;
                //    dest_end = dest_buf + dest_len;
                //    code_byte = dest_buf + code_pos;
                //}

 	            if (mask == 0)
 	            {
 	                //code_byte = dest;
                    blockBuffer[dInd++] = 0;
 	                mask = 0x80;
 	            }
 	
                int max_len = 0x111;
	            uint matchLen = 1;
 	            byte* found = null;

 	            if (range != 0 && src + 2 < src_end)
	            {
 	                byte* search = src - range;

                    //if (search < szs->data)
                    //    search = szs->data;

 	                byte* cmp_end = src + max_len;
 	                if (cmp_end > src_end)
 	                    cmp_end = src_end;
 	
 	                byte c1 = *src;
 	                for ( ; search < src; search++)
 	                {
                        int i = 0;
                        while (*search != c1 && i < (int)src - (int)search)
                        {
                            search++;
                            i++;
                        }

 	                    //search = memchr(search, c1, src - search);

                        if (i == (int)src - (int)search)
 	                        break;

 	                    //DASSERT( search < src );

 	                    byte* cmp1 = search + 1;
 	                    byte* cmp2 = src + 1;
 	                    while (cmp2 < cmp_end && *cmp1 == *cmp2)
                        {
 	                        cmp1++; 
                            cmp2++;
                        }

 	                    uint len = (uint)(cmp2 - src);
 	                    if (matchLen < len)
 	                    {
 	                        matchLen = len;
 	                        found = search;
 	                        if (matchLen == max_len)
 	                            break;
 	                    }
 	                }
 	            }

 	            if (matchLen >= 3)
 	            {
 	                uint delta = (uint)(src - found - 1);
 	                if (matchLen < 0x12)
 	                {
                        blockBuffer[dInd++] = (byte)(delta >> 8 | (matchLen - 2) << 4);
                        blockBuffer[dInd++] = (byte)delta;
 	                }
 	                else
 	                {
                        blockBuffer[dInd++] = (byte)(delta >> 8);
                        blockBuffer[dInd++] = (byte)delta;
                        blockBuffer[dInd++] = (byte)(matchLen - 0x12);
 	                }
 	                src += matchLen;
                    remaining -= (int)matchLen;
 	            }
 	            else
 	            {
 	                //*code_byte |= mask;
                    blockBuffer[dInd++] = *src++;
 	            }
 	            mask >>= 1;

                blockBuffer[0] = control;
                outStream.Write(blockBuffer, 0, dInd);
                dstLen += dInd;

                if (progress != null)
                    if ((lastUpdate - remaining) > 0x4000)
                    {
                        lastUpdate = remaining;
                        progress.Update(srcLen - remaining);
                    }
 	        }
            return dstLen;
        }
        private ushort MakeHash(byte* ptr)
        {
            return (ushort)((ptr[0] << 6) ^ (ptr[1] << 3) ^ ptr[2]);
        }

        private int FindPattern(byte* sPtr, int length, ref int matchOffset)
        {
            if (length < MinMatch) return 0;
            length = Math.Min(length, PatternLength);

            byte* mPtr;
            int bestLen = MinMatch - 1, bestOffset = 0, index;
            for (int offset = _First[MakeHash(sPtr)]; offset != 0xFFFF; offset = _Next[offset])
            {
                if (offset < _wIndex) mPtr = sPtr - _wIndex + offset;
                else mPtr = sPtr - _wLength - _wIndex + offset;

                if (sPtr - mPtr < 2) break;

                for (index = bestLen + 1; (--index >= 0) && (mPtr[index] == sPtr[index]); ) ;
                if (index >= 0) continue;
                for (index = bestLen; (++index < length) && (mPtr[index] == sPtr[index]); ) ;

                bestOffset = (int)(sPtr - mPtr);
                if ((bestLen = index) == length) break;
            }

            if (bestLen < MinMatch) return 0;

            matchOffset = bestOffset;
            return bestLen;
        }
        private void Consume(byte* ptr, int length, int remaining)
        {
            int last, inOffset, inVal, outVal;
            for (int i = Math.Min(length, remaining - 2); i-- > 0;)
            {
                if (_wLength == WindowLength)
                {
                    //Remove node
                    outVal = MakeHash(ptr - WindowLength);
                    if ((_First[outVal] = _Next[_First[outVal]]) == 0xFFFF)
                        _Last[outVal] = 0xFFFF;
                    inOffset = _wIndex++;
                    _wIndex &= WindowMask;
                }
                else
                    inOffset = _wLength++;

                inVal = MakeHash(ptr++);
                if ((last = _Last[inVal]) == 0xFFFF)
                    _First[inVal] = (ushort)inOffset;
                else
                    _Next[last] = (ushort)inOffset;

                _Last[inVal] = (ushort)inOffset;
                _Next[inOffset] = 0xFFFF;
            }
        }

        public static int CompactYAZ0(VoidPtr srcAddr, int srcLen, Stream outStream, string name)
        {
            using (RunLength rl = new RunLength())
            using (ProgressWindow prog = new ProgressWindow(null, "RunLength - YAZ0", String.Format("Compressing {0}, please wait...", name), false))
                return rl.CompressYAZ0(srcAddr, srcLen, outStream, prog);
        }

        public static void Expand(CompressionHeader* header, VoidPtr dstAddress, int dstLen)
        {
            if ((header->Algorithm != CompressionType.RunLength) || (header->Parameter != 0))
                throw new InvalidCompressionException("Compression header does not match RunLength format.");

            byte control = 0, bit = 0;
            byte* srcPtr = (byte*)header->Data, dstPtr = (byte*)dstAddress, ceiling = dstPtr + dstLen;
            while (dstPtr < ceiling)
            {
                if (bit == 0)
                {
                    control = *srcPtr++;
                    bit = 8;
                }
                bit--;
                if ((control & 0x80) == 0x80)
                    *dstPtr++ = *srcPtr++;
                else
                {
                    byte b1 = *srcPtr++, b2 = *srcPtr++;
                    byte* cpyPtr = (byte*)((VoidPtr)dstPtr - ((b1 & 0x0f) << 8 | b2) - 1);
                    int n = b1 >> 4;
                    if (n == 0) n = *srcPtr++ + 0x12;
                    else n += 2;
                    //if (!(n >= 3 && n <= 0x111)) return;
                    while (n-- > 0) *dstPtr++ = *cpyPtr++;
                }
                control <<= 1;
            }
        }

        public static void ExpandYAZ0(YAZ0* header, VoidPtr dstAddress, int dstLen)
        {
            byte control = 0, bit = 0;
            byte* srcPtr = (byte*)header->Data, dstPtr = (byte*)dstAddress, ceiling = dstPtr + dstLen;
            while (dstPtr < ceiling)
            {
                if (bit == 0)
                {
                    control = *srcPtr++;
                    bit = 8;
                }
                bit--;
                if ((control & 0x80) == 0x80)
                    *dstPtr++ = *srcPtr++;
                else
                {
                    byte b1 = *srcPtr++, b2 = *srcPtr++;
                    byte* cpyPtr = (byte*)((VoidPtr)dstPtr - ((b1 & 0x0f) << 8 | b2) - 1);
                    int n = b1 >> 4;
                    if (n == 0) n = *srcPtr++ + 0x12;
                    else n += 2;
                    //if (!(n >= 3 && n <= 0x111)) break;
                    while (n-- > 0) *dstPtr++ = *cpyPtr++;
                }
                control <<= 1;
            }
        }
    }
}
