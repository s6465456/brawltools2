using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using BrawlLib.IO;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using BrawlLib.Wii.Compression;
using System.Runtime.InteropServices;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefEntryNode : ResourceNode
    {
        //Variables specific for rebuilding
        [Browsable(false)]
        public VoidPtr _rebuildBase { get { return Root._rebuildBase;  } }

        public int _lookupCount = 0;
        public List<int> _lookupOffsets = new List<int>();

        public VoidPtr _entryOffset = 0;
        public int _entryLength = 0, _childLength = 0;

        [Browsable(false)]
        public int _rebuildOffset { get { return (int)_entryOffset - (int)_rebuildBase; } }
        
        [Browsable(false)]
        public VoidPtr Data { get { return (VoidPtr)WorkingUncompressed.Address; } }
        [Browsable(false)]
        public VoidPtr BaseAddress { get { 
            if (Root == null) 
                return 0; 
            return Root.BaseAddress; } }
        [Browsable(false)]
        public MDL0Node Model { get { return Root.Model; } }
        [Browsable(false)]
        public MoveDefNode Root
        {
            get
            {
                ResourceNode n = _parent;
                while (!(n is MoveDefNode) && (n != null))
                    n = n._parent;
                return n as MoveDefNode;
            }
        }
        [Category("Moveset Entry"), Browsable(true)]
        public int IntOffset { get { return _offset; } }
        [Browsable(false)]
        public int _offset { get { if (Data != null) return (int)Data - (int)BaseAddress; else return 0; } }
        [Category("Moveset Entry"), Browsable(false)]
        public string HexOffset { get { return "0x" + _offset.ToString("X"); } }
        [Category("Moveset Entry"), Browsable(true)]
        public int Size { get { return WorkingUncompressed.Length; } }
        [Category("Moveset Entry"), Browsable(true)]
        public bool External { get { return _extNode != null; } }
        public override void Rebuild(bool force)
        {
            if (!IsDirty && !force)
                return;

            //Get uncompressed size
            int size = OnCalculateSize(force);

            //Create temp map
            FileMap uncompMap = FileMap.FromTempFile(size);

            //Rebuild node (uncompressed)
            Rebuild(uncompMap.Address, size, force);
            _replSrc.Map = _replUncompSrc.Map = uncompMap;

            //If compressed, compress resulting data.
            if (_compression != CompressionType.None)
            {
                //Compress node to temp file
                FileStream stream = new FileStream(Path.GetTempFileName(), FileMode.Open, FileAccess.ReadWrite, FileShare.None, 0x8, FileOptions.DeleteOnClose | FileOptions.SequentialScan);
                try
                {
                    Compressor.Compact(_compression, _entryOffset, _entryLength, stream, this);
                    _replSrc = new DataSource(FileMap.FromStreamInternal(stream, FileMapProtect.Read, 0, (int)stream.Length), _compression);
                }
                catch (Exception x) { stream.Dispose(); throw x; }
            }
        }

        public MoveDefExternalNode _extNode = null;
        public bool _extOverride = false;

        VoidPtr data = null;
        VoidPtr dAddr { get { return data == null ? data = Data : data; } }

        public int offsetID = 0;
        public bool isExtra = false;

        public override ResourceType ResourceType { get { return ResourceType.NoEdit; } }

        public override bool OnInitialize()
        {
            if (Root == null)
                return base.OnInitialize();
            if (_extNode == null)
            {
                _extNode = Root.IsExternal(_offset);
                if (_extNode != null && !_extOverride)
                {
                    _name = _extNode.Name;
                    _extNode._refs.Add(this);
                }
            }
            //if (Index <= 30)
            //    Root._paths[_offset] = TreePath;
            if (!MoveDefNode.nodeDictionary.ContainsKey(_offset))
                MoveDefNode.nodeDictionary.Add(_offset, this);
            if (Size == 0)
            {
                int size = Root.GetSize(_offset);
                if (size > 0)
                    SetSizeInternal(size);
            }
            return base.OnInitialize();
        }

        public ActionEventInfo GetEventInfo(long id)
        {
            if (FileManager.EventDictionary == null)
                FileManager.LoadEventDictionary();

            if (FileManager.EventDictionary.ContainsKey(id))
                return FileManager.EventDictionary[id];

            return new ActionEventInfo(id, id.ToString("X"), "No Description Available.", null, null);
        }

        public void SortChildren()
        {
            _children.Sort(MoveDefEntryNode.Compare);
        }

        public static int Compare(ResourceNode n1, ResourceNode n2)
        {
            if (((MoveDefEntryNode)n1)._offset < ((MoveDefEntryNode)n2)._offset)
                return -1;
            if (((MoveDefEntryNode)n1)._offset > ((MoveDefEntryNode)n2)._offset)
                return 1;

            return 0;
        }

        public static int ActionCompare(ResourceNode n1, ResourceNode n2)
        {
            if (((MoveDefEntryNode)n1.Children[0])._offset < ((MoveDefEntryNode)n2.Children[0])._offset)
                return -1;
            if (((MoveDefEntryNode)n1.Children[0])._offset > ((MoveDefEntryNode)n2.Children[0])._offset)
                return 1;

            return 0;
        }

        public ResourceNode FindNode(int offset)
        {
            ResourceNode n;
            if (offset == _offset)
                return this;
            else
                foreach (MoveDefEntryNode e in Children)
                    if ((n = e.FindNode(offset)) != null)
                        return n;

            return null;
        }

        public ResourceNode GetByOffsetID(int id)
        {
            foreach (MoveDefEntryNode e in Children)
                if (e.offsetID == id)
                    return e;
            return null;
        }

        public virtual void PostProcess() { }
    }

    public unsafe abstract class MoveDefExternalNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.NoEdit; } }

        public List<int> _offsets = new List<int>();
        public List<MoveDefEntryNode> _refs = new List<MoveDefEntryNode>();

        public MoveDefEntryNode[] References { get { return _refs.ToArray(); } }

        public override void Remove()
        {
            foreach (MoveDefEntryNode e in _refs)
                e._extNode = null;
            base.Remove();
        }
    }

    public unsafe class MoveDefNode : ARCEntryNode
    {
        internal FDefHeader* Header { get { return (FDefHeader*)WorkingUncompressed.Address; } }
        internal int dataSize, lookupOffset, numLookupEntries, numDataTable, numExternalSubRoutine;

        //internal static ResourceNode TryParse(DataSource source) 
        //{
        //    VoidPtr addr = source.Address;
        //    FDefHeader* header = (FDefHeader*)addr;

        //    if (header->_pad1 != 0 || header->_pad2 != 0 || header->_pad3 != 0)
        //        return null;

        //    if (header->_fileSize > source.Length || header->_lookupOffset > source.Length)
        //        return null;



        //    return new MoveDefNode();
        //}

        #region Stuff to find other stuff

        public List<ResourceNode> _externalRefs;
        public List<MoveDefExternalNode> _externalSections;
        public MoveDefExternalNode IsExternal(int offset)
        {
            foreach (MoveDefExternalNode e in _externalRefs)
                foreach (int i in e._offsets)
                    if (i == offset)
                        return e; 
            foreach (MoveDefExternalNode e in _externalSections)
                foreach (int i in e._offsets)
                    if (i == offset)
                        return e;
            return null;
        }

        public ResourceNode FindNode(int offset)
        {
            ResourceNode n;
            if (offset == 0)
                return this;
            else
                foreach (MoveDefEntryNode e in Children)
                    if ((n = e.FindNode(offset)) != null)
                        return n;

            return null;
        }

        public MoveDefActionNode GetAction(int offset)
        {
            int list, type, index;
            GetLocation(offset, out list, out type, out index);
            return GetAction(list, type, index);
        }

        public MoveDefActionNode GetAction(int list, int type, int index)
        {
            if ((list >= 3 && dataCommon == null) || list == 4 || index == -1)
                return null;

            if (list > 4 && dataCommon != null)
            {
                if (list == 5 && type >= 0 && index < dataCommon._flashOverlay.Children.Count)
                    return (MoveDefActionNode)dataCommon._flashOverlay.Children[index];//.Children[0];

                if (list == 6 && type >= 0 && index < dataCommon._screenTint.Children.Count)
                    return (MoveDefActionNode)dataCommon._screenTint.Children[index];//.Children[0];
            }

            if (list == 0 && type >= 0 && index < _actions.Children.Count)
                return (MoveDefActionNode)_actions.Children[index].Children[type];

            if (list == 1 && type >= 0 && index < _subActions.Children.Count)
                return (MoveDefActionNode)_subActions.Children[index].Children[type];

            if (list == 2 && _subRoutineList.Count > index)
                return (MoveDefActionNode)_subRoutineList[index];

            return null;
        }

        public int GetOffset(int list, int type, int index)
        {
            if (list == 4 || index == -1)
                return -1;

            if (list == 0 && type >= 0 && type < _actions.ActionOffsets.Count)
                if (_actions.ActionOffsets[type].Count > index)
                    return _actions.ActionOffsets[type][index];

            if (list == 1 && type >= 0 && type < _subActions.ActionOffsets.Count)
                if (_subActions.ActionOffsets[type].Count > index)
                    return _subActions.ActionOffsets[type][index];

            if (list == 2)
                if (_subRoutineList.Count > index)
                    return ((MoveDefEntryNode)_subRoutineList[index])._offset;

            if (list == 3)
                if (_externalRefs.Count > index)
                    return ((MoveDefEntryNode)_externalRefs[index])._offset;

            return -1;
        }

        public void GetLocation(int offset, out int list, out int type, out int index)
        {
            list = 0;
            type = -1; 
            index = -1;

            bool done = false;

            if ((dataCommon == null && data == null) || offset <= 0)
            {
                list = 4; //Null
                done = true;
            }

            if (!done && _actions != null) //Search actions
                for (type = 0; type < _actions.ActionOffsets.Count; type++)
                    if ((index = _actions.ActionOffsets[type].IndexOf(offset)) != -1)
                    {
                        done = true;
                        break;
                    }
            if (!done) //Search sub actions
            {
                list++;
                if (_subActions != null)
                for (type = 0; type < _subActions.ActionOffsets.Count; type++)
                    if ((index = _subActions.ActionOffsets[type].IndexOf(offset)) != -1)
                        {
                            done = true;
                            break;
                        }
            }
            if (!done) //Search subroutines
            {
                list++;
                if (_subRoutines.ContainsKey(offset))
                {
                    index = _subRoutines[offset].Index;
                    type = -1;
                    done = true;
                }
            }
            if (!done)
            {
                list++;
                MoveDefExternalNode e = IsExternal(offset);
                if (e != null)
                {
                    index = e.Index;
                    type = -1;
                    done = true;
                }
            }
            if (!done)
            {
                list++;
                type = -1;
                index = -1;
            }
            if (dataCommon != null && data == null && offset > 0)
            {
                if (dataCommon._screenTint != null && !done)
                {
                    list++;
                    if ((index = dataCommon._screenTint.ActionOffsets.IndexOf((uint)offset)) != -1)
                        return;
                }
                if (dataCommon._flashOverlay != null && !done)
                {
                    list++;
                    if ((index = dataCommon._flashOverlay.ActionOffsets.IndexOf((uint)offset)) != -1)
                        return;
                }
            }
            if (!done)
                list = 4;
        }

        #endregion

        public int GetSize(int offset)
        {
            if (_lookupSizes.ContainsKey(offset))
            {
                //_lookupSizes[offset].remove = true;
                return _lookupSizes[offset].DataSize;
            }
            return -1;
        }

        public void GetBoneIndex(ref int boneIndex)
        {
            if (RootNode.Name.StartsWith("FitWario") || RootNode.Name == "FitKirby")
            {
                if (data != null)
                    if (data.warioParams8 != null)
                    {
                        MoveDefSectionParamNode p1 = data.warioParams8.Children[0] as MoveDefSectionParamNode;
                        MoveDefSectionParamNode p2 = data.warioParams8.Children[1] as MoveDefSectionParamNode;
                        bint* values = (bint*)p2.AttributeBuffer.Address;
                        int i = 0;
                        for ( ; i < p2.AttributeBuffer.Length / 4; i++)
                            if (values[i] == boneIndex)
                                break;
                        if (p1.AttributeBuffer.Length / 4 > i)
                        {
                            int value = -1;
                            if ((value = (int)(((bint*)p1.AttributeBuffer.Address)[i])) >= 0)
                            {
                                boneIndex = value;
                                return;
                            }
                            else boneIndex -= 400;
                        }
                    }
            }
        }

        public void SetBoneIndex(ref int boneIndex)
        {
            if (RootNode.Name.StartsWith("FitWario") || RootNode.Name == "FitKirby")
            {
                if (data != null)
                    if (data.warioParams8 != null)
                    {
                        MoveDefSectionParamNode p1 = data.warioParams8.Children[0] as MoveDefSectionParamNode;
                        MoveDefSectionParamNode p2 = data.warioParams8.Children[1] as MoveDefSectionParamNode;
                        bint* values = (bint*)p2.AttributeBuffer.Address;
                        int i = 0;
                        for (; i < p1.AttributeBuffer.Length / 4; i++)
                            if (values[i] == boneIndex)
                                break;
                        if (p2.AttributeBuffer.Length / 4 > i)
                        {
                            int value = -1;
                            if ((value = ((bint*)p2.AttributeBuffer.Address)[i]) >= 0)
                            {
                                boneIndex = value;
                                return;
                            }
                        }
                    }
            }
        }

        public bool[] StatusIDs;

        public Dictionary<uint, List<MoveDefEventNode>> _events;

        public SortedList<int, string> _paths = new SortedList<int, string>();
        public SortedList<int, string> Paths { get { return _paths; } }

        public Dictionary<string, SectionParamInfo> Params = null;

        public MoveDefActionListNode _subActions;
        public MoveDefActionListNode _actions;

        public SortedDictionary<int, MoveDefActionNode> _subRoutines;
        public List<ResourceNode> _subRoutineList;
        public ResourceNode _subRoutineGroup;

        public MoveDefDataNode data;
        public MoveDefDataCommonNode dataCommon;

        public MoveDefReferenceNode references;
        public MoveDefSectionNode sections;
        public MoveDefLookupNode lookupNode;

        public CompactStringTable refTable;

        public Dictionary<int, MoveDefLookupOffsetNode> _lookupSizes;

        public MDL0Node _model = null;

        [Category("Moveset Definition")]
        public int LookupOffset { get { return lookupOffset; } }
        [Category("Moveset Definition")]
        public int LookupCount { get { return numLookupEntries; } }
        [Category("Moveset Definition")]
        public int DataTableCount { get { return numDataTable; } }
        [Category("Moveset Definition")]
        public int ExtSubRoutines { get { return numExternalSubRoutine; } }

        public MDL0Node Model { get { return _model; } }

        public override ResourceType ResourceType { get { return ResourceType.MDef; } }
        public VoidPtr BaseAddress;
        
        [Category("Moveset Definition")]
        public string DataSize { get { return "0x" + dataSize.ToString("X"); } }

        public SortedDictionary<int, MoveDefEntryNode> NodeDictionary { get { return nodeDictionary; } }

        public static SortedDictionary<int, MoveDefEntryNode> nodeDictionary = new SortedDictionary<int, MoveDefEntryNode>();

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Moveset";

            nodeDictionary = new SortedDictionary<int, MoveDefEntryNode>();

            dataSize = Header->_fileSize;
            lookupOffset = Header->_lookupOffset;
            numLookupEntries = Header->_lookupEntryCount;
            numDataTable = Header->_dataTableEntryCount;
            numExternalSubRoutine = Header->_externalSubRoutineCount;

            BaseAddress = (VoidPtr)Header + 0x20;
            return true;
        }

        //Offset - Size
        public Dictionary<int, int> _lookupEntries;

        public void LoadOtherData()
        {
            Params = new Dictionary<string, SectionParamInfo>();
            string loc = Application.StartupPath + "/MovesetData/CharSpecific/" + Name + ".txt";
            string name = "", attrName = "";
            if (File.Exists(loc))
                using (StreamReader sr = new StreamReader(loc))
                    while (!sr.EndOfStream)
                    {
                        name = sr.ReadLine();
                        SectionParamInfo info = new SectionParamInfo();
                        info.NewName = sr.ReadLine();
                        info.Attributes = new List<AttributeInfo>();
                        while (true && !sr.EndOfStream)
                        {
                            if (String.IsNullOrEmpty(attrName = sr.ReadLine()))
                                break;
                            else
                            {
                                AttributeInfo i = new AttributeInfo();
                                i._name = attrName;
                                i._description = sr.ReadLine();
                                i._type = int.Parse(sr.ReadLine());
                                info.Attributes.Add(i);
                                sr.ReadLine();
                            }
                        }
                        if (!Params.ContainsKey(name))
                            Params.Add(name, info);
                    }
        }

        public override void OnPopulate()
        {
            _subRoutines = new SortedDictionary<int, MoveDefActionNode>();
            _externalRefs = new List<ResourceNode>();
            _externalSections = new List<MoveDefExternalNode>();
            _lookupSizes = new Dictionary<int, MoveDefLookupOffsetNode>();
            _events = new Dictionary<uint, List<MoveDefEventNode>>();
            StatusIDs = new bool[0];

            LoadOtherData();

            //Parse references first but don't add to children yet
            if (numExternalSubRoutine > 0)
            {
                (references = new MoveDefReferenceNode(Header->StringTable) { _parent = this }).Initialize(this, new DataSource(Header->ExternalSubRoutines, numExternalSubRoutine * 8));
                _externalRefs = references.Children;
            }
            (sections = new MoveDefSectionNode(Header->_fileSize, (VoidPtr)Header->StringTable)).Initialize(this, new DataSource(Header->DataTable, Header->_dataTableEntryCount * 8));
            (lookupNode = new MoveDefLookupNode(Header->_lookupEntryCount) { _parent = this }).Initialize(this, new DataSource(Header->LookupEntries, Header->_lookupEntryCount * 4));

            //Now add to children
            if (references != null)
                Children.Add(references);

            MoveDefSubRoutineListNode g = new MoveDefSubRoutineListNode() { _name = "SubRoutines", _parent = this };

            _subRoutineGroup = g;
            _subRoutineList = g.Children;

            //Load subroutines
            //if (!RootNode._origPath.Contains("Test"))
            {
                sections.Populate();
                foreach (MoveDefEntryNode p in sections._sectionList)
                    if (p is MoveDefExternalNode && (p as MoveDefExternalNode)._refs.Count == 0)
                        sections.Children.Add(p);
            }
            g._name = "[" + g.Children.Count + "] " + g._name;

            _children.Add(g);

            _children.Sort(MoveDefEntryNode.Compare);

            _children[0]._children.Sort(MoveDefEntryNode.Compare);
            for (int i = 0; i < _children[0]._children.Count; i++)
                _children[0]._children[i]._name = "SubRoutine" + i;
            int x = 0;
            {
                foreach (MoveDefActionNode i in _subRoutines.Values)
                {
                    i._name = "SubRoutine" + x;
                    foreach (MoveDefEventNode e in i._actionRefs)
                        if (e.EventID == 218104320)
                            (e.Children[1] as MoveDefEventOffsetNode).index = x;
                        else
                            (e.Children[0] as MoveDefEventOffsetNode).index = x;
                    x++;
                }
            }

            //for (int i = 0; i < lookupNode.Children.Count; i++)
            //    if ((lookupNode.Children[i] as MoveDefLookupOffsetNode).remove)
            //        lookupNode.Children[i--].Remove();

            //foreach (var i in Paths)
            //    Console.WriteLine(i.ToString());
        }

        public List<MoveDefEntryNode> _postProcessNodes;
        public VoidPtr _rebuildBase;
        public static LookupManager _lookupOffsets;
        public int lookupCount = 0, lookupLen = 0;
        public override int OnCalculateSize(bool force)
        {
            int size = 0x20;
            _postProcessNodes = new List<MoveDefEntryNode>();
            _lookupOffsets = new LookupManager();
            lookupCount = 0;
            lookupLen = 0;
            refTable = new CompactStringTable();
            foreach (MoveDefEntryNode e in sections._sectionList)
            {
                e._lookupCount = 0;
                if (e is MoveDefExternalNode)
                {
                    MoveDefExternalNode ext = e as MoveDefExternalNode;
                    if (ext._refs.Count > 0)
                    {
                        MoveDefEntryNode entry = ext._refs[0];

                        if ((entry.Parent is MoveDefDataNode || entry.Parent is MoveDefMiscNode) && !entry.isExtra)
                            lookupCount++;

                        if (!(entry is MoveDefRawDataNode))
                            entry.CalculateSize(true);
                        else
                            if (entry.Children.Count > 0)
                            {
                                int off = 0;
                                foreach (MoveDefEntryNode n in entry.Children)
                                {
                                    off += n.CalculateSize(true);
                                    entry._lookupCount += n._lookupCount;
                                }
                                entry._entryLength = entry._calcSize = off;
                            }
                            else
                                entry.CalculateSize(true);

                        e._lookupCount = entry._lookupCount;
                        e._childLength = entry._childLength;
                        e._entryLength = entry._entryLength;
                        e._calcSize = entry._calcSize;
                    }
                    else
                        e.CalculateSize(true);
                }
                else
                    e.CalculateSize(true);

                size += (e._calcSize == 0 ? e._childLength + e._entryLength : e._calcSize) + 8;
                lookupCount += e._lookupCount;
                refTable.Add(e.Name);
            }
            refCount = 0;
            if (references != null)
            foreach (MoveDefExternalNode e in references.Children)
            {
                if (e._refs.Count > 0)
                {
                    refTable.Add(e.Name);
                    size += 8;
                    refCount++;
                }
                //references don't use lookup table
                //lookupCount += e._refs.Count - 1;
            }
            return size + (lookupLen = lookupCount * 4) + refTable.TotalSize;
        }
        int refCount = 0;
        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            //Children are built in order but before their parent! 

            _rebuildBase = address + 0x20;

            FDefHeader* header = (FDefHeader*)address;
            header->_fileSize = length;
            header->_externalSubRoutineCount = refCount;
            header->_dataTableEntryCount = sections._sectionList.Count;
            header->_lookupEntryCount = lookupCount;
            header->_pad1 = header->_pad2 = header->_pad3 = 0;

            VoidPtr dataAddress = _rebuildBase;

            int lookupOffset = 0, sectionsOffset = 0;
            foreach (MoveDefEntryNode e in sections._sectionList)
            {
                lookupOffset += (e._calcSize == 0 ? e._childLength + e._entryLength : e._calcSize);
                sectionsOffset += e._childLength;
            }

            VoidPtr lookupAddress = dataAddress + lookupOffset;
            VoidPtr sectionsAddr = dataAddress + sectionsOffset;
            VoidPtr dataHeaderAddr = dataAddress;

            foreach (MoveDefEntryNode e in sections._sectionList)
            {
                e._lookupOffsets.Clear();
                if (e.Name == "data" || e.Name == "dataCommon")
                {
                    dataHeaderAddr = sectionsAddr; //Don't rebuild yet
                    sectionsAddr += e._entryLength;
                }
                else //Rebuild other sections first
                {
                    if (e is MoveDefExternalNode)
                    {
                        MoveDefExternalNode ext = e as MoveDefExternalNode;
                        if (ext._refs.Count > 0)
                        {
                            MoveDefEntryNode entry = ext._refs[0];

                            if (!(entry is MoveDefRawDataNode))
                                entry.Rebuild(sectionsAddr, entry._calcSize, true);
                            else
                                if (entry.Children.Count > 0)
                                {
                                    entry._entryOffset = sectionsAddr;
                                    int off = 0;
                                    foreach (MoveDefEntryNode n in entry.Children)
                                    {
                                        n.Rebuild(sectionsAddr + off, n._calcSize, true);
                                        off += n._calcSize;
                                        entry._lookupOffsets.AddRange(n._lookupOffsets);
                                    }
                                }
                                else
                                    entry.Rebuild(sectionsAddr, entry._calcSize, true);

                            e._entryOffset = entry._entryOffset;
                            e._lookupOffsets = entry._lookupOffsets;
                        }
                        else
                            e.Rebuild(sectionsAddr, e._calcSize, true);
                    }
                    else
                        e.Rebuild(sectionsAddr, e._calcSize, true);
                    if (e._lookupCount != e._lookupOffsets.Count && !((e as MoveDefExternalNode)._refs[0] is MoveDefActionNode))
                        Console.WriteLine();
                    _lookupOffsets.AddRange(e._lookupOffsets.ToArray());
                    sectionsAddr += e._calcSize;
                }
            }

            if (data != null)
            {
                data.dataHeaderAddr = dataHeaderAddr;
                data.Rebuild(address + 0x20, data._childLength, true);
            }
            else if (dataCommon != null)
            {
                dataCommon.dataHeaderAddr = dataHeaderAddr;
                dataCommon.Rebuild(address + 0x20, dataCommon._childLength, true);
            }

            foreach (MoveDefExternalNode e in references.Children)
            {
                for (int i = 0; i < e._refs.Count; i++)
                {
                    bint* addr = (bint*)e._refs[i]._entryOffset;
                    if (i == e._refs.Count - 1)
                        *addr = -1;
                    else
                    {
                        *addr = (int)e._refs[i + 1]._entryOffset - (int)_rebuildBase;

                        //references don't use lookup table
                        //_lookupOffsets.Add((int)addr - (int)_rebuildBase);
                    }
                }
            }

            _lookupOffsets.values.Sort();

            if (lookupCount != _lookupOffsets.Count)
                Console.WriteLine(lookupCount - _lookupOffsets.Count);

            header->_lookupOffset = (int)lookupAddress - (int)_rebuildBase;
            header->_lookupEntryCount = _lookupOffsets.Count;

            if (data != null && data.warioSwing4StringOffset > 0 && data.warioParams6 != null)
                ((WarioExtraParams6*)data.warioParams6._entryOffset)->_offset = data.warioSwing4StringOffset;

            int val = -1;
            if (data != null && data.zssFirstOffset > 0)
                val = data.zssFirstOffset;

            bint* values = (bint*)lookupAddress;
            foreach (int i in _lookupOffsets.values)
            {
                if (val == i && data != null && data.zssParams8 != null)
                {
                    *(bint*)data.zssParams8._entryOffset = 29;
                    *((bint*)data.zssParams8._entryOffset + 1) = (int)values - (int)_rebuildBase;
                }

                *values++ = i;
            }

            dataAddress = (VoidPtr)values;
            VoidPtr refTableAddr = dataAddress + sections._sectionList.Count * 8 + refCount * 8;
            refTable.WriteTable(refTableAddr);

            foreach (MoveDefEntryNode e in sections._sectionList)
            {
                *values++ = (int)e._entryOffset - (int)_rebuildBase;
                *values++ = (int)refTable[e.Name] - (int)refTableAddr;
            }

            foreach (MoveDefExternalNode e in references.Children)
                if (e._refs.Count > 0)
                {
                    *values++ = (int)e._refs[0]._entryOffset - (int)_rebuildBase;
                    *values++ = (int)refTable[e.Name] - (int)refTableAddr;
                }
            
            //Some nodes handle rebuilding their own children, 
            //so if one of those children has changed, the node will stay dirty and may rebuild over itself.
            //Manually set IsDirty to false to avoid that.
            IsDirty = false;

            BaseAddress = _rebuildBase;
        }
    }

    public class LookupManager
    {
        public List<int> values = new List<int>();
        public int Count { get { return values.Count; } }
        public void Add(int value)
        {
            if (value > 0 && !values.Contains(value))
                if (value < 1480)
                    Console.WriteLine(value);
                else
                    values.Add(value);
            else
                Console.WriteLine(value);
        }
        public void AddRange(int[] vals)
        {
            foreach (int value in vals)
                if (value > 0 && !values.Contains(value))
                    if (value < 1480)
                        Console.WriteLine(value);
                    else
                        values.Add(value);
                else
                    Console.WriteLine(value);
        }
    }

    public class NameSizeGroup { public string Name; public int Size; public NameSizeGroup(string name, int size) { Name = name; Size = size; } }

    public unsafe class MoveDefSectionNode : MoveDefEntryNode
    {
        internal FDefStringEntry* Header { get { return (FDefStringEntry*)WorkingUncompressed.Address; } }
        private Dictionary<NameSizeGroup, FDefStringEntry> DataTable = new Dictionary<NameSizeGroup, FDefStringEntry>();
        private FDefStringTable* stringTable;
        public int DataSize = 0, dataOffset = 0;

        public MoveDefSectionNode(int dataSize, VoidPtr table) { DataSize = dataSize; stringTable = (FDefStringTable*)table; }

        public override bool OnInitialize()
        {
            base.OnInitialize();

            _name = "Sections";

            for (int i = 0; i < WorkingUncompressed.Length / 8; i++)
                DataTable.Add(new NameSizeGroup(stringTable->GetString(Header[i]._stringOffset), 0), Header[i]);
            
            CalculateDataLen();

            foreach (var data in DataTable)
                if (data.Key.Name == "data" || data.Key.Name == "dataCommon")
                    dataOffset = data.Value._dataOffset;

            return true;
        }
        private void CalculateDataLen()
        {
            List<KeyValuePair<NameSizeGroup, FDefStringEntry>> sorted = DataTable.OrderBy(x => ((int)x.Value._dataOffset)).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                if (i < sorted.Count - 1)
                    sorted[i].Key.Size = (int)(sorted[i + 1].Value._dataOffset - sorted[i].Value._dataOffset);
                else sorted[i].Key.Size = (int)(((MoveDefNode)Parent).lookupOffset - sorted[i].Value._dataOffset);
                //Console.WriteLine(sorted[i].ToString());
            }
        }
        public List<MoveDefEntryNode> _sectionList;
        public override void OnPopulate()
        {
            _sectionList = new List<MoveDefEntryNode>();

            int offsetID = 0;

            //Parse external offsets first
            foreach (var data in DataTable)
            {
                if (data.Key.Name != "data" && data.Key.Name != "dataCommon" && data.Key.Name != "animParam" && data.Key.Name != "subParam")
                {
                    MoveDefRawDataNode r = new MoveDefRawDataNode(data.Key.Name) { _parent = this, offsetID = offsetID };
                    r.Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                    Root._externalSections.Add(r);
                    _sectionList.Add(r);
                }
                offsetID++;
            }

            offsetID = 0;

            //Now add the data node
            foreach (var data in DataTable)
            {
                if (data.Key.Name == "data")
                {
                    (Root.data = new MoveDefDataNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }).Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                    _sectionList.Add(Root.data);
                    break;
                }
                else if (data.Key.Name == "dataCommon")
                {
                    (Root.dataCommon = new MoveDefDataCommonNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }).Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                    _sectionList.Add(Root.dataCommon);
                    break;
                }
                //else if (data.Key.Name == "animParam")
                //{
                //    (Root.animParam = new MoveDefAnimParamNode(data.Key.Name) { offsetID = offsetID }).Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                //    _sectionList.Add(Root.animParam);
                //}
                //else if (data.Key.Name == "subParam")
                //{
                //    (Root.subParam = new MoveDefSubParamNode(data.Key.Name) { offsetID = offsetID }).Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                //    _sectionList.Add(Root.subParam);
                //}
                offsetID++;
            }

            SortChildren();
            _sectionList.Sort(MoveDefEntryNode.Compare);
        }
    }

    public class SpecialOffset { public int Index; public int Offset; public int Size; public override string ToString() { return String.Format("[{2}] Offset={0} Size={1}", Offset, Size, Index); } }

    public unsafe class MoveDefActionsNode : MoveDefEntryNode
    {
        internal bint* Header { get { return (bint*)WorkingUncompressed.Address; } }

        internal List<int> ActionOffsets = new List<int>();

        public MoveDefActionsNode(string name) { _name = name; }

        public override bool OnInitialize()
        {
            base.OnInitialize();
            for (int i = 0; i < WorkingUncompressed.Length / 4; i++)
                ActionOffsets.Add(Header[i]);
            return true;
        }

        public override void OnPopulate()
        {
            int i = 0;
            foreach (int offset in ActionOffsets)
            {
                if (offset > 0)
                    new MoveDefActionNode("Action" + i, false, null).Initialize(this, new DataSource(BaseAddress + offset, 0));
                else
                    Children.Add(new MoveDefActionNode("Action" + i, true, this));
                
                i++;
            }
        }
    }
}