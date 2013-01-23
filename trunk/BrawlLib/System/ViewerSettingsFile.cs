using System;
using BrawlLib.Imaging;
using BrawlLib.SSBBTypes;

namespace System
{
    public unsafe struct BBVS
    {
        public static UnsafeBuffer _data = null;

        public const uint Tag = 0x53564242;
        public const uint Size = 0x84;

        public uint _tag;
        public byte _version;
        public Bin8 _flags1;
        public Bin16 _flags2;
        public bfloat _tScale, _rScale, _zScale, _nearZ, _farz, _yFov;
        public BVec4 _amb, _pos, _diff, _spec;
        public BVec3 _defaultCam;
        public BVec2 _defaultRot;
        public ARGBPixel _orbColor;
        public ARGBPixel _lineColor;
        public ARGBPixel _floorColor;
        public bint _shaderCount;
        public bint _matCount;

        public bint* ShaderOffsets { get { return (bint*)_matCount.Address + 1; } }
        public bint* MaterialOffsets { get { return ShaderOffsets + _shaderCount; } }

        public MDL0Shader* GetShader(int index) { return (MDL0Shader*)(Address + ShaderOffsets[index]); }
        public MDL0Material* GetMaterial(int index) { return (MDL0Material*)(Address + MaterialOffsets[index]); }

        public bool RetrieveCorrAnims { get { return _flags1[0]; } }
        public bool UseModelViewerSettings { get { return _flags1[1]; } }
        public bool SyncLoopToAnim { get { return _flags1[2]; } }
        public bool SyncTexToObj { get { return _flags1[3]; } }
        public bool SyncObjToVIS0 { get { return _flags1[4]; } }
        public bool DisableBonesOnPlay { get { return _flags1[5]; } }
        public bool Maximize { get { return _flags1[6]; } }
        public bool CameraSet { get { return _flags1[7]; } }
        
        public bool UseDataTable { get { return _flags2[0]; } }
        public bool HasShaders { get { return _flags2[1]; } }
        public bool HasMaterials { get { return _flags2[2]; } }
        public bool Unused4 { get { return _flags2[3]; } }
        public bool Unused5 { get { return _flags2[4]; } }
        public bool Unused6 { get { return _flags2[5]; } }
        public bool Unused7 { get { return _flags2[6]; } }
        public bool Unused8 { get { return _flags2[7]; } }
        
        public bool Unused9 { get { return _flags2[8]; } }
        public bool Unused10 { get { return _flags2[9]; } }
        public bool Unused11 { get { return _flags2[10]; } }
        public bool Unused12 { get { return _flags2[11]; } }
        public bool Unused13 { get { return _flags2[12]; } }
        public bool Unused14 { get { return _flags2[13]; } }
        public bool Unused15 { get { return _flags2[14]; } }
        public bool Unused16 { get { return _flags2[15]; } }
        
        public void SetOptions(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h)
        {
            _flags1 = (byte)(
                ((a ? 1 : 0) << 0) |
                ((b ? 1 : 0) << 1) |
                ((c ? 1 : 0) << 2) |
                ((d ? 1 : 0) << 3) |
                ((e ? 1 : 0) << 4) |
                ((f ? 1 : 0) << 5) |
                ((g ? 1 : 0) << 6) |
                ((h ? 1 : 0) << 7));
        }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }
}
