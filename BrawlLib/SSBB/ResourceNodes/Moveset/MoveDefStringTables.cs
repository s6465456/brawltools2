﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using BrawlLib.IO;
using BrawlLib.Wii.Animations;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.OpenGL;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class FDefSubActionStringTable
    {
        SortedList<string, VoidPtr> _table = new SortedList<string, VoidPtr>();

        List<string> _order = new List<string>();

        public void Add(string s)
        {
            if ((!String.IsNullOrEmpty(s)) && (!_table.ContainsKey(s)))
            {
                _table.Add(s, 0);
                _order.Add(s);
            }
        }

        public int TotalSize
        {
            get
            {
                int len = 0;
                foreach (string s in _table.Keys)
                    len += (s.Length + 1).Align(4);
                return len;
            }
        }

        public void Clear() { _table.Clear(); _order.Clear(); }

        public VoidPtr this[string s] { get { return _table[s]; } }

        public void WriteTable(VoidPtr address)
        {
            FDefSubActionString* entry = (FDefSubActionString*)address;
            for (int i = 0; i < _table.Count; i++)
            {
                string s = _order[i];
                _table[s] = entry;
                entry->Value = s;
                entry = entry->Next;
            }
        }
    }

    public unsafe class CompactStringTable
    {
        public SortedList<string, VoidPtr> _table = new SortedList<string, VoidPtr>(StringComparer.Ordinal);

        public void Add(string s)
        {
            if ((!String.IsNullOrEmpty(s)) && (!_table.ContainsKey(s)))
                _table.Add(s, 0);
        }

        public int TotalSize
        {
            get
            {
                int len = 0;
                foreach (string s in _table.Keys)
                    len += (s.Length + 1);
                return len;
            }
        }

        public void Clear() { _table.Clear(); }

        public VoidPtr this[string s] { get { return _table[s]; } }

        public void WriteTable(VoidPtr address)
        {
            FDefReferenceString* entry = (FDefReferenceString*)address;
            for (int i = 0; i < _table.Count; i++)
            {
                string s = _table.Keys[i];
                _table[s] = entry;
                entry->Value = s;
                entry = entry->Next;
            }
        }
    }
}