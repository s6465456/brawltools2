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

namespace Ikarus
{
    public partial class MainForm : Form
    {
        private static MainForm _instance;
        public static MainForm Instance { get { return _instance == null ? _instance = new MainForm() : _instance; } }
        public static void Invalidate() { Instance._mainControl.ModelPanel.Invalidate(); }

        public MainForm()
        {
            InitializeComponent();
            Text = Program.AssemblyTitle;
            _instance = this;
        }

        private delegate bool DelegateOpenFile(String s);
        private DelegateOpenFile m_DelegateOpenFile;

        public void Reset()
        {
            UpdateName();
        }

        public void UpdateName()
        {
            Text = Program.AssemblyTitle;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!Program.Close()) 
                e.Cancel = true;

            base.OnClosing(e);
        }

        #region File Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { Close(); }
        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) { AboutForm.Instance.ShowDialog(this); }

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
