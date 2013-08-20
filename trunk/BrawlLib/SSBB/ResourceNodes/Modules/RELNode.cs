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

        public RELNode AppliedModule { get { return _appliedModule; } }
        public RELNode _appliedModule;

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

        public override bool OnInitialize()
        {
            _files.Add(this);

            //_name = Header->Name;
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

                section.Initialize(Children[0], WorkingUncompressed.Address + Header->SectionInfo[i]._offset, (int)Header->SectionInfo[i]._size);
            }

            for (int i = 0; i < Header->ImportListCount; i++)
                new RELImportNode().Initialize(Children[1], &Header->Imports[i], RELImportEntry.Size);

            ApplyRelocations();

            ModuleSectionNode s = _sections[Header->_prologSection];
            new RELMethodNode() { _name = "Constructor" }.Initialize(this, s.WorkingUncompressed.Address + (Header->_prologOffset - s._offset), 0);
            s = _sections[Header->_epilogSection];
            new RELMethodNode() { _name = "Destructor" }.Initialize(this, s.WorkingUncompressed.Address + (Header->_epilogOffset - s._offset), 0);
            s = _sections[Header->_unresolvedSection];
            new RELMethodNode() { _name = "Undefined" }.Initialize(this, s.WorkingUncompressed.Address + (Header->_unresolvedOffset - s._offset), 0);
        }

        public bool ApplyRelocations() { return ApplyRelocations(this); }
        public bool ApplyRelocations(RELNode n)
        {
            foreach (RELImportNode r in n.Children[1].Children)
                if (r.ModuleID == ModuleID)
                    if (r.ApplyRelocations(this))
                    {
                        _appliedModule = r.Root as RELNode;
                        return true;
                    }
            return false;
        }
        
        public override int OnCalculateSize(bool force)
        {
            int size = RELHeader.Size + Children[0].Children.Count * RELSectionEntry.Size + Children[1].Children.Count * RELImportEntry.Size;
            foreach (ModuleSectionNode s in Children[0].Children)
                size += s.CalculateSize(true);
            foreach (RELImportNode s in Children[1].Children)
                size += s.CalculateSize(true);
            return size;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            //Header
            //Section Entries
            //Section Data
            //Rel Import Entries
            //Rel Link Arrays

            RELHeader* header = (RELHeader*)address;

            header->_info._id = _id;
            header->_info._link._linkNext = 0;
            header->_info._link._linkPrev = 0;
            header->_info._numSections = (uint)Children[0].Children.Count;
            header->_info._sectionInfoOffset = RELHeader.Size;
            header->_info._nameOffset = 0;
            header->_info._nameSize = 0;
            header->_info._version = _version;

            header->_bssSize = 0;
            header->_prologSection = 1;
            header->_epilogSection = 1;
            header->_unresolvedSection = 1;
            header->_bssSection = 0;
            header->_prologOffset = 0;
            header->_epilogOffset = 0;
            header->_unresolvedOffset = 0;

            header->_moduleAlign = 0x20;
            header->_bssAlign = 0x8;
            header->_commandOffset = 0;

            RELSectionEntry* sections = (RELSectionEntry*)(address + RELHeader.Size);
            VoidPtr dataAddr = address + RELHeader.Size + Children[0].Children.Count * RELSectionEntry.Size;
            int i = 0;
            foreach (ModuleSectionNode s in Children[0].Children)
            {
                sections[i]._offset = (uint)(dataAddr - address);
                sections[i]._size = (uint)s._calcSize;
                sections[i].IsCodeSection = s.HasCode;
                s.Rebuild(dataAddr, s._calcSize, true);
                dataAddr += s._calcSize;
                i++;
            }
            RELImportEntry* imports = (RELImportEntry*)dataAddr;
            header->_impOffset = (uint)(dataAddr - address);
            dataAddr = (VoidPtr)imports + (header->_impSize = (uint)Children[1].Children.Count * RELImportEntry.Size);
            
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
            i = 0;
            foreach (RELImportNode s in k)
            {
                if (s.ModuleID == ModuleID)
                {
                    header->_relOffset = s._dataOffset = (uint)(dataAddr - address);
                    s.GenerateCommandList(this);
                }

                imports[i]._moduleId = s.ModuleID;
                imports[i]._offset = (uint)(dataAddr - address);
                s.Rebuild(dataAddr, s._calcSize, true);
                dataAddr += s._calcSize;
                i++;
            }
        }

        public static List<RELNode> _files = new List<RELNode>();

        public ModuleSectionNode Section(uint address)
        {
            foreach (ModuleSectionNode section in Sections)
                if ((uint)section.Header <= address && address < (uint)section.Header + section.Size)
                    return section;
            return null;
        }
    }
}
