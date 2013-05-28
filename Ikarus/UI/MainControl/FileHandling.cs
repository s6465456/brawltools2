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

                    comboCharacters.SelectedItem = TargetModel;
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
            modelPanel.AddTarget(model);
            model.ApplyCHR(null, 0);
            model._renderBones = true;
        }

        public bool CloseExternal()
        {
            return true;
        }

        public bool CloseFiles() 
        {
            try
            {
                if (TargetModel != null)
                    TargetModel.ApplyCHR(null, 0);
                ResetBoneColors();
                return CloseExternal() && rightPanel.pnlMoveset.CloseReferences();
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
                leftPanel.VIS0Indices = _targetModel.VIS0Indices;
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

            leftPanel.Reset();
            rightPanel.pnlBones.Reset();

            if (TargetModelChanged != null)
                TargetModelChanged(this, null);

            _updating = true;
            if (_targetModel != null && !_editingAll)
                comboCharacters.SelectedItem = _targetModel;
            _updating = false;

            if (_targetModel != null)
                RenderBones = _targetModel._renderBones;
        }
    }
}
