namespace PowerPcAssembly
{
    partial class PPCDisassembler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdDisassembler = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisassembler)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDisassembler
            // 
            this.grdDisassembler.AllowUserToAddRows = false;
            this.grdDisassembler.AllowUserToDeleteRows = false;
            this.grdDisassembler.AllowUserToResizeColumns = false;
            this.grdDisassembler.AllowUserToResizeRows = false;
            this.grdDisassembler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDisassembler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdDisassembler.ColumnHeadersVisible = false;
            this.grdDisassembler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDisassembler.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdDisassembler.Location = new System.Drawing.Point(0, 0);
            this.grdDisassembler.Name = "grdDisassembler";
            this.grdDisassembler.RowHeadersWidth = 12;
            this.grdDisassembler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDisassembler.RowTemplate.Height = 16;
            this.grdDisassembler.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdDisassembler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDisassembler.Size = new System.Drawing.Size(312, 304);
            this.grdDisassembler.TabIndex = 1;
            this.grdDisassembler.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grdDisassembler_Scroll);
            this.grdDisassembler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDisassembler_KeyDown);
            this.grdDisassembler.Resize += new System.EventHandler(this.grdDisassembler_Resize);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 40F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // vScroll
            // 
            this.vScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScroll.LargeChange = 1;
            this.vScroll.Location = new System.Drawing.Point(296, 0);
            this.vScroll.Maximum = 0;
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(16, 304);
            this.vScroll.TabIndex = 2;
            this.vScroll.ValueChanged += new System.EventHandler(this.vScroll_ValueChanged);
            // 
            // PPCDisassembler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdDisassembler);
            this.Controls.Add(this.vScroll);
            this.Name = "PPCDisassembler";
            this.Size = new System.Drawing.Size(312, 304);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisassembler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView grdDisassembler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.VScrollBar vScroll;

    }
}
