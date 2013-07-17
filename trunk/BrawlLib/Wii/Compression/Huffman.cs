using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using BrawlLib.SSBBTypes;
using BrawlLib.SSBB.ResourceNodes;
using System.Collections.Generic;

namespace BrawlLib.Wii.Compression
{
    public unsafe class Huffman
    {
        private Huffman()
        {

        }

        public int Compress(VoidPtr srcAddr, int srcLen, Stream outStream, IProgressTracker progress)
        {
            return 0;
        }
        
        public static int Compact(VoidPtr srcAddr, int srcLen, Stream outStream, ResourceNode r)
        {
            using (ProgressWindow prog = new ProgressWindow(r.RootNode._mainForm, "Huffman", String.Format("Compressing {0}, please wait...", r.Name), false))
                return new Huffman().Compress(srcAddr, srcLen, outStream, prog);
        }
        public static void Expand(CompressionHeader* header, VoidPtr dstAddress, int dstLen)
        {
            byte TREE_END = 0x80;
            buint* pSrc = (buint*)header->Data;
            buint* pDst = (buint*)dstAddress;
            int destCount = dstLen;
            byte* treep = (byte*)header->Data;
            byte* treeStartp = treep + 1;
            uint dataBit = header->Parameter;
            uint destTmp = 0;
            uint destTmpCount = 0;
            uint destTmpDataNum = 4 + (dataBit & 0x7);
            uint treeSize = (uint)((*treep + 1) << 1);

            if ((dataBit != 4) && (dataBit != 8))
                throw new InvalidCompressionException("Compression does not match Huffman format.");

            if (!CXiVerifyHuffmanTable_(treep, (byte)dataBit))
                throw new InvalidCompressionException("Invalid Huffman table.");

            pSrc = (buint*)(treep + treeSize);

            treep = treeStartp;

            while (destCount > 0)
            {
                int srcTmpCount = 32;
                uint srcTmp = *pSrc++;

                while (--srcTmpCount >= 0)
                {
                    uint treeShift = (srcTmp >> 31) & 0x1;
                    uint treeCheck = *treep;
                    treeCheck <<= (int)treeShift;
                    treep = (byte*)((((uint)treep >> 1) << 1) + (((*treep & 0x3f) + 1) << 1) + treeShift);
                    if ((treeCheck & TREE_END) != 0)
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
                            *pDst++ = destTmp;
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

        public static bool CXiVerifyHuffmanTable_(VoidPtr pTable, byte bit)
        {
            uint FLAGS_ARRAY_NUM = 512 / 8; /* 64 byte */
            byte* treep = (byte*)pTable;
            byte* treeStartp = treep + 1;
            uint treeSize = *treep;
            byte* treeEndp = (byte*)pTable + (treeSize + 1) * 2;
            uint i;
            byte[] end_flags = new byte[FLAGS_ARRAY_NUM];
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
                    uint offset = (uint)(((*treep & 0x3F) + 1) << 1);
                    byte* nodep = (byte*)((((uint)treep >> 1) << 1) + offset);

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
    }
}
