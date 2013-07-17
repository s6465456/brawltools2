using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using BrawlLib.SSBBTypes;
using BrawlLib.SSBB.ResourceNodes;
using System.Collections.Generic;

namespace BrawlLib.Wii.Compression
{
    public unsafe class Differential
    {
        private Differential()
        {

        }

        public int Compress(VoidPtr srcAddr, int srcLen, Stream outStream, IProgressTracker progress, bool extFmt)
        {
            return 0;
        }
        
        public static int Compact(VoidPtr srcAddr, int srcLen, Stream outStream, ResourceNode r, bool extendedFormat)
        {
            using (ProgressWindow prog = new ProgressWindow(r.RootNode._mainForm, (extendedFormat ? "Extended " : "") + "LZ77", String.Format("Compressing {0}, please wait...", r.Name), false))
                return new Differential().Compress(srcAddr, srcLen, outStream, prog, extendedFormat);
        }
        public static void Expand(CompressionHeader* header, VoidPtr dstAddress, int dstLen)
        {
            byte* pSrc = (byte*)header->Data;
            byte* pDst = (byte*)dstAddress;
            uint bitSize = header->Parameter;
            uint sum = 0;
            int destCount = dstLen;

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
                } 
                while (destCount > 0);
            }
            else
            {
                // Difference calculation in units of 16 bits
                do
                {
                    ushort tmp = *(bushort*)pSrc;
                    pSrc += 2;
                    destCount -= 2;
                    sum += tmp;
                    *(bushort*)pDst = (ushort)sum;
                    pDst += 2;
                } 
                while (destCount > 0);
            }
        }
    }
}
