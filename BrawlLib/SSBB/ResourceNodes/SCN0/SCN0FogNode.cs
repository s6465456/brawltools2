using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;
using BrawlLib.Wii.Graphics;
using BrawlLib.Wii.Animations;
using System.Runtime.InteropServices;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0FogNode : SCN0EntryNode, IColorSource, ISCN0KeyframeHolder
    {
        internal SCN0Fog* Data { get { return (SCN0Fog*)WorkingUncompressed.Address; } }

        private int type = 2;
        public SCN0FogFlags flags = (SCN0FogFlags)0xE0;

        public KeyframeArray _startKeys = new KeyframeArray(0), _endKeys = new KeyframeArray(0);

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

        public bool _constant = true;
        [Category("Fog")]
        public bool ConstantColor
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

        public KeyframeArray GetKeys(int i)
        {
            switch (i)
            {
                case 0: return _startKeys;
                case 1: return _endKeys;
            }
            return null;
        }

        public void SetKeys(int i, KeyframeArray value)
        {
            switch (i)
            {
                case 0: _startKeys = value; break;
                case 1: _endKeys = value; break;
            }
        }

        [Category("Fog")]
        public FogType Type { get { return (FogType)type; } set { type = (int)value; SignalPropertyChange(); } }
        
        [Browsable(false)]
        public int FrameCount { get { return ((SCN0Node)Parent.Parent).FrameCount; } }

        internal List<ARGBPixel> _colors = new List<ARGBPixel>();
        [Browsable(false)]
        public List<ARGBPixel> Colors { get { return _colors; } set { _colors = value; SignalPropertyChange(); } }

        internal ARGBPixel _solidColor;
        [Browsable(false)]
        public ARGBPixel SolidColor { get { return _solidColor; } set { _solidColor = value; SignalPropertyChange(); } }

        internal int _numEntries;
        [Browsable(false)]
        internal int NumEntries
        {
            get { return _numEntries; }
            set
            {
                if (_numEntries == 0)
                    return;

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

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _colors = new List<ARGBPixel>();

            _startKeys = new KeyframeArray(FrameCount + 1);
            _endKeys = new KeyframeArray(FrameCount + 1);

            flags = (SCN0FogFlags)Data->_flags;
            type = Data->_type;
            if (Name != "<null>")
            {
                if (flags.HasFlag(SCN0FogFlags.FixedStart))
                    _startKeys[0] = Data->_start;
                else if (!_replaced)
                    SCN0EntryNode.DecodeFrames(_startKeys, Data->startKeyframes);
                
                if (flags.HasFlag(SCN0FogFlags.FixedEnd))
                    _endKeys[0] = Data->_end;
                else if (!_replaced)
                    SCN0EntryNode.DecodeFrames(_endKeys, Data->endKeyframes);
                
                if (flags.HasFlag(SCN0FogFlags.FixedColor))
                {
                    _constant = true;
                    _numEntries = 0;
                    _solidColor = (ARGBPixel)Data->_color;
                }
                else
                {
                    _constant = false;
                    _numEntries = FrameCount + 1;
                    RGBAPixel* addr = Data->colorEntries;
                    for (int i = 0; i <= FrameCount; i++)
                        _colors.Add((ARGBPixel)(*addr++));
                }
            }

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            keyLen = 0;
            lightLen = 0;
            if (_startKeys._keyCount > 1)
                keyLen += 4 + _startKeys._keyCount * 12;
            if (_endKeys._keyCount > 1)
                keyLen += 4 + _endKeys._keyCount * 12;
            if (_colors.Count > 1)
                lightLen += 4 * (FrameCount + 1);
            return SCN0Fog.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0Fog* header = (SCN0Fog*)address;

            flags = SCN0FogFlags.None;
            if (_colors.Count > 1)
            {
                *((bint*)header->_color.Address) = (int)lightAddr - (int)header->_color.Address;
                for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                    if (i < _colors.Count)
                        *lightAddr++ = (RGBAPixel)_colors[i];
                    else
                        *lightAddr++ = new RGBAPixel();
                //flags &= ~SCN0FogFlags.FixedColor;
            }
            else
            {
                flags |= SCN0FogFlags.FixedColor;
                if (_colors.Count == 1)
                    header->_color = (RGBAPixel)_colors[0];
                else
                    header->_color = new RGBAPixel();
            }
            if (_startKeys._keyCount > 1)
            {
                *((bint*)header->_start.Address) = (int)keyframeAddr - (int)header->_start.Address;
                SCN0EntryNode.EncodeFrames(_startKeys, ref keyframeAddr);
                //flags &= ~SCN0FogFlags.FixedStart;
            }
            else
            {
                flags |= SCN0FogFlags.FixedStart;
                if (_startKeys._keyCount == 1)
                    header->_start = _startKeys._keyRoot._next._value;
                else
                    header->_start = 0;
            }
            if (_endKeys._keyCount > 1)
            {
                *((bint*)header->_end.Address) = (int)keyframeAddr - (int)header->_end.Address;
                SCN0EntryNode.EncodeFrames(_endKeys, ref keyframeAddr);
                //flags &= ~SCN0FogFlags.FixedEnd;
            }
            else
            {
                flags |= SCN0FogFlags.FixedEnd;
                if (_endKeys._keyCount == 1)
                    header->_end = _endKeys._keyRoot._next._value;
                else
                    header->_end = 0;
            }

            header->_flags = (byte)flags;
            header->_type = type;
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }

        internal FogAnimationFrame GetAnimFrame(int index)
        {
            FogAnimationFrame frame;
            float* dPtr = (float*)&frame;
            for (int x = 0; x < 2; x++)
                *dPtr++ = GetKeys(x).GetFrameValue(index);
            return frame;
        }

        internal KeyframeEntry GetKeyframe(int keyFrameMode, int index)
        {
            return GetKeys(keyFrameMode).GetKeyframe(index);
        }

        internal void RemoveKeyframe(int keyFrameMode, int index)
        {
            KeyframeEntry k = GetKeys(keyFrameMode).Remove(index);
            if (k != null)
            {
                k._prev.GenerateTangent();
                k._next.GenerateTangent();
                SignalPropertyChange();
            }
        }
        
        internal void SetKeyframe(int keyFrameMode, int index, float value)
        {
            KeyframeEntry k = GetKeys(keyFrameMode).SetFrameValue(index, value);
            k.GenerateTangent();
            k._prev.GenerateTangent();
            k._next.GenerateTangent();

            SignalPropertyChange();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FogAnimationFrame
    {
        public static readonly FogAnimationFrame Empty = new FogAnimationFrame();

        public float Start;
        public float End;

        public bool hasS;
        public bool hasE;

        public bool forKF;

        public void SetBools(int index, bool val)
        {
            switch (index)
            {
                case 0:
                    hasS = val; break;
                case 1:
                    hasE = val; break;
            }
        }

        public void ResetBools()
        {
            hasS = hasE = false;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Start;
                    case 1: return End;
                    default: return float.NaN;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Start = value; break;
                    case 1: End = value; break;
                }
            }
        }

        public FogAnimationFrame(float start, float end)
        {
            Start = start;
            End = end;
            Index = 0;
            hasS = hasE = false;
            forKF = true;
        }

        public int Index;
        const int len = 6;
        static string empty = new String('_', len);
        public override string ToString()
        {
            return String.Format("[{0}] StartZ={1}, EndZ={2}", Index + 1,
            !hasS ? empty : Start.ToString().TruncateAndFill(len, ' '),
            !hasE ? empty : End.ToString().TruncateAndFill(len, ' '));
        }
        //public override string ToString()
        //{
        //    return String.Format("{0}\r\n{1}\r\n{2}", Scale, Rotation, Translation);
        //}
    }
}
