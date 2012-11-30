using System;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARBankNode : RSAREntryNode
    {
        internal INFOBankEntry* Header { get { return (INFOBankEntry*)WorkingUncompressed.Address; } }
        internal override int StringId { get { return Header->_stringId; } }

        internal RBNKNode _rbnk;

        [Browsable(false)]
        public RBNKNode BankNode
        {
            get { return _rbnk; }
            set
            {
                if (_rbnk != value)
                    _rbnk = value;
            }
        }
        [Category("INFO Bank"), Browsable(true), TypeConverter(typeof(DropDownListRSARFiles))]
        public string BankFile
        {
            get { return _rbnk == null ? null : _rbnk._name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    BankNode = null;
                else
                {
                    RBNKNode node = null; int t = 0;
                    foreach (ResourceNode r in RSARNode.Files)
                    {
                        if (r.Name == value && r is RBNKNode) { node = r as RBNKNode; break; }
                        t++;
                    }
                    if (node != null)
                    {
                        BankNode = node;
                        _fileId = t;
                        SignalPropertyChange();
                    }
                }
            }
        }

        public override ResourceType ResourceType { get { return ResourceType.RSARBank; } }

        public int _fileId;

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _fileId = Header->_fileId;

            _rbnk = RSARNode.Files[_fileId] as RBNKNode;

            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            return INFOBankEntry.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            INFOBankEntry* header = (INFOBankEntry*)address;
            header->_stringId = _rebuildStringId;
            header->_fileId = _fileId;
            header->_padding = 0;
        }
    }
}
