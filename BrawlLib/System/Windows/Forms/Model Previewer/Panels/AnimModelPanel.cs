﻿using System;
using BrawlLib.SSBB.ResourceNodes;
using System.Drawing;
using BrawlLib.Modeling;
using System.ComponentModel;
using BrawlLib.OpenGL;
using BrawlLib;
using System.IO;
using BrawlBox;
using System.Collections.Generic;

namespace System.Windows.Forms
{
    public class AnimModelPanel : UserControl
    {
        #region Designer

        public CheckedListBox lstObjects;
        private CheckBox chkAllObj;
        private Button btnObjects;
        private ProxySplitter spltAnimObj;
        private Panel pnlAnims;
        private Button btnAnims;
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
        public ListView listAnims;
        private ColumnHeader nameColumn;
        public ComboBox fileType;
        private Panel panel1;
        private ContextMenuStrip ctxAnim;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem portToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        public Button SaveAnims;
        public Button Load;
        private TransparentPanel overObjPnl;
        private TransparentPanel overTexPnl;
        private ToolStripMenuItem createNewToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Panel pnlObjects;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Animations", System.Windows.Forms.HorizontalAlignment.Left);
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.overObjPnl = new System.Windows.Forms.TransparentPanel();
            this.lstObjects = new System.Windows.Forms.CheckedListBox();
            this.chkAllObj = new System.Windows.Forms.CheckBox();
            this.chkSyncVis = new System.Windows.Forms.CheckBox();
            this.btnObjects = new System.Windows.Forms.Button();
            this.pnlAnims = new System.Windows.Forms.Panel();
            this.listAnims = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveAnims = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.fileType = new System.Windows.Forms.ComboBox();
            this.btnAnims = new System.Windows.Forms.Button();
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
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlObjects.SuspendLayout();
            this.pnlAnims.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlObjects.Size = new System.Drawing.Size(137, 150);
            this.pnlObjects.TabIndex = 0;
            // 
            // overObjPnl
            // 
            this.overObjPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overObjPnl.Location = new System.Drawing.Point(0, 61);
            this.overObjPnl.Name = "overObjPnl";
            this.overObjPnl.Size = new System.Drawing.Size(135, 87);
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
            this.lstObjects.Size = new System.Drawing.Size(135, 87);
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
            this.chkAllObj.Size = new System.Drawing.Size(135, 20);
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
            this.chkSyncVis.Size = new System.Drawing.Size(135, 20);
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
            this.btnObjects.Size = new System.Drawing.Size(135, 21);
            this.btnObjects.TabIndex = 6;
            this.btnObjects.Text = "Objects";
            this.btnObjects.UseVisualStyleBackColor = true;
            this.btnObjects.Click += new System.EventHandler(this.btnObjects_Click);
            // 
            // pnlAnims
            // 
            this.pnlAnims.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnims.Controls.Add(this.listAnims);
            this.pnlAnims.Controls.Add(this.panel1);
            this.pnlAnims.Controls.Add(this.btnAnims);
            this.pnlAnims.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnims.Location = new System.Drawing.Point(0, 0);
            this.pnlAnims.MinimumSize = new System.Drawing.Size(0, 21);
            this.pnlAnims.Name = "pnlAnims";
            this.pnlAnims.Size = new System.Drawing.Size(137, 178);
            this.pnlAnims.TabIndex = 2;
            // 
            // listAnims
            // 
            this.listAnims.AutoArrange = false;
            this.listAnims.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn});
            this.listAnims.Cursor = System.Windows.Forms.Cursors.Default;
            this.listAnims.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Animations";
            listViewGroup1.Name = "grpAnims";
            this.listAnims.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listAnims.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listAnims.HideSelection = false;
            this.listAnims.Location = new System.Drawing.Point(0, 42);
            this.listAnims.MultiSelect = false;
            this.listAnims.Name = "listAnims";
            this.listAnims.Size = new System.Drawing.Size(135, 134);
            this.listAnims.TabIndex = 25;
            this.listAnims.UseCompatibleStateImageBehavior = false;
            this.listAnims.View = System.Windows.Forms.View.Details;
            this.listAnims.SelectedIndexChanged += new System.EventHandler(this.listAnims_SelectedIndexChanged);
            this.listAnims.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listAnims_KeyDown);
            this.listAnims.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listAnims_MouseDown);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 160;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveAnims);
            this.panel1.Controls.Add(this.Load);
            this.panel1.Controls.Add(this.fileType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 21);
            this.panel1.TabIndex = 27;
            // 
            // SaveAnims
            // 
            this.SaveAnims.Location = new System.Drawing.Point(41, 0);
            this.SaveAnims.Name = "SaveAnims";
            this.SaveAnims.Size = new System.Drawing.Size(41, 21);
            this.SaveAnims.TabIndex = 28;
            this.SaveAnims.Text = "Save";
            this.SaveAnims.UseVisualStyleBackColor = true;
            this.SaveAnims.Click += new System.EventHandler(this.button2_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(1, 0);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(41, 21);
            this.Load.TabIndex = 27;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileType
            // 
            this.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileType.FormattingEnabled = true;
            this.fileType.Items.AddRange(new object[] {
            "CHR",
            "SRT",
            "SHP",
            "PAT",
            "VIS",
            "SCN",
            "CLR"});
            this.fileType.Location = new System.Drawing.Point(82, 0);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(53, 21);
            this.fileType.TabIndex = 26;
            this.fileType.SelectedIndexChanged += new System.EventHandler(this.fileType_SelectedIndexChanged);
            // 
            // btnAnims
            // 
            this.btnAnims.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnims.Location = new System.Drawing.Point(0, 0);
            this.btnAnims.Name = "btnAnims";
            this.btnAnims.Size = new System.Drawing.Size(135, 21);
            this.btnAnims.TabIndex = 7;
            this.btnAnims.Text = "Animations";
            this.btnAnims.UseVisualStyleBackColor = true;
            this.btnAnims.Click += new System.EventHandler(this.btnAnims_Click);
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
            this.pnlTextures.Size = new System.Drawing.Size(137, 164);
            this.pnlTextures.TabIndex = 3;
            // 
            // overTexPnl
            // 
            this.overTexPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overTexPnl.Location = new System.Drawing.Point(0, 41);
            this.overTexPnl.Name = "overTexPnl";
            this.overTexPnl.Size = new System.Drawing.Size(135, 121);
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
            this.lstTextures.Size = new System.Drawing.Size(135, 121);
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
            this.chkAllTextures.Size = new System.Drawing.Size(135, 20);
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
            this.btnTextures.Size = new System.Drawing.Size(135, 21);
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
            this.spltObjTex.Size = new System.Drawing.Size(137, 4);
            this.spltObjTex.TabIndex = 4;
            this.spltObjTex.Dragged += new System.Windows.Forms.SplitterEventHandler(this.spltObjTex_Dragged);
            // 
            // spltAnimObj
            // 
            this.spltAnimObj.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spltAnimObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltAnimObj.Location = new System.Drawing.Point(0, 178);
            this.spltAnimObj.Name = "spltAnimObj";
            this.spltAnimObj.Size = new System.Drawing.Size(137, 4);
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
            this.ctxAnim.Size = new System.Drawing.Size(195, 186);
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
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.createNewToolStripMenuItem.Text = "Create New Animation";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ModelAssetPanel
            // 
            this.Controls.Add(this.pnlObjects);
            this.Controls.Add(this.spltObjTex);
            this.Controls.Add(this.spltAnimObj);
            this.Controls.Add(this.pnlAnims);
            this.Controls.Add(this.pnlTextures);
            this.Name = "ModelAssetPanel";
            this.Size = new System.Drawing.Size(137, 500);
            this.pnlObjects.ResumeLayout(false);
            this.pnlAnims.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ctxTextures.ResumeLayout(false);
            this.pnlTextures.ResumeLayout(false);
            this.ctxAnim.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        public bool _closing = false;

        public ModelEditControl _mainWindow;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ModelEditControl MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        private ListViewGroup _AnimGroup = new ListViewGroup("Animations");
        
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
            get { return _mainWindow._targetTexRef; }
            set
            {
                _mainWindow.TargetTexRef = value; 
                if (_mainWindow._srt0 != null && TargetTexRef != null)
                    _mainWindow.pnlKeyframes.TargetSequence = _mainWindow.srt0Editor.TexEntry;
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
            get  { return _mainWindow._chr0; }
            set  { _mainWindow.SelectedCHR0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SRT0Node SelectedSRT0
        {
            get { return _mainWindow._srt0; }
            set { _mainWindow.SelectedSRT0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SHP0Node SelectedSHP0
        {
            get { return _mainWindow._shp0; }
            set { _mainWindow.SelectedSHP0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PAT0Node SelectedPAT0
        {
            get { return _mainWindow._pat0; }
            set { _mainWindow.SelectedPAT0 = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0Node SelectedVIS0
        {
            get { return _mainWindow._vis0; }
            set { _mainWindow.SelectedVIS0 = value; }
        }

        public AnimType TargetAnimType
        {
            get { return (AnimType)fileType.SelectedIndex; }
            set { fileType.SelectedIndex = (int)value; }
        }

        //Bone Name - Attached Polygon Indices
        public Dictionary<string, List<int>> VIS0Indices = new Dictionary<string, List<int>>();

        public AnimModelPanel()
        {
            InitializeComponent();
            listAnims.Groups.Add(_AnimGroup);
        }

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
            Add: listAnims.Items.Add(new ListViewItem(node.Name, (int)node.ResourceType, _AnimGroup) { Tag = node });
            return found;
        }

        public CheckState BRRESRelative = CheckState.Unchecked;
        public bool UpdateAnimations() { return UpdateAnimations(TargetAnimType); }
        public bool UpdateAnimations(AnimType type)
        {
            _mainWindow._updating = true;

            string Name = listAnims.SelectedItems != null && listAnims.SelectedItems.Count > 0 ? listAnims.SelectedItems[0].Tag.ToString() : null;
            int frame = CurrentFrame;

            listAnims.BeginUpdate();
            listAnims.Items.Clear();

            if (TargetModel != null)
                if (BRRESRelative != CheckState.Unchecked)
                    LoadAnims(TargetModel.BRESNode, type);
                else
                    LoadAnims(TargetModel.RootNode, type);

            int count = listAnims.Items.Count;

            if (_mainWindow._externalAnimationsNode != null)
                if (BRRESRelative != CheckState.Checked)
                    LoadAnims(_mainWindow._externalAnimationsNode.RootNode, type);

            listAnims.EndUpdate();

            //Reselect the animation
            for (int i = 0; i < listAnims.Items.Count; i++)
                if (listAnims.Items[i].Tag.ToString() == Name)
                {
                    listAnims.Items[i].Selected = true;
                    break;
                }

            _mainWindow._updating = false;
            CurrentFrame = frame;

            if ((_mainWindow.GetSelectedBRRESFile((AnimType)TargetAnimType) == null) && (listAnims.SelectedItems.Count == 0))
            {
                _mainWindow._chr0 = null;
                _mainWindow._srt0 = null;
                _mainWindow._shp0 = null;
                _mainWindow._pat0 = null;
                _mainWindow._vis0 = null;
                _mainWindow._scn0 = null;
                _mainWindow._clr0 = null;
                _mainWindow.UpdatePropDisplay();
                _mainWindow.UpdateModel();
                _mainWindow.AnimChanged(TargetAnimType);
                _mainWindow.modelPanel.Invalidate();
            }

            return count != listAnims.Items.Count;
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
            _mainWindow._updating = true;

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

            _mainWindow._updating = false;
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

            int AnimsBottom = pnlAnims.Location.Y + pnlAnims.Height;
            int AnimsTop = pnlAnims.Location.Y;

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
                pnlAnims.Height += e.Y;
        }

        private void spltObjTex_Dragged(object sender, SplitterEventArgs e)
        {
            if (e.Y == 0)
                return;

            int TexturesBottom = pnlTextures.Location.Y + pnlTextures.Height;
            int TexturesTop = pnlTextures.Location.Y;

            int ObjectsBottom = pnlObjects.Location.Y + pnlObjects.Height;
            int ObjectsTop = pnlObjects.Location.Y;

            int AnimsBottom = pnlAnims.Location.Y + pnlAnims.Height;
            int AnimsTop = pnlAnims.Location.Y;

            int height = -1;
            if (TexturesTop - 6 + e.Y <= ObjectsTop + btnObjects.Height)
            {
                int difference = (ObjectsTop + btnObjects.Height) - (TexturesTop - 6 + e.Y);
                if (ObjectsTop + btnObjects.Height - e.Y >= TexturesTop - 6)
                    if (e.Y < 0) //Only want to push the anims panel up
                    {
                        height = pnlAnims.Height;
                        pnlAnims.Height -= difference;
                    }
            }

            if (height != pnlAnims.Height)
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

            if (!_updating) _mainWindow.modelPanel.Invalidate();
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
            if (!_updating) _mainWindow.modelPanel.Invalidate();
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

            _mainWindow.modelPanel.Invalidate();
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
                pnlAnims.Dock = DockStyle.Top;
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
            if (listAnims.Visible)
            {
                pnlAnims.Tag = pnlAnims.Height;
                pnlAnims.Height = btnAnims.Height;
                listAnims.Visible = fileType.Visible = spltAnimObj.Visible = false;
            }
            else
            {
                pnlAnims.Height = (int)pnlAnims.Tag;
                listAnims.Visible = fileType.Visible = spltAnimObj.Visible = true;
            }
        }

        private void lstTextures_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MDL0TextureNode tref = lstTextures.Items[e.Index] as MDL0TextureNode;

            tref.Enabled = e.NewValue == CheckState.Checked;

            if (!_updating)
                _mainWindow.modelPanel.Invalidate();
        }

        private void chkAllTextures_CheckStateChanged(object sender, EventArgs e)
        {
            _updating = true;

            lstTextures.BeginUpdate();
            for (int i = 0; i < lstTextures.Items.Count; i++)
                lstTextures.SetItemCheckState(i, chkAllTextures.CheckState);
            lstTextures.EndUpdate();

            _updating = false;

            _mainWindow.modelPanel.Invalidate();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedTexture != null)
                using (GLTextureWindow w = new GLTextureWindow())
                {
                    _mainWindow.modelPanel.Release();
                    w.ShowDialog(this, _selectedTexture.Texture);
                    _mainWindow.modelPanel.Capture();
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

                        _mainWindow.modelPanel.Invalidate();
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
                _mainWindow.modelPanel.Invalidate();
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
        private void listAnims_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                listAnims.SelectedItems.Clear();
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
            _mainWindow._updating = true;
            _mainWindow.syncObjectsListToVIS0ToolStripMenuItem.Checked = _syncVis0;
            _mainWindow._updating = false;
        }

        private void listAnims_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_closing)
                return;
            if (listAnims.SelectedItems.Count > 0)
            {
                switch (TargetAnimType)
                {
                    case AnimType.CHR: _mainWindow._chr0 = listAnims.SelectedItems[0].Tag as CHR0Node;
                        createNewToolStripMenuItem.Text = "Create New CHR0";
                        break;
                    case AnimType.SRT: _mainWindow._srt0 = listAnims.SelectedItems[0].Tag as SRT0Node;
                        createNewToolStripMenuItem.Text = "Create New SRT0";
                        break;
                    case AnimType.SHP: _mainWindow._shp0 = listAnims.SelectedItems[0].Tag as SHP0Node;
                        createNewToolStripMenuItem.Text = "Create New SHP0";
                        break;
                    case AnimType.PAT: _mainWindow._pat0 = listAnims.SelectedItems[0].Tag as PAT0Node;
                        createNewToolStripMenuItem.Text = "Create New PAT0";
                        break;
                    case AnimType.VIS: _mainWindow._vis0 = listAnims.SelectedItems[0].Tag as VIS0Node;
                        createNewToolStripMenuItem.Text = "Create New VIS0";
                        break;
                    case AnimType.SCN: _mainWindow._scn0 = listAnims.SelectedItems[0].Tag as SCN0Node;
                        createNewToolStripMenuItem.Text = "Create New SCN0";
                        break;
                    case AnimType.CLR: _mainWindow._clr0 = listAnims.SelectedItems[0].Tag as CLR0Node;
                        createNewToolStripMenuItem.Text = "Create New CLR0";
                        break;
                }
                if (_mainWindow.syncAnimationsTogetherToolStripMenuItem.Checked)
                    _mainWindow.GetFiles(TargetAnimType);
                _mainWindow.AnimChanged(TargetAnimType);
                _mainWindow.UpdatePropDisplay();
            }
            else
            {
                _mainWindow.GetFiles(AnimType.None);
                _mainWindow.UpdatePropDisplay();
                _mainWindow.UpdateModel();
                _mainWindow.AnimChanged(AnimType.None);
                _mainWindow.modelPanel.Invalidate();
            }

            //if (_selectedAnim != null)
            //    portToolStripMenuItem.Enabled = !_selectedAnim.IsPorted;
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
            _mainWindow.modelPanel.Invalidate();
        }
        #endregion

        private void listAnims_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (_mainWindow.GetSelectedBRRESFile(TargetAnimType) != null)
                    listAnims.ContextMenuStrip = ctxAnim;
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
            listAnims.Items[listAnims.Items.Count - 1].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainWindow.btnOpenClose_Click(this, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _mainWindow.btnSave_Click(this, null);
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
            _mainWindow.modelPanel.Invalidate();
        }
    }
    public enum AnimType : int
    {
        None = -1,
        CHR = 0,
        SRT = 1,
        SHP = 2,
        PAT = 3,
        VIS = 4,
        SCN = 5,
        CLR = 6
    }
}
