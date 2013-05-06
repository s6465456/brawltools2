﻿using System;
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

namespace System.Windows.Forms
{
    public partial class ModelEditControl : UserControl
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
            get { return (AnimType)pnlAssets.fileType.SelectedIndex; }
            set { pnlAssets.fileType.SelectedIndex = (int)value; }
        }
        private Control _currentControl = null;
        public int prevHeight = 0, prevWidth = 0;
        public void ToggleWeightEditor()
        {
            if (weightEditor.Visible)
            {
                panel3.Height = prevHeight;
                panel3.Width = prevWidth;
                weightEditor.Visible = false;
                _currentControl.Visible = true;
            }
            else
            {
                if (vertexEditor.Visible)
                    ToggleVertexEditor();

                prevHeight = panel3.Height;
                prevWidth = panel3.Width;
                panel3.Width = 320;
                panel3.Height = 78;
                weightEditor.Visible = true;
                _currentControl.Visible = false;
            }

            CheckDimensions();
        }
        public void ToggleVertexEditor()
        {
            if (vertexEditor.Visible)
            {
                panel3.Height = prevHeight;
                panel3.Width = prevWidth;
                vertexEditor.Visible = false;
                _currentControl.Visible = true;
            }
            else
            {
                if (weightEditor.Visible)
                    ToggleWeightEditor();

                prevHeight = panel3.Height;
                prevWidth = panel3.Width;
                panel3.Width = 118;
                panel3.Height = 85;
                vertexEditor.Visible = true;
                _currentControl.Visible = false;
            }

            CheckDimensions();
        }
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
                case AnimType.SCN:
                    newControl = scn0Editor;
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
                        pnlKeyframes.SetEditType(0);
                    }
                    else if (_currentControl is SRT0Editor)
                    {
                        animEditors.Height = 78;
                        panel3.Width = 483;
                        pnlKeyframes.SetEditType(0);
                    }
                    else if (_currentControl is SHP0Editor)
                    {
                        animEditors.Height = 106;
                        panel3.Width = 533;
                        pnlKeyframes.SetEditType(0);
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
                        pnlKeyframes.SetEditType(1);
                    }
                    else if (_currentControl is CLR0Editor)
                    {
                        animEditors.Height = 62;
                        panel3.Width = 168;
                        pnlKeyframes.SetEditType(2);
                    }
                    else if (_currentControl is SCN0Editor)
                    {
                        scn0Editor.GetDimensions();
                        pnlKeyframes.SetEditType(3);
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

            if (TargetAnimType == AnimType.CHR)
            {
                chr0Editor.UpdatePropDisplay();
                chr0Editor.btnInsert.Enabled =
                chr0Editor.btnDelete.Enabled =
                chr0Editor.btnClearAll.Enabled = SelectedCHR0 == null ? false : true;
            }

            if (TargetAnimType == AnimType.SRT)
            {
                srt0Editor.UpdatePropDisplay();
                srt0Editor.btnInsert.Enabled =
                srt0Editor.btnDelete.Enabled =
                srt0Editor.btnClear.Enabled = SelectedSRT0 == null ? false : true;
            }

            if (TargetAnimType == AnimType.VIS)
            {
                if (pnlKeyframes.visEditor.TargetNode != null && !((VIS0EntryNode)pnlKeyframes.visEditor.TargetNode).Flags.HasFlag(VIS0Flags.Constant))
                {
                    pnlKeyframes.visEditor._updating = true;
                    pnlKeyframes.visEditor.listBox1.SelectedIndices.Clear();
                    pnlKeyframes.visEditor.listBox1.SelectedIndex = CurrentFrame;
                    pnlKeyframes.visEditor._updating = false;
                }
            }

            if (TargetAnimType == AnimType.SHP)
                shp0Editor.UpdatePropDisplay();

            if (TargetAnimType == AnimType.PAT)
                pat0Editor.UpdatePropDisplay();

            if (TargetAnimType == AnimType.SCN)
                scn0Editor.UpdatePropDisplay();
        }

        public bool _editingAll { get { return (!(models.SelectedItem is MDL0Node) && models.SelectedItem != null && models.SelectedItem.ToString() == "All"); } }
        public void UpdateModel()
        {
            if (_updating || models == null)
                return;

            if (!_editingAll)
            {
                if (TargetModel != null)
                    UpdateModel(TargetModel);
            }
            else
                foreach (MDL0Node n in _targetModels)
                    UpdateModel(n);

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
            if (_scn0 != null/* && !(TargetFileType != FileType.SCN && !playSCN0ToolStripMenuItem.Checked)*/)
                model.SetSCN0Frame(_animFrame);
            else
                model.SetSCN0Frame(0);
            if (_clr0 != null && !(TargetAnimType != AnimType.CLR && !playCLR0ToolStripMenuItem.Checked))
                model.ApplyCLR(_clr0, _animFrame);
            else
                model.ApplyCLR(null, 0);
        }
        
        public void AnimChanged(AnimType type)
        {
            //Update animation editors
            if (type != AnimType.SRT) pnlAssets.UpdateSRT0Selection(null);
            if (type != AnimType.PAT) pnlAssets.UpdatePAT0Selection(null);
            if (type != AnimType.SCN)
                foreach (MDL0Node m in _targetModels)
                    m.SetSCN0(null);

            switch (type)
            {
                case AnimType.CHR:
                    break;
                case AnimType.SRT:
                    pnlAssets.UpdateSRT0Selection(SelectedSRT0);
                    break;
                case AnimType.SHP:
                    shp0Editor.UpdateSHP0Indices();
                    break;
                case AnimType.PAT:
                    pat0Editor.UpdateBoxes();
                    pnlAssets.UpdatePAT0Selection(SelectedPAT0);
                    break;
                case AnimType.VIS: 
                    vis0Editor.UpdateAnimation();
                    break;
                case AnimType.SCN:
                    //foreach (MDL0Node m in _targetModels)
                    //    m.SetSCN0(_scn0);
                    scn0Editor.tabControl1_Selected(null, new TabControlEventArgs(null, scn0Editor.tabIndex, TabControlAction.Selected));
                    break;
                case AnimType.CLR: 
                    clr0Editor.UpdateAnimation();
                    break;
            }

            //Update keyframe panel
            pnlKeyframes.TargetSequence = null;
            btnAnimToggle.Enabled = true;
            switch (TargetAnimType)
            {
                case AnimType.CHR:
                    if (_chr0 != null && SelectedBone != null)
                        pnlKeyframes.TargetSequence = _chr0.FindChild(SelectedBone.Name, false);
                    break;
                case AnimType.SRT:
                    if (_srt0 != null && TargetTexRef != null)
                        pnlKeyframes.TargetSequence = srt0Editor.TexEntry;
                    break;
                case AnimType.SHP:
                    if (_shp0 != null)
                        pnlKeyframes.TargetSequence = shp0Editor.VertexSetDest;
                    break;
                case AnimType.CLR:
                case AnimType.VIS:
                    //if (TargetVisEntry == null) break;
                    //string name = TargetVisEntry.Name;
                    //if (_vis0 != null)
                    //{
                    //    int i = 0;
                    //    foreach (object s in vis0Editor.listBox1.Items)
                    //        if (s.ToString() == name)
                    //            vis0Editor.listBox1.SelectedIndex = i;
                    //        else 
                    //            i++;
                    //}
                    break;
                default:
                    if (pnlKeyframes.Visible)
                        btnAnimToggle_Click(null, null);
                    btnAnimToggle.Enabled = false;
                    break;
            }

            if (GetSelectedBRRESFile(type) == null)
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

                _maxFrame = ((BRESEntryNode)GetSelectedBRRESFile(type)).tFrameCount;

                _updating = true;
                pnlPlayback.btnPlay.Enabled =
                pnlPlayback.numFrameIndex.Enabled =
                pnlPlayback.numTotalFrames.Enabled = true;
                pnlPlayback.Enabled = true;
                pnlPlayback.numTotalFrames.Value = _maxFrame;
                if (syncLoopToAnimationToolStripMenuItem.Checked)
                    pnlPlayback.chkLoop.Checked = ((BRESEntryNode)GetSelectedBRRESFile(type)).tLoop;
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

        public bool _playing = false;
        public void SetFrame(int index)
        {
            //if (_animFrame == index)
            //    return;

            if (index > _maxFrame || index < 0)
                return;
            
            index = TargetModel == null ? 0 : index;

            CurrentFrame = index;

            if (firstPersonSCN0CamToolStripMenuItem.Checked && _scn0 != null && scn0Editor._camera != null)
            {
                SCN0CameraNode c = scn0Editor._camera;
                CameraAnimationFrame f = c.GetAnimFrame(index - 1);
                Vector3 r = c.GetRotate(index);
                Vector3 t = f.Pos;
                modelPanel._camera.Reset();
                modelPanel._camera.Translate(t._x, t._y, t._z);
                modelPanel._camera.Rotate(r._x, r._y, r._z);
                modelPanel._aspect = f.Aspect;
                modelPanel._farZ = f.FarZ;
                modelPanel._nearZ = f.NearZ;
                modelPanel._fovY = f.FovY;
                modelPanel.OnResized();
            }

            pnlPlayback.btnNextFrame.Enabled = _animFrame < _maxFrame;
            pnlPlayback.btnPrevFrame.Enabled = _animFrame > 0;

            pnlPlayback.btnLast.Enabled = _animFrame != _maxFrame;
            pnlPlayback.btnFirst.Enabled = _animFrame > 1;

            if (_animFrame <= pnlPlayback.numFrameIndex.Maximum)
                pnlPlayback.numFrameIndex.Value = _animFrame;
        }
        private bool wasOff = false;
        public bool runningAction = false;
        public void PlayAnim()
        {
            if (GetSelectedBRRESFile(TargetAnimType) == null || _maxFrame == 1)
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
                animTimer.Start();
                pnlPlayback.btnPlay.Text = "Stop";
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
            animTimer.Stop();

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
        private void animTimer_Tick(object sender, EventArgs e)
        {
            if (GetSelectedBRRESFile(TargetAnimType) == null)
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
    }
}
