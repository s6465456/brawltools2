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

        protected override bool OnInitialize()
        {
            if (_origPath != null && _name == null)
                _name = Path.GetFileNameWithoutExtension(_origPath);
            else
             _name = "TPL" + Index;

            return Header->_numEntries > 0;
        }

        protected override void OnPopulate()
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

        protected override int OnCalculateSize(bool force)
        {
            int size = TPLHeader.Size + Children.Count * 8;
            foreach (TPLGroupNode g in Children)
            {
                if (g._palette != null)
                {
                    size += TPLPaletteHeader.Size;
                    size = size.Align(0x20);
                    size += g._palette.CalculateSize(true);
                }
                if (g._texture != null)
                {
                    size += TPLTextureHeader.Size;
                    size = size.Align(0x20);
                    size += g._texture.CalculateSize(true);
                }
            }
            return size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            TPLHeader* header = (TPLHeader*)address;
            header->_tag = TPLHeader.Tag;
            header->_numEntries = (uint)Children.Count;
            header->_dataOffset = 0xC;

            buint* values = (buint*)address + 3;

            VoidPtr data = address + 0xC + Children.Count * 8;

            foreach (TPLGroupNode g in Children)
            {
                if (g._palette != null)
                {
                    values[1] = (uint)(data - address);
                    TPLPaletteHeader* plt = (TPLPaletteHeader*)data;
                    plt->_numEntries = (ushort)g._palette.Colors;
                    plt->PaletteFormat = g._palette.Format;

                    plt->_data = ((uint)(data - address + TPLPaletteHeader.Size)).Align(0x20);
                }
                if (g._texture != null)
                {
                    values[0] = (uint)(data - address);
                    TPLTextureHeader* tex = (TPLTextureHeader*)data;
                    tex->_wrapS = g._texture._uWrap;
                    tex->_wrapT = g._texture._vWrap;
                    tex->_minFilter = g._texture._minFltr;
                    tex->_magFilter = g._texture._magFltr;
                    tex->PixelFormat = g._texture.Format;
                    tex->_width = (ushort)g._texture.Width;
                    tex->_height = (ushort)g._texture.Height;

                    tex->_data = ((uint)(data - address + TPLTextureHeader.Size)).Align(0x20);
                }
                values += 2;
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((TPLHeader*)source.Address)->_tag == TPLHeader.Tag ? new TPLNode() : null; }
    }

    public class TPLGroupNode : ResourceNode
    {
        public override ResourceType ResourceType { get { return ResourceType.NoEdit; } }

        public TPLTextureNode _texture;
        public TPLPaletteNode _palette;
    }

    public unsafe class TPLTextureNode : ResourceNode, IImageSource
    {
        public override ResourceType ResourceType { get { return ResourceType.TPLTexture; } }
        internal TPLTextureHeader* Header { get { return (TPLTextureHeader*)WorkingUncompressed.Address; } }

        internal VoidPtr _baseAddr;
        internal VoidPtr _dataAddr;

        int _width, _height;
        WiiPixelFormat _format;
        internal uint _uWrap;
        internal uint _vWrap;
        internal uint _minFltr;
        internal uint _magFltr;
        internal float _lodBias;
        internal bool _hasPalette;

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

        public TPLPaletteNode GetPaletteNode() { return (_parent == null) ? null : _parent.FindChild("Palette", false) as TPLPaletteNode; }

        protected override bool OnInitialize()
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

            return false;
        }

        [Browsable(false)]
        public int ImageCount { get { return 0; } }
        public Bitmap GetImage(int index)
        {
            TPLPaletteNode plt = GetPaletteNode();
            try
            {
                if (plt != null)
                    return TextureConverter.DecodeIndexed(_dataAddr, Width, Height, plt.Palette, index + 1, _format);
                else
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
                TPLPaletteNode pn = this.GetPaletteNode();
                tMap = TextureConverter.Get(Format).EncodeTPLTextureIndexed(bmp, pn.Colors, pn.Format, QuantizationAlgorithm.MedianCut, out pMap);
                pn.ReplaceRaw(pMap);
            }
            else
                tMap = TextureConverter.Get(Format).EncodeTPLTexture(bmp, 1);
            ReplaceRaw(tMap);
        }

        public override unsafe void ReplaceRaw(FileMap map)
        {
            base.ReplaceRaw(map);

            _dataAddr = WorkingUncompressed.Address + Header->_data;
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

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _palette = null;

            _name = "Palette";

            //_numColors = Header->_numEntries;
            _format = Header->PaletteFormat;

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return Palette.Entries.Length.Align(16) * 2;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            TextureConverter.EncodePalette(address, Palette, _format);
        }

        public override unsafe void ReplaceRaw(FileMap map)
        {
            base.ReplaceRaw(map);

            _dataAddr = WorkingUncompressed.Address;
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
