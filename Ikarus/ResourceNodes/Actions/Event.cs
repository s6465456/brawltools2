using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.OpenGL;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using OpenTK.Graphics.OpenGL;
using Ikarus;
using BrawlLib.Modeling;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class Event : MoveDefEntry
    {
        internal FDefEvent* Header { get { return (FDefEvent*)WorkingUncompressed.Address; } }
        internal FDefEventArgument* ArgumentHeader { get { return (FDefEventArgument*)(BaseAddress + Header->_argumentOffset); } }

        internal byte nameSpace, id, numArguments, unk1;
        internal List<FDefEventArgument> arguments = new List<FDefEventArgument>();

        public override int OnCalculateSize(bool force)
        {
            int size = 8;
            _lookupCount = (Children.Count > 0 ? 1 : 0);
            foreach (MoveDefEventParameterNode p in Children)
            {
                size += p.CalculateSize(true);
                _lookupCount += p._lookupCount;
            }
            return size;
        }

        [Browsable(false)]
        public ActionEventInfo EventInfo 
        {
            get
            {
                if (FileManager.EventDictionary.ContainsKey(_event)) 
                    return FileManager.EventDictionary[_event]; 
                else 
                    return null; 
            } 
        }
        public uint _event;

        [Browsable(false)]
        public uint EventID 
        {
            get { return _event; }
            set 
            {
                _event = value;
                string ev = Helpers.Hex8(_event);
                nameSpace = byte.Parse(ev.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                id = byte.Parse(ev.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                numArguments = byte.Parse(ev.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                unk1 = byte.Parse(ev.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                if (FileManager.EventDictionary.ContainsKey(_event))
                    Name = FileManager.EventDictionary[_event]._name;
                else
                    Name = ev;
            } 
        }

        [Browsable(false)]
        public Event EventData
        {
            get
            {
                Event e = new Event();
                e.SetEventEvent(_event);
                e._pParameters = ArgumentOffset;
                int i = 0;
                foreach (ResourceNode r in Children)
                    if (r is MoveDefEventParameterNode)
                    {
                        e._parameters[i]._type = (r as MoveDefEventParameterNode)._type;
                        e._parameters[i++]._data = (r as MoveDefEventParameterNode)._value;
                    }
                return e;
            }
        }

        public string Serialize()
        {
            string s = "";
            s += Helpers.Hex8(EventID) + "|";
            foreach (MoveDefEventParameterNode p in Children)
            {
                s += ((int)p._type).ToString() + "\\";
                if (p._type == ArgVarType.Offset)
                {
                    MoveDefEventOffsetNode o = p as MoveDefEventOffsetNode;
                    s += o.list + "," + o.type + "," + o.index;
                }
                else s += p._value;
                s += "|";
            }
            return s;
        }

        public static Event Deserialize(string s, MoveDefNode node)
        {
            if (String.IsNullOrEmpty(s))
                return null;

            try
            {
                string[] lines = s.Split('|');

                if (lines[0].Length != 8)
                    return null;

                Event newEv = new Event() { _parent = node };

                string id = lines[0];
                uint idNumber = Convert.ToUInt32(id, 16);

                newEv.EventID = idNumber;
                
                uint _event = newEv.EventID;
                ActionEventInfo info = newEv.EventInfo;

                for (int i = 0; i < newEv.numArguments; i++)
                {
                    string[] pLines = lines[i + 1].Split('\\');

                    int type = int.Parse(pLines[0]);

                    if (type == 2) //Offset
                    {
                        string[] oLines = pLines[1].Split(',');
                        int list = int.Parse(oLines[0]), type2 = int.Parse(oLines[1]), index = int.Parse(oLines[2]);
                        MoveDefEventOffsetNode o = (MoveDefEventOffsetNode)newEv.NewParam(i, 0, 2);
                        o.action = node.GetAction(list, type2, index);
                        o.list = list;
                        o.type = type2;
                        o.index = index;
                    }
                    else
                    {
                        int value = int.Parse(pLines[1]);
                        newEv.NewParam(i, value, type);
                    }
                }

                newEv._parent = null;
                return newEv;
            }
            catch { return null; }
        }

        public void NewChildren()
        {
            while (Children.Count > 0)
                RemoveChild(Children[0]);
            for (int i = 0; i < numArguments; i++) 
                NewParam(i, 0, -1);
        }

        public MoveDefEntry NewParam(int i, int value, int typeOverride)
        {
            MoveDefEntry child = null;
            ActionEventInfo info = EventInfo;
            ArgVarType type = ArgVarType.Value;
            if (typeOverride >= 0)
                type = (ArgVarType)typeOverride;
            else if (info != null)
                type = (ArgVarType)info.GetDfltParameter(i);

            if ((ArgVarType)(int)type == ArgVarType.Value)
            {
                string name = info != null && i < info._parameters.Length ? info._parameters[i] : "Value";

                //Check for some specific node types

                if //Hitbox Flags
                    ((_event == 0x06000D00 
                    || _event == 0x06150F00 
                    || _event == 0x062B0D00) 
                    && i == 12)
                    child = (new HitboxFlagsNode(name) { _value = value, val = new HitboxFlags() { _data = (uint)value } });

                else if (//Two Half Values
                    ((_event == 0x06000D00 
                    || _event == 0x06150F00 
                    || _event == 0x062B0D00) 
                    && (i == 0 || i == 3 || i == 4)))
                    child = (new MoveDefEventValue2HalfNode(name) { _value = value });

                else if //GFX Selector
                    ((_event == 0x11150300 
                    || _event == 0x11001000 
                    || _event == 0x11010A00 
                    || _event == 0x11020A00)
                    && i == 0)
                    child = (new MoveDefEventValue2HalfGFXNode(name) { _value = value });
                
                else if (
                    i == 14 && 
                    _event == 0x06150F00)
                    child = (new SpecialHitboxFlagsNode(name) { _value = value, val = new SpecialHitboxFlags() { _data = (uint)value } });
                
                else //Not a special value
                {
                    if (EventInfo != null && EventInfo.Enums != null && EventInfo.Enums.ContainsKey(i))
                        child = new MoveDefEventValueEnumNode(name) { Enums = EventInfo.Enums[i].ToArray() };
                    else
                        child = (new MoveDefEventValueNode(name) { _value = value });
                }
            }
            else if ((ArgVarType)(int)type == ArgVarType.Scalar)
                child = (new MoveDefEventScalarNode(info != null && i < info._parameters.Length ? info._parameters[i] : "Scalar") { _value = value });
            else if ((ArgVarType)(int)type == ArgVarType.Boolean)
                child = (new MoveDefEventBoolNode(info != null && i < info._parameters.Length ? info._parameters[i] : "Boolean") { _value = value });
            else if ((ArgVarType)(int)type == ArgVarType.File)
                child = (new MoveDefEventUnkNode(info != null && i < info._parameters.Length ? info._parameters[i] : "File") { _value = value });
            else if ((ArgVarType)(int)type == ArgVarType.Requirement)
            {
                MoveDefEventRequirementNode r = new MoveDefEventRequirementNode(info != null && i < info._parameters.Length ? info._parameters[i] : "Requirement") { _value = value };
                child = r;
                r._parent = _root;
                r._val = r.GetRequirement(r._value);
            }
            else if ((ArgVarType)(int)type == ArgVarType.Variable)
            {
                MoveDefEventVariableNode v = new MoveDefEventVariableNode(info != null && i < info._parameters.Length ? info._parameters[i] : "Variable") { _value = value };
                child = v;
                v._parent = _root;
                v.val = v.ResolveVariable(v._value);
            }
            else if ((ArgVarType)(int)type == ArgVarType.Offset)
                child = (new MoveDefEventOffsetNode(info != null && i < info._parameters.Length ? info._parameters[i] : "Offset") { _value = value });
            child._parent = null;
            if (i == Children.Count)
                AddChild(child);
            else
                InsertChild(child, true, i);
            return child;
        }

        public enum NameSpaceEnum : byte
        {
            ExecutionFlow = 0x00,
            LoopRest = 0x01,
            Actions = 0x02,
            SubActions = 0x04,
            Posture = 0x05,
            Collisions = 0x06,
            Controller = 0x07,
            EdgeInteraction = 0x08,
            Unknown09 = 0x09,
            Sounds = 0x0A,
            Models = 0x0B,
            CharacterSpecific = 0x0C,
            ConcurrentExecution = 0x0D,
            Movement = 0x0E,
            Unknown15 = 0x0F,
            Articles = 0x10,
            Graphics = 0x11,
            Variables = 0x12,
            Unknown19 = 0x13,
            AestheticWind = 0x14,
            Unknown21 = 0x15,
            Physics = 0x17,
            TerrainInteraction = 0x18,
            Unknown25 = 0x19,
            Camera = 0x1A,
            ProcedureCall = 0x1B,
            ArmorDamage = 0x1E,
            Items = 0x1F,
            Unknown32 = 0x20,
            FlashOverlays = 0x21,
            TeamAssociation = 0x22,
            Cancelling = 0x64,
            Unknown101 = 0x65,
            Unknown102 = 0x66,
            Unknown105 = 0x69,
            Unknown106 = 0x6A,
            Unknown107 = 0x6B,
            Unknown110 = 0x6E,
        }

        [Category("MoveDef Event")]
        public byte NameSpace { get { return nameSpace; } }//set { nameSpace = value; SignalPropertyChange(); } }
        [Category("MoveDef Event")]
        public byte ID { get { return id; } }//set { id = value; SignalPropertyChange(); } }
        [Category("MoveDef Event")]
        public byte NumArguments { get { return numArguments; } }//set { numArguments = value; SignalPropertyChange(); } }
        [Category("MoveDef Event")]
        public byte Unknown { get { return unk1; } set { unk1 = value; SignalPropertyChange(); } }
        [Category("MoveDef Event")]
        public uint ArgumentOffset { get { return argOffset; } }
        public uint argOffset = 0;

        [Category("MoveDef Event Argument")]
        public ArgVarType[] Type { get { var array = from x in arguments select (ArgVarType)(int)x._type; return array.ToArray<ArgVarType>(); } }
        [Category("MoveDef Event Argument")]
        public int[] Value { get { var array = from x in arguments select (int)x._data; return array.ToArray<int>(); } }

        [Browsable(false)]
        public List<FDefEventArgument> Arguments { get { return arguments; } set { arguments = value; } }

        public override bool OnInitialize()
        {
            if ((int)Header == (int)BaseAddress)
                return false;

            argOffset = Header->_argumentOffset;

            nameSpace = Header->_nameSpace;
            id = Header->_id;
            numArguments = Header->_numArguments;
            unk1 = Header->_unk1;

            //Merge values to create ID and match with events to get name
            _event = uint.Parse(String.Format("{0:X02}{1:X02}{2:X02}{3:X02}", nameSpace, id, numArguments, unk1), System.Globalization.NumberStyles.HexNumber);
            if (FileManager.EventDictionary.ContainsKey(_event))
                _name = FileManager.EventDictionary[_event]._name;
            else
            {
                if (unk1 > 0)
                {
                    uint temp = uint.Parse(String.Format("{0:X02}{1:X02}{2:X02}{3:X02}", nameSpace, id, numArguments, 0), System.Globalization.NumberStyles.HexNumber);
                    if (FileManager.EventDictionary.ContainsKey(temp))
                    {
                        _name = FileManager.EventDictionary[temp]._name + " (Unknown == " + unk1 + ")";
                        _event = temp;
                    }
                }
                else _name = Helpers.Hex8(_event);
            }

            if (!_root._events.ContainsKey(_event))
                _root._events.Add(_event, new List<Event>() { this });
            else
                _root._events[_event].Add(this);

            if (_name == "FADEF00D" || _name == "FADE0D8A")
            {
                Remove();
                return false;
            }
            
            for (int i = 0; i < numArguments; i++)
            {
                FDefEventArgument e;
                FDefEventArgument* header = &ArgumentHeader[i];
                arguments.Add(e = *header);

                string param = null;
                if (EventInfo != null && EventInfo._parameters != null && EventInfo._parameters.Length != 0 && EventInfo._parameters.Length > i)
                    param = String.IsNullOrEmpty(EventInfo._parameters[i]) ? null : EventInfo._parameters[i];

                if ((_event == 0x06000D00 || _event == 0x06150F00 || _event == 0x062B0D00) && i == 12)
                    new HitboxFlagsNode(param).Initialize(this, header, 8);
                else if (((_event == 0x06000D00 || _event == 0x06150F00 || _event == 0x062B0D00) && (i == 0 || i == 3 || i == 4)))
                    new MoveDefEventValue2HalfNode(param).Initialize(this, header, 8);
                else if (((_event == 0x11150300 || _event == 0x11001000 || _event == 0x11010A00 || _event == 0x11020A00) && i == 0))
                    new MoveDefEventValue2HalfGFXNode(param).Initialize(this, header, 8);
                else if (i == 14 && _event == 0x06150F00)
                    new SpecialHitboxFlagsNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Value)
                {
                    if (EventInfo != null && EventInfo.Enums != null && EventInfo.Enums.ContainsKey(i))
                        new MoveDefEventValueEnumNode(param) { Enums = EventInfo.Enums[i].ToArray() }.Initialize(this, header, 8);
                    else
                        new MoveDefEventValueNode(param).Initialize(this, header, 8);
                }
                else if ((ArgVarType)(int)e._type == ArgVarType.File)
                    new MoveDefEventUnkNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Scalar)
                    new MoveDefEventScalarNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Boolean)
                    new MoveDefEventBoolNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Requirement)
                    new MoveDefEventRequirementNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Variable)
                    new MoveDefEventVariableNode(param).Initialize(this, header, 8);
                else if ((ArgVarType)(int)e._type == ArgVarType.Offset)
                {
                    int offset = -1;
                    ReferenceEntry ext;
                    int paramOffset = e._data;

                    if (paramOffset == -1)
                        ext = _root.TryGetExternal((int)ArgumentOffset + i * 8 + 4);
                    else
                        ext = _root.TryGetExternal(paramOffset);

                    if (ext == null)
                        offset = e._data;

                    if (offset > 0)
                    {
                        ActionScript a;
                        int list, index, type;
                        _root.GetActionLocation(offset, out list, out type, out index);

                        if (list == 4) //Offset not found in existing nodes
                        {
                            _root._subRoutines[offset] = (a = new ActionScript("SubRoutine" + _root._subRoutines.Count, false, null));
                            a.Initialize(_root._subRoutineGroup, new DataSource((sbyte*)BaseAddress + offset, 8));
                            //if (offset != (Parent as MoveDefEntryNode)._offset)
                            //    a.Populate();
                            a._actionRefs.Add(this);
                        }
                        else
                        {
                            ActionScript n = _root.GetAction(list, type, index);
                            if (n != null)
                                n._actionRefs.Add(this);
                        }
                    }

                    //Add ID node
                    if (ext != null)
                    {
                        MoveDefEventOffsetNode x = new MoveDefEventOffsetNode(param) { _name = ext.Name, _externalEntry = ext, _extOverride = true };
                        x.Initialize(this, header, 8);
                        ext._references.Add(x);
                    }
                    else
                        new MoveDefEventOffsetNode(param).Initialize(this, header, 8);
                }
            }
            return arguments.Count > 0;
        }

        public override string ToString()
        {
            if (Children.Count > 0 && (Children[0] is MoveDefEventOffsetNode || (EventID == 0x0D000200 && Children[1] is MoveDefEventOffsetNode)))
                return TreePath;
            else
                return base.ToString();
        }

        public override void Remove()
        {
            foreach (MoveDefEventParameterNode p in Children)
                if (p.External)
                    p._externalEntry._refs.Remove(p);
            
            base.Remove();
        }
    }

    public class HitBox
    {
        //A seperate class for rendering hitboxes.
        //This allows the values to be modified by other events.
        public HitBox(Event ev, int articleIndex)
        {
            Root = ev._root;
            _event = ev._event;
            EventData = ev.EventData;
            if (_event != 0x060A0800)
                flags = ev.Children[12] as HitboxFlagsNode;
            if (_event == 0x06150F00)
                specialFlags = ev.Children[14] as SpecialHitboxFlagsNode;
            if ((_articleIndex = articleIndex) < 0)
                _model = RunTime.MainWindow.TargetModel;
            else
                _model = RunTime._articles[_articleIndex]._model;
        }

        public int _articleIndex;
        public MDL0Node _model;
        public MoveDefNode Root;
        public int HitboxID = -1;
        public int HitboxSize = 0;
        public uint _event = 0;
        public Event EventData = null;
        public HitboxFlagsNode flags;
        public SpecialHitboxFlagsNode specialFlags;

        #region Offensive Collision
        public unsafe void RenderOffensiveCollision(TKContext c, Vector3 cam)
        {
            if (_event != 0x06000D00) //Offensive Collision
                return;

            MoveDefNode node = Root;
            ResourceNode[] bl = _model._linker.BoneCache;

            Event e = EventData;

            int boneindex = (int)e._parameters[0]._data >> 16;
            int size = HitboxSize;
            int angle = e._parameters[2]._data;

            node.GetBoneIndex(ref boneindex);

            if (boneindex == 0) //If a hitbox is on TopN, make it follow TransN
            {
                //Use assigned references
                if (node._data != null)
                {
                    boneindex = (node._data._misc.boneRefs.Children[4] as MoveDefBoneIndexNode).boneIndex;
                    node.GetBoneIndex(ref boneindex);
                }
                else //Search manually
                {
                    int transindex = 0;
                    foreach (MDL0BoneNode bn in bl)
                    {
                        if (bn.Name.Equals("TransN")) break;
                        transindex++;
                    }
                    if (transindex != bl.Length)
                        boneindex = transindex;
                }
            }

            MDL0BoneNode b;
            b = bl[boneindex] as MDL0BoneNode;

            Matrix r = b.Matrix.GetRotationMatrix();
            FrameState state = b.Matrix.Derive();
            Vector3 bonePos = state._translate;
            Vector3 globalPos = r.Multiply(new Vector3(DataHelpers.UnScalar(e._parameters[6]._data), DataHelpers.UnScalar(e._parameters[7]._data), DataHelpers.UnScalar(e._parameters[8]._data)) / state._scale);

            Matrix m = Matrix.TransformMatrix(new Vector3(1), state._rotate, globalPos + bonePos);
            Vector3 resultPos = m.GetPoint();

            int id = (int)e._parameters[0]._data & 0xFFFF;
            RunTime.MainWindow.ModelPanel.ScreenText[id.ToString()] = RunTime.MainWindow.ModelPanel.Project(resultPos);

            m = Matrix.TransformMatrix(new Vector3(DataHelpers.UnScalar(size)), new Vector3(), resultPos);
            GL.PushMatrix();
            GL.MultMatrix((float*)&m);
            int res = 16;
            double drawAngle = 360.0 / res;

            Vector3 color = DataHelpers.GetTypeColor(flags.Type);
            GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.5f);
            
            GLDisplayList spheres = c.GetSphereList();
            spheres.Call();

            //Angle indicator
            double rangle = angle / 180.0 * Math.PI;

            //Apply color
            color = DataHelpers.GetEffectColor(flags.Effect);
            GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.75f);
            
            GL.PushMatrix();
            if (angle == 361) //Sakurai angle
            {
                m = Matrix.TransformMatrix(new Vector3(0.5f), (globalPos + bonePos).LookatAngles(cam) * Maths._rad2degf, new Vector3(0));
                GL.MultMatrix((float*)&m);
                GL.Begin(BeginMode.Quads);
                for (int i = 0; i < 16; i += 2)
                {
                    GL.Vertex3(Math.Cos((i - 1) * Math.PI / 8) * 0.5, Math.Sin((i - 1) * Math.PI / 8) * 0.5, 0);
                    GL.Vertex3(Math.Cos(i * Math.PI / 8), Math.Sin(i * Math.PI / 8), 0);
                    GL.Vertex3(Math.Cos((i + 1) * Math.PI / 8) * 0.5, Math.Sin((i + 1) * Math.PI / 8) * 0.5, 0);
                    GL.Vertex3(0, 0, 0);
                }
                GL.End();
            }
            else
            {
                long a = -angle; //Otherwise 90 would point down
                int angleflip = 0;
                if (resultPos._z < 0)
                    angleflip = 180;
                m = Matrix.TransformMatrix(new Vector3(1), new Vector3(a, angleflip, 0), new Vector3());
                GL.MultMatrix((float*)&m);
                GL.Begin(BeginMode.Quads);
                // left face
                GL.Vertex3(0.1, 0.1, 0);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(0.1, -0.1, 0);
                // right face
                GL.Vertex3(-0.1, -0.1, 0);
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(-0.1, 0.1, 1);
                GL.Vertex3(-0.1, 0.1, 0);
                // top face
                GL.Vertex3(-0.1, 0.1, 0);
                GL.Vertex3(-0.1, 0.1, 1);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(0.1, 0.1, 0);
                // bottom face
                GL.Vertex3(0.1, -0.1, 0);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(-0.1, -0.1, 0);
                // front face
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(-0.1, 0.1, 1);
                // back face
                GL.Vertex3(-0.1, 0.1, 0);
                GL.Vertex3(0.1, 0.1, 0);
                GL.Vertex3(0.1, -0.1, 0);
                GL.Vertex3(-0.1, -0.1, 0);
                GL.End();
            }
            GL.PopMatrix();

            // border
            GLDisplayList rings = c.GetRingList();
            for (int i = -5; i <= 5; i++)
            {
                GL.PushMatrix();
                m = Matrix.TransformMatrix(new Vector3(1 + 0.0025f * i), (globalPos + bonePos).LookatAngles(cam) * Maths._rad2degf, new Vector3());
                GL.MultMatrix((float*)&m);
                if (flags.Clang)
                    rings.Call();
                else
                {
                    for (double j = 0; j < 360 / (drawAngle / 2); j += 2)
                    {
                        double ang1 = (j * (drawAngle / 2)) / 180 * Math.PI;
                        double ang2 = ((j + 1) * (drawAngle / 2)) / 180 * Math.PI;
                        GL.Begin(BeginMode.LineStrip);
                        GL.Vertex3(Math.Cos(ang1), Math.Sin(ang1), 0);
                        GL.Vertex3(Math.Cos(ang2), Math.Sin(ang2), 0);
                        GL.End();
                    }
                }
                GL.PopMatrix();
            }
            
            GL.PopMatrix();
            GL.PopMatrix();
        }

        #endregion

        #region Special Offensive Collision
        public unsafe void RenderSpecialOffensiveCollision(TKContext c, Vector3 cam)
        {
            if (_event != 0x06150F00) //Special Offensive Collision
                return;

            Event e = EventData;
            ResourceNode[] bl = _model._linker.BoneCache;

            int boneindex = (int)e._parameters[0]._data >> 16;
            int size = HitboxSize;
            int angle = e._parameters[2]._data;

            Root.GetBoneIndex(ref boneindex);

            if (boneindex == 0) //If a hitbox is on TopN, make it follow TransN
            {
                if (Root._data != null)
                {
                    boneindex = (Root._data._misc.boneRefs.Children[4] as MoveDefBoneIndexNode).boneIndex;
                    Root.GetBoneIndex(ref boneindex);
                }
                else
                {
                    int transindex = 0;
                    foreach (MDL0BoneNode bn in bl)
                    {
                        if (bn.Name.Equals("TransN")) break;
                        transindex++;
                    }
                    if (transindex != bl.Length)
                        boneindex = transindex;
                }
            }
            MDL0BoneNode b;
            b = bl[boneindex] as MDL0BoneNode;

            Matrix r = b.Matrix.GetRotationMatrix();
            FrameState state = b.Matrix.Derive();
            Vector3 bonePos = state._translate;
            Vector3 pos = new Vector3(DataHelpers.UnScalar(e._parameters[6]._data), DataHelpers.UnScalar(e._parameters[7]._data), DataHelpers.UnScalar(e._parameters[8]._data)) / state._scale;
            Vector3 globalPos = r.Multiply(pos);

            Matrix m = Matrix.TransformMatrix(new Vector3(1), state._rotate, globalPos + bonePos);
            Vector3 resultPos = m.GetPoint();

            int id = (int)e._parameters[0]._data & 0xFFFF;
            RunTime.MainWindow.ModelPanel.ScreenText[id.ToString()] = RunTime.MainWindow.ModelPanel.Project(resultPos);

            m = Matrix.TransformMatrix(new Vector3(DataHelpers.UnScalar(size)), new Vector3(), resultPos);
            GL.PushMatrix();
            GL.MultMatrix((float*)&m);
            int res = 16, stretchres = 10;
            double drawangle = 360.0 / res;

            Vector3 color = DataHelpers.GetTypeColor(flags.Type);
            GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.5f);
                
            GLDisplayList spheres = c.GetSphereList();
            spheres.Call();
            if (specialFlags.Stretches)
            {
                GL.PushMatrix();
                m = Matrix.TransformMatrix(new Vector3(1), state._rotate, new Vector3());
                GL.MultMatrix((float*)&m);
                Vector3 reversepos = new Vector3(-pos._x / DataHelpers.UnScalar(size), -pos._y / DataHelpers.UnScalar(size), -pos._z / DataHelpers.UnScalar(size));

                color = DataHelpers.GetEffectColor(flags.Effect);
                GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.5f);
                
                GL.Translate(reversepos._x, reversepos._y, reversepos._z);
                GL.Begin(BeginMode.Lines); // stretch lines
                GL.Vertex3(1, 0, 0);
                GL.Vertex3(1 - reversepos._x, 0 - reversepos._y, 0 - reversepos._z);
                GL.Vertex3(-1, 0, 0);
                GL.Vertex3(-1 - reversepos._x, 0 - reversepos._y, 0 - reversepos._z);
                GL.Vertex3(0, 1, 0);
                GL.Vertex3(0 - reversepos._x, 1 - reversepos._y, 0 - reversepos._z);
                GL.Vertex3(0, -1, 0);
                GL.Vertex3(0 - reversepos._x, -1 - reversepos._y, 0 - reversepos._z);
                GL.Vertex3(0, 0, 1);
                GL.Vertex3(0 - reversepos._x, 0 - reversepos._y, 1 - reversepos._z);
                GL.Vertex3(0, 0, -1);
                GL.Vertex3(0 - reversepos._x, 0 - reversepos._y, -1 - reversepos._z);
                GL.End();

                color = DataHelpers.GetTypeColor(flags.Type);
                GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.25f);
                
                spheres.Call(); // root sphere
                GL.Translate(-reversepos._x, -reversepos._y, -reversepos._z);
                GL.PopMatrix();
            }

            // angle indicator
            double rangle = angle / 180.0 * Math.PI;
            Vector3 effectcolour = DataHelpers.GetEffectColor(flags.Effect);
            GL.Color4((effectcolour._x / 255.0f), (effectcolour._y / 225.0f), (effectcolour._z / 255.0f), 0.75f);
            GL.PushMatrix();
            if (angle == 361)
            {
                m = Matrix.TransformMatrix(new Vector3(0.5f), (globalPos + bonePos).LookatAngles(cam) * Maths._rad2degf, new Vector3(0));
                GL.MultMatrix((float*)&m);
                GL.Begin(BeginMode.Quads);
                for (int i = 0; i < 16; i += 2)
                {
                    GL.Vertex3(Math.Cos((i - 1) * Math.PI / 8) * 0.5, Math.Sin((i - 1) * Math.PI / 8) * 0.5, 0);
                    GL.Vertex3(Math.Cos(i * Math.PI / 8), Math.Sin(i * Math.PI / 8), 0);
                    GL.Vertex3(Math.Cos((i + 1) * Math.PI / 8) * 0.5, Math.Sin((i + 1) * Math.PI / 8) * 0.5, 0);
                    GL.Vertex3(0, 0, 0);
                }
                GL.End();
            }
            else
            {
                long a = -angle; // otherwise 90 would point down
                int angleflip = 0;
                if (resultPos._z < 0)
                    angleflip = 180;
                m = Matrix.TransformMatrix(new Vector3(1), new Vector3(a, angleflip, 0), new Vector3());
                GL.MultMatrix((float*)&m);
                GL.Begin(BeginMode.Quads);
                // left face
                GL.Vertex3(0.1, 0.1, 0);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(0.1, -0.1, 0);
                // right face
                GL.Vertex3(-0.1, -0.1, 0);
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(-0.1, 0.1, 1);
                GL.Vertex3(-0.1, 0.1, 0);
                // top face
                GL.Vertex3(-0.1, 0.1, 0);
                GL.Vertex3(-0.1, 0.1, 1);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(0.1, 0.1, 0);
                // bottom face
                GL.Vertex3(0.1, -0.1, 0);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(-0.1, -0.1, 0);
                // front face
                GL.Vertex3(-0.1, -0.1, 1);
                GL.Vertex3(0.1, -0.1, 1);
                GL.Vertex3(0.1, 0.1, 1);
                GL.Vertex3(-0.1, 0.1, 1);
                // back face
                GL.Vertex3(-0.1, 0.1, 0);
                GL.Vertex3(0.1, 0.1, 0);
                GL.Vertex3(0.1, -0.1, 0);
                GL.Vertex3(-0.1, -0.1, 0);
                GL.End();
            }
            GL.PopMatrix();

            // border
            GLDisplayList rings = c.GetRingList();
            for (int i = -5; i <= 5; i++)
            {
                GL.PushMatrix();
                m = Matrix.TransformMatrix(new Vector3(1 + 0.0025f * i), (globalPos + bonePos).LookatAngles(cam) * Maths._rad2degf, new Vector3());
                GL.MultMatrix((float*)&m);
                if (flags.Clang)
                    rings.Call();
                else
                {
                    for (double j = 0; j < 360 / (drawangle / 2); j += 2)
                    {
                        double ang1 = (j * (drawangle / 2)) / 180 * Math.PI;
                        double ang2 = ((j + 1) * (drawangle / 2)) / 180 * Math.PI;
                        int q = 0;
                        GL.Begin(BeginMode.LineStrip);
                        GL.Vertex3(Math.Cos(ang1), Math.Sin(ang1), 0);
                        GL.Vertex3(Math.Cos(ang2), Math.Sin(ang2), 0);
                        GL.End();
                    }
                }
                GL.PopMatrix();
            }
            
            GL.PopMatrix();
            GL.PopMatrix();
        }
        #endregion

        #region Catch Collision
        public unsafe void RenderCatchCollision(TKContext c, Vector3 cam)
        {
            if (_event != 0x060A0800 && _event != 0x060A0900 && _event != 0x060A0A00)
                return;

            Event e = EventData;
            ResourceNode[] bl = _model._linker.BoneCache;

            int boneindex = e._parameters[1]._data;
            int size = HitboxSize;

            Root.GetBoneIndex(ref boneindex);

            if (boneindex == 0) // if a hitbox is on TopN, make it follow TransN
            {
                if (Root._data != null)
                {
                    boneindex = (Root._data._misc.boneRefs.Children[4] as MoveDefBoneIndexNode).boneIndex;
                    Root.GetBoneIndex(ref boneindex);
                }
                else
                {
                    int transindex = 0;
                    foreach (MDL0BoneNode bn in bl)
                    {
                        if (bn.Name.Equals("TransN")) break;
                        transindex++;
                    }
                    if (transindex != bl.Length)
                        boneindex = transindex;
                }
            }
            MDL0BoneNode b = bl[boneindex] as MDL0BoneNode;

            Matrix r = b.Matrix.GetRotationMatrix();
            FrameState state = b.Matrix.Derive();
            Vector3 bonePos = state._translate;
            Vector3 pos = new Vector3(DataHelpers.UnScalar(e._parameters[3]._data), DataHelpers.UnScalar(e._parameters[4]._data), DataHelpers.UnScalar(e._parameters[5]._data)) / state._scale;
            Vector3 globalPos = r.Multiply(pos);

            Matrix m = Matrix.TransformMatrix(new Vector3(1), state._rotate, globalPos + bonePos);
            Vector3 resultPos = m.GetPoint();

            m = Matrix.TransformMatrix(new Vector3(DataHelpers.UnScalar(size)), new Vector3(), resultPos);
            GL.PushMatrix();
            GL.MultMatrix((float*)&m);
            int res = 16;
            double drawangle = 360.0 / res;

            Vector3 color = DataHelpers.GetTypeColor(DataHelpers.HitboxType.Throwing);
            GL.Color4((color._x / 255.0f), (color._y / 225.0f), (color._z / 255.0f), 0.375f);
            GLDisplayList spheres = c.GetSphereList();
            spheres.Call();
            
            GL.PopMatrix();
        }
        #endregion

        #region General Collision
        //public unsafe virtual void RenderGeneralCollision(List<MDL0BoneNode> bl, GLContext c, Vector3 cam, DrawStyle style)
        //{
        //    MDL0BoneNode b = bl[0];
        //    Vector3 bonepos = b._frameMatrix.GetPoint();
        //    Vector3 pos = new Vector3(intToScalar(getXPos()), intToScalar(getYPos()), intToScalar(getZPos()));
        //    Vector3 bonerot = b._frameMatrix.GetAngles();
        //    Matrix r = b._frameMatrix.GetRotationMatrix();
        //    Vector3 globpos = r.Multiply(pos);
        //    Matrix m = Matrix.TransformMatrix(new Vector3(1), bonerot, globpos + bonepos);
        //    Vector3 result = new Vector3(m[12], m[13], m[14]);
        //    m = Matrix.TransformMatrix(new Vector3(intToScalar(getSize())), new Vector3(), result);
        //    GL.PushMatrix();
        //    GL.MultMatrix((float*)&m);
        //    int res = 16;
        //    double drawangle = 360.0 / res;
        //    // bubble
        //    Vector3 typecolour = new Vector3(0x7f, 0x7f, 0x7f);
        //    GL.Color4((typecolour._x / 255.0f), (typecolour._y / 225.0f), (typecolour._z / 255.0f), 0.375f);
        //    if (style == DrawStyle.SSB64)
        //    {
        //        GL.Color4(1.0f, 1.0f, 1.0f, 0.25f);
        //        c.DrawInvertedCube(new Vector3(0, 0, 0), 1.025f);
        //        GL.Color4(0.5f, 0.5f, 0.5f, 0.5f);
        //        c.DrawCube(new Vector3(0, 0, 0), 0.975f);
        //    }
        //    else
        //    {
        //        GLDisplayList spheres = c.GetSphereList();
        //        spheres.Call();
        //    }
        //    GL.PopMatrix();
        //}
        #endregion
    }
}
