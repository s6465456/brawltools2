﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib;
using BrawlLib.SSBBTypes;
using BrawlLib.Imaging;
using BrawlLib.Wii.Models;

namespace BrawlBox.NodeWrappers
{
    [NodeWrapper(ResourceType.MDL0)]
    class MDL0Wrapper : GenericWrapper
    {
        #region Menu

        private static ContextMenuStrip _menu;
        static MDL0Wrapper()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add(new ToolStripMenuItem("&Preview", null, PreviewAction, Keys.Control | Keys.P));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Export", null, ExportAction, Keys.Control | Keys.E));
            _menu.Items.Add(new ToolStripMenuItem("&Replace", null, ReplaceAction, Keys.Control | Keys.R));
            _menu.Items.Add(new ToolStripMenuItem("Res&tore", null, RestoreAction, Keys.Control | Keys.T));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Move &Up", null, MoveUpAction, Keys.Control | Keys.Up));
            _menu.Items.Add(new ToolStripMenuItem("Move D&own", null, MoveDownAction, Keys.Control | Keys.Down));
            _menu.Items.Add(new ToolStripMenuItem("Re&name", null, RenameAction, Keys.Control | Keys.N));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("Add New S&hader", null, NewShaderAction, Keys.Control | Keys.H));
            _menu.Items.Add(new ToolStripMenuItem("Add New &Material", null, NewMaterialAction, Keys.Control | Keys.M));
            _menu.Items.Add(new ToolStripMenuItem("Add New Color &Node", null, NewColorAction, Keys.Control | Keys.G));
            _menu.Items.Add(new ToolStripMenuItem("Add New Vertex &Set", null, NewVertexAction, Keys.Control | Keys.J));
            _menu.Items.Add(new ToolStripMenuItem("&Import New Object", null, ImportObjectAction, Keys.Control | Keys.I));
            _menu.Items.Add(new ToolStripSeparator());
            _menu.Items.Add(new ToolStripMenuItem("&Delete", null, DeleteAction, Keys.Control | Keys.Delete));
            _menu.Opening += MenuOpening;
            _menu.Closing += MenuClosing;
        }
        protected static void PreviewAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().Preview(); }
        //protected static void MetalAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().AutoMetal(); }
        protected static void NewShaderAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().NewShader(); }
        protected static void NewMaterialAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().NewMaterial(); }
        protected static void NewColorAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().NewColor(); }
        protected static void NewVertexAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().NewVertex(); }
        protected static void ImportObjectAction(object sender, EventArgs e) { GetInstance<MDL0Wrapper>().ImportObject(); }
        private static void MenuClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menu.Items[3].Enabled = _menu.Items[4].Enabled = _menu.Items[6].Enabled = _menu.Items[7].Enabled = _menu.Items[10].Enabled = _menu.Items[16].Enabled = true;
        }
        private static void MenuOpening(object sender, CancelEventArgs e)
        {
            MDL0Wrapper w = GetInstance<MDL0Wrapper>();
            _menu.Items[3].Enabled = _menu.Items[16].Enabled = w.Parent != null;
            _menu.Items[4].Enabled = ((w._resource.IsDirty) || (w._resource.IsBranch));
            _menu.Items[6].Enabled = w.PrevNode != null;
            _menu.Items[7].Enabled = w.NextNode != null;
            if (((MDL0Node)w._resource)._shadList != null && ((MDL0Node)w._resource)._matList != null)
                _menu.Items[10].Enabled = (((MDL0Node)w._resource)._shadList.Count < ((MDL0Node)w._resource)._matList.Count);
            else
                _menu.Items[10].Enabled = false;
        }
        #endregion

        public override string ExportFilter { get { return ExportFilters.MDL0; } }

        public MDL0Wrapper() { ContextMenuStrip = _menu; }

        public void Preview()
        {
            using (ModelForm form = new ModelForm())
                form.ShowDialog(_owner, (MDL0Node)_resource);
        }

        public void NewShader()
        {
            if (_modelViewerOpen)
                return;

            MDL0Node model = ((MDL0Node)_resource);

            if (model._shadGroup == null)
            {
                MDL0GroupNode g = model._shadGroup;
                if (g == null)
                {
                    model.AddChild(g = new MDL0GroupNode(MDLResourceType.Shaders), true);
                    model._shadGroup = g; model._shadList = g.Children;
                }
            }

            if (model._shadList != null && model._matList != null)
            if (model._shadList.Count < model._matList.Count)
            {
                MDL0ShaderNode shader = new MDL0ShaderNode();
                model._shadGroup.AddChild(shader);
                shader.Default();
                shader.Rebuild(true);

                BaseWrapper b = FindResource(shader, true);
                if (b != null)
                    b.EnsureVisible();
            }
        }

        public void NewMaterial()
        {
            if (_modelViewerOpen)
                return;

            MDL0Node model = ((MDL0Node)_resource);

            if (model._matGroup == null)
            {
                MDL0GroupNode g = model._matGroup;
                if (g == null)
                {
                    model.AddChild(g = new MDL0GroupNode(MDLResourceType.Materials), true);
                    model._matGroup = g; model._matList = g.Children;
                }
            }

            MDL0MaterialNode mat = new MDL0MaterialNode();
            model._matGroup.AddChild(mat);
            mat.Name = "Material" + mat.Index;
            mat.New = true;
            if (model._shadGroup == null)
            {
                MDL0GroupNode g = model._shadGroup;
                if (g == null)
                {
                    model.AddChild(g = new MDL0GroupNode(MDLResourceType.Shaders), true);
                    model._shadGroup = g; model._shadList = g.Children;
                }
            }
            if (model._shadList.Count == 0)
                NewShader();
            
            mat.ShaderNode = (MDL0ShaderNode)model._shadList[0];
            mat.AddChild(new MDL0MaterialRefNode() { Name = "MatRef0" });
            mat.Rebuild(true);

            BaseWrapper b = FindResource(mat, true);
            if (b != null)
                b.EnsureVisible();
        }

        //public void AutoMetal()
        //{
        //    ((MDL0Node)_resource).AutoMetalMaterials = true;
        //}

        public void NewColor()
        {
            if (_modelViewerOpen)
                return;

            MDL0Node model = ((MDL0Node)_resource);

            MDL0GroupNode g = model._colorGroup;
            if (g == null)
            {
                model.AddChild(g = new MDL0GroupNode(MDLResourceType.Colors), true);
                model._colorGroup = g; model._colorList = g.Children;
            }

            MDL0ColorNode node = new MDL0ColorNode() { Name = "ColorSet" + ((MDL0Node)_resource)._colorList.Count };
            node.Colors = new RGBAPixel[] { new RGBAPixel() { A = 255, R = 128, G = 128, B = 128 } };
            g.AddChild(node, true);

            node.Rebuild(true);
            node.SignalPropertyChange();

            FindResource(node, true).EnsureVisible();
        }

        public void NewVertex()
        {
            if (_modelViewerOpen)
                return;

            MDL0Node model = ((MDL0Node)_resource);

            MDL0GroupNode g = model._vertGroup;
            if (g == null)
            {
                model.AddChild(g = new MDL0GroupNode(MDLResourceType.Vertices), true);
                model._vertGroup = g; model._vertList = g.Children;
            }

            MDL0VertexNode node = new MDL0VertexNode() { Name = "VertexSet" + ((MDL0Node)_resource)._vertList.Count };
            node.Vertices = new Vector3[] { new Vector3(0) };
            g.AddChild(node, true);
            node._forceRebuild = true;
            node.Rebuild(true);
            node.SignalPropertyChange();

            FindResource(node, true).EnsureVisible();
        }

        public void ImportObject()
        {
            if (_modelViewerOpen)
                return;

            MDL0Node external = null;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "MDL0 Raw Model (*.mdl0)|*.mdl0";
            o.Title = "Please select a model to import an object from.";
            if (o.ShowDialog() == DialogResult.OK)
            {
                if ((external = (MDL0Node)NodeFactory.FromFile(null, o.FileName)) != null)
                {
                    ObjectImporter i = new ObjectImporter();
                    i.ShowDialog((MDL0Node)_resource, external);
                }
            }
        }
    }
}
