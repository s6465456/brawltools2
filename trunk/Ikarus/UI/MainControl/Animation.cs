using System;
using BrawlLib.OpenGL;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlLib.Modeling;
using System.Drawing;
using BrawlLib.Wii.Animations;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;
using BrawlLib.IO;
using BrawlLib;
using System.Drawing.Imaging;
using Gif.Components;
using OpenTK.Graphics.OpenGL;
using BrawlLib.Imaging;
using System.Windows.Forms;

namespace Ikarus.UI
{
    public partial class MainControl : UserControl, IMainWindow
    {
        //Updates specified angle by applying an offset.
        //Allows pnlAnim to handle the changes so keyframes are updated.
        private unsafe void ApplyAngle(int index, float offset)
        {
            NumericInputBox box = chr0Editor._transBoxes[index + 3];
            box.Value = (float)Math.Round(box._value + offset, 3);
            chr0Editor.BoxChanged(box, null);
        }
        //Updates translation with offset.
        private unsafe void ApplyTranslation(int index, float offset)
        {
            NumericInputBox box = chr0Editor._transBoxes[index + 6];
            box.Value = (float)Math.Round(box._value + offset, 3);
            chr0Editor.BoxChanged(box, null);
        }
        //Updates scale with offset.
        private unsafe void ApplyScale(int index, float offset)
        {
            NumericInputBox box = chr0Editor._transBoxes[index];
            float value = (float)Math.Round(box._value * offset, 3);
            if (value == 0) return;
            box.Value = value;
            chr0Editor.BoxChanged(box, null);
        }
        private unsafe void ApplyScale2(int index, float offset)
        {
            NumericInputBox box = chr0Editor._transBoxes[index];

            if (box._value == 0)
                return;

            float scale = (box._value + offset) / box._value;
            
            float value = (float)Math.Round(box._value * scale, 3);
            if (value == 0) return;
            box.Value = value;
            chr0Editor.BoxChanged(box, null);
        }
        public AnimType TargetAnimType
        {
            get { return leftPanel.TargetAnimType; }
            set { leftPanel.TargetAnimType = value; }
        }
        private Control _currentControl = null;
        public int prevHeight = 0, prevWidth = 0;
        public void SetCurrentControl()
        {
            Control newControl = null;
            switch (TargetAnimType)
            {
                case AnimType.CHR:
                    newControl = chr0Editor;
                    break;
                case AnimType.SRT:
                    newControl = srt0Editor;
                    syncTexObjToolStripMenuItem.Checked = true;
                    break;
                case AnimType.SHP:
                    newControl = shp0Editor;
                    break;
                case AnimType.PAT:
                    newControl = pat0Editor;
                    syncTexObjToolStripMenuItem.Checked = true;
                    break;
                case AnimType.VIS:
                    newControl = vis0Editor;
                    break;
                case AnimType.CLR:
                    newControl = clr0Editor;
                    break;
            }
            if (_currentControl != newControl)
            {
                if (_currentControl != null)
                    _currentControl.Visible = false;
                _currentControl = newControl;
                if (!(_currentControl is SRT0Editor) && !(_currentControl is PAT0Editor))
                    syncTexObjToolStripMenuItem.Checked = false;
                if (_currentControl != null)
                {
                    _currentControl.Visible = true;
                    if (_currentControl is CHR0Editor)
                    {
                        animEditors.Height = 78;
                        panel3.Width = 582;
                        //rightPanel.pnlKeyframes.SetEditType(0);
                    }
                    else if (_currentControl is SRT0Editor)
                    {
                        animEditors.Height = 78;
                        panel3.Width = 483;
                        //rightPanel.pnlKeyframes.SetEditType(0);
                    }
                    else if (_currentControl is SHP0Editor)
                    {
                        animEditors.Height = 106;
                        panel3.Width = 533;
                        //rightPanel.pnlKeyframes.SetEditType(0);
                    }
                    else if (_currentControl is PAT0Editor)
                    {
                        animEditors.Height = 78;
                        panel3.Width = 402;
                    }
                    else if (_currentControl is VIS0Editor)
                    {
                        animEditors.Height = 62;
                        panel3.Width = 210;
                        //rightPanel.pnlKeyframes.SetEditType(1);
                    }
                    else if (_currentControl is CLR0Editor)
                    {
                        animEditors.Height = 62;
                        panel3.Width = 168;
                        //rightPanel.pnlKeyframes.SetEditType(2);
                    }
                    else
                        animEditors.Height = panel3.Width = 0;
                }
                else animEditors.Height = panel3.Width = 0;
                return;
            }
            CheckDimensions();
            UpdatePropDisplay();
        }
        public void UpdatePropDisplay()
        {
            if (animEditors.Height == 0 || animEditors.Visible == false)
                return;

            switch (TargetAnimType)
            {
                case AnimType.CHR: chr0Editor.UpdatePropDisplay(); break;
                case AnimType.SRT: srt0Editor.UpdatePropDisplay(); break;
                case AnimType.SHP: shp0Editor.UpdatePropDisplay(); break;
                //case AnimType.VIS: vis0Editor.UpdatePropDisplay(); break;
                case AnimType.PAT: pat0Editor.UpdatePropDisplay(); break;
                //case AnimType.SCN: scn0Editor.UpdatePropDisplay(); break;
                case AnimType.CLR: clr0Editor.UpdatePropDisplay(); break;
            }

            if (TargetAnimType == AnimType.VIS)
            {
                if (rightPanel.pnlKeyframes.visEditor.TargetNode != null && !((VIS0EntryNode)rightPanel.pnlKeyframes.visEditor.TargetNode).Constant)
                {
                    rightPanel.pnlKeyframes.visEditor._updating = true;
                    rightPanel.pnlKeyframes.visEditor.listBox1.SelectedIndices.Clear();
                    rightPanel.pnlKeyframes.visEditor.listBox1.SelectedIndex = CurrentFrame - 1;
                    rightPanel.pnlKeyframes.visEditor._updating = false;
                }
            }
        }

