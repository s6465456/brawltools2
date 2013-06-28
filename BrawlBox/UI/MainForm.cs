﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Imaging;
using System.Reflection;
using BrawlLib.IO;
using System.Audio;
using BrawlLib.Wii.Audio;
using BrawlLib.OpenGL;
using System.Diagnostics;

namespace BrawlBox
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        public static MainForm Instance { get { return _instance == null ? _instance = new MainForm() : _instance; } }

        private BaseWrapper _root;
        public BaseWrapper RootNode { get { return _root; } }

        private SettingsDialog _settings;
        private SettingsDialog Settings { get { return _settings == null ? _settings = new SettingsDialog() : _settings; } }
        
        public MainForm()
        {
            InitializeComponent();
            Text = Program.AssemblyTitle;
//#if _DEBUG
//            Text += " - DEBUG";
//#endif
            soundPackControl1._grid = propertyGrid1;
            soundPackControl1.lstSets.SmallImageList = ResourceTree.Images;
            msBinEditor1.Dock =
            animEditControl.Dock =
            texAnimEditControl.Dock =
            shpAnimEditControl.Dock =
            soundPackControl1.Dock =
            audioPlaybackPanel1.Dock =
            clrControl.Dock =
            visEditor.Dock =
            scN0CameraEditControl1.Dock =
            scN0LightEditControl1.Dock =
            scN0FogEditControl1.Dock =
            ppcDisassembler1.Dock =
            modelPanel1.Dock =
            previewPanel2.Dock =
            videoPlaybackPanel1.Dock =
            DockStyle.Fill;
            m_DelegateOpenFile = new DelegateOpenFile(Program.Open);
            _instance = this;
            modelPanel1._forceNoSelection = true;
            _currentControl = modelPanel1;
        }

        private delegate bool DelegateOpenFile(String s);
        private DelegateOpenFile m_DelegateOpenFile;

        public void Reset()
        {
            _root = null;
            resourceTree.SelectedNode = null;
            resourceTree.Clear();

            if (Program.RootNode != null)
            {
                _root = BaseWrapper.Wrap(this, Program.RootNode);
                resourceTree.BeginUpdate();
                resourceTree.Nodes.Add(_root);
                resourceTree.SelectedNode = _root;
                _root.Expand();
                resourceTree.EndUpdate();

                closeToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;

                Program.RootNode._mainForm = this;
            }
            else
            {
                closeToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
            }

            UpdateName();
        }

        public void UpdateName()
        {
            if (Program.RootPath != null)
                Text = String.Format("{0} - {1}", Program.AssemblyTitle, Program.RootPath);
            else
                Text = Program.AssemblyTitle;

//#if DEBUG
//            Text += " - DEBUG";
//#endif
        }

        public void TargetResource(ResourceNode n)
        {
            if (_root != null)
                resourceTree.SelectedNode = _root.FindResource(n, true);
        }

        public Control _currentControl = null;
        private Control _secondaryControl = null;
        public void resourceTree_SelectionChanged(object sender, EventArgs e)
        {
            audioPlaybackPanel1.TargetSource = null;
            animEditControl.TargetSequence = null;
            texAnimEditControl.TargetSequence = null;
            shpAnimEditControl.TargetSequence = null;
            msBinEditor1.CurrentNode = null;
            soundPackControl1.TargetNode = null;
            clrControl.ColorSource = null;
            visEditor.TargetNode = null;
            scN0CameraEditControl1.TargetSequence = null;
            scN0LightEditControl1.TargetSequence = null;
            scN0FogEditControl1.TargetSequence = null;
            ppcDisassembler1.TargetNode = null;
            modelPanel1.ClearAll();
            
            Control newControl = null;
            Control newControl2 = null;

            BaseWrapper w;
            ResourceNode node = null;
            bool disable2nd = false;
            if ((resourceTree.SelectedNode is BaseWrapper) && ((node = (w = resourceTree.SelectedNode as BaseWrapper).ResourceNode) != null))
            {
                propertyGrid1.SelectedObject = node;

                if (node is THPNode)
                {
                    videoPlaybackPanel1.TargetSource = node as THPNode;
                    newControl = videoPlaybackPanel1;
                }
                else if (node is MSBinNode)
                {
                    msBinEditor1.CurrentNode = node as MSBinNode;
                    newControl = msBinEditor1;
                }
                else if (node is CHR0EntryNode)
                {
                    animEditControl.TargetSequence = node as CHR0EntryNode;
                    newControl = animEditControl;
                }
                else if (node is SRT0TextureNode)
                {
                    texAnimEditControl.TargetSequence = node as SRT0TextureNode;
                    newControl = texAnimEditControl;
                }
                else if (node is SHP0VertexSetNode)
                {
                    shpAnimEditControl.TargetSequence = node as SHP0VertexSetNode;
                    newControl = shpAnimEditControl;
                }
                else if (node is RSARNode)
                {
                    soundPackControl1.TargetNode = node as RSARNode;
                    newControl = soundPackControl1;
                }
                else if (node is VIS0EntryNode)
                {
                    visEditor.TargetNode = node as VIS0EntryNode;
                    newControl = visEditor;
                }
                else if (node is SCN0CameraNode)
                {
                    scN0CameraEditControl1.TargetSequence = node as SCN0CameraNode;
                    newControl = scN0CameraEditControl1;
                }
                else if (node is SCN0LightNode)
                {
                    scN0LightEditControl1.TargetSequence = node as SCN0LightNode;
                    newControl = scN0LightEditControl1;
                    disable2nd = true;
                }
                else if (node is SCN0FogNode)
                {
                    scN0FogEditControl1.TargetSequence = node as SCN0FogNode;
                    newControl = scN0FogEditControl1;
                    disable2nd = true;
                }
                else if (node is ModuleDataNode && !(node as ModuleDataNode).HasNoCode)
                {
                    ppcDisassembler1.TargetNode = node as ModuleDataNode;
                    newControl = ppcDisassembler1;
                }
                else if (node is IAudioSource)
                {
                    audioPlaybackPanel1.TargetSource = node as IAudioSource;
                    IAudioStream[] sources = audioPlaybackPanel1.TargetSource.CreateStreams();
                    if (sources != null && sources.Length > 0 && sources[0] != null)
                        newControl = audioPlaybackPanel1;
                }
                else if (node is IImageSource)
                {
                    previewPanel2.RenderingTarget = ((IImageSource)node);
                    newControl = previewPanel2;
                }
                else if (node is IRenderedObject)
                    newControl = modelPanel1;

                if (node is IColorSource && !disable2nd)
                {
                    clrControl.ColorSource = node as IColorSource;
                    if (((IColorSource)node).ColorCount(0) > 0)
                        if (newControl != null)
                            newControl2 = clrControl;
                        else
                            newControl = clrControl;
                }

                if ((editToolStripMenuItem.DropDown = w.ContextMenuStrip) != null)
                    editToolStripMenuItem.Enabled = true;
                else
                    editToolStripMenuItem.Enabled = false;
            }
            else
            {
                propertyGrid1.SelectedObject = null;

                editToolStripMenuItem.DropDown = null;
                editToolStripMenuItem.Enabled = false;
            }

            if (_secondaryControl != newControl2)
            {
                if (_secondaryControl != null)
                {
                    _secondaryControl.Dock = DockStyle.Fill;
                    _secondaryControl.Visible = false;
                }
                _secondaryControl = newControl2;
                if (_secondaryControl != null)
                {
                    _secondaryControl.Dock = DockStyle.Right;
                    _secondaryControl.Visible = true;
                    _secondaryControl.Width = 340;
                }
            }
            if (_currentControl != newControl)
            {
                if (_currentControl != null)
                    _currentControl.Visible = false;
                _currentControl = newControl;
                if (_currentControl != null)
                    _currentControl.Visible = true;
            }
            if (_currentControl != null)
            {
                if (_secondaryControl != null)
                    _currentControl.Width = splitContainer2.Panel2.Width - _secondaryControl.Width;
                _currentControl.Dock = DockStyle.Fill;
            }

            //Model panel has to be loaded first to display model correctly
            if (_currentControl is ModelPanel)
            {
                if (node._children == null)
                {
                    node._children = new List<ResourceNode>();
                    node.OnPopulate();
                }

                if (node is MDL0Node)
                {
                    MDL0Node m = node as MDL0Node;
                    m._renderBones = false;
                    m._renderPolygons = true;
                    m._renderWireframe = false;
                    m._renderVertices = false;
                    m._renderBox = false;
                    m.ApplyCHR(null, 0);
                    m.ApplySRT(null, 0);
                }

                modelPanel1.AddTarget((IRenderedObject)node);

                Vector3 min, max;
                ((IRenderedObject)node).GetBox(out min, out max);
                modelPanel1.SetCamWithBox(min, max);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!Program.Close()) 
                e.Cancel = true;

            base.OnClosing(e);
        }

        private static string _filter = null;
        private static string InFilter 
        {
            get 
            {
                if (_filter != null)
                    return _filter;

                string f = "All Supported Formats (*.*)|";
                string f2 = "";
                string[] s = _inFilter.Split('|');
                for (int i = 0; i < s.Length; i++)
                {
                    if ((i & 1) != 0)
                    {
                        string[] t = s[i].Split(';');
                        string n = "";
                        for (int x = 0; x < t.Length; x++)
                        {
                            string l = t[x].Substring(t[x].IndexOf('.') + 1);
                            if (!l.Contains("*"))
                                n += (x != 0 ? ";" : "") + t[x];
                        }
                        f += (i != 1 ? ";" : "") + n;
                    }
                    else
                        f2 += String.Format("|{0} ({1})|{1}", s[i], s[i + 1]);
                }
                return _filter = f + f2;
            }
        }

        private static string _inFilter =
        "PAC File Archive|*.pac"
        +"|PCS Compressed File Archive|*.pcs"
        +"|Resource Package|*.brres;*.brtex;*.brmdl"
        +"|Palette|*.plt0"
        +"|Texture|*.tex0"
        +"|TPL Texture Archive|*.tpl"
        +"|Model|*.mdl0"
        +"|Model Animation|*.chr0"
        +"|Texture Animation|*.srt0"
        +"|Vertex Morph|*.shp0"
        +"|Texture Pattern|*.pat0"
        +"|Visibility Sequence|*.vis0"
        +"|Color Sequence|*.clr0"
        +"|Scene Settings|*.scn0"
        +"|Message Pack|*.msbin"
        +"|Audio Stream|*.brstm"
        +"|Sound Archive|*.brsar"
        +"|Sound Stream|*.brwsd"
        +"|Sound Bank|*.brbnk"
        +"|Sound Sequence|*.brseq"
        +"|Effect List|*.efls"
        +"|Effect Parameters|*.breff"
        +"|Effect Textures|*.breft"
        +"|ARC File Archive|*.arc"
        +"|SZS Compressed File Archive|*.szs"
        +"|Static Module|*.dol"
        +"|Relocatable Module|*.rel"
        +"|MRG Resource Group|*.mrg"
        +"|MRG Compressed Resource Group|*.mrgc"
        +"|THP Audio/Video|*.thp"
        //+"|Scan File|*.*"
        ;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inFile;
            int i = Program.OpenFile(InFilter, out inFile);
            if (i != 0)
            {
                if (i == 32)
                {
                    FileMap map = FileMap.FromFile(inFile, FileMapProtect.Read);
                    FileScanNode node = new FileScanNode();
                    Program.Scan(map, node);
                    if (node.Children.Count == 0)
                        MessageBox.Show("No formats recognized.");
                    else
                    {
                        Program._rootNode = node;
                        Program._rootPath = inFile;
                        node._list = node._children;
                        node.Initialize(null, new DataSource(map));
                        Reset();
                    }
                }
                else Program.Open(inFile);
            }
        }

        #region File Menu
        private void aRCArchiveToolStripMenuItem_Click(object sender, EventArgs e) { Program.New<ARCNode>(); }
        private void u8FileArchiveToolStripMenuItem_Click(object sender, EventArgs e) { Program.New<U8Node>(); }
        private void brresPackToolStripMenuItem_Click(object sender, EventArgs e) { Program.New<BRESNode>(); }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) { Program.Save(); }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) { Program.SaveAs(); }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) { Program.Close(); }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }
        #endregion

        private void fileResizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (FileResizer res = new FileResizer())
            //    res.ShowDialog();
        }
        private void settingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) { AboutForm.Instance.ShowDialog(this); }

        private void bRStmAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            if (Program.OpenFile("PCM Audio (*.wav)|*.wav", out path) > 0)
            {
                if (Program.New<RSTMNode>())
                {
                    using (BrstmConverterDialog dlg = new BrstmConverterDialog())
                    {
                        dlg.AudioSource = path;
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            Program.RootNode.Name = Path.GetFileNameWithoutExtension(dlg.AudioSource);
                            Program.RootNode.ReplaceRaw(dlg.AudioData);
                        }
                        else
                            Program.Close(true);
                    }
                }
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            //object o;
            //GoodColorDialog d;
            //if ((o = propertyGrid1.SelectedObject) is ResourceNode)
            //{
            //    ResourceNode n = (ResourceNode)o;
            //    if ((o = propertyGrid1.SelectedGridItem.Value) is RGBAPixel)
            //    {
            //        RGBAPixel p = (RGBAPixel)o;
            //        if ((d = new GoodColorDialog() { Color = Color.FromArgb(p.A, p.R, p.G, p.B) }).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //        {

            //        }
            //    }
            //}
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (a != null)
            {
                string s = null;
                for (int i = 0; i < a.Length; i++)
                {
                    s = a.GetValue(i).ToString();
                    this.BeginInvoke(m_DelegateOpenFile, new Object[] { s });
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=3T2HNHK5BM8LL&lc=US&item_name=Brawlbox&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted");
        }
    }
}
