﻿using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Modeling;
using BrawlLib.Wii.Models;
using System.Collections.Generic;
using BrawlLib.OpenGL;
using System.Drawing;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MDL0FurPosNode : MDL0EntryNode
    {
        internal MDL0FurPosData* Header { get { return (MDL0FurPosData*)WorkingUncompressed.Address; } }

        public MDL0ObjectNode[] Objects { get { return _polygons.ToArray(); } }
        internal List<MDL0ObjectNode> _polygons = new List<MDL0ObjectNode>();

        MDL0FurPosData hdr = new MDL0FurPosData();

        [Category("Fur Layer Vertex Data")]
        public int TotalLen { get { return hdr._dataLen; } }
        [Category("Fur Layer Vertex Data")]
        public int MDL0Offset { get { return hdr._mdl0Offset; } }
        [Category("Fur Layer Vertex Data")]
        public int DataOffset { get { return hdr._dataOffset; } }
        [Category("Fur Layer Vertex Data")]
        public int StringOffset { get { return hdr._stringOffset; } }

        [Category("Fur Layer Vertex Data")]
        public int ID { get { return hdr._index; } }
        [Category("Fur Layer Vertex Data")]
        public bool IsXYZ { get { return hdr._isXYZ != 0; } }
        [Category("Fur Layer Vertex Data")]
        public WiiVertexComponentType Format { get { return (WiiVertexComponentType)(int)hdr._type; } }
        [Category("Fur Layer Vertex Data")]
        public byte Divisor { get { return hdr._divisor; } }
        [Category("Fur Layer Vertex Data")]
        public byte EntryStride { get { return hdr._entryStride; } }
        [Category("Fur Layer Vertex Data")]
        public short NumVertices { get { return hdr._numVertices; } }

        [Category("Fur Layer Vertex Data")]
        public int NumLayers { get { return hdr._numLayers; } }
        [Category("Fur Layer Vertex Data")]
        public int LayerOffset { get { return hdr._offsetOfLayer; } }

        public bool ForceRebuild { get { return _forceRebuild; } set { if (_forceRebuild != value) { _forceRebuild = value; SignalPropertyChange(); } } }
        public bool ForceFloat { get { return _forceFloat; } set { if (_forceFloat != value) { _forceFloat = value; } } }
        
        public Vector3[] _vertices;
        public Vector3[] Vertices
        {
            get { return _vertices == null ? _vertices = VertexCodec.ExtractVertices(Header) : _vertices; }
            set { _vertices = value; SignalPropertyChange(); }
        }

        protected override bool OnInitialize()
        {
            hdr = *Header;
            base.OnInitialize();

            SetSizeInternal(hdr._dataLen);

            if ((_name == null) && (Header->_stringOffset != 0))
                _name = Header->ResourceString;

            return false;
        }

        public VertexCodec _enc;
        public bool _forceRebuild = false;
        public bool _forceFloat = false;
        protected override int OnCalculateSize(bool force)
        {
            if (Model._isImport || _forceRebuild)
            {
                _enc = new VertexCodec(Vertices, false, _forceFloat);
                return _enc._dataLen.Align(0x20) + 0x40;
            }
            else return base.OnCalculateSize(force);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            if (Model._isImport || _forceRebuild)
            {
                MDL0FurPosData* header = (MDL0FurPosData*)address;

                header->_dataLen = length;
                header->_dataOffset = 0x40;
                header->_index = _entryIndex;
                header->_isXYZ = _enc._hasZ ? 1 : 0;
                header->_type = (int)_enc._type;
                header->_divisor = (byte)_enc._scale;
                header->_entryStride = (byte)_enc._dstStride;
                header->_numVertices = (short)_enc._srcCount;

                header->_numLayers = NumLayers;
                header->_offsetOfLayer = LayerOffset;

                //Write data
                _enc.Write(Vertices, (byte*)address + 0x40);
                _enc.Dispose();
                _enc = null;

                _forceRebuild = false;
            }
            else
                base.OnRebuild(address, length, force);
        }

        public override unsafe void Export(string outPath)
        {
            base.Export(outPath);
        }

        protected internal override void PostProcess(VoidPtr mdlAddress, VoidPtr dataAddress, StringTable stringTable)
        {
            MDL0FurPosData* header = (MDL0FurPosData*)dataAddress;
            header->_mdl0Offset = (int)mdlAddress - (int)dataAddress;
            header->_stringOffset = (int)stringTable[Name] + 4 - (int)dataAddress;
            header->_index = Index;
        }
    }
}
