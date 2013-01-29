﻿using System;
using System.Collections.Generic;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.SSBBTypes;
using System.Linq;

namespace BrawlLib.Wii.Audio
{
    public unsafe class RSARConverter
    {
        public int _headerLen, _fileLen, _infoLen, _symbLen;
        internal int CalculateSize(RSAREntryList entries, RSARNode node)
        {
            //Header
            _headerLen = 0x40;

            //SYMB, INFO, FILE Headers
            _symbLen = 0x20;
            _infoLen = 0x8;
            _fileLen = 0x20;

            #region SYMB

            //String offsets
            _symbLen += entries._strings.Count * 4;
            
            //Strings are packed tightly with no trailing pad
            _symbLen += entries._stringLength;

            //Mask entries
            _symbLen += 32; //Headers
            _symbLen += (entries._strings.Count * 2 - 4) * 20; //Entries

            //Align
            _symbLen = _symbLen.Align(0x20);

            #endregion

            #region Info

            //Info ruint collection and ruint list counts
            _infoLen += 0x30;

            int sounds = 4, playerInfo = 4, banks = 4, groups = 4, files = 4;

            //ruint sizes
            sounds += entries._sounds.Count * 8;
            playerInfo += entries._playerInfo.Count * 8;
            groups += entries._groups.Count * 8;
            banks += entries._banks.Count * 8 + 8;
            files += entries._files.Count * 8;

            //Evaluate entries with child offsets
            foreach (RSAREntryState s in entries._sounds)
                sounds += s._node.CalculateSize(true);
            foreach (RSAREntryState s in entries._playerInfo)
                playerInfo += s._node.CalculateSize(true);
            foreach (RSAREntryState s in entries._banks)
                banks += s._node.CalculateSize(true);
            foreach (RSAREntryState s in entries._groups)
                groups += s._node.CalculateSize(true);
            groups += INFOGroupHeader.Size + 4; //Null group at the end
            groups += node._nullGroup.Files.Count * 32;
            foreach (RSARFileNode s in entries._files)
            {
                files += INFOFileHeader.Size + 4;
                if (!(s is RSARExtFileNode))
                    files += s._groups.Count * (8 + INFOFileEntry.Size);
                else
                    files += (s._extPath.Length + 1).Align(4);
            }

            //Footer and Align
            _infoLen = ((_infoLen += (sounds + banks + playerInfo + files + groups)) + 0x10).Align(0x20);

            #endregion

            #region File

            foreach (RSAREntryState r in entries._groups)
            {
                RSARGroupNode g = r._node as RSARGroupNode;
                foreach (RSARFileNode f in g.Files)
                    _fileLen += f.CalculateSize(true);
            }
            foreach (RSARFileNode f in node._nullGroup.Files)
                _fileLen += f.CalculateSize(true);

            //Align
            _fileLen = _fileLen.Align(0x20);

            #endregion

            return _headerLen + _symbLen + _infoLen + _fileLen;
        }

