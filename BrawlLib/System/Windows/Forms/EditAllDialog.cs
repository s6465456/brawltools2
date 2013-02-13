﻿using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;

namespace System.Windows.Forms
{
    public class EditAllDialog : Form
    {
        private ResourceNode _node;
        private CHR0EntryNode _copyNode = null;
        private TabPage vis;
        private TabPage pat;
        private TabPage shp;
        private TabPage srt;
        private CheckBox srtTexRename;
        private CheckBox srtModMat;
        private TextBox textBox7;
        private TextBox srtMatName;
        private TextBox srtTexName;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox12;
        private CheckBox srtLoopEnable;
        private Label label2;
        private Label srtScaleX;
        private Label srtScaleY;
        private Label srtRot;
        private Label srtTransX;
        private Label srtTransY;
        private CheckBox srtScaleSubtract;
        private CheckBox srtScaleAdd;
        private CheckBox srtScaleReplace;
        private CheckBox srtRotSubtract;
        private CheckBox srtRotAdd;
        private CheckBox srtRotReplace;
        private CheckBox srtTransSubtract;
        private CheckBox srtTransAdd;
        private CheckBox srtTransReplace;
        private CheckBox srtCopyKF;
        private CheckBox chkSrtVersion;
        private ComboBox srtVersion;
        private CheckBox srtEditLoop;
        private TabPage chr;
        private TabControl tabControl1;
        private EditAllCHR0Editor editAllCHR0Editor1;
        private CheckBox checkBox1;

        public EditAllDialog() { InitializeComponent(); }

        private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }

        #region Designer

