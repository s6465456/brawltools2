using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Textures;
using BrawlLib.Imaging;
using System.Drawing;
using System.Collections.Generic;
using BrawlLib.IO;
using System.Drawing.Imaging;
using System.IO;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class TPLNode : ARCEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.TPL; } }
        internal TPLHeader* Header { get { return (TPLHeader*)WorkingUncompressed.Address; } }

        public override bool OnInitialize()
        {
            if (_origPath != null && _name == null)
                _name = Path.GetFileNameWithoutExtension(_origPath);
            else
             _name = "TPL" + Index;

            return Header->_numEntries > 0;
        }

        public override void OnPopulate()
        {
            TPLGroupNode g;
            VoidPtr p;
            for (int i = 0; i < Header->_numEntries; i++)
            {
                (g = new TPLGroupNode() { _name = "Texture" + i }).Parent = this;
                if ((p = Header->GetTextureEntry(i)) != null)
                    (g._texture = new TPLTextureNode() { _dataAddr = (VoidPtr)Header + ((TPLTextureHeader*)p)->_data }).Initialize(g, p, 0);
                if ((p = Header->GetPaletteEntry(i)) != null)
                {
                    (g._palette = new TPLPaletteNode() { _dataAddr = (VoidPtr)Header + ((TPLPaletteHeader*)p)->_data }).Initialize(g, p, 0);
                    if (g._texture != null)
                        g._texture._hasPalette = true;
                }
            }
        }

        int size = 0, texHdrLen = 0, pltHdrLen = 0, texLen = 0, pltLen = 0;
        public override int OnCalculateSize(bool force)
        {
            texHdrLen = 0;
            pltHdrLen = 0;
            texLen = 0;
            pltLen = 0;

            size = TPLHeader.Size + Children.Count * 8;
            foreach (TPLGroupNode g in Children)
            {
                if (g._texture != null)
                {
                    texHdrLen += TPLTextureHeader.Size;
                    texLen += g._texture.CalculateSize(true);
                }
                if (g._palette != null)
                {
                    pltHdrLen += TPLPaletteHeader.Size;
                    pltLen += g._palette.CalculateSize(true);
                }
            }

            pltHdrLen = (pltHdrLen + size).Align(0x20) - size;
            pltLen = pltLen.Align(0x20);
            texHdrLen = texHdrLen.Align(0x20);
            texLen = texLen.Align(0x20);

            return size + pltHdrLen + pltLen + texHdrLen + texLen;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            TPLHeader* header = (TPLHeader*)address;
            header->_tag = TPLHeader.Tag;
            header->_numEntries = (uint)Children.Count;
            header->_dataOffset = 0xC;

            buint* values = (buint*)address + 3;

            VoidPtr pltHdrs = address + size;
            VoidPtr pltData = pltHdrs + pltHdrLen;
            VoidPtr texHdrs = pltData + pltLen;
            VoidPtr texData = texHdrs + texHdrLen;

            foreach (TPLGroupNode g in Children)
            {
                if (g._palette != null)
                {
                    values[1] = (uint)(pltHdrs - address);
                    TPLPaletteHeader* plt = (TPLPaletteHeader*)pltHdrs;
                    plt->_numEntries = (ushort)g._palette.Colors;
                    plt->PaletteFormat = g._palette.Format;

                    pltHdrs += TPLPaletteHeader.Size;

                    plt->_data = (uint)(pltData - address);

                    g._palette.Rebuild(pltData, g._palette._calcSize, true);
                    pltData += g._palette._calcSize;
                }
                else
                    values[1] = 0;

                if (g._texture != null)
                {
                    values[0] = (uint)(texHdrs - address);
                    TPLTextureHeader* tex = (TPLTextureHeader*)texHdrs;
                    tex->_wrapS = g._texture._uWrap;
                    tex->_wrapT = g._texture._vWrap;
                    tex->_minFilter = g._texture._minFltr;
                    tex->_magFilter = g._texture._magFltr;
                    tex->PixelFormat = g._texture.Format;
                    tex->_width = (ushort)g._texture.Width;
                    tex->_height = (ushort)g._texture.Height;
                    tex->_LODBias = g._texture._lodBias;
                    tex->_edgeLODEnable = (short)g._texture._enableEdgeLod;
                    tex->_maxLOD = (short)(g._texture.LevelOfDetail - 1);
                    tex->_minLOD = 0;

                    texHdrs += TPLTextureHeader.Size;

                    tex->_data = (uint)(texData - address);

                    g._texture.Rebuild(texData, g._texture._calcSize, true);
                    texData += g._texture._calcSize;
                }
                else
                    values[0] = 0;

                values += 2;
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((TPLHeader*)source.Address)->_tag == TPLHeader.Tag ? new TPLNode() : null; }
    }

    public class TPLGroupNode : ResourceNode, IImageSource
    {
        public override ResourceType ResourceType { get { return ResourceType.Container; } }

        public TPLTextureNode _texture;
        public TPLPaletteNode _palette;

        [Browsable(false)]
        public int ImageCount { get { return _texture != null ? _texture.ImageCount : 0; } }
        public Bitmap GetImage(int index)
        {
            if (_texture == null)
                return null;

            try
            {
                if (_palette != null)
                    return TextureConverter.DecodeIndexed(_texture._dataAddr, _texture.Width, _texture.Height, _palette.Palette, index + 1, _texture.Format);
                else
                    return TextureConverter.Decode(_texture._dataAddr, _texture.Width, _texture.Height, index + 1, _texture.Format);
            }
            catch { return null; }
        }
    }

    public unsafe class TPLTextureNode : ResourceNode, IImageSource
    {
        public override ResourceType ResourceType { get { return ResourceType.TPLTexture; } }
        internal TPLTextureHeader* Header { get { return (TPLTextureHeader*)WorkingUncompressed.Address; } }

        internal VoidPtr _dataAddr;

        int _width, _height;
        WiiPixelFormat _format;
        internal uint _uWrap;
        internal uint _vWrap;
        internal uint _minFltr;
        internal uint _magFltr;
        internal float _lodBias;
        internal bool _hasPalette;
        internal int _lod;
        internal int _enableEdgeLod;

        [Category("Texture")]
        public int Width { get { return _width; } }
        [Category("Texture")]
        public int Height { get { return _height; } }
        [Category("Texture")]
        public WiiPixelFormat Format { get { return _format; } }
        [Category("Texture")]
        public MDL0MaterialRefNode.WrapMode UWrapMode { get { return (MDL0MaterialRefNode.WrapMode)_uWrap; } set { _uWrap = (uint)value; SignalPropertyChange(); } }
        [Category("Texture")]
        public MDL0MaterialRefNode.WrapMode VWrapMode { get { return (MDL0MaterialRefNode.WrapMode)_vWrap; } set { _vWrap = (uint)value; SignalPropertyChange(); } }
        [Category("Texture")]
        public MDL0MaterialRefNode.TextureMinFilter MinFilter { get { return (MDL0MaterialRefNode.TextureMinFilter)_minFltr; } set { _minFltr = (uint)value; SignalPropertyChange(); } }
        [Category("Texture")]
        public MDL0MaterialRefNode.TextureMagFilter MagFilter { get { return (MDL0MaterialRefNode.TextureMagFilter)_magFltr; } set { _magFltr = (uint)value; SignalPropertyChange(); } }
        [Category("Texture")]
        public float LODBias { get { return _lodBias; } set { _lodBias = value; SignalPropertyChange(); } }
        [Category("Texture")]
        public int EnableEdgeLOD { get { return _enableEdgeLod; } set { _enableEdgeLod = value; SignalPropertyChange(); } }
        [Category("Texture")]
        public int LevelOfDetail { get { return _lod; } }

        public TPLPaletteNode GetPaletteNode() { return (_parent == null) ? null : _parent.FindChild("Palette", false) as TPLPaletteNode; }

        public override bool OnInitialize()
        {
            base.OnInitialize();

            _name = "Texture";

            _width = Header->_width;
            _height = Header->_height;
            _format = Header->PixelFormat;
            _uWrap = Header->_wrapS;
            _vWrap = Header->_wrapT;
            _minFltr = Header->_minFilter;
            _magFltr = Header->_magFilter;
            _lod = Header->_maxLOD + 1;
            _enableEdgeLod = Header->_edgeLODEnable;

            if (_replaced)
                _dataAddr = WorkingUncompressed.Address + Header->_data;

            return false;
        }

        [Browsable(false)]
        public int ImageCount { get { return LevelOfDetail; } }
        public Bitmap GetImage(int index)
        {
            //TPLPaletteNode plt = GetPaletteNode();
            try
            {
                //if (plt != null)
                //    return TextureConverter.DecodeIndexed(_dataAddr, Width, Height, plt.Palette, index + 1, _format);
                //else
                    return TextureConverter.Decode(_dataAddr, Width, Height, index + 1, _format);
            }
            catch { return null; }
        }

        public Bitmap GetImage(int index, TPLPaletteNode plt)
        {
            try
            {
                if (plt != null)
                    return TextureConverter.DecodeIndexed(_dataAddr, Width, Height, plt.Palette, index + 1, _format);
                else
                    return TextureConverter.Decode(_dataAddr, Width, Height, index + 1, _format);
            }
            catch { return null; }
        }

        public void Replace(Bitmap bmp)
        {
            FileMap tMap, pMap;
            if (_hasPalette)
            {
                TPLPaletteNode pn = GetPaletteNode();
                tMap = TextureConverter.Get(Format).EncodeTPLTextureIndexed(bmp, pn.Colors, pn.Format, QuantizationAlgorithm.MedianCut, out pMap);
                pn.ReplaceRaw(pMap);
            }
            else
                tMap = TextureConverter.Get(Format).EncodeTPLTexture(bmp, 1);
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
            {
                int dataLen = TPLTextureHeader.Size + CalculateSize(true);
                using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
                {
                    stream.SetLength(dataLen);
                    using (FileMap map = FileMap.FromStream(stream))
                    {
                        TPLTextureHeader* tex = (TPLTextureHeader*)map.Address;
                        tex->_wrapS = _uWrap;
                        tex->_wrapT = _vWrap;
                        tex->_minFilter = _minFltr;
                        tex->_magFilter = _magFltr;
                        tex->PixelFormat = Format;
                        tex->_width = (ushort)Width;
                        tex->_height = (ushort)Height;
                        tex->_LODBias = _lodBias;
                        tex->_edgeLODEnable = (short)_enableEdgeLod;
                        tex->_maxLOD = (short)(LevelOfDetail - 1);
                        tex->_minLOD = 0;

                        VoidPtr data = (VoidPtr)tex + TPLTextureHeader.Size;
                        tex->_data = (uint)(data - map.Address);
                        Rebuild(data, _calcSize, true);
                    }
                }
            }
        }

        public override int OnCalculateSize(bool force)
        {
            return TextureConverter.Get(Format).GetMipOffset(Width, Height, LevelOfDetail + 1);
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            Memory.Move(address, _dataAddr, (uint)length);
            _dataAddr = address;
        }
    }
    
    public unsafe class TPLPaletteNode : ResourceNode, IColorSource
    {
        public override ResourceType ResourceType { get { return ResourceType.TPLPalette; } }
        internal TPLPaletteHeader* Header { get { return (TPLPaletteHeader*)WorkingUncompressed.Address; } }

        //private int _numColors;
        private WiiPaletteFormat _format;

        internal VoidPtr _dataAddr;

        private ColorPalette _palette;
        [Browsable(false)]
        public ColorPalette Palette
        {
            get { return _palette == null ? _palette = TextureConverter.DecodePalette(_dataAddr, Header->_numEntries, Format) : _palette; }
            set { _palette = value; SignalPropertyChange(); }
        }

        [Category("Palette")]
        public int Colors { get { return Palette.Entries.Length; } }// set { _numColors = value; } }
        [Category("Palette")]
        public WiiPaletteFormat Format { get { return _format; } set { _format = value; SignalPropertyChange(); } }

        public override bool OnInitialize()
        {
            base.OnInitialize();

            _palette = null;

            _name = "Palette";

            //_numColors = Header->_numEntries;
            _format = Header->PaletteFormat;

            if (_replaced)
                _dataAddr = WorkingUncompressed.Address + Header->_data;

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            return Palette.Entries.Length.Align(16) * 2;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            TextureConverter.EncodePalette(address, Palette, _format);
            _dataAddr = address;
        }

        #region IColorSource Members

        public bool HasPrimary(int id) { return false; }
        public ARGBPixel GetPrimaryColor(int id) { return new ARGBPixel(); }
        public void SetPrimaryColor(int id, ARGBPixel color) { }
        [Browsable(false)]
        public string PrimaryColorName(int id) { return null; }
        [Browsable(false)]
        public int ColorCount(int id) { return Palette.Entries.Length; }
        public ARGBPixel GetColor(int index, int id) { return (ARGBPixel)Palette.Entries[index]; }
        public void SetColor(int index, int id, ARGBPixel color) { Palette.Entries[index] = (Color)color; SignalPropertyChange(); }

        #endregion
    }
}
