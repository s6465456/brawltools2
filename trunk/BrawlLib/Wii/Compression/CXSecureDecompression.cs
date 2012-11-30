using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BrawlLib.Wii.Compression
{
    public static unsafe class CXSecureDecompression
    { 
        public static int CXSecureUncompressAny(VoidPtr srcp, uint srcSize, VoidPtr destp)
        {
            switch (CX.GetCompressionType(srcp))
            {
                // Run-length compressed data
                case CX.CompressionType.CX_COMPRESSION_RL:
                    return CXSecureUncompressRL(srcp, srcSize, destp);
                // LZ77-compressed data
                case CX.CompressionType.CX_COMPRESSION_LZ:
                    return CXSecureUncompressLZ(srcp, srcSize, destp);
                // Huffman-compressed data
                case CX.CompressionType.CX_COMPRESSION_HUFFMAN:
                    return CXSecureUncompressHuffman(srcp, srcSize, destp);
                // Difference filter
                case CX.CompressionType.CX_COMPRESSION_DIFF:
                    return CXSecureUnfilterDiff(srcp, srcSize, destp);
                default:
                    return (int)CX.ERR.UNSUPPORTED;
            }
        }

        public static int CXSecureUncompressRL( VoidPtr srcp, uint srcSize, VoidPtr destp)
        {
            byte *pSrc  = (byte*)srcp;
            byte       *pDst  = (byte*)destp;
            byte       compType  = (byte)(CX.iConvertEndian(*(uint*)pSrc) & 0xFF);
            uint      destCount = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            int      srcCount  = (int)srcSize;
    
            if ((compType & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_RL)
                return (int)CX.ERR.UNSUPPORTED;
            if ((compType & 0xF) != 0)
                return (int)CX.ERR.UNSUPPORTED;
            if (srcSize <= 4)
                return (int)CX.ERR.SRC_SHORTAGE;

            pSrc     += 4;
            srcCount -= 4;
    
            if (destCount == 0)
            {
                if (srcCount < 4)
                    return (int)CX.ERR.SRC_SHORTAGE;

                destCount = CX.iConvertEndian(*(uint*)pSrc);
                pSrc     += 4;
                srcCount -= 4;
            }
    
            while (destCount > 0)
            {
                byte  flags  = *pSrc++;
                int length = flags & 0x7f;
                if (--srcCount < 0)
                    return (int)CX.ERR.SRC_SHORTAGE;
        
                if ((flags & 0x80) == 0)
                {
                    length++;
                    if (length > destCount)
                    // A buffer overrun handler for when invalid data is decompressed.
                        return (int)CX.ERR.DEST_OVERRUN;
                    srcCount -= length;
                    if (srcCount < 0)
                        return (int)CX.ERR.SRC_SHORTAGE;
            
                    destCount -= (uint)length;
                    do { *pDst++ = *pSrc++; } while (--length > 0);
                }
                else
                {
                    byte srcTmp;
            
                    length += 3;
                    if (length > destCount)
                    // A buffer overrun handler for when invalid data is decompressed.
                        return (int)CX.ERR.DEST_OVERRUN;
            
                    destCount -= (uint)length;
                    srcTmp    = *pSrc++;
                    if (--srcCount < 0)
                        return (int)CX.ERR.SRC_SHORTAGE;
                    do
                    {
                        *pDst++ =  srcTmp;
                    } while (--length > 0);
                }
            }
    
            if (srcCount > 32)
                return (int)CX.ERR.SRC_REMAINDER;
    
            return (int)CX.ERR.SUCCESS;
        }

        public static int CXSecureUncompressLZ(VoidPtr srcp, uint srcLen, VoidPtr destp)
        {
            byte* pSrc = (byte*)srcp;
            byte* pDst = (byte*)destp;
            byte compType = (byte)(CX.iConvertEndian(*(uint*)pSrc) & 0xFF);

            uint dstLen = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            VoidPtr dstCeil = destp + dstLen;
            VoidPtr srcCeil = srcp + srcLen;

            bool exFormat = (*pSrc & 0x0F) != 0;

            if ((compType & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_LZ)
                return (int)CX.ERR.UNSUPPORTED;
            if (((compType & 0xF) != 0x0) && ((compType & 0xF) != 0x1))
                return (int)CX.ERR.UNSUPPORTED;
            if (srcLen <= 4)
                return (int)CX.ERR.SRC_SHORTAGE;

            pSrc += 4;
            srcLen -= 4;

            if (dstLen == 0)
            {
                if (srcLen < 4)
                    return (int)CX.ERR.SRC_SHORTAGE;

                dstLen = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
                srcLen -= 4;
            }

            while (pDst < dstCeil)
            {
                byte flags = *pSrc++;

                if (srcCeil < pSrc)
                    return (int)CX.ERR.SRC_SHORTAGE;

                for (int i = 0; i < 8 && pDst < dstCeil; i++)
                {
                    if ((flags >> (8 - i)) == 0)
                    {
                        *pDst++ = *pSrc++;

                        if (srcCeil < pSrc)
                            return (int)CX.ERR.SRC_SHORTAGE;
                    }
                    else
                    {
                        int length = (*pSrc >> 4);
                        int offset = (((*pSrc++ & 0xF) << 8) | *pSrc++) + 2;

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
                            else length += 1;
                        }

                        if (srcCeil < pSrc)
                            return (int)CX.ERR.SRC_SHORTAGE;

                        // A buffer overrun handler for when invalid data is decompressed.
                        if (length > dstLen)
                            return (int)CX.ERR.DEST_OVERRUN;
                        if (&pDst[-offset] < destp)
                            return (int)CX.ERR.DEST_OVERRUN;

                        while (length-- > 0 && pDst != dstCeil) { *pDst++ = pDst[-offset]; }
                    }
                }
            }

            if (srcCeil - pSrc > 32)
                return (int)CX.ERR.SRC_REMAINDER;
    
            return (int)CX.ERR.SUCCESS;
        }

        public static bool CXiVerifyHuffmanTable_( VoidPtr pTable, byte bit)
        {
            uint FLAGS_ARRAY_NUM = 512 / 8; /* 64 byte */
            byte* treep = (byte*)pTable;
            byte* treeStartp = treep + 1;
            uint treeSize   = *treep;
            byte* treeEndp   = (byte*)pTable + (treeSize + 1) * 2;
            uint i;
            byte[]  end_flags = new byte[FLAGS_ARRAY_NUM];
            uint idx;
    
            for (i = 0; i < FLAGS_ARRAY_NUM; i++)
                end_flags[i] = 0;
    
            if (bit == 4)
                if (treeSize >= 0x10)
                    return false;

            idx = 1;
            treep = treeStartp;
            while (treep < treeEndp)
            {
                if ((end_flags[idx / 8] & (1 << (int)(idx % 8))) == 0)
                {
                    uint  offset = (uint)(((*treep & 0x3F) + 1) << 1);
                    byte*  nodep  = (byte*)((((uint)treep >> 1) << 1) + offset);
            
                    // Skip data added at the end for alignment.
                    if (*treep == 0 && idx >= (treeSize * 2))
                        goto next;

                    if (nodep >= treeEndp)
                        return false;
                    if ((*treep & 0x80) != 0)
                    {
                        uint left = (uint)(idx & ~0x1) + offset;
                        end_flags[left / 8] |= (byte)(1 << (int)(left % 8));
                    }
                    if ((*treep & 0x40) != 0)
                    {
                        uint right = (uint)(idx & ~0x1) + offset + 1;
                        end_flags[right / 8] |= (byte)(1 << (int)(right % 8));
                    }
                }
            next:
                ++idx;
                ++treep;
            }
            return true;
        }

        public static int CXSecureUncompressHuffman(VoidPtr srcp, uint srcSize, VoidPtr destp)
        {
            byte TREE_END = 0x80;
            uint* pSrc          = (uint*)srcp;
            uint       *pDst          = (uint*)destp;
            byte        compType       = (byte)(CX.iConvertEndian(*(uint*)pSrc) & 0xFF);
            int       destCount      = (int)(CX.iConvertEndian(*pSrc) >> 8);
            byte        *treep         = (destCount != 0)? ((byte*)pSrc + 4) : ((byte*)pSrc + 8);
            byte        *treeStartp    = treep + 1;
            uint       dataBit        = *(byte*)pSrc & 0x0FU;
            uint       destTmp        = 0;
            uint       destTmpCount   = 0;
            uint       destTmpDataNum = 4 + (dataBit & 0x7);
            int       srcCount       = (int)srcSize;
            uint       treeSize       = (uint)((*treep + 1) << 1);
    
            if ((compType & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_HUFFMAN)
                return (int)CX.ERR.UNSUPPORTED;
            
            if ((dataBit != 4) && (dataBit != 8))
                return (int)CX.ERR.UNSUPPORTED;
    
            if (destCount == 0)
                if (srcSize < 8 + treeSize)
                    return (int)CX.ERR.SRC_SHORTAGE;
                else
                    destCount = (int)(CX.iConvertEndian(*(pSrc + 1)));
            else if (srcSize < 4 + treeSize)
                return (int)CX.ERR.SRC_SHORTAGE;
    
            if (!CXiVerifyHuffmanTable_(treep, (byte)dataBit))
                return (int)CX.ERR.ILLEGAL_TABLE;
    
            pSrc  = (uint*)(treep + treeSize);
            srcCount -= (int)((uint)pSrc - (uint)srcp);
    
            if (srcCount < 0)
                return (int)CX.ERR.SRC_SHORTAGE;
    
            treep = treeStartp;
    
            while (destCount > 0)
            {
                int srcTmpCount = 32;
                uint srcTmp = CX.iConvertEndian(*pSrc++); // Endian strategy
                srcCount -= 4;
                if (srcCount < 0)
                    return (int)CX.ERR.SRC_SHORTAGE;

                while (--srcTmpCount >= 0)
                {
                    uint treeShift = (srcTmp >> 31) & 0x1;
                    uint treeCheck = *treep;
                    treeCheck <<= (int)treeShift;
                    treep = (byte*)((((uint)treep >> 1) << 1) + (((*treep & 0x3f) + 1) << 1) + treeShift);
                    if ((treeCheck & TREE_END)!= 0)
                    {
                        destTmp >>= (int)dataBit;
                        destTmp |= (uint)*treep << (byte)(32 - dataBit);
                        treep = treeStartp;
                        ++destTmpCount;

                        if (destCount <= (destTmpCount * dataBit) / 8)
                        {
                            destTmp >>= (int)((destTmpDataNum - destTmpCount) * dataBit);
                            destTmpCount = destTmpDataNum;
                        }

                        if (destTmpCount == destTmpDataNum)
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
            if (srcCount > 32)
                return (int)CX.ERR.SRC_REMAINDER;
    
            return (int)CX.ERR.SUCCESS;
        }

        public static uint CXiHuffImportTree(ushort* pTable,  byte* srcp, byte bitSize, uint srcRemainSize)
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
            if (srcRemainSize < tableSize)
                return tableSize;
            
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

        public static int CXSecureUnfilterDiff(VoidPtr srcp, uint srcSize, VoidPtr destp)
        {
            byte* pSrc = (byte*)srcp;
            byte* pDst = (byte*)destp;
            uint       bitSize    = *pSrc & 0xFU;
            byte        compType   = (byte)(CX.iConvertEndian(*(uint*)pSrc) & 0xFF);
            int       destCount  = (int)(CX.iConvertEndian(*(uint*)pSrc) >> 8);
            uint       sum = 0;
            int       srcCount  = (int)srcSize;
    
            if ((compType & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_DIFF)
            {
                return (int)CX.ERR.UNSUPPORTED;
            }
            if ((bitSize != 0) && (bitSize != 1))
            {
                return (int)CX.ERR.UNSUPPORTED;
            }
            if (srcSize <= 4)
            {
                return (int)CX.ERR.SRC_SHORTAGE;
            }
    
            pSrc     += 4;
            srcCount -= 4;
    
            if (bitSize != 1)
            {
                // Difference calculation in units of 8 bits
                do 
                {
                    byte tmp = *(pSrc++);
                    if (--srcCount < 0)
                    {
                        return (int)CX.ERR.SRC_SHORTAGE;
                    }
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
                    srcCount -= 2;
                    if (srcCount < 0)
                    {
                        return (int)CX.ERR.SRC_SHORTAGE;
                    }
                    destCount -= 2;
                    sum += tmp;
                    *(ushort*)pDst = CX.iConvertEndian16((ushort)sum);
                    pDst += 2;
                } while (destCount > 0);
            }
            if (srcCount > 32)
            {
                return (int)CX.ERR.SRC_REMAINDER;
            }
    
            return (int)CX.ERR.SUCCESS;
        }

        public static bool ENC_OFFSET_WIDTH = false;

        public static bool CXiLHVerifyTable( VoidPtr pTable, byte bit)
        {
            int FLAGS_ARRAY_NUM;
            if (!ENC_OFFSET_WIDTH)
                FLAGS_ARRAY_NUM = 8192 / 8; /* 1024 bytes */
            else
                FLAGS_ARRAY_NUM = 1024 / 8;  /* 128 bytes */
            byte[] end_flags = new byte[FLAGS_ARRAY_NUM];

            ushort* treep = (ushort*)pTable;
            ushort* treeStartp = treep + 1;
            uint treeSize = *treep;
            ushort* treeEndp = (ushort*)pTable + treeSize;
            uint i;
            uint idx;
            ushort ofs_mask = (ushort)((1 << (bit - 2)) - 1);
            ushort l_mask   = (ushort)(1 << (bit - 1));
            ushort r_mask   = (ushort)(1 << (bit - 2));
    
            for (i = 0; i < FLAGS_ARRAY_NUM; i++)
                end_flags[i] = 0;

            if (treeSize > (1U << (bit + 1)))
                return false;
            
            idx = 1;
            treep = treeStartp;
            while (treep < treeEndp)
            {
                if ((end_flags[idx / 8] & (1 << (int)(idx % 8))) == 0)
                {
                    uint offset = (uint)(((*treep & ofs_mask) + 1) << 1);
                    ushort* nodep  = (ushort*)((uint)treep & ~0x3) + offset;
            
                    // Skip data added at the end for alignment.
                    if (*treep == 0 && idx >= treeSize - 4)
                        goto next;
                    if (nodep >= treeEndp)
                        return false;
                    if ((*treep & l_mask) != 0)
                    {
                        uint left = (uint)(idx & ~0x1) + offset;
                        end_flags[left / 8] |= (byte)(1 << (int)(left % 8));
                    }
                    if ((*treep & r_mask) != 0)
                    {
                        uint right = (uint)(idx & ~0x1) + offset + 1;
                        end_flags[right / 8] |= (byte)(1 << (int)(right % 8));
                    }
                }
            next:
                ++idx;
                ++treep;
            }
            return true;
        }

        public struct BitReader
        {
           public byte* srcp;
           public uint cnt;
           public uint stream;
           public uint stream_len;
           public uint srcSize;
        }

        public static void BitReader_Init( BitReader* context, byte* srcp, uint srcSize )
        {
            context->srcp       = srcp;
            context->cnt        = 0; 
            context->stream     = 0;
            context->stream_len = 0;
            context->srcSize    = srcSize;
        }

        public static sbyte BitReader_Read(BitReader* context)
        {
            sbyte bit;
            if ( context->stream_len == 0 )
            {
                if ( context->cnt > context->srcSize )
                    return -1;
        
                context->stream     = context->srcp[context->cnt++];
                context->stream_len = 8;
            }
            bit = (sbyte)((context->stream >> (int)(context->stream_len - 1)) & 0x1 );
            context->stream_len--;
            return bit;
        }

        public static int CXSecureUncompressLH(byte* srcp, uint srcSize, byte* dstp, VoidPtr work)
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
            uint       dstSize;
            uint       dstCnt = 0;
            byte  *pSrc  = srcp;
            BitReader stream;
            ushort* huffTable9;    // Huffman table for length
            ushort* huffTable12;   // Huffman table for offset
            byte*  verify_work;   // For checking out-of-bounds accesses in the Huffman table (TODO: Not yet used)
    
            if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_LH)
                return (int)CX.ERR.UNSUPPORTED;
            if (srcSize <= 4)
                return (int)CX.ERR.SRC_SHORTAGE;
    
            huffTable9  = (ushort*)work;
            huffTable12 = (ushort*)work + (1 << LENGTH_BITS) * 2;
            verify_work = (byte*)work + CX.CX_UNCOMPRESS_LH_WORK_SIZE;

            // load the header
            dstSize = CX.iConvertEndian(*(uint*)pSrc) >> 8;
            pSrc += 4;
            if (dstSize == 0)
            {
                dstSize = CX.iConvertEndian(*(uint*)pSrc);
                pSrc += 4;
                if (srcSize < 8)
                    return (int)CX.ERR.SRC_SHORTAGE;
            }
    
            // read the Huffman table
            pSrc += CXiHuffImportTree(huffTable9,  pSrc, LENGTH_BITS, srcSize - ((uint)pSrc - (uint)srcp));
            if (pSrc > srcp + srcSize)
                return (int)CX.ERR.SRC_SHORTAGE;
            if (! CXiLHVerifyTable(huffTable9, LENGTH_BITS))
                return (int)CX.ERR.ILLEGAL_TABLE;
            pSrc += CXiHuffImportTree(huffTable12, pSrc, OFFSET_BITS, srcSize - ((uint)pSrc - (uint)srcp));
            if (pSrc > srcp + srcSize)
                return (int)CX.ERR.SRC_SHORTAGE;
            if (! CXiLHVerifyTable(huffTable12, OFFSET_BITS))
                return (int)CX.ERR.ILLEGAL_TABLE;
    
            BitReader_Init(&stream, pSrc, srcSize - ((uint)pSrc - (uint)srcp));
    
            while (dstCnt < dstSize)
            {
                ushort* nodep = huffTable9 + 1;
                ushort  val;
                do 
                {
                    sbyte  bit = BitReader_Read(&stream);
                    uint offset = (uint)(((((uint)*nodep & 0x7F) + 1U) << 1) + bit);
                    if (bit < 0)
                        return (int)CX.ERR.SRC_SHORTAGE;
            
                    if ((*nodep & (0x100 >> bit)) != 0)
                    {
                        nodep = (ushort*)((uint)nodep & ~0x3);
                        val  = *(nodep + offset);
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
                        sbyte  bit    = BitReader_Read(&stream);
                        uint offset = (uint)(((((uint)*nodep & OFFSET_MASK) + 1U) << 1) + bit);
                
                        if (bit < 0)
                            return (int)CX.ERR.SRC_SHORTAGE;
                
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
                                val |= (byte)BitReader_Read(&stream);
                            }
                        }
                    }
                
                    val += 1;
            
                    if (dstCnt - val < 0)
                        return (int)CX.ERR.DEST_OVERRUN;
                    if (dstCnt + length > dstSize)
                        return (int)CX.ERR.DEST_OVERRUN;
            
                    while (length-- > 0)
                    {
                        dstp[dstCnt] = dstp[dstCnt - val];
                        ++dstCnt;
                    }
                }
            }
    
            if (stream.srcSize - stream.cnt > 32)
                return (int)CX.ERR.SRC_REMAINDER;
            
            return (int)CX.ERR.SUCCESS;
        }

        // Structure for the range coder state
        public struct RCState
        {
            public uint low;
            public uint range;
            public uint code;       // only used during decompression
            public byte carry;      // only used during compression
            public uint carry_cnt;  // only used during compression
        }

        // Range coder structure
        public struct RCCompressionInfo
        {
            public uint* freq;          // Table for occurrence frequency: (1 << bitSize) * sizeof(uint) bytes
            public uint* low_cnt;       // Table for the LOW border value: (1 << bitSize) * sizeof(uint) bytes
            public uint total;          // Total: 4 bytes
            public byte bitSize;       // Bit size: 1 byte
            public byte padding;
        }

        public static uint RC_MAX_RANGE = 0x80000000;

        public static void RCInitState_(RCState* state)
        {
            // The starting range is 0x80000000, so a carry will not suddenly occur the first time
            state->low   = 0;
            state->range = RC_MAX_RANGE;
            state->code  = 0;
            state->carry = 0;
            state->carry_cnt = 0;
        }

        public static void RCInitInfo_(RCCompressionInfo* info, byte bitSize, VoidPtr work)
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
                    info->freq[0] = info->freq[0] / 2;
                
                info->low_cnt[0] = 0;
                info->total = info->freq[0];
        
                for (i = 1; i < tableSize; i++)
                {
                    if (info->freq[i] > 1)
                        info->freq[i] >>= 1;
                    
                    info->low_cnt[i] = info->low_cnt[i - 1] + info->freq[i - 1];
                    info->total += info->freq[i];
                }
            }
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

        public static int CXSecureUncompressLRC( byte* srcp, uint srcSize, byte* dstp, VoidPtr work)
        {
            byte LENGTH_BITS=  9;
            byte OFFSET_BITS = 12;
            RCCompressionInfo infoVal;
            RCCompressionInfo infoOfs;
            RCState rcState;
            byte* pSrc = srcp;
            uint dstCnt  = 0;
            uint dstSize = 0;

            if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_LRC)
                return (int)CX.ERR.UNSUPPORTED;
            if (srcSize <= 4)
                return (int)CX.ERR.SRC_SHORTAGE;
    
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
                if (srcSize < 8)
                    return (int)CX.ERR.SRC_SHORTAGE;
            }
    
            // load the initial code
            if (srcSize - ((uint)pSrc - (uint)srcp) < 4)
                return (int)CX.ERR.SRC_SHORTAGE;
            
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
        
                if (val < 0x100) // uncompressed data
                    dstp[dstCnt++] = (byte)val;
                else // compressed data
                {
                    ushort length = (ushort)((val & 0xFF) + 3);
                    val = (ushort)(RCGetData_(pSrc, &infoOfs, &rcState, &cnt) + 1);
                    pSrc += cnt;
            
                    // check for a buffer overrun
                    if (dstCnt + length > dstSize)
                        return (int)CX.ERR.DEST_OVERRUN;
                    if (dstCnt < val)
                        return (int)CX.ERR.DEST_OVERRUN;
                    if (((uint)pSrc - (uint)srcp) > srcSize)
                        return (int)CX.ERR.SRC_SHORTAGE;
            
                    while (length-- > 0)
                    {
                        dstp[dstCnt] = dstp[dstCnt - val];
                        ++dstCnt;
                    }
                }
            }
            return (int)CX.ERR.SUCCESS;
        }
    }
}