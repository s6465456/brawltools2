using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class UserDataClass
    {
        public string _name = "";

        [Category("User Data")]
        public string Name { get { return _name; } set { _name = value; } }

        [Category("User Data")]
        public string[] Entries 
        {
            get { return _entries.ToArray(); }
            set
            {
                _entries = value.ToList<string>();
                if (DataType != UserValueType.String)
                    for (int i = 0; i < _entries.Count; i++)
                        if (DataType == UserValueType.Float)
                        {
                            float x;
                            if (!float.TryParse(_entries[i], out x))
                                _entries[i] = "0"; 
                        }
                        else if (DataType == UserValueType.Int)
                        {
                            int x;
                            if (!int.TryParse(_entries[i], out x))
                                _entries[i] = "0";
                        }
            }
        }
        [Category("User Data")]
        public UserValueType DataType { get { return _type; } set { _type = value; } }

        public override string ToString()
        {
            string s = _name + ":";
            foreach (string i in Entries)
                s += " " + i;
            return s;
        }

        public UserValueType _type;
        public List<string> _entries = new List<string>();

        //public void Parse(VoidPtr address)
        //{

        //}

        //public int GetSize()
        //{
        //    int i = 0;
        //}
    }
}
