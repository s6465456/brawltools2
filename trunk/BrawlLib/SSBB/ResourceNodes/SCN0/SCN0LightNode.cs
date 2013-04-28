using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;
using BrawlLib.Wii.Graphics;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Animations;

namespace BrawlLib.SSBB.ResourceNodes
{
    public interface IBoolArrayNode
    {
        int EntryCount { get; set; }
        void SetEntry(int index, bool value);
        bool GetEntry(int index);
        void MakeAnimated();
        void MakeConstant(bool value);
    }

    public interface ISCN0KeyframeHolder
    {
        KeyframeArray GetKeys(int i);
        void SetKeys(int i, KeyframeArray value);
    }

    public unsafe class SCN0LightNode : SCN0EntryNode, IBoolArrayNode, IColorSource, ISCN0KeyframeHolder
    {
        internal SCN0Light* Data { get { return (SCN0Light*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        internal int _nonSpecLightId, _part2Offset, _enableOffset, _distFunc, _spotFunc;
        internal ushort _flags1 = 0xFFF8, _flags2 = 0x35;

        internal byte[] _data = new byte[0];
        internal int _entryCount;

        private List<RGBAPixel> _lightColor = new List<RGBAPixel>(), _specColor = new List<RGBAPixel>();
        public int[] _numEntries = new int[] { 0, 0 };
        public RGBAPixel[] _solidColors =  new RGBAPixel[2];
        public List<RGBAPixel> GetColors(int i)
        {
            switch (i)
            {
                case 0: return _lightColor;
                case 1: return _specColor;
            }
            return null;
        }

        public void SetColors(int i, List<RGBAPixel> value)
        {
            switch (i)
            {
                case 0: _lightColor = value; break;
                case 1: _specColor = value; break;
            }
        }

        #region IColorSource Members

        public bool HasPrimary(int id) { return false; }
        public ARGBPixel GetPrimaryColor(int id) { return new ARGBPixel(); }
        public void SetPrimaryColor(int id, ARGBPixel color) { }
        [Browsable(false)]
        public string PrimaryColorName(int id) { return null; }
        [Browsable(false)]
        public int ColorCount(int id) { return (_numEntries[id] == 0) ? 1 : _numEntries[id]; }
        public ARGBPixel GetColor(int index, int id) { return (_numEntries[id] == 0) ? (ARGBPixel)_solidColors[id] : (ARGBPixel)GetColors(id)[index]; }
        public void SetColor(int index, int id, ARGBPixel color)
        {
            if (_numEntries[id] == 0)
                _solidColors[id] = (RGBAPixel)color;
            else
                GetColors(id)[index] = (RGBAPixel)color;
            SignalPropertyChange();
        }

        #endregion

        #region IBoolArrayNode Members

        [Browsable(false)]
        public int EntryCount
        {
            get { return _entryCount; }
            set
            {
                if (_entryCount == 0)
                    return;

                _entryCount = value;
                int len = value.Align(32) / 8;

                if (_data.Length < len)
                {
                    byte[] newArr = new byte[len];
                    Array.Copy(_data, newArr, _data.Length);
                    _data = newArr;
                }
                SignalPropertyChange();
            }
        }

        public bool GetEntry(int index)
        {
            int i = index >> 3;
            int bit = 1 << (7 - (index & 0x7));
            return (_data[i] & bit) != 0;
        }
        public void SetEntry(int index, bool value)
        {
            int i = index >> 3;
            int bit = 1 << (7 - (index & 0x7));
            int mask = ~bit;
            _data[i] = (byte)((_data[i] & mask) | (value ? bit : 0));
            SignalPropertyChange();
        }

        public void MakeConstant(bool value)
        {
            SetConstant = true;
            SetEnabled = value;
            _entryCount = 0;

            SignalPropertyChange();
        }
        public void MakeAnimated()
        {
            bool enabled = SetEnabled;

            SetConstant = false;
            SetEnabled = false;

            _entryCount = -1;
            EntryCount = FrameCount + 1;

            if (enabled)
                for (int i = 0; i < _entryCount; i++)
                    SetEntry(i, true);

            SignalPropertyChange();
        }

#endregion

        [Browsable(false)]
        public FixedFlags flags { get { return (FixedFlags)_flags1; } set { _flags1 = (ushort)value; } }

        public bool[] _constants = new bool[] { true, true };

        [Category("Light Colors")]
        public bool ConstantColor
        {
            get { return _constants[0]; }
            set
            {
                if (_constants[0] != value)
                {
                    _constants[0] = value;
                    if (_constants[0])
                        MakeSolid(new ARGBPixel(), 0);
                    else
                        MakeList(0);

                    UpdateCurrentControl();
                }
            }
        }
        [Category("Light Colors")]
        public bool ConstantSpecular
        {
            get { return _constants[1]; }
            set
            {
                if (_constants[1] != value)
                {
                    _constants[1] = value;
                    if (_constants[1])
                        MakeSolid(new ARGBPixel(), 1);
                    else
                        MakeList(1);

                    UpdateCurrentControl();
                }
            }
        }

        public void MakeSolid(ARGBPixel color, int id)
        {
            _numEntries[id] = 0;
            _constants[id] = true;
            _solidColors[id] = (RGBAPixel)color;
            SignalPropertyChange();
        }
        public void MakeList(int id)
        {
            _constants[id] = false;
            int entries = ((SCN0Node)Parent._parent).FrameCount + 1;
            _numEntries[id] = GetColors(id).Count;
            SetNumEntries(id, entries);
        }

        [Browsable(false)]
        internal void SetNumEntries(int id, int value)
        {
            //if (_numEntries[id] == 0)
            //    return;

            if (value > _numEntries[id])
            {
                ARGBPixel p = _numEntries[id] > 0 ? (ARGBPixel)GetColors(id)[_numEntries[id] - 1] : new ARGBPixel(255, 0, 0, 0);
                for (int i = value - _numEntries[id]; i-- > 0; )
                    GetColors(id).Add((RGBAPixel)p);
            }
            else if (value < GetColors(id).Count)
                GetColors(id).RemoveRange(value, GetColors(id).Count - value);

            _numEntries[id] = value;
        }

        [Category("Light Enable")]
        public bool Constant
        {
            get { return SetConstant; }
            set
            {
                if (value != SetConstant)
                {
                    if (value)
                        MakeConstant(true);
                    else
                        MakeAnimated();

                    UpdateCurrentControl();
                }
            }
        }
        [Category("Light Enable")]
        public bool Enabled
        {
            get { return SetEnabled; }
            set { SetEnabled = value; SignalPropertyChange(); }
        }
        
        [Browsable(false)]
        public bool SetConstant
        {
            get { return flags.HasFlag(FixedFlags.EnabledConstant); }
            set
            {
                if (value) 
                    flags |= FixedFlags.EnabledConstant;
                else 
                    flags &= ~FixedFlags.EnabledConstant;
            }
        }

        [Browsable(false)]
        public bool SetEnabled
        {
            get { return ((_flags2 >> 2) & 1) != 0; }
            set { _flags2 = (ushort)((_flags2 & 0x3B) | ((ushort)((value ? 1 : 0) << 2) & 4)); }
        }

        public KeyframeArray
            _startX = new KeyframeArray(0),
            _startY = new KeyframeArray(0),
            _startZ = new KeyframeArray(0),
            _endX = new KeyframeArray(0),
            _endY = new KeyframeArray(0),
            _endZ = new KeyframeArray(0),
            _spotCut = new KeyframeArray(0),
            _spotBright = new KeyframeArray(0),
            _refDist = new KeyframeArray(0),
            _refBright = new KeyframeArray(0);

        public KeyframeArray GetKeys(int i)
        {
            switch (i)
            {
                case 0: return _startX;
                case 1: return _startY;
                case 2: return _startZ;
                case 3: return _endX;
                case 4: return _endY;
                case 5: return _endZ;
                case 6: return _refDist;
                case 7: return _refBright;
                case 8: return _spotCut;
                case 9: return _spotBright;
            }
            return null;
        }

        public void SetKeys(int i, KeyframeArray value)
        {
            switch (i)
            {
                case 0: _startX = value; break;
                case 1: _startY = value; break;
                case 2: _startZ = value; break;
                case 3: _endX = value; break;
                case 4: _endY = value; break;
                case 5: _endZ = value; break;
                case 6: _refDist = value; break;
                case 7: _refBright = value; break;
                case 8: _spotCut = value; break;
                case 9: _spotBright = value; break;
            }
        }

        public FixedFlags[] Ordered = new FixedFlags[] 
        { 
            FixedFlags.StartXConstant,
            FixedFlags.StartYConstant,
            FixedFlags.StartZConstant,
            FixedFlags.EndXConstant,
            FixedFlags.EndYConstant,
            FixedFlags.EndZConstant,
            FixedFlags.RefDistanceConstant,
            FixedFlags.RefBrightnessConstant,
            FixedFlags.CutoffConstant,
            FixedFlags.ShininessConstant,
        };

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
        
        [Category("SCN0 Entry")]
        public int NonSpecularLightID 
        { 
            get
            {
                if (!SpecularEnabled) 
                    return 0;
                int i = 0; 
                foreach (SCN0LightNode n in Parent.Children) 
                {
                    if (n.Index == Index)
                        return Parent.Children.Count + i;
                    if (n.SpecularEnabled && n.Index != Index)
                        i++;
                }
                return 0;
            } 
        }

        [Category("Light")]
        public LightType LightType { get { return (LightType)(_flags2 & 3); } set { _flags2 = (ushort)((_flags2 & 60) | ((ushort)value & 3)); SignalPropertyChange(); } }
        
        [Browsable(false)]
        public UsageFlags UsageFlags { get { return (UsageFlags)((_flags2 >> 2) & 0xE); } set { _flags2 = (ushort)((_flags2 & 7) | ((ushort)((ushort)value << 2) & 56)); SignalPropertyChange(); } }

        [Category("Light")]
        public bool ColorEnabled
        {
            get { return UsageFlags.HasFlag(UsageFlags.ColorEnabled); }
            set
            {
                if (value)
                    UsageFlags |= UsageFlags.ColorEnabled;
                else
                    UsageFlags &= ~UsageFlags.ColorEnabled;
                SignalPropertyChange();
            }
        }
        [Category("Light")]
        public bool AlphaEnabled
        {
            get { return UsageFlags.HasFlag(UsageFlags.AlphaEnabled); }
            set
            {
                if (value)
                    UsageFlags |= UsageFlags.AlphaEnabled;
                else
                    UsageFlags &= ~UsageFlags.AlphaEnabled; 
                SignalPropertyChange();
            }
        }
        [Category("Light")]
        public bool SpecularEnabled
        {
            get { return UsageFlags.HasFlag(UsageFlags.SpecularEnabled); }
            set
            {
                if (value)
                    UsageFlags |= UsageFlags.SpecularEnabled;
                else
                    UsageFlags &= ~UsageFlags.SpecularEnabled;
                SignalPropertyChange();
            }
        }

        [Category("Source Light")]
        public DistAttnFn DistanceFunction { get { return (DistAttnFn)_distFunc; } set { _distFunc = (int)value; SignalPropertyChange(); } }

        [Category("Spotlight")]
        public SpotFn SpotFunction { get { return (SpotFn)_spotFunc; } set { _spotFunc = (int)value; SignalPropertyChange(); } }

        [Browsable(false)]
        internal int FrameCount 
        {
            get 
            {
                return ((SCN0Node)Parent.Parent).FrameCount; 
            }
            set
            {
                int x = value + 1;
                SetNumEntries(0, x);
                SetNumEntries(1, x);
            }
        }

        public Vector3 GetStart(int frame)
        {
            return new Vector3(
                _startX.GetFrameValue(frame),
                _startY.GetFrameValue(frame),
                _startZ.GetFrameValue(frame));
        }

        public Vector3 GetEnd(int frame)
        {
            return new Vector3(
                _endX.GetFrameValue(frame),
                _endY.GetFrameValue(frame),
                _endZ.GetFrameValue(frame));
        }

        //  Description:  Convenience function to set spotlight parameters.
        //
        //  Arguments:    light         HW light ID.
        //                cutoff        Cut off angle.
        //                spot_func     Spot function characteristics.
        public Vector3 GetLightSpot(int frame)
        {
            float a0, a1, a2, r, d, cr;

            SpotFn spot_func = SpotFunction;
            float cutoff = _spotCut.GetFrameValue(frame);

            if (cutoff <= 0.0F || cutoff > 90.0F)
                spot_func = SpotFn.Off;

            r = cutoff * Maths._pif / 180.0F;
            cr = (float)Math.Cos(r);

            switch (spot_func)
            {
                case SpotFn.Flat:
                    a0 = -1000.0F * cr;
                    a1 = 1000.0F;
                    a2 = 0.0F;
                    break;
                case SpotFn.Cos:
                    a0 = -cr / (1.0F - cr);
                    a1 = 1.0F / (1.0F - cr);
                    a2 = 0.0F;
                    break;
                case SpotFn.Cos2:
                    a0 = 0.0F;
                    a1 = -cr / (1.0F - cr);
                    a2 = 1.0F / (1.0F - cr);
                    break;
                case SpotFn.Sharp:
                    d = (1.0F - cr) * (1.0F - cr);
                    a0 = cr * (cr - 2.0F) / d;
                    a1 = 2.0F / d;
                    a2 = -1.0F / d;
                    break;
                case SpotFn.Ring:
                    d = (1.0F - cr) * (1.0F - cr);
                    a0 = -4.0F * cr / d;
                    a1 = 4.0F * (1.0F + cr) / d;
                    a2 = -4.0F / d;
                    break;
                case SpotFn.Ring2:
                    d = (1.0F - cr) * (1.0F - cr);
                    a0 = 1.0F - 2.0F * cr * cr / d;
                    a1 = 4.0F * cr / d;
                    a2 = -2.0F / d;
                    break;
                case SpotFn.Off:
                default:
                    a0 = 1.0F;
                    a1 = 0.0F;
                    a2 = 0.0F;
                    break;
            }

            return new Vector3(a0, a1, a2);
        }

        //  Description:  Convenience function for setting distance attenuation.
        //
        //  Arguments:    light         HW light ID.
        //                ref_dist      Reference distance.
        //                ref_br        Reference brightness.
        //                dist_func     Attenuation characteristics.
        public Vector3 GetLightDistAttn(int frame)
        {
            float k0, k1, k2;

            float ref_dist = _refDist.GetFrameValue(frame);
            float ref_br = _refBright.GetFrameValue(frame);
            DistAttnFn dist_func = DistanceFunction;

            if (ref_dist < 0.0F || ref_br <= 0.0F || ref_br >= 1.0F)
                dist_func = DistAttnFn.Off;

            switch (dist_func)
            {
                case DistAttnFn.Gentle:
                    k0 = 1.0F;
                    k1 = (1.0F - ref_br) / (ref_br * ref_dist);
                    k2 = 0.0F;
                    break;
                case DistAttnFn.Medium:
                    k0 = 1.0F;
                    k1 = 0.5F * (1.0f - ref_br) / (ref_br * ref_dist);
                    k2 = 0.5F * (1.0f - ref_br) / (ref_br * ref_dist * ref_dist);
                    break;
                case DistAttnFn.Steep:
                    k0 = 1.0F;
                    k1 = 0.0F;
                    k2 = (1.0F - ref_br) / (ref_br * ref_dist * ref_dist);
                    break;
                case DistAttnFn.Off:
                default:
                    k0 = 1.0F;
                    k1 = 0.0F;
                    k2 = 0.0F;
                    break;
            }

            return new Vector3(k0, k1, k2);
        }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _numEntries = new int[] { 0, 0 };
            _solidColors =  new RGBAPixel[2];
            _constants = new bool[] { true, true };

            _nonSpecLightId = Data->_nonSpecLightId;
            _part2Offset = Data->_part2Offset;
            _flags1 = Data->_fixedFlags;
            _flags2 = Data->_usageFlags;
            _enableOffset = Data->_visOffset;
            _distFunc = Data->_distFunc;
            _spotFunc = Data->_spotFunc;

            //_enabled = new List<bool>();
            for (int x = 0; x < 10; x++)
                SetKeys(x, new KeyframeArray(FrameCount + 1));

            FixedFlags flags = (FixedFlags)_flags1;

            if (Name == "<null>")
                return false;

            if (!flags.HasFlag(FixedFlags.EnabledConstant))
            {
                _entryCount = FrameCount + 1;
                int numBytes = _entryCount.Align(32) / 8;

                _data = new byte[numBytes];
                Marshal.Copy((IntPtr)Data->visBitEntries, _data, 0, numBytes);

                //byte* addr = Data->visBitEntries;
                //int index = -1;
                //for (int x = 0; x <= FrameCount; x++) //Read each bit, progress in bytes
                //    _enabled.Add(((addr[(x % 8 == 0 ? ++index : index)] >> (7 - (x & 7))) & 1) != 0);
            }
            else
            {
                _entryCount = 0;
                _data = new byte[0];
            }

            if (flags.HasFlag(FixedFlags.ColorConstant))
                _solidColors[0] = Data->_lightColor;
            else
            {
                _constants[0] = false;
                _numEntries[0] = FrameCount + 1;
                RGBAPixel* addr = Data->lightColorEntries;
                for (int x = 0; x <= FrameCount; x++)
                    _lightColor.Add(*addr++);
            }
            if (flags.HasFlag(FixedFlags.SpecColorConstant))
                _solidColors[1] = Data->_specularColor;
            else
            {
                _constants[1] = false;
                _numEntries[1] = FrameCount + 1;
                RGBAPixel* addr = Data->specColorEntries;
                for (int x = 0; x <= FrameCount; x++)
                    _specColor.Add(*addr++);
            }

            bint* values = (bint*)&Data->_startPoint;

            int index = 0;
            for (int i = 0; i < 14; i++)
                if (!(i == 3 || i == 7 || i == 10 || i == 12))
                    DecodeFrames(GetKeys(index), &values[i], (int)_flags1, (int)Ordered[index++]);

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            lightLen = 0;
            keyLen = 0;
            if (_name != "<null>")
            {
                if (!SetConstant)
                    lightLen += _entryCount.Align(32) / 8;
                if (!_constants[0])
                    lightLen += 4 * (FrameCount + 1);
                if (!_constants[1])
                    lightLen += 4 * (FrameCount + 1);
                for (int i = 0; i < 10; i++)
                    if (GetKeys(i)._keyCount > 1)
                        keyLen += 4 + GetKeys(i)._keyCount * 12;
            }

            if (UsageFlags.HasFlag(UsageFlags.SpecularEnabled))
                ((SCN0Node)Parent.Parent)._specLights++;

            return SCN0Light.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0Light* header = (SCN0Light*)address;

            if (_name != "<null>")
            {
                header->_nonSpecLightId = NonSpecularLightID;
                header->_part2Offset = _part2Offset;
                header->_visOffset = _enableOffset;
                header->_distFunc = _distFunc;
                header->_spotFunc = _spotFunc;

                int newFlags = 0;

                if (_lightColor.Count > 1)
                {
                    *((bint*)header->_lightColor.Address) = (int)lightAddr - (int)header->_lightColor.Address;
                    for (int x = 0; x <= FrameCount; x++)
                        if (x < _lightColor.Count)
                            *lightAddr++ = _lightColor[x];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else
                {
                    newFlags |= (int)FixedFlags.ColorConstant;
                    header->_lightColor = _solidColors[0];
                }
                if (_specColor.Count > 1)
                {
                    *((bint*)header->_specularColor.Address) = (int)lightAddr - (int)header->_specularColor.Address;
                    for (int x = 0; x <= FrameCount; x++)
                        if (x < _specColor.Count)
                            *lightAddr++ = _specColor[x];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else
                {
                    newFlags |= (int)FixedFlags.SpecColorConstant;
                    header->_specularColor = _solidColors[1];
                }
                //if (_enabled.Count > 1)
                if (!SetConstant && _entryCount != 0)
                {
                    header->_visOffset = (int)lightAddr - (int)header->_visOffset.Address;
                    Marshal.Copy(_data, 0, (IntPtr)lightAddr, _data.Length);
                    //byte* addr = (byte*)lightAddr;
                    //int index = -1;
                    //for (int x = 0; x <= FrameCount; x++)
                    //    addr[(x % 8 == 0 ? ++index : index)] |= (byte)((x < _enabled.Count ? (_enabled[x] ? 1 : 0) : 0) << (7 - (x & 7)));
                    //addr += ((FrameCount + 1).Align(32) / 8); //Align pointer
                    lightAddr = (RGBAPixel*)((VoidPtr)lightAddr + EntryCount.Align(32) / 8);
                }
                else
                    newFlags |= (int)FixedFlags.EnabledConstant;

                bint* values = (bint*)&header->_startPoint;
                int index = 0;
                for (int i = 0; i < 14; i++)
                    if (!(i == 3 || i == 7 || i == 10 || i == 12))
                        EncodeFrames(GetKeys(index), ref keyframeAddr, &values[i], ref newFlags, (int)Ordered[index++]);

                header->_fixedFlags = _flags1 = (ushort)newFlags;
                header->_usageFlags = _flags2;
            }
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }

        internal LightAnimationFrame GetAnimFrame(int index)
        {
            LightAnimationFrame frame;
            float* dPtr = (float*)&frame;
            for (int x = 0; x < 10; x++)
                *dPtr++ = GetKeys(x).GetFrameValue(index);

            //if (((FixedFlags)_flags1).HasFlag(FixedFlags.EnabledConstant))
            //    frame.Enabled = UsageFlags.HasFlag(UsageFlags.Enabled);
            //else
            //    frame.Enabled = index < _enabled.Count ? _enabled[index] : false;

            return frame;
        }

        internal float GetFrameValue(LightKeyframeMode keyFrameMode, int index)
        {
            return GetKeys((int)keyFrameMode - 0x10).GetFrameValue(index);
        }

        internal KeyframeEntry GetKeyframe(LightKeyframeMode keyFrameMode, int index)
        {
            return GetKeys((int)keyFrameMode - 0x10).GetKeyframe(index);
        }

        internal void RemoveKeyframe(LightKeyframeMode keyFrameMode, int index)
        {
            KeyframeEntry k = GetKeys((int)keyFrameMode - 0x10).Remove(index);
            if (k != null)
            {
                k._prev.GenerateTangent();
                k._next.GenerateTangent();
                SignalPropertyChange();
            }
        }
        
        internal void SetKeyframe(LightKeyframeMode keyFrameMode, int index, float value)
        {
            KeyframeEntry k = GetKeys((int)keyFrameMode - 0x10).SetFrameValue(index, value);
            k.GenerateTangent();
            k._prev.GenerateTangent();
            k._next.GenerateTangent();

            SignalPropertyChange();
        }
    }

    public enum LightKeyframeMode
    {
        StartX = 0x10,
        StartY = 0x11,
        StartZ = 0x12,
        EndX = 0x13,
        EndY = 0x14,
        EndZ = 0x15,
        SpotCut = 0x16,
        SpotBright = 0x17,
        RefDist = 0x18,
        RefBright = 0x19,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LightAnimationFrame
    {
        public static readonly LightAnimationFrame Empty = new LightAnimationFrame();

        public Vector3 Start;
        public Vector3 End;
        public float RefDist;
        public float RefBright;
        public float SpotCutoff;
        public float SpotBright;

        public bool Enabled;

        public bool hasSx;
        public bool hasSy;
        public bool hasSz;

        public bool hasEx;
        public bool hasEy;
        public bool hasEz;

        public bool hasSC;
        public bool hasSB;
        public bool hasRD;
        public bool hasRB;

        public bool forKF;

        public void SetBools(int index, bool val)
        {
            switch (index)
            {
                case 0: hasSx = val; break;
                case 1: hasSy = val; break;
                case 2: hasSz = val; break;
                case 3: hasEx = val; break;
                case 4: hasEy = val; break;
                case 5: hasEz = val; break;
                case 6: hasRD = val; break;
                case 7: hasRB = val; break;
                case 8: hasSC = val; break;
                case 9: hasSB = val; break;
            }
        }

        public void ResetBools()
        {
            hasEx = hasEy = hasEz =
            hasSx = hasSy = hasSz =
            hasSC = hasSB = hasRD = hasRB = false;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Start._x;
                    case 1: return Start._y;
                    case 2: return Start._z;
                    case 3: return End._x;
                    case 4: return End._y;
                    case 5: return End._z;
                    case 6: return RefDist;
                    case 7: return RefBright;
                    case 8: return SpotCutoff;
                    case 9: return SpotBright;
                    default: return float.NaN;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Start._x = value; break;
                    case 1: Start._y = value; break;
                    case 2: Start._z = value; break;
                    case 3: End._x = value; break;
                    case 4: End._y = value; break;
                    case 5: End._z = value; break;
                    case 6: RefDist = value; break;
                    case 7: RefBright = value; break;
                    case 8: SpotCutoff = value; break;
                    case 9: SpotBright = value; break;
                }
            }
        }

        public LightAnimationFrame(Vector3 start, Vector3 end, float sc, float sb, float rd, float rb, bool enabled)
        {
            Start = start;
            End = end;
            SpotCutoff = sc;
            SpotBright = sb;
            RefDist = rd;
            RefBright = rb;
            Enabled = enabled;
            Index = 0;
            hasSx = hasSy = hasSz = hasEx = hasEy = hasEz = hasSC = hasSB = hasRD = hasRB = false;
            forKF = true;
        }
        public int Index;
        const int len = 6;
        static string empty = new String('_', len);
        public override string ToString()
        {
            return String.Format("[{0}] Start=({1},{2},{3}), End=({4},{5},{6}), SC={7}, SB={8} RD={9}, RB={10}", Index + 1,
            !hasSx ? empty : Start._x.ToString().TruncateAndFill(len, ' '),
            !hasSy ? empty : Start._y.ToString().TruncateAndFill(len, ' '),
            !hasSz ? empty : Start._z.ToString().TruncateAndFill(len, ' '),
            !hasEx ? empty : End._x.ToString().TruncateAndFill(len, ' '),
            !hasEy ? empty : End._y.ToString().TruncateAndFill(len, ' '),
            !hasEz ? empty : End._z.ToString().TruncateAndFill(len, ' '),
            !hasSC ? empty : SpotCutoff.ToString().TruncateAndFill(len, ' '),
            !hasSB ? empty : SpotBright.ToString().TruncateAndFill(len, ' '),
            !hasRD ? empty : RefDist.ToString().TruncateAndFill(len, ' '),
            !hasRB ? empty : RefBright.ToString().TruncateAndFill(len, ' '));
        }
        //public override string ToString()
        //{
        //    return String.Format("{0}\r\n{1}\r\n{2}", Scale, Rotation, Translation);
        //}
    }
}
