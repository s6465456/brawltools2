using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.OpenGL;
using System.ComponentModel;
using System.Drawing;
using BrawlLib.Modeling;
using BrawlLib.SSBB.ResourceNodes;
using OpenTK.Graphics.OpenGL;

namespace System.Windows.Forms
{
    public delegate void GLRenderEventHandler(object sender, TKContext ctx);

    public unsafe class ModelPanel : GLPanel
    {
        public ModelEditControl _mainWindow;

        public bool _grabbing = false;
        public bool _scrolling = false;
        private int _lastX, _lastY;

        //private int _rotX, _rotY;
        private float _rotFactor = 0.1f;
        public float RotationScale { get { return _rotFactor; } set { _rotFactor = value; } }

        //private int _transX, _transY;
        private float _transFactor = 0.05f;
        public float TranslationScale { get { return _transFactor; } set { _transFactor = value; } }

        //private int _zoom;
        private float _zoomFactor = 2.5f;
        public float ZoomScale { get { return _zoomFactor; } set { _zoomFactor = value; } }

        private int _zoomInit = 5;
        public int InitialZoomFactor { get { return _zoomInit; } set { _zoomInit = value; } }

        private int _yInit = 100;
        public int InitialYFactor { get { return _yInit; } set { _yInit = value; } }

        private float _viewDistance = 5.0f;
        private float _spotCutoff = 180.0f;
        private float _spotExponent = 100.0f;
        
        public Vector3 _defaultTranslate;
        public Vector2 _defaultRotate;

        public event GLRenderEventHandler PreRender, PostRender;

        private List<ResourceNode> _resourceList = new List<ResourceNode>();

        private Matrix43 _transform = Matrix43.Identity;

        private List<IRenderedObject> _renderList = new List<IRenderedObject>();

        public Vector4 _ambient = new Vector4(0.2f, 0.2f, 0.2f, 1);

        //Position for the angle of lighting. 
        //X = Radius, 
        //Y = Azimuth Angle, 
        //Z = Elevation Angle, 
        //W = 1 (World Coords)
        public Vector4 _position = new Vector4(700, 90, 45, 1);

