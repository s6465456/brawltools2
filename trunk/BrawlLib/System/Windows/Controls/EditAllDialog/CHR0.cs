using System;
using BrawlLib.SSBB.ResourceNodes;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class EditAllCHR0Editor : UserControl
    {
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private CheckBox ReplaceTrans;
        private Label label9;
        private Label label10;
        private Label label11;
        private NumericInputBox TransZ;
        private NumericInputBox TransY;
        private NumericInputBox TransX;
        private CheckBox SubtractTrans;
        private CheckBox AddTrans;
        private GroupBox groupBox3;
        private CheckBox ReplaceRot;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericInputBox RotZ;
        private NumericInputBox RotY;
        private NumericInputBox RotX;
        private CheckBox SubtractRot;
        private CheckBox AddRot;
        private GroupBox groupBox5;
        private CheckBox ReplaceScale;
        private Label label7;
        private Label label6;
        private Label label8;
        private NumericInputBox ScaleZ;
        private NumericInputBox ScaleY;
        private NumericInputBox ScaleX;
        private CheckBox SubtractScale;
        private CheckBox AddScale;
        private Label label1;
        private TextBox textBox1;
        private TextBox name;
        private CheckBox copyKeyframes;
        private GroupBox groupBox1;
        private CheckBox NameContains;
        private TextBox textBox2;
        private CheckBox Rename;
        private TextBox textBox8;
        private CheckBox editLoop;
        private CheckBox enableLoop;
        private CheckBox Port;
        private ComboBox Version;
        private CheckBox ChangeVersion;
        #region Designer


        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ReplaceTrans = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TransZ = new System.Windows.Forms.NumericInputBox();
            this.TransY = new System.Windows.Forms.NumericInputBox();
            this.TransX = new System.Windows.Forms.NumericInputBox();
            this.SubtractTrans = new System.Windows.Forms.CheckBox();
            this.AddTrans = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReplaceRot = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RotZ = new System.Windows.Forms.NumericInputBox();
            this.RotY = new System.Windows.Forms.NumericInputBox();
            this.RotX = new System.Windows.Forms.NumericInputBox();
            this.SubtractRot = new System.Windows.Forms.CheckBox();
            this.AddRot = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ReplaceScale = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ScaleZ = new System.Windows.Forms.NumericInputBox();
            this.ScaleY = new System.Windows.Forms.NumericInputBox();
            this.ScaleX = new System.Windows.Forms.NumericInputBox();
            this.SubtractScale = new System.Windows.Forms.CheckBox();
            this.AddScale = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.copyKeyframes = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NameContains = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Rename = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.editLoop = new System.Windows.Forms.CheckBox();
            this.enableLoop = new System.Windows.Forms.CheckBox();
            this.Port = new System.Windows.Forms.CheckBox();
            this.Version = new System.Windows.Forms.ComboBox();
            this.ChangeVersion = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Controls.Add(this.copyKeyframes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 159);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHR0 Bone Entries";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ReplaceTrans);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.TransZ);
            this.groupBox4.Controls.Add(this.TransY);
            this.groupBox4.Controls.Add(this.TransX);
            this.groupBox4.Controls.Add(this.SubtractTrans);
            this.groupBox4.Controls.Add(this.AddTrans);
            this.groupBox4.Location = new System.Drawing.Point(386, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 84);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Translate";
            // 
            // ReplaceTrans
            // 
            this.ReplaceTrans.AutoSize = true;
            this.ReplaceTrans.Location = new System.Drawing.Point(106, 17);
            this.ReplaceTrans.Name = "ReplaceTrans";
            this.ReplaceTrans.Size = new System.Drawing.Size(66, 17);
            this.ReplaceTrans.TabIndex = 27;
            this.ReplaceTrans.Text = "Replace";
            this.ReplaceTrans.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "X:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Z:";
            // 
            // TransZ
            // 
            this.TransZ.Enabled = false;
            this.TransZ.Location = new System.Drawing.Point(24, 57);
            this.TransZ.Name = "TransZ";
            this.TransZ.Size = new System.Drawing.Size(76, 20);
            this.TransZ.TabIndex = 14;
            this.TransZ.Text = "0";
            // 
            // TransY
            // 
            this.TransY.Enabled = false;
            this.TransY.Location = new System.Drawing.Point(24, 36);
            this.TransY.Name = "TransY";
            this.TransY.Size = new System.Drawing.Size(76, 20);
            this.TransY.TabIndex = 13;
            this.TransY.Text = "0";
            // 
            // TransX
            // 
            this.TransX.Enabled = false;
            this.TransX.Location = new System.Drawing.Point(24, 15);
            this.TransX.Name = "TransX";
            this.TransX.Size = new System.Drawing.Size(76, 20);
            this.TransX.TabIndex = 12;
            this.TransX.Text = "0";
            // 
            // SubtractTrans
            // 
            this.SubtractTrans.AutoSize = true;
            this.SubtractTrans.Location = new System.Drawing.Point(106, 59);
            this.SubtractTrans.Name = "SubtractTrans";
            this.SubtractTrans.Size = new System.Drawing.Size(66, 17);
            this.SubtractTrans.TabIndex = 29;
            this.SubtractTrans.Text = "Subtract";
            this.SubtractTrans.UseVisualStyleBackColor = true;
            // 
            // AddTrans
            // 
            this.AddTrans.AutoSize = true;
            this.AddTrans.Location = new System.Drawing.Point(106, 38);
            this.AddTrans.Name = "AddTrans";
            this.AddTrans.Size = new System.Drawing.Size(45, 17);
            this.AddTrans.TabIndex = 28;
            this.AddTrans.Text = "Add";
            this.AddTrans.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReplaceRot);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.RotZ);
            this.groupBox3.Controls.Add(this.RotY);
            this.groupBox3.Controls.Add(this.RotX);
            this.groupBox3.Controls.Add(this.SubtractRot);
            this.groupBox3.Controls.Add(this.AddRot);
            this.groupBox3.Location = new System.Drawing.Point(197, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 84);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotate";
            // 
            // ReplaceRot
            // 
            this.ReplaceRot.AutoSize = true;
            this.ReplaceRot.Location = new System.Drawing.Point(106, 17);
            this.ReplaceRot.Name = "ReplaceRot";
            this.ReplaceRot.Size = new System.Drawing.Size(66, 17);
            this.ReplaceRot.TabIndex = 27;
            this.ReplaceRot.Text = "Replace";
            this.ReplaceRot.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Z:";
            // 
            // RotZ
            // 
            this.RotZ.Enabled = false;
            this.RotZ.Location = new System.Drawing.Point(24, 57);
            this.RotZ.Name = "RotZ";
            this.RotZ.Size = new System.Drawing.Size(76, 20);
            this.RotZ.TabIndex = 14;
            this.RotZ.Text = "0";
            // 
            // RotY
            // 
            this.RotY.Enabled = false;
            this.RotY.Location = new System.Drawing.Point(24, 36);
            this.RotY.Name = "RotY";
            this.RotY.Size = new System.Drawing.Size(76, 20);
            this.RotY.TabIndex = 13;
            this.RotY.Text = "0";
            // 
            // RotX
            // 
            this.RotX.Enabled = false;
            this.RotX.Location = new System.Drawing.Point(24, 15);
            this.RotX.Name = "RotX";
            this.RotX.Size = new System.Drawing.Size(76, 20);
            this.RotX.TabIndex = 12;
            this.RotX.Text = "0";
            // 
            // SubtractRot
            // 
            this.SubtractRot.AutoSize = true;
            this.SubtractRot.Location = new System.Drawing.Point(106, 59);
            this.SubtractRot.Name = "SubtractRot";
            this.SubtractRot.Size = new System.Drawing.Size(66, 17);
            this.SubtractRot.TabIndex = 29;
            this.SubtractRot.Text = "Subtract";
            this.SubtractRot.UseVisualStyleBackColor = true;
            // 
            // AddRot
            // 
            this.AddRot.AutoSize = true;
            this.AddRot.Location = new System.Drawing.Point(106, 38);
            this.AddRot.Name = "AddRot";
            this.AddRot.Size = new System.Drawing.Size(45, 17);
            this.AddRot.TabIndex = 28;
            this.AddRot.Text = "Add";
            this.AddRot.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ReplaceScale);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.ScaleZ);
            this.groupBox5.Controls.Add(this.ScaleY);
            this.groupBox5.Controls.Add(this.ScaleX);
            this.groupBox5.Controls.Add(this.SubtractScale);
            this.groupBox5.Controls.Add(this.AddScale);
            this.groupBox5.Location = new System.Drawing.Point(8, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(183, 84);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scale";
            // 
            // ReplaceScale
            // 
            this.ReplaceScale.AutoSize = true;
            this.ReplaceScale.Location = new System.Drawing.Point(106, 17);
            this.ReplaceScale.Name = "ReplaceScale";
            this.ReplaceScale.Size = new System.Drawing.Size(66, 17);
            this.ReplaceScale.TabIndex = 27;
            this.ReplaceScale.Text = "Replace";
            this.ReplaceScale.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Z:";
            // 
            // ScaleZ
            // 
            this.ScaleZ.Enabled = false;
            this.ScaleZ.Location = new System.Drawing.Point(24, 57);
            this.ScaleZ.Name = "ScaleZ";
            this.ScaleZ.Size = new System.Drawing.Size(76, 20);
            this.ScaleZ.TabIndex = 14;
            this.ScaleZ.Text = "0";
            // 
            // ScaleY
            // 
            this.ScaleY.Enabled = false;
            this.ScaleY.Location = new System.Drawing.Point(24, 36);
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.Size = new System.Drawing.Size(76, 20);
            this.ScaleY.TabIndex = 13;
            this.ScaleY.Text = "0";
            // 
            // ScaleX
            // 
            this.ScaleX.Enabled = false;
            this.ScaleX.Location = new System.Drawing.Point(24, 15);
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.Size = new System.Drawing.Size(76, 20);
            this.ScaleX.TabIndex = 12;
            this.ScaleX.Text = "0";
            // 
            // SubtractScale
            // 
            this.SubtractScale.AutoSize = true;
            this.SubtractScale.Location = new System.Drawing.Point(106, 59);
            this.SubtractScale.Name = "SubtractScale";
            this.SubtractScale.Size = new System.Drawing.Size(66, 17);
            this.SubtractScale.TabIndex = 29;
            this.SubtractScale.Text = "Subtract";
            this.SubtractScale.UseVisualStyleBackColor = true;
            // 
            // AddScale
            // 
            this.AddScale.AutoSize = true;
            this.AddScale.Location = new System.Drawing.Point(106, 38);
            this.AddScale.Name = "AddScale";
            this.AddScale.Size = new System.Drawing.Size(45, 17);
            this.AddScale.TabIndex = 28;
            this.AddScale.Text = "Add";
            this.AddScale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Change all bone entries with the name:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(204, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 20);
            this.textBox1.TabIndex = 34;
            // 
            // name
            // 
            this.name.HideSelection = false;
            this.name.Location = new System.Drawing.Point(11, 42);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(187, 20);
            this.name.TabIndex = 0;
            // 
            // copyKeyframes
            // 
            this.copyKeyframes.AutoSize = true;
            this.copyKeyframes.Location = new System.Drawing.Point(204, 25);
            this.copyKeyframes.Name = "copyKeyframes";
            this.copyKeyframes.Size = new System.Drawing.Size(127, 17);
            this.copyKeyframes.TabIndex = 33;
            this.copyKeyframes.Text = "Copy keyframes from:";
            this.copyKeyframes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NameContains);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.Rename);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.editLoop);
            this.groupBox1.Controls.Add(this.enableLoop);
            this.groupBox1.Controls.Add(this.Port);
            this.groupBox1.Controls.Add(this.Version);
            this.groupBox1.Controls.Add(this.ChangeVersion);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 65);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHR0";
            // 
            // NameContains
            // 
            this.NameContains.AutoSize = true;
            this.NameContains.Location = new System.Drawing.Point(8, 18);
            this.NameContains.Name = "NameContains";
            this.NameContains.Size = new System.Drawing.Size(165, 17);
            this.NameContains.TabIndex = 85;
            this.NameContains.Text = "Modify only if name contains: ";
            this.NameContains.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(167, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 20);
            this.textBox2.TabIndex = 84;
            // 
            // Rename
            // 
            this.Rename.AutoSize = true;
            this.Rename.Location = new System.Drawing.Point(292, 19);
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(69, 17);
            this.Rename.TabIndex = 83;
            this.Rename.Text = "Rename:";
            this.Rename.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.HideSelection = false;
            this.textBox8.Location = new System.Drawing.Point(361, 17);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(119, 20);
            this.textBox8.TabIndex = 82;
            // 
            // editLoop
            // 
            this.editLoop.AutoSize = true;
            this.editLoop.Location = new System.Drawing.Point(8, 41);
            this.editLoop.Name = "editLoop";
            this.editLoop.Size = new System.Drawing.Size(74, 17);
            this.editLoop.TabIndex = 38;
            this.editLoop.Text = "Edit Loop:";
            this.editLoop.UseVisualStyleBackColor = true;
            this.editLoop.CheckedChanged += new System.EventHandler(this.editLoop_CheckedChanged);
            // 
            // enableLoop
            // 
            this.enableLoop.AutoSize = true;
            this.enableLoop.Enabled = false;
            this.enableLoop.Location = new System.Drawing.Point(82, 41);
            this.enableLoop.Name = "enableLoop";
            this.enableLoop.Size = new System.Drawing.Size(92, 17);
            this.enableLoop.TabIndex = 39;
            this.enableLoop.Text = "Loop Enabled";
            this.enableLoop.UseVisualStyleBackColor = true;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(202, 41);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(59, 17);
            this.Port.TabIndex = 37;
            this.Port.Text = "Port All";
            this.Port.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            this.Version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Version.Enabled = false;
            this.Version.FormattingEnabled = true;
            this.Version.Items.AddRange(new object[] {
            "4",
            "5"});
            this.Version.Location = new System.Drawing.Point(400, 38);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(80, 21);
            this.Version.TabIndex = 36;
            // 
            // ChangeVersion
            // 
            this.ChangeVersion.AutoSize = true;
            this.ChangeVersion.Location = new System.Drawing.Point(292, 41);
            this.ChangeVersion.Name = "ChangeVersion";
            this.ChangeVersion.Size = new System.Drawing.Size(103, 17);
            this.ChangeVersion.TabIndex = 35;
            this.ChangeVersion.Text = "Change version:";
            this.ChangeVersion.UseVisualStyleBackColor = true;
            // 
            // EditAllCHR0Editor
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditAllCHR0Editor";
            this.Size = new System.Drawing.Size(577, 224);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public EditAllCHR0Editor() { InitializeComponent(); }

        private void editLoop_CheckedChanged(object sender, EventArgs e)
        {
            enableLoop.Enabled = editLoop.Checked;
        }

        private void ReplaceScale_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = SubtractScale.Enabled = !ReplaceScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = ReplaceScale.Checked;
        }

        private void AddScale_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceScale.Enabled = SubtractScale.Enabled = !AddScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = AddScale.Checked;
        }

        private void SubtractScale_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = ReplaceScale.Enabled = !SubtractScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = SubtractScale.Checked;
        }

        private void ReplaceRot_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = SubtractScale.Enabled = !ReplaceScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = ReplaceScale.Checked;
        }

        private void AddRot_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceScale.Enabled = SubtractScale.Enabled = !AddScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = AddScale.Checked;
        }

        private void SubtractRot_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = ReplaceScale.Enabled = !SubtractScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = SubtractScale.Checked;
        }

        private void ReplaceTrans_CheckedChanged(object sender, EventArgs e)
        {
            AddTrans.Enabled = SubtractTrans.Enabled = !ReplaceTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = ReplaceTrans.Checked;
        }

        private void AddTrans_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceTrans.Enabled = SubtractTrans.Enabled = !AddTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = AddTrans.Checked;
        }

        private void SubtractTrans_CheckedChanged(object sender, EventArgs e)
        {
            AddTrans.Enabled = ReplaceTrans.Enabled = !SubtractTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = SubtractTrans.Checked;
        }
    }
}
