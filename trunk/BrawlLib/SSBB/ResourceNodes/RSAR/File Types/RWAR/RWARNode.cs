using System;
using BrawlLib.SSBBTypes;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RWARNode : RSAREntryNode
    {
        internal RWAR* Header { get { return (RWAR*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            return Header->Table->_entryCount > 0;
        }

        protected override void OnPopulate()
        {
            RWARTableBlock* table = Header->Table;
            RWARDataBlock* d = Header->Data;

            for (int i = 0; i < table->_entryCount; i++)
                new RWAVNode().Initialize(this, d->GetEntry(table->Entries[i].waveFileRef), 0);
        }

        internal static ResourceNode TryParse(DataSource source) { return ((RWAR*)source.Address)->_header._tag == RWAR.Tag ? new RWARNode() : null; }
    }
}
