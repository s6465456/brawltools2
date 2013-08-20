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
        ModuleSectionNode[] Sections { get { return (_parentRelocation._section.Root as ModuleNode).Sections; } }

        [Category("Relocation Command"), Browsable(false)]
        public bool IsBranchSet { get { return (_command >= RELLinkType.SetBranchDestination && _command <= RELLinkType.SetBranchConditionDestination3); } }
        [Category("Relocation Command"), Browsable(false)]
        public bool IsHalf { get { return (_command >= RELLinkType.WriteLowerHalf1 && _command <= RELLinkType.WriteUpperHalfandBit1); } }

        [Category("Relocation Command"), Description("The offset into the target section.")]
        public string TargetOffset 
        {
            get { return "0x" + _addend.ToString("X"); }
            set
            {
                string s = (value.StartsWith("0x") ? value.Substring(2, Math.Min(value.Length - 2, 8)) : value.Substring(0, Math.Min(value.Length, 8)));
                uint offset;
                if (uint.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out offset))
                {
                    ModuleSectionNode section = Sections[TargetSectionID];

                    offset = offset.RoundDown(4).Clamp(0, (uint)(section._relocations.Length - 1) * 4);
                    
                    Relocation r = section.GetRelocationAtOffset((int)offset);

                    if (r != null)
                    {
                        _addend = offset;
                        _targetRelocation = r;
                        _parentRelocation._section.SignalPropertyChange();
                    }
                }
            }
        }
        [Category("Relocation Command"), Description("Determines how the offset should be applied to this section.")]
        public RELLinkType Command { get { return _command; } set { _command = value; _parentRelocation._section.SignalPropertyChange(); } }

        [Category("Relocation Command"), Description("The index of the section to retrieve data from.")]
        public uint TargetSectionID 
        {
            get { return _targetSectionId; } 
            set 
            {
                _targetSectionId = value.Clamp(0, (uint)Sections.Length - 1);
                TargetOffset = _addend.ToString("X");
                _parentRelocation._section.SignalPropertyChange(); 
            } 
        }

        public RELLinkType _command;
        public int _modifiedSectionId;
        public uint _targetSectionId;
        public uint _moduleID;

        //Added is an offset relative to the start of the section
        public uint _addend;
        public bool _initialized = false;

        [Category("Relocation Command"), Browsable(false)]
        public RelCommand Next { get { return _next; } }
        [Category("Relocation Command"), Browsable(false)]
        public RelCommand Previous { get { return _prev; } }

        public RelCommand _next = null;
        public RelCommand _prev = null;

        public Relocation _parentRelocation;
        public Relocation _targetRelocation;

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

        public RelCommand(uint fileId, int section, RELLink link)
        {
            _moduleID = fileId;
            _modifiedSectionId = section;
            _targetSectionId = link._section;
            _command = link._type;
            _addend = link._value;
        }

        [Browsable(false)]
        public Relocation TargetRelocation 
        {
            get { return _targetRelocation; }
            set
            {
                if ((_targetRelocation = value) != null)
                    _addend = (uint)_targetRelocation._index * 4;
            }
        }

        private void GetTargetRelocation()
        {
            if (_parentRelocation == null)
                _targetRelocation = null;
            else if (_targetSectionId > 0 && _targetSectionId < Sections.Length)
                _targetRelocation = Sections[_targetSectionId].GetRelocationAtOffset((int)_addend);
        }

        public void SetRelocationParent(Relocation r)
        {
            _parentRelocation = r;
            GetTargetRelocation();
        }

        public uint Apply(bool absolute)
        {
            uint newValue = _parentRelocation.RawValue;
            uint param = _addend + (absolute ? _parentRelocation._section._offset : 0);

            switch (_command)
            {
                case RELLinkType.Nop:
                case RELLinkType.IncrementOffset:
                case RELLinkType.End:
                    break;

                case RELLinkType.WriteWord:
                    newValue = param;
                    break;

                case RELLinkType.SetBranchOffset:
                    newValue &= 0xFC000003;
                    newValue |= (param & 0x03FFFFFC);
                    break;

                case RELLinkType.WriteLowerHalf1:
                case RELLinkType.WriteLowerHalf2:
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)(param & 0xFFFF);
                    break;

                case RELLinkType.WriteUpperHalf:
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)(param >> 16);
                    break;

                case RELLinkType.WriteUpperHalfandBit1:
                    newValue &= 0xFFFF0000;
                    newValue |= (ushort)((param >> 16) | (param & 0x1));
                    break;

                case RELLinkType.SetBranchConditionOffset1:
                case RELLinkType.SetBranchConditionOffset2:
                case RELLinkType.SetBranchConditionOffset3:
                    newValue &= 0xFFFF0003;
                    newValue |= (param & 0xFFFC);
                    break;

                case RELLinkType.SetBranchDestination:
                    break;

                case RELLinkType.SetBranchConditionDestination1:
                case RELLinkType.SetBranchConditionDestination2:
                case RELLinkType.SetBranchConditionDestination3:
                    break;

                case RELLinkType.MrkRef:
                    break;

                default:
                    throw new Exception("Unknown Relocation Command.");
            }
            return newValue;
        }

        //public void Execute()
        //{
        //    if (_modifiedSection == null)
        //        return;

        //    uint param = _addend + ((_targetSection == null) ? 0 : (uint)_targetSection.Offset);
        //    VoidPtr address = _modifiedSection._dataBuffer.Address + _offset;

        //    switch (_command)
        //    {
        //        case 0x00: //Nop
        //        case 0xC9:
        //        case 0xCB: //End
        //            break;
        //        case 0x01: //Write Word
        //            *(buint*)address = param;
        //            break;
        //        case 0x02: //Set Branch Offset
        //            *(buint*)address &= 0xFC000003;
        //            *(buint*)address |= (param & 0x03FFFFFC);
        //            break;
        //        case 0x3: //Write Lower Half
        //        case 0x4:
        //            *(bushort*)address = (ushort)(param & 0xFFFF);
        //            break;
        //        case 0x5: //Write Upper Half
        //            *(bushort*)address = (ushort)(param >> 16);
        //            break;
        //        case 0x6: //Write Upper Half + bit 1
        //            *(bushort*)address = (ushort)((param >> 16) | (param & 0x1));
        //            break;
        //        case 0x7: //Set Branch Condition Offset
        //        case 0x8:
        //        case 0x9:
        //            *(buint*)address &= 0xFFFF0003;
        //            *(buint*)address |= (param & 0xFFFC);
        //            break;
        //        case 0xA: //Set Branch Destination
        //            break;
        //        case 0xB: //Set Branch Condition Destination
        //        case 0xC:
        //        case 0xD:
        //            break;
        //        default:
        //            throw new Exception("Unknown Relocation Command.");
        //    }
        //    _initialized = true;
        //}
    }
}
