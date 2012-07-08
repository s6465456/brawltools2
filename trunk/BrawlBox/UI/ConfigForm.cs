using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SmashBox
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void GetAssocBox(string name, CheckBox box)
        {
            FileAssociation assoc = new FileAssociation("." + name.ToLower());
            FileType t = new FileType("SSBB." + name.ToUpper());
            string cmd;

            if ((t == assoc.FileType) && ((cmd = t.GetShellCommand("open")) != null))
            {
                if (cmd.StartsWith("\"")) cmd = cmd.Substring(1, cmd.IndexOf('"', 1) - 1);

                if (cmd.Equals(Application.ExecutablePath, StringComparison.OrdinalIgnoreCase))
                {
                    box.Tag = true;
                    box.Checked = true;
                    return;
                }
            }
            box.Tag = false;
            box.Checked = false;
        }

        private void SetAssocBox(string name, CheckBox box)
        {
            if ((bool)box.Tag == box.Checked)
                return;

            FileAssociation assoc = new FileAssociation("." + name.ToLower());
            FileType t = new FileType("SSBB." + name.ToUpper());

            if (box.Checked)
            {
                assoc.FileType = t;
                t.SetShellCommand("open", String.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
                //t.DefaultIcon = String.Format("\"{0}\",1", Application.ExecutablePath);
            }
            else
            {
                t.Delete();
                assoc.Delete();
            }

            box.Tag = box.Checked;
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            GetAssocBox("pac", chkPAC);
            GetAssocBox("pcs", chkPCS);
            GetAssocBox("brres", chkBRRES);
            GetAssocBox("tex0", chkTEX0);
            GetAssocBox("plt0", chkPLT0);
            GetAssocBox("mdl0", chkMDL0);
            GetAssocBox("brsar", chkBRSAR);
            GetAssocBox("brstm", chkBRSTM);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SetAssocBox("pac", chkPAC);
            SetAssocBox("pcs", chkPCS);
            SetAssocBox("brres", chkBRRES);
            SetAssocBox("tex0", chkTEX0);
            SetAssocBox("plt0", chkPLT0);
            SetAssocBox("mdl0", chkMDL0);
            SetAssocBox("brsar", chkBRSAR);
            SetAssocBox("brstm", chkBRSTM);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnApply_Click(sender, e);
            this.Close();
        }
    }
}
