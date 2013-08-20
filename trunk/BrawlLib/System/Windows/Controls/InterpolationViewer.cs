using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.OpenGL;
using OpenTK.Graphics.OpenGL;
using BrawlLib.Imaging;
using BrawlLib.Wii.Animations;

namespace System.Windows.Forms
{
    public partial class InterpolationViewer : GLPanel
    {
        public InterpolationViewer() { InitializeComponent(); }

        public event EventHandler SelectedKeyframeChanged, FrameChanged, UpdateProps;

        public KeyframeEntry _selKey = null, _hiKey = null;

        internal int _frame;
        public int FrameIndex
        {
            get { return _frame; } 
            set 
            {
                _frame = value.Clamp(0, _frameLimit);
                Invalidate();

                if (!_updating && FrameChanged != null)
                    FrameChanged(this, null);
            }
        }

        private int _frameLimit = 0;
        public int FrameLimit { get { return _frameLimit; } set { _frameLimit = value; } }

        private int DisplayedFrameLimit
        {
            get
            {
                if (_allKeys)
                    return _frameLimit - 1;
                else if (_selKey != null)
                    return GetKeyframeMaxIndex() - GetKeyframeMinIndex();
                return 0;
            } 
        }

        private int GetKeyframeMaxIndex()
        {
            if (!AllKeyframes)
            {
                if (_selKey != null)
                    if (_selKey._next._index < 0)
                        return _selKey._index;
                    else
                        return _selKey._next._index;
            }
            else
                return _frameLimit - 1;

            return 0;
        }


        private int GetKeyframeMinIndex()
        {
            if (!AllKeyframes)
            {
                if (_selKey != null)
                    if (_selKey._prev._index < 0)
                        return _selKey._index;
                    else
                        return _selKey._prev._index;
            }
            else
                return 0;

            return 0;
        }

        KeyframeEntry _keyRoot = null;
        public KeyframeEntry KeyRoot { get { return _keyRoot; } set { _keyRoot = value; UpdateDisplay(); } }

        internal bool _updating = false;

        public void UpdateDisplay()
        {
            OnResized();
            Invalidate();
        }

        bool _allKeys = true;
        public bool AllKeyframes 
        {
            get { return _allKeys; } 
            set
            {
                _allKeys = value;
                UpdateDisplay();
            }
        }

        bool _genTans = false;
        public bool GenerateTangents { get { return _genTans; } set { _genTans = value; } }

        public KeyframeEntry SelectedKeyframe 
        {
            get { return _selKey; }
            set
            {
                _selKey = value;

                if (SelectedKeyframeChanged != null && !_updating)
                    SelectedKeyframeChanged(this, null);
            }
        }

        const float _lineWidth = 1.5f, _pointWidth = 5.0f;
        unsafe internal override void OnInit(TKContext ctx)
        {
            //Set caps
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.Disable(EnableCap.DepthTest);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PointSmooth);
            GL.LineWidth(_lineWidth);
            GL.PointSize(_pointWidth);

            OnResized();
        }

