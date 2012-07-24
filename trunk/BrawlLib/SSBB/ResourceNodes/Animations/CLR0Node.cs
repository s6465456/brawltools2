using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class CLR0Node : BRESEntryNode
    {
        internal BRESCommonHeader* Header { get { return (BRESCommonHeader*)WorkingUncompressed.Address; } }
        internal CLR0v3* Header3 { get { return (CLR0v3*)WorkingUncompressed.Address; } }
        internal CLR0v4* Header4 { get { return (CLR0v4*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.CLR0; } }

        internal int _numFrames = 1, _origPathOffset, _loop, _version = 3;

        [Category("CLR0")]
        public int Version { get { return _version; } set { _version = value; SignalPropertyChange(); } }
        [Category("CLR0")]
        public uint FrameCount
        {
            get { return (uint)_numFrames; }
            set
            {
                _numFrames = (int)value;
                foreach (CLR0MaterialNode n in Children)
                    foreach (CLR0MaterialEntryNode e in n.Children)
                        e.NumEntries = _numFrames + 1;
                SignalPropertyChange();
            }
        }

        [Category("CLR0")]
        public bool Loop { get { return _loop != 0; } set { _loop = value ? 1 : 0; SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _version = Header->_version;
            if (_version == 4)
            {
                _numFrames = Header4->_frames;
                _origPathOffset = Header4->_origPathOffset;
                _loop = Header4->_loop;

                if ((_name == null) && (Header4->_stringOffset != 0))
                    _name = Header4->ResourceString;

                return Header4->Group->_numEntries > 0;
            }
            else
            {
                _numFrames = Header3->_frames;
                _origPathOffset = Header3->_origPathOffset;
                _loop = Header3->_loop;

                if ((_name == null) && (Header3->_stringOffset != 0))
                    _name = Header3->ResourceString;

                return Header3->Group->_numEntries > 0;
            }
        }

        public CLR0MaterialNode CreateEntry()
        {
            CLR0MaterialNode node = new CLR0MaterialNode();
            CLR0MaterialEntryNode entry = new CLR0MaterialEntryNode();
            entry._target = EntryTarget.Color0;
            entry._name = entry._target.ToString();
            entry._numEntries = -1;
            entry.NumEntries = _numFrames + 1;
            node.Name = this.FindName(null);
            this.AddChild(node);
            node.AddChild(entry);
            return node;
        }

        protected override int OnCalculateSize(bool force)
        {
            int size = (_version == 4 ? CLR0v4.Size : CLR0v3.Size) + 0x18 + Children.Count * 0x10;
            foreach (CLR0MaterialNode n in Children)
            {
                size += 8 + n.Children.Count * 8;
                foreach (CLR0MaterialEntryNode e in n.Children)
                    if (e._numEntries != 0)
                        size += (e._colors.Count * 4);
            }
            return size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            int count = Children.Count;

            CLR0Material* pMat = (CLR0Material*)(address + (_version == 4 ? CLR0v4.Size : CLR0v3.Size) + 0x18 + (count * 0x10));

            int offset = Children.Count * 8;
            foreach (CLR0MaterialNode n in Children)
                offset += n.Children.Count * 8;

            ABGRPixel* pData = (ABGRPixel*)((VoidPtr)pMat + offset);

            ResourceGroup* group;
            if (_version == 4)
            {
                CLR0v4* header = (CLR0v4*)address;
                *header = new CLR0v4(length, _numFrames, count, _loop);

                group = header->Group;
            }
            else
            {
                CLR0v3* header = (CLR0v3*)address;
                *header = new CLR0v3(length, _numFrames, count, _loop);

                group = header->Group;
            }
            *group = new ResourceGroup(count);

            ResourceEntry* entry = group->First;
            foreach (CLR0MaterialNode n in Children)
            {
                (entry++)->_dataOffset = (int)pMat - (int)group;

                uint newFlags = 0;

                CLR0MaterialEntry* pMatEntry = (CLR0MaterialEntry*)((VoidPtr)pMat + 8);
                foreach (CLR0MaterialEntryNode e in n.Children)
                {
                    newFlags |= ((uint)((1 + (e._constant ? 2 : 0)) & 3) << ((int)e._target * 2));
                    if (e._numEntries == 0)
                        *pMatEntry = new CLR0MaterialEntry((ABGRPixel)e._colorMask, (ABGRPixel)e._solidColor);
                    else
                    {
                        *pMatEntry = new CLR0MaterialEntry((ABGRPixel)e._colorMask, (int)pData - (int)((VoidPtr)pMatEntry + 4));
                        foreach (ARGBPixel p in e._colors)
                            *pData++ = (ABGRPixel)p;
                    }
                    pMatEntry++;
                    e._changed = false;
                }
                pMat->_flags = newFlags;
                pMat = (CLR0Material*)pMatEntry;
                n._changed = false;
            }
        }

        protected override void OnPopulate()
        {
            ResourceGroup* group = Header3->Group;
            for (int i = 0; i < group->_numEntries; i++)
                new CLR0MaterialNode().Initialize(this, new DataSource(group->First[i].DataAddress, 8));
        }

        internal override void GetStrings(StringTable table)
        {
            table.Add(Name);
            foreach (CLR0MaterialNode n in Children)
                table.Add(n.Name);
        }

        protected internal override void PostProcess(VoidPtr bresAddress, VoidPtr dataAddress, int dataLength, StringTable stringTable)
        {
            base.PostProcess(bresAddress, dataAddress, dataLength, stringTable);

            CLR0v3* header = (CLR0v3*)dataAddress;
            if (_version == 4)
                ((CLR0v4*)header)->ResourceStringAddress = stringTable[Name] + 4;
            else
                header->ResourceStringAddress = stringTable[Name] + 4;

            ResourceGroup* group = header->Group;
            group->_first = new ResourceEntry(0xFFFF, 0, 0, 0, 0);
            ResourceEntry* rEntry = group->First;

            int index = 1;
            foreach (CLR0MaterialNode n in Children)
            {
                dataAddress = (VoidPtr)group + (rEntry++)->_dataOffset;
                ResourceEntry.Build(group, index++, dataAddress, (BRESString*)stringTable[n.Name]);
                n.PostProcess(dataAddress, stringTable);
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((CLR0v3*)source.Address)->_header._tag == CLR0v3.Tag ? new CLR0Node() : null; }

    }

    public unsafe class CLR0MaterialNode : ResourceNode
    {
        internal CLR0Material* Header { get { return (CLR0Material*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.CLR0Material; } }

        internal CLR0EntryFlags _flags;

        public List<int> _entries;

        protected override bool OnInitialize()
        {
            if ((_name == null) && (Header->_stringOffset != 0))
                _name = Header->ResourceString;

            _flags = Header->Flags;
            _entries = new List<int>();

            for (int i = 0; i < 11; i++)
            {
                EntryFlag flag = (EntryFlag)((uint)_flags >> i * 2);
                if (((uint)flag & 1) != 0)
                    _entries.Add(i);
            }

            return _entries.Count > 0;
        }

        protected override void OnPopulate()
        {
            for (int i = 0; i < _entries.Count; i++)
                new CLR0MaterialEntryNode() { _target = (EntryTarget)_entries[i], _constant = ((((uint)_flags >> _entries[i] * 2) & 2) == 2) }.Initialize(this, (VoidPtr)Header + 8 + i * 8, 8);
        }

        protected internal virtual void PostProcess(VoidPtr dataAddress, StringTable stringTable)
        {
            CLR0Material* header = (CLR0Material*)dataAddress;
            header->ResourceStringAddress = stringTable[Name] + 4;
        }

        public void CreateEntry()
        {
            int value = 0; Top:
            foreach (CLR0MaterialEntryNode t in Children)
                if ((int)t._target == value) { value++; goto Top; }
            if (value >= 11)
                return;

            CLR0MaterialEntryNode entry = new CLR0MaterialEntryNode();
            entry._target = (EntryTarget)value;
            entry._name = entry._target.ToString();
            entry._numEntries = -1;
            entry.NumEntries = ((CLR0Node)Parent)._numFrames + 1;
            AddChild(entry);
        }
    }

    public unsafe class CLR0MaterialEntryNode : ResourceNode, IColorSource
    {
        internal CLR0MaterialEntry* Header { get { return (CLR0MaterialEntry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.CLR0MaterialEntry; } }

        public bool _constant = false;
        [Category("CLR0 Material Entry")]
        public bool Constant 
        {
            get { return _constant; } 
            set 
            {
                if (_constant != value)
                {
                    _constant = value;
                    if (_constant)
                        MakeSolid(new ARGBPixel());
                    else
                        MakeList();
                }
            } 
        }
        internal EntryTarget _target;
        [Category("CLR0 Material Entry")]
        public EntryTarget Target 
        {
            get { return _target; } 
            set 
            {
                foreach (CLR0MaterialEntryNode t in Parent.Children)
                    if (t._target == value) return;

                _target = value;
                Name = _target.ToString();
                SignalPropertyChange(); 
            }
        }

        internal ARGBPixel _colorMask;
        [Browsable(false)]
        public ARGBPixel ColorMask { get { return _colorMask; } set { _colorMask = value; SignalPropertyChange(); } }

        internal List<ARGBPixel> _colors = new List<ARGBPixel>();
        [Browsable(false)]
        public List<ARGBPixel> Colors { get { return _colors; } set { _colors = value; SignalPropertyChange(); } }

        internal ARGBPixel _solidColor;
        [Browsable(false)]
        public ARGBPixel SolidColor { get { return _solidColor; } set { _solidColor = value; SignalPropertyChange(); } }

        internal int _numEntries;
        [Browsable(false)]
        internal int NumEntries
        {
            get { return _numEntries; }
            set
            {
                if (_numEntries == 0)
                    return;

                if (value > _numEntries)
                {
                    ARGBPixel p = _numEntries > 0 ? _colors[_numEntries - 1] : new ARGBPixel(255, 0, 0, 0);
                    for (int i = value - _numEntries; i-- > 0; )
                        _colors.Add(p);
                }
                else if (value < _colors.Count)
                    _colors.RemoveRange(value, _colors.Count - value);

                _numEntries = value;
            }
        }

        protected override bool OnInitialize()
        {
            _colorMask = (ARGBPixel)Header->_colorMask;

            _colors.Clear();
            if (_constant)
            {
                _numEntries = 0;
                _solidColor = (ARGBPixel)Header->SolidColor;
            }
            else
            {
                _numEntries = ((CLR0Node)_parent._parent)._numFrames + 1;
                ABGRPixel* data = Header->Data;
                for (int i = 0; i < _numEntries; i++)
                    _colors.Add((ARGBPixel)(*data++));
            }

            _name = _target.ToString();

            return false;
        }

        public void MakeSolid(ARGBPixel color)
        {
            _numEntries = 0;
            _constant = true;
            _solidColor = color;
            SignalPropertyChange();
        }
        public void MakeList()
        {
            _constant = false;
            int entries = ((CLR0Node)_parent._parent)._numFrames + 1;
            _numEntries = _colors.Count;
            NumEntries = entries;
        }

        protected internal virtual void PostProcess(VoidPtr dataAddress, StringTable stringTable)
        {
            CLR0Material* header = (CLR0Material*)dataAddress;
            header->ResourceStringAddress = stringTable[Name] + 4;
        }

        #region IColorSource Members

        [Browsable(false)]
        public bool HasPrimary { get { return true; } }
        [Browsable(false)]
        public ARGBPixel PrimaryColor
        {
            get { return _colorMask; }
            set { _colorMask = value; SignalPropertyChange(); }
        }
        [Browsable(false)]
        public string PrimaryColorName { get { return "Mask:"; } }
        [Browsable(false)]
        public int ColorCount { get { return (_numEntries == 0) ? 1 : _numEntries; } }
        public ARGBPixel GetColor(int index) { return (_numEntries == 0) ? _solidColor : _colors[index]; }
        public void SetColor(int index, ARGBPixel color)
        {
            if (_numEntries == 0)
                _solidColor = color;
            else
                _colors[index] = color;
            SignalPropertyChange();
        }

        #endregion
    }
}
