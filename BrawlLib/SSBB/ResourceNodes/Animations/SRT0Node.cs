using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Wii.Animations;
using System.IO;
using BrawlLib.IO;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SRT0Node : BRESEntryNode
    {
        internal BRESCommonHeader* Header { get { return (BRESCommonHeader*)WorkingUncompressed.Address; } }
        internal SRT0v4* Header4 { get { return (SRT0v4*)WorkingUncompressed.Address; } }
        internal SRT0v5* Header5 { get { return (SRT0v5*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.SRT0; } }

        public int _loop, _version = 4, _numFrames = 1, _matrixMode;

        [Browsable(false)]
        public override int tFrameCount { get { return FrameCount; } set { FrameCount = value; } }
        [Browsable(false)]
        public override bool tLoop { get { return Loop; } set { Loop = value; } }

        public int ConversionBias = 0;
        public int startUpVersion = 4;

        [Category("Texture Animation Data")]
        public int Version 
        { 
            get { return _version; } 
            set 
            {
                if (_version == value)
                    return;

                if (value == startUpVersion)
                    ConversionBias = 0;
                else if (startUpVersion == 4 && value == 5)
                    ConversionBias = -1;
                else if (startUpVersion == 5 && value == 4)
                    ConversionBias = 1;

                _version = value;
                SignalPropertyChange();
            }
        }
        [Category("Texture Animation Data")]
        public bool Loop { get { return _loop != 0; } set { _loop = value ? 1 : 0; SignalPropertyChange(); } }
        [Category("Texture Animation Data")]
        public int FrameCount
        {
            get { return _numFrames + (_version == 5 ? 1 : 0); }
            set
            {
                int bias = (_version == 5 ? 1 : 0);
                if ((_numFrames == value - bias) || (value - bias < (1 - bias)))
                    return;

                _numFrames = value - bias;

                foreach (SRT0EntryNode n in Children)
                    foreach (SRT0TextureNode t in n.Children)
                        t.SetSize(FrameCount);

                SignalPropertyChange();
            }
        }
        [Category("Texture Animation Data")]
        public TexMatrixMode MatrixMode { get { return (TexMatrixMode)_matrixMode; } set { _matrixMode = (int)value; SignalPropertyChange(); } }

        [Category("User Data"), TypeConverter(typeof(ExpandableObjectCustomConverter))]
        public UserDataCollection UserEntries { get { return _userEntries; } set { _userEntries = value; SignalPropertyChange(); } }
        internal UserDataCollection _userEntries = new UserDataCollection();

        [Category("Texture Animation Data")]
        public string OriginalPath { get { return _originalPath; } set { _originalPath = value; SignalPropertyChange(); } }
        public string _originalPath;

        public void InsertKeyframe(int index)
        {
            FrameCount++;
            foreach (SRT0EntryNode e in Children)
                foreach (SRT0TextureNode c in e.Children)
                    c.Keyframes.Insert(KeyFrameMode.All, index);
        }
        public void DeleteKeyframe(int index)
        {
            foreach (SRT0EntryNode e in Children)
                foreach (SRT0TextureNode c in e.Children)
                    c.Keyframes.Delete(KeyFrameMode.All, index);
            FrameCount--;
        }
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            startUpVersion = _version = Header->_version;

            if (_version == 5)
            {
                if ((_name == null) && (Header5->_stringOffset != 0))
                    _name = Header5->ResourceString;
                _loop = Header5->_loop;
                _numFrames = Header5->_numFrames;
                _matrixMode = Header5->_matrixMode;

                if (Header5->_origPathOffset > 0)
                    _originalPath = Header5->OrigPath;

                (_userEntries = new UserDataCollection()).Read(Header5->UserData);
            }
            else
            {
                if ((_name == null) && (Header4->_stringOffset != 0))
                    _name = Header4->ResourceString;
                _loop = Header4->_loop;
                _numFrames = Header4->_numFrames;
                _matrixMode = Header5->_matrixMode;

                if (Header4->_origPathOffset > 0)
                    _originalPath = Header4->OrigPath;
            }

            return Header4->Group->_numEntries > 0;
        }

        protected override void OnPopulate()
        {
            VoidPtr addr;
            ResourceGroup* group = Header4->Group;
            for (int i = 0; i < group->_numEntries; i++)
                new SRT0EntryNode().Initialize(this, new DataSource(addr = (VoidPtr)group + group->First[i]._dataOffset, ((SRT0Entry*)addr)->DataSize()));
        }

        internal override void GetStrings(StringTable table)
        {
            table.Add(Name);
            foreach (SRT0EntryNode n in Children)
                table.Add(n.Name);

            foreach (UserDataClass s in _userEntries)
                table.Add(s._name);

            if (!String.IsNullOrEmpty(_originalPath))
                table.Add(_originalPath);
        }

        protected internal override void PostProcess(VoidPtr bresAddress, VoidPtr dataAddress, int dataLength, StringTable stringTable)
        {
            base.PostProcess(bresAddress, dataAddress, dataLength, stringTable);

            SRT0v4* header = (SRT0v4*)dataAddress;

            if (_version == 5)
            {
                ((SRT0v5*)dataAddress)->ResourceStringAddress = stringTable[Name] + 4;
                if (!String.IsNullOrEmpty(_originalPath))
                    ((SRT0v5*)dataAddress)->OrigPathAddress = stringTable[_originalPath] + 4;
            }
            else
            {
                header->ResourceStringAddress = stringTable[Name] + 4;
                if (!String.IsNullOrEmpty(_originalPath))
                    header->OrigPathAddress = stringTable[_originalPath] + 4;
            }

            ResourceGroup* group = header->Group;
            group->_first = new ResourceEntry(0xFFFF, 0, 0, 0, 0);

            ResourceEntry* rEntry = group->First;

            int index = 1;
            foreach (SRT0EntryNode n in Children)
            {
                dataAddress = (VoidPtr)group + (rEntry++)->_dataOffset;
                ResourceEntry.Build(group, index++, dataAddress, (BRESString*)stringTable[n.Name]);
                n.PostProcess(dataAddress, stringTable);
            }

            if (_version == 5) _userEntries.PostProcess(((SRT0v5*)dataAddress)->UserData, stringTable);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            ResourceGroup* group;
            if (_version == 5)
            {
                SRT0v5* header = (SRT0v5*)address;
                *header = new SRT0v5((ushort)(_numFrames + ConversionBias), _loop, (ushort)Children.Count, _matrixMode);
                group = header->Group;
            }
            else
            {
                SRT0v4* header = (SRT0v4*)address;
                *header = new SRT0v4((ushort)(_numFrames + ConversionBias), _loop, (ushort)Children.Count, _matrixMode);
                group = header->Group;
            }

            *group = new ResourceGroup(Children.Count);

            VoidPtr entryAddress = group->EndAddress;
            VoidPtr dataAddress = entryAddress;
            foreach (SRT0EntryNode n in Children)
                dataAddress += n._entryLen;

            ResourceEntry* rEntry = group->First;
            foreach (SRT0EntryNode n in Children)
            {
                (rEntry++)->_dataOffset = (int)entryAddress - (int)group;

                n._dataAddr = dataAddress;
                n.Rebuild(entryAddress, n._entryLen, true);
                entryAddress += n._entryLen;
                dataAddress += n._dataLen;
            }

            if (_userEntries.Count > 0 && _version == 5)
            {
                SRT0v5* header = (SRT0v5*)address;
                header->UserData = dataAddress;
                _userEntries.Write(dataAddress);
            }
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = (Version == 5 ? SRT0v5.Size : SRT0v4.Size) + 0x18 + Children.Count * 0x10;
            foreach (SRT0EntryNode entry in Children)
                size += entry.CalculateSize(true);
            size += _userEntries.GetSize();
            return size;
        }

        internal static ResourceNode TryParse(DataSource source) { return ((BRESCommonHeader*)source.Address)->_tag == SRT0v4.Tag ? new SRT0Node() : null; }

        internal unsafe SRT0TextureNode FindOrCreateEntry(string name, int index, bool ind)
        {
            foreach (SRT0EntryNode t in Children)
                if (t.Name == name)
                {
                    int value = 0;
                    foreach (SRT0TextureNode x in t.Children)
                        if (x._textureIndex == value && x._indirect == ind)
                            return x;

                    SRT0TextureNode child = new SRT0TextureNode(index, ind) { _numFrames = _numFrames };
                    t.AddChild(child);
                    return child;
                }
            SRT0EntryNode entry = new SRT0EntryNode();
            entry.Name = name;
            AddChild(entry);
            SRT0TextureNode tex = new SRT0TextureNode(index, ind) { _numFrames = _numFrames };
            entry.AddChild(tex);
            return tex;
        }

        public void CreateEntry()
        {
            AddChild(new SRT0EntryNode() { Name = FindName("NewMaterial") });
        }

    }

    public unsafe class SRT0EntryNode : ResourceNode
    {
        internal SRT0Entry* Header { get { return (SRT0Entry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.SRT0Entry; } }

        public int[] _usageIndices = new int[11];
        
        public TextureIndices _texIndices;
        public IndirectTextureIndices _indIndices;

        protected override bool OnInitialize()
        {
            if ((_name == null) && (Header->_stringOffset != 0))
                _name = Header->ResourceString;

            _texIndices = (TextureIndices)(int)Header->_textureIndices;
            _indIndices = (IndirectTextureIndices)(int)Header->_indirectIndices;

            for (int i = 0; i < 8; i++)
                _usageIndices[i] = ((Header->_textureIndices >> i) & 1);

            for (int i = 0; i < 3; i++)
                _usageIndices[i + 8] = ((Header->_indirectIndices >> i) & 1);

            return (int)_texIndices > 0 || (int)_indIndices > 0;
        }

        protected internal virtual void PostProcess(VoidPtr dataAddress, StringTable stringTable)
        {
            SRT0Entry* header = (SRT0Entry*)dataAddress;
            header->ResourceStringAddress = stringTable[Name] + 4;
        }

        protected override void OnPopulate()
        {
            int index = 0; VoidPtr addr;
            for (int i = 0; i < 11; i++)
                if (_usageIndices[i] == 1)
                    new SRT0TextureNode(i, i >= 8).Initialize(this, new DataSource(addr = (VoidPtr)Header->GetEntry(index++), ((SRT0TextureEntry*)addr)->Code.DataSize()));
        }

        internal int _entryLen 
        {
            get
            {
                int size = 12;
                foreach (SRT0TextureNode t in Children)
                    size += 4 + t._entryLen;
                return size;
            }
        }

        internal int _dataLen
        {
            get
            {
                int size = 0;
                foreach (SRT0TextureNode t in Children)
                    size += t._dataLen;
                return size;
            }
        }

        internal VoidPtr _dataAddr;
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            SRT0Entry* header = (SRT0Entry*)address;

            header->_textureIndices = (int)_texIndices;
            header->_indirectIndices = (int)_indIndices;

            VoidPtr entryAddress = address + 12 + (Children.Count) * 4;

            int prevOffset = 0;
            for (int i = 0; i < Children.Count; i++)
            {
                SRT0TextureNode n = (SRT0TextureNode)Children[i];

                n._dataAddr = _dataAddr;

                header->SetOffset(i, 12 + (Children.Count) * 4 + prevOffset);
                n.Rebuild(entryAddress, n._entryLen, true);

                entryAddress += n._entryLen;
                prevOffset += n._entryLen;
                _dataAddr += n._dataLen;
            }
        }

        protected override int OnCalculateSize(bool force)
        {
            _texIndices = 0;
            int size = 12;
            foreach (SRT0TextureNode n in Children)
            {
                if (n._indirect)
                    _indIndices += 1 << n._textureIndex;
                else
                    _texIndices += 1 << n._textureIndex;
                size += 4 + n.CalculateSize(true);
            }
            return size;
        }

        public void CreateEntry()
        {
            bool indirect = false;
            int value = 0;
            foreach (SRT0TextureNode t in Children)
                if (t._textureIndex == value && !t._indirect)
                    value++;
            if (value == 8)
            {
                indirect = true;
                value = 0;
                foreach (SRT0TextureNode t in Children)
                    if (t._textureIndex == value && t._indirect)
                        value++;
                if (value == 3)
                    return;
            }
            SRT0TextureNode node = new SRT0TextureNode(value, indirect) { _numFrames = ((SRT0Node)Parent).FrameCount };
            AddChild(node);
        }
    }

    public unsafe class SRT0TextureNode : ResourceNode
    {
        internal SRT0TextureEntry* Header { get { return (SRT0TextureEntry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.SRT0Texture; } }

        //[Category("SRT0 Texture Entry")]
        //public SRT0Code Flags { get { return _flags; } }
        public SRT0Code _flags;

        public bool _indirect = false;
        [Category("SRT0 Texture Entry")]
        public bool Indirect
        {
            get { return _indirect; }
            set
            {
                foreach (SRT0TextureNode t in Parent.Children)
                    if (t.Index != Index && t._textureIndex == _textureIndex && t._indirect == value)
                        return;

                _indirect = value;

                Name = (_indirect ? "Ind" : "") + "Texture" + _textureIndex;

                CheckNext();
                CheckPrev();
            }
        }
        [Category("SRT0 Texture Entry")]
        public int TextureIndex
        {
            get { return _textureIndex; }
            set
            {
                int val = _indirect ? value.Clamp(0, 2) : value.Clamp(0, 7);

                foreach (SRT0TextureNode t in Parent.Children)
                    if (t.Index != Index && t._textureIndex == val && t._indirect == _indirect)
                        return;

                _textureIndex = val;

                Name = (_indirect ? "Ind" : "") + "Texture" + _textureIndex;

                CheckNext();
                CheckPrev();
            }
        }
        public int _textureIndex;

        public SRT0TextureNode(int index, bool indirect)
        {
            _textureIndex = index; 
            _name = "Texture" + index;
            _indirect = indirect;
        }

        public void CheckNext()
        {
            if (Index == Parent.Children.Count - 1)
                return;

            int index = Index;
            if (_textureIndex > ((SRT0TextureNode)Parent.Children[Index + 1])._textureIndex || (_indirect == true && ((SRT0TextureNode)Parent.Children[Index + 1])._indirect == false))
            {
                doMoveDown();
                if (index != Index)
                    CheckNext();
            }
        }

        public void CheckPrev()
        {
            if (Index == 0)
                return;

            int index = Index;
            if (_textureIndex < ((SRT0TextureNode)Parent.Children[Index - 1])._textureIndex || (_indirect == false && ((SRT0TextureNode)Parent.Children[Index - 1])._indirect == true))
            {
                doMoveUp();
                if (index != Index)
                    CheckPrev();
            }
        }

        internal void SetSize(int count)
        {
            _numFrames = count;

            if (_keyframes != null)
                Keyframes.FrameLimit = FrameCount;

            SignalPropertyChange();
        }

        internal int _numFrames;
        [Browsable(false)]
        public int FrameCount { get { return _numFrames; } }

        internal KeyframeCollection _keyframes;
        [Browsable(false)]
        public KeyframeCollection Keyframes
        {
            get
            {
                if (_keyframes == null)
                {
                    if (Header != null)
                        _keyframes = AnimationConverter.DecodeSRT0Keyframes(Header, FrameCount);
                    else
                        _keyframes = new KeyframeCollection(FrameCount);
                }
                return _keyframes;
            }
        }

        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = (_indirect ? "Ind" : "") + "Texture" + _textureIndex;

            _flags = Header->Code;

            _keyframes = null;

            if (_parent is SRT0EntryNode && _parent._parent is SRT0Node)
                _numFrames = ((SRT0Node)_parent._parent).FrameCount;

            return false;
        }

        internal int _dataLen;
        internal int _entryLen;
        internal VoidPtr _dataAddr;
        protected override int OnCalculateSize(bool force)
        {
            _dataLen = AnimationConverter.CalculateSRT0Size(Keyframes, out _entryLen);
            return _dataLen + _entryLen;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            AnimationConverter.EncodeSRT0Keyframes(_keyframes, address, _dataAddr);
        }

        public override unsafe void Export(string outPath)
        {
            int dataLen = OnCalculateSize(true);
            using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
            {
                stream.SetLength(dataLen);
                using (FileMap map = FileMap.FromStream(stream))
                    AnimationConverter.EncodeSRT0Keyframes(Keyframes, map.Address, map.Address + _entryLen);
            }
        }

        #region Keyframe Management

        public KeyframeEntry GetKeyframe(KeyFrameMode mode, int index) { return Keyframes.GetKeyframe(mode, index); }
        public void SetKeyframe(KeyFrameMode mode, int index, float value)
        {
            KeyframeEntry k = Keyframes.SetFrameValue(mode, index, value);
            k.GenerateTangent();
            k._prev.GenerateTangent();
            k._next.GenerateTangent();

            SignalPropertyChange();
        }
        public void SetKeyframe(int index, AnimationFrame frame)
        {
            float* v = (float*)&frame;
            for (int i = 0x10; i < 0x19; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyTrans(int index, AnimationFrame frame)
        {
            float* v = (float*)&frame.Translation;
            for (int i = 0x16; i < 0x19; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyRot(int index, AnimationFrame frame)
        {
            float* v = (float*)&frame.Rotation;
            for (int i = 0x13; i < 0x16; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyScale(int index, AnimationFrame frame)
        {
            float* v = (float*)&frame.Scale;
            for (int i = 0x10; i < 0x13; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyTrans(int index, Vector3 trans)
        {
            float* v = (float*)&trans;
            for (int i = 0x16; i < 0x19; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyRot(int index, Vector3 rot)
        {
            float* v = (float*)&rot;
            for (int i = 0x13; i < 0x16; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void SetKeyframeOnlyScale(int index, Vector3 scale)
        {
            float* v = (float*)&scale;
            for (int i = 0x10; i < 0x13; i++)
                SetKeyframe((KeyFrameMode)i, index, *v++);
        }

        public void RemoveKeyframe(KeyFrameMode mode, int index)
        {
            KeyframeEntry k = Keyframes.Remove(mode, index);
            if (k != null)
            {
                k._prev.GenerateTangent();
                k._next.GenerateTangent();
                SignalPropertyChange();
            }
        }

        public void RemoveKeyframe(int index)
        {
            for (int i = 0x10; i < 0x19; i++)
                RemoveKeyframe((KeyFrameMode)i, index);
        }

        public void RemoveKeyframeOnlyTrans(int index)
        {
            for (int i = 0x16; i < 0x19; i++)
                RemoveKeyframe((KeyFrameMode)i, index);
        }

        public void RemoveKeyframeOnlyRot(int index)
        {
            for (int i = 0x13; i < 0x16; i++)
                RemoveKeyframe((KeyFrameMode)i, index);
        }

        public void RemoveKeyframeOnlyScale(int index)
        {
            for (int i = 0x10; i < 0x13; i++)
                RemoveKeyframe((KeyFrameMode)i, index);
        }

        public AnimationFrame GetAnimFrame(int index)
        {
            return Keyframes.GetFullFrame(index);
        }

        #endregion
    }

    public class SRT0FrameEntry
    {
        public float _index, _value, _tangent;

        public static implicit operator SRT0FrameEntry(I12Entry v) { return new SRT0FrameEntry(v._index, v._value, v._tangent); }
        public static implicit operator I12Entry(SRT0FrameEntry v) { return new I12Entry(v._index, v._value, v._tangent); }

        public static implicit operator SRT0FrameEntry(Vector3 v) { return new SRT0FrameEntry(v._x, v._y, v._z); }
        public static implicit operator Vector3(SRT0FrameEntry v) { return new Vector3(v._index, v._value, v._tangent); }

        public SRT0FrameEntry(float x, float y, float z) { _index = x; _value = y; _tangent = z; }
        public SRT0FrameEntry() { }

        public float Index { get { return _index; } set { _index = value; } }
        public float Value { get { return _value; } set { _value = value; } }
        public float Tangent { get { return _tangent; } set { _tangent = value; } }

        public override string ToString()
        {
            return String.Format("Index={0}, Value={1}, Tangent={2}", _index, _value, _tangent);
        }
    }
}
