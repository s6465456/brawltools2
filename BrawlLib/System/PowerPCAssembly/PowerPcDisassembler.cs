using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;

namespace PowerPcAssembly
{
    public partial class PPCDisassembler : UserControl
    {
        const int RowHeight = 16;

        public RELDataNode _section;
        [Browsable(false)]
        public RELDataNode Section
        {
            get { return _section; }
            set { _section = value; if (_section != null) Source = _section.CodeList; }
        }

        public event EventHandler IndexChanged;
        public event EventHandler SourceChanged;

        protected int index = 0;
        [Browsable(false)]
        public int Index
        {
            get { return index; }
            set
                {
                    if (value < Min) value = Min;
                    if (value > Max) value = Max;
                    if (index == value) return;

                    index = value;
                    OnIndexChanged(EventArgs.Empty);
                    if (index != vScroll.Value) vScroll.Value = index;
                    Display();
                }
        }

        [Browsable(false)]
        public uint Address
        {
            get { return BaseAddress + (uint)Index * 4; }
            set { Index = (int)(value.RoundDown(4) / 4 - BaseAddress / 4); }
        }

        public uint BaseAddress
        {
            get { return 0; }//if (!generateAddresses && source != null) return source[0].Address + (uint)BaseOffset; else return 0 - (uint)BaseOffset; }
        }

        protected int baseOffset = 0;
        [DefaultValue(0)]
        public int BaseOffset
        {
            get { return baseOffset; }
            set { baseOffset = value.RoundDown(4); Display(); }
        }

        protected DisplayType valueDisplay = DisplayType.Decimal;
        [DefaultValue(DisplayType.Decimal)]
        public DisplayType ValueDisplay
        {
            get { return valueDisplay; }
            set { valueDisplay = value; Display(); }
        }

        protected bool generateAddresses = false;
        [DefaultValue(false)]
        public bool GenerateAddresses
        {
            get { return generateAddresses; }
            set { generateAddresses = value; Display(); }
        }

        protected bool scrollVisible = false;
        protected bool ScrollVisible
        {
            get { return scrollVisible; }
            set { scrollVisible = value; grdDisassembler.Width = this.Width - (value ? vScroll.Width : 0); }
        }

        protected PPCOpCode[] source = null;
        [Browsable(false)]
        public PPCOpCode[] Source
        {
            get { return source; }
            set 
            {
                if (source == value) 
                    return;
                
                source = value;
                OnSourceChanged(EventArgs.Empty);

                if (source != null)
                {
                    ScrollVisible = (source.Length > DisplayCount);
                    Max = source.Length - DisplayCount;
                }

                if (Index != 0)
                    Index = 0;
                else
                    Display();
            }
        }

        [Browsable(false)]
        public int DisplayCount { get { return (this.Height / RowHeight).RoundUp(1); } }
        [Browsable(false)]
        protected int Min { get { return vScroll.Minimum; } set { vScroll.Minimum = value; } }
        [Browsable(false)]
        protected int Max { get { return vScroll.Maximum - vScroll.LargeChange + 1; } set { vScroll.Maximum = (value + vScroll.LargeChange - 1 > vScroll.LargeChange ? value + vScroll.LargeChange - 1 : vScroll.LargeChange) ; } }

        public PPCDisassembler()
        {
            InitializeComponent();
            AdjustRows();
            vScroll.LargeChange = DisplayCount;
        }

        protected void AdjustRows()
        {
            if (grdDisassembler.Rows.Count == 0)
                grdDisassembler.Rows.Add();
            if(grdDisassembler.Rows.Count < DisplayCount)
                grdDisassembler.Rows.AddCopies(0, DisplayCount - 1);
            while (grdDisassembler.Rows.Count > DisplayCount)
                grdDisassembler.Rows.RemoveAt(grdDisassembler.Rows.Count - 1);
        }

        protected virtual void Display()
        {
            for (int i = 0; i < DisplayCount; i++)
            {
                DataGridViewRow row = this.grdDisassembler.Rows[i];
                if (Source != null && Index + i < source.Length)
                {
                    PPCOpCode opcode = source[Index + i].Copy();
                    string info = "";

                    if (GenerateAddresses == true)
                        opcode.Address = (uint)(BaseOffset + (Index + i) * 0x4);

                    opcode.Address += (uint)baseOffset;

                    PPCFormat.disassemblerDisplay = valueDisplay;
                    row.Cells[0].Value = PPCFormat.Offset(opcode.Address);
                    row.Cells[1].Value = opcode.FormName();
                    row.Cells[2].Value = opcode.FormOps();

                    if (info != "") row.Cells[2].Value = info;
                }
                else
                {
                    foreach (DataGridViewCell c in row.Cells)
                        c.Value = "";
                }
            }
        }

        protected void vScroll_ValueChanged(object sender, EventArgs e)
        {
            Index = vScroll.Value;
        }

        protected void grdDisassembler_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Up:
                case Keys.Down:
                case Keys.PageDown:
                case Keys.PageUp:
                    e.SuppressKeyPress = true;
                    break;
            }

            if (e.KeyCode == Keys.Down)
                Index += vScroll.SmallChange;

            if (e.KeyCode == Keys.PageDown)
                Index += vScroll.LargeChange;

            if (e.KeyCode == Keys.Up)
                Index -= vScroll.SmallChange;

            if (e.KeyCode == Keys.PageUp)
                Index -= vScroll.LargeChange;
        }

        protected void grdDisassembler_Scroll(object sender, ScrollEventArgs e)
        {
            e.NewValue = 0;
        }

        protected void grdDisassembler_Resize(object sender, EventArgs e)
        {
            AdjustRows();
            vScroll.LargeChange = DisplayCount - 1;

            if (source != null)
            {
                Max = source.Length - DisplayCount;
                if (Index > Max)
                    Index = Max;
                Display();
            }
        }

        protected void OnIndexChanged(EventArgs e)
        {
            if (IndexChanged != null)
                IndexChanged.Invoke(this, e);
        }

        protected void OnSourceChanged(EventArgs e)
        {
            if (SourceChanged != null)
                SourceChanged.Invoke(this, e);
        }
    }
}
