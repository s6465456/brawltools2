﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class EFLSNode : ARCEntryNode
    {
        internal EFLSHeader* Header { get { return (EFLSHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.EFLS; } }

        private int _brresCount, _unk1, _unk2;
        
        //[Category("EFLS")]
        //public int BrresCount { get { return _brresCount; } set { _brresCount = value; SignalPropertyChange(); } }
        [Category("EFLS")]
        public int Unknown1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [Category("EFLS")]
        public int Unknown2 { get { return _unk2; } set { _unk2 = value; SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _brresCount = Header->_numBrres;
            _unk1 = Header->_unk1;
            _unk2 = Header->_unk2;

            return Header->_numEntries > 0;
        }

        internal int RE3DOffset = 0;
        protected override int OnCalculateSize(bool force)
        {
            int size = 0x10, re3dSize = 0; _brresCount = 0;
            foreach (EFLSEntryNode e in Children)
            {
                if (e.UseBrres)
                    _brresCount++;

                if (String.Equals(e._name, "<null>", StringComparison.OrdinalIgnoreCase))
                    size += 0x10;
                else
                    size += e._name.Length + 0x11;

                if (e.Children.Count > 0)
                {
                    re3dSize = re3dSize.Align(0x10);
                    re3dSize += 0x10;
                    foreach (RE3DEntryNode r in e.Children)
                        re3dSize += 0x10 + r.Name.Length + 1 + r.Effect.Length + 1;
                }
            }
            if (re3dSize > 0)
                RE3DOffset = size.Align(0x10);
            return size.Align(0x10) + re3dSize;
        }

        protected override void OnPopulate()
        {
            EFLSHeader* header = Header;
            for (int i = 0; i < header->_numEntries; i++)
                new EFLSEntryNode() { _name = header->GetString(i) }.Initialize(this, &header->Entries[i], 0);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            int count = Children.Count;
            int re3dSize = 0;

            EFLSHeader* header = (EFLSHeader*)address;
            RE3D* RE3DAddr = (RE3D*)((VoidPtr)header + RE3DOffset);
            *header = new EFLSHeader(count, _brresCount, _unk1, _unk2);

            EFLSEntry* entry = (EFLSEntry*)((int)header + 0x10);
            sbyte* dPtr = (sbyte*)entry + (count * 0x10);
            foreach (EFLSEntryNode n in Children)
            {
                int offset = n._name.Equals("<null>", StringComparison.OrdinalIgnoreCase) ? 0 : (int)dPtr - (int)header;
                *entry = new EFLSEntry(n._brresID1, n._brresID2, offset, n._unk);

                if (offset > 0)
                    n._name.Write(ref dPtr);

                if (n.Children.Count > 0)
                {
                    re3dSize = re3dSize.Align(0x10);
                    RE3DAddr = (RE3D*)((VoidPtr)header + RE3DOffset + re3dSize);

                    entry->_re3dOffset = (int)RE3DAddr - (int)header;

                    RE3DAddr->_tag = RE3D.Tag;
                    RE3DAddr->_numEntries = (byte)n.Children.Count;

                    RE3DEntry* rEntry = (RE3DEntry*)((VoidPtr)RE3DAddr + 0x10);
                    sbyte* sPtr = (sbyte*)rEntry + n.Children.Count * 0x10;

                    foreach (RE3DEntryNode rNode in n.Children)
                    {
                        rEntry->_unk1 = rNode._unk1;
                        rEntry->_unk2 = rNode._unk2;
                        rEntry->_unk3 = rNode._unk3;

                        rEntry->_stringOffset = (int)sPtr - (int)RE3DAddr;
                        int len = rNode._name.Length;
                        rNode._name.Write(ref sPtr);
                        rEntry->_effectNameOffset = (int)sPtr - (int)RE3DAddr;
                        len = rNode.Effect.Length;
                        rNode._effect.Write(ref sPtr);

                        rEntry++;
                        re3dSize += 0x10 + rNode.Name.Length + 1 + rNode.Effect.Length + 1;
                    }
                    re3dSize += 0x10;
                }
                entry++;
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((EFLSHeader*)source.Address)->_tag == EFLSHeader.Tag ? new EFLSNode() : null; }
    }

    public unsafe class EFLSEntryNode : ResourceNode
    {
        internal EFLSEntry* Header { get { return (EFLSEntry*)WorkingUncompressed.Address; } }
        public override bool AllowNullNames { get { return true; } }
        public override ResourceType ResourceType { get { return ResourceType.EFLSEntry; } }

        internal int _brresID1, _brresID2, _re3dOffset, _unk;
        
        [Category("EFLS Entry")]
        public bool UseBrres { get { return _brresID1 != -1; } set { _brresID1 = (value ? _brresID2 : -1); SignalPropertyChange(); } }
        [Category("EFLS Entry")]
        public uint BrresId { get { return (uint)_brresID2; } set { _brresID2 = (int)value; if (UseBrres) _brresID1 = _brresID2; SignalPropertyChange(); } }
        [Category("EFLS Entry")]
        public int Unknown { get { return _unk; } set { _unk = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            _brresID1 = Header->_brresID1;
            _brresID2 = Header->_brresID2;
            _re3dOffset = Header->_re3dOffset;
            _unk = Header->_unk;
            
            return _re3dOffset > 0;
        }

        protected override void OnPopulate()
        {
            RE3D* data = (RE3D*)((VoidPtr)((EFLSNode)Parent).Header + _re3dOffset);
            for (int i = 0; i < data->_numEntries; i++)
                new RE3DEntryNode().Initialize(this, (VoidPtr)data + 0x10 + 0x10 * i, 0x10);
        }
    }

    public unsafe class RE3DEntryNode : ResourceNode
    {
        internal RE3DEntry* Header { get { return (RE3DEntry*)WorkingUncompressed.Address; } }

        internal int _stringOffset;
        internal int _unk1;
        internal short _unk2;
        internal short _unk3;
        internal int _stringOffset2;

        public string _effect;

        [Category("RE3D Entry")]
        public int Unk1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [Category("RE3D Entry")]
        public short Unk2 { get { return _unk2; } set { _unk2 = value; SignalPropertyChange(); } }
        [Category("RE3D Entry")]
        public short Unk3 { get { return _unk3; } set { _unk3 = value; SignalPropertyChange(); } }
        [Category("RE3D Entry")]
        public string Effect { get { return _effect; } set { _effect = value; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            _stringOffset = Header->_stringOffset;
            _unk1 = Header->_unk1;
            _unk2 = Header->_unk2;
            _unk3 = Header->_unk3;
            _stringOffset2 = Header->_effectNameOffset;

            _name = new String((sbyte*)(((VoidPtr)Header - 0x10 - 0x10 * Index) + _stringOffset));
            _effect = ((_stringOffset2 > 0) ? new String((sbyte*)(((VoidPtr)Header - 0x10 - 0x10 * Index) + _stringOffset2)) : null);

            return false;
        }
    }
}
