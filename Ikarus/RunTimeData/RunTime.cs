using BrawlLib.SSBB.ResourceNodes;
using Ikarus.UI;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;

namespace Ikarus
{
    /// <summary>
    /// A static class containing universally available variables and functions for what is going on in the viewer.
    /// </summary>
    public static class RunTime
    {
        static RunTime()
        {
            _timer.RenderFrame += RenderFrame;
            _timer.UpdateFrame += UpdateFrame;
        }

        private static RunTimeAccessor _instance;
        public static RunTimeAccessor Instance { get { return _instance == null ? _instance = new RunTimeAccessor() : _instance; } }

        public static MainControl MainWindow { get { return MainForm.Instance._mainControl; } }
        public static ScriptPanel ScriptWindow { get { return MainWindow.MovesetPanel; } }

        #region Variables

        //Variable storage. Order: IC, LA, RA
        public static int[][] BasicVars = new int[3][];
        public static float[][] FloatVars = new float[3][];
        public static bool[][] BitVars = new bool[3][];

        public static float GetVar(int var, int mem, int num)
        {
            var = var.Clamp(0, 2);
            mem = mem.Clamp(0, 2);
            switch (var)
            {
                case 0:
                    if (num < 0 || num >= BasicVars[mem].Length)
                        return float.NaN;
                    return BasicVars[mem][num];
                case 1:
                    if (num < 0 || num >= FloatVars[mem].Length)
                        return float.NaN;
                    return FloatVars[mem][num];
                case 2:
                    if (num < 0 || num >= BitVars[mem].Length)
                        return float.NaN;
                    return !BitVars[mem][num] ? 0 : 1;
            }
            return float.NaN;
        }

        #endregion

        private static List<ActionChangeInfo> _actionChanges = new List<ActionChangeInfo>();
        public static ActionChangeInfo GetActionChangeInfo(uint statusID)
        {
            foreach (ActionChangeInfo a in _actionChanges)
                if (a._statusID == statusID)
                    return a;
            return null;
        }
        public static void AddActionChangeInfo(ActionChangeInfo info)
        {
            _actionChanges.Add(info);

            //Is sorting "prioritized" action changes needed, or is it not actually prioritized at all?
            //If they are prioritized, then where do action changes without a status ID fit in to the sorting, first or last?
            //_actionChanges = _actionChanges.OrderBy(x => x._statusID).ToList();
        }

        public static bool _animationRunning = false;

        public static Location _location = Location.Ground;
        public enum Location
        {
            Ground,
            Air
        }

        ///// <summary>
        ///// Returns true if all running subaction scripts have finished executing code.
        ///// </summary>
        //public static bool AllScriptsIdling
        //{
        //    get
        //    {
        //        bool allEmpty = true;
        //        foreach (MoveDefActionNode a in _runningScripts)
        //            if (a.Children.Count > 0)
        //                allEmpty = false;
        //        if (allEmpty)
        //            return true;
        //        foreach (MoveDefActionNode a in _runningScripts)
        //            if (!a._idling)
        //                return false;
        //        return true;
        //    }
        //}
        
        public static List<MoveDefActionNode> _runningScripts = new List<MoveDefActionNode>();
        public static Dictionary<int, List<AudioInfo>> _playingSounds = new Dictionary<int, List<AudioInfo>>();
        public static ArticleInfo[] _articles;

        public static bool _muteSFX = false;

        public static CoolTimer _timer = new CoolTimer();
        public static bool IsRunning { get { return _timer.IsRunning; } }
        public static void Run() { _timer.Run(0, FramesPerSecond); }
        public static void Stop() { _timer.Stop(); }

        public static double FramesPerSecond 
        {
            get { return _timer.TargetRenderFrequency; }
            set { _timer.TargetRenderFrequency = value; }
        }

        public static double UpdatesPerSecond
        {
            get { return _timer.TargetUpdateFrequency; }
            set { _timer.TargetUpdateFrequency = value; }
        }

        private static MoveDefSubActionGroupNode _currentSubaction;
        private static MoveDefActionGroupNode _currentAction;
        private static MoveDefActionNode _currentSubRoutine;
        
