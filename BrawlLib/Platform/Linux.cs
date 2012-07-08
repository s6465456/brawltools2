﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System
{
    static unsafe class Linux
    {
        [DllImport("libm.so")]
        public static extern void memset(void* dest, byte value, uint length);
        [DllImport("libm.so")]
        public static extern void memmove(void* dst, void* src, uint length);

        [DllImport("libm.so")]
        public static extern void* mmap(void* addr, uint len, MMapProtect prot, MMapFlags flags, int fildes, uint off);
        [DllImport("libm.so")]
        public static extern int munmap(void* addr, uint len);


        [Flags]
        public enum MMapProtect : int
        {
            None = 0x00,
            Read = 0x01,
            Write = 0x02,
            Execute = 0x04
        }

        [Flags]
        public enum MMapFlags : int
        {
            Shared = 0x01,
            Private = 0x02,
            Fixed = 0x10
        }
    }
}
