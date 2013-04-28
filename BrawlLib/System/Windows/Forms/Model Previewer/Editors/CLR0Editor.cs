﻿using System;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Modeling;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;
using BrawlLib.Imaging;

namespace System.Windows.Forms
{
    public class CLR0Editor : UserControl
    {
        #region Designer

        private System.ComponentModel.IContainer components;
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstTarget = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstTarget
            // 
            this.lstTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTarget.FormattingEnabled = true;
            this.lstTarget.Items.AddRange(new object[] {
            "Color0",
            "Color1",
            "Ambient0",
            "Ambient1",
            "TevColorReg0",
            "TevColorReg1",
            "TevColorReg2",
            "TevKonstReg0",
            "TevKonstReg1",
            "TevKonstReg2",
            "TevKonstReg3"});
            this.lstTarget.Location = new System.Drawing.Point(-1, 18);
            this.lstTarget.Name = "lstTarget";
            this.lstTarget.Size = new System.Drawing.Size(100, 21);
            this.lstTarget.TabIndex = 2;
            this.lstTarget.SelectedIndexChanged += new System.EventHandler(this.lstTarget_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 40);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstTarget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(156, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 40);
            this.panel1.TabIndex = 5;
            // 
            // CLR0Editor
            // 
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CLR0Editor";
            this.Size = new System.Drawing.Size(256, 40);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ModelEditControl _mainWindow;

        private Label label1;
        private ListBox listBox1;
        private Panel panel1;
        public ComboBox lstTarget;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0MaterialRefNode TargetTexRef { get { return _mainWindow._targetTexRef; } set { _mainWindow.TargetTexRef = value; } }

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
        public CLR0Node SelectedAnimation
        {
            get { return _mainWindow.SelectedCLR0; }
            set { _mainWindow.SelectedCLR0 = value; }
        }

        public void UpdateAnimation()
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            if (_mainWindow._clr0 != null)
                foreach (CLR0MaterialNode n in _mainWindow._clr0.Children)
                    listBox1.Items.Add(n);
            listBox1.EndUpdate();
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            lstTarget.SelectedIndex = 0;
        }
        public CLR0MaterialNode _mat;
        public CLR0MaterialEntryNode _entry;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mat = (CLR0MaterialNode)(listBox1.Items[listBox1.SelectedIndex] as CLR0MaterialNode);
            if (_mat.Children.Count > 0)
                lstTarget.SelectedIndex = (int)((CLR0MaterialEntryNode)_mat.Children[0]).Target;
            else
                lstTarget.SelectedIndex = 0;
        }

        public CLR0Editor()
        {
            InitializeComponent(); 
        }

        private void lstTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mat == null)
            {
                _mainWindow.pnlKeyframes.chkEnabled.Checked = false;
                _mainWindow.pnlKeyframes.chkConstant.Checked = false;
                return;
            }
            _entry = _mat.FindChild(lstTarget.SelectedItem as string, false) as CLR0MaterialEntryNode;
            _mainWindow.pnlKeyframes.chkEnabled.Checked = _entry != null;
            _mainWindow.pnlKeyframes.chkConstant.Checked = _entry != null ? _entry.Constant : false;
            _mainWindow.pnlKeyframes.TargetSequence = _entry;
        }
    }
}
