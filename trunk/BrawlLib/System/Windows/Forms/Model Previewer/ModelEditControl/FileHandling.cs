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
    public partial class ModelEditControl : UserControl
    {
        private void btnLoadMoveset_Click(object sender, EventArgs e)
        {
            if (btnLoadMoveset.Text == "Load")
            {
                if (pnlMoveset.LoadMoveset())
                {
                    showMoveset.Checked = true;
                    btnLoadMoveset.Text = "Close";
                }
            }
            else
            {
                if (pnlMoveset.CloseMoveset())
                {
                    showMoveset.Checked = false;
                    btnLoadMoveset.Text = "Load";
                }
            }
        }

        private void btnSaveMoveset_Click(object sender, EventArgs e) { pnlMoveset.SaveMoveset(); }

        public ResourceNode _externalAnimationsNode;
        private SaveFileDialog dlgSave = new SaveFileDialog();
        private OpenFileDialog dlgOpen = new OpenFileDialog();
        private bool LoadExternal()
        {
            dlgOpen.Filter = "All Compatible Files (*.pac, *.pcs, *.brres, *.chr0, *.srt0, *.pat0, *.vis0, *.shp0, *.scn0, *.clr0, *.mrg)|*.pac;*.pcs;*.brres;*.chr0;*.srt0;*.pat0;*.vis0;*.shp0;*.scn0;*.clr0;*.mrg";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                ResourceNode node = null;
                pnlAssets.listAnims.BeginUpdate();
                try
                {
                    if ((node = NodeFactory.FromFile(null, dlgOpen.FileName)) != null)
                    {
                        if (!CloseExternal())
                            return false;

                        if (!pnlAssets.LoadAnims(node, TargetAnimType))
                            MessageBox.Show(this, "No animations could be found in external file.", "Error");
                        else
                        {
                            _externalAnimationsNode = node;
                            node = null;
                            //txtExtPath.Text = Path.GetFileName(dlgOpen.FileName);

                            modelPanel.AddReference(_externalAnimationsNode);

                            return true;
                        }
                    }
                    else
                        MessageBox.Show(this, "Unable to recognize input file.");
                }
                catch (Exception x) { MessageBox.Show(this, x.ToString()); }
                finally
                {
                    if (node != null)
                        node.Dispose();
                    pnlAssets.listAnims.EndUpdate();
                }
            }
            return false;
        }
        private bool CloseExternal()
        {
            if (_externalAnimationsNode != null)
            {
                if (_externalAnimationsNode.IsDirty)
                {
                    DialogResult res = MessageBox.Show(this, "You have made changes to an external file. Would you like to save those changes?", "Closing external file.", MessageBoxButtons.YesNoCancel);
                    if (((res == DialogResult.Yes) && (!SaveExternal(false))) || (res == DialogResult.Cancel))
                        return false;
                }

                modelPanel.RemoveReference(_externalAnimationsNode);
                pnlAssets._closing = true;
                pnlAssets.listAnims.Items.Clear();
                pnlAssets._closing = false;
                _externalAnimationsNode.Dispose();
                _externalAnimationsNode = null;

                if (SelectedBone != null)
                    SelectedBone._boneColor = SelectedBone._nodeColor = Color.Transparent;

                pnlAssets.UpdateAnimations(TargetAnimType);
                SetSelectedBRRESFile(TargetAnimType, null);
                GetFiles(AnimType.None);
                UpdatePropDisplay();
                UpdateModel();

                //txtExtPath.Text = "";
            }
            return true;
        }
        private bool SaveExternal(bool As)
        {
            if ((_externalAnimationsNode == null) || ((!_externalAnimationsNode.IsDirty) && !As))
                return true;

            try
            {
                if (As)
                    using (SaveFileDialog d = new SaveFileDialog())
                    {
                        d.InitialDirectory = _externalAnimationsNode._origPath.Substring(0, _externalAnimationsNode._origPath.LastIndexOf('\\'));
                        d.Filter = String.Format("(*{0})|*{0}", Path.GetExtension(_externalAnimationsNode._origPath));
                        d.Title = "Please choose a location to save this file.";
                        if (d.ShowDialog(this) == DialogResult.OK)
                        {
                            _externalAnimationsNode.Merge();
                            _externalAnimationsNode.Export(d.FileName);
                        }
                    }
                else
                {
                    _externalAnimationsNode.Merge();
                    _externalAnimationsNode.Export(_externalAnimationsNode._origPath);
                }
                return true;
            }
            catch (Exception x) { MessageBox.Show(this, x.ToString()); }
            return false;
        }

        public void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (btnOpenClose.Text == "Load")
            {
                if (LoadExternal())
                    btnOpenClose.Text = pnlAssets.Load.Text = "Close";
            }
            else if (btnOpenClose.Text == "Close" && CloseExternal())
                btnOpenClose.Text = pnlAssets.Load.Text = "Load";
        }
        public void btnSave_Click(object sender, EventArgs e) { SaveExternal(false); }
        private void btnSaveAs_Click(object sender, EventArgs e) { SaveExternal(true); }
        private void ModelEditControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ModelEditControl_DragDrop(object sender, DragEventArgs e)
        {
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (a != null)
            {
                string s = null;
                for (int i = 0; i < a.Length; i++)
                {
                    s = a.GetValue(i).ToString();
                    this.BeginInvoke(m_DelegateOpenFile, new Object[] { s });
                }
            }
        }
        private void OpenFile(string file)
        {
            ResourceNode node = null;
            try
            {
                if ((node = NodeFactory.FromFile(null, file)) != null)
                {
                    if (_targetModels == null)
                        _targetModels = new List<MDL0Node>();

                    LoadModels(node, _targetModels);

                    if (TargetModel == null)
                        TargetModel = _targetModels[0];

                    models.SelectedItem = TargetModel;
                }
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Error loading model(s) from file."); }
        }

        private void LoadModels(ResourceNode node, List<MDL0Node> models)
        {
            switch (node.ResourceType)
            {
                case ResourceType.ARC:
                case ResourceType.U8:
                case ResourceType.U8Folder:
                case ResourceType.MRG:
                case ResourceType.BRES:
                case ResourceType.BRESGroup:
                    foreach (ResourceNode n in node.Children)
                        LoadModels(n, models);
                    break;
                case ResourceType.MDL0:
                    AppendTarget((MDL0Node)node);
                    break;
            }
        }

        public void AppendTarget(MDL0Node model)
        {
            if (!_targetModels.Contains(model))
                _targetModels.Add(model);
            if (!models.Items.Contains(model))
                models.Items.Add(model);
            modelPanel.AddTarget(model);
            model.ApplyCHR(null, 0);
            model._renderBones = true;
        }

        public bool CloseFiles() 
        {
            try
            {
                TargetModel.ApplyCHR(null, 0);
                ResetBoneColors();
                return CloseExternal() && pnlMoveset.CloseReferences();
            }
            catch { return true; }
        }

        public bool _resetCam = true;
        public bool _hide = false;
        private void ModelChanged(MDL0Node model)
        {
            if (model != null && !_targetModels.Contains(model))
                _targetModels.Add(model);

            if (_targetModel != null)
                _targetModel._isTargetModel = false;

            if (model == null)
                modelPanel.RemoveTarget(_targetModel);

            if ((_targetModel = model) != null)
            {
                modelPanel.AddTarget(_targetModel);
                pnlAssets.VIS0Indices = _targetModel.VIS0Indices;
                _targetModel._isTargetModel = true;
                ResetVertexColors();
            }

            if (_resetCam)
            {
                modelPanel.ResetCamera();
                SetFrame(0);
            }
            else
                _resetCam = true;

            pnlAssets.Reset();
            pnlBones.Reset();

            if (TargetModelChanged != null)
                TargetModelChanged(this, null);

            _updating = true;
            if (_targetModel != null && !_editingAll)
                models.SelectedItem = _targetModel;
            _updating = false;

            if (_targetModel != null)
                RenderBones = _targetModel._renderBones;
        }
    }
}
