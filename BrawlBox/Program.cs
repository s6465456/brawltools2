using System;
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

        //public static string getNextWord(string str, bool t)
        //{
        //    string s = str;
        //    int i = Helpers.FindFirstNotDual(str, 0, ' ', ',');
        //    if (i > 0)
        //        s = str.Substring(i);
        //    i = Helpers.FindFirst(s, 0, t ? ' ' : '(');
        //    if (i > 0)
        //        s = s.Substring(0, i);
        //    return s;
        //}

        //public static string removePhrase(string str, string phrase)
        //{
        //    string s = str;
        //    Top:
        //    int index = s.IndexOf(phrase);
        //    if (index >= 0)
        //    {
        //        s = s.Substring(0, index) + s.Substring(index + phrase.Length);
        //        goto Top;
        //    }
        //    return s;
        //}

        //public static int FindFirstCommaSplit(string str)
        //{
        //    for (int i = 0; i < str.Length; i++)
        //        if (str[i] == ',')
        //            if (str[i - 1] != ',' && str[i - 1] != '[')
        //                if (str[i + 1] != ',' && str[i + 1] != ']')
        //                    return i;

        //    return -1;
        //}

        //public static List<string> parseInputNames(string str)
        //{
        //    List<string> input = new List<string>();
        //    string s = str;
        //    int i = Helpers.FindFirst(str, 0, '(');
        //    if (i > 0)
        //    {
        //        s = str.Substring(i + 1);
        //        i = Helpers.FindFirst(s, 0, ')');
        //        if (i > 0)
        //        {
        //            s = removePhrase(removePhrase(removePhrase(s.Substring(0, i), "[OutAttribute] "), "[InAttribute] "), "[InAttribute, OutAttribute] ");
        //            int h1, h2;
        //            string name = "";
        //            while(true)
        //            {
        //                h2 = FindFirstCommaSplit(s);
        //                string v = h2 >= 0 ? s.Substring(0, h2) : s;
        //                h1 = Helpers.FindLast(v, 0, ' ');
        //                name = v.Substring(h1 + 1);
        //                if (Helpers.FindCount(v, 0, ' ') == 2)
        //                    name = getNextWord(v, true) + " " + name;
        //                input.Add(name);
        //                if (h2 < 0) break;
        //                s = s.Substring(h2 + 2);
        //            }

        //        }
        //    }
        //    return input;
        //}

        //public static string name = "";
        //private static bool EqualsName(string s)
        //{
        //    if (s == name)
        //        return true;
        //    else
        //        return false;
        //}

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                //List<string> values = new List<string>();

                //StreamReader sr = null;
                //string line = "";
                //string loc = Application.StartupPath + "/ppc.txt";
                //if (File.Exists(loc))
                //    using (sr = new StreamReader(loc))
                //        for (int i = 0; !sr.EndOfStream; i++, line = sr.ReadLine())
                //        {
                //            if (String.IsNullOrEmpty(line)) continue;
                //            string v = line.Substring(12);
                //            int s = Helpers.FindFirst(v, 0, '(');
                //            string name = v.Substring(0, s - 1);
                //            int g = Helpers.FindFirst(v, 0, ')');
                //            string desc = v.Substring(s + 1, g - (s + 1));
                //            values.Add(name);
                //            values.Add(desc);
                //        }

                //for (int i = 0; i < values.Count; i += 2)
                //    Console.WriteLine("info.Add(new PPCOpCodeInfo(0x00000000, \"" + values[i] + "\", \"" + values[i + 1] + "\"));");
                
                //for (int i = 0; i < values.Count; i += 2)
                //    Console.WriteLine("public const uint " + values[i] + " = 0x00000000;");

                //List<string> funcNames = new List<string>();
                //List<string> classes = new List<string>();
                //List<int> spaces = new List<int>();
                //StreamReader sr = null;
                //string line = "";
                //string loc = Application.StartupPath + "/GL.cs";
                //string output1 = Application.StartupPath + "/glOut1.txt";
                //string output2 = Application.StartupPath + "/glOut2.txt";
                //using (StreamWriter file1 = new StreamWriter(output1))
                //using (StreamWriter file2 = new StreamWriter(output2))
                //{
                //    if (File.Exists(loc))
                //        using (sr = new StreamReader(loc))
                //            for (int i = 0; !sr.EndOfStream; i++, line = sr.ReadLine())
                //            {
                //                int x = MParams.FindFirstNot(line, 0, ' ');
                //                if (x > 0) line = line.Substring(x);
                //                if (x >= 0)
                //                {
                //                    if (line == "public static ")
                //                    {
                //                        string func = sr.ReadLine();
                //                        x = MParams.FindFirstNot(func, 0, ' ');
                //                        if (x > 0) func = func.Substring(x);
                //                        string type = func.Substring(0, MParams.FindFirst(func, 0, '('));
                //                        int l = MParams.FindLast(type, 0, ' ');
                //                        name = type.Substring(l + 1);
                //                        funcNames.Add(name);
                //                        if (name.EndsWith(">")) continue;
                //                        int ct = funcNames.FindAll(EqualsName).Count;
                //                        type = type.Substring(0, l);
                //                        string nP = removePhrase(removePhrase(removePhrase(func.Substring(type.Length + 1), "[OutAttribute] "), "[InAttribute] "), "[InAttribute, OutAttribute] ");
                //                        file1.WriteLine("internal abstract " + type + " gl" /*+ (ct > 1 ? ct.ToString() : "")*/ + nP + ";");
                //                        string lines = "internal override " + type + " gl" /*+ (ct > 1 ? ct.ToString() : "")*/ + nP + " { " + (!type.Contains("void") ? "return " : "") + "OpenTK.Graphics.OpenGL.GL.";
                //                        for (int t = 0; t < classes.Count; t++)
                //                            lines += classes[t] + ".";
                //                        lines += name + "(";
                //                        List<string> names = parseInputNames(func);
                //                        for (int t = 0; t < names.Count; t++)
                //                            lines += names[t] + (t != names.Count - 1 ? ", " : "");
                //                        file2.WriteLine(lines + "); }");
                //                    }
                //                    else if (line.StartsWith("public static partial class"))
                //                    {
                //                        classes.Add(line.Substring(28));
                //                        spaces.Add(x);
                //                    }
                //                    else if (line == "}")
                //                        for (int r = 0; r < classes.Count && r < spaces.Count; r++)
                //                            if (spaces[r] == x)
                //                            {
                //                                classes.RemoveAt(r);
                //                                spaces.RemoveAt(r);
                //                            }
                //                }
                //            }
                //}

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
            //catch (Exception x) { Program.Say(x.ToString()); }
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

            try
            {
                if ((_rootNode = NodeFactory.FromFile(null, _rootPath = path)) != null)
                {
                    MainForm.Instance.Reset();
                    return true;
                }
                else
                    Say("Unable to recognize input file.");
            }
            //catch (Exception x) { Say(x.ToString()); }
            finally { }

            Close();
            return false;
        }

        public static bool Save()
        {
            if (_rootNode != null)
            {
                //try
                //{
                    if (_rootPath == null)
                        return SaveAs();

                    _rootNode.Merge(Control.ModifierKeys == (Keys.Control | Keys.Shift));
                    _rootNode.Export(_rootPath);
                    return true;
                //}
                //catch (Exception x) { Say(x.Message); }
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
            //try
            //{
                if (_openDlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = _openDlg.FileName;
                    if ((categorize) && (_openDlg.FilterIndex == 1))
                        return CategorizeFilter(_openDlg.FileName, filter);
                    else
                        return _openDlg.FilterIndex;
                }
            //}
            //catch (Exception ex) { Say(ex.ToString()); }
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
                try
                {
                    GenericWrapper w = MainForm.Instance.RootNode as GenericWrapper;
                    string path = w.Export();
                    if (path != null)
                    {
                        _rootPath = path;
                        MainForm.Instance.UpdateName();
                        return true;
                    }
                }
                //catch (Exception x) { Say(x.Message); }
                finally { }
            }
            return false;
        }
    }
}
