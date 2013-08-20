namespace System.Windows.Forms
{
    unsafe partial class RELSectionMemoryEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RELSectionMemoryEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBSSSection = new System.Windows.Forms.CheckBox();
            this.chkCodeSection = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstLinked = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewCmd = new System.Windows.Forms.Button();
            this.btnDelCmd = new System.Windows.Forms.Button();
            this.btnOpenTarget = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportInitializedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteInsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOverwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlHexEditor = new System.Windows.Forms.Panel();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bitToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.OffsetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ppcDisassembler1 = new System.Windows.Forms.PPCDisassembler();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlHexEditor.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBSSSection);
            this.groupBox1.Controls.Add(this.chkCodeSection);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // chkBSSSection
            // 
            this.chkBSSSection.AutoSize = true;
            this.chkBSSSection.Location = new System.Drawing.Point(7, 36);
            this.chkBSSSection.Name = "chkBSSSection";
            this.chkBSSSection.Size = new System.Drawing.Size(97, 17);
            this.chkBSSSection.TabIndex = 14;
            this.chkBSSSection.Text = "Is BSS Section";
            this.chkBSSSection.UseVisualStyleBackColor = true;
            this.chkBSSSection.CheckedChanged += new System.EventHandler(this.chkBSSSection_CheckedChanged);
            // 
            // chkCodeSection
            // 
            this.chkCodeSection.AutoSize = true;
            this.chkCodeSection.Location = new System.Drawing.Point(7, 18);
            this.chkCodeSection.Name = "chkCodeSection";
            this.chkCodeSection.Size = new System.Drawing.Size(101, 17);
            this.chkCodeSection.TabIndex = 13;
            this.chkCodeSection.Text = "Is Code Section";
            this.chkCodeSection.UseVisualStyleBackColor = true;
            this.chkCodeSection.CheckedChanged += new System.EventHandler(this.chkCodeSection_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 341);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relocation Info";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstLinked);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 322);
            this.panel2.TabIndex = 11;
            // 
            // lstLinked
            // 
            this.lstLinked.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLinked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLinked.FormattingEnabled = true;
            this.lstLinked.IntegralHeight = false;
            this.lstLinked.Location = new System.Drawing.Point(0, 18);
            this.lstLinked.Name = "lstLinked";
            this.lstLinked.Size = new System.Drawing.Size(253, 55);
            this.lstLinked.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Linked Commands";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 73);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(253, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(253, 246);
            this.panel5.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNewCmd);
            this.panel1.Controls.Add(this.btnDelCmd);
            this.panel1.Controls.Add(this.btnOpenTarget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 24);
            this.panel1.TabIndex = 10;
            // 
            // btnNewCmd
            // 
            this.btnNewCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnNewCmd.Location = new System.Drawing.Point(0, 0);
            this.btnNewCmd.Name = "btnNewCmd";
            this.btnNewCmd.Size = new System.Drawing.Size(85, 24);
            this.btnNewCmd.TabIndex = 7;
            this.btnNewCmd.Text = "New";
            this.btnNewCmd.UseVisualStyleBackColor = true;
            this.btnNewCmd.Click += new System.EventHandler(this.btnNewCmd_Click);
            // 
            // btnDelCmd
            // 
            this.btnDelCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnDelCmd.Location = new System.Drawing.Point(84, 0);
            this.btnDelCmd.Name = "btnDelCmd";
            this.btnDelCmd.Size = new System.Drawing.Size(85, 24);
            this.btnDelCmd.TabIndex = 3;
            this.btnDelCmd.Text = "Delete";
            this.btnDelCmd.UseVisualStyleBackColor = true;
            this.btnDelCmd.Click += new System.EventHandler(this.btnDelCmd_Click);
            // 
            // btnOpenTarget
            // 
            this.btnOpenTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnOpenTarget.Location = new System.Drawing.Point(168, 0);
            this.btnOpenTarget.Name = "btnOpenTarget";
            this.btnOpenTarget.Size = new System.Drawing.Size(85, 24);
            this.btnOpenTarget.TabIndex = 8;
            this.btnOpenTarget.Text = "Open Target";
            this.btnOpenTarget.UseVisualStyleBackColor = true;
            this.btnOpenTarget.Click += new System.EventHandler(this.btnOpenTarget_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.propertyGrid1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 18);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(253, 228);
            this.panel6.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(253, 228);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Command Info";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gotoToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.exportInitializedToolStripMenuItem,
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportInitializedToolStripMenuItem
            // 
            this.exportInitializedToolStripMenuItem.Name = "exportInitializedToolStripMenuItem";
            this.exportInitializedToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exportInitializedToolStripMenuItem.Text = "Export Initialized";
            this.exportInitializedToolStripMenuItem.Click += new System.EventHandler(this.exportInitializedToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // gotoToolStripMenuItem
            // 
            this.gotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteInsertToolStripMenuItem,
            this.pasteOverwriteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
            this.gotoToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.gotoToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteInsertToolStripMenuItem
            // 
            this.pasteInsertToolStripMenuItem.Name = "pasteInsertToolStripMenuItem";
            this.pasteInsertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteInsertToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.pasteInsertToolStripMenuItem.Text = "Paste Insert";
            this.pasteInsertToolStripMenuItem.Click += new System.EventHandler(this.pasteInsertToolStripMenuItem_Click);
            // 
            // pasteOverwriteToolStripMenuItem
            // 
            this.pasteOverwriteToolStripMenuItem.Name = "pasteOverwriteToolStripMenuItem";
            this.pasteOverwriteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.pasteOverwriteToolStripMenuItem.Text = "Paste Overwrite";
            this.pasteOverwriteToolStripMenuItem.Click += new System.EventHandler(this.pasteOverwriteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoToolStripMenuItem2,
            this.findToolStripMenuItem1,
            this.findNextToolStripMenuItem,
            this.findPreviousToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // gotoToolStripMenuItem2
            // 
            this.gotoToolStripMenuItem2.Name = "gotoToolStripMenuItem2";
            this.gotoToolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
            this.gotoToolStripMenuItem2.Text = "Goto...";
            this.gotoToolStripMenuItem2.Click += new System.EventHandler(this.gotoToolStripMenuItem2_Click);
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.findToolStripMenuItem1.Text = "Find";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Enabled = false;
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.findNextToolStripMenuItem.Text = "Find Next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // findPreviousToolStripMenuItem
            // 
            this.findPreviousToolStripMenuItem.Enabled = false;
            this.findPreviousToolStripMenuItem.Name = "findPreviousToolStripMenuItem";
            this.findPreviousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F3)));
            this.findPreviousToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.findPreviousToolStripMenuItem.Text = "Find Previous";
            this.findPreviousToolStripMenuItem.Click += new System.EventHandler(this.findPreviousToolStripMenuItem_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlHexEditor);
            this.pnlLeft.Controls.Add(this.ppcDisassembler1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(661, 524);
            this.pnlLeft.TabIndex = 5;
            // 
            // pnlHexEditor
            // 
            this.pnlHexEditor.Controls.Add(this.hexBox1);
            this.pnlHexEditor.Controls.Add(this.menuStrip1);
            this.pnlHexEditor.Controls.Add(this.statusStrip);
            this.pnlHexEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHexEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlHexEditor.Name = "pnlHexEditor";
            this.pnlHexEditor.Size = new System.Drawing.Size(661, 524);
            this.pnlHexEditor.TabIndex = 11;
            // 
            // hexBox1
            // 
            // 
            // 
            // 
            this.hexBox1.BuiltInContextMenu.CopyMenuItemText = "Copy";
            this.hexBox1.BuiltInContextMenu.CutMenuItemText = "Cut";
            this.hexBox1.BuiltInContextMenu.PasteMenuItemText = "Paste";
            this.hexBox1.BuiltInContextMenu.SelectAllMenuItemText = "Select All";
            this.hexBox1.ColumnDividerColor = System.Drawing.Color.Gray;
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.GroupSeparatorVisible = true;
            this.hexBox1.InfoForeColor = System.Drawing.Color.Blue;
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(0, 24);
            this.hexBox1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.SectionNode = null;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(661, 478);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 3;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            this.hexBox1.SelectionStartChanged += new System.EventHandler(this.hexBox1_SelectionStartChanged);
            this.hexBox1.SelectionLengthChanged += new System.EventHandler(this.hexBox1_SelectionLengthChanged);
            this.hexBox1.CurrentLineChanged += new System.EventHandler(this.hexBox1_CurrentLineChanged);
            this.hexBox1.CurrentPositionInLineChanged += new System.EventHandler(this.hexBox1_CurrentPositionInLineChanged);
            this.hexBox1.Copied += new System.EventHandler(this.hexBox1_Copied);
            this.hexBox1.CopiedHex += new System.EventHandler(this.hexBox1_CopiedHex);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.fileSizeToolStripStatusLabel,
            this.bitToolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.OffsetToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 502);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(661, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 10;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.toolStripStatusLabel.Size = new System.Drawing.Size(7, 17);
            // 
            // fileSizeToolStripStatusLabel
            // 
            this.fileSizeToolStripStatusLabel.Name = "fileSizeToolStripStatusLabel";
            this.fileSizeToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileSizeToolStripStatusLabel.Size = new System.Drawing.Size(8, 17);
            // 
            // bitToolStripStatusLabel
            // 
            this.bitToolStripStatusLabel.Name = "bitToolStripStatusLabel";
            this.bitToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // OffsetToolStripStatusLabel
            // 
            this.OffsetToolStripStatusLabel.Name = "OffsetToolStripStatusLabel";
            this.OffsetToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this.OffsetToolStripStatusLabel.Text = " ";
            // 
            // ppcDisassembler1
            // 
            this.ppcDisassembler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppcDisassembler1.Location = new System.Drawing.Point(0, 0);
            this.ppcDisassembler1.Name = "ppcDisassembler1";
            this.ppcDisassembler1.Size = new System.Drawing.Size(661, 524);
            this.ppcDisassembler1.TabIndex = 11;
            this.ppcDisassembler1.TargetNode = null;
            this.ppcDisassembler1.Visible = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.groupBox2);
            this.pnlRight.Controls.Add(this.groupBox1);
            this.pnlRight.Controls.Add(this.panel3);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(664, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(261, 524);
            this.pnlRight.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 122);
            this.panel3.TabIndex = 16;
            this.panel3.Visible = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(661, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 524);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // RELSectionMemoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 524);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RELSectionMemoryEditor";
            this.Text = "Section Editor";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlHexEditor.ResumeLayout(false);
            this.pnlHexEditor.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNewCmd;
        private System.Windows.Forms.Button btnDelCmd;
        private Panel panel2;
        private Splitter splitter1;
        private Panel panel1;
        private Be.Windows.Forms.HexBox hexBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gotoToolStripMenuItem;
        private Panel pnlLeft;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem gotoToolStripMenuItem2;
        private ToolStripMenuItem findToolStripMenuItem1;
        private ToolStripMenuItem findNextToolStripMenuItem;
        private ToolStripMenuItem findPreviousToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteInsertToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem pasteOverwriteToolStripMenuItem;
        private CheckBox chkBSSSection;
        private CheckBox chkCodeSection;
        private Panel pnlRight;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private ToolStripStatusLabel bitToolStripStatusLabel;
        private Splitter splitter2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ListBox lstLinked;
        private Label label1;
        private Label label2;
        private Panel panel5;
        private Panel panel6;
        private Panel pnlHexEditor;
        private PPCDisassembler ppcDisassembler1;
        private PropertyGrid propertyGrid1;
        private ToolStripMenuItem exportInitializedToolStripMenuItem;
        private Panel panel3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel OffsetToolStripStatusLabel;
        private Button btnOpenTarget;
    }
}