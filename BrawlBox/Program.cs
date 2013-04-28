﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using BrawlLib.IO;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Diagnostics;
using BrawlLib;

namespace BrawlBox
{
    static class Program
    {
        public static readonly string AssemblyTitle;
        public static readonly string AssemblyDescription;
        public static readonly string AssemblyCopyright;
        public static readonly string FullPath;

        private static OpenFileDialog _openDlg;
        private static SaveFileDialog _saveDlg;
        private static FolderBrowserDialog _folderDlg;

        private static ResourceNode _rootNode;
        public static ResourceNode RootNode { get { return _rootNode; } }
        private static string _rootPath;
        public static string RootPath { get { return _rootPath; } }

        static Program()
        {
            Application.EnableVisualStyles();

            AssemblyTitle = ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
            AssemblyDescription = ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
            AssemblyCopyright = ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
            FullPath = Process.GetCurrentProcess().MainModule.FileName;

            _openDlg = new OpenFileDialog();
            _saveDlg = new SaveFileDialog();
            _folderDlg = new FolderBrowserDialog();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length >= 1)
                    Open(args[0]);

                if (args.Length >= 2)
                {
                    ResourceNode target = ResourceNode.FindNode(RootNode, args[1], true);
                    if (target != null)
                        MainForm.Instance.TargetResource(target);
                    else
                        Say(String.Format("Error: Unable to find node or path '{0}'!", args[1]));
                }
                
                Application.Run(MainForm.Instance);
            }
            catch (Exception x) { Program.Say(x.ToString()); }
            finally { Close(true); }
        }

        public static void Say(string msg)
        {
            MessageBox.Show(msg);
        }

        public static bool New<T>() where T : ResourceNode
        {
            if (!Close())
                return false;

            _rootNode = Activator.CreateInstance<T>();
            _rootNode.Name = "NewTree";
            MainForm.Instance.Reset();

            return true;
        }

        public static bool Close() { return Close(false); }
        public static bool Close(bool force)
        {
            if (_rootNode != null)
            {
                if ((_rootNode.IsDirty) && (!force))
                {
                    DialogResult res = MessageBox.Show("Save changes?", "Closing", MessageBoxButtons.YesNoCancel);
                    if (((res == DialogResult.Yes) && (!Save())) || (res == DialogResult.Cancel))
                        return false;
                }

                _rootNode.Dispose();
                _rootNode = null;

                MainForm.Instance.Reset();
            }
            _rootPath = null;
            return true;
        }

        public static bool Open(string path)
        {
            if (!Close())
                return false;

            //#if !DEBUG
            try
            {
            //#endif
                if ((_rootNode = NodeFactory.FromFile(null, _rootPath = path)) != null)
                {
                    MainForm.Instance.Reset();
                    return true;
                }
                else
                    Say("Unable to recognize input file.");
            //#if !DEBUG
            }
            catch (Exception x) { Say(x.ToString()); }
            //finally { }
            //#endif
                Close();
            return false;
        }

        public static bool Save()
        {
            if (_rootNode != null)
            {
                //#if !DEBUG
                try
                {
                //#endif
                    if (_rootPath == null)
                        return SaveAs();

                    _rootNode.Merge(Control.ModifierKeys == (Keys.Control | Keys.Shift));
                    _rootNode.Export(_rootPath);
                    _rootNode.IsDirty = false;
                    return true;
                //#if !DEBUG
                }
                catch (Exception x) { Say(x.Message); }
                //#endif
            }
            return false;
        }

        public static string ChooseFolder()
        {
            if (_folderDlg.ShowDialog() == DialogResult.OK)
                return _folderDlg.SelectedPath;
            return null;
        }

        public static int OpenFile(string filter, out string fileName) { return OpenFile(filter, out fileName, true); }
        public static int OpenFile(string filter, out string fileName, bool categorize)
        {
            _openDlg.Filter = filter;
            //#if !DEBUG
            try
            {
            //#endif
                if (_openDlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = _openDlg.FileName;
                    if ((categorize) && (_openDlg.FilterIndex == 1))
                        return CategorizeFilter(_openDlg.FileName, filter);
                    else
                        return _openDlg.FilterIndex;
                }
            //#if !DEBUG
            }
            catch (Exception ex) { Say(ex.ToString()); }
            //#endif
            fileName = null;
            return 0;
            
        }
        public static int SaveFile(string filter, string name, out string fileName) { return SaveFile(filter, name, out fileName, true); }
        public static int SaveFile(string filter, string name, out string fileName, bool categorize)
        {
            int fIndex = 0;
            fileName = null;

            _saveDlg.Filter = filter;
            _saveDlg.FileName = name;
            _saveDlg.FilterIndex = 1;
            if (_saveDlg.ShowDialog() == DialogResult.OK)
            {
                if ((categorize) && (_saveDlg.FilterIndex == 1) && (Path.HasExtension(_saveDlg.FileName)))
                    fIndex = CategorizeFilter(_saveDlg.FileName, filter);
                else
                    fIndex = _saveDlg.FilterIndex;

                //Fix extension
                fileName = ApplyExtension(_saveDlg.FileName, filter, fIndex - 1);
            }

            return fIndex;
        }
        public static int CategorizeFilter(string path, string filter)
        {
            string ext = "*" + Path.GetExtension(path);

            string[] split = filter.Split('|');
            for (int i = 3; i < split.Length; i += 2)
                foreach (string s in split[i].Split(';'))
                    if (s.Equals(ext, StringComparison.OrdinalIgnoreCase))
                        return (i + 1) / 2;
            return 1;
        }
        public static string ApplyExtension(string path, string filter, int filterIndex)
        {
            int tmp;
            if ((Path.HasExtension(path)) && (!int.TryParse(Path.GetExtension(path), out tmp)))
                return path;

            int index = filter.IndexOfOccurance('|', filterIndex * 2);
            if (index == -1)
                return path;

            index = filter.IndexOf('.', index);
            int len = Math.Max(filter.Length, filter.IndexOfAny(new char[] { ';', '|' })) - index;

            string ext = filter.Substring(index, len);

            if (ext.IndexOf('*') >= 0)
                return path;

            return path + ext;
        }

        internal static bool SaveAs()
        {
            if (MainForm.Instance.RootNode is GenericWrapper)
            {
                //#if !DEBUG
                try
                {
                //#endif
                    GenericWrapper w = MainForm.Instance.RootNode as GenericWrapper;
                    string path = w.Export();
                    if (path != null)
                    {
                        _rootPath = path;
                        MainForm.Instance.UpdateName();
                        w.ResourceNode.IsDirty = false;
                        return true;
                    }
                //#if !DEBUG
                }
                catch (Exception x) { Say(x.Message); }
                //finally { }
                //#endif
            }
            return false;
        }
    }
}
