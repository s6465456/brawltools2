using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.Wii.Models;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.Modeling
{
    public interface IMatrixNode
    {
        List<IMatrixNodeUser> References { get; }
        int ReferenceCount { get; set; }
        int NodeIndex { get; }
        Matrix Matrix { get; }
        Matrix InverseBindMatrix { get; }
        bool IsPrimaryNode { get; }
        List<BoneWeight> Weights { get; }
        int PermanentID { get; }
    }
}
