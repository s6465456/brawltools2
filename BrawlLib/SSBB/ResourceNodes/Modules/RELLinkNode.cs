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
    public unsafe class RELLinkNode : RELEntryNode
    {
        internal RELLink* Header { get { return (RELLink*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        
        [Category("REL Link")]
        public ushort PreviousOffset { get { return _prevOffset; } }
        [Category("REL Link")]
        public RELLinkType Type { get { return _type; } }
        [Category("REL Link")]
        public byte TargetSection { get { return _targetSection; } } //The section that the offset will redirect to
        [Category("REL Link")]
        public string Value { get { return "0x" + _value.ToString("X"); } }

        internal ushort _prevOffset;
        internal RELLinkType _type;
        internal byte _targetSection;
        internal uint _value;

        public override bool OnInitialize()
        {
            _prevOffset = Header->_prevOffset;
            _type = Header->_type;
            _targetSection = Header->_section;
            _value = Header->_value;

            _name = Type.ToString();

            return false;
        }
    }
}
