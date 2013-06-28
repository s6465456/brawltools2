using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BrawlLib.Wii.Compression
{
    public unsafe class CX
    {
        public enum ERR
        {
            SUCCESS = 0,
            UNSUPPORTED = -1,
            SRC_SHORTAGE = -2,
            SRC_REMAINDER = -3,
            DEST_OVERRUN = -4,
            ILLEGAL_TABLE = -5
        }

        public enum CompressionType
        {
            CX_COMPRESSION_LZ           = 0x10,     // LZ77
            CX_COMPRESSION_HUFFMAN      = 0x20,     // Huffman
            CX_COMPRESSION_RL           = 0x30,     // Run Length
            CX_COMPRESSION_LH           = 0x40,     // LH(LZ77+Huffman)
            CX_COMPRESSION_LRC          = 0x50,     // LRC(LZ77+RangeCoder)
            CX_COMPRESSION_DIFF         = 0x80,     // Differential filter

            CX_COMPRESSION_TYPE_MASK    = 0xF0,
            CX_COMPRESSION_TYPE_EX_MASK = 0xFF
        }

        public struct CXCompressionHeader
        {
            public byte compType;   // Compression type
            public byte compParam;  // Compression parameter
            public byte pad1;
            public byte pad2;
            public uint destSize;   // Expanded size
        }

        public static CX.CompressionType GetCompressionType(void *data)
        {
            return (CX.CompressionType)(*(byte*)data & 0xF0);
        }

        public static int CX_UNCOMPRESS_LH_WORK_SIZE = ((1 << 11) + (1 << 7));
        public static int CX_UNCOMPRESS_LRC_WORK_SIZE = (((1 << 12) + (1 << 9)) * 8);

        public static bool CX_PLATFORM_IS_BIGENDIAN = true;
        public static uint iConvertEndian(uint x)
        {
            if (CX_PLATFORM_IS_BIGENDIAN)
                return x.Reverse();
            else
                return x;
        }

        public static ushort iConvertEndian16(ushort x)
        {
            if (CX_PLATFORM_IS_BIGENDIAN)
                return x.Reverse();
            else
                return x;
        }
    }

    public static unsafe class CXCompression
    {
        //===========================================================================
        //  LZ Encoding
        //===========================================================================

        // Temporary information for LZ high-speed encoding
        public struct LZCompressInfo
        {
            public ushort windowPos;                 // Top position of the history window
            public ushort windowLen;                 // Length of the history window
    
            public short* LZOffsetTable;             // Offset buffer of the history window
            public short* LZByteTable;               // Pointer to the most recent character history
            public short* LZEndTable;                // Pointer to the oldest character history
        }

        /*---------------------------------------------------------------------------*
          Name:         CXCompressLZ

          Description:  Function that performs LZ77 compression

          Arguments:    srcp:            Pointer to compression source data
                        size:            Size of compression source data
                        dstp:            Pointer to destination for compressed data
                                         The buffer must be larger than the size of the compression source data.
                        work:            Temporary buffer for compression
                                         Requires a region of at least size CX_LZ_FAST_COMPRESS_WORK_SIZE.

          Returns:      The data size after compression.
                        If compressed data is larger than original data, compression is terminated and 0 is returned.
         *---------------------------------------------------------------------------*/
        public static uint CXCompressLZImpl(byte *srcp, uint size, byte *dstp, void *work, bool exFormat)
        {
            uint LZDstCount;     // Number of bytes of compressed data
            byte LZCompFlags;    // Flag series indicating whether there is compression
            byte *LZCompFlagsp;  // Points to memory region storing LZCompFlags
            ushort lastOffset;   // Offset to matching data (the longest matching data at the time) 
            uint lastLength;     // Length of matching data (the longest matching data at the time)
            byte i;
            uint dstMax;
            LZCompressInfo info; // Temporary LZ compression information
            uint MAX_LENGTH = exFormat ? (0xFFFF + 0xFF + 0xF + 3U) : (0xF + 3U);

            //ASSERT(((uint)srcp & 0x1) == 0);
            //ASSERT(work != NULL);
            //ASSERT(size > 4);
    
            if (size < (1 << 24))
            {
                *(uint*)dstp = CX.iConvertEndian((uint)(size << 8 | (uint)CX.CompressionType.CX_COMPRESSION_LZ | (uint)(exFormat? 1 : 0)));  // Data header
                dstp += 4;
                LZDstCount = 4;
            }
            else // Use extended header if the size is larger than 24 bits
            {
                *(uint*)dstp = CX.iConvertEndian((uint)CX.CompressionType.CX_COMPRESSION_LZ | (exFormat? 1U : 0U));  // Data header
                dstp += 4;
                *(uint*)dstp = CX.iConvertEndian(size); // Size extended header
                dstp += 4;
                LZDstCount = 8;
            }
            dstMax = size;
            LZInitTable(&info, work);
    
            while (size > 0)
            {
                LZCompFlags = 0;
                LZCompFlagsp = dstp++;         // Destination for storing flag series
                LZDstCount++;

                // Since flag series is stored as 8-bit data, loop eight times
                for (i = 0; i < 8; i++)
                {
                    LZCompFlags <<= 1;         // The first time (i=0) has no real meaning
                    if (size <= 0)
                    {
                        // When the end terminator is reached, quit after shifting flag through to the last
                        continue;
                    }

                    if ((lastLength = SearchLZ(&info, srcp, size, &lastOffset, MAX_LENGTH)) != 0)
                    {
                        uint length;
                        // Enable flag if compression is possible
                        LZCompFlags |= 0x1;

                        if (LZDstCount + 2 >= dstMax)   // Quit on error if size becomes larger than source
                            return 0;
                
                        if (exFormat)
                        {
                            if (lastLength >= 0xFF + 0xF + 3)
                            {
                                length  = (uint)(lastLength - 0xFF - 0xF - 3);
                                *dstp++ = (byte)(0x10 | (length >> 12));
                                *dstp++ = (byte)(length >> 4);
                                LZDstCount += 2;
                            }
                            else if (lastLength >= 0xF + 2)
                            {
                                length  = (uint)(lastLength - 0xF - 2);
                                *dstp++ = (byte)(length >> 4);
                                LZDstCount += 1;
                            }
                            else
                                length = (uint)(lastLength - 1);
                        }
                        else
                            length = (uint)(lastLength - 3);
                
                        // Divide offset into upper 4 bits and lower 8 bits and store
                        *dstp++ = (byte)(length << 4 | (lastOffset - 1U) >> 8);
                        *dstp++ = (byte)((lastOffset - 1) & 0xff);
                        LZDstCount += 2;
                        LZSlide(&info, srcp, lastLength);
                        srcp += lastLength;
                        size -= lastLength;
                    }
                    else
                    {
                        // No compression
                        if (LZDstCount + 1 >= dstMax)       // Quit on error if size becomes larger than source
                        {
                            return 0;
                        }
                        LZSlide(&info, srcp, 1);
                        *dstp++ = *srcp++;
                        size--;
                        LZDstCount++;
                    }
                }                              // Completed eight loops
                *LZCompFlagsp = LZCompFlags;   // Store flag series
            }
    
            // 4-byte boundary alignment
            //   Data size does not include Data0, used for alignment
            i = 0;
            while (((LZDstCount + i) & 0x3) != 0)
            {
                *dstp++ = 0;
                i++;
            }
    
            return LZDstCount;
        }

        //--------------------------------------------------------
        // With LZ77 compression, searches for the longest matching string in the slide window.
        //  Arguments:    startp:              Pointer to starting position of data
        //                nextp:               Pointer to data where search will start
        //                remainSize:          Size of remaining data
        //                offset:              Pointer to region storing matched offset
        //  Return   :    TRUE if matching string is found
        //                FALSE if not found
        //--------------------------------------------------------
        public static uint SearchLZ(LZCompressInfo * info, byte *nextp, uint remainSize, ushort *offset, uint maxLength)
        {
            byte* searchp, headp, searchHeadp;
            ushort maxOffset = 0;
            uint currLength = 2;
            uint tmpLength;
            int w_offset;
            short* LZOffsetTable = info->LZOffsetTable;
            ushort windowPos = info->windowPos;
            ushort windowLen = info->windowLen;

            if (remainSize < 3)
                return 0;

            w_offset = info->LZByteTable[*nextp];

            while (w_offset != -1)
            {
                if (w_offset < windowPos)
                    searchp = nextp - windowPos + w_offset;
                else
                    searchp = nextp - windowLen - windowPos + w_offset;

                /* This isn't needed, but it seems to make it a little faster */
                if (*(searchp + 1) != *(nextp + 1) || *(searchp + 2) != *(nextp + 2))
                {
                    w_offset = LZOffsetTable[w_offset];
                    continue;
                }

                if (nextp - searchp < 2)
                    // VRAM is accessed in 2-byte units (since data is sometimes read from VRAM), so the data to search must start 2 bytes prior to the start location actually desired.
                    // 
                    // 
                    // Since the offset is stored in 12 bits, the value is 4096 or less
                    break;
                tmpLength = 3;
                searchHeadp = searchp + 3;
                headp = nextp + 3;

                // Increments the compression size until a data terminator or different data is encountered.
                while (((uint)(headp - nextp) < remainSize) && (*headp == *searchHeadp))
                {
                    headp++;
                    searchHeadp++;
                    tmpLength++;

                    // Since the data length is stored in 4 bits, the value is 18 or less (3 is added)
                    if (tmpLength == maxLength)
                        break;
                }

                if (tmpLength > currLength)
                {
                    // Update the maximum-length offset
                    currLength = tmpLength;
                    maxOffset = (ushort)(nextp - searchp);
                    if (currLength == maxLength || currLength == remainSize)
                        // This is the longest matching length, so end search.
                        break;
                }
                w_offset = LZOffsetTable[w_offset];
            }

            if (currLength < 3)
                return 0;

            *offset = maxOffset;
            return currLength;
        }

        //--------------------------------------------------------
        // Initialize the dictionary index
        //--------------------------------------------------------
        static void LZInitTable(LZCompressInfo * info, void *work)
        {
            ushort i;
    
            info->LZOffsetTable = (short*)work;
            info->LZByteTable   = (short*)((uint)work + 4096 * sizeof(short));
            info->LZEndTable    = (short*)((uint)work + (4096 + 256) * sizeof(short));
    
            for (i = 0; i < 256; i++)
            {
                info->LZByteTable[i] = -1;
                info->LZEndTable [i] = -1;
            }
            info->windowPos = 0;
            info->windowLen = 0;
        }

        //--------------------------------------------------------
        // Slide the dictionary 1 byte
        //--------------------------------------------------------
        static void SlideByte(LZCompressInfo * info, byte *srcp)
        {
            short     offset;
            byte      in_data = *srcp;
            ushort     insert_offset;

            short    * LZByteTable   = info->LZByteTable;
            short    * LZOffsetTable = info->LZOffsetTable;
            short    * LZEndTable    = info->LZEndTable;
             ushort windowPos = info->windowPos;
             ushort windowLen = info->windowLen;

            if (windowLen == 4096)
            {
                byte out_data = *(srcp - 4096);
                if ((LZByteTable[out_data] = LZOffsetTable[LZByteTable[out_data]]) == -1)
                    LZEndTable[out_data] = -1;
                
                insert_offset = windowPos;
            }
            else
                insert_offset = windowLen;

            offset = LZEndTable[in_data];
            if (offset == -1)
                LZByteTable[in_data] = (short)insert_offset;
            else
                LZOffsetTable[offset] = (short)insert_offset;

            LZEndTable[in_data] = (short)insert_offset;
            LZOffsetTable[insert_offset] = -1;

            if (windowLen == 4096)
                info->windowPos = (ushort)((windowPos + 1) % 0x1000);
            else
                info->windowLen++;
        }

        public static void LZSlide(LZCompressInfo * info, byte *srcp, uint n)
        {
            for (uint i = 0; i < n; i++) SlideByte(info, srcp++);
        }

        public static uint CXCompressRL(byte *srcp, uint size, byte *dstp)
        {
            uint RLDstCount;     // Number of bytes of compressed data
            uint RLSrcCount;     // Processed data volume of the compression target data (in bytes)
            byte  RLCompFlag;    // 1 if performing run-length encoding
            byte  runLength;     // Run length
            byte  rawDataLength; // Length of non-run data
            uint i;

            byte *startp; // Point to the start of compression target data for each process loop
    
            //ASSERT(srcp != NULL);
            //ASSERT(dstp != NULL);
            //ASSERT(size > 4    );
    
            //  Data header (For the size after decompression)
            // To create the same output data as Nitro, work on on the endian.
            if (size < (1 << 24))
            {
                *(uint*)dstp = CX.iConvertEndian(size << 8 | (uint)CX.CompressionType.CX_COMPRESSION_RL); // Data header
                RLDstCount   = 4;
            }
            else // Use extended header if the size is larger than 24 bits
            {
                *(uint*)dstp       = CX.iConvertEndian((uint)CX.CompressionType.CX_COMPRESSION_RL);       // Data header
                *(uint*)(dstp + 4) = CX.iConvertEndian(size);                  // Extend header size
                RLDstCount         = 8;
            }
            RLSrcCount = 0;
            rawDataLength = 0;
            RLCompFlag = 0;

            while (RLSrcCount < size)
            {
                startp = &srcp[RLSrcCount];    // Set compression target data

                for (i = 0; i < 128; i++)      // Data volume that can be expressed in 7 bits is 0 to 127
                {
                    // Reach the end of the compression target data
                    if (RLSrcCount + rawDataLength >= size)
                    {
                        rawDataLength = (byte)(size - RLSrcCount);
                        break;
                    }

                    if (RLSrcCount + rawDataLength + 2 < size)
                    {
                        if (startp[i] == startp[i + 1] && startp[i] == startp[i + 2])
                        {
                            RLCompFlag = 1;
                            break;
                        }
                    }
                    rawDataLength++;
                }

                // Store data that will not be encoded
                // If the 8th bit of the data length storage byte is 0, this is a data sequence that is not encoded.
                // The data length is x - 1, so 0-127 becomes 1-128.
                if (rawDataLength != 0)
                {
                    if (RLDstCount + rawDataLength + 1 >= size) // Quit on error if size becomes larger than source
                        return 0;
                    
                    dstp[RLDstCount++] = (byte)(rawDataLength - 1); // Store "data length - 1" (7 bits)
                    for (i = 0; i < rawDataLength; i++)
                        dstp[RLDstCount++] = srcp[RLSrcCount++];
                    
                    rawDataLength = 0;
                }

                // Run-Length Encoding
                if (RLCompFlag != 0)
                {
                    runLength = 3;
                    for (i = 3; i < 128 + 2; i++)
                    {
                        // Reach the end of the data for compression
                        if (RLSrcCount + runLength >= size)
                        {
                            runLength = (byte)(size - RLSrcCount);
                            break;
                        }

                        // If run was interrupted
                        if (srcp[RLSrcCount] != srcp[RLSrcCount + runLength])
                            break;
                        
                        // Run continues
                        runLength++;
                    }

                    // If the 8th bit of the data length storage byte is 1, this is an encoded data sequence
                    if (RLDstCount + 2 >= size) // Quit on error if size becomes larger than source
                        return 0;
                    
                    dstp[RLDstCount++] = (byte)(0x80 | (runLength - 3));  // Add 3, and store from 3 to 130
                    dstp[RLDstCount++] = srcp[RLSrcCount];
                    RLSrcCount += runLength;
                    RLCompFlag = 0;
                }
            }

            // 4-byte boundary alignment
            //   Data size does not include Data0, used for alignment
            i = 0;
            while (((RLDstCount + i) & 0x3) != 0)
            {
                dstp[RLDstCount + i] = 0;
                i++;
            }
            return RLDstCount;
        }

        public static int HUFF_END_L = 0x80;
        public static int HUFF_END_R = 0x40;

        public struct HuffData // Total of 24 bytes
        {
            public uint Freq;           // Frequency of occurrence
            public ushort No;            // Data number
            public short PaNo;           // Parent number 
            public fixed short ChNo[2];  // Child Number (0: left side, 1: right side)
            public ushort PaDepth;       // Parent node depth
            public ushort LeafDepth;     // Depth to leaf
            public uint HuffCode;        // Huffman code
            public byte Bit;             // Node's bit data
            public byte _padding;
            public ushort HWord;         // For each intermediate node, the amount of memory needed to store in HuffTree the subtree that has that node as its root
        }

        public struct HuffTreeCtrlData // Total of 6 bytes
        {
            public byte leftOffsetNeed;  // 1 if offset to left child node is required
            public byte rightOffsetNeed; // 1 if an offset to the right child node is required
            public ushort leftNodeNo;    // The left child node's number
            public ushort rightNodeNo;   // Right child node's number
        }

        // Structure of the Huffman work buffer
        public struct HuffCompressionInfo // Total is 14340B
        {
            public HuffData* huffTable;              //  huffTable[512]; 12288B
            public byte* huffTree;                   //  huffTree[256 * 2]; 512B
            public HuffTreeCtrlData* huffTreeCtrl;   //  huffTreeCtrl[256]; 1536B
            public byte huffTreeTop;
            public fixed byte padding_[3];
        }

        //public static void HuffInitTable(HuffCompressionInfo* info, VoidPtr work, ushort dataNum);
        //public static void HuffCountData(HuffData* table, byte* srcp, uint size, byte bitSize);
        //public static ushort HuffConstructTree(HuffData* table, uint dataNum);
        //public static uint HuffConvertData(HuffData* table, byte* srcp, byte* dstp, uint srcSize, uint maxSize, byte bitSize);

        //public static void HuffAddParentDepthToTable(HuffData* table, ushort leftNo, ushort rightNo);
        //public static void HuffAddCodeToTable(HuffData* table, ushort nodeNo, uint paHuffCode);
        //public static byte HuffAddCountHWordToTable(HuffData* table, ushort nodeNo);

        //public static void HuffMakeHuffTree(HuffCompressionInfo* info, ushort rootNo);
        //public static void HuffMakeSubsetHuffTree(HuffCompressionInfo* info, ushort huffTreeNo, byte rightNodeFlag);
        //public static byte HuffRemainingNodeCanSetOffset(HuffCompressionInfo* info, byte costHWord);
        //public static void HuffSetOneNodeOffset(HuffCompressionInfo* info, ushort huffTreeNo, byte rightNodeFlag);

        public static uint CXCompressHuffman( byte *srcp, uint size, byte *dstp, byte huffBitSize, void *work)
        {
            uint huffDstCount;                  // Number of bytes of compressed data
            int i;
            ushort rootNo;                        // Binary tree's root number
            ushort huffDataNum  = (ushort)(1 << huffBitSize);      // 8->256, 4->16
            uint tableOffset;
            HuffCompressionInfo info;
    
            //ASSERT(srcp != NULL);
            //ASSERT(dstp != NULL);
            //ASSERT(huffBitSize == 4 || huffBitSize == 8);
            //ASSERT(work != NULL);
            //ASSERT(((uint)work & 0x3) == 0);
            //ASSERT(size > 4);
    
            // Initialize table
            HuffInitTable(&info, work, huffDataNum);
    
            // Check frequency of occurrence
            HuffCountData(info.huffTable, srcp, size, huffBitSize);
    
            // Create tree table
            rootNo = HuffConstructTree(info.huffTable, huffDataNum);
    
            // Create HuffTree
            HuffMakeHuffTree(&info, rootNo);
            info.huffTree[0] = --info.huffTreeTop;
    
            // Data header
            // To create the same compression data as Nitro, work on the endian.
            if (size < (1 << 24))
            {
                *(uint *)dstp = CX.iConvertEndian(size << 8 | (uint)CX.CompressionType.CX_COMPRESSION_HUFFMAN | huffBitSize);
                tableOffset  = 4;
            }
            else // Use extended header if the size is larger than 24 bits
            {
                *(uint *)dstp       = CX.iConvertEndian((uint)((uint)CX.CompressionType.CX_COMPRESSION_HUFFMAN | huffBitSize));
                *(uint *)(dstp + 4) = CX.iConvertEndian(size);
                tableOffset        = 8;
            }
            huffDstCount = tableOffset;
    
            if (huffDstCount + (info.huffTreeTop + 1) * 2 >= size)   // Quit on error if size becomes larger than source
            {
                return 0;
            }
    
            for (i = 0; i < (ushort)((info.huffTreeTop + 1) * 2); i++)  // Tree table
            {
                dstp[huffDstCount++] = ((byte*)info.huffTree)[i];
            }
    
            // 4-byte boundary alignment
            //   Data0 used for alignment is included in data size (as per the decoder algorithm)
            while ((huffDstCount & 0x3) != 0)
            {
                if ((huffDstCount & 0x1) != 0)
                {
                    info.huffTreeTop++;
                    dstp[tableOffset]++;
                }
                dstp[huffDstCount++] = 0;
            }
    
            // Data conversion via the Huffman table
            {
                uint convSize = HuffConvertData(info.huffTable, srcp, &dstp[huffDstCount], size, size - huffDstCount, huffBitSize);
                if (convSize == 0)
                {
                    // Compression fails because the compressed data is larger than the source
                    return 0;
                }
                huffDstCount += convSize;
            }
    
            return huffDstCount;
        }


        /*---------------------------------------------------------------------------*
          Name:         HuffInitTable
          Description:  Initializes the Huffman table.
          Arguments:    table   
                        size    
          Returns:      None.
         *---------------------------------------------------------------------------*/
        static void HuffInitTable(HuffCompressionInfo* info, VoidPtr work, ushort dataNum)
        {
            uint i;
            info->huffTable    = (HuffData*)(work);
            info->huffTree     = (byte*)((uint)work + sizeof(HuffData) * 512);
            info->huffTreeCtrl = (HuffTreeCtrlData*)((uint)info->huffTree + sizeof(byte) * 512);
            info->huffTreeTop  = 1;
    
            // Initialize huffTable
            {
                HuffData* table = info->huffTable;
                HuffData HUFF_TABLE_INIT_DATA = new HuffData();
                HUFF_TABLE_INIT_DATA.ChNo[0] = -1;
                HUFF_TABLE_INIT_DATA.ChNo[1] = -1;
                for (i = 0; i < dataNum * 2U; i++)
                {
                    table[i]    = HUFF_TABLE_INIT_DATA;
                    table[i].No = (ushort)i;
                }
            }
    
            // Initialize huffTree and huffTreeCtrl
            {
                HuffTreeCtrlData HUFF_TREE_CTRL_INIT_DATA = new HuffTreeCtrlData() { leftOffsetNeed = 1, rightOffsetNeed = 1 };
                
                byte* huffTree  = info->huffTree;
                HuffTreeCtrlData* huffTreeCtrl = info->huffTreeCtrl;
        
                for (i = 0; i < 256; i++)
                {
                    huffTree[i * 2]     = 0;
                    huffTree[i * 2 + 1] = 0;
                    huffTreeCtrl[i]     = HUFF_TREE_CTRL_INIT_DATA;
                }
            }
        }

        /*---------------------------------------------------------------------------*
          Name:         HuffCountData
          Description:  Count of frequency of appearance.
          Arguments:    table   
                        *srcp   
                        size    
                        bitSize 
          Returns:      None.
         *---------------------------------------------------------------------------*/
        static void HuffCountData(HuffData* table,  byte *srcp, uint size, byte bitSize)
        {
            uint i;
            byte  tmp;
    
            if (bitSize == 8)
                for (i = 0; i < size; i++)
                    table[srcp[i]].Freq++; // 8-bit encoding
            else
            {
                for (i = 0; i < size; i++)   // 4-bit encoding
                {
                    tmp = (byte)((srcp[i] & 0xf0) >> 4);
                    table[tmp].Freq++;       // Store from upper 4 bits first // Either is OK
                    tmp = (byte)(srcp[i] & 0x0f);
                    table[tmp].Freq++;       // The problem is the encoding
                }
            }
        }


        /*---------------------------------------------------------------------------*
          Name:         HuffConstructTree
          Description:  Constructs a Huffman tree
          Arguments:    *table  
                        dataNum 
          Returns:      None.
         *---------------------------------------------------------------------------*/
        static ushort HuffConstructTree(HuffData *table, uint dataNum)
        {
            int i;
            int leftNo, rightNo;         // Node's numbers at time of binary tree's creation
            ushort     tableTop = (ushort)dataNum; // The table top number at time of table's creation
            ushort     rootNo;                  // Binary tree's root number
            ushort     nodeNum;                 // Number of valid nodes
    
            leftNo  = -1;
            rightNo = -1;
            while (true)
            {
                // Search for two subtree vertices with low Freq value. At least one should be found.
                // Search child vertices (left)
                for (i = 0; i < tableTop; i++)
                {
                    if ((table[i].Freq == 0) || (table[i].PaNo != 0))
                        continue;
            
                    if (leftNo < 0)
                        leftNo = i;
                    else if (table[i].Freq < table[leftNo].Freq)
                        leftNo = i;
                }
        
                // Search child vertices (right)
                for (i = 0; i < tableTop; i++)
                {
                    if ((table[i].Freq == 0) || (table[i].PaNo != 0) || (i == leftNo))
                        continue;

                    if (rightNo < 0)
                        rightNo = i;
                    else if (table[i].Freq < table[rightNo].Freq)
                        rightNo = i;
                }
        
                // If only one, then end table creation
                if (rightNo < 0)
                {
                    // When only one type of value exists, then create one node that gives the same value for both 0 and 1.
                    if (tableTop == dataNum)
                    {
                        table[tableTop].Freq      = table[leftNo].Freq;
                        table[tableTop].ChNo[0]   = (short)leftNo;
                        table[tableTop].ChNo[1]   = (short)leftNo;
                        table[tableTop].LeafDepth = 1;
                        table[leftNo  ].PaNo      = (short)tableTop;
                        table[leftNo  ].Bit       = 0;
                        table[leftNo  ].PaDepth   = 1;
                    }
                    else
                        tableTop--;
                    
                    rootNo  = tableTop;
                    nodeNum = (ushort)((rootNo - dataNum + 1) * 2 + 1);
                    break;
                }
        
                // Create vertex that combines left subtree and right subtree
                table[tableTop].Freq = table[leftNo].Freq + table[rightNo].Freq;
                table[tableTop].ChNo[0] = (short)leftNo;
                table[tableTop].ChNo[1] = (short)rightNo;
                if (table[leftNo].LeafDepth > table[rightNo].LeafDepth)
                    table[tableTop].LeafDepth = (ushort)(table[leftNo].LeafDepth + 1);
                else
                    table[tableTop].LeafDepth = (ushort)(table[rightNo].LeafDepth + 1);
        
                table[leftNo ].PaNo = table[rightNo].PaNo = (short)(tableTop);
                table[leftNo ].Bit  = 0;
                table[rightNo].Bit  = 1;
        
                HuffAddParentDepthToTable(table, (ushort)leftNo, (ushort)rightNo);
        
                tableTop++;
                leftNo = rightNo = -1;
            }
    
            // Generate Huffman code (In table[i].HuffCode)
            HuffAddCodeToTable(table, rootNo, 0x00);        // The Huffman code is the code with HuffCode's lower bits masked for PaDepth bits
    
            // For each intermediate node, calculate the amount of memory needed to store as a huffTree the subtree that has that node as the root.
            HuffAddCountHWordToTable(table, rootNo);
    
            return rootNo;
        }

        //-----------------------------------------------------------------------
        // When creating binary tree and when combining subtrees, add 1 to the depth of every node in the subtree.
        //-----------------------------------------------------------------------
        static void HuffAddParentDepthToTable(HuffData *table, ushort leftNo, ushort rightNo)
        {
            table[leftNo ].PaDepth++;
            table[rightNo].PaDepth++;
    
            if (table[leftNo].LeafDepth != 0)
                HuffAddParentDepthToTable(table, (ushort)table[leftNo ].ChNo[0], (ushort)table[leftNo ].ChNo[1]);
            if (table[rightNo].LeafDepth != 0)
                HuffAddParentDepthToTable(table, (ushort)table[rightNo].ChNo[0], (ushort)table[rightNo].ChNo[1]);
        }

        //-----------------------------------------------------------------------
        // Create Huffman code
        //-----------------------------------------------------------------------
        static void HuffAddCodeToTable(HuffData* table, ushort nodeNo, uint paHuffCode)
        {
            table[nodeNo].HuffCode = (paHuffCode << 1) | table[nodeNo].Bit;
    
            if (table[nodeNo].LeafDepth != 0)
            {
                HuffAddCodeToTable(table, (ushort)table[nodeNo].ChNo[0], table[nodeNo].HuffCode);
                HuffAddCodeToTable(table, (ushort)table[nodeNo].ChNo[1], table[nodeNo].HuffCode);
            }
        }

        //-----------------------------------------------------------------------
        // Data volume required by intermediate nodes to create huffTree
        //-----------------------------------------------------------------------
        static byte HuffAddCountHWordToTable(HuffData *table, ushort nodeNo)
        {
            byte leftHWord, rightHWord;
    
            switch (table[nodeNo].LeafDepth)
            {
                case 0:
                    return 0;
                case 1:
                    leftHWord = rightHWord = 0;
                    break;
                default:
                    leftHWord  = HuffAddCountHWordToTable(table, (ushort)table[nodeNo].ChNo[0]);
                    rightHWord = HuffAddCountHWordToTable(table, (ushort)table[nodeNo].ChNo[1]);
                    break;
            }
    
            table[nodeNo].HWord = (ushort)(leftHWord + rightHWord + 1);
            return (byte)(leftHWord + rightHWord + 1);
        }


        //-----------------------------------------------------------------------
        // Create Huffman code table
        //-----------------------------------------------------------------------
        static void HuffMakeHuffTree(HuffCompressionInfo* info, ushort rootNo)
        {
            short i;
            short costHWord, tmpCostHWord;       // Make subtree code table for most-costly node when subtree code table has not been created.
            short costOffsetNeed, tmpCostOffsetNeed;
            short costMaxKey, costMaxRightFlag = 0;  // Information for singling out the least costly node from HuffTree
            byte offsetNeedNum;
            byte tmpKey, tmpRightFlag;
    
            info->huffTreeTop = 1;
            costOffsetNeed    = 0;
    
            info->huffTreeCtrl[0].leftOffsetNeed = 0; // Do not use (used as table size)
            info->huffTreeCtrl[0].rightNodeNo    = rootNo;
    
            while (true) 
            {
                // Calculate the number of nodes whose offset needs setting
                offsetNeedNum = 0;
                for (i = 0; i < info->huffTreeTop; i++)
                {
                    if (info->huffTreeCtrl[i].leftOffsetNeed != 0)
                        offsetNeedNum++;
                    if (info->huffTreeCtrl[i].rightOffsetNeed != 0)
                        offsetNeedNum++;
                }

                // Search for node with greatest cost
                costHWord    = -1;
                costMaxKey   = -1;
                tmpKey       =  0;
                tmpRightFlag =  0;

                for (i = 0; i < info->huffTreeTop; i++)
                {
                    tmpCostOffsetNeed = (byte)(info->huffTreeTop - i);
            
                    // Evaluate cost of left child node
                    if (info->huffTreeCtrl[i].leftOffsetNeed != 0)
                    {
                        tmpCostHWord = (short)info->huffTable[info->huffTreeCtrl[i].leftNodeNo].HWord;
                
                        if ((tmpCostHWord + offsetNeedNum) > 64)
                        {
                            goto leftCostEvaluationEnd;
                        }
                        if ( HuffRemainingNodeCanSetOffset(info, (byte)tmpCostHWord) == 0)
                        {
                            goto leftCostEvaluationEnd;
                        }
                        if (tmpCostHWord > costHWord)
                        {
                            costMaxKey = i;
                            costMaxRightFlag = 0;
                        }
                        else if ((tmpCostHWord == costHWord) && (tmpCostOffsetNeed > costOffsetNeed))
                        {
                            costMaxKey = i;
                            costMaxRightFlag = 0;
                        }
                    }
        leftCostEvaluationEnd: { }
            
                    // Evaluate cost of right child node
                    if (info->huffTreeCtrl[i].rightOffsetNeed != 0)
                    {
                        tmpCostHWord = (short)info->huffTable[info->huffTreeCtrl[i].rightNodeNo].HWord;
                
                        if ((tmpCostHWord + offsetNeedNum) > 64)
                        {
                            goto rightCostEvaluationEnd;
                        }
                        if (HuffRemainingNodeCanSetOffset(info, (byte)tmpCostHWord) != 0)
                        {
                            goto rightCostEvaluationEnd;
                        }
                        if (tmpCostHWord > costHWord)
                        {
                            costMaxKey = i;
                            costMaxRightFlag = 1;
                        }
                        else if ((tmpCostHWord == costHWord) && (tmpCostOffsetNeed > costOffsetNeed))
                        {
                            costMaxKey = i;
                            costMaxRightFlag = 1;
                        }
                    }
        rightCostEvaluationEnd: { }
                }

                // Store entire subtree in huffTree
                if (costMaxKey >= 0)
                {
                    HuffMakeSubsetHuffTree(info, (byte)costMaxKey, (byte)costMaxRightFlag);
                    goto nextTreeMaking;
                }
                else
                {
                    // Search for node with largest required offset
                    for (i = 0; i < info->huffTreeTop; i++)
                    {
                        ushort tmp = 0;
                        tmpRightFlag = 0;
                        if (info->huffTreeCtrl[i].leftOffsetNeed != 0)
                        {
                            tmp = info->huffTable[info->huffTreeCtrl[i].leftNodeNo].HWord;
                        }
                        if (info->huffTreeCtrl[i].rightOffsetNeed != 0)
                        {
                            if (info->huffTable[info->huffTreeCtrl[i].rightNodeNo].HWord > tmp)
                            {
                                tmpRightFlag = 1;
                            }
                        }
                        if ((tmp != 0) || (tmpRightFlag != 0))
                        {
                            HuffSetOneNodeOffset(info, (byte)i, tmpRightFlag);
                            goto nextTreeMaking;
                        }
                    }
                }
                return;
        nextTreeMaking: { }
            }
        }

        //-----------------------------------------------------------------------
        // Store entire subtree in huffTree
        //-----------------------------------------------------------------------
        static void HuffMakeSubsetHuffTree(HuffCompressionInfo* info, ushort huffTreeNo, byte rightNodeFlag)
        {
            byte  i;
    
            i = info->huffTreeTop;
            HuffSetOneNodeOffset(info, huffTreeNo, rightNodeFlag);
    
            if (rightNodeFlag != 0)
                info->huffTreeCtrl[huffTreeNo].rightOffsetNeed = 0;
            else
                info->huffTreeCtrl[huffTreeNo].leftOffsetNeed = 0;
    
            while (i < info->huffTreeTop)
            {
                if (info->huffTreeCtrl[i].leftOffsetNeed != 0)
                {
                    HuffSetOneNodeOffset(info, i, 0);
                    info->huffTreeCtrl[i].leftOffsetNeed = 0;
                }
                if (info->huffTreeCtrl[i].rightOffsetNeed != 0)
                {
                    HuffSetOneNodeOffset(info, i, 1);
                    info->huffTreeCtrl[i].rightOffsetNeed = 0;
                }
                i++;
            }
        }

        //-----------------------------------------------------------------------
        // Check if there is any problems with huffTree ruction if subtree of obtained data size is decompressed.
        //-----------------------------------------------------------------------
        static byte HuffRemainingNodeCanSetOffset(HuffCompressionInfo* info, byte costHWord)
        {
            byte  i;
            short capacity;
    
            capacity = (short)(64 - costHWord);
    
            // The offset value is larger for smaller values of i, so you should calculate without sorting, with i=0 -> huffTreeTop
            for (i = 0; i < info->huffTreeTop; i++)
            {
                if (info->huffTreeCtrl[i].leftOffsetNeed != 0)
                    if ((info->huffTreeTop - i) <= capacity)
                        capacity--;
                    else
                        return 0;
                if (info->huffTreeCtrl[i].rightOffsetNeed != 0)
                    if ((info->huffTreeTop - i) <= capacity)
                        capacity--;
                    else
                        return 0;
            }
    
            return 1;
        }

        /*---------------------------------------------------------------------------*
          Name:         HuffSetOneNodeOffset
          Description:  Create Huffman code table for one node
          Arguments:    *info :          Pointer to data for ructing a Huffman tree
                        huffTreeNo      
                        rightNodeFlag :  Flag for whether node is at right
          Returns:      None.
         *---------------------------------------------------------------------------*/
        static void HuffSetOneNodeOffset(HuffCompressionInfo* info, ushort huffTreeNo, byte rightNodeFlag)
        {
            ushort nodeNo;
            byte  offsetData = 0;
    
            HuffData*         huffTable    = info->huffTable;
            byte*               huffTree     = info->huffTree;
            HuffTreeCtrlData* huffTreeCtrl = info->huffTreeCtrl;
            byte                huffTreeTop  = info->huffTreeTop;
    
            if (rightNodeFlag != 0)
            {
                nodeNo = huffTreeCtrl[huffTreeNo].rightNodeNo;
                huffTreeCtrl[huffTreeNo].rightOffsetNeed = 0;
            }
            else
            {
                nodeNo = huffTreeCtrl[huffTreeNo].leftNodeNo;
                huffTreeCtrl [huffTreeNo].leftOffsetNeed = 0;
            }
    
            // Left child node
            if (huffTable[huffTable[nodeNo].ChNo[0]].LeafDepth == 0)
            {
                offsetData |= 0x80;
                huffTree[huffTreeTop * 2 + 0] = (byte)huffTable[nodeNo].ChNo[0];
                huffTreeCtrl[huffTreeTop].leftNodeNo = (byte)huffTable[nodeNo].ChNo[0];
                huffTreeCtrl[huffTreeTop].leftOffsetNeed = 0;   // Offset no longer required
            }
            else
            {
                huffTreeCtrl[huffTreeTop].leftNodeNo = (ushort)huffTable[nodeNo].ChNo[0];  // Offset is required
            }
    
            // Right child node
            if (huffTable[huffTable[nodeNo].ChNo[1]].LeafDepth == 0)
            {
                offsetData |= 0x40;
                huffTree[huffTreeTop * 2 + 1] = (byte)huffTable[nodeNo].ChNo[1];
                huffTreeCtrl[huffTreeTop].rightNodeNo = (byte)huffTable[nodeNo].ChNo[1];
                huffTreeCtrl[huffTreeTop].rightOffsetNeed = 0;  // Offset no longer required
            }
            else
            {
                huffTreeCtrl[huffTreeTop].rightNodeNo = (ushort)huffTable[nodeNo].ChNo[1]; // Offset is required
            }
    
            offsetData |= (byte)(huffTreeTop - huffTreeNo - 1);
            huffTree[huffTreeNo * 2 + rightNodeFlag] = offsetData;
    
            info->huffTreeTop++;
        }


        /*---------------------------------------------------------------------------*
          Name:         HuffConvertData
          Description:  Data conversion based on Huffman table.
          Arguments:    *table  
                        srcp    
                        dstp    
                        srcSize 
                        bitSize 
          Returns:      None.
         *---------------------------------------------------------------------------*/
        static uint HuffConvertData( HuffData *table,  byte* srcp, byte* dstp, uint srcSize, uint maxSize, byte bitSize)
        {
            uint     i, ii, iii;
            byte      srcTmp;
            uint     bitStream    = 0;
            uint     streamLength = 0;
            uint     dstSize      = 0;
    
            // Huffman encoding
            for (i = 0; i < srcSize; i++)
            {                                  // Data compression
                byte val = srcp[i];
                if (bitSize == 8)
                {                              // 8-bit Huffman
                    bitStream = (bitStream << table[val].PaDepth) | table[val].HuffCode;
                    streamLength += table[val].PaDepth;
            
                    if (dstSize + (streamLength / 8) >= maxSize)
                        // Error if size becomes larger than source
                        return 0;
            
                    for (ii = 0; ii < streamLength / 8; ii++)
                        dstp[dstSize++] = (byte)(bitStream >> (int)(streamLength - (ii + 1) * 8));
                    streamLength %= 8;
                }
                else                           // 4-bit Huffman
                {
                    for (ii = 0; ii < 2; ii++)
                    {
                        if (ii != 0)
                            srcTmp = (byte)(val >> 4);     // First four bits come later
                        else
                            srcTmp = (byte)(val & 0x0F);   // Last four bits come first (because the decoder accesses in a Little-Endian method)
                        bitStream = (bitStream << table[srcTmp].PaDepth) | table[srcTmp].HuffCode;
                        streamLength += table[srcTmp].PaDepth;
                        if (dstSize + (streamLength / 8) >= maxSize)
                            // Error if size becomes larger than source
                            return 0;
                        for (iii = 0; iii < streamLength / 8; iii++)
                            dstp[dstSize++] = (byte)(bitStream >> (int)(streamLength - (iii + 1) * 8));
                        streamLength %= 8;
                    }
                }
            }
    
            if (streamLength != 0)
            {
                if (dstSize + 1 >= maxSize)
                    // Error if size becomes larger than source
                    return 0;
                dstp[dstSize++] = (byte)(bitStream << (int)(8 - streamLength));
            }
    
            // 4-byte boundary alignment
            //   Data0 for alignment is included in data size 
            //   This is special to Huffman encoding! Data subsequent to the alignment-boundary data is stored because little-endian conversion is used.
            while ((dstSize & 0x3) != 0)
                dstp[dstSize++] = 0;
    
            // Little endian conversion
            for (i = 0; i < dstSize / 4; i++)
            {
                byte tmp;
                tmp = dstp[i * 4 + 0];
                dstp[i * 4 + 0] = dstp[i * 4 + 3];
                dstp[i * 4 + 3] = tmp;         // Swap
                tmp = dstp[i * 4 + 1];
                dstp[i * 4 + 1] = dstp[i * 4 + 2];
                dstp[i * 4 + 2] = tmp;         // Swap
            }
            return dstSize;
        }
    }
}