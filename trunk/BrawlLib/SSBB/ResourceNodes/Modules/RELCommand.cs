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
    [TypeConverter(typeof(ExpandableObjectCustomConverter))]
    public unsafe class RelCommand
    {
        public RELNode _targetModule;
        public RELSectionNode _modifiedSection;
        public RELSectionNode _targetSection;

        public uint _moduleID;

        [Category("Relocation Command"), Browsable(false)]
        public bool IsBranchSet { get { return (_command >= 0xA && _command <= 0xD); } }
        [Category("Relocation Command"), Browsable(false)]
        public bool IsHalf { get { return (_command > 0x2 && _command < 0x7); } }

        [Category("Relocation Command")]
        public int Offset { get { return _offset; } }
        [Category("Relocation Command")]
        public uint Addend { get { return _addend; } }
        [Category("Relocation Command")]
        public RELLinkType Command { get { return (RELLinkType)_command; } }

        public int _index;
        public int _offset;
        public uint _command;
        public int _modifiedSectionId;
        public uint _targetSectionId;
        public uint _addend;
        public bool _initialized = false;

        [Category("Relocation Command")]
        public RelCommand Next { get { return _next; } }
        [Category("Relocation Command")]
        public RelCommand Previous { get { return _prev; } }

        public RelCommand _next = null;
        public RelCommand _prev = null;

        [Category("Relocation Command")]
        public Relocation TargetRelocation { get { return (_targetSection != null ? _targetSection.Relocations((int)Addend) : null); } }

        public void Remove()
        {
            if (_next != null)
                _next._prev = _prev;
            if (_prev != null)
                _prev._next = _next;
            _next = _prev = null;
        }

        public void InsertAfter(RelCommand cmd)
        {
            _prev = cmd;
            _next = cmd._next;
            cmd._next = this;
        }

        public void InsertBefore(RelCommand cmd)
        {
            _next = cmd;
            _prev = cmd._prev;
            cmd._prev = this;
        }

        public RelCommand(uint fileId, int section, int offset, RELLink link)
        {
            _moduleID = fileId;
            _modifiedSectionId = section;
            _targetSectionId = link._section;
            _offset = offset;
            _command = link._type;
            _addend = link._value;

            _targetModule = RELNode.File((int)_moduleID);
            if (_targetModule != null)
            {
                _modifiedSection = _targetModule.Sections[_modifiedSectionId];
                _targetSection = _targetModule.Sections[_targetSectionId];
            }
        }

        public uint Apply(uint value) { return Apply(value, false); }
        public uint Apply(uint value, bool targetSectionIsBaseOffset)
        {
            if (_modifiedSection == null)
                return value;

            uint newValue = value;
            uint param = _addend + ((_targetSection == null || targetSectionIsBaseOffset) ? 0 : (uint)_targetSection.Offset);

            switch (_command)
            {
                case 0x00: //Nop
                case 0xC9:
                case 0xCB: //End
                    break;
                case 0x01: //Write Word
                    newValue = param;
                    break;
                case 0x02: //Set Branch Offset
                    newValue &= 0xFC000003;
                    newValue |= (param & 0x03FFFFFC);
                    break;
                case 0x3: //Write Lower Half
                case 0x4:
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)(param & 0xFFFF);
                    break;
                case 0x5: //Write Upper Half
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)(param >> 16);
                    break;
                case 0x6: //Write Upper Half + bit 1
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)((param >> 16) | (param & 0x1));
                    break;
                case 0x7: //Set Branch Condition Offset
                case 0x8:
                case 0x9:
                    newValue &= 0xFFFF0003;
                    newValue |= (param & 0xFFFC);
                    break;
                case 0xA: //Set Branch Destination
                    break;
                case 0xB: //Set Branch Condition Destination
                case 0xC:
                case 0xD:
                    break;
                default:
                    throw new Exception("Unknown Relocation Command.");
            }
            return newValue;
        }

        public void Execute()
        {
            if (_modifiedSection == null)
                return;

            uint param = _addend + ((_targetSection == null) ? 0 : (uint)_targetSection.Offset);
            VoidPtr address = _modifiedSection._dataBuffer.Address + _offset;

            switch (_command)
            {
                case 0x00: //Nop
                case 0xC9:
                case 0xCB: //End
                    break;
                case 0x01: //Write Word
                    *(buint*)address = param;
                    break;
                case 0x02: //Set Branch Offset
                    *(buint*)address &= 0xFC000003;
                    *(buint*)address |= (param & 0x03FFFFFC);
                    break;
                case 0x3: //Write Lower Half
                case 0x4:
                    *(bushort*)address = (ushort)(param & 0xFFFF);
                    break;
                case 0x5: //Write Upper Half
                    *(bushort*)address = (ushort)(param >> 16);
                    break;
                case 0x6: //Write Upper Half + bit 1
                    *(bushort*)address = (ushort)((param >> 16) | (param & 0x1));
                    break;
                case 0x7: //Set Branch Condition Offset
                case 0x8:
                case 0x9:
                    *(buint*)address &= 0xFFFF0003;
                    *(buint*)address |= (param & 0xFFFC);
                    break;
                case 0xA: //Set Branch Destination
                    break;
                case 0xB: //Set Branch Condition Destination
                case 0xC:
                case 0xD:
                    break;
                default:
                    throw new Exception("Unknown Relocation Command.");
            }
            _initialized = true;
        }
    }
}
