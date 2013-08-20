using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public partial class InterpolationEditor : Form
    {
        public IMainWindow _mainWindow; 

        public InterpolationEditor(IMainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private InterpolationViewer interpolationViewer1;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            numericInputBox3.Integral = true;
            comboBox1.DataSource = _modes;

            this.interpolationViewer1 = new System.Windows.Forms.InterpolationViewer();
            this.interpolationViewer1.AllKeyframes = true;
            this.interpolationViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interpolationViewer1._updating = true;
            this.interpolationViewer1.FrameIndex = 0;
            this.interpolationViewer1._updating = false;
            this.interpolationViewer1.FrameLimit = 0;
            this.interpolationViewer1.Linear = false;
            this.interpolationViewer1.Location = new System.Drawing.Point(0, 97);
            this.interpolationViewer1.Name = "interpolationViewer1";
            this.interpolationViewer1.SelectedKeyframe = null;
            this.interpolationViewer1.Size = new System.Drawing.Size(271, 215);
            this.interpolationViewer1.TabIndex = 0;
            this.Controls.Add(this.interpolationViewer1);
            interpolationViewer1.SelectedKeyframeChanged += interpolationViewer1_SelectedKeyframeChanged;
            interpolationViewer1.FrameChanged += interpolationViewer1_FrameChanged;
            interpolationViewer1.UpdateProps += interpolationViewer1_UpdateProps;
            panel1.SendToBack();

            chkLinear.Checked = _mainWindow.LinearInterpolation;
        }

        void interpolationViewer1_UpdateProps(object sender, EventArgs e)
        {
            _mainWindow.UpdatePropDisplay();
            _mainWindow.UpdateModel();
        }

        void interpolationViewer1_FrameChanged(object sender, EventArgs e)
        {
            _mainWindow.SetFrame(interpolationViewer1.FrameIndex.Clamp(1, _mainWindow.MaxFrame));
        }

        protected override void OnClosed(EventArgs e)
        {
            _open = false;
            _mainWindow.InterpolationEditorVisible = false;
            base.OnClosed(e);
        }

        public bool _open = false;

        public BindingList<KeyFrameMode> _modes = new BindingList<KeyFrameMode>();

        public KeyframeEntry SelectedKeyframe 
        {
            get { return interpolationViewer1.SelectedKeyframe; } 
            set { interpolationViewer1.SelectedKeyframe = value; } 
        }

        public KeyFrameMode SelectedMode { get { return _modes[comboBox1.SelectedIndex]; } set { comboBox1.SelectedIndex = ((int)value - 0x10).Clamp(comboBox1.Items.Count == 0 ? -1 : 0, comboBox1.Items.Count - 1); } }

        public void UpdateDisplay()
        {
            ResourceNode node = _targetNode;
            if (node is ISCN0KeyframeHolder)
            {

            }
            else if (node is IKeyframeHolder)
            {
                if (node is CHR0EntryNode)
                {
                    CHR0EntryNode n = node as CHR0EntryNode;

                    interpolationViewer1.FrameLimit = n._keyframes._frameLimit;
                    interpolationViewer1.KeyRoot = n._keyframes._keyRoots[(int)SelectedMode & 0xF];
                    //if (SelectedKeyframe != null)
                    //{
                    //    KeyframeEntry prev = SelectedKeyframe;
                    //    for (KeyframeEntry entry = interpolationViewer1.KeyRoot._next; (entry != interpolationViewer1.KeyRoot); entry = entry._next)
                    //        if (entry._index == SelectedKeyframe._index)
                    //        {
                    //            SelectedKeyframe = entry;
                    //            break;
                    //        }
                    //    if (SelectedKeyframe == prev)
                    //        SelectedKeyframe = null;
                    //}
                }
                else if (node is SRT0TextureNode)
                {
                    SRT0TextureNode n = node as SRT0TextureNode;

                    interpolationViewer1.FrameLimit = n._keyframes._frameLimit;
                    interpolationViewer1.KeyRoot = n._keyframes._keyRoots[(int)SelectedMode & 0xF];
                    //if (SelectedKeyframe != null)
                    //{
                    //    KeyframeEntry prev = SelectedKeyframe;
                    //    for (KeyframeEntry entry = interpolationViewer1.KeyRoot._next; (entry != interpolationViewer1.KeyRoot); entry = entry._next)
                    //        if (entry._index == SelectedKeyframe._index)
                    //        {
                    //            SelectedKeyframe = entry;
                    //            break;
                    //        }
                    //    if (SelectedKeyframe == prev)
                    //        SelectedKeyframe = null;
                    //}
                }
            }
            else if (node is IKeyframeArrayHolder)
            {
                comboBox1.Enabled = false;

                if (node is SHP0VertexSetNode)
                {
                    SHP0VertexSetNode n = node as SHP0VertexSetNode;

                    interpolationViewer1.FrameLimit = n._keyframes._frameLimit;
                    interpolationViewer1.KeyRoot = n._keyframes._keyRoot;
                    //if (SelectedKeyframe != null)
                    //{
                    //    KeyframeEntry prev = SelectedKeyframe;
                    //    for (KeyframeEntry entry = interpolationViewer1.KeyRoot._next; (entry != interpolationViewer1.KeyRoot); entry = entry._next)
                    //        if (entry._index == SelectedKeyframe._index)
                    //        {
                    //            SelectedKeyframe = entry;
                    //            break;
                    //        }
                    //    if (SelectedKeyframe == prev)
                    //        SelectedKeyframe = null;
                    //}
                }
            }
        }

        public ResourceNode _targetNode;
        public void SetTarget(ResourceNode node)
        {
            if ((_targetNode = node) != null)
            {
                panel1.Enabled = true;
                if (node is ISCN0KeyframeHolder)
                {

                }
                else if (node is IKeyframeHolder)
                {
                    if (node is CHR0EntryNode)
                    {
                        CHR0EntryNode n = node as CHR0EntryNode;

                        if (_modes.Count != 9)
                        {
                            _updating = true;
                            _modes.Clear();
                            _modes.Add(KeyFrameMode.ScaleX);
                            _modes.Add(KeyFrameMode.ScaleY);
                            _modes.Add(KeyFrameMode.ScaleZ);
                            _modes.Add(KeyFrameMode.RotX);
                            _modes.Add(KeyFrameMode.RotY);
                            _modes.Add(KeyFrameMode.RotZ);
                            _modes.Add(KeyFrameMode.TransX);
                            _modes.Add(KeyFrameMode.TransY);
                            _modes.Add(KeyFrameMode.TransZ);

                            comboBox1.SelectedIndex = 0;
                            _updating = false;
                        }
                    }
                    else if (node is SRT0TextureNode)
                    {
                        SRT0TextureNode n = node as SRT0TextureNode;

                        if (_modes.Count != 5)
                        {
                            _updating = true;
                            _modes.Clear();
                            _modes.Add(KeyFrameMode.ScaleX);
                            _modes.Add(KeyFrameMode.ScaleY);
                            _modes.Add(KeyFrameMode.RotX);
                            _modes.Add(KeyFrameMode.TransX);
                            _modes.Add(KeyFrameMode.TransY);

                            comboBox1.SelectedIndex = 0;
                            _updating = false;
                        }
                    }
                }
                else if (node is IKeyframeArrayHolder)
                {
                    comboBox1.Enabled = false;

                    if (_modes.Count != 1)
                    {
                        _updating = true;

                        _modes.Clear();
                        _modes.Add(KeyFrameMode.ScaleX);

                        comboBox1.SelectedIndex = 0;
                        _updating = false;
                    }
                }
                UpdateDisplay();
            }
            else
            {
                interpolationViewer1.KeyRoot = null;
                panel1.Enabled = false;
            }
        }

        public int Frame 
        {
            get { return interpolationViewer1.FrameIndex; } 
            set
            {
                interpolationViewer1._updating = true;
                interpolationViewer1.FrameIndex = value - 1;
                interpolationViewer1._updating = false;
            } 
        }

        bool _updating = false;
        void interpolationViewer1_SelectedKeyframeChanged(object sender, EventArgs e)
        {
            _updating = true;
            if (interpolationViewer1._selKey != null)
            {
                groupBox1.Enabled = true;
                numericInputBox1.Value = interpolationViewer1._selKey._tangent;
                numericInputBox2.Value = interpolationViewer1._selKey._value;
                numericInputBox3.Value = interpolationViewer1._selKey._index + 1;
            }
            else
            {
                groupBox1.Enabled = false;
                numericInputBox1.Value = 0;
                numericInputBox2.Value = 0;
                numericInputBox3.Value = 0;
            }
            _updating = false;
        }

        private void numericInputBox1_ValueChanged(object sender, EventArgs e)
        {
            if (_updating || interpolationViewer1._selKey == null)
                return;

            interpolationViewer1._selKey._tangent = numericInputBox1.Value;
            interpolationViewer1.Invalidate();
            _targetNode.SignalPropertyChange();
            //interpolationViewer1_UpdateProps(null, null);
        }

        private void numericInputBox3_ValueChanged(object sender, EventArgs e)
        {
            if (_updating || interpolationViewer1._selKey == null)
                return;

            interpolationViewer1._selKey._index = (int)numericInputBox3.Value - 1;
            interpolationViewer1.Invalidate();
            _targetNode.SignalPropertyChange();
            interpolationViewer1_UpdateProps(null, null);
        }

        private void numericInputBox2_ValueChanged(object sender, EventArgs e)
        {
            if (_updating || interpolationViewer1._selKey == null)
                return;

            interpolationViewer1._selKey._value = numericInputBox2.Value;
            interpolationViewer1.Invalidate();
            _targetNode.SignalPropertyChange();
            interpolationViewer1_UpdateProps(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            UpdateDisplay();

            if (SelectedKeyframe != null)
            {
                KeyframeEntry prev = SelectedKeyframe;
                for (KeyframeEntry entry = interpolationViewer1.KeyRoot._next; (entry != interpolationViewer1.KeyRoot); entry = entry._next)
                    if (entry._index == SelectedKeyframe._index)
                    {
                        SelectedKeyframe = entry;
                        break;
                    }
                if (SelectedKeyframe == prev)
                    SelectedKeyframe = null;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            interpolationViewer1.AllKeyframes = chkViewAll.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            interpolationViewer1.Linear = chkLinear.Checked;
        }

        private void chkGenTans_CheckedChanged(object sender, EventArgs e)
        {
            interpolationViewer1.GenerateTangents = chkGenTans.Checked;
        }

        private void chkKeyDrag_CheckedChanged(object sender, EventArgs e)
        {
            interpolationViewer1.KeyDraggingAllowed = chkKeyDrag.Checked;
        }
    }
}
