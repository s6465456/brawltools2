using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using System.Runtime.InteropServices;
using BrawlLib.OpenGL;
using System.Windows.Forms;
using System.Drawing;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class SubActionGroup : MoveDefEntry
    {
        [Category("Sub Action")]
        public AnimationFlags Flags { get { return _flags; } set { _flags = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public byte InTranslationTime { get { return _inTransTime; } set { _inTransTime = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public int ID { get { return _index; } }

        public AnimationFlags _flags;
        public byte _inTransTime;
        public string _animationName;
        public int _index;

        public ActionScript _main;
        public ActionScript _sfx;
        public ActionScript _gfx;
        public ActionScript _other;

        public ActionScript GetWithType(int type)
        {
            switch (type)
            {
                case 0: return _main;
                case 1: return _sfx;
                case 2: return _gfx;
                case 3: return _other;
            }
            return null;
        }

        public override string ToString() { return _animationName; }
    }
    public class ActionGroup : MoveDefEntry
    {
        [Category("Action")]
        public int ID { get { return _index; } }
        public int _index;

        public ActionScript _entry;
        public ActionScript _exit;

        public ActionScript GetWithType(int type)
        {
            switch (type)
            {
                case 0: return _entry;
                case 1: return _exit;
            }
            return null;
        }

        public override string ToString() { return String.Format("Action", ID); }
    }
    public unsafe partial class ActionScript : ReferenceEntry
    {
        public override string ToString() { if (_name.StartsWith("SubRoutine")) return _name; else return base.ToString(); }

        public List<Event> _events;

        MoveDefNode.ListValue _list;
        MoveDefNode.TypeValue _list;
        int _index;

        public bool _isBlank = false;
        public bool _build = false;
        [Category("Script")]
        public bool ForceWrite { get { return _build; } set { _build = value; } }
        
        public List<ResourceNode> _actionRefs = new List<ResourceNode>();
        public ResourceNode[] ActionRefs { get { return _actionRefs.ToArray(); } }

        MoveDefArticleNode _parentArticle = null;
        public ActionScript(string name, MoveDefArticleNode article) 
        {
            _name = name;
            _isBlank = true;
            _build = false;
            _parentArticle = article;
        }

        public override void Parse(VoidPtr address)
        {
            _build = true;
            FDefEvent* ev = (FDefEvent*)address;
            if (ev->_nameSpace != 0 || ev->_id != 0)
            {

            }
        }

        public override void OnPopulate()
        {
            FDefEvent* ev = Header;
            if (!_isBlank)
            while (ev->_nameSpace != 0 || ev->_id != 0)
                new Event().Initialize(this, new DataSource(((VoidPtr)ev++), 8));

            _size = _events.Count * 8 + 8;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            int size = 8; //Terminator event size
            foreach (Event e in _events)
            {
                if (e.EventID == 0xFADEF00D || e.EventID == 0xFADE0D8A) continue;
                size += e.CalculateSize(true);
                _lookupCount += e._lookupCount;
            }
            return size;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            int off = 0;
            foreach (Event e in Children)
                off += e.Children.Count * 8;

            FDefEventArgument* paramAddr = (FDefEventArgument*)address;
            FDefEvent* eventAddr = (FDefEvent*)(address + off);

            _rebuildAddr = eventAddr;

            foreach (Event e in _events)
            {
                if (e._name == "FADEF00D" || e._name == "FADE0D8A") continue;
                e._rebuildAddr = eventAddr;
                *eventAddr = new FDefEvent() { _id = e.id, _nameSpace = e.nameSpace, _numArguments = (byte)e.Children.Count, _unk1 = e.unk1 };
                if (e._paremeters.Count > 0)
                {
                    eventAddr->_argumentOffset = (uint)paramAddr - (uint)RebuildBase;
                    _lookupOffsets.Add(eventAddr->_argumentOffset.Address);
                }
                else
                    eventAddr->_argumentOffset = 0;
                eventAddr++;
                foreach (MoveDefEventParameterNode p in e.Children)
                {
                    p._rebuildAddr = paramAddr;
                    if (p._type != ArgVarType.Offset)
                        *paramAddr = new FDefEventArgument() { _type = (int)p._type, _data = p._value };
                    else
                    {
                        MoveDefNode.Builder._postProcessNodes.Add(p);
                        //if ((p as MoveDefEventOffsetNode).action != null)
                        //    _lookupOffsets.Add(0);
                    }
                    paramAddr++;
                }
            }

            eventAddr++; //Terminate
        }
    }
}
