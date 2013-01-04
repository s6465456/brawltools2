using System;
using BrawlLib.SSBBTypes;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSEQNode : RSARFileNode
    {
        internal RSEQHeader* Header { get { return (RSEQHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RSEQ; } }
        
        public string Offset { get { if (RSARNode != null) return ((uint)((VoidPtr)Header - (VoidPtr)RSARNode.Header)).ToString("X"); else return null; } }

        [Category("RSEQ")]
        public float Version { get { return _version; } }
        private float _version;

        public MMLCommand[] _cmds;
        public MMLCommand[] Commands { get { return _cmds; } }

        DataSource _data;
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();
            _version = Header->_header.Version;
            _data = new DataSource(Header->Data, Header->_dataLength);
            _cmds = MMLParser.Parse(Header->Data + 12);
            return true;
        }

        protected override void OnPopulate()
        {
            for (int i = 0; i < ((LABLHeader*)Header->Labl)->_numEntries; i++)
                new RSEQLabelNode().Initialize(this, ((LABLHeader*)Header->Labl)->Get(i), 0);
        }

        private LabelBuilder builder;
        protected override int OnCalculateSize(bool force)
        {
            builder = new LabelBuilder();
            foreach (RSEQLabelNode node in Children)
                builder.Add(node.Id, node._name);
            _audioLen = 0;
            return _headerLen = 0x20 + _data.Length + builder.GetSize();
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            RSEQHeader* header = (RSEQHeader*)address;
            header->_header._endian = -2;
            header->_header._tag = RSEQHeader.Tag;
            header->_header._version = 0x100;
            header->_header._length = length;
            header->_header._numEntries = 2;
            header->_header._firstOffset = 0x20;
            header->_dataOffset = 0x20;
            header->_dataLength = _data.Length;
            header->_lablOffset = 0x20 + _data.Length;
            header->_lablLength = builder.GetSize();

            //MML Parser is not complete yet, so copy raw data over
            Memory.Move((VoidPtr)header + header->_dataOffset, _data.Address, (uint)_data.Length);
            
            builder.Write((VoidPtr)header + header->_lablOffset);
        }

        public override void Remove()
        {
            if (RSARNode != null)
                RSARNode.Files.Remove(this);
            base.Remove();
        }

        internal static ResourceNode TryParse(DataSource source) { return ((RSEQHeader*)source.Address)->_header._tag == RSEQHeader.Tag ? new RSEQNode() : null; }
    }
}
