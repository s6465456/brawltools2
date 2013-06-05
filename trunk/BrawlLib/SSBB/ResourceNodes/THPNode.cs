using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class THPNode : ResourceNode, IImageSource, IDisposable
    {
        internal THPFile* Header { get { return (THPFile*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        THPHeader hdr;
        THPFrameCompInfo cmp;
        THPAudioInfo audio;
        THPVideoInfo video;

        [Category("THP Video Data")]
        public uint Width { get { return video._xSize; } }
        [Category("THP Video Data")]
        public uint Height { get { return video._ySize; } }
        [Category("THP Video Data")]
        public uint Type { get { return video._videoType; } }

        [Category("THP Audio Data")]
        public uint Channels { get { return audio._sndChannels; } }
        [Category("THP Audio Data")]
        public uint Frequency { get { return audio._sndFrequency; } }
        [Category("THP Audio Data")]
        public uint NumSamples { get { return audio._sndNumSamples; } }
        [Category("THP Audio Data")]
        public uint NumTracks { get { return audio._sndNumTracks; } }
        
        [Category("THP Header Data")]
        public float FrameRate { get { return hdr._frameRate; } }
        [Category("THP Header Data")]
        public uint NumFrames { get { return hdr._numFrames; } }

        public THPFrame[] _frames;

        public List<byte> _componentTypes;

        public override bool OnInitialize()
        {
            if ((_name == null) && (_origPath != null))
                _name = Path.GetFileNameWithoutExtension(_origPath);
            
            base.OnInitialize();

            hdr = Header->_header;
            cmp = Header->_frameCompInfo;
            audio = Header->_audioInfo;
            video = Header->_videoInfo;

            _componentTypes = new List<byte>();

            for (int i = 0; i < Header->_frameCompInfo._numComponents; i++)
                _componentTypes.Add(Header->_frameCompInfo._frameComp[i]);

            uint size = Header->_header._firstFrameSize;
            VoidPtr addr = Header->_header.FirstFrame;
            _frames = new THPFrame[NumFrames];
            for (int i = 0; i < NumFrames; i++)
            {
                _frames[i] = new THPFrame(addr, size, this);
                addr += size;
                size = _frames[i].Header->_frameSizeNext;
            }

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            return base.OnCalculateSize(force);
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);
        }

        internal static ResourceNode TryParse(DataSource source) { return ((THPHeader*)source.Address)->_tag == THPHeader.Tag ? new THPNode() : null; }

        [Browsable(false)]
        public int ImageCount
        {
            get { return _frames.Length; }
        }

        public Bitmap GetImage(int index)
        {
            return _frames[index.Clamp(0, ImageCount - 1)].GetImage();
        }
    }

    public enum JpegMarkers : ushort
    {
        // Start of Frame markers, non-differential, Huffman coding
        HuffBaselineDCT = 0xFFC0,
        HuffExtSequentialDCT = 0xFFC1,
        HuffProgressiveDCT = 0xFFC2,
        HuffLosslessSeq = 0xFFC3,

        // Start of Frame markers, differential, Huffman coding
        HuffDiffSequentialDCT = 0xFFC5,
        HuffDiffProgressiveDCT = 0xFFC6,
        HuffDiffLosslessSeq = 0xFFC7,

        // Start of Frame markers, non-differential, arithmetic coding
        ArthBaselineDCT = 0xFFC8,
        ArthExtSequentialDCT = 0xFFC9,
        ArthProgressiveDCT = 0xFFCA,
        ArthLosslessSeq = 0xFFCB,

        // Start of Frame markers, differential, arithmetic coding
        ArthDiffSequentialDCT = 0xFFCD,
        ArthDiffProgressiveDCT = 0xFFCE,
        ArthDiffLosslessSeq = 0xFFCF,

        // Huffman table spec
        HuffmanTableDef = 0xFFC4,

        // Arithmetic table spec
        ArithmeticTableDef = 0xFFCC,

        // Restart Interval termination
        RestartIntervalStart = 0xFFD0,
        RestartIntervalEnd = 0xFFD7,

        // Other markers
        StartOfImage = 0xFFD8,
        EndOfImage = 0xFFD9,
        StartOfScan = 0xFFDA,
        QuantTableDef = 0xFFDB,
        NumberOfLinesDef = 0xFFDC,
        RestartIntervalDef = 0xFFDD,
        HierarchProgressionDef = 0xFFDE,
        ExpandRefComponents = 0xFFDF,

        // App segments
        App0 = 0xFFE0,
        App1 = 0xFFE1,
        App2 = 0xFFE2,
        App3 = 0xFFE3,
        App4 = 0xFFE4,
        App5 = 0xFFE5,
        App6 = 0xFFE6,
        App7 = 0xFFE7,
        App8 = 0xFFE8,
        App9 = 0xFFE9,
        App10 = 0xFFEA,
        App11 = 0xFFEB,
        App12 = 0xFFEC,
        App13 = 0xFFED,
        App14 = 0xFFEE,
        App15 = 0xFFEF,

        // Jpeg Extensions
        JpegExt0 = 0xFFF0,
        JpegExt1 = 0xFFF1,
        JpegExt2 = 0xFFF2,
        JpegExt3 = 0xFFF3,
        JpegExt4 = 0xFFF4,
        JpegExt5 = 0xFFF5,
        JpegExt6 = 0xFFF6,
        JpegExt7 = 0xFFF7,
        JpegExt8 = 0xFFF8,
        JpegExt9 = 0xFFF9,
        JpegExtA = 0xFFFA,
        JpegExtB = 0xFFFB,
        JpegExtC = 0xFFFC,
        JpegExtD = 0xFFFD,

        // Comments
        Comment = 0xFFFE,

        // Reserved
        ArithTemp = 0xFF01,
        ReservedStart = 0xFF02,
        ReservedEnd = 0xFFBF
    }

    public unsafe class THPFrame
    {
        THPNode _node;

        public Bitmap GetImage()
        {
            //We have to convert the raw buffer to a usable image every time the image is called.
            //Dispose of image when done displaying. This way we won't run out of memory.
            //Doesn't seem to slow down frame rate or anything.

            byte[] buffer = new byte[Header->_videoSize];
            Marshal.Copy(_source.Address + 8 + _node._componentTypes.Count * 4, buffer, 0, buffer.Length);

            bool begun = false;
            List<byte> temp = buffer.ToList();

            int end = 0;
            for (int i = temp.Count - 2; i >= 0; i--)
            {
                byte b1 = temp[i];
                byte b2 = temp[i + 1];
                ushort code = (ushort)((b1 << 8) | b2);

                if (Enum.IsDefined(typeof(JpegMarkers), code))
                {
                    JpegMarkers m = (JpegMarkers)code;
                    if (m == JpegMarkers.EndOfImage)
                    {
                        end = i;
                        break;
                    }
                }
            }

            for (int i = 0; i < temp.Count; i++)
            {
                byte b1 = temp[i];
                if (b1 == 0xFF)
                {
                    byte b2 = temp[i + 1];
                    ushort code = (ushort)((b1 << 8) | b2);

                    if (Enum.IsDefined(typeof(JpegMarkers), code))
                    {
                        JpegMarkers m = (JpegMarkers)code;
                        if (m == JpegMarkers.EndOfImage && i == end)
                            break;
                        else
                        {
                            if (begun)
                            {
                                temp.Insert(i + 1, 0);
                                i++;
                            }
                        }
                        if (m == JpegMarkers.StartOfScan)
                            begun = true;
                    }
                    else
                    {
                        if (begun)
                        {
                            temp.Insert(i + 1, 0);
                            i++;
                        }
                    }
                }
            }
            buffer = temp.ToArray();

            return (Bitmap)new ImageConverter().ConvertFrom(buffer);
        }

        DataSource _source;
        public THPFrameHeader* Header { get { return (THPFrameHeader*)_source.Address; } }

        public THPFrame(VoidPtr addr, uint size, THPNode node)
        {
            _source = new DataSource(addr, (int)size);
            _node = node;
        }
    }
}