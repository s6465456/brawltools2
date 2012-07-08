using System;
using BrawlLib.SSBBTypes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARSetNode : RSAREntryNode
    {
        internal INFOData4* Header { get { return (INFOData4*)WorkingUncompressed.Address; } }


        int _index;

        protected override bool OnInitialize()
        {
            _index = Index;
            _name = String.Format("0x{0:X}", _index);
            return true;
        }

        protected override void OnPopulate()
        {
            RSARNode n = RSARNode;
            if (n != null)
            {
                ruint* group = n.Header->INFOBlock->GroupList;
                ruint* list = (ruint*)((uint)group + group[0] + 4);
                int count = *((bint*)list - 1);

                for (int i = 0; i < count; i++)
                {
                    INFOData1Part1* data = (INFOData1Part1*)((uint)group + list[i]);
                    if (data->_groupId == _index)
                        new RSARSoundNode().Initialize(this, new DataSource(data, 0));
                }
            }
        }
    }
}
