using Be.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.SSBBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public unsafe partial class RELSectionMemoryEditor : Form
    {
        private ModuleSectionNode _section = null;

        public RELSectionMemoryEditor(ModuleSectionNode section)
        {
            InitializeComponent();

            _section = section;

            Text = String.Format("Section Editor - {0}", _section.Name);

            hexBox1.SectionNode = _section;
            chkCodeSection.Checked = _section._isCodeSection;
            chkBSSSection.Checked = _section._isBSSSection;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hexBox1.ByteProvider = new DynamicFileByteProvider(new UnmanagedMemoryStream((byte*)_section._dataBuffer.Address, _section._dataBuffer.Length, _section._dataBuffer.Length, FileAccess.ReadWrite));
            UpdateFileSizeStatus();
        }

        void UpdateFileSizeStatus()
        {
            if (hexBox1.ByteProvider == null)
                fileSizeToolStripStatusLabel.Text = string.Empty;
            else
                fileSizeToolStripStatusLabel.Text = GetDisplayBytes(hexBox1.ByteProvider.Length);
        }

        string GetDisplayBytes(long size)
        {
            const long multi = 1024;
            long kb = multi;
            long mb = kb * multi;
            long gb = mb * multi;
            long tb = gb * multi;

            const string BYTES = "Bytes";
            const string KB = "KB";
            const string MB = "MB";
            const string GB = "GB";
            const string TB = "TB";

            string result;
            if (size < kb)
                result = string.Format("{0} {1}", size, BYTES);
            else if (size < mb)
                result = string.Format("{0} {1} ({2} Bytes)",
                    ConvertToOneDigit(size, kb), KB, ConvertBytesDisplay(size));
            else if (size < gb)
                result = string.Format("{0} {1} ({2} Bytes)",
                    ConvertToOneDigit(size, mb), MB, ConvertBytesDisplay(size));
            else if (size < tb)
                result = string.Format("{0} {1} ({2} Bytes)",
                    ConvertToOneDigit(size, gb), GB, ConvertBytesDisplay(size));
            else
                result = string.Format("{0} {1} ({2} Bytes)",
                    ConvertToOneDigit(size, tb), TB, ConvertBytesDisplay(size));

            return result;
        }

        string ConvertBytesDisplay(long size)
        {
            return size.ToString("###,###,###,###,###", CultureInfo.CurrentCulture);
        }

        string ConvertToOneDigit(long size, long quan)
        {
            double quotient = (double)size / (double)quan;
            string result = quotient.ToString("0.#", CultureInfo.CurrentCulture);
            return result;
        }

        private void hexBox1_Copied(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void hexBox1_CopiedHex(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void hexBox1_CurrentLineChanged(object sender, EventArgs e)
        {
            PosChanged();
        }

        private void hexBox1_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            PosChanged();
        }

        void PosChanged()
        {
            this.toolStripStatusLabel.Text = string.Format("Ln {0}    Col {1}",
                hexBox1.CurrentLine, hexBox1.CurrentPositionInLine);

            long offset = hexBox1.SelectionStart;

            OffsetToolStripStatusLabel.Text = String.Format("Offset: 0x{0}", offset.ToString("X"));

            TargetRelocation = (offset < _section.Size ? _section.GetRelocationAtOffset((int)offset) : null);
        }

        public long Position 
        {
            get { return hexBox1.SelectionStart; }
            set
            {
                if (hexBox1.SelectionStart == value)
                    PosChanged();
                else
                    hexBox1.SelectionStart = value;
            }
        }

        Relocation _targetRelocation;
        public Relocation TargetRelocation
        {
            get { return _targetRelocation; }
            set 
            {
                if ((_targetRelocation = value) != null)
                    lstLinked.DataSource = _targetRelocation.Linked;
                else
                    lstLinked.DataSource = null;
                
                CommandChanged();
            }
        }

        private void CommandChanged()
        {
            if (TargetRelocation == null)
            {
                propertyGrid1.SelectedObject = null;
                btnNewCmd.Enabled = false;
                btnDelCmd.Enabled = false;
                btnOpenTarget.Enabled = false;
            }
            else if ((propertyGrid1.SelectedObject = TargetRelocation.Command) != null)
            {
                btnNewCmd.Enabled = false;
                btnDelCmd.Enabled = true;
                btnOpenTarget.Enabled = TargetRelocation.Command.TargetRelocation != null;
            }
            else
            {
                btnNewCmd.Enabled = true;
                btnDelCmd.Enabled = false;
                btnOpenTarget.Enabled = false;
            }

            hexBox1.Invalidate();
        }

        void EnableButtons()
        {
            copyToolStripMenuItem.Enabled = hexBox1.CanCopy();
            deleteToolStripMenuItem.Enabled= cutToolStripMenuItem.Enabled = hexBox1.CanCut();
            pasteInsertToolStripMenuItem.Enabled = hexBox1.CanPasteHex();
        }

        private void hexBox1_SelectionLengthChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void hexBox1_SelectionStartChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox1.CopyHex();
        }

        private void pasteInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox1.PasteHex(false);
        }

        private void pasteOverwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox1.PasteHex(true);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexBox1.Delete();
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gotoToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chkBSSSection_CheckedChanged(object sender, EventArgs e)
        {
            pnlLeft.Enabled = groupBox2.Enabled = !(_section._isBSSSection = chkBSSSection.Checked);
        }

        private void chkCodeSection_CheckedChanged(object sender, EventArgs e)
        {
            _section._isCodeSection = chkCodeSection.Checked;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog d = new SaveFileDialog())
            {
                d.Filter = "Raw Data (*.*)|*.*";
                d.FileName = _section.Name;
                d.Title = "Choose a place to export to.";
                if (d.ShowDialog() == Forms.DialogResult.OK)
                    _section.Export(d.FileName);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog d = new OpenFileDialog())
            {
                d.Filter = "Raw Data (*.*)|*.*";
                if (d.ShowDialog() == Forms.DialogResult.OK)
                    _section.Replace(d.FileName);
            }
        }

        private void exportInitializedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog d = new SaveFileDialog())
            {
                d.Filter = "Raw Data (*.*)|*.*";
                d.FileName = _section.Name;
                if (d.ShowDialog() == Forms.DialogResult.OK)
                    _section.ExportInitialized(d.FileName);
            }
        }

        private void btnNewCmd_Click(object sender, EventArgs e)
        {
            if (TargetRelocation == null || TargetRelocation.Command != null)
                return;

            TargetRelocation.Command = new RelCommand((TargetRelocation._section.Root as ModuleNode).ID, TargetRelocation._section.Index, new RELLink());

            CommandChanged();
        }

        private void btnDelCmd_Click(object sender, EventArgs e)
        {
            if (TargetRelocation == null || TargetRelocation.Command == null)
                return;

            TargetRelocation.Command = null;

            CommandChanged();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid1.Refresh();
        }

        private void btnOpenTarget_Click(object sender, EventArgs e)
        {
            if (TargetRelocation == null || TargetRelocation.Command == null)
                return;

            Relocation target = TargetRelocation.Command.TargetRelocation;
            if (target == null)
                return;

            if (target._section != _section)
            {
                RELSectionMemoryEditor x = new RELSectionMemoryEditor(target._section as ModuleSectionNode);
                x.Show();

                x.Position = target._index * 4;
            }
            else
                Position = target._index * 4;
        }
    }
}
