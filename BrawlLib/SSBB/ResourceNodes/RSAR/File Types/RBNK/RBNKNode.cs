﻿using System;
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

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            int len = Header->_header._length;
            int total = WorkingUncompressed.Length;

            //Set data source
            if (total > len)
                _audioSource = new DataSource((VoidPtr)Header + len, total - len);

            return true;
        }

        protected override void OnPopulate()
        {
            new RBNKDataGroupNode().Initialize(this, Header->Data, Header->_dataLength);
            if (Header->_waveOffset > 0 && VersionMinor < 2)
                new RBNKSoundGroupNode().Initialize(this, Header->Wave, Header->_waveLength);
            else if (VersionMinor >= 2)
                new RWARNode() { _name = "Audio" }.Initialize(this, _audioSource.Address, _audioSource.Length);
        }

        protected override int OnCalculateSize(bool force)
        {
            _audioLen = 0;
            _headerLen = RBNKHeader.Size;
            if (VersionMinor >= 2)
            {
                _headerLen += Children[0].CalculateSize(true);
                _audioLen = Children[1].CalculateSize(true);
            }
            else
            {
                foreach (ResourceNode g in Children)
                    _headerLen += g.CalculateSize(true);
                foreach (WAVESoundNode s in Children[1].Children)
                    _audioLen += s._audioSource.Length;
            }

            return _headerLen + _audioLen;
        }
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address + 0x20;
            
            RBNKHeader* header = (RBNKHeader*)address;
            header->_header._length = length;
            header->_header._tag = RBNKHeader.Tag;
            header->_header._numEntries = (ushort)(VersionMinor >= 2 ? 1 : 2);
            header->_header._firstOffset = 0x20;
            header->_header.Endian = Endian.Big;
            header->_header._version = (ushort)(0x100 + VersionMinor);
            header->_dataOffset = 0x20;
            header->_dataLength = Children[0]._calcSize;

            Children[0].Rebuild(addr, Children[0]._calcSize, true);
            addr += Children[0]._calcSize;

            if (VersionMinor < 2)
            {
                header->_waveOffset = 0x20 + Children[0]._calcSize;
                header->_waveLength = Children[1]._calcSize;

                if (RSARNode == null)
                {
                    VoidPtr audioAddr = addr;
                    foreach (ResourceNode e in Children)
                        audioAddr += e._calcSize;
                    (Children[1] as RBNKSoundGroupNode)._audioAddr = audioAddr;
                }
                else (Children[1] as RBNKSoundGroupNode)._audioAddr = _rebuildAudioAddr;

                Children[1].Rebuild(addr, Children[1]._calcSize, true);
                addr += Children[1]._calcSize;
            }
            else
            {
                header->_waveOffset = 0;
                header->_waveLength = 0;

                VoidPtr a;
                if (RSARNode == null)
                {
                    VoidPtr audioAddr = addr;
                    foreach (ResourceNode e in Children)
                        audioAddr += e._calcSize;
                    a = audioAddr;
                }
                else a = _rebuildAudioAddr;

                Children[1].Rebuild(a, Children[1]._calcSize, true);
            }
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
