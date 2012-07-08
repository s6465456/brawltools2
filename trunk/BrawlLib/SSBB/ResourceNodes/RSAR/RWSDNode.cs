using System;
using BrawlLib.SSBBTypes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RWSDNode : ResourceNode
    {
        internal RWSDHeader* Header { get { return (RWSDHeader*)WorkingUncompressed.Address; } }

        protected override bool OnInitialize()
        {
            _name = "Raw Sound";
            return true;
        }
    }
}
