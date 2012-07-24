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
    public unsafe class SCN0CameraNode : SCN0EntryNode
    {
        internal SCN0Camera* Data { get { return (SCN0Camera*)WorkingUncompressed.Address; } }

        public SCN0CameraType _type;
        public ProjectionType _projType;
        public SCN0CameraFlags _flags1;
        public ushort _flags2;
        private List<SCN0Keyframe>
            PosX = new List<SCN0Keyframe>(), PosY = new List<SCN0Keyframe>(), PosZ = new List<SCN0Keyframe>(),
            _aspect = new List<SCN0Keyframe>(), _nearZ = new List<SCN0Keyframe>(), _farZ = new List<SCN0Keyframe>(),
            RotX = new List<SCN0Keyframe>(), RotY = new List<SCN0Keyframe>(), RotZ = new List<SCN0Keyframe>(),
            _aimX = new List<SCN0Keyframe>(), _aimY = new List<SCN0Keyframe>(), _aimZ = new List<SCN0Keyframe>(),
            _twist = new List<SCN0Keyframe>(), _perspFovY = new List<SCN0Keyframe>(), _orthoHeight = new List<SCN0Keyframe>();

        [Category("Camera Position")]
        public List<SCN0Keyframe> PositionX { get { return PosX; } set { PosX = value; SignalPropertyChange(); } }
        [Category("Camera Position")]
        public List<SCN0Keyframe> PositionY { get { return PosY; } set { PosY = value; SignalPropertyChange(); } }
        [Category("Camera Position")]
        public List<SCN0Keyframe> PositionZ { get { return PosZ; } set { PosZ = value; SignalPropertyChange(); } }
        
        [Category("Camera Rotation")]
        public List<SCN0Keyframe> RotationX { get { return RotX; } set { RotX = value; SignalPropertyChange(); } }
        [Category("Camera Rotation")]
        public List<SCN0Keyframe> RotationY { get { return RotY; } set { RotY = value; SignalPropertyChange(); } }
        [Category("Camera Rotation")]
        public List<SCN0Keyframe> RotationZ { get { return RotZ; } set { RotZ = value; SignalPropertyChange(); } }

        [Category("Camera Aim")]
        public List<SCN0Keyframe> AimX { get { return _aimX; } set { _aimX = value; SignalPropertyChange(); } }
        [Category("Camera Aim")]
        public List<SCN0Keyframe> AimY { get { return _aimY; } set { _aimY = value; SignalPropertyChange(); } }
        [Category("Camera Aim")]
        public List<SCN0Keyframe> AimZ { get { return _aimZ; } set { _aimZ = value; SignalPropertyChange(); } }
        
        [Category("Camera Etc")]
        public List<SCN0Keyframe> Twist { get { return _twist; } set { _twist = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public List<SCN0Keyframe> PerspectiveFovY { get { return _perspFovY; } set { _perspFovY = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public List<SCN0Keyframe> OrthographicHeight { get { return _orthoHeight; } set { _orthoHeight = value; SignalPropertyChange(); } }

        [Category("Camera Etc")]
        public List<SCN0Keyframe> AspectRatio { get { return _aspect; } set { _aspect = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public List<SCN0Keyframe> NearZ { get { return _nearZ; } set { _nearZ = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public List<SCN0Keyframe> FarZ { get { return _farZ; } set { _farZ = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public SCN0CameraType Type { get { return _type; } set { _type = value; SignalPropertyChange(); } }
        [Category("Camera Etc")]
        public ProjectionType ProjectionType { get { return _projType; } set { _projType = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _flags1 = (SCN0CameraFlags)(ushort)Data->_flags1;
            _flags2 = Data->_flags2;
            _type = (SCN0CameraType)((ushort)_flags2 & 1);
            _projType = (ProjectionType)(int)Data->_projType;

            PosX = new List<SCN0Keyframe>();
            PosY = new List<SCN0Keyframe>();
            PosZ = new List<SCN0Keyframe>();
            RotX = new List<SCN0Keyframe>();
            RotY = new List<SCN0Keyframe>();
            RotZ = new List<SCN0Keyframe>();
            _aimX = new List<SCN0Keyframe>();
            _aimY = new List<SCN0Keyframe>();
            _aimZ = new List<SCN0Keyframe>();
            _twist = new List<SCN0Keyframe>();
            _perspFovY = new List<SCN0Keyframe>();
            _orthoHeight = new List<SCN0Keyframe>();
            _aspect = new List<SCN0Keyframe>();
            _farZ = new List<SCN0Keyframe>();
            _nearZ = new List<SCN0Keyframe>();

            if (_flags1.HasFlag(SCN0CameraFlags.PosXConstant))
                PosX.Add(new Vector3(0, 0, Data->_position._x));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->posXKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        PosX.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.PosYConstant))
                PosY.Add(new Vector3(0, 0, Data->_position._y));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->posYKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        PosY.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.PosZConstant))
                PosZ.Add(new Vector3(0, 0, Data->_position._z));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->posZKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        PosZ.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.RotXConstant))
                RotX.Add(new Vector3(0, 0, Data->_rotate._x));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->rotXKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        RotX.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.RotYConstant))
                RotY.Add(new Vector3(0, 0, Data->_rotate._y));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->rotYKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        RotY.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.RotZConstant))
                RotZ.Add(new Vector3(0, 0, Data->_rotate._z));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->rotZKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        RotZ.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.AimXConstant))
                _aimX.Add(new Vector3(0, 0, Data->_aim._x));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->aimXKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _aimX.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.AimYConstant))
                _aimY.Add(new Vector3(0, 0, Data->_aim._y));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->aimYKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _aimY.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.AimZConstant))
                _aimZ.Add(new Vector3(0, 0, Data->_aim._z));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->aimZKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _aimZ.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.TwistConstant))
                _twist.Add(new Vector3(0, 0, Data->_twist));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->twistKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _twist.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.PerspFovYConstant))
                _perspFovY.Add(new Vector3(0, 0, Data->_perspFovY));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->fovYKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _perspFovY.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.OrthoHeightConstant))
                _orthoHeight.Add(new Vector3(0, 0, Data->_orthoHeight));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->heightKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _orthoHeight.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.AspectConstant))
                _aspect.Add(new Vector3(0, 0, Data->_aspect));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->aspectKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _aspect.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.NearConstant))
                _nearZ.Add(new Vector3(0, 0, Data->_nearZ));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->nearZKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _nearZ.Add(*addr++);
                }
            }
            if (_flags1.HasFlag(SCN0CameraFlags.FarConstant))
                _farZ.Add(new Vector3(0, 0, Data->_farZ));
            else
            {
                if (Name != "<null>")
                {
                    SCN0KeyframesHeader* keysHeader = Data->farZKeyframes;
                    SCN0KeyframeStruct* addr = keysHeader->Data;
                    for (int i = 0; i < keysHeader->_numFrames; i++)
                        _farZ.Add(*addr++);
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
                if (PosX.Count > 1)
                    keyLen += 4 + PosX.Count * 12;
                if (PosY.Count > 1)
                    keyLen += 4 + PosY.Count * 12;
                if (PosZ.Count > 1)
                    keyLen += 4 + PosZ.Count * 12;

                if (RotX.Count > 1)
                    keyLen += 4 + RotX.Count * 12;
                if (RotY.Count > 1)
                    keyLen += 4 + RotY.Count * 12;
                if (RotZ.Count > 1)
                    keyLen += 4 + RotZ.Count * 12;

                if (_aimX.Count > 1)
                    keyLen += 4 + _aimX.Count * 12;
                if (_aimY.Count > 1)
                    keyLen += 4 + _aimY.Count * 12;
                if (_aimZ.Count > 1)
                    keyLen += 4 + _aimZ.Count * 12;

                if (_twist.Count > 1)
                    keyLen += 4 + _twist.Count * 12;
                if (_perspFovY.Count > 1)
                    keyLen += 4 + _perspFovY.Count * 12;
                if (_orthoHeight.Count > 1)
                    keyLen += 4 + _orthoHeight.Count * 12;

                if (_aspect.Count > 1)
                    keyLen += 4 + _aspect.Count * 12;
                if (_nearZ.Count > 1)
                    keyLen += 4 + _nearZ.Count * 12;
                if (_farZ.Count > 1)
                    keyLen += 4 + _farZ.Count * 12;
            }
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

            if (PosX.Count > 1)
            {
                *((bint*)header->_position._x.Address) = (int)keyframeAddr - (int)header->_position._x.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)PosX.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < PosX.Count; i++)
                    *addr++ = PosX[i];
                keyframeAddr += 4 + PosX.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosXConstant;
                if (PosX.Count == 1)
                    header->_position._x = PosX[0]._value;
                else
                    header->_position._x = 0;
            }
            if (PosY.Count > 1)
            {
                *((bint*)header->_position._y.Address) = (int)keyframeAddr - (int)header->_position._y.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)PosY.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < PosY.Count; i++)
                    *addr++ = PosY[i];
                keyframeAddr += 4 + PosY.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosYConstant;
                if (PosY.Count == 1)
                    header->_position._y = PosY[0]._value;
                else
                    header->_position._y = 0;
            }
            if (PosZ.Count > 1)
            {
                *((bint*)header->_position._z.Address) = (int)keyframeAddr - (int)header->_position._z.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)PosZ.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < PosZ.Count; i++)
                    *addr++ = PosZ[i];
                keyframeAddr += 4 + PosZ.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PosZConstant;
                if (PosZ.Count == 1)
                    header->_position._z = PosZ[0]._value;
                else
                    header->_position._z = 0;
            }
            if (_twist.Count > 1)
            {
                *((bint*)header->_twist.Address) = (int)keyframeAddr - (int)header->_twist.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_twist.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _twist.Count; i++)
                    *addr++ = _twist[i];
                keyframeAddr += 4 + _twist.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.TwistConstant;
                if (_twist.Count == 1)
                    header->_twist = _twist[0]._value;
                else
                    header->_twist = 0;
            }
            if (_perspFovY.Count > 1)
            {
                *((bint*)header->_perspFovY.Address) = (int)keyframeAddr - (int)header->_perspFovY.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_perspFovY.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _perspFovY.Count; i++)
                    *addr++ = _perspFovY[i];
                keyframeAddr += 4 + _perspFovY.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.PerspFovYConstant;
                if (_perspFovY.Count == 1)
                    header->_perspFovY = _perspFovY[0]._value;
                else
                    header->_perspFovY = 0;
            }
            if (_orthoHeight.Count > 1)
            {
                *((bint*)header->_orthoHeight.Address) = (int)keyframeAddr - (int)header->_orthoHeight.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_orthoHeight.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _orthoHeight.Count; i++)
                    *addr++ = _orthoHeight[i];
                keyframeAddr += 4 + _orthoHeight.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.OrthoHeightConstant;
                if (_orthoHeight.Count == 1)
                    header->_orthoHeight = _orthoHeight[0]._value;
                else
                    header->_orthoHeight = 0;
            }
            if (_aimX.Count > 1)
            {
                *((bint*)header->_aim._x.Address) = (int)keyframeAddr - (int)header->_aim._x.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_aimX.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _aimX.Count; i++)
                    *addr++ = _aimX[i];
                keyframeAddr += 4 + _aimX.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimXConstant;
                if (_aimX.Count == 1)
                    header->_aim._x = _aimX[0]._value;
                else
                    header->_aim._x = 0;
            }
            if (_aimY.Count > 1)
            {
                *((bint*)header->_aim._y.Address) = (int)keyframeAddr - (int)header->_aim._y.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_aimY.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _aimY.Count; i++)
                    *addr++ = _aimY[i];
                keyframeAddr += 4 + _aimY.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimYConstant;
                if (_aimY.Count == 1)
                    header->_aim._y = _aimY[0]._value;
                else
                    header->_aim._y = 0;
            }
            if (_aimZ.Count > 1)
            {
                *((bint*)header->_aim._z.Address) = (int)keyframeAddr - (int)header->_aim._z.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_aimZ.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _aimZ.Count; i++)
                    *addr++ = _aimZ[i];
                keyframeAddr += 4 + _aimZ.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AimZConstant;
                if (_aimZ.Count == 1)
                    header->_aim._z = _aimZ[0]._value;
                else
                    header->_aim._z = 0;
            }
            if (RotX.Count > 1)
            {
                *((bint*)header->_rotate._x.Address) = (int)keyframeAddr - (int)header->_rotate._x.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)RotX.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < RotX.Count; i++)
                    *addr++ = RotX[i];
                keyframeAddr += 4 + RotX.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotXConstant;
                if (RotX.Count == 1)
                    header->_rotate._x = RotX[0]._value;
                else
                    header->_rotate._x = 0;
            }
            if (RotY.Count > 1)
            {
                *((bint*)header->_rotate._y.Address) = (int)keyframeAddr - (int)header->_rotate._y.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)RotY.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < RotY.Count; i++)
                    *addr++ = RotY[i];
                keyframeAddr += 4 + RotY.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotYConstant;
                if (RotY.Count == 1)
                    header->_rotate._y = RotY[0]._value;
                else
                    header->_rotate._y = 0;
            }
            if (RotZ.Count > 1)
            {
                *((bint*)header->_rotate._z.Address) = (int)keyframeAddr - (int)header->_rotate._z.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)RotZ.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < RotZ.Count; i++)
                    *addr++ = RotZ[i];
                keyframeAddr += 4 + RotZ.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.RotZConstant;
                if (RotZ.Count == 1)
                    header->_rotate._z = RotZ[0]._value;
                else
                    header->_position._z = 0;
            }
            if (_aspect.Count > 1)
            {
                *((bint*)header->_aspect.Address) = (int)keyframeAddr - (int)header->_aspect.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_aspect.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _aspect.Count; i++)
                    *addr++ = _aspect[i];
                keyframeAddr += 4 + _aspect.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.AspectConstant;
                if (_aspect.Count == 1)
                    header->_aspect = _aspect[0]._value;
                else
                    header->_aspect = 0;
            }
            if (_nearZ.Count > 1)
            {
                *((bint*)header->_nearZ.Address) = (int)keyframeAddr - (int)header->_nearZ.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_nearZ.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _nearZ.Count; i++)
                    *addr++ = _nearZ[i];
                keyframeAddr += 4 + _nearZ.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.NearConstant;
                if (_nearZ.Count == 1)
                    header->_nearZ = _nearZ[0]._value;
                else
                    header->_nearZ = 0;
            }
            if (_farZ.Count > 1)
            {
                *((bint*)header->_farZ.Address) = (int)keyframeAddr - (int)header->_farZ.Address;
                ((SCN0KeyframesHeader*)keyframeAddr)->_numFrames = (ushort)_farZ.Count;
                SCN0KeyframeStruct* addr = ((SCN0KeyframesHeader*)keyframeAddr)->Data;
                for (int i = 0; i < _farZ.Count; i++)
                    *addr++ = _farZ[i];
                keyframeAddr += 4 + _farZ.Count * 12;
            }
            else
            {
                newFlags1 |= SCN0CameraFlags.FarConstant;
                if (_farZ.Count == 1)
                    header->_farZ = _farZ[0]._value;
                else
                    header->_farZ = 0;
            }

            header->_flags1 = (ushort)newFlags1;
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }
    }
}
