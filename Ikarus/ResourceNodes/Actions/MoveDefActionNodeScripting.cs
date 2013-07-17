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
    public unsafe partial class MoveDefActionNode : MoveDefExternalNode
    {
        //Variable storage. Order: RA, LA, IC
        public static int[][] BasicVars = new int[3][];
        public static float[][] FloatVars = new float[3][];
        public static bool[][] BitVars = new bool[3][];

        public List<HitBox> catchCollisions = new List<HitBox>();
        public List<HitBox> offensiveCollisions = new List<HitBox>();
        public List<HitBox> specialOffensiveCollisions = new List<HitBox>();
        public int _eventIndex = 0, _loopCount = -1, _loopStartIndex = -1, _loopEndIndex = -1, _loopTime = 0;
        public bool _looping = false, _runEvents = true, _return = false, _idling = false, _subRoutine = false, _delete = false;
        public int _waitFrames = 0, _frameIndex = 0;

        public static List<MoveDefActionNode> _runningActions = new List<MoveDefActionNode>();

        /// <summary>
        /// Advances the code frame.
        /// </summary>
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
                RunEvent(_eventIndex++);
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

        /// <summary>
        /// Runs the event at the given index.
        /// </summary>
        public void RunEvent(int eventIndex)
        {
            if (eventIndex >= Children.Count)
                return;
            
            int list, index, type;
            MoveDefEventNode e = Children[eventIndex] as MoveDefEventNode;

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
                    if (Root._model != null && Root._model._linker.BoneCache.Length > id && id >= 0)
                    {
                        MDL0BoneNode bone = Root._model._linker.BoneCache[id] as MDL0BoneNode;
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
                    MainForm.Instance._mainControl.SetFrame((int)Helpers.UnScalar(p[0]));
                    break;
                case 0x00070100: //Go to subroutine and return
                    break;
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
                    break;
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

                    //Check if we have data to work with
                    if (Root._model._objList == null) break;
                    if (Root._data.mdlVisibility.Children.Count == 0) break;

                    //Get the target reference
                    MoveDefModelVisRefNode entry = Root._data.mdlVisibility.Children[((int)(e._event >> 16 & 1))] as MoveDefModelVisRefNode;
                    
                    //Check if the reference and switch id is usable
                    if (entry.Children.Count == 0 || p[0] < 0 && p[0] >= entry.Children.Count) break;

                    //Turn off objects
                    MoveDefBoneSwitchNode SwitchNode = entry.Children[p[0]] as MoveDefBoneSwitchNode;
                    foreach (MoveDefModelVisGroupNode grp in SwitchNode.Children)
                        foreach (MoveDefBoneIndexNode b in grp.Children)
                            if (b.BoneNode != null)
                                foreach (MDL0ObjectNode obj in b.BoneNode._manPolys)
                                    obj._render = false;

                    //Check if the group id is usable
                    if (p[1] > SwitchNode.Children.Count || p[1] < 0) break;

                    //Turn on objects
                    MoveDefModelVisGroupNode Group = SwitchNode.Children[p[1]] as MoveDefModelVisGroupNode;
                    foreach (MoveDefBoneIndexNode b in Group.Children)
                        if (b.BoneNode != null)
                            foreach (MDL0ObjectNode obj in b.BoneNode._manPolys)
                                obj._render = true;

                    break;
                case 0x0B020100: //Model visibility
                    Root._model._visible = p[0] != 0;
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
    }
}
