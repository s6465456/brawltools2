using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace System
{
    public static unsafe class ListExtension
    {
        public static int[] FindAllOccurences(this IList a, object o)
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
        //public static List<BrawlLib.Wii.Audio.RSARConverter.TEntry> ShiftFirst(this IList list, int index)
        //{
        //    List<BrawlLib.Wii.Audio.RSARConverter.TEntry> newList = new List<BrawlLib.Wii.Audio.RSARConverter.TEntry>();
        //    for (int i = index; i < list.Count + index; i++)
        //    {
        //        int x = i;
        //        if (i >= list.Count)
        //            x = i - list.Count;
        //        newList.Add((BrawlLib.Wii.Audio.RSARConverter.TEntry)list[x]);
        //    }
        //    return newList;
        //}
    }
}