        public bool _editingAll { get { return (!(comboCharacters.SelectedItem is MDL0Node) && comboCharacters.SelectedItem != null && comboCharacters.SelectedItem.ToString() == "All"); } }
        public void UpdateModel()
        {
            if (_updating)
                return;

            if (!_editingAll)
            {
                if (TargetModel != null)
                    UpdateModel(TargetModel);
            }
            else
                foreach (MDL0Node n in _targetModels)
                    UpdateModel(n);

            if (RunTime._articles != null)
                foreach (ArticleInfo a in RunTime._articles)
                    if (a.Running)
                        a.UpdateModel();

            if (!_playing) 
                UpdatePropDisplay();

            modelPanel.Invalidate();
        }
        private void UpdateModel(MDL0Node model)
        {
            if (_chr0 != null && !(TargetAnimType != AnimType.CHR && !playCHR0ToolStripMenuItem.Checked))
                model.ApplyCHR(_chr0, _animFrame);
            else
                model.ApplyCHR(null, 0);
            if (_srt0 != null && !(TargetAnimType != AnimType.SRT && !playSRT0ToolStripMenuItem.Checked))
                model.ApplySRT(_srt0, _animFrame);
            else
                model.ApplySRT(null, 0);
            if (_shp0 != null && !(TargetAnimType != AnimType.SHP && !playSHP0ToolStripMenuItem.Checked))
                model.ApplySHP(_shp0, _animFrame);
            else
                model.ApplySHP(null, 0);
            if (_pat0 != null && !(TargetAnimType != AnimType.PAT && !playPAT0ToolStripMenuItem.Checked))
                model.ApplyPAT(_pat0, _animFrame);
            else
                model.ApplyPAT(null, 0);
            if (_vis0 != null && !(TargetAnimType != AnimType.VIS && !playVIS0ToolStripMenuItem.Checked))
                if (model == TargetModel)
                    ReadVIS0();
                else
                    model.ApplyVIS(_vis0, _animFrame);
            if (_clr0 != null && !(TargetAnimType != AnimType.CLR && !playCLR0ToolStripMenuItem.Checked))
                model.ApplyCLR(_clr0, _animFrame);
            else
                model.ApplyCLR(null, 0);
        }
        
