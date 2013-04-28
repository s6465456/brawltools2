﻿using System;
namespace System.Windows.Forms
{
    partial class KeyframePanel
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
            this.visPanel = new System.Windows.Forms.Panel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkConstant = new System.Windows.Forms.CheckBox();
            this.clrPanel = new System.Windows.Forms.Panel();
            this.clrControl = new System.Windows.Forms.CLRControl();
            this.ctrlPanel = new System.Windows.Forms.Panel();
            this.visclrPanel = new System.Windows.Forms.Panel();
            this.lstTypes = new System.Windows.Forms.ComboBox();
            this.grpKeys.SuspendLayout();
            this.visPanel.SuspendLayout();
            this.clrPanel.SuspendLayout();
            this.ctrlPanel.SuspendLayout();
            this.visclrPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKeys
            // 
            this.grpKeys.Controls.Add(this.listKeyframes);
            this.grpKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKeys.Location = new System.Drawing.Point(0, 23);
            this.grpKeys.Name = "grpKeys";
            this.grpKeys.Size = new System.Drawing.Size(279, 361);
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
            this.listKeyframes.Size = new System.Drawing.Size(273, 342);
            this.listKeyframes.TabIndex = 18;
            this.listKeyframes.SelectedIndexChanged += new System.EventHandler(this.listKeyframes_SelectedIndexChanged);
            // 
            // visEditor
            // 
            this.visEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visEditor.Location = new System.Drawing.Point(0, 0);
            this.visEditor.Name = "visEditor";
            this.visEditor.Size = new System.Drawing.Size(279, 361);
            this.visEditor.TabIndex = 19;
            // 
            // visPanel
            // 
            this.visPanel.Controls.Add(this.visEditor);
            this.visPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visPanel.Location = new System.Drawing.Point(0, 23);
            this.visPanel.Name = "visPanel";
            this.visPanel.Size = new System.Drawing.Size(279, 361);
            this.visPanel.TabIndex = 23;
            this.visPanel.Visible = false;
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
            // clrPanel
            // 
            this.clrPanel.Controls.Add(this.clrControl);
            this.clrPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clrPanel.Location = new System.Drawing.Point(0, 23);
            this.clrPanel.Name = "clrPanel";
            this.clrPanel.Size = new System.Drawing.Size(279, 361);
            this.clrPanel.TabIndex = 24;
            this.clrPanel.Visible = false;
            // 
            // clrControl
            // 
            this.clrControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clrControl.Location = new System.Drawing.Point(0, 0);
            this.clrControl.Name = "clrControl";
            this.clrControl.Size = new System.Drawing.Size(279, 361);
            this.clrControl.TabIndex = 21;
            // 
            // ctrlPanel
            // 
            this.ctrlPanel.Controls.Add(this.visclrPanel);
            this.ctrlPanel.Controls.Add(this.lstTypes);
            this.ctrlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPanel.Location = new System.Drawing.Point(0, 0);
            this.ctrlPanel.Name = "ctrlPanel";
            this.ctrlPanel.Size = new System.Drawing.Size(279, 23);
            this.ctrlPanel.TabIndex = 20;
            // 
            // visclrPanel
            // 
            this.visclrPanel.Controls.Add(this.chkEnabled);
            this.visclrPanel.Controls.Add(this.chkConstant);
            this.visclrPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visclrPanel.Location = new System.Drawing.Point(90, 0);
            this.visclrPanel.Name = "visclrPanel";
            this.visclrPanel.Size = new System.Drawing.Size(189, 23);
            this.visclrPanel.TabIndex = 3;
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
            this.Controls.Add(this.grpKeys);
            this.Controls.Add(this.visPanel);
            this.Controls.Add(this.clrPanel);
            this.Controls.Add(this.ctrlPanel);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(279, 384);
            this.grpKeys.ResumeLayout(false);
            this.visPanel.ResumeLayout(false);
            this.clrPanel.ResumeLayout(false);
            this.ctrlPanel.ResumeLayout(false);
            this.visclrPanel.ResumeLayout(false);
            this.visclrPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ListBox listKeyframes;
        public VisEditor visEditor;
        public GroupBox grpKeys;
        private Panel visPanel;
        public CheckBox chkEnabled;
        public CheckBox chkConstant;
        private Panel clrPanel;
        public CLRControl clrControl;
        private Panel ctrlPanel;
        private Panel visclrPanel;
        private ComboBox lstTypes;
    }
}
