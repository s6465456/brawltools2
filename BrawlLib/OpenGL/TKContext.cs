using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.OpenGL;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using GL = OpenTK.Graphics.OpenGL.GL;
using OpenTK.Platform;
using OpenTK.Graphics;

namespace BrawlLib.OpenGL
{
    public delegate T GLCreateHandler<T>(TKContext ctx);

    public unsafe class TKContext : IDisposable
    {
        IGraphicsContext _context;
        private IWindowInfo _winInfo = null;
        private IWindowInfo WindowInfo { get { return _winInfo; } }

        internal Dictionary<string, object> _states = new Dictionary<string, object>();
        public T FindOrCreate<T>(string name, GLCreateHandler<T> handler)
        {
            if (_states.ContainsKey(name))
                return (T)_states[name];
            T obj = handler(this);
            _states[name] = obj;
            return obj;
        }

        public void Unbind()
        {
            try
            {
                Capture();
                foreach (object o in _states.Values)
                {
                    if (o is GLDisplayList)
                        (o as GLDisplayList).Delete();
                    else if (o is GLTexture)
                        (o as GLTexture).Delete();
                }
            }
            catch { }
            _states.Clear();
        }

        public bool bSupportsGLSLBinding, bSupportsGLSLUBO, bSupportsGLSLATTRBind, bSupportsGLSLCache;
        public bool _canUseShaders = true;
        public int _version = 0;

        public TKContext(Control window) 
        {
            _winInfo = Utilities.CreateWindowsWindowInfo(window.Handle);
            _context = new GraphicsContext(GraphicsMode.Default, WindowInfo, 1, 1, GraphicsContextFlags.Default);
            _context.MakeCurrent(WindowInfo);
            (_context as IGraphicsContextInternal).LoadAll();

            // Check for GLSL support
            string version = GL.GetString(OpenTK.Graphics.OpenGL.StringName.Version);
            _version = int.Parse(version[0].ToString());
            if (_version < 2) _canUseShaders = false;

            if (_canUseShaders)
            {
                //Now check extensions
                string extensions = GL.GetString(OpenTK.Graphics.OpenGL.StringName.Extensions);
                if (extensions.Contains("GL_ARB_shading_language_420pack"))
                    bSupportsGLSLBinding = true;
                if (extensions.Contains("GL_ARB_uniform_buffer_object"))
                    bSupportsGLSLUBO = true;
                if ((bSupportsGLSLBinding || bSupportsGLSLUBO) && extensions.Contains("GL_ARB_explicit_attrib_location"))
                    bSupportsGLSLATTRBind = true;
                if (extensions.Contains("GL_ARB_get_program_binary"))
                    bSupportsGLSLCache = true;
            }
        }

        public void Share(TKContext ctx)
        {

        }

        public void Dispose() 
        {
            if (_context != null)
                _context.Dispose();
        }

        public void CheckErrors()
        {
            OpenTK.Graphics.OpenGL.ErrorCode code = GL.GetError();
            if (code == OpenTK.Graphics.OpenGL.ErrorCode.NoError)
                return;

            throw new Exception(code.ToString());
        }

        public void Capture() { _context.MakeCurrent(WindowInfo); }
        public void Swap() { _context.SwapBuffers(); }
        public void Release() 
        {
            _context.MakeCurrent(null);
        }
        public void Update() { _context.Update(WindowInfo); }

        public unsafe void DrawBox(Vector3 p1, Vector3 p2)
        {
            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.QuadStrip);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);
            GL.Vertex3(p2._x, p1._y, p1._z);
            GL.Vertex3(p2._x, p2._y, p1._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);

