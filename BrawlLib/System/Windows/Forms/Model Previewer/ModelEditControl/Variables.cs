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

namespace System.Windows.Forms
{
    public partial class ModelEditControl : UserControl
    {
        private const float _orbRadius = 1.0f;
        private const float _circRadius = 1.2f;
        private const float _axisSnapRange = 7.0f;
        private const float _selectRange = 0.03f; //Selection error range for orb and circ
        private const float _axisSelectRange = 0.15f; //Selection error range for axes
        private const float _selectOrbScale = _selectRange / _orbRadius;
        private const float _circOrbScale = _circRadius / _orbRadius;

        public event EventHandler TargetModelChanged;

        private delegate void DelegateOpenFile(String s);
        private DelegateOpenFile m_DelegateOpenFile;

        public int _animFrame = 0, _maxFrame;
        public bool _updating, _loop;
        
        public CHR0Node _chr0;
        public SRT0Node _srt0;
        public SHP0Node _shp0;
        public PAT0Node _pat0;
        public VIS0Node _vis0;
        public SCN0Node _scn0;
        public CLR0Node _clr0;

        public bool _rotating, _translating, _scaling;
        private Vector3 _lastPointBone, _firstPointBone, _lastPointWorld, _firstPointWorld;
        private Vector3 _oldAngles, _oldPosition, _oldScale;
        private bool _snapX, _snapY, _snapZ, _snapCirc;
        private bool _hiX, _hiY, _hiZ, _hiCirc, _hiSphere;

        public List<MDL0Node> _targetModels = new List<MDL0Node>();
        private MDL0Node _targetModel;

        public Color _clearColor;
        public MDL0MaterialRefNode _targetTexRef = null;
        public Vertex3 _targetVertex = null;
        public VIS0EntryNode _targetVisEntry;
        public bool _enableTransform = true;

        public bool _renderFloor, _renderBones = true, _renderBox, _dontRenderOffscreen = true, _renderVertices, _renderNormals, _renderHurtboxes, _renderHitboxes;
        public CheckState _renderPolygons = CheckState.Checked;

