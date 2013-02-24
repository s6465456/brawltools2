using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Imaging;

namespace System.Windows.Forms
{
    public partial class UserControl1 : UserControl
    {
        public ModelEditControl _mainWindow;

        public UserControl1() { InitializeComponent(); }

        private int _currentPage = 1;
        private ResourceNode _target;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceNode TargetSequence
        {
            get { return _target; }
            set
            {
                //if (_target == value)
                //    return;

                _target = value;
                UpdateTarget();
            }
        }

        public bool panelEnabled = false;
        public void SetEditType(int type)
        {
            lstTypes.Items.Clear();

            //Visible = panelEnabled = type != -1;
            grpKeys.Visible = type == 0; //Keyframes
            panel4.Visible = type != 0 && type != 2;
            panel6.Visible = panel1.Visible = type == 1; //Vis
            panel3.Visible = type == 2; //Colors

            lstTypes.Visible = false;
        }

        public void SetEditTypes(bool keys, bool clr, bool vis, bool enabled)
        {
            lstTypes.Items.Clear();

            //Visible = panelEnabled = enabled;
            grpKeys.Visible = keys;
            panel1.Visible = panel6.Visible = vis;
            panel3.Visible = clr;

            lstTypes.Visible = (keys && vis) || (vis && clr) || (clr && keys);

            if (lstTypes.Visible)
            {
                if (keys) lstTypes.Items.Add("Keyframes");
                if (clr) lstTypes.Items.Add("Colors");
                if (vis) lstTypes.Items.Add("Visibility");
            }
        }

        public void SetEditTypes2(bool keys, bool clr, bool spec, bool vis, bool enabled)
        {
            lstTypes.Items.Clear();

            //Visible = panelEnabled = enabled;
            grpKeys.Visible = keys;
            panel1.Visible = panel6.Visible = vis;
            panel3.Visible = clr || spec;

            lstTypes.Visible = (keys && vis) || (vis && (clr || spec)) || ((clr || spec) && keys);

            if (lstTypes.Visible)
            {
                if (keys) lstTypes.Items.Add("Keyframes");
                if (clr) lstTypes.Items.Add("Colors");
                if (spec) lstTypes.Items.Add("Specular");
                if (vis) lstTypes.Items.Add("Visibility");
            }
        }

        private void UpdateTarget()
        {
            clrControl.ColorSource = null;
            visEditor.TargetNode = null;

            if (_target is IColorSource)
                clrControl.ColorSource = _target as IColorSource;
            else if (_target is IBoolArrayNode)
                visEditor.TargetNode = _target as IBoolArrayNode;
            else
            {
                listKeyframes.BeginUpdate();
                listKeyframes.Items.Clear();
                if (_target != null)
                {
                    if (_target is CHR0EntryNode)
                    {
                        CHR0EntryNode entry = _target as CHR0EntryNode;
                        if (entry.FrameCount > 0)
                        {
                            AnimationFrame a;
                            bool check = false;
                            for (int x = 0; x < entry.FrameCount; x++) //Loop thru each frame
                            {
                                a = entry.GetAnimFrame(x); //Get the frame to check
                                a.Index = x;
                                a.ResetBools();
                                for (int i = 0x10; i < 0x19; i++) //Loop thru trans, rotate and scale
                                {
                                    if (entry.GetKeyframe((KeyFrameMode)i, x) != null) //Check for a keyframe
                                    {
                                        check = true; //Keyframe found
                                        a.SetBool(i, true); //Make sure the anim frame displays this
                                    }
                                }
                                if (check == true)
                                {
                                    //Only add the frame if it has a keyframe
                                    a.forKeyframeCHR = true;
                                    listKeyframes.Items.Add(a);
                                    check = false; //Reset the check for the loop
                                }
                            }
                        }
                    }
                    else if (_target is SRT0TextureNode)
                    {
                        SRT0TextureNode entry = _target as SRT0TextureNode;
                        if (entry.FrameCount > 0)
                        {
                            AnimationFrame a = new AnimationFrame();
                            bool check = false;
                            for (int x = 0; x < entry.FrameCount; x++)
                            {
                                a = entry.GetAnimFrame(x);
                                a.Index = x;
                                for (int i = 0x10; i < 0x19; i++)
                                {
                                    if (entry.GetKeyframe((KeyFrameMode)i, x) != null)
                                    {
                                        check = true;
                                        a.SetBool(i, true);
                                    }
                                }
                                if (check == true)
                                {
                                    a.forKeyframeSRT = true;
                                    listKeyframes.Items.Add(a);
                                    check = false;
                                }
                            }
                        }
                    }
                    else if (_target is SHP0VertexSetNode)
                    {
                        SHP0VertexSetNode entry = _target as SHP0VertexSetNode;
                        if (entry.FrameCount > 0)
                        {
                            KeyframeEntry kfe = null;
                            for (int x = 0; x < entry.FrameCount; x++)
                                if ((kfe = entry.GetKeyframe(x)) != null)
                                    listKeyframes.Items.Add(new FloatKeyframe() { Value = kfe._value, Index = x });
                        }
                    }
                }
                listKeyframes.EndUpdate();
            }
            numFrame_ValueChanged();
            RefreshPage();
        }

