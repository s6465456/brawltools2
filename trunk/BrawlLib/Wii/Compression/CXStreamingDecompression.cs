using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BrawlLib.Wii.Compression
{
    public unsafe class CXStreamingDecompression
    {
        public struct CXUncompContextRL // 16 bytes
        {
            public byte *destp;                       // Write-destination pointer
            public int destCount;                     // Remaining size to write
            public int forceDestCount;                // Forcibly set the decompression size
            public ushort length;                     // Remaining size of continuous write
            public byte  flags;                       // Compression flag
            public byte  headerSize;                  // Size of header being read
        }

        public struct CXUncompContextLZ // 24 bytes
        {
            public byte *destp;                       // Write-destination pointer
            public int destCount;                     // Remaining size to write
            public int forceDestCount;                // Forcibly set the decompression size
            public int length;                        // Remaining length of continuous write
            public byte lengthFlg;                    // 'length' obtained flag
            public byte flags;                        // Compression flag
            public byte flagIndex;                    // Current compression flag index
            public byte headerSize;                   // Size of header being read
            public byte exFormat;                     // LZ77 compression extension option
            public byte pad1;    
            public byte pad2;
            public byte pad3;
        }

        public struct CXUncompContextHuffman
        {
            public byte *destp;                       // Write-destination pointer
            public int destCount;                     // Remaining size to write
            public int forceDestCount;                // Forcibly set the decompression size
            public byte *treep;                       // Huffman encoding table, current pointer
            public uint srcTmp;                       // Data being read
            public uint destTmp;                      // Data being decoded
            public short treeSize;                    // Size of Huffman encoding table
            public byte  srcTmpCnt;                   // Size of data being read
            public byte  destTmpCnt;                  // Number of bits that have been decoded
            public byte  bitSize;                     // Size of encoded bits
            public byte  headerSize;                  // Size of header being read
            public byte  pad1;  
            public byte  pad2;
            public fixed byte tree[0x200]; // Huffman encoding table: 512B (32B is enough for 4-bit encoding, but allocated enough for 8-bit encoding)
            //Total = 544B  (60B sufficient if 4-bit encoding)
        }

        public struct CXUncompContextLH //2216 bytes
        {
            public byte *destp;                         // Write-destination pointer
            public int destCount;                      // Remaining size to write
            public int forceDestCount;                 // Forcibly set the decompression size
            public fixed ushort huffTable9 [ 1 << (9 + 1) ];    // Huffman encoding table: 2048B
            public fixed ushort huffTable12[ 1 << (5 + 1) ];    // Huffman encoding table: 128B
            public ushort *nodep;                         // Node during a Huffman table search
            public int tableSize9;                     // Table size during a load
            public int tableSize12;                    // Table size during a load
            public uint tableIdx;                       // Index for the table load position
            public uint stream;                         // Bit stream for loading
            public uint stream_len;                     // Number of valid stream bits for loading
            public ushort length;                         // Read length for LZ compression
            public sbyte offset_bits;                    // Bit length for offset information
            public byte headerSize;                     // Size of header being read
        }
        
        public struct CXUncompContextLRC // 36908 bytes
        {
            public byte *destp;                         // Write-destination pointer
            public int destCount;                      // Remaining size to write
            public int forceDestCount;                 // Forcibly set the decompression size
            public fixed uint freq9    [1 << 9];           // Frequency table for code data (2048 bytes)
            public fixed uint low_cnt9 [1 << 9];           // low_cnt table for code data: 2048B
            public fixed uint freq12   [1 << 12];           // Frequency table for offset data: 16384B
            public fixed uint low_cnt12[1 << 12];           // low_cnt table for offset data: 16384B
            public uint total9;                         // Total value for code data
            public uint total12;                        // Total value for offset data
            public uint range;                          // Range state of a range coder
            public uint code;                           // Code state of a range coder
            public uint low;                            // Low state of a range coder
            public uint carry_cnt;                      // Number of carry digits for a range coder
            public byte carry;                          // Carry state for a range coder
            public byte codeLen;                        // Code length required for a range coder
            public ushort length;                         // Read length for LZ compression

            public byte headerSize;                     // Size of header being read
            public byte pad1;
            public byte pad2;
            public byte pad3;                       
        }

        public static bool CXIsFinishedUncompRL(CXUncompContextRL *context )
        {
            return (context->destCount > 0 || context->headerSize > 0) ? false : true;
        }

        public static bool CXIsFinishedUncompLZ(CXUncompContextLZ *context)
        {
            return (context->destCount > 0 || context->headerSize > 0) ? false : true;
        }

        public static bool CXIsFinishedUncompHuffman(CXUncompContextHuffman* context)
        {
            return (context->destCount > 0 || context->headerSize > 0) ? false : true;
        }

        public static bool CXIsFinishedUncompLH(CXUncompContextLH* context)
        {
            return (context->destCount > 0 || context->headerSize > 0) ? false : true;
        }

        public static bool CXIsFinishedUncompLRC(CXUncompContextLRC* context)
        {
            return (context->destCount > 0 || context->headerSize > 0) ? false : true;
        }

        public static void CXInitUncompContextRLFront(CXUncompContextRL* context, VoidPtr dest, int destSize)
        {
            //ASSERT( destSize > 0 );
            CXInitUncompContextRL( context, dest );
            context->forceDestCount = destSize;
        }

        public static void CXInitUncompContextLZFront(CXUncompContextLZ* context, VoidPtr dest, int destSize)
        {
            //ASSERT( destSize > 0 );
            CXInitUncompContextLZ( context, dest );
            context->forceDestCount = destSize;
        }

        public static void CXInitUncompContextHuffmanFront(CXUncompContextHuffman* context, VoidPtr dest, int destSize)
        {
            //ASSERT( destSize > 0 );
            //ASSERT( (destSize % 4) == 0 );
            CXInitUncompContextHuffman( context, dest );
            context->forceDestCount = destSize;
        }

        public static void CXInitUncompContextLHFront(CXUncompContextLH* context, VoidPtr dest, int destSize)
        {
            //ASSERT( destSize > 0 );
            CXInitUncompContextLH( context, dest );
            context->forceDestCount = destSize;
        }

        public static void CXInitUncompContextLRCFront(CXUncompContextLRC* context, VoidPtr dest, int destSize)
        {
            //ASSERT( destSize > 0 );
            CXInitUncompContextLRC( context, dest );
            context->forceDestCount = destSize;
        }

        public static void CXInitUncompContextRL(CXUncompContextRL *context, VoidPtr dest)
        {
            context->destp      = (byte*)dest;
            context->destCount  = 0;
            context->flags      = 0;
            context->length     = 0;
            context->headerSize = 8;
            context->forceDestCount = 0;
        }

        public static void CXInitUncompContextLZ(CXUncompContextLZ *context, VoidPtr dest)
        {
            context->destp      = (byte*)dest;
            context->destCount  = 0;
            context->flags      = 0;
            context->flagIndex  = 0;
            context->length     = 0;
            context->lengthFlg  = 3;
            context->headerSize = 8;
            context->exFormat   = 0;
            context->forceDestCount = 0;
        }

        public static void CXInitUncompContextHuffman(CXUncompContextHuffman *context, VoidPtr dest)
        {
            context->destp      = (byte*)dest;
            context->destCount  = 0;
            context->bitSize    = 0;
            context->treeSize   = -1;
            context->treep      = &context->tree[ 0 ];
            context->destTmp    = 0;
            context->destTmpCnt = 0;
            context->srcTmp     = 0;
            context->srcTmpCnt  = 0;
            context->headerSize = 8;
            context->forceDestCount = 0;
        }

        public static uint CXiReadHeader(byte* headerSize, int *destCount, byte* srcp, uint srcSize, int forceDestSize)
        {
            uint readLen = 0;
            while (*headerSize > 0)
            {
                --(*headerSize);
                if (*headerSize <= 3)
                    *destCount |= (*srcp << ((3 - *headerSize) * 8));
                else if (*headerSize <= 6)
                    *destCount |= (*srcp << ((6 - *headerSize) * 8));
                
                ++srcp;
                ++readLen;
                if (*headerSize == 4 && *destCount > 0)
                    *headerSize = 0;
                
                if (--srcSize == 0 && *headerSize > 0)
                    return readLen;
                
            }
    
            if ((forceDestSize > 0) && (forceDestSize < *destCount))
                *destCount = forceDestSize;
            return readLen;
        }

        int CXReadUncompRL(CXUncompContextRL* context, VoidPtr data, uint len)
        {
            byte* srcp = (byte*)data;
            byte  srcTmp;
    
            // Header parsing
            if (context->headerSize > 0)
            {
                uint read_len;
                if (context->headerSize == 8)
                {
                    if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_RL)
                        return (int)CX.ERR.UNSUPPORTED;
                    
                    if ((*srcp & 0x0F) != 0)
                        return (int)CX.ERR.UNSUPPORTED;
                    
                }
                read_len = CXiReadHeader(&context->headerSize, &context->destCount, srcp, len, context->forceDestCount);
                srcp += read_len;
                len  -= read_len;
                if (len == 0)
                    return (context->headerSize == 0)? context->destCount : -1;
            }
    
            while (context->destCount > 0)
            {
                // Process if length > 0.
                if ((context->flags & 0x80) == 0)
                // Uncompressed data has a length not equal to 0
                {
                    while (context->length > 0)
                    {
                        *context->destp++ = *srcp++;
                        context->length--;
                        context->destCount--;
                        len--;
                        // End when the prepared buffer has been read in full
                        if (len == 0)
                            return context->destCount;
                    }
                }
                else if (context->length > 0)
                // Compressed data has a length not equal to 0
                {
                    srcTmp = *srcp++;
                    len--;
                    while (context->length > 0)
                    {
                        *context->destp++ = srcTmp;
                        context->length--;
                        context->destCount--;
                    }
                    if (len == 0)
                        return context->destCount;
                }
        
                // Reading the flag byte
                context->flags = *srcp++;
                len--;
                context->length = (ushort)(context->flags & 0x7F);
                if ((context->flags & 0x80) != 0)
                    context->length += 3;
                else
                    context->length += 1;
        
                if (context->length > context->destCount)
                // A buffer overrun handler for when invalid data is decompressed.
                {
                    if (context->forceDestCount == 0)
                        return (int)CX.ERR.DEST_OVERRUN;
                    
                    context->length = (ushort)context->destCount;
                }
                if (len == 0)
                    return context->destCount;
            }
    
            // Processing to perform in the event that context->destCount  == 0
            if ((context->forceDestCount == 0) && (len > 32))
                return (int)CX.ERR.SRC_REMAINDER;
            
            return 0;
        }

        public int CXReadUncompLZ(CXUncompContextLZ* context, VoidPtr data, uint len)
        {
            byte* srcp = (byte*)data;
            int offset;

            // Header parsing
            if (context->headerSize > 0)
            {
                uint read_len;
                // Process the first byte
                if (context->headerSize == 8)
                {
                    if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_LZ)
                        return (int)CX.ERR.UNSUPPORTED;
                    
                    // Record as an LZ compression parameter
                    context->exFormat = (byte)(*srcp & 0x0F);
                    if ((context->exFormat != 0x0) && (context->exFormat != 0x1))
                        return (int)CX.ERR.UNSUPPORTED;
                }
                read_len = CXiReadHeader(&context->headerSize, &context->destCount, srcp, len, context->forceDestCount);
                srcp += read_len;
                len  -= read_len;
                if (len == 0)
                    return (context->headerSize == 0)? context->destCount : -1;
            }
    
            while (context->destCount > 0)
            {
                while (context->flagIndex > 0)
                {
                    if (len == 0)
                        return context->destCount;
            
                    if ((context->flags & 0x80) == 0)
                    // Process for non-compressed data
                    {
                        *context->destp++ = *srcp++;
                        context->destCount--;
                        len--;
                    }
                    else
                    // Process for compressed data
                    {
                        while (context->lengthFlg > 0)
                        {
                            --context->lengthFlg;
                            if ( context->exFormat == 0)
                            {
                                context->length  = *srcp++;
                                context->length += (3 << 4);
                                context->lengthFlg = 0;
                            }
                            else
                            {
                                switch (context->lengthFlg)
                                {
                                    case 2:
                                        {
                                            context->length = *srcp++;
                                            if ((context->length >> 4) == 1)
                                            {
                                                // Read two more bytes
                                                context->length =  (context->length & 0x0F) << 16;
                                                context->length += ((0xFF + 0xF + 3) << 4);
                                            }
                                            else if ((context->length >> 4) == 0)
                                            {
                                                // Read one more byte
                                                context->length =  (context->length & 0x0F) << 8;
                                                context->length += ((0xF + 2) << 4);
                                                context->lengthFlg = 1;
                                            }
                                            else
                                            {
                                                context->length += (1 << 4);
                                                context->lengthFlg = 0;
                                            }
                                        }
                                        break;
                                    case 1: context->length += (*srcp++ << 8); break;
                                    case 0: context->length += *srcp++; break;
                                }
                            }
                            if (--len == 0)
                                return context->destCount;
                        }
                
                        offset = (context->length & 0xF) << 8;
                        context->length = context->length >> 4;
                        offset = (offset | *srcp++) + 1;
                        len--;
                        context->lengthFlg = 3;
                
                        // A buffer overrun handler for when invalid data is decompressed.
                        if (context->length > context->destCount)
                        {
                            if (context->forceDestCount == 0)
                                return (int)CX.ERR.DEST_OVERRUN;
                            
                            context->length = context->destCount;
                        }
                        // Copy a length amount of data located at the offset position
                        while (context->length > 0)
                        {
                            *context->destp = context->destp[ -offset ];
                            context->destp++;
                            context->destCount--;
                            context->length--;
                        }
                    }
            
                    if (context->destCount == 0)
                        goto Out;
                    
                    context->flags <<= 1;
                    context->flagIndex--;
                }
        
                if (len == 0)
                    return context->destCount;
                
                // Read a new flag
                context->flags     = *srcp++;
                context->flagIndex = 8;
                len--;
            }
    
        Out:
            // Processing to perform in the event that context->destCount  == 0
            if ((context->forceDestCount == 0) && (len > 32))
                return (int)CX.ERR.SRC_REMAINDER;
            
            return 0;
        }


        // Get the next node in the Huffman signed table
        public static byte* GetNextNode(byte* pTree, uint select)
        {
            return (byte*)(((uint)pTree & ~0x1) + (((*pTree & 0x3F) + 1) * 2) + select);
        }

        public static int CXReadUncompHuffman(CXUncompContextHuffman* context, VoidPtr data, uint len)
        {
            uint TREE_END_MASK = 0x80U;
            byte* srcp = (byte*)data;
            uint  select;
            uint  endFlag;
    
            // Header parsing
            if (context->headerSize > 0)
            {
                uint read_len;
                // Process the first byte
                if (context->headerSize == 8)
                {
                    context->bitSize = (byte)(*srcp & 0xF);

                    if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_HUFFMAN)
                        return (int)CX.ERR.UNSUPPORTED;
                    
                    if ((context->bitSize != 4) && (context->bitSize != 8))
                        return (int)CX.ERR.UNSUPPORTED;
                    
                }
                read_len = CXiReadHeader(&context->headerSize, &context->destCount, srcp, len, context->forceDestCount);
                srcp += read_len;
                len  -= read_len;
                if (len == 0)
                    return (context->headerSize == 0)? context->destCount : -1;
            }
    
            // treeSize is set to -1 in CXInitUncompContextHuffman.
            // When context->treeSize is negative, the data's beginning is used.
            if (context->treeSize < 0)
            {
                context->treeSize = (short)((*srcp + 1) * 2 - 1);
                *context->treep++ = *srcp++;
                len--;
            }
    
            // Load the Huffman signed table
            while (context->treeSize > 0)
            {
                if (len == 0)
                    return context->destCount;
                
                *context->treep++ = *srcp++;
                context->treeSize--;
                len--;
                if (context->treeSize == 0)
                {
                    context->treep = &context->tree[ 1 ];
                    if (!CXSecureDecompression.CXiVerifyHuffmanTable_(&context->tree[0], context->bitSize))
                        return (int)CX.ERR.ILLEGAL_TABLE;
                }
            }
    
            // Decoding process
            while (context->destCount > 0)
            {
                // src data is read in 4-byte units
                while (context->srcTmpCnt < 32)
                {
                    if (len == 0)
                        return context->destCount;

                    context->srcTmp |= ((uint)(*srcp++) << context->srcTmpCnt);
                    len--;
                    context->srcTmpCnt += 8;
                }
        
                // Decode the 32 bits that were loaded. After those 32 bits are processed, the next 4 bytes are read.
                while (context->srcTmpCnt > 0)
                {
                    select = context->srcTmp >> 31;
                    endFlag = ((uint)*context->treep << (int)select) & TREE_END_MASK;
                    context->treep = GetNextNode(context->treep, select);
                    context->srcTmp <<= 1;
                    context->srcTmpCnt--;
            
                    if (endFlag == 0)
                        continue;
            
                    // When the Huffman tree's terminal flag is set, data is stored at the end of the offset.

                    context->destTmp >>= context->bitSize;
                    context->destTmp |= (uint)*context->treep << (32 - context->bitSize);
                    context->treep = &context->tree[1];
                    context->destTmpCnt += context->bitSize;
            
                    if (context->destCount <= (context->destTmpCnt / 8))
                    {
                        context->destTmp >>= (32 - context->destTmpCnt);
                        context->destTmpCnt = 32;
                    }
            
                    // Write in 4-byte units
                    if (context->destTmpCnt == 32)
                    {
                        *(uint*)context->destp = CX.iConvertEndian(context->destTmp);
                        context->destp     += 4;
                        context->destCount -= 4;
                        context->destTmpCnt = 0;
                        if (context->destCount <= 0)
                            goto Out;
                    }
                }
            }
    
        Out:
            // Processing to perform in the event that context->destCount == 0
            if ((context->forceDestCount == 0) && (len > 32))
                return (int)CX.ERR.SRC_REMAINDER;
            
            return 0;
        }

        public static bool ENC_OFFSET_WIDTH = false;
        public static void CXInitUncompContextLH(CXUncompContextLH* context, VoidPtr dest)
        {
            context->destp       = (byte*)dest;
            context->destCount   = -1;
            context->nodep       = context->huffTable9  + 1;
            context->tableSize9  = -1;
            context->tableSize12 = -1;
            context->headerSize  = 8;
            context->length      = 0;
            context->stream      = 0;
            context->stream_len  = 0;
            context->offset_bits = -1;
            context->forceDestCount = 0;
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
            context->srcp = srcp;
            context->cnt = 0;
            context->stream = 0;
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
            byte stock = 0;

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

        public static int CXReadUncompLH(CXUncompContextLH* context, VoidPtr data, uint len)
        {
            byte LENGTH_BITS = 9;
            byte OFFSET_BITS;
            int OFFSET_MASK, LEAF_FLAG;
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

            byte* srcp = (byte*)data;
            BitReader stream;
            int val;
            ushort* nodep;
            ushort  length;
    
            stream.srcp       = srcp;
            stream.cnt        = len;
            stream.stream     = context->stream;
            stream.stream_len = context->stream_len;
    
            // Header parsing
            while (context->headerSize > 0)
            {
                long val32 = BitReader_ReadEx(&stream, 32);
                if (val32 < 0)
                    goto Out;
                
                context->headerSize -= 4;
                if (context->headerSize == 4)
                {
                    uint headerVal = CX.iConvertEndian((uint)val32);
                    if ((headerVal & (uint)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (uint)CX.CompressionType.CX_COMPRESSION_LH)
                        return (int)CX.ERR.UNSUPPORTED;
                    
                    context->destCount = (int)(headerVal >> 8);
            
                    if (context->destCount == 0)
                    {
                        context->headerSize = 4;
                        context->destCount  = -1;
                    }
                    else
                        context->headerSize = 0;
                }
                else // if (context->headerSize == 0)
                    context->destCount  = (int)CX.iConvertEndian((uint)val32);
                if (context->headerSize == 0)
                    if ((context->forceDestCount > 0) && (context->forceDestCount < context->destCount))
                        context->destCount = context->forceDestCount;
            }
    
            // load the Huffman table
            {
                if (context->tableSize9 < 0)
                {
                    if ((val = BitReader_Read(&stream, 16)) < 0)
                        goto Out;
                    context->tableSize9 = (CX.iConvertEndian16((ushort)val) + 1) * 4 * 8; // shown with the bit count
                    context->tableIdx   = 1;
                    context->tableSize9 -= 16;
                }
                while (context->tableSize9 >= LENGTH_BITS)
                {
                    if ((val = BitReader_Read(&stream, LENGTH_BITS)) < 0)
                        goto Out;
                    context->huffTable9[ context->tableIdx++ ] = (ushort)val;
                    context->tableSize9 -= LENGTH_BITS;
                }
                while (context->tableSize9 > 0)
                {
                    if ((val = BitReader_Read(&stream, (byte)context->tableSize9)) < 0)
                        goto Out;
                    context->tableSize9 = 0;
                }
                // verify the table
                if (!CXSecureDecompression.CXiLHVerifyTable(context->huffTable9, LENGTH_BITS))
                    return (int)CX.ERR.ILLEGAL_TABLE;
            }
            {
                if (context->tableSize12 < 0)
                {
                    if ((val = BitReader_Read(&stream, (byte)((OFFSET_BITS > 8) ? 16 : 8))) < 0)
                        goto Out;
                    if (OFFSET_BITS > 8)
                        context->tableSize12 = (CX.iConvertEndian16((ushort)val) + 1) * 4 * 8;
                    else // (OFFSET_BITS <= 8)
                        context->tableSize12 = ((ushort)val + 1) * 4 * 8;

                    context->tableIdx    = 1;
                    context->tableSize12 -= (OFFSET_BITS > 8)? 16 : 8;
                }
        
                while (context->tableSize12 >= OFFSET_BITS)
                {
                    if ((val = BitReader_Read(&stream, OFFSET_BITS)) < 0)
                        goto Out;
                    
                    context->huffTable12[ context->tableIdx++ ] = (ushort)val;
                    context->tableSize12 -= OFFSET_BITS;
                }
                while (context->tableSize12 > 0)
                {
                    if ((val = BitReader_Read(&stream, (byte)context->tableSize12)) < 0)
                        goto Out;

                    context->tableSize12 = 0;
                }
                // verify the table
                if (!CXSecureDecompression.CXiLHVerifyTable(context->huffTable12, OFFSET_BITS))
                    return (int)CX.ERR.ILLEGAL_TABLE;
            }
    
            nodep  = context->nodep;
            length = context->length;
    
            // Data conversion
            while (context->destCount > 0)
            {
                // get length data
                if (length == 0)
                {
                    do
                    {
                        byte  bit;
                        uint offset;
                        if ((val = BitReader_Read(&stream, 1)) < 0)
                        {
                            context->nodep  = nodep;
                            context->length = length;
                            goto Out;
                        }
                        bit = (byte)(val & 1);
                        offset = (uint)((((*nodep & 0x7F) + 1U) << 1) + bit);
                
                        if ((*nodep & (0x100 >> bit)) != 0)
                        {
                            nodep = (ushort*)((uint)nodep & ~0x3);
                            length = *(nodep + offset);
                            nodep = context->huffTable12 + 1;
                            break;
                        }
                        else
                        {
                            nodep = (ushort*)((uint)nodep & ~0x3);
                            nodep += offset;
                        }
                    } while (true);
                }
        
                if (length < 0x100) // uncompressed data
                {
                    *context->destp++ = (byte)length;
                    context->destCount--;
                    nodep = context->huffTable9 + 1;
                    length = 0;
                }
                else // compressed data
                {
                    ushort lzOffset = 0;
                    ushort lzLength = (ushort)((length & 0xFF) + 3);
            
               if (ENC_OFFSET_WIDTH)
                    if (context->offset_bits >= 0)
                        goto Skip;
                do
                {
                    byte bit;
                    uint offset;
                    
                    if ((val = BitReader_Read(&stream, 1)) < 0)
                    {
                        context->nodep  = nodep;
                        context->length = length;
                        goto Out;
                    }
                    bit = (byte)(val & 1);
                    offset = (uint)((((*nodep & OFFSET_MASK) + 1U) << 1) + bit);
                    
                    if ((*nodep & (LEAF_FLAG >> bit)) != 0)
                    {
                        nodep = (ushort*)((uint)nodep & ~0x3);
                        if (ENC_OFFSET_WIDTH)
                            context->offset_bits = (sbyte)(*(nodep + offset));
                        else
                            lzOffset = (ushort)(*(nodep + offset) + 1);
                        break;
                    }
                    else
                    {
                        nodep =  (ushort*)((uint)nodep & ~0x3);
                        nodep += offset;
                    }
                } while (true);
                Skip:
            
                if (ENC_OFFSET_WIDTH)
                {
                    if (context->offset_bits <= 1)
                    {
                        val = context->offset_bits;
                    }
                    else if ((val = BitReader_Read(&stream, (byte)(context->offset_bits - 1))) < 0)
                    {
                        context->nodep  = nodep;
                        context->length = length;
                        goto Out;
                    }
                    if (context->offset_bits >= 2)
                    {
                        val |= (1 << (context->offset_bits - 1));
                    }
            
                    context->offset_bits = -1;
                    lzOffset = (ushort)(val + 1);
                }
            
                    if (context->destCount < lzLength)
                    // A buffer overrun handler for when invalid data is decompressed.
                    {
                        if (context->forceDestCount == 0)
                        {
                            return (int)CX.ERR.DEST_OVERRUN;
                        }
                        lzLength = (ushort)context->destCount;
                    }
            
                    context->destCount -= lzLength;
                    while (lzLength-- != 0)
                    {
                        *context->destp = *(context->destp - lzOffset);
                        ++context->destp;
                    }
                    length = 0;
                    nodep  = context->huffTable9 + 1;
                }
            }
    
        Out:
            context->stream     = stream.stream;
            context->stream_len = stream.stream_len;
    
            // After decompression, remaining source data will be treated as an error
            if ((context->destCount == 0) &&  (context->forceDestCount == 0) && (len > 32)                    )
                return (int)CX.ERR.SRC_REMAINDER;
    
            return context->destCount;
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

        public static void LRCIntro_(
            CXUncompContextLRC       *context, 
            RCCompressionInfo        *info9, 
            RCCompressionInfo        *info12, 
            RCState                  *state)
        {
            info9->freq        = context->freq9;
            info9->low_cnt     = context->low_cnt9;
            info9->total       = context->total9;
            info9->bitSize     = 9;
    
            info12->freq       = context->freq12;
            info12->low_cnt    = context->low_cnt12;
            info12->total      = context->total12;
            info12->bitSize    = 12;
    
            state->low       = context->low;
            state->range     = context->range;
            state->code      = context->code;
            state->carry     = context->carry;
            state->carry_cnt = context->carry_cnt;
        }

        public static void LRCFin_(
            CXUncompContextLRC       *context, 
            RCCompressionInfo  *info9, 
            RCCompressionInfo  *info12, 
            RCState            *state)
        {
            context->total9  = info9->total;
            context->total12 = info12->total;
    
            context->low       = state->low;
            context->range     = state->range;
            context->code      = state->code;
            context->carry     = state->carry;
            context->carry_cnt = state->carry_cnt;
        }

        public static void RCInitState_(RCState* state)
        {
            state->low   = 0;
            state->range = RC_MAX_RANGE;
            state->code  = 0;
            state->carry = 0;
            state->carry_cnt = 0;
        }

        public static void RCInitInfo_(RCCompressionInfo* info, byte bitSize)
        {
            uint tableSize = (uint)(1 << bitSize);
            uint i;
    
            info->bitSize = bitSize;
    
            for (i = 0; i < tableSize; i++)
            {
                info->freq[ i ]    = 1;
                info->low_cnt[ i ] = i;
            }
            info->total = tableSize;
        }

        public static void RCAddCount_(RCCompressionInfo* info, ushort val)
        {
            uint i;
            uint tableSize = (uint)(1 << info->bitSize);
    
            info->freq[ val ]++;
            info->total++;
            for (i = (uint)(val + 1); i < tableSize; i++)
            {
                info->low_cnt[ i ]++;
            }
    
            // Reruct if the total exceeds the maximum value.
            if (info->total >= 0x00010000)
            {
                if (info->freq[ 0 ] > 1)
                {
                    info->freq[ 0 ] = info->freq[ 0 ] / 2;
                }
                info->low_cnt[ 0 ] = 0;
                info->total = info->freq[ 0 ];
        
                for (i = 1; i < tableSize; i++)
                {
                    if (info->freq[ i ] > 1)
                    {
                        info->freq[ i ] >>= 1;
                    }
                    info->low_cnt[ i ] = info->low_cnt[ i - 1 ] + info->freq[ i - 1 ];
                    info->total += info->freq[ i ];
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
        
                if (info->low_cnt[ i ] > tempVal)
                    right = i;
                else
                    left = i + 1;
            }
    
            i = left;
            while (info->low_cnt[ i ] > tempVal)
                --i;
            return (ushort)i;
        }

        public static ushort RCGetData_(byte* srcp, RCCompressionInfo* info, RCState* state, uint srcCnt, int* pReadCnt)
        {
            uint MIN_RANGE = 0x01000000;
            ushort val = RCSearch_(info, state->code, state->range, state->low);
            int cnt = 0;
            
            uint tmp;
            tmp          =  state->range / info->total;
            state->low   += info->low_cnt[ val ] * tmp;
            state->range =  info->freq[ val ] * tmp;
    
            // Update the table for occurrence frequency
            RCAddCount_(info, val);
    
            while (state->range < MIN_RANGE)
            {
                if (srcCnt == 0)
                    cnt = (cnt < 0)? (cnt - 1) : (-1);
                else
                {
                    state->code  <<= 8;
                    state->code  += srcp[ cnt++ ];
                    --srcCnt;
                }
                state->range <<= 8;
                state->low   <<= 8;
            }
            *pReadCnt = cnt;
    
            return val;
        }

        public static void CXInitUncompContextLRC(CXUncompContextLRC* context, VoidPtr dest)
        {
            byte LENGTH_BITS = 9;
            byte OFFSET_BITS = 12;
            RCCompressionInfo info9;
            RCCompressionInfo info12;
            RCState           rcState;
    
            // Set up processing
            LRCIntro_(context, &info9, &info12, &rcState);
    
            context->destp       = (byte*)dest;
            context->destCount   = 0;
            context->headerSize  = 8;
            context->length      = 0;
            context->forceDestCount = 0;
    
            context->codeLen = 4;
    
            RCInitInfo_(&info9, LENGTH_BITS);
            RCInitInfo_(&info12, OFFSET_BITS); 
    
            RCInitState_(&rcState);
    
            // Stop processing
            LRCFin_(context, &info9, &info12, &rcState);
        }

        public int CXReadUncompLRC(CXUncompContextLRC* context,  VoidPtr data, uint len)
        {
            RCCompressionInfo info9;
            RCCompressionInfo info12;
            RCState           rcState;
            byte*         srcp = (byte*)data;
    
            // Set up processing
            LRCIntro_(context, &info9, &info12, &rcState);
    
            // Header parsing
            if (context->headerSize > 0)
            {
                uint read_len;
                if (context->headerSize == 8)
                    if ((*srcp & (int)CX.CompressionType.CX_COMPRESSION_TYPE_MASK) != (int)CX.CompressionType.CX_COMPRESSION_LRC)
                        return (int)CX.ERR.UNSUPPORTED;
                    else if ((*srcp & 0x0F) != 0)
                        return (int)CX.ERR.UNSUPPORTED;
        
                read_len = CXiReadHeader(&context->headerSize, &context->destCount, srcp, len, context->forceDestCount);
                srcp += read_len;
                len  -= read_len;
                if (len == 0)
                    return (context->headerSize == 0)? context->destCount : -1;
            }
    
            // load the code
            while (context->codeLen > 0)
            {
                if (len == 0)
                    goto Out;
                
                rcState.code <<= 8;
                rcState.code += *srcp;
                ++srcp;
                --len;
                --context->codeLen;
            }
    
            while (context->destCount > 0)
            {
                // get the value for length
                if (context->length == 0)
                {
                    int cnt;
                    ushort val = RCGetData_(srcp, &info9, &rcState, len, &cnt);
            
                    if (val < 0x100)
                    // uncompressed data
                    {
                        *context->destp++  = (byte)val;
                        context->destCount--;
                    }
                    else
                    // compressed data
                    {
                        context->length = (ushort)((val & 0xFF) + 3);
                    }
            
                    // prepare to read the next data
                    if (cnt < 0)
                    {
                        context->codeLen = (byte)(-cnt);
                        goto Out;
                    }
                    srcp += cnt;
                    len  -= (uint)cnt; //cnt will be greater than 0 here
                }
        
                // Expanding compressed data
                if (context->length > 0)
                {
                    int cnt;
                    ushort val = (ushort)(RCGetData_(srcp, &info12, &rcState, len, &cnt) + 1);
            
                    // A buffer overrun handler for when invalid data is decompressed.
                    if (context->length > context->destCount)
                    {
                        if (context->forceDestCount == 0)
                            return (int)CX.ERR.DEST_OVERRUN;
                        
                        context->length = (ushort)(context->destCount);
                    }
            
                    while (context->length > 0)
                    {
                        *context->destp = context->destp[ -val ];
                        context->destp++;
                        context->destCount--;
                        context->length--;
                    }
                    // advance the load position
                    if (cnt < 0)
                    {
                        context->codeLen = (byte)(-cnt);
                        goto Out;
                    }
                    srcp += cnt;
                    len  -= (uint)cnt; //cnt will be greater than 0 here
                }
            }
        Out:
            // Stop processing
            LRCFin_(context, &info9, &info12, &rcState);
    
            // After decompression, remaining source data will be treated as an error
            if ((context->destCount == 0) && (context->forceDestCount == 0) && (len > 32))
                return (int)CX.ERR.SRC_REMAINDER;
    
            return context->destCount;
        }
    }
}
