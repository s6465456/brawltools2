using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using System.Runtime.InteropServices;
using BrawlLib.OpenGL;
using System.Windows.Forms;
using System.Drawing;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class MoveDefSubActionGroupNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefSubActionGroup; } }
        public override bool AllowDuplicateNames { get { return true; } }
        public override string ToString() { return Name; }

        public AnimationFlags _flags;
        public byte _inTransTime;

        [Category("Sub Action")]
        public AnimationFlags Flags { get { return _flags; } set { _flags = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public byte InTranslationTime { get { return _inTransTime; } set { _inTransTime = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public int ID { get { return Index; } }
    }
    public class MoveDefActionGroupNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefActionGroup; } }
        public override string ToString() { return Name; }

        [Category("Action")]
        public int ID { get { return Index; } }
    }
    public unsafe class MoveDefActionNode : MoveDefExternalNode
    {
        internal FDefEvent* Header { get { return (FDefEvent*)WorkingUncompressed.Address; } }
        public override string ToString() { if (Name.StartsWith("SubRoutine")) return Name; else return base.ToString(); }

        public bool _isBlank = false;
        public bool _build = false;
        [Category("Script")]
        public bool ForceWrite { get { return _build; } set { _build = value; } }
        
        public List<ResourceNode> _actionRefs = new List<ResourceNode>();
        public ResourceNode[] ActionRefs { get { return _actionRefs.ToArray(); } }

        public MoveDefActionNode(string name, bool blank, ResourceNode parent) 
        {
            _name = name;
            _isBlank = blank;
            _build = false;
            if (_isBlank) //Initialize will not be called, because there is no data to read
            {
                _parent = parent;

                if (_name == null)
                {
                    if (Parent.Parent.Name == "Action Scripts")
                    {
                        if (Index == 0)
                            _name = "Entry";
                        else if (Index == 1)
                            _name = "Exit";
                    }
                    else if (Parent.Parent.Name == "SubAction Scripts")
                    {
                        if (Index == 0)
                            _name = "Main";
                        else if (Index == 1)
                            _name = "GFX";
                        else if (Index == 2)
                            _name = "SFX";
                        else if (Index == 3)
                            _name = "Other";
                    }
                    if (_name == null)
                        _name = "Action" + Index;
                }
            }
        }

        public override bool OnInitialize()
        {
            _offsets.Add(_offset);
            _build = true;
            if (_offset > Root.dataSize)
                return false;
            if (_name == null)
            {
                if (Parent.Parent.Name == "Action Scripts")
                {
                    if (Index == 0)
                        _name = "Entry";
                    else if (Index == 1)
                        _name = "Exit";
                }
                else if (Parent.Parent.Name == "SubAction Scripts")
                {
                    if (Index == 0)
                        _name = "Main";
                    else if (Index == 1)
                        _name = "GFX";
                    else if (Index == 2)
                        _name = "SFX";
                    else if (Index == 3)
                        _name = "Other";
                }
                if (_name == null)
                    _name = "Action" + Index;
            }

            base.OnInitialize();

            //Root._paths[_offset] = TreePath;

            return (Header->_nameSpace != 0 || Header->_id != 0);
        }

        public override void OnPopulate()
        {
            FDefEvent* ev = Header;
            if (!_isBlank)
            while (ev->_nameSpace != 0 || ev->_id != 0)
                new MoveDefEventNode().Initialize(this, new DataSource(((VoidPtr)ev++), 8));

            SetSizeInternal(Children.Count * 8 + 8);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            int size = 8; //Terminator event size
            foreach (MoveDefEventNode e in Children)
            {
                if (e.EventID == 0xFADEF00D || e.EventID == 0xFADE0D8A) continue;
                size += e.CalculateSize(true);
                _lookupCount += e._lookupCount;
            }
            return size;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            int off = 0;
            foreach (MoveDefEventNode e in Children)
                off += e.Children.Count * 8;

            FDefEventArgument* paramAddr = (FDefEventArgument*)address;
            FDefEvent* eventAddr = (FDefEvent*)(address + off);

            _entryOffset = eventAddr;

            foreach (MoveDefEventNode e in Children)
            {
                if (e._name == "FADEF00D" || e._name == "FADE0D8A") continue;
                e._entryOffset = eventAddr;
                *eventAddr = new FDefEvent() { _id = e.id, _nameSpace = e.nameSpace, _numArguments = (byte)e.Children.Count, _unk1 = e.unk1 };
                if (e.Children.Count > 0)
                {
                    eventAddr->_argumentOffset = (uint)paramAddr - (uint)_rebuildBase;
                    _lookupOffsets.Add((int)eventAddr->_argumentOffset.Address - (int)_rebuildBase);
                }
                else
                    eventAddr->_argumentOffset = 0;
                eventAddr++;
                foreach (MoveDefEventParameterNode p in e.Children)
                {
                    p._entryOffset = paramAddr;
                    if (p._type != ArgVarType.Offset)
                        *paramAddr = new FDefEventArgument() { _type = (int)p._type, _data = p._value };
                    else
                    {
                        Root._postProcessNodes.Add(p);
                        //if ((p as MoveDefEventOffsetNode).action != null)
                        //    _lookupOffsets.Add(0);
                    }
                    paramAddr++;
                }
            }

            eventAddr++; //Terminate
        }

        #region Scripting
        public List<HitBox> catchCollisions = new List<HitBox>();
        public List<HitBox> offensiveCollisions = new List<HitBox>();
        public List<HitBox> specialOffensiveCollisions = new List<HitBox>();
        public int _eventIndex = 0, _loopCount = -1, _loopStartIndex = -1, _loopEndIndex = -1, _loopTime = 0;
        public bool _looping = false, _runEvents = true, _return = false, _idling = false, _subRoutine = false, _delete = false;
        public int _waitFrames = 0, _frameIndex = 0;

        public static List<MoveDefActionNode> _runningActions = new List<MoveDefActionNode>();

        public void FrameAdvance()
        {
            if (_eventIndex >= Children.Count)
            {
                _idling = true;
                if (_delete)
                {
                    _runningActions.Remove(this);
                    Reset();
                }
                _frameIndex++;
                return;
            }

            string name = Parent.Name;
            string fillername = subRoutine == null ? "" : subRoutine.Parent.Name;

            if (subRoutine != null && _frameIndex >= _subRoutineSetAt)
                if (subRoutine == this || subRoutine == _actionReferencedBy || name == fillername || (_subRoutine && _idling))
                {
                    _return = true;
                    _eventIndex = Children.Count;
                }
                else
                {
                    subRoutine.FrameAdvance();
                    _frameIndex++;
                    if (subRoutine._return || subRoutine._eventIndex == subRoutine.Children.Count)
                    {
                        subRoutine.Reset();
                        subRoutine = null;
                        _subRoutineSetAt = 0;
                    }
                    return;
                }

            if (_waitFrames > 0)
            {
                _waitFrames--;
                if (_waitFrames > 0)
                {
                    _frameIndex++;
                    if (_looping)
                        _loopTime++;
                    return;
                }
            }

            //Progress until the next wait event
            while (_waitFrames == 0 && _eventIndex < Children.Count && subRoutine == null)
            {
                if (_looping && _loopEndIndex == _eventIndex)
                {
                    _loopCount--;
                    _eventIndex = _loopStartIndex;
                }
                if (_looping && _loopCount == 0)
                {
                    _looping = false;
                    _eventIndex = _loopEndIndex + 1;
                    _loopTime = 0;
                }
                Advance(_eventIndex++);
            }

            if (_looping)
                _loopTime++;

            _frameIndex++;
        }

        public void SetFrame(int index)
        {
            Reset();
            if (_actionReferencedBy != null && _delete)
                index -= _actionReferencedBy._subRoutineSetAt;
            while (_frameIndex <= index)
                FrameAdvance();
        }

        public void Reset()
        {
            _eventIndex = 0;
            _looping = false;
            _frameIndex = 0;
            _loopCount = -1;
            _loopStartIndex = -1;
            _loopEndIndex = -1;
            _loopTime = 0;
            _waitFrames = 0;
            catchCollisions = new List<HitBox>();
            offensiveCollisions = new List<HitBox>();
            specialOffensiveCollisions = new List<HitBox>();
            _idling = false;
            _delete = false;
            _subRoutine = false;
            _subRoutineSetAt = 0;
            subRoutine = null;
            _actionReferencedBy = null;
            _caseIndices = null;
            _defaultCaseIndex = -1;
            _cases = null;

            //if (scriptEditor1.EventList.Items.Count > 0)
            //    scriptEditor1.EventList.SelectedIndex = 0;
        }

        public MoveDefActionNode subRoutine = null;
        public MoveDefActionNode _actionReferencedBy = null;
        public int _subRoutineSetAt = 0;

        public List<MoveDefEventParameterNode> _cases = null;
        public List<int> _caseIndices;
        public int _defaultCaseIndex = -1;

        public static int _hurtBoxType = 0;
        public static List<MDL0BoneNode> _boneCollisions = new List<MDL0BoneNode>();

        public void Advance(int eventid)
        {
            if (eventid >= Children.Count)
                return;

            int list, index, type;
            MoveDefEventNode e = Children[eventid] as MoveDefEventNode;

            if (!_runEvents && 
                e._event != 0x00050000 && 
                e._event != 0x00110100 && 
                e._event != 0x00120000 && 
                e._event != 0x00130000)
                return;

            Param[] p = e.EventData.parameters;

            //Code what to do for each event here.
            switch (e._event)
            {
                case 0x00010100: //Synchronous Timer
                    _waitFrames = (int)Helpers.UnScalar(p[0]);
                    break;
                case 0x00020000: //No Operation
                    break;
                case 0x00020100: //Asynchronous Timer
                    _waitFrames = Math.Max((int)Helpers.UnScalar(p[0]) - _frameIndex, 0);
                    break;
                case 0x00040100: //Set loop data
                    _loopCount = p[0];
                    _loopStartIndex = e.Index + 1;
                    _runEvents = false;
                    break;
                case 0x00050000: //Start looping
                    _looping = true;
                    _loopEndIndex = e.Index;
                    _eventIndex = _loopStartIndex;
                    _runEvents = true;
                    break;
                case 0x01010000: //Loop Rest
                    _waitFrames = 1;
                    break;
                case 0x06000D00: //Offensive Collison
                case 0x062B0D00: //Thrown Collision
                    HitBox bubble1 = new HitBox(e);
                    bubble1.HitboxID = (int)(p[0] & 0xFFFF);
                    bubble1.HitboxSize = p[5];
                    offensiveCollisions.Add(bubble1);
                    break;
                case 0x06050100: //Body Collision
                    _hurtBoxType = p[0];
                    break;
                case 0x06080200: //Bone Collision
                    int id = p[0];
                    if (Root.Model != null && Root.Model._linker.BoneCache.Length > id && id >= 0)
                    {
                        MDL0BoneNode bone = Root.Model._linker.BoneCache[id] as MDL0BoneNode;
                        switch ((int)p[1])
                        {
                            case 0:
                                bone._nodeColor = Color.Transparent;
                                bone._boneColor = Color.Transparent;
                                break;
                            case 1:
                                bone._nodeColor = bone._boneColor = Color.FromArgb(255, 255, 0);
                                break;
                            default:
                                bone._nodeColor = bone._boneColor = Color.FromArgb(0, 0, 255);
                                break;
                        }
                        _boneCollisions.Add(bone);
                    }
                    break;
                case 0x06060100: //Undo Bone Collision
                    foreach (MDL0BoneNode bone in _boneCollisions)
                        bone._nodeColor = bone._boneColor = Color.Transparent;
                    _boneCollisions = new List<MDL0BoneNode>();
                    break;
                case 0x060A0800: //Catch Collision 1
                case 0x060A0900: //Catch Collision 2
                case 0x060A0A00: //Catch Collision 3
                    HitBox bubble2 = new HitBox(e);
                    bubble2.HitboxID = p[0];
                    bubble2.HitboxSize = p[2];
                    catchCollisions.Add(bubble2);
                    break;
                case 0x060D0000: //Terminate Catch Collisions
                    catchCollisions = new List<HitBox>();
                    break;
                case 0x00060000: //Loop break?
                    _looping = false;
                    _eventIndex = _loopEndIndex + 1;
                    _loopTime = 0;
                    break;
                case 0x06150F00: //Special Offensive Collison
                    HitBox bubble3 = new HitBox(e);
                    bubble3.HitboxID = (int)(p[0] & 0xFFFF);
                    bubble3.HitboxSize = p[5];
                    specialOffensiveCollisions.Add(bubble3);
                    break;
                case 0x06040000: //Terminate Collisions
                    offensiveCollisions = new List<HitBox>();
                    specialOffensiveCollisions = new List<HitBox>();
                    break;
                case 0x06030100: //Delete hitbox
                    foreach (HitBox ev in offensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            offensiveCollisions.Remove(ev);
                            break;
                        }
                    foreach (HitBox ev in specialOffensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            specialOffensiveCollisions.Remove(ev);
                            break;
                        }
                    break;
                case 0x061B0500: //Move hitbox
                    foreach (HitBox ev in offensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            ev.EventData.parameters[1] = p[1];
                            ev.EventData.parameters[6] = p[2];
                            ev.EventData.parameters[7] = p[3];
                            ev.EventData.parameters[8] = p[4];
                            break;
                        }
                    foreach (HitBox ev in specialOffensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            ev.EventData.parameters[1] = p[1];
                            ev.EventData.parameters[6] = p[2];
                            ev.EventData.parameters[7] = p[3];
                            ev.EventData.parameters[8] = p[4];
                            break;
                        }
                    break;
                case 0x04060100: //Set anim frame - subaction timer unaffected
                    //_mainWindow.SetFrame((int)Helpers.UnScalar(p[0]));
                    break;
                case 0x00070100: //Go to subroutine and return
                    Root.GetLocation(p[0], out list, out type, out index);
                    subRoutine = Root.GetAction(list, type, index);
                    if (subRoutine != null)
                    {
                        _subRoutineSetAt = _frameIndex;
                        subRoutine._actionReferencedBy = this;
                        subRoutine._subRoutine = true;
                    }
                    break;
                case 0x00080000: //Return
                    _return = true;
                    _eventIndex = Children.Count;
                    _idling = true;
                    break;
                case 0x00090100: //Go to and do not return unless called
                    Root.GetLocation(p[0], out list, out type, out index);
                    MoveDefActionNode a = Root.GetAction(list, type, index);
                    if (a != null)
                    {
                        _subRoutineSetAt = _frameIndex;
                        a._actionReferencedBy = this;
                        a._delete = true;
                       //MainForm.Instance pnlMoveset.selectedActionNodes.Add(a);
                        //if (_eventIndex == Children.Count)
                       //     _mainWindow.pnlMoveset.selectedActionNodes.Remove(this);
                    }
                    break;
                case 0x0B000200: //Model Changer 1
                case 0x0B010200: //Model Changer 2
                    if (Root.Model._polyList == null)  break;
                    if (Root.data.mdlVisibility.Children.Count == 0) break;
                    MoveDefModelVisRefNode entry = Root.data.mdlVisibility.Children[((int)(e._event >> 16 & 1))] as MoveDefModelVisRefNode;
                    if (entry.Children.Count == 0 || p[0] < 0 && p[0] >= entry.Children.Count) break;
                    MoveDefBoneSwitchNode SwitchNode = entry.Children[p[0]] as MoveDefBoneSwitchNode;
                    foreach (MoveDefModelVisGroupNode grp in SwitchNode.Children)
                        foreach (MoveDefBoneIndexNode b in grp.Children)
                            if (b.BoneNode != null)
                                foreach (MDL0ObjectNode x in b.BoneNode._manPolys)
                                    x._render = false;
                    if (p[1] > SwitchNode.Children.Count || p[1] < 0) break;
                    MoveDefModelVisGroupNode Group = SwitchNode.Children[p[1]] as MoveDefModelVisGroupNode;
                    foreach (MoveDefBoneIndexNode b in Group.Children)
                        if (b.BoneNode != null)
                            foreach (MDL0ObjectNode x in b.BoneNode._manPolys)
                                x._render = true;
                    break;
                case 0x0B020100:
                    Root.Model._visible = p[0] != 0;
                    break;
                case 0x00100200: //Switch
                    _cases = new List<MoveDefEventParameterNode>();
                    _caseIndices = new List<int>();
                    _runEvents = false;
                    _loopStartIndex = e.Index;
                    break;
                case 0x00110100: //Case
                    if (!_runEvents)
                    {
                        if (_cases != null && _caseIndices != null)
                        {
                            _cases.Add(e.Children[0] as MoveDefEventParameterNode);
                            _caseIndices.Add(e.Index);
                        }
                    }
                    else
                    {
                        _eventIndex = _loopEndIndex + 1;
                        _loopEndIndex = -1;
                    }
                    break;
                case 0x00120000: //Default Case
                    _defaultCaseIndex = e.Index;
                    break;
                case 0x00130000: //End Switch
                    _runEvents = true;
                    _loopEndIndex = e.Index;
                    //Apply cases
                    int i = 0;
                    MoveDefEventParameterNode Switch = Children[_loopStartIndex].Children[1] as MoveDefEventParameterNode;
                    foreach (MoveDefEventParameterNode param in _cases)
                    {
                        if (Switch.Compare(param, 2))
                        {
                            _eventIndex = _caseIndices[i] + 1;
                            break;
                        }
                        i++;
                    }
                    if (i == _cases.Count && _defaultCaseIndex != -1)
                        _eventIndex = _defaultCaseIndex + 1;
                    _cases = null;
                    _defaultCaseIndex = -1;
                    _loopStartIndex = -1;
                    break;
                case 0x00180000: //Break
                    _eventIndex = _loopEndIndex + 1;
                    _loopEndIndex = -1;
                    break;
                case 10000200: //Generate Article 
                    break;
                case 0x10040200: //Set Anchored Article SubAction
                case 0x10070200: //Set Remote Article SubAction
                    break;
                case 0x10010200: //Set Ex-Anchored Article Action
                    break;
            }
        }
        #endregion
    }
}
