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
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Brawl = new System.Windows.Forms.TabPage();
            this.SSE = new System.Windows.Forms.TabPage();
            this.editor = new System.Windows.Forms.ComboBox();
            this.pnlKeyframes = new System.Windows.Forms.KeyframePanel();
            this.pnlBones = new System.Windows.Forms.BonesPanel();
            this.brawlAttributes = new System.Windows.Forms.AttributeGrid();
            this.sseAttributes = new System.Windows.Forms.AttributeGrid();
            this.pnlMoveset = new Ikarus.UI.ScriptPanel();
            this.pnlControls.SuspendLayout();
            this.pnlAttributes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Brawl.SuspendLayout();
            this.SSE.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.lstOpenedFiles);
            this.pnlControls.Controls.Add(this.pnlAttributes);
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
            // pnlAttributes
            // 
            this.pnlAttributes.Controls.Add(this.tabControl1);
            this.pnlAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttributes.Location = new System.Drawing.Point(0, 0);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(262, 484);
            this.pnlAttributes.TabIndex = 4;
            this.pnlAttributes.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Brawl);
            this.tabControl1.Controls.Add(this.SSE);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(262, 484);
            this.tabControl1.TabIndex = 4;
            // 
            // Brawl
            // 
            this.Brawl.Controls.Add(this.brawlAttributes);
            this.Brawl.Location = new System.Drawing.Point(4, 22);
            this.Brawl.Name = "Brawl";
            this.Brawl.Padding = new System.Windows.Forms.Padding(3);
            this.Brawl.Size = new System.Drawing.Size(254, 458);
            this.Brawl.TabIndex = 0;
            this.Brawl.Text = "Brawl";
            this.Brawl.UseVisualStyleBackColor = true;
            // 
            // SSE
            // 
            this.SSE.Controls.Add(this.sseAttributes);
            this.SSE.Location = new System.Drawing.Point(4, 22);
            this.SSE.Name = "SSE";
            this.SSE.Padding = new System.Windows.Forms.Padding(3);
            this.SSE.Size = new System.Drawing.Size(254, 458);
            this.SSE.TabIndex = 1;
            this.SSE.Text = "Subspace Emissary";
            this.SSE.UseVisualStyleBackColor = true;
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
            // pnlKeyframes
            // 
            this.pnlKeyframes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKeyframes.FrameCount = -1;
            this.pnlKeyframes.Location = new System.Drawing.Point(0, 0);
            this.pnlKeyframes.Name = "pnlKeyframes";
            this.pnlKeyframes.Size = new System.Drawing.Size(262, 484);
            this.pnlKeyframes.TabIndex = 3;
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
            // brawlAttributes
            // 
            this.brawlAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brawlAttributes.Location = new System.Drawing.Point(3, 3);
            this.brawlAttributes.Name = "brawlAttributes";
            this.brawlAttributes.Size = new System.Drawing.Size(248, 452);
            this.brawlAttributes.TabIndex = 2;
            // 
            // sseAttributes
            // 
            this.sseAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sseAttributes.Location = new System.Drawing.Point(3, 3);
            this.sseAttributes.Name = "sseAttributes";
            this.sseAttributes.Size = new System.Drawing.Size(248, 452);
            this.sseAttributes.TabIndex = 3;
            // 
            // pnlMoveset
            // 
            this.pnlMoveset.CurrentFrame = -1;
            this.pnlMoveset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoveset.Location = new System.Drawing.Point(0, 0);
            this.pnlMoveset.Name = "pnlMoveset";
            this.pnlMoveset.Size = new System.Drawing.Size(262, 484);
            this.pnlMoveset.TabIndex = 0;
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
            this.pnlAttributes.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Brawl.ResumeLayout(false);
            this.SSE.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ComboBox editor;
        public BonesPanel pnlBones;
        private Panel pnlAttributes;
        private TabControl tabControl1;
        private TabPage Brawl;
        private AttributeGrid brawlAttributes;
        private TabPage SSE;
        private AttributeGrid sseAttributes;
        public KeyframePanel pnlKeyframes;
        private ListBox lstOpenedFiles;
        public ScriptPanel pnlMoveset;
    }
}
