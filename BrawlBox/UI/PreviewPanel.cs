﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using BrawlLib.Imaging;

namespace BrawlBox
{
    //interface IPreviewObject
    //{
    //    int PreviewImageCount { get; }
    //    Bitmap GetPreviewImage(int index);
    //}

    partial class PreviewPanel : UserControl
    {
        private object _target;
        private int _targetIndex, _maxIndex;
        private Image _currentImage;
        internal static HatchBrush _brush = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.LightGray, Color.GhostWhite);

        public object RenderingTarget
        {
            get { return _target; }
            set
            {
                if (_currentImage != null) { _currentImage.Dispose(); _currentImage = null; }
                _targetIndex = 0;
                _target = value;

                if (_target is IImageSource)
                    _maxIndex = ((IImageSource)_target).ImageCount - 1;
                else
                    _maxIndex = 0;

                if (_maxIndex > 0)
                    btnRight.Visible = btnLeft.Visible = true;
                else
                    btnRight.Visible = btnLeft.Visible = false;

                CurrentIndex = 0;
            }
        }
        public int CurrentIndex
        {
            get { return _targetIndex; }
            set
            {
                _targetIndex = Math.Min(Math.Max(value, 0), _maxIndex);
                if (_targetIndex == 0)
                    btnLeft.Enabled = false;
                else
                    btnLeft.Enabled = true;

                if (_targetIndex == _maxIndex)
                    btnRight.Enabled = false;
                else
                    btnRight.Enabled = true;

                if (_target is Image)
                    _currentImage = _target as Image;
                else if (_target is IImageSource)
                {
                    if (_currentImage != null) { _currentImage.Dispose(); _currentImage = null; }
                    _currentImage = ((IImageSource)_target).GetImage(value);
                }

                Refresh();
            }
        }

        public PreviewPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            if (_currentImage == null)
                return;

            int w = _currentImage.Width, h = _currentImage.Height;
            Rectangle client = this.ClientRectangle;
            Rectangle bounds = new Rectangle(0, 0, w, h);

            float aspect = (float)w / h;
            float newaspect = (float)client.Width / client.Height;

            float scale = (newaspect > aspect) ? (float)client.Height / h : (float)client.Width / w;

            bounds.Width = (int)(w * scale);
            bounds.Height = (int)(h * scale);
            bounds.X = (client.Width - bounds.Width) >> 1;
            bounds.Y = (client.Height - bounds.Height) >> 1;

            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingMode = CompositingMode.SourceOver;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.AssumeLinear;

            g.FillRectangle(_brush, bounds);
            g.DrawImage(_currentImage, bounds);

            g.Flush();
        }

        private void btnLeft_Click(object sender, EventArgs e) { CurrentIndex--; }
        private void btnRight_Click(object sender, EventArgs e) { CurrentIndex++; }
    }
}