            GL.End();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);

            GL.Vertex3(p1._x, p2._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p1._z);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p1._z);

            GL.End();
        }

        public unsafe void DrawInvertedBox(Vector3 p1, Vector3 p2)
        {
            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.QuadStrip);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p1._z);
            GL.Vertex3(p2._x, p2._y, p1._z);
            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);

            GL.End();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);

            GL.Vertex3(p2._x, p2._y, p1._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p2._y, p1._z);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p1._z);

            GL.End();
        }

        public void DrawCube(Vector3 p, float radius)
        {
            Vector3 p1 = new Vector3(p._x + radius, p._y + radius, p._z + radius);
            Vector3 p2 = new Vector3(p._x - radius, p._y - radius, p._z - radius);
            DrawBox(p2, p1);
        }

        public void DrawInvertedCube(Vector3 p, float radius)
        {
            Vector3 p1 = new Vector3(p._x + radius, p._y + radius, p._z + radius);
            Vector3 p2 = new Vector3(p._x - radius, p._y - radius, p._z - radius);
            DrawInvertedBox(p2, p1);
        }

        public void DrawRing(float radius)
        {
            GL.PushMatrix();
            GL.Scale(radius, radius, radius);
            GetRingList().Call();
            GL.PopMatrix();
        }

        public GLDisplayList GetLine() { return FindOrCreate<GLDisplayList>("Line", CreateLine); }
        private static GLDisplayList CreateLine(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(2.0f, 0.0f, 0.0f);

            GL.End();

            list.End();
            return list;
        }

        public GLDisplayList GetRingList() { return FindOrCreate<GLDisplayList>("Ring", CreateRing); }
        private static GLDisplayList CreateRing(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            list.Begin();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.LineLoop);

            float angle = 0.0f;
            for (int i = 0; i < 360; i++, angle = i * Maths._deg2radf)
                GL.Vertex2(Math.Cos(angle), Math.Sin(angle));

            GL.End();

            list.End();
            return list;
        }

        public GLDisplayList GetSquareList() { return FindOrCreate<GLDisplayList>("Square", CreateSquare); }
        private static GLDisplayList CreateSquare(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            list.Begin();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.LineLoop);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);

            GL.End();

            list.End();
            return list;
        }

        public GLDisplayList GetAxisList() { return FindOrCreate<GLDisplayList>("Axes", CreateAxes); }
        private static GLDisplayList CreateAxes(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            list.Begin();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);

            GL.Color4(1.0f, 0.0f, 0.0f, 1.0f);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(2.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 1.0f);

            GL.Color4(0.0f, 1.0f, 0.0f, 1.0f);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 2.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 1.0f);

            GL.Color4(0.0f, 0.0f, 1.0f, 1.0f);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 2.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(1.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 1.0f);

            GL.End();

            list.End();
            return list;
        }
        public GLDisplayList GetCubeList() { return FindOrCreate<GLDisplayList>("Cube", CreateCube); }
        private static GLDisplayList CreateCube(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            list.Begin();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.QuadStrip);

            Vector3 p1 = new Vector3(0);
            Vector3 p2 = new Vector3(0.99f);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);
            GL.Vertex3(p2._x, p1._y, p1._z);
            GL.Vertex3(p2._x, p2._y, p1._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p1._z);

            GL.End();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);

            GL.Vertex3(p1._x, p2._y, p1._z);
            GL.Vertex3(p1._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p2._z);
            GL.Vertex3(p2._x, p2._y, p1._z);

            GL.Vertex3(p1._x, p1._y, p1._z);
            GL.Vertex3(p1._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p2._z);
            GL.Vertex3(p2._x, p1._y, p1._z);

            GL.End();

            list.End();
            return list;
        }

        public GLDisplayList GetCircleList() { return FindOrCreate<GLDisplayList>("Circle", CreateCircle); }
        private static GLDisplayList CreateCircle(TKContext ctx)
        {
            GLDisplayList list = new GLDisplayList();
            list.Begin();

            GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.TriangleFan);

            GL.Vertex3(0.0f, 0.0f, 0.0f);

            float angle = 0.0f;
            for (int i = 0; i < 361; i++, angle = i * Maths._deg2radf)
                GL.Vertex2(Math.Cos(angle), Math.Sin(angle));

            GL.End();

            list.End();
            return list;
        }

        public void DrawSphere(float radius)
        {
            GL.PushMatrix();
            GL.Scale(radius, radius, radius);
            GetSphereList().Call();
            GL.PopMatrix();
        }
        public GLDisplayList GetSphereList() { return FindOrCreate<GLDisplayList>("Sphere", CreateSphere); }
        public static GLDisplayList CreateSphere(TKContext ctx)
        {
            IntPtr quad = Glu.NewQuadric();
            Glu.QuadricDrawStyle(quad, QuadricDrawStyle.Fill);
            Glu.QuadricOrientation(quad, QuadricOrientation.Outside);

            GLDisplayList dl = new GLDisplayList();

            dl.Begin();
            Glu.Sphere(quad, 1.0f, 40, 40);
            dl.End();

            Glu.DeleteQuadric(quad);

            return dl;
        }
    }
}