        private Button btnCancel;
        private Button btnOkay;

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.vis = new System.Windows.Forms.TabPage();
            this.pat = new System.Windows.Forms.TabPage();
            this.shp = new System.Windows.Forms.TabPage();
            this.srt = new System.Windows.Forms.TabPage();
            this.srtTexRename = new System.Windows.Forms.CheckBox();
            this.srtModMat = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.srtMatName = new System.Windows.Forms.TextBox();
            this.srtTexName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.srtLoopEnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.srtScaleX = new System.Windows.Forms.Label();
            this.srtScaleY = new System.Windows.Forms.Label();
            this.srtRot = new System.Windows.Forms.Label();
            this.srtTransX = new System.Windows.Forms.Label();
            this.srtTransY = new System.Windows.Forms.Label();
            this.srtScaleSubtract = new System.Windows.Forms.CheckBox();
            this.srtScaleAdd = new System.Windows.Forms.CheckBox();
            this.srtScaleReplace = new System.Windows.Forms.CheckBox();
            this.srtRotSubtract = new System.Windows.Forms.CheckBox();
            this.srtRotAdd = new System.Windows.Forms.CheckBox();
            this.srtRotReplace = new System.Windows.Forms.CheckBox();
            this.srtTransSubtract = new System.Windows.Forms.CheckBox();
            this.srtTransAdd = new System.Windows.Forms.CheckBox();
            this.srtTransReplace = new System.Windows.Forms.CheckBox();
            this.srtCopyKF = new System.Windows.Forms.CheckBox();
            this.chkSrtVersion = new System.Windows.Forms.CheckBox();
            this.srtVersion = new System.Windows.Forms.ComboBox();
            this.srtEditLoop = new System.Windows.Forms.CheckBox();
            this.chr = new System.Windows.Forms.TabPage();
            this.editAllCHR0Editor1 = new System.Windows.Forms.EditAllCHR0Editor();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.srt.SuspendLayout();
            this.chr.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(339, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(258, 375);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "&Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(263, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable Modifications";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // vis
            // 
            this.vis.BackColor = System.Drawing.SystemColors.Control;
            this.vis.Location = new System.Drawing.Point(4, 25);
            this.vis.Name = "vis";
            this.vis.Size = new System.Drawing.Size(410, 344);
            this.vis.TabIndex = 4;
            this.vis.Text = "VIS0";
            // 
            // pat
            // 
            this.pat.BackColor = System.Drawing.SystemColors.Control;
            this.pat.Location = new System.Drawing.Point(4, 25);
            this.pat.Name = "pat";
            this.pat.Size = new System.Drawing.Size(410, 344);
            this.pat.TabIndex = 3;
            this.pat.Text = "PAT0";
            // 
            // shp
            // 
            this.shp.BackColor = System.Drawing.SystemColors.Control;
            this.shp.Location = new System.Drawing.Point(4, 25);
            this.shp.Name = "shp";
            this.shp.Size = new System.Drawing.Size(410, 344);
            this.shp.TabIndex = 2;
            this.shp.Text = "SHP0";
            // 
            // srt
            // 
            this.srt.BackColor = System.Drawing.SystemColors.Control;
            this.srt.Controls.Add(this.srtTexRename);
            this.srt.Controls.Add(this.srtModMat);
            this.srt.Controls.Add(this.textBox7);
            this.srt.Controls.Add(this.srtMatName);
            this.srt.Controls.Add(this.srtTexName);
            this.srt.Controls.Add(this.textBox3);
            this.srt.Controls.Add(this.textBox4);
            this.srt.Controls.Add(this.textBox6);
            this.srt.Controls.Add(this.textBox9);
            this.srt.Controls.Add(this.textBox10);
            this.srt.Controls.Add(this.textBox12);
            this.srt.Controls.Add(this.srtLoopEnable);
            this.srt.Controls.Add(this.label2);
            this.srt.Controls.Add(this.srtScaleX);
            this.srt.Controls.Add(this.srtScaleY);
            this.srt.Controls.Add(this.srtRot);
            this.srt.Controls.Add(this.srtTransX);
            this.srt.Controls.Add(this.srtTransY);
            this.srt.Controls.Add(this.srtScaleSubtract);
            this.srt.Controls.Add(this.srtScaleAdd);
            this.srt.Controls.Add(this.srtScaleReplace);
            this.srt.Controls.Add(this.srtRotSubtract);
            this.srt.Controls.Add(this.srtRotAdd);
            this.srt.Controls.Add(this.srtRotReplace);
            this.srt.Controls.Add(this.srtTransSubtract);
            this.srt.Controls.Add(this.srtTransAdd);
            this.srt.Controls.Add(this.srtTransReplace);
            this.srt.Controls.Add(this.srtCopyKF);
            this.srt.Controls.Add(this.chkSrtVersion);
            this.srt.Controls.Add(this.srtVersion);
            this.srt.Controls.Add(this.srtEditLoop);
            this.srt.Location = new System.Drawing.Point(4, 25);
            this.srt.Name = "srt";
            this.srt.Padding = new System.Windows.Forms.Padding(3);
            this.srt.Size = new System.Drawing.Size(410, 344);
            this.srt.TabIndex = 1;
            this.srt.Text = "SRT0";
            // 
            // srtTexRename
            // 
            this.srtTexRename.AutoSize = true;
            this.srtTexRename.Location = new System.Drawing.Point(205, 96);
            this.srtTexRename.Name = "srtTexRename";
            this.srtTexRename.Size = new System.Drawing.Size(69, 17);
            this.srtTexRename.TabIndex = 81;
            this.srtTexRename.Text = "Rename:";
            this.srtTexRename.UseVisualStyleBackColor = true;
            // 
            // srtModMat
            // 
            this.srtModMat.AutoSize = true;
            this.srtModMat.Location = new System.Drawing.Point(204, 8);
            this.srtModMat.Name = "srtModMat";
            this.srtModMat.Size = new System.Drawing.Size(196, 17);
            this.srtModMat.TabIndex = 80;
            this.srtModMat.Text = "Only modify materials with the name:";
            this.srtModMat.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.HideSelection = false;
            this.textBox7.Location = new System.Drawing.Point(204, 113);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(189, 20);
            this.textBox7.TabIndex = 78;
            // 
            // srtMatName
            // 
            this.srtMatName.HideSelection = false;
            this.srtMatName.Location = new System.Drawing.Point(204, 25);
            this.srtMatName.Name = "srtMatName";
            this.srtMatName.Size = new System.Drawing.Size(189, 20);
            this.srtMatName.TabIndex = 75;
            // 
            // srtTexName
            // 
            this.srtTexName.HideSelection = false;
            this.srtTexName.Location = new System.Drawing.Point(11, 25);
            this.srtTexName.Name = "srtTexName";
            this.srtTexName.Size = new System.Drawing.Size(187, 20);
            this.srtTexName.TabIndex = 40;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(81, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 20);
            this.textBox3.TabIndex = 42;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(81, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(119, 20);
            this.textBox4.TabIndex = 43;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(82, 139);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(119, 20);
            this.textBox6.TabIndex = 48;
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(81, 188);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(119, 20);
            this.textBox9.TabIndex = 51;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(81, 209);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(119, 20);
            this.textBox10.TabIndex = 52;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(204, 73);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(189, 20);
            this.textBox12.TabIndex = 70;
            // 
            // srtLoopEnable
            // 
            this.srtLoopEnable.AutoSize = true;
            this.srtLoopEnable.Enabled = false;
            this.srtLoopEnable.Location = new System.Drawing.Point(279, 166);
            this.srtLoopEnable.Name = "srtLoopEnable";
            this.srtLoopEnable.Size = new System.Drawing.Size(92, 17);
            this.srtLoopEnable.TabIndex = 77;
            this.srtLoopEnable.Text = "Loop Enabled";
            this.srtLoopEnable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Change all textures with the name:";
            // 
            // srtScaleX
            // 
            this.srtScaleX.AutoSize = true;
            this.srtScaleX.Location = new System.Drawing.Point(12, 76);
            this.srtScaleX.Name = "srtScaleX";
            this.srtScaleX.Size = new System.Drawing.Size(47, 13);
            this.srtScaleX.TabIndex = 45;
            this.srtScaleX.Text = "Scale X:";
            // 
            // srtScaleY
            // 
            this.srtScaleY.AutoSize = true;
            this.srtScaleY.Location = new System.Drawing.Point(11, 97);
            this.srtScaleY.Name = "srtScaleY";
            this.srtScaleY.Size = new System.Drawing.Size(47, 13);
            this.srtScaleY.TabIndex = 46;
            this.srtScaleY.Text = "Scale Y:";
            // 
            // srtRot
            // 
            this.srtRot.AutoSize = true;
            this.srtRot.Location = new System.Drawing.Point(12, 142);
            this.srtRot.Name = "srtRot";
            this.srtRot.Size = new System.Drawing.Size(50, 13);
            this.srtRot.TabIndex = 54;
            this.srtRot.Text = "Rotation:";
            // 
            // srtTransX
            // 
            this.srtTransX.AutoSize = true;
            this.srtTransX.Location = new System.Drawing.Point(11, 192);
            this.srtTransX.Name = "srtTransX";
            this.srtTransX.Size = new System.Drawing.Size(64, 13);
            this.srtTransX.TabIndex = 57;
            this.srtTransX.Text = "Translate X:";
            // 
            // srtTransY
            // 
            this.srtTransY.AutoSize = true;
            this.srtTransY.Location = new System.Drawing.Point(11, 214);
            this.srtTransY.Name = "srtTransY";
            this.srtTransY.Size = new System.Drawing.Size(64, 13);
            this.srtTransY.TabIndex = 58;
            this.srtTransY.Text = "Translate Y:";
            // 
            // srtScaleSubtract
            // 
            this.srtScaleSubtract.AutoSize = true;
            this.srtScaleSubtract.Location = new System.Drawing.Point(123, 51);
            this.srtScaleSubtract.Name = "srtScaleSubtract";
            this.srtScaleSubtract.Size = new System.Drawing.Size(66, 17);
            this.srtScaleSubtract.TabIndex = 62;
            this.srtScaleSubtract.Text = "Subtract";
            this.srtScaleSubtract.UseVisualStyleBackColor = true;
            // 
            // srtScaleAdd
            // 
            this.srtScaleAdd.AutoSize = true;
            this.srtScaleAdd.Location = new System.Drawing.Point(77, 51);
            this.srtScaleAdd.Name = "srtScaleAdd";
            this.srtScaleAdd.Size = new System.Drawing.Size(45, 17);
            this.srtScaleAdd.TabIndex = 61;
            this.srtScaleAdd.Text = "Add";
            this.srtScaleAdd.UseVisualStyleBackColor = true;
            // 
            // srtScaleReplace
            // 
            this.srtScaleReplace.AutoSize = true;
            this.srtScaleReplace.Location = new System.Drawing.Point(12, 51);
            this.srtScaleReplace.Name = "srtScaleReplace";
            this.srtScaleReplace.Size = new System.Drawing.Size(66, 17);
            this.srtScaleReplace.TabIndex = 60;
            this.srtScaleReplace.Text = "Replace";
            this.srtScaleReplace.UseVisualStyleBackColor = true;
            // 
            // srtRotSubtract
            // 
            this.srtRotSubtract.AutoSize = true;
            this.srtRotSubtract.Location = new System.Drawing.Point(123, 118);
            this.srtRotSubtract.Name = "srtRotSubtract";
            this.srtRotSubtract.Size = new System.Drawing.Size(66, 17);
            this.srtRotSubtract.TabIndex = 65;
            this.srtRotSubtract.Text = "Subtract";
            this.srtRotSubtract.UseVisualStyleBackColor = true;
            // 
            // srtRotAdd
            // 
            this.srtRotAdd.AutoSize = true;
            this.srtRotAdd.Location = new System.Drawing.Point(77, 118);
            this.srtRotAdd.Name = "srtRotAdd";
            this.srtRotAdd.Size = new System.Drawing.Size(45, 17);
            this.srtRotAdd.TabIndex = 64;
            this.srtRotAdd.Text = "Add";
            this.srtRotAdd.UseVisualStyleBackColor = true;
            // 
            // srtRotReplace
            // 
            this.srtRotReplace.AutoSize = true;
            this.srtRotReplace.Location = new System.Drawing.Point(12, 118);
            this.srtRotReplace.Name = "srtRotReplace";
            this.srtRotReplace.Size = new System.Drawing.Size(66, 17);
            this.srtRotReplace.TabIndex = 63;
            this.srtRotReplace.Text = "Replace";
            this.srtRotReplace.UseVisualStyleBackColor = true;
            // 
            // srtTransSubtract
            // 
            this.srtTransSubtract.AutoSize = true;
            this.srtTransSubtract.Location = new System.Drawing.Point(123, 166);
            this.srtTransSubtract.Name = "srtTransSubtract";
            this.srtTransSubtract.Size = new System.Drawing.Size(66, 17);
            this.srtTransSubtract.TabIndex = 68;
            this.srtTransSubtract.Text = "Subtract";
            this.srtTransSubtract.UseVisualStyleBackColor = true;
            // 
            // srtTransAdd
            // 
            this.srtTransAdd.AutoSize = true;
            this.srtTransAdd.Location = new System.Drawing.Point(77, 166);
            this.srtTransAdd.Name = "srtTransAdd";
            this.srtTransAdd.Size = new System.Drawing.Size(45, 17);
            this.srtTransAdd.TabIndex = 67;
            this.srtTransAdd.Text = "Add";
            this.srtTransAdd.UseVisualStyleBackColor = true;
            // 
            // srtTransReplace
            // 
            this.srtTransReplace.AutoSize = true;
            this.srtTransReplace.Location = new System.Drawing.Point(12, 166);
            this.srtTransReplace.Name = "srtTransReplace";
            this.srtTransReplace.Size = new System.Drawing.Size(66, 17);
            this.srtTransReplace.TabIndex = 66;
            this.srtTransReplace.Text = "Replace";
            this.srtTransReplace.UseVisualStyleBackColor = true;
            // 
            // srtCopyKF
            // 
            this.srtCopyKF.AutoSize = true;
            this.srtCopyKF.Location = new System.Drawing.Point(205, 51);
            this.srtCopyKF.Name = "srtCopyKF";
            this.srtCopyKF.Size = new System.Drawing.Size(127, 17);
            this.srtCopyKF.TabIndex = 69;
            this.srtCopyKF.Text = "Copy keyframes from:";
            this.srtCopyKF.UseVisualStyleBackColor = true;
            // 
            // chkSrtVersion
            // 
            this.chkSrtVersion.AutoSize = true;
            this.chkSrtVersion.Location = new System.Drawing.Point(205, 141);
            this.chkSrtVersion.Name = "chkSrtVersion";
            this.chkSrtVersion.Size = new System.Drawing.Size(103, 17);
            this.chkSrtVersion.TabIndex = 71;
            this.chkSrtVersion.Text = "Change version:";
            this.chkSrtVersion.UseVisualStyleBackColor = true;
            // 
            // srtVersion
            // 
            this.srtVersion.Enabled = false;
            this.srtVersion.FormattingEnabled = true;
            this.srtVersion.Items.AddRange(new object[] {
            "4",
            "5"});
            this.srtVersion.Location = new System.Drawing.Point(314, 139);
            this.srtVersion.Name = "srtVersion";
            this.srtVersion.Size = new System.Drawing.Size(79, 21);
            this.srtVersion.TabIndex = 72;
            // 
            // srtEditLoop
            // 
            this.srtEditLoop.AutoSize = true;
            this.srtEditLoop.Location = new System.Drawing.Point(205, 166);
            this.srtEditLoop.Name = "srtEditLoop";
            this.srtEditLoop.Size = new System.Drawing.Size(74, 17);
            this.srtEditLoop.TabIndex = 74;
            this.srtEditLoop.Text = "Edit Loop:";
            this.srtEditLoop.UseVisualStyleBackColor = true;
            // 
            // chr
            // 
            this.chr.BackColor = System.Drawing.SystemColors.Control;
            this.chr.Controls.Add(this.editAllCHR0Editor1);
            this.chr.Location = new System.Drawing.Point(4, 25);
            this.chr.Name = "chr";
            this.chr.Padding = new System.Windows.Forms.Padding(3);
            this.chr.Size = new System.Drawing.Size(410, 344);
            this.chr.TabIndex = 0;
            this.chr.Text = "CHR0";
            // 
            // editAllCHR0Editor1
            // 
            this.editAllCHR0Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAllCHR0Editor1.Enabled = false;
            this.editAllCHR0Editor1.Location = new System.Drawing.Point(3, 3);
            this.editAllCHR0Editor1.Name = "editAllCHR0Editor1";
            this.editAllCHR0Editor1.Size = new System.Drawing.Size(404, 338);
            this.editAllCHR0Editor1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.chr);
            this.tabControl1.Controls.Add(this.srt);
            this.tabControl1.Controls.Add(this.shp);
            this.tabControl1.Controls.Add(this.pat);
            this.tabControl1.Controls.Add(this.vis);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 373);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // EditAllDialog
            // 
            this.AcceptButton = this.btnOkay;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(418, 405);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditAllDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit All Animations";
            this.srt.ResumeLayout(false);
            this.srt.PerformLayout();
            this.chr.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public bool[] _enabled = new bool[5];

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (_enabled[0])
                editAllCHR0Editor1.Apply(_node);
            DialogResult = DialogResult.OK; 
            Close();
        }

        public void ShowDialog(IWin32Window owner, ResourceNode resource)
        {
            _node = resource; 
            _enabled = new bool[5];
            base.ShowDialog(owner);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = _enabled[tabControl1.SelectedIndex];
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    editAllCHR0Editor1.Enabled = checkBox1.Checked;
                    break;
                //case 1:
                //    editAllSRT0Editor1.Enabled = checkBox1.Checked;
                //    break;
                //case 2:
                //    editAllSHP0Editor1.Enabled = checkBox1.Checked;
                //    break;
                //case 3:
                //    editAllPAT0Editor1.Enabled = checkBox1.Checked;
                //    break;
                //case 4:
                //    editAllVIS0Editor1.Enabled = checkBox1.Checked;
                //    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _enabled[tabControl1.SelectedIndex] = checkBox1.Checked;
            tabControl1_SelectedIndexChanged(null, null);
        }
    }
}
