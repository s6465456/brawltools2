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
    public unsafe partial class MovesetConverter
    {
        //dataCommon:

        //Unknown7 entries
        //Params8
        //Params10
        //Params16
        //Params18
        //Global IC-Basics
        //Unknown23
        //IC-Basics
        //Params24 
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
        //Subroutines
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
            return 0;
        }

        internal static unsafe void BuildDataCommon(MoveDefDataCommonNode node, int length, bool force)
        {

        }
    }
}