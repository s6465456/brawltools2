using System;
using BrawlLib.SSBB.ResourceNodes;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    public class OffsetEditor : UserControl
    {
        #region Designer

        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.indexBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.listBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBox.FormattingEnabled = true;
            this.listBox.Items.AddRange(new object[] {
            "Actions",
            "Animations",
            "SubRoutines",
            "External",
            "Null"});
            this.listBox.Location = new System.Drawing.Point(49, 3);
            this.listBox.Name = "comboBox1";
            this.listBox.Size = new System.Drawing.Size(121, 21);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Action:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox2
            // 
            this.indexBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.indexBox.FormattingEnabled = true;
            this.indexBox.Location = new System.Drawing.Point(49, 27);
            this.indexBox.Name = "comboBox2";
            this.indexBox.Size = new System.Drawing.Size(121, 21);
            this.indexBox.TabIndex = 2;
            this.indexBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox3
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(216, 3);
            this.typeBox.Name = "comboBox3";
            this.typeBox.Size = new System.Drawing.Size(74, 21);
            this.typeBox.TabIndex = 4;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(0, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(296, 53);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listBox);
            this.panel1.Controls.Add(this.indexBox);
            this.panel1.Controls.Add(this.typeBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 52);
            this.panel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OffsetEditor
            // 
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "OffsetEditor";
            this.Size = new System.Drawing.Size(296, 105);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        int index = -2;
        private ComboBox listBox;
        private Label label1;
        private Label label2;
        private ComboBox indexBox;
        private Label label3;
        private ComboBox typeBox;
        public RichTextBox richTextBox1;
        private Panel panel1;
        private Button button1;

        private MoveDefEventOffsetNode _targetNode;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MoveDefEventOffsetNode TargetNode
        {
            get { return _targetNode; }
            set { _targetNode = value; TargetChanged(); }
        }

        private void TargetChanged()
        {
            if (_targetNode == null)
                return;

            _updating = true;

            if (_targetNode.Root._dataCommon != null)
            {
                listBox.Items.Clear();
                listBox.Items.AddRange(new object[] {
                "Actions",
                "Animations",
                "SubRoutines",
                "External",
                "Null",
                "Screen Tints",
                "Flash Overlays"});
            }
            else
            {
                listBox.Items.AddRange(new object[] {
                "Actions",
                "Animations",
                "SubRoutines",
                "External",
                "Null"});
            }

            listBox.SelectedIndex = _targetNode.list;
            if (_targetNode.type != -1)
                typeBox.SelectedIndex = _targetNode.type;
            if (_targetNode.index != -1 && indexBox.Items.Count > _targetNode.index)
                indexBox.SelectedIndex = _targetNode.index;

            //if (_targetNode.list < 3)
            //{
            //    _targetNode.action = _targetNode.Root.GetAction(_targetNode.list, _targetNode.type, _targetNode.index);
            //    if (_targetNode.action == null)
            //        _targetNode.action = _targetNode.GetAction();
            //}
            //else
            //    _targetNode.action = null;

            _updating = false;
            UpdateText();
        }

        private bool _updating = false;

        public OffsetEditor() { InitializeComponent(); }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == 0)
            {
                typeBox.Items.Clear();
                typeBox.Items.Add("Entry");
                typeBox.Items.Add("Exit");

                indexBox.Items.Clear();
                indexBox.Items.AddRange(_targetNode.Root._actions.Children.ToArray());
            }
            if (listBox.SelectedIndex == 1)
            {
                typeBox.Items.Clear();
                typeBox.Items.Add("Main");
                typeBox.Items.Add("GFX");
                typeBox.Items.Add("SFX");
                typeBox.Items.Add("Other");

                indexBox.Items.Clear();
                if (TargetNode.Root._subActions != null)
                indexBox.Items.AddRange(_targetNode.Root._subActions.Children.ToArray());
            }

            if (listBox.SelectedIndex >= 2)
                typeBox.Visible = label3.Visible = false;
            else
                typeBox.Visible = label3.Visible = true;

            if (listBox.SelectedIndex == 4)
                indexBox.Visible = label2.Visible = false;
            else
                indexBox.Visible = label2.Visible = true;

            if (listBox.SelectedIndex == 2)
            {
                indexBox.Items.Clear();
                indexBox.Items.AddRange(_targetNode.Root._subRoutineList.ToArray());
            }
            if (listBox.SelectedIndex == 3)
            {
                indexBox.Items.Clear();
                indexBox.Items.AddRange(_targetNode.Root._externalRefs.ToArray());
            }
            if (listBox.SelectedIndex == 5)
            {
                indexBox.Items.Clear();
                indexBox.Items.AddRange(_targetNode.Root._dataCommon._screenTint.Children.ToArray());
            }
            if (listBox.SelectedIndex == 6)
            {
                indexBox.Items.Clear();
                indexBox.Items.AddRange(_targetNode.Root._dataCommon._flashOverlay.Children.ToArray());
            }
            if (!_updating)
                UpdateText();
        }

        private void UpdateText()
        {
            if (listBox.SelectedIndex == 4)
                richTextBox1.Text = "Go nowhere.";
            else
                richTextBox1.Text = "Go to " + indexBox.Text + (listBox.SelectedIndex >= 2 ? "" : " - " + typeBox.Text) + " in the " + listBox.Text + " list.";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_updating)
                UpdateText();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_updating)
                UpdateText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_targetNode.action != null)
            {
                _targetNode._value = -1;
                (_targetNode as MoveDefEventOffsetNode).action._actionRefs.Remove(_targetNode);
            }
            if (listBox.SelectedIndex >= 3)
            {
                if (listBox.SelectedIndex == 3 && indexBox.SelectedIndex >= 0 && indexBox.SelectedIndex < _targetNode.Root._externalRefs.Count)
                {
                    if (_targetNode._extNode != null)
                    {
                        _targetNode._extNode._refs.Remove(_targetNode);
                        _targetNode._extNode = null;
                    }
                    (_targetNode._extNode = _targetNode.Root._externalRefs[indexBox.SelectedIndex] as MoveDefExternalNode)._refs.Add(_targetNode);
                    _targetNode.Name = _targetNode._extNode.Name;
                }
            }
            else
            {
                if (_targetNode._extNode != null)
                {
                    _targetNode._extNode._refs.Remove(_targetNode);
                    _targetNode._extNode = null;
                }
            }
            _targetNode.list = listBox.SelectedIndex;
            _targetNode.type = (listBox.SelectedIndex >= 2 ? -1 : typeBox.SelectedIndex);
            _targetNode.index = (listBox.SelectedIndex == 4 ? -1 : indexBox.SelectedIndex);
            _targetNode.action = _targetNode.Root.GetAction(_targetNode.list, _targetNode.type, _targetNode.index);
            if (_targetNode.action != null)
                _targetNode._value = _targetNode.action._offset;
            _targetNode.SignalPropertyChange();
        }
    }
}
