using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using BrawlLib.SSBBTypes;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Compression;
using BrawlLib.IO;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.Wii.Compression
{
    public unsafe class RunLength : IDisposable
    {
        private RunLength()
        {

        }

        ~RunLength() { Dispose(); }
        public void Dispose()
        {
            //if (_dataAddr) { Marshal.FreeHGlobal(_dataAddr); _dataAddr = 0; }
            //GC.SuppressFinalize(this);
        }

        public static int CompactYAZ0(VoidPtr srcAddr, int srcLen, Stream outStream, string name)
        {
            Yaz0Stream s = new Yaz0Stream(outStream, CompressionMode.Compress);
            s.Write2(srcAddr, srcLen);
            s.Flush();
            return (int)s.BaseStream.Length;
        }

        public static void Expand(CompressionHeader* header, VoidPtr dstAddress, int dstLen)
        {
            if ((header->Algorithm != CompressionType.RunLength)/* || (header->Parameter != 0)*/)
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
                if ((control & 0x80) != 0)
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

    //From here down is from CTools. Sorta messy, but works so whatevs
    public class Yaz0Stream : Stream
    {
        private static int LookBackCache = 63;
        private static int lookBack { get { return LookBackCache; } }

        private const int threadChunk = 0x10000;
        private MemoryStream dataBuffer;
        //private EndianBinaryReader reader;
        private EndianBinaryWriter writer;
        private int codeBits, toCopy, copyPosition, _position;
        private byte codeByte;
        private byte[] writeBuffer;
        private List<Contraction>[] contractions;

        public CompressionMode Mode { get; private set; }

        public Stream BaseStream { get; private set; }

        public override bool CanRead { get { return Mode == CompressionMode.Decompress; } }

        public override bool CanSeek { get { return BaseStream.CanSeek && CanRead; } }

        public override bool CanTimeout { get { return BaseStream.CanTimeout; } }

        public override bool CanWrite { get { return Mode == CompressionMode.Compress; } }

        public bool HasHeader { get; private set; }

        public int DecompressedSize { get; private set; }

        public override long Length
        {
            get { return DecompressedSize; }
        }

        public override long Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (!CanSeek) throw new InvalidOperationException();

                throw new NotImplementedException();
            }
        }

        public override int ReadTimeout
        {
            get
            {
                return BaseStream.ReadTimeout;
            }
            set
            {
                BaseStream.ReadTimeout = value;
            }
        }

        public override int WriteTimeout
        {
            get
            {
                return BaseStream.WriteTimeout;
            }
            set
            {
                BaseStream.WriteTimeout = value;
            }
        }

        public Yaz0Stream(Stream baseStream, CompressionMode mode)
        {
            Mode = mode;
            BaseStream = baseStream;

            //if ((mode == CompressionMode.Compress && !baseStream.CanWrite) || (mode == CompressionMode.Decompress && !baseStream.CanRead)) throw new ArgumentException("baseStream");

            //if (mode == CompressionMode.Decompress)
            //    reader = new EndianBinaryReader(baseStream);
            //else
            {
                writer = new EndianBinaryWriter(baseStream);
                dataBuffer = new MemoryStream();
            }

            DecompressedSize = -1;
        }

        //public bool ReadHeader()
        //{
        //    string tag;

        //    if (!CanRead || HasHeader) throw new InvalidOperationException();

        //    tag = reader.ReadString(Encoding.ASCII, 4);

        //    if (tag != "Yaz0") return false;

        //    DecompressedSize = reader.ReadInt32s(3)[0];
        //    dataBuffer = new MemoryStream(DecompressedSize);

        //    HasHeader = true;

        //    return true;
        //}

        public override void Flush()
        {
            if (CanWrite)
                WriteFlush();
            BaseStream.Flush();
        }

        private void WriteFlush()
        {
            int chunkCount;
            ParallelLoopResult result;

            //if (HasHeader) throw new InvalidOperationException();

            chunkCount = (int)Math.Ceiling((double)dataBuffer.Length / threadChunk);
            contractions = new List<Contraction>[chunkCount];
            writeBuffer = dataBuffer.ToArray();

            WriteHeader(writeBuffer.Length);

            result = Parallel.For(0, chunkCount, FindContractions);

            while (!result.IsCompleted)
                Thread.Sleep(100);

            Compile();
        }

        private void Compile()
        {
            List<Contraction> fullContractions;
            int codeBits, tempLoc, current;
            byte codeByte;
            byte[] temp;

            fullContractions = new List<Contraction>();

            for (int i = 0; i < contractions.Length; i++)
            {
                fullContractions.AddRange(contractions[i]);
                contractions[i].Clear();
                contractions[i] = null;
            }

            contractions = null;
            temp = new byte[3 * 8];
            codeBits = 0;
            codeByte = 0;
            tempLoc = 0;
            current = 0;

            for (int i = 0; i < writeBuffer.Length; )
            {
                if (codeBits == 8)
                {
                    BaseStream.WriteByte(codeByte);
                    BaseStream.Write(temp, 0, tempLoc);
                    codeBits = 0;
                    codeByte = 0;
                    tempLoc = 0;
                }

                if (current < fullContractions.Count && fullContractions[current].Location == i)
                {
                    if (fullContractions[current].Size >= 0x12)
                    {
                        temp[tempLoc++] = (byte)(fullContractions[current].Offset >> 8);
                        temp[tempLoc++] = (byte)(fullContractions[current].Offset & 0xFF);
                        temp[tempLoc++] = (byte)(fullContractions[current].Size - 0x12);
                    }
                    else
                    {
                        temp[tempLoc++] = (byte)((fullContractions[current].Offset >> 8) | ((fullContractions[current].Size - 2) << 4));
                        temp[tempLoc++] = (byte)(fullContractions[current].Offset & 0xFF);
                    }

                    i += fullContractions[current++].Size;

                    while (current < fullContractions.Count && fullContractions[current].Location < i)
                        current++;
                }
                else
                {
                    codeByte |= (byte)(1 << (7 - codeBits));
                    temp[tempLoc++] = writeBuffer[i++];
                }

                codeBits++;
            }

            BaseStream.WriteByte(codeByte);
            BaseStream.Write(temp, 0, tempLoc);
        }

        private void WriteHeader(int size)
        {
            //if (!CanWrite || HasHeader) throw new InvalidOperationException();

            writer.Write("Yaz0", Encoding.ASCII, false);
            writer.Write(DecompressedSize = size);
            writer.Write(0);
            writer.Write(0);

            toCopy = 1;

            HasHeader = true;
        }

        private void FindContractions(int chunk)
        {
            int from, to, run, bestRun, bestOffset;
            Contraction contraction;

            contractions[chunk] = new List<Contraction>();

            from = chunk * threadChunk;
            to = Math.Min(from + threadChunk, writeBuffer.Length);

            for (int i = from; i < to; )
            {
                bestRun = 0;
                bestOffset = 0;

                for (int j = i - 1; j > 0 && j >= i - lookBack; j--)
                {
                    run = 0;

                    while (i + run < writeBuffer.Length && run < 0x111 && writeBuffer[j + run] == writeBuffer[i + run])
                        run++;

                    if (run > bestRun)
                    {
                        bestRun = run;
                        bestOffset = i - j - 1;

                        if (run == 0x111) break;
                    }
                }

                if (bestRun >= 3)
                {
                    contraction = new Contraction(i, bestRun, bestOffset);
                    contractions[chunk].Add(contraction);
                    i += bestRun;
                }
                else
                    i++;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            byte current, code1, code2, code3;

            //if (!CanRead || !HasHeader) throw new InvalidOperationException();

            count = (int)Math.Min(count, Length - Position);

            if (count == 0) return count;

            for (int read = 0; read < count; read++)
            {
                if (toCopy > 0)
                {
                    dataBuffer.Seek(copyPosition, SeekOrigin.Begin);
                    current = (byte)dataBuffer.ReadByte();
                    dataBuffer.Seek(_position, SeekOrigin.Begin);
                    dataBuffer.WriteByte(current);
                    buffer[offset] = current;

                    toCopy--;
                    offset++;
                    _position++;
                    copyPosition++;
                }
                else
                {
                    if (codeBits == 0)
                    {
                        codeByte = (byte)BaseStream.ReadByte();
                        codeBits = 8;
                    }

                    if ((codeByte & 0x80) == 0)
                    {
                        code1 = (byte)BaseStream.ReadByte();
                        code2 = (byte)BaseStream.ReadByte();

                        copyPosition = _position - (((code1 & 0xf) << 8 | code2) + 1);

                        if ((code1 & 0xF0) == 0)
                        {
                            code3 = (byte)BaseStream.ReadByte();

                            toCopy = code3 + 0x12;
                        }
                        else
                        {
                            toCopy = (code1 >> 4) + 2;
                        }

                        read--;
                    }
                    else
                    {
                        current = (byte)BaseStream.ReadByte();
                        dataBuffer.WriteByte(current);
                        buffer[offset] = current;

                        offset++; _position++;
                    }

                    codeByte <<= 1;
                    codeBits--;
                }
            }

            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
                case SeekOrigin.End:
                    Position = Length + offset;
                    break;
            }

            return Position;
        }

        public override void SetLength(long value)
        {
            throw new InvalidOperationException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            //if (!CanWrite || HasHeader) throw new InvalidOperationException();

            if (count == 0) return;

            dataBuffer.Write(buffer, offset, count);
            _position += count;
        }

        public void Write2(VoidPtr addr, int len)
        {
            //if (!CanWrite || HasHeader) throw new InvalidOperationException();

            //if (count == 0) return;

            dataBuffer.Write(addr, len);
            _position += len;
        }

        private struct Contraction
        {
            public int Location;
            public int Size;
            public int Offset;

            public Contraction(int loc, int sz, int off)
            {
                Location = loc;
                Size = sz;
                Offset = off;
            }
        }
    }
    public sealed class EndianBinaryWriter : IDisposable
    {
        private bool disposed;
        private byte[] buffer;

        public Stream BaseStream { get; private set; }
        //public Endian Endian { get; set; }
        //public Endian SystemEndian { get { return BitConverter.IsLittle ? Endian.Little : Endian.Big; } }

        //private bool Reverse { get { return SystemEndian != Endian; } }

        public EndianBinaryWriter(Stream baseStream)
            : this(baseStream, Endian.Big)
        { }

        public EndianBinaryWriter(Stream baseStream, Endian Endian)
        {
            if (baseStream == null) throw new ArgumentNullException("baseStream");
            if (!baseStream.CanWrite) throw new ArgumentException("baseStream");

            BaseStream = baseStream;
            //Endian = Endian;
        }

        ~EndianBinaryWriter()
        {
            Dispose(false);
        }

        private void WriteBuffer(int bytes, int stride)
        {
            //if (Reverse)
                for (int i = 0; i < bytes; i += stride)
                {
                    Array.Reverse(buffer, i, stride);
                }

            BaseStream.Write(buffer, 0, bytes);
        }

        private void CreateBuffer(int size)
        {
            if (buffer == null || buffer.Length < size)
                buffer = new byte[size];
        }

        public void Write(byte value)
        {
            CreateBuffer(1);
            buffer[0] = value;
            WriteBuffer(1, 1);
        }

        public void Write(byte[] value, int offset, int count)
        {
            CreateBuffer(count);
            Array.Copy(value, offset, buffer, 0, count);
            WriteBuffer(count, 1);
        }

        public void Write(sbyte value)
        {
            CreateBuffer(1);
            unchecked
            {
                buffer[0] = (byte)value;
            }
            WriteBuffer(1, 1);
        }

        public void Write(sbyte[] value, int offset, int count)
        {
            CreateBuffer(count);

            unchecked
            {
                for (int i = 0; i < count; i++)
                {
                    buffer[i] = (byte)value[i + offset];
                }
            }

            WriteBuffer(count, 1);
        }

        public void Write(char value, Encoding encoding)
        {
            int size;

            size = GetEncodingSize(encoding);
            CreateBuffer(size);
            Array.Copy(encoding.GetBytes(new string(value, 1)), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(char[] value, int offset, int count, Encoding encoding)
        {
            int size;

            size = GetEncodingSize(encoding);
            CreateBuffer(size * count);
            Array.Copy(encoding.GetBytes(value, offset, count), 0, buffer, 0, count * size);
            WriteBuffer(size * count, size);
        }

        private static int GetEncodingSize(Encoding encoding)
        {
            if (encoding == Encoding.UTF8 || encoding == Encoding.ASCII)
                return 1;
            else if (encoding == Encoding.Unicode || encoding == Encoding.BigEndianUnicode)
                return 2;

            return 1;
        }

        public void Write(string value, Encoding encoding, bool nullTerminated)
        {
            Write(value.ToCharArray(), 0, value.Length, encoding);
            if (nullTerminated)
                Write('\0', encoding);
        }

        public void Write(double value)
        {
            const int size = sizeof(double);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(double[] value, int offset, int count)
        {
            const int size = sizeof(double);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(Single value)
        {
            const int size = sizeof(Single);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(Single[] value, int offset, int count)
        {
            const int size = sizeof(Single);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(Int32 value)
        {
            const int size = sizeof(Int32);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(Int32[] value, int offset, int count)
        {
            const int size = sizeof(Int32);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(Int64 value)
        {
            const int size = sizeof(Int64);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(Int64[] value, int offset, int count)
        {
            const int size = sizeof(Int64);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(Int16 value)
        {
            const int size = sizeof(Int16);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(Int16[] value, int offset, int count)
        {
            const int size = sizeof(Int16);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(UInt16 value)
        {
            const int size = sizeof(UInt16);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(UInt16[] value, int offset, int count)
        {
            const int size = sizeof(UInt16);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(UInt32 value)
        {
            const int size = sizeof(UInt32);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(UInt32[] value, int offset, int count)
        {
            const int size = sizeof(UInt32);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void Write(UInt64 value)
        {
            const int size = sizeof(UInt64);

            CreateBuffer(size);
            Array.Copy(BitConverter.GetBytes(value), 0, buffer, 0, size);
            WriteBuffer(size, size);
        }

        public void Write(UInt64[] value, int offset, int count)
        {
            const int size = sizeof(UInt64);

            CreateBuffer(size * count);
            for (int i = 0; i < count; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i + offset]), 0, buffer, i * size, size);
            }

            WriteBuffer(size * count, size);
        }

        public void WritePadding(int multiple, byte padding)
        {
            int length = (int)(BaseStream.Position % multiple);

            if (length != 0)
                while (length != multiple)
                {
                    BaseStream.WriteByte(padding);
                    length++;
                }
        }

        public void WritePadding(int multiple, byte padding, long from, int offset)
        {
            int length = (int)((BaseStream.Position - from) % multiple);
            length = (length + offset) % multiple;

            if (length != 0)
                while (length != multiple)
                {
                    BaseStream.WriteByte(padding);
                    length++;
                }
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (BaseStream != null)
                    {
                        BaseStream.Close();
                    }
                }

                buffer = null;

                disposed = true;
            }
        }
    }
}
