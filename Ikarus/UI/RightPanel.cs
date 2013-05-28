using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ikarus.UI
{
    public partial class RightPanel : UserControl
    {
        public RightPanel()
        {
            InitializeComponent();
            editor.SelectedIndex = 0;
            lstOpenedFiles.DataSource = Program.OpenedFilePaths;
        }

        Control _currentControl;
        private void editor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control newControl = null;
            switch (editor.SelectedIndex)
            {
                case 0:
                    newControl = pnlMoveset;
                    break;
                case 1:
                    break;
                case 2:
                    newControl = pnlKeyframes;
                    break;
                case 3:
                    newControl = pnlBones;
                    break;
                case 4:
                    newControl = lstOpenedFiles;
                    break;
            }

            if (_currentControl != null)
                _currentControl.Visible = false;

            if ((_currentControl = newControl) != null)
                _currentControl.Visible = true;
        }

        private void lstOpenedFiles_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(Program.RootPath + lstOpenedFiles.SelectedItem as string);
        }
    }
}
