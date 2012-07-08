using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.REFT)]
    class REFTWrapper : GenericWrapper
    {
        public override string ExportFilter { get { return ExportFilters.REFT; } }
    }
}
