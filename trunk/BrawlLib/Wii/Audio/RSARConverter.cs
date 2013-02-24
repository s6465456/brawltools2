using System;
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
                    //Make an attempt to get current file size
                    uint s = 0;
                    if (file.ExternalFileInfo.Exists)
                        s = (uint)file.ExternalFileInfo.Length;
                    if (file._extFileSize != s && s != 0) file._extFileSize = s;
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
                        bool done = false;
                        foreach (int i in all)
                            if (!used.Contains(i))
                            {
                                fileEntries[z]._index = i;
                                used.Add(i);
                                done = true;
                                break;
                            }
                        if (!done)
                            fileEntries[z]._index = g._files.IndexOf(file);
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

        static void GenIds(SYMBHeader* symb, SYMBMaskHeader* header, int index, ushort allowedBit)
        {
            //Pants.

            SYMBMaskEntry* main = &header->Entries[index];
            string mainName = symb->GetStringEntry(main->_stringId);

            for (int i = 1; i < header->_numEntries; i += (i == 0 ? 1 : 2))
            {
                SYMBMaskEntry* leafMatchEntry = &header->Entries[i];
                SYMBMaskEntry* nonLeafMatchEntry = &header->Entries[i + 1];

                if (i == index || nonLeafMatchEntry->_bit != allowedBit)
                    continue;

                string compName = symb->GetStringEntry(leafMatchEntry->_stringId);

                int bitIndex = -1, bit = 0, b;
                int min = Math.Min(mainName.Length, compName.Length);
                for (b = 0; b < Math.Max(mainName.Length, compName.Length); b++)
                {
                    if (min <= b)
                    {
                        //Case where one string is longer but they match for as long as the shortest string
                        bitIndex = min * 8;
                        break;
                    }

                    bool brk = false;
                    byte b1 = (byte)mainName[b];
                    byte b2 = (byte)compName[b];

                    for (bit = 0; bit < 8; bit++)
                        if ((b1 >> (8 - bit) & 1) != (b2 >> (8 - bit) & 1))
                        {
                            bitIndex = b * 8 + bit - 1;
                            brk = true;
                            break;
                        }
                    if (brk)
                        break;
                }

                if (bitIndex >= 0)
                {
                    //Set the bit index
                    nonLeafMatchEntry->_bit = (ushort)bitIndex;

                    bool leftFound = false, rightFound = false;

                    //Keeping looking down the list for the left and right entries
                    for (int x = i + 2; x < header->_numEntries; x += 2)
                    {
                        SYMBMaskEntry* compEntryLeafed = &header->Entries[x];
                        SYMBMaskEntry* compEntryNonLeafed = &header->Entries[x + 1];
                        compName = symb->GetStringEntry(compEntryLeafed->_stringId);

                        if (x == index || compEntryNonLeafed->_bit != allowedBit)
                            continue;

                        byte b1 = 0, b2 = 0;
                        bool forceLeft = false;

                        if (mainName.Length <= b || compName.Length <= b)
                            forceLeft = true;
                        else
                        {
                            b1 = (byte)mainName[b];
                            b2 = (byte)compName[b];
                        }

                        if (forceLeft || (((b1 >> (8 - bit)) & 1) == ((b2 >> (8 - bit)) & 1)))
                        {
                            if (leftFound)
                                continue;

                            leftFound = true;

                            nonLeafMatchEntry->_leftId = compEntryLeafed->_index;
                            GenIds(symb, header, compEntryLeafed->_index, compEntryNonLeafed->_bit);
                            break;
                        }
                        else
                        {
                            if (rightFound)
                                continue;

                            rightFound = true;

                            nonLeafMatchEntry->_rightId = compEntryLeafed->_index;
                            GenIds(symb, header, compEntryLeafed->_index, compEntryNonLeafed->_bit);
                            break;
                        }
                    }

                    if (!leftFound) //No strings matched
                        nonLeafMatchEntry->_leftId = leafMatchEntry->_index;
                    else if (!rightFound) //All strings matched
                        nonLeafMatchEntry->_rightId = leafMatchEntry->_index;

                    //For the next bit you find that MATCHES write it’s non-leafed entry id into LEFT ID. 
                    //If no string matches, then write the leafed entry id into it.
                    //For the next bit you find that DOESN’T match, write it’s non-leafed entry id into RIGHT ID. 
                    //If all strings match, then write the leafed entry id into it.
                    //Break when done
                    break;
                }
            }
        }

        private static int EncodeMaskGroup(SYMBHeader* symb, SYMBMaskHeader* header, List<RSAREntryState> group)
        {
            SYMBMaskEntry* entry = header->Entries;
            foreach (RSAREntryState s in group)
            {
                *entry++ = new SYMBMaskEntry(1, 0xFFFF, -1, -1, s._stringId, s._index);
                if (s._index != 0)
                    *entry++ = new SYMBMaskEntry(0, 0, 0, 0, -1, -1);
            }

            header->_numEntries = group.Count * 2 - 1;

            //GenIds(symb, header, 0, 0);

            return (int)((VoidPtr)entry - (VoidPtr)header);
        }
    }

    public unsafe class SymbMaskEntryTable
    {
        public List<SYMBMaskPair> _pairs = new List<SYMBMaskPair>();

        public void Add(RSAREntryState state)
        {

        }

        public void Write(SYMBMaskHeader* header)
        {
            int rootId = 0;
            int lowestBit = int.MaxValue;
            SYMBMaskEntry* entry = header->Entries;
            foreach (SYMBMaskPair s in _pairs)
            {
                *entry++ = s._leafed;
                if (s._index != 0)
                    *entry++ = s._nonLeafed;

                if (s._nonLeafed._bit < lowestBit)
                {
                    lowestBit = s._nonLeafed._bit;
                    rootId = s._leafed._index + 1;
                }
            }
            header->_numEntries = _pairs.Count * 2 - 1;
            header->_rootId = rootId;
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
            //return n2._stringId < n1._stringId ? 1 : n2._stringId > n1._stringId ? -1 : 0;
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

            //_sounds.Sort(RSAREntryState.Compare);
            //_playerInfo.Sort(RSAREntryState.Compare);
            //_groups.Sort(RSAREntryState.Compare);
            //_banks.Sort(RSAREntryState.Compare);
        }
    }
}
