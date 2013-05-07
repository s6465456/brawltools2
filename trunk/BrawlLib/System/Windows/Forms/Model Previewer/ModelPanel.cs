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
using System.Drawing.Imaging;
using BrawlLib.Imaging;

namespace System.Windows.Forms
{
    public delegate void GLRenderEventHandler(object sender, TKContext ctx);

    public unsafe class ModelPanel : GLPanel
    {
        public ModelEditControl _mainWindow;

        public bool _grabbing = false;
        public bool _scrolling = false;
        private int _lastX, _lastY;

        private float _rotFactor = 0.1f;
        public float RotationScale { get { return _rotFactor; } set { _rotFactor = value; } }

        private float _transFactor = 0.05f;
        public float TranslationScale { get { return _transFactor; } set { _transFactor = value; } }

        private float _zoomFactor = 2.5f;
        public float ZoomScale { get { return _zoomFactor; } set { _zoomFactor = value; } }

        private int _zoomInit = 5;
        public int InitialZoomFactor { get { return _zoomInit; } set { _zoomInit = value; } }

        private int _yInit = 100;
        public int InitialYFactor { get { return _yInit; } set { _yInit = value; } }

        private float _viewDistance = 5.0f;
        private float _spotCutoff = 180.0f;
        private float _spotExponent = 100.0f;

        [TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 DefaultTranslate { get { return _defaultTranslate; } set { _defaultTranslate = value; } }
        [TypeConverter(typeof(Vector3StringConverter))]
        public Vector2 DefaultRotate { get { return _defaultRotate; } set { _defaultRotate = value; } }

        public Vector3 _defaultTranslate;
        public Vector2 _defaultRotate;

        public event GLRenderEventHandler PreRender, PostRender;

        private List<ResourceNode> _resourceList = new List<ResourceNode>();

        private Matrix43 _transform = Matrix43.Identity;

        private List<IRenderedObject> _renderList = new List<IRenderedObject>();

        //Position for the angle of lighting. 
        //X = Radius, 
        //Y = Azimuth Angle, 
        //Z = Elevation Angle, 
        //W = 1 (World Coords) 

        const float v = 100.0f / 255.0f;
        public Vector4 _position = new Vector4(100.0f, 45.0f, 45.0f, 1.0f);
        public Vector4 _ambient = new Vector4(v, v, v, 1.0f);
        public Vector4 _diffuse = new Vector4(v, v, v, 1.0f);
        public Vector4 _specular = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        public Vector4 _emission = new Vector4(v, v, v, 1.0f);
        
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
                if (BGImage != null)
                    BGImage.Dispose();

                BGImage = value;

                _updateImage = true;
                
                Invalidate();
            }
        }
        [TypeConverter(typeof(Vector4StringConverter))]
        public Vector4 Emission
        {
            get { return _emission; }
            set
            {
                _emission = value;
                Invalidate();
            }
        }
        [TypeConverter(typeof(Vector4StringConverter))]
        public Vector4 Ambient
        {
            get { return _ambient; }
            set
            {
                _ambient = value;
                Invalidate();
            }
        }
        [TypeConverter(typeof(Vector4StringConverter))]
        public Vector4 LightPosition
        {
            get { return _position; }
            set 
            {
                _position = value; 
                Invalidate(); 
            }
        }
        [TypeConverter(typeof(Vector4StringConverter))]
        public Vector4 Diffuse
        {
            get { return _diffuse; }
            set
            {
                _diffuse = value;
                Invalidate();
            }
        }
        [TypeConverter(typeof(Vector4StringConverter))]
        public Vector4 Specular
        {
            get { return _specular; }
            set
            {
                _specular = value;
                Invalidate();
            }
        }

        public ModelPanel()
        {
            _camera = new GLCamera();

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ModelPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ModelPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ModelPanel_MouseUp);
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

