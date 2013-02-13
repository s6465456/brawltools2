using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.OpenGL;
using System.Collections.Generic;
using BrawlLib.Modeling;
using BrawlLib.Wii.Models;
using BrawlLib.Wii.Graphics;
using System.Windows.Forms;
using BrawlLib.Imaging;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MDL0ObjectNode : MDL0EntryNode
    {
        internal MDL0Object* Header { get { return (MDL0Object*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.MDL0Object; } }

        #region Attributes

        //public List<Vertex3> Vertices { get { return _manager != null ? _manager._vertices : null; } }

        public List<IMatrixNode> Nodes = new List<IMatrixNode>();

        internal bool Weighted { get { return _nodeId == -1 || _singleBind == null; } }
        internal bool TexMtx
        {
            get
            {
                for (int i = 0; i < 8; i++)
                    if (_vertexFormat.GetHasTexMatrix(i))
                        return true;
                return false;
            }
        }

        public byte _drawIndex;
        public byte DrawPriority
        {
            get { return _drawIndex; }
            set
            {
                _drawIndex = value;
                SignalPropertyChange();
            }
        }

        [Category("Object Data"), Browsable(false)]
        public int TotalLen { get { return _totalLength; } }
        [Category("Object Data"), Browsable(false)]
        public int MDL0Offset { get { return _mdl0Offset; } }
        //[Category("Object Data")]
        //public int NodeId { get { return _nodeId; } }

        //[Browsable(true), Category("Vertex Flags")]
        //public CPVertexFormat VertexFormat { get { return _vertexFormat; } }
        public CPVertexFormat _vertexFormat;

        //[Browsable(true), Category("Vertex Flags")]
        //public XFArrayFlags ArrayFlags { get { return _arrayFlags; } }
        public XFArrayFlags _arrayFlags;

        //[Browsable(true), Category("Vertex Flags")]
        //public XFVertexSpecs VertexSpecs { get { return _vertexSpecs; } }
        public XFVertexSpecs _vertexSpecs;

        public CPElementSpec UVATGroups;
        
        //[Browsable(true), Category("UVAT Flags")]
        //public bool ByteDequant { get { return UVATGroups.ByteDequant; } }
        //[Browsable(true), Category("UVAT Flags")]
        //public bool NormalIndex3 { get { return UVATGroups.NormalIndex3; } }

        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef PosDef { get { return UVATGroups.PositionDef; } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef NormDef { get { return UVATGroups.NormalDef; } }
        
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef0 { get { return UVATGroups.GetUVDef(0); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef1 { get { return UVATGroups.GetUVDef(1); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef2 { get { return UVATGroups.GetUVDef(2); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef3 { get { return UVATGroups.GetUVDef(3); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef4 { get { return UVATGroups.GetUVDef(4); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef5 { get { return UVATGroups.GetUVDef(5); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef6 { get { return UVATGroups.GetUVDef(6); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public CPElementDef UVDef7 { get { return UVATGroups.GetUVDef(7); } }

        //[Browsable(true), Category("UVAT Flags")]
        //public string ColorDef0 { get { return UVATGroups.GetColorDef(0).asColor(); } }
        //[Browsable(true), Category("UVAT Flags")]
        //public string ColorDef1 { get { return UVATGroups.GetColorDef(1).asColor(); } }

        //[Category("Object Data")]
        //public int DefBufferSize { get { return _defBufferSize; } }
        //[Category("Object Data")]
        //public int DefSize { get { return _defSize; } }
        //[Category("Object Data")]
        //public int DefOffset { get { return _defOffset; } }

        //[Category("Object Data")]
        //public int PrimBufferSize { get { return _primBufferSize; } }
        //[Category("Object Data")]
        //public int PrimSize { get { return _primSize; } }
        //[Category("Object Data")]
        //public int PrimOffset { get { return _primOffset; } }

        [Category("Object Data")]
        public ObjFlag Flags { get { return (ObjFlag)_flag; } set { _flag = (int)value; SignalPropertyChange(); } }
        //[Category("Object Data")]
        //public int StringOffset { get { return _stringOffset; } }
        [Category("Object Data")]
        public int ID { get { return _entryIndex; } }
        [Category("Object Data")]
        public int FacepointCount { get { return _numFacepoints; } }
        [Category("Object Data")]
        public int VertexCount { get { return _manager._vertices.Count; } }
        [Category("Object Data")]
        public int FaceCount { get { return _numFaces; } }

        internal List<IMatrixNode> _influences;
        [Browsable(false)]
        public List<IMatrixNode> Influences { get { return _influences; } }

        #endregion

        #region Linked Sets

        [TypeConverter(typeof(DropDownListVertices))]
        public string VertexNode
        {
            get { return _vertexNode == null ? null : _vertexNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_vertexNode = null;
                    //_elementIndices[0] = -1;
                }
                else
                {
                    MDL0VertexNode node = Model.FindChild(String.Format("Vertices/{0}", value), false) as MDL0VertexNode;
                    if (node != null)
                    {
                        if (_vertexNode != null && node.NumVertices == _vertexNode.NumVertices)
                        {
                            _vertexNode = node;
                            _elementIndices[0] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Vertex counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        //public MDL0VertexNode VertexNode { get { return _vertexNode; } set { _vertexNode = value; SignalPropertyChange(); _rebuild = true; } }
        public MDL0VertexNode _vertexNode;

        [TypeConverter(typeof(DropDownListNormals))]
        public string NormalNode
        {
            get { return _normalNode == null ? null : _normalNode._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_normalNode = null;
                    //_elementIndices[1] = -1;
                }
                else
                {
                    MDL0NormalNode node = Model.FindChild(String.Format("Normals/{0}", value), false) as MDL0NormalNode;
                    if (node != null)
                    {
                        if (_normalNode != null && node.NumEntries == _normalNode.NumEntries)
                        {
                            _normalNode = node;
                            _elementIndices[1] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        //public MDL0NormalNode NormalNode { get { return _normalNode; } }
        internal MDL0NormalNode _normalNode;

        public bool _c0Changed = false;
        [TypeConverter(typeof(DropDownListColors))]
        public string ColorNode0
        {
            get { return _colorSet[0] == null ? null : _colorSet[0]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (_colorSet[0] != null)
                    {
                        _c0Changed = true;
                        _colorSet[0] = null;
                        _elementIndices[2] = -1;
                        _rebuild = true;
                    }
                }
                else
                {
                    MDL0ColorNode node = Model.FindChild(String.Format("Colors/{0}", value), false) as MDL0ColorNode;
                    if (node != null && node.NumEntries != 0)
                    {
                        if (_colorSet[0] != null)
                            if (node.NumEntries == _colorSet[0].NumEntries)
                            {
                                _colorSet[0] = node;
                                _elementIndices[2] = (short)node.Index;
                            }
                            else if (node.NumEntries > _colorSet[0].NumEntries)
                            {
                                MessageBox.Show("All vertices will only use the first color entry.");
                                _colorSet[0] = node;
                                _elementIndices[2] = (short)node.Index;
                            }
                            else
                            {
                                MessageBox.Show("There are not enough color entries for this object.");
                                return;
                            }
                        else
                        {
                            if (node.NumEntries > 1)
                                MessageBox.Show("All vertices will only use the first color entry.");

                            _colorSet[0] = node;
                            _elementIndices[2] = (short)node.Index;
                            _rebuild = true;
                            _c0Changed = true;
                        }
                    }
                    else return;
                }
                SignalPropertyChange();
            }
        }
        public bool _c1Changed = false;
        [TypeConverter(typeof(DropDownListColors))]
        public string ColorNode1
        {
            get { return _colorSet[1] == null ? null : _colorSet[1]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    if (_colorSet[1] != null)
                    {
                        _c1Changed = true;
                        _colorSet[1] = null;
                        _elementIndices[3] = -1;
                        _rebuild = true;
                    }
                }
                else
                {
                    MDL0ColorNode node = Model.FindChild(String.Format("Colors/{0}", value), false) as MDL0ColorNode;
                    if (node != null && node.NumEntries != 0)
                    {
                        if (_colorSet[1] != null)
                            if (node.NumEntries == _colorSet[1].NumEntries)
                            {
                                _colorSet[1] = node;
                                _elementIndices[3] = (short)node.Index;
                            }
                            else if (node.NumEntries > _colorSet[1].NumEntries)
                            {
                                MessageBox.Show("All vertices will only use the first color entry.");
                                _colorSet[1] = node;
                                _elementIndices[3] = (short)node.Index;
                            }
                            else
                            {
                                MessageBox.Show("There are not enough color entries for this object.");
                                return;
                            }
                        else
                        {
                            if (node.NumEntries > 1)
                                MessageBox.Show("All vertices will only use the first color entry.");

                            _colorSet[1] = node;
                            _elementIndices[3] = (short)node.Index;
                            _rebuild = true;
                            _c1Changed = true;
                        }
                    }
                    else return;
                }
                SignalPropertyChange();
            }
        }

        //public MDL0ColorNode[] ColorNodes { get { return _colorSet; } }
        internal MDL0ColorNode[] _colorSet = new MDL0ColorNode[2];

        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord0
        {
            get { return _uvSet[0] == null ? null : _uvSet[0]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[0] = null;
                    //_elementIndices[4] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[0] != null && node.NumEntries == _uvSet[0].NumEntries)
                        {
                            _uvSet[0] = node;
                            _elementIndices[4] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord1
        {
            get { return _uvSet[1] == null ? null : _uvSet[1]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[1] = null;
                    //_elementIndices[5] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[1] != null && node.NumEntries == _uvSet[1].NumEntries)
                        {
                            _uvSet[1] = node;
                            _elementIndices[5] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord2
        {
            get { return _uvSet[2] == null ? null : _uvSet[2]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[2] = null;
                    //_elementIndices[6] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[2] != null && node.NumEntries == _uvSet[0].NumEntries)
                        {
                            _uvSet[2] = node;
                            _elementIndices[6] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord3
        {
            get { return _uvSet[3] == null ? null : _uvSet[3]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[3] = null;
                    //_elementIndices[7] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[3] != null && node.NumEntries == _uvSet[3].NumEntries)
                        {
                            _uvSet[3] = node;
                            _elementIndices[7] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord4
        {
            get { return _uvSet[4] == null ? null : _uvSet[4]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[4] = null;
                    //_elementIndices[8] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[4] != null && node.NumEntries == _uvSet[4].NumEntries)
                        {
                            _uvSet[4] = node;
                            _elementIndices[8] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord5
        {
            get { return _uvSet[5] == null ? null : _uvSet[5]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[5] = null;
                    //_elementIndices[9] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[5] != null && node.NumEntries == _uvSet[5].NumEntries)
                        {
                            _uvSet[5] = node;
                            _elementIndices[4] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord6
        {
            get { return _uvSet[6] == null ? null : _uvSet[6]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[6] = null;
                    //_elementIndices[10] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[6] != null && node.NumEntries == _uvSet[6].NumEntries)
                        {
                            _uvSet[6] = node;
                            _elementIndices[10] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }
        [TypeConverter(typeof(DropDownListUVs))]
        public string TexCoord7
        {
            get { return _uvSet[7] == null ? null : _uvSet[7]._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    return;
                    //_uvSet[7] = null;
                    //_elementIndices[11] = -1;
                }
                else
                {
                    MDL0UVNode node = Model.FindChild(String.Format("UVs/{0}", value), false) as MDL0UVNode;
                    if (node != null)
                    {
                        if (_uvSet[7] != null && node.NumEntries == _uvSet[7].NumEntries)
                        {
                            _uvSet[7] = node;
                            _elementIndices[11] = (short)node.Index;
                        }
                        else
                        {
                            MessageBox.Show("Entry counts are not equal. Cannot continue.");
                            return;
                        }
                    }
                }
                SignalPropertyChange();
            }
        }

        //public MDL0UVNode[] UVNodes { get { return _uvSet; } }
        internal MDL0UVNode[] _uvSet = new MDL0UVNode[8];

        #endregion

        #region Variables

        int _totalLength, _mdl0Offset, _stringOffset;

        public int _numFacepoints;
        public int _numFaces;
        public int _nodeId;
        public int _defBufferSize = 0xE0;
        public int _defSize = 0x80;
        public int _defOffset;
        public int _primBufferSize;
        public int _primSize;
        public int _primOffset;
        public int _flag = 0;
        public int _index;

        internal short[] _elementIndices = new short[12];

        public int[] _nodeCache;
        private int tableLen = 0;
        private int triCount = 0;
        private int stripCount = 0;
        private int primitiveStart = 0;
        private int primitiveSize = 0;
        public GXVtxDescList[] _descList;
        public GXVtxAttrFmtList[] _fmtList;
        public int fpStride = 0;
        public Facepoint[] _facepoints;
        //public List<PrimitiveGroup> Primitives { get { return groups; } }
        public List<PrimitiveGroup> groups = new List<PrimitiveGroup>();
        public List<Triangle> Triangles = new List<Triangle>();
        public List<Tristrip> Tristrips = new List<Tristrip>();

        public bool _rebuild = false;

        #endregion

        #region Single Bind linkage
        [Browsable(true), TypeConverter(typeof(DropDownListBones))]
        public string SingleBind
        {
            get { return _singleBind == null ? "(none)" : _singleBind.IsPrimaryNode ? ((MDL0BoneNode)_singleBind)._name : "(multiple)"; }
            set
            {
                SingleBindInf = String.IsNullOrEmpty(value) ? null : Model.FindBone(value); 
                Model.SignalPropertyChange();
                //Model._rebuildAllObj = true;
                Model.Rebuild(false);
            }
        }
        internal IMatrixNode _singleBind;
        [Browsable(false)]
        public IMatrixNode SingleBindInf
        {
            get { return _singleBind; }
            set
            {
                if (_singleBind == value)
                    return;
                if (_singleBind != null)
                {
                    if (_singleBind is MDL0BoneNode)
                        ((MDL0BoneNode)_singleBind)._infPolys.Remove(this);
                    else
                        _singleBind.ReferenceCount--;
                }
                if ((_singleBind = value) != null)
                {
                    //Singlebind bones aren't added to NodeMix, but its node id is still built as influenced
                    //_singleBind.ReferenceCount++;
                    if (_singleBind is MDL0BoneNode)
                        ((MDL0BoneNode)_singleBind)._infPolys.Add(this);
                    else
                        _singleBind.ReferenceCount++;
                }
            }
        }
        #endregion

        #region Material linkage
        public void EvalMaterials(ref string message)
        {
            if (XluMaterialNode != null && !XluMaterialNode.XLUMaterial)
                if (OpaMaterialNode != null)
                    message += Name + "\n";
            if (OpaMaterialNode != null && OpaMaterialNode.XLUMaterial)
                if (XluMaterialNode != null)
                    message += Name + "\n";
        }
        public void FixMaterials(ref string message)
        {
            if (XluMaterialNode != null && !XluMaterialNode.XLUMaterial)
            {
                if (OpaMaterialNode == null)
                    OpaMaterialNode = XluMaterialNode;
                else
                    message += Name + "\n";
                XluMaterialNode = null;
            }
            if (OpaMaterialNode != null && OpaMaterialNode.XLUMaterial)
            {
                if (XluMaterialNode == null)
                    XluMaterialNode = OpaMaterialNode;
                else
                    message += Name + "\n";
                OpaMaterialNode = null;
            }
        }
        [Browsable(false)]
        public MDL0MaterialNode UsableMaterialNode
        {
            get
            {
                if (OpaMaterialNode != null)
                    return OpaMaterialNode;
                else
                    return XluMaterialNode;
            }
            set
            {
                if (value.XLUMaterial)
                    XluMaterialNode = value;
                else 
                    OpaMaterialNode = value;
            }
        }

        internal MDL0MaterialNode _opaMaterial, _xluMaterial;
        [Browsable(false)]
        public MDL0MaterialNode OpaMaterialNode
        {
            get { return _opaMaterial; }
            set
            {
                if (_opaMaterial == value)
                    return;
                if (_opaMaterial != null)
                    _opaMaterial._polygons.Remove(this);
                if ((_opaMaterial = value) != null)
                    _opaMaterial._polygons.Add(this);
            }
        }
        [Browsable(false)]
        public MDL0MaterialNode XluMaterialNode
        {
            get { return _xluMaterial; }
            set
            {
                if (_xluMaterial == value)
                    return;
                if (_xluMaterial != null)
                    _xluMaterial._polygons.Remove(this);
                if ((_xluMaterial = value) != null)
                    _xluMaterial._polygons.Add(this);
            }
        }
        [Browsable(true), TypeConverter(typeof(DropDownListOpaMaterials))]
        public string OpaMaterial
        {
            get { return _opaMaterial == null ? null : _opaMaterial._name; }
            set { if (String.IsNullOrEmpty(value)) return; OpaMaterialNode = Model.FindOrCreateOpaMaterial(value); Model.SignalPropertyChange(); }
        }
        [Browsable(true), TypeConverter(typeof(DropDownListXluMaterials))]
        public string XluMaterial
        {
            get { return _xluMaterial == null ? null : _xluMaterial._name; }
            set { if (String.IsNullOrEmpty(value)) return; XluMaterialNode = Model.FindOrCreateXluMaterial(value); Model.SignalPropertyChange(); }
        }
        #endregion

        #region Bone linkage
        internal MDL0BoneNode _bone;
        [Browsable(false)]
        public MDL0BoneNode BoneNode
        {
            get { return _bone; }
            set
            {
                if (_bone == value)
                    return;
                if (_bone != null)
                    _bone._manPolys.Remove(this);
                if ((_bone = value) != null)
                {
                    _bone._manPolys.Add(this);
                    _render = _bone._flags1.HasFlag(BoneFlags.Visible);
                }
            }
        }
        [Browsable(true), TypeConverter(typeof(DropDownListBones))]
        public string VisibilityBone //This attaches the object to a bone controlled by a VIS0
        {
            get { return _bone == null ? null : _bone._name; }
            set { BoneNode = String.IsNullOrEmpty(value) ? null : Model.FindBone(value); Model.SignalPropertyChange(); }
        }
        #endregion

        #region Reading & Writing

        internal PrimitiveManager _manager;

        public override void Dispose()
        {
            if (_manager != null)
            {
                _manager.Dispose();
                _manager = null;
            }
            base.Dispose();
        }

        public void attachSingleBind()
        {
            SingleBindInf = (_nodeId >= 0 && _nodeId < Model._linker.NodeCache.Length) ? Model._linker.NodeCache[_nodeId] : null;
        }

        protected override bool OnInitialize()
        {
            MDL0Object* header = Header;
            _nodeId = header->_nodeId;

            SetSizeInternal(_totalLength = header->_totalLength);
            _mdl0Offset = header->_mdl0Offset;
            _stringOffset = header->_stringOffset;

            ModelLinker linker = Model._linker;

            attachSingleBind();

            _vertexFormat = header->_vertexFormat;
            _vertexSpecs = header->_vertexSpecs;
            _arrayFlags = header->_arrayFlags;

            _numFacepoints = header->_numVertices;
            _numFaces = header->_numFaces;

            _flag = header->_flag;

            _primBufferSize = header->_primitives._bufferSize;
            _primSize = header->_primitives._size;
            _primOffset = header->_primitives._offset;

            _defBufferSize = header->_defintions._bufferSize;
            _defSize = header->_defintions._size;
            _defOffset = header->_defintions._offset;

            _entryIndex = header->_index;

            //Conditional name assignment
            if ((_name == null) && (header->_stringOffset != 0))
                if (!_replaced)
                    _name = header->ResourceString;
                else
                    _name = "polygon" + Index;

            //Link nodes
            if (header->_vertexId >= 0)
                foreach (MDL0VertexNode v in Model._vertList)
                    if (header->_vertexId == v.ID)
                        (_vertexNode = v)._polygons.Add(this);

            if (header->_normalId >= 0)
                foreach (MDL0NormalNode n in Model._normList)
                    if (header->_normalId == n.ID)
                        (_normalNode = n)._polygons.Add(this);

            int id;
            for (int i = 0; i < 2; i++)
                if ((id = ((bshort*)header->_colorIds)[i]) >= 0)
                    foreach (MDL0ColorNode c in Model._colorList)
                        if (id == c.ID)
                            (_colorSet[i] = c)._polygons.Add(this);

            for (int i = 0; i < 8; i++)
                if ((id = ((bshort*)header->_uids)[i]) >= 0)
                    foreach (MDL0UVNode u in Model._uvList)
                        if (id == u.ID)
                            (_uvSet[i] = u)._polygons.Add(this);

            //Link element indices for rebuild
            _elementIndices[0] = (short)(_vertexNode != null ? _vertexNode.Index : -1);
            _elementIndices[1] = (short)(_normalNode != null ? _normalNode.Index : -1);
            for (int i = 2; i < 4; i++)
                _elementIndices[i] = (short)(_colorSet[i - 2] != null ? _colorSet[i - 2].Index : -1);
            for (int i = 4; i < 12; i++)
                _elementIndices[i] = (short)(_uvSet[i - 4] != null ? _uvSet[i - 4].Index : -1);

            //Create primitive manager
            if (_parent != null)
            {
                int i = 0;
                _manager = new PrimitiveManager(header, Model._assets, linker.NodeCache, this);
                foreach (Vertex3 v in _manager._vertices)
                    v.Index = i++;
            }

            //Get polygon UVAT groups
            MDL0PolygonDefs* Defs = (MDL0PolygonDefs*)header->DefList;
            UVATGroups = new CPElementSpec(
                (uint)Defs->UVATA,
                (uint)Defs->UVATB,
                (uint)Defs->UVATC);

            //Read internal object node cache and read influence list
            if (Model._linker.NodeCache != null)
            {
                foreach (ushort node in _manager._desc.NodeIds)
                    try { Nodes.Add(Model._linker.NodeCache[node]); }
                    catch { }

                if (_singleBind == null)
                {
                    _influences = new List<IMatrixNode>();
                    bushort* weights = header->WeightIndices(Model._version);
                    int count = *(bint*)weights; weights += 2;
                    for (int i = 0; i < count; i++)
                        if (*weights < Model._linker.NodeCache.Length)
                            _influences.Add(Model._linker.NodeCache[*weights++]);
                        else
                            weights++;
                }
            }

            //Debug stuff
            if (header->_primitives._bufferSize != header->_primitives._size)
                Console.WriteLine("DataLen deviation!");
            if (header->_flag != 0)
                Console.WriteLine("Flag is not 0!");
            if (header->_totalLength - header->_primitives._offset - header->_primitives._bufferSize != 0x24)
                Console.WriteLine("Improper data offsets!");
            if (header->_totalLength % 0x20 != 0)
            {
                Model._errors.Add("Object " + Index + " has an improper data length.");
                SignalPropertyChange(); _rebuild = true;
            }
            if ((int)(0x24 + header->_primitives._offset) % 0x20 != 0)
            {
                Model._errors.Add("Object " + Index + " has an improper primitives start offset.");
                SignalPropertyChange(); _rebuild = true;
            }

            return false;
        }

        #region Rebuilding

        public void RecalcIndices()
        {
            _elementIndices[0] = (short)(_vertexNode != null ? _vertexNode.Index : _elementIndices[0]);
            _elementIndices[1] = (short)(_normalNode != null ? _normalNode.Index : _elementIndices[1]);
            for (int i = 2; i < 4; i++)
                _elementIndices[i] = (short)(_colorSet[i - 2] != null ? _colorSet[i - 2].Index : _elementIndices[i]);
            for (int i = 4; i < 12; i++)
                _elementIndices[i] = (short)(_uvSet[i - 4] != null ? _uvSet[i - 4].Index : _elementIndices[i]);
        }

        //This should be done after node indices have been assigned
        protected override int OnCalculateSize(bool force)
        {
            //Reset everything!
            tableLen =
            primitiveStart =
            primitiveSize =
            fpStride =
            triCount =
            stripCount = 0;

            //Create node table
            HashSet<int> nodes = new HashSet<int>();
            foreach (Vertex3 v in _manager._vertices)
                if (v._influence != null)
                    nodes.Add(v._influence.NodeIndex);

            //Copy to array and sort
            _nodeCache = new int[nodes.Count];
            nodes.CopyTo(_nodeCache);
            Array.Sort(_nodeCache);

            //Rebuild only under certain circumstances
            if (Model._rebuildAllObj || Model._isImport || _rebuild)
            {
                //RecalcIndices();

                int size = (int)MDL0Object.Size;

                if (Model._version >= 10)
                    size += 4; //Add extra -1 value

                if (Model._isImport)
                {
                    //Continue checking for single bind
                    if (_nodeId == -2 && _singleBind == null)
                    {
                        bool first = true;
                        foreach (Vertex3 v in _manager._vertices)
                        {
                            if (first)
                            {
                                if (v._influence != null)
                                {
                                    _singleBind = Model._linker.NodeCache[v._influence.NodeIndex];
                                    if (_singleBind is MDL0BoneNode)
                                        ((MDL0BoneNode)_singleBind)._infPolys.Add(this);
                                }
                                first = false;
                            }
                            v._influence = null;
                        }
                    }

                    _manager.Nodes = new Dictionary<int, IMatrixNode>();
                    foreach (Vertex3 v in _manager._vertices)
                    {
                        if (v._influence != null)
                            if (!_manager.Nodes.ContainsKey(v._influence.NodeIndex))
                                _manager.Nodes.Add(v._influence.NodeIndex, v._influence);
                    }
                }

                //Set vertex descriptor
                _descList = _manager.setDescList(this, Model._linker._forceDirectAssets);

                //Add table length
                size += _nodeCache.Length * 2 + 4;
                tableLen = ((size.Align(0x10) + 0xE0) % 0x20 == 0) ? size.Align(0x10) : size.Align(0x20);

                //Add def length
                size = primitiveStart = tableLen + 0xE0;

                if (Model._isImport)
                {
                    groups.Clear();
                    Triangles.Clear();
                    Tristrips.Clear();

                    //_bone = Model._boneGroup._children[0] as MDL0BoneNode;

                    //Merge vertices and assets into facepoints
                    _facepoints = _manager.MergeData(this);

                    Triangle Tri;
                    if (_manager._triangles != null)
                    {
                        ushort* indices = (ushort*)_manager._triangles._indices.Address;
                        for (int t = 0; t < _manager._triangles._elementCount; t += 3)
                        {
                            Tri = new Triangle();

                            if (!Model._importOptions._forceCCW)
                            {
                                //Indices are written in reverse for each triangle, 
                                //so they need to be set to a triangle in reverse

                                Tri.z = _facepoints[indices[t + 0]];
                                Tri.y = _facepoints[indices[t + 1]];
                                Tri.x = _facepoints[indices[t + 2]];
                            }
                            else
                            {
                                Tri.x = _facepoints[indices[t + 0]];
                                Tri.y = _facepoints[indices[t + 1]];
                                Tri.z = _facepoints[indices[t + 2]];
                            }

                            Triangles.Add(Tri);
                        }

                        //TriangleConverter.ACTCData tc = TriangleConverter.actcNew();

                        //int triangleCount = Triangles.Count;
                        //uint[][] triangles = new uint[triangleCount][];
                        //int g = 0;
                        //foreach (Triangle t in Triangles)
                        //{
                        //    triangles[g] = new uint[3];
                        //    triangles[g][0] = (uint)t.xIndex;
                        //    triangles[g][1] = (uint)t.yIndex;
                        //    triangles[g][2] = (uint)t.zIndex;
                        //    g++;
                        //}
                        //int[] primLengths;
                        //TriangleConverter.ACTC_var[] primTypes;
                        //uint[] primVerts;
                        //int primCount;

                        //primLengths = new int[triangleCount];
                        //primTypes = new TriangleConverter.ACTC_var[triangleCount];
                        //primVerts = new uint[triangleCount * 3];
                        //primCount = TriangleConverter.actcTrianglesToPrimitives(tc, triangleCount, triangles, primTypes, primLengths, primVerts, int.MaxValue);
                        ////if (primCount < 0)
                        ////{
                        ////    /* something bad happened */
                        ////    /* print error and exit or whatever */
                        ////}

                        //Groups as triangles (working)
                        bool NewGroup = true;
                        PrimitiveGroup grp = new PrimitiveGroup();
                        for (int i = 0; i < Triangles.Count; i++)
                        {
                        Top:
                            if (NewGroup) //Create a new group of triangles and node ids
                            {
                                grp = new PrimitiveGroup();
                                NewGroup = false;
                            }
                            if (!(grp.CanAdd(Triangles[i]))) //Will add automatically if true
                            {
                                groups.Add(grp);
                                NewGroup = true;
                                goto Top;
                            }
                            if (i == Triangles.Count - 1) //Last triangle
                                groups.Add(grp);
                        }
                    }
                }

                //Build display list
                foreach (PrimitiveGroup g in groups)
                {
                    if (Model._isImport)
                    {
                        if (g.Tristrips.Count != 0)
                            foreach (Tristrip strip in g.Tristrips)
                                primitiveSize += 3 + strip.points.Count * fpStride;

                        if (g.Triangles.Count != 0)
                        {
                            primitiveSize += 3;
                            foreach (Triangle t in g.Triangles)
                                primitiveSize += 3 * fpStride;
                        }
                    }
                    else
                        for (int i = 0; i < g._headers.Count; i++)
                            primitiveSize += 3 + g._points[i].Count * fpStride;

                    if (Weighted)
                        primitiveSize += 5 * g.nodeIds.Count * (TexMtx ? 3 : 2); //Add total matrices size
                }

                size += primitiveSize;
                int align = ((size.Align(0x10)) % 0x20 == 0) ? 0x10 : 0x20;
                size = size.Align(align);
                primitiveSize = primitiveSize.Align(align);

                //Texture matrices (0x30) start at 0x00, max 11
                //Pos matrices (0x20) start at 0x78, max 10
                //Normal matrices (0x28) start at 0x400, max 10

                return size;
            }
            else
                return base.OnCalculateSize(force);
        }
        
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            MDL0Object* header = (MDL0Object*)address;

            if (Model._rebuildAllObj || Model._isImport || _rebuild)
            {
                //Set Header
                header->_totalLength = length;

                //header->_numVertices = _numVertices = triCount + stripCount;
                //header->_numFaces = _numFaces = (triCount / 3) + (stripCount <= 2 ? 0 : stripCount - 2);

                _numFacepoints = header->_numVertices = _manager._pointCount;
                _numFaces = header->_numFaces = _manager._faceCount;

                _primBufferSize = header->_primitives._bufferSize = primitiveSize;
                _primSize = header->_primitives._size = primitiveSize;
                _primOffset = header->_primitives._offset = tableLen + 0xBC;

                _defOffset = tableLen - 0x18;

                header->_defintions._bufferSize = _defBufferSize;
                header->_defintions._size = _defSize;
                header->_defintions._offset = _defOffset;

                header->_flag = _flag;

                header->_index = _entryIndex;

                if (Model._version < 10)
                    header->_nodeTableOffset = 0x64;
                else
                {
                    //Technically two bshorts: Fur Vector Id & Fur Layer Coord Id. Currently unsupported.
                    *(bint*)((byte*)header + 0x60) = -1;

                    //Table offset
                    *(byte*)((byte*)header + 0x67) = 0x68;
                }

                //Set the node id
                if (_singleBind != null)
                    header->_nodeId = _nodeId = (ushort)_singleBind.NodeIndex;
                else
                    header->_nodeId = _nodeId = -1;

                //Set asset ids
                header->_vertexId = Model._isImport && Model._linker._forceDirectAssets[0] ? (short)-1 : (short)(_elementIndices[0] >= 0 ? _elementIndices[0] : -1);
                header->_normalId = Model._isImport && Model._linker._forceDirectAssets[1] ? (short)-1 : (short)(_elementIndices[1] >= 0 ? _elementIndices[1] : -1);
                for (int i = 2; i < 4; i++)
                    *(bshort*)&header->_colorIds[i - 2] = Model._isImport && Model._linker._forceDirectAssets[2] ? (short)-1 : (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);
                for (int i = 4; i < 12; i++)
                    *(bshort*)&header->_uids[i - 4] = Model._isImport && Model._linker._forceDirectAssets[3] ? (short)-1 : (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);

                //Write def list
                MDL0PolygonDefs* Defs = (MDL0PolygonDefs*)header->DefList;
                *Defs = MDL0PolygonDefs.Default;

                //Array flags are already set
                header->_arrayFlags = _arrayFlags;

                //Set vertex flags using descriptor list (sets the flags to this object)
                fixed (GXVtxDescList* desc = _descList) { _manager.SetVtxDescriptor(desc, this); }

                //Set UVAT groups using format list (writes directly to header)
                fixed (GXVtxAttrFmtList* format = _fmtList) { _manager.SetVertexFormat(GXVtxFmt.GX_VTXFMT0, format, header); }

                //Write newly set flags
                header->_vertexFormat._lo = Defs->VtxFmtLo = _vertexFormat._lo;
                header->_vertexFormat._hi = Defs->VtxFmtHi = _vertexFormat._hi;
                header->_vertexSpecs = Defs->VtxSpecs = _vertexSpecs;

                //Display UVAT groups that were written
                UVATGroups = new CPElementSpec(
                    (uint)Defs->UVATA,
                    (uint)Defs->UVATB,
                    (uint)Defs->UVATC);

                //If the object has a single-bind, there will be no weight table
                if (_singleBind == null)
                {
                    //Write weight table
                    bushort* ptr = (bushort*)header->WeightIndices(Model._version);
                    *(buint*)ptr = (uint)_nodeCache.Length; ptr += 2;
                    foreach (int n in _nodeCache)
                        *ptr++ = (ushort)n;
                }

                //Write primitives
                _manager.WritePrimitives(this, header);

                //Regenerate internal node cache
                if (Model._linker.NodeCache != null)
                {
                    Nodes.Clear();
                    foreach (ushort node in _manager._desc.NodeIds)
                        if (node < Model._linker.NodeCache.Length && node >= 0) 
                            Nodes.Add(Model._linker.NodeCache[node]);
                }
            }
            else
            {
                //Move raw data over
                base.OnRebuild(address, length, force);

                //Correct some things, just in case.
                CorrectNodeIds(header); RecalcIndices();
                header->_vertexId = _elementIndices[0];
                header->_normalId = _elementIndices[1];
                for (int i = 2; i < 4; i++)
                    *(bshort*)&header->_colorIds[i - 2] = (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);
                for (int i = 4; i < 12; i++)
                    *(bshort*)&header->_uids[i - 4] = (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);
            }

            _rebuild = false;
        }

        public void CorrectNodeIds(MDL0Object* header)
        {
            //Write weight table. The count won't change
            bushort* ptr = (bushort*)header->WeightIndices(Model._version);
            *(buint*)ptr = (uint)_nodeCache.Length; ptr += 2;
            foreach (int n in _nodeCache)
                *ptr++ = (ushort)n;

            if (_singleBind != null)
                header->_nodeId = _nodeId = (ushort)_singleBind.NodeIndex;
            else 
                header->_nodeId = _nodeId = -1;

            int i = 0;
            foreach (uint addr in _manager._desc.Addresses) //Node ids will always match with addresses
                *(bushort*)((byte*)header->PrimitiveData + addr) = (ushort)Nodes[i++].NodeIndex;
        }

        public override unsafe void Export(string outPath)
        {
            if (outPath.EndsWith(".obj"))
                Wavefront.Serialize(outPath, this);
            else
                base.Export(outPath);
        }

        protected internal override void PostProcess(VoidPtr mdlAddress, VoidPtr dataAddress, StringTable stringTable)
        {
            MDL0Object* header = (MDL0Object*)dataAddress;
            header->_mdl0Offset = (int)mdlAddress - (int)dataAddress;
            header->_stringOffset = (int)stringTable[Name] + 4 - (int)dataAddress;
            header->_index = Index;
        }

        #endregion

        #endregion

        #region Rendering

        #region GLSL

        public const int SHADER_POSMTX_ATTRIB = 1;
        public const int SHADER_NORM1_ATTRIB = 6;
        public const int SHADER_NORM2_ATTRIB = 7;

        public const string I_POSNORMALMATRIX = "cpnmtx";
        public const string I_PROJECTION = "cproj";
        public const string I_MATERIALS = "cmtrl";
        public const string I_LIGHTS = "clights";
        public const string I_TEXMATRICES = "ctexmtx";
        public const string I_TRANSFORMMATRICES = "ctrmtx";
        public const string I_NORMALMATRICES = "cnmtx";
        public const string I_POSTTRANSFORMMATRICES = "cpostmtx";
        public const string I_DEPTHPARAMS = "cDepth";

        public const int C_POSNORMALMATRIX = 0;
        public const int C_PROJECTION = (C_POSNORMALMATRIX + 6);
        public const int C_MATERIALS = (C_PROJECTION + 4);
        public const int C_LIGHTS = (C_MATERIALS + 4);
        public const int C_TEXMATRICES = (C_LIGHTS + 40);
        public const int C_TRANSFORMMATRICES = (C_TEXMATRICES + 24);
        public const int C_NORMALMATRICES = (C_TRANSFORMMATRICES + 64);
        public const int C_POSTTRANSFORMMATRICES = (C_NORMALMATRICES + 32);
        public const int C_DEPTHPARAMS = (C_POSTTRANSFORMMATRICES + 64);
        public const int C_VENVCONST_END = (C_DEPTHPARAMS + 4);

        #region Vertex Shader

        public void GenerateVSOutputStruct()
        {
            w("struct VS_OUTPUT\n{\n");
            w("vec4 pos;\n");
            w("vec4 colors_0;\n");
            w("vec4 colors_1;\n");

            if (UsableMaterialNode.Children.Count < 7)
            {
                for (uint i = 0; i < UsableMaterialNode.Children.Count; i++)
                    w("vec3 tex{0};\n", i);
                w("vec4 clipPos;\n");
                w("vec4 Normal;\n");
            }
            else
            {
                // clip position is in w of first 4 texcoords
                //if(g_ActiveConfig.bEnablePixelLighting && ctx.bSupportsPixelLighting)
                //{
                    for (int i = 0; i < 8; i++)
                        w("vec4 tex{0};\n", i);
                //}
                //else
                //{
                //    for (uint i = 0; i < MaterialNode.Children.Count; ++i)
                //        s += String.Format("  float{0} tex{1} : TEXCOORD{1};\n", i < 4 ? 4 : 3, i);
                //}
            }      
            w("};\n");
        }

        #region Shader Helpers
        public string tempShader;
        public int tabs = 0;
        [Browsable(false)]
        public string Tabs { get { string t = ""; for (int i = 0; i < tabs; i++) t += "\t"; return t; } }
        public void w(string str, params object[] args)
        {
            if (args.Length == 0)
                tabs -= Helpers.FindCount(str, 0, '}');
            bool s = false;
            if (str.LastIndexOf("\n") == str.Length - 1)
            {
                str = str.Substring(0, str.Length - 1);
                s = true;
            }
            str = str.Replace("\n", "\n" + Tabs);
            if (s) str += "\n";
            tempShader += Tabs + (args != null && args.Length > 0 ? String.Format(str, args) : str);
            if (args.Length == 0)
                tabs += Helpers.FindCount(str, 0, '{');
        }

        public static string WriteRegister(string prefix, uint num)
        {
            return "";
        }

        public static string WriteBinding(uint num, TKContext ctx)
        {
            if (!ctx.bSupportsGLSLBinding)
                return "";
            return String.Format("layout(binding = {0}) ", num);
        }

        public static string WriteLocation(TKContext ctx)
        {
            //if (ctx.bSupportsGLSLUBO)
            //    return "";
            return "uniform ";
        }

        public void _assert_(bool arg)
        {
            if (arg != true)
                Console.WriteLine();
        }

        #endregion

        public string GenerateVertexShaderCode(TKContext ctx)
        {
            tempShader = "";
            tabs = 0;

            uint lightMask = 0;
            if (UsableMaterialNode.LightChannels > 0)
                lightMask |= (uint)UsableMaterialNode._chan1._color.Lights | (uint)UsableMaterialNode._chan1._alpha.Lights;
            if (UsableMaterialNode.LightChannels > 1)
                lightMask |= (uint)UsableMaterialNode._chan2._color.Lights | (uint)UsableMaterialNode._chan2._alpha.Lights;

	        w("//Vertex Shader\n");

            // A few required defines and ones that will make our lives a lot easier
		    if (ctx.bSupportsGLSLBinding || ctx.bSupportsGLSLUBO)
		    {
			    w("#version 330 compatibility\n");
			    if (ctx.bSupportsGLSLBinding)
				    w("#extension GL_ARB_shading_language_420pack : enable\n");
                //if (ctx.bSupportsGLSLUBO)
                //    w("#extension GL_ARB_uniform_buffer_object : enable\n");
		    }
		    else
			    w("#version 120\n");
		    
		    if (ctx.bSupportsGLSLATTRBind)
			    w("#extension GL_ARB_explicit_attrib_location : enable\n");

		    // Silly differences
		    w("#define float2 vec2\n");
		    w("#define float3 vec3\n");
		    w("#define float4 vec4\n");

		    // cg to glsl function translation
		    w("#define frac(x) fract(x)\n");
		    w("#define saturate(x) clamp(x, 0.0f, 1.0f)\n");
		    w("#define lerp(x, y, z) mix(x, y, z)\n");
	        
            //// uniforms
            //if (ctx.bSupportsGLSLUBO)
            //    w("layout(std140) uniform VSBlock\n{\n");

            //w("{0}float4 " + I_POSNORMALMATRIX + "[6];\n", WriteLocation(ctx));
            //w("{0}float4 " + I_PROJECTION + "[4];\n", WriteLocation(ctx));
            w("{0}float4 " + I_MATERIALS + "[4];\n", WriteLocation(ctx));
            w("{0}float4 " + I_LIGHTS + "[40];\n", WriteLocation(ctx));

            //Tex effect matrices
            w("{0}float4 " + I_TEXMATRICES + "[24];\n", WriteLocation(ctx)); // also using tex matrices
            
            w("{0}float4 " + I_TRANSFORMMATRICES + "[64];\n", WriteLocation(ctx));
            //w("{0}float4 " + I_NORMALMATRICES + "[32];\n", WriteLocation(ctx));
            //w("{0}float4 " + I_POSTTRANSFORMMATRICES + "[64];\n", WriteLocation(ctx));
	        //w("{0}float4 " + I_DEPTHPARAMS + ";\n", WriteLocation(ctx));

            //if (ctx.bSupportsGLSLUBO) w("};\n");

	        GenerateVSOutputStruct();

            if (_normalNode != null)
                w("float3 rawnorm0 = gl_Normal;\n");

            //if (ctx.bSupportsGLSLATTRBind)
            //{
            //    if (_vertexFormat.HasPosMatrix)
            //        Write("layout(location = {0}) ATTRIN float fposmtx;\n", SHADER_POSMTX_ATTRIB);
            //    //if (components & VB_HAS_NRM1)
            //    //    Write("layout(location = {0}) ATTRIN float3 rawnorm1;\n", SHADER_NORM1_ATTRIB);
            //    //if (components & VB_HAS_NRM2)
            //    //    Write("layout(location = {0}) ATTRIN float3 rawnorm2;\n", SHADER_NORM2_ATTRIB);
            //}
            //else
            //{
            //    if (_vertexFormat.HasPosMatrix)
            //        Write("ATTRIN float fposmtx; // ATTR{0},\n", SHADER_POSMTX_ATTRIB);
            //    //if (components & VB_HAS_NRM1)
            //    //    Write("ATTRIN float3 rawnorm1; // ATTR%d,\n", SHADER_NORM1_ATTRIB);
            //    //if (components & VB_HAS_NRM2)
            //    //    Write("ATTRIN float3 rawnorm2; // ATTR%d,\n", SHADER_NORM2_ATTRIB);
            //}

		    if (_colorSet[0] != null)
                w("float4 color0 = gl_Color;\n");
		    if (_colorSet[1] != null)
                w("float4 color1 = gl_SecondaryColor;\n");

            for (int i = 0; i < 8; i++)
            {
                bool hastexmtx = _vertexFormat.GetHasTexMatrix(i);
                if (_uvSet[i] != null || hastexmtx)
                    w("float{1} tex{0} = gl_MultiTexCoord{0}.xy{2};\n", i, hastexmtx ? 3 : 2, hastexmtx ? "z" : "");
            }

            w("float4 rawpos = gl_Vertex;\n");
		    w("void main()\n{\n");
	        w("VS_OUTPUT o;\n");

            // transforms
            //if (_vertexFormat.HasPosMatrix)
            //{
            //    w("int posmtx = int(fposmtx);\n");

            //    w("float4 pos = float4(dot(" + I_TRANSFORMMATRICES + "[posmtx], rawpos), dot(" + I_TRANSFORMMATRICES + "[posmtx+1], rawpos), dot(" + I_TRANSFORMMATRICES + "[posmtx+2], rawpos), 1);\n");

            //    if (_normalNode != null)
            //    {
            //        w("int normidx = posmtx >= 32 ? (posmtx-32) : posmtx;\n");
            //        w("float3 N0 = " + I_NORMALMATRICES + "[normidx].xyz, N1 = " + I_NORMALMATRICES + "[normidx+1].xyz, N2 = " + I_NORMALMATRICES + "[normidx+2].xyz;\n");
            //    }

            //    if (_normalNode != null)
            //        w("float3 _norm0 = normalize(float3(dot(N0, rawnorm0), dot(N1, rawnorm0), dot(N2, rawnorm0)));\n");
            //    //if (components & VB_HAS_NRM1)
            //    //    w("float3 _norm1 = float3(dot(N0, rawnorm1), dot(N1, rawnorm1), dot(N2, rawnorm1));\n");
            //    //if (components & VB_HAS_NRM2)
            //    //    w("float3 _norm2 = float3(dot(N0, rawnorm2), dot(N1, rawnorm2), dot(N2, rawnorm2));\n");
            //}
            //else
            //{
            //    w("float4 pos = float4(dot(" + I_POSNORMALMATRIX + "[0], rawpos), dot(" + I_POSNORMALMATRIX + "[1], rawpos), dot(" + I_POSNORMALMATRIX + "[2], rawpos), 1.0f);\n");
            //    if (_normalNode != null)
            //        w("float3 _norm0 = normalize(float3(dot(" + I_POSNORMALMATRIX + "[3].xyz, rawnorm0), dot(" + I_POSNORMALMATRIX + "[4].xyz, rawnorm0), dot(" + I_POSNORMALMATRIX + "[5].xyz, rawnorm0)));\n");
            //    //if (components & VB_HAS_NRM1)
            //    //    w("float3 _norm1 = float3(dot("+I_POSNORMALMATRIX+"[3].xyz, rawnorm1), dot("+I_POSNORMALMATRIX+"[4].xyz, rawnorm1), dot("+I_POSNORMALMATRIX+"[5].xyz, rawnorm1));\n");
            //    //if (components & VB_HAS_NRM2)
            //    //    w("float3 _norm2 = float3(dot("+I_POSNORMALMATRIX+"[3].xyz, rawnorm2), dot("+I_POSNORMALMATRIX+"[4].xyz, rawnorm2), dot("+I_POSNORMALMATRIX+"[5].xyz, rawnorm2));\n");
            //}

            w("float4 pos = gl_ModelViewProjectionMatrix * rawpos;\n");
            if (_normalNode != null)
                w("float3 _norm0 = rawnorm0;\n");

	        if (_normalNode == null)
		        w("float3 _norm0 = float3(0.0f, 0.0f, 0.0f);\n");

            w("o.pos = pos;\n");//float4(dot("+I_PROJECTION+"[0], pos), dot("+I_PROJECTION+"[1], pos), dot("+I_PROJECTION+"[2], pos), dot("+I_PROJECTION+"[3], pos));\n");

	        w("float4 mat, lacc;\nfloat3 ldir, h;\nfloat dist, dist2, attn;\n");

            if (UsableMaterialNode.LightChannels == 0)
            {
                if (_colorSet[0] != null)
                    w("o.colors_0 = color0;\n");
                else
                    w("o.colors_0 = float4(1.0f, 1.0f, 1.0f, 1.0f);\n");
            }

	        // TODO: This probably isn't necessary if pixel lighting is enabled.
	        tempShader += GenerateLightingShader(I_MATERIALS, I_LIGHTS, "color", "o.colors_");

            if (UsableMaterialNode.LightChannels < 2)
            {
                if (_colorSet[1] != null)
                    w("o.colors_1 = color1;\n");
                else
                    w("o.colors_1 = o.colors_0;\n");
            }

	        // transform texcoords
	        w("float4 coord = float4(0.0f, 0.0f, 1.0f, 1.0f);\n");
	        for (int i = 0; i < UsableMaterialNode.Children.Count; i++) 
            {
		        MDL0MaterialRefNode texgen = UsableMaterialNode.Children[i] as MDL0MaterialRefNode;

                w("{\n");
                w("//Texgen " + i + "\n");
		        switch (texgen.Coordinates) 
                {
		            case TexSourceRow.Geometry:
			            _assert_(texgen.InputForm == TexInputForm.AB11);
			            w("coord = rawpos;\n"); // pos.w is 1
			            break;
		            case TexSourceRow.Normals:
			            if (_normalNode != null) 
                        {
			                _assert_(texgen.InputForm == TexInputForm.ABC1);
                            w("coord = float4(rawnorm0.xyz, 1.0f);\n");
			            }
			            break;
		            case TexSourceRow.Colors:
			            _assert_(texgen.Type == TexTexgenType.Color0 || texgen.Type == TexTexgenType.Color1);
			            break;
		            case TexSourceRow.BinormalsT:
                        //if (components & VB_HAS_NRM1)
                        //{
                        //      _assert_(texgen.InputForm == TexInputForm.ABC1);
                        //    Write("coord = float4(rawnorm1.xyz, 1.0f);\n");
                        //}
			            //break;
		            case TexSourceRow.BinormalsB:
                        //if (components & VB_HAS_NRM2)
                        //{
                        //    _assert_(texgen.InputForm == TexInputForm.ABC1);
                        //    Write("coord = float4(rawnorm2.xyz, 1.0f);\n");
                        //}
			            //break;
		            default:
			            _assert_(texgen.Coordinates <= TexSourceRow.TexCoord7);
                        int c = texgen.Coordinates - TexSourceRow.TexCoord0;
			            if (_uvSet[c] != null)
                            w("coord = float4(tex{0}.x, tex{0}.y, 1.0f, 1.0f);\n", c);
			            break;
		        }

		        // first transformation
		        switch (texgen.Type) 
                {
			        case TexTexgenType.EmbossMap: // calculate tex coords into bump map
                        //if (components & (VB_HAS_NRM1|VB_HAS_NRM2)) 
                        //{
                        //    // transform the light dir into tangent space
                        //    Write("ldir = normalize("+I_LIGHTS+"[{0} + 3].xyz - pos.xyz);\n", texgen.EmbossLight);
                        //    Write("o.tex{0}.xyz = o.tex{1}.xyz + float3(dot(ldir, _norm1), dot(ldir, _norm2), 0.0f);\n", i, texgen.EmbossSource);
                        //}
                        //else
                        //{
                        //    //_assert_(0); // should have normals
                        //    Write("o.tex{0}.xyz = o.tex{1}.xyz;\n", i, texgen.EmbossSource);
                        //}

				        break;
			        case TexTexgenType.Color0:
			        case TexTexgenType.Color1:
				        _assert_(texgen.Coordinates == TexSourceRow.Colors);
				        w("o.tex{0}.xyz = float3(o.colors_{1}.x, o.colors_{1}.y, 1);\n", i, ((int)texgen.Type - (int)TexTexgenType.Color0).ToString());
				        break;
			        case TexTexgenType.Regular:
			        default:
				        if (_vertexFormat.GetHasTexMatrix(i))
				        {
					        w("int tmp = int(tex{0}.z);\n", i);
                            if (texgen.Projection == TexProjection.STQ)
                                w("o.tex{0}.xyz = float3(dot(coord, " + I_TRANSFORMMATRICES + "[tmp]), dot(coord, " + I_TRANSFORMMATRICES + "[tmp+1]), dot(coord, " + I_TRANSFORMMATRICES + "[tmp+2]));\n", i);
                            else
                            {
                                w("o.tex{0}.xyz = float3(dot(coord, " + I_TRANSFORMMATRICES + "[tmp]), dot(coord, " + I_TRANSFORMMATRICES + "[tmp+1]), 1);\n", i);
                                w("o.tex{0}.z = 1.0f", 1);
                            }
                        }
				        else
                        {
                            if (texgen.Projection == TexProjection.STQ)
						        w("o.tex{0}.xyz = float3(dot(coord, " + I_TEXMATRICES + "[{1}]), dot(coord, " + I_TEXMATRICES + "[{2}]), dot(coord, "+I_TEXMATRICES+"[{3}]));\n", i, 3*i, 3*i+1, 3*i+2);
					        else
						        w("o.tex{0}.xyz = float3(dot(coord, " + I_TEXMATRICES + "[{1}]), dot(coord, " + I_TEXMATRICES + "[{2}]), 1);\n", i, 3*i, 3*i+1);
				        }
				        break;
		        }

                //Dual tex trans always enabled?
		        if (texgen.Type == TexTexgenType.Regular)
                {
                    // only works for regular tex gen types?
                    //int postidx = texgen.DualTexFlags.DualMtx;
                    //w("float4 P0 = " + I_POSTTRANSFORMMATRICES + "[{0}];\n"+
                    //  "float4 P1 = " + I_POSTTRANSFORMMATRICES + "[{1}];\n"+
                    //  "float4 P2 = " + I_POSTTRANSFORMMATRICES + "[{2}];\n",
                    //  postidx&0x3f, (postidx+1)&0x3f, (postidx+2)&0x3f);

                    if (texgen.Normalize)
					    w("o.tex{0}.xyz = normalize(o.tex{0}.xyz);\n", i);

				    // multiply by postmatrix
				    //w("o.tex{0}.xyz = float3(dot(P0.xyz, o.tex{0}.xyz) + P0.w, dot(P1.xyz, o.tex{0}.xyz) + P1.w, dot(P2.xyz, o.tex{0}.xyz) + P2.w);\n", i);
		        }

		        w("}\n");
	        }

	        // clipPos/w needs to be done in pixel shader, not here
	        if (UsableMaterialNode.Children.Count < 7) 
		        w("o.clipPos = float4(pos.x,pos.y,o.pos.z,o.pos.w);\n");
            else 
            {
		        w("o.tex0.w = pos.x;\n");
		        w("o.tex1.w = pos.y;\n");
		        w("o.tex2.w = o.pos.z;\n");
		        w("o.tex3.w = o.pos.w;\n");
	        }

            //if(g_ActiveConfig.bEnablePixelLighting && ctx.bSupportsPixelLighting)
            //{
                if (UsableMaterialNode.Children.Count < 7) 
			        w("o.Normal = float4(_norm0.x,_norm0.y,_norm0.z,pos.z);\n");
                else 
                {
			        w("o.tex4.w = _norm0.x;\n");
			        w("o.tex5.w = _norm0.y;\n");
			        w("o.tex6.w = _norm0.z;\n");
			        if (UsableMaterialNode.Children.Count < 8)
				        w("o.tex7 = pos.xyzz;\n");
			        else
				        w("o.tex7.w = pos.z;\n");
		        }
		        if (_colorSet[0] != null)
			        w("o.colors_0 = color0;\n");

                if (_colorSet[1] != null)
			        w("o.colors_1 = color1;\n");
            //}

	        //write the true depth value, if the game uses depth textures pixel shaders will override with the correct values
	        //if not early z culling will improve speed

	        // this results in a scale from -1..0 to -1..1 after perspective
	        // divide
	        //w("o.pos.z = o.pos.w + o.pos.z * 2.0f;\n");

	        // Sonic Unleashed puts its final rendering at the near or
	        // far plane of the viewing frustrum(actually box, they use
	        // orthogonal projection for that), and we end up putting it
	        // just beyond, and the rendering gets clipped away. (The
	        // primitive gets dropped)
	        //w("o.pos.z = o.pos.z * 1048575.0f/1048576.0f;\n");

	        // the next steps of the OGL pipeline are:
	        // (x_c,y_c,z_c,w_c) = o.pos  //switch to OGL spec terminology
	        // clipping to -w_c <= (x_c,y_c,z_c) <= w_c
	        // (x_d,y_d,z_d) = (x_c,y_c,z_c)/w_c//perspective divide
	        // z_w = (f-n)/2*z_d + (n+f)/2
	        // z_w now contains the value to go to the 0..1 depth buffer

	        //trying to get the correct semantic while not using glDepthRange
	        //seems to get rather complicated
	        
		    // Bit ugly here
		    // Will look better when we bind uniforms in GLSL 1.3
		    // clipPos/w needs to be done in pixel shader, not here

		    if (UsableMaterialNode.Children.Count < 7) 
            {
			    for (uint i = 0; i < UsableMaterialNode.Children.Count; i++)
				    w("gl_TexCoord[{0}].xyz = o.tex{0};\n", i);
			    w("gl_TexCoord[{0}] = o.clipPos;\n", UsableMaterialNode.Children.Count);
			    //if(g_ActiveConfig.bEnablePixelLighting && ctx.bSupportsPixelLighting)
				    w("gl_TexCoord[{0}] = o.Normal;\n", UsableMaterialNode.Children.Count + 1);
		    } 
            else 
            {
			    // clip position is in w of first 4 texcoords
                //if (g_ActiveConfig.bEnablePixelLighting && ctx.bSupportsPixelLighting)
                //{
				    for (int i = 0; i < 8; i++)
					    w("gl_TexCoord[{0}] = o.tex{0};\n", i);
                //}
                //else
                //{
                //    for (unsigned int i = 0; i < xfregs.numTexGen.numTexGens; ++i)
                //        Write("  gl_TexCoord[%d]%s = o.tex%d;\n", i, i < 4 ? ".xyzw" : ".xyz" , i);
                //}
            }
            w("gl_FrontColor = o.colors_0;\n");
            w("gl_FrontSecondaryColor = o.colors_1;\n");
		    w("gl_Position = o.pos;\n");
		    w("}\n");

            return tempShader;
        }

        #endregion

        #region Light Shader
        public int temptabs = 0;
        [Browsable(false)]
        public string TempTabs { get { string t = ""; for (int i = 0; i < temptabs; i++) t += "\t"; return t; } }
        public void w(ref string output, string str, params object[] args)
        {
            temptabs = tabs;
            if (args.Length == 0)
                temptabs -= Helpers.FindCount(str, 0, '}');
            bool s = false;
            if (str.LastIndexOf("\n") == str.Length - 1)
            {
                str = str.Substring(0, str.Length - 1);
                s = true;
            }
            str = str.Replace("\n", "\n" + TempTabs);
            if (s) str += "\n";
            output += Tabs + TempTabs + (args != null && args.Length > 0 ? String.Format(str, args) : str);
            if (args.Length == 0)
                temptabs += Helpers.FindCount(str, 0, '{');
        }

        // coloralpha - 1 if color, 2 if alpha
        public string GenerateLightShader(int index, LightChannelControl chan, string lightsName, int coloralpha)
        {
            string s = "";

            string swizzle = "xyzw";
            if (coloralpha == 1 ) swizzle = "xyz";
            else if (coloralpha == 2 ) swizzle = "w";

            if (chan.Attenuation == GXAttnFn.None) 
            {
                // atten disabled
                switch (chan.DiffuseFunction) 
                {
                    case GXDiffuseFn.Disabled:
                        w(ref s, "lacc.{0} += {1}[{2}].{3};\n", swizzle, lightsName, index * 5, swizzle);
                        break;
                    case GXDiffuseFn.Enabled:
                    case GXDiffuseFn.Clamped:
                        w(ref s, "ldir = normalize({0}[{1} + 3].xyz - pos.xyz);\n", lightsName, index * 5);
                        w(ref s, "lacc.{0} += {1}dot(ldir, _norm0)) * {2}[{3}].{4};\n", swizzle, chan.DiffuseFunction != GXDiffuseFn.Enabled ? "max(0.0f," : "(", lightsName, index * 5, swizzle);
                        break;
                }
            }
            else
            {
                // spec and spot
                if (chan.Attenuation == GXAttnFn.Spotlight)
                {
                    // spot
                    w(ref s, "ldir = {0}[{1} + 3].xyz - pos.xyz;\n", lightsName, index * 5);
                    w(ref s, "dist2 = dot(ldir, ldir);\n" +
                            "dist = sqrt(dist2);\n" +
                            "ldir = ldir / dist;\n" +
                            "attn = max(0.0f, dot(ldir, {0}[{1} + 4].xyz));\n", lightsName, index * 5);
                    w(ref s, "attn = max(0.0f, dot({0}[{1} + 1].xyz, float3(1.0f, attn, attn*attn))) / dot({2}[{3} + 2].xyz, float3(1.0f,dist,dist2));\n", lightsName, index * 5, lightsName, index * 5);
                }
                if (chan.Attenuation == GXAttnFn.Specular)
                {
                    // specular
                    w(ref s, "ldir = normalize({0}[{1} + 3].xyz);\n", lightsName, index * 5);
                    w(ref s, "attn = (dot(_norm0, ldir) >= 0.0f) ? max(0.0f, dot(_norm0, {0}[{1} + 4].xyz)) : 0.0f;\n", lightsName, index * 5);
                    w(ref s, "attn = max(0.0f, dot({0}[{1} + 1].xyz, float3(1,attn,attn*attn))) / dot({2}[{3} + 2].xyz, float3(1,attn,attn*attn));\n", lightsName, index * 5, lightsName, index * 5);
                }

                switch (chan.DiffuseFunction)
                {
                    case GXDiffuseFn.Disabled:
                        w(ref s, "lacc.{0} += attn * {1}[{2}].{3};\n", swizzle, lightsName, index * 5, swizzle);
                        break;
                    case GXDiffuseFn.Enabled:
                    case GXDiffuseFn.Clamped:
                        w(ref s, "lacc.{0} += attn * {1}dot(ldir, _norm0)) * {2}[{3}].{4};\n",
                        swizzle,
                        chan.DiffuseFunction != GXDiffuseFn.Enabled ? "max(0.0f," : "(",
                        lightsName,
                        index * 5,
                        swizzle);
                        break;
                }
            }
            w(ref s, "\n");
            return s;
        }

        // vertex shader
        // lights/colors
        // materials name is I_MATERIALS in vs and I_PMATERIALS in ps
        // inColorName is color in vs and colors_ in ps
        // dest is o.colors_ in vs and colors_ in ps
        public string GenerateLightingShader(string materialsName, string lightsName, string inColorName, string dest)
        {
            string s = Tabs + "{\n";
            w(ref s, "//Lighting Section\n");
            for (uint j = 0; j < UsableMaterialNode.LightChannels; j++)
            {
                LightChannelControl color = j == 0 ? UsableMaterialNode._chan1._color : UsableMaterialNode._chan2._color;
                LightChannelControl alpha = j == 0 ? UsableMaterialNode._chan1._alpha : UsableMaterialNode._chan2._alpha;

                if (color.MaterialSource == GXColorSrc.Vertex) 
                    if (_colorSet[j] != null)
                        w(ref s, "mat = {0}{1};\n", inColorName, j);
                    else if (_colorSet[0] != null)
                        w(ref s, "mat = {0}0;\n", inColorName);
                    else
                        w(ref s, "mat = vec4(1.0f, 1.0f, 1.0f, 1.0f);\n");
                else
                    w(ref s, "mat = {0}[{1}];\n", materialsName, j + 2);

                if (color.Enabled) 
                    if (color.AmbientSource == GXColorSrc.Vertex) 
                        if (_colorSet[j] != null)
                            w(ref s, "lacc = {0}{1};\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            w(ref s, "lacc = {0}0;\n", inColorName);
                        else
                            w(ref s, "lacc = vec4(0.0f, 0.0f, 0.0f, 0.0f);\n");
                    else 
                        w(ref s, "lacc = {0}[{1}];\n", materialsName, j);
                else
                    w(ref s, "lacc = vec4(1.0f, 1.0f, 1.0f, 1.0f);\n");

                // check if alpha is different
                if (alpha.MaterialSource != color.MaterialSource) 
                    if (alpha.MaterialSource == GXColorSrc.Vertex) 
                        if (_colorSet[j] != null)
                            w(ref s, "mat.w = {0}{1}.w;\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            w(ref s, "mat.w = {0}0.w;\n", inColorName);
                        else
                            w(ref s, "mat.w = 1.0f;\n");
                    else 
                        w(ref s, "mat.w = {0}[{1}].w;\n", materialsName, j + 2);
                
                if (alpha.Enabled)
                    if (alpha.AmbientSource == GXColorSrc.Vertex) 
                        if (_colorSet[j] != null)
                            w(ref s, "lacc.w = {0}{1}.w;\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            w(ref s, "lacc.w = {0}0.w;\n", inColorName);
                        else
                            w(ref s, "lacc.w = 0.0f;\n");
                    else
                        w(ref s, "lacc.w = {0}[{1}].w;\n", materialsName, j);
                else
                    w(ref s, "lacc.w = 1.0f;\n");

                if (color.Enabled && alpha.Enabled)
                {
                    //Both have lighting, test if they use the same lights
                    int mask = 0;
                    if (color.Lights == alpha.Lights)
                    {
                        mask = (int)color.Lights & (int)alpha.Lights;
                        if (mask != 0)
                        {
                            for (int i = 0; i < 8; i++)
                                if ((mask & (1 << i)) != 0)
                                    w(ref s, GenerateLightShader(i, color, lightsName, 3));
                        }
                    }

                    //No shared lights
                    for (int i = 0; i < 8; i++)
                    {
                        if (((mask & (1 << i)) == 0) && ((int)color.Lights & (1 << i)) != 0)
                            w(ref s, GenerateLightShader(i, color, lightsName, 1));
                        if (((mask & (1 << i)) == 0) && ((int)alpha.Lights & (1 << i)) != 0)
                            w(ref s, GenerateLightShader(i, alpha, lightsName, 2));
                    }
                }
                else if (color.Enabled || alpha.Enabled)
                {
                    //Lights are disabled on one channel so process only the active ones
                    LightChannelControl workingchannel = color.Enabled ? color : alpha;
                    int coloralpha = color.Enabled ? 1 : 2;
                    for (int i = 0; i < 8; i++)
                        if (((int)workingchannel.Lights & (1 << i)) != 0)
                            w(ref s, GenerateLightShader(i, workingchannel, lightsName, coloralpha));
                }
                w(ref s, "{0}{1} = mat * saturate(lacc);\n", dest, j);
            }
            w(ref s, "}\n");
            return s;
        }

        #endregion
        
        //public int _vsBlockLoc = 0, BufferUBO = 0, BufferIndex = 0;
        //public void SetVSBlock()
        //{
        //    GL.GenBuffers(1, out BufferUBO); // Generate the buffer
        //    GL.BindBuffer(BufferTarget.UniformBuffer, BufferUBO); // Bind the buffer for writing
        //    GL.BufferData(BufferTarget.UniformBuffer, (IntPtr)(sizeof(float) * 8), (IntPtr)(null), BufferUsageHint.DynamicDraw); // Request the memory to be allocated
        //    GL.BindBufferRange(BufferTarget.UniformBuffer, BufferIndex, BufferUBO, (IntPtr)0, (IntPtr)(sizeof(float) * 8)); // Bind the created Uniform Buffer to the Buffer Index
        //    _vsBlockLoc = GL.GetUniformBlockIndex(shaderProgramHandle, "VSBlock");
        //    GL.UniformBlockBinding(shaderProgramHandle, _vsBlockLoc, BufferIndex);
        //    GL.BindBuffer(BufferTarget.UniformBuffer, BufferUBO);
        //    GL.BufferSubData(BufferTarget.UniformBuffer, (IntPtr)0, (IntPtr)(sizeof(float) * 8), ref vsData);
        //    GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        //}
        
        public void SetMultiPSConstant4fv(uint offset, float* f, uint count)
        {
	        GL.BufferSubData(BufferTarget.UniformBuffer, (IntPtr)(offset * sizeof(float) * 4), (IntPtr)(count * sizeof(float) * 4), (IntPtr)f);
        }

        public void SetMultiVSConstant4fv(uint offset, float* f, uint count)
        {
            GL.BufferSubData(BufferTarget.UniformBuffer, (IntPtr)(offset * sizeof(float) * 4), (IntPtr)(count * sizeof(float) * 4), (IntPtr)f);
        }

        public int[] UniformLocations = new int[UniformNames.Length];
        public static readonly string[] UniformNames =
        {
	        // SAMPLERS
	        "samp0","samp1","samp2","samp3","samp4","samp5","samp6","samp7",
	        // PIXEL SHADER UNIFORMS
	        MDL0MaterialNode.I_COLORS,
	        MDL0MaterialNode.I_KCOLORS,
	        MDL0MaterialNode.I_ALPHA,
	        MDL0MaterialNode.I_TEXDIMS,
	        MDL0MaterialNode.I_ZBIAS,
	        MDL0MaterialNode.I_INDTEXSCALE,
	        MDL0MaterialNode.I_INDTEXMTX,
	        MDL0MaterialNode.I_FOG,
	        MDL0MaterialNode.I_PLIGHTS,
	        MDL0MaterialNode.I_PMATERIALS,
	        // VERTEX SHADER UNIFORMS
	        I_POSNORMALMATRIX,
	        I_PROJECTION,
	        I_MATERIALS,
	        I_LIGHTS,
	        I_TEXMATRICES,
	        I_TRANSFORMMATRICES,
	        I_NORMALMATRICES,
	        I_POSTTRANSFORMMATRICES,
	        I_DEPTHPARAMS,
        };

        public void SetProgramVariables(TKContext ctx)
        {
            if (ctx.bSupportsGLSLUBO)
            {
                GL.UniformBlockBinding(shaderProgramHandle, 0, 1);
                if (vertexShaderHandle != 0)
                    GL.UniformBlockBinding(shaderProgramHandle, 1, 2);
            }

            if (!ctx.bSupportsGLSLUBO)
                for (int a = 8; a < UniformNames.Length; a++)
                    UniformLocations[a] = GL.GetUniformLocation(shaderProgramHandle, UniformNames[a]);

            if (!ctx.bSupportsGLSLBinding)
                for (int a = 0; a < 8; a++)
                    if ((UniformLocations[a] = GL.GetUniformLocation(shaderProgramHandle, UniformNames[a])) != -1)
                        GL.Uniform1(UniformLocations[a], a);

            // Need to get some attribute locations
            if (vertexShaderHandle != 0 && !ctx.bSupportsGLSLATTRBind)
            {
                // We have no vertex Shader
                GL.BindAttribLocation(shaderProgramHandle, SHADER_NORM1_ATTRIB, "rawnorm1");
                GL.BindAttribLocation(shaderProgramHandle, SHADER_NORM2_ATTRIB, "rawnorm2");
                GL.BindAttribLocation(shaderProgramHandle, SHADER_POSMTX_ATTRIB, "fposmtx");
            }
        }

        public string fragmentShaderSource;
        public int fragmentShaderHandle;
        public int shaderProgramHandle = 0;
        /*
            w("{0}float4 " + I_POSNORMALMATRIX + "[6];\n", WriteLocation(ctx));
            w("{0}float4 " + I_PROJECTION + "[4];\n", WriteLocation(ctx));
            w("{0}float4 " + I_MATERIALS + "[4];\n", WriteLocation(ctx));
            w("{0}float4 " + I_LIGHTS + "[40];\n", WriteLocation(ctx));

            //Tex effect matrices
            w("{0}float4 " + I_TEXMATRICES + "[24];\n", WriteLocation(ctx)); // also using tex matrices
            
            w("{0}float4 " + I_TRANSFORMMATRICES + "[64];\n", WriteLocation(ctx));
            w("{0}float4 " + I_NORMALMATRICES + "[32];\n", WriteLocation(ctx));
            w("{0}float4 " + I_POSTTRANSFORMMATRICES + "[64];\n", WriteLocation(ctx));
	        w("{0}float4 " + I_DEPTHPARAMS + ";\n", WriteLocation(ctx));
         * 
            //24
            //16
            //16
            //160
            //96
            //256
            //128
            //256
            //4
        */
        public void SetLightUniforms(int programHandle)
        {
            int currUniform = GL.GetUniformLocation(programHandle, I_LIGHTS);
            if (currUniform > -1)
            {
                int frame = UsableMaterialNode.renderFrame;
                List<float> values = new List<float>();
                foreach (SCN0LightNode l in UsableMaterialNode._lightSet._lights)
                {
                    //float4 col; float4 cosatt; float4 distatt; float4 pos; float4 dir;

                    RGBAPixel p = (RGBAPixel)l.GetColor(frame, 0);
                    values.Add((float)p.R * RGBAPixel.ColorFactor);
                    values.Add((float)p.G * RGBAPixel.ColorFactor);
                    values.Add((float)p.B * RGBAPixel.ColorFactor);
                    values.Add((float)p.A * RGBAPixel.ColorFactor);
                    Vector3 v = l.GetLightSpot(frame);
                    values.Add(v._x);
                    values.Add(v._y);
                    values.Add(v._z);
                    values.Add(1.0f);
                    v = l.GetLightDistAttn(frame);
                    values.Add(v._x);
                    values.Add(v._y);
                    values.Add(v._z);
                    values.Add(1.0f);
                    v = l.GetStart(frame);
                    values.Add(v._x);
                    values.Add(v._y);
                    values.Add(v._z);
                    values.Add(1.0f);
                    Vector3 v2 = l.GetEnd(frame);
                    Vector3 dir = Matrix.AxisAngleMatrix(v, v2).GetAngles();
                    values.Add(dir._x);
                    values.Add(dir._y);
                    values.Add(dir._z);
                    values.Add(1.0f);
                }
                
                GL.Uniform4(currUniform, 40, values.ToArray());
            }
        }
        public void SetUniforms(int programHandle)
        {
            int currUniform = -1;

            //currUniform = GL.GetUniformLocation(programHandle, I_POSNORMALMATRIX);
            //if (currUniform > -1) GL.Uniform4(currUniform, 6, new float[] 
            //{
                
            //});
            //currUniform = GL.GetUniformLocation(programHandle, I_PROJECTION);
            //if (currUniform > -1) GL.Uniform4(currUniform, 4, new float[] 
            //{
                
            //});
            currUniform = GL.GetUniformLocation(programHandle, I_MATERIALS);
            if (currUniform > -1) GL.Uniform4(currUniform, 4, new float[] 
            {
                UsableMaterialNode.C1AmbientColor.R * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1AmbientColor.G * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1AmbientColor.B * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1AmbientColor.A * RGBAPixel.ColorFactor,

                UsableMaterialNode.C2AmbientColor.R * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2AmbientColor.G * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2AmbientColor.B * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2AmbientColor.A * RGBAPixel.ColorFactor,

                UsableMaterialNode.C1MaterialColor.R * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1MaterialColor.G * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1MaterialColor.B * RGBAPixel.ColorFactor,
                UsableMaterialNode.C1MaterialColor.A * RGBAPixel.ColorFactor,

                UsableMaterialNode.C2MaterialColor.R * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2MaterialColor.G * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2MaterialColor.B * RGBAPixel.ColorFactor,
                UsableMaterialNode.C2MaterialColor.A * RGBAPixel.ColorFactor,
            });
            currUniform = GL.GetUniformLocation(programHandle, I_TEXMATRICES);
            if (currUniform > -1)
            {
                List<float> mtxValues = new List<float>();
                int i = 0;
                foreach (MDL0MaterialRefNode m in UsableMaterialNode.Children)
                {
                    for (int x = 0; x < 12; x++)
                        mtxValues.Add(m.EffectMatrix[x]);
                    i++;
                }
                while (i < 8)
                {
                    for (int x = 0; x < 12; x++)
                        mtxValues.Add(Matrix43.Identity[x]);
                    i++;
                }
                if (mtxValues.Count != 96)
                    Console.WriteLine();
                GL.Uniform4(currUniform, 24, mtxValues.ToArray());
            }
            //currUniform = GL.GetUniformLocation(programHandle, I_TRANSFORMMATRICES);
            //if (currUniform > -1) GL.Uniform4(currUniform, 64, new float[] 
            //{
                
            //});
            //currUniform = GL.GetUniformLocation(programHandle, I_NORMALMATRICES);
            //if (currUniform > -1) GL.Uniform4(currUniform, 32, new float[] 
            //{
                
            //});
            //currUniform = GL.GetUniformLocation(programHandle, I_DEPTHPARAMS);
            //if (currUniform > -1) GL.Uniform4(currUniform, 1, new float[] 
            //{

            //});

        }

#endregion

        internal bool _render = true;
        public void PreRender()
        {
            if (_singleBind != null)
            {
                GL.PushMatrix();
                Matrix m = _singleBind.Matrix;
                GL.MultMatrix((float*)&m);
            }

            if (UsableMaterialNode != null)
            {
                switch ((int)UsableMaterialNode.CullMode)
                {
                    case 0: //None
                        GL.Disable(EnableCap.CullFace);
                        break;
                    case 1: //Outside
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Front);
                        break;
                    case 2: //Inside
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.Back);
                        break;
                    case 3: //Double
                        GL.Enable(EnableCap.CullFace);
                        GL.CullFace(CullFaceMode.FrontAndBack);
                        break;
                }

                //if (_opaMaterial.EnableDepthTest)
                //{
                //    GL.Enable(EnableCap.DepthTest);
                //    DepthFunction depth = DepthFunction.Lequal;
                //    switch (_opaMaterial.DepthFunction)
                //    {
                //        case GXCompare.Never:
                //            depth = DepthFunction.Never; break;
                //        case GXCompare.Less:
                //            depth = DepthFunction.Less; break;
                //        case GXCompare.Equal:
                //            depth = DepthFunction.Equal; break;
                //        case GXCompare.LessOrEqual:
                //            depth = DepthFunction.Lequal; break;
                //        case GXCompare.Greater:
                //            depth = DepthFunction.Greater; break;
                //        case GXCompare.NotEqual:
                //            depth = DepthFunction.Notequal; break;
                //        case GXCompare.GreaterOrEqual:
                //            depth = DepthFunction.Gequal; break;
                //        case GXCompare.Always:
                //            depth = DepthFunction.Always; break;
                //    }
                //    GL.DepthFunc(depth);
                //}
                //else
                //    GL.Disable(EnableCap.DepthTest);

                //if (_opaMaterial._blendMode.EnableBlend)
                //{
                //    GL.Enable(EnableCap.Blend);
                //    BlendingFactorSrc src = BlendingFactorSrc.OneMinusSrcAlpha;
                //    switch (_opaMaterial._blendMode.SrcFactor)
                //    {
                //        case BlendFactor.DestinationAlpha:
                //            src = BlendingFactorSrc.DstAlpha; break;
                //        case BlendFactor.DestinationColor:
                //            src = BlendingFactorSrc.DstColor; break;
                //        case BlendFactor.InverseDestinationAlpha:
                //            src = BlendingFactorSrc.OneMinusDstAlpha; break;
                //        case BlendFactor.InverseDestinationColor:
                //            src = BlendingFactorSrc.OneMinusDstColor; break;
                //        case BlendFactor.InverseSourceAlpha:
                //            src = BlendingFactorSrc.OneMinusSrcAlpha; break;
                //        //case BlendFactor.InverseSourceColor:
                //        //    src = BlendingFactorSrc.ONE_MINUS_SRC_COLOR; break;
                //        case BlendFactor.One:
                //            src = BlendingFactorSrc.One; break;
                //        case BlendFactor.SourceAlpha:
                //            src = BlendingFactorSrc.SrcAlpha; break;
                //        //case BlendFactor.SourceColor:
                //        //    src = BlendingFactorSrc.SrcColor; break;
                //        case BlendFactor.Zero:
                //            src = BlendingFactorSrc.Zero; break;
                //    }
                //    BlendingFactorDest dst = BlendingFactorDest.OneMinusSrcAlpha;
                //    switch (_opaMaterial._blendMode.DstFactor)
                //    {
                //        case BlendFactor.DestinationAlpha:
                //            dst = BlendingFactorDest.DstAlpha; break;
                //        case BlendFactor.DestinationColor:
                //            dst = BlendingFactorDest.DstColor; break;
                //        case BlendFactor.InverseDestinationAlpha:
                //            dst = BlendingFactorDest.OneMinusDstAlpha; break;
                //        case BlendFactor.InverseDestinationColor:
                //            dst = BlendingFactorDest.OneMinusDstColor; break;
                //        case BlendFactor.InverseSourceAlpha:
                //            dst = BlendingFactorDest.OneMinusSrcAlpha; break;
                //        //case BlendFactor.InverseSourceColor:
                //        //    dst = BlendingFactorDest.ONE_MINUS_SRC_COLOR; break;
                //        case BlendFactor.One:
                //            dst = BlendingFactorDest.One; break;
                //        case BlendFactor.SourceAlpha:
                //            dst = BlendingFactorDest.SrcAlpha; break;
                //        //case BlendFactor.SourceColor:
                //        //    dst = BlendingFactorDest.SrcColor; break;
                //        case BlendFactor.Zero:
                //            dst = BlendingFactorDest.Zero; break;
                //    }
                //    GL.BlendFunc(src, dst);
                //}
                //else
                //    GL.Disable(EnableCap.Blend);

                //if (_opaMaterial.EnableBlendLogic)
                //{
                //    GL.Enable(EnableCap.ColorLogicOp);
                //    GL.LogicOp((LogicOp)((int)LogicOp.Clear + (int)_opaMaterial.BlendLogicOp));
                //}
                //else
                //    GL.Disable(EnableCap.ColorLogicOp);

                //if (_material.EnableAlphaFunction)
                //{
                //    GL.Enable(EnableCap.AlphaTest);

                //    double near = 0.0f, far = 1.0f;
                //    EvalAlphaFunc(out near, out far);
                //    GL.DepthRange(near, far);

                //    AlphaFunction alpha = AlphaFunction.Greater;
                //    switch (_material._alphaFunc.Comp0)
                //    {
                //        case AlphaCompare.Never:
                //            alpha = AlphaFunction.Never; break;
                //        case AlphaCompare.Less:
                //            alpha = AlphaFunction.Less; break;
                //        case AlphaCompare.Equal:
                //            alpha = AlphaFunction.Equal; break;
                //        case AlphaCompare.LessOrEqual:
                //            alpha = AlphaFunction.Lequal; break;
                //        case AlphaCompare.Greater:
                //            alpha = AlphaFunction.Greater; break;
                //        case AlphaCompare.NotEqual:
                //            alpha = AlphaFunction.Notequal; break;
                //        case AlphaCompare.GreaterOrEqual:
                //            alpha = AlphaFunction.Gequal; break;
                //        case AlphaCompare.Always:
                //            alpha = AlphaFunction.Always; break;
                //    }
                //    GL.AlphaFunc(alpha, ((float)_material._alphaFunc.ref0) / 255.0f);
                //    switch (_material._alphaFunc.Comp1)
                //    {
                //        case AlphaCompare.Never:
                //            alpha = AlphaFunction.Never; break;
                //        case AlphaCompare.Less:
                //            alpha = AlphaFunction.Less; break;
                //        case AlphaCompare.Equal:
                //            alpha = AlphaFunction.Equal; break;
                //        case AlphaCompare.LessOrEqual:
                //            alpha = AlphaFunction.Lequal; break;
                //        case AlphaCompare.Greater:
                //            alpha = AlphaFunction.Greater; break;
                //        case AlphaCompare.NotEqual:
                //            alpha = AlphaFunction.Notequal; break;
                //        case AlphaCompare.GreaterOrEqual:
                //            alpha = AlphaFunction.Gequal; break;
                //        case AlphaCompare.Always:
                //            alpha = AlphaFunction.Always; break;
                //    }
                //    GL.AlphaFunc(alpha, ((float)_material._alphaFunc.ref1) / 255.0f);
                //}
                //else
                //    GL.Disable(EnableCap.AlphaTest);
            }
        }

        internal void Render(TKContext ctx)
        {
            if (!_render)
                return;

            if (ctx._canUseShaders)
            {
                bool temp = false;

                //_renderUpdate = MaterialNode._renderUpdate = MaterialNode.ShaderNode._renderUpdate = true;

                bool updateProgram = _renderUpdate || UsableMaterialNode._renderUpdate || UsableMaterialNode.ShaderNode._renderUpdate;
                if (updateProgram)
                {
                    temp = true;

                    if (shaderProgramHandle > 0)
                        GL.DeleteProgram(shaderProgramHandle);

                    shaderProgramHandle = GL.CreateProgram();

                    int status_code;
                    string info;

                    if (_renderUpdate)
                    {
                        vertexShaderSource = GenerateVertexShaderCode(ctx);

                        GL.ShaderSource(vertexShaderHandle, vertexShaderSource);
                        GL.CompileShader(vertexShaderHandle);

                        GL.GetShaderInfoLog(vertexShaderHandle, out info);
                        GL.GetShader(vertexShaderHandle, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, out status_code);
                        //Console.WriteLine(info + "\n\n" + vertexShaderSource + "\n\n");
                        if (status_code != 1)
                        {
                            //MessageBox.Show(info);
                            Console.WriteLine(info + "\n\n" + vertexShaderSource + "\n\n");
                        }
                        else
                            GL.AttachShader(shaderProgramHandle, vertexShaderHandle);
                    }
                    if (_renderUpdate || UsableMaterialNode._renderUpdate || UsableMaterialNode.ShaderNode._renderUpdate)
                    {
                        fragmentShaderSource = UsableMaterialNode.GeneratePixelShaderCode(this, MDL0MaterialNode.PSGRENDER_MODE.PSGRENDER_NORMAL, ctx);

                        GL.ShaderSource(fragmentShaderHandle, fragmentShaderSource);
                        GL.CompileShader(fragmentShaderHandle);

                        GL.GetShaderInfoLog(fragmentShaderHandle, out info);
                        GL.GetShader(fragmentShaderHandle, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, out status_code);
                        //Console.WriteLine(info + "\n\n" + fragmentShaderSource + "\n\n");
                        if (status_code != 1)
                        {
                            //MessageBox.Show(info);
                            Console.WriteLine(info + "\n\n" + fragmentShaderSource + "\n\n");
                        }
                        else
                            GL.AttachShader(shaderProgramHandle, fragmentShaderHandle);

                        UsableMaterialNode._renderUpdate = UsableMaterialNode.ShaderNode._renderUpdate = false;
                    }

                    _renderUpdate = false;

                    GL.LinkProgram(shaderProgramHandle);
                }

                GL.UseProgram(shaderProgramHandle);

                if (temp)
                {
                    SetUniforms(shaderProgramHandle);
                    UsableMaterialNode.SetUniforms(shaderProgramHandle);
                }
                if (UsableMaterialNode._lightSet != null)
                    SetLightUniforms(shaderProgramHandle);
            }

            _manager.PrepareStream();

            PreRender();

            if (UsableMaterialNode != null)
                if (UsableMaterialNode.Children.Count == 0) _manager.RenderTexture(null);
                else foreach (MDL0MaterialRefNode mr in UsableMaterialNode.Children)
                {
                    if (mr._texture != null && (!mr._texture.Enabled || mr._texture.Rendered))
                        continue;

                    GL.MatrixMode(MatrixMode.Texture);

                    GL.PushMatrix();

                    //Add bind transform
                    GL.Scale(mr.Scale._x, mr.Scale._y, 0);
                    GL.Rotate(mr.Rotation, 1, 0, 0);
                    GL.Translate(-mr.Translation._x, mr.Translation._y, 0);

                    //Now add frame transform
                    GL.Scale(mr._frameState._scale._x, mr._frameState._scale._y, 1);
                    GL.Rotate(mr._frameState._rotate._x, 1, 0, 0);
                    GL.Translate(-mr._frameState._translate._x, mr._frameState._translate._y - ((mr._frameState._scale._y - 1) / 2), 0);

                    GL.MatrixMode(MatrixMode.Modelview);

                    mr.Bind(ctx, shaderProgramHandle);
                    
                    _manager.RenderTexture(mr);

                    switch ((int)mr.UWrapMode)
                    {
                        case 0: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge); break;
                        case 1: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat); break;
                        case 2: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.MirroredRepeat); break;
                    }

                    switch ((int)mr.VWrapMode)
                    {
                        case 0: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge); break;
                        case 1: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat); break;
                        case 2: GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.MirroredRepeat); break;
                    }

                    GL.MatrixMode(MatrixMode.Texture);
                    GL.PopMatrix();
                    GL.MatrixMode(MatrixMode.Modelview);

                    //mr._texture.Rendered = true;
                }
            else
                _manager.RenderTexture(null);
            
            _manager.DetachStreams();

            if (_singleBind != null)
                GL.PopMatrix();
        }

        public bool _renderUpdate = false;

        public string vertexShaderSource;
        public int vertexShaderHandle;

        internal void WeightVertices() { _manager.Weight(); }
        internal void UnWeightVertices() { _manager.UnWeight(); }

        internal override void Bind(TKContext ctx) 
        {
            _render = (_bone != null ? _bone._flags1.HasFlag(BoneFlags.Visible) ? true : false : true);

            if (ctx._canUseShaders)
            {
                vertexShaderHandle = GL.CreateShader(OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
                fragmentShaderHandle = GL.CreateShader(OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);

                _renderUpdate = true;
            }
        }
        internal override void Unbind() 
        {
            _render = false;

            if (vertexShaderHandle != 0)
                GL.DeleteShader(vertexShaderHandle);

            if (fragmentShaderHandle != 0)
                GL.DeleteShader(fragmentShaderHandle);

            if (shaderProgramHandle != 0)
                GL.DeleteProgram(shaderProgramHandle);
        }

        #endregion

        #region Etc

        public MDL0ObjectNode Clone() { return MemberwiseClone() as MDL0ObjectNode; }

        public override void Remove()
        {
            MDL0Node node = Model;

            if (node == null)
            {
                base.Remove();
                return;
            }

            if (_vertexNode != null)
                if (_vertexNode._polygons.Count == 1)
                    if (MessageBox.Show("Do you want to remove this object's vertex node?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        _vertexNode.Remove();
                    else _vertexNode._polygons.Remove(this);
                else _vertexNode._polygons.Remove(this);

            if (_normalNode != null)
                if (_normalNode._polygons.Count == 1)
                    _normalNode.Remove();
                else _normalNode._polygons.Remove(this);

            for (int i = 0; i < 2; i++)
                if (_colorSet[i] != null)
                    if (_colorSet[i]._polygons.Count == 1)
                        _colorSet[i].Remove();
                    else _colorSet[i]._polygons.Remove(this);

            for (int i = 0; i < 8; i++)
                if (_uvSet[i] != null)
                    if (_uvSet[i]._polygons.Count == 1)
                        _uvSet[i].Remove();
                    else _uvSet[i]._polygons.Remove(this);

            SingleBindInf = null;
            BoneNode = null;
            OpaMaterialNode = null;
            XluMaterialNode = null;

            if (_manager != null)
            {
                foreach (Vertex3 v in _manager._vertices)
                    if (v._influence != null)
                        v._influence.ReferenceCount--;
            }

            base.Remove();

            Dispose();

            foreach (MDL0ObjectNode p in node._polyList)
                p.RecalcIndices();
        }

        public static int DrawCompareOpa(ResourceNode n1, ResourceNode n2)
        {
            //First compare draw priorities
            if (((MDL0ObjectNode)n1).DrawPriority > ((MDL0ObjectNode)n2).DrawPriority)
                return 1;
            if (((MDL0ObjectNode)n1).DrawPriority < ((MDL0ObjectNode)n2).DrawPriority)
                return -1;

            //Make sure the node isn't null
            if (((MDL0ObjectNode)n1).OpaMaterialNode != null && ((MDL0ObjectNode)n2).OpaMaterialNode == null)
                return 1;
            if (((MDL0ObjectNode)n1).OpaMaterialNode == null && ((MDL0ObjectNode)n2).OpaMaterialNode != null)
                return -1;
            if (((MDL0ObjectNode)n1).OpaMaterialNode == null && ((MDL0ObjectNode)n2).OpaMaterialNode == null)
                return 0;

            //They were equal. Fall back on material draw priority
            if (((MDL0ObjectNode)n1).OpaMaterialNode.Index > ((MDL0ObjectNode)n2).OpaMaterialNode.Index)
                return 1;
            if (((MDL0ObjectNode)n1).OpaMaterialNode.Index < ((MDL0ObjectNode)n2).OpaMaterialNode.Index)
                return -1;

            //Now compare the object index
            if (((MDL0ObjectNode)n1).Index > ((MDL0ObjectNode)n2).Index)
                return 1;
            if (((MDL0ObjectNode)n1).Index < ((MDL0ObjectNode)n2).Index)
                return -1;

            //Should never return equal
            return 0;
        }
        public static int DrawCompareXlu(ResourceNode n1, ResourceNode n2)
        {
            //First compare draw priorities
            if (((MDL0ObjectNode)n1).DrawPriority > ((MDL0ObjectNode)n2).DrawPriority)
                return 1;
            if (((MDL0ObjectNode)n1).DrawPriority < ((MDL0ObjectNode)n2).DrawPriority)
                return -1;

            //Make sure the node isn't null
            if (((MDL0ObjectNode)n1).XluMaterialNode != null && ((MDL0ObjectNode)n2).XluMaterialNode == null)
                return 1;
            if (((MDL0ObjectNode)n1).XluMaterialNode == null && ((MDL0ObjectNode)n2).XluMaterialNode != null)
                return -1;
            if (((MDL0ObjectNode)n1).XluMaterialNode == null && ((MDL0ObjectNode)n2).XluMaterialNode == null)
                return 0;

            //They were equal. Fall back on material draw priority
            if (((MDL0ObjectNode)n1).XluMaterialNode.Index > ((MDL0ObjectNode)n2).XluMaterialNode.Index)
                return 1;
            if (((MDL0ObjectNode)n1).XluMaterialNode.Index < ((MDL0ObjectNode)n2).XluMaterialNode.Index)
                return -1;

            //Now compare the object index
            if (((MDL0ObjectNode)n1).Index > ((MDL0ObjectNode)n2).Index)
                return 1;
            if (((MDL0ObjectNode)n1).Index < ((MDL0ObjectNode)n2).Index)
                return -1;

            //Should never return equal
            return 0;
        }
        #endregion
    }
}