        internal int EncodeSYMBBlock(SYMBHeader* header, RSAREntryList entries, RSARNode node)
        {
            int len = 0;
            int count = entries._strings.Count;
            VoidPtr baseAddr = (VoidPtr)header + 8, dataAddr;
            bint* strEntry = (bint*)(baseAddr + 0x18);
            PString pStr = (byte*)strEntry + (count << 2);

            //Strings
            header->_stringOffset = 0x14;
            strEntry[-1] = entries._strings.Count;
            foreach (string s in entries._strings)
            {
                *strEntry++ = (int)(pStr - baseAddr);
                pStr.Write(s, 0, s.Length + 1);
                pStr += s.Length + 1;
            }

            dataAddr = pStr;

            //Sounds
            header->_maskOffset1 = (int)(dataAddr - baseAddr);
            dataAddr += EncodeMaskGroup(header, (SYMBMaskHeader*)dataAddr, entries._sounds);

            //Types
            header->_maskOffset2 = (int)(dataAddr - baseAddr);
            dataAddr += EncodeMaskGroup(header, (SYMBMaskHeader*)dataAddr, entries._playerInfo);

            //Groups
            header->_maskOffset3 = (int)(dataAddr - baseAddr);
            dataAddr += EncodeMaskGroup(header, (SYMBMaskHeader*)dataAddr, entries._groups);

            //Banks
            header->_maskOffset4 = (int)(dataAddr - baseAddr);
            dataAddr += EncodeMaskGroup(header, (SYMBMaskHeader*)dataAddr, entries._banks);

            int temp = (int)dataAddr - (int)header;
            len = temp.Align(0x20);

            //Fill padding
            byte* p = (byte*)dataAddr;
            for (int i = temp; i < len; i++)
                *p++ = 0;

            //Set header
            header->_header._tag = SYMBHeader.Tag;
            header->_header._length = len;

            return len;
        }
        internal int EncodeINFOBlock(INFOHeader* header, RSAREntryList entries, RSARNode node)
        {
            int len = 0;

            VoidPtr baseAddr = header->_collection.Address;
            ruint* values = (ruint*)baseAddr;
            VoidPtr dataAddr = baseAddr + 0x30;
            RuintList* entryList;
            int index = 0;

            //Set up sound ruint list
            values[0] = (uint)dataAddr - (uint)baseAddr;
            entryList = (RuintList*)dataAddr;
            entryList->_numEntries = entries._sounds.Count;
            dataAddr += entries._sounds.Count * 8 + 4;

            //Write sound entries
            foreach (RSAREntryState r in entries._sounds)
            {
                r._node._rebuildBase = baseAddr;
                entryList->Entries[index++] = (uint)dataAddr - (uint)baseAddr;
                r._node.Rebuild(dataAddr, r._node._calcSize, true);
                dataAddr += r._node._calcSize;
            }
            index = 0;
            //Set up bank ruint list
            values[1] = (uint)dataAddr - (uint)baseAddr;
            entryList = (RuintList*)dataAddr;
            entryList->_numEntries = entries._banks.Count;
            dataAddr += entries._banks.Count * 8 + 4;

            //Write bank entries
            foreach (RSAREntryState r in entries._banks)
            {
                r._node._rebuildBase = baseAddr;
                entryList->Entries[index++] = (uint)dataAddr - (uint)baseAddr;
                r._node.Rebuild(dataAddr, r._node._calcSize, true);
                dataAddr += r._node._calcSize;
            }
            index = 0;
            //Set up playerInfo ruint list
            values[2] = (uint)dataAddr - (uint)baseAddr;
            entryList = (RuintList*)dataAddr;
            entryList->_numEntries = entries._playerInfo.Count;
            dataAddr += entries._playerInfo.Count * 8 + 4;

            //Write playerInfo entries
            foreach (RSAREntryState r in entries._playerInfo)
            {
                r._node._rebuildBase = baseAddr;
                entryList->Entries[index++] = (uint)dataAddr - (uint)baseAddr;
                r._node.Rebuild(dataAddr, r._node._calcSize, true);
                dataAddr += r._node._calcSize;
            }
            index = 0;
            //Set up file ruint list
            values[3] = (uint)dataAddr - (uint)baseAddr;
            entryList = (RuintList*)dataAddr;
            entryList->_numEntries = entries._files.Count;
            dataAddr += entries._files.Count * 8 + 4;

            //Write file entries
            foreach (RSARFileNode file in entries._files)
            {
                entryList->Entries[index++] = (uint)dataAddr - (uint)baseAddr;
                INFOFileHeader* fileHdr = (INFOFileHeader*)dataAddr;
                dataAddr += INFOFileHeader.Size;
                RuintList* list = (RuintList*)dataAddr;
                fileHdr->_entryNumber = -1;
                if (file is RSARExtFileNode)
                {
                    //Make an attempt to get file size
                    if (file._extFileSize == 0) file.GetExtSize();
                    //Shouldn't matter if 0
                    fileHdr->_headerLen = file._extFileSize; 

                    fileHdr->_dataLen = 0;
                    fileHdr->_stringOffset = (uint)((VoidPtr)list - (VoidPtr)baseAddr);
                    
                    sbyte* dPtr = (sbyte*)list;
                    file._extPath.Write(ref dPtr);
                    dataAddr += ((int)((VoidPtr)dPtr - (VoidPtr)dataAddr)).Align(4);
                    
                    fileHdr->_listOffset = (uint)((VoidPtr)dataAddr - (VoidPtr)baseAddr);
                    dataAddr += 4; //Empty list
                }
                else
                {
                    fileHdr->_headerLen = (uint)file._headerLen;
                    fileHdr->_dataLen = (uint)file._audioLen;
                    //fileHdr->_stringOffset = 0;
                    fileHdr->_listOffset = (uint)((VoidPtr)list - (VoidPtr)baseAddr);
                    list->_numEntries = file._groups.Count;
                    INFOFileEntry* fileEntries = (INFOFileEntry*)((VoidPtr)list + 4 + file._groups.Count * 8);
                    int z = 0;
                    List<int> used = new List<int>();
                    foreach (RSARGroupNode g in file._groups)
                    {
                        list->Entries[z] = (uint)((VoidPtr)(&fileEntries[z]) - baseAddr);
                        fileEntries[z]._groupId = g._rebuildIndex;
                        int[] all = g._files.FindAllOccurences(file);
                        foreach (int i in all)
                            if (!used.Contains(i))
                            {
                                fileEntries[z]._index = i;
                                break;
                            }
                        z++;
                    }
                    dataAddr = (VoidPtr)fileEntries + file._groups.Count * INFOFileEntry.Size;
                }
            }
            index = 0;
            //Set up group ruint list
            values[4] = (uint)dataAddr - (uint)baseAddr;
            entryList = (RuintList*)dataAddr;
            entryList->_numEntries = entries._groups.Count + 1;
            dataAddr += (entries._groups.Count + 1) * 8 + 4;

            //Write group entries
            foreach (RSAREntryState r in entries._groups)
            {
                r._node._rebuildBase = baseAddr;
                entryList->Entries[index++] = (uint)dataAddr - (uint)baseAddr;
                r._node.Rebuild(dataAddr, r._node._calcSize, true);
                dataAddr += r._node._calcSize;
            }
            //Null group at the end
            entryList->Entries[entries._groups.Count] = (uint)dataAddr - (uint)baseAddr;
            INFOGroupHeader* grp = (INFOGroupHeader*)dataAddr;
            node._nullGroup._rebuildAddr = grp;
            node._nullGroup._rebuildBase = baseAddr;
            *(bint*)(dataAddr + INFOGroupHeader.Size) = 0;
            grp->_entryNum = -1;
            grp->_stringId = -1;
            //grp->_extFilePathRef = 0;
            //grp->_extFilePathRef._dataType = 0;
            grp->_headerLength = 0;
            grp->_waveDataLength = 0;
            grp->_headerOffset = grp->_waveDataOffset = _headerLen + _symbLen + _infoLen + _fileLen;
            grp->_listOffset = (uint)((VoidPtr)(dataAddr + INFOGroupHeader.Size) - baseAddr);
            dataAddr += INFOGroupHeader.Size;
            RuintList* l = (RuintList*)dataAddr;
            INFOGroupEntry* e = (INFOGroupEntry*)((VoidPtr)l + 4 + node._nullGroup.Files.Count * 8);
            l->_numEntries = node._nullGroup.Files.Count;
            int y = 0;
            foreach (RSARFileNode file in node._nullGroup.Files)
            {
                l->Entries[y] = (uint)((VoidPtr)(&e[y]) - baseAddr);
                e[y++]._fileId = file._fileIndex;
                //entries[i]._dataLength = 0;
                //entries[i]._dataOffset = 0;
                //entries[i]._headerLength = 0;
                //entries[i]._headerOffset = 0;
            }
            dataAddr = (VoidPtr)e + node._nullGroup.Files.Count * 0x18;

            //Write footer
            values[5] = (uint)dataAddr - (uint)baseAddr;
            *(INFOFooter*)dataAddr = node.ftr;

            //Set header
            header->_header._tag = INFOHeader.Tag;
            header->_header._length = len = ((int)((dataAddr + INFOFooter.Size) - (baseAddr - 8))).Align(0x20);

            return len;
        }
        internal int EncodeFILEBlock(FILEHeader* header, RSAREntryList entries, RSARNode node)
        {
            int len = 0;
            VoidPtr baseAddr = (VoidPtr)header + 0x20;
            VoidPtr addr = baseAddr;

            //Build files - order by groups
            for (int x = 0; x <= entries._groups.Count; x++)
            {
                RSARGroupNode g = x == entries._groups.Count ? node._nullGroup : ((RSAREntryState)entries._groups[x])._node as RSARGroupNode;
                int headerLen = 0, audioLen = 0;
                int i = 0;
                INFOGroupEntry* e = (INFOGroupEntry*)((VoidPtr)g._rebuildAddr + INFOGroupHeader.Size + 4 + g._files.Count * 8);
                g._rebuildAddr->_headerOffset = (int)(addr - node._rebuildBase);
                foreach (RSARFileNode f in g.Files)
                {
                    e[i]._headerLength = f._headerLen;
                    e[i++]._headerOffset = headerLen;

                    headerLen += f._headerLen;
                }
                i = 0;
                VoidPtr wave = addr + headerLen;
                g._rebuildAddr->_waveDataOffset = (int)(wave - node._rebuildBase);
                foreach (RSARFileNode f in g.Files)
                {
                    f._rebuildAudioAddr = wave + audioLen;

                    f.Rebuild(addr, f._headerLen, true);
                    addr += f._headerLen;

                    e[i]._dataLength = f._audioLen;
                    e[i++]._dataOffset = f._audioLen == 0 ? 0 : audioLen;

                    audioLen += f._audioLen;
                }

                addr += audioLen;
                g._rebuildAddr->_headerLength = headerLen;
                g._rebuildAddr->_waveDataLength = audioLen;
            }

            len = ((int)addr - (int)(VoidPtr)header).Align(0x20);

            //Set header
            header->_header._tag = FILEHeader.Tag;
            header->_header._length = len;

            return len;
        }