        public Vector4 _diffuse = new Vector4(0.8f, 0.8f, 0.8f, 1);
        public Vector4 _specular = new Vector4(0.5f, 0.5f, 0.5f, 1);
        
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (base.BackColor != value)
                {
                    base.BackColor = value;
                    Vector3 v = (Vector3)value;
                    GL.ClearColor(v._x, v._y, v._z, 0.0f);
                }
            }
        }

        public override Image BackgroundImage
        {
            get { return BGImage; }
            set
            {
                BGImage = value;
                Invalidate();
            }
        }

        public Vector4 Ambient
        {
            get { return _ambient; }
            set
            {
                _ambient = value;
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                fixed (Vector4* pos = &_ambient)
                {
                    GL.Light(LightName.Light0, LightParameter.Ambient, (float*)pos);
                    GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Ambient);
                }
                Invalidate();
            }
        }

        public Vector4 LightPosition
        {
            get { return _position; }
            set
            {
                _position = value;

                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);

                float r = value._x;
                float azimuth = value._y * Maths._deg2radf;
                float elevation = value._z * Maths._deg2radf;

                Vector4 PositionLight = new Vector4(r * (float)Math.Cos(azimuth) * (float)Math.Sin(elevation), r * (float)Math.Cos(elevation), r * (float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
                Vector4 SpotDirectionLight = new Vector4(-(float)Math.Cos(azimuth) * (float)Math.Sin(elevation), -(float)Math.Cos(elevation), -(float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
                
                GL.Light(LightName.Light0, LightParameter.Position, (float*)&PositionLight);
                GL.Light(LightName.Light0, LightParameter.SpotDirection, (float*)&SpotDirectionLight);
            }
        }

        public Vector4 Diffuse
        {
            get { return _diffuse; }
            set
            {
                _diffuse = value;
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                fixed (Vector4* pos = &_diffuse)
                {
                    GL.Light(LightName.Light0, LightParameter.Diffuse, (float*)pos);
                    GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Diffuse);
                }
                Invalidate();
            }
        }

        public Vector4 Specular
        {
            get { return _specular; }
            set
            {
                _specular = value;
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                fixed (Vector4* pos = &_specular)
                {
                    GL.Light(LightName.Light0, LightParameter.Specular, (float*)pos);
                    GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Specular);
                }
                Invalidate();
            }
        }

        public ModelPanel()
        {
            ColorChanged += OnBackColorChanged;
            ImageChanged += OnBgImageChanged;
            _camera = new GLCamera();
        }

        private void OnBackColorChanged(Color c) { this.BackColor = c; }
        private void OnBgImageChanged(Image i) { this.BackgroundImage = i; }

        private delegate void ColorChangeEvent(Color c);
        private static event ColorChangeEvent ColorChanged;

        private delegate void BgImageChangeEvent(Image i);
        private static event BgImageChangeEvent ImageChanged;

        private static ColorDialog _colorDlg;
        public static void ChooseColor()
        {
            if (_colorDlg == null)
                _colorDlg = new ColorDialog();

            if (_colorDlg.ShowDialog() == DialogResult.OK)
            {
                if (ColorChanged != null)
                    ColorChanged(_colorDlg.Color);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _camera.Reset();
            _camera.Translate(_defaultTranslate._x, _defaultTranslate._y, _defaultTranslate._z);
            _camera.Rotate(_defaultRotate._x, _defaultRotate._y);
        }

        public void ResetCamera()
        {
            _camera.Reset();
            _camera.Translate(_defaultTranslate._x, _defaultTranslate._y, _defaultTranslate._z);
            _camera.Rotate(_defaultRotate._x, _defaultRotate._y);
            Invalidate();
        }

        public void ClearAll()
        {
            ClearTargets();
            ClearReferences();

            if (_ctx != null)
            {
                _ctx.Unbind();
                _ctx._states["_Node_Refs"] = _resourceList;
            }
        }

        public void AddTarget(IRenderedObject target)
        {
            if (_renderList.Contains(target))
                return;

            _renderList.Add(target);

            if (target is ResourceNode)
                _resourceList.Add(target as ResourceNode);

            target.Attach(_ctx);

            Invalidate();
        }
        public void RemoveTarget(IRenderedObject target)
        {
            if (!_renderList.Contains(target))
                return;

            target.Detach();

            if (target is ResourceNode)
                RemoveReference(target as ResourceNode);

            _renderList.Remove(target);
        }
        public void ClearTargets()
        {
            foreach (IRenderedObject o in _renderList)
                o.Detach();
            _renderList.Clear();
        }

        public void AddReference(ResourceNode node)
        {
            if (_resourceList.Contains(node))
                return;

            _resourceList.Add(node);
            RefreshReferences();
        }
        public void RemoveReference(ResourceNode node)
        {
            if (!_resourceList.Contains(node))
                return;

            _resourceList.Remove(node);
            RefreshReferences();
        }
        public void ClearReferences()
        {
            _resourceList.Clear();
            RefreshReferences();
        }
        public void RefreshReferences()
        {
            foreach (IRenderedObject o in _renderList)
                o.Refesh();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            _scrolling = true;
            float z = (float)e.Delta / 120;
            if (Control.ModifierKeys == Keys.Shift)
                z *= 32;

            Translate(0.0f, 0.0f, -z * _zoomFactor);
            
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                _grabbing = true;

            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _grabbing = false;
                this.Invalidate();
            }

            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int xDiff = e.X - _lastX;
            int yDiff = _lastY - e.Y;
            _lastX = e.X;
            _lastY = e.Y;

            Keys mod = Control.ModifierKeys;
            bool ctrl = (mod & Keys.Control) != 0;
            bool shift = (mod & Keys.Shift) != 0;
            bool alt = (mod & Keys.Alt) != 0;

            if (shift)
            {
                xDiff *= 16;
                yDiff *= 16;
            }

            lock (_ctx)
                if (_grabbing)
                    if (ctrl)
                        if (alt)
                            Rotate(0, 0, -yDiff * _rotFactor);
                        else
                            Rotate(yDiff * _rotFactor, -xDiff * _rotFactor);
                    else
                        Translate(-xDiff * _transFactor, -yDiff * _transFactor, 0.0f);

            base.OnMouseMove(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            keyData &= (Keys)0xFFFF;
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    return true;

                default:
                    return base.IsInputKey(keyData);
            }
        }

        protected override bool ProcessKeyMessage(ref Message m)
        {
            if (m.Msg == 0x100)
            {
                Keys mod = Control.ModifierKeys;
                bool ctrl = (mod & Keys.Control) != 0;
                bool shift = (mod & Keys.Shift) != 0;
                bool alt = (mod & Keys.Alt) != 0;
                switch ((Keys)m.WParam)
                {
                    case Keys.NumPad8:
                    case Keys.Up:
                        {
                            if (alt)
                                break;
                            if (ctrl)
                                Rotate(-_rotFactor * (shift ? 32 : 4), 0.0f);
                            else
                                Translate(0.0f, _transFactor * (shift ? 128 : 8), 0.0f);
                            return true;
                        }
                    case Keys.NumPad2:
                    case Keys.Down:
                        {
                            if (alt)
                                break;
                            if (ctrl)
                                Rotate(_rotFactor * (shift ? 32 : 4), 0.0f);
                            else
                                Translate(0.0f, -_transFactor * (shift ? 128 : 8), 0.0f);
                            return true;
                        }
                    case Keys.NumPad6:
                    case Keys.Right:
                        {
                            if (alt)
                                break;
                            if (ctrl)
                                Rotate(0.0f, _rotFactor * (shift ? 32 : 4));
                            else
                                Translate(_transFactor * (shift ? 128 : 8), 0.0f, 0.0f);
                            return true;
                        }
                    case Keys.NumPad4:
                    case Keys.Left:
                        {
                            if (alt)
                                break;
                            if (ctrl)
                                Rotate(0.0f, -_rotFactor * (shift ? 32 : 4));
                            else
                                Translate(-_transFactor * (shift ? 128 : 8), 0.0f, 0.0f);
                            return true;
                        }
                    case Keys.Add:
                    case Keys.Oemplus:
                        {
                            if (alt)
                                break;
                            Translate(0.0f, 0.0f, -_zoomFactor * (shift ? 32 : 2));
                            return true;
                        }
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        {
                            if (alt)
                                break;
                            Translate(0.0f, 0.0f, _zoomFactor * (shift ? 32 : 2));
                            return true;
                        }
                }
            }
            return base.ProcessKeyMessage(ref m);
        }

        private void Translate(float x, float y, float z)
        {
            _camera.Translate(x, y, z);
            _scrolling = false;
            this.Invalidate();
        }
        private void Rotate(float x, float y)
        {
            _camera.Pivot(_viewDistance, x, y);
            this.Invalidate();
        }
        private void Rotate(float x, float y, float z)
        {
            _camera.Rotate(x, y, z);
            this.Invalidate();
        }
        public void RecalcLight(SCN0Node scn)
        {
            GL.Light(LightName.Light0, LightParameter.SpotCutoff, _spotCutoff);
            GL.Light(LightName.Light0, LightParameter.SpotExponent, _spotExponent);

            float r = _position._x;
            float azimuth = _position._y * Maths._deg2radf;
            float elevation = _position._z * Maths._deg2radf;
            
            Vector4 PositionLight = new Vector4(r * (float)Math.Cos(azimuth) * (float)Math.Sin(elevation), r * (float)Math.Cos(elevation), r * (float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
            Vector4 SpotDirectionLight = new Vector4(-(float)Math.Cos(azimuth) * (float)Math.Sin(elevation), -(float)Math.Cos(elevation), -(float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
            
            GL.Light(LightName.Light0, LightParameter.Position, (float*)&PositionLight);
            GL.Light(LightName.Light0, LightParameter.SpotDirection, (float*)&SpotDirectionLight);

            fixed (Vector4* pos = &_ambient)
            {
                GL.Light(LightName.Light0, LightParameter.Ambient, (float*)pos);
                //GL.Material(MaterialFace.Back, MaterialParameter.Ambient, (float*)pos);
                GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Ambient);
            }
            fixed (Vector4* pos = &_diffuse)
            {
                GL.Light(LightName.Light0, LightParameter.Diffuse, (float*)pos);
                //GL.Material(MaterialFace.Back, MaterialParameter.Diffuse, (float*)pos);
                GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Diffuse);
            }
            fixed (Vector4* pos = &_specular)
            {
                GL.Light(LightName.Light0, LightParameter.Specular, (float*)pos);
                //GL.Material(MaterialFace.Back, MaterialParameter.Specular, (float*)pos);
                GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Specular);
                GL.ColorMaterial(MaterialFace.Back, ColorMaterialParameter.Emission);
            }
        }

        protected internal unsafe override void OnInit(TKContext ctx)
        {
            //_context.glEnable(GLEnableCap.Fog);
            //float* l = stackalloc float[4];
            //l[0] = 0.5f; l[1] = 0.5f; l[2] = 0.5f; l[3] = 1;
            //_context.glFog(FogParameter.FogColor, l);
            //_context.glFog(FogParameter.FogDensity, 0.05f);
            //_context.glHint(GLHintTarget.FOG_HINT, GLHintMode.NICEST);
            //_context.glFog(FogParameter.FogStart, 0);
            //_context.glFog(FogParameter.FogEnd, 10);

            //_context.glClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);

            Vector3 v = (Vector3)BackColor;
            GL.ClearColor(v._x, v._y, v._z, 0.0f);
            GL.ClearDepth(1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.ShadeModel(ShadingModel.Smooth);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            //GL.Enable(EnableCap.AlphaTest);
            //GL.AlphaFunc(AlphaFunction.Gequal, 0.1f);

            RecalcLight(null);

            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Modulate);

            //Set client states
            ctx._states["_Node_Refs"] = _resourceList;
        }

        protected internal override void OnRender(TKContext ctx, SCN0Node scn)
        {
            if (_mainWindow != null)
            {
                _mainWindow.lblPos.Text = "Position: " + _camera.GetPoint();
                _mainWindow.lblRot.Text = "Rotation: " + _camera._rotation;
            }

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            
            RecalcLight(scn);

            if (PreRender != null)
                PreRender(this, ctx);

            foreach (IRenderedObject o in _renderList)
                o.Render(ctx, _mainWindow);

            if (PostRender != null)
                PostRender(this, ctx);
        }

        public Bitmap GrabScreenshot()
        {
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(this.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, this.ClientSize.Width, this.ClientSize.Height, PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }

        Form popoutForm;

        //Gummers told me to put this here
        public void Popout()
        {
            popoutForm = new Form();
            _mainWindow.Controls.Remove(this);
            popoutForm.Controls.Add(this);
            Dock = DockStyle.Fill;
            popoutForm.Show();
        }

        public void Popin()
        {
            popoutForm.Controls.Remove(this);
            _mainWindow.Controls.Add(this);
            popoutForm.Close();
            Dock = DockStyle.Fill;
        }
    }
}
