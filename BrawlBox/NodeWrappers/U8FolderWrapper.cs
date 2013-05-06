﻿using System;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib;
using System.Collections.Generic;
using BrawlLib.IO;
using BrawlLib.SSBB;

namespace BrawlBox
{
    [NodeWrapper(ResourceType.U8Folder)]
    class U8FolderWrapper : GenericWrapper
    {
        #region Menu

        private static ContextMenuStrip _menu;
        static U8FolderWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("Ne&w", null,
                //new ToolStripMenuItem("RLYT", null, NewRlytAction),
                new ToolStripMenuItem("TPL", null, NewTplAction),
                //new ToolStripMenuItem("RFNT", null, NewRfntAction),
                //new ToolStripMenuItem("WAV", null, NewWavAction),
                new ToolStripMenuItem("BRRES", null, NewBrresAction),
                new ToolStripMenuItem("Folder", null, NewFolderAction)));
            _menu.Items.Add(new ToolStripMenuItem("&Import", null,
                //new ToolStripMenuItem("RLYT", null, ImportRlytAction),
                new ToolStripMenuItem("TPL", null, ImportTplAction),
                //new ToolStripMenuItem("RFNT", null, ImportRfntAction),
                //new ToolStripMenuItem("WAV", null, ImportWavAction),
                new ToolStripMenuItem("BRRES", null, ImportBrresAction),
                new ToolStripMenuItem("U8 Archive", null, ImportU8Action)));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Preview All Models", null, PreviewAllAction));
            _menu.Items.Add(new ToolStripMenuItem("Export All", null, ExportAllAction));
            _menu.Items.Add(new ToolStripMenuItem("Replace All", null, ReplaceAllAction));
            _menu.Items.Add(new ToolStripMenuItem("Edit All", null, EditAllAction));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
            _menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void NewRlytAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewRlyt(); }
        protected static void NewTplAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewTpl(); }
        protected static void NewRfntAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewRfnt(); }
        protected static void NewWavAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewWav(); }
        protected static void NewBrresAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewBrres(); }
        protected static void NewFolderAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().NewFolder(); }

        protected static void ImportBrresAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportBrres(); }
        protected static void ImportRlytAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportRlyt(); }
        protected static void ImportTplAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportTpl(); }
        protected static void ImportRfntAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportRfnt(); }
        protected static void ImportWavAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportWav(); }
        protected static void ImportU8Action(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportU8(); }

        protected static void ExportAllAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ExportAll(); }
        protected static void ImportFolderAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ImportFolder(); }
        protected static void ReplaceAllAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().ReplaceAll(); }
        protected static void EditAllAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().EditAll(); }
        protected static void PreviewAllAction(object sender, EventArgs e) { GetInstance<U8FolderWrapper>().PreviewAll(); }
        
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[9].Enabled = _menu.Items[10].Enabled = _menu.Items[12].Enabled = _menu.Items[13].Enabled = _menu.Items[15].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            U8FolderWrapper w = GetInstance<U8FolderWrapper>();

            _menu.Items[9].Enabled = _menu.Items[15].Enabled = w.Parent != null;
            _menu.Items[10].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[12].Enabled = w.PrevNode != null;
            _menu.Items[13].Enabled = w.NextNode != null;
        }

        #endregion

        public override string ExportFilter
        {
            get
            {
                return "U8 Archive (*.arc)|*.arc|" +
                    "Compressed U8 Archive (*.szs)|*.szs|" +
                    "Archive Pair (*.pair)|*.pair";
            }
        }

        public U8FolderWrapper() { ContextMenuStrip = _menu; }

        public void NewRlyt()
        {
            //RlytNode node = ((U8FolderNode)_resource).CreateResource<RlytNode>("NewRLYT");
            //BaseWrapper res = this.FindResource(node, true);
            //res = res.FindResource(node, false);
            //res.EnsureVisible();
            //res.TreeView.SelectedNode = res;
        }

        public void NewTpl()
        {
            TPLNode node = ((U8FolderNode)_resource).CreateResource<TPLNode>("TPL");
            BaseWrapper res = this.FindResource(node, true);
            res = res.FindResource(node, false);
            res.EnsureVisible();
            res.TreeView.SelectedNode = res;
        }

        public void NewRfnt()
        {
            //RlytNode node = ((U8FolderNode)_resource).CreateResource<RlytNode>("NewRLYT");
            //BaseWrapper res = this.FindResource(node, true);
            //res = res.FindResource(node, false);
            //res.EnsureVisible();
            //res.TreeView.SelectedNode = res;
        }

        public void NewWav()
        {
            //RlytNode node = ((U8FolderNode)_resource).CreateResource<RlytNode>("NewRLYT");
            //BaseWrapper res = this.FindResource(node, true);
            //res = res.FindResource(node, false);
            //res.EnsureVisible();
            //res.TreeView.SelectedNode = res;
        }

        public U8FolderNode NewFolder()
        {
            U8FolderNode node = ((U8FolderNode)_resource).CreateResource<U8FolderNode>("NewFolder");
            BaseWrapper res = this.FindResource(node, true);
            res = res.FindResource(node, false);
            res.EnsureVisible();
            res.TreeView.SelectedNode = res;
            return node;
        }

        public BRESNode NewBrres()
        {
            BRESNode node = ((U8FolderNode)_resource).CreateResource<BRESNode>("NewBrres");
            BaseWrapper res = this.FindResource(node, true);
            res = res.FindResource(node, false);
            res.EnsureVisible();
            res.TreeView.SelectedNode = res;
            return node;
        }

        public void ImportRlyt()
        {
            //string path;
            //if (Program.OpenFile(ExportFilters.SRT0, out path) > 0)
            //{
            //    RLYTNode node = NodeFactory.FromFile(null, path) as RLYTNode;
            //    ((U8FolderNode)_resource).AddChild(node);

            //    BaseWrapper w = this.FindResource(node, true);
            //    w.EnsureVisible();
            //    w.TreeView.SelectedNode = w;
            //}
        }
        public void ImportTpl()
        {
            //string path;
            //if (Program.OpenFile(ExportFilters.SRT0, out path) > 0)
            //{
            //    TPLNode node = NodeFactory.FromFile(null, path) as TPLNode;
            //    ((U8FolderNode)_resource).AddChild(node);

            //    BaseWrapper w = this.FindResource(node, true);
            //    w.EnsureVisible();
            //    w.TreeView.SelectedNode = w;
            //}
        }
        public void ImportRfnt()
        {
            //string path;
            //if (Program.OpenFile(ExportFilters.SRT0, out path) > 0)
            //{
            //    RLYTNode node = NodeFactory.FromFile(null, path) as RLYTNode;
            //    ((U8FolderNode)_resource).AddChild(node);

            //    BaseWrapper w = this.FindResource(node, true);
            //    w.EnsureVisible();
            //    w.TreeView.SelectedNode = w;
            //}
        }
        public void ImportWav()
        {
            //string path;
            //if (Program.OpenFile(ExportFilters.SRT0, out path) > 0)
            //{
            //    RLYTNode node = NodeFactory.FromFile(null, path) as RLYTNode;
            //    ((U8FolderNode)_resource).AddChild(node);

            //    BaseWrapper w = this.FindResource(node, true);
            //    w.EnsureVisible();
            //    w.TreeView.SelectedNode = w;
            //}
        }
        public void ImportU8()
        {
            string path;
            if (Program.OpenFile("U8 Archive (*.arc)|*.arc|" +
                    "Compressed U8 Archive (*.szs)|*.szs|" +
                    "Archive Pair (*.pair)|*.pair", out path) > 0)
            {
                U8Node node = NodeFactory.FromFile(null, path) as U8Node;
                U8FolderNode n = new U8FolderNode();
                foreach (ResourceNode r in node.Children) n.AddChild(r);
                n.Name = node.Name;
                ((U8FolderNode)_resource).AddChild(n);

                BaseWrapper w = this.FindResource(n, true);
                w.EnsureVisible();
                w.TreeView.SelectedNode = w;
            }
        }
        public void ImportBrres()
        {
            string path;
            if (Program.OpenFile(ExportFilters.BRES, out path) > 0)
            {
                BRESNode node = NodeFactory.FromFile(null, path) as BRESNode;
                ((U8FolderNode)_resource).AddChild(node);

                BaseWrapper w = this.FindResource(node, true);
                w.EnsureVisible();
                w.TreeView.SelectedNode = w;
            }
        }

        public void ExportAll()
        {
            string path = Program.ChooseFolder();
            if (path == null)
                return;

            ExportAllFormatDialog dialog = new ExportAllFormatDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
                ((BRESNode)_resource).ExportToFolder(path, dialog.SelectedExtension);
        }

        public void EditAll()
        {
            EditAllDialog ctd = new EditAllDialog();
            ctd.ShowDialog(_owner, _resource);
        }

        public void ReplaceAll()
        {
            string path = Program.ChooseFolder();
            if (path == null)
                return;

            ExportAllFormatDialog dialog = new ExportAllFormatDialog();
            dialog.label1.Text = "Input format for textures:";

            if (dialog.ShowDialog() == DialogResult.OK)
                ((BRESNode)_resource).ReplaceFromFolder(path, dialog.SelectedExtension);
        }

        public void ImportFolder()
        {
            string path = Program.ChooseFolder();
            if (path == null)
                return;

            ((BRESNode)_resource).ImportFolder(path);
        }

        private void LoadModels(ResourceNode node, List<MDL0Node> models)
        {
            switch (node.ResourceType)
            {
                case ResourceType.ARC:
                case ResourceType.U8:
                case ResourceType.MRG:
                case ResourceType.BRES:
                case ResourceType.U8Folder:
                case ResourceType.BRESGroup:
                    foreach (ResourceNode n in node.Children)
                        LoadModels(n, models);
                    break;
                case ResourceType.MDL0:
                    models.Add((MDL0Node)node);
                    break;
            }
        }

        public void PreviewAll()
        {
            List<MDL0Node> models = new List<MDL0Node>();
            LoadModels(_resource, models);
            using (ModelForm form = new ModelForm())
            {
                form.ShowDialog(_owner, models);
            }
        }
    }
}
