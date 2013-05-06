﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Textures;
using BrawlLib.Imaging;
using System.Drawing;
using BrawlLib.IO;
using System.Drawing.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class REFTNode : NW4RArcEntryNode
    {
        internal REFT* Header { get { return (REFT*)WorkingUncompressed.Address; } }
        internal NW4RCommonHeader* CommonHeader { get { return (NW4RCommonHeader*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.REFT; } }

        private int _unk1, _unk2, _unk3, _dataLen, _dataOff;
        private int _TableLen;
        private short _TableEntries;
        private short _TableUnk1;

        //[Category("REFT Data")]
        //public int DataLength { get { return _dataLen; } }
        //[Category("REFT Data")]
        //public int DataOffset { get { return _dataOff; } }

        //[Category("REFT Object Table")]
        //public int Length { get { return _TableLen; } }
        //[Category("REFT Object Table")]
        //public short NumEntries { get { return _TableEntries; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            REFT* header = Header;

            _name = header->IdString;
            _dataLen = header->_dataLength;
            _dataOff = header->_dataOffset;
            _unk1 = header->_linkPrev;
            _unk2 = header->_linkNext;

            REFTypeObjectTable* objTable = header->Table;
            _TableLen = (int)objTable->_length;
            _TableEntries = (short)objTable->_entries;
            _TableUnk1 = (short)objTable->_unk1;

            return header->Table->_entries > 0;
        }
        int tableLen = 0;
        protected override int OnCalculateSize(bool force)
        {
            int size = 0x60;
            tableLen = 0x9;
            foreach (ResourceNode n in Children)
            {
                tableLen += n.Name.Length + 11;
                size += n.CalculateSize(force);
            }
            return size + (tableLen = tableLen.Align(0x20));
        }

        protected override void OnPopulate()
        {
            REFTypeObjectTable* table = Header->Table;
            REFTypeObjectEntry* Entry = table->First;
            for (int i = 0; i < table->_entries; i++, Entry = Entry->Next)
                new REFTEntryNode() { _name = Entry->Name, _offset = (int)Entry->DataOffset, _length = (int)Entry->DataLength + 0x20 }.Initialize(this, new DataSource((byte*)table->Address + Entry->DataOffset, (int)Entry->DataLength + 0x20));
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            REFT* header = (REFT*)address;
            header->_linkPrev = 0;
            header->_linkNext = 0;
            header->_padding = 0;
            header->_dataLength = length - 0x18;
            header->_dataOffset = 0x48;
            header->_header._tag = header->_tag = REFT.Tag;
            header->_header.Endian = Endian.Big;
            header->_header._version = 7;
            header->_header._length = length;
            header->_header._firstOffset = 0x10;
            header->_header._numEntries = 1;
            header->IdString = Name;

            REFTypeObjectTable* table = (REFTypeObjectTable*)((byte*)header + header->_dataOffset + 0x18);
            table->_entries = (short)Children.Count;
            table->_unk1 = 0;
            table->_length = tableLen;

            REFTypeObjectEntry* entry = table->First;
            int offset = tableLen;
            foreach (ResourceNode n in Children)
            {
                entry->Name = n.Name;
                entry->DataOffset = offset;
                entry->DataLength = n._calcSize - 0x20;
                n.Rebuild((VoidPtr)table + offset, n._calcSize, force);
                offset += n._calcSize;
                entry = entry->Next;
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((REFT*)source.Address)->_tag == REFT.Tag ? new REFTNode() : null; }
    }
    public unsafe class REFTEntryNode : ResourceNode, IImageSource, IColorSource
    {
        internal REFTImageHeader* Header { get { return (REFTImageHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.REFTImage; } }

        public int _offset;
        public int _length;

        private WiiPixelFormat _format;
        private WiiPaletteFormat _pltFormat;
        int numColors, _imgLen, _pltLen;
        int _width, _height;
        uint _unk;
        int _lod;
        float _lodBias;
        internal uint _minFltr;
        internal uint _magFltr;

        [Browsable(false)]
        public bool hasPlt { get { return Header->_colorCount > 0; } }

        //[Category("REFT Image")]
        //public uint Unknown { get { return _unk; } }
        [Category("REFT Image")]
        public WiiPixelFormat TextureFormat { get { return _format; } }
        [Category("REFT Image")]
        public WiiPaletteFormat PaletteFormat { get { return _pltFormat; } }
        [Category("REFT Image")]
        public int Colors { get { return numColors; } }
        [Category("REFT Image")]
        public int Width { get { return _width; } }
        [Category("REFT Image")]
        public int Height { get { return _height; } }
        [Category("REFT Image")]
        public int ImageLength { get { return _imgLen; } }
        [Category("REFT Image")]
        public int PaletteLength { get { return _pltLen; } }
        [Category("REFT Image")]
        public int LevelOfDetail { get { return _lod; } }
        [Category("REFT Image")]
        public MDL0MaterialRefNode.TextureMinFilter MinFilter { get { return (MDL0MaterialRefNode.TextureMinFilter)_minFltr; } set { _minFltr = (uint)value; SignalPropertyChange(); } }
        [Category("REFT Image")]
        public MDL0MaterialRefNode.TextureMagFilter MagFilter { get { return (MDL0MaterialRefNode.TextureMagFilter)_magFltr; } set { _magFltr = (uint)value; SignalPropertyChange(); } }
        [Category("REFT Image")]
        public float LODBias { get { return _lodBias; } set { _lodBias = value; SignalPropertyChange(); } }

        [Category("REFT Entry")]
        public int REFTOffset { get { return _offset; } }
        [Category("REFT Entry")]
        public int DataLength { get { return _length; } }

        [Browsable(false)]
        public int ImageCount { get { return LevelOfDetail; } }
        public Bitmap GetImage(int index)
        {
            try
            {
                if (hasPlt == true)
                    return TextureConverter.DecodeIndexed((byte*)Header + 0x20, Width, Height, Palette, index + 1, _format);
                else
                    return TextureConverter.Decode((byte*)Header + 0x20, Width, Height, index + 1, _format);
            }
            catch
            {
                return null;
            }
        }

        private ColorPalette _palette;
        [Browsable(false)]
        public ColorPalette Palette
        {
            get { return hasPlt ? _palette == null ? _palette = TextureConverter.DecodePalette((VoidPtr)((byte*)Header + 0x20 + Header->_imagelen), Colors, _pltFormat) : _palette : null; }
            set { _palette = value; SignalPropertyChange(); }
        }

        #region IColorSource Members

        public bool HasPrimary(int id) { return false; }
        public ARGBPixel GetPrimaryColor(int id) { return new ARGBPixel(); }
        public void SetPrimaryColor(int id, ARGBPixel color) { }
        [Browsable(false)]
        public string PrimaryColorName(int id) { return null; }
        [Browsable(false)]
        public int ColorCount(int id) { return Palette != null ? Palette.Entries.Length : 0; }
        public ARGBPixel GetColor(int index, int id) { return Palette != null ? (ARGBPixel)Palette.Entries[index] : new ARGBPixel(); }
        public void SetColor(int index, int id, ARGBPixel color) { if (Palette != null) { Palette.Entries[index] = (Color)color; SignalPropertyChange(); } }

        #endregion

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _unk = Header->_unknown;
            _format = (WiiPixelFormat)Header->_format;
            _pltFormat = (WiiPaletteFormat)Header->_pltFormat;
            numColors = Header->_colorCount;
            _imgLen = (int)Header->_imagelen;
            _width = Header->_width;
            _height = Header->_height;
            _pltLen = (int)Header->_pltSize;
            _lod = Header->_mipmap + 1;
            _minFltr = Header->_min_filt;
            _magFltr = Header->_mag_filt;

            return false;
        }

        //public void Replace(Bitmap bmp)
        //{
        //    ReplaceRaw(TextureConverter.Get(_format).EncodeREFTTexture(bmp, 1, PaletteFormat, _format == WiiPixelFormat.CI4 || _format == WiiPixelFormat.CI8));
        //}

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            REFTImageHeader* header = (REFTImageHeader*)address;
            header->Set((byte)_minFltr, (byte)_magFltr, (byte)_lodBias);
        }

        public void Replace(Bitmap bmp)
        {
            FileMap tMap;
            if (hasPlt)
                tMap = TextureConverter.Get(_format).EncodeREFTTextureIndexed(bmp, LevelOfDetail, Palette.Entries.Length, PaletteFormat, QuantizationAlgorithm.MedianCut);
            else
                tMap = TextureConverter.Get(_format).EncodeREFTTexture(bmp, LevelOfDetail, WiiPaletteFormat.IA8);
            ReplaceRaw(tMap);
        }

        public override unsafe void Replace(string fileName)
        {
            Bitmap bmp;
            if (fileName.EndsWith(".tga"))
                bmp = TGA.FromFile(fileName);
            else if (fileName.EndsWith(".png") ||
                fileName.EndsWith(".tiff") || fileName.EndsWith(".tif") ||
                fileName.EndsWith(".bmp") ||
                fileName.EndsWith(".jpg") || fileName.EndsWith(".jpeg") ||
                fileName.EndsWith(".gif"))
                bmp = (Bitmap)Bitmap.FromFile(fileName);
            else
            {
                base.Replace(fileName);
                return;
            }

            using (Bitmap b = bmp)
                Replace(b);
        }

        public override void Export(string outPath)
        {
            if (outPath.EndsWith(".png"))
                using (Bitmap bmp = GetImage(0)) bmp.Save(outPath, ImageFormat.Png);
            else if (outPath.EndsWith(".tga"))
                using (Bitmap bmp = GetImage(0)) bmp.SaveTGA(outPath);
            else if (outPath.EndsWith(".tiff") || outPath.EndsWith(".tif"))
                using (Bitmap bmp = GetImage(0)) bmp.Save(outPath, ImageFormat.Tiff);
            else if (outPath.EndsWith(".bmp"))
                using (Bitmap bmp = GetImage(0)) bmp.Save(outPath, ImageFormat.Bmp);
            else if (outPath.EndsWith(".jpg") || outPath.EndsWith(".jpeg"))
                using (Bitmap bmp = GetImage(0)) bmp.Save(outPath, ImageFormat.Jpeg);
            else if (outPath.EndsWith(".gif"))
                using (Bitmap bmp = GetImage(0)) bmp.Save(outPath, ImageFormat.Gif);
            else
                base.Export(outPath);
        }
    }
}
