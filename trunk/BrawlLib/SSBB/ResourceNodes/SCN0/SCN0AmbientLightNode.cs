using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0AmbientLightNode : SCN0EntryNode, IColorSource
    {
        internal SCN0AmbientLight* Data { get { return (SCN0AmbientLight*)WorkingUncompressed.Address; } }
        private byte fixedFlags, usageFlags = 3;

        //[Category("Ambient Light")]
        //public SCN0AmbLightFlags UsageFlags { get { return (SCN0AmbLightFlags)unk4; } set { unk4 = (byte)value; SignalPropertyChange(); } }

        [Category("Ambient Light")]
        public bool ColorEnabled 
        {
            get { return (usageFlags & 1) != 0; } 
            set
            {
                if (value)
                    usageFlags |= 1;
                else
                    usageFlags &= 2;
                SignalPropertyChange();
            }
        }
        [Category("Ambient Light")]
        public bool AlphaEnabled
        {
            get { return (usageFlags & 2) != 0; }
            set
            {
                if (value)
                    usageFlags |= 2;
                else
                    usageFlags &= 1;
                SignalPropertyChange();
            }
        }
        
        public bool _constant = true;
        [Category("Ambient Light")]
        public bool Constant
        {
            get { return _constant; }
            set
            {
                if (_constant != value)
                {
                    _constant = value;
                    if (_constant)
                        MakeSolid(new ARGBPixel());
                    else
                        MakeList();

                    UpdateCurrentControl();
                }
            }
        }

        internal List<ARGBPixel> _colors = new List<ARGBPixel>();
        [Browsable(false)]
        public List<ARGBPixel> Colors { get { return _colors; } set { _colors = value; SignalPropertyChange(); } }

        internal ARGBPixel _solidColor = new ARGBPixel();
        [Browsable(false)]
        public ARGBPixel SolidColor { get { return _solidColor; } set { _solidColor = value; SignalPropertyChange(); } }

        internal int _numEntries;
        [Browsable(false)]
        internal int NumEntries
        {
            get { return _numEntries; }
            set
            {
                //if (_numEntries == 0)
                //    return;

                if (value > _numEntries)
                {
                    ARGBPixel p = _numEntries > 0 ? _colors[_numEntries - 1] : new ARGBPixel(255, 0, 0, 0);
                    for (int i = value - _numEntries; i-- > 0; )
                        _colors.Add(p);
                }
                else if (value < _colors.Count)
                    _colors.RemoveRange(value, _colors.Count - value);

                _numEntries = value;
            }
        }

        public void MakeSolid(ARGBPixel color)
        {
            _numEntries = 0;
            _constant = true;
            _solidColor = color;
            SignalPropertyChange();
        }
        public void MakeList()
        {
            _constant = false;
            int entries = FrameCount + 1;
            _numEntries = _colors.Count;
            NumEntries = entries;
        }

        #region IColorSource Members

        public bool HasPrimary(int id) { return false; }
        public ARGBPixel GetPrimaryColor(int id) { return new ARGBPixel(); }
        public void SetPrimaryColor(int id, ARGBPixel color) { }
        [Browsable(false)]
        public string PrimaryColorName(int id) { return null; }
        [Browsable(false)]
        public int ColorCount(int id) { return (_numEntries == 0) ? 1 : _numEntries; }
        public ARGBPixel GetColor(int index, int id) { return (_numEntries == 0) ? _solidColor : _colors[index]; }
        public void SetColor(int index, int id, ARGBPixel color)
        {
            if (_numEntries == 0)
                _solidColor = color;
            else
                _colors[index] = color;
            SignalPropertyChange();
        }

        #endregion

        [Browsable(false)]
        public int FrameCount { get { return ((SCN0Node)Parent.Parent).FrameCount; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _colors = new List<ARGBPixel>();

            fixedFlags = Data->_fixedFlags;
            usageFlags = Data->_flags;
            if ((fixedFlags >> 7 & 1) == 1)
            {
                _constant = true;
                _numEntries = 0;
                _solidColor = (ARGBPixel)Data->_lighting;
            }
            else if (Name != "<null>")
            {
                _constant = false;
                _numEntries = FrameCount + 1;
                RGBAPixel* addr = Data->lightEntries;
                for (int i = 0; i < _numEntries; i++)
                    _colors.Add((ARGBPixel)(*addr++));
            }

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            if (_name != "<null>")
                if (_numEntries != 0)
                {
                    fixedFlags &= 0xFF - 128;
                    lightLen = 4 * (FrameCount + 1);
                }
                else
                {
                    fixedFlags |= 128;
                    lightLen = 0;
                }
            return SCN0AmbientLight.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0AmbientLight* header = (SCN0AmbientLight*)address;
            header->_header._length = _length = SCN0AmbientLight.Size;

            if (_name != "<null>")
            {
                header->_fixedFlags = 128;
                header->_pad1 = 0;
                header->_pad2 = 0;
                header->_flags = usageFlags;
                if (_numEntries != 0)
                {
                    header->_fixedFlags = 0;
                    *((bint*)header->_lighting.Address) = (int)lightAddr - (int)header->_lighting.Address;
                    for (int i = 0; i <= FrameCount; i++)
                        if (i < _colors.Count)
                            *lightAddr++ = (RGBAPixel)_colors[i];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else if (_colors.Count == 1)
                    header->_lighting = (RGBAPixel)_colors[0];
                else
                    header->_lighting = new RGBAPixel();
            }
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }
    }
}