        public void AnimChanged(AnimType type)
        {
            //Update animation editors
            if (type != AnimType.SRT) leftPanel.UpdateSRT0Selection(null);
            if (type != AnimType.PAT) leftPanel.UpdatePAT0Selection(null);

            switch (type)
            {
                case AnimType.CHR:
                    break;
                case AnimType.SRT:
                    leftPanel.UpdateSRT0Selection(SelectedSRT0);
                    break;
                case AnimType.SHP:
                    shp0Editor.UpdateSHP0Indices();
                    break;
                case AnimType.PAT:
                    pat0Editor.UpdateBoxes();
                    leftPanel.UpdatePAT0Selection(SelectedPAT0);
                    break;
                case AnimType.VIS: 
                    vis0Editor.UpdateAnimation();
                    break;
                case AnimType.CLR: 
                    clr0Editor.UpdateAnimation();
                    break;
            }

            //Update keyframe panel
            //pnlKeyframes.TargetSequence = null;
            //btnRightToggle.Enabled = true;
            //switch (TargetAnimType)
            //{
            //    case AnimType.CHR:
            //        if (_chr0 != null && SelectedBone != null)
            //            pnlKeyframes.TargetSequence = _chr0.FindChild(SelectedBone.Name, false);
            //        break;
            //    case AnimType.SRT:
            //        if (_srt0 != null && TargetTexRef != null)
            //            pnlKeyframes.TargetSequence = srt0Editor.TexEntry;
            //        break;
            //    case AnimType.SHP:
            //        if (_shp0 != null)
            //            pnlKeyframes.TargetSequence = shp0Editor.VertexSetDest;
            //        break;
            //    case AnimType.CLR:
            //    case AnimType.VIS:
            //        //if (TargetVisEntry == null) break;
            //        //string name = TargetVisEntry.Name;
            //        //if (_vis0 != null)
            //        //{
            //        //    int i = 0;
            //        //    foreach (object s in vis0Editor.listBox1.Items)
            //        //        if (s.ToString() == name)
            //        //            vis0Editor.listBox1.SelectedIndex = i;
            //        //        else 
            //        //            i++;
            //        //}
            //        break;
            //    default:
            //        if (pnlKeyframes.Visible)
            //            btnRightToggle_Click(null, null);
            //        btnRightToggle.Enabled = false;
            //        break;
            //}

            if (GetAnimation(type) == null)
            {
                pnlPlayback.numFrameIndex.Maximum = _maxFrame = 0;
                pnlPlayback.numTotalFrames.Minimum = 0;
                _updating = true;
                pnlPlayback.numTotalFrames.Value = 0;
                _updating = false;
                pnlPlayback.btnPlay.Enabled =
                pnlPlayback.numTotalFrames.Enabled =
                pnlPlayback.numFrameIndex.Enabled = false;
                pnlPlayback.btnLast.Enabled = false;
                pnlPlayback.btnFirst.Enabled = false;
                pnlPlayback.Enabled = false;
                SetFrame(0);
            }
            else
            {
                int oldMax = _maxFrame;

                _maxFrame = GetAnimation(type).FrameCount;

                _updating = true;
                pnlPlayback.btnPlay.Enabled =
                pnlPlayback.numFrameIndex.Enabled =
                pnlPlayback.numTotalFrames.Enabled = true;
                pnlPlayback.Enabled = true;
                pnlPlayback.numTotalFrames.Value = _maxFrame;
                if (syncLoopToAnimationToolStripMenuItem.Checked)
                    pnlPlayback.chkLoop.Checked = GetAnimation(type).Loop;
                _updating = false;

                if (_maxFrame < oldMax)
                {
                    SetFrame(1);
                    pnlPlayback.numFrameIndex.Maximum = _maxFrame;
                }
                else
                {
                    pnlPlayback.numFrameIndex.Maximum = _maxFrame;
                    SetFrame(1);
                }
            }
        }

