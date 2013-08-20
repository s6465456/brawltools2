using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;

namespace System.Windows.Forms
{
    [DefaultEvent("OffsetChanged")]
    public partial class SectionMemoryViewer : UserControl
    {
        public event EventHandler OffsetChanged = null;

        [Browsable(false)]
        public ModuleSectionNode Section { get { return _Section; } set { SetSection(value); } }
        private ModuleSectionNode _Section = null;

        [Browsable(false)]
        public int Offset { get { return GetOffset(); } set { Navigate(value); } }

        private DataGridViewCellStyle _NormalStyle = null;
        private DataGridViewCellStyle _RelocationStyle = null;

        public SectionMemoryViewer()
        {
            InitializeComponent();

            _NormalStyle = new DataGridViewCellStyle() { BackColor = Color.White };
            _RelocationStyle = new DataGridViewCellStyle() { BackColor = Color.Wheat };
        }

        public void SetSection(ModuleSectionNode value)
        {
            if (_Section == value)
                return;

            _Section = value;
            SetupSource();
            SetupRelocations();
        }

        public void Navigate(int offset)
        {
            int column = (offset / 4) % 4;
            int row = offset / 0x10;
            row = Math.Min(dataGridView1.Rows.Count - 1, row);
            row = Math.Max(0, row);

            if (dataGridView1.Rows.Count == 0)
                return;

            if (new Drawing.Point(column, row) == dataGridView1.CurrentCellAddress)
                return;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = dataGridView1[column, row];
            dataGridView1.FirstDisplayedCell = dataGridView1[column, row];

            OnSelectedOffsetChanged(this, EventArgs.Empty);
        }

        public int GetOffset()
        {
            if (dataGridView1.CurrentCell != null)
                return dataGridView1.CurrentCell.RowIndex * 0x10 + Math.Min(dataGridView1.CurrentCell.ColumnIndex, 0x04) * 0x04;
            else
                return 0;
        }

        public void RefreshDisplay(bool updateMemoryRegion)
        {
            if (updateMemoryRegion)
                SetupSource();
            else
                bindingSource1.ResetBindings(false);

            SetupRelocations();
        }

        public void RefreshCurrent()
        {
            int offset = GetOffset();
            bindingSource1.ResetItem(offset / 0x10);

            if (offset < _Section.Size)
                if (_Section.GetRelocationAtOffset(offset).Command != null)
                    dataGridView1.CurrentCell.Style = _RelocationStyle;
                else
                    dataGridView1.CurrentCell.Style = _NormalStyle;

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex + i];
                int offset = (row.DataBoundItem as RowProxy).Row * 0x10;

                row.HeaderCell.Value = string.Format("0x{0:X}", offset);

                if (offset + 0x10 >= _Section.Size)
                    SetRowLength(e.RowIndex + i, (int)_Section.Size - offset);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewTextBoxCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;
            
            if (cell.OwningColumn.DataPropertyName != "Ascii")
            {
                e.FormattingApplied = true;
                e.Value = "";

                if (!cell.ReadOnly)
                    e.Value = string.Format(string.Format("{{0:X{0}}}", cell.MaxInputLength), cell.Value);
            }
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridViewTextBoxCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;
            string editedValue = cell.EditedFormattedValue as string;
            uint result = 0;
            e.ParsingApplied = true;
            e.Value = cell.Value;
            
            if (uint.TryParse(editedValue, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out result))
                e.Value = result;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bindingSource1.ResetItem(e.RowIndex);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            OnSelectedOffsetChanged(this, EventArgs.Empty);
        }

        private void SetupSource()
        {
            if (_Section != null)
            {
                RowProxy[] rows = new RowProxy[(_Section.Size + 0xF) / 0x10];
                for (int i = 0; i < rows.Length; i++)
                    rows[i] = new RowProxy(this, i);

                bindingSource1.DataSource = rows.ToList();
            }
            else
            {
                bindingSource1.DataSource = null;
            }
        }

        private void SetupRelocations()
        {
            if (_Section != null)
                for (int i = 0; i < _Section.Size / 4; i++)
                    if (_Section[i].Command != null)
                        dataGridView1[i % 4, i / 4].Style = _RelocationStyle;
                    else
                        dataGridView1[i % 4, i / 4].Style = _NormalStyle;
        }

        private void SetRowLength(int rowIndex, int byteLength)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            for (int j = 0; j < 4; j++)
            {
                DataGridViewTextBoxCell cell = row.Cells[j] as DataGridViewTextBoxCell;
                int bytes = Math.Max(0, Math.Min(byteLength - (j * 4), 4));

                if (bytes > 0)
                    cell.MaxInputLength = bytes * 2;
                else
                    cell.ReadOnly = true;
            }
        }

        private void OnSelectedOffsetChanged(object sender, EventArgs e)
        {
            if (OffsetChanged != null)
                OffsetChanged.Invoke(sender, e);
        }

        #region Private Classes

        private unsafe class RowProxy
        {
            public SectionMemoryViewer Owner { get { return _Owner; } }
            public int Row { get { return _Row; } }

            private SectionMemoryViewer _Owner = null;
            private int _Row = 0;

            public uint E0 { get { return GetElement(0); } set { SetElement(0, value); } }
            public uint E1 { get { return GetElement(1); } set { SetElement(1, value); } }
            public uint E2 { get { return GetElement(2); } set { SetElement(2, value); } }
            public uint E3 { get { return GetElement(3); } set { SetElement(3, value); } }

            public string Ascii { get { return GetAscii(); } }

            public RowProxy(SectionMemoryViewer owner, int row)
            {
                _Owner = owner;
                _Row = row;
            }

            public string GetAscii()
            {
                int offset = _Row * 0x10;
                int count = 0x10;

                if (offset + 0xF >= _Owner._Section.Size)
                    count = (int)_Owner._Section.Size & 0xF;

                return new string((sbyte*)_Owner._Section._dataBuffer.Address, offset, count);
            }

            public bool ElementIsValid(int index)
            {
                int offset = _Row * 0x10;
                return index < 4 && offset + index * 4 < _Owner._Section.Size;
            }

            public uint GetElement(int index)
            {
                if (!ElementIsValid(index))
                    return 0x0000FADE;

                int offset = _Row * 0x10;
                buint* ptr = (buint*)(_Owner._Section._dataBuffer.Address + offset);

                return ptr[index];
            }

            public void SetElement(int index, uint value)
            {
                if (!ElementIsValid(index))
                    return;

                int offset = _Row * 0x10;
                buint* ptr = (buint*)(_Owner._Section._dataBuffer.Address + offset);

                ptr[index] = value;
            }
        }

        #endregion
    }
}
