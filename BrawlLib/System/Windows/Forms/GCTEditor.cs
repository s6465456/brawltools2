using BrawlLib.SSBB.ResourceNodes;
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
                    if (((res == DialogResult.Yes) && (!Save())) || (res == DialogResult.Cancel))
                        return;
                }

                if ((_targetNode = value) == null)
                {
                    _updating = true;
                    txtPath.Text = "";
                    txtCode.Text = "";
                    txtName.Text = "";
                    txtDesc.Text = "";
                    txtID.Text = "";
                    txtPath.Text = "";
                    textBox1.Text = "";
                    lstCodes.DataSource = null;
                    _updating = false;
                }
                else
                {
                    _updating = true;
                    txtID.Text = _targetNode._name;
                    txtName.Text = _targetNode.GameName;
                    lstCodes.DataSource = _targetNode.Children;
                    _updating = false;
                    if (_targetNode.Children.Count > 0)
                        lstCodes.SelectedIndex = 0;
                }
                
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            TargetNode = null;

            if (TargetNode != null)
                e.Cancel = true;

            base.OnClosing(e);
        }

        public bool LoadGCT()
        {
            if (dlgOpen.ShowDialog(this) != DialogResult.OK)
                return false;

            return LoadGCT(dlgOpen.FileName);
        }
        public bool LoadGCT(string path)
        {
            GCTNode node;

            if (Path.GetExtension(path).ToUpper() == ".TXT")
            {
                txtPath.Text = path;
                TargetNode = GCTNode.FromTXT(path);
                return true;
            }
            else if ((node = GCTNode.IsParsable(path)) != null)
            {
                txtPath.Text = path;
                TargetNode = node;
                return true;
            }
            
            return false;
        }

        public bool Save()
        {
            try
            {
                if (String.IsNullOrEmpty(TargetNode._origPath))
                    return SaveAs();

                TargetNode.Merge();
                TargetNode._writeInfo = checkBox1.Checked;
                TargetNode.Export(TargetNode._origPath);
                TargetNode.IsDirty = false;
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool SaveAs()
        {
            if (dlgSave.ShowDialog(this) != DialogResult.OK)
                return false;

            string path = dlgSave.FileName;
            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    if (Path.GetExtension(path).ToUpper() == ".TXT")
                        TargetNode.ToTXT(path);
                    else
                    {
                        TargetNode.Merge();
                        TargetNode._writeInfo = checkBox1.Checked;
                        TargetNode.Export(TargetNode._origPath = path);
                        TargetNode.IsDirty = false;
                        txtPath.Text = path;
                    }
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        private void btnBrowse_Click(object sender, EventArgs e) { LoadGCT(); }
        private void btnSaveAs_Click(object sender, EventArgs e) { SaveAs(); }
        private void btnSave_Click(object sender, EventArgs e) { Save(); }
        private void btnClose_Click(object sender, EventArgs e) { TargetNode = null; }

        bool _updating = false;
        private void lstCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel1.Enabled = lstCodes.SelectedIndex >= 0)
            {
                _updating = true;
                _codeEntry = lstCodes.Items[lstCodes.SelectedIndex] as GCTCodeEntryNode;
                txtDesc.Text = _codeEntry._description;
                txtCode.Text = _codeEntry.Lines;
                textBox1.Text = _codeEntry._name;
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
        }

        private void btnDeleteCode_Click(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry == null || _updating)
                return;

            _codeEntry.Remove();
            lstCodes.SelectedIndex = lstCodes.SelectedIndex.Clamp(-1, TargetNode.Children.Count - 1);

            lstCodes.RefreshItems();
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            if (_updating)
                return;

            if (TargetNode == null)
                TargetNode = new GCTNode();

            TargetNode.AddChild(new GCTCodeEntryNode() { _name = "New Code" });
            lstCodes.RefreshItems();
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
                _codeEntry._lines = lines.ToArray();

            txtCode.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TargetNode == null || _codeEntry  == null || _updating)
                return;

            _codeEntry.Name = textBox1.Text;
            lstCodes.RefreshItems();
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
                if (MessageBox.Show(this, "Are you sure you don't want the info written in the GCT?\nYou will not be able to open it back up later.", "Are you sure?", MessageBoxButtons.YesNo) == Forms.DialogResult.No)
                    checkBox1.Checked = true;
            _updating = false;
        }
    }
}