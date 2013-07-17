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
        public VoidPtr RebuildBase { get { return MoveDefNode.Builder == null ? null : MoveDefNode.Builder._rebuildBase; } }

        public int _lookupCount = 0;
        public List<VoidPtr> _lookupOffsets = new List<VoidPtr>();

        //Nodes rebuild with their children before them
        //This is the address of the main data that contains all the children
        public VoidPtr _rebuildAddr;
        public int _entryLength = 0, _childLength = 0;

        [Browsable(false)]
        public int RebuildOffset { get { return (int)_rebuildAddr - (int)RebuildBase; } }
        
        [Browsable(false)]
        public VoidPtr Data { get { return (VoidPtr)WorkingUncompressed.Address; } }
        [Browsable(false)]
        public VoidPtr BaseAddress 
        {
            get
            {
                if (Root == null)
                    return 0;

                return Root._baseAddress;
            }
        }
        [Browsable(false)]
        public MDL0Node Model { get { return Root._model; } }
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
        [Category("Moveset Entry"), Browsable(false)]
        public int IntOffset { get { return _offset; } }
        [Browsable(false)]
        public int _offset { get { if (Data != null) return (int)Data - (int)BaseAddress; else return 0; } }
        [Category("Moveset Entry"), Browsable(true)]
        public string DataOffset { get { return _offset.ToString("X"); } }
        [Category("Moveset Entry"), Browsable(true)]
        public int Size { get { return WorkingUncompressed.Length; } }
        [Category("Moveset Entry"), Browsable(true)]
        public bool External { get { return _extNode != null; } }

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
            if (!Root.nodeDictionary.ContainsKey(_offset))
                Root.nodeDictionary.Add(_offset, this);
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

        public virtual void PostProcess(LookupManager lookupOffsets) { }
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
        public override ResourceType ResourceType { get { return ResourceType.MDef; } }

        [Category("Moveset Definition")]
        public int LookupOffset { get { return lookupOffset; } }
        [Category("Moveset Definition")]
        public int LookupCount { get { return numLookupEntries; } }
        [Category("Moveset Definition")]
        public int DataTableCount { get { return numDataTable; } }
        [Category("Moveset Definition")]
        public int ExtSubRoutines { get { return numExternalSubRoutine; } }
        [Category("Moveset Definition")]
        public string DataSize { get { return "0x" + dataSize.ToString("X"); } }

        public MoveDefNode(CharName character)
        {
            _character = character;
        }

        #region Stuff to get other stuff
        
        public int GetSize(int offset)
        {
            if (_lookupSizes.ContainsKey(offset))
            {
                //_lookupSizes[offset].remove = true;
                return _lookupSizes[offset].DataSize;
            }
            return -1;
        }

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
            if ((list >= 3 && _dataCommon == null) || list == 4 || index == -1)
                return null;

            if (list > 4 && _dataCommon != null)
            {
                if (list == 5 && type >= 0 && index < _dataCommon._flashOverlay.Children.Count)
                    return (MoveDefActionNode)_dataCommon._flashOverlay.Children[index];//.Children[0];

                if (list == 6 && type >= 0 && index < _dataCommon._screenTint.Children.Count)
                    return (MoveDefActionNode)_dataCommon._screenTint.Children[index];//.Children[0];
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

            if ((_dataCommon == null && _data == null) || offset <= 0)
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
            if (_dataCommon != null && _data == null && offset > 0)
            {
                if (_dataCommon._screenTint != null && !done)
                {
                    list++;
                    if ((index = _dataCommon._screenTint.ActionOffsets.IndexOf((uint)offset)) != -1)
                        return;
                }
                if (_dataCommon._flashOverlay != null && !done)
                {
                    list++;
                    if ((index = _dataCommon._flashOverlay.ActionOffsets.IndexOf((uint)offset)) != -1)
                        return;
                }
            }
            if (!done)
                list = 4;
        }

        #endregion

        #region Bone Index Handling

        public void GetBoneIndex(ref int boneIndex)
        {
            if (RootNode.Name.StartsWith("FitWario") || RootNode.Name == "FitKirby")
            {
                if (_data != null)
                    if (_data.warioParams8 != null)
                    {
                        MoveDefSectionParamNode p1 = _data.warioParams8.Children[0] as MoveDefSectionParamNode;
                        MoveDefSectionParamNode p2 = _data.warioParams8.Children[1] as MoveDefSectionParamNode;
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
                if (_data != null)
                    if (_data.warioParams8 != null)
                    {
                        MoveDefSectionParamNode p1 = _data.warioParams8.Children[0] as MoveDefSectionParamNode;
                        MoveDefSectionParamNode p2 = _data.warioParams8.Children[1] as MoveDefSectionParamNode;
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

        #endregion

        #region Variables

        public CharName _character;
        internal int
            dataSize,
            lookupOffset,
            numLookupEntries,
            numDataTable,
            numExternalSubRoutine;

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

        public MoveDefDataNode _data;
        public MoveDefDataCommonNode _dataCommon;

        public MoveDefReferenceNode _references;
        public MoveDefSectionNode _sections;
        public MoveDefLookupNode _lookupNode;

        public Dictionary<int, MoveDefLookupOffsetNode> _lookupSizes;

        public MDL0Node _model = null;
        
        public VoidPtr _baseAddress;
        
        public SortedDictionary<int, MoveDefEntryNode> NodeDictionary { get { return nodeDictionary; } }
        public SortedDictionary<int, MoveDefEntryNode> nodeDictionary = new SortedDictionary<int, MoveDefEntryNode>();

        #endregion

        #region Parsing

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = _character.ToString();

            nodeDictionary = new SortedDictionary<int, MoveDefEntryNode>();

            dataSize = Header->_fileSize;
            lookupOffset = Header->_lookupOffset;
            numLookupEntries = Header->_lookupEntryCount;
            numDataTable = Header->_dataTableEntryCount;
            numExternalSubRoutine = Header->_externalSubRoutineCount;

            _baseAddress = (VoidPtr)Header + 0x20;
            return true;
        }

        public override void OnPopulate()
        {
            _subRoutines = new SortedDictionary<int, MoveDefActionNode>();
            _externalRefs = new List<ResourceNode>();
            _externalSections = new List<MoveDefExternalNode>();
            _lookupSizes = new Dictionary<int, MoveDefLookupOffsetNode>();
            _events = new Dictionary<uint, List<MoveDefEventNode>>();
            StatusIDs = new bool[0];

            //Parse references first but don't add to children yet
            if (numExternalSubRoutine > 0)
            {
                (_references = new MoveDefReferenceNode(Header->StringTable) { _parent = this }).Initialize(this, new DataSource(Header->ExternalSubRoutines, numExternalSubRoutine * 8));
                _externalRefs = _references.Children;
            }
            (_sections = new MoveDefSectionNode(Header->_fileSize, (VoidPtr)Header->StringTable)).Initialize(this, new DataSource(Header->DataTable, Header->_dataTableEntryCount * 8));
            (_lookupNode = new MoveDefLookupNode(Header->_lookupEntryCount) { _parent = this }).Initialize(this, new DataSource(Header->LookupEntries, Header->_lookupEntryCount * 4));

            //Now add to children
            if (_references != null)
                Children.Add(_references);

            MoveDefSubRoutineListNode g = new MoveDefSubRoutineListNode() { _name = "SubRoutines", _parent = this };

            _subRoutineGroup = g;
            _subRoutineList = g.Children;

            //Load subroutines
            //if (!RootNode._origPath.Contains("Test"))
            {
                _sections.Populate();
                foreach (MoveDefEntryNode p in _sections._sectionList)
                    if (p is MoveDefExternalNode && (p as MoveDefExternalNode)._refs.Count == 0)
                        _sections.Children.Add(p);
            }
            g._name = "[" + g.Children.Count + "] " + g._name;

            _children.Add(g);

            //_children.Sort(MoveDefEntryNode.Compare);

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

        #endregion

        #region Saving

        /// <summary>
        /// Returns the moveset builder of the moveset currently being written.
        /// Use only after calling CalculateSize or Rebuild.
        /// </summary>
        public static NewMovesetBuilder Builder { get { return _currentlyBuilding == null ? null : _currentlyBuilding._builder; } }
        public static MoveDefNode _currentlyBuilding = null;

        internal NewMovesetBuilder _builder;
        public override int OnCalculateSize(bool force)
        {
            _currentlyBuilding = this;
            return (_builder = new NewMovesetBuilder()).CalcSize(this);
        }
        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _currentlyBuilding = this;
            _builder.Write(this, address, length);
        }
        #endregion
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

            List<ResourceNode> nodes = new List<ResourceNode>();
            List<int> offsets = new List<int>();
            List<int> sizes = new List<int>();
            
            //Parse offsets and add them to the section list in the order they appear
            //Initialize external data now so the internal data can use it
            foreach (var data in DataTable)
            {
                if (data.Key.Name != "data" && data.Key.Name != "dataCommon" && data.Key.Name != "animParam" && data.Key.Name != "subParam")
                {
                    MoveDefRawDataNode r = new MoveDefRawDataNode(data.Key.Name) { _parent = this, offsetID = offsetID };
                    r.Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                    Root._externalSections.Add(r);
                    _sectionList.Add(r);
                }
                else
                {
                    offsets.Add(data.Value._dataOffset);
                    sizes.Add(data.Key.Size);
                    switch (data.Key.Name)
                    {
                        case "data":
                            nodes.Add((Root._data = new MoveDefDataNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }));
                            _sectionList.Add(Root._data);
                            break;
                        case "dataCommon":
                            nodes.Add((Root._dataCommon = new MoveDefDataCommonNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }));
                            _sectionList.Add(Root._dataCommon);
                            break;
                        case "animParam":
                            //nodes.Add((Root._animParam = new MoveDefAnimParamNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }));
                            //_sectionList.Add(Root._animParam);
                            break;
                        case "subParam":
                            //nodes.Add((Root._subParam = new MoveDefSubParamNode((uint)DataSize, data.Key.Name) { offsetID = offsetID }));
                            //_sectionList.Add(Root._subParam);
                            break;
                    }
                }
                offsetID++;
            }

            int i = 0;
            foreach (ResourceNode node in nodes)
            {
                node.Initialize(this, BaseAddress + offsets[i], sizes[i]);
                i++;
            }

            //SortChildren();
            //_sectionList.Sort(MoveDefEntryNode.Compare);
        }
    }

    public class SpecialOffset { public int Index; public int Offset; public int Size; public override string ToString() { return String.Format("[{2}] Offset={0} Size={1}", Offset, Size, Index); } }
}