        public void numFrameIndex_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)pnlPlayback.numFrameIndex.Value;
            if (val != _animFrame)
            {
                RunTime.SetFrame(val);

                KeyframePanel.numFrame_ValueChanged();
            }
        }

        public bool _playing = false;
        public void SetFrame(int index)
        {
            index = TargetModel == null ? 0 : index.Clamp(0, _maxFrame);

            //if (index < 0)
            //    return;

            //if (index > _maxFrame)
            //    if (Loop)
            //    {
            //        if (MaxFrame == 0)
            //            return;

            //        index = ((index - 1) % MaxFrame) + 1;

            //        //if (RunTime.SelectedSubActionGrp != null && index == 1)
            //        //{
            //        //    if (RunTime.SelectedSubActionGrp.Flags.HasFlag(AnimationFlags.MovesCharacter))
            //        //    {
            //        //        MDL0BoneNode TopN = (FileManager.Moveset._data.boneRef1.Children[0] as MoveDefBoneIndexNode).BoneNode;
            //        //        MDL0BoneNode TransN = (FileManager.Moveset._data._misc.boneRefs.Children[4] as MoveDefBoneIndexNode).BoneNode;
            //        //        Vector3 v = TransN._frameMatrix.GetPoint();
            //        //        TopN._overrideTranslate = v;
            //        //    }
            //        //}
            //    }
            //    else
            //        return;

            CurrentFrame = index;

            pnlPlayback.btnNextFrame.Enabled = _animFrame < _maxFrame;
            pnlPlayback.btnPrevFrame.Enabled = _animFrame > 0;

            pnlPlayback.btnLast.Enabled = _animFrame != _maxFrame;
            pnlPlayback.btnFirst.Enabled = _animFrame > 1;

            if (_animFrame <= pnlPlayback.numFrameIndex.Maximum)
                pnlPlayback.numFrameIndex.Value = _animFrame;
        }
        private bool wasOff = false;
        public bool runningAction = false;

        void _timer_RenderFrame(object sender, FrameEventArgs e)
        {
            if (TargetAnimation == null)
                return;

            if (_animFrame >= _maxFrame)
                if (!_loop)
                    StopAnim();
                else
                    SetFrame(1);
            else
                SetFrame(_animFrame + 1);

            if (_capture)
                images.Add(modelPanel.GrabScreenshot(false));
        }

        public void PlayAnim()
        {
            if (GetAnimation(TargetAnimType) == null || _maxFrame == 1)
                return;

            _playing = true;

            if (disableBonesWhenPlayingToolStripMenuItem.Checked)
            {
                if (RenderBones == false)
                    wasOff = true;

                RenderBones = false;
                toggleBones.Checked = false;
            }

            EnableTransformEdit = false;

            if (_animFrame >= _maxFrame) //Reset anim
                SetFrame(1);

            if (_animFrame < _maxFrame)
            {
                pnlPlayback.btnPlay.Text = "Stop";
                RunTime.Run();
            }
            else
            {
                if (disableBonesWhenPlayingToolStripMenuItem.Checked)
                    RenderBones = true;
                _playing = false;
            }
        }
        public void StopAnim()
        {
            _playing = false;

            if (disableBonesWhenPlayingToolStripMenuItem.Checked)
            {
                if (!wasOff)
                    RenderBones = true;

                wasOff = false;
            }

            pnlPlayback.btnPlay.Text = "Play";
            EnableTransformEdit = true;
            UpdatePropDisplay();

            if (_capture)
            {
                RenderToGIF(images.ToArray());
                images.Clear();
                _capture = false;
            }
        }
    }
}
