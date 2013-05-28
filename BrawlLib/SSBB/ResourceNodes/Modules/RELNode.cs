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

namespace BrawlLib.SSBB.ResourceNodes
{
    //Credit to PhantomWings for researching RELs and coding Module Editors 1, 2 & 3
    public unsafe class RELNode : ModuleNode
    {
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

        public uint _moduleAlign = 32;
        public uint _bssAlign = 8;
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
            _fixSize = Header->_fixSize;

            return true;
        }

        public override void OnPopulate()
        {
            RELGroupNode g;
            g = new RELGroupNode() { _name = "Sections" };
            g.Parent = this;
            g = new RELGroupNode() { _name = "Imports" };
            g.Parent = this;

            _sections = new RELSectionNode[_numSections];
            for (int i = 0; i < _numSections; i++)
                (_sections[i] = new RELSectionNode()).Initialize(Children[0], &Header->SectionInfo[i], RELSection.Size);

            for (int i = 0; i < Header->ImportListCount; i++)
                new RELImportNode().Initialize(Children[1], &Header->Imports[i], RELImport.Size);

            foreach (RELImportNode r in Children[1].Children)
                if (r.ModuleID == ID)
                {
                    r.ApplyRelocations();
                    break;
                }

            //foreach (RELSectionNode n in _sections)
            //    foreach (RelCommand c in n._commandList)
            //        if (c != null)
            //            c.Execute();

            RELSectionNode s = _sections[Header->_prologSection];
            new RELMethodNode() { _name = "Constructor" }.Initialize(this, s._sectionAddr + (Header->_prologOffset - s._offset), 0);
            s = _sections[Header->_epilogSection];
            new RELMethodNode() { _name = "Destructor" }.Initialize(this, s._sectionAddr + (Header->_epilogOffset - s._offset), 0);
            s = _sections[Header->_unresolvedSection];
            new RELMethodNode() { _name = "Undefined" }.Initialize(this, s._sectionAddr + (Header->_unresolvedOffset - s._offset), 0);
        }

        public override int OnCalculateSize(bool force)
        {
            int size = RELHeader.Size + Children[0].Children.Count * RELSection.Size + Children[1].Children.Count * RELImport.Size;
            foreach (RELSectionNode s in Children[0].Children)
                size += s.CalculateSize(true);
            foreach (RELImportNode s in Children[1].Children)
                size += s.CalculateSize(true);
            return size;
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

            header->_bssSize = _bssSize;
            header->_impSize = (uint)Children[1].Children.Count * RELImport.Size;
            header->_prologSection = _prologSection;
            header->_epilogSection = _epilogSection;
            header->_unresolvedSection = _unresolvedSection;
            header->_bssSection = _bssSection;
            header->_prologOffset = _prologOffset;
            header->_epilogOffset = _epilogOffset;
            header->_unresolvedOffset = _unresolvedOffset;

            header->_moduleAlign = _moduleAlign;
            header->_bssAlign = _bssAlign;
            header->_fixSize = _fixSize;

            RELSection* sections = (RELSection*)(address + RELHeader.Size);
            VoidPtr dataAddr = address + RELHeader.Size + Children[0].Children.Count * RELSection.Size;
            int i = 0;
            foreach (RELSectionNode s in Children[0].Children)
            {
                sections[i]._offset = (uint)(dataAddr - address);
                sections[i]._size = (uint)s._calcSize;
                sections[i].IsCodeSection = s.CodeSection;
                s.Rebuild(dataAddr, s._calcSize, true);
                dataAddr += s._calcSize;
                i++;
            }
            RELImport* imports = (RELImport*)dataAddr;
            header->_impOffset = (uint)(dataAddr - address);
            dataAddr = (VoidPtr)imports + header->_impSize;
            i = 0;
            foreach (RELImportNode s in Children[1].Children)
            {
                imports[i]._moduleId = s.ModuleID;
                imports[i]._offset = (uint)(dataAddr - address);
                s.Rebuild(dataAddr, s._calcSize, true);
                dataAddr += s._calcSize;
                i++;
            }

            header->_relOffset = _relOffset;
           
        }

        public static List<RELNode> _files = new List<RELNode>();
        public static RELNode File(int fileId)
        {
            foreach (RELNode file in _files)
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
            foreach (RELNode file in _files)
                if (address >= (uint)file.Header && address < (uint)file.Header + file.WorkingUncompressed.Length)
                    return file.FileId;
            return -1;
        }
    }
}
