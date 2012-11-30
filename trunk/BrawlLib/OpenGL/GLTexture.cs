using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using BrawlLib.SSBB.ResourceNodes;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace BrawlLib.OpenGL
{
    public class GLTexture
    {
        public string _name;
        public int _texId;

        private bool _remake = true;
        private Bitmap[] _textures;

        //public unsafe GLTexture(GLModel gLModel, MDL0TextureNode tex)
        //{
        //    _name = tex.Name;
        //}

        public unsafe int Initialize()
        {
            if (_remake)
            {
                ClearTexture();

                _texId = GL.GenTexture();

                GL.BindTexture(TextureTarget.Texture2D, _texId);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)GLTextureFilter.LINEAR);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)GLTextureFilter.NEAREST_MIPMAP_LINEAR);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBaseLevel, 0);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, _textures.Length - 1);

                for (int i = 0; i < _textures.Length; i++)
                {
                    Bitmap bmp = _textures[i];
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, i, PixelInternalFormat.Four, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, (IntPtr)data.Scan0);
                    bmp.UnlockBits(data);
                }

                _remake = false;
                ClearImages();
            }
            return _texId;
        }

        private void ClearImages()
        {
            if (_textures != null)
            {
                foreach (Bitmap bmp in _textures)
                    bmp.Dispose();
                _textures = null;
            }
        }
        private unsafe void ClearTexture()
        {
            if (_texId != 0)
            {
                int id = _texId;
                GL.DeleteTexture(id);
                _texId = 0;
            }
        }

        public void Unbind()
        {
            ClearImages();
            ClearTexture();
        }

        //internal void Attach(Bitmap bmp, string name)
        //{
        //    if (name.Equals(_name))
        //    {
        //        _bmp = bmp;
        //        _remake = true;
        //    }
        //}

        internal unsafe void Attach(TEX0Node tex)
        {
            ClearImages();

            _textures = new Bitmap[tex.LevelOfDetail];
            for (int i = 0; i < tex.LevelOfDetail; i++)
                _textures[i] = tex.GetImage(i);

            _remake = true;
        }
        
        internal int _id;
        internal int _width, _height;

        public int Id { get { return _id; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        //public GLTexture() { }
        public unsafe GLTexture(int width, int height)
        {
            _id = GL.GenTexture();
            _width = width;
            _height = height;
        }

        public void Bind() { Bind(-1, -1, null); }
        public void Bind(int index, int program, TKContext ctx)
        {
            if (program != -1 && index >= 0 && index <= 7 && ctx != null && ctx._canUseShaders)
            {
                //GL.ActiveTexture(TextureUnit.Texture0 + index);
                GL.ClientActiveTexture(TextureUnit.Texture0 + index);
                int i = GL.GetUniformLocation(program, "samp" + index);
                if (i > -1) GL.Uniform1(i, index);
            }
            GL.BindTexture(TextureTarget.Texture2D, _id);
        }

        public unsafe void Delete()
        {
            if (_id != 0)
            {
                int id = _id;
                GL.DeleteTexture(id);
                _id = 0;
            }
        }
    }
}