        public int FrameCount { get { if (_mainWindow != null) return (int)_mainWindow.pnlPlayback.numFrameIndex.Value; return -1; } set { if (_mainWindow != null) _mainWindow.pnlPlayback.numFrameIndex.Value = value; } }

        public void numFrame_ValueChanged()
        {
            int page = (int)FrameCount - 1;
            if (_currentPage != page)
            {
                _currentPage = page;
                RefreshPage();
            }
        }

        private void RefreshPage()
        {
            if (_target != null)
                listKeyframes.SelectedIndex = FindKeyframe(_currentPage);
        }

        public int FindKeyframe(int index)
        {
            int count = listKeyframes.Items.Count;
            for (int i = 0; i < count; i++)
            {
                switch (_mainWindow.pnlAssets.fileType.SelectedIndex)
                {
                    case 0: //CHR
                    case 1: //SRT
                        if (((AnimationFrame)listKeyframes.Items[i]).Index == index)
                            return i;
                        break;
                    case 2: //SHP
                        if (((FloatKeyframe)listKeyframes.Items[i]).Index == index)
                            return i;
                        break;
                    case 3: //PAT
                        break;

                    case 4: //VIS
                        break;
                    case 5:
                        if (((AnimationFrame)listKeyframes.Items[i]).Index == index)
                            return i;
                        break;
                }
            }
            return -1;
        }

        private void listKeyframes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listKeyframes.SelectedIndex;
            if (index >= 0)
            {
                AnimationFrame f = (AnimationFrame)listKeyframes.SelectedItem;
                _mainWindow.pnlPlayback.numFrameIndex.Value = f.Index + 1;
            }
        }
        public void UpdateEntry()
        {
            visEditor.listBox1.BeginUpdate();
            visEditor.listBox1.Items.Clear();

            if (visEditor.TargetNode != null && visEditor.TargetNode.EntryCount > -1)
                for (int i = 0; i < visEditor.TargetNode.EntryCount; i++)
                    visEditor.listBox1.Items.Add(visEditor.TargetNode.GetEntry(i));

            visEditor.listBox1.EndUpdate();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (visEditor.TargetNode != null)
            {
                if (chkConstant.Checked)
                    visEditor.TargetNode.MakeConstant(chkEnabled.Checked);
                UpdateEntry();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chkEnabled.Enabled = chkConstant.Checked;
            if (visEditor.TargetNode != null)
            {
                if (chkConstant.Checked)
                    visEditor.TargetNode.MakeConstant(chkEnabled.Checked);
                else
                    visEditor.TargetNode.MakeAnimated();
                UpdateEntry();
            }
        }

        private void chkClrEnabled_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkClrConst_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lstTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display panels 
        }
    }
}
