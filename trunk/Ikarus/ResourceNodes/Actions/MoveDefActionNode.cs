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
    public class MoveDefSubActionGroupNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefSubActionGroup; } }
        public override bool AllowDuplicateNames { get { return true; } }
        public override string ToString() { return Name; }

        public AnimationFlags _flags;
        public byte _inTransTime;

        [Category("Sub Action")]
        public AnimationFlags Flags { get { return _flags; } set { _flags = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public byte InTranslationTime { get { return _inTransTime; } set { _inTransTime = value; SignalPropertyChange(); } }
        [Category("Sub Action")]
        public int ID { get { return Index; } }
    }
    public class MoveDefActionGroupNode : MoveDefEntryNode
    {
        public override ResourceType ResourceType { get { return ResourceType.MDefActionGroup; } }
        public override string ToString() { return Name; }

        [Category("Action")]
        public int ID { get { return Index; } }
    }
    public unsafe partial class MoveDefActionNode : MoveDefExternalNode
    {
        internal FDefEvent* Header { get { return (FDefEvent*)WorkingUncompressed.Address; } }
        public override string ToString() { if (Name.StartsWith("SubRoutine")) return Name; else return base.ToString(); }

        public bool _isBlank = false;
        public bool _build = false;
        [Category("Script")]
        public bool ForceWrite { get { return _build; } set { _build = value; } }
        
        public List<ResourceNode> _actionRefs = new List<ResourceNode>();
        public ResourceNode[] ActionRefs { get { return _actionRefs.ToArray(); } }

        public MoveDefActionNode(string name, bool blank, ResourceNode parent) 
        {
            _name = name;
            _isBlank = blank;
            _build = false;
            if (parent != null && (parent as MoveDefEntryNode).ParentArticle != null)
                _attachedArticleIndex = (parent as MoveDefEntryNode).ParentArticle.Index;
            if (_isBlank) //Initialize will not be called, because there is no data to read
            {
                _parent = parent;

                if (_name == null)
                {
                    if (Parent.Parent.Name == "Action Scripts")
                    {
                        if (Index == 0)
                            _name = "Entry";
                        else if (Index == 1)
                            _name = "Exit";
                    }
                    else if (Parent.Parent.Name == "SubAction Scripts")
                    {
                        if (Index == 0)
                            _name = "Main";
                        else if (Index == 1)
                            _name = "GFX";
                        else if (Index == 2)
                            _name = "SFX";
                        else if (Index == 3)
                            _name = "Other";
                    }
                    if (_name == null)
                        _name = "Action" + Index;
                }
            }
        }

        public override bool OnInitialize()
        {
            _offsets.Add(_offset);
            _build = true;
            if (_offset > Root.dataSize)
                return false;

            if (_parent != null && (_parent as MoveDefEntryNode).ParentArticle != null)
                _attachedArticleIndex = (_parent as MoveDefEntryNode).ParentArticle.Index;

            if (_name == null)
            {
                if (Parent.Parent.Name == "Action Scripts")
                {
                    if (Index == 0)
                        _name = "Entry";
                    else if (Index == 1)
                        _name = "Exit";
                }
                else if (Parent.Parent.Name == "SubAction Scripts")
                {
                    if (Index == 0)
                        _name = "Main";
                    else if (Index == 1)
                        _name = "GFX";
                    else if (Index == 2)
                        _name = "SFX";
                    else if (Index == 3)
                        _name = "Other";
                }
                if (_name == null)
                    _name = "Action" + Index;
            }

            base.OnInitialize();

            //Root._paths[_offset] = TreePath;

            return (Header->_nameSpace != 0 || Header->_id != 0);
        }

        public override void OnPopulate()
        {
            FDefEvent* ev = Header;
            if (!_isBlank)
            while (ev->_nameSpace != 0 || ev->_id != 0)
                new MoveDefEventNode().Initialize(this, new DataSource(((VoidPtr)ev++), 8));

            SetSizeInternal(Children.Count * 8 + 8);
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            int size = 8; //Terminator event size
            foreach (MoveDefEventNode e in Children)
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
            foreach (MoveDefEventNode e in Children)
                off += e.Children.Count * 8;

            FDefEventArgument* paramAddr = (FDefEventArgument*)address;
            FDefEvent* eventAddr = (FDefEvent*)(address + off);

            _rebuildAddr = eventAddr;

            foreach (MoveDefEventNode e in Children)
            {
                if (e._name == "FADEF00D" || e._name == "FADE0D8A") continue;
                e._rebuildAddr = eventAddr;
                *eventAddr = new FDefEvent() { _id = e.id, _nameSpace = e.nameSpace, _numArguments = (byte)e.Children.Count, _unk1 = e.unk1 };
                if (e.Children.Count > 0)
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
