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
    public unsafe class RELImportNode : RELEntryNode
    {
        internal RELImportEntry* Header { get { return (RELImportEntry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RELImport; } }

        [Category("REL Import")]
        public uint ModuleID { get { return _id; } }
        [Category("REL Import")]
        public uint Offset { get { return _dataOffset; } }

        public uint _id;
        public uint _dataOffset;

        public List<RELLinkNode> _cmds;
        public List<RELLinkNode> Commands { get { return _cmds; } set { _cmds = value; } }

        public override bool OnInitialize()
        {
            _id = Header->_moduleId;
            _dataOffset = Header->_offset;

            if (RELNode._idNames.ContainsKey((int)ModuleID))
                _name = RELNode._idNames[(int)ModuleID];
            else
                _name = "Module" + ModuleID;

            _cmds = new List<RELLinkNode>();
            RELLinkNode n;

            RELLink* link = (RELLink*)(Root.WorkingUncompressed.Address + (uint)Header->_offset);
            do
            {
                (n = new RELLinkNode()).Initialize(null, link, RELImportEntry.Size);
                _cmds.Add(n);
            }
            while ((link++)->_type != RELLinkType.End);
            
            return false;
        }

        public bool ApplyRelocations(ModuleNode target)
        {
            if (target == null || target.ID != ModuleID)
                return false;

            ModuleSectionNode section = null;

            int offset = 0;
            foreach (RELLinkNode link in _cmds)
                if (link.Type == RELLinkType.Section)
                {
                    offset = 0;
                    section = target.Sections[link.TargetSection];
                }
                else
                {
                    offset += (int)link.PreviousOffset;
                    RelCommand cmd = new RelCommand(ModuleID, section.Index, *link.Header);
                    if (section != null)
                        section.SetCommandAtOffset(offset, cmd);
                    else
                        Console.WriteLine(String.Format("Non-block oriented relocation command: {0} {1} {2} {3}", link.Type.ToString(), link._targetSection, link._prevOffset, link.Value));
                }

            return true;
        }

        public static RELImportNode GenerateNewCommandList(RELNode module)
        {
            RELImportNode node = new RELImportNode();
            node.GenerateCommandList(module);
            return node;
        }
        public void GenerateCommandList(RELNode module)
        {
            _cmds.Clear();
            _id = module.ModuleID;
            _dataOffset = 0;

            if (RELNode._idNames.ContainsKey((int)ModuleID))
                _name = RELNode._idNames[(int)ModuleID];
            else
                _name = "Module" + ModuleID;
            
            uint offset = 0;
            uint lastOffset = 0;
            byte section = 0;
            
            foreach (ModuleSectionNode s in module._sections)
            {
                bool first = true;
                uint i = 0;
                foreach (Relocation loc in s._relocations)
                {
                    if (loc.Command != null)
                    {
                        if (first)
                        {
                            _cmds.Add(new RELLinkNode() { _type = RELLinkType.Section, _targetSection = section });
                            first = false;
                        }

                        RelCommand cmd = loc.Command;

                        offset = i * 4 + (cmd.IsHalf ? 2u : 0);
                        while (offset - lastOffset > 0xFFFF)
                        {
                            lastOffset += 0xFFFF;
                            _cmds.Add(new RELLinkNode() { _type = RELLinkType.IncrementOffset, _targetSection = 0, _value = 0, _prevOffset = 0xFFFF });
                        }

                        byte targetSection = (byte)cmd._targetRelocation._section.Index;
                        RELLinkType type = (RELLinkType)cmd._command;
                        uint val = cmd._addend;

                        _cmds.Add(new RELLinkNode() { _type = type, _targetSection = targetSection, _value = val, _prevOffset = (ushort)(offset - lastOffset) });

                        lastOffset = offset;
                    }
                    i++;
                }
                section++;
            }
            _cmds.Add(new RELLinkNode() { _type = RELLinkType.End });
        }

        public override int OnCalculateSize(bool force)
        {
            return (_cmds.Count * RELLink.Size).Align(8);
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            RELLink* link = (RELLink*)address;
            foreach (RELLinkNode n in _cmds)
            {
                link->_value = n._value;
                link->_prevOffset = (ushort)n.PreviousOffset;
                link->_type = n.Type;
                link->_section = n.TargetSection;

                link++;
            }
        }
    }
}