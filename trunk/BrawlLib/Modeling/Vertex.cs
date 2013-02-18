using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Wii.Models;
using BrawlLib.OpenGL;
using System.Drawing;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Imaging;

namespace BrawlLib.Modeling
{
    public class Vertex3
    {
        public Vector3 _position;
        public Vector3 _weightedPosition;

        public Vector3 _normal;
        public Vector3 _weightedNormal;

        internal IMatrixNode _influence;

        public RGBAPixel[] _colors = new RGBAPixel[2];
        public Vector2[] _uvs = new Vector2[8];

        public int Index = 0;

        [Browsable(true)]
        public string Influence
        {
            get { return Inf == null ? "(none)" : Inf.IsPrimaryNode ? ((MDL0BoneNode)Inf)._name : "(multiple)"; }
            //set { Inf = String.IsNullOrEmpty(value) ? null : Model.FindOrCreateBone(value); Model.SignalPropertyChange(); }
        }
        [Browsable(false)]
        public IMatrixNode Inf
        {
            get { return _influence; }
            set
            {
                if (_influence == value)
                    return;

                if (_influence != null)
                    _influence.ReferenceCount--;

                if ((_influence = value) != null)
                    _influence.ReferenceCount++;
            }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 WeightedPosition
        {
            get { return _weightedPosition; }
            set { _weightedPosition = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel Color1
        {
            get { return _colors[0]; }
            set { _colors[0] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel Color2
        {
            get { return _colors[1]; }
            set { _colors[1] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV1
        {
            get { return _uvs[0]; }
            set { _uvs[0] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV2
        {
            get { return _uvs[1]; }
            set { _uvs[1] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV3
        {
            get { return _uvs[2]; }
            set { _uvs[2] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV4
        {
            get { return _uvs[3]; }
            set { _uvs[3] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV5
        {
            get { return _uvs[4]; }
            set { _uvs[4] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV6
        {
            get { return _uvs[5]; }
            set { _uvs[5] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV7
        {
            get { return _uvs[6]; }
            set { _uvs[6] = value; }
        }
        [Browsable(true), Category("Vertex"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 UV8
        {
            get { return _uvs[7]; }
            set { _uvs[7] = value; }
        }
        [Browsable(true), Category("Normal"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 WeightedNormal
        {
            get { return _weightedNormal; }
            set { _weightedNormal = value; }
        }

        public Vertex3(Vector3 position)
        {
            Position = position;
        }

        public Vertex3(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }

        public Vertex3(Vector3 position, IMatrixNode influence)
        {
            Position = position;
            Inf = influence;
        }

        public Vertex3(Vector3 position, Vector3 normal, IMatrixNode influence)
        {
            Position = position;
            Normal = normal;
            Inf = influence;
        }

        public Vertex3(Vector3 position, IMatrixNode influence, Vector3 normal, RGBAPixel[] color, Vector2[] uv)
        {
            Position = position;
            Inf = influence;
            Normal = normal;
            _colors = color;
            _uvs = uv;
        }

        //Pre-multiply vertex and normal using influence.
        //Influences must have already been calculated.
        public void Weight()
        {
            _weightedPosition = (_influence != null) ? _influence.Matrix * Position : Position;
            //_weightedNormal = (_influence != null) ? _influence.Matrix.GetRotationMatrix() * Normal : Normal;
        }
        //Need to do this to put the vertices back in their raw positions if they were moved.
        public void UnWeight()
        {
            
        }

        public void Morph(Vector3 dest, float percent) { _weightedPosition.Morph(dest, percent); }

        public Color GetWeightColor(MDL0BoneNode targetBone)
        {
            float weight = -1;
            if (_influence == null || targetBone == null) 
                return Color.Transparent;
            if (_influence is MDL0BoneNode)
                if (_influence == targetBone)
                    weight = 1.0f;
                else
                    return Color.Transparent;
            else 
                foreach (BoneWeight b in ((Influence)_influence)._weights)
                    if (b.Bone == targetBone)
                    {
                        weight = b.Weight;
                        break;
                    }
            if (weight == -1)
                return Color.Transparent;
            int r = ((int)(weight * 255.0f)).Clamp(0, 0xFF);
            return Color.FromArgb(r, 0, 0xFF - r);
        }

        public bool Equals(Vertex3 v)
        {
            if (object.ReferenceEquals(this, v))
                return true;

            return (Position == v.Position) && (_influence == v._influence);
        }
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public unsafe struct VertData
    //{
    //    public const int Size = 12 + 12 + 4 + 4 * 2 + 8 * 8;

    //    public Vector3 _position;
    //    public Vector3 _normal;
    //    public int _weight;

    //    public RGBAPixel _color1;
    //    public RGBAPixel _color2;

    //    public Vector2 _uv1;
    //    public Vector2 _uv2;
    //    public Vector2 _uv3;
    //    public Vector2 _uv4;
    //    public Vector2 _uv5;
    //    public Vector2 _uv6;
    //    public Vector2 _uv7;
    //    public Vector2 _uv8;
        
    //    public VertData(Vector3 position, int weight, Vector3 normal, RGBAPixel[] color, Vector2[] uv)
    //    {
    //        _position = position;
    //        _weight = weight;
    //        _normal = normal;

    //        _color1 = color[0];
    //        _color2 = color[1];

    //        _uv1 = uv[0];
    //        _uv2 = uv[1];
    //        _uv3 = uv[2];
    //        _uv4 = uv[3];
    //        _uv5 = uv[4];
    //        _uv6 = uv[5];
    //        _uv7 = uv[6];
    //        _uv8 = uv[7];
    //    }

    //    public bool Equals(VertData v)
    //    {
    //        if (object.ReferenceEquals(this, v))
    //            return true;

    //        return
    //            (_position == v._position) &&
    //            (_normal == v._normal) &&
    //            (_weight == v._weight) &&
    //            (_color1 == v._color1) &&
    //            (_color2 == v._color2) &&
    //            (_uv1 == v._uv1) &&
    //            (_uv2 == v._uv2) &&
    //            (_uv3 == v._uv3) &&
    //            (_uv4 == v._uv4) &&
    //            (_uv5 == v._uv5) &&
    //            (_uv6 == v._uv6) &&
    //            (_uv7 == v._uv7) &&
    //            (_uv8 == v._uv8); 
    //    }

    //    public static bool operator !=(VertData v1, VertData v2)
    //    {
    //        return
    //            (v1._position != v2._position) ||
    //            (v1._normal != v2._normal) ||
    //            (v1._weight != v2._weight) ||
    //            (v1._color1 != v2._color1) ||
    //            (v1._color2 != v2._color2) ||
    //            (v1._uv1 != v2._uv1) ||
    //            (v1._uv2 != v2._uv2) ||
    //            (v1._uv3 != v2._uv3) ||
    //            (v1._uv4 != v2._uv4) ||
    //            (v1._uv5 != v2._uv5) ||
    //            (v1._uv6 != v2._uv6) ||
    //            (v1._uv7 != v2._uv7) ||
    //            (v1._uv8 != v2._uv8);
    //    }

    //    public static bool operator ==(VertData v1, VertData v2)
    //    {
    //        return
    //            (v1._position == v2._position) &&
    //            (v1._normal == v2._normal) &&
    //            (v1._weight == v2._weight) &&
    //            (v1._color1 == v2._color1) &&
    //            (v1._color2 == v2._color2) &&
    //            (v1._uv1 == v2._uv1) &&
    //            (v1._uv2 == v2._uv2) &&
    //            (v1._uv3 == v2._uv3) &&
    //            (v1._uv4 == v2._uv4) &&
    //            (v1._uv5 == v2._uv5) &&
    //            (v1._uv6 == v2._uv6) &&
    //            (v1._uv7 == v2._uv7) &&
    //            (v1._uv8 == v2._uv8);
    //    }
    //}
}
