using BrawlLib.SSBB.ResourceNodes;
using Ikarus.UI;
using System;
using System.Audio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ikarus
{
    /// <summary>
    /// Info for displaying and animating articles.
    /// </summary>
    public class ArticleInfo
    {
        [Browsable(false)]
        public MoveDefArticleNode _article;
        [Browsable(false)]
        public MDL0Node _model;
        [Browsable(false)]
        public List<CHR0Node> _chr0List;
        [Browsable(false)]
        public List<SRT0Node> _srt0List;
        [Browsable(false)]
        public List<SHP0Node> _shp0List;
        [Browsable(false)]
        public List<VIS0Node> _vis0List;
        [Browsable(false)]
        public List<PAT0Node> _pat0List;
        [Browsable(false)]
        public List<CLR0Node> _clr0List;

        public int _animFrame = 1, _maxFrame, _setAt;

        public CHR0Node _chr0;
        public SRT0Node _srt0;
        public SHP0Node _shp0;
        public PAT0Node _pat0;
        public VIS0Node _vis0;
        public CLR0Node _clr0;

        public SubActionGroup _currentSubaction = null;
        public ActionGroup _currentAction = null;
        public SubActionGroup CurrentSubaction
        {
            get { return _currentSubaction; }
            set
            {
                _currentSubaction = value;

                //Reset all of the subaction-dependent variables
                ResetSubactionVariables();
            }
        }

        public ActionGroup CurrentAction
        {
            get { return _currentAction; }
            set
            {
                _currentAction = value;
            }
        }

        private void LoadSubactionScripts()
        {
            if (CurrentSubaction != null)
            {
                for (int i = 0; i < RunTime._runningScripts.Count; i++)
                    if (RunTime._runningScripts[i]._attachedArticleIndex >= 0)
                        RunTime._runningScripts.RemoveAt(i);
                
                foreach (ActionScript a in CurrentSubaction.Children)
                {
                    RunTime._runningScripts.Add(a);
                    a.Reset();
                }
            }
        }

        public void ResetSubactionVariables()
        {
            //Reload scripts
            LoadSubactionScripts();

            //Reset model visiblity to its default state
            if (_model != null && _model._objList != null && _article._mdlVis != null)
            {
                MoveDefModelVisibilityNode node = _article._mdlVis;
                if (node.Children.Count != 0)
                {
                    MoveDefModelVisRefNode entry = node.Children[0] as MoveDefModelVisRefNode;

                    //First, disable bones
                    foreach (MoveDefBoneSwitchNode Switch in entry.Children)
                        foreach (MoveDefModelVisGroupNode Group in Switch.Children)
                            if (Group.Index != Switch.defaultGroup)
                                foreach (MoveDefBoneIndexNode b in Group.Children)
                                    if (b.BoneNode != null)
                                        foreach (MDL0ObjectNode p in b.BoneNode._manPolys)
                                            p._render = false;

                    //Now, enable bones
                    foreach (MoveDefBoneSwitchNode Switch in entry.Children)
                        foreach (MoveDefModelVisGroupNode Group in Switch.Children)
                            if (Group.Index == Switch.defaultGroup)
                                foreach (MoveDefBoneIndexNode b in Group.Children)
                                    if (b.BoneNode != null)
                                        foreach (MDL0ObjectNode p in b.BoneNode._manPolys)
                                            p._render = true;
                }
            }
        }

        private bool _running = false;
        public bool _etcModel = true; //If false, this article should be visible by default

        public int CurrentFrame
        {
            get { return _animFrame; }
            set
            {
                _animFrame = value;

                UpdateModel();
            }
        }

        public void ProgressFrame()
        {
            CurrentFrame = _animFrame + 1;
        }

        public void SetFrame(int index)
        {
            CurrentFrame = (index + 1 - _setAt);
        }

        private AnimationNode GetAnim(AnimationNode[] arr, string name)
        {
            foreach (AnimationNode n in arr)
                if (n.Name.Contains(name))
                    return n;
            return null;
        }

        private int _subaction = -1;
        public int SubactionIndex 
        {
            get { return _subaction; } 
            set
            {
                if ((_subaction = value) >= 0 && _article._subActions != null && _subaction < _article._subActions.Children.Count)
                {
                    CurrentSubaction = _article._subActions.Children[_subaction] as SubActionGroup;
                    if (CurrentSubaction != null)
                    {
                        _chr0 = GetAnim(_chr0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as CHR0Node;
                        _srt0 = GetAnim(_srt0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as SRT0Node;
                        _pat0 = GetAnim(_pat0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as PAT0Node;
                        _vis0 = GetAnim(_vis0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as VIS0Node;
                        _shp0 = GetAnim(_shp0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as SHP0Node;
                        _clr0 = GetAnim(_clr0List.ToArray<AnimationNode>(), CurrentSubaction.Name) as CLR0Node;

                        _maxFrame = _chr0.FrameCount;
                    }
                }
                CurrentFrame = 0;
            }
        }

        public bool Running { get { return _running; } set { _running = value; } }
        public bool ModelVisible { get { return _model == null ? false : _model._visible; } set { if (_model == null) return; _model._visible = value; } }

        public void UpdateModel()
        {
            if (_model == null || !_running)
                return;

            MainControl ctrl = MainForm.Instance._mainControl;

            if (_chr0 != null && !(ctrl.TargetAnimType != AnimType.CHR && !ctrl.playCHR0ToolStripMenuItem.Checked) && _subaction >= 0)
                _model.ApplyCHR(_chr0, _animFrame);
            else
                _model.ApplyCHR(null, 0);
            if (_srt0 != null && !(ctrl.TargetAnimType != AnimType.SRT && !ctrl.playSRT0ToolStripMenuItem.Checked))
                _model.ApplySRT(_srt0, _animFrame);
            else
                _model.ApplySRT(null, 0);
            if (_shp0 != null && !(ctrl.TargetAnimType != AnimType.SHP && !ctrl.playSHP0ToolStripMenuItem.Checked))
                _model.ApplySHP(_shp0, _animFrame);
            else
                _model.ApplySHP(null, 0);
            if (_pat0 != null && !(ctrl.TargetAnimType != AnimType.PAT && !ctrl.playPAT0ToolStripMenuItem.Checked))
                _model.ApplyPAT(_pat0, _animFrame);
            else
                _model.ApplyPAT(null, 0);
            if (_vis0 != null && !(ctrl.TargetAnimType != AnimType.VIS && !ctrl.playVIS0ToolStripMenuItem.Checked))
                _model.ApplyVIS(_vis0, _animFrame);
            if (_clr0 != null && !(ctrl.TargetAnimType != AnimType.CLR && !ctrl.playCLR0ToolStripMenuItem.Checked))
                _model.ApplyCLR(_clr0, _animFrame);
            else
                _model.ApplyCLR(null, 0);
        }

        public ArticleInfo(MoveDefArticleNode article, MDL0Node model, bool running)
        {
            _article = article;
            _model = model;
            _running = running;

            _chr0List = new List<CHR0Node>();
            _srt0List = new List<SRT0Node>();
            _shp0List = new List<SHP0Node>();
            _vis0List = new List<VIS0Node>();
            _pat0List = new List<PAT0Node>();
            _clr0List = new List<CLR0Node>();

            _article._info = this;
        }
    }

    /// <summary>
    /// Info for properly managing audio streams.
    /// </summary>
    public class AudioInfo
    {
        public AudioBuffer _buffer;
        public IAudioStream _stream;

        public AudioInfo(AudioBuffer buffer, IAudioStream stream)
        {
            _buffer = buffer;
            _stream = stream;
        }
    }

    public class RequirementInfo
    {
        public uint _requirement;
        public List<MoveDefEventParameterNode> _values = new List<MoveDefEventParameterNode>();
    }

    /// <summary>
    /// Info for executing an 'if' event successfully.
    /// </summary>
    public class IfInfo
    {
        //Indices of the first event of each if case in the sequence
        public List<int> _reqIndices = new List<int>();

        //List of requirements for each if statement (if, else if)
        //"And" event adds requirements to a requirement list
        public List<List<RequirementInfo>> _requirements = new List<List<RequirementInfo>>();

        //Event index of the first event of the else event, if there is an else event
        //Run code after this event if all other requirements are false
        public int _elseIndex = -1;

        //Index of the the endif
        //Go past here to end the if cases
        public int _endIndex;

        /// <summary>
        /// Runs all requirements and returns the event index of the code to be executed.
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            int index = 0;
            foreach (List<RequirementInfo> list in _requirements)
            {
                bool failed = false;
                foreach (RequirementInfo req in list)
                {
                    bool isTrue = ActionScript.ApplyRequirement(req);
                    if (!isTrue)
                    {
                        failed = true;
                        break;
                    }
                }
                if (!failed)
                    return _reqIndices[index];
                index++;
            }
            if (_elseIndex >= 0)
                return _elseIndex;
            return _endIndex;
        }
    }

    public class ActionChangeInfo
    {
        public bool _enabled = true;
        public bool _prioritized = true;
        public uint _statusID; //Used to enable 
        public int _newActionID = 0;
        
        public List<RequirementInfo> _requirements;

        public bool Evaluate()
        {
            if (!_enabled)
                return false;

            foreach (RequirementInfo i in _requirements)
                if (!ActionScript.ApplyRequirement(i))
                    return false;

            return true;
        }
    }
}
