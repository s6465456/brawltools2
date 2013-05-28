using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using BrawlLib.IO;
using System.PowerPcAssembly;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RELSectionNode : ModuleDataNode
    {
        internal RELSection* Header { get { return (RELSection*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        private bool _isCodeSection;
        private int _off;
        private uint _size;

        [Category("REL Section")]
        public bool CodeSection { get { return _isCodeSection; } }
        [Category("REL Section")]
        public int Offset { get { return _off; } }
        [Category("REL Section")]
        public uint Size { get { return _size; } }

        public VoidPtr _sectionAddr;
        public bool _isDynamic = false;

        public override bool OnInitialize()
        {
            _isCodeSection = Header->IsCodeSection;
            _off = Header->Offset;
            _size = Header->_size;

            //if (Offset == 0 && Size == 0) { Remove(); return false; }

            if (Offset == 0 && Size != 0)
            {
                _sectionAddr = System.Memory.Alloc((int)Size);
                _isDynamic = true;
            }
            else
                _sectionAddr = Root.WorkingUncompressed.Address + Offset;

            _name = String.Format("[{0}] ", Index);
            switch (Index)
            {
                default: _name += "Section"; break;
                case 1: _name += "Assembly"; break;
                case 2: _name += "Constructors"; break;
                case 3: _name += "Destructors"; break;
                case 4: _name += "Constants"; break;
                case 5: _name += "Objects"; break;
                case 6: _name += "BSS"; break;
            }

            Init(Size, CodeSection, _sectionAddr);

            return Index > 1 && Index < 6;
        }

        public override void OnPopulate()
        {
            switch (Index)
            {
                case 2: //Parse Constructors
                case 3: //Parse Destructors
                    for (int i = 0; i < _relocations.Length; i++)
                        if (_relocations[i].FormalValue > 0)
                            new RELDeConStructorNode() { _destruct = Index == 3, _index = i }.Initialize(this, (VoidPtr)BaseAddress + _relocations[i].FormalValue, 0);
                        break;
                case 4: //Display Constants
                    //new MoveDefSectionParamNode().Initialize(this, _dataBuffer.Address, _dataBuffer.Length);
                    break;
                case 5: //Parse Objects
                    new ObjectParser().Parse(this);
                    break;
            }
        }

        public override unsafe void Export(string outPath)
        {
            using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
            {
                stream.SetLength(_dataBuffer.Length);
                using (FileMap map = FileMap.FromStream(stream))
                {
                    VoidPtr addr = _dataBuffer.Address;

                    byte* pIn = (byte*)addr;
                    byte* pOut = (byte*)map.Address;
                    for (int i = 0; i < _dataBuffer.Length; i++)
                        *pOut++ = *pIn++;
                }
            }
        }
    }
}
