using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using BrawlLib.IO;
using System.PowerPcAssembly;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    //Credit to PhantomWings for researching RELs and coding Module Editors 1, 2 & 3
    public unsafe class RELNode : ARCEntryNode, ModuleNode
    {
        internal RELHeader* Header { get { return (RELHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.REL; } }

        public static Dictionary<int, string> _idNames = new Dictionary<int, string>();

        static RELNode()
        {
            string loc = Application.StartupPath + "/REL ID List.txt";
            if (File.Exists(loc))
                using (StreamReader sr = new StreamReader(loc))
                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        string s = sr.ReadLine();
                        string[] sp = s.Split(' ');
                        if (sp.Length < 2 || String.IsNullOrEmpty(sp[1]))
                            continue;
                        int x;
                        if (int.TryParse(sp[0], out x))
                            _idNames[x] = sp[1];
                    }
        }

        [Browsable(false)]
        public ModuleSectionNode[] Sections { get { return _sections; } }
        public ModuleSectionNode[] _sections;

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

        public uint _moduleAlign = 32;
        public uint _bssAlign = 8;
        public uint _fixSize;

        [Browsable(false)]
        public new bool IsDirty { get { return base.IsDirty || (AppliedModule != null && AppliedModule.HasChanged); } set { base.IsDirty = value; } }

        [Browsable(true)]
        public RELNode AppliedModule { get { return _appliedModule; } }
        private RELNode _appliedModule = null;

        [Category("Relocatable Module")]
        public uint ModuleID { get { return ID; } set { if (value > 0) { ID = value; SignalPropertyChange(); } } }
        [Browsable(false)]
        public new uint ID { get { return _id; } set { _id = value; } }
        
        //[Category("REL")]
        //public int NextLink { get { return _linkNext; } }
        //[Category("REL")]
        //public int PrevLink { get { return _linkPrev; } }
        //[Category("REL")]
        //public uint SectionCount { get { return _numSections; } }
        
        //[Category("REL")]
        //public uint SectionInfoOffset { get { return _infoOffset; } }
        //[Category("REL")]
        //public uint NameOffset { get { return _nameOffset; } }
        //[Category("REL")]
        //public uint NameSize { get { return _nameSize; } }
        [Category("Relocatable Module")]
        public uint Version { get { return _version; } }

        //[Category("REL")]
        //public uint BSSSize { get { return _bssSize; } }
        //[Category("REL")]
        //public uint RelOffset { get { return _relOffset; } }
        //[Category("REL")]
        //public uint ImpOffset { get { return _impOffset; } }
        //[Category("REL")]
        //public uint ImpSize { get { return _impSize; } }

        //[Category("REL")]
        //public uint PrologSection { get { return _prologSection; } }
        //[Category("REL")]
        //public uint EpilogSection { get { return _epilogSection; } }
        //[Category("REL")]
        //public uint UnresolvedSection { get { return _unresolvedSection; } }
        //[Category("REL")]
        //public uint BSSSection { get { return _bssSection; } }

        //[Category("REL")]
        //public uint PrologOffset { get { return _prologOffset; } }
        //[Category("REL")]
        //public uint EpilogOffset { get { return _epilogOffset; } }
        //[Category("REL")]
        //public uint UnresolvedOffset { get { return _unresolvedOffset; } }

        //[Category("REL")]
        //public uint ModuleAlign { get { return _moduleAlign; } }
        //[Category("REL")]
        //public uint BSSAlign { get { return _bssAlign; } }
        //[Category("REL")]
        //public uint FixSize { get { return _fixSize; } }

        public Relocation
            _prologReloc = null,
            _epilogReloc = null,
            _unresReloc = null;

        public override bool OnInitialize()
        {
            _files.Add(this);

            _name = Path.GetFileName(_origPath);

            _id = Header->_info._id;
            _linkNext = Header->_info._link._linkNext; //0
            _linkPrev = Header->_info._link._linkPrev; //0
            _numSections = Header->_info._numSections;
            _infoOffset = Header->_info._sectionInfoOffset;
            _nameOffset = Header->_info._nameOffset;
            _nameSize = Header->_info._nameSize;
            _version = Header->_info._version;

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
            _fixSize = Header->_commandOffset;

            return true;
        }

        public override void OnPopulate()
        {
            RELGroupNode g;
            (g = new RELGroupNode() { _name = "Sections" }).Parent = this;
            (g = new RELGroupNode() { _name = "Imports" }).Parent = this;

            _sections = new ModuleSectionNode[_numSections];
            for (int i = 0; i < _numSections; i++)
            {
                RELSectionEntry entry = Header->SectionInfo[i];
                ModuleSectionNode section = _sections[i] = new ModuleSectionNode();

                section._isCodeSection = entry.IsCodeSection;
                section._dataOffset = entry.Offset;
                section._dataSize = entry._size;

                section.Initialize(Children[0], WorkingUncompressed.Address + Header->SectionInfo[i].Offset, (int)Header->SectionInfo[i]._size);
            }

            for (int i = 0; i < Header->ImportListCount; i++)
                new RELImportNode().Initialize(Children[1], &Header->Imports[i], RELImportEntry.Size);

            ApplyRelocations();
        }

        public bool ApplyRelocations() { return ApplyRelocations(this); }
        public bool ApplyRelocations(RELNode n)
        {
            if (_appliedModule == n)
                return false;

            if (_appliedModule != null && _appliedModule.IsDirty && _appliedModule != this)
            {
                if (MessageBox.Show(RootNode._mainForm, "You have made changes to the externally applied module. Save changes?", "Save External Module?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    _appliedModule.Merge();
                    _appliedModule.Export(_appliedModule._origPath);
                    _appliedModule.IsDirty = false;
                }
            }
            if (n != null)
            {
                foreach (RELImportNode r in n.Children[1].Children)
                    if (r.ModuleID == ModuleID)
                    {
                        RELNode temp = _appliedModule;
                        _appliedModule = n;
                        if (r.ApplyRelocationsTo(this))
                        {
                            if (temp != null)
                                temp.Dispose();

                            ModuleDataNode s;
                            int offset;

                            if (_prologReloc == null)
                            {
                                s = _sections[Header->_prologSection];
                                offset = (int)Header->_prologOffset - (int)s._offset;
                            }
                            else
                            {
                                s = _prologReloc._section;
                                offset = _prologReloc._index * 4;
                            }
                            _prologReloc = s.GetRelocationAtOffset(offset);
                            if (_prologReloc != null)
                                _prologReloc._prolog = true;

                            if (_epilogReloc == null)
                            {
                                s = _sections[Header->_epilogSection];
                                offset = (int)Header->_epilogOffset - (int)s._offset;
                            }
                            else
                            {
                                s = _epilogReloc._section;
                                offset = _epilogReloc._index * 4;
                            }
                            _epilogReloc = s.GetRelocationAtOffset(offset);
                            if (_epilogReloc != null)
                                _epilogReloc._epilog = true;

                            if (_unresReloc == null)
                            {
                                s = _sections[Header->_unresolvedSection];
                                offset = (int)Header->_unresolvedOffset - (int)s._offset;
                            }
                            else
                            {
                                s = _unresReloc._section;
                                offset = _unresReloc._index * 4;
                            }
                            _unresReloc = s.GetRelocationAtOffset(offset);
                            if (_unresReloc != null)
                                _unresReloc._unresolved = true;

                            return true;
                        }
                        else
                            _appliedModule = temp;
                    }
            }
            else
            {
                foreach (ModuleSectionNode s in Sections)
                    s.ClearCommands();

                _appliedModule = n;
            }
            return false;
        }
        
        public override int OnCalculateSize(bool force)
        {
            int size = RELHeader.Size + Children[0].Children.Count * RELSectionEntry.Size + Children[1].Children.Count * RELImportEntry.Size;
            foreach (ModuleSectionNode s in Children[0].Children)
            {
                if (s.Index > 3)
                    size = size.Align(0x20);
                int r = s.CalculateSize(true);
                if (!s._isBSSSection)
                    size += r;
            }

            if (AppliedModule != null && AppliedModule != this)
                foreach (RELImportNode s in AppliedModule.Children[1].Children)
                    if (s.ModuleID == ModuleID)
                        s.GenerateCommandList(this);

            foreach (RELImportNode s in Children[1].Children)
            {
                if (AppliedModule == this && s.ModuleID == ModuleID)
                    s.GenerateCommandList(this);

                size += s.CalculateSize(true);
            }
            
            return size - 8;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            RELHeader* header = (RELHeader*)address;

            header->_info._id = _id;
            header->_info._link._linkNext = 0;
            header->_info._link._linkPrev = 0;
            header->_info._numSections = (uint)Children[0].Children.Count;
            header->_info._sectionInfoOffset = RELHeader.Size;
            header->_info._nameOffset = 0;
            header->_info._nameSize = 0;
            header->_info._version = _version;

            header->_moduleAlign = 0x20;
            header->_bssAlign = 0x8;
            header->_commandOffset = 0;

            bool bssFound = false;
            RELSectionEntry* sections = (RELSectionEntry*)(address + RELHeader.Size);
            VoidPtr dataAddr = address + RELHeader.Size + Children[0].Children.Count * RELSectionEntry.Size;
            foreach (ModuleSectionNode s in Children[0].Children)
                if (s._dataBuffer.Length != 0)
                {
                    int i = s.Index;

                    if (i > 3)
                    {
                        int off = (int)(dataAddr - address);
                        int aligned = off.Align(0x20);
                        int diff = aligned - off;
                        dataAddr += diff;
                    }

                    if (!s._isBSSSection)
                    {
                        sections[i]._offset = (uint)(dataAddr - address);
                        sections[i].IsCodeSection = s.HasCode;

                        s.Rebuild(dataAddr, s._calcSize, true);
                        dataAddr += s._calcSize;
                    }
                    else
                    {
                        sections[i]._offset = 0;
                        header->_bssSize = (uint)s._calcSize;
                        header->_bssSection = 0;
                        bssFound = true;
                    }
                    sections[i]._size = (uint)s._calcSize;
                }

            if (!bssFound)
            {
                header->_bssSize = 0;
                header->_bssSection = 0;
            }

            if (_prologReloc != null)
            {
                header->_prologSection = (byte)_prologReloc._section.Index;
                header->_prologOffset = (uint)sections[_prologReloc._section.Index].Offset + (uint)_prologReloc._index * 4;
            }
            else
            {
                header->_prologOffset = 0;
                header->_prologSection = 0;
            }

            if (_epilogReloc != null)
            {
                header->_epilogSection = (byte)_epilogReloc._section.Index;
                header->_epilogOffset = (uint)sections[_epilogReloc._section.Index].Offset + (uint)_epilogReloc._index * 4;
            }
            else
            {
                header->_epilogSection = 0;
                header->_epilogOffset = 0;
            }

            if (_unresReloc != null)
            {
                header->_unresolvedSection = (byte)_unresReloc._section.Index;
                header->_unresolvedOffset = (uint)sections[_unresReloc._section.Index].Offset + (uint)_unresReloc._index * 4;
            }
            else
            {
                header->_unresolvedSection = 0;
                header->_unresolvedOffset = 0;
            }
            
            RELImportEntry* imports = (RELImportEntry*)dataAddr;
            header->_impOffset = (uint)(dataAddr - address);
            dataAddr = (VoidPtr)imports + (header->_impSize = (uint)Children[1].Children.Count * RELImportEntry.Size);
            header->_relOffset = (uint)(dataAddr - address);

            List<RELImportNode> k = new List<RELImportNode>();
            foreach (RELImportNode s in Children[1].Children)
                if (s.ModuleID != ModuleID && s.ModuleID != 0)
                    k.Add(s);
            k = k.OrderBy(x => x.ModuleID).ToList();
            foreach (RELImportNode s in Children[1].Children)
                if (s.ModuleID == ModuleID)
                {
                    k.Add(s);
                    break;
                }
            foreach (RELImportNode s in Children[1].Children)
                if (s.ModuleID == 0)
                {
                    k.Add(s);
                    break;
                }
            foreach (RELImportNode s in k)
            {
                int i = s.Index;

                if (s.ModuleID == ModuleID)
                    header->_commandOffset = s._dataOffset = (uint)(dataAddr - address);

                imports[i]._moduleId = s.ModuleID;
                imports[i]._offset = s._dataOffset;
                s.Rebuild(dataAddr, s._calcSize, true);
                dataAddr += s._calcSize;
            }
        }

        public static List<RELNode> _files = new List<RELNode>();
    }
}