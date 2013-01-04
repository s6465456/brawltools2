using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Textures;
using BrawlLib.Imaging;
using System.Drawing;
using System.Collections.Generic;
using BrawlLib.IO;
using System.Drawing.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class TEX0Node : BRESEntryNode, IImageSource
    {
        public override ResourceType ResourceType { get { return ResourceType.TEX0; } }
        internal TEX0v1* Header1 { get { return (TEX0v1*)WorkingUncompressed.Address; } }
        internal TEX0v3* Header3 { get { return (TEX0v3*)WorkingUncompressed.Address; } }

        public override int DataAlign { get { return 0x20; } }

        int _width, _height;
        WiiPixelFormat _format;
        int _lod;
        bool _hasPalette;
        int _version;

        //[Category("Texture")]
        //public int Version { get { return _version; } set { _version = value; } }
        [Category("Texture")]
        public int Width { get { return _width; } }
        [Category("Texture")]
        public int Height { get { return _height; } }
        [Category("Texture")]
        public WiiPixelFormat Format { get { return _format; } }
        [Category("Texture")]
        public int LevelOfDetail { get { return _lod; } }
        [Category("Texture")]
        public bool HasPalette { get { return _hasPalette; } }

        public PLT0Node GetPaletteNode() { return ((_parent == null) || (!HasPalette)) ? null : _parent._parent.FindChild("Palettes(NW4R)/" + this.Name, false) as PLT0Node; }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            if ((_name == null) && (Header1->_stringOffset != 0))
                _name = Header1->ResourceString;

            _width = Header1->_width;
            _height = Header1->_height;
            _format = Header1->PixelFormat;
            _lod = Header1->_levelOfDetail;
            _hasPalette = Header1->HasPalette;
            _version = Header1->_header._version;

            return false;
        }

        [Browsable(false)]
        public int ImageCount { get { return _lod; } }
        public Bitmap GetImage(int index)
        {
            PLT0Node plt = GetPaletteNode();
            try
            {
                if (plt != null)
                    return TextureConverter.DecodeIndexed(Header1, plt.Palette, index + 1);
                else
                    return TextureConverter.Decode(Header1, index + 1);
            }
            catch { return null; }
        }

        public Bitmap GetImage(int index, PLT0Node plt)
        {
            try
            {
                if (plt != null)
                    return TextureConverter.DecodeIndexed(Header1, plt.Palette, index + 1);
                else
                    return TextureConverter.Decode(Header1, index + 1);
            }
            catch { return null; }
        }

        protected internal override void PostProcess(VoidPtr bresAddress, VoidPtr dataAddress, int dataLength, StringTable stringTable)
        {
            base.PostProcess(bresAddress, dataAddress, dataLength, stringTable);

            TEX0v1* header = (TEX0v1*)dataAddress;
            header->ResourceStringAddress = stringTable[Name] + 4;
        }

        public void Replace(Bitmap bmp)
        {
            FileMap tMap, pMap;
            if (HasPalette)
            {
                PLT0Node pn = this.GetPaletteNode();
                tMap = TextureConverter.Get(Format).EncodeTextureIndexed(bmp, LevelOfDetail, pn.Colors, pn.Format, QuantizationAlgorithm.MedianCut, out pMap);
                pn.ReplaceRaw(pMap);
            }
            else
                tMap = TextureConverter.Get(Format).EncodeTEX0Texture(bmp, LevelOfDetail);
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

        internal static ResourceNode TryParse(DataSource source) { return ((TEX0v1*)source.Address)->_header._tag == TEX0v1.Tag ? new TEX0Node() : null; }
    }
}
