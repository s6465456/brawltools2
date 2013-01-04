﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class RELObjectNode : ModuleEntryNode
    {
        private RELType _type = null;

        [Browsable(false)]
        public RELType Type { get { return _type; } }

        public int InheritanceCount { get { return _type.Inheritance.Count; } }

        public RELObjectNode(RELType type)
        {
            _type = type;
            _name = _type.FullName;
        }

        public override string ToString()
        {
            return _type.ToString();
        }
    }
}
