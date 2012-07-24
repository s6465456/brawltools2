using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Animations;

namespace BrawlLib.SSBBTypes
{
    [StructLayout( LayoutKind.Sequential, Pack=1)]
    unsafe struct SRT0v4
    {
        public const uint Tag = 0x30545253;
        public const int Size = 0x28;

        public BRESCommonHeader _header;
        public bint _dataOffset;
        public bint _stringOffset;
        public bint _origPathOffset;
        public bushort _numFrames;
        public bushort _numEntries;
        public bint _matrixMode;
        public bint _loop;
        
        public SRT0v4(ushort frames, int loop, ushort entries, int matrixMode)
        {
            _header._tag = Tag;
            _header._size = Size;
            _header._version = 4;
            _header._bresOffset = 0;

            _dataOffset = 0x28;
            _origPathOffset = 0;
            _matrixMode = matrixMode;
            _numFrames = frames;
            _loop = loop;
            _stringOffset = 0;
            _numEntries = entries;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceGroup* Group { get { return (ResourceGroup*)(Address + _dataOffset); } }

        public string ResourceString { get { return new String((sbyte*)ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct SRT0v5
    {
        public const uint Tag = 0x30545253;
        public const int Size = 0x2C;

        public BRESCommonHeader _header;
        public bint _dataOffset;
        public bint _part2Offset;
        public bint _stringOffset;
        public bint _origPathOffset;
        public bushort _numFrames;
        public bushort _numEntries;
        public bint _matrixMode;
        public bint _loop;

        public SRT0v5(ushort frames, int loop, ushort entries, int matrixMode)
        {
            _header._tag = Tag;
            _header._size = Size;
            _header._version = 5;
            _header._bresOffset = 0;

            _dataOffset = 0x2C;
            _part2Offset = _origPathOffset = 0;
            _matrixMode = matrixMode;
            _numFrames = frames;
            _loop = loop;
            _stringOffset = 0;
            _numEntries = entries;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceGroup* Group { get { return (ResourceGroup*)(Address + _dataOffset); } }

        public string ResourceString { get { return new String((sbyte*)ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct SRT0Entry
    {
        public bint _stringOffset;
        public bint _textureIndices; //Sets which of the 8 texure references to animate with bits
        public bint _indirectIndices;

        //Entry offsets here for each texture

        public SRT0Entry(int textureIndices, int unk1)
        {
            _textureIndices = textureIndices;
            _indirectIndices = unk1;
            _stringOffset = 0;
        }

        public int DataSize()
        {
            int size = 12, index = 0;
            for (int i = 0; i < 8; i++)
                if (((_textureIndices >> i) & 1) != 0)
                    size += 4 + GetEntry(index++)->Code.DataSize();
            return size;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public SRT0TextureEntry* GetEntry(int index) { return (SRT0TextureEntry*)(Address + GetOffset(index)); }
        public void SetEntry(int index, SRT0TextureEntry value) { *(SRT0TextureEntry*)(Address + GetOffset(index)) = value; } 
        
        public int GetOffset(int index) { return *(bint*)(Address + 12 + index * 4); }
        public void SetOffset(int index, int value) { *(bint*)(Address + 12 + index * 4) = value; }

        public string ResourceString { get { return new String((sbyte*)ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }

    [Flags]
    public enum TextureIndices
    {
        Texture0 = 0x01,
        Texture1 = 0x02,
        Texture2 = 0x04,
        Texture3 = 0x08,
        Texture4 = 0x10,
        Texture5 = 0x20,
        Texture6 = 0x40,
        Texture7 = 0x80,
    }

    [Flags]
    public enum IndirectTextureIndices
    {
        Indirect0 = 0x01,
        Indirect1 = 0x02,
        Indirect2 = 0x04,
    }
    
    [Flags]
    public enum IndTextureIndices
    {
        IndirectTexture0 = 0x01,
        IndirectTexture1 = 0x02,
        IndirectTexture2 = 0x04
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct SRT0EntryType2
    {
        bint _unk1; //entry count?
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct SRT0TextureEntry
    {
        public buint _code;

        //These are either a float value or int offset, in this order:
        //Scale X
        //Scale Y
        //Rotation
        //X Trans
        //Y Trans
        
        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public VoidPtr Data { get { return Address + 4; } }
        public SRT0Code Code { get { return new SRT0Code() { data = _code }; } set { _code = value.data; } }

        //Uses same header as CHR0 animations
        public I12Header* Entry(int index) { return (I12Header*)(Address + 4 + 4 * index + GetOffset(index)); }
        
        public float GetValue(int index) { return *(bfloat*)(Address + 4 + 4 * index); }
        public void SetValue(int index, float value) { *(bfloat*)(Address + 4 + 4 * index) = value; }
        
        public int GetOffset(int index) { return *(bint*)(Address + 4 + 4 * index); }
        public void SetOffset(int index, int value) { *(bint*)(Address + 4 + 4 * index) = value; }
    }

    public struct SRT0Code
    {
        public static SRT0Code Default = new SRT0Code() { data = 0x3FF };

        //0000 0000 0000 0000 0000 0000 0000 0001       Always set

        //0000 0000 0000 0000 0000 0000 0000 0010       Scale One
        //0000 0000 0000 0000 0000 0000 0000 0100       Rot Zero
        //0000 0000 0000 0000 0000 0000 0000 1000       Trans Zero
        //0000 0000 0000 0000 0000 0000 0001 0000		Scale Isotropic

        //0000 0000 0000 0000 0000 0000 0010 0000		Fixed Scale X
        //0000 0000 0000 0000 0000 0000 0100 0000		Fixed Scale Y
        //0000 0000 0000 0000 0000 0000 1000 0000		Fixed Rotation
        //0000 0000 0000 0000 0000 0001 0000 0000		Fixed X Translation
        //0000 0000 0000 0000 0000 0010 0000 0000		Fixed Y Translation

        public uint data;

        public bool AlwaysOn { get { return (data >> 0 & 1) != 0; } set { data = (uint)(data & (uint)1022) | (uint)(value ? 1 : 0); } }
        public bool NoScale { get { return (data >> 1 & 1) != 0; } set { data = (uint)(data & (uint)1021) | (uint)((value ? 1 : 0) << 1); } }
        public bool NoRotation { get { return (data >> 2 & 1) != 0; } set { data = (uint)(data & (uint)1019) | (uint)((value ? 1 : 0) << 2); } }
        public bool NoTranslation { get { return (data >> 3 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x8) | (uint)((value ? 1 : 0) << 3); } }
        public bool ScaleIsotropic { get { return (data >> 4 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x10) | (uint)((value ? 1 : 0) << 4); } }
        public bool FixedScaleX { get { return (data >> 5 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x20) | (uint)((value ? 1 : 0) << 5); } }
        public bool FixedScaleY { get { return (data >> 6 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x40) | (uint)((value ? 1 : 0) << 6); } }
        public bool FixedRotation { get { return (data >> 7 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x80) | (uint)((value ? 1 : 0) << 7); } }
        public bool FixedX { get { return (data >> 8 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x100) | (uint)((value ? 1 : 0) << 8); } }
        public bool FixedY { get { return (data >> 9 & 1) != 0; } set { data = (uint)(data & (uint)1023 - 0x200) | (uint)((value ? 1 : 0) << 9); } }

        public bool GetHas(int i) { return ((data >> (i + 1)) & 1) != 1; }
        public void SetHas(int index, bool p)
        {
            uint mask = (uint)1 << (1 + index);
            data = (data & ~mask) | (!p ? mask : 0);
        }

        public bool GetFixed(int i) { return ((data >> (i + 5)) & 1) != 0; }
        public void SetFixed(int i, bool p)
        {
            uint mask = (uint)1 << (5 + i);
            data = (data & ~mask) | (p ? mask : 0);
        }
        
        public int DataSize()
        {
            int val = 4;
            for (int i = 0; i < 4; i++)
                if (GetHas(i))
                    if (i == 2)
                        val += 8;
                    else 
                        val += 4;
            return val;
        }

        public override string ToString()
        {
            string val = "None";
            if (AlwaysOn) val = "Enabled";

            if (!NoScale) val += ", Has ";
            else val += ", No ";
            val += "Scale";

            if (!NoRotation) val += ", Has ";
            else val += ", No ";
            val += "Rotation";

            if (!NoTranslation) val += ", Has ";
            else val += ", No ";
            val += "Translation";

            if (ScaleIsotropic) val += ", Scale is isotropic";

            if (FixedScaleX) val += ", Fixed ";
            else val += ", Unfixed ";
            val += "Scale X";

            if (FixedScaleY) val += ", Fixed ";
            else val += ", Unfixed ";
            val += "Scale Y";

            if (FixedRotation) val += ", Fixed ";
            else val += ", Unfixed ";
            val += "Rotation";

            if (FixedX) val += ", Fixed ";
            else val += ", Unfixed ";
            val += "X";

            if (FixedY) val += ", Fixed ";
            else val += ", Unfixed ";
            val += "Y";

            return val;
        }
    }
}