        public static MoveDefSubActionGroupNode CurrentSubaction
        {
            get { return _currentSubaction; }
            set
            {
                _currentSubaction = value;

                //Reset all of the subaction-dependent variables
                ResetSubactionVariables();

                ScriptWindow.SubactionGroupChanged();
            }
        }

        public static MoveDefActionGroupNode CurrentAction
        {
            get { return _currentAction; }
            set
            {
                _currentAction = value;
                ScriptWindow.ActionGroupChanged();
            }
        }

        public static MoveDefActionNode CurrentSubRoutine
        {
            get { return _currentSubRoutine; }
            set
            {
                _currentSubRoutine = value;
                ScriptWindow.SubRoutineChanged();
            }
        }

        private static void LoadSubactionScripts()
        {
            foreach (MoveDefActionNode a in _runningScripts) 
                a.Reset(); 

            _runningScripts.Clear();
            if (CurrentSubaction != null)
                foreach (MoveDefActionNode a in CurrentSubaction.Children) 
                {
                    _runningScripts.Add(a); 
                    a.Reset();
                }
        }

        public static void ResetSubactionVariables()
        {
            //Reset TopN
            MDL0BoneNode TopN = (FileManager.Moveset._data.boneRef1.Children[0] as MoveDefBoneIndexNode).BoneNode;
            TopN._overrideTranslate = new Vector3();

            //Reload scripts
            LoadSubactionScripts();

            //Reset bone collisions and hurtbox type
            foreach (MDL0BoneNode bone in MoveDefActionNode._boneCollisions)
                bone._nodeColor = bone._boneColor = Color.Transparent;
            MoveDefActionNode._boneCollisions = new List<MDL0BoneNode>();
            MoveDefActionNode._hurtBoxType = 0;

            //Reset articles
            if (_articles != null)
                foreach (ArticleInfo i in _articles)
                {
                    i.SubactionIndex = -1;
                    if (!i._etcModel)
                    {
                        if (i._model != null)
                        {
                            i._model._visible = true;
                            i._model.ApplyCHR(null, 0);
                        }
                        i.Running = true;
                    }
                    else
                    {
                        if (i._model != null)
                            i._model._visible = false;
                        i.Running = false;
                    }
                }

            //Reset model visiblity to its default state
            if (MainWindow.TargetModel != null && MainWindow.TargetModel._objList != null && FileManager.Moveset != null)
            {
                MoveDefModelVisibilityNode node = FileManager.Moveset._data.mdlVisibility;
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

        #region Frames

        /// <summary>
        /// Changes the code frame using a difference.
        /// This will do nothing if the timer is running.
        /// </summary>
        public static void SetFrame(int frame)
        {
            if (frame > MainWindow.MaxFrame && MainWindow.MaxFrame > 0)
                frame = ((frame - 1) % MainWindow.MaxFrame) + 1;

            int difference = frame - MainWindow.CurrentFrame;
            if (difference == 0)
                return;

            MainWindow.SetFrame(frame);

            if (frame <= 1)
                ResetSubactionVariables();

            if (difference > 0)
                for (int i = 0; i < difference; i++)
                    IncrementFrame();
            else
            {
                //We can't exactly go back frames, 
                //so instead we'll reset the subaction and run it until the new index.

                //ResetSubactionVariables();

                UpdateScripts(false, frame);
                UpdateScripts(true, frame);

                foreach (ArticleInfo a in RunTime._articles)
                    if (a.Running)
                        a.SetFrame(frame);
            }
        }

        /// <summary>
        /// Progresses everything one frame forward.
        /// </summary>
        public static void IncrementFrame()
        {
            UpdateScripts(false, -1);
            UpdateScripts(true, -1);

            foreach (ArticleInfo a in RunTime._articles)
                if (a.Running)
                    a.ProgressFrame();
        }

        private static void UpdateScripts(bool articlePass, int index)
        {
            for (int i = 0; i < _runningScripts.Count; i++)
            {
                MoveDefActionNode a = _runningScripts[i];

                if (index == -1 && ((!articlePass && a._attachedArticleIndex < 0) || (articlePass && a._attachedArticleIndex >= 0)))
                    a.FrameAdvance();
                else if (index >= 0)
                    if (!articlePass && a._attachedArticleIndex < 0)
                        a.SetFrame(index - 1);
                    else if (articlePass && a._attachedArticleIndex >= 0)
                        a.SetFrame(index - _articles[a._attachedArticleIndex]._setAt);

                //if (a._idling)
                //{
                //    _runningScripts.RemoveAt(i--);
                //    continue;
                //}

                ScriptWindow.UpdateScriptEditor(a);
            }
        }

        #endregion

        #region Rendering

        private static void RenderFrame(object sender, FrameEventArgs e)
        {
            if (!IsRunning)
                return;

            if (MainWindow.CurrentFrame == MainWindow.MaxFrame && !MainWindow.Loop)
                if (_playingSounds.Count == 0)
                {
                    //Stop and reset scripts
                    Stop(); ResetSubactionVariables();
                }
                else
                {
                    //Wait for playing sounds to finish, but don't update the frame.
                }
            else
                SetFrame(MainWindow.CurrentFrame + 1);

            //Rendering text on the screen makes the FPS drop by nearly 20
            //So ironically, rendering the FPS on the screen slows the FPS
            //MainWindow.ModelPanel.ScreenText[String.Format("FPS: {0}", Math.Round(_timer.RenderFrequency, 3).ToString())] = new Vector3(5.0f, 10.0f, 0.5f);

            //Check if any sounds are done playing so they can be disposed of
            if (_playingSounds.Count != 0)
            {
                Dictionary<int, List<int>> keys = new Dictionary<int, List<int>>();
                foreach (var b in _playingSounds)
                {
                    int l = 0;
                    foreach (AudioInfo info in b.Value)
                    {
                        if (info._buffer != null)
                        {
                            if (info._buffer.Owner != null)
                                info._buffer.Fill();

                            if (info._buffer.ReadSample >= info._stream.Samples)
                            {
                                if (info._buffer.Owner != null)
                                    info._buffer.Stop();

                                info._buffer.Dispose();

                                if (!keys.ContainsKey(b.Key))
                                    keys[b.Key] = new List<int>();

                                keys[b.Key].Add(l);
                            }
                        }
                        l++;
                    }
                }
                foreach (var i in keys)
                {
                    List<int> list = i.Value;
                    int b = i.Key;

                    if (_playingSounds.ContainsKey(b))
                    {
                        foreach (int l in list)
                            if (l < _playingSounds[b].Count && l >= 0)
                                _playingSounds[b].RemoveAt(l);
                        if (_playingSounds[b].Count == 0)
                            _playingSounds.Remove(b);
                    }
                }
            }
        }

        #endregion

        /*
            -- Button Press Values --
            00 A (normal attack)
            01 B (special attack)
            02 X, Y (jump)
            03 R, L, Z (shield)
            04 R, L, Z
            05 ?
            06 D-Up
            07 D-Down
            08 D-Left, D-Right
            09 D-Left
            10 D-Right
            11 B, X, D-Right, D-Left
            12 Y, X, D-Up, D-Right
            13 B, Y, X, D-Up, D-Right, D-Left
            14 A + B together
            15 C-Stick, any direction
            16 Tap jump setting. Always "held" while on and not while off. 
            17 ?
            18 ?
         
            -- Movement Values --
            Forward: IC-Basic[1011]
            Backward: IC-Basic[1012]
            Upward: IC-Basic[1018]
            Downward: IC-Basic[1020]
         
        */

        public static ButtonManager ButtonManager = new ButtonManager();

        public static readonly Keys[] Buttons = new Keys[]
        {
            Keys.J, //Attack
            Keys.K, //Special
            Keys.W, //Jump
            Keys.L, //Shield
            Keys.L, //Dodge?
            Keys.None,
            Keys.Up, //Up taunt
            Keys.Down, //Down taunt
            Keys.Left | Keys.Right, //Side taunt
            Keys.Left, //Side taunt L
            Keys.Right, //Side taunt R
            Keys.K | Keys.W | Keys.Right | Keys.Left,
            Keys.W | Keys.Up | Keys.Right,
            Keys.K | Keys.W | Keys.Up | Keys.Right | Keys.Left,
        };

        
        private static void UpdateFrame(object sender, FrameEventArgs e)
        {
            //foreach (ActionChangeInfo info in _actionChanges)
            //{
            //    if (info.Evaluate())
            //    {
            //        int i = info._newActionID;
            //        if (i < 274)
            //        {
            //            if (FileManager.CommonMoveset != null && i < FileManager.CommonMoveset._actions.Children.Count)
            //                CurrentAction = FileManager.CommonMoveset._actions.Children[i] as MoveDefActionGroupNode;
            //        }
            //        else
            //        {
            //            if (FileManager.Moveset != null && i < FileManager.Moveset._actions.Children.Count)
            //                CurrentAction = FileManager.Moveset._actions.Children[i] as MoveDefActionGroupNode;
            //        }
            //    }
            //}

            //Read controller input here
        }
    }

    public class ButtonManager
    {
        internal KeyMessageFilter _keyFilter = new KeyMessageFilter();
        internal Wiimote wm = new Wiimote();
        private WiimoteState wmState = null;
        private WiimoteExtensionChangedEventArgs wmExtLastChange = null;

        private Controller _controller = Controller.Keyboard;
        public Controller InputController
        {
            get { return _controller; }
            set 
            {
                if (_controller == value)
                    return;

                if (value == Controller.Keyboard)
                    DisconnectWiimote();
                else
                    if (!wm.Connected && !ConnectWiimote())
                    {
                        _controller = Controller.Keyboard;
                        return;
                    }

                _controller = value;
            }
        }

        public bool ConnectWiimote()
        {
            try { wm.Connect(); }
            catch { return false; }
            wm.SetReportType(InputReport.IRAccel, true);
            wm.SetLEDs(false, true, true, false);
            return true;
        }

        public void DisconnectWiimote()
        {
            wm.Disconnect();
            wm.SetReportType(InputReport.IRAccel, true);
            wm.SetLEDs(false, true, true, false);
        }

        public ButtonManager()
        {
            wm.WiimoteChanged += wm_WiimoteChanged;
            wm.WiimoteExtensionChanged += wm_WiimoteExtensionChanged;
        }

        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            wmState = args.WiimoteState;
        }

        private void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
        {
            wmExtLastChange = args;

            if (args.Inserted)
                wm.SetReportType(InputReport.IRExtensionAccel, true);
            else
                wm.SetReportType(InputReport.IRAccel, true);
        }

        public bool GetButtonPressed(int button)
        {
            if (InputController == Controller.Keyboard && !RunTime.MainWindow.ModelPanel.Focused)
                return false;

            return false;
        }

        public enum Controller
        {
            Keyboard,
            Wiimote,
            Nunchuk,
            Classic
        }
    }

