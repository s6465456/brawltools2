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
    public unsafe class RELImportNode : ModuleEntryNode
    {
        internal RELImport* Header { get { return (RELImport*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RELImport; } }

        [Category("REL Import")]
        public uint ModuleID { get { return Header->_moduleId; } }
        [Category("REL Import")]
        public uint Offset { get { return Header->_offset; } }

        public List<RELLinkNode> _cmds;
        public List<RELLinkNode> Commands { get { return _cmds; } set { _cmds = value; } }

        public override bool OnInitialize()
        {
            _name = "Module" + ModuleID;

            _cmds = new List<RELLinkNode>();
            RELLinkNode n;

            RELLink* link = (RELLink*)(Root.WorkingUncompressed.Address + (uint)Header->_offset);
            do
            {
                (n = new RELLinkNode()).Initialize(null, link, RELImport.Size);
                _cmds.Add(n);
            }
            while ((link++)->Type != RELLinkType.End);

            return false;
        }

        public bool ApplyRelocations()
        {
            RELNode target = RELNode.File((int)ModuleID);
            if (target == null)
                return false;

            RELSectionNode section = null;

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
                    RelCommand cmd = new RelCommand(ModuleID, section.Index, offset, *link.Header);
                    if (section != null)
                        section.SetCommandAtOffset(offset, cmd);
                    else
                        throw new Exception("Non-block oriented relocation command.");
                }

            return true;
        }
    }
}
