using System;
using BrawlLib.SSBBTypes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARExtFileNode : RSARFileNode
    {
        internal INFOFileHeader* Data { get { return (INFOFileHeader*)WorkingUncompressed.Address; } }

        protected override bool OnInitialize()
        {
            RSARNode parent = RSARNode;
            _extPath = Data->GetPath(&RSARNode.Header->INFOBlock->_collection);
            if (_name == null)
                _name = String.Format("[{0}] {1}", _fileIndex, _extPath);
            _extFileSize = Data->_headerLen;
            return false;
        }
    }
}
