﻿using System;
using System.ComponentModel;
using System.Globalization;
using BrawlLib.Imaging;
using System.Windows.Forms;
using System.Drawing;
using BrawlLib.SSBBTypes;

namespace System
{
    public class Vector4StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Vector4); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Vector4 v = new Vector4();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 4)
            {
                float.TryParse(arr[0], out v._x);
                float.TryParse(arr[1], out v._y);
                float.TryParse(arr[2], out v._z);
                float.TryParse(arr[3], out v._w);
            }

            return v;
        }
    }

    public class Vector3StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Vector3); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)        {            return value.ToString();        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Vector3 v = new Vector3();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 3)
            {
                float.TryParse(arr[0], out v._x);
                float.TryParse(arr[1], out v._y);
                float.TryParse(arr[2], out v._z);
            }

            return v;
        }
    }

    public class Vector2StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Vector2); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Vector2 v = new Vector2();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 2)
            {
                float.TryParse(arr[0], out v._x);
                float.TryParse(arr[1], out v._y);
            }

            return v;
        }
    }

    public class RGBAStringConverter : TypeConverter
    {
        GoodColorDialog d = new GoodColorDialog();

        private static char[] delims = new char[] { ',', 'R', 'G', 'B', 'A', ':', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(RGBAPixel); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            RGBAPixel p = new RGBAPixel();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            
            if (arr.Length == 4)
            {
                byte.TryParse(arr[0], out p.R);
                byte.TryParse(arr[1], out p.G);
                byte.TryParse(arr[2], out p.B);
                byte.TryParse(arr[3], out p.A);
            }

            d.Color = (Color)(ARGBPixel)p;
            if (!d.Visible && d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                p = new RGBAPixel() { R = d.Color.R, G = d.Color.G, B = d.Color.B, A = d.Color.A };

            return p;
        }
    }

    public class GXColorS10StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', 'R', 'G', 'B', 'A', ':', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(GXColorS10); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            GXColorS10 p = new GXColorS10();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 4)
            {
                short.TryParse(arr[0], out p.R);
                short.TryParse(arr[1], out p.G);
                short.TryParse(arr[2], out p.B);
                short.TryParse(arr[3], out p.A);
            }

            return p;
        }
    }

    public unsafe class Matrix43StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Matrix43); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Matrix43 m = new Matrix43();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 12)
            {
                float.TryParse(arr[0], out m._data[0]);
                float.TryParse(arr[1], out m._data[1]);
                float.TryParse(arr[2], out m._data[2]);
                float.TryParse(arr[3], out m._data[3]);
                float.TryParse(arr[4], out m._data[4]);
                float.TryParse(arr[5], out m._data[5]);
                float.TryParse(arr[6], out m._data[6]);
                float.TryParse(arr[7], out m._data[7]);
                float.TryParse(arr[8], out m._data[8]);
                float.TryParse(arr[9], out m._data[9]);
                float.TryParse(arr[10], out m._data[10]);
                float.TryParse(arr[11], out m._data[11]);
            }
            return m;
        }
    }

    public unsafe class MatrixStringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Matrix); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Matrix m = new Matrix();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 16)
            {
                float.TryParse(arr[0], out m.Data[0]);
                float.TryParse(arr[1], out m.Data[1]);
                float.TryParse(arr[2], out m.Data[2]);
                float.TryParse(arr[3], out m.Data[3]);
                float.TryParse(arr[4], out m.Data[4]);
                float.TryParse(arr[5], out m.Data[5]);
                float.TryParse(arr[6], out m.Data[6]);
                float.TryParse(arr[7], out m.Data[7]);
                float.TryParse(arr[8], out m.Data[8]);
                float.TryParse(arr[9], out m.Data[9]);
                float.TryParse(arr[10], out m.Data[10]);
                float.TryParse(arr[11], out m.Data[11]);
                float.TryParse(arr[12], out m.Data[12]);
                float.TryParse(arr[13], out m.Data[13]);
                float.TryParse(arr[14], out m.Data[14]);
                float.TryParse(arr[15], out m.Data[15]);
            }
            return m;
        }
    }

    public class QuaternionStringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Vector4); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Vector4 q = new Vector4();

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length == 4)
            {
                float.TryParse(arr[0], out q._x);
                float.TryParse(arr[1], out q._y);
                float.TryParse(arr[2], out q._z);
                float.TryParse(arr[3], out q._w);
            }

            return q;
        }
    }

    public class Bin16StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Bin16); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            ushort b = 0;
            
            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            for (int len = 0; len < arr.Length; len++)
            {
                byte bit = 0;
                for (int i = 0; i < arr[len].Length; i++)
                {
                    b <<= 1;
                    byte.TryParse(arr[len][i].ToString(), out bit);
                    bit = (byte)(bit > 1 ? 1 : bit < 0 ? 0 : bit);
                    b += bit;
                }
            }

            return new Bin16(b);
        }
    }

    public class Bin32StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Bin32); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            uint b = 0;

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            for (int len = 0; len < arr.Length; len++)
            {
                byte bit = 0;
                for (int i = 0; i < arr[len].Length; i++)
                {
                    b <<= 1;
                    byte.TryParse(arr[len][i].ToString(), out bit);
                    bit = (byte)(bit > 1 ? 1 : bit < 0 ? 0 : bit);
                    b += bit;
                }
            }

            return new Bin32(b);
        }
    }

    public class Bin8StringConverter : TypeConverter
    {
        private static char[] delims = new char[] { ',', '(', ')', ' ' };

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) { return destinationType == typeof(Bin8); }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) { return value.ToString(); }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) { return sourceType == typeof(string); }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            byte b = 0;

            string s = value.ToString();
            string[] arr = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);

            for (int len = 0; len < arr.Length; len++)
            {
                byte bit = 0;
                for (int i = 0; i < arr[len].Length; i++)
                {
                    b <<= 1;
                    byte.TryParse(arr[len][i].ToString(), out bit);
                    bit = (byte)(bit > 1 ? 1 : bit < 0 ? 0 : bit);
                    b += bit;
                }
            }

            return new Bin8(b);
        }
    }
}