        public void SetCamWithBox(Vector3 min, Vector3 max)
        {
            Vector3 average = new Vector3(
                (max._x + min._x) / 2.0f,
                (max._y + min._y) / 2.0f,
                (max._z + min._z) / 2.0f);

            float y = max._y - average._y;
            float x = max._x - average._x;
            float ratio = x / y;
            float tan = (float)Math.Tan((_fovY / 2.0f) * Maths._deg2radf);
            float distY = y / tan;
            float distX = distY * ratio;

            _camera.Reset();
            _camera.Translate(average._x, average._y, Maths.Max(distX, distY, max._z) + 3.0f);
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

        private float _multiplier = 1.0f;
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            _scrolling = true;
            float z = (float)e.Delta / 120;
            if (Control.ModifierKeys == Keys.Shift)
                z *= 32;

            Zoom(-z * _zoomFactor * _multiplier);

            if (Control.ModifierKeys == Keys.Alt)
                if (z < 0)
                    _multiplier /= 0.9f;
                else
                    _multiplier *= 0.9f;

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
                Invalidate();
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

            if (_ctx != null)
            lock (_ctx)
                if (_grabbing)
                    if (ctrl)
                        if (alt)
                            Rotate(0, 0, -yDiff * _rotFactor);
                        else
                            Rotate(yDiff * _rotFactor, -xDiff * _rotFactor);
                    else
                        Translate(-xDiff * _transFactor, -yDiff * _transFactor, 0.0f);

            if (_selecting && _mainWindow == null)
                Invalidate();

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
                            Zoom(-_zoomFactor * (shift ? 32 : 2));
                            return true;
                        }
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        {
                            if (alt)
                                break;
                            Zoom(_zoomFactor * (shift ? 32 : 2));
                            return true;
                        }
                }
            }
            return base.ProcessKeyMessage(ref m);
        }
        private void Zoom(float amt)
        {
            if (_ortho)
            {
                float scale = (amt >= 0 ? amt / 2.0f : 2.0f / -amt) * _multiplier;
                Scale(scale, scale, 1.0f);
            }
            else
                Translate(0.0f, 0.0f, amt * _multiplier);
        }
        private void Scale(float x, float y, float z)
        {
            x *= _multiplier;
            y *= _multiplier;
            z *= _multiplier;
            _camera.Scale(x, y, z);
            _scrolling = false;
            Invalidate();
        }
        private void Translate(float x, float y, float z)
        {
            x *= _ortho ? 20.0f : 1.0f;
            y *= _ortho ? 20.0f : 1.0f;
            _camera.Translate(x, y, z);
            _scrolling = false;
            Invalidate();
        }
        private void Rotate(float x, float y)
        {
            _camera.Pivot(_viewDistance, x, y);
            Invalidate();
        }
        private void Rotate(float x, float y, float z)
        {
            _camera.Rotate(x, y, z);
            Invalidate();
        }

        //Call this every time the scene is rendered
        //Otherwise the light will move with the camera
        //(Which makes sense, since the camera isn't moving and the scene is)
        public void RecalcLight()
        {
            GL.Light(LightName.Light0, LightParameter.SpotCutoff, _spotCutoff);
            GL.Light(LightName.Light0, LightParameter.SpotExponent, _spotExponent);

            float r = _position._x;
            float azimuth = _position._y * Maths._deg2radf;
            float elevation = 360.0f - (_position._z * Maths._deg2radf);
            
            Vector4 PositionLight = new Vector4(r * (float)Math.Cos(azimuth) * (float)Math.Sin(elevation), r * (float)Math.Cos(elevation), r * (float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
            Vector4 SpotDirectionLight = new Vector4(-(float)Math.Cos(azimuth) * (float)Math.Sin(elevation), -(float)Math.Cos(elevation), -(float)Math.Sin(azimuth) * (float)Math.Sin(elevation), 1);
            
            GL.Light(LightName.Light0, LightParameter.Position, (float*)&PositionLight);
            GL.Light(LightName.Light0, LightParameter.SpotDirection, (float*)&SpotDirectionLight);

            fixed (Vector4* pos = &_ambient)
            {
                GL.Light(LightName.Light0, LightParameter.Ambient, (float*)pos);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, (float*)pos);
            }
            fixed (Vector4* pos = &_diffuse)
            {
                GL.Light(LightName.Light0, LightParameter.Diffuse, (float*)pos);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, (float*)pos);
            }
            fixed (Vector4* pos = &_specular)
            {
                GL.Light(LightName.Light0, LightParameter.Specular, (float*)pos);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, (float*)pos);
            }
            fixed (Vector4* pos = &_emission)
            {
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, (float*)pos);
            }

            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (int)TextureEnvMode.Modulate);

            if (_enableSmoothing)
            {
                GL.Enable(EnableCap.PointSmooth);
                GL.Enable(EnableCap.PolygonSmooth);
                GL.Enable(EnableCap.LineSmooth);
                GL.PointSize(1.0f);
                GL.LineWidth(1.0f);
            }
            else
            {
                GL.Disable(EnableCap.PointSmooth);
                GL.Disable(EnableCap.PolygonSmooth);
                GL.Disable(EnableCap.LineSmooth);
                GL.PointSize(3.0f);
                GL.LineWidth(2.0f);
            }
        }

        public bool _enableSmoothing = false;
        protected internal unsafe override void OnInit(TKContext ctx)
        {
            Vector3 v = (Vector3)BackColor;
            GL.ClearColor(v._x, v._y, v._z, 0.0f);
            GL.ClearDepth(1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.ShadeModel(ShadingModel.Smooth);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Fastest);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Fastest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Fastest);
            GL.Hint(HintTarget.GenerateMipmapHint, HintMode.Fastest);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.1f);

            //GL.PointSize(3.0f);
            //GL.LineWidth(2.0f);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            //GL.Enable(EnableCap.Normalize);

            RecalcLight();

            //Set client states
            ctx._states["_Node_Refs"] = _resourceList;
        }
        public bool _showCamCoords = false;
        protected internal override void OnRender(TKContext ctx, PaintEventArgs e)
        {
            if (_showCamCoords)
            {
                Vector3 v = _camera.GetPoint().Round(3);
                Vector3 r = _camera._rotation.Round(3);
                ScreenText[String.Format("Position\nX: {0}\nY: {1}\nZ: {2}\n\nRotation\nX: {3}\nY: {4}\nZ: {5}", v._x, v._y, v._z, r._x, r._y, r._z)] = new Vector3(5.0f, 5.0f, 0.5f);
            }

            if (_ctx._needsUpdate)
            {
                OnInit(ctx);
                OnResized();
                _ctx._needsUpdate = false;
            }

            if (_bgImage == null)
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            
            RecalcLight();

            if (PreRender != null)
                PreRender(this, ctx);

            foreach (IRenderedObject o in _renderList)
                o.Render(ctx, this);

            if (PostRender != null)
                PostRender(this, ctx);
        }
        public ARGBPixel DoPicking(int x, int y)
        {
            DrawColorIds();

            ARGBPixel pixel = new ARGBPixel();
            int[] viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, viewport);
            GL.ReadBuffer(ReadBufferMode.Back);
            GL.ReadPixels(x, viewport[3] - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.ColorIndex, PixelType.UnsignedByte, (IntPtr)(&pixel));
            
            return pixel;
            
            //int index = (int)pixel[0] + (((int)pixel[1]) << 8) + ((((int)pixel[2]) << 16));
            //int modelId = pixel[3];
            //if (index > -1 && index < shapes.Count)
            //{
            //    selectedShape = shapes[index];
            //}
        }

        private void DrawColorIds()
        {
            GL.PushAttrib(AttribMask.EnableBit | AttribMask.ColorBufferBit);
            GL.Disable(EnableCap.Fog);
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.Dither);
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.LineStipple);
            GL.Disable(EnableCap.PolygonStipple);
            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.AlphaTest);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Supports up to 65535 models with up to 65535 objects each.

            byte i = 0;
            foreach (IRenderedObject o in _renderList)
                if (o is MDL0Node)
                {
                    MDL0Node m = o as MDL0Node;
                    if (m._polyList != null)
                        foreach (MDL0ObjectNode n in m._polyList)
                        {
                            byte r = (byte)(n.Index & 0xFF);
                            byte g = (byte)((n.Index & 0xFF00) >> 8);
                            byte b = (byte)(i & 0xFF);
                            byte a = (byte)((i & 0xFF00) >> 8);
                            GL.Color4(r, g, b, a);
                            n.Render(_ctx);
                        }
                    i++;
                }

            GL.PopAttrib();
        }
        private void ModelPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_forceNoSelection)
            {
                _selecting = true;
                _selStart = e.Location;
                _selEnd = e.Location;
            }
        }
        private void ModelPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selEnd = e.Location;
                if (_mainWindow == null)
                {
                    _selecting = false;
                    Invalidate();
                }
            }
        }

        private void ModelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selecting)
                _selEnd = e.Location;
        }
        public Bitmap GrabScreenshot(bool withTransparency)
        {
            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            BitmapData data;
            if (withTransparency)
            {
                data = bmp.LockBits(ClientRectangle, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.ReadPixels(0, 0, ClientSize.Width, ClientSize.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            }
            else
            {
                data = bmp.LockBits(this.ClientRectangle, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                GL.ReadPixels(0, 0, ClientSize.Width, ClientSize.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            }
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