        private static int EncodeMaskGroup(SYMBHeader* symb, SYMBMaskHeader* header, List<RSAREntryState> group)
        {
            header->_rootId = 0;
            header->_numEntries = group.Count * 2 - 1;
            SYMBMaskEntry* entry = header->Entries;
            foreach (RSAREntryState s in group)
            {
                *entry++ = new SYMBMaskEntry(1, 0xFFFF, -1, -1, s._stringId, s._index);
                if (s._index != 0)
                    *entry++ = new SYMBMaskEntry(0, 0, 0, 0, -1, -1);
            }
            return (int)entry - (int)header;

            //SYMBBinaryStringTable t = new SYMBBinaryStringTable(group);
            //t.Write(header);
            ////header->_rootId = 0xA;
            ////header->_numEntries = group.Count * 2 - 1;
            ////SYMBMaskEntry* entry = header->Entries;
            ////foreach (RSAREntryState s in group)
            ////    SYMBMaskEntry.Build(symb, header, s._stringId, s._index);
            //return 8 + header->_numEntries * SYMBMaskEntry.Size;
        }

        public unsafe class SYMBBinaryStringTable
        {
            private List<SYMBBinaryStringEntry> _entries = new List<SYMBBinaryStringEntry>();
            private SYMBBinaryStringEntry _root = new SYMBBinaryStringEntry("", 0, -1);

