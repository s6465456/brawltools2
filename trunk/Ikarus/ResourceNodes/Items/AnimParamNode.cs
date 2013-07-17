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
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefAnimParamNode : MoveDefEntryNode
    {
        internal AnimParamHeader* Header { get { return (AnimParamHeader*)WorkingUncompressed.Address; } }

        [Category("Data Offsets")]
        public int SubactionFlags { get { return Header->Unknown0; } }
        [Category("Data Offsets")]
        public int SubactionFlagsCount { get { return Header->Unknown1; } }
        [Category("Data Offsets")]
        public int ActionFlags { get { return Header->Unknown2; } }
        [Category("Data Offsets")]
        public int ActionFlagsCount { get { return Header->Unknown3; } }
        [Category("Data Offsets")]
        public int Unk4 { get { return Header->Unknown4; } }
        [Category("Data Offsets")]
        public int Unk5 { get { return Header->Unknown5; } }
        [Category("Data Offsets")]
        public int Unk6 { get { return Header->Unknown6; } }
        [Category("Data Offsets")]
        public int Unk7 { get { return Header->Unknown7; } }
        [Category("Data Offsets")]
        public int Unk8 { get { return Header->Unknown8; } }
        [Category("Data Offsets")]
        public int Unk9 { get { return Header->Unknown9; } }
        [Category("Data Offsets")]
        public int Unk10 { get { return Header->Unknown10; } }
        [Category("Data Offsets")]
        public int Unk11 { get { return Header->Unknown11; } }
        [Category("Data Offsets")]
        public int HitData { get { return Header->Unknown12; } }
        [Category("Data Offsets")]
        public int Unk13 { get { return Header->Unknown13; } }
        [Category("Data Offsets")]
        public int CollisionData { get { return Header->Unknown14; } }
        [Category("Data Offsets")]
        public int Unk15 { get { return Header->Unknown15; } }

        public MoveDefAnimParamNode(string name) { _name = name; }

        public override bool OnInitialize()
        {
            base.OnInitialize();

            return true;
        }
        public VoidPtr dataHeaderAddr;
        public override void OnPopulate()
        {
            #region Populate
            


            #endregion

            SortChildren();
        }

        public void PopulateActionGroup(ResourceNode g, List<int> ActionOffsets, bool subactions, int index)
        {
            string innerName = "";
            if (subactions)
                if (index == 0)
                    innerName = "Main";
                else if (index == 1)
                    innerName = "GFX";
                else if (index == 2)
                    innerName = "SFX";
                else if (index == 3)
                    innerName = "Other";
                else return;
            else
                if (index == 0)
                    innerName = "Entry";
                else if (index == 1)
                    innerName = "Exit";

            int i = 0;
            foreach (int offset in ActionOffsets)
            {
                //if (i >= g.Children.Count)
                //    if (subactions)
                //        g.Children.Add(new MoveDefSubActionGroupNode() { _name = "Extra" + i, _flags = new AnimationFlags(), _inTransTime = 0, _parent = g });
                //    else
                //        g.Children.Add(new MoveDefGroupNode() { _name = "Extra" + i, _parent = g });

                if (offset > 0)
                    new MoveDefActionNode(innerName, false, g.Children[i]).Initialize(g.Children[i], new DataSource(BaseAddress + offset, 0));
                else
                    g.Children[i].Children.Add(new MoveDefActionNode(innerName, true, g.Children[i]));
                i++;
            }
        }
    }
}