    public class RunTimeAccessor
    {
        public int[][] BasicVars { get { return RunTime.BasicVars; } }
        public float[][] FloatVars { get { return RunTime.FloatVars; } }
        public bool[][] BitVars { get { return RunTime.BitVars; } }

        public RunTime.Location CharacterLocation { get { return RunTime._location; } set { RunTime._location = value; } }

        public List<MoveDefActionNode> RunningScripts { get { return RunTime._runningScripts; } }
        
        public Dictionary<int, List<AudioInfo>> PlayingSounds { get { return RunTime._playingSounds; } }
        public ArticleInfo[] Articles { get { return RunTime._articles; } }
    }

    public class KeyMessageFilter : IMessageFilter
    {
        private Dictionary<Keys, bool> m_keyTable = new Dictionary<Keys, bool>();
        public Dictionary<Keys, bool> KeyTable
        {
            get { return m_keyTable; }
            private set { m_keyTable = value; }
        }

        public bool IsKeyPressed() { return m_keyPressed; }
        public bool IsKeyPressed(Keys k)
        {
            bool pressed = false;
            if (KeyTable.TryGetValue(k, out pressed))
                return pressed;

            return false;
        }

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private bool m_keyPressed = false;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                KeyTable[(Keys)m.WParam] = true;
                m_keyPressed = true;
            }

            if (m.Msg == WM_KEYUP)
            {
                KeyTable[(Keys)m.WParam] = false;
                m_keyPressed = false;
            }

            return false;
        }
    }
}