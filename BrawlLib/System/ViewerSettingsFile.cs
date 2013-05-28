using System;
using BrawlLib.Imaging;
using BrawlLib.SSBBTypes;
using System.Collections.Generic;

namespace System
{
    public unsafe struct BBVS
    {
        public const uint Tag = 0x53564242;
        public const uint Size = 0xA4;

        public uint _tag;
        public byte _version;
        public Bin8 _flags1;
        public Bin16 _flags2;
        public Bin32 _flags3;
        public bfloat _tScale, _rScale, _zScale, _nearZ, _farz, _yFov;
        public BVec4 _amb, _pos, _diff, _spec, _emis; 
        public BVec3 _defaultCam;
        public BVec2 _defaultRot;
        public ARGBPixel _orbColor;
        public ARGBPixel _lineColor;
        public ARGBPixel _floorColor;
        public buint _screenCapPathOffset;
        public buint _undoCount;
        public bint _shaderCount;
        public bint _matCount;

        public bint* ShaderOffsets { get { return (bint*)_matCount.Address + 1; } }
        public bint* MaterialOffsets { get { return ShaderOffsets + _shaderCount; } }

        public MDL0Shader* GetShader(int index) { return (MDL0Shader*)(Address + ShaderOffsets[index]); }
        public MDL0Material* GetMaterial(int index) { return (MDL0Material*)(Address + MaterialOffsets[index]); }

        public bool RetrieveCorrAnims { get { return _flags1[0]; } }
        public bool UseModelViewerSettings { get { return _flags1[1]; } set { _flags1[1] = value; } }
        public bool SyncLoopToAnim { get { return _flags1[2]; } }
        public bool SyncTexToObj { get { return _flags1[3]; } }
        public bool SyncObjToVIS0 { get { return _flags1[4]; } }
        public bool DisableBonesOnPlay { get { return _flags1[5]; } }
        public bool Maximize { get { return _flags1[6]; } }
        public bool CameraSet { get { return _flags1[7]; } }

        public bool UseDataTable { get { return _flags2[0]; } set { _flags2[0] = value; } }
        public bool HasShaders { get { return _flags2[1]; } set { _flags2[1] = value; } }
        public bool HasMaterials { get { return _flags2[2]; } set { _flags2[2] = value; } }
        public int ImageCapFmt { get { return _flags2[3, 3]; } set { _flags2[3, 3] = (ushort)value; } }
        public bool Bones { get { return _flags2[6]; } set { _flags2[6] = value; } }
        public bool Polys { get { return _flags2[7]; } set { _flags2[7] = value; } }

        public bool Wireframe { get { return _flags2[8]; } set { _flags2[8] = value; } }
        public bool Floor { get { return _flags2[9]; } set { _flags2[9] = value; } }
        public bool Vertices { get { return _flags2[10]; } set { _flags2[10] = value; } }
        public bool Normals { get { return _flags2[11]; } set { _flags2[11] = value; } }
        public bool ShowCamCoords { get { return _flags2[12]; } set { _flags2[12] = value; } }
        public bool OrthoCam { get { return _flags2[13]; } set { _flags2[13] = value; } }
        public bool BoundingBox { get { return _flags2[14]; } set { _flags2[14] = value; } }
        public bool HideOffscreen { get { return _flags2[15]; } set { _flags2[15] = value; } }

        public bool EnableSmoothing { get { return _flags3[0]; } set { _flags3[0] = value; } }
        public bool EnableText { get { return _flags3[1]; } set { _flags3[1] = value; } }

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

    public unsafe class CompactStringTable
    {
        public SortedList<string, VoidPtr> _table = new SortedList<string, VoidPtr>(StringComparer.Ordinal);

        public void Add(string s)
        {
            if ((!String.IsNullOrEmpty(s)) && (!_table.ContainsKey(s)))
                _table.Add(s, 0);
        }

        public int TotalSize
        {
            get
            {
                int len = 0;
                foreach (string s in _table.Keys)
                    len += (s.Length + 1);
                return len;
            }
        }

        public void Clear() { _table.Clear(); }

        public VoidPtr this[string s] { get { return _table[s]; } }

        public void WriteTable(VoidPtr address)
        {
            FDefReferenceString* entry = (FDefReferenceString*)address;
            for (int i = 0; i < _table.Count; i++)
            {
                string s = _table.Keys[i];
                _table[s] = entry;
                entry->Value = s;
                entry = entry->Next;
            }
        }
    }
}
