using System;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.SSBBTypes;

namespace System.Windows.Forms
{
    public class VIS0Editor : UserControl
    {
        #region Designer
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 47);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // VIS0Editor
            // 
            this.Controls.Add(this.listBox1);
            this.Name = "VIS0Editor";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(210, 55);
            this.ResumeLayout(false);

        }

        #endregion

        public ListBox listBox1;

        public ModelEditControl _mainWindow;

        public VIS0Editor() { InitializeComponent(); }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentFrame
        {
            get { return _mainWindow.CurrentFrame; }
            set { _mainWindow.CurrentFrame = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0Node TargetModel
        {
            get { return _mainWindow.TargetModel; }
            set { _mainWindow.TargetModel = value; }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0Node SelectedAnimation
        {
            get { return _mainWindow._vis0; }
            set { _mainWindow.SelectedVIS0 = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0EntryNode TargetVisEntry { get { return _mainWindow._targetVisEntry; } set { _mainWindow.TargetVisEntry = value; } }
        
        public void UpdateAnimation()
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            if (_mainWindow._vis0 != null)
            foreach (VIS0EntryNode n in _mainWindow._vis0.Children)
                listBox1.Items.Add(n);

            listBox1.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TargetVisEntry = listBox1.Items[listBox1.SelectedIndex] as VIS0EntryNode;
            if (_mainWindow._animFrame > 0 && _mainWindow._animFrame < _mainWindow.pnlKeyframes.visEditor.listBox1.Items.Count)
                _mainWindow.pnlKeyframes.visEditor.listBox1.SelectedIndex = _mainWindow._animFrame;
        }

        public void UpdateEntry()
        {
            _mainWindow.pnlKeyframes.visEditor.listBox1.BeginUpdate();
            _mainWindow.pnlKeyframes.visEditor.listBox1.Items.Clear();

            if (_mainWindow.pnlKeyframes.visEditor.TargetNode != null && _mainWindow.pnlKeyframes.visEditor.TargetNode.EntryCount > -1)
                for (int i = 0; i < _mainWindow.pnlKeyframes.visEditor.TargetNode.EntryCount; i++)
                    _mainWindow.pnlKeyframes.visEditor.listBox1.Items.Add(_mainWindow.pnlKeyframes.visEditor.TargetNode.GetEntry(i));

            _mainWindow.pnlKeyframes.visEditor.listBox1.EndUpdate();
        }

        public void EntryChanged()
        {
            _mainWindow.ReadVIS0();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableTransformEdit
        {
            get { return _mainWindow._enableTransform; }
            set { /*_mainWindow.pnlKeyframes.Enabled = (_mainWindow.EnableTransformEdit = value) && (SelectedAnimation != null);*/ }
        }
    }
}