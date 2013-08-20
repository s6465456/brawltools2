namespace System.Windows.Forms
{
    partial class InterpolationEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkLinear = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericInputBox3 = new System.Windows.Forms.NumericInputBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericInputBox1 = new System.Windows.Forms.NumericInputBox();
            this.numericInputBox2 = new System.Windows.Forms.NumericInputBox();
            this.chkGenTans = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkKeyDrag = new System.Windows.Forms.CheckBox();
            this.chkViewAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 105);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.chkLinear);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.chkGenTans);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.chkKeyDrag);
            this.panel2.Controls.Add(this.chkViewAll);
            this.panel2.Location = new System.Drawing.Point(58, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 99);
            this.panel2.TabIndex = 12;
            // 
            // chkLinear
            // 
            this.chkLinear.AutoSize = true;
            this.chkLinear.Location = new System.Drawing.Point(8, 45);
            this.chkLinear.Name = "chkLinear";
            this.chkLinear.Size = new System.Drawing.Size(92, 17);
            this.chkLinear.TabIndex = 12;
            this.chkLinear.Text = "Linear Display";
            this.chkLinear.UseVisualStyleBackColor = true;
            this.chkLinear.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericInputBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericInputBox1);
            this.groupBox1.Controls.Add(this.numericInputBox2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(134, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Keyframe";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frame:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericInputBox3
            // 
            this.numericInputBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericInputBox3.Location = new System.Drawing.Point(62, 16);
            this.numericInputBox3.Name = "numericInputBox3";
            this.numericInputBox3.Size = new System.Drawing.Size(60, 20);
            this.numericInputBox3.TabIndex = 4;
            this.numericInputBox3.Text = "0";
            this.numericInputBox3.ValueChanged += new System.EventHandler(this.numericInputBox3_ValueChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tangent:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericInputBox1
            // 
            this.numericInputBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericInputBox1.Location = new System.Drawing.Point(62, 54);
            this.numericInputBox1.Name = "numericInputBox1";
            this.numericInputBox1.Size = new System.Drawing.Size(60, 20);
            this.numericInputBox1.TabIndex = 0;
            this.numericInputBox1.Text = "0";
            this.numericInputBox1.ValueChanged += new System.EventHandler(this.numericInputBox1_ValueChanged);
            // 
            // numericInputBox2
            // 
            this.numericInputBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericInputBox2.Location = new System.Drawing.Point(62, 35);
            this.numericInputBox2.Name = "numericInputBox2";
            this.numericInputBox2.Size = new System.Drawing.Size(60, 20);
            this.numericInputBox2.TabIndex = 2;
            this.numericInputBox2.Text = "0";
            this.numericInputBox2.ValueChanged += new System.EventHandler(this.numericInputBox2_ValueChanged);
            // 
            // chkGenTans
            // 
            this.chkGenTans.AutoSize = true;
            this.chkGenTans.Location = new System.Drawing.Point(8, 79);
            this.chkGenTans.Name = "chkGenTans";
            this.chkGenTans.Size = new System.Drawing.Size(118, 17);
            this.chkGenTans.TabIndex = 10;
            this.chkGenTans.Text = "Generate Tangents";
            this.chkGenTans.UseVisualStyleBackColor = true;
            this.chkGenTans.CheckedChanged += new System.EventHandler(this.chkGenTans_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Scale X",
            "Scale Y",
            "Scale Z",
            "Rotation X",
            "Rotation Y",
            "Rotation Z",
            "Translation X",
            "Translation Y",
            "Translation Z"});
            this.comboBox1.Location = new System.Drawing.Point(7, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(116, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkKeyDrag
            // 
            this.chkKeyDrag.Location = new System.Drawing.Point(8, 59);
            this.chkKeyDrag.Name = "chkKeyDrag";
            this.chkKeyDrag.Size = new System.Drawing.Size(134, 22);
            this.chkKeyDrag.TabIndex = 11;
            this.chkKeyDrag.Text = "Draggable Keyframes";
            this.chkKeyDrag.UseVisualStyleBackColor = true;
            this.chkKeyDrag.CheckedChanged += new System.EventHandler(this.chkKeyDrag_CheckedChanged);
            // 
            // chkViewAll
            // 
            this.chkViewAll.AutoSize = true;
            this.chkViewAll.Checked = true;
            this.chkViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAll.Location = new System.Drawing.Point(8, 28);
            this.chkViewAll.Name = "chkViewAll";
            this.chkViewAll.Size = new System.Drawing.Size(115, 17);
            this.chkViewAll.TabIndex = 8;
            this.chkViewAll.Text = "View All Keyframes";
            this.chkViewAll.UseVisualStyleBackColor = true;
            this.chkViewAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // InterpolationEditor
            // 
            this.ClientSize = new System.Drawing.Size(384, 296);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(290, 235);
            this.Name = "InterpolationEditor";
            this.ShowIcon = false;
            this.Text = "Interpolation Editor";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private NumericInputBox numericInputBox1;
        private Label label3;
        private NumericInputBox numericInputBox3;
        private Label label2;
        private NumericInputBox numericInputBox2;
        private ComboBox comboBox1;
        private CheckBox chkViewAll;
        private GroupBox groupBox1;
        private CheckBox chkGenTans;
        private CheckBox chkKeyDrag;
        private Panel panel2;
        private CheckBox chkLinear;
    }
}