        private bool _keyDraggingAllowed = false;
        public bool KeyDraggingAllowed { get { return _keyDraggingAllowed; } set { _keyDraggingAllowed = value; } }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_allKeys || _keyRoot == null)
                return;

            float x = e.X / xinc;
            int frameVal = (int)(x + 1.5f);
            if (!_dragging)
            {
                _hiKey = null;

                Cursor = Cursors.Default;

                float y = (Height - e.Y);
                for (KeyframeEntry entry = _keyRoot._next; (entry != _keyRoot); entry = entry._next)
                {
                    float frame = (float)entry._index;
                    if (Math.Abs(x - frame) <= 1.0f)
                    {
                        if (Math.Abs(y - (entry._value - _minVal) * yinc) < _pointWidth)
                        {
                            _hiKey = entry;
                            Cursor = Cursors.Hand;
                        }
                    }
                }

                if (Cursor != Cursors.Hand)
                    if (Math.Abs(x - _frame) < 1.0f)
                        Cursor = Cursors.VSplit;
            }
            else if (_selKey != null && _keyDraggingAllowed)
            {
                float y = (Height - e.Y) / yinc + _minVal;
                int xv = frameVal - 1;

                int xDiff = xv - _prevX;

                if (_selKey._prev._index < _selKey._index + xDiff && _selKey._next._index > _selKey._index + xDiff)
                    _selKey._index += xDiff;

                _selKey._value += (y - _prevY);

                _prevX = xv;
                _prevY = y;

                if (_genTans)
                {
                    _selKey.GenerateTangent();
                    _selKey._prev.GenerateTangent();
                    _selKey._next.GenerateTangent();
                }
            }
            else if (frameVal > 0 && _selKey == null)
                FrameIndex = frameVal;

            if (UpdateProps != null)
                UpdateProps(this, null);
            Invalidate();
        }

        bool _dragging = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool t = _selKey != _hiKey;

            _dragging = (_selKey = _hiKey) != null || Cursor == Cursors.VSplit;

            if (_selKey != null)
            {
                _prevX = _selKey._index;
                _prevY = _selKey._value;
            }

            if (t && SelectedKeyframeChanged != null)
                SelectedKeyframeChanged(this, null);
        }

        private int _prevX;
        private float _prevY;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _dragging = false;
        }

        private bool _linear = false;
        public bool Linear
        {
            get { return _linear; }
            set
            {
                _linear = value;
                if (!_updating)
                    UpdateDisplay();
            }
        }

        public float GetFrameValue(float index)
        {
            KeyframeEntry entry, root = _keyRoot;

            if (_keyRoot == null)
                return 0;

            if (index >= root._prev._index)
                return root._prev._value;
            if (index <= root._next._index)
                return root._next._value;

            for (entry = root._next;
                (entry != root) &&
                (entry._index < index); 
                entry = entry._next)
                if (entry._index == index)
                    return entry._value;
            
            return entry._prev.Interpolate(index - entry._prev._index, _linear);
        }

        public float _minVal = float.MaxValue;
        public float _maxVal = float.MinValue;
        public void FindMaxMin()
        {
            if (!AllKeyframes && SelectedKeyframe == null)
                return;

            _minVal = float.MaxValue;
            _maxVal = float.MinValue;

            int start = GetKeyframeMinIndex();
            int end = GetKeyframeMaxIndex();

            for (int i = start; i <= end; i++)
                if (i >= 0 && i < _frameLimit)
                {
                    float v = GetFrameValue(i);

                    if (v < _minVal)
                        _minVal = v;
                    if (v > _maxVal)
                        _maxVal = v;
                }
        }

        private float _tanLen = 5.0f;
        public float TangentLength { get { return _tanLen; } set { _tanLen = value; } }

        private void DrawTangent(KeyframeEntry e, float xMin)
        {
            int xVal = e._index;
            float yVal = e._value;
            float tan = e._tangent;

            GL.Begin(BeginMode.LineStrip);
            for (float i = -(_tanLen / 2); i <= (_tanLen / 2); i += 1)
                GL.Vertex2((xVal + i - xMin) * xinc, ((yVal - _minVal) + (tan * i)) * yinc);
            GL.End();

            //This other way displays the tangents with a fixed length,
            //but doesn't display the magnitude of the tangent's effect

            //float angle = (float)Math.Atan((tan * yinc) / xinc) * Maths._rad2degf;

            //GL.Translate((xVal - xMin) * xinc, (yVal - _minVal) * yinc, 0);
            //GL.Rotate(angle, 0, 0, 1);
            //GL.Scale(xinc, yinc, 0);

            //GL.Begin(BeginMode.Lines);
            //GL.Vertex2(-_tanLen / 2, 0);
            //GL.Vertex2(_tanLen / 2, 0);
            //GL.End();

            //GL.Scale(1 / xinc, 1 / yinc, 0);
            //GL.Rotate(-angle, 0, 0, 1);
            //GL.Translate(-(xVal - xMin) * xinc, -(yVal - _minVal) * yinc, 0);
        }

        private float _precision = 4.0f;
        public float Precision { get { return _precision; } set { _precision = value; Invalidate(); } }

        protected internal unsafe override void OnRender(TKContext ctx, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);

            if (_keyRoot == null)
                return;

            CalcXY();

            if (_allKeys)
            {
                //Draw lines
                //GL.Color4(Color.Black);
                //GL.Begin(BeginMode.Lines);
                //for (KeyframeEntry entry = _keyRoot._next; (entry != _keyRoot); entry = entry._next)
                //{
                //    float xv = entry._index * xinc;
                //    GL.Vertex2(xv, 0.0f);
                //    GL.Vertex2(xv, Height);

                //    float yv = (GetFrameValue(entry._index) - _minVal) * yinc;
                //    GL.Vertex2(0.0f, yv);
                //    GL.Vertex2(Width, yv);
                //}
                //GL.End();

                //Draw interpolation
                GL.Color4(Color.Red);
                GL.Begin(BeginMode.LineStrip);
                if (!_linear)
                    for (float i = 0; i < (float)_frameLimit; i += (1 / _precision))
                        GL.Vertex2(i * xinc, (GetFrameValue(i) - _minVal) * yinc);
                else
                    for (KeyframeEntry entry = _keyRoot._next; (entry != _keyRoot); entry = entry._next)
                        GL.Vertex2(entry._index * xinc, (GetFrameValue(entry._index) - _minVal) * yinc);
                GL.End();

                //Draw tangents
                GL.Color4(Color.Green);
                for (KeyframeEntry entry = _keyRoot._next; (entry != _keyRoot); entry = entry._next)
                    DrawTangent(entry, 0);
                
                //Draw frame indicator
                GL.Color4(Color.Blue);
                if (_frame >= 0 && _frame < _frameLimit)
                {
                    GL.Begin(BeginMode.Lines);

                    float r = _frame * xinc;
                    GL.Vertex2(r, 0.0f);
                    GL.Vertex2(r, Height);

                    GL.End();
                }

                //Draw points
                GL.Color4(Color.Black);
                GL.Begin(BeginMode.Points);
                for (KeyframeEntry entry = _keyRoot._next; (entry != _keyRoot); entry = entry._next)
                {
                    bool t = false;
                    if (t = (_hiKey == entry || _selKey == entry))
                    {
                        GL.PointSize(_pointWidth * 4.0f);
                        GL.Color4(Color.Orange);
                    }
                    GL.Vertex2(entry._index * xinc, (GetFrameValue(entry._index) - _minVal) * yinc);

                    if (t)
                    {
                        GL.PointSize(_pointWidth);
                        GL.Color4(Color.Black);
                    }
                }
                GL.End();
            }
            else if (SelectedKeyframe != null)
            {
                //Draw lines
                GL.Color4(Color.Black);
                GL.Begin(BeginMode.Lines);

                int min = GetKeyframeMinIndex();
                int max = GetKeyframeMaxIndex();

                float xv = (SelectedKeyframe._index - min) * xinc;
                GL.Vertex2(xv, 0.0f);
                GL.Vertex2(xv, Height);

                float yv = (GetFrameValue(SelectedKeyframe._index) - _minVal) * yinc;
                GL.Vertex2(0.0f, yv);
                GL.Vertex2(Width, yv);

                GL.End();

                //Draw interpolation
                GL.Color4(Color.Red);
                GL.Begin(BeginMode.LineStrip);
                for (float i = 0; i <= (float)(max - min); i += (1 / _precision))
                    GL.Vertex2(i * xinc, (GetFrameValue(i + min) - _minVal) * yinc);
                GL.End();
                
                //Draw tangent
                GL.Color4(Color.Green);
                DrawTangent(SelectedKeyframe, min);

                //Draw points
                GL.Color4(Color.Black);
                GL.Begin(BeginMode.Points);

                GL.Vertex2((SelectedKeyframe._index - min) * xinc, (GetFrameValue(SelectedKeyframe._index) - _minVal) * yinc);
                
                GL.End();
            }
        }

        float xinc; //Width/Frames ratio
        float yinc; //Height/Values ratio
        private void CalcXY()
        {
            int i = DisplayedFrameLimit;
            if (i == 0)
                return;

            //Calculate X Interval
            xinc = (float)Width / (float)i;

            FindMaxMin();

            //Calculate Y Interval
            yinc = ((float)Height / (_maxVal - _minVal));
        }

        public override void OnResized()
        {
            Capture();

            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Width, 0, Height, -0.1f, 1.0f);
        }
    }
}
