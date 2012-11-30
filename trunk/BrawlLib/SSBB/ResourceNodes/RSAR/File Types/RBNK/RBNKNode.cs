using System;
using BrawlLib.SSBBTypes;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RBNKNode : RSARFileNode
    {
        internal RBNKHeader* Header { get { return (RBNKHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RBNK; } }

        //protected override void GetStrings(LabelBuilder builder)
        //{
        //    //foreach (RWSDDataNode node in Children[0].Children)
        //    //    builder.Add(0, node._name);
        //}

        //Finds labels using LABL block between header and footer, also initializes array
        protected bool GetLabels(int count)
        {
            RBNKHeader* header = (RBNKHeader*)WorkingUncompressed.Address;
            int len = header->_header._length;
            LABLHeader* labl = (LABLHeader*)((int)header + len);

            if ((WorkingUncompressed.Length > len) && (labl->_tag == LABLHeader.Tag))
            {
                _labels = new LabelItem[count];
                count = labl->_numEntries;
                for (int i = 0; i < count; i++)
                {
                    LABLEntry* entry = labl->Get(i);
                    _labels[i] = new LabelItem() { String = entry->Name, Tag = entry->_id };
                }
                return true;
            }

            return false;
        }
        protected override bool OnInitialize()
        {
            RSARNode parent = RSARNode;

            //Find bank entry in rsar - only appears once
            if (parent != null)
            {
                RSARHeader* rsar = parent.Header;
                RuintList* list = rsar->INFOBlock->Banks;
                VoidPtr offset = &rsar->INFOBlock->_collection;
                SYMBHeader* symb = rsar->SYMBBlock;

                int count = list->_numEntries;
                for (int i = 0; i < count; i++)
                {
                    INFOBankEntry* bank = (INFOBankEntry*)list->Get(offset, i);
                    if (bank->_fileId == _fileIndex)
                    {
                        _name = String.Format("[{0}] {1}", _fileIndex, symb->GetStringEntry(bank->_stringId));
                        break;
                    }
                }
            }

            base.OnInitialize();

            ParseBlocks();

            return true;
        }

        protected override void OnPopulate()
        {
            new RBNKDataGroupNode().Initialize(this, Header->Data, Header->_dataLength);
            new RBNKSoundGroupNode().Initialize(this, Header->Wave, Header->_waveLength);
        }

        private void ParseBlocks()
        {
            VoidPtr dataAddr = Header;
            int len = Header->_header._length;
            int total = WorkingUncompressed.Length;

            //Look for labl block
            LABLHeader* labl = (LABLHeader*)(dataAddr + len);
            if ((total > len) && (labl->_tag == LABLHeader.Tag))
            {
                int count = labl->_numEntries;
                _labels = new LabelItem[count];
                count = labl->_numEntries;
                for (int i = 0; i < count; i++)
                {
                    LABLEntry* entry = labl->Get(i);
                    _labels[i] = new LabelItem() { String = entry->Name, Tag = entry->_id };
                }
                len += labl->_size;
            }

            //Set data source
            if (total > len)
                _audioSource = new DataSource(dataAddr + len, total - len);
        }

        protected override int OnCalculateSize(bool force)
        {
            _audioLen = 0;
            _headerLen = RBNKHeader.Size;
            foreach (ResourceNode g in Children)
                _headerLen += g.CalculateSize(true);
            //foreach (RWSDSoundNode s in Children[1].Children)
            //    _audioLen += s._audioSource.Length;

            return _headerLen + (_audioLen = _audioSource.Length);
        }
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            VoidPtr addr = address;

            RBNKHeader* header = (RBNKHeader*)address;
            header->_header._length = length - _audioSource.Length;
            header->_header._tag = RBNKHeader.Tag;
            header->_header._numEntries = 2;
            header->_header._firstOffset = 0x20;
            header->_header._endian = -2;
            header->_header._version = 0x102;
            header->_dataOffset = 0x20;
            header->_dataLength = Children[0]._calcSize;
            header->_waveOffset = 0x20 + Children[0]._calcSize;
            header->_waveLength = Children[1]._calcSize;

            addr += 0x20; //Advance address to data header

            //VoidPtr audioAddr = addr;
            //foreach (ResourceNode e in Children)
            //    audioAddr += e._calcSize;
            (Children[1] as RWSDSoundGroupNode)._audioAddr = _rebuildAudioAddr;

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
