using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.OpenGL;
using BrawlLib.Modeling;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.IO;
using System.IO;
using System.Drawing;
using BrawlLib.Properties;

namespace BrawlBox
{
    class ModelForm : Form
    {
        #region Designer

        private ModelEditControl modelEditControl1;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelForm));
            this.modelEditControl1 = new System.Windows.Forms.ModelEditControl();
            this.SuspendLayout();
            // 
            // modelEditControl1
            // 
            this.modelEditControl1.AllowDrop = true;
            this.modelEditControl1.BackColor = System.Drawing.Color.Lavender;
            this.modelEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelEditControl1.ImgExtIndex = 0;
            this.modelEditControl1.Location = new System.Drawing.Point(0, 0);
            this.modelEditControl1.Name = "modelEditControl1";
            this.modelEditControl1.Size = new System.Drawing.Size(639, 528);
            this.modelEditControl1.TabIndex = 0;
            this.modelEditControl1.TargetAnimType = System.Windows.Forms.AnimType.CHR;
            this.modelEditControl1.TargetModelChanged += new System.EventHandler(this.TargetModelChanged);
            // 
            // ModelForm
            // 
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(639, 528);
            this.Controls.Add(this.modelEditControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelForm_FormClosing);
            this.ResumeLayout(false);

        }
        #endregion

        public ModelForm() { InitializeComponent(); }

        private System.ComponentModel.IContainer components;

        private List<MDL0Node> _models = new List<MDL0Node>();

        public DialogResult ShowDialog(List<MDL0Node> models) { return ShowDialog(null, models); }
        public DialogResult ShowDialog(IWin32Window owner, List<MDL0Node> models) 
        {
            _models = models;
            try { return base.ShowDialog(owner); }
            finally { _models = null; }
        }
        public DialogResult ShowDialog(MDL0Node model) { return ShowDialog(null, model); }
        public DialogResult ShowDialog(IWin32Window owner, MDL0Node model)
        {
            _models.Add(model);
            try { return base.ShowDialog(owner); }
            finally { _models = null; }
        }

        public void Show(List<MDL0Node> models) { Show(null, models); }
        public void Show(IWin32Window owner, List<MDL0Node> models)
        {
            _models = models;
            base.Show(owner);
        }
        public void Show(MDL0Node model) { Show(null, model); }
        public void Show(IWin32Window owner, MDL0Node model)
        {
            _models.Add(model);
            base.Show(owner);
        }

        public unsafe void ReadSettings()
        {
            BBVS settings = new BBVS();
            string ScreenCapBgLocText = "";

            modelEditControl1._updating = true;
            modelEditControl1.storeSettingsExternallyToolStripMenuItem.Checked = BrawlLib.Properties.Settings.Default.External;
            modelEditControl1._updating = false;

            bool ext = File.Exists(Application.StartupPath + "/brawlbox.settings") && modelEditControl1.storeSettingsExternallyToolStripMenuItem.Checked;
            if (ext)
            {
                using (FileMap map = FileMap.FromFile(Application.StartupPath + "/brawlbox.settings", FileMapProtect.Read))
                {
                    if (*(uint*)map.Address == BBVS.Tag)
                    {
                        settings = *(BBVS*)map.Address;
                        ScreenCapBgLocText = new String((sbyte*)map.Address + ((BBVS*)map.Address)->_screenCapPathOffset);
                    }
                    else
                        ext = false;
                }
            }
            
            if (!ext)
            {
                settings = BrawlLib.Properties.Settings.Default.ViewerSettings;
                ScreenCapBgLocText = BrawlLib.Properties.Settings.Default.ScreenCapBgLocText;
            }

            if (!settings.UseModelViewerSettings)
            {
                modelEditControl1.clearSavedSettingsToolStripMenuItem.Enabled = false;
                return;
            }
            else
                modelEditControl1.clearSavedSettingsToolStripMenuItem.Enabled = true;

            modelEditControl1.modelPanel.BeginUpdate();

            modelEditControl1.syncAnimationsTogetherToolStripMenuItem.Checked = settings.RetrieveCorrAnims;
            modelEditControl1.syncLoopToAnimationToolStripMenuItem.Checked = settings.SyncLoopToAnim;
            modelEditControl1.syncTexObjToolStripMenuItem.Checked = settings.SyncTexToObj;
            modelEditControl1.syncObjectsListToVIS0ToolStripMenuItem.Checked = settings.SyncObjToVIS0;
            modelEditControl1.disableBonesWhenPlayingToolStripMenuItem.Checked = settings.DisableBonesOnPlay;

            modelEditControl1.modelPanel._ambient = settings._amb;
            modelEditControl1.modelPanel._position = settings._pos;
            modelEditControl1.modelPanel._diffuse = settings._diff;
            modelEditControl1.modelPanel._specular = settings._spec;

            modelEditControl1.modelPanel._fovY = settings._yFov;
            modelEditControl1.modelPanel._nearZ = settings._nearZ;
            modelEditControl1.modelPanel._farZ = settings._farz;

            modelEditControl1.modelPanel.ZoomScale = settings._zScale;
            modelEditControl1.modelPanel.TranslationScale = settings._tScale;
            modelEditControl1.modelPanel.RotationScale = settings._rScale;

            MDL0BoneNode.DefaultNodeColor = (Color)settings._orbColor;
            MDL0BoneNode.DefaultBoneColor = (Color)settings._lineColor;
            ModelEditControl._floorHue = (Color)settings._floorColor;
            if (settings.CameraSet)
            {
                modelEditControl1.btnSaveCam.Text = "Clear Camera";
                modelEditControl1.modelPanel._defaultTranslate = settings._defaultCam;
                modelEditControl1.modelPanel._defaultRotate = settings._defaultRot;
            }

            modelEditControl1._allowedUndos = settings._undoCount;
            modelEditControl1.modelPanel._emission = settings._emis;
            modelEditControl1.ImgExtIndex = settings.ImageCapFmt;
            modelEditControl1.RenderBones = settings.Bones;

            if (settings.Wireframe)
                modelEditControl1.RenderPolygons = CheckState.Indeterminate;
            else if (settings.Polys)
                modelEditControl1.RenderPolygons = CheckState.Checked;
            else
                modelEditControl1.RenderPolygons = CheckState.Unchecked;
            
            modelEditControl1.RenderVertices = settings.Vertices;
            modelEditControl1.RenderBox = settings.BoundingBox;
            modelEditControl1.RenderNormals = settings.Normals;
            modelEditControl1.DontRenderOffscreen = settings.HideOffscreen;
            modelEditControl1.showCameraCoordinatesToolStripMenuItem.Checked = settings.ShowCamCoords;
            modelEditControl1.RenderFloor = settings.Floor;
            modelEditControl1.enablePointAndLineSmoothingToolStripMenuItem.Checked = settings.EnableSmoothing;
            modelEditControl1.enableTextOverlaysToolStripMenuItem.Checked = settings.EnableText;

            if (!String.IsNullOrEmpty(ScreenCapBgLocText))
                modelEditControl1.ScreenCapBgLocText.Text = ScreenCapBgLocText;
            else
                modelEditControl1.ScreenCapBgLocText.Text = Application.StartupPath;
            //modelEditControl1.orthographicToolStripMenuItem.Checked = settings.OrthoCam;

            if (settings.Maximize)
                WindowState = FormWindowState.Maximized;

            modelEditControl1.modelPanel.EndUpdate();

            modelEditControl1.modelPanel.ResetCamera();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            if (_models.Count != 0)
            {
                for (int i = 0; i < _models.Count; i++)
                    if (_models[i] != null)
                        modelEditControl1.AppendTarget(_models[i]);
                modelEditControl1.TargetModel = _models[0];
                modelEditControl1.ResetBoneColors();
            }

            ReadSettings();

            modelEditControl1.modelPanel.Capture();

            GenericWrapper._modelViewerOpen = true;
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (!(e.Cancel = !modelEditControl1.CloseFiles()))
            {
                try
                {
                    if (modelEditControl1.TargetModel != null)
                        modelEditControl1.TargetModel = null;

                    if (modelEditControl1._targetModels != null)
                        modelEditControl1._targetModels = null;

                    modelEditControl1.modelPanel.ClearAll();
                    modelEditControl1.models.Items.Clear();

                    MainForm.Instance.modelPanel1.Capture();
                    MainForm.Instance.resourceTree_SelectionChanged(this, null);
                }
                catch { }
            }

            GenericWrapper._modelViewerOpen = false;
        }
        private void TargetModelChanged(object sender, EventArgs e)
        {
            if (modelEditControl1.TargetModel != null)
                Text = String.Format("Advanced Model Editor - {0}", modelEditControl1.TargetModel.Name);
            else
                Text = "Advanced Model Editor";
        }
    }
}
