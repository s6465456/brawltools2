﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.RSARSound)]
    class RSARSoundWrapper : GenericWrapper
    {
        public override string ExportFilter { get { return ExportFilters.WAV; } }

        #region Menu

        private static ContextMenuStrip _menu;
        static RSARSoundWrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("Change Sound", null, ChangeSoundAction, Keys.Control | Keys.W));
            _menu.Items.Add(new ToolStripMenuItem("View File", null, ViewFileAction, Keys.Control | Keys.V));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            //_menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            //_menu.Items.Add(new ToolStripSeparator());
            //_menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
            //_menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
            //_menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
            //_menu.Items.Add(new ToolStripSeparator());
            //_menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void ChangeSoundAction(object sender, EventArgs e) { GetInstance<RSARSoundWrapper>().ChangeSound(); }
        protected static void ViewFileAction(object sender, EventArgs e) { GetInstance<RSARSoundWrapper>().ViewFile(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[3].Enabled = _menu.Items[4].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            RSARSoundWrapper w = GetInstance<RSARSoundWrapper>();
            _menu.Items[3].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
        }

        #endregion

        public RSARSoundWrapper() { ContextMenuStrip = _menu; }

        public void ChangeSound()
        {
            RSARSoundNode n = _resource as RSARSoundNode;
            if (n.SoundDataNode != null)
            {
                if (n._dataNode._refs.Count > 1)
                {
                    string s = "The following entries also use this sound:\n";
                    foreach (RSARSoundNode x in n._dataNode._refs)
                        s += x.TreePath + "\n";
                    s += "\nDo you still want to replace this sound?";
                    if (MessageBox.Show(s, "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                string inPath;
                string FileType;
                int index = Program.OpenFile(ReplaceFilter, out inPath);
                if (index != 0)
                {
                    FileType = inPath.Substring(inPath.LastIndexOf(".") + 1);
                    n._dataNode.Sound.Replace(inPath);
                    n._dataNode.Sound.Parent.Parent.SignalPropertyChange();
                    n.RSARNode.SignalPropertyChange();
                    MainForm.Instance.resourceTree_SelectionChanged(null, null);
                }
            }
        }
        public void ViewFile()
        {
            RSARFileNode n;
            if ((n = (_resource as RSARSoundNode).SoundNode) == null)
                return;
            if (n is RSARExtFileNode)
            {
                if (File.Exists(n.FullExtPath)) 
                    Process.Start(n.FullExtPath);
            }
            else
                new EditRSARFileDialog().ShowDialog(MainForm.Instance, n);
        }
    }
}
