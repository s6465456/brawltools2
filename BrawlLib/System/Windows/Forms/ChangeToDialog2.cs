using System;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Animations;

namespace System.Windows.Forms
{
    public class ChangeToDialog2 : Form
    {
        private ResourceNode _node;
        private CHR0EntryNode _copyNode = null;
        private TextBox ScaleX;
        private TextBox ScaleY;
        private TextBox ScaleZ;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox RotX;
        private TextBox RotY;
        private TextBox RotZ;
        private TextBox TransX;
        private TextBox TransY;
        private TextBox TransZ;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private CheckBox ReplaceScale;
        private CheckBox AddScale;
        private CheckBox SubtractScale;
        private CheckBox SubtractRot;
        private CheckBox AddRot;
        private CheckBox ReplaceRot;
        private CheckBox SubtractTrans;
        private CheckBox AddTrans;
        private CheckBox ReplaceTrans;
        private CheckBox copyKeyframes;
        private TextBox textBox1;
        private CheckBox ChangeVersion;
        private ComboBox Version;
        private CheckBox Port;
        private CheckBox editLoop;
        private TabControl tabControl1;
        private TabPage chr;
        private TabPage srt;
        private TabPage shp;
        private TabPage pat;
        private TabPage vis;
        private CheckBox enableLoop;
        private CheckBox checkBox1;
        private TextBox textBox5;
        private Label label14;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label12;
        private Label label13;
        private TextBox textBox6;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label15;
        private Label label18;
        private Label label19;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox11;
        private TextBox textBox12;
        private CheckBox checkBox12;
        private ComboBox comboBox1;
        private CheckBox checkBox14;
        private Label label11;

        public ChangeToDialog2() { InitializeComponent(); }

        public DialogResult ShowDialog(IWin32Window owner, ResourceNode node)
        {
            name.MaxLength = 255;
            _node = node;
            Version.Items.Add("Version 4");
            Version.Items.Add("Version 5");
            Version.SelectedIndex = 0;
            try { return base.ShowDialog(owner); }
            finally { _node = null; }
        }

        private unsafe void btnOkay_Click(object sender, EventArgs e)
        {
            float x, y, z;
            string _name = name.Text;
            MDL0Node model = new MDL0Node();
            MDL0Node _targetModel = new MDL0Node();
            bool disableLoop = false;

            if (editLoop.Checked)
                disableLoop = true;
             
            if (Port.Checked)
            {
                MessageBox.Show("Please open the model you want to port the animations to.\nThen open the model the animations work normally for.");
                OpenFileDialog dlgOpen = new OpenFileDialog();
                OpenFileDialog dlgOpen2 = new OpenFileDialog();
                dlgOpen.Filter = dlgOpen2.Filter = "MDL0 Raw Model (*.mdl0)|*.mdl0";
                dlgOpen.Title = "Select the model to port the animations to...";
                dlgOpen2.Title = "Select the model the animations are for...";
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    _targetModel = (MDL0Node)NodeFactory.FromFile(null, dlgOpen.FileName);
                    if (dlgOpen2.ShowDialog() == DialogResult.OK)
                        model = (MDL0Node)NodeFactory.FromFile(null, dlgOpen2.FileName);
                }
            }

            try { x = Convert.ToSingle(ScaleX.Text); }
            catch { x = 0; }
            try { y = Convert.ToSingle(ScaleY.Text); }
            catch { y = 0; }
            try { z = Convert.ToSingle(ScaleZ.Text); }
            catch { z = 0; }

            Vector3 scale = new Vector3(x, y, z);

            try { x = Convert.ToSingle(RotX.Text); }
            catch { x = 0; }
            try { y = Convert.ToSingle(RotY.Text); }
            catch { y = 0; }
            try { z = Convert.ToSingle(RotZ.Text); }
            catch { z = 0; }

            Vector3 rot = new Vector3(x, y, z);

            try { x = Convert.ToSingle(TransX.Text); }
            catch { x = 0; }
            try { y = Convert.ToSingle(TransY.Text); }
            catch { y = 0; }
            try { z = Convert.ToSingle(TransZ.Text); }
            catch { z = 0; }

            Vector3 trans = new Vector3(x, y, z);

            if (_name != null)
                ChangeNode(_name, _node, scale, rot, trans, _targetModel, model, disableLoop);
            
