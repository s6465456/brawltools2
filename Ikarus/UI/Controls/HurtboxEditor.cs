﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;

namespace Ikarus.UI.Controls
{
    public partial class HurtboxEditor : UserControl
    {
        public HurtboxEditor()
        {
            InitializeComponent();
            numRegion._integral = true;
            numRegion._maxValue = 3;
            numRegion._minValue = 0;
            SelectedZone.Items.AddRange(Enum.GetNames(typeof(HurtBoxZone)));
        }

        public void _mainControl_TargetModelChanged(object sender, EventArgs e)
        {
            SelectedBone.Items.Clear();
            SelectedBone.Items.AddRange(MainForm.Instance._mainControl.TargetModel._linker.BoneCache);
        }

        bool _updating = false;
        public MoveDefHurtBoxNode _targetHurtbox;
        public MoveDefHurtBoxNode TargetHurtBox
        {
            get { return _targetHurtbox; }
            set
            {
                if (Enabled = (_targetHurtbox = value) != null)
                {
                    _updating = true;

                    numTransX.Value = _targetHurtbox.PosOffset._x;
                    numTransY.Value = _targetHurtbox.PosOffset._y;
                    numTransZ.Value = _targetHurtbox.PosOffset._z;
                    numRotX.Value = _targetHurtbox.Stretch._x;
                    numRotY.Value = _targetHurtbox.Stretch._y;
                    numRotZ.Value = _targetHurtbox.Stretch._z;
                    numRadius.Value = _targetHurtbox.Radius;
                    numRegion.Value = _targetHurtbox.Region;
                    SelectedZone.SelectedIndex = (int)_targetHurtbox.Zone;
                    SelectedBone.SelectedIndex = Array.IndexOf(MainForm.Instance._mainControl.TargetModel._linker.BoneCache, _targetHurtbox.BoneNode);
                    checkBox1.Checked = _targetHurtbox.Enabled;

                    _updating = false;
                }
            }
        }
        
        private void BoxChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _targetHurtbox.PosOffset = new Vector3(numTransX.Value, numTransY.Value, numTransZ.Value);
            _targetHurtbox.Stretch = new Vector3(numRotX.Value, numRotY.Value, numRotZ.Value);
            _targetHurtbox.Radius = numRadius.Value;
            _targetHurtbox.Region = (int)numRegion.Value;
            _targetHurtbox.BoneNode = SelectedBone.SelectedItem as MDL0BoneNode;
            _targetHurtbox.Zone = (HurtBoxZone)SelectedZone.SelectedIndex;

            MainForm.Instance._mainControl.ModelPanel.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            _targetHurtbox.Enabled = checkBox1.Checked;
        }
    }
}
