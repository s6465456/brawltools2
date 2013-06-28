using System;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Models;
using System.Collections.Generic;
using BrawlLib.Imaging;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.Modeling
{
    public class Facepoint
    {
        public Vertex3 _vertex;

        private IMatrixNode Node { get { return _vertex != null ? _vertex.MatrixNode : null; } }
        public int NodeID { get { if (Node != null) return Node.NodeIndex; return -1; } }

        public int _vertexIndex = -1;
        public int _normalIndex = -1;
        public int[] _colorIndices = new int[2] { -1, -1 };
        public int[] _UVIndices = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };

        [Category("Facepoint"), Browsable(true)]
        public int VertexIndex { get { return _vertexIndex; } }
        [Category("Facepoint"), Browsable(true)]
        public int NormalIndex { get { return _normalIndex; } }
        [Category("Facepoint"), Browsable(true)]
        public int[] ColorIndices { get { return _colorIndices; } }
        [Category("Facepoint"), Browsable(true)]
        public int[] UVIndices { get { return _UVIndices; } }

        public override string ToString()
        {
            return String.Format("M({12}), V({0}), N({1}), C({2}, {3}), U({4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", _vertexIndex, _normalIndex, _colorIndices[0], _colorIndices[1], _UVIndices[0], _UVIndices[1], _UVIndices[2], _UVIndices[3], _UVIndices[4], _UVIndices[5], _UVIndices[6], _UVIndices[7], NodeID);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PrimitiveHeader
    {
        public WiiPrimitiveType Type;
        public bushort Entries;

        public PrimitiveHeader(WiiPrimitiveType type, int entries)
        {
            Type = type;
            Entries = (ushort)entries;
        }

        internal VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public VoidPtr Data { get { return Address + 3; } }
    }

    public class PrimitiveGroup
    {
        //This is the main group of primitives, all using a group of node ids.
        public List<ushort> _nodes = new List<ushort>();

        public void RegroupNodes()
        {
            _nodes.Clear();
            for (int i = 0; i < _headers.Count; i++)
            {
                //Re-assign node ids, just in case the nodes were moved
                foreach (Facepoint point in _points[i])
                    if (!_nodes.Contains((ushort)point.NodeID))
                        _nodes.Add((ushort)point.NodeID);
            }
        }

        //For imports
        public List<Trifan> _trifans = new List<Trifan>();
        public List<Tristrip> _tristrips = new List<Tristrip>();
        public List<Triangle> _triangles = new List<Triangle>();

        //For existing models
        public List<PrimitiveHeader> _headers = new List<PrimitiveHeader>();
        public List<List<Facepoint>> _points = new List<List<Facepoint>>();

        //Offset from the start of the primitives to this group.
        public uint _offset; 
        
        //Cache for rebuilding in case nodes are moved
        public List<NodeOffset> _nodeOffsets = new List<NodeOffset>();

        public unsafe void SetNodeIds(VoidPtr primAddr)
        {
            byte* grpAddr = (byte*)(primAddr + _offset);
            for (int i = 0; i < _nodeOffsets.Count; i++)
                *(bushort*)(grpAddr + _nodeOffsets[i]._offset) = (ushort)_nodeOffsets[i]._node.NodeIndex;
        }

        public void AddTriangle(Triangle t)
        {
            _triangles.Add(t);
            if (!_nodes.Contains((ushort)t._x.NodeID)) _nodes.Add((ushort)t._x.NodeID);
            if (!_nodes.Contains((ushort)t._y.NodeID)) _nodes.Add((ushort)t._y.NodeID);
            if (!_nodes.Contains((ushort)t._z.NodeID)) _nodes.Add((ushort)t._z.NodeID);
        }

        public bool CanAdd(Triangle t)
        {
            int count = 0;
            if (!_nodes.Contains((ushort)t._x.NodeID)) count++;
            if (!_nodes.Contains((ushort)t._y.NodeID)) count++;
            if (!_nodes.Contains((ushort)t._z.NodeID)) count++;
            if (count + _nodes.Count <= 10)
            {
                AddTriangle(t);
                return true;
            }
            return false;
        }

        public override string ToString() { return String.Format("Nodes: {0} - Primitives: {1}", _nodes.Count, _headers.Count); }
    }

    public class NodeOffset
    {
        internal uint _offset;
        internal IMatrixNode _node;

        public NodeOffset(uint offset, IMatrixNode node)
        {
            _offset = offset;
            _node = node;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TriangleGroup
    {
        public PrimitiveHeader Header { get { return new PrimitiveHeader(WiiPrimitiveType.Triangles, _triangles.Count * 3); } }
        public List<Triangle> _triangles = new List<Triangle>();
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class TristripGroup
    {
        public PrimitiveHeader Header { get { return new PrimitiveHeader(WiiPrimitiveType.TriangleStrip, Count); } }
        public int Count 
        {
            get
            {
                int count = 0;
                foreach (Tristrip t in _tristrips)
                    count += t._points.Count;
                return count;
            }
        }
        public List<Tristrip> _tristrips = new List<Tristrip>();
    }

    public class Tristrip
    {
        public List<Facepoint> _points = new List<Facepoint>();
        
        public List<Triangle> _temp = new List<Triangle>();
    }

    public class Trifan
    {
        public List<Facepoint> _points = new List<Facepoint>();
    }

    public class Triangle
    {
        public Facepoint _x;
        public Facepoint _y;
        public Facepoint _z;

        public Facepoint this[int i]
        { 
            get
            {
                switch (i)
                {
                    case 0: return _x;
                    case 1: return _y;
                    case 2: return _z;
                }
                return null;
            }
            set
            {
                switch (i)
                {
                    case 0: _x = value; break;
                    case 1: _y = value; break;
                    case 2: _z = value; break;
                }
            }
        }

        public Triangle() { }
        public Triangle(Facepoint x, Facepoint y, Facepoint z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public bool Contains(Facepoint f)
        {
            if (_x == f) return true;
            if (_y == f) return true;
            if (_z == f) return true;
            return false;
        }

        public Triangle RotateUp()
        {
            return new Triangle(_y, _z, _x);
        }

        public bool _grouped = false;
    }
}
