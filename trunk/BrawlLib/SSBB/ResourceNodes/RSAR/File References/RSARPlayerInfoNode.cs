using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARPlayerInfoNode : RSAREntryNode
    {
        internal INFOPlayerInfoEntry* Header { get { return (INFOPlayerInfoEntry*)WorkingUncompressed.Address; } }
        internal override int StringId { get { return Header->_stringId; } }

        public override ResourceType ResourceType { get { return ResourceType.RSARType; } }

        private byte _playableSoundCount;

        [Category("Player Info")]
        public byte PlayableSoundCount { get { return _playableSoundCount; } set { _playableSoundCount = value; SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _playableSoundCount = Header->_playableSoundCount;

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return INFOPlayerInfoEntry.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            INFOPlayerInfoEntry* header = (INFOPlayerInfoEntry*)address;

            header->_stringId = _rebuildStringId;
            header->_playableSoundCount = _playableSoundCount;
        }
    }
}
