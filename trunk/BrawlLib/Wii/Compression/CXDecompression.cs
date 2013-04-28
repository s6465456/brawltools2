using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BrawlLib.Wii.Compression
{
    public static unsafe class CXDecompression
    {
        public static uint CXGetUncompressedSize(VoidPtr srcp)
        {
            uint size = CX.iConvertEndian(*(uint*)srcp) >> 8;
            if (size == 0)
                size = CX.iConvertEndian(*((uint*)srcp + 1));
            
            return size;
        }

        public static void CXDecompressAny(VoidPtr srcp, VoidPtr destp, uint dstLen)
        {
            switch (CX.GetCompressionType(srcp))
            {
                // Run-length compressed data
                case CX.CompressionType.CX_COMPRESSION_RL:
                    CXUncompressRL(srcp, destp);
                    break;
                // LZ77 compressed data
                case CX.CompressionType.CX_COMPRESSION_LZ:
                    CXUncompressLZ(srcp, destp, dstLen);
                    break;
                // Huffman compressed data
                case CX.CompressionType.CX_COMPRESSION_HUFFMAN:
                    CXUncompressHuffman(srcp, destp);
                    break;
                // Difference filter
                case CX.CompressionType.CX_COMPRESSION_DIFF:
                    CXUnfilterDiff(srcp, destp);
                    break;
                default:
                    MessageBox.Show("Unknown compressed format");
                    break;
            }
        }

        public static void CXUncompressRL(VoidPtr srcp, VoidPtr destp)
        {
            byte *pSrc = (byte*)srcp;
            byte *pDst = (byte*)destp;
            uint destCount = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            pSrc += 4;
    
            if (destCount == 0)
            {
                destCount = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
            }
    
            while (destCount > 0)
            {
                byte  flags  = *pSrc++;
                uint length = flags & 0x7fU;
                if ((flags & 0x80) == 0)
                {   
                    length++;
                    if (length > destCount)
                    // Measures for buffer overrun when invalid data is decompressed.
                        length = destCount;
            
                    destCount -= length;
                    do { *pDst++ = *pSrc++; } while (--length > 0);
                }
                else
                {
                    byte srcTmp;
                    length += 3;
                    if (length > destCount)
                    // Measures for buffer overrun when invalid data is decompressed.
                        length = destCount;
            
                    destCount -= length;
                    srcTmp = *pSrc++;
                    do { *pDst++ =  srcTmp; } while (--length > 0);
                }
            }
        }

        public static void CXUncompressLZ(VoidPtr srcp, VoidPtr destp, uint dstLen)
        {
            byte* pSrc = (byte*)srcp;
            byte* pDst = (byte*)destp;
            uint destCount = dstLen <= 0 ? CX.iConvertEndian(*(uint*)pSrc) >> 8 : dstLen;
            bool exFormat = (*pSrc & 0x0F) != 0;

            pSrc += 4;

            if (destCount == 0)
            {
                destCount = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
            }

            while (destCount > 0)
            {
                uint flags = *pSrc++;
                for (uint i = 0; i < 8; ++i)
                {
                    if ((flags & 0x80) == 0)
                    {
                        *pDst++ = *pSrc++;
                        destCount--;
                    }
                    else
                    {
                        int length = (*pSrc >> 4);
                        int offset;

                        if (!exFormat)
                            length += 3;
                        else
                        {
                            // LZ77 extended format
                            if (length == 1)
                            {
                                length =  (*pSrc++ & 0x0F) << 12;
                                length |= (*pSrc++) << 4;
                                length |= (*pSrc >> 4);
                                length += 0xFF + 0xF + 3;
                            }
                            else if (length == 0)
                            {
                                length =  (*pSrc++ & 0x0F) << 4;
                                length |= (*pSrc >> 4);
                                length += 0xF + 2;
                            }
                            else
                                length += 1;
                        }
                        offset = (*pSrc++ & 0x0f) << 8;
                        offset = (offset | *pSrc++) + 1;
                        if (length > destCount)
                        // Measures for buffer overrun when invalid data is decompressed.
                            length = (int)destCount;
                        
                        destCount -= (uint)length;

                        do { *pDst++ = pDst[-offset]; } while (--length > 0);
                    }
                    if (destCount <= 0)
                        break;

                    flags <<= 1;
                }
            }
        }

        public static void CXUncompressHuffman(VoidPtr srcp, VoidPtr destp)
        {
            byte TREE_END = 0x80;
            uint *pSrc          = (uint*)srcp;
            uint *pDst          = (uint*)destp;
            int destCount       = (int)(CX.iConvertEndian(*pSrc) >> 8);
            byte *treep         = (destCount != 0)? ((byte*)pSrc + 4) : ((byte*)pSrc + 8);
            byte *treeStartp    = treep + 1;
            uint dataBit        = *(byte*)pSrc & 0x0FU;
            uint destTmp        = 0;
            uint destTmpCount   = 0;
            uint destTmpDataNum = 4 + (dataBit & 0x7);
    
            if (destCount == 0)
                destCount = (int)(CX.iConvertEndian(*(pSrc + 1)));
    
            pSrc  = (uint*)(treep + ((*treep + 1) << 1));
            treep = treeStartp;
    
            while (destCount > 0)
            {
                int srcCount = 32;
                uint srcTmp = CX.iConvertEndian(*pSrc++); // Endian strategy
                while (--srcCount >= 0)
                {
                    uint treeShift = (srcTmp >> 31) & 0x1;
                    uint treeCheck = *treep;
                    treeCheck <<= (int)treeShift;
                    treep = (byte*)((((uint)treep >> 1) << 1) + (((*treep & 0x3f) + 1) << 1) + treeShift);
                    if ((treeCheck & TREE_END)!=0)
                    {
                        destTmp >>= (int)dataBit;
                        destTmp |= (uint)*treep << (byte)(32 - dataBit);
                        treep = treeStartp;
                        if (++destTmpCount == destTmpDataNum)
                        {
                            // Over-access until the last 4-byte alignment of the decompression buffer
                            *pDst++ = CX.iConvertEndian(destTmp); // Endian strategy
                            destCount -= 4;
                            destTmpCount = 0;
                        }
                    }
                    if (destCount <= 0)
                        break;
                    srcTmp <<= 1;
                }
            }
        }

        public static uint CXiHuffImportTree(ushort* pTable,  byte* srcp, byte bitSize)
        {
            uint tableSize;
            uint idx     = 1;
            uint data    = 0;
            uint bitNum  = 0;
            uint bitMask = (uint)(1 << bitSize) - 1;
            uint srcCnt  = 0;
            uint MAX_IDX = (uint)((1 << bitSize) * 2);
    
            if (bitSize > 8)
            {
                tableSize = CX.iConvertEndian16(*(ushort*)srcp);
                srcp   += 2;
                srcCnt += 2;
            }
            else
            {
                tableSize = *srcp;
                srcp   += 1;
                srcCnt += 1;
            }
            tableSize = (tableSize + 1) * 4;
    
            while (srcCnt < tableSize)
            {
                while (bitNum < bitSize)
                {
                    data <<= 8;
                    data |= *srcp++;
                    ++srcCnt;
                    bitNum += 8;
                }
        
                if (idx < MAX_IDX)
                    pTable[idx++] = (ushort)((data >> (int)(bitNum - bitSize)) & bitMask);
                
                bitNum -= bitSize;
            }
            return tableSize;
        }

        public struct BitReader
        {
            public byte* srcp;
            public uint cnt;
            public uint stream;
            public uint stream_len;
        }

        public static void BitReader_Init(BitReader* context, byte* srcp)
        {
            context->srcp       = srcp;
            context->cnt        = 0; 
            context->stream     = 0;
            context->stream_len = 0;
        }

        public static int BitReader_Read(BitReader* context, byte bits)
        {
            int value;
    
            while (context->stream_len < bits)
            {
                if (context->cnt == 0)
                    return -1;
                
                context->stream <<= 8;
                context->stream += *context->srcp;
                context->srcp++;
                context->cnt--;
                context->stream_len += 8;
            }
    
            value = (int)((context->stream >> (int)(context->stream_len - bits)) & ((1 << bits) - 1));
            context->stream_len -= bits;
            return value;
        }

        public static byte BitReader_Read(BitReader* context)
        {
            byte bit;
            if (context->stream_len == 0)
            {
                context->stream = context->srcp[context->cnt++];
                context->stream_len = 8;
            }
            bit = (byte)((context->stream >> (int)(context->stream_len - 1)) & 0x1);
            context->stream_len--;
            return bit;
        }

        public static long BitReader_ReadEx(BitReader* context, byte bits)
        {
            long value;
            byte  stock = 0;
    
            while (context->stream_len < bits)
            {
                if (context->cnt == 0)
                    return -1;
                
                if (context->stream_len > 24)
                    stock = (byte)(context->stream >> 24);
                
                context->stream <<= 8;
                context->stream += *context->srcp;
                context->srcp++;
                context->cnt--;
                context->stream_len += 8;
            }
            value = context->stream;
            value |= (long)stock << 32;
            value = (long)((value >> (int)(context->stream_len - bits)) & ((1 << bits) - 1));
            context->stream_len -= bits;
    
            return value;
        }

        public static bool ENC_OFFSET_WIDTH = false;
        public static void CXUncompressLH( byte* srcp, byte* dstp, VoidPtr work)
        {
            byte LENGTH_BITS = 9;
            byte OFFSET_BITS;
            uint OFFSET_MASK, LEAF_FLAG;
            ushort offset_bit;
            if (ENC_OFFSET_WIDTH)
            {
                OFFSET_BITS = 5;
                OFFSET_MASK = 0x07;
                LEAF_FLAG = 0x10;
            }
            else
            {
                OFFSET_BITS = 12;
                OFFSET_MASK = 0x3FF;
                LEAF_FLAG = 0x800;
            }
            uint dstSize;
            uint dstCnt = 0;
            byte *pSrc = srcp;
            BitReader stream;
            ushort* huffTable9;
            ushort* huffTable12;
    
            huffTable9  = (ushort*)work;
            huffTable12 = (ushort*)work + (1 << LENGTH_BITS) * 2;
    
            // load the header
            dstSize = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            pSrc += 4;
            if (dstSize == 0)
            {
                dstSize = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
            }
    
            // read the Huffman table
            pSrc += CXiHuffImportTree(huffTable9,  pSrc, LENGTH_BITS);
            pSrc += CXiHuffImportTree(huffTable12, pSrc, OFFSET_BITS);
    
            BitReader_Init(&stream, pSrc);
    
            while (dstCnt < dstSize)
            {
                ushort* nodep = huffTable9 + 1;
                ushort  val;
                do 
                {
                    byte bit = BitReader_Read(&stream);
                    uint offset = ((((uint)*nodep & 0x7F) + 1U) << 1) + bit;
            
                    if ((*nodep & (0x100 >> bit)) != 0)
                    {
                        nodep = (ushort*)((uint)nodep & ~0x3);
                        val   = *(nodep + offset);
                        break;
                    }
                    else
                    {
                        nodep = (ushort*)((uint)nodep & ~0x3);
                        nodep += offset;
                    }
                } while (true);
        
                if (val < 0x100) // uncompressed data
                    dstp[dstCnt++] = (byte)val;
                else // compressed data
                {
                    ushort length = (ushort)((val & 0xFF) + 3);
                    nodep = huffTable12 + 1;
                    do
                    {
                        byte  bit = BitReader_Read(&stream);
                        uint offset = ((((uint)*nodep & OFFSET_MASK) + 1U) << 1) + bit;
                
                        if ((*nodep & (LEAF_FLAG >> bit)) != 0)
                        {
                            nodep = (ushort*)((uint)nodep & ~0x3);
                            val   = *(nodep + offset);
                            break;
                        }
                        else
                        {
                            nodep = (ushort*)((uint)nodep & ~0x3);
                            nodep += offset;
                        }
                    } while (true);
            
                    if (ENC_OFFSET_WIDTH)
                    {
                        offset_bit = val;
                        val = 0;
                        if (offset_bit > 0)
                        {
                            val = 1;
                            while (--offset_bit > 0)
                            {
                                val <<= 1;
                                val |= BitReader_Read(&stream);
                            }
                        }
                    }
                    val += 1;
                    // Measures for buffer overrun when invalid data is decompressed.
                    if (dstCnt + length > dstSize)
                    {
                        length = (ushort)(dstSize - dstCnt);
                    }
            
                    while (length-- > 0)
                    {
                        dstp[dstCnt] = dstp[dstCnt - val];
                        ++dstCnt;
                    }
                }
            }
        }

        // Structure for the range coder state
        public struct RCState
        {
            public uint     low;
            public uint     range;
            public uint     code;       // only used during decompression
            public byte     carry;      // only used during compression
            public uint     carry_cnt;  // only used during compression
        }

        // Range coder structure
        public struct RCCompressionInfo
        {
            public uint *freq;         // Table for occurrence frequency: (1 << bitSize) * sizeof(uint) bytes
            public uint *low_cnt;      // Table for the LOW border value: (1 << bitSize) * sizeof(uint) bytes
            public uint total;         // Total: 4 bytes
            public byte bitSize;       // Bit size: 1 byte
            public byte padding;    
        }

        public static uint RC_MAX_RANGE = 0x80000000;

        static void RCInitState_(RCState* state)
        {
            state->low   = 0;
            state->range = RC_MAX_RANGE;
            state->code  = 0;
            state->carry = 0;
            state->carry_cnt = 0;
        }

        static void RCInitInfo_(RCCompressionInfo* info, byte bitSize, VoidPtr work)
        {
            uint tableSize = (uint)(1 << bitSize);
            uint i;
    
            info->bitSize = bitSize;
            info->freq    = (uint*)work;
            info->low_cnt = (uint*)((uint)work + tableSize * sizeof(uint));
    
            for (i = 0; i < tableSize; i++)
            {
                info->freq[i]    = 1;
                info->low_cnt[i] = i;
            }
            info->total = tableSize;
        }

        public static void RCAddCount_(RCCompressionInfo* info, ushort val)
        {
            uint i;
            uint tableSize = (uint)(1 << info->bitSize);
    
            info->freq[val]++;
            info->total++;
            for (i = (uint)(val + 1); i < tableSize; i++)
            {
                info->low_cnt[i]++;
            }
    
            // Reruct if the total exceeds the maximum value.
            if (info->total >= 0x00010000)
            {
                if (info->freq[0] > 1)
                {
                    info->freq[0] = info->freq[0] / 2;
                }
                info->low_cnt[0] = 0;
                info->total = info->freq[0];
        
                for (i = 1; i < tableSize; i++)
                {
                    if (info->freq[i] > 1)
                    {
                        info->freq[i] >>= 1;
                    }
                    info->low_cnt[i] = info->low_cnt[i - 1] + info->freq[i - 1];
                    info->total += info->freq[i];
                }
            }
        }

        public static ushort RCGetData_( byte* srcp, RCCompressionInfo* info, RCState* state, uint* pSrcCnt)
        {
            uint MIN_RANGE = 0x01000000;
            ushort val = RCSearch_(info, state->code, state->range, state->low);
            uint cnt = 0;
            {
                uint tmp;
                tmp          =  state->range / info->total;
                state->low   += info->low_cnt[val] * tmp;
                state->range =  info->freq[val] * tmp;
            }
    
            // Update the table for occurrence frequency
            RCAddCount_(info, val);
    
            while (state->range < MIN_RANGE)
            {
                state->code  <<= 8;
                state->code  += srcp[cnt++];
                state->range <<= 8;
                state->low   <<= 8;
            }
            *pSrcCnt = cnt;
    
            return val;
        }

        public static ushort RCSearch_(RCCompressionInfo* info, uint code, uint range, uint low)
        {
            uint tableSize = (uint)(1 << info->bitSize);
            uint codeVal = code - low;
            uint i;
            uint temp = range / info->total;
            uint tempVal = codeVal / temp;
    
            // binary search
            uint left  = 0;
            uint right = tableSize - 1;
    
            while (left < right)
            {
                i = (left + right) / 2;
        
                if (info->low_cnt[i] > tempVal)
                    right = i;
                else
                    left = i + 1;
            }
    
            i = left;
            while (info->low_cnt[i] > tempVal)
                --i;
            return (ushort)i;
        }

        public static void CXUncompressLRC( byte* srcp, byte* dstp, VoidPtr work)
        {
            byte LENGTH_BITS = 9;
            byte OFFSET_BITS = 12;
            RCCompressionInfo infoVal;
            RCCompressionInfo infoOfs;
            RCState           rcState;
             byte*         pSrc = srcp;
            uint               dstCnt  = 0;
            uint               dstSize = 0;
    
            RCInitInfo_(&infoVal, LENGTH_BITS, work);
            RCInitInfo_(&infoOfs, OFFSET_BITS, (byte*)work + (1 << LENGTH_BITS) * sizeof(uint) * 2);
            RCInitState_(&rcState);
    
            // load the header
            dstSize = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            pSrc += 4;
            if (dstSize == 0)
            {
                dstSize = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
            }
    
            // load the initial code
            rcState.code = (uint)((*pSrc       << 24) |
                                  (*(pSrc + 1) << 16) |
                                  (*(pSrc + 2) <<  8) |
                                  (*(pSrc + 3)     ));
            pSrc += 4;
    
            // continue to get values from the range coder and perform LZ decompression
            while (dstCnt < dstSize)
            {
                uint cnt;
                ushort val = (ushort)(RCGetData_(pSrc, &infoVal, &rcState, &cnt));
                pSrc += cnt;
        
                if (val < 0x100)
                // uncompressed data
                {
                    dstp[dstCnt++] = (byte)val;
                }
                else
                // compressed data
                {
                    ushort length = (ushort)((val & 0xFF) + 3);
                    val = (ushort)(RCGetData_(pSrc, &infoOfs, &rcState, &cnt) + 1);
                    pSrc += cnt;
            
                    // check for a buffer overrun
                    if (dstCnt + length > dstSize)
                    {
                        return;
                    }
                    if (dstCnt < val)
                    {
                        return;
                    }
            
                    while (length-- > 0)
                    {
                        dstp[dstCnt] = dstp[dstCnt - val];
                        ++dstCnt;
                    }
                }
            }
        }

        public static void CXUnfilterDiff(void *srcp, void *destp)
        {
            byte* pSrc = (byte*)srcp;
            byte* pDst = (byte*)destp;
            uint bitSize = *pSrc & 0xFU;
            int destCount = (int)(CX.iConvertEndian(*(uint*)pSrc) >> 8);
            uint sum = 0;
    
            pSrc += 4;
    
            if (bitSize != 1)
            {
                // Difference calculation in units of 8 bits
                do 
                {
                    byte tmp = *(pSrc++);
                    destCount--;
                    sum += tmp;
                    *(pDst++) = (byte)sum;
                } while (destCount > 0);
            }
            else
            {
                // Difference calculation in units of 16 bits
                do 
                {
                    ushort tmp = CX.iConvertEndian16(*(ushort*)pSrc);
                    pSrc += 2;
                    destCount -= 2;
                    sum += tmp;
                    *(ushort*)pDst = CX.iConvertEndian16((ushort)sum);
                    pDst += 2;
                } while (destCount > 0);
            }
        }

        public static CX.CXCompressionHeader CXGetCompressionHeader(VoidPtr data)
        {
            CX.CXCompressionHeader ret = new CX.CXCompressionHeader();
    
            ret.compType  = (byte)((*(byte*)data & 0xF0) >> 4);
            ret.compParam = (byte)(*(byte*)data & 0x0F);

            ret.destSize  = CX.iConvertEndian(*(uint*)data) >> 8;
            if (ret.destSize == 0)
                ret.destSize = CX.iConvertEndian(*((uint*)data + 1));
            
            return ret;
        }
    }
}
