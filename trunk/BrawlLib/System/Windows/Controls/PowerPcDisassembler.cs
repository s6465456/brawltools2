using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.PowerPcAssembly;

namespace System.Windows.Forms
{
    public partial class PPCDisassembler : UserControl
    {
        public ModuleDataNode _targetNode;
        [Browsable(false)]
        public ModuleDataNode TargetNode
        {
            get { return _targetNode; }
            set { SetTarget(value); }
        }

        public void SetTarget(ModuleDataNode value)
        {
            if ((_targetNode = value) == null) 
                return;

            _baseOffset = (int)(_targetNode._initAddr - _targetNode.BaseAddress);
            Display();
        }

        public PPCDisassembler() { InitializeComponent(); }

        public int _baseOffset;
        
        void Display()
        {
            grdDisassembler.Rows.Clear();
            if (_targetNode == null || _targetNode.HasNoCode) return;
            for (int i = 0; i < _targetNode._relocations.Length; i++)
            {
                DataGridViewRow row = grdDisassembler.Rows[grdDisassembler.Rows.Add()];
                PPCOpCode opcode = _targetNode[i].Code;

                row.Cells[0].Value = PPCFormat.Offset(_baseOffset + _targetNode[i]._index * 4);
                row.Cells[1].Value = opcode.FormName();
                row.Cells[2].Value = opcode.FormOps();
                row.Cells[3].Value = _targetNode[i].Description;

                row.DefaultCellStyle.BackColor = TargetNode.GetStatusColorFromIndex(i);
            }
        }

        private void grdDisassembler_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void grdDisassembler_SizeChanged(object sender, EventArgs e)
        {

        }

        private void grdDisassembler_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
