using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.REL)]
    class RELWrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static RELWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("Convert Stage Module", null, ConvertAction, Keys.Control | Keys.C));
            _menu.Items.Add(new ToolStripMenuItem("Apply Relocations", null, RelocateAction));
            _menu.Items.Add(new ToolStripMenuItem("Relocate Self", null, RelocateSelfAction));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Open Constructor Function", null, ConstructorAction));
            _menu.Items.Add(new ToolStripMenuItem("Open Destructor Function", null, DestructorAction));
            _menu.Items.Add(new ToolStripMenuItem("Open Unresolved Function", null, UnresolvedAction));
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
        protected static void ConvertAction(object sender, EventArgs e) { GetInstance<RELWrapper>().Convert(); }
        protected static void RelocateAction(object sender, EventArgs e) { GetInstance<RELWrapper>().Relocate(); }
        protected static void RelocateSelfAction(object sender, EventArgs e) { GetInstance<RELWrapper>().RelocateSelf(); }
        protected static void ConstructorAction(object sender, EventArgs e) { GetInstance<RELWrapper>().Constructor(); }
        protected static void DestructorAction(object sender, EventArgs e) { GetInstance<RELWrapper>().Destructor(); }
        protected static void UnresolvedAction(object sender, EventArgs e) { GetInstance<RELWrapper>().Unresolved(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[2].Enabled = _menu.Items[9].Enabled = _menu.Items[10].Enabled = _menu.Items[12].Enabled = _menu.Items[13].Enabled = _menu.Items[16].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            RELWrapper w = GetInstance<RELWrapper>();
            _menu.Items[2].Enabled = (w._resource as ModuleNode).AppliedModule != w._resource;
            _menu.Items[9].Enabled = _menu.Items[16].Enabled = w.Parent != null;
            _menu.Items[10].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[12].Enabled = w.PrevNode != null;
            _menu.Items[13].Enabled = w.NextNode != null;
        }

        #endregion
        
        public RELWrapper() { ContextMenuStrip = _menu; }

        public void Convert()
        {
            using (StageModuleConverter dlg = new StageModuleConverter())
            {
                dlg.Path = _resource.FilePath;
                if (dlg.ShowDialog(null) == DialogResult.OK)
                {
                    _resource.ReplaceRaw(dlg.ToFileMap());
                    _resource.Name = dlg.OutputName;
                }
            }
        }

        public void Relocate()
        {
            RELNode r = _resource as RELNode;
            string file;
            int index = Program.OpenFile(FileFilters.REL, out file);
            if (index > 0)
            {
                ResourceNode x = NodeFactory.FromFile(null, file);
                if (x is RELNode)
                {
                    if (r.ApplyRelocations(x as RELNode))
                        MessageBox.Show("Relocations have been applied.");
                    else
                        MessageBox.Show("No relocations for this module were found.");
                }
            }
        }

        public void RelocateSelf()
        {
            RELNode r = _resource as RELNode;
            r.ApplyRelocations();
        }

        public void Constructor()
        {
            RELNode r = _resource as RELNode;
            if (r._prologReloc != null)
            {
                ModuleDataNode s = r._prologReloc._section;

                foreach (SectionEditor l in SectionEditor._openedSections)
                    if (l._section == s)
                    {
                        l.Focus();
                        l.Position = r._prologReloc._index * 4;
                        l.hexBox1.Focus();
                        return;
                    }

                SectionEditor e = new SectionEditor(s as ModuleSectionNode);
                e.Show();
                e.Position = r._prologReloc._index * 4;
                e.hexBox1.Focus();
            }
            else
                MessageBox.Show("This module has no constructor function.");
        }

        public void Destructor()
        {
            RELNode r = _resource as RELNode;
            if (r._epilogReloc != null)
            {
                ModuleDataNode s = r._epilogReloc._section;

                foreach (SectionEditor l in SectionEditor._openedSections)
                    if (l._section == s)
                    {
                        l.Focus();
                        l.Position = r._epilogReloc._index * 4;
                        l.hexBox1.Focus();
                        return;
                    }

                SectionEditor e = new SectionEditor(s as ModuleSectionNode);
                e.Show();
                e.Position = r._epilogReloc._index * 4;
                e.hexBox1.Focus();
            }
            else
                MessageBox.Show("This module has no destructor function.");
        }

        public void Unresolved()
        {
            RELNode r = _resource as RELNode;
            if (r._unresReloc != null)
            {
                ModuleDataNode s = r._unresReloc._section;

                foreach (SectionEditor l in SectionEditor._openedSections)
                    if (l._section == s)
                    {
                        l.Focus();
                        l.Position = r._unresReloc._index * 4;
                        l.hexBox1.Focus();
                        return;
                    }

                SectionEditor e = new SectionEditor(s as ModuleSectionNode);
                e.Show();
                e.Position = r._unresReloc._index * 4;
                e.hexBox1.Focus();
            }
            else
                MessageBox.Show("This module has no unresolved function.");
        }

        public override string ExportFilter { get { return FileFilters.REL; } }
    }

    [NodeWrapper(ResourceType.RELSection)]
    class RELSectionWrapper : GenericWrapper
    {
        #region Menu
        private static ContextMenuStrip _menu;
        static RELSectionWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&Open in Memory Viewer", null, OpenAction, Keys.Control | Keys.O));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export Raw", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Export Initialized", null, Export2Action, Keys.Control | Keys.X));
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
        protected static void OpenAction(object sender, EventArgs e) { GetInstance<RELSectionWrapper>().Open(); }
        protected static void Export2Action(object sender, EventArgs e) { GetInstance<RELSectionWrapper>().Export2(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            //_menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = _menu.Items[7].Enabled = _menu.Items[10].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            RELSectionWrapper w = GetInstance<RELSectionWrapper>();
            //_menu.Items[3].Enabled = _menu.Items[10].Enabled = w.Parent != null;
            //_menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            //_menu.Items[6].Enabled = w.PrevNode != null;
            //_menu.Items[7].Enabled = w.NextNode != null;
        }

        #endregion

        public RELSectionWrapper() { ContextMenuStrip = _menu; }

        public void Export2()
        {
            if (_modelViewerOpen)
                return;

            string outPath;
            int index = Program.SaveFile(ExportFilter, Text, out outPath);
            if (index != 0)
                (_resource as ModuleSectionNode).ExportInitialized(outPath);
        }

        public void Open()
        {
            ModuleSectionNode r = _resource as ModuleSectionNode;

            foreach (SectionEditor l in SectionEditor._openedSections)
                if (l._section == r)
                {
                    l.Focus();
                    return;
                }

            new SectionEditor(r).Show();
        }

        public override string ExportFilter { get { return FileFilters.Raw; } }
    }
}
