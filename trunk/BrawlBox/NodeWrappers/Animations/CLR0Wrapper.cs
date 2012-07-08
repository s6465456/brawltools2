using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;
using System.Windows.Forms;
using System.ComponentModel;

namespace BrawlBox
{
    [NodeWrapper(ResourceType.CLR0)]
    class CLR0Wrapper : GenericWrapper
    {
        #region Menu

        private static ContextMenuStrip _menu;
        static CLR0Wrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("New Color Sequence", null, NewCLRAction));
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
        protected static void NewCLRAction(object sender, EventArgs e) { GetInstance<CLR0Wrapper>().NewCLR(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = _menu.Items[7].Enabled = _menu.Items[9].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            CLR0Wrapper w = GetInstance<CLR0Wrapper>();

            _menu.Items[3].Enabled = _menu.Items[9].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[6].Enabled = w.PrevNode != null;
            _menu.Items[7].Enabled = w.NextNode != null;
        }

        #endregion

        public override string ExportFilter { get { return ExportFilters.CLR0; } }

        public CLR0Wrapper() { ContextMenuStrip = _menu; }

        private void NewCLR()
        {
            ((CLR0Node)this._resource).CreateEntry();
        }
    }
}
