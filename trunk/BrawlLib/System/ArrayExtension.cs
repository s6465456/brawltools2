using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static unsafe class ArrayExtension
    {
        public static int[] FindAllOccurences(this Array a, object o)
        {
            List<int> l = new List<int>();
            int i = 0;
            foreach (object x in a)
            {
                if (x == o)
                    l.Add(i);
                i++;
            }
            return l.ToArray();
        }
    }
}