            DialogResult = DialogResult.OK;
            Close();
        }

        public unsafe void ChangeNode(string _name, ResourceNode parent, Vector3 scale, Vector3 rot, Vector3 trans, MDL0Node _targetModel, MDL0Node model, bool disLoop)
        {
            int numFrames;
            float* v;
            bool hasKeyframe = false;
            CHR0EntryNode entry;
            KeyframeEntry kfe;
            AnimationFrame anim = new AnimationFrame();
            foreach (ResourceNode r in parent.Children)
            {
                if (r is CHR0Node)
                {
                    if (Port.Checked && _targetModel != null && model != null)
                        ((CHR0Node)r).Port(_targetModel, model);

                    if (Version.Enabled)
                        if (Version.SelectedIndex == 0)
                            ((CHR0Node)r).Version = 4;
                        else if (Version.SelectedIndex == 1)
                            ((CHR0Node)r).Version = 5;

                    if (disLoop)
                        ((CHR0Node)r).Loop = false;

                    _copyNode = r.FindChild(textBox1.Text, false) as CHR0EntryNode;

                    if (r.FindChild(_name, false) == null)
                    {
                        if (_name != null && _name != String.Empty)
                        {
                            CHR0EntryNode c = new CHR0EntryNode();
                            c._numFrames = (r as CHR0Node).FrameCount;
                            c.Name = _name;

                            if (_copyNode != null)
                                for (int x = 0; x < _copyNode._numFrames; x++)
                                    for (int i = 0x10; i < 0x19; i++)
                                        if ((kfe = _copyNode.GetKeyframe((KeyFrameMode)i, x)) != null)
                                            c.SetKeyframe((KeyFrameMode)i, x, kfe._value);

                            r.Children.Add(c);
                            r._changed = true;
                        }
                    }
                }
                if (r.Name == _name)
                {
                    if (r is CHR0EntryNode)
                    {
                        entry = r as CHR0EntryNode;
                        numFrames = entry.FrameCount;
                        if (ReplaceScale.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x10; i < 0x13; i++)
                                {
                                    if (entry.GetKeyframe((KeyFrameMode)i, x) != null)
                                        entry.RemoveKeyframe((KeyFrameMode)i, x);
                                }
                            }
                            entry.SetKeyframeOnlyScale(0, scale);
                        }
                        if (ReplaceRot.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x13; i < 0x16; i++)
                                {
                                    if (entry.GetKeyframe((KeyFrameMode)i, x) != null)
                                        entry.RemoveKeyframe((KeyFrameMode)i, x);
                                }
                            }
                            entry.SetKeyframeOnlyRot(0, rot);
                        }
                        if (ReplaceTrans.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x16; i < 0x19; i++)
                                {
                                    if (entry.GetKeyframe((KeyFrameMode)i, x) != null)
                                        entry.RemoveKeyframe((KeyFrameMode)i, x);
                                }
                            }
                            entry.SetKeyframeOnlyTrans(0, trans);
                        }
                        hasKeyframe = false;
                        if (AddScale.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x10; i < 0x13; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x10:
                                                kfe._value += scale._x;
                                                break;
                                            case 0x11:
                                                kfe._value += scale._y;
                                                break;
                                            case 0x12:
                                                kfe._value += scale._z;
                                                break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newScale = anim.Scale;
                                scale._x += newScale._x;
                                scale._y += newScale._y;
                                scale._z += newScale._z;
                                entry.SetKeyframeOnlyScale(0, scale);
                            }
                        }
                        hasKeyframe = false;
                        if (AddRot.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x13; i < 0x16; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x13:
                                                kfe._value += rot._x;
                                                break;
                                            case 0x14:
                                                kfe._value += rot._y;
                                                break;
                                            case 0x15:
                                                kfe._value += rot._z;
                                                break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newRot = anim.Rotation;
                                rot._x += newRot._x;
                                rot._y += newRot._y;
                                rot._z += newRot._z;
                                entry.SetKeyframeOnlyRot(0, rot);
                            }
                        }
                        hasKeyframe = false;
                        if (AddTrans.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x16; i < 0x19; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x16:
                                            kfe._value += trans._x;
                                            break;
                                            case 0x17:
                                            kfe._value += trans._y;
                                            break;
                                            case 0x18:
                                            kfe._value += trans._z;
                                            break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newTrans = anim.Translation;
                                trans._x += newTrans._x;
                                trans._y += newTrans._y;
                                trans._z += newTrans._z;
                                entry.SetKeyframeOnlyTrans(0, trans);
                            }
                        }
                        hasKeyframe = false;
                        if (SubtractScale.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x10; i < 0x13; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x10:
                                                kfe._value -= scale._x;
                                                break;
                                            case 0x11:
                                                kfe._value -= scale._y;
                                                break;
                                            case 0x12:
                                                kfe._value -= scale._z;
                                                break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newScale = anim.Scale;
                                scale._x = newScale._x - scale._x;
                                scale._y = newScale._y - scale._y;
                                scale._z = newScale._z - scale._z;
                                entry.SetKeyframeOnlyScale(0, scale);
                            }
                        }
                        hasKeyframe = false;
                        if (SubtractRot.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x13; i < 0x16; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x13:
                                                kfe._value -= rot._x;
                                                break;
                                            case 0x14:
                                                kfe._value -= rot._y;
                                                break;
                                            case 0x15:
                                                kfe._value -= rot._z;
                                                break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newRot = anim.Rotation;
                                rot._x = newRot._x - rot._x;
                                rot._y = newRot._y - rot._y;
                                rot._z = newRot._z - rot._z;
                                entry.SetKeyframeOnlyRot(0, rot);
                            }
                        }
                        hasKeyframe = false;
                        if (SubtractTrans.Checked)
                        {
                            for (int x = 0; x < numFrames; x++)
                            {
                                for (int i = 0x16; i < 0x19; i++)
                                {
                                    if ((kfe = entry.GetKeyframe((KeyFrameMode)i, x)) != null)
                                    {
                                        switch (i)
                                        {
                                            case 0x16:
                                                kfe._value -= trans._x;
                                                break;
                                            case 0x17:
                                                kfe._value -= trans._y;
                                                break;
                                            case 0x18:
                                                kfe._value -= trans._z;
                                                break;
                                        }
                                        hasKeyframe = true;
                                    }
                                }
                            }
                            if (!hasKeyframe)
                            {
                                anim = entry.GetAnimFrame(0);
                                Vector3 newTrans = anim.Translation;
                                trans._x = newTrans._x - trans._x;
                                trans._y = newTrans._y - trans._y;
                                trans._z = newTrans._z - trans._z;
                                entry.SetKeyframeOnlyTrans(0, trans);
                            }
                        }
                    }
                    r._changed = true;
                }
                ChangeNode(_name, r, scale, rot, trans, _targetModel, model, disLoop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }

        #region Designer

        private TextBox name;
        private Button btnCancel;
        private Label label1;
        private Button btnOkay;

        private void InitializeComponent()
        {
            this.name = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ScaleX = new System.Windows.Forms.TextBox();
            this.ScaleY = new System.Windows.Forms.TextBox();
            this.ScaleZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RotX = new System.Windows.Forms.TextBox();
            this.RotY = new System.Windows.Forms.TextBox();
            this.RotZ = new System.Windows.Forms.TextBox();
            this.TransX = new System.Windows.Forms.TextBox();
            this.TransY = new System.Windows.Forms.TextBox();
            this.TransZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ReplaceScale = new System.Windows.Forms.CheckBox();
            this.AddScale = new System.Windows.Forms.CheckBox();
            this.SubtractScale = new System.Windows.Forms.CheckBox();
            this.SubtractRot = new System.Windows.Forms.CheckBox();
            this.AddRot = new System.Windows.Forms.CheckBox();
            this.ReplaceRot = new System.Windows.Forms.CheckBox();
            this.SubtractTrans = new System.Windows.Forms.CheckBox();
            this.AddTrans = new System.Windows.Forms.CheckBox();
            this.ReplaceTrans = new System.Windows.Forms.CheckBox();
            this.copyKeyframes = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChangeVersion = new System.Windows.Forms.CheckBox();
            this.Version = new System.Windows.Forms.ComboBox();
            this.Port = new System.Windows.Forms.CheckBox();
            this.editLoop = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chr = new System.Windows.Forms.TabPage();
            this.srt = new System.Windows.Forms.TabPage();
            this.shp = new System.Windows.Forms.TabPage();
            this.pat = new System.Windows.Forms.TabPage();
            this.vis = new System.Windows.Forms.TabPage();
            this.enableLoop = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.chr.SuspendLayout();
            this.srt.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.HideSelection = false;
            this.name.Location = new System.Drawing.Point(11, 25);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(187, 20);
            this.name.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(333, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(252, 266);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "&Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Change all bone entries with the name:";
            // 
            // ScaleX
            // 
            this.ScaleX.Enabled = false;
            this.ScaleX.Location = new System.Drawing.Point(81, 73);
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.Size = new System.Drawing.Size(119, 20);
            this.ScaleX.TabIndex = 6;
            // 
            // ScaleY
            // 
            this.ScaleY.Enabled = false;
            this.ScaleY.Location = new System.Drawing.Point(81, 94);
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.Size = new System.Drawing.Size(119, 20);
            this.ScaleY.TabIndex = 7;
            // 
            // ScaleZ
            // 
            this.ScaleZ.Enabled = false;
            this.ScaleZ.Location = new System.Drawing.Point(81, 115);
            this.ScaleZ.Name = "ScaleZ";
            this.ScaleZ.Size = new System.Drawing.Size(119, 20);
            this.ScaleZ.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Scale X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Scale Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Scale Z:";
            // 
            // RotX
            // 
            this.RotX.Enabled = false;
            this.RotX.Location = new System.Drawing.Point(81, 164);
            this.RotX.Name = "RotX";
            this.RotX.Size = new System.Drawing.Size(119, 20);
            this.RotX.TabIndex = 12;
            // 
            // RotY
            // 
            this.RotY.Enabled = false;
            this.RotY.Location = new System.Drawing.Point(81, 185);
            this.RotY.Name = "RotY";
            this.RotY.Size = new System.Drawing.Size(119, 20);
            this.RotY.TabIndex = 13;
            // 
            // RotZ
            // 
            this.RotZ.Enabled = false;
            this.RotZ.Location = new System.Drawing.Point(81, 206);
            this.RotZ.Name = "RotZ";
            this.RotZ.Size = new System.Drawing.Size(119, 20);
            this.RotZ.TabIndex = 14;
            // 
            // TransX
            // 
            this.TransX.Enabled = false;
            this.TransX.Location = new System.Drawing.Point(275, 73);
            this.TransX.Name = "TransX";
            this.TransX.Size = new System.Drawing.Size(119, 20);
            this.TransX.TabIndex = 15;
            // 
            // TransY
            // 
            this.TransY.Enabled = false;
            this.TransY.Location = new System.Drawing.Point(275, 94);
            this.TransY.Name = "TransY";
            this.TransY.Size = new System.Drawing.Size(119, 20);
            this.TransY.TabIndex = 16;
            // 
            // TransZ
            // 
            this.TransZ.Enabled = false;
            this.TransZ.Location = new System.Drawing.Point(275, 115);
            this.TransZ.Name = "TransZ";
            this.TransZ.Size = new System.Drawing.Size(119, 20);
            this.TransZ.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rotate X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Rotate Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Rotate Z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Translate X:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Translate Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Translate Z:";
            // 
            // ReplaceScale
            // 
            this.ReplaceScale.AutoSize = true;
            this.ReplaceScale.Location = new System.Drawing.Point(11, 51);
            this.ReplaceScale.Name = "ReplaceScale";
            this.ReplaceScale.Size = new System.Drawing.Size(66, 17);
            this.ReplaceScale.TabIndex = 24;
            this.ReplaceScale.Text = "Replace";
            this.ReplaceScale.UseVisualStyleBackColor = true;
            this.ReplaceScale.CheckedChanged += new System.EventHandler(this.ReplaceScale_CheckedChanged);
            // 
            // AddScale
            // 
            this.AddScale.AutoSize = true;
            this.AddScale.Location = new System.Drawing.Point(76, 51);
            this.AddScale.Name = "AddScale";
            this.AddScale.Size = new System.Drawing.Size(45, 17);
            this.AddScale.TabIndex = 25;
            this.AddScale.Text = "Add";
            this.AddScale.UseVisualStyleBackColor = true;
            this.AddScale.CheckedChanged += new System.EventHandler(this.AddScale_CheckedChanged);
            // 
            // SubtractScale
            // 
            this.SubtractScale.AutoSize = true;
            this.SubtractScale.Location = new System.Drawing.Point(122, 51);
            this.SubtractScale.Name = "SubtractScale";
            this.SubtractScale.Size = new System.Drawing.Size(66, 17);
            this.SubtractScale.TabIndex = 26;
            this.SubtractScale.Text = "Subtract";
            this.SubtractScale.UseVisualStyleBackColor = true;
            this.SubtractScale.CheckedChanged += new System.EventHandler(this.SubtractScale_CheckedChanged);
            // 
            // SubtractRot
            // 
            this.SubtractRot.AutoSize = true;
            this.SubtractRot.Location = new System.Drawing.Point(122, 142);
            this.SubtractRot.Name = "SubtractRot";
            this.SubtractRot.Size = new System.Drawing.Size(66, 17);
            this.SubtractRot.TabIndex = 29;
            this.SubtractRot.Text = "Subtract";
            this.SubtractRot.UseVisualStyleBackColor = true;
            this.SubtractRot.CheckedChanged += new System.EventHandler(this.SubtractRot_CheckedChanged);
            // 
            // AddRot
            // 
            this.AddRot.AutoSize = true;
            this.AddRot.Location = new System.Drawing.Point(76, 142);
            this.AddRot.Name = "AddRot";
            this.AddRot.Size = new System.Drawing.Size(45, 17);
            this.AddRot.TabIndex = 28;
            this.AddRot.Text = "Add";
            this.AddRot.UseVisualStyleBackColor = true;
            this.AddRot.CheckedChanged += new System.EventHandler(this.AddRot_CheckedChanged);
            // 
            // ReplaceRot
            // 
            this.ReplaceRot.AutoSize = true;
            this.ReplaceRot.Location = new System.Drawing.Point(11, 142);
            this.ReplaceRot.Name = "ReplaceRot";
            this.ReplaceRot.Size = new System.Drawing.Size(66, 17);
            this.ReplaceRot.TabIndex = 27;
            this.ReplaceRot.Text = "Replace";
            this.ReplaceRot.UseVisualStyleBackColor = true;
            this.ReplaceRot.CheckedChanged += new System.EventHandler(this.ReplaceRot_CheckedChanged);
            // 
            // SubtractTrans
            // 
            this.SubtractTrans.AutoSize = true;
            this.SubtractTrans.Location = new System.Drawing.Point(326, 51);
            this.SubtractTrans.Name = "SubtractTrans";
            this.SubtractTrans.Size = new System.Drawing.Size(66, 17);
            this.SubtractTrans.TabIndex = 32;
            this.SubtractTrans.Text = "Subtract";
            this.SubtractTrans.UseVisualStyleBackColor = true;
            this.SubtractTrans.CheckedChanged += new System.EventHandler(this.SubtractTrans_CheckedChanged);
            // 
            // AddTrans
            // 
            this.AddTrans.AutoSize = true;
            this.AddTrans.Location = new System.Drawing.Point(275, 51);
            this.AddTrans.Name = "AddTrans";
            this.AddTrans.Size = new System.Drawing.Size(45, 17);
            this.AddTrans.TabIndex = 31;
            this.AddTrans.Text = "Add";
            this.AddTrans.UseVisualStyleBackColor = true;
            this.AddTrans.CheckedChanged += new System.EventHandler(this.AddTrans_CheckedChanged);
            // 
            // ReplaceTrans
            // 
            this.ReplaceTrans.AutoSize = true;
            this.ReplaceTrans.Location = new System.Drawing.Point(205, 51);
            this.ReplaceTrans.Name = "ReplaceTrans";
            this.ReplaceTrans.Size = new System.Drawing.Size(66, 17);
            this.ReplaceTrans.TabIndex = 30;
            this.ReplaceTrans.Text = "Replace";
            this.ReplaceTrans.UseVisualStyleBackColor = true;
            this.ReplaceTrans.CheckedChanged += new System.EventHandler(this.ReplaceTrans_CheckedChanged);
            // 
            // copyKeyframes
            // 
            this.copyKeyframes.AutoSize = true;
            this.copyKeyframes.Location = new System.Drawing.Point(206, 8);
            this.copyKeyframes.Name = "copyKeyframes";
            this.copyKeyframes.Size = new System.Drawing.Size(127, 17);
            this.copyKeyframes.TabIndex = 33;
            this.copyKeyframes.Text = "Copy keyframes from:";
            this.copyKeyframes.UseVisualStyleBackColor = true;
            this.copyKeyframes.CheckedChanged += new System.EventHandler(this.copyKeyframes_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(205, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 20);
            this.textBox1.TabIndex = 34;
            // 
            // ChangeVersion
            // 
            this.ChangeVersion.AutoSize = true;
            this.ChangeVersion.Location = new System.Drawing.Point(205, 141);
            this.ChangeVersion.Name = "ChangeVersion";
            this.ChangeVersion.Size = new System.Drawing.Size(103, 17);
            this.ChangeVersion.TabIndex = 35;
            this.ChangeVersion.Text = "Change version:";
            this.ChangeVersion.UseVisualStyleBackColor = true;
            this.ChangeVersion.CheckedChanged += new System.EventHandler(this.ChangeVersion_CheckedChanged);
            // 
            // Version
            // 
            this.Version.Enabled = false;
            this.Version.FormattingEnabled = true;
            this.Version.Items.AddRange(new object[] {
            "4",
            "5"});
            this.Version.Location = new System.Drawing.Point(314, 138);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(80, 21);
            this.Version.TabIndex = 36;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(205, 189);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(59, 17);
            this.Port.TabIndex = 37;
            this.Port.Text = "Port All";
            this.Port.UseVisualStyleBackColor = true;
            // 
            // editLoop
            // 
            this.editLoop.AutoSize = true;
            this.editLoop.Location = new System.Drawing.Point(205, 166);
            this.editLoop.Name = "editLoop";
            this.editLoop.Size = new System.Drawing.Size(74, 17);
            this.editLoop.TabIndex = 38;
            this.editLoop.Text = "Edit Loop:";
            this.editLoop.UseVisualStyleBackColor = true;
            this.editLoop.CheckedChanged += new System.EventHandler(this.editLoop_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.chr);
            this.tabControl1.Controls.Add(this.srt);
            this.tabControl1.Controls.Add(this.shp);
            this.tabControl1.Controls.Add(this.pat);
            this.tabControl1.Controls.Add(this.vis);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 263);
            this.tabControl1.TabIndex = 39;
            // 
            // chr
            // 
            this.chr.BackColor = System.Drawing.SystemColors.Control;
            this.chr.Controls.Add(this.enableLoop);
            this.chr.Controls.Add(this.name);
            this.chr.Controls.Add(this.label1);
            this.chr.Controls.Add(this.ScaleX);
            this.chr.Controls.Add(this.ScaleY);
            this.chr.Controls.Add(this.ScaleZ);
            this.chr.Controls.Add(this.label3);
            this.chr.Controls.Add(this.label4);
            this.chr.Controls.Add(this.label5);
            this.chr.Controls.Add(this.RotX);
            this.chr.Controls.Add(this.RotY);
            this.chr.Controls.Add(this.RotZ);
            this.chr.Controls.Add(this.TransX);
            this.chr.Controls.Add(this.TransY);
            this.chr.Controls.Add(this.TransZ);
            this.chr.Controls.Add(this.label6);
            this.chr.Controls.Add(this.label7);
            this.chr.Controls.Add(this.label8);
            this.chr.Controls.Add(this.label9);
            this.chr.Controls.Add(this.label10);
            this.chr.Controls.Add(this.label11);
            this.chr.Controls.Add(this.SubtractScale);
            this.chr.Controls.Add(this.AddScale);
            this.chr.Controls.Add(this.ReplaceScale);
            this.chr.Controls.Add(this.SubtractRot);
            this.chr.Controls.Add(this.AddRot);
            this.chr.Controls.Add(this.ReplaceRot);
            this.chr.Controls.Add(this.ReplaceTrans);
            this.chr.Controls.Add(this.AddTrans);
            this.chr.Controls.Add(this.SubtractTrans);
            this.chr.Controls.Add(this.copyKeyframes);
            this.chr.Controls.Add(this.textBox1);
            this.chr.Controls.Add(this.ChangeVersion);
            this.chr.Controls.Add(this.Version);
            this.chr.Controls.Add(this.Port);
            this.chr.Controls.Add(this.editLoop);
            this.chr.Location = new System.Drawing.Point(4, 25);
            this.chr.Name = "chr";
            this.chr.Padding = new System.Windows.Forms.Padding(3);
            this.chr.Size = new System.Drawing.Size(404, 234);
            this.chr.TabIndex = 0;
            this.chr.Text = "CHR0";
            // 
            // srt
            // 
            this.srt.BackColor = System.Drawing.SystemColors.Control;
            this.srt.Controls.Add(this.checkBox1);
            this.srt.Controls.Add(this.textBox5);
            this.srt.Controls.Add(this.label14);
            this.srt.Controls.Add(this.textBox2);
            this.srt.Controls.Add(this.label2);
            this.srt.Controls.Add(this.textBox3);
            this.srt.Controls.Add(this.textBox4);
            this.srt.Controls.Add(this.label12);
            this.srt.Controls.Add(this.label13);
            this.srt.Controls.Add(this.textBox6);
            this.srt.Controls.Add(this.textBox9);
            this.srt.Controls.Add(this.textBox10);
            this.srt.Controls.Add(this.label15);
            this.srt.Controls.Add(this.label18);
            this.srt.Controls.Add(this.label19);
            this.srt.Controls.Add(this.checkBox2);
            this.srt.Controls.Add(this.checkBox3);
            this.srt.Controls.Add(this.checkBox4);
            this.srt.Controls.Add(this.checkBox5);
            this.srt.Controls.Add(this.checkBox6);
            this.srt.Controls.Add(this.checkBox7);
            this.srt.Controls.Add(this.checkBox10);
            this.srt.Controls.Add(this.checkBox9);
            this.srt.Controls.Add(this.checkBox8);
            this.srt.Controls.Add(this.checkBox11);
            this.srt.Controls.Add(this.textBox12);
            this.srt.Controls.Add(this.checkBox12);
            this.srt.Controls.Add(this.comboBox1);
            this.srt.Controls.Add(this.checkBox14);
            this.srt.Location = new System.Drawing.Point(4, 25);
            this.srt.Name = "srt";
            this.srt.Padding = new System.Windows.Forms.Padding(3);
            this.srt.Size = new System.Drawing.Size(404, 234);
            this.srt.TabIndex = 1;
            this.srt.Text = "SRT0";
            // 
            // shp
            // 
            this.shp.BackColor = System.Drawing.SystemColors.Control;
            this.shp.Location = new System.Drawing.Point(4, 25);
            this.shp.Name = "shp";
            this.shp.Size = new System.Drawing.Size(404, 234);
            this.shp.TabIndex = 2;
            this.shp.Text = "SHP0";
            // 
            // pat
            // 
            this.pat.BackColor = System.Drawing.SystemColors.Control;
            this.pat.Location = new System.Drawing.Point(4, 25);
            this.pat.Name = "pat";
            this.pat.Size = new System.Drawing.Size(404, 234);
            this.pat.TabIndex = 3;
            this.pat.Text = "PAT0";
            // 
            // vis
            // 
            this.vis.BackColor = System.Drawing.SystemColors.Control;
            this.vis.Location = new System.Drawing.Point(4, 25);
            this.vis.Name = "vis";
            this.vis.Size = new System.Drawing.Size(404, 234);
            this.vis.TabIndex = 4;
            this.vis.Text = "VIS0";
            // 
            // enableLoop
            // 
            this.enableLoop.AutoSize = true;
            this.enableLoop.Enabled = false;
            this.enableLoop.Location = new System.Drawing.Point(279, 166);
            this.enableLoop.Name = "enableLoop";
            this.enableLoop.Size = new System.Drawing.Size(92, 17);
            this.enableLoop.TabIndex = 39;
            this.enableLoop.Text = "Loop Enabled";
            this.enableLoop.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(11, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Change all textures with the name:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(81, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 20);
            this.textBox3.TabIndex = 42;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(81, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(119, 20);
            this.textBox4.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Scale X:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "Scale Y:";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(82, 139);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(119, 20);
            this.textBox6.TabIndex = 48;
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(81, 188);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(119, 20);
            this.textBox9.TabIndex = 51;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(81, 209);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(119, 20);
            this.textBox10.TabIndex = 52;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Rotation:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "Translate X:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 214);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 58;
            this.label19.Text = "Translate Y:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(123, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 62;
            this.checkBox2.Text = "Subtract";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(77, 51);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(45, 17);
            this.checkBox3.TabIndex = 61;
            this.checkBox3.Text = "Add";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(12, 51);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 60;
            this.checkBox4.Text = "Replace";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(123, 118);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 17);
            this.checkBox5.TabIndex = 65;
            this.checkBox5.Text = "Subtract";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(77, 118);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(45, 17);
            this.checkBox6.TabIndex = 64;
            this.checkBox6.Text = "Add";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(12, 118);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(66, 17);
            this.checkBox7.TabIndex = 63;
            this.checkBox7.Text = "Replace";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(12, 166);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(66, 17);
            this.checkBox8.TabIndex = 66;
            this.checkBox8.Text = "Replace";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(77, 166);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(45, 17);
            this.checkBox9.TabIndex = 67;
            this.checkBox9.Text = "Add";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(123, 166);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(66, 17);
            this.checkBox10.TabIndex = 68;
            this.checkBox10.Text = "Subtract";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(205, 51);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(127, 17);
            this.checkBox11.TabIndex = 69;
            this.checkBox11.Text = "Copy keyframes from:";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(204, 73);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(189, 20);
            this.textBox12.TabIndex = 70;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(205, 141);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(103, 17);
            this.checkBox12.TabIndex = 71;
            this.checkBox12.Text = "Change version:";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(314, 139);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 21);
            this.comboBox1.TabIndex = 72;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(205, 166);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(74, 17);
            this.checkBox14.TabIndex = 74;
            this.checkBox14.Text = "Edit Loop:";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.HideSelection = false;
            this.textBox5.Location = new System.Drawing.Point(204, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(187, 20);
            this.textBox5.TabIndex = 75;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(203, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 13);
            this.label14.TabIndex = 76;
            this.label14.Text = "Only modify materials with the name:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(279, 166);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 77;
            this.checkBox1.Text = "Loop Enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ChangeToDialog2
            // 
            this.AcceptButton = this.btnOkay;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 296);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeToDialog2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit All Animations";
            this.tabControl1.ResumeLayout(false);
            this.chr.ResumeLayout(false);
            this.chr.PerformLayout();
            this.srt.ResumeLayout(false);
            this.srt.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Check Switches
        private void ReplaceScale_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = SubtractScale.Enabled = !ReplaceScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = ReplaceScale.Checked;
        }

        private void AddScale_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceScale.Enabled = SubtractScale.Enabled = !AddScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = AddScale.Checked;
        }

        private void SubtractScale_CheckedChanged(object sender, EventArgs e)
        {
            AddScale.Enabled = ReplaceScale.Enabled = !SubtractScale.Checked;
            ScaleX.Enabled = ScaleY.Enabled = ScaleZ.Enabled = SubtractScale.Checked;
        }

        private void ReplaceRot_CheckedChanged(object sender, EventArgs e)
        {
            AddRot.Enabled = SubtractRot.Enabled = !ReplaceRot.Checked;
            RotX.Enabled = RotY.Enabled = RotZ.Enabled = ReplaceRot.Checked;
        }

        private void AddRot_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceRot.Enabled = SubtractRot.Enabled = !AddRot.Checked;
            RotX.Enabled = RotY.Enabled = RotZ.Enabled = AddRot.Checked;
        }

        private void SubtractRot_CheckedChanged(object sender, EventArgs e)
        {
            AddRot.Enabled = ReplaceRot.Enabled = !SubtractRot.Checked;
            RotX.Enabled = RotY.Enabled = RotZ.Enabled = SubtractRot.Checked;
        }

        private void ReplaceTrans_CheckedChanged(object sender, EventArgs e)
        {
            AddTrans.Enabled = SubtractTrans.Enabled = !ReplaceTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = ReplaceTrans.Checked;
        }

        private void AddTrans_CheckedChanged(object sender, EventArgs e)
        {
            ReplaceTrans.Enabled = SubtractTrans.Enabled = !AddTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = AddTrans.Checked;
        }

        private void SubtractTrans_CheckedChanged(object sender, EventArgs e)
        {
            AddTrans.Enabled = ReplaceTrans.Enabled = !SubtractTrans.Checked;
            TransX.Enabled = TransY.Enabled = TransZ.Enabled = SubtractTrans.Checked;
        }
        #endregion

        private void copyKeyframes_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = copyKeyframes.Checked;
        }

        private void ChangeVersion_CheckedChanged(object sender, EventArgs e)
        {
            Version.Enabled = ChangeVersion.Checked;
        }

        private void editLoop_CheckedChanged(object sender, EventArgs e)
        {
            enableLoop.Enabled = editLoop.Checked;
        }
    }
}
