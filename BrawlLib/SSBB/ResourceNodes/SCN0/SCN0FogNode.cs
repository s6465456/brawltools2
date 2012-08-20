using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;
using BrawlLib.Wii.Graphics;
using BrawlLib.Wii.Animations;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0FogNode : SCN0EntryNode
    {
        internal SCN0Fog* Data { get { return (SCN0Fog*)WorkingUncompressed.Address; } }

        private int type;
        public SCN0FogFlags flags;

        private List<SCN0Keyframe> starts = new List<SCN0Keyframe>(), ends = new List<SCN0Keyframe>();

        public KeyframeArray _startKeys, _endKeys;

        [Category("Fog")]
        public FogType Type { get { return (FogType)type; } set { type = (int)value; SignalPropertyChange(); } }
        [Category("Fog")]
        public List<SCN0Keyframe> StartZ { get { return starts; } set { starts = value; SignalPropertyChange(); } }
        [Category("Fog")]
        public List<SCN0Keyframe> EndZ { get { return ends; } set { ends = value; SignalPropertyChange(); } }
        [Category("Fog")]
        public ARGBPixel[] ColorsArr { get { return _colors.ToArray(); } set { _colors = value.ToList<ARGBPixel>(); SignalPropertyChange(); } }

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

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            starts = new List<SCN0Keyframe>();
            ends = new List<SCN0Keyframe>();
            _colors = new List<ARGBPixel>();

            _startKeys = new KeyframeArray(((SCN0Node)Parent.Parent).FrameCount + 1);
            _endKeys = new KeyframeArray(((SCN0Node)Parent.Parent).FrameCount + 1);

            flags = (SCN0FogFlags)Data->_flags;
            type = Data->_type;
            if (Name != "<null>")
            {
                if (flags.HasFlag(SCN0FogFlags.FixedStart))
                {
                    _startKeys[0] = Data->_start;
                    starts.Add(new Vector3(0, 0, Data->_start));
                }
                else
                {
                    if (!_replaced)
                    {
                        SCN0EntryNode.DecodeFrames(_startKeys, Data->startKeyframes);
                        SCN0KeyframeStruct* addr = Data->startKeyframes->Data;
                        for (int i = 0; i < Data->startKeyframes->_numFrames; i++)
                            starts.Add(*addr++);
                    }
                }
                if (flags.HasFlag(SCN0FogFlags.FixedEnd))
                {
                    _endKeys[0] = Data->_end;
                    ends.Add(new Vector3(0, 0, Data->_end));
                }
                else
                {
                    if (!_replaced)
                    {
                        SCN0EntryNode.DecodeFrames(_endKeys, Data->endKeyframes);
                        SCN0KeyframeStruct* addr = Data->endKeyframes->Data;
                        for (int i = 0; i < Data->endKeyframes->_numFrames; i++)
                            ends.Add(*addr++);
                    }
                }
                if (flags.HasFlag(SCN0FogFlags.FixedColor))
                    _colors.Add((ARGBPixel)Data->_color);
                else
                {
                    if (!_replaced)
                    {
                        RGBAPixel* addr = Data->colorEntries;
                        for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                            _colors.Add((ARGBPixel)(*addr++));
                    }
                }
            }

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            keyLen = 0;
            lightLen = 0;
            if (starts.Count > 1)
                keyLen += 4 + starts.Count * 12;
            if (ends.Count > 1)
                keyLen += 4 + ends.Count * 12;
            if (_colors.Count > 1)
                lightLen += 4 * (((SCN0Node)Parent.Parent).FrameCount + 1);
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
                flags &= ~SCN0FogFlags.FixedColor;
            }
            else
            {
                flags |= SCN0FogFlags.FixedColor;
                if (_colors.Count == 1)
                    header->_color = (RGBAPixel)_colors[0];
                else
                    header->_color = new RGBAPixel();
            }
            if (starts.Count > 1)
            {
                *((bint*)header->_start.Address) = (int)keyframeAddr - (int)header->_start.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)starts.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < starts.Count; i++)
                    *addr++ = starts[i];
                keyframeAddr += 4 + starts.Count * 12;
                flags &= ~SCN0FogFlags.FixedStart;
            }
            else
            {
                flags |= SCN0FogFlags.FixedStart;
                if (starts.Count == 1)
                    header->_start = starts[0]._value;
                else
                    header->_start = 0;
            }
            if (ends.Count > 1)
            {
                *((bint*)header->_end.Address) = (int)keyframeAddr - (int)header->_end.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)ends.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < ends.Count; i++)
                    *addr++ = ends[i];
                keyframeAddr += 4 + ends.Count * 12;
                flags &= ~SCN0FogFlags.FixedEnd;
            }
            else
            {
                flags |= SCN0FogFlags.FixedEnd;
                if (ends.Count == 1)
                    header->_end = ends[0]._value;
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
    }
}
