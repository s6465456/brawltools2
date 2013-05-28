using Ikarus.UI;
using System.Windows.Forms;
namespace Ikarus
{
    partial class MainForm
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
            this.mainControl = new Ikarus.UI.MainControl();
            this.SuspendLayout();
            // 
            // mainControl
            // 
            this.mainControl.AllowDrop = true;
            this.mainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControl.ImgExtIndex = 0;
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.Name = "mainControl";
            this.mainControl.Size = new System.Drawing.Size(661, 437);
            this.mainControl.TabIndex = 0;
            this.mainControl.TargetAnimType = System.Windows.Forms.AnimType.CHR;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 437);
            this.Controls.Add(this.mainControl);
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private MainControl mainControl;


    }
}

