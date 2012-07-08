using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;
using System.Windows.Forms;
using System.ComponentModel;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.SCN0)]
    class SCN0Wrapper : GenericWrapper
    {
        #region Menu
        
        private static ContextMenuStrip _menu;
        static SCN0Wrapper()
        {
            _menu = new ContextMenuStrip();
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
        protected static void MoveUpAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().MoveUp(); }
        protected static void MoveDownAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().MoveDown(); }
        protected static void ExportAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().Export(); }
        protected static void ReplaceAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().Replace(); }
        protected static void RestoreAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().Restore(); }
        protected static void DeleteAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().Delete(); }
        protected static void RenameAction(object sender, EventArgs e) { GetInstance<SCN0Wrapper>().Rename(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[1].Enabled = _menu.Items[2].Enabled = _menu.Items[4].Enabled = _menu.Items[5].Enabled = _menu.Items[8].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            SCN0Wrapper w = GetInstance<SCN0Wrapper>();
            _menu.Items[1].Enabled = _menu.Items[8].Enabled = w.Parent != null;
            _menu.Items[2].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[4].Enabled = w.PrevNode != null;
            _menu.Items[5].Enabled = w.NextNode != null;
        }

        #endregion

        public SCN0Wrapper() { ContextMenuStrip = _menu; }

        public override string ExportFilter { get { return ExportFilters.SCN0; } }
    }
}
