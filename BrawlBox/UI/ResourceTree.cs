using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using System.Drawing;
using BrawlBox.Properties;

namespace BrawlBox
{
    public class ResourceTree : TreeView
    {
        private static ImageList _imgList;
        public static ImageList Images
        {
            get
            {
                if (_imgList == null)
                {
                    _imgList = new ImageList();
                    _imgList.ImageSize = new Size(24, 24);
                    _imgList.ColorDepth = ColorDepth.Depth32Bit;
                    _imgList.Images.AddRange(new Image[]{
                        Resources.Unknown, //0
                        Resources.Folder,
                        Resources.ARC,
                        Resources.BRES,
                        Resources.MSG,
                        Resources.TEX0, //5
                        Resources.PLT0,
                        Resources.MDL0,
                        Resources.CHR,
                        Resources.CLR,
                        Resources.VIS, //10
                        Resources.SHP,
                        Resources.SRT,
                        Resources.RSAR,
                        Resources.RSTM,
                        Resources.S, //15
                        Resources.G,
                        Resources.T,
                        Resources.B,
                        Resources.EFLS,
                        Resources.Coll, //20
                        Resources.REFF,
                        Resources.AI,
                        Resources.AIPD,
                        Resources.ATKD,
                        Resources.CE, //25
                        Resources.MDef,
                        Resources.Event,
                        Resources.REFT,
                        Resources.PAT,
                        Resources.IMG, //30
                        Resources.SCN0,
                        Resources.STPM,
                        Resources.TPL,
                        Resources.Palette,
                        Resources.U8, //35
                    });
                }
                return _imgList;
            }
        }

        public event EventHandler SelectionChanged;

        private bool _allowContextMenus = true;
        [DefaultValue(true)]
        public bool AllowContextMenus
        {
            get { return _allowContextMenus; }
            set { _allowContextMenus = value; }
        }

        private bool _allowIcons = false;
        [DefaultValue(false)]
        public bool ShowIcons
        {
            get { return _allowIcons; }
            set { ImageList = (_allowIcons = value) ? Images : null; }
        }

        private TreeNode _selected;
        new public TreeNode SelectedNode 
        { 
            get { return base.SelectedNode; } 
            set 
            {
                if (_selected == value)
                    return;

                _selected = base.SelectedNode = value;
                if (SelectionChanged != null)
                    SelectionChanged(this, null);
            } 
        }

        public ResourceTree()
        {
            this.SetStyle(ControlStyles.UserMouse, true);
        }

        public BaseWrapper FindResource(ResourceNode node)
        {
            BaseWrapper w = null;
            foreach (BaseWrapper n in Nodes)
                if ((w = n.FindResource(node, true)) != null)
                    break;
            return w;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204)
            {
                int x = (int)m.LParam & 0xFFFF, y = (int)m.LParam >> 16;

                TreeNode n = GetNodeAt(x, y);
                if (n != null)
                {
                    Rectangle r = n.Bounds;
                    r.X -= 25; r.Width += 25;
                    if (r.Contains(x, y))
                        SelectedNode = n;
                }

                m.Result = IntPtr.Zero;
                return;
            }
            else if (m.Msg == 0x205)
            {
                int x = (int)m.LParam & 0xFFFF, y = (int)m.LParam >> 16;

                if ((_allowContextMenus) && (_selected != null) && (_selected.ContextMenuStrip != null))
                {
                    Rectangle r = _selected.Bounds;
                    r.X -= 25; r.Width += 25;
                    if (r.Contains(x, y))
                        _selected.ContextMenuStrip.Show(this, x, y);
                }
            }

            base.WndProc(ref m);
        }

        public void Clear()
        {
            BeginUpdate();
            foreach (BaseWrapper n in Nodes) n.Unlink();
            Nodes.Clear();
            EndUpdate();
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            SelectedNode = e.Node;
            base.OnAfterSelect(e);
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            base.OnBeforeExpand(e);
            if (e.Node is BaseWrapper)
                ((BaseWrapper)e.Node).OnExpand();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (SelectedNode is BaseWrapper))
                ((BaseWrapper)SelectedNode).OnDoubleClick();
            else
                base.OnMouseDoubleClick(e);
        }

        protected override void Dispose(bool disposing) { Clear(); base.Dispose(disposing); }
    }
}
