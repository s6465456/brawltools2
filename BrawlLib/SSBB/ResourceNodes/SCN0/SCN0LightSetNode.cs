using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class SCN0LightSetNode : SCN0EntryNode
    {
        internal SCN0LightSet* Data { get { return (SCN0LightSet*)WorkingUncompressed.Address; } }

        private string _ambientLight;
        private List<string> _entries = new List<string>();
        private byte numLights;

        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Ambience))]
        public string Ambience { get { return _ambientLight; } set { _ambientLight = value; SignalPropertyChange(); } }
        [Category("Light Set")]
        public string[] Lights { get { return _entries.ToArray(); } set { _entries = value.ToList<string>(); SignalPropertyChange(); } }
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            if (Data->_ambNameOffset != 0 && !_replaced)
                _ambientLight = Data->AmbientString;

            numLights = Data->_numLights;

            bint* strings = Data->StringOffsets;
            if (!_replaced)
            for (int i = 0; i < Data->_numLights; i++)
                _entries.Add(new String((sbyte*)strings + strings[i]));

            return false;
        }

        internal override void GetStrings(StringTable table)
        {
            if (Name != "<null>")
                table.Add(Name);
            else return;

            if (_ambientLight != null)
                table.Add(_ambientLight);

            foreach (string s in _entries)
                table.Add(s);
        }

        protected override int OnCalculateSize(bool force)
        {
            return SCN0LightSet.Size;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);

            SCN0LightSet* header = (SCN0LightSet*)address;

            header->_pad = 0;
            header->_id = -1;
            header->_numLights = (byte)Lights.Length.Clamp(0, 8);
            bshort* ids = header->IDs;
            int i = 0;
            while (i < 8)
                ids[i++] = -1;
        }

        protected internal override void PostProcess(VoidPtr scn0Address, VoidPtr dataAddress, StringTable stringTable)
        {
            base.PostProcess(scn0Address, dataAddress, stringTable);

            SCN0LightSet* header = (SCN0LightSet*)dataAddress;

            if (_ambientLight != null)
                header->AmbientStringAddress = stringTable[_ambientLight] + 4;
            else
                header->_ambNameOffset = 0;

            int i;
            bint* strings = header->StringOffsets;
            for (i = 0; i < _entries.Count && i < 8; i++)
                strings[i] = (int)stringTable[_entries[i]] + 4 - (int)strings;
            while (i < 8)
                strings[i++] = 0;
        }
    }
}