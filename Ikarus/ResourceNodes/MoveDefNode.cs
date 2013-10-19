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
    public unsafe class MoveDefEntry
    {
        //Properties
        [Browsable(false)]
        public VoidPtr RebuildBase { get { return MoveDefNode.Builder == null ? null : MoveDefNode.Builder._rebuildBase; } }
        [Browsable(false)]
        public int RebuildOffset { get { return _rebuildAddr == null || RebuildBase == null || _rebuildAddr < RebuildBase ? -1 : (int)_rebuildAddr - (int)RebuildBase; } }
        [Browsable(false)]
        public VoidPtr BaseAddress { get { return _root.BaseAddress; } }
        [Browsable(false)]
        public MDL0Node Model { get { return _root._model; } }
        public MoveDefNode _root;
        [Browsable(false)]
        public bool External { get { return _externalEntry != null; } }

        //Variables
        public int _size;
        public string _name;
        public int _offset;
        public ExternalEntry _externalEntry = null;
        public int _offsetID = 0;
        public VoidPtr _rebuildAddr = null;
        public int _entryLength = 0, _childLength = 0;
        public int _lookupCount = 0;
        public List<VoidPtr> _lookupOffsets = new List<VoidPtr>();

        //Functions
        public void SignalRebuildChange() { _root._rebuildNeeded = true; }
        public void SignalPropertyChange() 
        {
            if (!_root._propertyChangedEntries.Contains(this))
                _root._propertyChangedEntries.Add(this); 
        }
        public int GetOffset(VoidPtr address) { return (int)(address - BaseAddress); }
        public int GetSize(int offset) { return _root.GetSize(offset); }
        public static T Parse<T>(MoveDefNode node, int offset) where T : MoveDefEntry
        {
            T n = Activator.CreateInstance(typeof(T)) as T;
            n.Setup(node, offset);
            n.Parse(node.BaseAddress + offset);
            return n;
        }
        private void Setup(MoveDefNode node, int offset)
        {
            _root = node;
            _offset = offset;
            _size = node.GetSize(offset);
            if ((_externalEntry = _root.TryGetExternal(offset)) != null)
                if (_externalEntry is SectionEntry)
                {
                    if (((SectionEntry)_externalEntry).Reference != null) 
                        Console.WriteLine("wat");

                    ((SectionEntry)_externalEntry).Reference = this;
                }
                else
                    ((ReferenceEntry)_externalEntry).References.Add(this);
        }
        public void Write(int offset) { Write(_root.BaseAddress + offset); }

        //Overridable functions
        private virtual void Parse(VoidPtr address) { }
        private virtual int Write(VoidPtr address) { return 0; }
        public virtual int GetSize() { return 0; }
        public virtual void PostProcess(LookupManager lookupOffsets) { }
    }

    public unsafe class ExternalEntry : MoveDefEntry
    {
        protected List<int> _dataOffsets = new List<int>();
        protected List<MoveDefEntry> _references = new List<MoveDefEntry>();
    }

    /// <summary>
    /// Stores offsets to various entries that run a specific external subroutine.
    /// </summary>
    public unsafe class ReferenceEntry : ExternalEntry
    {
        public List<int> DataOffsets { get { return _dataOffsets; } set { _dataOffsets = value; } }
        public List<MoveDefEntry> References { get { return _references; } set { _references = value; } }

        public override void Parse(VoidPtr address)
        {
            _dataOffsets = new List<int>();
            _dataOffsets.Add(_offset);
            int offset = *(bint*)address;
            while (offset > 0)
            {
                _dataOffsets.Add(offset);
                offset = *(bint*)(BaseAddress + offset);

                //Infinite loops are NO GOOD
                if (_dataOffsets.Contains(offset))
                    break;
            }
        }
    }

    /// <summary>
    /// Stores an offset to an important entry
    /// </summary>
    public unsafe class SectionEntry : ExternalEntry
    {
        public int DataOffset { get { return _dataOffsets.Count == 0 ? 0 : _dataOffsets[0]; } set { if (_dataOffsets.Count != 0) _dataOffsets[0] = value; } }
        public MoveDefEntry Reference { get { return _references.Count == 0 ? null : _references[0]; } set { if (_references.Count != 0) _references[0] = value; } }

        public override void Parse(VoidPtr address)
        {
            _dataOffsets = new List<int>();
            _dataOffsets.Add(_offset);
            _references.Add(null);
        }
    }

    public unsafe class MoveDefNode
    {
        public MoveDefNode(CharName character) { _character = character; }

        #region Stuff to get other stuff
        
        public int GetSize(int offset)
        {
            if (_lookupSizes.ContainsKey(offset))
                return _lookupSizes[offset].DataSize;
            return -1;
        }

        public ExternalEntry TryGetExternal(int offset)
        {
            foreach (ReferenceEntry e in _referenceList)
                foreach (int i in e.DataOffsets)
                    if (i == offset)
                        return e;
            foreach (SectionEntry e in _sectionList)
                if (e.DataOffset == offset)
                    return e;
            return null;
        }

        public MoveDefEntry GetEntry(int offset)
        {
            if (_entryCache.ContainsKey(offset))
                return _entryCache[offset];
            return null;
        }

        public enum ListValue
        {
            Actions = 0,
            SubActions = 1,
            SubRoutines = 2,
            References = 3,
            Null = 4,
            FlashOverlays = 5,
            ScreenTints = 6
        }

        public enum TypeValue
        {
            None = -1,
            Main = 0,
            GFX = 1,
            SFX = 2,
            Other = 3,
            Entry = 0,
            Exit = 1,
        }

        public ActionScript GetAction(int offset)
        {
            if (offset < 0)
                return null;

            MoveDefEntry e = GetEntry(offset);

            if (e is ActionScript)
                return e as ActionScript;

            return null;
        }

        public ActionScript GetAction(ListValue list, TypeValue type, int index)
        {
            if ((list >= ListValue.References && _dataCommon == null) || list == ListValue.Null || index == -1)
                return null;

            switch (list)
            {
                case ListValue.Actions:
                    if ((type == TypeValue.Entry || type == TypeValue.Exit) && index >= 0 && index < _actions.Count)
                        return (ActionScript)_actions[index].GetWithType((int)type);
                    break;
                case ListValue.SubActions:
                    if (_data != null && index >= 0 && index < _data._subActions.Count)
                        return (ActionScript)_data._subActions[index].GetWithType((int)type);
                    break;
                case ListValue.SubRoutines:
                    if (index >= 0 && index < _subRoutines.Count)
                        return (ActionScript)_subRoutines[index];
                    break;
                case ListValue.FlashOverlays:
                    if (_dataCommon != null && index >= 0 && index < _dataCommon._flashOverlays.Count)
                        return (ActionScript)_dataCommon._flashOverlays[index];
                    break;
                case ListValue.ScreenTints:
                    if (_dataCommon != null && index >= 0 && index < _dataCommon._screenTints.Count)
                        return (ActionScript)_dataCommon._screenTints[index];
                    break;
            }
            return null;
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
                        RawParamList p1 = _data.warioParams8.Children[0] as RawParamList;
                        RawParamList p2 = _data.warioParams8.Children[1] as RawParamList;
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
                        RawParamList p1 = _data.warioParams8.Children[0] as RawParamList;
                        RawParamList p2 = _data.warioParams8.Children[1] as RawParamList;
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
        public List<MoveDefEntry> _propertyChangedEntries = new List<MoveDefEntry>();
        public bool _rebuildNeeded = false;

        public List<ActionGroup> _actions = new List<ActionGroup>();
        public List<ActionScript> _subRoutines = new List<ActionScript>();

        public MoveDefDataNode _data = null;
        public MoveDefDataCommonNode _dataCommon = null;
        public MoveDefAnimParamNode _animParam = null;

        public MoveDefSectionNode _sections;

        public List<ReferenceEntry> _referenceList;
        public List<SectionEntry> _sectionList;

        public Dictionary<int, MoveDefEntry> _entryCache;

        public MoveDefLookupNode _lookupNode;

        public Dictionary<int, MoveDefLookupOffsetNode> _lookupSizes;

        public MDL0Node _model = null;

        public VoidPtr BaseAddress { get { return _source.Address + 0x20; } }
        
        #endregion

        #region Parsing

        DataSource _source;
        public void Parse(DataSource d)
        {
            _source = d;
            FDefHeader* hdr = (FDefHeader*)_source.Address;

            _subRoutines = new List<ActionScript>();
            _referenceList = new List<ReferenceEntry>();
            _sectionList = new List<SectionEntry>();
            _lookupSizes = new Dictionary<int, MoveDefLookupOffsetNode>();

            int
            dataSize = hdr->_fileSize,
            lookupOffset = hdr->_lookupOffset,
            numLookup = hdr->_lookupEntryCount,
            numSections = hdr->_dataTableEntryCount,
            numRefs = hdr->_externalSubRoutineCount;
            FDefStringTable* stringTable = hdr->StringTable;

            //Parse references
            if (numRefs > 0)
            {
                FDefStringEntry* entries = (FDefStringEntry*)hdr->ExternalSubRoutines;
                for (int i = 0; i < numRefs; i++)
                {
                    ReferenceEntry e = Parse<ReferenceEntry>(this, entries[i]._dataOffset);
                    e._name = stringTable->GetString(entries[i]._stringOffset);
                    _referenceList.Add(e);
                }
            }

            //Parse sections
            if (numSections > 0)
            {
                FDefStringEntry* entries = (FDefStringEntry*)hdr->DataTable;
                for (int i = 0; i < numSections; i++)
                {
                    string s = stringTable->GetString(entries[i]._stringOffset);
                    int off = entries[i]._dataOffset;
                    SectionEntry e = null;
                    switch (s)
                    {
                        case "data":
                            e = Parse<MoveDefDataNode>(this, off);
                            break;
                        case "dataCommon":
                            e = Parse<MoveDefDataCommonNode>(this, off);
                            break;
                        case "animParam":
                            e = Parse<MoveDefRawDataNode>(this, off);
                            break;
                        case "subParam":
                            e = Parse<MoveDefRawDataNode>(this, off);
                            break;
                        default:
                            e = Parse<MoveDefRawDataNode>(this, off);
                            break;
                    }

                    e._name = s;
                    _sectionList.Add(e);
                }
            }
        }

        public static T Parse<T>(MoveDefNode node, int offset) where T : MoveDefEntry
        {
            return MoveDefEntry.Parse<T>(node, offset);
        }

        public override void OnPopulate()
        {

            (_sections = new MoveDefSectionNode(Header->_fileSize, (VoidPtr)Header->StringTable)).Initialize(this, new DataSource(Header->DataTable, Header->_dataTableEntryCount * 8));
            (_lookupNode = new MoveDefLookupNode(Header->_lookupEntryCount) { _parent = this }).Initialize(this, new DataSource(Header->LookupEntries, Header->_lookupEntryCount * 4));

            //Now add to children
            if (_references != null)
                Children.Add(_references);

            MoveDefSubRoutineListNode g = new MoveDefSubRoutineListNode() { _name = "SubRoutines", _parent = this };

            _subRoutineGroup = g;
            _subRoutines = g.Children;

            //Load subroutines
            //if (!RootNode._origPath.Contains("Test"))
            {
                _sections.Populate();
                foreach (MoveDefEntry p in _sections._sectionList)
                    if (p is ReferenceEntry && (p as ReferenceEntry)._references.Count == 0)
                        _sections.Children.Add(p);
            }
            g._name = "[" + g.Children.Count + "] " + g._name;

            _children.Add(g);
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

    public unsafe class MoveDefSectionNode : MoveDefEntry
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
        public List<MoveDefEntry> _sectionList;
        public override void OnPopulate()
        {
            _sectionList = new List<MoveDefEntry>();

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
                    MoveDefRawDataNode r = new MoveDefRawDataNode(data.Key.Name) { _parent = this, _offsetID = offsetID };
                    r.Initialize(this, new DataSource(BaseAddress + data.Value._dataOffset, data.Key.Size));
                    _root._sectionList.Add(r);
                    _sectionList.Add(r);
                }
                else
                {
                    offsets.Add(data.Value._dataOffset);
                    sizes.Add(data.Key.Size);
                    switch (data.Key.Name)
                    {
                        case "data":
                            nodes.Add((_root._data = new MoveDefDataNode((uint)DataSize, data.Key.Name) { _offsetID = offsetID }));
                            _sectionList.Add(_root._data);
                            break;
                        case "dataCommon":
                            nodes.Add((_root._dataCommon = new MoveDefDataCommonNode((uint)DataSize, data.Key.Name) { _offsetID = offsetID }));
                            _sectionList.Add(_root._dataCommon);
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