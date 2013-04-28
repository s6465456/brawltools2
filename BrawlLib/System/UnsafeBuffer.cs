﻿using System;
using System.Runtime.InteropServices;

namespace System
{
    public class UnsafeBuffer : IDisposable
    {
        private VoidPtr _data;
        public VoidPtr Address { get { return _data; } }

        private int _length;
        public int Length { get { return _length; } }

        public UnsafeBuffer(int size) { _data = Marshal.AllocHGlobal(size); _length = size; }
        ~UnsafeBuffer() { Dispose(); }

        public VoidPtr this[int count, int stride] { get { return _data[count, stride]; } }

        public void Dispose()
        {
            if (_data)
            {
                Marshal.FreeHGlobal(_data);
                _data = null;
                GC.SuppressFinalize(this);
            }
        }
    }
}
