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
    public class RelDisassembler : PPCDisassembler
    {
        protected override void Display()
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
                    else
                    {
                        //opcode.Address += (uint)baseOffset;
                        opcode.Address = (uint)(BaseOffset + (Index + i) * 0x4);
                        RelCommand relocate = _section._commandList[Index + i];
                        if (relocate != null && relocate.IsBranchSet)
                            if (_section._commandList[Index + i].Initialized)
                                ((BranchOpcode)opcode).Destination = relocate.Addend;
                            else
                                info = relocate.OperandInfo;

                        row.DefaultCellStyle.BackColor = _section.StatusColor(Index + i);
                    }

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
    }
}
