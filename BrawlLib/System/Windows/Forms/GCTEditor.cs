﻿using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public partial class GCTEditor : Form
    {
        public GCTEditor()
        {
            InitializeComponent();
            txtCode.TextChanged += txtCode_TextChanged;

            _updating = true;
            checkBox1.Checked = BrawlLib.Properties.Settings.Default.SaveGCTWithInfo;
            _updating = false;
        }

        private GCTCodeEntryNode _codeEntry;

        private GCTNode _targetNode;
        public GCTNode TargetNode
        {
            get { return _targetNode; }
            set
            {
                if (_targetNode != null && _targetNode.IsDirty)
                {
                    DialogResult res = MessageBox.Show("Save changes?", "Closing", MessageBoxButtons.YesNoCancel);
                    if (((res == DialogResult.Yes) && (!Save(_targetNode, checkBox1.Checked))) || (res == DialogResult.Cancel))
                        return;
                }

                _updating = true;
                txtCode.Text = "";
                txtName.Text = "";
                txtDesc.Text = "";
                txtID.Text = "";
                txtPath.Text = "";
                textBox1.Text = "";
                lstCodes.Items.Clear();
                if ((_targetNode = value) != null)
                {
                    txtID.Text = _targetNode._name;
                    txtName.Text = _targetNode.GameName;
                    lstCodes.Items.AddRange(_targetNode.Children.Select(s => new ListViewItem() { Text = s.Name, Checked = true, Tag = s }).ToArray());
                    if (_targetNode.Children.Count > 0)
                        lstCodes.Items[0].Selected = true;
                }
                _updating = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            TargetNode = null;

            if (TargetNode != null)
                e.Cancel = true;

            BrawlLib.Properties.Settings.Default.Save();

            base.OnClosing(e);
        }

        public GCTNode LoadGCT()
        {
            if (dlgOpen.ShowDialog(this) != DialogResult.OK)
                return null;

            return LoadGCT(dlgOpen.FileName);
        }
        public GCTNode LoadGCT(string path)
        {
            GCTNode node;

            if (Path.GetExtension(path).ToUpper() == ".TXT")
            {
                txtPath.Text = path;
                node = GCTNode.FromTXT(path);
                return node;
            }
            else if ((node = GCTNode.IsParsable(path)) != null)
            {
                txtPath.Text = path;
                return node;
            }
            
            return null;
        }

        public bool Save(GCTNode node, bool writeInfo)
        {
            try
            {
                if (String.IsNullOrEmpty(node._origPath))
                    return SaveAs(node, writeInfo);

                node.Children.Clear();
                foreach (ListViewItem e in lstCodes.Items)
                    if (e.Checked)
                        node.Children.Add(e.Tag as GCTCodeEntryNode);

                node._writeInfo = writeInfo;
                node.Merge();
                node.Export(TargetNode._origPath);
                node.IsDirty = false;
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool SaveAs(GCTNode node, bool writeInfo)
        {
            if (dlgSave.ShowDialog(this) != DialogResult.OK)
                return false;

            string path = dlgSave.FileName;
            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    node.Children.Clear();
                    foreach (ListViewItem e in lstCodes.Items)
                        if (e.Checked)
                            node.Children.Add(e.Tag as GCTCodeEntryNode);

                    if (Path.GetExtension(path).ToUpper() == ".TXT")
                        node.ToTXT(path);
                    else
                    {
                        node._writeInfo = writeInfo;
                        node.Merge();
                        node.Export(node._origPath = path);
                        node.IsDirty = false;
                        txtPath.Text = path;
                    }
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        private void btnBrowse_Click(object sender, EventArgs e) { GCTNode node = LoadGCT(); if (node != null) TargetNode = node; }
        private void btnSaveAs_Click(object sender, EventArgs e) { SaveAs(TargetNode, checkBox1.Checked); }
        private void btnSave_Click(object sender, EventArgs e) { Save(TargetNode, checkBox1.Checked); }
        private void btnClose_Click(object sender, EventArgs e) { TargetNode = null; }

        bool _updating = false;
        public int _codeEntrySavedIndex = -1;
        private void lstCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel1.Enabled = lstCodes.SelectedIndices.Count > 0)
            {
                _updating = true;
                _codeEntry = lstCodes.Items[lstCodes.SelectedIndices[0]].Tag as GCTCodeEntryNode;
                txtDesc.Text = _codeEntry._description;
                txtCode.Text = _codeEntry.DisplayLines;
                textBox1.Text = _codeEntry._name;

                string s = _codeEntry.LinesNoSpaces;
                int i = 0;
                _codeEntrySavedIndex = -1;
                foreach (CodeStorage c in BrawlLib.Properties.Settings.Default.Codes)
                {
                    if (c._code == s)
                    {
                        btnAddRemoveCode.Text = "Forget Code";
                        _codeEntrySavedIndex = i;
                        break;
                    }
                    i++;
                }
                if (_codeEntrySavedIndex == -1)
                    btnAddRemoveCode.Text = "Remember Code";

                _updating = false;
            }
            status.Text = "";
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            string s = txtID.Text;

            bool temp = false;
            if (TargetNode == null)
            {
                TargetNode = new GCTNode();
                temp = true;
            }

            TargetNode.Name = txtID.Text = s;
            if (temp)
                txtID.Select(txtID.Text.Length, 0);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            string s = txtName.Text;

            bool temp = false;
            if (TargetNode == null)
            {
                TargetNode = new GCTNode();
                temp = true;
            }

            TargetNode.GameName = txtName.Text = s;
            if (temp)
                txtName.Select(txtName.Text.Length, 0);
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry == null || _updating)
                return;

            _codeEntry._description = txtDesc.Text;

            if (_codeEntrySavedIndex != -1)
                BrawlLib.Properties.Settings.Default.Codes[_codeEntrySavedIndex]._description = _codeEntry._description;
        }

        private void btnDeleteCode_Click(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry == null || _updating)
                return;

            _codeEntry.Remove();
            int i = lstCodes.SelectedIndices[0];
            lstCodes.Items[i].Remove();
            i = i.Clamp(-1, TargetNode.Children.Count - 1);
            lstCodes.Items[i].Selected = true;
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (_updating)
                return;

            if (TargetNode == null)
                TargetNode = new GCTNode();

            GCTCodeEntryNode n = new GCTCodeEntryNode() { _name = "New Code" };
            TargetNode.AddChild(n);
            lstCodes.Items.Add(new ListViewItem() { Text = n.Name, Checked = true, Tag = n });
        }

        void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry == null || _updating)
                return;

            int i = txtCode.textBox.SelectionStart;
            txtCode.Text = txtCode.Text.ToUpper();
            txtCode.textBox.Select(i, 0);

            List<GCTCodeLine> lines;
            if ((txtCode._borderColor = CheckCode(out lines)) == Color.Green)
            {
                _codeEntry._lines = lines.ToArray();

                if (_codeEntrySavedIndex != -1)
                    BrawlLib.Properties.Settings.Default.Codes[_codeEntrySavedIndex]._code = _codeEntry.LinesNoSpaces;
            }

            txtCode.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry  == null || _updating)
                return;

            _codeEntry.Name = textBox1.Text;

            if (_codeEntrySavedIndex != -1)
                BrawlLib.Properties.Settings.Default.Codes[_codeEntrySavedIndex]._name = _codeEntry._name;
        }

        public Color CheckCode(out List<GCTCodeLine> lines)
        {
            lines = new List<GCTCodeLine>();

            string code = txtCode.Text;
            string[] values = code.Split('\n');
            int x = 1;
            foreach (string s in values)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                string[] values2 = s.Split(' ');
                if (values2.Length < 2)
                {
                    status.Text = String.Format("Problem on line {0}: Not enough values", x);
                    return Color.Red;
                }
                else if (values2[0].Length != 8 || values2[1].Length != 8)
                {
                    status.Text = String.Format("Problem on line {0}: Values must have length of 8", x);
                    return Color.Red;
                }
                else
                {
                    if (values2.Length > 2)
                        for (int i = 2; i < values2.Length; i++)
                            if (!String.IsNullOrWhiteSpace(values2[i]))
                            {
                                status.Text = String.Format("Problem on line {0}: Too many values", x);
                                return Color.Red;
                            }

                    uint val1, val2;
                    if (!uint.TryParse(values2[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val1))
                    {
                        status.Text = String.Format("Problem on line {0}: 1st value is not a hex integer", x);
                        return Color.Red;
                    }
                    else if (!uint.TryParse(values2[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val2))
                    {
                        status.Text = String.Format("Problem on line {0}: 2nd value is not a hex integer", x);
                        return Color.Red;
                    }
                    else
                        lines.Add(new GCTCodeLine(val1, val2));
                }
                x++;
            }

            status.Text = "Code successfully parsed";
            return Color.Green;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _updating = true;
            if (!checkBox1.Checked)
                if (MessageBox.Show(this, "Are you sure you don't want the info written in the GCT?\nOnly codes you have set to remember will be readable.", "Are you sure?", MessageBoxButtons.YesNo) == Forms.DialogResult.No)
                    checkBox1.Checked = true;
            _updating = false;

            BrawlLib.Properties.Settings.Default.SaveGCTWithInfo = checkBox1.Checked;
        }

        private void btnAddRemoveCode_Click(object sender, EventArgs e)
        {
            if (_codeEntrySavedIndex == -1)
            {
                CodeStorage c = new CodeStorage();

                c._code = _codeEntry.LinesNoSpaces;
                c._name = _codeEntry._name;
                c._description = _codeEntry._description;

                BrawlLib.Properties.Settings.Default.Codes.Add(c);
                _codeEntrySavedIndex = BrawlLib.Properties.Settings.Default.Codes.Count - 1;
                btnAddRemoveCode.Text = "Forget Code";
            }
            else
            {
                BrawlLib.Properties.Settings.Default.Codes.RemoveAt(_codeEntrySavedIndex);

                _codeEntrySavedIndex = -1;
                btnAddRemoveCode.Text = "Remember Code";
            }
        }

        private void rememberAllCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_targetNode == null)
                return;
            
            foreach (GCTCodeEntryNode r in _targetNode.Children)
            {
                string c = r.LinesNoSpaces;
                bool found = false;
                foreach (CodeStorage w in BrawlLib.Properties.Settings.Default.Codes)
                {
                    if (w._code == c)
                    {
                        w._name = r._name;
                        w._description = r._description;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    BrawlLib.Properties.Settings.Default.Codes.Add(new CodeStorage() { _name = r._name, _description = r._description, _code = r.LinesNoSpaces });
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_targetNode == null)
                return;

            foreach (GCTCodeEntryNode r in _targetNode.Children)
            {
                string c = r.LinesNoSpaces;
                int i = 0;
                foreach (CodeStorage w in BrawlLib.Properties.Settings.Default.Codes)
                {
                    if (w._code == c)
                        break;
                    i++;
                }
                if (i != BrawlLib.Properties.Settings.Default.Codes.Count)
                    BrawlLib.Properties.Settings.Default.Codes.RemoveAt(i);
            }
        }

        private void forgetAllCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to forget all codes?", "Are you sure?", MessageBoxButtons.YesNo) == Forms.DialogResult.Yes)
                if (MessageBox.Show("Are you really sure?", "Are you sure?", MessageBoxButtons.YesNo) == Forms.DialogResult.Yes)
                    BrawlLib.Properties.Settings.Default.Codes.Clear();
        }

        private void saveAllRememberedCodesToGCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GCTNode g = new GCTNode();
            foreach (CodeStorage w in BrawlLib.Properties.Settings.Default.Codes)
            {
                GCTCodeEntryNode r = new GCTCodeEntryNode();

                r.LinesNoSpaces = w._code;
                r._name = w._name;
                r._description = w._description;

                g.AddChild(r);
            }
            SaveAs(g, true);
        }

        private void loadCodesToRememberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GCTNode l = LoadGCT();
            if (l == null)
                return;

            foreach (GCTCodeEntryNode r in l.Children)
            {
                string c = r.LinesNoSpaces;
                bool found = false;
                foreach (CodeStorage w in BrawlLib.Properties.Settings.Default.Codes)
                {
                    if (w._code == c)
                    {
                        w._name = r._name;
                        w._description = r._description;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    BrawlLib.Properties.Settings.Default.Codes.Add(new CodeStorage() { _name = r._name, _description = r._description, _code = r.LinesNoSpaces });
            }

            l.Dispose();
        }

        private void loadRememberedCodesAsNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GCTNode node = new GCTNode();
            node._name = "CODE";
            node._gameName = "Code List";
            foreach (CodeStorage w in BrawlLib.Properties.Settings.Default.Codes)
                node.AddChild(new GCTCodeEntryNode() { _name = w._name, _description = w._description, LinesNoSpaces = w._code });
            TargetNode = node;
        }

        private void lstCodes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            TargetNode.SignalPropertyChange();
        }
    }
}