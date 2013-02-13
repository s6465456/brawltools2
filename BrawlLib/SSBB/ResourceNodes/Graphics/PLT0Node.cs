﻿using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Textures;
using System.Collections.Generic;
using System.Drawing.Imaging;
using BrawlLib.Imaging;
using System.Drawing;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class PLT0Node : BRESEntryNode, IColorSource
    {
        public override ResourceType ResourceType { get { return ResourceType.PLT0; } }
        internal PLT0v1* Header1 { get { return (PLT0v1*)WorkingUncompressed.Address; } }
        internal PLT0v3* Header3 { get { return (PLT0v3*)WorkingUncompressed.Address; } }
        internal BRESCommonHeader* Header { get { return (BRESCommonHeader*)WorkingUncompressed.Address; } }
        
        public override int DataAlign { get { return 0x20; } }

        //private int _numColors;
        private WiiPaletteFormat _format;
        int _version;
        private ColorPalette _palette;
        [Browsable(false)]
        public ColorPalette Palette
        {
            get { return _palette == null ? _palette = TextureConverter.DecodePalette(Header1) : _palette; }
            set { _palette = value; SignalPropertyChange(); }
        }

        [Category("Palette")]
        public int Colors { get { return Palette.Entries.Length; } }// set { _numColors = value; } }
        [Category("Palette")]
        public WiiPaletteFormat Format { get { return _format; } set { _format = value; SignalPropertyChange(); } }
        [Category("Palette")]
        public string OriginalPath { get { return _originalPath; } set { _originalPath = value; SignalPropertyChange(); } }
        public string _originalPath;

        [Category("User Data"), TypeConverter(typeof(ExpandableObjectCustomConverter))]
        public UserDataCollection UserEntries { get { return _userEntries; } set { _userEntries = value; SignalPropertyChange(); } }
        internal UserDataCollection _userEntries = new UserDataCollection();

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _palette = null;

            if ((_name == null) && (Header1->_stringOffset != 0))
                _name = Header1->ResourceString;

            _version = Header1->_bresEntry._version;
            //_numColors = Header->_numEntries;
            _format = Header1->PaletteFormat;

            if (_version == 3)
                (_userEntries = new UserDataCollection()).Read(Header3->UserData);

            return false;
        }

        internal override void GetStrings(StringTable table)
        {
            table.Add(Name);

            if (_version == 3)
                foreach (UserDataClass s in _userEntries)
                    table.Add(s._name);

            if (!String.IsNullOrEmpty(_originalPath))
                table.Add(_originalPath);
        }

        protected override int OnCalculateSize(bool force)
        {
            int count = Palette.Entries.Length.Align(16);
            return 0x40 + (count * 2);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            PLT0v1* header = (PLT0v1*)address;
            *header = new PLT0v1(Palette.Entries.Length, _format);

            TextureConverter.EncodePalette(address + 0x40, Palette, _format);
        }

        protected internal override void PostProcess(VoidPtr bresAddress, VoidPtr dataAddress, int dataLength, StringTable stringTable)
        {
            base.PostProcess(bresAddress, dataAddress, dataLength, stringTable);

            PLT0v1* header = (PLT0v1*)dataAddress;
            header->ResourceStringAddress = stringTable[Name] + 4; 
            if (!String.IsNullOrEmpty(_originalPath))
                header->OrigPathAddress = stringTable[_originalPath] + 4;
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

        internal static ResourceNode TryParse(DataSource source) { return ((PLT0v1*)source.Address)->_bresEntry._tag == PLT0v1.Tag ? new PLT0Node() : null; }
    }
}
