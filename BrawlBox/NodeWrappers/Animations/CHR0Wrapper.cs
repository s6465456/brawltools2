using System;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;
using System.Windows.Forms;
using System.ComponentModel;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.CHR0)]
    class CHR0Wrapper : GenericWrapper
    {
        #region Menu

        private static ContextMenuStrip _menu;
        static CHR0Wrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("Ne&w Bone Animation", null, NewBoneAction, Keys.Control | Keys.W));
            _menu.Items.Add(new ToolStripMenuItem("&Merge Animation", null, MergeAction, Keys.Control | Keys.M));
            _menu.Items.Add(new ToolStripMenuItem("&Append Animation", null, AppendAction, Keys.Control | Keys.A));
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
        protected static void NewBoneAction(object sender, EventArgs e) { GetInstance<CHR0Wrapper>().NewBone(); }
        protected static void MergeAction(object sender, EventArgs e) { GetInstance<CHR0Wrapper>().Merge(); }
        protected static void AppendAction(object sender, EventArgs e) { GetInstance<CHR0Wrapper>().Append(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[5].Enabled = _menu.Items[6].Enabled = _menu.Items[8].Enabled = _menu.Items[9].Enabled = _menu.Items[12].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            CHR0Wrapper w = GetInstance<CHR0Wrapper>();
            _menu.Items[5].Enabled = _menu.Items[12].Enabled = w.Parent != null;
            _menu.Items[6].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[8].Enabled = w.PrevNode != null;
            _menu.Items[9].Enabled = w.NextNode != null;
        }

        #endregion

        public CHR0Wrapper() { ContextMenuStrip = _menu; }

        public override string ExportFilter { get { return ExportFilters.CHR0; } }

        public void NewBone()
        {
            CHR0EntryNode node = ((CHR0Node)_resource).CreateEntry();
            BaseWrapper res = this.FindResource(node, false);
            res.EnsureVisible();
            res.TreeView.SelectedNode = res;
        }

        public void Merge()
        {
            CHR0Node external = null;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "CHR0 Raw Animation (*.chr0)|*.chr0";
            o.Title = "Please select an animation to merge with.";
            if (o.ShowDialog() == DialogResult.OK)
            {
                if ((external = (CHR0Node)NodeFactory.FromFile(null, o.FileName)) != null)
                {
                    ((CHR0Node)_resource).MergeWith(external);
                    BaseWrapper res = this.FindResource(_resource, false);
                    res.EnsureVisible();
                    res.TreeView.SelectedNode = res;
                }
            }
        }
        
        public void Append()
        {
            CHR0Node external = null;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "CHR0 Raw Animation (*.chr0)|*.chr0";
            o.Title = "Please select an animation to append.";
            if (o.ShowDialog() == DialogResult.OK)
            {
                if ((external = (CHR0Node)NodeFactory.FromFile(null, o.FileName)) != null)
                {
                    ((CHR0Node)_resource).Append(external);
                    BaseWrapper res = this.FindResource(_resource, false);
                    res.EnsureVisible();
                    res.TreeView.SelectedNode = res;
                }
            }
        }
    }
}
