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
    public unsafe class RELLinkNode : ModuleEntryNode
    {
        internal RELLink* Header { get { return (RELLink*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        
        [Category("REL Link")]
        public uint PreviousOffset { get { return Header->_prevOffset; } }
        [Category("REL Link")]
        public RELLinkType Type { get { return (RELLinkType)Header->_type; } }
        [Category("REL Link")]
        public byte TargetSection { get { return Header->_section; } } //The section that the offset will redirect to
        [Category("REL Link")]
        public uint Operand { get { return Header->_value; } }

        public override bool OnInitialize()
        {
            _name = Type.ToString();

            return false;
        }
    }
}
