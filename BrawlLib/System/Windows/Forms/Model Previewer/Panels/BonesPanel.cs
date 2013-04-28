﻿using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;
using System.Drawing;
using BrawlLib.Modeling;
using System.IO;
using System.ComponentModel;
using BrawlLib;
using System.Collections.Generic;
using BrawlLib.Wii.Models;
using BrawlBox;

namespace System.Windows.Forms
{
    public class ModelAnimPanel : UserControl
    {
        public delegate void ReferenceEventHandler(ResourceNode node);

        #region Designer

        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
        private IContainer components;
        private FolderBrowserDialog folderBrowserDialog1;
        private Panel pnlKeyframes;
        private ImageList imageList1;
        private Splitter spltBones;
        public CheckedListBox lstBones;
        private ContextMenuStrip ctxBones;
        private ToolStripMenuItem boneIndex;
        private ToolStripMenuItem renameBoneToolStripMenuItem;
        private CheckBox chkAllBones;
        private Panel pnlBones;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlKeyframes = new System.Windows.Forms.Panel();
            this.spltBones = new System.Windows.Forms.Splitter();
            this.pnlBones = new System.Windows.Forms.Panel();
            this.lstBones = new System.Windows.Forms.CheckedListBox();
            this.ctxBones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.boneIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.renameBoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAllBones = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlKeyframes.SuspendLayout();
            this.pnlBones.SuspendLayout();
            this.ctxBones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKeyframes
            // 
            this.pnlKeyframes.AutoScroll = true;
            this.pnlKeyframes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlKeyframes.Controls.Add(this.spltBones);
            this.pnlKeyframes.Controls.Add(this.pnlBones);
            this.pnlKeyframes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKeyframes.Location = new System.Drawing.Point(0, 0);
            this.pnlKeyframes.Name = "pnlKeyframes";
            this.pnlKeyframes.Size = new System.Drawing.Size(376, 398);
            this.pnlKeyframes.TabIndex = 26;
            // 
            // spltBones
            // 
            this.spltBones.Location = new System.Drawing.Point(0, 0);
            this.spltBones.Name = "spltBones";
            this.spltBones.Size = new System.Drawing.Size(3, 394);
            this.spltBones.TabIndex = 9;
            this.spltBones.TabStop = false;
            this.spltBones.Visible = false;
            // 
            // pnlBones
            // 
            this.pnlBones.Controls.Add(this.lstBones);
            this.pnlBones.Controls.Add(this.chkAllBones);
            this.pnlBones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBones.Location = new System.Drawing.Point(0, 0);
            this.pnlBones.Name = "pnlBones";
            this.pnlBones.Size = new System.Drawing.Size(372, 394);
            this.pnlBones.TabIndex = 10;
            // 
            // lstBones
            // 
            this.lstBones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBones.CausesValidation = false;
            this.lstBones.ContextMenuStrip = this.ctxBones;
            this.lstBones.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstBones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBones.IntegralHeight = false;
            this.lstBones.Location = new System.Drawing.Point(0, 20);
            this.lstBones.Margin = new System.Windows.Forms.Padding(0);
            this.lstBones.Name = "lstBones";
            this.lstBones.Size = new System.Drawing.Size(372, 374);
            this.lstBones.TabIndex = 8;
            this.lstBones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstBones_ItemCheck_1);
            this.lstBones.SelectedValueChanged += new System.EventHandler(this.lstBones_SelectedValueChanged_1);
            this.lstBones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBones_KeyDown_1);
            this.lstBones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstBones_MouseDown);
            // 
            // ctxBones
            // 
            this.ctxBones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boneIndex,
            this.renameBoneToolStripMenuItem});
            this.ctxBones.Name = "ctxBones";
            this.ctxBones.Size = new System.Drawing.Size(153, 70);
            // 
            // boneIndex
            // 
            this.boneIndex.Enabled = false;
            this.boneIndex.Name = "boneIndex";
            this.boneIndex.Size = new System.Drawing.Size(152, 22);
            this.boneIndex.Text = "Bone Index";
            // 
            // renameBoneToolStripMenuItem
            // 
            this.renameBoneToolStripMenuItem.Name = "renameBoneToolStripMenuItem";
            this.renameBoneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameBoneToolStripMenuItem.Text = "Rename";
            this.renameBoneToolStripMenuItem.Click += new System.EventHandler(this.renameBoneToolStripMenuItem_Click);
            // 
            // chkAllBones
            // 
            this.chkAllBones.Checked = true;
            this.chkAllBones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllBones.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllBones.Location = new System.Drawing.Point(0, 0);
            this.chkAllBones.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllBones.Name = "chkAllBones";
            this.chkAllBones.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.chkAllBones.Size = new System.Drawing.Size(372, 20);
            this.chkAllBones.TabIndex = 28;
            this.chkAllBones.Text = "All";
            this.chkAllBones.UseVisualStyleBackColor = false;
            this.chkAllBones.CheckStateChanged += new System.EventHandler(this.chkAllBones_CheckStateChanged_1);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ModelAnimPanel
            // 
            this.Controls.Add(this.pnlKeyframes);
            this.Name = "ModelAnimPanel";
            this.Size = new System.Drawing.Size(376, 398);
            this.pnlKeyframes.ResumeLayout(false);
            this.pnlBones.ResumeLayout(false);
            this.ctxBones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ModelEditControl _mainWindow;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ModelEditControl MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        private object _targetObject;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object TargetObject
        {
            get { return _targetObject; }
            set { _targetObject = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0MaterialRefNode TargetTexRef { get { return _mainWindow._targetTexRef; } set { _mainWindow.TargetTexRef = value; } }

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
        public CHR0Node SelectedCHR0 { get { return _mainWindow.SelectedCHR0; } set { _mainWindow.SelectedCHR0 = value; } }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode SelectedBone 
        {
            get { return _mainWindow.SelectedBone; } 
            set
            {
                _mainWindow.SelectedBone = value;
            } 
        }

        public ModelAnimPanel() { InitializeComponent(); }
        //public bool CloseReferences() { return CloseExternal(); }

        private void lstBones_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SelectedBone != null)
                {
                    lstBones.ContextMenuStrip = ctxBones;
                    boneIndex.Text = "Bone Index: " + SelectedBone.BoneIndex.ToString();
                }
                else
                    lstBones.ContextMenuStrip = null;
            }
        }

        public bool _updating;

        internal void Reset()
        {
            lstBones.BeginUpdate();
            lstBones.Items.Clear();
            
            if (TargetModel != null && TargetModel._linker != null)
                foreach (MDL0BoneNode bone in TargetModel._linker.BoneCache)
                    lstBones.Items.Add(bone, bone._render);

            lstBones.EndUpdate();
        }

        private void lstBones_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (SelectedBone != null)
                SelectedBone._boneColor = SelectedBone._nodeColor = Color.Transparent;

            if ((TargetObject = SelectedBone = lstBones.SelectedItem as MDL0BoneNode) != null)
            {

            }

            _mainWindow.modelPanel.Invalidate();
        }

        private void lstBones_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                lstBones.SelectedItem = null;
        }

        private void chkAllBones_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (lstBones.Items.Count == 0)
                return;

            _updating = true;

            lstBones.BeginUpdate();
            for (int i = 0; i < lstBones.Items.Count; i++)
                lstBones.SetItemCheckState(i, chkAllBones.CheckState);
            lstBones.EndUpdate();

            _updating = false;

            _mainWindow.modelPanel.Invalidate();
        }

        private void lstBones_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            MDL0BoneNode bone = lstBones.Items[e.Index] as MDL0BoneNode;

            bone._render = e.NewValue == CheckState.Checked;

            if (!_updating)
                _mainWindow.modelPanel.Invalidate();
        }

        private void renameBoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RenameDialog().ShowDialog(this, lstBones.SelectedItem as MDL0BoneNode);
        }
    }
}
