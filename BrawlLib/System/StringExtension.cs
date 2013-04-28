﻿using System;
using System.Collections.Generic;

namespace System
{
    public static class StringExtension
    {
        public static unsafe string TruncateAndFill(this string s, int length, char fillChar)
        {
            char* buffer = stackalloc char[length];

            int i;
            int min = Math.Min(s.Length, length);
            for (i = 0; i < min; i++)
                buffer[i] = s[i];

            while (i < length)
                buffer[i++] = fillChar;

            return new string(buffer, 0, length);
        }
        public static unsafe int IndexOfOccurance(this string s, char c, int index)
        {
            int len = s.Length;
            fixed(char* cPtr = s)
            {
                for (int i = 0, count = 0; i < len; i++)
                    if ((cPtr[i] == c) && (count++ == index))
                        return i;
            }
            return -1;
        }
        public unsafe static void Write(this string s, sbyte* ptr)
        {
            for (int i = 0; i < s.Length; i++)
                ptr[i] = (sbyte)s[i];
        }
        public unsafe static void Write(this string s, ref sbyte* ptr)
        {
            for (int i = 0; i < s.Length; i++)
                *ptr++ = (sbyte)s[i];
            ptr++; //Null terminator
        }
        public static string ToBinaryArray(this string s)
        {
            //string value = "";
            //for (int i = 0; i < s.Length; i++)
            //{
            //    byte c = (byte)s[i];
            //    for (int x = 0; x < 8; x++)
            //        value += ((c >> (7 - x)) & 1);
            //}
            //return value;
            string result = string.Empty;
            foreach (char ch in s)
                result += Convert.ToString((int)ch, 2);
            return result.PadLeft(result.Length.Align(8), '0');
        }
        public static int CompareBits(this String t1, String t2)
        {
            int bit = 0;
            bool found = false;
            int min = Math.Min(t1.Length, t2.Length);
            for (int i = 0; i < min; i++)
            {
                byte c1 = (byte)t1[i];
                byte c2 = (byte)t2[i];

                for (int x = 0; x < 8; x++)
                    if (c1 >> (7 - x) != c2 >> (7 - x))
                    {
                        bit = i * 8 + x; 
                        found = true;
                        break;
                    }
                if (bit != 0)
                    break;
            }
            if (!found)
                bit = min * 8 + 1;
            return bit;
        }
        public static bool AtBit(this String s, int bitIndex)
        {
            int bit = bitIndex % 8;
            int byteIndex = (bitIndex - bit) / 8;
            return ((s[byteIndex] >> (7 - bit)) & 1) != 0;
        }
    }
}
