﻿using System;
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
    public unsafe class MDL0PolygonNode : MDL0EntryNode
    {
        internal MDL0Polygon* Header { get { return (MDL0Polygon*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.MDL0Polygon; } }

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
                if (value < 0 || value >= Model._polyList.Count)
                    return;

                _drawIndex = value;
                SignalPropertyChange();
            }
        }

        [Category("Object Data")]
        public int TotalLen { get { return _totalLength; } }
        [Category("Object Data")]
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
        public int FacepointCount { get { return _numVertices; } }
        [Category("Object Data")]
        public int VertexCount { get { return _manager._vertices.Count; } }
        [Category("Object Data")]
        public int FaceCount { get { return _numFaces; } }

        internal List<IMatrixNode> _influences;
        [Browsable(false)]
        public List<IMatrixNode> Influences { get { return _influences; } }

        #endregion

        #region Linked Sets

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

        public int _numVertices;
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
        internal MDL0MaterialNode _material;
        [Browsable(false)]
        public MDL0MaterialNode MaterialNode
        {
            get { return _material; }
            set
            {
                if (_material == value)
                    return;
                if (_material != null)
                    _material._polygons.Remove(this);
                if ((_material = value) != null)
                    _material._polygons.Add(this);
            }
        }
        [Browsable(true), TypeConverter(typeof(DropDownListMaterials))]
        public string Material
        {
            get { return _material == null ? null : _material._name; }
            set { if (String.IsNullOrEmpty(value)) return; MaterialNode = Model.FindOrCreateMaterial(value); Model.SignalPropertyChange(); }
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
            MDL0Polygon* header = Header;
            _nodeId = header->_nodeId;

            SetSizeInternal(_totalLength = header->_totalLength);
            _mdl0Offset = header->_mdl0Offset;
            _stringOffset = header->_stringOffset;

            ModelLinker linker = Model._linker;

            attachSingleBind();

            _vertexFormat = header->_vertexFormat;
            _vertexSpecs = header->_vertexSpecs;
            _arrayFlags = header->_arrayFlags;

            _numVertices = header->_numVertices;
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

            //Create primitive manager
            if (_parent != null)
            {
                int i = 0;
                _manager = new PrimitiveManager(header, Model._assets, linker.NodeCache, this);
                foreach (Vertex3 v in _manager._vertices)
                    v.Index = i++;
            }

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

                int size = (int)MDL0Polygon.Size;

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
                _descList = _manager.setDescList(this);

                //Add table length
                size += _nodeCache.Length * 2 + 4;
                if ((size.Align(0x10) + 0xE0) % 0x20 == 0)
                    tableLen = size.Align(0x10);
                else
                    tableLen = size.Align(0x20);

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

                                Tri.z = _facepoints[*indices++];
                                Tri.y = _facepoints[*indices++];
                                Tri.x = _facepoints[*indices++];
                            }
                            else
                            {
                                Tri.x = _facepoints[*indices++];
                                Tri.y = _facepoints[*indices++];
                                Tri.z = _facepoints[*indices++];
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

                //#region Tristripper
                //bool forceNone = false;
                //    Begin:
                //        //Groups faces as tristrips based on shared sides (not fully working)
                //        if (//Model._importOptions._useTristrips && 
                //            !forceNone)
                //        {
                        
                //        Start:
                //            Tristrip tri = new Tristrip();
                //            List<Triangle> grouped = new List<Triangle>();
                //            for (int i = 0; i < Triangles.Count; i++)
                //            {
                //                Triangle t = Triangles[i];

                //                if (!t.grouped)
                //                {
                //                    Triangle prev = t;

                //                    for (int x = i + 1; x < Triangles.Count; x++)
                //                    {
                //                        Triangle next = Triangles[x];
                //                        if (next.grouped == false)
                //                        {
                //                            if (prev.TwoPointsMatch(next))
                //                            {
                //                                //Collection will be modified; needs to be copied
                //                                Facepoint[] v1 = new Facepoint[3];
                //                                prev.values.CopyTo(v1, 0);
                //                                Facepoint[] v2 = new Facepoint[3];
                //                                next.values.CopyTo(v2, 0);
                                                
                //                                //Edit triangles to match tristrip order
                //                                if (prev == t)
                //                                {
                //                                    prev.x = v1[prev.remaining];
                //                                    prev.y = v1[prev.p1];
                //                                    prev.z = v1[prev.p2];

                //                                    grouped.Add(prev);
                //                                    prev.grouped = true;
                //                                }

                //                                next.x = v2[next.index1];
                //                                next.y = v2[next.index2];
                //                                next.z = v2[next.remainingIndex];

                //                                grouped.Add(next);
                //                                next.grouped = true;

                //                                prev = next;
                //                            }
                //                            else continue;
                //                        }
                //                        else continue;
                //                    }

                //                    bool first = true;
                //                    foreach (Triangle g in grouped)
                //                    {
                //                        if (first)
                //                        {
                //                            tri.points.Add(g.x);
                //                            tri.points.Add(g.y);
                //                            tri.points.Add(g.z);
                //                            first = false;
                //                        }
                //                        else
                //                            tri.points.Add(g.z);
                //                    }
                //                    if (tri.points.Count != 0)
                //                        Tristrips.Add(tri);
                //                    else
                //                        break;
                //                    if (i != Triangles.Count)
                //                        goto Start;
                //                }
                //            }

                //            List<Triangle> notStripped = new List<Triangle>();
                //            foreach (Triangle t in Triangles)
                //                if (!t.grouped) notStripped.Add(t);

                //            triCount = notStripped.Count * 3;
                //            foreach (Tristrip j in Tristrips)
                //                stripCount += j.points.Count;

                //            if (triCount > stripCount)
                //            {
                //                //Group triangles to groups first, then try to add tristrips

                //                bool NewGroup = true;
                //                PrimitiveGroup grp = new PrimitiveGroup();
                //                for (int i = 0; i < notStripped.Count; i++)
                //                {
                //                Top:
                //                    if (NewGroup) //Create a new group of triangles and node ids
                //                    {
                //                        grp = new PrimitiveGroup();
                //                        NewGroup = false;
                //                    }
                //                    if (!(grp.CanAdd(notStripped[i]))) //Will add automatically if true
                //                    {
                //                        groups.Add(grp);
                //                        NewGroup = true;
                //                        goto Top;
                //                    }
                //                    if (i == notStripped.Count - 1) //Last triangle
                //                        groups.Add(grp);
                //                }

                //                NewGroup = false;
                //                Tristrip notAdded = null;
                //                for (int v = 0; v < Tristrips.Count; v++)
                //                {
                //                    Tristrip current = Tristrips[v];
                //                Top:
                //                    if (NewGroup) //Create a new group of triangles and node ids
                //                    {
                //                        grp = new PrimitiveGroup();
                //                        NewGroup = false;
                //                        if ((notAdded = grp.CanAdd(current)) != null)
                //                        {
                //                            current = notAdded;
                //                            groups.Add(grp);
                //                            NewGroup = true;
                //                            goto Top;
                //                        }
                //                        else
                //                            groups.Add(grp);
                //                    }

                //                    bool added = false;
                //                    for (int a = 0; a < groups.Count; a++)
                //                    {
                //                        if ((notAdded = groups[a].CanAdd(current)) != null)
                //                            current = notAdded;
                //                        else
                //                        {
                //                            added = true;
                //                            break;
                //                        }
                //                    }
                //                    if (!added)
                //                    {
                //                        NewGroup = true;
                //                        goto Top;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                //Group tristrips to groups first, then try to add triangles

                //                if (Tristrips.Count == 0)
                //                {
                //                    forceNone = true;
                //                    goto Begin;
                //                }

                //                Tristrip notAdded = null;
                //                PrimitiveGroup grp = new PrimitiveGroup();
                //                bool NewGroup = true;
                //                for (int v = 0; v < Tristrips.Count; v++)
                //                {
                //                    Tristrip current = Tristrips[v];
                //                Top:
                //                    if (NewGroup)
                //                    {
                //                        grp = new PrimitiveGroup();
                //                        NewGroup = false;
                //                    }

                //                    if ((notAdded = grp.CanAdd(current)) != null)
                //                    {
                //                        current = notAdded;
                //                        groups.Add(grp);
                //                        NewGroup = true;
                //                        goto Top;
                //                    }

                //                    if (v == Tristrips.Count - 1) //Last tristrip
                //                        groups.Add(grp);
                //                }

                //                NewGroup = false;
                //                for (int i = 0; i < notStripped.Count; i++)
                //                {
                //                Top:
                //                    if (NewGroup) //Create a new group of triangles and node ids
                //                    {
                //                        grp = new PrimitiveGroup();
                //                        NewGroup = false;
                //                        if ((grp.CanAdd(notStripped[i])))
                //                            groups.Add(grp);
                //                        else
                //                        {
                //                            Console.WriteLine("Error");
                //                        }
                //                    }

                //                    bool added = false;
                //                    for (int a = 0; a < groups.Count; a++)
                //                    {
                //                        if ((groups[a].CanAdd(notStripped[i])))
                //                        {
                //                            added = true;
                //                            break;
                //                        }
                //                    }
                //                    if (!added)
                //                    {
                //                        NewGroup = true;
                //                        goto Top;
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            //Groups as triangles (working)
                //            bool NewGroup = true;
                //            PrimitiveGroup grp = new PrimitiveGroup();
                //            for (int i = 0; i < Triangles.Count; i++)
                //            {
                //            Top:
                //                if (NewGroup) //Create a new group of triangles and node ids
                //                {
                //                    grp = new PrimitiveGroup();
                //                    NewGroup = false;
                //                }
                //                if (!(grp.CanAdd(Triangles[i]))) //Will add automatically if true
                //                {
                //                    groups.Add(grp);
                //                    NewGroup = true;
                //                    goto Top;
                //                }
                //                if (i == Triangles.Count - 1) //Last triangle
                //                    groups.Add(grp);
                //            }

                //            triCount = Triangles.Count * 3;
                //            goto Build;
                //        }
                //    }
                //}
                //
                //for (int i1 = 0; i1 < groups.Count; i1++)
                //    for (int i2 = 0; i2 < groups.Count; i2++)
                //        if (groups[i1] != groups[i2] && groups[i1].tryMerge(groups[i2]))
                //        {
                //            groups.RemoveAt(i2--);
                //            i1 = 0;
                //        }
                //#endregion

            //Build:
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
                if ((size.Align(0x10)) % 0x20 == 0)
                {
                    size = size.Align(0x10);
                    primitiveSize = primitiveSize.Align(0x10);
                }
                else
                {
                    size = size.Align(0x20);
                    primitiveSize = primitiveSize.Align(0x20);
                }

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
            MDL0Polygon* header = (MDL0Polygon*)address;

            if (Model._rebuildAllObj || Model._isImport || _rebuild)
            {
                //Set Header
                header->_totalLength = length;

                //header->_numVertices = _numVertices = triCount + stripCount;
                //header->_numFaces = _numFaces = (triCount / 3) + (stripCount <= 2 ? 0 : stripCount - 2);

                _numVertices = header->_numVertices = _manager._pointCount;
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
                header->_vertexId = _elementIndices[0];
                header->_normalId = _elementIndices[1];
                for (int i = 2; i < 4; i++)
                    *(bshort*)&header->_colorIds[i - 2] = (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);
                for (int i = 4; i < 12; i++)
                    *(bshort*)&header->_uids[i - 4] = (short)(_elementIndices[i] >= 0 ? _elementIndices[i] : -1);

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

        public void CorrectNodeIds(MDL0Polygon* header)
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
            MDL0Polygon* header = (MDL0Polygon*)dataAddress;
            header->_mdl0Offset = (int)mdlAddress - (int)dataAddress;
            header->_stringOffset = (int)stringTable[Name] + 4 - (int)dataAddress;
            header->_index = Index;
        }

        #endregion

        #endregion

        #region Rendering
        internal bool _render = true;
        public void EvalAlphaFunc(out double near, out double far)
        {
            near = 0;
            far = 1;

            GXAlphaFunction func = MaterialNode._alphaFunc;
            //Simplify the alpha equation.
            switch (func.Logic)
            {
                case AlphaOp.And: //&&
                    if (func.ref0 > func.ref1)
                    {

                    }
                    
                    break;
                case AlphaOp.Or: //||

                    break; //==
                case AlphaOp.InverseExclusiveOr:

                    break; //!=
                case AlphaOp.ExclusiveOr:
                    
                    break;
            }
        }

        public void PreRender()
        {
            if (_singleBind != null)
            {
                GL.PushMatrix();
                Matrix m = _singleBind.Matrix;
                GL.MultMatrix((float*)&m);
            }

            if (_material != null)
            {
                switch ((int)_material.CullMode)
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

                if (_material.EnableDepthTest)
                {
                    GL.Enable(EnableCap.DepthTest);
                    DepthFunction depth = DepthFunction.Lequal;
                    switch (_material.DepthFunction)
                    {
                        case GXCompare.Never:
                            depth = DepthFunction.Never; break;
                        case GXCompare.Less:
                            depth = DepthFunction.Less; break;
                        case GXCompare.Equal:
                            depth = DepthFunction.Equal; break;
                        case GXCompare.LessOrEqual:
                            depth = DepthFunction.Lequal; break;
                        case GXCompare.Greater:
                            depth = DepthFunction.Greater; break;
                        case GXCompare.NotEqual:
                            depth = DepthFunction.Notequal; break;
                        case GXCompare.GreaterOrEqual:
                            depth = DepthFunction.Gequal; break;
                        case GXCompare.Always:
                            depth = DepthFunction.Always; break;
                    }
                    GL.DepthFunc(depth);
                }
                else
                    GL.Disable(EnableCap.DepthTest);

                if (_material._blendMode.EnableBlend)
                {
                    GL.Enable(EnableCap.Blend);
                    BlendingFactorSrc src = BlendingFactorSrc.OneMinusSrcAlpha;
                    switch (_material._blendMode.SrcFactor)
                    {
                        case BlendFactor.DestinationAlpha:
                            src = BlendingFactorSrc.DstAlpha; break;
                        case BlendFactor.DestinationColor:
                            src = BlendingFactorSrc.DstColor; break;
                        case BlendFactor.InverseDestinationAlpha:
                            src = BlendingFactorSrc.OneMinusDstAlpha; break;
                        case BlendFactor.InverseDestinationColor:
                            src = BlendingFactorSrc.OneMinusDstColor; break;
                        case BlendFactor.InverseSourceAlpha:
                            src = BlendingFactorSrc.OneMinusSrcAlpha; break;
                        //case BlendFactor.InverseSourceColor:
                        //    src = BlendingFactorSrc.ONE_MINUS_SRC_COLOR; break;
                        case BlendFactor.One:
                            src = BlendingFactorSrc.One; break;
                        case BlendFactor.SourceAlpha:
                            src = BlendingFactorSrc.SrcAlpha; break;
                        //case BlendFactor.SourceColor:
                        //    src = BlendingFactorSrc.SrcColor; break;
                        case BlendFactor.Zero:
                            src = BlendingFactorSrc.Zero; break;
                    }
                    BlendingFactorDest dst = BlendingFactorDest.OneMinusSrcAlpha;
                    switch (_material._blendMode.DstFactor)
                    {
                        case BlendFactor.DestinationAlpha:
                            dst = BlendingFactorDest.DstAlpha; break;
                        case BlendFactor.DestinationColor:
                            dst = BlendingFactorDest.DstColor; break;
                        case BlendFactor.InverseDestinationAlpha:
                            dst = BlendingFactorDest.OneMinusDstAlpha; break;
                        case BlendFactor.InverseDestinationColor:
                            dst = BlendingFactorDest.OneMinusDstColor; break;
                        case BlendFactor.InverseSourceAlpha:
                            dst = BlendingFactorDest.OneMinusSrcAlpha; break;
                        //case BlendFactor.InverseSourceColor:
                        //    dst = BlendingFactorDest.ONE_MINUS_SRC_COLOR; break;
                        case BlendFactor.One:
                            dst = BlendingFactorDest.One; break;
                        case BlendFactor.SourceAlpha:
                            dst = BlendingFactorDest.SrcAlpha; break;
                        //case BlendFactor.SourceColor:
                        //    dst = BlendingFactorDest.SrcColor; break;
                        case BlendFactor.Zero:
                            dst = BlendingFactorDest.Zero; break;
                    }
                    GL.BlendFunc(src, dst);
                }
                else
                    GL.Disable(EnableCap.Blend);

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

        public string GenVertexShader()
        {
            string shader = "";
            for (int i = 0; i < 12; i++)
                if (_manager._faceData[i] != null)
                    switch (i)
                    {
                        case 0:
                            shader += "in vec3 poscoords;\n";
                            break;
                        case 1:
                            shader += "in vec3 normcoords;\n";
                            break;
                        case 2:
                        case 3:
                            shader += String.Format("in vec3 rascolor{0};\n", i);
                            break;
                        default:
                            shader += String.Format("in vec2 texcoord{0};\n", i);
                            break;
                    }
            shader += "void main(void)\n{";
            shader += "gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;";
            shader += "\n}";
            return shader;
        }

        public string GenerateVSOutputStruct()
        {
            string s = "";
            s += String.Format("struct VS_OUTPUT\n{\n");
            s += String.Format("  vec4 pos : POSITION;\n");
            s += String.Format("  vec4 colors_0 : COLOR0;\n");
            s += String.Format("  vec4 colors_1 : COLOR1;\n");

            if (MaterialNode.Children.Count < 7)
            {
                for (uint i = 0; i < MaterialNode.Children.Count; ++i)
                    s += String.Format("  vec3 tex{0} : TEXCOORD{0};\n", i);
                s += String.Format("  vec4 clipPos : TEXCOORD{0};\n", MaterialNode.Children.Count);
                s += String.Format("  vec4 Normal : TEXCOORD{0};\n", MaterialNode.Children.Count + 1);
            }
            else
            {
                // clip position is in w of first 4 texcoords
                //if(g_ActiveConfig.bEnablePixelLighting && g_ActiveConfig.backend_info.bSupportsPixelLighting)
                //{
                    for (int i = 0; i < 8; ++i)
                        s += String.Format("  vec4 tex{0} : TEXCOORD{0};\n", i);
                //}
                //else
                //{
                //    for (uint i = 0; i < MaterialNode.Children.Count; ++i)
                //        s += String.Format("  float{0} tex{1} : TEXCOORD{1};\n", i < 4 ? 4 : 3, i);
                //}
            }      
            s += String.Format("};\n");
            return s;
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
                        s += String.Format("lacc.{0} += {1}.lights[{2}].col.{0};\n", swizzle, lightsName, index);
                        break;
                    case GXDiffuseFn.Enabled:
                    case GXDiffuseFn.Clamped:
                        s += String.Format("ldir = normalize({0}.lights[{1}].pos.xyz - pos.xyz);\n", lightsName, index);
                        s += String.Format("lacc.{0} += {1}dot(ldir, _norm0)) * {2}.lights[{3}].col.{4};\n",
                            swizzle, chan.DiffuseFunction != GXDiffuseFn.Enabled ? "max(0.0f," :"(", lightsName, index, swizzle);
                        break;
                    //default: _assert_(0);
                }
            }
            else
            {
                // spec and spot
                if (chan.Attenuation == GXAttnFn.Spotlight)
                {
                    // spot
                    s += String.Format("ldir = {0}.lights[{1}].pos.xyz - pos.xyz;\n", lightsName, index);
                    s += String.Format("dist2 = dot(ldir, ldir);\n" + 
                            "dist = sqrt(dist2);\n" + 
                            "ldir = ldir / dist;\n" + 
                            "attn = max(0.0f, dot(ldir, {0}.lights[{1}].dir.xyz));\n", lightsName, index);
                    s += String.Format("attn = max(0.0f, dot({0}.lights[{1}].cosatt.xyz, vec3(1.0f, attn, attn*attn))) / dot({2}.lights[{3}].distatt.xyz, vec3(1.0f,dist,dist2));\n", lightsName, index, lightsName, index);
                }
                if (chan.Attenuation == GXAttnFn.Specular)
                {
                    // specular
                    s += String.Format("ldir = normalize({0}.lights[{1}].pos.xyz);\n", lightsName, index);
                    s += String.Format("attn = (dot(_norm0,ldir) >= 0.0f) ? max(0.0f, dot(_norm0, {0}.lights[{1}].dir.xyz)) : 0.0f;\n", lightsName, index);
                    s += String.Format("attn = max(0.0f, dot({0}.lights[{1}].cosatt.xyz, vec3(1,attn,attn*attn))) / dot({2}.lights[{3}].distatt.xyz, vec3(1,attn,attn*attn));\n", lightsName, index, lightsName, index);
                }

                switch (chan.DiffuseFunction)
                {
                    case GXDiffuseFn.Disabled:
                        s += String.Format("lacc.{0} += attn * {1}.lights[{2}].col.{3};\n", swizzle, lightsName, index, swizzle);
                        break;
                    case GXDiffuseFn.Enabled:
                    case GXDiffuseFn.Clamped:
                        s += String.Format("lacc.{0} += attn * {1}dot(ldir, _norm0)) * {2}.lights[{3}].col.{4};\n",
                            swizzle,
                            chan.DiffuseFunction != GXDiffuseFn.Enabled ? "max(0.0f," : "(",
                            lightsName,
                            index,
                            swizzle);
                        break;
                    //default: _assert_(0);
                }
            }
            s += "\n";
            return s;
        }

        // vertex shader
        // lights/colors
        // materials name is I_MATERIALS in vs and I_PMATERIALS in ps
        // inColorName is color in vs and colors_ in ps
        // dest is o.colors_ in vs and colors_ in ps
        public string GenerateLightingShader(string materialsName, string lightsName, string inColorName, string dest)
        {
            string s = "{\n";
            for (uint j = 0; j < MaterialNode.LightChannels; j++)
            {
                LightChannelControl color = j == 0 ? MaterialNode._chan1._color : MaterialNode._chan2._color;
                LightChannelControl alpha = j == 0 ? MaterialNode._chan1._alpha : MaterialNode._chan2._alpha;

                if (color.MaterialSource == GXColorSrc.Vertex) 
                {
                    // from vertex
                    if (_colorSet[j] != null)
                        s += String.Format("mat = {0}{1};\n", inColorName, j);
                    else if (_colorSet[0] != null)
                        s += String.Format("mat = {0}0;\n", inColorName);
                    else
                        s += String.Format("mat = vec4(1.0f, 1.0f, 1.0f, 1.0f);\n");
                }
                else // from color
                    s += String.Format("mat = {0}.C{1};\n", materialsName, j + 2);

                if (color.Enabled) 
                {
                    if (color.AmbientSource == GXColorSrc.Vertex) 
                    {
                        // from vertex
                        if (_colorSet[j] != null)
                            s += String.Format("lacc = {0}{1};\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            s += String.Format("lacc = {0}0;\n", inColorName);
                        else
                            s += String.Format("lacc = vec4(0.0f, 0.0f, 0.0f, 0.0f);\n");
                    }
                    else // from color
                        s += String.Format("lacc = {0}.C{1};\n", materialsName, j);
                }
                else
                    s += "lacc = vec4(1.0f, 1.0f, 1.0f, 1.0f);\n";

                // check if alpha is different
                if (alpha.MaterialSource != color.MaterialSource) 
                {
                    if (alpha.MaterialSource == GXColorSrc.Vertex) 
                    {
                        // from vertex
                        if (_colorSet[j] != null)
                            s += String.Format("mat.w = {0}{1}.w;\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            s += String.Format("mat.w = {0}0.w;\n", inColorName);
                        else
                            s += String.Format("mat.w = 1.0f;\n");
                    }
                    else // from color
                        s += String.Format("mat.w = {0}.C{1}.w;\n", materialsName, j+2);
                }

                if (alpha.Enabled)
                {
                    if (alpha.AmbientSource == GXColorSrc.Vertex) 
                    {
                        // from vertex
                        if (_colorSet[j] != null)
                            s += String.Format("lacc.w = {0}{1}.w;\n", inColorName, j);
                        else if (_colorSet[0] != null)
                            s += String.Format("lacc.w = {0}0.w;\n", inColorName);
                        else
                            s += String.Format("lacc.w = 0.0f;\n");
                    }
                    else // from color
                        s += String.Format("lacc.w = {0}.C{1}.w;\n", materialsName, j);
                }
                else
                    s += "lacc.w = 1.0f;\n";

                if (color.Enabled && alpha.Enabled)
                {
                    // both have lighting, test if they use the same lights
                    int mask = 0;
                    if (color.Lights == alpha.Lights)
                    {
                        mask = (int)color.Lights & (int)alpha.Lights;
                        if (mask != 0)
                            for (int i = 0; i < 8; i++)
                                if ((mask & (1 << i)) != 0)
                                    s += GenerateLightShader(i, color, lightsName, 3);
                    }

                    // no shared lights
                    for (int i = 0; i < 8; i++)
                    {
                        if (((mask & (1 << i)) == 0) && ((int)color.Lights & (1 << i)) != 0)
                            s += GenerateLightShader(i, color, lightsName, 1);
                        if (((mask & (1 << i)) == 0) && ((int)alpha.Lights & (1 << i)) != 0)
                            s += GenerateLightShader(i, alpha, lightsName, 2);
                    }
                }
                else if (color.Enabled || alpha.Enabled)
                {
                    // lights are disabled on one channel so process only the active ones
                    LightChannelControl workingchannel = color.Enabled ? color : alpha;
                    int coloralpha = color.Enabled ? 1 : 2;
                    for (int i = 0; i < 8; i++)
                        if (((int)workingchannel.Lights & (1 << i)) != 0)
                            s += GenerateLightShader(i, workingchannel, lightsName, coloralpha);
                }
                s += String.Format("{0}{1} = mat * saturate(lacc);\n}\n", dest, j);
            }
            return s;
        }
        
        public int shaderProgramHandle = 0;
        internal void Render(TKContext ctx)
        {
            if (!_render)
                return;

            if (ctx._canUseShaders)
            {
                bool updateProgram = _renderUpdate || MaterialNode._renderUpdate || MaterialNode.ShaderNode._renderUpdate;
                if (updateProgram)
                {
                    if (shaderProgramHandle > 0)
                        GL.DeleteProgram(shaderProgramHandle);

                    shaderProgramHandle = GL.CreateProgram();

                    if (_renderUpdate)
                    {
                        vertexShaderSource = GenVertexShader();
                        GL.ShaderSource(vertexShaderHandle, vertexShaderSource);
                        GL.CompileShader(vertexShaderHandle);
                        GL.AttachShader(shaderProgramHandle, vertexShaderHandle);
                    }
                    if (MaterialNode._renderUpdate || MaterialNode.ShaderNode._renderUpdate)
                    {
                        MaterialNode.GenFragShader();
                        GL.AttachShader(shaderProgramHandle, MaterialNode.fragmentShaderHandle);
                        MaterialNode.SetUniforms(shaderProgramHandle);
                    }
                    GL.LinkProgram(shaderProgramHandle);
                }
                GL.UseProgram(shaderProgramHandle);
            }

            _manager.PrepareStream();

            PreRender();

            if (_material != null)
                if (_material.Children.Count == 0) _manager.RenderTexture(null);
                else foreach (MDL0MaterialRefNode mr in _material.Children)
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

                    switch ((int)mr.VWrapMode)
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

            vertexShaderHandle = GL.CreateShader(OpenTK.Graphics.OpenGL.ShaderType.VertexShader);

            _renderUpdate = true;
        }
        internal override void Unbind() 
        {
            _render = false;

            if (vertexShaderHandle != 0)
                GL.DeleteShader(vertexShaderHandle);

            if (shaderProgramHandle != 0)
                GL.DeleteProgram(shaderProgramHandle);
        }

        #endregion

        #region Etc

        public MDL0PolygonNode Clone()
        {
            MDL0PolygonNode node = this.MemberwiseClone() as MDL0PolygonNode;
            //node._parent = Parent;
            //node.Name = Name;
            //node.SingleBindInf = SingleBindInf;
            //node.BoneNode = BoneNode;
            //node.MaterialNode = MaterialNode;
            //node._vertexNode = _vertexNode;
            //node._normalNode = _normalNode;
            //for (int i = 0; i < 2; i++)
            //    node._colorSet[i] = _colorSet[i];
            //for (int i = 0; i < 8; i++)
            //    node._uvSet[i] = _uvSet[i];
            //node.groups = groups;
            //node.UVATGroups = UVATGroups;
            //node._vertexFormat = VertexFormat;
            //node._vertexSpecs = VertexSpecs;
            //node._defFlags = _defFlags;
            //node._defSize = _defSize;
            //node._manager = _manager.Clone();
            ////node._manager = new PrimitiveManager();
            ////node._manager._faceData = _manager._faceData;
            ////node._manager._graphicsBuffer = _manager._graphicsBuffer;
            //for (int i = 0; i < 12; i++)
            //{
            //    node._elementIndices[i] = _elementIndices[i];
            //    //if (node._elementIndices[i] != -1)
            //    //    node._manager._dirty[i] = true;
            //}
            ////node._manager._vertices = _manager._vertices;
            //node._manager._polygon = node;
            ////node._manager._faces = _manager._faces;
            ////node._manager._lines = _manager._lines;
            ////node._manager._points = _manager._points;
            ////node._manager._indices = _manager._indices;
            ////node._manager.Nodes = _manager.Nodes;
            ////node._manager._desc = _manager._desc;
            //node._nodeId = _nodeId;
            //if (node.Weighted)
            //{
            //    foreach (Vertex3 vert in node._manager._vertices)
            //        if (vert._influence != null && vert._influence is Influence)
            //            vert._influence = Model._influences.AddOrCreateInf((Influence)vert._influence);
            //}
            //else if (node.SingleBindInf != null && node.SingleBindInf is Influence)
            //    node.SingleBindInf = Model._influences.AddOrCreateInf((Influence)node.SingleBindInf);
            //node._rebuild = true;
            //node.SignalPropertyChange();
            ////node.Rebuild(true);
            return node;
        }

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
            MaterialNode = null;

            if (_manager != null)
            {
                foreach (Vertex3 v in _manager._vertices)
                    if (v._influence != null)
                        v._influence.ReferenceCount--;
            }

            base.Remove();

            Dispose();

            foreach (MDL0PolygonNode p in node._polyList)
                p.RecalcIndices();
        }

        public static int DrawCompare(ResourceNode n1, ResourceNode n2)
        {
            //First compare draw priorities
            if (((MDL0PolygonNode)n1).DrawPriority > ((MDL0PolygonNode)n2).DrawPriority)
                return 1;
            if (((MDL0PolygonNode)n1).DrawPriority < ((MDL0PolygonNode)n2).DrawPriority)
                return -1;
            //They were equal. Fall back on material draw priority
            if (((MDL0PolygonNode)n1).MaterialNode.Index > ((MDL0PolygonNode)n2).MaterialNode.Index)
                return 1;
            if (((MDL0PolygonNode)n1).MaterialNode.Index < ((MDL0PolygonNode)n2).MaterialNode.Index)
                return -1;
            //Should never return equal
            return 0;
        }

#endregion
    }
}
