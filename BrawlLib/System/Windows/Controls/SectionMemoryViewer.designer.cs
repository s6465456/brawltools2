namespace System.Windows.Forms
{
    partial class SectionMemoryViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._00010203 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._04050607 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._08090A0B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._0C0D0E0F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Ascii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._00010203,
            this._04050607,
            this._08090A0B,
            this._0C0D0E0F,
            this._Ascii});
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 75;
            this.dataGridView1.RowTemplate.Height = 16;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(150, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // _00010203
            // 
            this._00010203.DataPropertyName = "E0";
            this._00010203.HeaderText = "00010203";
            this._00010203.MaxInputLength = 8;
            this._00010203.MinimumWidth = 57;
            this._00010203.Name = "_00010203";
            this._00010203.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._00010203.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._00010203.Width = 57;
            // 
            // _04050607
            // 
            this._04050607.DataPropertyName = "E1";
            this._04050607.HeaderText = "04050607";
            this._04050607.MaxInputLength = 8;
            this._04050607.MinimumWidth = 57;
            this._04050607.Name = "_04050607";
            this._04050607.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._04050607.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._04050607.Width = 57;
            // 
            // _08090A0B
            // 
            this._08090A0B.DataPropertyName = "E2";
            this._08090A0B.HeaderText = "08090A0B";
            this._08090A0B.MaxInputLength = 8;
            this._08090A0B.MinimumWidth = 57;
            this._08090A0B.Name = "_08090A0B";
            this._08090A0B.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._08090A0B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._08090A0B.Width = 57;
            // 
            // _0C0D0E0F
            // 
            this._0C0D0E0F.DataPropertyName = "E3";
            this._0C0D0E0F.HeaderText = "0C0D0E0F";
            this._0C0D0E0F.MaxInputLength = 8;
            this._0C0D0E0F.MinimumWidth = 57;
            this._0C0D0E0F.Name = "_0C0D0E0F";
            this._0C0D0E0F.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._0C0D0E0F.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._0C0D0E0F.Width = 57;
            // 
            // _Ascii
            // 
            this._Ascii.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Ascii.DataPropertyName = "Ascii";
            this._Ascii.HeaderText = "";
            this._Ascii.MaxInputLength = 16;
            this._Ascii.MinimumWidth = 108;
            this._Ascii.Name = "_Ascii";
            this._Ascii.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            // 
            // SectionMemoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "SectionMemoryViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _00010203;
        private System.Windows.Forms.DataGridViewTextBoxColumn _04050607;
        private System.Windows.Forms.DataGridViewTextBoxColumn _08090A0B;
        private System.Windows.Forms.DataGridViewTextBoxColumn _0C0D0E0F;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Ascii;
    }
}
