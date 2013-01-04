using System;
namespace System.Windows.Forms
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpKeys = new System.Windows.Forms.GroupBox();
            this.listKeyframes = new System.Windows.Forms.ListBox();
            this.visEditor = new System.Windows.Forms.VisEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkConstant = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clrControl = new System.Windows.Forms.CLRControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkClrEnabled = new System.Windows.Forms.CheckBox();
            this.chkClrConst = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lstTypes = new System.Windows.Forms.ComboBox();
            this.grpKeys.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKeys
            // 
            this.grpKeys.Controls.Add(this.listKeyframes);
            this.grpKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKeys.Location = new System.Drawing.Point(0, 0);
            this.grpKeys.Name = "grpKeys";
            this.grpKeys.Size = new System.Drawing.Size(279, 384);
            this.grpKeys.TabIndex = 22;
            this.grpKeys.TabStop = false;
            this.grpKeys.Text = "Keyframes";
            // 
            // listKeyframes
            // 
            this.listKeyframes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKeyframes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listKeyframes.FormattingEnabled = true;
            this.listKeyframes.IntegralHeight = false;
            this.listKeyframes.ItemHeight = 14;
            this.listKeyframes.Location = new System.Drawing.Point(3, 16);
            this.listKeyframes.Name = "listKeyframes";
            this.listKeyframes.Size = new System.Drawing.Size(273, 365);
            this.listKeyframes.TabIndex = 18;
            this.listKeyframes.SelectedIndexChanged += new System.EventHandler(this.listKeyframes_SelectedIndexChanged);
            // 
            // visEditor
            // 
            this.visEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visEditor.Location = new System.Drawing.Point(0, 23);
            this.visEditor.Name = "visEditor";
            this.visEditor.Size = new System.Drawing.Size(279, 361);
            this.visEditor.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.visEditor);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 384);
            this.panel1.TabIndex = 23;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 23);
            this.panel2.TabIndex = 20;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Enabled = false;
            this.chkEnabled.Location = new System.Drawing.Point(71, 3);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkConstant
            // 
            this.chkConstant.AutoSize = true;
            this.chkConstant.Location = new System.Drawing.Point(3, 3);
            this.chkConstant.Name = "chkConstant";
            this.chkConstant.Size = new System.Drawing.Size(68, 17);
            this.chkConstant.TabIndex = 0;
            this.chkConstant.Text = "Constant";
            this.chkConstant.UseVisualStyleBackColor = true;
            this.chkConstant.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clrControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 384);
            this.panel3.TabIndex = 24;
            this.panel3.Visible = false;
            // 
            // clrControl
            // 
            this.clrControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clrControl.Location = new System.Drawing.Point(0, 0);
            this.clrControl.Name = "clrControl";
            this.clrControl.Size = new System.Drawing.Size(279, 384);
            this.clrControl.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.lstTypes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 23);
            this.panel4.TabIndex = 20;
            // 
            // chkClrEnabled
            // 
            this.chkClrEnabled.AutoSize = true;
            this.chkClrEnabled.Location = new System.Drawing.Point(71, 3);
            this.chkClrEnabled.Name = "chkClrEnabled";
            this.chkClrEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkClrEnabled.TabIndex = 1;
            this.chkClrEnabled.Text = "Enabled";
            this.chkClrEnabled.UseVisualStyleBackColor = true;
            this.chkClrEnabled.CheckedChanged += new System.EventHandler(this.chkClrEnabled_CheckedChanged);
            // 
            // chkClrConst
            // 
            this.chkClrConst.AutoSize = true;
            this.chkClrConst.Location = new System.Drawing.Point(3, 3);
            this.chkClrConst.Name = "chkClrConst";
            this.chkClrConst.Size = new System.Drawing.Size(68, 17);
            this.chkClrConst.TabIndex = 0;
            this.chkClrConst.Text = "Constant";
            this.chkClrConst.UseVisualStyleBackColor = true;
            this.chkClrConst.CheckedChanged += new System.EventHandler(this.chkClrConst_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.chkClrEnabled);
            this.panel6.Controls.Add(this.chkClrConst);
            this.panel6.Controls.Add(this.chkEnabled);
            this.panel6.Controls.Add(this.chkConstant);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(90, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(189, 23);
            this.panel6.TabIndex = 3;
            // 
            // lstTypes
            // 
            this.lstTypes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.Items.AddRange(new object[] {
            "Keyframes",
            "Colors",
            "Visibility"});
            this.lstTypes.Location = new System.Drawing.Point(0, 0);
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(90, 21);
            this.lstTypes.TabIndex = 0;
            this.lstTypes.SelectedIndexChanged += new System.EventHandler(this.lstTypes_SelectedIndexChanged);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpKeys);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(279, 384);
            this.grpKeys.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ListBox listKeyframes;
        public VisEditor visEditor;
        public GroupBox grpKeys;
        private Panel panel1;
        private Panel panel2;
        public CheckBox chkEnabled;
        public CheckBox chkConstant;
        private Panel panel3;
        public CLRControl clrControl;
        private Panel panel4;
        public CheckBox chkClrConst;
        public CheckBox chkClrEnabled;
        private Panel panel6;
        private ComboBox lstTypes;
    }
}
