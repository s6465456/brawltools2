﻿using System;
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
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class AnimParamSection : ExternalEntry
    {
        AnimParamHeader hdr;

        [Category("Data Offsets")]
        public int SubactionFlags { get { return hdr.SubactionFlags; } }
        [Category("Data Offsets")]
        public int SubactionFlagsCount { get { return hdr.SubactionFlagsCount; } }
        [Category("Data Offsets")]
        public int ActionFlags { get { return hdr.ActionFlags; } }
        [Category("Data Offsets")]
        public int ActionFlagsCount { get { return hdr.ActionFlagsCount; } }
        [Category("Data Offsets")]
        public int Unk4 { get { return hdr.Unknown4; } }
        [Category("Data Offsets")]
        public int Unk5 { get { return hdr.Unknown5; } }
        [Category("Data Offsets")]
        public int Unk6 { get { return hdr.Unknown6; } }
        [Category("Data Offsets")]
        public int Unk7 { get { return hdr.Unknown7; } }
        [Category("Data Offsets")]
        public int Unk8 { get { return hdr.Unknown8; } }
        [Category("Data Offsets")]
        public int Unk9 { get { return hdr.Unknown9; } }
        [Category("Data Offsets")]
        public int Unk10 { get { return hdr.Unknown10; } }
        [Category("Data Offsets")]
        public int Unk11 { get { return hdr.Unknown11; } }
        [Category("Data Offsets")]
        public int HitData { get { return hdr.Hurtboxes; } }
        [Category("Data Offsets")]
        public int Unk13 { get { return hdr.Unknown13; } }
        [Category("Data Offsets")]
        public int CollisionData { get { return hdr.CollisionData; } }
        [Category("Data Offsets")]
        public int Unk15 { get { return hdr.Unknown15; } }

        public override void Parse(VoidPtr address)
        {
            AnimParamHeader* h = (AnimParamHeader*)address;

            hdr = *h;
        }
    }
}