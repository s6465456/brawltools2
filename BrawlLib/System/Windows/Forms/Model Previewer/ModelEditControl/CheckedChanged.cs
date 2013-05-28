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

namespace System.Windows.Forms
{
    public partial class ModelEditControl : UserControl, IMainWindow
    {
        private void toggleNormals_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;

            _updating = true;
            RenderNormals = toggleNormals.Checked;
            _updating = false;
        }
        private unsafe void storeSettingsExternallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            BrawlLib.Properties.Settings.Default.External = storeSettingsExternallyToolStripMenuItem.Checked;

            BBVS settings = new BBVS();
            if (BrawlLib.Properties.Settings.Default.External)
            {
                settings = BrawlLib.Properties.Settings.Default.ViewerSettings;
                using (FileStream stream = new FileStream(Application.StartupPath + "/brawlbox.settings", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 8, FileOptions.SequentialScan))
                {
                    CompactStringTable s = new CompactStringTable();
                    s.Add(ScreenCapBgLocText.Text);
                    stream.SetLength((long)BBVS.Size + s.TotalSize);
                    using (FileMap map = FileMap.FromStream(stream))
                    {
                        *(BBVS*)map.Address = settings;
                        s.WriteTable(map.Address + BBVS.Size);
                        ((BBVS*)map.Address)->_screenCapPathOffset = (uint)s[ScreenCapBgLocText.Text] - (uint)map.Address;
                    }
                }
            }
            else
            {
                if (File.Exists(Application.StartupPath + "/brawlbox.settings"))
                    using (FileMap map = FileMap.FromFile(Application.StartupPath + "/brawlbox.settings", FileMapProtect.Read))
                        if (*(uint*)map.Address == BBVS.Tag)
                            settings = *(BBVS*)map.Address;

                BrawlLib.Properties.Settings.Default.ViewerSettings = settings;
                BrawlLib.Properties.Settings.Default.ScreenCapBgLocText = ScreenCapBgLocText.Text;
                BrawlLib.Properties.Settings.Default.Save();
            }
        }
        private void orthographicToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _updating = true;
            if (orthographicToolStripMenuItem.Checked)
            {
                modelPanel.SetProjectionType(true);
                perspectiveToolStripMenuItem.Checked = false;
            }
            else
            {
                modelPanel.SetProjectionType(false);
                perspectiveToolStripMenuItem.Checked = true;
            }
            _updating = false;
        }

        private void perspectiveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _updating = true;
            if (perspectiveToolStripMenuItem.Checked)
            {
                modelPanel.SetProjectionType(false);
                orthographicToolStripMenuItem.Checked = false;
            }
            else
            {
                modelPanel.SetProjectionType(true);
                orthographicToolStripMenuItem.Checked = true;
            }
            _updating = false;
        }
        private void stretchToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (stretchToolStripMenuItem1.Checked)
            {
                _updating = true;
                centerToolStripMenuItem1.Checked = resizeToolStripMenuItem1.Checked = false;
                modelPanel._bgType = GLPanel.BackgroundType.Stretch;
                _updating = false;
                modelPanel.Invalidate();
            }
        }

        private void centerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (centerToolStripMenuItem1.Checked)
            {
                _updating = true;
                stretchToolStripMenuItem1.Checked = resizeToolStripMenuItem1.Checked = false;
                modelPanel._bgType = GLPanel.BackgroundType.Center;
                _updating = false;
                modelPanel.Invalidate();
            }
        }

        private void resizeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (resizeToolStripMenuItem1.Checked)
            {
                _updating = true;
                centerToolStripMenuItem1.Checked = stretchToolStripMenuItem1.Checked = false;
                modelPanel._bgType = GLPanel.BackgroundType.ResizeWithBars;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        private void chkShaders_CheckedChanged(object sender, EventArgs e)
        {
            if (modelPanel._ctx != null)
            {
                if (modelPanel._ctx._version < 2 && chkShaders.Checked)
                {
                    MessageBox.Show("You need at least OpenGL 2.0 to view shaders.", "GLSL not supported",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    chkShaders.Checked = false;
                    return;
                }
                else
                {
                    if (modelPanel._ctx._canUseShaders && !chkShaders.Checked) { GL.UseProgram(0); GL.ClientActiveTexture(TextureUnit.Texture0); }
                    modelPanel._ctx._canUseShaders = chkShaders.Checked;
                }
            }
            modelPanel.Invalidate();
        }

        private void showCameraCoordinatesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            modelPanel._showCamCoords = showCameraCoordinatesToolStripMenuItem.Checked;
        }

        private void enableTextOverlaysToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            modelPanel._textEnabled = enableTextOverlaysToolStripMenuItem.Checked;
        }

        private void enablePointAndLineSmoothingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            modelPanel._enableSmoothing = enablePointAndLineSmoothingToolStripMenuItem.Checked;
        }

        private void stPersonToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rotationToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (rotationToolStripMenuItem.Checked)
            {
                _updating = true;
                scaleToolStripMenuItem.Checked = translationToolStripMenuItem.Checked = false;
                _editType = TransformType.Rotation;
                _snapCirc = _snapX = _snapY = _snapZ = false;
                _updating = false;
                modelPanel.Invalidate();
            }
            else if (translationToolStripMenuItem.Checked == rotationToolStripMenuItem.Checked == scaleToolStripMenuItem.Checked)
                _editType = TransformType.None;
        }

        private void translationToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (translationToolStripMenuItem.Checked)
            {
                _updating = true;
                rotationToolStripMenuItem.Checked = scaleToolStripMenuItem.Checked = false;
                _editType = TransformType.Translation;
                _snapCirc = _snapX = _snapY = _snapZ = false;
                _updating = false;
                modelPanel.Invalidate();
            }
            else if (translationToolStripMenuItem.Checked == rotationToolStripMenuItem.Checked == scaleToolStripMenuItem.Checked)
                _editType = TransformType.None;
        }

        private void scaleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            if (scaleToolStripMenuItem.Checked)
            {
                _updating = true;
                rotationToolStripMenuItem.Checked = translationToolStripMenuItem.Checked = false;
                _editType = TransformType.Scale;
                _snapCirc = _snapX = _snapY = _snapZ = false;
                _updating = false;
                modelPanel.Invalidate();
            }
            else if (translationToolStripMenuItem.Checked == rotationToolStripMenuItem.Checked == scaleToolStripMenuItem.Checked)
                _editType = TransformType.None;
        }
        private void displayBRRESRelativeAnimationsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            leftPanel.BRRESRelative = displayBRRESRelativeAnimationsToolStripMenuItem.CheckState;
            leftPanel.UpdateAnimations(TargetAnimType);
            switch (leftPanel.BRRESRelative)
            {
                case CheckState.Checked:
                    displayBRRESRelativeAnimationsToolStripMenuItem.Text = "Displaying only BRRES animations"; break;
                case CheckState.Indeterminate:
                    displayBRRESRelativeAnimationsToolStripMenuItem.Text = "Displaying BRRES and external animations"; break;
                case CheckState.Unchecked:
                    displayBRRESRelativeAnimationsToolStripMenuItem.Text = "Displaying all animations"; break;
            }
        }

        private void chkPolygons_CheckStateChanged(object sender, EventArgs e)
        {
            if (!_updating)
                RenderPolygons = chkPolygons.CheckState;
        }

        private void displayFrameCountDifferencesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            DialogResult d;
            if (!displayFrameCountDifferencesToolStripMenuItem.Checked)
            {
                if ((d = MessageBox.Show("Do you want to sync animation frame counts by default?", "Sync Frame Counts by Default", MessageBoxButtons.YesNo)) == DialogResult.Yes && !alwaysSyncFrameCountsToolStripMenuItem.Checked)
                    alwaysSyncFrameCountsToolStripMenuItem.Checked = true;
                else if (d == DialogResult.No)
                    alwaysSyncFrameCountsToolStripMenuItem.Checked = false;
            }
            else
                alwaysSyncFrameCountsToolStripMenuItem.Checked = false;
        }

        private void syncObjectsListToVIS0ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            leftPanel.chkSyncVis.Checked = syncObjectsListToVIS0ToolStripMenuItem.Checked;
        }

        private void syncAnimationsTogetherToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (syncAnimationsTogetherToolStripMenuItem.Checked)
                GetFiles(TargetAnimType);
            else
                GetFiles(AnimType.None);
        }
        public void pnlAnim_ReferenceLoaded(ResourceNode node) { modelPanel.AddReference(node); }

        public void CHR0StateChanged(object sender, EventArgs e)
        {
            if (_chr0 == null)
                return;

            if (_animFrame < _chr0.FrameCount)
                SetFrame(_animFrame);
            pnlPlayback.numTotalFrames.Value = _chr0.FrameCount;
        }
        public void SRT0StateChanged(object sender, EventArgs e)
        {
            if (_srt0 == null)
                return;

            if (_animFrame < _srt0.FrameCount)
                SetFrame(_animFrame);
            pnlPlayback.numTotalFrames.Value = _srt0.FrameCount;
        }
        public void SHP0StateChanged(object sender, EventArgs e)
        {
            if (_shp0 == null)
                return;

            if (_animFrame < _shp0.FrameCount)
                SetFrame(_animFrame);
            pnlPlayback.numTotalFrames.Value = _shp0.FrameCount;
        }
        public void VIS0StateChanged(object sender, EventArgs e)
        {
            if (_vis0 == null)
                return;

            if (_animFrame < _vis0.FrameCount)
                SetFrame(_animFrame);
            pnlPlayback.numTotalFrames.Value = _vis0.FrameCount;
        }
        public void PAT0StateChanged(object sender, EventArgs e)
        {
            if (_pat0 == null)
                return;

            if (_animFrame < _pat0.FrameCount)
                SetFrame(_animFrame);
            pnlPlayback.numTotalFrames.Value = _pat0.FrameCount;
        }

        private void pnlOptions_FloorRenderChanged(object sender, EventArgs e)
        {
            if (RenderFloor == false)
                toggleFloor.Checked = false;
            else
                toggleFloor.Checked = true;

            modelPanel.Invalidate();
        }

        private void Undo(object sender, EventArgs e)
        {
            if (btnUndo.Enabled)
                btnUndo_Click(null, null);
        }
        private void Redo(object sender, EventArgs e)
        {
            if (btnRedo.Enabled)
                btnRedo_Click(null, null);
        }
        //private void ApplySave(object sender, EventArgs e)
        //{
        //    SaveState save = _save;
        //    pnlAnim.ApplySave(save);
        //    SetFrame(save.frameIndex);
        //    modelPanel1.Invalidate();
        //}
        public void numFrameIndex_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)pnlPlayback.numFrameIndex.Value;
            if (val != _animFrame)
            {
                int difference = val - _animFrame;
                //if (pnlMoveset._mainMoveset != null && pnlMoveset.selectedActionNodes.Count > 0)
                //{
                //    //Run frame value through the moveset panel.
                //    if (val < _animFrame)
                //    {
                //        if (pnlMoveset._animFrame > 0)
                //            pnlMoveset.SetFrame(pnlMoveset._animFrame + difference);
                //        else if (pnlMoveset.subactions)
                //            pnlMoveset.SetFrame(_maxFrame - 1);
                //    }
                //    else if (val > _animFrame)
                //        if (pnlMoveset.ActionsIdling || (pnlMoveset.subactions && pnlMoveset._animFrame >= _maxFrame - 1))
                //        {
                //            if (pnlMoveset.subactions && pnlMoveset.selectedSubActionGrp != null)
                //                if (_animFrame < _maxFrame)
                //                {
                //                    SetFrame(_animFrame + difference);
                //                    pnlMoveset._animFrame += difference;
                //                }
                //                else
                //                    pnlMoveset.SetFrame(0);
                //        }
                //        else
                //            pnlMoveset.SetFrame(pnlMoveset._animFrame + difference);
                //}
                //else 
                if (GetSelectedBRRESFile(TargetAnimType) != null)
                    SetFrame(_animFrame += difference);
                rightPanel.pnlKeyframes.numFrame_ValueChanged();
            }
        }
        public void numFPS_ValueChanged(object sender, EventArgs e) { /*pnlMoveset.animTimer.Interval = */animTimer.Interval = pnlPlayback.numFPS.Value == 60 ? 1 : 1000 / (int)pnlPlayback.numFPS.Value; }
        public void chkLoop_CheckedChanged(object sender, EventArgs e) 
        {
            _loop = pnlPlayback.chkLoop.Checked;
            if (syncLoopToAnimationToolStripMenuItem.Checked && !_updating)
                ((BRESEntryNode)GetSelectedBRRESFile(TargetAnimType)).Loop = _loop;
        }

        //private void FileChanged(object sender, EventArgs e)
        //{
        //    movesetToolStripMenuItem1.Visible = chkHurtboxes.Visible = chkHitboxes.Visible = chkHurtboxes.Checked = pnlMoveset._mainMoveset != null;
        //}

        private void RenderStateChanged(object sender, EventArgs e)
        {
            modelPanel.Invalidate();
        }

        private void HtBoxesChanged(object sender, EventArgs e)
        {
            if (chkHurtboxes.Checked)
                hurtboxesOffToolStripMenuItem.Checked = true;
            else
                hurtboxesOffToolStripMenuItem.Checked = false;

            if (chkHitboxes.Checked)
                hitboxesOffToolStripMenuItem.Checked = true;
            else
                hitboxesOffToolStripMenuItem.Checked = false;
            
            modelPanel.Invalidate(); 
        }

        public void SelectedPolygonChanged(object sender, EventArgs e) 
        {
            _targetModel._polyIndex = _targetModel._polyList.IndexOf(leftPanel.SelectedPolygon);

            if (leftPanel._syncObjTex)
                leftPanel.UpdateTextures();

            if (TargetAnimType == AnimType.VIS)
                if (leftPanel.TargetObject != null && vis0Editor.listBox1.Items.Count != 0)
                {
                    int x = 0;
                    foreach (object i in vis0Editor.listBox1.Items)
                        if (i.ToString() == leftPanel.TargetObject.VisibilityBone)
                        {
                            vis0Editor.listBox1.SelectedIndex = x;
                            break;
                        }
                        else
                            x++;
                    if (x == vis0Editor.listBox1.Items.Count)
                        vis0Editor.listBox1.SelectedIndex = -1;
                }

            modelPanel.Invalidate(); 
        }

        public void numTotalFrames_ValueChanged(object sender, EventArgs e)
        {
            if ((GetSelectedBRRESFile(TargetAnimType) == null) || (_updating))
                return;

            _maxFrame = (int)pnlPlayback.numTotalFrames.Value;

            ResourceNode n;
            if (alwaysSyncFrameCountsToolStripMenuItem.Checked)
                for (int i = 0; i < 5; i++)
                    if ((n = GetSelectedBRRESFile((AnimType)i)) != null) 
                        //if (i == 5) ((BRESEntryNode)n).tFrameCount = _maxFrame - 1; else 
                        ((BRESEntryNode)n).FrameCount = _maxFrame;
                    else { }
            else
            {
                if ((n = GetSelectedBRRESFile(TargetAnimType)) != null)
                    ((BRESEntryNode)n).FrameCount = _maxFrame;
                if (displayFrameCountDifferencesToolStripMenuItem.Checked)
                    if (MessageBox.Show("Do you want to update the frame counts of the other animation types?", "Update Frame Counts?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    for (int i = 0; i < 5; i++)
                        if (i != (int)TargetAnimType && (n = GetSelectedBRRESFile((AnimType)i)) != null)
                            ((BRESEntryNode)n).FrameCount = _maxFrame;
            }

            pnlPlayback.numFrameIndex.Maximum = _maxFrame;
        }
        private void showAssets_CheckedChanged(object sender, EventArgs e)
        {
            leftPanel.Visible = spltLeft.Visible = showLeft.Checked;
            btnLeftToggle.Text = showLeft.Checked == false ? ">" : "<";
        }
        private void showAnim_CheckedChanged(object sender, EventArgs e)
        {
            rightPanel.Visible = spltRight.Visible = showRight.Checked;
            btnRightToggle.Text = showRight.Checked == false ? "<" : ">";
        }
        //private void showMoveset_CheckedChanged(object sender, EventArgs e)
        //{
        //    pnlMoveset.Visible = spltAnims.Visible = showMoveset.Checked;
        //    DetermineRight();
        //}
        public void DetermineRight()
        {
            if (rightPanel.Visible)
                btnRightToggle.Text = ">";
            else
                btnRightToggle.Text = "<";
        }
        private void showPlay_CheckedChanged(object sender, EventArgs e) 
        {
            animEditors.Visible = !animEditors.Visible;
            //if (_currentControl is CHR0Editor)
            //{
            //    animEditors.Height =
            //    panel3.Height = 82;
            //    panel3.Width = 732;
            //}
            //else if (_currentControl is SRT0Editor)
            //{
            //    animEditors.Height =
            //    panel3.Height = 82;
            //    panel3.Width = 561;
            //}
            //else if (_currentControl is SHP0Editor)
            //{
            //    animEditors.Height =
            //    panel3.Height = 106;
            //    panel3.Width = 533;
            //}
            //else if (_currentControl is PAT0Editor)
            //{
            //    animEditors.Height =
            //    panel3.Height = 77;
            //    panel3.Width = 402;
            //}
            //else if (_currentControl is VIS0Editor)
            //{
            //    animEditors.Height =
            //    panel3.Height = 112;
            //    panel3.Width = 507;
            //}
            //else
            //    animEditors.Height = panel3.Width = 0;
            CheckDimensions();
        }
        private void showOptions_CheckedChanged(object sender, EventArgs e) { controlPanel.Visible = showOptions.Checked; }
        //private void undoToolStripMenuItem_EnabledChanged(object sender, EventArgs e) { Undo.Enabled = undoToolStripMenuItem.Enabled; }
        //private void redoToolStripMenuItem_EnabledChanged(object sender, EventArgs e) { Redo.Enabled = redoToolStripMenuItem.Enabled; }
        
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updating)
                RenderVertices = chkVertices.Checked;
        }

        private void models_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _resetCam = false;

            if ((models.SelectedItem is MDL0Node) && models.SelectedItem.ToString() != "All")
                TargetModel = (MDL0Node)models.SelectedItem;
            else
                TargetModel = _targetModels != null && _targetModels.Count > 0 ? _targetModels[0] : null;

            _undoSaves.Clear();
            _redoSaves.Clear();
            _saveIndex = -1;
        }

        private void chkBones_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updating)
                RenderBones = chkBones.Checked;
        }

        private void chkFloor_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updating)
                RenderFloor = chkFloor.Checked;
        }

        private void boundingBoxToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updating)
                RenderBox = boundingBoxToolStripMenuItem.Checked;
        }

        private void chkDontRenderOffscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updating)
                DontRenderOffscreen = chkDontRenderOffscreen.Checked;
        }

        private void chr0Editor_VisibleChanged(object sender, EventArgs e)
        {
            //pnlEditors.Height = pnlPlayback.Height + (chr0Editor.Visible ? chr0Editor.Height : 0);
        }
    }
}
