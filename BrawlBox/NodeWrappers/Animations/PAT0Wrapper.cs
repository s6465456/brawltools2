﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using BrawlLib;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.PAT0)]
    class PAT0Wrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static PAT0Wrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&New Entry", null, NewEntryAction, Keys.Control | Keys.H));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
            _menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
            _menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void NewEntryAction(object sender, EventArgs e) { GetInstance<PAT0Wrapper>().NewEntry(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = _menu.Items[7].Enabled = _menu.Items[10].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            PAT0Wrapper w = GetInstance<PAT0Wrapper>();
            _menu.Items[3].Enabled = _menu.Items[10].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[6].Enabled = w.PrevNode != null;
            _menu.Items[7].Enabled = w.NextNode != null;
        }
        #endregion

        public PAT0Wrapper() { ContextMenuStrip = _menu; }

        public override string ExportFilter
        {
            get
            {
                return ExportFilters.PAT0;
            }
        }

        public void NewEntry()
        {
            PAT0Node n = (PAT0Node)_resource;
            n.CreateEntry();
        }
    }

    [NodeWrapper(ResourceType.PAT0Entry)]
    class PAT0EntryWrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static PAT0EntryWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&New Entry", null, NewEntryAction, Keys.Control | Keys.H));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
            _menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
            _menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void NewEntryAction(object sender, EventArgs e) { GetInstance<PAT0EntryWrapper>().NewEntry(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[0].Enabled = _menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = _menu.Items[7].Enabled = _menu.Items[10].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            PAT0EntryWrapper w = GetInstance<PAT0EntryWrapper>();
            _menu.Items[0].Enabled = w._resource.Children.Count < 8;
            _menu.Items[3].Enabled = _menu.Items[10].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[6].Enabled = w.PrevNode != null;
            _menu.Items[7].Enabled = w.NextNode != null;
        }
        #endregion

        public PAT0EntryWrapper() { ContextMenuStrip = _menu; }

        public void NewEntry()
        {
            PAT0EntryNode n = (PAT0EntryNode)_resource;
            n.CreateEntry();
        }
    }

    [NodeWrapper(ResourceType.PAT0Texture)]
    class PAT0TextureWrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static PAT0TextureWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&New Entry", null, NewEntryAction, Keys.Control | Keys.H));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void NewEntryAction(object sender, EventArgs e) { GetInstance<PAT0TextureWrapper>().NewEntry(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            PAT0TextureWrapper w = GetInstance<PAT0TextureWrapper>();
            _menu.Items[3].Enabled = _menu.Items[6].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
        }
        #endregion

        public void NewEntry()
        {
            PAT0TextureNode n = (PAT0TextureNode)_resource;
            n.CreateEntry();
        }

        public PAT0TextureWrapper() { ContextMenuStrip = _menu; }
    }

    [NodeWrapper(ResourceType.PAT0TextureEntry)]
    class PAT0TextureEntryWrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static PAT0TextureEntryWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[1].Enabled = _menu.Items[2].Enabled = _menu.Items[6].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            PAT0TextureEntryWrapper w = GetInstance<PAT0TextureEntryWrapper>();
            _menu.Items[1].Enabled = _menu.Items[6].Enabled = w.Parent != null;
            _menu.Items[2].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
        }
        #endregion

        public PAT0TextureEntryWrapper() { ContextMenuStrip = _menu; }
    }
}