            public List<SYMBBinaryStringEntry> Entries { get { return _entries; } }
            public SYMBBinaryStringEntry RootEntry { get { return _root; } }

            public SYMBBinaryStringTable() { _entries.Add(_root); }
            public SYMBBinaryStringTable(List<RSAREntryState> group) 
            {
                //_entries.Add(_root);
                foreach (RSAREntryState e in group)
                {
                    if (e._index == 0)
                        _root = new SYMBBinaryStringEntry(e._node.Name, 0, e._stringId);
                    Add(e._node.Name, e._stringId);
                }
            }

            public void Add(string s, int stringId)
            {
                SYMBBinaryStringEntry entry = new SYMBBinaryStringEntry(s, _entries.Count, stringId);
                _entries.Add(entry);
                Traverse(entry);
            }

            private void Traverse(SYMBBinaryStringEntry entry)
            {
                SYMBBinaryStringEntry current = _root._left, prev = _root;
                bool isRight = false;

                while (entry._id <= current._id)
                {
                    if (entry._id == current._id)
                        entry.GenerateId(current);

                    isRight = current.IsRight(entry);

                    prev = current;
                    current = (isRight) ? current._right : current._left;

                    if (prev._id <= current._id)
                        break;
                }

                if (isRight)
                    prev.InsertRight(entry);
                else
                    prev.InsertLeft(entry);

                _root = prev;
            }

