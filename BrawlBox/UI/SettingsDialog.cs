﻿using System;
using System.Windows.Forms;
using System.IO;
namespace BrawlBox
{
    class SettingsDialog : Form
    {
        private static FileAssociation[] _assocList =new FileAssociation[] {
                FileAssociation.Get(".pac"),
                FileAssociation.Get(".pcs"),
                FileAssociation.Get(".arc"),
                FileAssociation.Get(".szs"),
                FileAssociation.Get(".brres"),
                FileAssociation.Get(".brmdl"),
                FileAssociation.Get(".brtex"),
                FileAssociation.Get(".msbin"),
                FileAssociation.Get(".brsar"),
                FileAssociation.Get(".brstm"),

                FileAssociation.Get(".tex0"),
                FileAssociation.Get(".plt0"),
                FileAssociation.Get(".mdl0"),
                FileAssociation.Get(".chr0"),
                FileAssociation.Get(".srt0"),
                FileAssociation.Get(".shp0"),
                FileAssociation.Get(".pat0"),
                FileAssociation.Get(".vis0"),
                FileAssociation.Get(".scn0"),
                FileAssociation.Get(".clr0"),

                FileAssociation.Get(".efls"),
                FileAssociation.Get(".breff"),
                FileAssociation.Get(".breft"),

                FileAssociation.Get(".brwsd"),
                FileAssociation.Get(".brbnk"),
                FileAssociation.Get(".brseq"),

                FileAssociation.Get(".dol"),
                FileAssociation.Get(".rel"),

                FileAssociation.Get(".tpl"),
            };

        private static FileType[] _typeList = new FileType[]{
            FileType.Get("SSBB.PAC"),
            FileType.Get("SSBB.PCS"),
            FileType.Get("SSBB.ARC"),
            FileType.Get("SSBB.SZS"),
            FileType.Get("SSBB.BRRES"),
            FileType.Get("SSBB.BRMDL"),
            FileType.Get("SSBB.BRTEX"),
            FileType.Get("SSBB.MSBIN"),
            FileType.Get("SSBB.BRSAR"),
            FileType.Get("SSBB.BRSTM"),

            FileType.Get("SSBB.TEX0"),
            FileType.Get("SSBB.PLT0"),
            FileType.Get("SSBB.MDL0"),
            FileType.Get("SSBB.CHR0"),
            FileType.Get("SSBB.SRT0"),
            FileType.Get("SSBB.SHP0"),
            FileType.Get("SSBB.PAT0"),
            FileType.Get("SSBB.VIS0"),
            FileType.Get("SSBB.SCN0"),
            FileType.Get("SSBB.CLR0"),

            FileType.Get("SSBB.EFLS"),
            FileType.Get("SSBB.BREFF"),
            FileType.Get("SSBB.BREFT"),

            FileType.Get("SSBB.BRWSD"),
            FileType.Get("SSBB.BRBNK"),
            FileType.Get("SSBB.BRSEQ"),

            FileType.Get("SSBB.DOL"),
            FileType.Get("SSBB.REL"),

            FileType.Get("SSBB.TPL"),
        };

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void Apply()
        {
            bool check;
            int index = 0;
            foreach (ListViewItem i in listView1.Items)
            {
                if ((check = i.Checked) != (bool)i.Tag)
                {
                    if (check)
                    {
                        _assocList[index].FileType = _typeList[index];
                        _typeList[index].SetCommand("open", String.Format("\"{0}\" \"%1\"", Program.FullPath));
                    }
                    else 
                    {
                        _typeList[index].Delete();
                        _assocList[index].Delete();
                    }
                    i.Tag = check;
                }
                index++;
            }
            btnApply.Enabled = false;
        }
        private void SettingsDialog_Shown(object sender, EventArgs e)
        {
            int index = 0;
            string cmd;
            foreach (ListViewItem i in listView1.Items)
            {
                if ((_typeList[index] == _assocList[index].FileType) &&
                    (!String.IsNullOrEmpty(cmd = _typeList[index].GetCommand("open"))) &&
                    (cmd.IndexOf(Program.FullPath, StringComparison.OrdinalIgnoreCase) >= 0))
                    i.Tag = i.Checked = true;
                else
                    i.Tag = i.Checked = false;
                index++;
            }
            btnApply.Enabled = false;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnApply.Enabled = true;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }
        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (btnApply.Enabled)
                Apply();

            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Designer

        private GroupBox groupBox1;
        private ListView listView1;
        private CheckBox checkBox1;
        private Button btnOkay;
        private Button btnCancel;
        private Button btnApply;
        private ColumnHeader columnHeader1;
    
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("File Types", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Resource Types", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("ARChive Pack (*.pac)");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Compressed ARChive Pack (*.pcs)");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("ARChive (*.arc)");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Compressed ARChive (*.szs)");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Resource Pack (*.brres)");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Model Pack (*.brmdl)");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Texture Pack (*.brtex)");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("MSBin Message List (*.msbin)");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Sound Archive (*.brsar)");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Sound Stream (*.brstm)");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Texture (*.tex0)");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Palette (*.plt0)");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Model (*.mdl0)");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("Model Animation (*.chr0)");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("Texture Animation (*.srt0)");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("Vertex Morph (*.shp0)");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("Texture Pattern (*.pat0)");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("Bone Visibility (*.vis0)");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("Scene Settings (*.scn0)");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("Color Sequence (*.clr0)");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("Effect List (*.efls)");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("Effect Parameters (*.breff)");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("Effect Textures (*.breft)");
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("Sound Stream (*.brwsd)");
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem("Sound Bank (*.brbnk)");
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("Sound Sequence (*.brseq)");
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("Static Module (*.dol)");
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("Relocatable Module (*.rel)");
            System.Windows.Forms.ListViewItem listViewItem29 = new System.Windows.Forms.ListViewItem("Texture Archive (*.tpl)");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Associations";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Location = new System.Drawing.Point(121, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(104, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Check All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            listViewGroup1.Header = "File Types";
            listViewGroup1.Name = "grpFileTypes";
            listViewGroup2.Header = "Resource Types";
            listViewGroup2.Name = "grpResTypes";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.Tag = "";
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem5.Tag = "";
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.StateImageIndex = 0;
            listViewItem8.Tag = "";
            listViewItem9.StateImageIndex = 0;
            listViewItem10.StateImageIndex = 0;
            listViewItem11.StateImageIndex = 0;
            listViewItem12.StateImageIndex = 0;
            listViewItem13.StateImageIndex = 0;
            listViewItem14.StateImageIndex = 0;
            listViewItem15.StateImageIndex = 0;
            listViewItem16.StateImageIndex = 0;
            listViewItem17.StateImageIndex = 0;
            listViewItem18.StateImageIndex = 0;
            listViewItem19.StateImageIndex = 0;
            listViewItem20.StateImageIndex = 0;
            listViewItem21.StateImageIndex = 0;
            listViewItem22.StateImageIndex = 0;
            listViewItem23.StateImageIndex = 0;
            listViewItem24.StateImageIndex = 0;
            listViewItem25.StateImageIndex = 0;
            listViewItem26.StateImageIndex = 0;
            listViewItem27.StateImageIndex = 0;
            listViewItem28.StateImageIndex = 0;
            listViewItem29.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28,
            listViewItem29});
            this.listView1.Location = new System.Drawing.Point(3, 37);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 206);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(13, 267);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 1;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(94, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(175, 267);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // SettingsDialog
            // 
            this.ClientSize = new System.Drawing.Size(262, 302);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.SettingsDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            foreach (ListViewItem i in listView1.Items)
                i.Checked = check;
        }
    }
}
