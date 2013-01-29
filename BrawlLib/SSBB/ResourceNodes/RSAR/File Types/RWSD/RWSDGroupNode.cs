using System;
using BrawlLib.SSBBTypes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RWSDDataGroupNode : ResourceNode
    {
        internal RWSD_DATAHeader* Header { get { return (RWSD_DATAHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RWSDDataGroup; } }

        protected override bool OnInitialize()
        {
            _name = "Data";
            return Header->_list._numEntries > 0;
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = 0xC + Children.Count * 8;
            foreach (RSARFileEntryNode g in Children)
                size += g.CalculateSize(true);
            return size.Align(0x20);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            RWSD_DATAHeader* header = (RWSD_DATAHeader*)address;
            header->_tag = RWSD_DATAHeader.Tag;
            header->_length = length;
            header->_list._numEntries = Children.Count;
            VoidPtr addr = address + 12 + Children.Count * 8;
            foreach (RWSDDataNode d in Children)
            {
                d._baseAddr = header->_list.Address;
                header->_list[d.Index] = (int)(addr - header->_list.Address);
                d.Rebuild(addr, d._calcSize, force);
                addr += d._calcSize;
            }
        }
    }

    public unsafe class RWSDSoundGroupNode : ResourceNode
    {
        internal WAVEHeader* Header { get { return (WAVEHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RWSDSoundGroup; } }

        public VoidPtr _audioAddr;

        protected override bool OnInitialize()
        {
            _name = "Audio";

            return Header->_numEntries > 0;
        }

        protected override void OnPopulate()
        {
            for (int i = 0; i < Header->_numEntries; i++)
                new WAVESoundNode().Initialize(this, Header->GetEntry(i), 0);
            foreach (WAVESoundNode n in Children)
                n.GetAudio();
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = 0xC + Children.Count * 4;
            foreach (WAVESoundNode g in Children)
                size += g.WorkingUncompressed.Length;
            return size.Align(0x20);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            uint offset = 0;
            WAVEHeader* header = (WAVEHeader*)address;
            header->_tag = WAVEHeader.Tag;
            header->_numEntries = Children.Count;
            header->_length = length;
            buint* table = (buint*)header + 3;
            VoidPtr addr = (VoidPtr)(table + Children.Count);
            foreach (WAVESoundNode r in Children)
            {
                //Set offset and write header data
                table[r.Index] = (uint)(addr - address);
                Memory.Move(addr, r.WorkingUncompressed.Address, (uint)r.WorkingUncompressed.Length);

                //Set the offset to the audio samples
                WaveInfo* wave = (WaveInfo*)addr;
                wave->_dataLocation = offset;
                offset += (uint)r._audioSource.Length;

                //Write audio samples
                Memory.Move(_audioAddr, r._audioSource.Address, (uint)r._audioSource.Length);
                _audioAddr += r._audioSource.Length;

                //Advance
                addr += r.WorkingUncompressed.Length;
            }
        }
    }
}