            public int GetTotalSize() { return (_entries.Count * 2 - 1) * SYMBMaskEntry.Size + 8; }
            public void Write(VoidPtr address)
            {
                SYMBMaskHeader* group = (SYMBMaskHeader*)address;
                group->_numEntries = _entries.Count * 2 - 1;

                SYMBMaskEntry* pEntry = group->Entries;
                foreach (SYMBBinaryStringEntry e in _entries)
                {
                    *pEntry++ = e.GetEntry1();
                    if (e._index != 0)
                        *pEntry++ = e.GetEntry2();
                }
            }
        }

        public class SYMBBinaryStringEntry
        {
            public string _name;
            public int _id, _index;
            public SYMBBinaryStringEntry _left, _right;
            public int _stringId;
            
            public SYMBBinaryStringEntry(string name, int index, int stringId)
            {
                _stringId = stringId;
                _name = name;
                _index = index;
                _left = _right = this;
                _id = (name == "") ? -1 : ((name.Length - 1) << 3) | CompareBits(name[name.Length - 1], 0);
            }

            public void InsertLeft(SYMBBinaryStringEntry entry)
            {
                if (entry.IsRight(_left))
                    entry._right = _left;
                else
                    entry._left = _left;

                _left = entry;
            }

            public void InsertRight(SYMBBinaryStringEntry entry)
            {
                if (entry.IsRight(_right))
                    entry._right = _right;
                else
                    entry._left = _right;

                _right = entry;
            }

            public int GenerateId(SYMBBinaryStringEntry comparison)
            {
                for (int i = _name.Length; i-- > 0; )
                    if (_name[i] != comparison._name[i])
                    {
                        _id = (i << 3) | CompareBits(_name[i], comparison._name[i]);
                        if (IsRight(comparison))
                        {
                            _left = this;
                            _right = comparison;
                        }
                        else
                        {
                            _left = comparison;
                            _right = this;
                        }
                        return _id;
                    }

                return 0;
            }

            public bool IsRight(SYMBBinaryStringEntry entry) { return (_name.Length != entry._name.Length) ? false : ((entry._name[(_id >> 3)] >> (_id & 7)) & 1) != 0; }

            internal SYMBMaskEntry GetEntry1() { return new SYMBMaskEntry(1, 0xFFFF, -1, -1, _stringId, _index); }
            internal SYMBMaskEntry GetEntry2() { return new SYMBMaskEntry(0, (ushort)_id, _left._index, _right._index, -1, -1); }
            
