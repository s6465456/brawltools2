﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using Ikarus;
using System.Collections;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RawData : ExternalEntry
    {
        internal byte[] _data;

        public override void Parse(VoidPtr address)
        {
            DataOffsets.Add(_offset);

            if (_size > 0)
            {
                _data = new byte[_size];
                byte* b = (byte*)address;
                for (int i = 0; i < _data.Length; i++)
                    _data[i] = b[i];
            }
            else
                _data = new byte[0];
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return _entryLength = _data.Length;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;
            byte* header = (byte*)address;
            if (_data != null)
                for (int i = 0; i < _data.Length; i++)
                    header[i] = _data[i];
        }
    }

    public unsafe class BoneIndexValue : MovesetEntry
    {
        [Browsable(false)]
        public MDL0BoneNode BoneNode
        {
            get 
            {
                if (//ParentArticle == null && 
                    Model == null) 
                    return null;

                MDL0Node model;
                //if (ParentArticle != null && ParentArticle._info != null)
                //    model = ParentArticle._info._model;
                //else
                    model = Model;

                if (boneIndex >= model._linker.BoneCache.Length || boneIndex < 0) 
                    return null;

                return (MDL0BoneNode)model._linker.BoneCache[boneIndex];
            }
            set
            {
                boneIndex = value.BoneIndex; 
                _name = value.Name;
            }
        }

        [Category("Bone Index"), TypeConverter(typeof(DropDownListBonesMDef))]
        public string Bone { get { return BoneNode == null ? boneIndex.ToString() : BoneNode.Name; } set { if (Model == null) { boneIndex = Convert.ToInt32(value); _name = boneIndex.ToString(); } else { BoneNode = String.IsNullOrEmpty(value) ? BoneNode : Model.FindBone(value); } SignalPropertyChange(); } }
        internal int boneIndex = 0;

        public override string Name { get { return Bone; } }

        public override void Parse(VoidPtr address)
        {
            boneIndex = *(bint*)address;
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 4;
        }

        protected override void OnWrite(VoidPtr address)
        {
            *(bint*)(_rebuildAddr = address) = boneIndex;
        }
    }

    public unsafe class IndexValue : MovesetEntry
    {
        public int val = 0;

        [Category("Index Entry")]
        public int ItemIndex { get { return val; } set { val = value; SignalPropertyChange(); } }

        public override void Parse(VoidPtr address)
        {
            val = *(bint*)address;
        }

        protected override int OnGetSize()
        {
            _lookupCount = 0;
            return 4;
        }

        protected override void OnWrite(VoidPtr address)
        {
            *(bint*)(_rebuildAddr = address) = val;
        }
    }

    public unsafe class ListOffset : MovesetEntry
    {
        sListOffset hdr;

        [Category("List Offset")]
        public int DataOffset { get { return hdr._startOffset; } }
        [Category("List Offset")]
        public int Count { get { return hdr._listCount; } }

        public override void Parse(VoidPtr address)
        {
            hdr = *(sListOffset*)address;
        }
    }

    public class EntryList<T> : MovesetEntry, IEnumerable<T>, IListSource where T : MovesetEntry 
    {
        #region Child Enumeration

        public IEnumerator<T> GetEnumerator() { return _entries.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        public bool ContainsListCollection
        {
            get { return false; }
        }

        public IList GetList()
        {
            return _entries;
        }

        public int Count { get { return _entries.Count; } }
        public T this[int i]
        {
            get
            {
                if (i >= 0 && i < Count)
                    return _entries[i];
                return null;
            }
            set
            {
                if (i >= 0 && i < Count)
                {
                    SignalPropertyChange();
                    _entries[i] = value;
                }
            }
        }
        private void Insert(int i, T e)
        {
            if (i >= 0)
            {
                if (i < Count)
                    _entries.Insert(i, e);
                else
                    _entries.Add(e);
                SignalRebuildChange();
            }
        }
        private void Add(int i, T e)
        {
            _entries.Add(e);
            SignalRebuildChange();
        }
        internal void RemoveAt(int i)
        {
            if (i >= 0 && i < Count)
            {
                _entries.RemoveAt(i);
                SignalRebuildChange();
            }
        }
        private void Clear()
        {
            if (Count != 0)
            {
                _entries.Clear();
                SignalRebuildChange();
            }
        }

        #endregion

        private int _stride, _count = -1;
        private BindingList<T> _entries;

        //public BindingList<T> Entries { get { return _entries; } set { if (value.Count != _entries.Count) SignalRebuildChange(); _entries = value; } }

        public EntryList(int stride, int count) { _stride = stride; _count = count; }
        public EntryList(int stride) { _stride = stride; }
        public override void Parse(VoidPtr address)
        {
            //if (_count >= 0 && _count != _size / _stride)
            //    Console.WriteLine("wat");

            _entries = new BindingList<T>();
            if (_count > 0 || _size > 0)
                for (int i = 0; i < (_count > 0 ? _count : _size / _stride); i++)
                {
                    T e = Parse<T>(address[i, _stride]);
                    e._index = i;
                    _entries.Add(e);
                }
        }

        protected override int OnGetSize()
        {
            return _entries.Count * _stride;
        }

        protected override void OnWrite(VoidPtr address)
        {
            _rebuildAddr = address;
            for (int i = 0; i < _entries.Count; i++)
                _entries[i].Write(address[i, _stride]);
        }
    }

    public unsafe class EntryListOffset<T> : ListOffset where T : MovesetEntry
    {
        private int _stride;
        public List<T> _entries;

        public EntryListOffset(int stride) { _stride = stride; }
        public override void Parse(VoidPtr address)
        {
            base.Parse(address);
            _entries = new List<T>();
            if (Count > 0)
                for (int i = 0; i < Count; i++)
                    _entries.Add(Parse<T>(DataOffset + i * _stride));
        }

        protected override int OnGetSize()
        {
            _lookupCount = _entries.Count > 0 ? 1 : 0;
            return 8 + _entries.Count * _stride;
        }

        protected override void OnWrite(VoidPtr address)
        {
            for (int i = 0; i < _entries.Count; i++)
                _entries[i].Write(address[i, _stride]);

            sListOffset* o = (sListOffset*)(_rebuildAddr = address + _entries.Count * _stride);
            if (_entries.Count > 0)
            {
                o->_startOffset = Offset(address);
                o->_listCount = _entries.Count;
                _lookupOffsets.Add(&o->_startOffset);
            }
            else
            {
                o->_startOffset = 0;
                o->_listCount = 0;
            }
        }
    }
}
