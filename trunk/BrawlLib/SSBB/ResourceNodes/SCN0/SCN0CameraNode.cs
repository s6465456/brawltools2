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
    public unsafe class SCN0CameraNode : SCN0EntryNode, ISCN0KeyframeHolder
    {
        //Aim is a point in space which the camera looks at. Use lookat matrix / axis angle matrix
        //Rotate means the rotation of the camera
        //Ignore rotate if camera type is aim, vice versa

        internal SCN0Camera* Data { get { return (SCN0Camera*)WorkingUncompressed.Address; } }

        public SCN0CameraType _type = SCN0CameraType.Aim;
        public ProjectionType _projType;
        public SCN0CameraFlags _flags1 = (SCN0CameraFlags)0xFFFE;
        public ushort _flags2 = 1;

        public KeyframeArray _posX = new KeyframeArray(0), _posY = new KeyframeArray(0), _posZ = new KeyframeArray(0), _rotX = new KeyframeArray(0), _rotY = new KeyframeArray(0), _rotZ = new KeyframeArray(0), _aimX = new KeyframeArray(0), _aimY = new KeyframeArray(0), _aimZ = new KeyframeArray(0), _twist = new KeyframeArray(0), _fovY = new KeyframeArray(0), _height = new KeyframeArray(0), _aspect = new KeyframeArray(0), _nearZ = new KeyframeArray(0), _farZ = new KeyframeArray(0);

        public KeyframeArray GetKeys(int i)
        {
            switch (i)
            {
                case 0: return _posX;
                case 1: return _posY;
                case 2: return _posZ;
                case 3: return _rotX;
                case 4: return _rotY;
                case 5: return _rotZ;
                case 6: return _aimX;
                case 7: return _aimY;
                case 8: return _aimZ;
                case 9: return _twist;
                case 10: return _fovY;
                case 11: return _height;
                case 12: return _aspect;
                case 13: return _nearZ;
                case 14: return _farZ;
            }
            return null;
        }

        public void SetKeys(int i, KeyframeArray value)
        {
            switch (i)
            {
                case 0: _posX = value; break;
                case 1: _posY = value; break;
                case 2: _posZ = value; break;
                case 3: _rotX = value; break;
                case 4: _rotY = value; break;
                case 5: _rotZ = value; break;
                case 6: _aimX = value; break;
                case 7: _aimY = value; break;
                case 8: _aimZ = value; break;
                case 9: _twist = value; break;
                case 10: _fovY = value; break;
                case 11: _height = value; break;
                case 12: _aspect = value; break;
                case 13: _nearZ = value; break;
                case 14: _farZ = value; break;
            }
        }

        [Category("Camera")]
        public SCN0CameraType Type { get { return _type; } set { _type = value; SignalPropertyChange(); } }
        [Category("Camera")]
        public ProjectionType ProjectionType { get { return _projType; } set { _projType = value; SignalPropertyChange(); } }

        public Vector3 GetRotate(int frame)
        {
            if (Type == SCN0CameraType.Rotate)
                return new Vector3(
                    _rotX.GetFrameValue(frame),
                    _rotY.GetFrameValue(frame),
                    _rotZ.GetFrameValue(frame));
            else //Aim - calculate rotation facing the position
            {
                Vector3 aimPos = new Vector3(
                    _aimX.GetFrameValue(frame),
                    _aimY.GetFrameValue(frame),
                    _aimZ.GetFrameValue(frame));
                Vector3 pos = new Vector3(
                    _posX.GetFrameValue(frame),
                    _posY.GetFrameValue(frame),
                    _posZ.GetFrameValue(frame));
                Matrix m = Matrix.ReverseLookat(aimPos, pos, _twist.GetFrameValue(frame));
                Vector3 a = m.GetAngles();
                return new Vector3(-a._x, -a._y, -a._z);
            }
        }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _flags1 = (SCN0CameraFlags)(ushort)Data->_flags1;
            _flags2 = Data->_flags2;
            _type = (SCN0CameraType)((ushort)_flags2 & 1);
            _projType = (ProjectionType)(int)Data->_projType;

            for (int x = 0; x < 15; x++)
                SetKeys(x, new KeyframeArray(FrameCount + 1));

            int i = 0;
            if (_flags1.HasFlag(SCN0CameraFlags.PosXConstant))
                GetKeys(i)[0] = Data->_position._x;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->posXKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.PosYConstant))
                GetKeys(i)[0] = Data->_position._y;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->posYKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.PosZConstant))
                GetKeys(i)[0] = Data->_position._z;
            else if (Name != "<null>" && !_replaced)
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->posZKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.RotXConstant))
                GetKeys(i)[0] = Data->_rotate._x;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->rotXKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.RotYConstant))
                GetKeys(i)[0] = Data->_rotate._y;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->rotYKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.RotZConstant))
                GetKeys(i)[0] = Data->_rotate._z;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->rotZKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.AimXConstant))
                GetKeys(i)[0] = Data->_aim._x;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->aimXKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.AimYConstant))
                GetKeys(i)[0] = Data->_aim._y;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->aimYKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.AimZConstant))
                GetKeys(i)[0] = Data->_aim._z;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->aimZKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.TwistConstant))
                GetKeys(i)[0] = Data->_twist;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->twistKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.PerspFovYConstant))
                GetKeys(i)[0] = Data->_perspFovY;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->fovYKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.OrthoHeightConstant))
                GetKeys(i)[0] = Data->_orthoHeight;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->heightKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.AspectConstant))
                GetKeys(i)[0] = Data->_aspect;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->aspectKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.NearConstant))
                GetKeys(i)[0] = Data->_nearZ;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->nearZKeyframes);
            i++;
            if (_flags1.HasFlag(SCN0CameraFlags.FarConstant))
                GetKeys(i)[0] = Data->_farZ;
            else if (Name != "<null>")
                SCN0EntryNode.DecodeFrames(GetKeys(i), Data->farZKeyframes);

            _posX._linearRot = true;
            _posY._linearRot = true;
            _posZ._linearRot = true;

            _aimX._linearRot = true;
            _aimY._linearRot = true;
            _aimZ._linearRot = true;

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            lightLen = 0;
            keyLen = 0;
            if (_name != "<null>")
                for (int i = 0; i < 15; i++)
                    if (GetKeys(i)._keyCount > 1)
                        keyLen += 4 + GetKeys(i)._keyCount * 12;
            return SCN0Camera.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0Camera* header = (SCN0Camera*)address;

            header->_projType = (int)_projType;
            header->_flags2 = (ushort)(2 + (int)_type);
            header->_part2Offset = 0;

            SCN0CameraFlags newFlags1 = new SCN0CameraFlags();

            int i = 0;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_position._x.Address) = (int)keyframeAddr - (int)header->_position._x.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosXConstant;
                header->_position._x = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_position._y.Address) = (int)keyframeAddr - (int)header->_position._y.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosYConstant;
                header->_position._y = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_position._z.Address) = (int)keyframeAddr - (int)header->_position._z.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosZConstant;
                header->_position._z = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_rotate._x.Address) = (int)keyframeAddr - (int)header->_rotate._x.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotXConstant;
                header->_rotate._x = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_rotate._y.Address) = (int)keyframeAddr - (int)header->_rotate._y.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotYConstant;
                header->_rotate._y = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_rotate._z.Address) = (int)keyframeAddr - (int)header->_rotate._z.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotZConstant;
                header->_rotate._z = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_aim._x.Address) = (int)keyframeAddr - (int)header->_aim._x.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimXConstant;
                header->_aim._x = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_aim._y.Address) = (int)keyframeAddr - (int)header->_aim._y.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimYConstant;
                header->_aim._y = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_aim._z.Address) = (int)keyframeAddr - (int)header->_aim._z.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimZConstant;
                header->_aim._z = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_twist.Address) = (int)keyframeAddr - (int)header->_twist.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.TwistConstant;
                header->_twist = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_perspFovY.Address) = (int)keyframeAddr - (int)header->_perspFovY.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PerspFovYConstant;
                header->_perspFovY = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_orthoHeight.Address) = (int)keyframeAddr - (int)header->_orthoHeight.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.OrthoHeightConstant;
                header->_orthoHeight = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_aspect.Address) = (int)keyframeAddr - (int)header->_aspect.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AspectConstant;
                header->_aspect = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_nearZ.Address) = (int)keyframeAddr - (int)header->_nearZ.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.NearConstant;
                header->_nearZ = GetKeys(i)._keyRoot._next._value;
            }
            i++;
            if (GetKeys(i)._keyCount > 1)
            {
                *((bint*)header->_farZ.Address) = (int)keyframeAddr - (int)header->_farZ.Address;
                SCN0EntryNode.EncodeFrames(GetKeys(i), ref keyframeAddr);
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.FarConstant;
                header->_farZ = GetKeys(i)._keyRoot._next._value;
            }
            i++;

            header->_flags1 = (ushort)newFlags1;
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }

        [Browsable(false)]
        public int FrameCount { get { return ((SCN0Node)Parent.Parent).FrameCount; } }

        internal CameraAnimationFrame GetAnimFrame(int index)
        {
            CameraAnimationFrame frame;
            float* dPtr = (float*)&frame;
            for (int x = 0; x < 15; x++)
                *dPtr++ = GetKeys(x).GetFrameValue(index);
            return frame;
        }
        internal KeyframeEntry GetKeyframe(CameraKeyframeMode keyFrameMode, int index)
        {
            return GetKeys((int)keyFrameMode - 0x10).GetKeyframe(index);
        }

        internal float GetFrameValue(CameraKeyframeMode keyFrameMode, int index)
        {
            return GetKeys((int)keyFrameMode - 0x10).GetFrameValue(index);
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

        internal void RemoveKeyframe(CameraKeyframeMode keyFrameMode, int index)
        {
            KeyframeEntry k = GetKeys((int)keyFrameMode - 0x10).Remove(index);
            if (k != null)
            {
                k._prev.GenerateTangent();
                k._next.GenerateTangent();
                SignalPropertyChange();
            }
        }
        
        internal void SetKeyframe(CameraKeyframeMode keyFrameMode, int index, float value)
        {
            KeyframeEntry k = GetKeys((int)keyFrameMode - 0x10).SetFrameValue(index, value);
            k.GenerateTangent();
            k._prev.GenerateTangent();
            k._next.GenerateTangent();

            SignalPropertyChange();
        }
    }

    public enum CameraKeyframeMode
    {
        PosX = 0x10,
        PosY = 0x11,
        PosZ = 0x12,
        RotX = 0x13,
        RotY = 0x14,
        RotZ = 0x15,
        AimX = 0x16,
        AimY = 0x17,
        AimZ = 0x18,
        Twist = 0x19,
        FovY = 0x1A,
        Height = 0x1B,
        Aspect = 0x1C,
        NearZ = 0x1D,
        FarZ = 0x1E,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CameraAnimationFrame
    {
        public static readonly CameraAnimationFrame Empty = new CameraAnimationFrame();

        public Vector3 Pos;
        public Vector3 Rot;
        public Vector3 Aim;
        public float Twist;
        public float FovY;
        public float Height;
        public float Aspect;
        public float NearZ;
        public float FarZ;

        public bool hasPx;
        public bool hasPy;
        public bool hasPz;

        public bool hasRx;
        public bool hasRy;
        public bool hasRz;

        public bool hasAx;
        public bool hasAy;
        public bool hasAz;

        public bool hasT;
        public bool hasF;
        public bool hasH;
        public bool hasA;
        public bool hasNz;
        public bool hasFz;

        public bool forKF;

        public void SetBools(int index, bool val)
        {
            switch (index)
            {
                case 0:
                    hasPx = val; break;
                case 1:
                    hasPy = val; break;
                case 2:
                    hasPz = val; break;
                case 3:
                    hasRx = val; break;
                case 4:
                    hasRy = val; break;
                case 5:
                    hasRz = val; break;
                case 6:
                    hasAx = val; break;
                case 7:
                    hasAy = val; break;
                case 8:
                    hasAz = val; break;
                case 9:
                    hasT = val; break;
                case 10:
                    hasF = val; break;
                case 11:
                    hasH = val; break;
                case 12:
                    hasA = val; break;
                case 13:
                    hasNz = val; break;
                case 14:
                    hasFz = val; break;
            }
        }

        public void ResetBools()
        {
            hasRx = hasRy = hasRz =
            hasPx = hasPy = hasPz =
            hasAx = hasAy = hasAz =
            hasT = hasF = hasH = 
            hasA = hasNz = hasFz = false;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Pos._x;
                    case 1: return Pos._y;
                    case 2: return Pos._z;
                    case 3: return Rot._x;
                    case 4: return Rot._y;
                    case 5: return Rot._z;
                    case 6: return Aim._x;
                    case 7: return Aim._y;
                    case 8: return Aim._z;
                    case 9: return Twist;
                    case 10: return FovY;
                    case 11: return Height;
                    case 12: return Aspect;
                    case 13: return NearZ;
                    case 14: return FarZ;
                    default: return float.NaN;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: Pos._x = value; break;
                    case 1: Pos._y = value; break;
                    case 2: Pos._z = value; break;
                    case 3: Rot._x = value; break;
                    case 4: Rot._y = value; break;
                    case 5: Rot._z = value; break;
                    case 6: Aim._x = value; break;
                    case 7: Aim._y = value; break;
                    case 8: Aim._z = value; break;
                    case 9: Twist = value; break;
                    case 10: FovY = value; break;
                    case 11: Height = value; break;
                    case 12: Aspect = value; break;
                    case 13: NearZ = value; break;
                    case 14: FarZ = value; break;
                }
            }
        }

        public CameraAnimationFrame(Vector3 pos, Vector3 rot, Vector3 aim, float t, float f, float h, float a, float nz, float fz)
        {
            Pos = pos;
            Rot = rot;
            Aim = aim;
            Twist = t;
            FovY = f;
            Height = h;
            Aspect = a;
            NearZ = nz;
            FarZ = fz;
            Index = 0;
            hasRx = hasRy = hasRz =
            hasPx = hasPy = hasPz =
            hasAx = hasAy = hasAz =
            hasT = hasF = hasH =
            hasA = hasNz = hasFz = false;
            forKF = true;
        }
        public int Index;
        const int len = 6;
        static string empty = new String('_', len);
        public override string ToString()
        {
            return String.Format("[{0}] Pos=({1},{2},{3}), Rot=({4},{5},{6}), Aim=({7},{8},{9}), Twist={10}, FovY={11}, Height={12}, Aspect={13}, NearZ={14}, FarZ={15}", Index + 1,
            !hasPx ? empty : Pos._x.ToString().TruncateAndFill(len, ' '),
            !hasPy ? empty : Pos._y.ToString().TruncateAndFill(len, ' '),
            !hasPz ? empty : Pos._z.ToString().TruncateAndFill(len, ' '),
            !hasRx ? empty : Rot._x.ToString().TruncateAndFill(len, ' '),
            !hasRy ? empty : Rot._y.ToString().TruncateAndFill(len, ' '),
            !hasRz ? empty : Rot._z.ToString().TruncateAndFill(len, ' '),
            !hasAx ? empty : Aim._x.ToString().TruncateAndFill(len, ' '),
            !hasAy ? empty : Aim._y.ToString().TruncateAndFill(len, ' '),
            !hasAz ? empty : Aim._z.ToString().TruncateAndFill(len, ' '),
            !hasT ? empty : Twist.ToString().TruncateAndFill(len, ' '),
            !hasF ? empty : FovY.ToString().TruncateAndFill(len, ' '),
            !hasH ? empty : Height.ToString().TruncateAndFill(len, ' '),
            !hasA ? empty : Aspect.ToString().TruncateAndFill(len, ' '),
            !hasNz ? empty : NearZ.ToString().TruncateAndFill(len, ' '),
            !hasFz ? empty : FarZ.ToString().TruncateAndFill(len, ' '));
        }
        //public override string ToString()
        //{
        //    return String.Format("{0}\r\n{1}\r\n{2}", Scale, Rotation, Translation);
        //}
    }
}
