using System.Windows.Forms;
namespace Ikarus.UI
{
    partial class RightPanel
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lstOpenedFiles = new System.Windows.Forms.ListBox();
            this.pnlMoveset = new Ikarus.UI.ScriptPanel();
            this.pnlKeyframes = new System.Windows.Forms.KeyframePanel();
            this.pnlBones = new System.Windows.Forms.BonesPanel();
            this.editor = new System.Windows.Forms.ComboBox();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.lstOpenedFiles);
            this.pnlControls.Controls.Add(this.pnlMoveset);
            this.pnlControls.Controls.Add(this.pnlKeyframes);
            this.pnlControls.Controls.Add(this.pnlBones);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 21);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(262, 484);
            this.pnlControls.TabIndex = 3;
            // 
            // lstOpenedFiles
            // 
            this.lstOpenedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOpenedFiles.FormattingEnabled = true;
            this.lstOpenedFiles.IntegralHeight = false;
            this.lstOpenedFiles.Location = new System.Drawing.Point(0, 0);
            this.lstOpenedFiles.Name = "lstOpenedFiles";
            this.lstOpenedFiles.Size = new System.Drawing.Size(262, 484);
            this.lstOpenedFiles.TabIndex = 3;
            this.lstOpenedFiles.Visible = false;
            this.lstOpenedFiles.DoubleClick += new System.EventHandler(this.lstOpenedFiles_DoubleClick);
            // 
            // pnlMoveset
            // 
            this.pnlMoveset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoveset.Location = new System.Drawing.Point(0, 0);
            this.pnlMoveset.Name = "pnlMoveset";
            this.pnlMoveset.SelectedEvent = null;
            this.pnlMoveset.Size = new System.Drawing.Size(262, 484);
            this.pnlMoveset.TabIndex = 0;
            // 
            // pnlKeyframes
            // 
            this.pnlKeyframes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKeyframes.FrameCount = -1;
            this.pnlKeyframes.Location = new System.Drawing.Point(0, 0);
            this.pnlKeyframes.Name = "pnlKeyframes";
            this.pnlKeyframes.Size = new System.Drawing.Size(262, 484);
            this.pnlKeyframes.TabIndex = 3;
            this.pnlKeyframes.Visible = false;
            // 
            // pnlBones
            // 
            this.pnlBones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBones.Location = new System.Drawing.Point(0, 0);
            this.pnlBones.Name = "pnlBones";
            this.pnlBones.Size = new System.Drawing.Size(262, 484);
            this.pnlBones.TabIndex = 1;
            this.pnlBones.Visible = false;
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Top;
            this.editor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editor.FormattingEnabled = true;
            this.editor.Items.AddRange(new object[] {
            "Scripting",
            "Miscellaneous",
            "Keyframes",
            "Bones",
            "Opened File List"});
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(262, 21);
            this.editor.TabIndex = 0;
            this.editor.SelectedIndexChanged += new System.EventHandler(this.editor_SelectedIndexChanged);
            // 
            // RightPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.editor);
            this.Name = "RightPanel";
            this.Size = new System.Drawing.Size(262, 505);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ComboBox editor;
        public BonesPanel pnlBones;
        public KeyframePanel pnlKeyframes;
        private ListBox lstOpenedFiles;
        public ScriptPanel pnlMoveset;
    }
}
