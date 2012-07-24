using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0AmbientLightNode : SCN0EntryNode
    {
        internal SCN0AmbientLight* Data { get { return (SCN0AmbientLight*)WorkingUncompressed.Address; } }
        private byte fixedFlags, unk2, unk3, unk4;
        private List<RGBAPixel> _lighting = new List<RGBAPixel>();

        [Category("Ambient Light")]
        public SCN0AmbLightFlags Flags { get { return (SCN0AmbLightFlags)unk4; } set { unk4 = (byte)value; SignalPropertyChange(); } }
        [Category("Ambient Light")]
        public RGBAPixel[] Lighting { get { return _lighting.ToArray(); } set { _lighting = value.ToList<RGBAPixel>(); SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _lighting = new List<RGBAPixel>();

            fixedFlags = Data->_fixedFlags;
            unk2 = Data->_pad1;
            unk3 = Data->_pad2;
            unk4 = Data->_flags;
            if ((fixedFlags >> 7 & 1) == 1)
                _lighting.Add(Data->_lighting);
            else
            {
                if (Name != "<null>" && !_replaced)
                {
                    RGBAPixel* addr = Data->lightEntries;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        _lighting.Add(*addr++);
                }
            }
            return false;
        }

        protected override int OnCalculateSize(bool force)
        {
            if (_name != "<null>")
                if (_lighting.Count > 1)
                {
                    fixedFlags &= 0xFF - 128;
                    lightLen = 4 * (((SCN0Node)Parent.Parent).FrameCount + 1);
                }
                else
                {
                    fixedFlags |= 128;
                    lightLen = 0;
                }
            return SCN0AmbientLight.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0AmbientLight* header = (SCN0AmbientLight*)address;
            header->_header._length = _length = SCN0AmbientLight.Size;

            if (_name != "<null>")
            {
                header->_fixedFlags = 128;
                header->_pad1 = 0;
                header->_pad2 = 0;
                header->_flags = unk4;
                if (_lighting.Count > 1)
                {
                    header->_fixedFlags = 0;
                    *((bint*)header->_lighting.Address) = (int)lightAddr - (int)header->_lighting.Address;
                    for (int i = 0; i <= ((SCN0Node)Parent.Parent).FrameCount; i++)
                        if (i < _lighting.Count)
                            *lightAddr++ = _lighting[i];
                        else
                            *lightAddr++ = new RGBAPixel();
                }
                else if (_lighting.Count == 1)
                    header->_lighting = _lighting[0];
                else
                    header->_lighting = new RGBAPixel();
            }
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);
        }
    }
}