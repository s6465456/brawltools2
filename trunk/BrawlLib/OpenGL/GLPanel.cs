using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.OpenGL
{
    public abstract unsafe class GLPanel : UserControl
    {
        //internal protected GLContext _context;
        internal protected TKContext _ctx;
        
        public bool _projectionChanged = true;
        private int _updateCounter;
        internal GLCamera _camera;
        
        public GLPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, false);
        }
        protected override void Dispose(bool disposing)
        {
            DisposeContext();
            base.Dispose(disposing);
        }
        private void DisposeContext()
        {
            //if (_context != null)
            //{
            //    _context.Unbind();
            //    _context.Dispose();
            //    _context = null;
            //}
            if (_ctx != null)
            {
                _ctx.Dispose();
                _ctx = null;
            }
        }

        public void BeginUpdate() { _updateCounter++; }
        public void EndUpdate() { if ((_updateCounter = Math.Max(_updateCounter - 1, 0)) == 0) Invalidate(); }

        protected override void OnLoad(EventArgs e)
        {
            //_context = GLContext.Attach(this);

            _ctx = new TKContext(this);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.ClearDepth(1.0f);

            OnInit(_ctx);

            base.OnLoad(e);
        }

        protected override void DestroyHandle()
        {
            DisposeContext();
            base.DestroyHandle();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            DisposeContext();
            base.OnHandleDestroyed(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }

        public virtual float GetDepth(int x, int y)
        {
            float val = 0;
            GL.ReadPixels(x, Height - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.DepthComponent, OpenTK.Graphics.OpenGL.PixelType.Float, ref val);
            return val;
        }

        public SCN0Node _scn0 = null;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_updateCounter > 0)
                return;

            if (_ctx == null)
                base.OnPaint(e);
            else if (Monitor.TryEnter(_ctx))
            {
                try
                {
                    _ctx.Capture();

                    //Set projection
                    if (_projectionChanged)
                    {
                        OnResized();
                        _projectionChanged = false;
                    }

                    if (_camera != null)
                    {
                        fixed (Matrix* p = &_camera._matrix)
                        {
                            GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
                            GL.LoadMatrix((float*)p);
                        }
                    }

                    OnRender(_ctx, _scn0);
                    GL.Finish();
                    _ctx.Swap();
                }
                finally { Monitor.Exit(_ctx); }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            _projectionChanged = true;
            Invalidate();
        }

        //protected override void OnHandleDestroyed(EventArgs e)
        //{
        //    DisposeContext();
        //    base.OnHandleDestroyed(e);
        //}

        internal protected virtual void OnInit(TKContext ctx)
        {
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.ClearDepth(1.0f);
        }

        public float _fovY = 45.0f, _nearZ = 1.0f, _farZ = 20000.0f, _aspect;

        internal Matrix _projectionMatrix;
        internal Matrix _projectionInverse;

        public Vector3 UnProject(Vector3 point) { return UnProject(point._x, point._y, point._z); }
        public Vector3 UnProject(float x, float y, float z)
        {
            if (_camera == null)
                return new Vector3();

            Vector4 v;
            v._x = 2 * x / Width - 1;
            v._y = 2 * (Height - y) / Height - 1;
            v._z = 2 * z - 1;
            v._w = 1.0f;

            return (Vector3)(_camera._matrixInverse * _projectionInverse * v);
        }

        public Vector3 TraceZ(Vector3 point, float z)
        {
            if (_camera == null)
                return new Vector3();

            double a = point._z - z;
            //Perform trig functions, using camera for angles

            //Get angle, truncating to MOD 180
            //double angleX = _camera._rotation._y - ((int)(_camera._rotation._y / 180.0) * 180);

            double angleX = Math.IEEERemainder(-_camera._rotation._y, 180.0);
            if (angleX < -90.0f)
                angleX = -180.0f - angleX;
            if (angleX > 90.0f)
                angleX = 180.0f - angleX;

            double angleY = Math.IEEERemainder(_camera._rotation._x, 180.0);
            if (angleY < -90.0f)
                angleY = -180.0f - angleY;
            if (angleY > 90.0f)
                angleY = 180.0f - angleY;

            float lenX = (float)(Math.Tan(angleX * Math.PI / 180.0) * a);
            float lenY = (float)(Math.Tan(angleY * Math.PI / 180.0) * a);

            return new Vector3(point._x + lenX, point._y + lenY, z);
        }

        //Projects a ray at 'screenPoint' through sphere at 'center' with 'radius'.
        //If point does not intersect
        public Vector3 ProjectCameraSphere(Vector2 screenPoint, Vector3 center, float radius, bool clamp)
        {
            if (_camera == null)
                return new Vector3();

            Vector3 point;

            //Get ray points
            Vector4 v = new Vector4(2 * screenPoint._x / Width - 1, 2 * (Height - screenPoint._y) / Height - 1, -1.0f, 1.0f);
            Vector3 ray1 = (Vector3)(_camera._matrixInverse * _projectionInverse * v);
            v._z = 1.0f;
            Vector3 ray2 = (Vector3)(_camera._matrixInverse * _projectionInverse * v);

            if (!Maths.LineSphereIntersect(ray1, ray2, center, radius, out point))
            {
                //If no intersect is found, project the ray through the plane perpendicular to the camera.
                Maths.LinePlaneIntersect(ray1, ray2, center, _camera.GetPoint().Normalize(center), out point);

                //Clamp the point to edge of the sphere
                if (clamp)
                    point = Maths.PointAtLineDistance(center, point, radius);
            }

            return point;
        }

        protected void CalculateProjection()
        {
            _projectionMatrix = Matrix.ProjectionMatrix(_fovY, _aspect, _nearZ, _farZ);
            _projectionInverse = Matrix.ReverseProjectionMatrix(_fovY, _aspect, _nearZ, _farZ);
        }

        internal protected virtual void OnResized()
        {
            _ctx.Update();

            _aspect = (float)Width / Height;
            CalculateProjection();

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);

            fixed (Matrix* p = &_projectionMatrix)
                GL.LoadMatrix((float*)p);
        }

        internal protected virtual void OnRender(TKContext ctx, SCN0Node scn)
        {
            GL.Clear(OpenTK.Graphics.OpenGL.ClearBufferMask.ColorBufferBit | OpenTK.Graphics.OpenGL.ClearBufferMask.DepthBufferBit);
        }
    }
}
