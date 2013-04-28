﻿using System;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using System.ComponentModel;
using System.Collections.Generic;
using BrawlLib.Modeling;
using System.Drawing;

namespace System.Windows.Forms
{
    public class SRT0Editor : UserControl
    {
        #region Designer
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FrameScale = new System.Windows.Forms.CheckBox();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPaste = new System.Windows.Forms.Button();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.FrameRot = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCut = new System.Windows.Forms.Button();
            this.subtract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.FrameTrans = new System.Windows.Forms.CheckBox();
            this.numScaleY = new System.Windows.Forms.NumericInputBox();
            this.add = new System.Windows.Forms.ToolStripMenuItem();
            this.numRot = new System.Windows.Forms.NumericInputBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Source = new System.Windows.Forms.ToolStripMenuItem();
            this.numTransX = new System.Windows.Forms.NumericInputBox();
            this.numTransY = new System.Windows.Forms.NumericInputBox();
            this.lblTransX = new System.Windows.Forms.Label();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRot = new System.Windows.Forms.Label();
            this.ctxBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCustomAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRawTangentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpTransform = new System.Windows.Forms.GroupBox();
            this.lblScaleX = new System.Windows.Forms.Label();
            this.numScaleX = new System.Windows.Forms.NumericInputBox();
            this.AllScale = new System.Windows.Forms.CheckBox();
            this.grpTransAll = new System.Windows.Forms.GroupBox();
            this.AllRot = new System.Windows.Forms.CheckBox();
            this.AllTrans = new System.Windows.Forms.CheckBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnPasteAll = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.ctxBox.SuspendLayout();
            this.grpTransform.SuspendLayout();
            this.grpTransAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameScale
            // 
            this.FrameScale.AutoSize = true;
            this.FrameScale.Checked = true;
            this.FrameScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameScale.Location = new System.Drawing.Point(249, 58);
            this.FrameScale.Name = "FrameScale";
            this.FrameScale.Size = new System.Drawing.Size(53, 17);
            this.FrameScale.TabIndex = 35;
            this.FrameScale.Text = "Scale";
            this.FrameScale.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem7.Text = "+45";
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(101, 55);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(50, 20);
            this.btnPaste.TabIndex = 23;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "+90";
            // 
            // FrameRot
            // 
            this.FrameRot.AutoSize = true;
            this.FrameRot.Checked = true;
            this.FrameRot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameRot.Location = new System.Drawing.Point(208, 58);
            this.FrameRot.Name = "FrameRot";
            this.FrameRot.Size = new System.Drawing.Size(43, 17);
            this.FrameRot.TabIndex = 34;
            this.FrameRot.Text = "Rot";
            this.FrameRot.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(52, 55);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(50, 20);
            this.btnCopy.TabIndex = 22;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "+180";
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(3, 55);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(50, 20);
            this.btnCut.TabIndex = 21;
            this.btnCut.Text = "Cut";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // subtract
            // 
            this.subtract.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8});
            this.subtract.Name = "subtract";
            this.subtract.Size = new System.Drawing.Size(166, 22);
            this.subtract.Text = "Subtract From All";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem5.Text = "-180";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem6.Text = "-90";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem8.Text = "-45";
            // 
            // FrameTrans
            // 
            this.FrameTrans.AutoSize = true;
            this.FrameTrans.Checked = true;
            this.FrameTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameTrans.Location = new System.Drawing.Point(155, 58);
            this.FrameTrans.Name = "FrameTrans";
            this.FrameTrans.Size = new System.Drawing.Size(53, 17);
            this.FrameTrans.TabIndex = 33;
            this.FrameTrans.Text = "Trans";
            this.FrameTrans.UseVisualStyleBackColor = true;
            // 
            // numScaleY
            // 
            this.numScaleY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleY.Location = new System.Drawing.Point(154, 35);
            this.numScaleY.Name = "numScaleY";
            this.numScaleY.Size = new System.Drawing.Size(82, 20);
            this.numScaleY.TabIndex = 18;
            this.numScaleY.Text = "0";
            this.numScaleY.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numScaleY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numScaleY_MouseDown);
            // 
            // add
            // 
            this.add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem7});
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(166, 22);
            this.add.Text = "Add To All";
            // 
            // numRot
            // 
            this.numRot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRot.Location = new System.Drawing.Point(235, 35);
            this.numRot.Name = "numRot";
            this.numRot.Size = new System.Drawing.Size(82, 20);
            this.numRot.TabIndex = 15;
            this.numRot.Text = "0";
            this.numRot.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numRot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numRotX_MouseDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // Source
            // 
            this.Source.Enabled = false;
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(166, 22);
            this.Source.Text = "Source";
            // 
            // numTransX
            // 
            this.numTransX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTransX.Location = new System.Drawing.Point(73, 16);
            this.numTransX.Name = "numTransX";
            this.numTransX.Size = new System.Drawing.Size(82, 20);
            this.numTransX.TabIndex = 3;
            this.numTransX.Text = "0";
            this.numTransX.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numTransX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numTransX_MouseDown);
            // 
            // numTransY
            // 
            this.numTransY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTransY.Location = new System.Drawing.Point(154, 16);
            this.numTransY.Name = "numTransY";
            this.numTransY.Size = new System.Drawing.Size(82, 20);
            this.numTransY.TabIndex = 13;
            this.numTransY.Text = "0";
            this.numTransY.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numTransY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numTransY_MouseDown);
            // 
            // lblTransX
            // 
            this.lblTransX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransX.Location = new System.Drawing.Point(4, 16);
            this.lblTransX.Name = "lblTransX";
            this.lblTransX.Size = new System.Drawing.Size(70, 20);
            this.lblTransX.TabIndex = 4;
            this.lblTransX.Text = "Translation:";
            this.lblTransX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.removeAllToolStripMenuItem.Text = "Remove All";
            // 
            // lblRot
            // 
            this.lblRot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRot.Location = new System.Drawing.Point(235, 16);
            this.lblRot.Name = "lblRot";
            this.lblRot.Size = new System.Drawing.Size(82, 20);
            this.lblRot.TabIndex = 7;
            this.lblRot.Text = "Rotation:";
            this.lblRot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctxBox
            // 
            this.ctxBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Source,
            this.toolStripSeparator1,
            this.add,
            this.subtract,
            this.removeAllToolStripMenuItem,
            this.addCustomAmountToolStripMenuItem,
            this.editRawTangentToolStripMenuItem});
            this.ctxBox.Name = "ctxBox";
            this.ctxBox.Size = new System.Drawing.Size(167, 164);
            // 
            // addCustomAmountToolStripMenuItem
            // 
            this.addCustomAmountToolStripMenuItem.Name = "addCustomAmountToolStripMenuItem";
            this.addCustomAmountToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addCustomAmountToolStripMenuItem.Text = "Edit All...";
            this.addCustomAmountToolStripMenuItem.Click += new System.EventHandler(this.addCustomAmountToolStripMenuItem_Click_1);
            // 
            // editRawTangentToolStripMenuItem
            // 
            this.editRawTangentToolStripMenuItem.Name = "editRawTangentToolStripMenuItem";
            this.editRawTangentToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editRawTangentToolStripMenuItem.Text = "Edit Raw Tangent";
            this.editRawTangentToolStripMenuItem.Click += new System.EventHandler(this.editRawTangentToolStripMenuItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 20);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpTransform
            // 
            this.grpTransform.Controls.Add(this.lblScaleX);
            this.grpTransform.Controls.Add(this.numScaleX);
            this.grpTransform.Controls.Add(this.FrameScale);
            this.grpTransform.Controls.Add(this.btnPaste);
            this.grpTransform.Controls.Add(this.FrameRot);
            this.grpTransform.Controls.Add(this.btnCopy);
            this.grpTransform.Controls.Add(this.FrameTrans);
            this.grpTransform.Controls.Add(this.btnCut);
            this.grpTransform.Controls.Add(this.numScaleY);
            this.grpTransform.Controls.Add(this.numRot);
            this.grpTransform.Controls.Add(this.numTransX);
            this.grpTransform.Controls.Add(this.numTransY);
            this.grpTransform.Controls.Add(this.lblTransX);
            this.grpTransform.Controls.Add(this.lblRot);
            this.grpTransform.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTransform.Enabled = false;
            this.grpTransform.Location = new System.Drawing.Point(0, 0);
            this.grpTransform.Name = "grpTransform";
            this.grpTransform.Size = new System.Drawing.Size(321, 78);
            this.grpTransform.TabIndex = 28;
            this.grpTransform.TabStop = false;
            this.grpTransform.Text = "Transform Frame";
            // 
            // lblScaleX
            // 
            this.lblScaleX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScaleX.Location = new System.Drawing.Point(4, 35);
            this.lblScaleX.Name = "lblScaleX";
            this.lblScaleX.Size = new System.Drawing.Size(70, 20);
            this.lblScaleX.TabIndex = 37;
            this.lblScaleX.Text = "Scale:";
            this.lblScaleX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numScaleX
            // 
            this.numScaleX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleX.Location = new System.Drawing.Point(73, 35);
            this.numScaleX.Name = "numScaleX";
            this.numScaleX.Size = new System.Drawing.Size(82, 20);
            this.numScaleX.TabIndex = 36;
            this.numScaleX.Text = "0";
            this.numScaleX.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numScaleX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numScaleX_MouseDown);
            // 
            // AllScale
            // 
            this.AllScale.AutoSize = true;
            this.AllScale.Checked = true;
            this.AllScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllScale.Location = new System.Drawing.Point(108, 57);
            this.AllScale.Name = "AllScale";
            this.AllScale.Size = new System.Drawing.Size(53, 17);
            this.AllScale.TabIndex = 32;
            this.AllScale.Text = "Scale";
            this.AllScale.UseVisualStyleBackColor = true;
            // 
            // grpTransAll
            // 
            this.grpTransAll.Controls.Add(this.AllScale);
            this.grpTransAll.Controls.Add(this.AllRot);
            this.grpTransAll.Controls.Add(this.AllTrans);
            this.grpTransAll.Controls.Add(this.btnClean);
            this.grpTransAll.Controls.Add(this.btnPasteAll);
            this.grpTransAll.Controls.Add(this.btnCopyAll);
            this.grpTransAll.Controls.Add(this.btnClear);
            this.grpTransAll.Controls.Add(this.btnInsert);
            this.grpTransAll.Controls.Add(this.btnDelete);
            this.grpTransAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransAll.Enabled = false;
            this.grpTransAll.Location = new System.Drawing.Point(321, 0);
            this.grpTransAll.Name = "grpTransAll";
            this.grpTransAll.Size = new System.Drawing.Size(162, 78);
            this.grpTransAll.TabIndex = 29;
            this.grpTransAll.TabStop = false;
            this.grpTransAll.Text = "Transform All";
            // 
            // AllRot
            // 
            this.AllRot.AutoSize = true;
            this.AllRot.Checked = true;
            this.AllRot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllRot.Location = new System.Drawing.Point(108, 38);
            this.AllRot.Name = "AllRot";
            this.AllRot.Size = new System.Drawing.Size(43, 17);
            this.AllRot.TabIndex = 31;
            this.AllRot.Text = "Rot";
            this.AllRot.UseVisualStyleBackColor = true;
            // 
            // AllTrans
            // 
            this.AllTrans.AutoSize = true;
            this.AllTrans.Checked = true;
            this.AllTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllTrans.Location = new System.Drawing.Point(108, 19);
            this.AllTrans.Name = "AllTrans";
            this.AllTrans.Size = new System.Drawing.Size(53, 17);
            this.AllTrans.TabIndex = 30;
            this.AllTrans.Text = "Trans";
            this.AllTrans.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(55, 35);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(50, 20);
            this.btnClean.TabIndex = 29;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnPasteAll
            // 
            this.btnPasteAll.Location = new System.Drawing.Point(6, 35);
            this.btnPasteAll.Name = "btnPasteAll";
            this.btnPasteAll.Size = new System.Drawing.Size(50, 20);
            this.btnPasteAll.TabIndex = 28;
            this.btnPasteAll.Text = "Paste";
            this.btnPasteAll.UseVisualStyleBackColor = true;
            this.btnPasteAll.Click += new System.EventHandler(this.btnPasteAll_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(6, 54);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(50, 20);
            this.btnCopyAll.TabIndex = 27;
            this.btnCopyAll.Text = "Copy";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(55, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 20);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(55, 54);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(50, 20);
            this.btnInsert.TabIndex = 24;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // SRT0Editor
            // 
            this.Controls.Add(this.grpTransAll);
            this.Controls.Add(this.grpTransform);
            this.Name = "SRT0Editor";
            this.Size = new System.Drawing.Size(483, 78);
            this.ctxBox.ResumeLayout(false);
            this.grpTransform.ResumeLayout(false);
            this.grpTransform.PerformLayout();
            this.grpTransAll.ResumeLayout(false);
            this.grpTransAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox FrameScale;
        private ToolStripMenuItem toolStripMenuItem7;
        private Button btnPaste;
        private ToolStripMenuItem toolStripMenuItem4;
        private CheckBox FrameRot;
        private Button btnCopy;
        private ToolStripMenuItem toolStripMenuItem3;
        private Button btnCut;
        private ToolStripMenuItem subtract;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem8;
        private CheckBox FrameTrans;
        private NumericInputBox numScaleY;
        private ToolStripMenuItem add;
        internal NumericInputBox numRot;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem Source;
        internal NumericInputBox numTransX;
        internal NumericInputBox numTransY;
        private Label lblTransX;
        private ToolStripMenuItem removeAllToolStripMenuItem;
        private Label lblRot;
        private ContextMenuStrip ctxBox;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem addCustomAmountToolStripMenuItem;
        public Button btnDelete;
        private GroupBox grpTransform;
        private CheckBox AllScale;
        private GroupBox grpTransAll;
        private CheckBox AllRot;
        private CheckBox AllTrans;
        public Button btnClean;
        public Button btnPasteAll;
        public Button btnCopyAll;
        public Button btnClear;
        public Button btnInsert;
        private Label lblScaleX;
        private NumericInputBox numScaleX;

        public ModelEditControl _mainWindow;

        public event EventHandler CreateUndo;

        internal NumericInputBox[] _transBoxes = new NumericInputBox[9];
        private ToolStripMenuItem editRawTangentToolStripMenuItem;
        private AnimationFrame _tempFrame = AnimationFrame.Identity;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode TargetBone { get { return _mainWindow.SelectedBone; } set { _mainWindow.SelectedBone = value; } }

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
        public SRT0Node SelectedAnimation
        {
            get { return _mainWindow.SelectedSRT0; }
            set { _mainWindow.SelectedSRT0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableTransformEdit
        {
            get { return _mainWindow._enableTransform; }
            set { grpTransform.Enabled = grpTransAll.Enabled = (_mainWindow.EnableTransformEdit = value) && (TargetTexRef != null); }
        }

        public SRT0TextureNode TexEntry
        {
            get 
            {
                MDL0MaterialRefNode mr = TargetTexRef;
                if (mr != null && SelectedAnimation != null)
                    return SelectedAnimation.FindChild(mr.Parent.Name + "/Texture" + mr.Index, true) as SRT0TextureNode;
                else return null;
            }
        }

        public SRT0Editor()
        {
            InitializeComponent();
            _transBoxes[0] = numScaleX; numScaleX.Tag = 0;
            _transBoxes[1] = numScaleY; numScaleY.Tag = 1;
            //_transBoxes[2] = numScaleZ; numScaleZ.Tag = 2;
            _transBoxes[3] = numRot; numRot.Tag = 3;
            //_transBoxes[4] = numRotY; numRotY.Tag = 4;
            //_transBoxes[5] = numRotZ; numRotZ.Tag = 5;
            _transBoxes[6] = numTransX; numTransX.Tag = 6;
            _transBoxes[7] = numTransY; numTransY.Tag = 7;
            //_transBoxes[8] = numTransZ; numTransZ.Tag = 8;
        }
        public void UpdatePropDisplay()
        {
            grpTransAll.Enabled = EnableTransformEdit && (SelectedAnimation != null);
            btnInsert.Enabled = btnDelete.Enabled = btnClear.Enabled = CurrentFrame != 0;
            grpTransform.Enabled = EnableTransformEdit && (TargetTexRef != null);
            for (int i = 0; i < 9; i++)
                ResetBox(i);
        }
        public unsafe void ResetBox(int index)
        {
            if (index == 2 || index == 4 || index == 5 || index == 8)
                return;

            NumericInputBox box = _transBoxes[index];
            
            if (TargetTexRef != null)
            if ((SelectedAnimation != null) && (CurrentFrame > 0) && TexEntry != null)
            {
                KeyframeEntry e = TexEntry.Keyframes.GetKeyframe((KeyFrameMode)index + 0x10, CurrentFrame - 1);
                if (e == null)
                {
                    box.Value = TexEntry.Keyframes[KeyFrameMode.ScaleX + index, CurrentFrame - 1];
                    box.BackColor = Color.White;
                }
                else
                {
                    box.Value = e._value;
                    box.BackColor = Color.Yellow;
                }
            }
            else
            {
                FrameState state = TargetTexRef._bindState;
                box.Value = ((float*)&state)[index];
                box.BackColor = Color.White;
            }
        }
        public unsafe void Undo(SaveState save)
        {
            FrameState t = (FrameState)save._frameState;
            numTransX.Value = t._translate._x;
            BoxChanged(numTransX, null);
            numTransY.Value = t._translate._y;
            BoxChanged(numTransY, null);
            numRot.Value = t._rotate._x;
            BoxChanged(numRot, null);
            numScaleX.Value = t._scale._x;
            BoxChanged(numScaleX, null);
            numScaleY.Value = t._scale._y;
            BoxChanged(numScaleY, null);
        }
        internal unsafe void BoxChangedCreateUndo(object sender, EventArgs e)
        {
            if (CreateUndo != null)
                CreateUndo(sender, null);

            //Only update for input boxes: Methods affecting multiple values call BoxChanged on their own.
            if (sender.GetType() == typeof(NumericInputBox))
                BoxChanged(sender, null);
        }
        internal unsafe void BoxChanged(object sender, EventArgs e)
        {
            if (TargetTexRef == null || sender == null)
                return;

            NumericInputBox box = sender as NumericInputBox;
            int index = (int)box.Tag;

            AnimationFrame kf;
            float* pkf = (float*)&kf;

            if (index == 2 || index == 4 || index == 5 || index == 8)
                return;

            if ((SelectedAnimation != null) && (CurrentFrame > 0))
            {
                int kfIndex = _mainWindow.pnlKeyframes.FindKeyframe(CurrentFrame - 1);
                int x;
                if (TexEntry == null)
                {
                    if (!float.IsNaN(box.Value))
                    {
                        SRT0TextureNode newEntry = SelectedAnimation.FindOrCreateEntry(TargetTexRef.Parent.Name, TargetTexRef.Index, false);

                        //Set initial values (so they aren't null)
                        FrameState state = TargetTexRef._bindState; //Get the texture's bindstate
                        float* p = (float*)&state;
                        for (int i = 0; i < 3; i++) //Get the scale
                            if (p[i] != 1.0f) //Check for default values
                                newEntry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);
                        for (int i = 3; i < 9; i++) //Get rotation and translation respectively
                            if (p[i] != 0.0f) //Check for default values
                                newEntry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);
                        if (p[10] != 0.0f)
                            newEntry.SetKeyframe(KeyFrameMode.ScaleX + 10, 0, p[10]);

                        kf = AnimationFrame.Empty;
                        kf.forKeyframeSRT = true;
                        kf.SetBool(index + 0x10, true);
                        kf.Index = CurrentFrame - 1;
                        pkf[index] = box.Value;

                        int count = _mainWindow.pnlKeyframes.listKeyframes.Items.Count;
                        for (x = 0; (x < count) && (((AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[x]).Index < CurrentFrame - 1); x++) ;

                        _mainWindow.pnlKeyframes.listKeyframes.Items.Insert(x, kf);
                        _mainWindow.pnlKeyframes.listKeyframes.SelectedIndex = x;

                        //Finally, replace with the changed value
                        newEntry.SetKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1, box.Value);
                    }
                }
                else //Set to existing SRT0 texture 
                    if (float.IsNaN(box.Value))
                    {
                        //Value removed, find keyframe and zero it out
                        if (kfIndex >= 0)
                        {
                            kf = (AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex];
                            kf.forKeyframeSRT = true;
                            kf.SetBool(index + 0x10, false);
                            pkf[index] = box.Value;

                            for (x = 0; (x < 9) && (float.IsNaN(pkf[x]) || !kf.GetBool(x + 0x10)); x++) ;
                            if (x == 9)
                            {
                                _mainWindow.pnlKeyframes.listKeyframes.Items.RemoveAt(kfIndex);
                                _mainWindow.pnlKeyframes.listKeyframes.SelectedIndex = -1;
                            }
                            else
                                _mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex] = kf;
                        }
                        TexEntry.RemoveKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1);
                    }
                    else
                    {
                        TexEntry.SetKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1, box.Value);
                        if (kfIndex >= 0)
                        {
                            kf = (AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex];
                            kf.forKeyframeSRT = true;
                            kf.SetBool(index + 0x10, true);
                            pkf[index] = box.Value;
                            _mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex] = kf;
                        }
                        else
                        {
                            kf = AnimationFrame.Empty;
                            kf.forKeyframeSRT = true;
                            kf.SetBool(index + 0x10, true);
                            kf.Index = CurrentFrame - 1;
                            pkf[index] = box.Value;

                            int count = _mainWindow.pnlKeyframes.listKeyframes.Items.Count;
                            for (x = 0; (x < count) && (((AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[x]).Index < CurrentFrame - 1); x++) ;

                            _mainWindow.pnlKeyframes.listKeyframes.Items.Insert(x, kf);
                            _mainWindow.pnlKeyframes.listKeyframes.SelectedIndex = x;
                        }
                    }
            }
            else
            {
                //Change base transform
                FrameState state = TargetTexRef._bindState;
                float* p = (float*)&state;
                p[index] = float.IsNaN(box.Value) ? (index > 2 ? 0.0f : 1.0f) : box.Value;
                TargetTexRef._bindState = state;
                //mr.RecalcBindState();
                TargetTexRef.SignalPropertyChange();
            }
            
            ResetBox(index);

            _mainWindow.UpdateModel();
            _mainWindow.modelPanel.Invalidate();
        }

        private static Dictionary<string, AnimationFrame> _copyAllState = new Dictionary<string, AnimationFrame>();

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            _copyAllState.Clear();

            if (CurrentFrame == 0)
                foreach (MDL0MaterialNode mat in TargetModel.FindChildrenByType("Materials", ResourceType.MDL0Material))
                    foreach (MDL0MaterialRefNode mr in mat.Children) 
                        _copyAllState[mr.Parent.Name + mr.Index] = (AnimationFrame)mr._bindState;
            else
                foreach (SRT0EntryNode entry in SelectedAnimation.Children)
                    foreach (SRT0TextureNode tex in entry.Children)
                        _copyAllState[tex.Parent.Name + tex.TextureIndex] = tex.GetAnimFrame(CurrentFrame - 1);
        }

        private void btnPasteAll_Click(object sender, EventArgs e)
        {
            if (_copyAllState.Count == 0)
                return;

            if (CurrentFrame == 0)
            {
                foreach (MDL0MaterialNode mat in TargetModel.FindChildrenByType("Materials", ResourceType.MDL0Material))
                    foreach (MDL0MaterialRefNode mr in mat.Children)
                        if (_copyAllState.ContainsKey(mr.Parent.Name + mr.Index))
                        {
                            if (AllTrans.Checked)
                                mr._bindState._translate = _copyAllState[mr.Parent.Name + mr.Index].Translation;
                            if (AllRot.Checked)
                                mr._bindState._rotate = _copyAllState[mr.Parent.Name + mr.Index].Rotation;
                            if (AllScale.Checked)
                                mr._bindState._scale = _copyAllState[mr.Parent.Name + mr.Index].Scale;
                            mr.SignalPropertyChange();
                        }
            }
            else
                foreach (SRT0EntryNode entry in SelectedAnimation.Children)
                    foreach (SRT0TextureNode tex in entry.Children)
                        if (_copyAllState.ContainsKey(tex.Parent.Name + tex.TextureIndex))
                        {
                            if (AllTrans.Checked)
                                tex.SetKeyframeOnlyTrans(CurrentFrame - 1, _copyAllState[tex.Parent.Name + tex.TextureIndex]);
                            if (AllRot.Checked)
                                tex.SetKeyframeOnlyRot(CurrentFrame - 1, _copyAllState[tex.Parent.Name + tex.TextureIndex]);
                            if (AllScale.Checked)
                                tex.SetKeyframeOnlyScale(CurrentFrame - 1, _copyAllState[tex.Parent.Name + tex.TextureIndex]);
                        }

            _mainWindow.UpdateModel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CurrentFrame == 0)
                return;

            foreach (SRT0EntryNode entry in SelectedAnimation.Children)
                foreach (SRT0TextureNode tex in entry.Children)
                {
                    if (AllTrans.Checked)
                        tex.RemoveKeyframeOnlyTrans(CurrentFrame - 1);
                    if (AllRot.Checked)
                        tex.RemoveKeyframeOnlyRot(CurrentFrame - 1);
                    if (AllScale.Checked)
                        tex.RemoveKeyframeOnlyScale(CurrentFrame - 1);
                }

            _mainWindow.UpdateModel();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            ResourceNode group = TargetModel._matGroup;
            ResourceNode mat = null;
            if (group == null)
                return;

            List<SRT0EntryNode> badMaterials = new List<SRT0EntryNode>();
            List<SRT0TextureNode> badTextures = new List<SRT0TextureNode>();
            foreach (SRT0EntryNode entry in SelectedAnimation.Children)
            {
                if ((mat = group.FindChild(entry._name, true)) == null)
                    badMaterials.Add(entry);
                else
                {
                    int count = 0;
                    foreach (SRT0TextureNode tex in entry.Children)
                    {
                        if (((mat = group.FindChild(entry._name, true)) == null) || mat.Children.Count < tex.TextureIndex)
                        { 
                            badTextures.Add(tex);
                            count++;
                        }
                        else
                            tex.Keyframes.Clean();
                    }
                    if (count == entry.Children.Count)
                        badMaterials.Add(entry);
                }
            }
            int temp0 = badMaterials.Count;
            int temp1 = badTextures.Count;
            foreach (SRT0TextureNode n in badTextures)
            {
                n.Remove();
                n.Dispose();
            }
            foreach (SRT0EntryNode n in badMaterials)
            {
                n.Remove();
                n.Dispose();
            }
            MessageBox.Show(temp0 + " unused material entries and\n" + temp1 + " unused texture entries removed.");
            UpdatePropDisplay();
        }

        private void ctxBox_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedAnimation == null)
                e.Cancel = true;
        }
        public int type = 0;
        private void numScaleX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x10;
                if (numScaleX.Enabled == true)
                {
                    if (_transBoxes[0].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numScaleX.ContextMenuStrip = ctxBox;
                    Source.Text = numScaleX.Text;
                }
                else
                    numScaleX.ContextMenuStrip = null;
            }
        }

        private void numScaleY_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x11;
                if (numScaleY.Enabled == true)
                {
                    if (_transBoxes[1].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numScaleY.ContextMenuStrip = ctxBox;
                    Source.Text = numScaleY.Text;
                }
                else
                    numScaleY.ContextMenuStrip = null;
            }
        }
        private void numRotX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x13;
                if (numRot.Enabled == true)
                {
                    if (_transBoxes[3].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numRot.ContextMenuStrip = ctxBox;
                    Source.Text = numRot.Text;
                }
                else
                    numRot.ContextMenuStrip = null;
            }
        }
        private void numTransX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x16;
                if (numTransX.Enabled == true)
                {
                    if (_transBoxes[6].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numTransX.ContextMenuStrip = ctxBox;
                    Source.Text = numTransX.Text;
                }
                else
                    numTransX.ContextMenuStrip = null;
            }
        }

        private void numTransY_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x17;
                if (numTransY.Enabled == true)
                {
                    if (_transBoxes[7].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numTransY.ContextMenuStrip = ctxBox;
                    Source.Text = numTransY.Text;
                }
                else
                    numTransY.ContextMenuStrip = null;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name, false) as CHR0EntryNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value += 180;
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value += 90;
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value -= 180;
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value -= 90;
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value += 45; 
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    kfe._value -= 45;
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            SRT0TextureNode _target = SelectedAnimation.FindChild(TargetTexRef.Parent.Name + "/Texture" + TargetTexRef.Index, true) as SRT0TextureNode;
            if (_target != null)
            {
                _target.Keyframes._keyRoots[type & 0xF] = new KeyframeEntry(-1, type >= 0x10 && type <= 0x12 ? 1 : 0);
                _target.Keyframes._keyCounts[type & 0xF] = 0;
                _target.SignalPropertyChange();
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void addCustomAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            EditAllKeyframesDialog ed = new EditAllKeyframesDialog();
            ed.ShowDialog(null, (KeyFrameMode)type, SelectedAnimation.FindChild(TargetTexRef.Name, false) as CHR0EntryNode);
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private unsafe void btnCut_Click(object sender, EventArgs e)
        {
            AnimationFrame frame;
            float* p = (float*)&frame;

            BoxChangedCreateUndo(this, null);

            for (int i = 0; i < 9; i++)
            {
                if (i == 2 || i == 4 || i == 5 || i == 8)
                    continue;

                if ((!FrameScale.Checked && i < 3))
                    p[i] = 1;
                else if (
                    (FrameScale.Checked && i < 3) ||
                    (FrameRot.Checked && i >= 3 && i < 6) ||
                    (FrameTrans.Checked && i >= 6))
                    p[i] = _transBoxes[i].Value;
                _transBoxes[i].Value = float.NaN;
                BoxChanged(_transBoxes[i], null);
            }

            _tempFrame = frame;
        }

        private unsafe void btnCopy_Click(object sender, EventArgs e)
        {
            AnimationFrame frame;
            float* p = (float*)&frame;

            for (int i = 0; i < 9; i++)
            {
                if (i == 2 || i == 4 || i == 5 || i == 8)
                    continue;

                if ((!FrameScale.Checked && i < 3))
                    p[i] = 1;
                else if (
                    (FrameScale.Checked && i < 3) ||
                    (FrameRot.Checked && i >= 3 && i < 6) ||
                    (FrameTrans.Checked && i >= 6))
                    p[i] = _transBoxes[i].Value;
            }

            _tempFrame = frame;
            //Clipboard.SetData("AnimationFrame", frame);
        }

        private unsafe void btnPaste_Click(object sender, EventArgs e)
        {
            //AnimationFrame copyFrame = (AnimationFrame)Clipboard.GetData("AnimationFrame");

            AnimationFrame frame = _tempFrame;
            float* p = (float*)&frame;

            BoxChangedCreateUndo(this, null);

            for (int i = 0; i < 9; i++)
            {
                if (i == 2 || i == 4 || i == 5 || i == 8)
                    continue;

                if ((FrameScale.Checked && i < 3) ||
                    (FrameRot.Checked && i >= 3 && i < 6) ||
                    (FrameTrans.Checked && i >= 6))
                    _transBoxes[i].Value = p[i];
                //_transBoxes[i].Value = p[i];
                BoxChanged(_transBoxes[i], null);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if ((SelectedAnimation == null) || (CurrentFrame == 0))
                return;

            SelectedAnimation.InsertKeyframe(CurrentFrame - 1);
            _mainWindow.SRT0StateChanged(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((SelectedAnimation == null) || (CurrentFrame == 0))
                return;

            SelectedAnimation.DeleteKeyframe(CurrentFrame - 1);
            _mainWindow.SRT0StateChanged(this, null);
        }

        private void btnClearFrame_Click(object sender, EventArgs e)
        {
            BoxChangedCreateUndo(this, null);

            for (int i = 0; i < 9; i++)
            {
                if (i == 2 || i == 4 || i == 5 || i == 8)
                    continue;

                _transBoxes[i].Value = float.NaN;
                BoxChanged(_transBoxes[i], null);
            }
        }

        private void editRawTangentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TexEntry == null) return;
            TangentEditor t = new TangentEditor();
            KeyframeEntry kfe = TexEntry.GetKeyframe((KeyFrameMode)type, CurrentFrame - 1);
            if (kfe != null)
                if (t.ShowDialog(this, kfe._tangent) == DialogResult.OK)
                    kfe._tangent = t.tan;
        }

        private void addCustomAmountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0 || TexEntry == null)
                return;

            EditAllKeyframesDialog ed = new EditAllKeyframesDialog();
            ed.ShowDialog(null, (KeyFrameMode)type, TexEntry);
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }
    }
}
