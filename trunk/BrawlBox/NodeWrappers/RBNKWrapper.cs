using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.RBNK)]
    class RBNKWrapper : GenericWrapper
    {
        public override string ExportFilter { get { return ExportFilters.RBNK; } }
    }
}
