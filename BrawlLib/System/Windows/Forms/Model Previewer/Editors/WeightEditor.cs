using System;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Modeling;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;
using BrawlLib.Wii.Models;
using System.Linq;

namespace System.Windows.Forms
{
    public class WeightEditor : UserControl
    {
        #region Designer

        private System.ComponentModel.IContainer components;
        private void InitializeComponent()
        {
            this.lstBoneWeights = new System.Windows.Forms.RefreshingListBox();
            this.btnAddBone = new System.Windows.Forms.Button();
            this.btnSetWeight = new System.Windows.Forms.Button();
            this.numWeight = new System.Windows.Forms.NumericInputBox();
            this.btnBlend = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnRemoveBone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoneWeights
            // 
            this.lstBoneWeights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoneWeights.FormattingEnabled = true;
            this.lstBoneWeights.IntegralHeight = false;
            this.lstBoneWeights.Location = new System.Drawing.Point(3, 3);
            this.lstBoneWeights.Name = "lstBoneWeights";
            this.lstBoneWeights.Size = new System.Drawing.Size(117, 72);
            this.lstBoneWeights.TabIndex = 0;
            this.lstBoneWeights.SelectedIndexChanged += new System.EventHandler(this.lstBoneWeights_SelectedIndexChanged);
            // 
            // btnAddBone
            // 
            this.btnAddBone.Location = new System.Drawing.Point(126, 3);
            this.btnAddBone.Name = "btnAddBone";
            this.btnAddBone.Size = new System.Drawing.Size(94, 23);
            this.btnAddBone.TabIndex = 1;
            this.btnAddBone.Text = "Add Bone";
            this.btnAddBone.UseVisualStyleBackColor = true;
            this.btnAddBone.Click += new System.EventHandler(this.btnAddBone_Click);
            // 
            // btnSetWeight
            // 
            this.btnSetWeight.Location = new System.Drawing.Point(191, 28);
            this.btnSetWeight.Name = "btnSetWeight";
            this.btnSetWeight.Size = new System.Drawing.Size(79, 22);
            this.btnSetWeight.TabIndex = 2;
            this.btnSetWeight.Text = "Set Weight";
            this.btnSetWeight.UseVisualStyleBackColor = true;
            this.btnSetWeight.Click += new System.EventHandler(this.btnSetWeight_Click);
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(127, 29);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(62, 20);
            this.numWeight.TabIndex = 3;
            this.numWeight.Text = "0";
            // 
            // btnBlend
            // 
            this.btnBlend.Location = new System.Drawing.Point(254, 52);
            this.btnBlend.Name = "btnBlend";
            this.btnBlend.Size = new System.Drawing.Size(62, 23);
            this.btnBlend.TabIndex = 4;
            this.btnBlend.Text = "Blend";
            this.btnBlend.UseVisualStyleBackColor = true;
            this.btnBlend.Click += new System.EventHandler(this.btnBlend_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(127, 52);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(62, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(191, 52);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(62, 23);
            this.btnPaste.TabIndex = 6;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(271, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 22);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(294, 28);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(22, 22);
            this.btnSubtract.TabIndex = 8;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // btnRemoveBone
            // 
            this.btnRemoveBone.Location = new System.Drawing.Point(221, 3);
            this.btnRemoveBone.Name = "btnRemoveBone";
            this.btnRemoveBone.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveBone.TabIndex = 9;
            this.btnRemoveBone.Text = "Remove Bone";
            this.btnRemoveBone.UseVisualStyleBackColor = true;
            this.btnRemoveBone.Click += new System.EventHandler(this.btnRemoveBone_Click);
            // 
            // WeightEditor
            // 
            this.Controls.Add(this.btnRemoveBone);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnBlend);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.btnSetWeight);
            this.Controls.Add(this.btnAddBone);
            this.Controls.Add(this.lstBoneWeights);
            this.Name = "WeightEditor";
            this.Size = new System.Drawing.Size(318, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public WeightEditor() { InitializeComponent(); }

        private RefreshingListBox lstBoneWeights;

        public ModelEditControl _mainWindow;
        private Button btnAddBone;
        private Button btnSetWeight;
        private NumericInputBox numWeight;
        private Button btnBlend;
        private Button btnCopy;
        private Button btnPaste;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnRemoveBone;

        public List<BoneWeight> _boneWeights { get { return _vertex == null ? null : _vertex.MatrixNode == null ? _vertex._object.MatrixNode.Weights : _vertex.MatrixNode.Weights; } }
        public MDL0BoneNode[] _bones { get { return _boneWeights == null ? null : _boneWeights.Select(x => x.Bone).ToArray(); } }
        public float[] _weightValues { get { return _boneWeights == null ? null : _boneWeights.Select(x => x.Weight).ToArray(); } }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentFrame
        {
            get { return _mainWindow.CurrentFrame; }
            set { _mainWindow.CurrentFrame = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0Node TargetModel
        {
            get { return _mainWindow.TargetModel; }
            set { _mainWindow.TargetModel = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode TargetBone { get { return _mainWindow._targetBone; } set { _mainWindow.TargetBone = value; } }

        private Vertex3 _vertex = null;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IMatrixNode TargetInfluence
        {
            get { return _vertex != null ? _vertex.MatrixNode : null; }
            set { if (_vertex == null) return; _vertex.MatrixNode = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Vertex3 TargetVertex
        {
            get { return _vertex; }
            set { SetVertex(value); }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BoneWeight TargetBoneWeight
        {
            get { return _targetBoneWeight; }
            set 
            {
                _targetBoneWeight = value;
                btnAdd.Enabled = _targetBoneWeight.Weight != 1.0f;
                btnSubtract.Enabled = _targetBoneWeight.Weight != 0.0f;
                numWeight.Value = _targetBoneWeight.Weight * 100.0f;
            }
        }
        internal BoneWeight _targetBoneWeight;
        public void SetVertex(Vertex3 vertex)
        {
            lstBoneWeights.Items.Clear();

            //Remove weights with value 0 from the current vertex's influence
            if (_vertex != null)
                for (int i = 0; i < _boneWeights.Count; i++)
                    if (_boneWeights[i].Weight == 0.0f)
                        _boneWeights.RemoveAt(i--);

            if ((_vertex = vertex) != null)
                lstBoneWeights.Items.AddRange(_boneWeights.ToArray());
        }
        public void SetWeight(float value)
        {
            if (_boneWeights.Count == 1)
            {
                _targetBoneWeight.Weight = 1.0f; 
                return;
            }

            value = value.Clamp(0.0f, 1.0f);
            float diff = _targetBoneWeight.Weight - value;
            _targetBoneWeight.Weight = value;
            float total = _boneWeights.Count - 1;
            if (total == 0) return;
            float val = diff / total;
            for (int i = 0; i < _boneWeights.Count; i++)
                if (_boneWeights[i] != TargetBoneWeight)
                    _boneWeights[i].Weight += val;

            if (TargetInfluence is Influence)
                ((Influence)TargetInfluence).Normalize();

            numWeight.Value = _targetBoneWeight.Weight * 100.0f;
            UpdateValues();
        }
        public void UpdateValues()
        {
            lstBoneWeights.RefreshItems();
            btnAdd.Enabled = _targetBoneWeight.Weight != 1.0f;
            btnSubtract.Enabled = _targetBoneWeight.Weight != 0.0f;
            numWeight.Value = _targetBoneWeight.Weight * 100.0f;
        }
        public void BoneChanged()
        {
            if (_bones != null)
            if (_bones.Contains(TargetBone))
                btnAddBone.Enabled = false;
            else
                btnAddBone.Enabled = true;
        }

        private void btnAddBone_Click(object sender, EventArgs e)
        {
            _boneWeights.Add(new BoneWeight(TargetBone, 0.0f));
        }

        private void lstBoneWeights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoneWeights.SelectedIndex >= 0)
                TargetBoneWeight = lstBoneWeights.Items[lstBoneWeights.SelectedIndex] as BoneWeight;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {

        }

        private void btnBlend_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemoveBone_Click(object sender, EventArgs e)
        {

        }
        float increment = 0.1f;
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetWeight(_targetBoneWeight.Weight - increment);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetWeight(_targetBoneWeight.Weight + increment);
        }

        private void btnSetWeight_Click(object sender, EventArgs e)
        {
            SetWeight(numWeight.Value / 100.0f);
        }
    }

    public class RefreshingListBox : ListBox
    {
        public new void RefreshItem(int index)
        {
            base.RefreshItem(index);
        }

        public new void RefreshItems()
        {
            base.RefreshItems();
        }
    }
}
