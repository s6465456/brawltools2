using System;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Modeling;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;

namespace System.Windows.Forms
{
    public class CHR0Editor : UserControl
    {
        #region Designer
        private GroupBox grpTransform;
        private Button btnPaste;
        private Button btnCopy;
        private Button btnCut;
        private Label lblTrans;
        private NumericInputBox numScaleZ;
        internal NumericInputBox numTransX;
        private NumericInputBox numScaleY;
        private Label lblRot;
        private NumericInputBox numScaleX;
        private Label lblScale;
        internal NumericInputBox numRotZ;
        internal NumericInputBox numRotY;
        internal NumericInputBox numRotX;
        internal NumericInputBox numTransZ;
        internal NumericInputBox numTransY;
        private GroupBox grpTransAll;
        private CheckBox AllScale;
        private CheckBox AllRot;
        private CheckBox AllTrans;
        public Button btnClean;
        public Button btnPasteAll;
        public Button btnCopyAll;
        public Button btnClear;
        public Button btnInsert;
        public Button btnDelete;
        private CheckBox FrameScale;
        private CheckBox FrameRot;
        private CheckBox FrameTrans;
        private ContextMenuStrip ctxBox;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem Source;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem add;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem subtract;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem removeAllToolStripMenuItem;
        private ToolStripMenuItem addCustomAmountToolStripMenuItem;
        private ToolStripMenuItem editRawTangentToolStripMenuItem;
        public Label labelBone;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpTransform = new System.Windows.Forms.GroupBox();
            this.FrameScale = new System.Windows.Forms.CheckBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.FrameRot = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.FrameTrans = new System.Windows.Forms.CheckBox();
            this.btnCut = new System.Windows.Forms.Button();
            this.numScaleX = new System.Windows.Forms.NumericInputBox();
            this.numScaleY = new System.Windows.Forms.NumericInputBox();
            this.numScaleZ = new System.Windows.Forms.NumericInputBox();
            this.numRotX = new System.Windows.Forms.NumericInputBox();
            this.numRotY = new System.Windows.Forms.NumericInputBox();
            this.numRotZ = new System.Windows.Forms.NumericInputBox();
            this.numTransX = new System.Windows.Forms.NumericInputBox();
            this.labelBone = new System.Windows.Forms.Label();
            this.numTransY = new System.Windows.Forms.NumericInputBox();
            this.numTransZ = new System.Windows.Forms.NumericInputBox();
            this.lblTrans = new System.Windows.Forms.Label();
            this.lblRot = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.grpTransAll = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnPasteAll = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.AllScale = new System.Windows.Forms.CheckBox();
            this.AllRot = new System.Windows.Forms.CheckBox();
            this.AllTrans = new System.Windows.Forms.CheckBox();
            this.ctxBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Source = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.subtract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRawTangentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTransform.SuspendLayout();
            this.grpTransAll.SuspendLayout();
            this.ctxBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTransform
            // 
            this.grpTransform.Controls.Add(this.FrameScale);
            this.grpTransform.Controls.Add(this.btnPaste);
            this.grpTransform.Controls.Add(this.FrameRot);
            this.grpTransform.Controls.Add(this.btnCopy);
            this.grpTransform.Controls.Add(this.FrameTrans);
            this.grpTransform.Controls.Add(this.btnCut);
            this.grpTransform.Controls.Add(this.numScaleX);
            this.grpTransform.Controls.Add(this.numScaleY);
            this.grpTransform.Controls.Add(this.numScaleZ);
            this.grpTransform.Controls.Add(this.numRotX);
            this.grpTransform.Controls.Add(this.numRotY);
            this.grpTransform.Controls.Add(this.numRotZ);
            this.grpTransform.Controls.Add(this.numTransX);
            this.grpTransform.Controls.Add(this.labelBone);
            this.grpTransform.Controls.Add(this.numTransY);
            this.grpTransform.Controls.Add(this.numTransZ);
            this.grpTransform.Controls.Add(this.lblTrans);
            this.grpTransform.Controls.Add(this.lblRot);
            this.grpTransform.Controls.Add(this.lblScale);
            this.grpTransform.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTransform.Enabled = false;
            this.grpTransform.Location = new System.Drawing.Point(0, 0);
            this.grpTransform.Name = "grpTransform";
            this.grpTransform.Padding = new System.Windows.Forms.Padding(0);
            this.grpTransform.Size = new System.Drawing.Size(422, 78);
            this.grpTransform.TabIndex = 23;
            this.grpTransform.TabStop = false;
            this.grpTransform.Text = "Transform Frame";
            // 
            // FrameScale
            // 
            this.FrameScale.AutoSize = true;
            this.FrameScale.Checked = true;
            this.FrameScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameScale.Location = new System.Drawing.Point(367, 56);
            this.FrameScale.Name = "FrameScale";
            this.FrameScale.Size = new System.Drawing.Size(53, 17);
            this.FrameScale.TabIndex = 35;
            this.FrameScale.Text = "Scale";
            this.FrameScale.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(318, 54);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(48, 20);
            this.btnPaste.TabIndex = 23;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // FrameRot
            // 
            this.FrameRot.AutoSize = true;
            this.FrameRot.Checked = true;
            this.FrameRot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameRot.Location = new System.Drawing.Point(367, 38);
            this.FrameRot.Name = "FrameRot";
            this.FrameRot.Size = new System.Drawing.Size(43, 17);
            this.FrameRot.TabIndex = 34;
            this.FrameRot.Text = "Rot";
            this.FrameRot.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(318, 35);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(48, 20);
            this.btnCopy.TabIndex = 22;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FrameTrans
            // 
            this.FrameTrans.AutoSize = true;
            this.FrameTrans.Checked = true;
            this.FrameTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrameTrans.Location = new System.Drawing.Point(367, 20);
            this.FrameTrans.Name = "FrameTrans";
            this.FrameTrans.Size = new System.Drawing.Size(53, 17);
            this.FrameTrans.TabIndex = 33;
            this.FrameTrans.Text = "Trans";
            this.FrameTrans.UseVisualStyleBackColor = true;
            // 
            // btnCut
            // 
            this.btnCut.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCut.Location = new System.Drawing.Point(318, 16);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(48, 20);
            this.btnCut.TabIndex = 21;
            this.btnCut.Text = "Cut";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // numScaleX
            // 
            this.numScaleX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleX.Location = new System.Drawing.Point(73, 54);
            this.numScaleX.Name = "numScaleX";
            this.numScaleX.Size = new System.Drawing.Size(82, 20);
            this.numScaleX.TabIndex = 18;
            this.numScaleX.Text = "0";
            this.numScaleX.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numScaleX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numScaleX_MouseDown);
            // 
            // numScaleY
            // 
            this.numScaleY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleY.Location = new System.Drawing.Point(154, 54);
            this.numScaleY.Name = "numScaleY";
            this.numScaleY.Size = new System.Drawing.Size(82, 20);
            this.numScaleY.TabIndex = 19;
            this.numScaleY.Text = "0";
            this.numScaleY.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numScaleY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numScaleY_MouseDown);
            // 
            // numScaleZ
            // 
            this.numScaleZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleZ.Location = new System.Drawing.Point(235, 54);
            this.numScaleZ.Name = "numScaleZ";
            this.numScaleZ.Size = new System.Drawing.Size(82, 20);
            this.numScaleZ.TabIndex = 20;
            this.numScaleZ.Text = "0";
            this.numScaleZ.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numScaleZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numScaleZ_MouseDown);
            // 
            // numRotX
            // 
            this.numRotX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRotX.Location = new System.Drawing.Point(73, 35);
            this.numRotX.Name = "numRotX";
            this.numRotX.Size = new System.Drawing.Size(82, 20);
            this.numRotX.TabIndex = 15;
            this.numRotX.Text = "0";
            this.numRotX.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numRotX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numRotX_MouseDown);
            // 
            // numRotY
            // 
            this.numRotY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRotY.Location = new System.Drawing.Point(154, 35);
            this.numRotY.Name = "numRotY";
            this.numRotY.Size = new System.Drawing.Size(82, 20);
            this.numRotY.TabIndex = 16;
            this.numRotY.Text = "0";
            this.numRotY.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numRotY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numRotY_MouseDown);
            // 
            // numRotZ
            // 
            this.numRotZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRotZ.Location = new System.Drawing.Point(235, 35);
            this.numRotZ.Name = "numRotZ";
            this.numRotZ.Size = new System.Drawing.Size(82, 20);
            this.numRotZ.TabIndex = 17;
            this.numRotZ.Text = "0";
            this.numRotZ.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numRotZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numRotZ_MouseDown);
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
            // labelBone
            // 
            this.labelBone.AutoSize = true;
            this.labelBone.Location = new System.Drawing.Point(97, -2);
            this.labelBone.Name = "labelBone";
            this.labelBone.Size = new System.Drawing.Size(0, 13);
            this.labelBone.TabIndex = 36;
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
            // numTransZ
            // 
            this.numTransZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTransZ.Location = new System.Drawing.Point(235, 16);
            this.numTransZ.Name = "numTransZ";
            this.numTransZ.Size = new System.Drawing.Size(82, 20);
            this.numTransZ.TabIndex = 14;
            this.numTransZ.Text = "0";
            this.numTransZ.ValueChanged += new System.EventHandler(this.BoxChangedCreateUndo);
            this.numTransZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numTransZ_MouseDown);
            // 
            // lblTrans
            // 
            this.lblTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrans.Location = new System.Drawing.Point(4, 16);
            this.lblTrans.Name = "lblTrans";
            this.lblTrans.Size = new System.Drawing.Size(70, 20);
            this.lblTrans.TabIndex = 4;
            this.lblTrans.Text = "Translation:";
            this.lblTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRot
            // 
            this.lblRot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRot.Location = new System.Drawing.Point(4, 35);
            this.lblRot.Name = "lblRot";
            this.lblRot.Size = new System.Drawing.Size(70, 20);
            this.lblRot.TabIndex = 5;
            this.lblRot.Text = "Rotation:";
            this.lblRot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScale
            // 
            this.lblScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScale.Location = new System.Drawing.Point(4, 54);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(70, 20);
            this.lblScale.TabIndex = 6;
            this.lblScale.Text = "Scale:";
            this.lblScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpTransAll
            // 
            this.grpTransAll.Controls.Add(this.btnInsert);
            this.grpTransAll.Controls.Add(this.btnClean);
            this.grpTransAll.Controls.Add(this.btnPasteAll);
            this.grpTransAll.Controls.Add(this.btnCopyAll);
            this.grpTransAll.Controls.Add(this.btnClear);
            this.grpTransAll.Controls.Add(this.btnDelete);
            this.grpTransAll.Controls.Add(this.AllScale);
            this.grpTransAll.Controls.Add(this.AllRot);
            this.grpTransAll.Controls.Add(this.AllTrans);
            this.grpTransAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransAll.Enabled = false;
            this.grpTransAll.Location = new System.Drawing.Point(422, 0);
            this.grpTransAll.Name = "grpTransAll";
            this.grpTransAll.Size = new System.Drawing.Size(160, 78);
            this.grpTransAll.TabIndex = 26;
            this.grpTransAll.TabStop = false;
            this.grpTransAll.Text = "Transform All";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(106, 54);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(50, 20);
            this.btnInsert.TabIndex = 24;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(106, 35);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(50, 20);
            this.btnClean.TabIndex = 29;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnPasteAll
            // 
            this.btnPasteAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPasteAll.Location = new System.Drawing.Point(57, 35);
            this.btnPasteAll.Name = "btnPasteAll";
            this.btnPasteAll.Size = new System.Drawing.Size(50, 20);
            this.btnPasteAll.TabIndex = 28;
            this.btnPasteAll.Text = "Paste";
            this.btnPasteAll.UseVisualStyleBackColor = true;
            this.btnPasteAll.Click += new System.EventHandler(this.btnPasteAll_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(57, 54);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(50, 20);
            this.btnCopyAll.TabIndex = 27;
            this.btnCopyAll.Text = "Copy";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(106, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 20);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(57, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 20);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AllScale
            // 
            this.AllScale.AutoSize = true;
            this.AllScale.Checked = true;
            this.AllScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllScale.Location = new System.Drawing.Point(6, 56);
            this.AllScale.Name = "AllScale";
            this.AllScale.Size = new System.Drawing.Size(53, 17);
            this.AllScale.TabIndex = 32;
            this.AllScale.Text = "Scale";
            this.AllScale.UseVisualStyleBackColor = true;
            // 
            // AllRot
            // 
            this.AllRot.AutoSize = true;
            this.AllRot.Checked = true;
            this.AllRot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllRot.Location = new System.Drawing.Point(6, 38);
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
            this.AllTrans.Location = new System.Drawing.Point(6, 20);
            this.AllTrans.Name = "AllTrans";
            this.AllTrans.Size = new System.Drawing.Size(53, 17);
            this.AllTrans.TabIndex = 30;
            this.AllTrans.Text = "Trans";
            this.AllTrans.UseVisualStyleBackColor = true;
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
            this.ctxBox.Size = new System.Drawing.Size(167, 142);
            // 
            // Source
            // 
            this.Source.Enabled = false;
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(166, 22);
            this.Source.Text = "Source";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "+180";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "+90";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem7.Text = "+45";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
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
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem6.Text = "-90";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem8.Text = "-45";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.removeAllToolStripMenuItem.Text = "Remove All";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // addCustomAmountToolStripMenuItem
            // 
            this.addCustomAmountToolStripMenuItem.Name = "addCustomAmountToolStripMenuItem";
            this.addCustomAmountToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addCustomAmountToolStripMenuItem.Text = "Edit All...";
            this.addCustomAmountToolStripMenuItem.Click += new System.EventHandler(this.addCustomAmountToolStripMenuItem_Click);
            // 
            // editRawTangentToolStripMenuItem
            // 
            this.editRawTangentToolStripMenuItem.Name = "editRawTangentToolStripMenuItem";
            this.editRawTangentToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editRawTangentToolStripMenuItem.Text = "Edit Raw Tangent";
            this.editRawTangentToolStripMenuItem.Click += new System.EventHandler(this.editRawTangentToolStripMenuItem_Click);
            // 
            // CHR0Editor
            // 
            this.Controls.Add(this.grpTransAll);
            this.Controls.Add(this.grpTransform);
            this.Name = "CHR0Editor";
            this.Size = new System.Drawing.Size(582, 78);
            this.grpTransform.ResumeLayout(false);
            this.grpTransform.PerformLayout();
            this.grpTransAll.ResumeLayout(false);
            this.grpTransAll.PerformLayout();
            this.ctxBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ModelEditControl _mainWindow;

        public event EventHandler CreateUndo;

        internal NumericInputBox[] _transBoxes = new NumericInputBox[9];
        private AnimationFrame _tempFrame = AnimationFrame.Identity;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode TargetBone { get { return _mainWindow._targetBone; } set { _mainWindow.TargetBone = value; } }

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
        public CHR0Node SelectedAnimation
        {
            get { return _mainWindow._chr0; }
            set { _mainWindow._chr0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableTransformEdit
        {
            get { return _mainWindow._enableTransform; }
            set { grpTransform.Enabled = grpTransAll.Enabled = (_mainWindow.EnableTransformEdit = value) && (TargetBone != null); }
        }

        public CHR0Editor()
        {
            InitializeComponent(); 
            _transBoxes[0] = numScaleX; numScaleX.Tag = 0;
            _transBoxes[1] = numScaleY; numScaleY.Tag = 1;
            _transBoxes[2] = numScaleZ; numScaleZ.Tag = 2;
            _transBoxes[3] = numRotX; numRotX.Tag = 3;
            _transBoxes[4] = numRotY; numRotY.Tag = 4;
            _transBoxes[5] = numRotZ; numRotZ.Tag = 5;
            _transBoxes[6] = numTransX; numTransX.Tag = 6;
            _transBoxes[7] = numTransY; numTransY.Tag = 7;
            _transBoxes[8] = numTransZ; numTransZ.Tag = 8;
        }
        public void UpdatePropDisplay()
        {
            grpTransAll.Enabled = EnableTransformEdit && (SelectedAnimation != null);
            btnInsert.Enabled = btnDelete.Enabled = btnClear.Enabled = CurrentFrame != 0;
            grpTransform.Enabled = EnableTransformEdit && (TargetBone != null);
            
            for (int i = 0; i < 9; i++)
                ResetBox(i);
        }
        public unsafe void ResetBox(int index)
        {
            NumericInputBox box = _transBoxes[index];
            MDL0BoneNode bone = TargetBone;
            CHR0EntryNode entry;
            if (TargetBone != null)
            if ((SelectedAnimation != null) && (CurrentFrame > 0) && ((entry = SelectedAnimation.FindChild(bone.Name, false) as CHR0EntryNode) != null))
            {
                KeyframeEntry e = entry.Keyframes.GetKeyframe((KeyFrameMode)index + 0x10, CurrentFrame - 1);
                if (e == null)
                {
                    box.Value = entry.Keyframes[KeyFrameMode.ScaleX + index, CurrentFrame - 1];
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
                FrameState state = bone._bindState;
                box.Value = ((float*)&state)[index];
                box.BackColor = Color.White;
            }
        }
        public unsafe void Undo(SaveState2 save)
        {
            if (numTransX.Value != save.frameState._translate._x)
            {
                numTransX.Value = save.frameState._translate._x;
                BoxChanged(numTransX, null);
            }
            if (numTransY.Value != save.frameState._translate._y)
            {
                numTransY.Value = save.frameState._translate._y;
                BoxChanged(numTransY, null);
            }
            if (numTransZ.Value != save.frameState._translate._z)
            {
                numTransZ.Value = save.frameState._translate._z;
                BoxChanged(numTransZ, null);
            }

            if (numRotX.Value != save.frameState._rotate._x)
            {
                numRotX.Value = save.frameState._rotate._x;
                BoxChanged(numRotX, null);
            }
            if (numRotY.Value != save.frameState._rotate._y)
            {
                numRotY.Value = save.frameState._rotate._y;
                BoxChanged(numRotY, null);
            }
            if (numRotZ.Value != save.frameState._rotate._z)
            {
                numRotZ.Value = save.frameState._rotate._z;
                BoxChanged(numRotZ, null);
            }

            if (numRotX.Value != save.frameState._rotate._x)
            {
                numRotX.Value = save.frameState._rotate._x;
                BoxChanged(numRotX, null);
            }
            if (numRotY.Value != save.frameState._rotate._y)
            {
                numRotY.Value = save.frameState._rotate._y;
                BoxChanged(numRotY, null);
            }
            if (numRotZ.Value != save.frameState._rotate._z)
            {
                numRotZ.Value = save.frameState._rotate._z;
                BoxChanged(numRotZ, null);
            }
        }
        internal unsafe void BoxChangedCreateUndo(object sender, EventArgs e)
        {
            _mainWindow.CreateUndo(this, null);

            //Only update for input boxes: Methods affecting multiple values call BoxChanged on their own.
            if (sender.GetType() == typeof(NumericInputBox))
                BoxChanged(sender, null);
        }
        internal unsafe void BoxChanged(object sender, EventArgs e)
        {
            if (TargetBone == null)
                return;

            NumericInputBox box = sender as NumericInputBox;
            int index = (int)box.Tag;

            MDL0BoneNode bone = TargetBone;
            AnimationFrame kf; 
            float* pkf = (float*)&kf;

            if ((SelectedAnimation != null) && (CurrentFrame > 0))
            {
                //Find bone anim and change transform
                CHR0EntryNode entry = SelectedAnimation.FindChild(bone.Name, false) as CHR0EntryNode;
                int kfIndex = _mainWindow.pnlKeyframes.FindKeyframe(CurrentFrame - 1);
                int x;

                if (entry == null) //Create new bone animation
                {
                    if (!float.IsNaN(box.Value))
                    {
                        entry = SelectedAnimation.CreateEntry();
                        entry.Name = bone.Name;

                        //Set initial values (so they aren't null)
                        FrameState state = bone._bindState; //Get the bone's bindstate
                        float* p = (float*)&state;
                        for (int i = 0; i < 3; i++) //Get the scale
                            if (p[i] != 1.0f) //Check for default values
                                entry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);
                        for (int i = 3; i < 9; i++) //Get rotation and translation respectively
                            if (p[i] != 0.0f) //Check for default values
                                entry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);

                        kf = AnimationFrame.Empty;
                        kf.forKeyframeCHR = true;
                        kf.SetBool(index + 0x10, true);
                        kf.Index = CurrentFrame - 1;
                        pkf[index] = box.Value;

                        int count = _mainWindow.pnlKeyframes.listKeyframes.Items.Count;
                        for (x = 0; (x < count) && (((AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[x]).Index < CurrentFrame - 1); x++) ;

                        _mainWindow.pnlKeyframes.listKeyframes.Items.Insert(x, kf);
                        _mainWindow.pnlKeyframes.listKeyframes.SelectedIndex = x;

                        //Finally, replace with the changed value
                        entry.SetKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1, box.Value);
                    }
                }
                else //Set to existing CHR0 entry 
                    if (float.IsNaN(box.Value))
                    {
                        //Value removed, find keyframe and zero it out
                        if (kfIndex >= 0)
                        {
                            kf = (AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex];
                            kf.forKeyframeCHR = true;
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

                        entry.RemoveKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1);
                    }
                    else
                    {
                        if (kfIndex >= 0)
                        {
                            kf = (AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex];
                            kf.forKeyframeCHR = true;
                            kf.SetBool(index + 0x10, true);
                            pkf[index] = box.Value;
                            _mainWindow.pnlKeyframes.listKeyframes.Items[kfIndex] = kf;
                        }
                        else
                        {
                            kf = AnimationFrame.Empty;
                            kf.forKeyframeCHR = true;
                            kf.SetBool(index + 0x10, true);
                            kf.Index = CurrentFrame - 1;
                            pkf[index] = box.Value;

                            int count = _mainWindow.pnlKeyframes.listKeyframes.Items.Count;
                            for (x = 0; (x < count) && (((AnimationFrame)_mainWindow.pnlKeyframes.listKeyframes.Items[x]).Index < CurrentFrame - 1); x++) ;

                            _mainWindow.pnlKeyframes.listKeyframes.Items.Insert(x, kf);
                            _mainWindow.pnlKeyframes.listKeyframes.SelectedIndex = x;
                        }
                        entry.SetKeyframe(KeyFrameMode.ScaleX + index, CurrentFrame - 1, box.Value);
                    }
            }
            else
            {
                //Change base transform
                FrameState state = bone._bindState;
                float* p = (float*)&state;
                p[index] = float.IsNaN(box.Value) ? (index > 2 ? 0.0f : 1.0f) : box.Value;
                bone._bindState = state;
                bone._bindState.CalcTransforms();
                //bone.RecalcBindState();
                //TargetModel.CalcBindMatrices();
                bone.SignalPropertyChange();
            }

            TargetModel.ApplyCHR(SelectedAnimation, CurrentFrame);

            ResetBox(index);

            _mainWindow.modelPanel1.Invalidate();
        }

        //public unsafe void ApplySave(SaveState save)
        //{
        //    _transformObject = save.bone;
        //    if (save.animation != null)
        //    {
        //        CHR0EntryNode entry = null;
        //        if (save.bone != null)
        //            entry = save.animation.FindChild(save.bone.Name, false) as CHR0EntryNode;
        //        _selectedAnim = save.animation;
        //        if (save.undo) //Do the opposite of what the booleans say.
        //        {
        //            //Console.WriteLine("Undo");
        //            if (save.newEntry)
        //                save.animation.RemoveChild(entry);

        //            if (save.keyframeRemoved && save.boxIndex != -1)
        //                if (save.primarySave)
        //                    entry.SetKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1, save.oldBoxValues[save.boxIndex]);
        //                else
        //                    entry.SetKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1, save.newBoxValues[save.boxIndex]);

        //            if (save.keyframeSet && save.boxIndex != -1)
        //            {
        //                entry.RemoveKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1);
        //                entry.SetKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1, save.oldBoxValues[save.boxIndex]);
        //            }

        //            if (save.animPorted && save.oldAnimation != null)
        //                _targetModel.ApplyCHR(_selectedAnim = save.oldAnimation, _animFrame = save.frameIndex);
        //        }
        //        //Follow what the booleans say, the opposite of undo. 
        //        //This is because undo will already have been called.
        //        if (save.redo)
        //        {
        //            //Console.WriteLine("Redo");
        //            if (save.newEntry)
        //            {
        //                entry = save.animation.CreateEntry();
        //                entry.Name = save.bone.Name;

        //                //Set initial values (so they aren't null)
        //                FrameState state = save.oldFrameState; //Get the bone's bindstate
        //                float* p = (float*)&state;
        //                for (int i = 0; i < 3; i++) //Get the scale
        //                    if (p[i] != 1.0f)
        //                        entry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);
        //                for (int i = 3; i < 9; i++) //Get rotation and translation respectively
        //                    if (p[i] != 0.0f)
        //                        entry.SetKeyframe(KeyFrameMode.ScaleX + i, 0, p[i]);
        //                //Finally, replace the changed value
        //                entry.SetKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1, save.newBoxValues[save.boxIndex]);
        //            }

        //            if (save.keyframeRemoved)
        //                entry.RemoveKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1);

        //            if (save.keyframeSet)
        //                entry.SetKeyframe(KeyFrameMode.ScaleX + save.boxIndex, save.frameIndex - 1, save.newBoxValues[save.boxIndex]);
        //        }

        //        if (save.animation != null && !save.animPorted)
        //            _targetModel.ApplyCHR(_selectedAnim = save.animation, _animFrame = save.frameIndex);

        //        if (SelectedAnimationChanged != null)
        //            SelectedAnimationChanged(this, null);

        //        if (save.boxIndex != -1)
        //            ResetBox(save.boxIndex);
        //    }
        //    else
        //    {
        //        if (save.undo)
        //            save.bone._bindState = save.oldFrameState;
        //        if (save.redo)
        //            save.bone._bindState = save.newFrameState;
        //        //save.bone.RecalcBindState();
        //    }
        //}
        //public bool _rotating = false;
        //public bool check = false, removed = false;

        private static Dictionary<string, AnimationFrame> _copyAllState = new Dictionary<string, AnimationFrame>();

        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            _copyAllState.Clear();

            if (CurrentFrame == 0)
                foreach (MDL0BoneNode bone in TargetModel._linker.BoneCache)
                {
                    AnimationFrame frame = (AnimationFrame)bone._bindState;
                    if (!AllTrans.Checked)
                        frame.Translation = new Vector3();
                    if (!AllRot.Checked)
                        frame.Rotation = new Vector3();
                    if (!AllScale.Checked)
                        frame.Scale = new Vector3(1);
                    _copyAllState[bone._name] = frame;
                }
            else
                foreach (CHR0EntryNode entry in SelectedAnimation.Children)
                {
                    AnimationFrame frame = entry.GetAnimFrame(CurrentFrame - 1);
                    if (!AllTrans.Checked)
                        frame.Translation = new Vector3();
                    if (!AllRot.Checked)
                        frame.Rotation = new Vector3();
                    if (!AllScale.Checked)
                        frame.Scale = new Vector3(1);
                    _copyAllState[entry._name] = frame;
                }
        }

        private void btnPasteAll_Click(object sender, EventArgs e)
        {
            if (_copyAllState.Count == 0)
                return;

            if (CurrentFrame == 0)
            {
                foreach (MDL0BoneNode bone in TargetModel._linker.BoneCache)
                    if (_copyAllState.ContainsKey(bone._name))
                    {
                        if (AllTrans.Checked)
                            bone._bindState._translate = _copyAllState[bone._name].Translation;
                        if (AllRot.Checked)
                            bone._bindState._rotate = _copyAllState[bone._name].Rotation;
                        if (AllScale.Checked)
                            bone._bindState._scale = _copyAllState[bone._name].Scale;
                        //bone.RecalcBindState();
                        bone.SignalPropertyChange();
                    }
            }
            else
            {
                foreach (string name in _copyAllState.Keys)
                {
                    CHR0EntryNode entry = null;
                    if ((entry = SelectedAnimation.FindChild(name, false) as CHR0EntryNode) == null)
                    {
                        entry = new CHR0EntryNode() { Name = name };
                        entry._numFrames = SelectedAnimation.FrameCount;
                        SelectedAnimation.AddChild(entry);
                    }

                    if (AllTrans.Checked)
                        entry.SetKeyframeOnlyTrans(CurrentFrame - 1, _copyAllState[entry._name]);
                    if (AllRot.Checked)
                        entry.SetKeyframeOnlyRot(CurrentFrame - 1, _copyAllState[entry._name]);
                    if (AllScale.Checked)
                        entry.SetKeyframeOnlyScale(CurrentFrame - 1, _copyAllState[entry._name]);
                }
            }
            _mainWindow.UpdateModel();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CurrentFrame == 0)
                return;

            foreach (CHR0EntryNode entry in SelectedAnimation.Children)
            {
                if (AllTrans.Checked)
                    entry.RemoveKeyframeOnlyTrans(CurrentFrame - 1);
                if (AllRot.Checked)
                    entry.RemoveKeyframeOnlyRot(CurrentFrame - 1);
                if (AllScale.Checked)
                    entry.RemoveKeyframeOnlyScale(CurrentFrame - 1);
            }

            _mainWindow.UpdateModel();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            ResourceNode group = TargetModel._boneGroup;
            if (group == null)
                return;

            List<CHR0EntryNode> badNodes = new List<CHR0EntryNode>();
            foreach (CHR0EntryNode entry in SelectedAnimation.Children)
            {
                if (group.FindChild(entry._name, true) == null)
                    badNodes.Add(entry);
                else
                    entry.Keyframes.Clean();
            }
            int temp = badNodes.Count;
            foreach (CHR0EntryNode n in badNodes)
            {
                n.Remove();
                n.Dispose();
            }
            MessageBox.Show(temp + " unused nodes removed.");
            UpdatePropDisplay();
        }

        private void ctxBox_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedAnimation == null || numRotX.Enabled == false || numRotY.Enabled == false || numRotZ.Enabled == false)
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

        private void numScaleZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x12;
                if (numScaleZ.Enabled == true)
                {
                    if (_transBoxes[2].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numScaleZ.ContextMenuStrip = ctxBox;
                    Source.Text = numScaleZ.Text;
                }
                else
                    numScaleZ.ContextMenuStrip = null;
            }
        }

        private void numRotX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x13;
                if (numRotX.Enabled == true)
                {
                    if (_transBoxes[3].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numRotX.ContextMenuStrip = ctxBox;
                    Source.Text = numRotX.Text;
                }
                else
                    numRotX.ContextMenuStrip = null;
            }
        }

        private void numRotY_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x14;
                if (numRotY.Enabled == true)
                {
                    if (_transBoxes[4].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numRotY.ContextMenuStrip = ctxBox;
                    Source.Text = numRotY.Text;
                }
                else
                    numRotY.ContextMenuStrip = null;
            }
        }

        private void numRotZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x15;
                if (numRotZ.Enabled == true)
                {
                    if (_transBoxes[5].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numRotZ.ContextMenuStrip = ctxBox;
                    Source.Text = numRotZ.Text;
                }
                else
                    numRotZ.ContextMenuStrip = null;
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

        private void numTransZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Forms.MouseButtons.Right)
            {
                type = 0x18;
                if (numTransZ.Enabled == true)
                {
                    if (_transBoxes[8].BackColor == Color.Yellow)
                        editRawTangentToolStripMenuItem.Visible = true;
                    else
                        editRawTangentToolStripMenuItem.Visible = false;
                    numTransZ.ContextMenuStrip = ctxBox;
                    Source.Text = numTransZ.Text;
                }
                else
                    numTransZ.ContextMenuStrip = null;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            if (_target != null)
            {
                for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                    if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    { kfe._value += 180; }
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            if (_target != null)
            {
                for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                    if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    { kfe._value += 90; }
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            if (_target != null)
            {
                for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                    if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    { kfe._value -= 90; }
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            if (_target != null)
            {
                for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                    if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    { kfe._value += 45; }
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            KeyframeEntry kfe;
            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            if (_target != null)
            {
                for (int x = 0; x < _target.FrameCount; x++) //Loop thru each frame
                    if ((kfe = _target.GetKeyframe((KeyFrameMode)type, x)) != null) //Check for a keyframe
                    { kfe._value -= 45; }
                ResetBox(type - 0x10);
                _mainWindow.UpdateModel();
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAnimation == null || type == 0)
                return;

            CHR0EntryNode _target = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
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
            ed.ShowDialog(null, (KeyFrameMode)type, SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode);
            ResetBox(type - 0x10);
            _mainWindow.UpdateModel();
        }

        private unsafe void btnCut_Click(object sender, EventArgs e)
        {
            AnimationFrame frame = new AnimationFrame();
            float* p = (float*)&frame;

            if (FrameScale.Checked) frame.hasSx = frame.hasSy = frame.hasSz = true;
            if (FrameRot.Checked) frame.hasRx = frame.hasRy = frame.hasRz = true;
            if (FrameTrans.Checked) frame.hasTx = frame.hasTy = frame.hasTz = true;

            BoxChangedCreateUndo(this, null);

            for (int i = 0; i < 9; i++)
            {
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
            AnimationFrame frame = new AnimationFrame();
            float* p = (float*)&frame;

            if (FrameScale.Checked) frame.hasSx = frame.hasSy = frame.hasSz = true;
            if (FrameRot.Checked) frame.hasRx = frame.hasRy = frame.hasRz = true;
            if (FrameTrans.Checked) frame.hasTx = frame.hasTy = frame.hasTz = true;

            for (int i = 0; i < 9; i++)
                if ((!FrameScale.Checked && i < 3))
                    p[i] = 1;
                else if (
                    (FrameScale.Checked && i < 3) ||
                    (FrameRot.Checked && i >= 3 && i < 6) ||
                    (FrameTrans.Checked && i >= 6))
                    p[i] = _transBoxes[i].Value;

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
                if ((FrameScale.Checked && i < 3) ||
                    (FrameRot.Checked && i >= 3 && i < 6) ||
                    (FrameTrans.Checked && i >= 6))
                    if (_transBoxes[i].Value != p[i])
                        _transBoxes[i].Value = p[i];
                BoxChanged(_transBoxes[i], null);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if ((SelectedAnimation == null) || (CurrentFrame == 0))
                return;

            SelectedAnimation.InsertKeyframe(CurrentFrame - 1);
            _mainWindow.CHR0StateChanged(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((SelectedAnimation == null) || (CurrentFrame == 0))
                return;

            SelectedAnimation.DeleteKeyframe(CurrentFrame - 1);
            _mainWindow.CHR0StateChanged(this, null);
        }

        //private void chkLinear_CheckedChanged(object sender, EventArgs e)
        //{
        //    DialogResult r;
        //    if (SelectedAnimation != null)
        //        if (TargetBone != null)
        //        {
        //            if ((r = MessageBox.Show("Do you want to apply linear interpolation to only this bone?\nOtherwise, all bones in the animation will be set to linear.", "", MessageBoxButtons.YesNoCancel)) == DialogResult.Yes)
        //                (SelectedAnimation.FindChild(TargetBone.Name, true) as CHR0EntryNode).Keyframes.LinearRotation = chkLinear.Checked;
        //            else if (r == DialogResult.No)
        //                foreach (CHR0EntryNode n in SelectedAnimation.Children)
        //                    n.Keyframes.LinearRotation = chkLinear.Checked;
        //            else return;
        //        }
        //        else
        //            foreach (CHR0EntryNode n in SelectedAnimation.Children)
        //                n.Keyframes.LinearRotation = chkLinear.Checked;
        //}

        //private void chkLoop_CheckedChanged(object sender, EventArgs e)
        //{
        //    SelectedAnimation.Loop = chkLoop.Checked ? true : false;
        //}

        private void editRawTangentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TangentEditor t = new TangentEditor();
            CHR0EntryNode entry = SelectedAnimation.FindChild(TargetBone.Name, false) as CHR0EntryNode;
            KeyframeEntry kfe = entry.GetKeyframe((KeyFrameMode)type, CurrentFrame - 1);
            if (kfe != null)
            if (t.ShowDialog(this, kfe._tangent) == DialogResult.OK)
                kfe._tangent = t.tan;
        }
    }
}
