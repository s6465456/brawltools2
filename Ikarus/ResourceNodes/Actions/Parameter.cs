using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using BrawlLib.SSBBTypes;
using System.Runtime.InteropServices;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefEventParameterNode : MoveDefEntry
    {
        internal FDefEventArgument* Header { get { return (FDefEventArgument*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Parameter; } }

        public int _value = 0;

        [Browsable(false)]
        public virtual ArgVarType _type { get { return ArgVarType.Value; } }
        [Browsable(false)]
        public virtual float RealValue { get { return _value; } }
        public bool Compare(MoveDefEventParameterNode param, int compare)
        {
            switch (compare)
            {
                case 0: return this.RealValue < param.RealValue;
                case 1: return this.RealValue <= param.RealValue;
                case 2: return this.RealValue == param.RealValue;
                case 3: return this.RealValue != param.RealValue;
                case 4: return this.RealValue >= param.RealValue;
                case 5: return this.RealValue > param.RealValue;
                default: return false;
            }
        }

        public override bool OnInitialize()
        {
            _value = Header->_data;
            return base.OnInitialize();
        }

        [Browsable(false)]
        public string Description { get { return (Parent as Event).EventInfo != null && Index < (Parent as Event).EventInfo._paramDescs.Length ? (Parent as Event).EventInfo._paramDescs[Index] : "No Description Available."; } }

        public MoveDefEventParameterNode() { }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 8;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefEventArgument* header = (FDefEventArgument*)address;
            header->_type = (int)_type;
            header->_data = _value;
        }
    }

    #region Value Nodes
    public unsafe class MoveDefEventValueNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value")]
        public int Value { get { return _value; } set {  _value = value; SignalPropertyChange(); } }

        public MoveDefEventValueNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValueEnumNode : MoveDefEventParameterNode
    {
        public string[] Enums = new string[0];

        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value"), TypeConverter(typeof(DropDownListEnumMDef))]
        public string Value
        {
            get
            {
                if (_value >= 0 && _value < Enums.Length)
                    return Enums[_value];
                else
                    return _value.ToString();
            }
            set
            {
                if (!int.TryParse(value, out _value))
                    _value = Array.IndexOf(Enums, value);
                
                if (_value == -1)
                    _value = 0;

                SignalPropertyChange();
            }
        }

        public MoveDefEventValueEnumNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValue2HalfNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value")]
        public short Value1 { get { return (short)((_value >> 16) & 0xFFFF); } set { _value = (_value & 0xFFFF) | ((value & 0xFFFF) << 16); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public short Value2 { get { return (short)((_value) & 0xFFFF); } set { _value = (int)((uint)_value & 0xFFFF0000) | (value & 0xFFFF); SignalPropertyChange(); } }
        
        public MoveDefEventValue2HalfNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValue2HalfGFXNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value"), TypeConverter(typeof(DropDownListGFXFilesMDef))]
        public string GFXFile 
        { 
            get 
            { 
                int index = ((_value >> 16) & 0xFFFF);
                if (FileManager.iGFXFiles != null && FileManager.iGFXFiles.Length > 0 && index < FileManager.iGFXFiles.Length)
                    return FileManager.iGFXFiles[index];
                else return index.ToString();
            } 
            set 
            {
                int index = 0;
                if (!int.TryParse(value, out index))
                    if (FileManager.iGFXFiles != null && FileManager.iGFXFiles.Length > 0 && FileManager.iGFXFiles.Contains(value))
                        index = Array.IndexOf(FileManager.iGFXFiles, value);
                _value = (_value & 0xFFFF) | ((index & 0xFFFF) << 16);
                SignalPropertyChange(); 
            } 
        }
        [Category("MoveDef Event Value")]
        public short EFLSEntryIndex { get { return (short)((_value) & 0xFFFF); } set { _value = (int)((uint)_value & 0xFFFF0000) | (value & 0xFFFF); SignalPropertyChange(); } }
        
        public MoveDefEventValue2HalfGFXNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValueHalf2ByteNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value")]
        public short Value1 { get { return (short)((_value >> 16) & 0xFFFF); } set { _value = (_value & 0xFFFF) | ((value & 0xFFFF) << 16); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value2 { get { return (byte)((_value >> 8) & 0xFF); } set { _value = (int)((uint)_value & 0xFFFF00FF) | ((value & 0xFF) << 8); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value3 { get { return (byte)((_value) & 0xFF); } set { _value = (int)((uint)_value & 0xFFFFFF00) | (value & 0xFF); SignalPropertyChange(); } }
        
        public MoveDefEventValueHalf2ByteNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValue2ByteHalfNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value")]
        public byte Value1 { get { return (byte)((_value >> 24) & 0xFF); } set { _value = (int)((uint)_value & 0x00FFFFFF) | ((value & 0xFF) << 24); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value2 { get { return (byte)((_value >> 16) & 0xFF); } set { _value = (int)((uint)_value & 0xFF00FFFF) | ((value & 0xFF) << 16); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public short Value3 { get { return (short)((_value) & 0xFFFF); } set { _value = (int)((uint)_value & 0xFFFF0000) | (value & 0xFFFF); SignalPropertyChange(); } }
        
        public MoveDefEventValue2ByteHalfNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventValue4ByteNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Value; } }

        [Category("MoveDef Event Value")]
        public byte Value1 { get { return (byte)((_value >> 24) & 0xFF); } set { _value = (int)((uint)_value & 0x00FFFFFF) | ((value & 0xFF) << 24); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value2 { get { return (byte)((_value >> 16) & 0xFF); } set { _value = (int)((uint)_value & 0xFF00FFFF) | ((value & 0xFF) << 16); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value3 { get { return (byte)((_value >> 8) & 0xFF); } set { _value = (int)((uint)_value & 0xFFFF00FF) | ((value & 0xFF) << 8); SignalPropertyChange(); } }
        [Category("MoveDef Event Value")]
        public byte Value4 { get { return (byte)((_value) & 0xFF); } set { _value = (int)((uint)_value & 0xFFFFFF00) | (value & 0xFF); SignalPropertyChange(); } }
        
        public MoveDefEventValue4ByteNode(string name) { _name = name != null ? name : "Value"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Value";
            base.OnInitialize();
            return false;
        }
    }
    #endregion

    public unsafe class MoveDefEventUnkNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.File; } }

        [Category("MoveDef Event File")]
        public int Value { get { return _value; } set { if (_value < int.MaxValue) { _value = value; SignalPropertyChange(); } } }

        public MoveDefEventUnkNode(string name) { _name = name != null ? name : "Unknown"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Unknown";
            //MessageBox.Show(TreePath);
            base.OnInitialize();
            return false;
        }
    }
    public unsafe class MoveDefEventOffsetNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Offset; } }

        public int list, type, index;

        [Category("MoveDef Event Offset")]
        public int RawOffset
        {
            get { return _value; }
            set
            {
                //if (value < 0)
                //{
                //    _value = value;
                //    list = 4;
                //    type = -1;
                //    index = -1;
                //    SignalPropertyChange();
                //    return;
                //}
                ResourceNode r = _root.GetEntry(value);
                if (r != null && r is ActionScript)
                {
                    _value = value;
                    SignalPropertyChange();
                }
                else MessageBox.Show("An action could not be located.");
            }
        }
        [Category("MoveDef Event Offset"), Browsable(true), TypeConverter(typeof(DropDownListExtNodesMDef))]
        public string ExternalNode
        {
            get
            {
                return _externalEntry != null ? _externalEntry.Name : null;
            }
            set
            {
                if (_externalEntry != null)
                    if (_externalEntry.Name != value)
                        _externalEntry._refs.Remove(this);
                foreach (ReferenceEntry e in _root._referenceList)
                    if (e.Name == value)
                    {
                        _externalEntry = e;
                        e._references.Add(this);
                        Name = e.Name;
                        action = null;
                        list = 3;
                        index = _externalEntry.Index;
                    }

                if (_externalEntry == null)
                    Name = "Offset";
            }
        }

        public ActionScript GetAction()
        {
            ResourceNode r = _root.GetEntry(RawOffset);
            if (r != null && r is ActionScript)
                return r as ActionScript;
            return null;
        }

        public ActionScript action;

        public MoveDefEventOffsetNode(string name) { _name = name != null ? name : "Offset"; }

        public override bool OnInitialize()
        {
            base.OnInitialize();

            if (RawOffset > 0)
            {
                _root.GetActionLocation(RawOffset, out list, out type, out index);
                if (!External)
                {
                    action = _root.GetAction(list, type, index);
                    if (action == null)
                        action = GetAction();
                }
            }
            else if (RawOffset < 0 && External)
            {
                action = null;
                index = _externalEntry.Index;
                list = 3;
                type = -1;
            }
            else
            {
                action = null;
                index = -1;
                list = 4;
                type = -1;
            }

            if (_name == null)
                _name = "Offset";

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            if (action != null)
                _lookupCount = 1;
            return 8;
        }

        public override void PostProcess(LookupManager lookupOffsets)
        {
            FDefEventArgument* arg = (FDefEventArgument*)_rebuildAddr;
            arg->_type = (int)_type;
            if (action != null)
            {
                //if (action._entryOffset == 0)
                //    Console.WriteLine("Action offset = 0");
                
                arg->_data = (int)action._rebuildAddr - (int)action.RebuildBase;
                if (arg->_data > 0)
                    lookupOffsets.Add(arg->_data.Address);
            }
            else
            {
                arg->_data = -1;
                if (External)
                {
                    if (_externalEntry is MoveDefReferenceEntryNode)
                        _rebuildAddr += 4;
                }
                else
                    foreach (MoveDefReferenceEntryNode e in _root._references.Children)
                        if (e.Name == this.Name)
                        {
                            _externalEntry = e;
                            //if (!e._refs.Contains(this))
                                e._references.Add(this);
                            _rebuildAddr += 4;
                            break;
                        }
            }
        }
    }

    public unsafe class MoveDefEventScalarNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Scalar; } }

        [Category("MoveDef Event Scalar Value")]
        public float Value { get { return (float)_value / 60000f; } set { if (value * 60000f < int.MaxValue) { _value = Convert.ToInt32(value * 60000f); SignalPropertyChange(); } } }

        public MoveDefEventScalarNode(string name) { _name = name != null ? name : "Scalar"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Scalar";
            base.OnInitialize();
            return false;
        }
    }

    public unsafe class MoveDefEventBoolNode : MoveDefEventParameterNode
    {
        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Boolean; } }
        
        [Category("MoveDef Event Boolean")]
        public bool Value { get { return _value == 1 ? true : false; } set { _value = value ? 1 : 0; SignalPropertyChange(); } }

        public MoveDefEventBoolNode(string name) { _name = name != null ? name : "Boolean"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Boolean";
            base.OnInitialize();
            return false;
        }
    }

    public unsafe class MoveDefEventVariableNode : MoveDefEventParameterNode
    {
        internal string val;

        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Variable; } }

        internal int number;
        internal VarMemType mem;
        internal VariableType type;

        [Category("MoveDef Event Variable")]
        public VarMemType MemType { get { return mem; } set { mem = value; GetValue(); SignalPropertyChange(); } }
        [Category("MoveDef Event Variable")]
        public VariableType VarType { get { return type; } set { type = value; GetValue(); SignalPropertyChange(); } }
        [Category("MoveDef Event Variable")]
        public int Number { get { return number; } set { number = value; GetValue(); SignalPropertyChange(); } }

        public MoveDefEventVariableNode(string name) { _name = name != null ? name : "Variable"; }

        public override float RealValue
        {
            get
            {
                return RunTime.GetVar((int)type, (int)mem, number);
            }
        }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Variable";
            base.OnInitialize();
            val = ResolveVariable((long)_value);
            return false;
        }

        public void GetValue()
        {
            val = ResolveVariable(_value = ((int)mem * 0x10000000) + ((int)type * 0x1000000) + number.Clamp(0, 0xFFFFFF));
        }

        public enum VarMemType
        {
            IC,
            LA,
            RA
        }

        public enum VariableType
        {
            Basic,
            Float,
            Bit
        }

        public override string ToString()
        {
            return val == null ? val = ResolveVariable(_value) : val;
        }

        public string ResolveVariable(long value)
        {
            string variableName = "";
            long variableMemType = (value & 0xF0000000) / 0x10000000;
            long variableType = (value & 0xF000000) / 0x1000000;
            long variableNumber = (value & 0xFFFFFF);
            if (variableMemType == 0) { variableName = "IC-"; mem = VarMemType.IC; }
            if (variableMemType == 1) { variableName = "LA-"; mem = VarMemType.LA; }
            if (variableMemType == 2) { variableName = "RA-"; mem = VarMemType.RA; }
            if (variableType == 0) { variableName += "Basic"; type = VariableType.Basic; }
            if (variableType == 1) { variableName += "Float"; type = VariableType.Float; }
            if (variableType == 2) { variableName += "Bit"; type = VariableType.Bit; }
            variableName += "[" + (number = (int)variableNumber) + "]";

            return variableName;
        }
    }

    public unsafe class MoveDefEventRequirementNode : MoveDefEventParameterNode
    {
        internal string _val;

        [Browsable(false)]
        public override ArgVarType _type { get { return ArgVarType.Requirement; } }

        internal bool not;
        internal string arg;

        [Category("MoveDef Event Requirement"), TypeConverter(typeof(DropDownListRequirementsMDef))]
        public string Requirement { get { return arg; } set { if (Array.IndexOf(FileManager.iRequirements, value) == -1) return; arg = value; GetValue(); SignalPropertyChange(); } }
        [Category("MoveDef Event Requirement")]
        public bool Not { get { return not; } set { not = value; GetValue(); SignalPropertyChange(); } }

        public MoveDefEventRequirementNode(string name) { _name = name != null ? name : "Requirement"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Requirement";
            base.OnInitialize();
            _val = GetRequirement(_value);
            return false;
        }

        public override float RealValue
        {
            get
            {
                float value = Array.IndexOf(FileManager.iRequirements, arg);
                return value * (not ? -1 : 1);
            }
        }

        public void GetValue()
        {
            long value = Array.IndexOf(FileManager.iRequirements, arg);
            if (not) value |= (1 << 31);
            _val = GetRequirement(_value = (int)value);
        }

        public override string ToString()
        {
            return _val == null ? _val = GetRequirement(_value) : _val;
        }

        public string GetRequirement(int value)
        {
            not = ((value >> 31) & 1) == 1;
            int requirement = value & 0x7FFFFFFF;

            if (requirement >= FileManager.iRequirements.Length)
                return requirement.ToString();

            if (not == true)
                return "Not " + (arg = FileManager.iRequirements[requirement]);

            return (arg = FileManager.iRequirements[requirement]);
        }
    }

    #region htBoxes
    public unsafe class HitboxFlagsNode : MoveDefEventParameterNode
    {
        internal HitboxFlags val = new HitboxFlags();

        public string HexValue
        {
            get { return _value.ToString("X8"); }
            set { val._data = (uint)(_value = Int32.Parse(value, System.Globalization.NumberStyles.HexNumber)); }
        }

        [Category("Hitbox Flags")]
        public DataHelpers.HitboxEffect Effect { get { return (DataHelpers.HitboxEffect)val.Effect; } set { val.Effect = (uint)value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Unk1 { get { return val.Unk1; } set { val.Unk1 = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public DataHelpers.HitboxSFX Sound { get { return (DataHelpers.HitboxSFX)val.Sound; } set { val.Sound = (uint)value; SetValue(); } }
        [Category("Hitbox Flags")]
        public uint Unk2 { get { return val.Unk2; } set { val.Unk2 = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Grounded { get { return val.Grounded; } set { val.Grounded = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Aerial { get { return val.Aerial; } set { val.Aerial = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public uint Unk3 { get { return val.Unk3; } set { val.Unk3 = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public DataHelpers.HitboxType Type { get { return (DataHelpers.HitboxType)val.Type; } set { val.Type = (uint)value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Clang { get { return val.Clang; } set { val.Clang = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Unk4 { get { return val.Unk4; } set { val.Unk4 = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public bool Direct { get { return val.Direct; } set { val.Direct = value; SetValue(); } }
        [Category("Hitbox Flags")]
        public uint Unk5 { get { return val.Unk5; } set { val.Unk5 = value; SetValue(); } }

        public HitboxFlagsNode(string name) { _name = name != null ? name : "Flags"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Flags";
            base.OnInitialize();
            val._data = (uint)_value;
            return false;
        }

        private void SetValue()
        {
            _value = (int)(uint)val._data;
            SignalPropertyChange();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HitboxFlags
    {
        //0000 0000 0000 0000 0000 0000 0001 1111   Effect
        //0000 0000 0000 0000 0000 0000 0010 0000   Unknown1
        //0000 0000 0000 0000 0011 1111 1100 0000   Sound
        //0000 0000 0000 0000 1100 0000 0000 0000   Unknown2
        //0000 0000 0000 0001 0000 0000 0000 0000   Grounded
        //0000 0000 0000 0010 0000 0000 0000 0000   Aerial
        //0000 0000 0011 1100 0000 0000 0000 0000   Unknown3
        //0000 0111 1100 0000 0000 0000 0000 0000   Type
        //0000 1000 0000 0000 0000 0000 0000 0000   Clang
        //0001 0000 0000 0000 0000 0000 0000 0000   Unknown4
        //0010 0000 0000 0000 0000 0000 0000 0000   Direct
        //1100 0000 0000 0000 0000 0000 0000 0000   Unknown5

        public uint Effect { get { return _data[0, 5]; } set { _data[0, 5] = value.Clamp(0, 31); } }
        public bool Unk1 { get { return _data[5]; } set { _data[5] = value; } }
        public uint Sound { get { return _data[6, 8]; } set { _data[6, 8] = value.Clamp(0, 255); } }
        public uint Unk2 { get { return _data[14, 2]; } set { _data[14, 2] = value.Clamp(0, 3); } }
        public bool Grounded { get { return _data[16]; } set { _data[16] = value; } }
        public bool Aerial { get { return _data[17]; } set { _data[17] = value; } }
        public uint Unk3 { get { return _data[18, 4]; } set { _data[18, 4] = value.Clamp(0, 15); } }
        public uint Type { get { return _data[22, 5]; } set { _data[22, 5] = value.Clamp(0, 31); } }
        public bool Clang { get { return _data[27]; } set { _data[27] = value; } }
        public bool Unk4 { get { return _data[28]; } set { _data[28] = value; } }
        public bool Direct { get { return _data[29]; } set { _data[29] = value; } }
        public uint Unk5 { get { return _data[30, 2]; } set { _data[30, 2] = value.Clamp(0, 3); } }

        public Bin32 _data;
    }

    public unsafe class SpecialHitboxFlagsNode : MoveDefEventParameterNode
    {
        internal SpecialHitboxFlags val = new SpecialHitboxFlags();

        public string HexValue 
        {
            get { return _value.ToString("X8"); }
            set { val._data = (uint)(_value = Int32.Parse(value, System.Globalization.NumberStyles.HexNumber)); }
        }
        
        [Category("Special Hitbox Flags")]
        public uint AngleFlipping { get { return val.AngleFlipping; } set { val.AngleFlipping = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool Unk1 { get { return val.Unk1; } set { val.Unk1 = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool Stretches { get { return val.Stretches; } set { val.Stretches = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool Unk2 { get { return val.Unk2; } set { val.Unk2 = value; SetValue(); } }

        [Category("Hit Flags")]
        public bool CanHitMultiplayerCharacters { get { return val.GetHitBit(0); } set { val.SetHitBit(0, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitSSEenemies { get { return val.GetHitBit(1); } set { val.SetHitBit(1, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk1 { get { return val.GetHitBit(2); } set { val.SetHitBit(2, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk2 { get { return val.GetHitBit(3); } set { val.SetHitBit(3, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk3 { get { return val.GetHitBit(4); } set { val.SetHitBit(4, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk4 { get { return val.GetHitBit(5); } set { val.SetHitBit(5, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk5 { get { return val.GetHitBit(6); } set { val.SetHitBit(6, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitDamageableCeilings { get { return val.GetHitBit(7); } set { val.SetHitBit(7, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitDamageableWalls { get { return val.GetHitBit(8); } set { val.SetHitBit(8, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitDamageableFloors { get { return val.GetHitBit(9); } set { val.SetHitBit(9, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk6 { get { return val.GetHitBit(10); } set { val.SetHitBit(10, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk7 { get { return val.GetHitBit(11); } set { val.SetHitBit(11, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool CanHitUnk8 { get { return val.GetHitBit(12); } set { val.SetHitBit(12, value); SetValue(); } }
        [Category("Hit Flags")]
        public bool Enabled { get { return val.GetHitBit(13); } set { val.SetHitBit(13, value); SetValue(); } }

        [Category("Special Hitbox Flags")]
        public uint Unk3 { get { return val.Unk3; } set { val.Unk3 = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool CanBeShielded { get { return val.Shieldable; } set { val.Shieldable = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool CanBeAbsorbed { get { return val.Absorbable; } set { val.Absorbable = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool CanBeReflected { get { return val.Reflectable; } set { val.Reflectable = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public uint Unk4 { get { return val.Unk4; } set { val.Unk4 = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool HittingGrippedCharacter { get { return val.Gripped; } set { val.Gripped = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool IgnoreInvincibility { get { return val.IgnoreInv; } set { val.IgnoreInv = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool FreezeFrameDisable { get { return val.NoFreeze; } set { val.NoFreeze = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool PutsToSleep { get { return val.Sleep; } set { val.Sleep = value; SetValue(); } }
        [Category("Special Hitbox Flags")]
        public bool Flinchless { get { return val.Flinchless; } set { val.Flinchless = value; SetValue(); } }

        public SpecialHitboxFlagsNode(string name) { _name = name != null ? name : "Special Flags"; }

        public override bool OnInitialize()
        {
            if (_name == null)
                _name = "Special Flags";
            base.OnInitialize();
            val._data = (uint)_value;
            return false;
        }
        private void SetValue()
        {
            _value = (int)(uint)val._data;
            SignalPropertyChange();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpecialHitboxFlags
    {
        //0000 0000 0000 0000 0000 0000 0000 0111   Angle Flipping
        //0000 0000 0000 0000 0000 0000 0000 1000   Unknown1
        //0000 0000 0000 0000 0000 0000 0001 0000   Stretches
        //0000 0000 0000 0000 0000 0000 0010 0000   Unknown2

        //Hit Bits
        //               0000 0000 0000 01          Can Hit Multiplayer Characters
        //               0000 0000 0000 10          Can Hit SSE Enemies
        //               0000 0000 0001 00          Can Hit Unknown1
        //               0000 0000 0010 00          Can Hit Unknown2
        //               0000 0000 0100 00          Can Hit Unknown3
        //               0000 0000 1000 00          Can Hit Unknown4
        //               0000 0001 0000 00          Can Hit Unknown5
        //               0000 0010 0000 00          Can Hit Damageable Ceilings
        //               0000 0100 0000 00          Can Hit Damageable Walls
        //               0000 1000 0000 00          Can Hit Damageable Floors
        //               0001 0000 0000 00          Can Hit Unknown6
        //               0010 0000 0000 00          Can Hit Unknown7
        //               0100 0000 0000 00          Can Hit Unknown8
        //               1000 0000 0000 00          Enabled

        //0000 0000 0011 0000 0000 0000 0000 0000   Unknown3
        //0000 0000 0100 0000 0000 0000 0000 0000   Can be Shielded
        //0000 0000 1000 0000 0000 0000 0000 0000   Can be Reflected 
        //0000 0001 0000 0000 0000 0000 0000 0000   Can be Absorbed 
        //0000 0110 0000 0000 0000 0000 0000 0000   Unknown4
        //0000 1000 0000 0000 0000 0000 0000 0000   Hitting a gripped character
        //0001 0000 0000 0000 0000 0000 0000 0000   Ignore Invincibility
        //0010 0000 0000 0000 0000 0000 0000 0000   Freeze Frame Disable
        //0100 0000 0000 0000 0000 0000 0000 0000   Unknown5
        //1000 0000 0000 0000 0000 0000 0000 0000   Flinchless

        public uint AngleFlipping { get { return _data[0, 3]; } set { _data[0, 3] = value.Clamp(0, 7); } }
        //0, 2, 5: Regular angles; the target is always sent away from the attacker.
        //1, 3: The target is always sent the direction the attacker is facing.
        //4: The target is always sent the direction the attacker is not facing.
        //6, 7: The target is turned to the Z axis

        public bool Unk1 { get { return _data[3]; } set { _data[3] = value; } }
        public bool Stretches { get { return _data[4]; } set { _data[4] = value; } }
        public bool Unk2 { get { return _data[5]; } set { _data[5] = value; } }

        public bool GetHitBit(int index) { return _data[6 + index.Clamp(0, 13)]; }
        public void SetHitBit(int index, bool value) { _data[6 + index.Clamp(0, 13)] = value; }

        public uint Unk3 { get { return _data[20, 2]; } set { _data[20, 2] = value.Clamp(0, 3); } }
        public bool Shieldable { get { return _data[22]; } set { _data[22] = value; } }
        public bool Reflectable { get { return _data[23]; } set { _data[23] = value; } }
        public bool Absorbable { get { return _data[24]; } set { _data[24] = value; } }
        public uint Unk4 { get { return _data[25, 2]; } set { _data[25, 2] = value.Clamp(0, 3); } }
        public bool Gripped { get { return _data[27]; } set { _data[27] = value; } }
        public bool IgnoreInv { get { return _data[28]; } set { _data[28] = value; } }
        public bool NoFreeze { get { return _data[29]; } set { _data[29] = value; } }
        public bool Sleep { get { return _data[30]; } set { _data[30] = value; } }
        public bool Flinchless { get { return _data[31]; } set { _data[31] = value; } }

        public Bin32 _data;
    }
    #endregion
}
