﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib;
using System.Windows.Forms;
using System.ComponentModel;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.RSARSound)]
    class RSARSoundWrapper : GenericWrapper
    {
        public override string ExportFilter { get { return ExportFilters.WAV; } }

        //#region Menu

        //private static ContextMenuStrip _menu;
        //static RSARSoundWrapper()
        //{
        //    _menu = new ContextMenuStrip();
        //    _menu.Items.Add(new ToolStripMenuItem("Change Sound", null, ChangeSoundAction, Keys.Control | Keys.W));
        //    _menu.Items.Add(new ToolStripSeparator());
        //    _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
        //    _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
        //    _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
        //    _menu.Items.Add(new ToolStripSeparator());
        //    _menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
        //    _menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
        //    _menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
        //    _menu.Items.Add(new ToolStripSeparator());
        //    _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
        //    _menu.Opening += MenuOpening;
        //    _menu.Closing += MenuClosing;
        //}
        //protected static void MoveUpAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().MoveUp(); }
        //protected static void MoveDownAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().MoveDown(); }
        //protected static void ExportAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().Export(); }
        //protected static void ReplaceAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().Replace(); }
        //protected static void RestoreAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().Restore(); }
        //protected static void ChangeSoundAction(object sender, EventArgs e) { GetInstance<RSARSoundWrapper>().ChangeSound(); }
        //protected static void DeleteAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().Delete(); }
        //protected static void RenameAction(object sender, EventArgs e) { GetInstance<GenericWrapper>().Rename(); }
        //private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        //{
        //    _menu.Items[2].Enabled = _menu.Items[3].Enabled = _menu.Items[5].Enabled = _menu.Items[6].Enabled = _menu.Items[9].Enabled = true;
        //}
        //private static void MenuOpening(object sender, CancelEventArgs e)
        //{
        //    RSARSoundWrapper w = GetInstance<RSARSoundWrapper>();
        //    _menu.Items[2].Enabled = _menu.Items[9].Enabled = w.Parent != null;
        //    _menu.Items[3].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
        //    _menu.Items[5].Enabled = w.PrevNode != null;
        //    _menu.Items[6].Enabled = w.NextNode != null;
        //}

        //#endregion
        
        //public RSARSoundWrapper() { ContextMenuStrip = _menu; }

        //public void ChangeSound()
        //{

        //}
    }
}
