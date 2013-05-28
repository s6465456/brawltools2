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
        public IMatrixNode _node = null;

        public int _nodeId { get { return _vertex != null && _vertex.MatrixNode != null ? _vertex.MatrixNode.NodeIndex : _node != null ? _node.NodeIndex : -1; } }

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
            return String.Format("M({12}), V({0}), N({1}), C({2}, {3}), U({4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", _vertexIndex, _normalIndex, _colorIndices[0], _colorIndices[1], _UVIndices[0], _UVIndices[1], _UVIndices[2], _UVIndices[3], _UVIndices[4], _UVIndices[5], _UVIndices[6], _UVIndices[7], _nodeId);
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
        public List<int> _nodeIds = new List<int>();

        //For imports
        public List<Trifan> _trifans = new List<Trifan>();
        public List<Tristrip> _tristrips = new List<Tristrip>();
        public List<Triangle> _triangles = new List<Triangle>();

        //For existing models
        public List<PrimitiveHeader> _headers = new List<PrimitiveHeader>();
        public List<List<Facepoint>> _points = new List<List<Facepoint>>();

        public void AddTriangle(Triangle t)
        {
            _triangles.Add(t);
            if (!_nodeIds.Contains(t._x._nodeId)) _nodeIds.Add(t._x._nodeId);
            if (!_nodeIds.Contains(t._y._nodeId)) _nodeIds.Add(t._y._nodeId);
            if (!_nodeIds.Contains(t._z._nodeId)) _nodeIds.Add(t._z._nodeId);
        }

        public bool CanAdd(Triangle t)
        {
            int count = 0;
            if (!_nodeIds.Contains(t._x._nodeId)) count++;
            if (!_nodeIds.Contains(t._y._nodeId)) count++;
            if (!_nodeIds.Contains(t._z._nodeId)) count++;
            if (count + _nodeIds.Count <= 10)
            {
                AddTriangle(t);
                return true;
            }
            return false;
        }

        public override string ToString() { return String.Format("Nodes: {0} - Primitives: {1}", _nodeIds.Count, _headers.Count); }
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

        public Triangle _adj1;
        public Triangle _adj2;
        public Triangle _adj3;
    }
}
