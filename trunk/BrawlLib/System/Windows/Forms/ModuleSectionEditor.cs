using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;

namespace System.Windows.Forms
{
    public class ModuleSectionEditor : Form
    {
        private DataGridViewTextBoxColumn Col0x0;
        private DataGridViewTextBoxColumn Col0x4;
        private DataGridViewTextBoxColumn Col0x8;
        private DataGridViewTextBoxColumn Col0xC;
        private DataGridView dataGridView1;
    
        public ModuleSectionEditor() { InitializeComponent(); }
        
        #region Designer


        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col0x0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col0x4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col0x8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col0xC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col0x0,
            this.Col0x4,
            this.Col0x8,
            this.Col0xC});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 55;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(479, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // Col0x0
            // 
            this.Col0x0.HeaderText = "0";
            this.Col0x0.MaxInputLength = 8;
            this.Col0x0.Name = "Col0x0";
            this.Col0x0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col0x0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col0x0.Width = 55;
            // 
            // Col0x4
            // 
            this.Col0x4.HeaderText = "4";
            this.Col0x4.MaxInputLength = 8;
            this.Col0x4.Name = "Col0x4";
            this.Col0x4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col0x4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col0x4.Width = 55;
            // 
            // Col0x8
            // 
            this.Col0x8.HeaderText = "8";
            this.Col0x8.MaxInputLength = 8;
            this.Col0x8.Name = "Col0x8";
            this.Col0x8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col0x8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col0x8.Width = 55;
            // 
            // Col0xC
            // 
            this.Col0xC.HeaderText = "C";
            this.Col0xC.MaxInputLength = 8;
            this.Col0xC.Name = "Col0xC";
            this.Col0xC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Col0xC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Col0xC.Width = 55;
            // 
            // ModuleSectionEditor
            // 
            this.ClientSize = new System.Drawing.Size(479, 368);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ModuleSectionEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Section Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