        public ResourceNode GetSelectedBRRESFile(AnimType type)
        {
            switch (type)
            {
                case AnimType.CHR: return SelectedCHR0;
                case AnimType.SRT: return SelectedSRT0;
                case AnimType.SHP: return SelectedSHP0;
                case AnimType.PAT: return SelectedPAT0;
                case AnimType.VIS: return SelectedVIS0;
                case AnimType.SCN: return SelectedSCN0;
                case AnimType.CLR: return SelectedCLR0;
                default: return null;
            }
        }
        public void SetSelectedBRRESFile(AnimType type, ResourceNode value)
        {
            switch (type)
            {
                case AnimType.CHR: SelectedCHR0 = value as CHR0Node; break;
                case AnimType.SRT: SelectedSRT0 = value as SRT0Node; break;
                case AnimType.SHP: SelectedSHP0 = value as SHP0Node; break;
                case AnimType.PAT: SelectedPAT0 = value as PAT0Node; break;
                case AnimType.VIS: SelectedVIS0 = value as VIS0Node; break;
                case AnimType.SCN: SelectedSCN0 = value as SCN0Node; break;
                case AnimType.CLR: SelectedCLR0 = value as CLR0Node; break;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0Node TargetModel { get { return _targetModel; } set { ModelChanged(value); } }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CHR0Node SelectedCHR0
        { 
            get { return _chr0; } 
            set 
            {
                _chr0 = value;

                if (_updating)
                    return;

                AnimChanged(AnimType.CHR);
                UpdatePropDisplay();
            } 
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SRT0Node SelectedSRT0 
        { 
            get { return _srt0; } 
            set 
            { 
                _srt0 = value;

                if (_updating)
                    return;

                AnimChanged(AnimType.SRT);
                UpdatePropDisplay();
            } 
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SHP0Node SelectedSHP0
        {
            get { return _shp0; }
            set
            {
                _shp0 = value;

                if (_updating)
                    return;

                AnimChanged(AnimType.SHP);
                UpdatePropDisplay();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PAT0Node SelectedPAT0
        {
            get { return _pat0; }
            set
            {
                _pat0 = value; 
                
                if (_updating)
                    return;

                AnimChanged(AnimType.PAT);
                UpdatePropDisplay();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0Node SelectedVIS0
        {
            get { return _vis0; }
            set
            {
                _vis0 = value; 
                
                if (_updating)
                    return;

                AnimChanged(AnimType.VIS);
                UpdatePropDisplay();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SCN0Node SelectedSCN0
        {
            get { return _scn0; }
            set
            {
                _scn0 = value;

                if (_updating)
                    return;

                AnimChanged(AnimType.SCN);
                UpdatePropDisplay();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CLR0Node SelectedCLR0
        {
            get { return _clr0; }
            set
            {
                _clr0 = value;

                if (_updating)
                    return;

                AnimChanged(AnimType.CLR);
                UpdatePropDisplay();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ClearColor { get { return _clearColor; } set { _clearColor = value; } }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image BGImage { get { return modelPanel.BackgroundImage; } set { modelPanel.BackgroundImage = value; } }

        //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public Vertex3 TargetVertex 
        //{
        //    get { return _targetVertex; }
        //    set
        //    {
        //        if (_targetVertex != null)
        //        {
        //            _targetVertex._highlightColor = Color.Transparent;
        //            if (_selectedVertices.Contains(_targetVertex))
        //                _selectedVertices.Remove(_targetVertex);
        //        }
        //        if ((_targetVertex = value) != null)
        //        {
        //            _targetVertex._highlightColor = Color.Orange;
        //            _targetVertex._selected = true;
        //            if (!_selectedVertices.Contains(_targetVertex))
        //                _selectedVertices.Add(_targetVertex);
        //        }
        //        //weightEditor.TargetVertex = _targetVertex;
        //        UpdatePropDisplay();
        //    }
        //}

        MDL0BoneNode _selectedBone = null;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0BoneNode SelectedBone 
        {
            get { return _selectedBone; } 
            set 
            {
                if (_selectedBone != null)
                    _selectedBone._boneColor = _selectedBone._nodeColor = Color.Transparent;
                
                if ((_selectedBone = value) != null)
                {
                    _selectedBone._boneColor = Color.FromArgb(0, 128, 255);
                    _selectedBone._nodeColor = Color.FromArgb(255, 128, 0);
                }

                if (models.SelectedItem != null & !(models.SelectedItem is MDL0Node) && models.SelectedItem.ToString() == "All")
                    if (_selectedBone != null)
                        if (TargetModel != _selectedBone.Model)
                        {
                            //The user selected a bone from another model.
                            TargetModel = _selectedBone.Model;
                            _resetCam = false;
                        }

                pnlBones.lstBones.SelectedItem = _selectedBone;
                weightEditor.BoneChanged();
                //UpdatePropDisplay();
                chr0Editor.UpdatePropDisplay();

                if (_chr0 != null && _selectedBone != null && pnlAssets.fileType.SelectedIndex == 0)
                    pnlKeyframes.TargetSequence = _chr0.FindChild(_selectedBone.Name, false);
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MDL0MaterialRefNode TargetTexRef { get { return _targetTexRef; } set { _targetTexRef = value; UpdatePropDisplay(); } }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VIS0EntryNode TargetVisEntry 
        { 
            get { return _targetVisEntry; } 
            set 
            {
                _targetVisEntry = value; 
                UpdatePropDisplay();
                pnlKeyframes.TargetSequence = _targetVisEntry as ResourceNode;
                pnlKeyframes.chkConstant.Checked = _targetVisEntry._flags.HasFlag(VIS0Flags.Constant);
                pnlKeyframes.chkEnabled.Checked = _targetVisEntry._flags.HasFlag(VIS0Flags.Enabled);
            } 
        }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentFrame { get { return _animFrame; } set { _animFrame = value; UpdateModel(); UpdatePropDisplay(); } }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableTransformEdit
        {
            get { return _enableTransform; }
            set 
            {
                if (_enableTransform == value)
                    return;

                _enableTransform = value;
                chr0Editor.EnableTransformEdit = 
                srt0Editor.EnableTransformEdit =
                shp0Editor.EnableTransformEdit =
                vis0Editor.EnableTransformEdit =
                pat0Editor.EnableTransformEdit = value; 
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderFloor 
        {
            get { return _renderFloor; } 
            set
            {
                _renderFloor = value;
                _updating = true;
                chkFloor.Checked = toggleFloor.Checked = _renderFloor;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderBones
        {
            get { return _renderBones; }
            set
            {
                if (_editingAll)
                    foreach (MDL0Node m in _targetModels)
                        m._renderBones = value;
                else if (TargetModel != null)
                    TargetModel._renderBones = value;

                _renderBones = value;
                _updating = true;
                chkBones.Checked = toggleBones.Checked = _renderBones;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderVertices
        {
            get { return _renderVertices; }
            set
            {
                if (_editingAll)
                    foreach (MDL0Node m in _targetModels)
                        m._renderVertices = value;
                else 
                    if (TargetModel != null)
                        TargetModel._renderVertices = value;

                _renderVertices = value;
                _updating = true;
                chkVertices.Checked = toggleVertices.Checked = _renderVertices;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderNormals
        {
            get { return _renderNormals; }
            set
            {
                if (_editingAll)
                    foreach (MDL0Node m in _targetModels)
                        m._renderNormals = value;
                else
                    if (TargetModel != null)
                        TargetModel._renderNormals = value;

                _renderNormals = value;
                _updating = true;
                toggleNormals.Checked = _renderNormals;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckState RenderPolygons
        {
            get { return _renderPolygons; }
            set
            {
                if (_editingAll)
                    foreach (MDL0Node m in _targetModels)
                    {
                        m._renderPolygons = value;// == CheckState.Checked || value == CheckState.Indeterminate ? true : false;
                        //m._renderPolygonsWireframe = value == CheckState.Indeterminate ? true : false;
                    }
                else if (TargetModel != null)
                {
                    TargetModel._renderPolygons = value;// == CheckState.Checked || value == CheckState.Indeterminate ? true : false;
                    //TargetModel._renderPolygonsWireframe = value == CheckState.Indeterminate ? true : false;
                }

                _renderPolygons = value;
                _updating = true;
                chkPolygons.CheckState = togglePolygons.CheckState = _renderPolygons;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RenderBox
        {
            get { return _renderBox; }
            set
            {
                if (_editingAll && _targetModels != null)
                    foreach (MDL0Node m in _targetModels)
                        m._renderBox = value;
                else if (TargetModel != null)
                    TargetModel._renderBox = value;

                _renderBox = value;
                _updating = true;
                boundingBoxToolStripMenuItem.Checked = _renderBox;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DontRenderOffscreen
        {
            get { return _dontRenderOffscreen; }
            set
            {
                if (_editingAll && _targetModels != null)
                    foreach (MDL0Node m in _targetModels)
                        m._dontRenderOffscreen = value;
                else if (TargetModel != null)
                    TargetModel._dontRenderOffscreen = value;

                _dontRenderOffscreen = value;
                _updating = true;
                chkDontRenderOffscreen.Checked = _dontRenderOffscreen;
                _updating = false;
                modelPanel.Invalidate();
            }
        }
    }
}
