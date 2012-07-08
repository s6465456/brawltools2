namespace SmashBox
{
    partial class ConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMDL0 = new System.Windows.Forms.CheckBox();
            this.chkPLT0 = new System.Windows.Forms.CheckBox();
            this.chkTEX0 = new System.Windows.Forms.CheckBox();
            this.chkBRRES = new System.Windows.Forms.CheckBox();
            this.chkPCS = new System.Windows.Forms.CheckBox();
            this.chkPAC = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkBRSTM = new System.Windows.Forms.CheckBox();
            this.chkBRSAR = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkBRSAR);
            this.groupBox1.Controls.Add(this.chkBRSTM);
            this.groupBox1.Controls.Add(this.chkMDL0);
            this.groupBox1.Controls.Add(this.chkPLT0);
            this.groupBox1.Controls.Add(this.chkTEX0);
            this.groupBox1.Controls.Add(this.chkBRRES);
            this.groupBox1.Controls.Add(this.chkPCS);
            this.groupBox1.Controls.Add(this.chkPAC);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Associations";
            // 
            // chkMDL0
            // 
            this.chkMDL0.AutoSize = true;
            this.chkMDL0.Enabled = false;
            this.chkMDL0.Location = new System.Drawing.Point(97, 65);
            this.chkMDL0.Name = "chkMDL0";
            this.chkMDL0.Size = new System.Drawing.Size(51, 17);
            this.chkMDL0.TabIndex = 6;
            this.chkMDL0.Text = ".mdl0";
            this.chkMDL0.UseVisualStyleBackColor = true;
            // 
            // chkPLT0
            // 
            this.chkPLT0.AutoSize = true;
            this.chkPLT0.Location = new System.Drawing.Point(97, 42);
            this.chkPLT0.Name = "chkPLT0";
            this.chkPLT0.Size = new System.Drawing.Size(46, 17);
            this.chkPLT0.TabIndex = 5;
            this.chkPLT0.Text = ".plt0";
            this.chkPLT0.UseVisualStyleBackColor = true;
            // 
            // chkTEX0
            // 
            this.chkTEX0.AutoSize = true;
            this.chkTEX0.Location = new System.Drawing.Point(97, 19);
            this.chkTEX0.Name = "chkTEX0";
            this.chkTEX0.Size = new System.Drawing.Size(49, 17);
            this.chkTEX0.TabIndex = 4;
            this.chkTEX0.Text = ".tex0";
            this.chkTEX0.UseVisualStyleBackColor = true;
            // 
            // chkBRRES
            // 
            this.chkBRRES.AutoSize = true;
            this.chkBRRES.Location = new System.Drawing.Point(6, 65);
            this.chkBRRES.Name = "chkBRRES";
            this.chkBRRES.Size = new System.Drawing.Size(52, 17);
            this.chkBRRES.TabIndex = 3;
            this.chkBRRES.Text = ".brres";
            this.chkBRRES.UseVisualStyleBackColor = true;
            // 
            // chkPCS
            // 
            this.chkPCS.AutoSize = true;
            this.chkPCS.Location = new System.Drawing.Point(6, 42);
            this.chkPCS.Name = "chkPCS";
            this.chkPCS.Size = new System.Drawing.Size(46, 17);
            this.chkPCS.TabIndex = 2;
            this.chkPCS.Text = ".pcs";
            this.chkPCS.UseVisualStyleBackColor = true;
            // 
            // chkPAC
            // 
            this.chkPAC.AutoSize = true;
            this.chkPAC.Location = new System.Drawing.Point(6, 19);
            this.chkPAC.Name = "chkPAC";
            this.chkPAC.Size = new System.Drawing.Size(47, 17);
            this.chkPAC.TabIndex = 1;
            this.chkPAC.Text = ".pac";
            this.chkPAC.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(272, 120);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(191, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(110, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&Okay";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkBRSTM
            // 
            this.chkBRSTM.AutoSize = true;
            this.chkBRSTM.Location = new System.Drawing.Point(190, 19);
            this.chkBRSTM.Name = "chkBRSTM";
            this.chkBRSTM.Size = new System.Drawing.Size(54, 17);
            this.chkBRSTM.TabIndex = 7;
            this.chkBRSTM.Text = ".brstm";
            this.chkBRSTM.UseVisualStyleBackColor = true;
            // 
            // chkBRSAR
            // 
            this.chkBRSAR.AutoSize = true;
            this.chkBRSAR.Location = new System.Drawing.Point(190, 42);
            this.chkBRSAR.Name = "chkBRSAR";
            this.chkBRSAR.Size = new System.Drawing.Size(52, 17);
            this.chkBRSAR.TabIndex = 8;
            this.chkBRSAR.Text = ".brsar";
            this.chkBRSAR.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 155);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigForm";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPLT0;
        private System.Windows.Forms.CheckBox chkTEX0;
        private System.Windows.Forms.CheckBox chkBRRES;
        private System.Windows.Forms.CheckBox chkPCS;
        private System.Windows.Forms.CheckBox chkPAC;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkMDL0;
        private System.Windows.Forms.CheckBox chkBRSAR;
        private System.Windows.Forms.CheckBox chkBRSTM;
    }
}