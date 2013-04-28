﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using BrawlLib.Imaging;
using System.Drawing.Design;

namespace System.Windows.Forms
{
    public class GoodColorControl : UserControl
    {
        #region Designer

        private BufferedPanel pnlColorBox;
        private BufferedPanel pnlColorBar;
        private Label lblR;
        private Label label1;
        private Label label2;
        private NumericUpDown numB;
        private NumericUpDown numG;
        private NumericUpDown numR;
        private NumericUpDown numH;
        private NumericUpDown numS;
        private NumericUpDown numV;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numA;
        private Label lblA;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private BufferedPanel pnlAlpha;

        private void InitializeComponent()
        {
            this.lblR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numB = new System.Windows.Forms.NumericUpDown();
            this.numG = new System.Windows.Forms.NumericUpDown();
            this.numR = new System.Windows.Forms.NumericUpDown();
            this.numH = new System.Windows.Forms.NumericUpDown();
            this.numS = new System.Windows.Forms.NumericUpDown();
            this.numV = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numA = new System.Windows.Forms.NumericUpDown();
            this.lblA = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlAlpha = new System.Windows.Forms.BufferedPanel();
            this.pnlColorBox = new System.Windows.Forms.BufferedPanel();
            this.pnlColorBar = new System.Windows.Forms.BufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblR
            // 
            this.lblR.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(-1, 91);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(19, 20);
            this.lblR.TabIndex = 2;
            this.lblR.Text = "R";
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "B";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "G";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numB
            // 
            this.numB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numB.Location = new System.Drawing.Point(19, 130);
            this.numB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numB.Name = "numB";
            this.numB.Size = new System.Drawing.Size(43, 20);
            this.numB.TabIndex = 5;
            this.numB.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // numG
            // 
            this.numG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numG.Location = new System.Drawing.Point(19, 111);
            this.numG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numG.Name = "numG";
            this.numG.Size = new System.Drawing.Size(43, 20);
            this.numG.TabIndex = 6;
            // 
            // numR
            // 
            this.numR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numR.Location = new System.Drawing.Point(19, 92);
            this.numR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numR.Name = "numR";
            this.numR.Size = new System.Drawing.Size(43, 20);
            this.numR.TabIndex = 7;
            // 
            // numH
            // 
            this.numH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numH.Location = new System.Drawing.Point(19, 20);
            this.numH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(43, 20);
            this.numH.TabIndex = 13;
            // 
            // numS
            // 
            this.numS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numS.Location = new System.Drawing.Point(19, 39);
            this.numS.Name = "numS";
            this.numS.Size = new System.Drawing.Size(43, 20);
            this.numS.TabIndex = 12;
            // 
            // numV
            // 
            this.numV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numV.Location = new System.Drawing.Point(19, 58);
            this.numV.Name = "numV";
            this.numV.Size = new System.Drawing.Size(43, 20);
            this.numV.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "S";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "V";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-1, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "H";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numA
            // 
            this.numA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numA.Location = new System.Drawing.Point(19, 149);
            this.numA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numA.Name = "numA";
            this.numA.Size = new System.Drawing.Size(43, 20);
            this.numA.TabIndex = 15;
            // 
            // lblA
            // 
            this.lblA.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.Location = new System.Drawing.Point(-1, 148);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(19, 20);
            this.lblA.TabIndex = 14;
            this.lblA.Text = "A";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlColorBox);
            this.panel1.Controls.Add(this.pnlColorBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 187);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlAlpha);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(217, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 187);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numH);
            this.panel3.Controls.Add(this.lblR);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.numA);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblA);
            this.panel3.Controls.Add(this.numB);
            this.panel3.Controls.Add(this.numG);
            this.panel3.Controls.Add(this.numS);
            this.panel3.Controls.Add(this.numR);
            this.panel3.Controls.Add(this.numV);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(237, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 187);
            this.panel3.TabIndex = 18;
            // 
            // pnlAlpha
            // 
            this.pnlAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAlpha.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlpha.Location = new System.Drawing.Point(3, 3);
            this.pnlAlpha.Name = "pnlAlpha";
            this.pnlAlpha.Size = new System.Drawing.Size(14, 180);
            this.pnlAlpha.TabIndex = 2;
            this.pnlAlpha.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAlpha_Paint);
            this.pnlAlpha.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlAlpha_MouseMove);
            this.pnlAlpha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlAlpha_MouseDown);
            this.pnlAlpha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlAlpha_MouseUp);
            // 
            // pnlColorBox
            // 
            this.pnlColorBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlColorBox.Location = new System.Drawing.Point(3, 3);
            this.pnlColorBox.Name = "pnlColorBox";
            this.pnlColorBox.Size = new System.Drawing.Size(180, 180);
            this.pnlColorBox.TabIndex = 0;
            this.pnlColorBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlColorBox_Paint);
            this.pnlColorBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlColorBox_MouseMove);
            this.pnlColorBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlColorBox_MouseDown);
            this.pnlColorBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlColorBox_MouseUp);
            // 
            // pnlColorBar
            // 
            this.pnlColorBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlColorBar.Location = new System.Drawing.Point(189, 3);
            this.pnlColorBar.Name = "pnlColorBar";
            this.pnlColorBar.Size = new System.Drawing.Size(25, 180);
            this.pnlColorBar.TabIndex = 1;
            this.pnlColorBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlColorBar_Paint);
            this.pnlColorBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlColorBar_MouseMove);
            this.pnlColorBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlColorBar_MouseDown);
            this.pnlColorBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlColorBar_MouseUp);
            // 
            // GoodColorControl
            // 
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(310, 187);
            this.Name = "GoodColorControl";
            this.Size = new System.Drawing.Size(310, 187);
            ((System.ComponentModel.ISupportInitialize)(this.numB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numA)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private int _hue;
        private HSVPixel _hsv = new HSVPixel(0, 100, 100);

        //private int _alpha = 255;
        private ARGBPixel _rgb;

        bool _squareGrabbing;
        int _squareX, _squareY;

        bool _barGrabbing;
        int _barY;

        bool _alphaGrabbing;
        int _alphaY;

        bool _updating;

        private NumericUpDown[] _boxes;

        private int _brushH = -1;
        private PathGradientBrush _squareBrush;
        //private GraphicsPath _squarePath;
        private Color[] _boxColors = new Color[]{Color.Black, Color.White, Color.Black, Color.Black, Color.Black};

        private LinearGradientBrush _barBrush;
        private LinearGradientBrush _alphaBrush;

        public event EventHandler ColorChanged;

        private bool _showAlpha = true;
        public bool ShowAlpha
        {
            get { return _showAlpha; }
            set { panel2.Visible = numA.Visible = lblA.Visible = _showAlpha = value; }
        }

        public Color Color
        {
            get { return (Color)_rgb; }
            set 
            { 
                _hsv = (HSVPixel)value;

                _updating = true;
                numA.Value = value.A;
                _updating = false;

                OnColorChanged(); 
            }
        }


        public GoodColorControl()
        {
            InitializeComponent();

            _boxes = new NumericUpDown[] { numH, numS, numV, numR, numG, numB, numA };
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].ValueChanged += OnBoxChanged;
                _boxes[i].Tag = i;
            }

            Rectangle r = pnlColorBox.ClientRectangle;

            //_squarePath = new GraphicsPath();
            //_squarePath.AddRectangle(r);
            //_squareBrush = new PathGradientBrush(_squarePath);

            _squareBrush = new PathGradientBrush(new PointF[] { 
                new PointF(r.Width, 0),
                new PointF(r.Width, r.Height),
                new PointF(0, r.Height),
                new PointF(0,0),
                new PointF(r.Width, 0)});
            _squareBrush.CenterPoint = new PointF(r.Width / 2, r.Height / 2);

            float p = r.Height / 6.0f / r.Height;
            _barBrush = new LinearGradientBrush(new Rectangle(0, 0, r.Width, r.Height), Color.Red, Color.Red, LinearGradientMode.Vertical);

            ColorBlend blend = new ColorBlend();
            blend.Colors = new Color[] { Color.Red, Color.Yellow, Color.Lime, Color.Cyan, Color.Blue, Color.Magenta, Color.Red };
            blend.Positions = new float[] { 0, p, p * 2, p * 3, p * 4, p * 5, 1.0f };

            _barBrush.InterpolationColors = blend;

            _alphaBrush = new LinearGradientBrush(new Rectangle(0, 0, pnlAlpha.Width, pnlAlpha.Height), Color.White, Color.Black, LinearGradientMode.Vertical);
        }

        protected void OnBoxChanged(object sender, EventArgs e)
        {
            if (_updating)
                return;

            NumericUpDown box = sender as NumericUpDown;
            int value = (int)box.Value;
            int index = (int)box.Tag;
            switch (index)
            {
                case 0: { _hsv.H = (ushort)value; break; }
                case 1: { _hsv.S = (byte)value; break; }
                case 2: { _hsv.V = (byte)value; break; }
                case 3: { _rgb.R = (byte)value; break; }
                case 4: { _rgb.G = (byte)value; break; }
                case 5: { _rgb.B = (byte)value; break; }
                case 6: { pnlAlpha.Invalidate(); break; }
            }

            if ((index > 2) && (index < 6))
                _hsv = (HSVPixel)_rgb;

            //OnColorChanged();

            pnlColorBox.Invalidate();
            pnlColorBar.Invalidate();

            _rgb = (ARGBPixel)_hsv;
            _rgb.A = (byte)numA.Value;

            if (ColorChanged != null)
                ColorChanged(this, null);
        }

        protected virtual void OnColorChanged()
        {
            pnlColorBox.Invalidate();
            pnlColorBar.Invalidate();
            UpdateBoxes();

            if (ColorChanged != null)
                ColorChanged(this, null);
        }

        private void UpdateBoxes()
        {
            _updating = true;

            numH.Value = _hsv.H;
            numS.Value = _hsv.S;
            numV.Value = _hsv.V;

            _rgb = (ARGBPixel)_hsv;
            _rgb.A = (byte)numA.Value;
            numR.Value = _rgb.R;
            numG.Value = _rgb.G;
            numB.Value = _rgb.B;

            _updating = false;
        }


        #region ColorBox
        private void pnlColorBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _squareGrabbing = true;
                pnlColorBox_MouseMove(sender, e);
            }
        }
        private void pnlColorBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _squareGrabbing = false;
        }
        private void pnlColorBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_squareGrabbing)
            {
                int x = Math.Min(Math.Max(e.X, 0), pnlColorBox.Width);
                int y = Math.Min(Math.Max(e.Y, 0), pnlColorBox.Height);
                if ((x != _squareX) || (y != _squareY))
                {
                    _squareX = x;
                    _squareY = y;

                    _hsv.V = (byte)((float)x / pnlColorBox.Width * 100);
                    _hsv.S = (byte)((float)(pnlColorBox.Height - y) / pnlColorBox.Height * 100);

                    OnColorChanged();
                }
            }
        }
        private void pnlColorBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Update brush if color changed
            if (_brushH != _hsv.H)
            {
                _boxColors[0] = _boxColors[4] = (Color)(new HSVPixel(_hsv.H, 100, 100));
                _squareBrush.SurroundColors = _boxColors;
                _squareBrush.CenterColor = (Color)(new HSVPixel(_hsv.H, 50, 50));
                _brushH = _hsv.H;
            }

            //Draw square
            //g.FillPath(_squareBrush, _squarePath);
            g.FillRectangle(_squareBrush, pnlColorBox.ClientRectangle);

            //Draw indicator
            int x = (int)(_hsv.V / 100.0f * pnlColorBox.Width);
            int y = (int)((100 - _hsv.S) / 100.0f * pnlColorBox.Height);
            Rectangle r = new Rectangle(x - 3, y - 3, 6, 6);
            ARGBPixel p = _rgb.Inverse();
            p.A = 255;

            using (Pen pen = new Pen((Color)p))
                g.DrawEllipse(pen, r);

            r.X -= 1;
            r.Y -= 1;
            r.Width += 2;
            r.Height += 2;
            p = p.Lighten(64);

            using (Pen pen = new Pen((Color)p))
                g.DrawEllipse(pen, r);
        }
        #endregion

        #region HueBar
        private void pnlColorBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _barGrabbing = true;
                pnlColorBar_MouseMove(sender, e);
            }
        }
        private void pnlColorBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _barGrabbing = false;
        }
        private void pnlColorBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_barGrabbing)
            {
                int y = Math.Max(Math.Min(e.Y, (pnlColorBar.Height - 1)), 0);
                if (y != _barY)
                {
                    _barY = y;

                    _hsv.H = (ushort)((float)y / (pnlColorBar.Height - 1) * 360);
                    OnColorChanged();
                }
            }
        }
        private void pnlColorBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Draw bar
            g.FillRectangle(_barBrush, pnlColorBar.ClientRectangle);

            //Draw indicator
            ARGBPixel p = ((ARGBPixel)(new HSVPixel(_hsv.H, 100, 100))).Inverse();
            int y = (int)(_hsv.H / 360.0f * (pnlColorBar.Height - 1));
            Rectangle r = new Rectangle(-1, y - 2, pnlColorBar.Width + 1, 4);

            using (Pen pen = new Pen((Color)p))
                g.DrawRectangle(pen, r);

            r.Y += 1;
            r.Height -= 2;
            p = p.Lighten(64);

            using (Pen pen = new Pen((Color)p))
                g.DrawRectangle(pen, r);
        }
        #endregion

        #region AlphaBar

        private void pnlAlpha_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _alphaGrabbing = true;
                pnlAlpha_MouseMove(sender, e);
            }
        }
        private void pnlAlpha_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            _alphaGrabbing = false;
        }
        private void pnlAlpha_MouseMove(object sender, MouseEventArgs e)
        {
            if (_alphaGrabbing)
            {
                int y = Math.Max(Math.Min(e.Y, (pnlAlpha.Height - 1)), 0);
                if (y != _alphaY)
                {
                    _alphaY = y;
                    numA.Value = (byte)(255 - ((float)y / (pnlAlpha.Height - 1) * 255));
                }
            }
        }
        private void pnlAlpha_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Draw bar
            g.FillRectangle(_alphaBrush, pnlAlpha.ClientRectangle);

            //Draw indicator
            byte col = (byte)(255 - _rgb.A);
            ARGBPixel p = new ARGBPixel(255, col, col, col);
            int y = (int)(col / 255.0f * (pnlAlpha.Height - 1));
            Rectangle r = new Rectangle(-1, y - 2, pnlAlpha.Width + 1, 4);

            using (Pen pen = new Pen((Color)p))
                g.DrawRectangle(pen, r);

            p.Lighten(64);

            r.Y += 1;
            r.Height -= 2;

            using (Pen pen = new Pen((Color)p))
                g.DrawRectangle(pen, r);
        }

        #endregion

        private void pnlColorBox_Resize(object sender, EventArgs e)
        {

        }
    }
}
