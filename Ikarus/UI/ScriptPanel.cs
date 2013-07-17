using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;
using System.Drawing;
using BrawlLib.Modeling;
using System.IO;
using System.ComponentModel;
using BrawlLib;
using System.Collections.Generic;
using BrawlLib.Wii.Models;
using BrawlLib.SSBBTypes;
using System.Globalization;
using System.Timers;
using System.Windows.Forms;

namespace Ikarus.UI
{
    public class ScriptPanel : UserControl
    {
        public delegate void ReferenceEventHandler(ResourceNode node);

        #region Designer

        private OpenFileDialog dlgOpen;
        private ContextMenuStrip ctxSubActions;
        private ToolStripMenuItem add;
        private ToolStripMenuItem subtract;
        private ToolStripMenuItem sourceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem replaceToolStripMenuItem;
        private ToolStripMenuItem portToolStripMenuItem;
        private SaveFileDialog dlgSave;
        private IContainer components;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem Source;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem removeAllToolStripMenuItem;
        private ToolStripMenuItem addCustomAmountToolStripMenuItem;
        public ScriptEditor scriptEditor1;
        private Panel ActionEditor;
        private Panel SubActionFlagsPanel;
        private NumericInputBox inTransTime;
        private CheckBox chkNoOutTrans;
        private Label label1;
        private Button flagsToggle;
        private CheckBox chkMovesChar;
        private CheckBox chkTransOutStart;
        private CheckBox chkUnk;
        private CheckBox chkLoop;
        private CheckBox chkFixedTrans;
        private CheckBox chkFixedRot;
        private CheckBox chkFixedScale;
        private Panel panel2;
        private Button btnRunScript;
        public ComboBox comboBox1;
        private Panel ActionFlagsPanel;
        public EventModifier eventModifier;
        private ToolStripMenuItem renameToolStripMenuItem;
        private Splitter splitter1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSubActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Source = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.subtract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.eventModifier = new System.Windows.Forms.EventModifier();
            this.ActionEditor = new System.Windows.Forms.Panel();
            this.scriptEditor1 = new Ikarus.UI.ScriptEditor();
            this.ActionFlagsPanel = new System.Windows.Forms.Panel();
            this.SubActionFlagsPanel = new System.Windows.Forms.Panel();
            this.chkUnk = new System.Windows.Forms.CheckBox();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.chkFixedTrans = new System.Windows.Forms.CheckBox();
            this.chkFixedRot = new System.Windows.Forms.CheckBox();
            this.chkFixedScale = new System.Windows.Forms.CheckBox();
            this.chkMovesChar = new System.Windows.Forms.CheckBox();
            this.chkTransOutStart = new System.Windows.Forms.CheckBox();
            this.inTransTime = new System.Windows.Forms.NumericInputBox();
            this.chkNoOutTrans = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flagsToggle = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ctxSubActions.SuspendLayout();
            this.ActionEditor.SuspendLayout();
            this.SubActionFlagsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(6, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ctxSubActions
            // 
            this.ctxSubActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem});
            this.ctxSubActions.Name = "ctxBox";
            this.ctxSubActions.Size = new System.Drawing.Size(118, 26);
            this.ctxSubActions.Text = "Subaction";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // Source
            // 
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // add
            // 
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(32, 19);
            // 
            // subtract
            // 
            this.subtract.Name = "subtract";
            this.subtract.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(32, 19);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // addCustomAmountToolStripMenuItem
            // 
            this.addCustomAmountToolStripMenuItem.Name = "addCustomAmountToolStripMenuItem";
            this.addCustomAmountToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // eventModifier
            // 
            this.eventModifier.AutoSize = true;
            this.eventModifier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.eventModifier.Location = new System.Drawing.Point(0, 358);
            this.eventModifier.Name = "eventModifier";
            this.eventModifier.Size = new System.Drawing.Size(229, 257);
            this.eventModifier.TabIndex = 37;
            this.eventModifier.Visible = false;
            // 
            // ActionEditor
            // 
            this.ActionEditor.Controls.Add(this.scriptEditor1);
            this.ActionEditor.Controls.Add(this.ActionFlagsPanel);
            this.ActionEditor.Controls.Add(this.SubActionFlagsPanel);
            this.ActionEditor.Controls.Add(this.panel2);
            this.ActionEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionEditor.Location = new System.Drawing.Point(0, 0);
            this.ActionEditor.Name = "ActionEditor";
            this.ActionEditor.Size = new System.Drawing.Size(229, 355);
            this.ActionEditor.TabIndex = 26;
            // 
            // scriptEditor1
            // 
            this.scriptEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditor1.Location = new System.Drawing.Point(0, 21);
            this.scriptEditor1.Name = "scriptEditor1";
            this.scriptEditor1.Padding = new System.Windows.Forms.Padding(1);
            this.scriptEditor1.Size = new System.Drawing.Size(229, 334);
            this.scriptEditor1.TabIndex = 26;
            // 
            // ActionFlagsPanel
            // 
            this.ActionFlagsPanel.Location = new System.Drawing.Point(0, 168);
            this.ActionFlagsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ActionFlagsPanel.Name = "ActionFlagsPanel";
            this.ActionFlagsPanel.Size = new System.Drawing.Size(201, 147);
            this.ActionFlagsPanel.TabIndex = 37;
            this.ActionFlagsPanel.Visible = false;
            // 
            // SubActionFlagsPanel
            // 
            this.SubActionFlagsPanel.Controls.Add(this.chkUnk);
            this.SubActionFlagsPanel.Controls.Add(this.chkLoop);
            this.SubActionFlagsPanel.Controls.Add(this.chkFixedTrans);
            this.SubActionFlagsPanel.Controls.Add(this.chkFixedRot);
            this.SubActionFlagsPanel.Controls.Add(this.chkFixedScale);
            this.SubActionFlagsPanel.Controls.Add(this.chkMovesChar);
            this.SubActionFlagsPanel.Controls.Add(this.chkTransOutStart);
            this.SubActionFlagsPanel.Controls.Add(this.inTransTime);
            this.SubActionFlagsPanel.Controls.Add(this.chkNoOutTrans);
            this.SubActionFlagsPanel.Controls.Add(this.label1);
            this.SubActionFlagsPanel.Location = new System.Drawing.Point(0, 21);
            this.SubActionFlagsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SubActionFlagsPanel.Name = "SubActionFlagsPanel";
            this.SubActionFlagsPanel.Size = new System.Drawing.Size(201, 147);
            this.SubActionFlagsPanel.TabIndex = 27;
            this.SubActionFlagsPanel.Visible = false;
            // 
            // chkUnk
            // 
            this.chkUnk.AutoSize = true;
            this.chkUnk.Location = new System.Drawing.Point(63, 125);
            this.chkUnk.Name = "chkUnk";
            this.chkUnk.Size = new System.Drawing.Size(72, 17);
            this.chkUnk.TabIndex = 36;
            this.chkUnk.Text = "Unknown";
            this.chkUnk.UseVisualStyleBackColor = true;
            this.chkUnk.CheckedChanged += new System.EventHandler(this.chkUnk_CheckedChanged);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(7, 125);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 35;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            this.chkLoop.CheckedChanged += new System.EventHandler(this.chkLoop_CheckedChanged);
            // 
            // chkFixedTrans
            // 
            this.chkFixedTrans.AutoSize = true;
            this.chkFixedTrans.Location = new System.Drawing.Point(7, 108);
            this.chkFixedTrans.Name = "chkFixedTrans";
            this.chkFixedTrans.Size = new System.Drawing.Size(106, 17);
            this.chkFixedTrans.TabIndex = 34;
            this.chkFixedTrans.Text = "Fixed Translation";
            this.chkFixedTrans.UseVisualStyleBackColor = true;
            this.chkFixedTrans.CheckedChanged += new System.EventHandler(this.chkFixedTrans_CheckedChanged);
            // 
            // chkFixedRot
            // 
            this.chkFixedRot.AutoSize = true;
            this.chkFixedRot.Location = new System.Drawing.Point(7, 91);
            this.chkFixedRot.Name = "chkFixedRot";
            this.chkFixedRot.Size = new System.Drawing.Size(94, 17);
            this.chkFixedRot.TabIndex = 33;
            this.chkFixedRot.Text = "Fixed Rotation";
            this.chkFixedRot.UseVisualStyleBackColor = true;
            this.chkFixedRot.CheckedChanged += new System.EventHandler(this.chkFixedRot_CheckedChanged);
            // 
            // chkFixedScale
            // 
            this.chkFixedScale.AutoSize = true;
            this.chkFixedScale.Location = new System.Drawing.Point(7, 74);
            this.chkFixedScale.Name = "chkFixedScale";
            this.chkFixedScale.Size = new System.Drawing.Size(81, 17);
            this.chkFixedScale.TabIndex = 32;
            this.chkFixedScale.Text = "Fixed Scale";
            this.chkFixedScale.UseVisualStyleBackColor = true;
            this.chkFixedScale.CheckedChanged += new System.EventHandler(this.chkFixedScale_CheckedChanged);
            // 
            // chkMovesChar
            // 
            this.chkMovesChar.AutoSize = true;
            this.chkMovesChar.Location = new System.Drawing.Point(7, 57);
            this.chkMovesChar.Name = "chkMovesChar";
            this.chkMovesChar.Size = new System.Drawing.Size(107, 17);
            this.chkMovesChar.TabIndex = 31;
            this.chkMovesChar.Text = "Moves Character";
            this.chkMovesChar.UseVisualStyleBackColor = true;
            this.chkMovesChar.CheckedChanged += new System.EventHandler(this.chkMovesChar_CheckedChanged);
            // 
            // chkTransOutStart
            // 
            this.chkTransOutStart.AutoSize = true;
            this.chkTransOutStart.Location = new System.Drawing.Point(7, 40);
            this.chkTransOutStart.Name = "chkTransOutStart";
            this.chkTransOutStart.Size = new System.Drawing.Size(143, 17);
            this.chkTransOutStart.TabIndex = 30;
            this.chkTransOutStart.Text = "Transition Out From Start";
            this.chkTransOutStart.UseVisualStyleBackColor = true;
            this.chkTransOutStart.CheckedChanged += new System.EventHandler(this.chkTransOutStart_CheckedChanged);
            // 
            // inTransTime
            // 
            this.inTransTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inTransTime.Location = new System.Drawing.Point(107, 4);
            this.inTransTime.Name = "inTransTime";
            this.inTransTime.Size = new System.Drawing.Size(89, 20);
            this.inTransTime.TabIndex = 29;
            this.inTransTime.Text = "0";
            this.inTransTime.ValueChanged += new System.EventHandler(this.inTransTime_ValueChanged);
            // 
            // chkNoOutTrans
            // 
            this.chkNoOutTrans.AutoSize = true;
            this.chkNoOutTrans.Location = new System.Drawing.Point(7, 24);
            this.chkNoOutTrans.Name = "chkNoOutTrans";
            this.chkNoOutTrans.Size = new System.Drawing.Size(109, 17);
            this.chkNoOutTrans.TabIndex = 2;
            this.chkNoOutTrans.Text = "No Out Transition";
            this.chkNoOutTrans.UseVisualStyleBackColor = true;
            this.chkNoOutTrans.CheckedChanged += new System.EventHandler(this.chkNoOutTrans_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "In Translation Time:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRunScript);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.flagsToggle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 21);
            this.panel2.TabIndex = 37;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunScript.Location = new System.Drawing.Point(101, -1);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(128, 23);
            this.btnRunScript.TabIndex = 2;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Main",
            "GFX",
            "SFX",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(47, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // flagsToggle
            // 
            this.flagsToggle.Cursor = System.Windows.Forms.Cursors.Default;
            this.flagsToggle.Location = new System.Drawing.Point(0, -1);
            this.flagsToggle.Name = "flagsToggle";
            this.flagsToggle.Size = new System.Drawing.Size(47, 23);
            this.flagsToggle.TabIndex = 0;
            this.flagsToggle.Text = "Flags";
            this.flagsToggle.UseVisualStyleBackColor = true;
            this.flagsToggle.Click += new System.EventHandler(this.flagsToggle_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 355);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(229, 3);
            this.splitter1.TabIndex = 26;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // ScriptPanel
            // 
            this.Controls.Add(this.ActionEditor);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.eventModifier);
            this.MinimumSize = new System.Drawing.Size(185, 0);
            this.Name = "ScriptPanel";
            this.Size = new System.Drawing.Size(229, 615);
            this.ctxSubActions.ResumeLayout(false);
            this.ActionEditor.ResumeLayout(false);
            this.SubActionFlagsPanel.ResumeLayout(false);
            this.SubActionFlagsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public MainControl _mainWindow;

        internal NumericInputBox[] _hurtboxBoxes = new NumericInputBox[8];

        public ScriptPanel() 
        {
            InitializeComponent();
            SubActionFlagsPanel.Dock = ActionFlagsPanel.Dock = DockStyle.Top;
            scriptEditor1._mainWindow = this;
            //scriptEditor1.label1.Visible = false;
            //scriptEditor1.Offset.Visible = false;
            _timer = new CoolTimer();
            _timer.RenderFrame += _timer_RenderFrame;
            eventModifier.Completed += eventModifier_Completed;
        }

        void eventModifier_Completed(object sender, EventArgs e)
        {
            if (eventModifier._status == DialogResult.OK)
            {
                scriptEditor1.MakeScript();
                SetFrame(_animFrame);
            }

            eventModifier.Visible = false;
        }

        public bool CloseReferences()
        {
            return true;
        }

        public void ActionGroupChanged()
        {

        }

        public void SubactionGroupChanged()
        {
            MoveDefSubActionGroupNode grp = _mainWindow.SelectedSubActionGrp;
            inTransTime.Value = grp._inTransTime;
            chkNoOutTrans.Checked = grp._flags.HasFlag(AnimationFlags.NoOutTransition);
            chkTransOutStart.Checked = grp._flags.HasFlag(AnimationFlags.TransitionOutFromStart);
            chkMovesChar.Checked = grp._flags.HasFlag(AnimationFlags.MovesCharacter);
            chkLoop.Checked = _mainWindow.Loop = grp._flags.HasFlag(AnimationFlags.Loop);
            chkUnk.Checked = grp._flags.HasFlag(AnimationFlags.Unknown);
            chkFixedScale.Checked = grp._flags.HasFlag(AnimationFlags.FixedScale);
            chkFixedRot.Checked = grp._flags.HasFlag(AnimationFlags.FixedRotation);
            chkFixedTrans.Checked = grp._flags.HasFlag(AnimationFlags.FixedTranslation);
        }

        /// <summary>
        /// Opens the event editor for the currently selected event.
        /// </summary>
        public void ModifyEvent()
        {
            eventModifier.Setup(_selectedEvent);
            eventModifier.Visible = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0Node TargetModel
        {
            get { return _mainWindow.TargetModel; }
            set { _mainWindow.TargetModel = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MoveDefEventNode SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; }
        }
        private MoveDefEventNode _selectedEvent;

        public bool _updating = false;

        public bool EditingSubactions { get { return _mainWindow.leftPanel.movesetEditor.SelectedIndex == 1; } }
        private void flagsToggle_Click(object sender, EventArgs e)
        {
            if (EditingSubactions)
                if (SubActionFlagsPanel.Visible)
                    SubActionFlagsPanel.Visible = false;
                else
                    SubActionFlagsPanel.Visible = true;
            else
                if (ActionFlagsPanel.Visible)
                    ActionFlagsPanel.Visible = false;
                else
                    ActionFlagsPanel.Visible = true;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            if (EditingSubactions)
                if (_mainWindow._selectedSubActionGrp != null)
                    scriptEditor1.TargetNode = _mainWindow._selectedSubActionGrp.Children[comboBox1.SelectedIndex] as MoveDefActionNode;
                else { }
            else
                if (_mainWindow._selectedSubActionGrp != null)
                    scriptEditor1.TargetNode = _mainWindow._selectedSubActionGrp.Children[comboBox1.SelectedIndex] as MoveDefActionNode;
                else { }
        }

        public CoolTimer _timer;
        private void btnRunScript_Click(object sender, EventArgs e)
        {
            if (_timer.IsRunning)
                StopScript();
            else
                RunScript();
        }

        public bool ActionsIdling
        {
            get
            {
                bool allEmpty = true;
                foreach (MoveDefActionNode a in MoveDefActionNode._runningActions)
                    if (a.Children.Count > 0)
                        allEmpty = false;
                if (allEmpty)
                    return true;
                foreach (MoveDefActionNode a in MoveDefActionNode._runningActions)
                    if (!a._idling)
                        return false;
                return true;
            }
        }

        public bool _playing = false;
        public void RunScript()
        {
            _playing = true;

            if (EditingSubactions)
            {
                _mainWindow.Playing = true;
                if (ActionsIdling && _animFrame >= _mainWindow.MaxFrame) //Reset scripts
                    SetFrame(0);
            }

            btnRunScript.Text = "Stop Script";

            _timer.Run(0, (double)_mainWindow.PlaybackPanel.numFPS.Value);

            _playing = false;
            if (EditingSubactions)
                _mainWindow.Playing = false;
            btnRunScript.Text = "Run Script";
        }
        public void StopScript() { _timer.Stop(); }
        public int _animFrame = 0;

        void _timer_RenderFrame(object sender, FrameEventArgs e)
        {
            if (ActionsIdling && EditingSubactions && _animFrame >= _mainWindow.MaxFrame && _mainWindow._selectedSubActionGrp != null)
            {
                if (_mainWindow.CurrentFrame < _mainWindow.MaxFrame)
                    _mainWindow.SetFrame(_mainWindow.CurrentFrame + 1);
                else
                {
                    _animFrame = 0;
                    if (_mainWindow.Loop)
                        SetFrame(0);
                    else
                        StopScript();
                }
            }
            else
                SetFrame(_animFrame + 1);
        }

        public void SetFrame(int index)
        {
            if (index <= 1)
                ResetModelVisEtc();

            if (EditingSubactions)
                _mainWindow.SetFrame(index);

            if (!_updating)
            {
                var running = MoveDefActionNode._runningActions;
                if (!_playing)
                {
                    ResetModelVisEtc();
                    for (int i = 0; i < running.Count; i++)
                    {
                        MoveDefActionNode a = running[i];

                        //if (a._idling)
                        //    continue;

                        a.SetFrame(index - 1);
                        if (a == scriptEditor1.TargetNode)
                        {
                            scriptEditor1.EventList.SelectedIndices.Clear();
                            if (a._eventIndex - 1 < scriptEditor1.EventList.Items.Count)
                                scriptEditor1.EventList.SelectedIndex = a._eventIndex - 1;
                        }
                    }
                }
                else
                {
                    if (_animFrame == index)
                        for (int i = 0; i < running.Count; i++)
                        {
                            MoveDefActionNode a = running[i];

                            //if (a._idling)
                            //    continue;

                            if (index == 0)
                                a.Reset();

                            a.FrameAdvance();
                            if (a == scriptEditor1.TargetNode)
                            {
                                scriptEditor1.EventList.SelectedIndices.Clear();
                                if (a._eventIndex - 1 < scriptEditor1.EventList.Items.Count)
                                    scriptEditor1.EventList.SelectedIndex = a._eventIndex - 1;
                            }
                        }
                    else
                    {
                        ResetModelVisEtc();
                        for (int i = 0; i < running.Count; i++)
                        {
                            MoveDefActionNode a = running[i];
                            a.SetFrame(index);
                            if (a == scriptEditor1.TargetNode)
                            {
                                scriptEditor1.EventList.SelectedIndices.Clear();
                                if (a._eventIndex - 1 < scriptEditor1.EventList.Items.Count)
                                    scriptEditor1.EventList.SelectedIndex = a._eventIndex - 1;
                            }
                        }
                    }
                }
            }
            CurrentFrame = index;
        }

        public int CurrentFrame { get { return _animFrame; } set { _animFrame = value; if (_mainWindow != null) _mainWindow.ModelPanel.Invalidate(); } }

        public void ResetModelVisEtc()
        {
            foreach (MDL0BoneNode bone in MoveDefActionNode._boneCollisions)
                bone._nodeColor = bone._boneColor = Color.Transparent;
            MoveDefActionNode._boneCollisions = new List<MDL0BoneNode>();
            MoveDefActionNode._hurtBoxType = 0;

            if (TargetModel != null && TargetModel._objList != null && FileManager.Moveset != null)
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

        private void chkUnk_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkUnk.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.Unknown;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.Unknown;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkLoop.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.Loop;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.Loop;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkFixedTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkFixedTrans.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.FixedTranslation;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.FixedTranslation;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkFixedRot_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkFixedRot.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.FixedRotation;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.FixedRotation;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkFixedScale_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkFixedScale.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.FixedScale;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.FixedScale;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkMovesChar_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkMovesChar.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.MovesCharacter;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.MovesCharacter;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkTransOutStart_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkTransOutStart.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.TransitionOutFromStart;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.TransitionOutFromStart;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void chkNoOutTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                if (chkNoOutTrans.Checked)
                    _mainWindow._selectedSubActionGrp._flags |= AnimationFlags.NoOutTransition;
                else
                    _mainWindow._selectedSubActionGrp._flags &= ~AnimationFlags.NoOutTransition;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void inTransTime_ValueChanged(object sender, EventArgs e)
        {
            if (_mainWindow._selectedSubActionGrp != null)
            {
                _mainWindow._selectedSubActionGrp._inTransTime = (byte)inTransTime.Value;
                _mainWindow._selectedSubActionGrp.SignalPropertyChange();
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
