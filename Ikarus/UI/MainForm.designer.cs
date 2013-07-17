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
            this._mainControl = new Ikarus.UI.MainControl();
            this.SuspendLayout();
            // 
            // _mainControl
            // 
            this._mainControl.AllowDrop = true;
            this._mainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainControl.ImgExtIndex = 0;
            this._mainControl.Location = new System.Drawing.Point(0, 0);
            this._mainControl.Name = "_mainControl";
            this._mainControl.Size = new System.Drawing.Size(763, 515);
            this._mainControl.TabIndex = 0;
            this._mainControl.TargetAnimation = null;
            this._mainControl.TargetAnimType = System.Windows.Forms.AnimType.CHR;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 515);
            this.Controls.Add(this._mainControl);
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        public MainControl _mainControl;
    }
}

