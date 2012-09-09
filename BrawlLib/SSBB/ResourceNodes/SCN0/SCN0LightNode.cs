using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;
using BrawlLib.Wii.Graphics;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0LightNode : SCN0EntryNode
    {
        internal SCN0Light* Data { get { return (SCN0Light*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int _nonSpecLightId, _part2Offset, _enableOffset, _distFunc, _spotFunc;
        internal ushort _flags1, _flags2;
        private List<SCN0Keyframe> _refDist = new List<SCN0Keyframe>(), _refBrightness = new List<SCN0Keyframe>(), _cutoff = new List<SCN0Keyframe>(), _shininess = new List<SCN0Keyframe>();
        private List<RGBAPixel> _lightColor = new List<RGBAPixel>(), _specColor = new List<RGBAPixel>();
        private List<SCN0Keyframe> xStarts = new List<SCN0Keyframe>(), yStarts = new List<SCN0Keyframe>(), zStarts = new List<SCN0Keyframe>(), xEnds = new List<SCN0Keyframe>(), yEnds = new List<SCN0Keyframe>(), zEnds = new List<SCN0Keyframe>();
        private List<bool> _enabled = new List<bool>();

        [Flags]
        public enum FixedFlags : ushort
        {
            StartXConstant = 0x8,
            StartYConstant = 0x10,
            StartZConstant = 0x20,
            ColorConstant = 0x40,
            EnabledConstant = 0x80, //Refer to Enabled in UsageFlags if constant
            EndXConstant = 0x100,
            EndYConstant = 0x200,
            EndZConstant = 0x400,
            CutoffConstant = 0x800,
            RefDistanceConstant = 0x1000,
            RefBrightnessConstant = 0x2000,
            SpecColorConstant = 0x4000,
            ShininessConstant = 0x8000
        }
        
        [Category("Specular Color")]
        public int NonSpecularLightID { get { return _nonSpecLightId; } set { _nonSpecLightId = value; SignalPropertyChange(); } }
        [Category("Specular Color")]
        public RGBAPixel[] SpecularColor { get { return _specColor.ToArray(); } set { _specColor = value.ToList<RGBAPixel>(); SignalPropertyChange(); } }
        [Category("Specular Color")]
        public List<SCN0Keyframe> Brightness { get { return _shininess; } set { _shininess = value; SignalPropertyChange(); } }
        
        [Category("Light")]
        public LightType LightType { get { return (LightType)(_flags2 & 3); } set { _flags2 = (ushort)((_flags2 & 60) | ((ushort)value & 3)); SignalPropertyChange(); } }
        [Category("Light")]
        public UsageFlags UsageFlags { get { return (UsageFlags)(_flags2 >> 2); } set { _flags2 = (ushort)((_flags2 & 3) | ((ushort)((ushort)value << 2) & 60)); SignalPropertyChange(); } }
        
        [Category("Light")]
        public bool[] LightEnabled { get { return _enabled.ToArray(); } set { _enabled = value.ToList<bool>(); SignalPropertyChange(); } }

        [Category("Light")]
        public RGBAPixel[] LightColor { get { return _lightColor.ToArray(); } set { _lightColor = value.ToList<RGBAPixel>(); SignalPropertyChange(); } }
        
        [Category("Light Start Points")]
        public List<SCN0Keyframe> XStartPoints { get { return xStarts; } set { xStarts = value; SignalPropertyChange(); } }
        [Category("Light Start Points")]
        public List<SCN0Keyframe> YStartPoints { get { return yStarts; } set { yStarts = value; SignalPropertyChange(); } }
        [Category("Light Start Points")]
        public List<SCN0Keyframe> ZStartPoints { get { return zStarts; } set { zStarts = value; SignalPropertyChange(); } }
        
        [Category("Light End Points")]
        public List<SCN0Keyframe> XEndPoints { get { return xEnds; } set { xEnds = value; SignalPropertyChange(); } }
        [Category("Light End Points")]
        public List<SCN0Keyframe> YEndPoints { get { return yEnds; } set { yEnds = value; SignalPropertyChange(); } }
        [Category("Light End Points")]
        public List<SCN0Keyframe> ZEndPoints { get { return zEnds; } set { zEnds = value; SignalPropertyChange(); } }
        
        [Category("SourceLight")]
        public DistAttnFn DistanceFunction { get { return (DistAttnFn)_distFunc; } set { _distFunc = (int)value; SignalPropertyChange(); } }
        [Category("SourceLight")]
        public List<SCN0Keyframe> RefDistance { get { return _refDist; } set { _refDist = value; SignalPropertyChange(); } }
        [Category("SourceLight")]
        public List<SCN0Keyframe> RefBrightness { get { return _refBrightness; } set { _refBrightness = value; SignalPropertyChange(); } }
        
        [Category("Spotlight")]
        public SpotFn SpotFunction { get { return (SpotFn)_spotFunc; } set { _spotFunc = (int)value; SignalPropertyChange(); } }
        [Category("Spotlight")]
        public List<SCN0Keyframe> Cutoff { get { return _cutoff; } set { _cutoff = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _nonSpecLightId = Data->_nonSpecLightId;
            _part2Offset = Data->_part2Offset;
            _flags1 = Data->_fixedFlags;
            _flags2 = Data->_usageFlags;
            _enableOffset = Data->_visOffset;
            _distFunc = Data->_distFunc;
            _spotFunc = Data->_spotFunc;

            _enabled = new List<bool>();
            _lightColor = new List<RGBAPixel>();
            _specColor = new List<RGBAPixel>();
            xEnds = new List<SCN0Keyframe>();
            yEnds = new List<SCN0Keyframe>();
            zEnds = new List<SCN0Keyframe>();
            xStarts = new List<SCN0Keyframe>();
            yStarts = new List<SCN0Keyframe>();
            zStarts = new List<SCN0Keyframe>();
            _refDist = new List<SCN0Keyframe>();
            _refBrightness = new List<SCN0Keyframe>();
            _cutoff = new List<SCN0Keyframe>();
            _shininess = new List<SCN0Keyframe>();

            if (((FixedFlags)_flags1).HasFlag(FixedFlags.ShininessConstant))
                _shininess.Add(new Vector3(0, 0, Data->_shininess));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->shininessKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _shininess.Add(*addr++);
                }
            }

            if (((FixedFlags)_flags1).HasFlag(FixedFlags.CutoffConstant))
                _cutoff.Add(new Vector3(0, 0, Data->_cutoff));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->cutoffKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _cutoff.Add(*addr++);
                }
            }

            if (((FixedFlags)_flags1).HasFlag(FixedFlags.RefBrightnessConstant))
                _refBrightness.Add(new Vector3(0, 0, Data->_refBrightness));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->refBrightnessKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _refBrightness.Add(*addr++);
                }
            }

            if (((FixedFlags)_flags1).HasFlag(FixedFlags.RefDistanceConstant))
                _refDist.Add(new Vector3(0, 0, Data->_refDistance));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->refDistanceKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _refDist.Add(*addr++);
                }
            }

            if (((FixedFlags)_flags1).HasFlag(FixedFlags.EndXConstant))
                xEnds.Add(new Vector3(0, 0, Data->_endPoint._x));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->xEndKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        xEnds.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.EndYConstant))
                yEnds.Add(new Vector3(0, 0, Data->_endPoint._y));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->yEndKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        yEnds.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.EndZConstant))
                zEnds.Add(new Vector3(0, 0, Data->_endPoint._z));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->zEndKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        zEnds.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.ColorConstant))
                _lightColor.Add(Data->_lightColor);
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    RGBAPixel* addr = Data->lightColorEntries;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        _lightColor.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.StartXConstant))
                xStarts.Add(new Vector3(0, 0, Data->_startPoint._x));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->xStartKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        xStarts.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.StartYConstant))
                yStarts.Add(new Vector3(0, 0, Data->_startPoint._y));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->yStartKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        yStarts.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.StartZConstant))
                zStarts.Add(new Vector3(0, 0, Data->_startPoint._z));
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    SCN0KeyframesHeader* keysHeader = Data->zStartKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        zStarts.Add(*addr++);
                }
            }
            if (((FixedFlags)_flags1).HasFlag(FixedFlags.SpecColorConstant))
                _specColor.Add(Data->_specularColor);
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    RGBAPixel* addr = Data->specColorEntries;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        _specColor.Add(*addr++);
                }
            }
            if (!((FixedFlags)_flags1).HasFlag(FixedFlags.EnabledConstant))
            {
                if (Name != "<null>" && !_replaced)
                {
                    byte* addr = Data->visBitEntries;
                    int index = -1;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        _enabled.Add(((addr[(i % 8 == 0 ? ++index : index)] >> (7 - (i & 7))) & 1) != 0);
                }
            }
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            lightLen = 0;
            keyLen = 0;
            if (_name != "<null>")
            {
                if (_enabled.Count > 1)
                    lightLen += ((((SCN0Node)Parent.Parent).FrameCount + 1).Align(32) / 8);
                if (_lightColor.Count > 1)
                    lightLen += 4 * (((SCN0Node)Parent.Parent).FrameCount + 1);
                if (_specColor.Count > 1)
                    lightLen += 4 * (((SCN0Node)Parent.Parent).FrameCount + 1);
                if (xStarts.Count > 1)
                    keyLen += 4 + xStarts.Count * 12;
                if (yStarts.Count > 1)
                    keyLen += 4 + yStarts.Count * 12;
                if (zStarts.Count > 1)
                    keyLen += 4 + zStarts.Count * 12;
                if (xEnds.Count > 1)
                    keyLen += 4 + xEnds.Count * 12;
                if (yEnds.Count > 1)
                    keyLen += 4 + yEnds.Count * 12;
                if (zEnds.Count > 1)
                    keyLen += 4 + zEnds.Count * 12;
                if (_refDist.Count > 1)
                    keyLen += 4 + _refDist.Count * 12;
                if (_refBrightness.Count > 1)
                    keyLen += 4 + _refBrightness.Count * 12;
                if (_cutoff.Count > 1)
                    keyLen += 4 + _cutoff.Count * 12;
                if (_shininess.Count > 1)
                    keyLen += 4 + _shininess.Count * 12;
            }
            return SCN0Light.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0Light* header = (SCN0Light*)address;

            if (_name != "<null>")
            {
                header->_nonSpecLightId = _nonSpecLightId;
                header->_part2Offset = _part2Offset;
                header->_visOffset = _enableOffset;
                header->_distFunc = _distFunc;
                header->_spotFunc = _spotFunc;

                FixedFlags newFlags = new FixedFlags();
                if (_shininess.Count > 1)
                {
                    *((bint*)header->_shininess.Address) = (int)keyframeAddr - (int)header->_shininess.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_shininess.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < _shininess.Count; i++)
                        *addr++ = _shininess[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.ShininessConstant;
                    if (_shininess.Count == 1)
                        header->_shininess = _shininess[0]._value;
                    else
                        header->_shininess = 0;
                }
                if (_cutoff.Count > 1)
                {
                    *((bint*)header->_cutoff.Address) = (int)keyframeAddr - (int)header->_cutoff.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_cutoff.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < _cutoff.Count; i++)
                        *addr++ = _cutoff[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.CutoffConstant;
                    if (_cutoff.Count == 1)
                        header->_cutoff = _cutoff[0]._value;
                    else
                        header->_cutoff = 0;
                }
                if (_refBrightness.Count > 1)
                {
                    *((bint*)header->_refBrightness.Address) = (int)keyframeAddr - (int)header->_refBrightness.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_refBrightness.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < _refBrightness.Count; i++)
                        *addr++ = _refBrightness[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.RefBrightnessConstant;
                    if (_refBrightness.Count == 1)
                        header->_refBrightness = _refBrightness[0]._value;
                    else
                        header->_refBrightness = 0;
                }
                if (_refDist.Count > 1)
                {
                    *((bint*)header->_refDistance.Address) = (int)keyframeAddr - (int)header->_refDistance.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_refDist.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < _refDist.Count; i++)
                        *addr++ = _refDist[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.RefDistanceConstant;
                    if (_refDist.Count == 1)
                        header->_refDistance = _refDist[0]._value;
                    else
                        header->_refDistance = 0;
                }
                if (_lightColor.Count > 1)
                {
                    *((bint*)header->_lightColor.Address) = (int)lightAddr - (int)header->_lightColor.Address;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        if (i < _lightColor.Count)
                            *lightAddr++ = _lightColor[i];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else
                {
                    newFlags |= FixedFlags.ColorConstant;
                    if (_lightColor.Count == 1)
                        header->_lightColor = _lightColor[0];
                    else
                        header->_lightColor = new RGBAPixel();
                }
                if (_specColor.Count > 1)
                {
                    *((bint*)header->_specularColor.Address) = (int)lightAddr - (int)header->_specularColor.Address;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        if (i < _specColor.Count)
                            *lightAddr++ = _specColor[i];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else
                {
                    newFlags |= FixedFlags.SpecColorConstant;
                    if (_specColor.Count == 1)
                        header->_specularColor = _specColor[0];
                    else
                        header->_specularColor = new RGBAPixel();
                }
                if (_enabled.Count > 1)
                {
                    header->_visOffset = (int)lightAddr - (int)header->_visOffset.Address;
                    byte* addr = (byte*)lightAddr;
                    int index = -1;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        addr[(i % 8 == 0 ? ++index : index)] |= (byte)((i < _enabled.Count ? (_enabled[i] ? 1 : 0) : 0) << (7 - (i & 7)));
                    addr += ((((SCN0Node)Parent.Parent).FrameCount + 1).Align(32) / 8); //Align pointer
                    lightAddr = (RGBAPixel*)addr;
                }
                else
                    newFlags |= FixedFlags.EnabledConstant;
                if (xEnds.Count > 1)
                {
                    *((bint*)header->_endPoint._x.Address) = (int)keyframeAddr - (int)header->_endPoint._x.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)xEnds.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < xEnds.Count; i++)
                        *addr++ = xEnds[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.EndXConstant;
                    if (xEnds.Count == 1)
                        header->_endPoint._x = xEnds[0]._value;
                    else
                        header->_endPoint._x = 0;
                }
                if (yEnds.Count > 1)
                {
                    *((bint*)header->_endPoint._y.Address) = (int)keyframeAddr - (int)header->_endPoint._y.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)yEnds.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < yEnds.Count; i++)
                        *addr++ = yEnds[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.EndYConstant;
                    if (yEnds.Count == 1)
                        header->_endPoint._y = yEnds[0]._value;
                    else
                        header->_endPoint._y = 0;
                }
                if (zEnds.Count > 1)
                {
                    *((bint*)header->_endPoint._z.Address) = (int)keyframeAddr - (int)header->_endPoint._z.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)zEnds.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < zEnds.Count; i++)
                        *addr++ = zEnds[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.EndZConstant;
                    if (zEnds.Count == 1)
                        header->_endPoint._z = zEnds[0]._value;
                    else
                        header->_endPoint._z = 0;
                }
                if (xStarts.Count > 1)
                {
                    *((bint*)header->_startPoint._x.Address) = (int)keyframeAddr - (int)header->_startPoint._x.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)xStarts.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < xStarts.Count; i++)
                        *addr++ = xStarts[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.StartXConstant;
                    if (xStarts.Count == 1)
                        header->_startPoint._x = xStarts[0]._value;
                    else
                        header->_startPoint._x = 0;
                }
                if (yStarts.Count > 1)
                {
                    *((bint*)header->_startPoint._y.Address) = (int)keyframeAddr - (int)header->_startPoint._y.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)yStarts.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < yStarts.Count; i++)
                        *addr++ = yStarts[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.StartYConstant;
                    if (yStarts.Count == 1)
                        header->_startPoint._y = yStarts[0]._value;
                    else
                        header->_startPoint._y = 0;
                }
                if (zStarts.Count > 1)
                {
                    *((bint*)header->_startPoint._z.Address) = (int)keyframeAddr - (int)header->_startPoint._z.Address;
                    ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)zStarts.Count;
                    SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                    for (int i = 0; i < zStarts.Count; i++)
                        *addr++ = zStarts[i];
                    keyframeAddr = addr;
                }
                else
                {
                    newFlags |= FixedFlags.StartZConstant;
                    if (zStarts.Count == 1)
                        header->_startPoint._z = zStarts[0]._value;
                    else
                        header->_startPoint._z = 0;
                }

                header->_fixedFlags = this._flags1 = (ushort)newFlags;
                header->_usageFlags = this._flags2;
            }
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }
    }
}
