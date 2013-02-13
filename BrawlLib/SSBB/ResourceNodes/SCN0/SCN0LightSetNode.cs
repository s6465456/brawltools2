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
        private string[] _entries = new string[8];
        public SCN0LightNode[] _lights = new SCN0LightNode[8];
        public SCN0AmbientLightNode _ambient;
        private byte numLights;

        //Remaps light entries to an array with no space between entries.
        private void SetLight(int index, string value)
        {
            int i = 0;
            if (!String.IsNullOrEmpty(value))
            {
                for (; i < 8; i++)
                    if (_entries[i] == value && i != index)
                        return;
                for (i = 0; i < index; i++)
                    if (_entries[i] == null)
                        break;
            }
            else
            {
                _lights[index] = null;
                _entries[index] = null;

                SignalPropertyChange();

                int amt = 0;
                for (int x = 0; x < 8; x++)
                    if (_lights[x] == null)
                        amt++;
                    else if (amt != 0)
                    {
                        _lights[x - amt] = _lights[x];
                        _entries[x - amt] = _entries[x];

                        _lights[x] = null;
                        _entries[x] = null;
                    }
                UpdateProperties();
                return;
            }
            if (i <= index)
            {
                _lights[i] = ((SCN0Node)Parent.Parent).GetFolder<SCN0LightNode>().FindChild(value, false) as SCN0LightNode;
                if (_lights[i] != null)
                    _entries[i] = _lights[i].Name;
                else
                {
                    _entries[i] = null;

                    int amt = 0;
                    for (int x = 0; x < 8; x++)
                        if (_lights[x] == null)
                            amt++;
                        else if (amt != 0)
                        {
                            _lights[x - amt] = _lights[x];
                            _entries[x - amt] = _entries[x];

                            _lights[x] = null;
                            _entries[x] = null;
                        }
                }
                UpdateProperties();
                SignalPropertyChange();
            }
        }

        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Ambience))]
        public string Ambience
        { 
            get { return _ambientLight; } 
            set
            {
                _ambient = ((SCN0Node)Parent.Parent).GetFolder<SCN0AmbientLightNode>().FindChild(value, false) as SCN0AmbientLightNode;
                if (_ambient != null)
                    _ambientLight = _ambient.Name; 
                SignalPropertyChange();
            } 
        }
        
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light0 
        {
            get { return _entries[0]; } 
            set { SetLight(0, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light1
        {
            get { return _entries[1]; }
            set { SetLight(1, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light2
        {
            get { return _entries[2]; }
            set { SetLight(2, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light3
        {
            get { return _entries[3]; }
            set { SetLight(3, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light4
        {
            get { return _entries[4]; }
            set { SetLight(4, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light5
        {
            get { return _entries[5]; }
            set { SetLight(5, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light6
        {
            get { return _entries[6]; }
            set { SetLight(6, value); }
        }
        [Category("Light Set"), TypeConverter(typeof(DropDownListSCN0Light))]
        public string Light7
        {
            get { return _entries[7]; }
            set { SetLight(7, value); }
        }

        protected override bool OnInitialize()
        {
            base.OnInitialize();
            _entries = new string[8];

            if (Data->_ambNameOffset != 0 && !_replaced)
                _ambientLight = Data->AmbientString;

            numLights = Data->_numLights;

            bint* strings = Data->StringOffsets;
            if (!_replaced)
                for (int i = 0; i < Data->_numLights && i < 8; i++)
                    _entries[i] = new String((sbyte*)strings + strings[i]);

            return false;
        }

        public void AttachNodes()
        {
            SCN0Node node = (SCN0Node)Parent.Parent;
            SCN0GroupNode g = node.GetFolder<SCN0LightNode>();
            int i = 0;
            if (g != null)
                foreach (string s in _entries)
                    _lights[i++] = g.FindChild(s, false) as SCN0LightNode;
            g = node.GetFolder<SCN0AmbientLightNode>();
            if (g != null)
                _ambient = g.FindChild(_ambientLight, false) as SCN0AmbientLightNode;
        }

        internal override void GetStrings(StringTable table)
        {
            if (Name != "<null>")
                table.Add(Name);
            else return;

            if (_ambientLight != null)
                table.Add(_ambientLight);

            foreach (string s in _entries)
                if (!String.IsNullOrEmpty(s))
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
            header->_numLights = (byte)_entries.Length.Clamp(0, 8);
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
            for (i = 0; i < 8; i++)
                if (!String.IsNullOrEmpty(_entries[i]))
                    strings[i] = (int)stringTable[_entries[i]] + 4 - (int)strings;
                else break;
            while (i < 8)
                strings[i++] = 0;
        }
    }
}