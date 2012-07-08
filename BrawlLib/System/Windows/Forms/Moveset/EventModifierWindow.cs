﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.Reflection;

namespace System.Windows.Forms
{
    public class FormModifyEvent : Form
    {
        public EventModifier eventModifier1;
        public FormModifyEvent() { InitializeComponent(); }
        private void InitializeComponent()
        {
            this.eventModifier1 = new System.Windows.Forms.EventModifier();
            this.SuspendLayout();
            // 
            // eventModifier1
            // 
            this.eventModifier1.AutoSize = true;
            this.eventModifier1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventModifier1.Location = new System.Drawing.Point(0, 0);
            this.eventModifier1.Name = "eventModifier1";
            this.eventModifier1.Size = new System.Drawing.Size(284, 262);
            this.eventModifier1.TabIndex = 0;
            this.eventModifier1.Completed += new System.EventHandler(this.eventModifier1_Completed);
            // 
            // FormModifyEvent
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.eventModifier1);
            this.Name = "FormModifyEvent";
            this.Text = "Event Modifier";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void eventModifier1_Completed(object sender, EventArgs e)
        {
            DialogResult = eventModifier1.status; Close();
        }
    }
}
