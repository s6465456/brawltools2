using System;
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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ResetClip();

            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingMode = CompositingMode.SourceOver;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.AssumeLinear;

            g.Clear(this.BackColor);

            if (_target == null) return;

            if (_currentImage == null) return;

            Rectangle client = this.ClientRectangle;
            Rectangle bounds = new Rectangle(0, 0, _currentImage.Width, _currentImage.Height);

            float aspect = (float)bounds.Width / bounds.Height;
            float newaspect = (float)client.Width / client.Height;

            float scale;
            if (newaspect > aspect)
                scale = (float)client.Height / bounds.Height;
            else
                scale = (float)client.Width / bounds.Width;

            bounds.Width = (int)(bounds.Width * scale);
            bounds.Height = (int)(bounds.Height * scale);
            bounds.X = (client.Width - bounds.Width) >> 1;
            bounds.Y = (client.Height - bounds.Height) >> 1;

            g.TranslateTransform(bounds.X, bounds.Y);
            g.ScaleTransform(scale, scale);
            g.SetClip(bounds);
            g.FillRectangle(Brushes.Cyan, new Rectangle(-1, -1, _currentImage.Width + 2, _currentImage.Height + 2));
            g.FillRectangle(Brushes.Magenta, 0, 0, _currentImage.Width, _currentImage.Height);
            g.Clear(Color.White);
            g.DrawImage(_currentImage, 0, 0);
            g.Flush();
        }

        private void btnLeft_Click(object sender, EventArgs e) { CurrentIndex--; }
        private void btnRight_Click(object sender, EventArgs e) { CurrentIndex++; }
    }
}
