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
using System.Audio;
using Ikarus.UI;
using System.Threading;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe partial class MoveDefActionNode : MoveDefExternalNode
    {
        public int _attachedArticleIndex = -1;

        public int 
            _loopCount = 0,
            _loopStartIndex = -1,
            _loopEndIndex = -1,
            _loopTime = 0,

            _switchStartIndex = -1,
            _switchEndIndex = -1,

            _ifIndex = 0,
            _currentIf = -1,

            _eventIndex = 0,
            _waitFrames = 0,
            _frameIndex = 0;

        public bool 
            _looping = false, 
            _runEvents = true, 
            _return = false,
            _subRoutine = false,
            _delete = false;

        public IfInfo _ifInfo;
        public List<int> _ifEndIndices = new List<int>();
        public List<HitBox> catchCollisions = new List<HitBox>();
        public List<HitBox> offensiveCollisions = new List<HitBox>();
        public List<HitBox> specialOffensiveCollisions = new List<HitBox>();

        /// <summary>
        /// Returns true if there is nothing left to execute.
        /// </summary>
        public bool Idling { get { return _eventIndex >= Children.Count; } }

        /// <summary>
        /// Advances the code frame.
        /// </summary>
        public void FrameAdvance()
        {
            //If the script is idling, there's nothing to run
            if (Idling)
            {
                _frameIndex++;
                return;
            }

            //Implement subroutines here

            //Wait around for a bit...
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
                //Start over the loop if it reaches the end
                //When the loop count reaches 0, the loop will terminate.
                if (_looping && _loopEndIndex == _eventIndex)
                {
                    _loopCount--;
                    _eventIndex = _loopStartIndex;
                }

                //Stop the loop if it's done looping or if it's running infinitely with no wait time
                if (_looping && ((_loopCount < 0 && _waitFrames <= 0) || _loopCount == 0))
                {
                    _looping = false;
                    _eventIndex = _loopEndIndex + 1;
                    _loopTime = 0;
                }
                
                //Add the effects of the current event to the scene
                RunEvent(_eventIndex++);
            }

            if (_looping)
                _loopTime++;

            _frameIndex++;
        }

        /// <summary>
        /// Sets the script frame. 
        /// The maximum script frame is not necessarily known, 
        /// but the script will simply idle if the maximum frame is exceeded.
        /// </summary>
        /// <param name="index"></param>
        public void SetFrame(int index)
        {
            //if (_actionReferencedBy != null && _delete)
            //    index -= _actionReferencedBy._subRoutineSetAt;

            Reset();
            while (_frameIndex <= index && !Idling && RunTime._runningScripts.Contains(this))
                FrameAdvance();
        }

        /// <summary>
        /// Resets all script variables back to their initial values
        /// </summary>
        public void Reset()
        {
            _eventIndex = 0;
            _frameIndex = 0;
            _waitFrames = 0;

            _looping = false;
            _loopCount = 0;
            _loopStartIndex = -1;
            _loopEndIndex = -1;
            _loopTime = 0;

            _delete = false;
            _subRoutine = false;
            _subRoutineSetAt = 0;
            subRoutine = null;
            _actionReferencedBy = null;
                        
            _switchStartIndex = -1;
            _switchEndIndex = -1;
            _cases = null;
            _defaultCaseIndex = -1;
            _caseIndices = null;

            catchCollisions = new List<HitBox>();
            offensiveCollisions = new List<HitBox>();
            specialOffensiveCollisions = new List<HitBox>();

            _ifInfo = null;
            _ifEndIndices = new List<int>();
            _ifIndex = 0;
            _currentIf = -1;
        }

        public MoveDefActionNode subRoutine = null;
        public MoveDefActionNode _actionReferencedBy = null;
        public int _subRoutineSetAt = 0;

        public List<MoveDefEventParameterNode> _cases = null;
        public List<int> _caseIndices;
        public int _defaultCaseIndex = -1;

        public static int _hurtBoxType = 0;
        public static List<MDL0BoneNode> _boneCollisions = new List<MDL0BoneNode>();

        //These events are read when we're not executing code in order to set something up
        public static readonly List<long> _runExceptions = new List<long>()
        {
            0x00050000, //Start looping
            0x000A0100, //If 1
            0x000A0200, //If 2
            0x000A0300, //If 3
            0x000A0400, //If 4
            0x000F0000, //End if
            0x000E0000, //Else
            0x000D0100, //Else if 1
            0x000D0200, //Else if 2
            0x000D0300, //Else if 3
            0x000D0400, //Else if 4
            0x00110100, //Case
            0x00120000, //Default Case
            0x00130000, //End Switch
        };

        /// <summary>
        /// Runs the event at the given event index.
        /// </summary>
        public void RunEvent(int eventIndex)
        {
            if (eventIndex >= Children.Count)
                return;
            
            int list, index, type;
            MoveDefEventNode e = Children[eventIndex] as MoveDefEventNode;
            uint eventId = e._event;

            if (!_runEvents && !_runExceptions.Contains(eventId)) 
                return;

            //Get an array of the raw parameter values
            Param[] p = e.EventData._parameters;
            
            //Code what to do for each event here.
            switch (eventId)
            {
                case 0x01000000: //Loop Rest 1 for Goto
                    Thread.Sleep(0);
                    Application.DoEvents();
                    break;
                case 0x00010100: //Synchronous Timer
                    _waitFrames = (int)DataHelpers.UnScalar(p[0]);
                    break;
                case 0x00020000: //No Operation
                    break;
                case 0x00020100: //Asynchronous Timer
                    _waitFrames = Math.Max((int)DataHelpers.UnScalar(p[0]) - _frameIndex, 0);
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
                case 0x000A0100: //If
                case 0x000A0200: //If Value
                case 0x000A0300: //If Unk
                case 0x000A0400: //If Comparison
                    if (_runEvents)
                    {
                        _currentIf = _ifIndex++;
                        _runEvents = false;
                        _ifInfo = new IfInfo();

                        int ei1 = eventIndex + 1;
                        while (true)
                        {
                            if (ei1 < Children.Count)
                            {
                                MoveDefEventNode eventNode = Children[ei1] as MoveDefEventNode;
                                if (eventNode._event == 0x000B0100 ||
                                    eventNode._event == 0x000B0200 ||
                                    eventNode._event == 0x000B0300 ||
                                    eventNode._event == 0x000B0400)
                                    ei1++;
                                else
                                    break;
                            }
                            else
                                break;
                        }
                        _ifInfo._reqIndices = new List<int>();
                        _ifInfo._reqIndices.Add(ei1);
                         
                        _ifEndIndices.Add(0);
                        RequirementInfo info1 = new RequirementInfo();
                        info1._requirement = p[0];
                        for (int i = 1; i < ((eventId >> 8) & 0xFF); i++)
                            info1._values.Add(e.Children[i] as MoveDefEventParameterNode);
                        _ifInfo._requirements = new List<List<RequirementInfo>>();
                        _ifInfo._requirements.Add(new List<RequirementInfo>());
                        _ifInfo._requirements[0].Add(info1);
                    }
                    else
                    {
                        _ifIndex++;
                    }
                    break;
                case 0x000E0000: //Else
                    if (!_runEvents)
                    {
                        if (_ifIndex == _currentIf)
                        {
                            _ifInfo._elseIndex = _eventIndex;
                        }
                    }
                    else
                    {
                        if (_ifIndex == _currentIf + 1)
                            _eventIndex = _ifInfo._endIndex;
                    }
                    break;
                case 0x000D0100: //Else If (req)
                case 0x000D0200: //Else If Value (req val)
                case 0x000D0300: //Else If Unk (req val unk)
                case 0x000D0400: //Else If Comparison (req var val var)

                    if (!_runEvents)
                    {
                        if (_ifIndex == _currentIf)
                        {
                            int ei2 = eventIndex + 1;
                            while (true)
                            {
                                if (ei2 < Children.Count)
                                {
                                    MoveDefEventNode eventNode = Children[ei2] as MoveDefEventNode;
                                    if (eventNode._event == 0x000B0100 ||
                                        eventNode._event == 0x000B0200 ||
                                        eventNode._event == 0x000B0300 ||
                                        eventNode._event == 0x000B0400)
                                        ei2++;
                                    else
                                        break;
                                }
                                else
                                    break;
                            }
                            _ifInfo._reqIndices.Add(ei2);
                        }
                    }
                    else
                    {
                        if (_ifIndex == _currentIf + 1)
                            _eventIndex = _ifInfo._endIndex;
                    }

                    if (!_runEvents && _ifIndex == _currentIf + 1)
                    {
                        RequirementInfo info2 = new RequirementInfo();
                        info2._requirement = p[0];
                        for (int i = 1; i < ((eventId >> 8) & 0xFF); i++)
                            info2._values.Add(e.Children[i] as MoveDefEventParameterNode);
                        _ifInfo._requirements.Add(new List<RequirementInfo>());
                        _ifInfo._requirements[0].Add(info2);
                    }
                    break;
                case 0x000B0100: //And If
                case 0x000B0200: //And If Value
                case 0x000B0300: //And If Unk
                case 0x000B0400: //And If Comparison
                    if (!_runEvents && _ifIndex == _currentIf + 1)
                    {
                        RequirementInfo info2 = new RequirementInfo();
                        info2._requirement = p[0];
                        for (int i = 1; i < ((eventId >> 8) & 0xFF); i++)
                            info2._values.Add(e.Children[i] as MoveDefEventParameterNode);
                        _ifInfo._requirements.Add(new List<RequirementInfo>());
                        _ifInfo._requirements[0].Add(info2);
                    }
                    break;
                case 0x000F0000: //End if
                    _ifIndex--;
                    if (!_runEvents)
                    {
                        if (_ifIndex == _currentIf)
                        {
                            _ifInfo._endIndex = _ifEndIndices[_currentIf] = eventIndex + 1;
                            _eventIndex = _ifInfo.Run();
                            _runEvents = true;
                        }
                    }
                    break;
                case 0x10050200: //Article Visiblity
                    int articleId = p[0];
                    if (articleId < 0 || articleId >= RunTime._articles.Length)
                        break;
                    ArticleInfo aInfo1 = RunTime._articles[articleId];
                    if (aInfo1._model != null)
                        aInfo1._model._visible = p[1] != 0;
                    break;
                case 0x01010000: //Loop Rest
                    _waitFrames = 1;
                    break;
                case 0x06000D00: //Offensive Collison
                case 0x062B0D00: //Thrown Collision
                    HitBox bubble1 = new HitBox(e, _attachedArticleIndex);
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
                    HitBox bubble2 = new HitBox(e, _attachedArticleIndex);
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
                    HitBox bubble3 = new HitBox(e, _attachedArticleIndex);
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
                case 0x060C0100: //Delete Catch Collision
                    foreach (HitBox ev in catchCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            catchCollisions.Remove(ev);
                            break;
                        }
                    break;
                case 0x061B0500: //Move hitbox
                    foreach (HitBox ev in offensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            ev.EventData._parameters[1] = p[1];
                            ev.EventData._parameters[6] = p[2];
                            ev.EventData._parameters[7] = p[3];
                            ev.EventData._parameters[8] = p[4];
                            break;
                        }
                    foreach (HitBox ev in specialOffensiveCollisions)
                        if (ev.HitboxID == p[0])
                        {
                            ev.EventData._parameters[1] = p[1];
                            ev.EventData._parameters[6] = p[2];
                            ev.EventData._parameters[7] = p[3];
                            ev.EventData._parameters[8] = p[4];
                            break;
                        }
                    break;
                case 0x04060100: //Set anim frame - subaction timer unaffected
                    if (_attachedArticleIndex < 0)
                        MainForm.Instance._mainControl.SetFrame((int)DataHelpers.UnScalar(p[0]));
                    else
                    {
                        //TODO
                    }
                    break;
                case 0x00070100: //Go to subroutine and return

                    //TODO

                    //Root.GetLocation(p[0], out list, out type, out index);
                    //subRoutine = Root.GetAction(list, type, index);
                    //if (subRoutine != null)
                    //{
                    //    _subRoutineSetAt = _frameIndex;
                    //    subRoutine._actionReferencedBy = this;
                    //    subRoutine._subRoutine = true;
                    //}
                    break;
                case 0x00080000: //Return
                    _return = true;
                    _eventIndex = Children.Count;
                    break;
                case 0x00090100: //Go to and do not return unless called
                    Root.GetLocation(p[0], out list, out type, out index);
                    MoveDefActionNode a = Root.GetAction(list, type, index);
                    if (a != null)
                    {
                        //if (RunTime.ScriptWindow.scriptEditor1.TargetNode == this)
                        //    RunTime.ScriptWindow.scriptEditor1.TargetNode = a;

                        RunTime._runningScripts.Remove(this);
                        a.Reset();
                        RunTime._runningScripts.Add(a);
                    }
                    break;
                case 0x0A030100: //Stop sound
                    int soundID1 = p[0];
                    if (RunTime._playingSounds.ContainsKey(soundID1))
                    {
                        List<AudioInfo> aList = RunTime._playingSounds[soundID1];
                        foreach (AudioInfo aInfo in aList)
                            if (aInfo._buffer != null)
                            {
                                aInfo._buffer.Stop();
                                aInfo._buffer.Dispose();
                                aInfo._stream.Dispose();
                                
                            }
                        RunTime._playingSounds.Remove(soundID1);
                    }
                    break;
                case 0x0A000100: //Play sound
                case 0x0A010100:
                case 0x0A020100:
                case 0x0A040100:
                case 0x0A050100:
                case 0x0A060100:
                case 0x0A070100:
                case 0x0A080100:
                case 0x0A090100:
                case 0x0A0A0100:
                case 0x0A0B0100:
                case 0x0A0C0100:
                case 0x0A0D0100:
                case 0x0A0E0100:
                case 0x0A0F0100:

                    if (RunTime._muteSFX)
                        break;

                    int soundID2 = p[0];
                    if (FileManager.SoundArchive != null)
                    {
                        RSARNode node = FileManager.SoundArchive;
                        List<RSAREntryNode> sounds = node._infoCache[0];
                        if (soundID2 >= 0 && soundID2 < sounds.Count)
                        {
                            RSARSoundNode s = sounds[soundID2] as RSARSoundNode;
                            if (s != null)
                            {
                                IAudioStream stream = s.CreateStreams()[0];
                                AudioBuffer b = FileManager._audioProvider.CreateBuffer(stream);
                                AudioInfo info = new AudioInfo(b, stream);

                                if (RunTime._playingSounds.ContainsKey(soundID2))
                                    RunTime._playingSounds[soundID2].Add(info);
                                else
                                    RunTime._playingSounds[soundID2] = new List<AudioInfo>() { info };
                                
                                b.Reset();
                                b.Seek(0);
                                b.Play();
                            }
                        }
                    }
                    break;
                case 0x0B000200: //Model Changer 1
                case 0x0B010200: //Model Changer 2

                    MoveDefModelVisibilityNode visNode = null;
                    if (_attachedArticleIndex >= 0)
                    {
                        //Check if we have data to work with
                        ArticleInfo a1 = RunTime._articles[_attachedArticleIndex];

                        if (a1._model == null) break;
                        if (a1._model._objList == null) break;
                        if (a1._article._mdlVis == null) break;
                        if (a1._article._mdlVis.Children.Count == 0) break;

                        visNode = a1._article._mdlVis;
                    }
                    else
                    {
                        //Check if we have data to work with
                        if (Root._model._objList == null) break;
                        if (Root._data.mdlVisibility.Children.Count == 0) break;

                        visNode = Root._data.mdlVisibility;
                    }

                    //Get the target reference
                    MoveDefModelVisRefNode refEntry = Root._data.mdlVisibility.Children[((int)(eventId >> 16 & 1))] as MoveDefModelVisRefNode;

                    //Check if the reference and switch id is usable
                    if (refEntry.Children.Count == 0 || p[0] < 0 || p[0] >= refEntry.Children.Count) break;

                    //Turn off objects
                    MoveDefBoneSwitchNode SwitchNode = refEntry.Children[p[0]] as MoveDefBoneSwitchNode;
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
                    if (_attachedArticleIndex < 0)
                        Root._model._visible = p[0] != 0;
                    else if (_attachedArticleIndex < RunTime._articles.Length && RunTime._articles[_attachedArticleIndex]._model != null)
                        RunTime._articles[_attachedArticleIndex]._model._visible = p[0] != 0;
                    break;
                case 0x00100200: //Switch
                    _cases = new List<MoveDefEventParameterNode>();
                    _caseIndices = new List<int>();
                    _runEvents = false;
                    _switchStartIndex = eventIndex;
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
                        _eventIndex = _switchEndIndex + 1;
                        _switchEndIndex = -1;
                    }
                    break;
                case 0x00120000: //Default Case
                    _defaultCaseIndex = e.Index;
                    break;
                case 0x00130000: //End Switch
                    _runEvents = true;
                    _switchEndIndex = e.Index;

                    //Apply cases
                    int i2 = 0;
                    MoveDefEventParameterNode Switch = Children[_switchStartIndex].Children[1] as MoveDefEventParameterNode;
                    foreach (MoveDefEventParameterNode param in _cases)
                    {
                        if (Switch.Compare(param, 2))
                        {
                            _eventIndex = _caseIndices[i2] + 1;
                            break;
                        }
                        i2++;
                    }

                    if (i2 == _cases.Count && _defaultCaseIndex != -1)
                        _eventIndex = _defaultCaseIndex + 1;
                    
                    _defaultCaseIndex = -1;
                    _switchStartIndex = -1;
                    _cases = null;

                    break;
                case 0x00180000: //Break
                    _eventIndex = _switchEndIndex + 1;
                    _switchEndIndex = -1;
                    break;
                case 0x10000100: //Generate Article 
                case 0x10000200: //Generate Article 
                case 0x10030100: //Remove Article

                    //These events do a similar job!
                    bool removeArticle = ((eventId >> 16) & 0xFF) == 3;

                    //Make sure we have all the data we need available
                    MainControl main = MainForm.Instance._mainControl;
                    MoveDefNode mNode = FileManager.Moveset;
                    if (mNode == null)
                        break;
                    MoveDefDataNode d = mNode._data;
                    if (d == null)
                        break;

                    //Get the id of the article to be called and check it
                    int aId2 = p[0];
                    if (aId2 < 0 || aId2 >= RunTime._articles.Length)
                        break;

                    //Get the called article from the article list
                    ArticleInfo articleInfo = RunTime._articles[aId2];

                    //Remove or add the article
                    if (removeArticle)
                    {
                        if (!articleInfo.Running)
                            return;

                        //Remove the article's model from the scene
                        if (articleInfo._model != null)
                        {
                            main.RemoveTarget(articleInfo._model);
                            articleInfo._model._visible = false;
                        }

                        //This article is no longer available for use
                        articleInfo.Running = false;
                    }
                    else
                    {
                        if (articleInfo.Running)
                            return;

                        //Add the article's model to the scene
                        if (articleInfo._model != null)
                        {
                            main.AddTarget(articleInfo._model);
                            articleInfo._model._visible = true;
                        }

                        //This article is now available for use
                        articleInfo.Running = true;                      
                    }
                    break;
                case 0x10040200: //Set Anchored Article SubAction
                case 0x10070200: //Set Remote Article SubAction
                    int aId3 = p[0];
                    int sId = p[1];
                    if (aId3 < 0 || aId3 >= RunTime._articles.Length)
                        break;
                    
                    //Get the called article from the article list
                    ArticleInfo articleInfo2 = RunTime._articles[aId3];
                    articleInfo2.SubactionIndex = sId;
                    articleInfo2._setAt = _frameIndex + 1;

                    break;
                case 0x10010200: //Set Ex-Anchored Article Action
                    break;
            }
        }
        
        /// <summary>
        /// Evaluates a requirement using the info given.
        /// </summary>
        /// <returns>Whether the requirement returned true or false</returns>
        public static bool ApplyRequirement(RequirementInfo info)
        {
            bool not = ((info._requirement >> 31) & 1) == 1;
            long req = info._requirement & 0xFF;
            
            if (req > 0x7F)
                return false;

            switch (req)
            {
                case 3:
                    return RunTime._location == RunTime.Location.Ground;
                case 4:
                    return RunTime._location == RunTime.Location.Air;
                case 21: //Article Exists
                    int aId = (int)info._values[0].RealValue;
                    if (aId < 0 || aId >= RunTime._articles.Length)
                        break;
                    return RunTime._articles[aId].Running;
            }

            return false;
        }
    }
}
