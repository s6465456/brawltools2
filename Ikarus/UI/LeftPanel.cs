using System;
using BrawlLib.SSBB.ResourceNodes;
using System.Drawing;
using BrawlLib.Modeling;
using System.ComponentModel;
using BrawlLib.OpenGL;
using BrawlLib;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Ikarus.UI
{
    public class LeftPanel : UserControl
    {
        #region Designer

        public CheckedListBox lstObjects;
        private CheckBox chkAllObj;
        private Button btnObjects;
        private ProxySplitter spltAnimObj;
        private Panel pnlLists;
        private Button btnLists;
        private Panel pnlTextures;
        private CheckedListBox lstTextures;
        private CheckBox chkAllTextures;
        private Button btnTextures;
        private ProxySplitter spltObjTex;
        private ContextMenuStrip ctxTextures;
        private ToolStripMenuItem sourceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem replaceTextureToolStripMenuItem;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem renameTextureTextureToolStripMenuItem;
        private ToolStripMenuItem exportTextureToolStripMenuItem;
        private IContainer components;
        public CheckBox chkSyncVis;
        private ContextMenuStrip ctxAnim;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem portToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private TransparentPanel overObjPnl;
        private TransparentPanel overTexPnl;
        private ToolStripMenuItem createNewToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ListBox ActionsList;
        private ListBox SubActionsList;
        private AttributeGrid attributeGridMain;
        private AttributeGrid attributeGridSSE;
        public CheckedListBox lstHurtboxes;
        private CheckBox chkAllHurtboxes;
        private Panel pnlHurtboxes;
        private Panel pnlTop;
        public ComboBox movesetEditor;
        private ComboBox fileType;
        private Panel listGroupPanel;
        private Panel pnlObjects;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.overObjPnl = new System.Windows.Forms.TransparentPanel();
            this.lstObjects = new System.Windows.Forms.CheckedListBox();
            this.chkAllObj = new System.Windows.Forms.CheckBox();
            this.chkSyncVis = new System.Windows.Forms.CheckBox();
            this.btnObjects = new System.Windows.Forms.Button();
            this.pnlLists = new System.Windows.Forms.Panel();
            this.listGroupPanel = new System.Windows.Forms.Panel();
            this.pnlHurtboxes = new System.Windows.Forms.Panel();
            this.lstHurtboxes = new System.Windows.Forms.CheckedListBox();
            this.chkAllHurtboxes = new System.Windows.Forms.CheckBox();
            this.SubActionsList = new System.Windows.Forms.ListBox();
            this.ActionsList = new System.Windows.Forms.ListBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.movesetEditor = new System.Windows.Forms.ComboBox();
            this.fileType = new System.Windows.Forms.ComboBox();
            this.btnLists = new System.Windows.Forms.Button();
            this.ctxTextures = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameTextureTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTextures = new System.Windows.Forms.Panel();
            this.overTexPnl = new System.Windows.Forms.TransparentPanel();
            this.lstTextures = new System.Windows.Forms.CheckedListBox();
            this.chkAllTextures = new System.Windows.Forms.CheckBox();
            this.btnTextures = new System.Windows.Forms.Button();
            this.spltObjTex = new System.Windows.Forms.ProxySplitter();
            this.spltAnimObj = new System.Windows.Forms.ProxySplitter();
            this.ctxAnim = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributeGridSSE = new System.Windows.Forms.AttributeGrid();
            this.attributeGridMain = new System.Windows.Forms.AttributeGrid();
            this.pnlObjects.SuspendLayout();
            this.pnlLists.SuspendLayout();
            this.listGroupPanel.SuspendLayout();
            this.pnlHurtboxes.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.ctxTextures.SuspendLayout();
            this.pnlTextures.SuspendLayout();
            this.ctxAnim.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlObjects
            // 
            this.pnlObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjects.Controls.Add(this.overObjPnl);
            this.pnlObjects.Controls.Add(this.lstObjects);
            this.pnlObjects.Controls.Add(this.chkAllObj);
            this.pnlObjects.Controls.Add(this.chkSyncVis);
            this.pnlObjects.Controls.Add(this.btnObjects);
            this.pnlObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjects.Location = new System.Drawing.Point(0, 182);
            this.pnlObjects.MinimumSize = new System.Drawing.Size(0, 21);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(202, 150);
            this.pnlObjects.TabIndex = 0;
            // 
            // overObjPnl
            // 
            this.overObjPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overObjPnl.Location = new System.Drawing.Point(0, 61);
            this.overObjPnl.Name = "overObjPnl";
            this.overObjPnl.Size = new System.Drawing.Size(200, 87);
            this.overObjPnl.TabIndex = 8;
            this.overObjPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.overObjPnl_Paint);
            // 
            // lstObjects
            // 
            this.lstObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstObjects.CausesValidation = false;
            this.lstObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstObjects.IntegralHeight = false;
            this.lstObjects.Location = new System.Drawing.Point(0, 61);
            this.lstObjects.Margin = new System.Windows.Forms.Padding(0);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(200, 87);
            this.lstObjects.TabIndex = 4;
            this.lstObjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstPolygons_ItemCheck);
            this.lstObjects.SelectedValueChanged += new System.EventHandler(this.lstPolygons_SelectedValueChanged);
            this.lstObjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPolygons_KeyDown);
            this.lstObjects.Leave += new System.EventHandler(this.lstObjects_Leave);
            // 
            // chkAllObj
            // 
            this.chkAllObj.Checked = true;
            this.chkAllObj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllObj.Location = new System.Drawing.Point(0, 41);
            this.chkAllObj.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllObj.Name = "chkAllObj";
            this.chkAllObj.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.chkAllObj.Size = new System.Drawing.Size(200, 20);
            this.chkAllObj.TabIndex = 5;
            this.chkAllObj.Text = "All";
            this.chkAllObj.UseVisualStyleBackColor = false;
            this.chkAllObj.CheckStateChanged += new System.EventHandler(this.chkAllPoly_CheckStateChanged);
            // 
            // chkSyncVis
            // 
            this.chkSyncVis.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSyncVis.Location = new System.Drawing.Point(0, 21);
            this.chkSyncVis.Margin = new System.Windows.Forms.Padding(0);
            this.chkSyncVis.Name = "chkSyncVis";
            this.chkSyncVis.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.chkSyncVis.Size = new System.Drawing.Size(200, 20);
            this.chkSyncVis.TabIndex = 7;
            this.chkSyncVis.Text = "Sync VIS0";
            this.chkSyncVis.UseVisualStyleBackColor = false;
            this.chkSyncVis.CheckedChanged += new System.EventHandler(this.chkSyncVis_CheckedChanged);
            // 
            // btnObjects
            // 
            this.btnObjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnObjects.Location = new System.Drawing.Point(0, 0);
            this.btnObjects.Name = "btnObjects";
            this.btnObjects.Size = new System.Drawing.Size(200, 21);
            this.btnObjects.TabIndex = 6;
            this.btnObjects.Text = "Objects";
            this.btnObjects.UseVisualStyleBackColor = true;
            this.btnObjects.Click += new System.EventHandler(this.btnObjects_Click);
            // 
            // pnlLists
            // 
            this.pnlLists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLists.Controls.Add(this.listGroupPanel);
            this.pnlLists.Controls.Add(this.btnLists);
            this.pnlLists.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLists.Location = new System.Drawing.Point(0, 0);
            this.pnlLists.MinimumSize = new System.Drawing.Size(0, 21);
            this.pnlLists.Name = "pnlLists";
            this.pnlLists.Size = new System.Drawing.Size(202, 178);
            this.pnlLists.TabIndex = 2;
            // 
            // listGroupPanel
            // 
            this.listGroupPanel.Controls.Add(this.pnlHurtboxes);
            this.listGroupPanel.Controls.Add(this.SubActionsList);
            this.listGroupPanel.Controls.Add(this.ActionsList);
            this.listGroupPanel.Controls.Add(this.attributeGridSSE);
            this.listGroupPanel.Controls.Add(this.attributeGridMain);
            this.listGroupPanel.Controls.Add(this.pnlTop);
            this.listGroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGroupPanel.Location = new System.Drawing.Point(0, 21);
            this.listGroupPanel.Name = "listGroupPanel";
            this.listGroupPanel.Size = new System.Drawing.Size(200, 155);
            this.listGroupPanel.TabIndex = 2;
            // 
            // pnlHurtboxes
            // 
            this.pnlHurtboxes.Controls.Add(this.lstHurtboxes);
            this.pnlHurtboxes.Controls.Add(this.chkAllHurtboxes);
            this.pnlHurtboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHurtboxes.Location = new System.Drawing.Point(0, 21);
            this.pnlHurtboxes.Name = "pnlHurtboxes";
            this.pnlHurtboxes.Size = new System.Drawing.Size(200, 134);
            this.pnlHurtboxes.TabIndex = 2;
            this.pnlHurtboxes.Visible = false;
            // 
            // lstHurtboxes
            // 
            this.lstHurtboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHurtboxes.IntegralHeight = false;
            this.lstHurtboxes.Location = new System.Drawing.Point(0, 17);
            this.lstHurtboxes.Name = "lstHurtboxes";
            this.lstHurtboxes.Size = new System.Drawing.Size(200, 117);
            this.lstHurtboxes.TabIndex = 1;
            this.lstHurtboxes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstHurtboxes_ItemCheck);
            this.lstHurtboxes.SelectedIndexChanged += new System.EventHandler(this.lstHurtboxes_SelectedIndexChanged);
            this.lstHurtboxes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstHurtboxes_KeyDown);
            // 
            // chkAllHurtboxes
            // 
            this.chkAllHurtboxes.AutoSize = true;
            this.chkAllHurtboxes.BackColor = System.Drawing.SystemColors.Control;
            this.chkAllHurtboxes.Checked = true;
            this.chkAllHurtboxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllHurtboxes.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllHurtboxes.Location = new System.Drawing.Point(0, 0);
            this.chkAllHurtboxes.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllHurtboxes.Name = "chkAllHurtboxes";
            this.chkAllHurtboxes.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.chkAllHurtboxes.Size = new System.Drawing.Size(200, 17);
            this.chkAllHurtboxes.TabIndex = 0;
            this.chkAllHurtboxes.Text = "All";
            this.chkAllHurtboxes.UseVisualStyleBackColor = false;
            this.chkAllHurtboxes.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SubActionsList
            // 
            this.SubActionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubActionsList.FormattingEnabled = true;
            this.SubActionsList.IntegralHeight = false;
            this.SubActionsList.Location = new System.Drawing.Point(0, 21);
            this.SubActionsList.Name = "SubActionsList";
            this.SubActionsList.Size = new System.Drawing.Size(200, 134);
            this.SubActionsList.TabIndex = 1;
            this.SubActionsList.Visible = false;
            this.SubActionsList.SelectedIndexChanged += new System.EventHandler(this.SubActionsList_SelectedIndexChanged_1);
            this.SubActionsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubActionsList_KeyDown);
            // 
            // ActionsList
            // 
            this.ActionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsList.FormattingEnabled = true;
            this.ActionsList.IntegralHeight = false;
            this.ActionsList.Location = new System.Drawing.Point(0, 21);
            this.ActionsList.Name = "ActionsList";
            this.ActionsList.Size = new System.Drawing.Size(200, 134);
            this.ActionsList.TabIndex = 0;
            this.ActionsList.Visible = false;
            this.ActionsList.SelectedIndexChanged += new System.EventHandler(this.ActionsList_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.movesetEditor);
            this.pnlTop.Controls.Add(this.fileType);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(200, 21);
            this.pnlTop.TabIndex = 27;
            // 
            // movesetEditor
            // 
            this.movesetEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movesetEditor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.movesetEditor.FormattingEnabled = true;
            this.movesetEditor.Items.AddRange(new object[] {
            "Actions",
            "SubActions",
            "Brawl Attributes",
            "SSE Attributes",
            "Hurtboxes"});
            this.movesetEditor.Location = new System.Drawing.Point(0, 0);
            this.movesetEditor.Name = "movesetEditor";
            this.movesetEditor.Size = new System.Drawing.Size(151, 21);
            this.movesetEditor.TabIndex = 27;
            this.movesetEditor.SelectedIndexChanged += new System.EventHandler(this.movesetEditor_SelectedIndexChanged);
            // 
            // fileType
            // 
            this.fileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileType.FormattingEnabled = true;
            this.fileType.Items.AddRange(new object[] {
            "CHR",
            "SRT",
            "SHP",
            "PAT",
            "VIS",
            "CLR"});
            this.fileType.Location = new System.Drawing.Point(152, 0);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(47, 21);
            this.fileType.TabIndex = 26;
            this.fileType.SelectedIndexChanged += new System.EventHandler(this.fileType_SelectedIndexChanged);
            // 
            // btnLists
            // 
            this.btnLists.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLists.Location = new System.Drawing.Point(0, 0);
            this.btnLists.Name = "btnLists";
            this.btnLists.Size = new System.Drawing.Size(200, 21);
            this.btnLists.TabIndex = 7;
            this.btnLists.Text = "Lists";
            this.btnLists.UseVisualStyleBackColor = true;
            this.btnLists.Click += new System.EventHandler(this.btnAnims_Click);
            // 
            // ctxTextures
            // 
            this.ctxTextures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.exportTextureToolStripMenuItem,
            this.replaceTextureToolStripMenuItem,
            this.renameTextureTextureToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.ctxTextures.Name = "ctxTextures";
            this.ctxTextures.Size = new System.Drawing.Size(125, 164);
            this.ctxTextures.Opening += new System.ComponentModel.CancelEventHandler(this.ctxTextures_Opening);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Enabled = false;
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.sourceToolStripMenuItem.Text = "Source";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Enabled = false;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.viewToolStripMenuItem.Text = "View...";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // exportTextureToolStripMenuItem
            // 
            this.exportTextureToolStripMenuItem.Name = "exportTextureToolStripMenuItem";
            this.exportTextureToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exportTextureToolStripMenuItem.Text = "Export...";
            this.exportTextureToolStripMenuItem.Click += new System.EventHandler(this.exportTextureToolStripMenuItem_Click);
            // 
            // replaceTextureToolStripMenuItem
            // 
            this.replaceTextureToolStripMenuItem.Name = "replaceTextureToolStripMenuItem";
            this.replaceTextureToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.replaceTextureToolStripMenuItem.Text = "Replace...";
            this.replaceTextureToolStripMenuItem.Click += new System.EventHandler(this.replaceTextureToolStripMenuItem_Click);
            // 
            // renameTextureTextureToolStripMenuItem
            // 
            this.renameTextureTextureToolStripMenuItem.Name = "renameTextureTextureToolStripMenuItem";
            this.renameTextureTextureToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.renameTextureTextureToolStripMenuItem.Text = "Rename";
            this.renameTextureTextureToolStripMenuItem.Click += new System.EventHandler(this.renameTextureToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.resetToolStripMenuItem.Text = "Reload";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // pnlTextures
            // 
            this.pnlTextures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTextures.Controls.Add(this.overTexPnl);
            this.pnlTextures.Controls.Add(this.lstTextures);
            this.pnlTextures.Controls.Add(this.chkAllTextures);
            this.pnlTextures.Controls.Add(this.btnTextures);
            this.pnlTextures.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTextures.Location = new System.Drawing.Point(0, 336);
            this.pnlTextures.MinimumSize = new System.Drawing.Size(0, 21);
            this.pnlTextures.Name = "pnlTextures";
            this.pnlTextures.Size = new System.Drawing.Size(202, 164);
            this.pnlTextures.TabIndex = 3;
            // 
            // overTexPnl
            // 
            this.overTexPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overTexPnl.Location = new System.Drawing.Point(0, 41);
            this.overTexPnl.Name = "overTexPnl";
            this.overTexPnl.Size = new System.Drawing.Size(200, 121);
            this.overTexPnl.TabIndex = 9;
            this.overTexPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.overTexPnl_Paint);
            // 
            // lstTextures
            // 
            this.lstTextures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTextures.CausesValidation = false;
            this.lstTextures.ContextMenuStrip = this.ctxTextures;
            this.lstTextures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTextures.IntegralHeight = false;
            this.lstTextures.Location = new System.Drawing.Point(0, 41);
            this.lstTextures.Margin = new System.Windows.Forms.Padding(0);
            this.lstTextures.Name = "lstTextures";
            this.lstTextures.Size = new System.Drawing.Size(200, 121);
            this.lstTextures.TabIndex = 7;
            this.lstTextures.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstTextures_ItemCheck);
            this.lstTextures.SelectedValueChanged += new System.EventHandler(this.lstTextures_SelectedValueChanged);
            this.lstTextures.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTextures_KeyDown);
            this.lstTextures.Leave += new System.EventHandler(this.lstTextures_Leave);
            this.lstTextures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTextures_MouseDown);
            // 
            // chkAllTextures
            // 
            this.chkAllTextures.Checked = true;
            this.chkAllTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllTextures.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAllTextures.Location = new System.Drawing.Point(0, 21);
            this.chkAllTextures.Margin = new System.Windows.Forms.Padding(0);
            this.chkAllTextures.Name = "chkAllTextures";
            this.chkAllTextures.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.chkAllTextures.Size = new System.Drawing.Size(200, 20);
            this.chkAllTextures.TabIndex = 8;
            this.chkAllTextures.Text = "All";
            this.chkAllTextures.UseVisualStyleBackColor = false;
            this.chkAllTextures.CheckStateChanged += new System.EventHandler(this.chkAllTextures_CheckStateChanged);
            // 
            // btnTextures
            // 
            this.btnTextures.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTextures.Location = new System.Drawing.Point(0, 0);
            this.btnTextures.Name = "btnTextures";
            this.btnTextures.Size = new System.Drawing.Size(200, 21);
            this.btnTextures.TabIndex = 9;
            this.btnTextures.Text = "Textures";
            this.btnTextures.UseVisualStyleBackColor = true;
            this.btnTextures.Click += new System.EventHandler(this.btnTextures_Click);
            // 
            // spltObjTex
            // 
            this.spltObjTex.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spltObjTex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spltObjTex.Location = new System.Drawing.Point(0, 332);
            this.spltObjTex.Name = "spltObjTex";
            this.spltObjTex.Size = new System.Drawing.Size(202, 4);
            this.spltObjTex.TabIndex = 4;
            this.spltObjTex.Dragged += new System.Windows.Forms.SplitterEventHandler(this.spltObjTex_Dragged);
            // 
            // spltAnimObj
            // 
            this.spltAnimObj.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spltAnimObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltAnimObj.Location = new System.Drawing.Point(0, 178);
            this.spltAnimObj.Name = "spltAnimObj";
            this.spltAnimObj.Size = new System.Drawing.Size(202, 4);
            this.spltAnimObj.TabIndex = 1;
            this.spltAnimObj.Dragged += new System.Windows.Forms.SplitterEventHandler(this.spltAnimObj_Dragged);
            // 
            // ctxAnim
            // 
            this.ctxAnim.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.portToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.createNewToolStripMenuItem});
            this.ctxAnim.Name = "ctxAnim";
            this.ctxAnim.Size = new System.Drawing.Size(195, 164);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem2.Text = "Source";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem3.Text = "Export...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem4.Text = "Replace...";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.portToolStripMenuItem.Text = "Port...";
            this.portToolStripMenuItem.Click += new System.EventHandler(this.portToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.createNewToolStripMenuItem.Text = "Create New Animation";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // attributeGridSSE
            // 
            this.attributeGridSSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeGridSSE.Location = new System.Drawing.Point(0, 21);
            this.attributeGridSSE.Name = "attributeGridSSE";
            this.attributeGridSSE.Size = new System.Drawing.Size(200, 134);
            this.attributeGridSSE.TabIndex = 0;
            this.attributeGridSSE.Visible = false;
            // 
            // attributeGridMain
            // 
            this.attributeGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeGridMain.Location = new System.Drawing.Point(0, 21);
            this.attributeGridMain.Margin = new System.Windows.Forms.Padding(0);
            this.attributeGridMain.Name = "attributeGridMain";
            this.attributeGridMain.Size = new System.Drawing.Size(200, 134);
            this.attributeGridMain.TabIndex = 0;
            this.attributeGridMain.Visible = false;
            // 
            // LeftPanel
            // 
            this.Controls.Add(this.pnlObjects);
            this.Controls.Add(this.spltObjTex);
            this.Controls.Add(this.spltAnimObj);
            this.Controls.Add(this.pnlLists);
            this.Controls.Add(this.pnlTextures);
            this.Name = "LeftPanel";
            this.Size = new System.Drawing.Size(202, 500);
            this.pnlObjects.ResumeLayout(false);
            this.pnlLists.ResumeLayout(false);
            this.listGroupPanel.ResumeLayout(false);
            this.pnlHurtboxes.ResumeLayout(false);
            this.pnlHurtboxes.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ctxTextures.ResumeLayout(false);
            this.pnlTextures.ResumeLayout(false);
            this.ctxAnim.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public bool _closing = false;

        public MainControl _mainWindow;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MainControl MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        public bool _syncVis0 = false;
        public bool _syncPat0 = false;

        private bool _updating = false;
        private MDL0ObjectNode _targetObject;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0ObjectNode TargetObject
        {
            get { return _targetObject; }
            set { _targetObject = value; }
        }

        private MDL0ObjectNode _selectedPolygon;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0ObjectNode SelectedPolygon { get { return _selectedPolygon; } set { lstObjects.SelectedItem = value; } }

        private MDL0TextureNode _selectedTexture;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0TextureNode SelectedTexture { get { return _selectedTexture; } set { lstTextures.SelectedItem = value; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode TargetBone { get { return _mainWindow.SelectedBone; } set { _mainWindow.SelectedBone = value; } }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0MaterialRefNode TargetTexRef
        {
            get { return _mainWindow.TargetTexRef; }
            set
            {
                _mainWindow.TargetTexRef = value; 
                if (_mainWindow.SelectedSRT0 != null && TargetTexRef != null)
                    _mainWindow.KeyframePanel.TargetSequence = _mainWindow.SRT0Editor.TexEntry;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentFrame
        {
            get { return _mainWindow.CurrentFrame; }
            set { _mainWindow.CurrentFrame = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0Node TargetModel
        {
            get { return _mainWindow.TargetModel; }
            set { _mainWindow.TargetModel = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CHR0Node SelectedCHR0
        {
            get  { return _mainWindow.SelectedCHR0; }
            set  { _mainWindow.SelectedCHR0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SRT0Node SelectedSRT0
        {
            get { return _mainWindow.SelectedSRT0; }
            set { _mainWindow.SelectedSRT0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SHP0Node SelectedSHP0
        {
            get { return _mainWindow.SelectedSHP0; }
            set { _mainWindow.SelectedSHP0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PAT0Node SelectedPAT0
        {
            get { return _mainWindow.SelectedPAT0; }
            set { _mainWindow.SelectedPAT0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0Node SelectedVIS0
        {
            get { return _mainWindow.SelectedVIS0; }
            set { _mainWindow.SelectedVIS0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AnimType TargetAnimType
        {
            get 
            {
                return (AnimType)(fileType.SelectedIndex == 5 ? 6 : fileType.SelectedIndex);
            }
            set 
            {
                if (value == AnimType.None)
                    return;

                fileType.SelectedIndex = ((int)value).Clamp(0, 5); 
            }
        }

        //Bone Name - Attached Polygon Indices
        public Dictionary<string, List<int>> VIS0Indices = new Dictionary<string, List<int>>();

        public LeftPanel()
        {
            InitializeComponent();
            //listAnims.Groups.Add(_AnimGroup);
            movesetEditor.SelectedIndex = 1;
        }

        public List<BRESEntryNode> _animations = new List<BRESEntryNode>();

        public bool LoadAnims(ResourceNode node, AnimType type)
        {
            bool found = false;
            switch (node.ResourceType)
            {
                case ResourceType.ARC:
                case ResourceType.MRG:
                case ResourceType.U8:
                case ResourceType.U8Folder:
                case ResourceType.BRES:
                case ResourceType.BRESGroup:
                default:
                    foreach (ResourceNode n in node.Children)
                        if (found) 
                            LoadAnims(n, type);
                        else 
                            found = LoadAnims(n, type);
                    break;

                case ResourceType.MDef:
                    return false;

                case ResourceType.CHR0: found = true; if (type == AnimType.CHR) goto Add; break;
                case ResourceType.SRT0: found = true; if (type == AnimType.SRT) goto Add; break;
                case ResourceType.SHP0: found = true; if (type == AnimType.SHP) goto Add; break;
                case ResourceType.PAT0: found = true; if (type == AnimType.PAT) goto Add; break;
                case ResourceType.VIS0: found = true; if (type == AnimType.VIS) goto Add; break;
                case ResourceType.SCN0: found = true; if (type == AnimType.SCN) goto Add; break;
                case ResourceType.CLR0: found = true; if (type == AnimType.CLR) goto Add; break;
            }
            return found;
            Add: _animations.Add(node as BRESEntryNode);
            return found;
        }

        public CheckState BRRESRelative = CheckState.Unchecked;
        public bool UpdateAnimations() { return UpdateAnimations(TargetAnimType); }
        public bool UpdateAnimations(AnimType type)
        {
            _mainWindow.Updating = true;

            string Name = SubActionsList.SelectedItems != null && SubActionsList.SelectedItems.Count > 0 ? SubActionsList.SelectedItems[0].ToString() : null;
            int frame = CurrentFrame;

            _animations.Clear();

            if (TargetModel != null)
                if (BRRESRelative != CheckState.Unchecked)
                    LoadAnims(TargetModel.BRESNode, type);
                else
                    LoadAnims(TargetModel.RootNode, type);

            int count = _animations.Count;

            if (_mainWindow.ExternalAnimationsNode != null)
                if (BRRESRelative != CheckState.Checked)
                    LoadAnims(_mainWindow.ExternalAnimationsNode.RootNode, type);

            //Reselect the animation
            for (int i = 0; i < _animations.Count; i++)
                if (_animations[i].Name == Name)
                {
                    for (int x = 0; x < SubActionsList.Items.Count; x++)
                        if (SubActionsList.Items[x].ToString() == Name)
                        {
                            SubActionsList.SetSelected(x, true);
                            break;
                        }
                    break;
                }

            _mainWindow.Updating = false;
            CurrentFrame = frame;

            if ((_mainWindow.GetSelectedBRRESFile((AnimType)TargetAnimType) == null) && (SubActionsList.SelectedItems.Count == 0))
            {
                _mainWindow.SelectedCHR0 = null;
                _mainWindow.SelectedSRT0 = null;
                _mainWindow.SelectedSHP0 = null;
                _mainWindow.SelectedPAT0 = null;
                _mainWindow.SelectedVIS0 = null;
                _mainWindow.SelectedCLR0 = null;
                _mainWindow.UpdatePropDisplay();
                _mainWindow.UpdateModel();
                _mainWindow.ModelPanel.Invalidate();
            }

            return count != SubActionsList.Items.Count;
        }

        public SRT0Node _srt0Selection = null;
        public void UpdateSRT0Selection(SRT0Node selection)
        {
            _srt0Selection = selection;
            if (_srt0Selection == null && _pat0Selection == null)
                overObjPnl.Visible = overTexPnl.Visible = false;
            else
            {
                overObjPnl.Visible = overTexPnl.Visible = true;
                overObjPnl.Invalidate();
                overTexPnl.Invalidate();
            }
        }
        public PAT0Node _pat0Selection = null;
        public void UpdatePAT0Selection(PAT0Node selection)
        {
            _pat0Selection = selection;
            if (_pat0Selection == null && _srt0Selection == null)
                overObjPnl.Visible = overTexPnl.Visible = false;
            else
            {
                overObjPnl.Visible = overTexPnl.Visible = true;
                overObjPnl.Invalidate();
                overTexPnl.Invalidate();
            }
        }

        public void UpdateTextures()
        {
            _mainWindow.Updating = true;

            string Name = lstTextures.SelectedItems != null && lstTextures.SelectedItems.Count > 0 ? lstTextures.SelectedItems[0].ToString() : null;

            lstTextures.BeginUpdate();
            lstTextures.Items.Clear();

            chkAllTextures.CheckState = CheckState.Checked;

            ResourceNode n;
            if (_selectedPolygon != null && _syncObjTex)
                foreach (MDL0MaterialRefNode tref in _selectedPolygon.UsableMaterialNode.Children)
                    lstTextures.Items.Add(tref.TextureNode, tref.TextureNode.Enabled);
            else if (TargetModel != null && (n = TargetModel.FindChild("Textures", false)) != null)
                foreach (MDL0TextureNode tref in n.Children)
                    lstTextures.Items.Add(tref, tref.Enabled);
            
            lstTextures.EndUpdate();

            //Reselect the animation
            //lstTextures.Focus();
            for (int i = 0; i < lstTextures.Items.Count; i++)
                if (lstTextures.Items[i].ToString() == Name)
                {
                    lstTextures.SetSelected(i, true);
                    break;
                }

            _mainWindow.Updating = false;
        }

        public void Reset()
        {
            lstObjects.BeginUpdate();
            lstObjects.Items.Clear();
            lstTextures.BeginUpdate();
            lstTextures.Items.Clear();

            _selectedPolygon = null;
            _targetObject = null;

            chkAllObj.CheckState = CheckState.Checked;
            chkAllTextures.CheckState = CheckState.Checked;

            if (TargetModel != null)
            {
                ResourceNode n;

                UpdateAnimations(TargetAnimType);

                if ((n = TargetModel.FindChild("Objects", false)) != null)
                    foreach (MDL0ObjectNode poly in n.Children)
                        lstObjects.Items.Add(poly, poly._render);

                if ((n = TargetModel.FindChild("Textures", false)) != null)
                    foreach (MDL0TextureNode tref in n.Children)
                        lstTextures.Items.Add(tref, tref.Enabled);
            }

            lstTextures.EndUpdate();
            lstObjects.EndUpdate();

            //VIS0Indices.Clear(); int i = 0;
            //foreach (MDL0PolygonNode p in lstObjects.Items)
            //{
            //    if (p._bone != null && p._bone.BoneIndex != 0)
            //        if (VIS0Indices.ContainsKey(p._bone.Name))
            //            if (!VIS0Indices[p._bone.Name].Contains(i))
            //                VIS0Indices[p._bone.Name].Add(i); else { }
            //        else VIS0Indices.Add(p._bone.Name, new List<int> { i });
            //    i++;
            //}
        }

        //private void WrapBone(MDL0BoneNode bone)
        //{
        //    lstBones.Items.Add(bone, bone._render);
        //    foreach (MDL0BoneNode b in bone.Children)
        //        WrapBone(b);
        //}

        private void spltAnimObj_Dragged(object sender, SplitterEventArgs e)
        {
            if (e.Y == 0)
                return;

            int TexturesBottom = pnlTextures.Location.Y + pnlTextures.Height;
            int TexturesTop = pnlTextures.Location.Y;

            int ObjectsBottom = pnlObjects.Location.Y + pnlObjects.Height;
            int ObjectsTop = pnlObjects.Location.Y;

            int AnimsBottom = pnlLists.Location.Y + pnlLists.Height;
            int AnimsTop = pnlLists.Location.Y;

            int height = -1;
            if (ObjectsTop + btnObjects.Height + e.Y >= TexturesTop - 6)
            {
                int difference = (ObjectsTop + btnObjects.Height + e.Y) - (TexturesTop - 6);
                if (TexturesTop - 6 - e.Y <= ObjectsTop + btnObjects.Height)
                    if (e.Y > 0) //Only want to push the texture panel down
                    {
                        height = pnlTextures.Height;
                        pnlTextures.Height -= difference;
                    }
            }

            if (height != pnlTextures.Height)
                pnlLists.Height += e.Y;
        }

        private void spltObjTex_Dragged(object sender, SplitterEventArgs e)
        {
            if (e.Y == 0)
                return;

            int TexturesBottom = pnlTextures.Location.Y + pnlTextures.Height;
            int TexturesTop = pnlTextures.Location.Y;

            int ObjectsBottom = pnlObjects.Location.Y + pnlObjects.Height;
            int ObjectsTop = pnlObjects.Location.Y;

            int AnimsBottom = pnlLists.Location.Y + pnlLists.Height;
            int AnimsTop = pnlLists.Location.Y;

            int height = -1;
            if (TexturesTop - 6 + e.Y <= ObjectsTop + btnObjects.Height)
            {
                int difference = (ObjectsTop + btnObjects.Height) - (TexturesTop - 6 + e.Y);
                if (ObjectsTop + btnObjects.Height - e.Y >= TexturesTop - 6)
                    if (e.Y < 0) //Only want to push the anims panel up
                    {
                        height = pnlLists.Height;
                        pnlLists.Height -= difference;
                    }
            }

            if (height != pnlLists.Height)
                pnlTextures.Height -= e.Y;
        }

        private void lstPolygons_SelectedValueChanged(object sender, EventArgs e)
        {
            _targetObject = _selectedPolygon = lstObjects.SelectedItem as MDL0ObjectNode;
            TargetTexRef = _selectedPolygon != null && _selectedTexture != null ? _selectedPolygon.UsableMaterialNode.FindChild(_selectedTexture.Name, true) as MDL0MaterialRefNode : null;
            _mainWindow.SelectedPolygonChanged(this, null);
            overObjPnl.Invalidate();
            overTexPnl.Invalidate();
        }

        public bool _vis0Updating = false; 
        public bool _pat0Updating = false; 
        
        public int _polyIndex = -1;
        public int _boneIndex = -1;
        public int _texIndex = -1;

        public bool _syncObjTex;

        private void lstPolygons_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MDL0ObjectNode poly = lstObjects.Items[e.Index] as MDL0ObjectNode;

            poly._render = e.NewValue == CheckState.Checked;

            if (_syncVis0 && poly._bone != null)
            {
                bool temp = false;
                if (!_vis0Updating)
                {
                    _vis0Updating = true;
                    temp = true;
                }

                if (VIS0Indices.ContainsKey(poly._bone.Name))
                    foreach (int i in VIS0Indices[poly._bone.Name])
                        if (((MDL0ObjectNode)lstObjects.Items[i])._render != poly._render)
                            lstObjects.SetItemChecked(i, poly._render);

                if (temp)
                {
                    _vis0Updating = false;
                    temp = false;
                }

                if (!_vis0Updating)
                {
                    _polyIndex = e.Index;
                    _mainWindow.UpdateVis0(this, null);
                }
            }

            if (!_updating) _mainWindow.ModelPanel.Invalidate();
        }

        //public event EventHandler Key;
        //public event EventHandler Unkey;
        //protected override bool ProcessKeyPreview(ref Message m)
        //{
        //    if (m.Msg == 0x100)
        //    {
        //        Keys key = (Keys)m.WParam;
        //        if (Control.ModifierKeys == Keys.Control)
        //        {
        //            if (key == Keys.K)
        //            {
        //                if (Key != null)
        //                    Key(this, null);
        //                return true;
        //            }
        //            else if (key == Keys.L)
        //            {
        //                if (Unkey != null)
        //                    Unkey(this, null);
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    return base.ProcessKeyPreview(ref m);
        //}

        private void lstTextures_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_selectedTexture != null)
                _selectedTexture.Selected = false;

            if ((_selectedTexture = lstTextures.SelectedItem as MDL0TextureNode) != null)
            {
                _selectedTexture.Selected = true;

                overObjPnl.Invalidate();
                overTexPnl.Invalidate();

                if (_syncObjTex)
                    _selectedTexture.ObjOnly = true;

                TargetTexRef = _selectedPolygon != null ? _selectedPolygon.UsableMaterialNode.FindChild(_selectedTexture.Name, true) as MDL0MaterialRefNode : null;
            }
            if (!_updating) _mainWindow.ModelPanel.Invalidate();
        }

        private void chkAllPoly_CheckStateChanged(object sender, EventArgs e)
        {
            if (lstObjects.Items.Count == 0)
                return;

            _updating = true;

            lstObjects.BeginUpdate();
            for (int i = 0; i < lstObjects.Items.Count; i++)
                lstObjects.SetItemCheckState(i, chkAllObj.CheckState);
            lstObjects.EndUpdate();

            _updating = false;

            _mainWindow.ModelPanel.Invalidate();
        }

        private void btnObjects_Click(object sender, EventArgs e)
        {
            if (lstObjects.Visible)
            {
                pnlObjects.Tag = pnlObjects.Height;
                pnlObjects.Height = btnObjects.Height;
                lstObjects.Visible = chkSyncVis.Visible = chkAllObj.Visible = overObjPnl.Visible = false;
            }
            else
            {
                pnlObjects.Height = (int)pnlObjects.Tag;
                pnlLists.Dock = DockStyle.Top;
                pnlTextures.Dock = DockStyle.Bottom;
                pnlObjects.Dock = DockStyle.Fill;
                lstObjects.Visible = chkSyncVis.Visible = chkAllObj.Visible = overObjPnl.Visible = true;
                
            }
        }

        private void btnTextures_Click(object sender, EventArgs e)
        {
            if (lstTextures.Visible)
            {
                pnlTextures.Tag = pnlTextures.Height;
                pnlTextures.Height = btnTextures.Height;
                lstTextures.Visible = chkAllTextures.Visible = spltObjTex.Visible = overTexPnl.Visible = false;
            }
            else
            {
                pnlTextures.Height = (int)pnlTextures.Tag;
                lstTextures.Visible = chkAllTextures.Visible = spltObjTex.Visible = overTexPnl.Visible = true;
            }
        }

        private void btnAnims_Click(object sender, EventArgs e)
        {
            if (listGroupPanel.Visible)
            {
                pnlLists.Tag = pnlLists.Height;
                pnlLists.Height = btnLists.Height;
                listGroupPanel.Visible = fileType.Visible = spltAnimObj.Visible = false;
            }
            else
            {
                pnlLists.Height = (int)pnlLists.Tag;
                listGroupPanel.Visible = fileType.Visible = spltAnimObj.Visible = true;
            }
        }

        private void lstTextures_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MDL0TextureNode tref = lstTextures.Items[e.Index] as MDL0TextureNode;

            tref.Enabled = e.NewValue == CheckState.Checked;

            if (!_updating)
                _mainWindow.ModelPanel.Invalidate();
        }

        private void chkAllTextures_CheckStateChanged(object sender, EventArgs e)
        {
            _updating = true;

            lstTextures.BeginUpdate();
            for (int i = 0; i < lstTextures.Items.Count; i++)
                lstTextures.SetItemCheckState(i, chkAllTextures.CheckState);
            lstTextures.EndUpdate();

            _updating = false;

            _mainWindow.ModelPanel.Invalidate();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedTexture != null)
                using (GLTextureWindow w = new GLTextureWindow())
                {
                    _mainWindow.ModelPanel.Release();
                    w.ShowDialog(this, _selectedTexture.Texture);
                    _mainWindow.ModelPanel.Capture();
                }
        }

        private void replaceTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lstTextures.SelectedIndex;
            if ((_selectedTexture != null) && (_selectedTexture.Source is TEX0Node))
            {
                TEX0Node node = _selectedTexture.Source as TEX0Node;
                using (TextureConverterDialog dlg = new TextureConverterDialog())
                    if (dlg.ShowDialog(this, node) == DialogResult.OK)
                    {
                        _updating = true;
                        _selectedTexture.Reload();
                        lstTextures.SetItemCheckState(index, CheckState.Checked);
                        lstTextures.SetSelected(index, false);
                        _updating = false;

                        _mainWindow.ModelPanel.Invalidate();
                    }
            }
        }

        private void ctxTextures_Opening(object sender, CancelEventArgs e)
        {
            if (_selectedTexture == null)
                e.Cancel = true;
            else
            {
                if (_selectedTexture.Source is TEX0Node)
                {
                    viewToolStripMenuItem.Enabled = true;
                    replaceTextureToolStripMenuItem.Enabled = true;
                    exportTextureToolStripMenuItem.Enabled = true;
                    sourceToolStripMenuItem.Text = String.Format("Source: {0}", Path.GetFileName(((ResourceNode)_selectedTexture.Source).RootNode._origPath));
                }
                else if (_selectedTexture.Source is string)
                {
                    viewToolStripMenuItem.Enabled = true;
                    replaceTextureToolStripMenuItem.Enabled = false;
                    exportTextureToolStripMenuItem.Enabled = false;
                    sourceToolStripMenuItem.Text = String.Format("Source: {0}", (string)_selectedTexture.Source);
                }
                else
                {
                    viewToolStripMenuItem.Enabled = false;
                    replaceTextureToolStripMenuItem.Enabled = false;
                    exportTextureToolStripMenuItem.Enabled = false;
                    sourceToolStripMenuItem.Text = "Source: <Not Found>";
                }

                if (_selectedTexture.Texture != null)
                    sizeToolStripMenuItem.Text = String.Format("Size: {0} x {1}", _selectedTexture.Texture.Width, _selectedTexture.Texture.Height);
                else
                    sizeToolStripMenuItem.Text = "Size: <Not Found>";
            }
        }

        private void lstTextures_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lstTextures.IndexFromPoint(e.X, e.Y);
            if (lstTextures.SelectedIndex != index)
                lstTextures.SelectedIndex = index;

            if (e.Button == MouseButtons.Right)
            {
                if (_selectedTexture != null)
                    lstTextures.ContextMenuStrip = ctxTextures;
                else
                    lstTextures.ContextMenuStrip = null;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedTexture != null)
            {
                _selectedTexture.Reload();
                _mainWindow.ModelPanel.Invalidate();
            }
        }

        private void lstTextures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                lstTextures.SelectedItem = null;
        }
        private void lstPolygons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                lstObjects.SelectedItem = null;
        }
        private void exportTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((_selectedTexture != null) && (_selectedTexture.Source is TEX0Node))
            {
                TEX0Node node = _selectedTexture.Source as TEX0Node;
                using (SaveFileDialog dlgSave = new SaveFileDialog())
                {
                    dlgSave.FileName = node.Name;
                    dlgSave.Filter = ExportFilters.TEX0;
                    if (dlgSave.ShowDialog(this) == DialogResult.OK)
                        node.Export(dlgSave.FileName);
                }
            }
        }

        private void renameTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RenameDialog dlg = new RenameDialog())
                dlg.ShowDialog(this.ParentForm, (_selectedTexture.Source as TEX0Node));
            
            _selectedTexture.Name = (_selectedTexture.Source as TEX0Node).Name;
        }

        private void chkSyncVis_CheckedChanged(object sender, EventArgs e)
        {
            _syncVis0 = chkSyncVis.Checked;
            _mainWindow.Updating = true;
            _mainWindow.SyncVIS0 = _syncVis0;
            _mainWindow.Updating = false;
        }

        private void fileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAnimations(TargetAnimType);
            if (TargetAnimType == 0)
                portToolStripMenuItem.Visible = true;
            else
                portToolStripMenuItem.Visible = false;
            _mainWindow.SetCurrentControl();
        }

        #region Animation Context Menu
        private void ctxAnim_Opening(object sender, CancelEventArgs e)
        {
            if (_mainWindow.GetSelectedBRRESFile(TargetAnimType) == null)
                e.Cancel = true;
            else
                sourceToolStripMenuItem.Text = String.Format("Source: {0}", Path.GetFileName(_mainWindow.GetSelectedBRRESFile(TargetAnimType).RootNode._origPath));
        }

        private SaveFileDialog dlgSave = new SaveFileDialog();
        private OpenFileDialog dlgOpen = new OpenFileDialog();
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BRESEntryNode node;
            if ((node = _mainWindow.GetSelectedBRRESFile(TargetAnimType) as BRESEntryNode) == null)
                return;

            dlgSave.FileName = node.Name;
            switch (TargetAnimType)
            {
                case AnimType.CHR: dlgSave.Filter = ExportFilters.CHR0; break;
                case AnimType.SRT: dlgSave.Filter = ExportFilters.SRT0; break;
                case AnimType.SHP: dlgSave.Filter = ExportFilters.SHP0; break;
                case AnimType.PAT: dlgSave.Filter = ExportFilters.PAT0; break;
                case AnimType.VIS: dlgSave.Filter = ExportFilters.VIS0; break;
                case AnimType.SCN: dlgSave.Filter = ExportFilters.SCN0; break;
                case AnimType.CLR: dlgSave.Filter = ExportFilters.CLR0; break;
            }
            if (dlgSave.ShowDialog() == DialogResult.OK)
                node.Export(dlgSave.FileName);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BRESEntryNode node;
            if ((node = _mainWindow.GetSelectedBRRESFile(TargetAnimType) as BRESEntryNode) == null)
                return;

            switch (TargetAnimType)
            {
                case AnimType.CHR: dlgOpen.Filter = ExportFilters.CHR0; break;
                case AnimType.SRT: dlgOpen.Filter = ExportFilters.SRT0; break;
                case AnimType.SHP: dlgOpen.Filter = ExportFilters.SHP0; break;
                case AnimType.PAT: dlgOpen.Filter = ExportFilters.PAT0; break;
                case AnimType.VIS: dlgOpen.Filter = ExportFilters.VIS0; break;
                case AnimType.SCN: dlgOpen.Filter = ExportFilters.SCN0; break;
                case AnimType.CLR: dlgOpen.Filter = ExportFilters.CLR0; break;
            }

            if (dlgOpen.ShowDialog() == DialogResult.OK)
                node.Replace(dlgOpen.FileName);
        }

        private unsafe void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TargetAnimType != 0 || SelectedCHR0 == null || (SelectedCHR0.IsPorted && MessageBox.Show("This animation has already been ported!\nDo you still want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No))
                return;

            MDL0Node model;

            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "MDL0 Raw Model (*.mdl0)|*.mdl0";
            dlgOpen.Title = "Select the model this animation is for...";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
                if ((model = (MDL0Node)NodeFactory.FromFile(null, dlgOpen.FileName)) != null)
                    SelectedCHR0.Port(TargetModel, model);

            _mainWindow.UpdateModel();
            _mainWindow.ModelPanel.Invalidate();
        }
        #endregion

        private void listAnims_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (_mainWindow.GetSelectedBRRESFile(TargetAnimType) != null)
                    SubActionsList.ContextMenuStrip = ctxAnim;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RenameDialog dlg = new RenameDialog())
                dlg.ShowDialog(this.ParentForm, _mainWindow.GetSelectedBRRESFile(TargetAnimType));
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourceNode r;
            if ((r = _mainWindow.GetSelectedBRRESFile(TargetAnimType)) != null)
                switch (TargetAnimType)
                {
                    case AnimType.CHR: ((BRESNode)r.Parent.Parent).CreateResource<CHR0Node>("NewCHR"); break;
                    case AnimType.SRT: ((BRESNode)r.Parent.Parent).CreateResource<SRT0Node>("NewSRT"); break;
                    case AnimType.SHP: ((BRESNode)r.Parent.Parent).CreateResource<SHP0Node>("NewSHP"); break;
                    case AnimType.PAT: ((BRESNode)r.Parent.Parent).CreateResource<PAT0Node>("NewPAT"); break;
                    case AnimType.VIS: ((BRESNode)r.Parent.Parent).CreateResource<VIS0Node>("NewVIS"); break;
                    case AnimType.SCN: ((BRESNode)r.Parent.Parent).CreateResource<SCN0Node>("NewSCN"); break;
                    case AnimType.CLR: ((BRESNode)r.Parent.Parent).CreateResource<CLR0Node>("NewCLR"); break;
                }
            UpdateAnimations(TargetAnimType);
            SubActionsList.SetSelected(SubActionsList.Items.Count - 1, true);
        }

        private void overObjPnl_Paint(object sender, PaintEventArgs e)
        {
            if (_srt0Selection == null && _pat0Selection == null)
                return;
            Graphics g = e.Graphics;
            for (int i = 0; i < lstObjects.Items.Count; i++)
            {
                MDL0ObjectNode poly = lstObjects.Items[i] as MDL0ObjectNode;
                if (poly.UsableMaterialNode != null)
                    if (_srt0Selection != null)
                    {
                        if (_srt0Selection.FindChildByType(poly.UsableMaterialNode.Name, false, ResourceType.SRT0Entry) != null)
                        {
                            Rectangle r = lstObjects.GetItemRectangle(i);
                            g.DrawRectangle(Pens.Black, r);
                        }
                    }
                    else if (_pat0Selection != null)
                    {
                        if (_pat0Selection.FindChildByType(poly.UsableMaterialNode.Name, false, ResourceType.PAT0Entry) != null)
                        {
                            Rectangle r = lstObjects.GetItemRectangle(i);
                            g.DrawRectangle(Pens.Black, r);

                        }
                    }
            }
        }

        private void overTexPnl_Paint(object sender, PaintEventArgs e)
        {
            if (_srt0Selection == null && _pat0Selection == null)
                return;
            Graphics g = e.Graphics;
            ResourceNode rn = null;
            if (_selectedPolygon != null && _selectedPolygon.UsableMaterialNode != null)
                for (int i = 0; i < lstTextures.Items.Count; i++)
                {
                    MDL0TextureNode tex = lstTextures.Items[i] as MDL0TextureNode;
                    if ((rn = _selectedPolygon.UsableMaterialNode.FindChild(tex.Name, true)) != null)
                        if (_srt0Selection != null)
                        {
                            if (_srt0Selection.FindChildByType(_selectedPolygon.UsableMaterialNode.Name + "/Texture" + rn.Index, false, ResourceType.SRT0Texture) != null)
                            {
                                Rectangle r = lstTextures.GetItemRectangle(i);
                                g.DrawRectangle(Pens.Black, r);
                            }
                        }
                        else if (_pat0Selection != null)
                        {
                            if (_pat0Selection.FindChildByType(_selectedPolygon.UsableMaterialNode.Name + "/Texture" + rn.Index, false, ResourceType.PAT0Texture) != null)
                            {
                                Rectangle r = lstTextures.GetItemRectangle(i);
                                g.DrawRectangle(Pens.Black, r);
                            }
                        }
                }
        }

        private void lstObjects_Leave(object sender, EventArgs e)
        {
            overObjPnl.Invalidate();
            overTexPnl.Invalidate();
        }

        private void lstTextures_Leave(object sender, EventArgs e)
        {
            overObjPnl.Invalidate();
            overTexPnl.Invalidate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainWindow.GetSelectedBRRESFile(TargetAnimType).Remove();
            _mainWindow.GetFiles(AnimType.None);
            UpdateAnimations();
            _mainWindow.UpdatePropDisplay();
            _mainWindow.UpdateModel();
            _mainWindow.AnimChanged(AnimType.None);
            _mainWindow.ModelPanel.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (lstHurtboxes.Items.Count == 0)
                return;

            _updating = true;

            lstHurtboxes.BeginUpdate();
            for (int i = 0; i < lstHurtboxes.Items.Count; i++)
                lstHurtboxes.SetItemCheckState(i, chkAllHurtboxes.CheckState);
            lstHurtboxes.EndUpdate();

            _updating = false;

            _mainWindow.ModelPanel.Invalidate();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MoveDefHurtBoxNode SelectedHurtbox
        {
            get { return _mainWindow._selectedHurtbox; }
            set { _mainWindow._selectedHurtbox = value; }
        }

        private void lstHurtboxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lstHurtboxes.SelectedItem = null;
                SelectedHurtbox = null;

                if (!_updating)
                    _mainWindow.ModelPanel.Invalidate();
            }
        }

        private void lstHurtboxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            SelectedHurtbox = lstHurtboxes.SelectedItem as MoveDefHurtBoxNode;
            _mainWindow.ModelPanel.Invalidate();
        }

        private void lstHurtboxes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_updating)
                return;
            
            _mainWindow.ModelPanel.Invalidate();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MoveDefSubActionGroupNode SelectedSubActionGrp
        {
            get { return _mainWindow.SelectedSubActionGrp; }
            set { _mainWindow.SelectedSubActionGrp = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MoveDefActionGroupNode SelectedActionGrp
        {
            get { return _mainWindow.SelectedActionGrp; }
            set { _mainWindow.SelectedActionGrp = value; }
        }

        private void ActionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_closing)
                return;

            SelectedActionGrp = ActionsList.SelectedItem as MoveDefActionGroupNode;

            _mainWindow.MaxFrame = 1;
            _mainWindow.GetFiles(AnimType.None);

            //comboBox1_SelectedIndexChanged(this, null);
            //UpdateCurrentControl();

            foreach (MoveDefActionNode a in MoveDefActionNode._runningActions)
                a.Reset();

            MoveDefActionNode._runningActions.Clear();
            foreach (MoveDefActionNode a in SelectedActionGrp.Children)
                MoveDefActionNode._runningActions.Add(a);

            _mainWindow.SetFrame(0);
            //_mainWindow.pnlAssets.listAnims.SelectedIndices.Clear();
        }

        Control _currentControl;
        private void movesetEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control newControl = null;
            switch (movesetEditor.SelectedIndex)
            {
                case 0:
                    newControl = ActionsList;
                    break;
                case 1:
                    newControl = SubActionsList;
                    break;
                case 2:
                    newControl = attributeGridMain;
                    break;
                case 3:
                    newControl = attributeGridSSE;
                    break;
                case 4:
                    newControl = pnlHurtboxes;
                    break;
            }

            if (_currentControl != null)
                _currentControl.Visible = false;

            if ((_currentControl = newControl) != null)
                _currentControl.Visible = true;
        }

        public void UpdateMoveset(MoveDefNode moveset)
        {
            _updating = true;
            attributeGridMain.TargetNode = moveset._data._attributes;
            attributeGridSSE.TargetNode = moveset._data._sseAttributes;
            foreach (MoveDefHurtBoxNode h in moveset._data._misc.hurtBoxes.Children)
                lstHurtboxes.Items.Add(h, true);
            SubActionsList.Items.AddRange(moveset._subActions.Children.ToArray());
            ActionsList.Items.AddRange(moveset._actions.Children.ToArray());
            _updating = false;
        }

        private void SubActionsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (_closing)
                return;

            SelectedSubActionGrp = SubActionsList.SelectedItem as MoveDefSubActionGroupNode;

            //comboBox1_SelectedIndexChanged(this, null);
            //UpdateCurrentControl();

            foreach (MoveDefActionNode a in MoveDefActionNode._runningActions)
                a.Reset();

            MoveDefActionNode._runningActions.Clear();
            foreach (MoveDefActionNode a in SelectedSubActionGrp.Children)
                MoveDefActionNode._runningActions.Add(a);

            //_mainWindow.pnlAssets.listAnims.SelectedItems.Clear();
            //for (int i = 0; i < _mainWindow.pnlAssets.listAnims.Items.Count; i++)
            //    if (_mainWindow.pnlAssets.listAnims.Items[i].Tag.ToString() == selectedSubActionGrp.Name)
            //    {
            //        _mainWindow.pnlAssets.listAnims.Items[i].Selected = true;
            //        break;
            //    }

            if (SubActionsList.SelectedItems.Count > 0)
            {
                string[] anims = _animations.Select(x => x.Name).ToArray();
                string s = SubActionsList.SelectedItem.ToString();
                int i = Array.IndexOf(anims, s);
                if (i >= 0)
                {
                    switch (TargetAnimType)
                    {
                        case AnimType.CHR: _mainWindow.SelectedCHR0 = _animations[i] as CHR0Node;
                            createNewToolStripMenuItem.Text = "Create New CHR0";
                            break;
                        case AnimType.SRT: _mainWindow.SelectedSRT0 = _animations[i] as SRT0Node;
                            createNewToolStripMenuItem.Text = "Create New SRT0";
                            break;
                        case AnimType.SHP: _mainWindow.SelectedSHP0 = _animations[i] as SHP0Node;
                            createNewToolStripMenuItem.Text = "Create New SHP0";
                            break;
                        case AnimType.PAT: _mainWindow.SelectedPAT0 = _animations[i] as PAT0Node;
                            createNewToolStripMenuItem.Text = "Create New PAT0";
                            break;
                        case AnimType.VIS: _mainWindow.SelectedVIS0 = _animations[i] as VIS0Node;
                            createNewToolStripMenuItem.Text = "Create New VIS0";
                            break;
                        case AnimType.CLR: _mainWindow.SelectedCLR0 = _animations[i] as CLR0Node;
                            createNewToolStripMenuItem.Text = "Create New CLR0";
                            break;
                    }
                    _mainWindow.GetFiles(TargetAnimType);
                }
                else
                {
                    _mainWindow.GetFiles(AnimType.None);
                    _mainWindow.SetSelectedBRRESFile(TargetAnimType, null);
                }
                _mainWindow.UpdatePropDisplay();
            }
            else
            {
                _mainWindow.GetFiles(AnimType.None);
                _mainWindow.UpdatePropDisplay();
                _mainWindow.UpdateModel();
                _mainWindow.AnimChanged(AnimType.None);
                _mainWindow.ModelPanel.Invalidate();
            }

            //if (_selectedAnim != null)
            //    portToolStripMenuItem.Enabled = !_selectedAnim.IsPorted;

            _mainWindow.Updating = true;
            _mainWindow.Loop = SelectedSubActionGrp._flags.HasFlag(AnimationFlags.Loop);
            _mainWindow.Updating = false;
            _mainWindow.SetFrame(1);
            _mainWindow.MovesetPanel.comboBox1_SelectedIndexChanged(this, null);
        }

        private void SubActionsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                SubActionsList.SelectedItems.Clear();
        }
    }
}