            private static int CompareBits(int b1, int b2)
            {
                for (int i = 8, b = 0x80; i-- != 0; b >>= 1)
                    if ((b1 & b) != (b2 & b))
                        return i;
                return 0;
            }
        }
    }

    public class RSAREntryState
    {
        public RSAREntryNode _node;
        public int _index;
        public int _stringId;

        public static int Compare(RSAREntryState n1, RSAREntryState n2)
        {
            return n2._node.InfoIndex < n1._node.InfoIndex ? 1 : n2._node.InfoIndex > n1._node.InfoIndex ? -1 : 0;
        }
    }

    public class RSARStringEntryState
    {
        public int _type;
        public int _index;
        public string _name;
    }

    public class RSAREntryList
    {
        public int _stringLength = 0;
        public List<string> _strings = new List<string>();
        public List<RSARStringEntryState> _tempStrings = new List<RSARStringEntryState>();
        public List<RSAREntryState> _sounds = new List<RSAREntryState>();
        public List<RSAREntryState> _playerInfo = new List<RSAREntryState>();
        public List<RSAREntryState> _groups = new List<RSAREntryState>();
        public List<RSAREntryState> _banks = new List<RSAREntryState>();
        public List<RSARFileNode> _files;

        public void AddEntry(string path, RSAREntryNode node)
        {
            RSAREntryState state = new RSAREntryState();
            RSARStringEntryState str = new RSARStringEntryState();

            state._node = node;
            if (node._name != "<null>")
                str._name = path;
            else 
                str._name = null;

            if (string.IsNullOrEmpty(str._name))
                state._stringId = -1;

            int type = -1;
            List<RSAREntryState> group;
            if (node is RSARSoundNode)
            {
                group = _sounds;
                type = 3;
            }
            else if (node is RSARGroupNode)
            {
                group = _groups;
                type = 1;
            }
            else if (node is RSARPlayerInfoNode)
            {
                group = _playerInfo;
                type = 0;
            }
            else
            {
                group = _banks;
                type = 2;
            }

            str._type = type;
            str._index = node.InfoIndex;

            _tempStrings.Add(str);

            state._index = group.Count;
            group.Add(state);

            state._node._rebuildIndex = state._index;
        }

        public void Clear()
        {
            _sounds.Clear();
            _playerInfo.Clear();
            _groups.Clear();
            _banks.Clear();
            _stringLength = 0;
            _strings = new List<string>();
            _tempStrings = new List<RSARStringEntryState>();
        }

        internal void SortStrings()
        {
            _stringLength = 0;
            _strings = new List<string>();
            int type = 0;
            int index = 0;
        Top:
            foreach (RSARStringEntryState s in _tempStrings)
            {
                if (s._type == type && s._index == index)
                {
                    if (s._name != null && !s._name.Contains("<null>"))
                        _strings.Add(s._name);
                    index++;
                    goto Top;
                }
            }
            if (++type < 4)
            {
                index = 0;
                goto Top;
            }

            foreach (string s in _strings)
                _stringLength += s.Length + 1;

            _sounds.Sort(RSAREntryState.Compare);
            _playerInfo.Sort(RSAREntryState.Compare);
            _groups.Sort(RSAREntryState.Compare);
            _banks.Sort(RSAREntryState.Compare);

            foreach (RSAREntryState s in _sounds)
                s._node._rebuildStringId = s._stringId = _strings.IndexOf(s._node._fullPath);
            foreach (RSAREntryState s in _playerInfo)
                s._node._rebuildStringId = s._stringId = _strings.IndexOf(s._node._fullPath);
            foreach (RSAREntryState s in _groups)
                s._node._rebuildStringId = s._stringId = _strings.IndexOf(s._node._fullPath);
            foreach (RSAREntryState s in _banks)
                s._node._rebuildStringId = s._stringId = _strings.IndexOf(s._node._fullPath);
        }
    }
}
