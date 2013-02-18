﻿using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

namespace BrawlLib.Imaging
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ARGBPixel
    {
        private const float ColorFactor = 1.0f / 255.0f;

        public byte B, G, R, A;

        public ARGBPixel(byte a, byte r, byte g, byte b) { A = a; R = r; G = g; B = b; }
        public ARGBPixel(byte intensity) { A = 255; R = intensity; G = intensity; B = intensity; }

        public int DistanceTo(Color c)
        {
            int val = A - c.A;
            int dist = val * val;
            val = R - c.R;
            dist += val * val;
            val = G - c.G;
            dist += val * val;
            val = B - c.B;
            dist += val * val;
            return dist;
        }
        public int DistanceTo(ARGBPixel p)
        {
            int val = A - p.A;
            int dist = val * val;
            val = R - p.R;
            dist += val * val;
            val = G - p.G;
            dist += val * val;
            val = B - p.B;
            return dist + val;
        }
        public float Luminance()
        {
            return (0.299f * R) + (0.587f * G) + (0.114f * B);
        }
        public bool IsGreyscale()
        {
            return (R == G) && (G == B);
        }
        public int Greyscale() { return (R + G + B) / 3; }

        public static explicit operator ARGBPixel(int val) { return *((ARGBPixel*)&val); }
        public static explicit operator int(ARGBPixel p) { return *((int*)&p); }
        public static explicit operator ARGBPixel(uint val) { return *((ARGBPixel*)&val); }
        public static explicit operator uint(ARGBPixel p) { return *((uint*)&p); }
        public static explicit operator ARGBPixel(Color val) { return (ARGBPixel)val.ToArgb(); }
        public static explicit operator Color(ARGBPixel p) { return Color.FromArgb((int)p); }
        public static explicit operator Vector3(ARGBPixel p) { return new Vector3(p.R * ColorFactor, p.G * ColorFactor, p.B * ColorFactor); }

        public ARGBPixel Min(ARGBPixel p) { return new ARGBPixel(Math.Min(A, p.A), Math.Min(R, p.R), Math.Min(G, p.G), Math.Min(B, p.B)); }
        public ARGBPixel Max(ARGBPixel p) { return new ARGBPixel(Math.Max(A, p.A), Math.Max(R, p.R), Math.Max(G, p.G), Math.Max(B, p.B)); }

        public static bool operator ==(ARGBPixel p1, ARGBPixel p2) { return *((uint*)(&p1)) == *((uint*)(&p2)); }
        public static bool operator !=(ARGBPixel p1, ARGBPixel p2) { return *((uint*)(&p1)) != *((uint*)(&p2)); }

        public override string ToString()
        {
            //return String.Format("A:{0:X2} R:{1:X2} G:{2:X2} B:{3:X2}", A, R, G, B);
            return String.Format("A:{0} R:{1} G:{2} B:{3}", A, R, G, B);
        }
        public override int GetHashCode() { return (int)this; }
        public override bool Equals(object obj)
        {
            if (obj is ARGBPixel) return (ARGBPixel)obj == this;
            return false;
        }

        internal unsafe ARGBPixel Inverse()
        {
            return new ARGBPixel(A, (byte)(255 - R), (byte)(255 - G), (byte)(255 - B));
        }
        internal unsafe ARGBPixel Lighten(int amount)
        {
            return new ARGBPixel(A, (byte)Math.Min(R + amount, 255), (byte)Math.Min(G + amount, 255), (byte)Math.Min(B + amount, 255));
        }
        internal unsafe ARGBPixel Darken(int amount)
        {
            return new ARGBPixel(A, (byte)Math.Max(R - amount, 0), (byte)Math.Max(G - amount, 0), (byte)Math.Max(B - amount, 0));
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct HSVPixel
    {
        public ushort H;
        public byte S, V;

        public HSVPixel(ushort h, byte s, byte v) { H = h; S = s; V = v; }

        public static explicit operator HSVPixel(ARGBPixel p)
        {
            HSVPixel outp;

            int min = Math.Min(Math.Min(p.R, p.G), p.B);
            int max = Math.Max(Math.Max(p.R, p.G), p.B);
            int diff = max - min;

            if (diff == 0)
            {
                outp.H = 0;
                outp.S = 0;
            }
            else
            {
                if (max == p.R)
                    outp.H = (ushort)((60 * ((float)(p.G - p.B) / diff) + 360) % 360);
                else if (max == p.G)
                    outp.H = (ushort)(60 * ((float)(p.B - p.R) / diff) + 120);
                else
                    outp.H = (ushort)(60 * ((float)(p.R - p.G) / diff) + 240);

                if (max == 0)
                    outp.S = 0;
                else
                    outp.S = (byte)(diff * 100 / max);
            }

            outp.V = (byte)(max * 100 / 255);

            return outp;
        }
        public static explicit operator ARGBPixel(HSVPixel pixel)
        {
            ARGBPixel newPixel;

            byte v = (byte)(pixel.V * 255 / 100);
            if (pixel.S == 0)
                newPixel = new ARGBPixel(255, v, v, v);
            else
            {
                int h = (pixel.H / 60) % 6;
                float f = (pixel.H / 60.0f) - (pixel.H / 60);

                byte p = (byte)(pixel.V * (100 - pixel.S) * 255 / 10000);
                byte q = (byte)(pixel.V * (100 - (int)(f * pixel.S)) * 255 / 10000);
                byte t = (byte)(pixel.V * (100 - (int)((1.0f - f) * pixel.S)) * 255 / 10000);

                switch (h)
                {
                    case 0: newPixel = new ARGBPixel(255, v, t, p); break;
                    case 1: newPixel = new ARGBPixel(255, q, v, p); break;
                    case 2: newPixel = new ARGBPixel(255, p, v, t); break;
                    case 3: newPixel = new ARGBPixel(255, p, q, v); break;
                    case 4: newPixel = new ARGBPixel(255, t, p, v); break;
                    default: newPixel = new ARGBPixel(255, v, p, q); break;
                }
            }
            return newPixel;
        }
        public static explicit operator Color(HSVPixel p)
        {
            ARGBPixel np = (ARGBPixel)p;
            return Color.FromArgb(*(int*)&np);
        }
        public static explicit operator HSVPixel(Color c)
        {
            return (HSVPixel)(ARGBPixel)c;
        }
    }

    //[Editor(typeof(UITypeEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(ExpandableObjectCustomConverter))]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RGBAPixel : IComparable//, ICustomTypeDescriptor
    {
        public const float ColorFactor = 1.0f / 255.0f;
        
        public byte R, G, B, A;

        public static explicit operator RGBAPixel(ARGBPixel p) { return new RGBAPixel() { A = p.A, B = p.B, G = p.G, R = p.R }; }
        public static explicit operator ARGBPixel(RGBAPixel p) { return new ARGBPixel() { A = p.A, B = p.B, G = p.G, R = p.R }; }

        public RGBAPixel(byte r, byte g, byte b, byte a) { R = r; G = g; B = b; A = a; }

        [Category("RGBA Pixel")]
        public byte Red { get { return R; } set { R = value; } }
        [Category("RGBA Pixel")]
        public byte Green { get { return G; } set { G = value; } }
        [Category("RGBA Pixel")]
        public byte Blue { get { return B; } set { B = value; } }
        [Category("RGBA Pixel")]
        public byte Alpha { get { return A; } set { A = value; } }
        [Category("RGBA Pixel"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel Value { get { return this; } set { this = value; } }

        public override string ToString()
        {
            //return String.Format("R:{0:X2} G:{1:X2} B:{2:X2} A:{3:X2}", R, G, B, A);
            return String.Format("R:{0} G:{1} B:{2} A:{3}", R, G, B, A);
        }

        public override int GetHashCode()
        {
            fixed (RGBAPixel* p = &this)
                return *(int*)p;
        }
        public override bool Equals(object obj)
        {
            if (obj is RGBAPixel)
                return this == (RGBAPixel)obj;
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is RGBAPixel)
            {
                RGBAPixel o = (RGBAPixel)obj;
                if (A > o.A)
                    return 1;
                else if (A < o.A)
                    return -1;
                else if (R > o.R)
                    return 1;
                else if (R < o.R)
                    return -1;
                else if (G > o.G)
                    return 1;
                else if (G < o.G)
                    return -1;
                else if (B > o.B)
                    return 1;
                else if (B < o.B)
                    return -1;
                return 0;
            }
            return 1;
        }

        public static bool operator ==(RGBAPixel p1, RGBAPixel p2) { return *(int*)&p1 == *(int*)&p2; }
        public static bool operator !=(RGBAPixel p1, RGBAPixel p2) { return *(int*)&p1 != *(int*)&p2; }
        public static int Compare(RGBAPixel p1, RGBAPixel p2)
        {
            int v1 = *(int*)&p1;
            int v2 = *(int*)&p2;

            if (v1 > v2)
                return 1;
            if (v1 < v2)
                return -1;
            return 1;
        }

        [Browsable(false)]
        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        //public String GetClassName()
        //{
        //    return TypeDescriptor.GetClassName(this, true);
        //}

        //public AttributeCollection GetAttributes()
        //{
        //    return TypeDescriptor.GetAttributes(this, true);
        //}

        //public String GetComponentName()
        //{
        //    return TypeDescriptor.GetComponentName(this, true);
        //}

        //public TypeConverter GetConverter()
        //{
        //    return TypeDescriptor.GetConverter(this, true);
        //}

        //public EventDescriptor GetDefaultEvent()
        //{
        //    return TypeDescriptor.GetDefaultEvent(this, true);
        //}

        //public PropertyDescriptor GetDefaultProperty()
        //{
        //    return TypeDescriptor.GetDefaultProperty(this, true);
        //}

        //public object GetEditor(Type editorBaseType)
        //{
        //    return TypeDescriptor.GetEditor(this, editorBaseType, true);
        //}

        //public EventDescriptorCollection GetEvents(Attribute[] attributes)
        //{
        //    return TypeDescriptor.GetEvents(this, attributes, true);
        //}

        //public EventDescriptorCollection GetEvents()
        //{
        //    return TypeDescriptor.GetEvents(this, true);
        //}

        //public object GetPropertyOwner(PropertyDescriptor pd)
        //{
        //    return this;
        //}

        //public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        //{
        //    return GetProperties();
        //}

        //public PropertyDescriptorCollection GetProperties()
        //{
        //    PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
        //    RGBAPixelPropertyDescriptor pd = new RGBAPixelPropertyDescriptor(this);
        //    pds.Add(pd);
        //    return pds;
        //}
    }

    public class RGBAPixelPropertyDescriptor : PropertyDescriptor
    {
        private RGBAPixel value;
        public RGBAPixelPropertyDescriptor(RGBAPixel coll)
            : base(coll.ToString(), null)
        {
            this.value = coll;
        }
        public UITypeEditor editor;
        public override object GetEditor(Type editorBaseType)
        {
            // make sure we're looking for a UITypeEditor.
            //
            if (editorBaseType == typeof(System.Drawing.Design.UITypeEditor))
            {
                // create and return one of our editors.
                //
                if (editor == null)
                {
                    //editor = new GoodColorControl() { Color = (Color)(ARGBPixel)value };
                }
                return editor;
            }
            return base.GetEditor(editorBaseType);
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.value.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                return ((RGBAPixel)this.value).ToString();
            }
        }

        public override string Description
        {
            get
            {
                return null;
            }
        }

        public override object GetValue(object component)
        {
            return this.value;
        }

        public override bool IsReadOnly
        {
            get { return true; }
        }

        public override string Name
        {
            get { return value.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.value.GetType(); }
        }

        public override void ResetValue(object component) { }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            this.value = (RGBAPixel)value;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ABGRPixel
    {
        public byte R, G, B, A;

        public ABGRPixel(byte a, byte b, byte g, byte r) { A = a; B = b; G = g; R = r; }

        public static explicit operator ABGRPixel(ARGBPixel p) { return new ABGRPixel() { A = p.A, B = p.B, G = p.G, R = p.R }; }
        public static explicit operator ARGBPixel(ABGRPixel p) { return new ARGBPixel() { A = p.A, B = p.B, G = p.G, R = p.R }; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RGBPixel
    {
        public byte B, G, R;

        public static explicit operator RGBPixel(ARGBPixel p) { return new RGBPixel() { R = p.R, G = p.G, B = p.B }; }
        public static explicit operator ARGBPixel(RGBPixel p) { return new ARGBPixel() { A = 0xFF, R = p.R, G = p.G, B = p.B }; }

        public static explicit operator Color(RGBPixel p) { return Color.FromArgb(p.R, p.G, p.B); }
        public static explicit operator RGBPixel(Color p) { return new RGBPixel() { R = p.R, G = p.G, B = p.B }; }

        public static RGBPixel FromIntensity(byte value) { return new RGBPixel() { R = value, G = value, B = value }; }

        public override string ToString()
        {
            return String.Format("R:{0:X2} G:{1:X2} B:{2:X2}", R, G, B);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RGB555Pixel
    {
        public ushort _data;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ARGB15Pixel
    {
        public ushort _data;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct ColorF4
    {
        private const float ColorFactor = 1.0f / 255.0f;

        public float A;
        public float R;
        public float G;
        public float B;

        public ColorF4(float a, float r, float g, float b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public float DistanceTo(ColorF4 p)
        {
            float a = A - p.A;
            float r = R - p.R;
            float g = G - p.G;
            float b = B - p.B;
            return (a * a) + (r * r) + (g * g) + (b * b);
        }

        public Color ToColor()
        {
            return Color.FromArgb((int)(A / ColorFactor + 0.5f), (int)(R / ColorFactor + 0.5f), (int)(G / ColorFactor + 0.5f), (int)(B / ColorFactor + 0.5f));
        }

        public static ColorF4 Factor(ColorF4 p1, ColorF4 p2, float factor)
        {
            float f1 = factor, f2 = 1.0f - factor;
            return new ColorF4((p1.A * f1) + (p2.A * f2), (p1.R * f1) + (p2.R * f2), (p1.G * f1) + (p2.G * f2), (p1.B * f1) + (p2.B * f2));
        }
        public void Factor(ColorF4 p, float factor)
        {
            float f1 = 1.0f - factor, f2 = factor;
            A = (A * f1) + (p.A * f2);
            R = (R * f1) + (p.R * f2);
            G = (G * f1) + (p.G * f2);
            B = (B * f1) + (p.B * f2);
        }

        public static explicit operator ColorF4(ARGBPixel p) { return new ColorF4(p.A * ColorFactor, p.R * ColorFactor, p.G * ColorFactor, p.B * ColorFactor); }
        public static explicit operator ColorF4(GXColorS10 p) { return new ColorF4(p.A * ColorFactor, p.R * ColorFactor, p.G * ColorFactor, p.B * ColorFactor); }

        public static bool operator ==(ColorF4 p1, ColorF4 p2) { return (p1.A == p2.A) && (p1.R == p2.R) && (p1.G == p2.G) && (p1.B == p2.B); }
        public static bool operator !=(ColorF4 p1, ColorF4 p2) { return (p1.A != p2.A) || (p1.R != p2.R) || (p1.G != p2.G) || (p1.B != p2.B); }
        public static ColorF4 operator *(ColorF4 c1, ColorF4 c2) { return new ColorF4((c1.A * c2.A), (c1.R * c2.R), (c1.G * c2.G), (c1.B * c2.B)); }
        public static ColorF4 operator *(ColorF4 c1, float f) { return new ColorF4((c1.A * f), (c1.R * f), (c1.G * f), (c1.B * f)); }
        public static ColorF4 operator *(float f, ColorF4 c1) { return new ColorF4((c1.A * f), (c1.R * f), (c1.G * f), (c1.B * f)); }
        public static ColorF4 operator +(ColorF4 c1, ColorF4 c2) { return new ColorF4((c1.A + c2.A), (c1.R + c2.R), (c1.G + c2.G), (c1.B + c2.B)); }
        public static ColorF4 operator +(float f, ColorF4 c2) { return new ColorF4((f + c2.A), (f + c2.R), (f + c2.G), (f + c2.B)); }
        public static ColorF4 operator +(ColorF4 c2, float f) { return new ColorF4((f + c2.A), (f + c2.R), (f + c2.G), (f + c2.B)); }
        public static ColorF4 operator -(ColorF4 c1, ColorF4 c2) { return new ColorF4((c1.A - c2.A), (c1.R - c2.R), (c1.G - c2.G), (c1.B - c2.B)); }
        public static ColorF4 operator -(float f, ColorF4 c2) { return new ColorF4((f - c2.A), (f - c2.R), (f - c2.G), (f - c2.B)); }
        public static ColorF4 operator -(ColorF4 c2, float f) { return new ColorF4((f - c2.A), (f - c2.R), (f - c2.G), (f - c2.B)); }
        public static ColorF4 operator /(ColorF4 c1, float f) { return new ColorF4((c1.A / f), (c1.R / f), (c1.G / f), (c1.B / f)); }
        public static ColorF4 operator /(ColorF4 c1, ColorF4 c2) { return new ColorF4((c1.A / c2.A), (c1.R / c2.R), (c1.G / c2.G), (c1.B / c2.B)); }
        public static ColorF4 operator /(float f, ColorF4 c1) { return new ColorF4((c1.A / f), (c1.R / f), (c1.G / f), (c1.B / f)); }

        public override bool Equals(object obj)
        {
            if (obj is ColorF4)
                return this == (ColorF4)obj;
            return base.Equals(obj);
        }
        public override int GetHashCode() { return base.GetHashCode(); }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct GXColorS10
    {
        public const float ColorFactor = 1.0f / 255.0f;

        public short R, G, B, A;

        public static explicit operator GXColorS10(ARGBPixel p) { return new GXColorS10() { A = p.A, B = p.B, G = p.G, R = p.R }; }
        public static explicit operator ARGBPixel(GXColorS10 p) { return new ARGBPixel() { A = (byte)(p.A & 0xFF), B = (byte)(p.B & 0xFF), G = (byte)(p.G & 0xFF), R = (byte)(p.R & 0xFF) }; }

        public GXColorS10(short a, short r, short g, short b) { A = a; R = r; G = g; B = b; }

        [Category("RGBA Pixel")]
        public short Red { get { return R; } set { R = value; } }
        [Category("RGBA Pixel")]
        public short Green { get { return G; } set { G = value; } }
        [Category("RGBA Pixel")]
        public short Blue { get { return B; } set { B = value; } }
        [Category("RGBA Pixel")]
        public short Alpha { get { return A; } set { A = value; } }

        public override string ToString()
        {
            //return String.Format("R:{0:X2} G:{1:X2} B:{2:X2} A:{3:X2}", R, G, B, A);
            return String.Format("R:{0} G:{1} B:{2} A:{3}", R, G, B, A);
        }

        public static bool operator ==(GXColorS10 p1, GXColorS10 p2) { return (p1.A == p2.A) && (p1.R == p2.R) && (p1.G == p2.G) && (p1.B == p2.B); }
        public static bool operator !=(GXColorS10 p1, GXColorS10 p2) { return (p1.A != p2.A) || (p1.R != p2.R) || (p1.G != p2.G) || (p1.B != p2.B); }

        public static GXColorS10 operator *(GXColorS10 c1, GXColorS10 c2) { return new GXColorS10((short)(c1.A * c2.A), (short)(c1.R * c2.R), (short)(c1.G * c2.G), (short)(c1.B * c2.B)); }
        public static GXColorS10 operator *(GXColorS10 c1, float f) { return new GXColorS10((short)(c1.A * f), (short)(c1.R * f), (short)(c1.G * f), (short)(c1.B * f)); }
        public static GXColorS10 operator +(GXColorS10 c1, GXColorS10 c2) { return new GXColorS10((short)(c1.A + c2.A), (short)(c1.R + c2.R), (short)(c1.G + c2.G), (short)(c1.B + c2.B)); }
        public static GXColorS10 operator -(GXColorS10 c1, GXColorS10 c2) { return new GXColorS10((short)(c1.A - c2.A), (short)(c1.R - c2.R), (short)(c1.G - c2.G), (short)(c1.B - c2.B)); }
        public static GXColorS10 operator -(float f, GXColorS10 c2) { return new GXColorS10((short)(f - c2.A), (short)(f - c2.R), (short)(f - c2.G), (short)(f - c2.B)); }
        public static GXColorS10 operator -(GXColorS10 c2, float f) { return new GXColorS10((short)(f - c2.A), (short)(f - c2.R), (short)(f - c2.G), (short)(f - c2.B)); }
        public static GXColorS10 operator +(float f, GXColorS10 c2) { return new GXColorS10((short)(f + c2.A), (short)(f + c2.R), (short)(f + c2.G), (short)(f + c2.B)); }
        public static GXColorS10 operator +(GXColorS10 c2, float f) { return new GXColorS10((short)(f + c2.A), (short)(f + c2.R), (short)(f + c2.G), (short)(f + c2.B)); }
        public static GXColorS10 operator /(GXColorS10 c1, float f) { return new GXColorS10((short)(c1.A / f), (short)(c1.R / f), (short)(c1.G / f), (short)(c1.B / f)); }

        public void Clamp(short min, short max)
        {
            A = A > max ? max : A < min ? min : A;
            R = R > max ? max : R < min ? min : R;
            G = G > max ? max : G < min ? min : G;
            B = B > max ? max : B < min ? min : B;
        }

        //Is used when "clamped" by tev stage
        public void CutoffTo8bit()
        {
            A = (short)(A & 0xFF);
            R = (short)(R & 0xFF);
            G = (short)(G & 0xFF);
            B = (short)(B & 0xFF);
        }

        public override bool Equals(object obj)
        {
            if (obj is GXColorS10)
                return this == (GXColorS10)obj;
            return false;
        }
    }
}
