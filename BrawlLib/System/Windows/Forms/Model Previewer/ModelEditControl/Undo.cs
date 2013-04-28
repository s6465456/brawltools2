﻿using System;
using BrawlLib.OpenGL;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlLib.Modeling;
using System.Drawing;
using BrawlLib.Wii.Animations;
using System.Collections.Generic;
using BrawlLib.SSBBTypes;
using BrawlLib.IO;
using BrawlLib;
using System.Drawing.Imaging;
using Gif.Components;
using OpenTK.Graphics.OpenGL;
using BrawlLib.Imaging;
using System.Collections;

namespace System.Windows.Forms
{
    public partial class ModelEditControl : UserControl
    {
        public uint _allowedUndos = 50;
        public List<SaveState> _undoSaves = new List<SaveState>();
        public List<SaveState> _redoSaves = new List<SaveState>();
        public int _saveIndex = -1;
        bool _undoing = true;

        private void AddUndo(SaveState save)
        {
            int i = _saveIndex + 1;
            if (_undoSaves.Count > i)
            {
                _undoSaves.RemoveRange(i, _undoSaves.Count - i);
                _redoSaves.RemoveRange(i, _redoSaves.Count - i);
            }

            _undoSaves.Add(save);
            _undoing = true;

            if (_undoSaves.Count > _allowedUndos)
            {
                _undoSaves.RemoveAt(0);
                _redoSaves.RemoveAt(0);
                _saveIndex--;
            }
        }
        private void AddRedo(SaveState save)
        {
            _redoSaves.Add(save);
            _saveIndex++;
            UpdateUndoButtons();
        }

        public void BoneChange(MDL0BoneNode bone, bool before)
        {
            SaveState state = new SaveState();
            state._bone = bone;
            state._frameState = bone._frameState;
            state._animation = SelectedCHR0;
            state._frameIndex = CurrentFrame;

            if (before)
                AddUndo(state);
            else
                AddRedo(state);
        }

        public void VertexChange(List<Vertex3> vertices, bool before)
        {
            SaveState state = new SaveState();
            state._vertices = vertices;
            state._targetModel = TargetModel;
            state._translation = (Vector3)VertexLoc;

            if (before)
                AddUndo(state);
            else
                AddRedo(state);
        }

        public bool CanUndo { get { return _saveIndex > -1; } }
        public bool CanRedo { get { return _saveIndex < _undoSaves.Count; } }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (CanUndo)
            {
                modelPanel.BeginUpdate();

                if (!_undoing) 
                    _saveIndex--;
                _undoing = true;

                Apply(_undoSaves[_saveIndex]);

                //Decrement index after applying save
                _saveIndex--;

                UpdateUndoButtons();

                modelPanel.EndUpdate();
                modelPanel.Invalidate();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (CanRedo)
            {
                modelPanel.BeginUpdate();

                if (_undoing) 
                    _saveIndex++;
                _undoing = false;

                Apply(_redoSaves[_saveIndex]);

                //Increment index after applying save
                _saveIndex++;

                UpdateUndoButtons();

                modelPanel.EndUpdate();
                modelPanel.Invalidate();
            }
        }

        private void Apply(SaveState s)
        {
            if (s._frameState != null)
            {
                SelectedCHR0 = s._animation;
                CurrentFrame = s._frameIndex;
                pnlBones.SelectedBone = s._bone;
                chr0Editor.ApplyState(s);
            }
            else if (s._vertices != null)
            {
                if (TargetModel != s._targetModel)
                    TargetModel = s._targetModel;

                Vector3 diff = _redoSaves[_saveIndex]._translation - _undoSaves[_saveIndex]._translation;
                if (!_undoing) diff = -diff;
                foreach (Vertex3 v in s._vertices)
                {
                    v._weightedPosition -= diff;
                    v.Unweight();
                }
                UpdateModel();
            }
        }

        public void UpdateUndoButtons()
        {
            btnUndo.Enabled = CanUndo;
            btnRedo.Enabled = CanRedo;
        }
    }
}
