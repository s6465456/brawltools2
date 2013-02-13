﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class UserDataCollectionPropertyDescriptor : PropertyDescriptor
    {
        private UserDataCollection collection = null;
        private int index = -1;
        
        public UserDataCollectionPropertyDescriptor(UserDataCollection coll, int idx) : base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        } 

        public override AttributeCollection Attributes { get { return new AttributeCollection(null); } }
        public override bool CanResetValue(object component) { return true; }
        public override Type ComponentType { get { return this.collection.GetType(); } }
        public override string DisplayName { get { return index >= collection.Count || index < 0 ? null : ((UserDataClass)this.collection[index]).ToString(); } }
        public override string Description { get { return null; } }
        public override object GetValue(object component) { return this.collection[index]; }
        public override bool IsReadOnly { get { return true; } }
        public override string Name { get { return "#" + index.ToString(); } }
        public override Type PropertyType { get { return this.collection[index].GetType(); } }
        public override void ResetValue(object component) { }
        public override bool ShouldSerializeValue(object component) { return true; }
        public override void SetValue(object component, object value) { this.collection[index] = (UserDataClass)value; }
    }

    public unsafe class UserDataCollection : CollectionBase, ICustomTypeDescriptor
    {
        public void Read(VoidPtr userDataAddr)
        {
            if (userDataAddr == null) return;

            UserData* data = (UserData*)userDataAddr;
            ResourceGroup* group = data->Group;
            ResourceEntry* pEntry = &group->_first + 1;
            int count = group->_numEntries;
            for (int i = 0; i < count; i++)
            {
                UserDataEntry* entry = (UserDataEntry*)((VoidPtr)group + pEntry->_dataOffset);
                UserDataClass d = new UserDataClass() { _name = new String((sbyte*)group + pEntry->_stringOffset) };
                VoidPtr addr = (VoidPtr)entry + entry->_dataOffset;
                d._type = entry->Type;
                for (int x = 0; x < entry->_entryCount; x++)
                    switch (entry->Type)
                    {
                        case UserValueType.Float:
                            d._entries.Add(((float)*(bfloat*)addr).ToString());
                            addr += 4;
                            break;
                        case UserValueType.Int:
                            d._entries.Add(((int)*(bint*)addr).ToString());
                            addr += 4;
                            break;
                        case UserValueType.String:
                            string s = new String((sbyte*)(addr + 2));
                            d._entries.Add(s);
                            addr += s.Length + 3;
                            break;
                    }
                Add(d);
            }
        }

        public int GetSize()
        {
            if (Count == 0) return 0;

            int len = 0x1C + (Count * 0x28);
            foreach (UserDataClass c in this)
                foreach (string s in c._entries)
                    if (c.DataType == UserValueType.Float || c.DataType == UserValueType.Int)
                        len += 4;
                    else if (c.DataType == UserValueType.String)
                        len += s.Length + 3;

            return len;
        }

        public void Write(VoidPtr userDataAddr)
        {
            if (Count == 0 || userDataAddr == null) return;

            UserData* data = (UserData*)userDataAddr;
            
            ResourceGroup* pGroup = data->Group;
            ResourceEntry* pEntry = &pGroup->_first + 1;
            *pGroup = new ResourceGroup(Count);

            byte* pData = (byte*)pGroup + pGroup->_totalSize;

            int id = 0;
            foreach (UserDataClass s in this)
            {
                (pEntry++)->_dataOffset = (int)pData - (int)pGroup;
                UserDataEntry* p = (UserDataEntry*)pData;
                *p = new UserDataEntry(s._entries.Count, s._type, id++);
                pData += 0x18;
                for (int i = 0; i < s._entries.Count; i++)
                    if (s.DataType == UserValueType.Float)
                    {
                        float x;
                        if (!float.TryParse(s._entries[i], out x))
                            x = 0;
                        *(bfloat*)pData = x;
                        pData += 4;
                    }
                    else if (s.DataType == UserValueType.Int)
                    {
                        int x;
                        if (!int.TryParse(s._entries[i], out x))
                            x = 0;
                        *(bint*)pData = x;
                        pData += 4;
                    }
                    else if (s.DataType == UserValueType.String)
                    {
                        if (s._entries[i] == null)
                            s._entries[i] = "";

                        int len = s._entries[i].Length;
                        int ceil = len + 3;

                        sbyte* ptr = (sbyte*)pData + 2;

                        for (int x = 0; x < len; )
                            ptr[x] = (sbyte)s._entries[i][x++];

                        for (int x = len; x < ceil; )
                            ptr[x++] = 0;

                        *(bushort*)pData = (ushort)(len + 1);
                        pData += s._entries[i].Length + 3;
                    }
                p->_totalLen = (int)pData - (int)p;
            }
            data->_totalLen = (int)pData - (int)userDataAddr;
        }

        public void PostProcess(VoidPtr userDataAddr, StringTable stringTable)
        {
            if (Count == 0 || userDataAddr == null) return;

            UserData* data = (UserData*)userDataAddr;

            ResourceGroup* pGroup = data->Group;
            ResourceEntry* pEntry = &pGroup->_first;
            int count = pGroup->_numEntries;
            (*pEntry++) = new ResourceEntry(0xFFFF, 0, 0, 0, 0);

            for (int i = 0; i < count; i++)
            {
                UserDataEntry* entry = (UserDataEntry*)((byte*)pGroup + (pEntry++)->_dataOffset);
                ResourceEntry.Build(pGroup, i + 1, entry, (BRESString*)stringTable[this[i]._name]);
                entry->ResourceStringAddress = stringTable[this[i]._name] + 4;
            }
        }

        public void Add(UserDataClass u) { this.List.Add(u); }
        public void Remove(UserDataClass u) { this.List.Remove(u); } 
        public UserDataClass this[int index] 
        {
            get { return index >= List.Count || index < 0 ? null : (UserDataClass)this.List[index]; }
            set { this.List[index] = value; }
        }

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
            for (int i = 0; i < this.List.Count; i++)
            {
                UserDataCollectionPropertyDescriptor pd = new UserDataCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }
    }

    [TypeConverter(typeof(UserDataConverter))]
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
                s += i + ",";
            return s.Substring(0, s.Length - 1);
        }

        public UserValueType _type;
        public List<string> _entries = new List<string>();
    }

    public enum UserValueType
    {
        Int = 0,
        Float,
        String
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UserData
    {
        public bint _totalLen; //Of everything user data related

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public ResourceGroup* Group { get { return (ResourceGroup*)(Address + 4); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UserDataEntry
    {
        public const int Size = 0x18;

        public bint _totalLen;
        public bint _dataOffset;
        public bint _entryCount;
        public bint _type;
        public bint _stringOffset; //same as entry
        public bint _id;

        //Entries, in the specified type

        public UserValueType Type { get { return (UserValueType)(int)_type; } set { _type = (int)value; } }

        public UserDataEntry(int entries, UserValueType type, int id)
        {
            _totalLen = 0;
            _dataOffset = type == UserValueType.String ? 0 : 0x18;
            _entryCount = entries;
            _type = (int)type;
            _stringOffset = 0;
            _id = id;
        }

        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }

        public string ResourceString { get { return new String((sbyte*)ResourceStringAddress); } }
        public VoidPtr ResourceStringAddress
        {
            get { return (VoidPtr)Address + _stringOffset; }
            set { _stringOffset = (int)value - (int)Address; }
        }
    }
}
