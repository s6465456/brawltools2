using System;
using BrawlLib.SSBBTypes;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RBNKNode : RSARFileNode
    {
        internal RBNKHeader* Header { get { return (RBNKHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RBNK; } }

        public List<RSARBankNode> _rsarBankEntries = new List<RSARBankNode>();
        [Browsable(false)]
        public RSARBankNode[] Banks { get { return _rsarBankEntries.ToArray(); } }
        public void AddBankRef(RSARBankNode n)
        {
            if (!_rsarBankEntries.Contains(n))
            {
                _rsarBankEntries.Add(n);
                _references.Add(n.TreePath);
            }
        }
        public void RemoveBankRef(RSARBankNode n)
        {
            if (_rsarBankEntries.Contains(n))
            {
                _rsarBankEntries.Remove(n);
                _references.Remove(n.TreePath);
            }
        }

        [Category("RBNK")]
        public byte VersionMajor { get { return _major; } }
        [Category("RBNK")]
        public byte VersionMinor { get { return _minor; } }
        private byte _minor, _major;

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            int len = Header->_header._length;
            int total = WorkingUncompressed.Length;

            //Set data source
            if (total > len)
                _audioSource = new DataSource((VoidPtr)Header + len, total - len);

            _major = Header->_header.VersionMajor;
            _minor = Header->_header.VersionMinor;

            return true;
        }

        protected override void OnPopulate()
        {
            new RBNKDataGroupNode().Initialize(this, Header->Data, Header->_dataLength);
            if (Header->_waveOffset > 0)
                new RBNKSoundGroupNode().Initialize(this, Header->Wave, Header->_waveLength);
        }

        protected override int OnCalculateSize(bool force)
        {
            _audioLen = 0;
            _headerLen = RBNKHeader.Size;
            foreach (ResourceNode g in Children)
                _headerLen += g.CalculateSize(true);
            foreach (WAVESoundNode s in Children[1].Children)
                _audioLen += s._audioSource.Length;

            return _headerLen + _audioLen;
        }
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;

            RBNKHeader* header = (RBNKHeader*)address;
            header->_header._length = length;
            header->_header._tag = RBNKHeader.Tag;
            header->_header._numEntries = 2;
            header->_header._firstOffset = 0x20;
            header->_header._endian = -2;
            header->_header._version = 0x101;
            header->_dataOffset = 0x20;
            header->_dataLength = Children[0]._calcSize;
            header->_waveOffset = 0x20 + Children[0]._calcSize;
            header->_waveLength = Children[1]._calcSize;

            addr += 0x20; //Advance address to data header

            //VoidPtr audioAddr = addr;
            //foreach (ResourceNode e in Children)
            //    audioAddr += e._calcSize;
            (Children[1] as RBNKSoundGroupNode)._audioAddr = _rebuildAudioAddr;

            Children[0].Rebuild(addr, Children[0]._calcSize, true);
            addr += Children[0]._calcSize;
            Children[1].Rebuild(addr, Children[1]._calcSize, true);
            addr += Children[1]._calcSize;
        }

        public override void Remove()
        {
            if (RSARNode != null)
                RSARNode.Files.Remove(this);
            base.Remove();
        }

        internal static ResourceNode TryParse(DataSource source) { return ((RBNKHeader*)source.Address)->_header._tag == RBNKHeader.Tag ? new RBNKNode() : null; }
    }
}
