﻿using System;

namespace System.Reflection
{
    public static class MemberInfoExtension
    {
        public static T GetAttribute<T>(this MemberInfo info)
        {
            foreach (T obj in info.GetCustomAttributes(typeof(T), true))
                return obj;
            return default(T);
        }
    }
}
