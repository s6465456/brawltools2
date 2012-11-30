using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using BrawlLib.IO;
using PowerPcAssembly;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RELNode : ARCEntryNode
    {
        public static List<RELNode> _extFiles = new List<RELNode>();
        public static RELNode File(int fileId)
        {
            foreach (RELNode file in _extFiles)
                if (file._id == fileId)
                    return file;
            return null;
        }
        public RELSectionNode Section(uint address)
        {
            foreach (RELSectionNode section in Sections)
                if ((uint)section._sectionAddr <= address && address < (uint)section._sectionAddr + section.Size)
                    return section;
            return null;
        }
        public static int OfFile(uint address)
        {
            foreach (RELNode file in _extFiles)
                if (address >= (uint)file.Header && address < (uint)file.Header + file.WorkingUncompressed.Length)
                    return file.FileId;
            return -1;
        }

        internal RELHeader* Header { get { return (RELHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.REL; } }

        public RELSectionNode[] _sections;
        public RELSectionNode[] Sections { get { return _sections; } }

        public uint _id;
        public int _linkNext; //0
        public int _linkPrev; //0
        public uint _numSections;

        public uint _infoOffset;
        public uint _nameOffset;
        public uint _nameSize;
        public uint _version;

        public uint _bssSize;
        public uint _relOffset;
        public uint _impOffset;
        public uint _impSize;

        public byte _prologSection;
        public byte _epilogSection;
        public byte _unresolvedSection;
        public byte _bssSection;

        public uint _prologOffset;
        public uint _epilogOffset;
        public uint _unresolvedOffset;

        public uint _moduleAlign;
        public uint _bssAlign;
        public uint _fixSize;

        [Category("REL")]
        public uint ID { get { return _id; } }
        [Category("REL")]
        public int NextLink { get { return _linkNext; } }
        [Category("REL")]
        public int PrevLink { get { return _linkPrev; } }
        [Category("REL")]
        public uint SectionCount { get { return _numSections; } }
        
        [Category("REL")]
        public uint SectionInfoOffset { get { return _infoOffset; } }
        [Category("REL")]
        public uint NameOffset { get { return _nameOffset; } }
        [Category("REL")]
        public uint NameSize { get { return _nameSize; } }
        [Category("REL")]
        public uint Version { get { return _version; } }

        [Category("REL")]
        public uint bssSize { get { return _bssSize; } }
        [Category("REL")]
        public uint relOffset { get { return _relOffset; } }
        [Category("REL")]
        public uint impOffset { get { return _impOffset; } }
        [Category("REL")]
        public uint impSize { get { return _impSize; } }

        [Category("REL")]
        public uint prologSection { get { return _prologSection; } }
        [Category("REL")]
        public uint epilogSection { get { return _epilogSection; } }
        [Category("REL")]
        public uint unresolvedSection { get { return _unresolvedSection; } }
        [Category("REL")]
        public uint bssSection { get { return _bssSection; } }

        [Category("REL")]
        public uint prologOffset { get { return _prologOffset; } }
        [Category("REL")]
        public uint epilogOffset { get { return _epilogOffset; } }
        [Category("REL")]
        public uint unresolvedOffset { get { return _unresolvedOffset; } }

        [Category("REL")]
        public uint moduleAlign { get { return _moduleAlign; } }
        [Category("REL")]
        public uint bssAlign { get { return _bssAlign; } }
        [Category("REL")]
        public uint fixSize { get { return _fixSize; } }

        protected override bool OnInitialize()
        {
            _extFiles.Add(this);

            //_name = Header->Name;
            _name = Path.GetFileName(_origPath);

            _id = Header->_info.id;
            _linkNext = Header->_info.link._linkNext; //0
            _linkPrev = Header->_info.link._linkPrev; //0
            _numSections = Header->_info.numSections;
            _infoOffset = Header->_info.sectionInfoOffset;
            _nameOffset = Header->_info.nameOffset;
            _nameSize = Header->_info.nameSize;
            _version = Header->_info.version;

            _bssSize = Header->_bssSize;
            _relOffset = Header->_relOffset;
            _impOffset = Header->_impOffset;
            _impSize = Header->_impSize;
            _prologSection = Header->_prologSection;
            _epilogSection = Header->_epilogSection;
            _unresolvedSection = Header->_unresolvedSection;
            _bssSection = Header->_bssSection;
            _prologOffset = Header->_prologOffset;
            _epilogOffset = Header->_epilogOffset;
            _unresolvedOffset = Header->_unresolvedOffset;

            _moduleAlign = Header->_moduleAlign;
            _bssAlign = Header->_bssAlign;
            _fixSize = Header->_fixSize;

            return true;
        }

        protected override void OnPopulate()
        {
            RELGroupNode g;
            g = new RELGroupNode() { _name = "Sections" };
            g.Parent = this;
            g = new RELGroupNode() { _name = "Imports" };
            g.Parent = this;

            _sections = new RELSectionNode[_numSections];
            for (int i = 0; i < _numSections; i++)
                //if (Header->SectionInfo[i]._size != 0)
                    (_sections[i] = new RELSectionNode()).Initialize(Children[0], &Header->SectionInfo[i], RELSection.Size);

            for (int i = 0; i < Header->ImportListCount; i++)
                new RELImportNode().Initialize(Children[1], &Header->Imports[i], RELImport.Size);

            foreach (RELSectionNode s in _sections)
            {
                if (s != null)
                {
                    foreach (RelCommand c in s._commandList)
                        if (c != null)
                            c.Execute();
                    if (s.CodeSection)
                        s._code = new ASM(s._dataBuffer.Address, s._dataBuffer.Length / 4);
                }
            }
        }
    }

    public class RELGroupNode : RELEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefNoEdit; } }
    }

    public class RELDataNode : RELEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public ASM _code;
        public PPCOpCode[] _codeList = null;
        [Browsable(false)]
        public PPCOpCode[] CodeList { get { if (_codeList == null) return _codeList = _code.ToCollection(); else return _codeList; } }

        public RelCommand[] _commandList;
        public UnsafeBuffer _dataBuffer;

        static Color clrNotRelocated = Color.FromArgb(255, 255, 255);
        static Color clrRelocated = Color.FromArgb(200, 255, 200);
        static Color clrBadRelocate = Color.FromArgb(255, 200, 200);
        public Color StatusColor(int offset)
        {
            RelCommand command = _commandList[offset];
            if (command == null) return clrNotRelocated;
            if (command.Initialized) return clrRelocated;
            return clrBadRelocate;
        }
    }

    public unsafe class RELSectionNode : RELDataNode
    {
        internal RELSection* Header { get { return (RELSection*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        [Category("REL Section")]
        public bool CodeSection { get { return Header->IsCodeSection; } }
        [Category("REL Section")]
        public int Offset { get { return Header->Offset; } }
        [Category("REL Section")]
        public uint Size { get { return Header->_size; } }

        public VoidPtr _sectionAddr;
        public bool _isDynamic = false;

        protected override bool OnInitialize()
        {
            //if (Offset == 0 && Size == 0) { Remove(); return false; }

            if (Offset == 0 && Size != 0)
            {
                _sectionAddr = System.Memory.Alloc((int)Size);
                _isDynamic = true;
            }
            else
                _sectionAddr = (VoidPtr)Root.Header + Offset;

            _name = String.Format("[{0}] ", Index);
            switch (Index)
            {
                default: _name += "Section"; break;
                case 1: _name += "Assembly"; break;
                case 2: _name += "Constructors"; break;
                case 3: _name += "Destructors"; break;
                case 4: _name += "Constants"; break;
                case 5: _name += "Objects"; break;
                case 6: _name += "BSS"; break;
            }

            _dataBuffer = new UnsafeBuffer((int)Size.RoundUp(4));
            _commandList = new RelCommand[_dataBuffer.Length / 4];

            byte* pOut = (byte*)_dataBuffer.Address;
            byte* pIn = (byte*)_sectionAddr;
            uint i = 0;
            for (; i < Size; i++)
                *pOut++ = *pIn++;
            for (; i < Size.RoundUp(4); i++)
                *pOut++ = 0;

            return Index > 1 && Index < 5;
        }

        protected override void OnPopulate()
        {
            switch (Index)
            {
                case 2:
                case 3:
                    buint* addr = (buint*)_dataBuffer.Address;
                    for (int i = 0; i < _dataBuffer.Length / 4; i++)
                        if (addr[i] > 0)
                            new RELDeConStructor() { _name = "Constructor" + i, _destruct = Index == 3 }.Initialize(this, (VoidPtr)Root.Header + addr[i], 0);
                    break;
                case 4:
                    new MoveDefSectionParamNode().Initialize(this, _dataBuffer.Address, _dataBuffer.Length);
                    break;
            }

        }

        public override unsafe void Export(string outPath)
        {
            using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
            {
                stream.SetLength(_dataBuffer.Length);
                using (FileMap map = FileMap.FromStream(stream))
                {
                    VoidPtr addr = _dataBuffer.Address;

                    byte* pIn = (byte*)addr;
                    byte* pOut = (byte*)map.Address;
                    for (int i = 0; i < _dataBuffer.Length; i++)
                        *pOut++ = *pIn++;
                }
            }
        }
    }

    public unsafe class RELImportNode : RELEntryNode
    {
        internal RELImport* Header { get { return (RELImport*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        [Category("REL Import")]
        public uint ModuleID { get { return Header->_moduleId; } }
        [Category("REL Import")]
        public uint Offset { get { return Header->_offset; } }

        public List<RELLinkNode> _cmds;
        public List<RELLinkNode> Commands { get { return _cmds; } set { _cmds = value; } }

        protected override bool OnInitialize()
        {
            _name = "Module" + ModuleID;
            _cmds = new List<RELLinkNode>();

            RELLinkNode n;
            RELSectionNode section = null;
            uint offset = 0;

            RELImport* header = Header;
            RELLink* link = (RELLink*)((VoidPtr)Root.Header + (uint)header->_offset);
            while (link->Type != RELLinkType.End)
            {
                offset += link->_prevOffset;

                if (link->Type == RELLinkType.Section)
                {
                    offset = 0;
                    section = Root.Sections[link->_section];
                }
                else
                {
                    if (section != null)
                        section._commandList[offset.RoundDown(4) / 4] = new RelCommand((int)Root._id, section.Index, offset, ModuleID, *link);
                    else
                        throw new Exception("Non-block oriented relocation command.");
                }
                (n = new RELLinkNode() { _section = section }).Initialize(null, link++, RELImport.Size);
                _cmds.Add(n);
            }
            //Add the end node
            (n = new RELLinkNode() { _section = section }).Initialize(null, link++, RELImport.Size);
            _cmds.Add(n);

            return false;
        }
    }

    public unsafe class RELLinkNode : RELEntryNode
    {
        internal RELLink* Header { get { return (RELLink*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        
        [Category("REL Link")]
        public uint PreviousOffset { get { return Header->_prevOffset; } }
        [Category("REL Link")]
        public RELLinkType Type { get { return (RELLinkType)Header->_type; } }
        [Category("REL Link")]
        public byte Section { get { return Header->_section; } }
        [Category("REL Link")]
        public uint Operand { get { return Header->_value; } }

        public RELSectionNode _section = null;

        protected override bool OnInitialize()
        {
            _name = Type.ToString();

            return false;
        }
    }

    public unsafe class RelCommand
    {
        [Category("Relocation Command Info")]
        public int BaseFileId { get { return _baseFileId; } set { _baseFileId = value; } }
        protected int _baseFileId;

        [Category("Relocation Command Info")]
        public bool Initialized { get { return _initialized; } }
        private bool _initialized = false;

        [Category("Relocation Command Info")]
        public int ExternalFileId { get { return _extFileId; } set { _extFileId = value; } }
        protected int _extFileId;

        [Category("Relocation Command Info")]
        public int ExternalSection { get { return _extSection; } set { _extSection = value; } }
        protected int _extSection;

        [Category("Relocation Command"), Browsable(true)]
        public bool IsBranchSet { get { return (_command >= 0xA && _command <= 0xD); } }

        [Browsable(false)]
        public string OperandInfo { get { return "m" + PPCFormat.Hex(_extFileId) + "[" + _extSection + "] + " + PPCFormat.Offset(Addend); } }

        protected uint _offset;
        [Category("Relocation Command")]
        public uint Offset { get { return _offset; } set { _offset = value; } }
        public int _command;
        [Category("Relocation Command")]
        public int Command { get { return _command; } set { _command = value; } }
        protected int _section;
        [Category("Relocation Command")]
        public int Section { get { return _section; } set { _section = value; } }
        protected uint _addend;
        [Category("Relocation Command")]
        public uint Addend { get { return _addend + (_initialized && _extFileId > 0 ? (uint)RELNode.File(_extFileId).Sections[_extSection].Offset : 0); } }

        public RelCommand(int fileId, int memblock, uint offset, uint refId, RELLink relData)
        {
            _baseFileId = fileId;
            _section = memblock;
            _offset = offset;
            _extFileId = (int)refId;
            _extSection = relData._section;
            _command = relData._type;
            _addend = relData._value;
            _initialized = false;
        }

        public void Execute()
        {
            if (_initialized == true) return;

            RELNode baseFile = RELNode.File(_baseFileId);
            RELNode extFile = RELNode.File(_extFileId);

            VoidPtr address = 0;
            uint param = 0;

            if (baseFile == null) 
                return;

            if (extFile == null && _extFileId > 0) 
                return;

            if (extFile == null)
                param = _addend;
            else
                param = (uint)extFile.Sections[_extSection].Offset + _addend;

            if (_section >= 0)
                address = baseFile.Sections[_section]._dataBuffer.Address + _offset;

            switch (_command)
            {
                case 0x00: //Nop
                case 0xC9:
                    break;
                case 0x01: //Write Word
                    *(buint*)address = param;
                    break;
                case 0x02: //Set Branch Offset
                    *(buint*)address &= 0xFC000003;
                    *(buint*)address |= (param & 0x03FFFFFC);
                    break;
                case 0x3: //Write Lower Half
                case 0x4:
                    *(bushort*)address = (bushort)(param & 0x0000FFFF);
                    break;
                case 0x5: //Write Upper Half
                    *(bushort*)address = (bushort)((param & 0xFFFF0000) >> 16);
                    break;
                case 0x6: //Write Upper Half + bit 1
                    *(bushort*)address = (bushort)(((param & 0xFFFF0000) >> 16) | (param & 0x1));
                    break;
                case 0x7: //Set Branch Condition Offset
                case 0x8:
                case 0x9:
                    *(buint*)address &= 0xFFFF0003;
                    *(buint*)address |= (param & 0x0000FFFC);
                    break;
                case 0xA: //Set Branch Destination
                    break;
                case 0xB: //Set Branch Condition Destination
                case 0xC:
                case 0xD:
                    break;
                default:
                    throw new Exception("Unknown Relocation Command.");
            }
            _initialized = true;
        }

        public static RelCommand RelocateOf(uint address)
        {
            RELNode file = RELNode.File(RELNode.OfFile(address));

            if (file == null) 
                return null;

            RELSectionNode block = file.Section(address);

            if (block == null) 
                return null;

            return block._commandList[((int)(address - (uint)block._sectionAddr)).RoundDown(4) / 4];
        }
    }

    public unsafe class RELDeConStructor : RELDataNode
    {
        internal buint* Header { get { return (buint*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public bool _destruct;

        protected override bool OnInitialize()
        {
            _name = String.Format("{0}{1}", _destruct ? "Destructor" : "Constructor", Index);

            RELSectionNode section = Location;
            uint relative = (uint)Header - (uint)section._sectionAddr;

            int x = 0;
            buint* addr = Header;
            while ((PPCOpCode.Disassemble(addr[x], (uint)&addr[x++])).FormName() != "blr") ;

            _commandList = new RelCommand[x];
            Array.Copy(section._commandList, relative / 4, _commandList, 0, x);

            _dataBuffer = new UnsafeBuffer(x * 4);

            byte* pOut = (byte*)_dataBuffer.Address;
            byte* pIn = (byte*)section._dataBuffer.Address + relative;
            for (int i = 0; i < _dataBuffer.Length; i++)
                *pOut++ = *pIn++;

            _code = new ASM(_dataBuffer.Address, x);

            return false;
        }

        public override unsafe void Export(string outPath)
        {
            using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
            {
                stream.SetLength(_dataBuffer.Length);
                using (FileMap map = FileMap.FromStream(stream))
                {
                    VoidPtr addr = _dataBuffer.Address;

                    byte* pIn = (byte*)addr;
                    byte* pOut = (byte*)map.Address;
                    for (int i = 0; i < _dataBuffer.Length; i++)
                        *pOut++ = *pIn++;
                }
            }
        }
    }

    public unsafe class RELEntryNode : ResourceNode
    {
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        internal VoidPtr Data { get { return WorkingUncompressed.Address; } }
        
        [Browsable(false)]
        public uint _offset { get { return Root != null ? ((uint)Data - (uint)(VoidPtr)Root.Header) : 0; } }
        public string FileOffset { get { return "0x" + _offset.ToString("X"); } }
        
        [Browsable(false)]
        public RELNode Root
        {
            get
            {
                ResourceNode n = _parent;
                while (!(n is RELNode) && (n != null))
                    n = n._parent;
                return n as RELNode;
            }
        }

        [Browsable(false)]
        public RELSectionNode Location
        {
            get
            {
                List<ResourceNode> list = Root.Children[0].Children;
                foreach (RELSectionNode s in list)
                    if (s._offset <= _offset && s._offset + s.Size > _offset)
                        return s;
                return null;
            }
        }
    }
}
