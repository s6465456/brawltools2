using System.Windows.Forms;
namespace BrawlBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resourceTree = new BrawlBox.ResourceTree();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aRCArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brresPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bRStmAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.animEditControl = new System.Windows.Forms.AnimEditControl();
            this.offsetEditor1 = new System.Windows.Forms.OffsetEditor();
            this.shpAnimEditControl = new System.Windows.Forms.ShpAnimEditControl();
            this.texAnimEditControl = new System.Windows.Forms.TexAnimEditControl();
            this.eventDescription1 = new System.Windows.Forms.EventDescription();
            this.attributeControl = new System.Windows.Forms.AttributeGrid();
            this.audioPlaybackPanel1 = new System.Windows.Forms.AudioPlaybackPanel();
            this.movesetEditor1 = new System.Windows.Forms.ScriptEditor();
            this.visEditor = new System.Windows.Forms.VisEditor();
            this.clrControl = new System.Windows.Forms.CLRControl();
            this.soundPackControl1 = new System.Windows.Forms.SoundPackControl();
            this.msBinEditor1 = new System.Windows.Forms.MSBinEditor();
            this.previewPanel1 = new System.Windows.Forms.GoodPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.articleAttributeGrid = new System.Windows.Forms.ArticleAttributeGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resourceTree);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(617, 411);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 1;
            // 
            // resourceTree
            // 
            this.resourceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceTree.HideSelection = false;
            this.resourceTree.ImageIndex = 0;
            this.resourceTree.Indent = 20;
            this.resourceTree.Location = new System.Drawing.Point(0, 24);
            this.resourceTree.Name = "resourceTree";
            this.resourceTree.SelectedImageIndex = 0;
            this.resourceTree.ShowIcons = true;
            this.resourceTree.Size = new System.Drawing.Size(229, 387);
            this.resourceTree.TabIndex = 0;
            this.resourceTree.SelectionChanged += new System.EventHandler(this.resourceTree_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(229, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRCArchiveToolStripMenuItem,
            this.brresPackToolStripMenuItem,
            this.bRStmAudioToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // aRCArchiveToolStripMenuItem
            // 
            this.aRCArchiveToolStripMenuItem.Name = "aRCArchiveToolStripMenuItem";
            this.aRCArchiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aRCArchiveToolStripMenuItem.Text = "ARC File Archive";
            this.aRCArchiveToolStripMenuItem.Click += new System.EventHandler(this.aRCArchiveToolStripMenuItem_Click);
            // 
            // brresPackToolStripMenuItem
            // 
            this.brresPackToolStripMenuItem.Name = "brresPackToolStripMenuItem";
            this.brresPackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brresPackToolStripMenuItem.Text = "Brres Resource Pack";
            this.brresPackToolStripMenuItem.Click += new System.EventHandler(this.brresPackToolStripMenuItem_Click);
            // 
            // bRStmAudioToolStripMenuItem
            // 
            this.bRStmAudioToolStripMenuItem.Name = "bRStmAudioToolStripMenuItem";
            this.bRStmAudioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bRStmAudioToolStripMenuItem.Text = "Brstm Audio Stream";
            this.bRStmAudioToolStripMenuItem.Click += new System.EventHandler(this.bRStmAudioToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.propertyGrid1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.animEditControl);
            this.splitContainer2.Panel2.Controls.Add(this.offsetEditor1);
            this.splitContainer2.Panel2.Controls.Add(this.shpAnimEditControl);
            this.splitContainer2.Panel2.Controls.Add(this.texAnimEditControl);
            this.splitContainer2.Panel2.Controls.Add(this.eventDescription1);
            this.splitContainer2.Panel2.Controls.Add(this.attributeControl);
            this.splitContainer2.Panel2.Controls.Add(this.articleAttributeGrid);
            this.splitContainer2.Panel2.Controls.Add(this.audioPlaybackPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.movesetEditor1);
            this.splitContainer2.Panel2.Controls.Add(this.visEditor);
            this.splitContainer2.Panel2.Controls.Add(this.clrControl);
            this.splitContainer2.Panel2.Controls.Add(this.soundPackControl1);
            this.splitContainer2.Panel2.Controls.Add(this.msBinEditor1);
            this.splitContainer2.Panel2.Controls.Add(this.previewPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(384, 411);
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(384, 238);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid1_SelectedGridItemChanged);
            // 
            // animEditControl
            // 
            this.animEditControl.Location = new System.Drawing.Point(0, 0);
            this.animEditControl.Name = "animEditControl";
            this.animEditControl.Size = new System.Drawing.Size(384, 169);
            this.animEditControl.TabIndex = 1;
            this.animEditControl.Visible = false;
            // 
            // offsetEditor1
            // 
            this.offsetEditor1.Location = new System.Drawing.Point(0, 0);
            this.offsetEditor1.Name = "offsetEditor1";
            this.offsetEditor1.Size = new System.Drawing.Size(296, 105);
            this.offsetEditor1.TabIndex = 8;
            this.offsetEditor1.Visible = false;
            // 
            // shpAnimEditControl
            // 
            this.shpAnimEditControl.Location = new System.Drawing.Point(0, 0);
            this.shpAnimEditControl.Name = "shpAnimEditControl";
            this.shpAnimEditControl.Size = new System.Drawing.Size(384, 169);
            this.shpAnimEditControl.TabIndex = 7;
            this.shpAnimEditControl.Visible = false;
            // 
            // texAnimEditControl
            // 
            this.texAnimEditControl.Location = new System.Drawing.Point(0, 0);
            this.texAnimEditControl.Name = "texAnimEditControl";
            this.texAnimEditControl.Size = new System.Drawing.Size(300, 212);
            this.texAnimEditControl.TabIndex = 7;
            this.texAnimEditControl.Visible = false;
            // 
            // eventDescription1
            // 
            this.eventDescription1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventDescription1.Location = new System.Drawing.Point(0, 0);
            this.eventDescription1.Name = "eventDescription1";
            this.eventDescription1.Size = new System.Drawing.Size(384, 169);
            this.eventDescription1.TabIndex = 1;
            this.eventDescription1.Visible = false;
            // 
            // attributeControl
            // 
            this.attributeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeControl.Location = new System.Drawing.Point(0, 0);
            this.attributeControl.Name = "attributeControl";
            this.attributeControl.Size = new System.Drawing.Size(384, 169);
            this.attributeControl.TabIndex = 0;
            this.attributeControl.Visible = false;
            // 
            // audioPlaybackPanel1
            // 
            this.audioPlaybackPanel1.Location = new System.Drawing.Point(149, 92);
            this.audioPlaybackPanel1.Name = "audioPlaybackPanel1";
            this.audioPlaybackPanel1.Size = new System.Drawing.Size(70, 111);
            this.audioPlaybackPanel1.TabIndex = 4;
            this.audioPlaybackPanel1.Visible = false;
            // 
            // movesetEditor1
            // 
            this.movesetEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movesetEditor1.Location = new System.Drawing.Point(0, 0);
            this.movesetEditor1.Name = "movesetEditor1";
            this.movesetEditor1.Size = new System.Drawing.Size(384, 169);
            this.movesetEditor1.TabIndex = 0;
            this.movesetEditor1.Visible = false;
            // 
            // visEditor
            // 
            this.visEditor.Location = new System.Drawing.Point(0, 0);
            this.visEditor.Name = "visEditor";
            this.visEditor.Size = new System.Drawing.Size(78, 87);
            this.visEditor.TabIndex = 6;
            this.visEditor.Visible = false;
            // 
            // clrControl
            // 
            this.clrControl.Location = new System.Drawing.Point(0, 0);
            this.clrControl.Name = "clrControl";
            this.clrControl.Size = new System.Drawing.Size(98, 47);
            this.clrControl.TabIndex = 5;
            this.clrControl.Visible = false;
            // 
            // soundPackControl1
            // 
            this.soundPackControl1.Location = new System.Drawing.Point(13, 101);
            this.soundPackControl1.Name = "soundPackControl1";
            this.soundPackControl1.Size = new System.Drawing.Size(130, 65);
            this.soundPackControl1.TabIndex = 3;
            this.soundPackControl1.TargetNode = null;
            this.soundPackControl1.Visible = false;
            // 
            // msBinEditor1
            // 
            this.msBinEditor1.Location = new System.Drawing.Point(104, 4);
            this.msBinEditor1.Name = "msBinEditor1";
            this.msBinEditor1.Size = new System.Drawing.Size(146, 82);
            this.msBinEditor1.TabIndex = 2;
            this.msBinEditor1.Visible = false;
            // 
            // previewPanel1
            // 
            this.previewPanel1.Location = new System.Drawing.Point(0, 0);
            this.previewPanel1.Name = "previewPanel1";
            this.previewPanel1.Picture = null;
            this.previewPanel1.Size = new System.Drawing.Size(98, 86);
            this.previewPanel1.TabIndex = 0;
            // 
            // articleAttributeGrid
            // 
            this.articleAttributeGrid.Location = new System.Drawing.Point(0, 0);
            this.articleAttributeGrid.Name = "articleAttributeGrid";
            this.articleAttributeGrid.Size = new System.Drawing.Size(479, 305);
            this.articleAttributeGrid.TabIndex = 9;
            this.articleAttributeGrid.Visible = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 411);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ResourceTree resourceTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private GoodPictureBox previewPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        public System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem aRCArchiveToolStripMenuItem;
        private ToolStripMenuItem brresPackToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private AnimEditControl animEditControl;
        private MSBinEditor msBinEditor1;
        private ToolStripMenuItem bRStmAudioToolStripMenuItem;
        private SoundPackControl soundPackControl1;
        private AudioPlaybackPanel audioPlaybackPanel1;
        private CLRControl clrControl;
        private VisEditor visEditor;
        private Timer timer1;
        private ScriptEditor movesetEditor1;
        private EventDescription eventDescription1;
        private TexAnimEditControl texAnimEditControl;
        private ShpAnimEditControl shpAnimEditControl;
        private AttributeGrid attributeControl;
        private OffsetEditor offsetEditor1;
        private ArticleAttributeGrid articleAttributeGrid;
    }
}

