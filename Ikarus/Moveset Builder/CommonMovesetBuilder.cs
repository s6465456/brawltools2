using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using BrawlLib.IO;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.OpenGL;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe partial class NewMovesetBuilder
    {
        //Subroutines are written just before the first action are called by.

        //dataCommon:

        //Unknown23 Parameters
        //Unknown7's Children's Entries
        //Params8
        //Params10
        //Params16
        //Params18
        //Global IC-Basics // Unknown23 Offset
        //IC-Basics // Params24 Value
        //Params12
        //Params13
        //Params14
        //Params15
        //SSE Global IC-Basics
        //SSE IC-Basics
        //Flash Overlay Actions
        //patternPowerMul parameters
        //Flash Overlay Action Offsets
        //Screen Tint Actions
        //Screen Tint Action Offsets
        //Unknown22 entries
        //Entry/Exit actions alternating
        //Unknown7 Data entries
        //Unknown11
        //Leg bones
        //Unknown22 header
        //patternPowerMul header
        //patternPowerMul events  
        //Sections data
        //dataCommon header

        public static int CalcDataCommonSize(MoveDefDataCommonNode node)
        {
            int size = 0;
            
            return 0;
        }

        internal static unsafe void BuildDataCommon(MoveDefDataCommonNode node, int length, bool force)
        {

        }
    }
}