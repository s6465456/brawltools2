using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.Wii.Models;
using BrawlLib.SSBBTypes;
using BrawlLib.Modeling;
using BrawlLib.OpenGL;
using System.Drawing;
using BrawlLib.Wii.Animations;
using BrawlLib.Wii.Compression;
using System.Windows;
using BrawlLib.IO;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MDL0BoneNode : MDL0EntryNode, IMatrixNode
    {
        public int _permanentID;
        [Browsable(false)]
        public int PermanentID { get { return _permanentID; } }

        internal MDL0Bone* Header { get { return (MDL0Bone*)WorkingUncompressed.Address; } }

        public bool _moved = false;
        [Browsable(false)]
        public bool Moved
        {  
            get { return _moved;  } 
            set 
            {
                _moved = true;
                Model.SignalPropertyChange();
                Model.Rebuild(false); //Bone rebuilds are forced automatically
            } 
        }

        public override ResourceType ResourceType { get { return ResourceType.MDL0Bone; } }
        public override bool AllowDuplicateNames { get { return true; } }

        public BoneFlags _flags1 = (BoneFlags)0x100;
        public BillboardFlags _flags2;
        public uint _bbNodeId;
        
        internal List<MDL0ObjectNode> _infPolys = new List<MDL0ObjectNode>();
        internal List<MDL0ObjectNode> _manPolys = new List<MDL0ObjectNode>();
        [Category("Bone")]
        public MDL0ObjectNode[] AttachedObjects { get { return _manPolys.ToArray(); } }
        [Category("Bone")]
        public MDL0ObjectNode[] InfluencedObjects { get { return _infPolys.ToArray(); } }

        internal FrameState _bindState = FrameState.Neutral;
        public Matrix _bindMatrix = Matrix.Identity, _inverseBindMatrix = Matrix.Identity;
        internal FrameState _frameState = FrameState.Neutral;
        public Matrix _frameMatrix = Matrix.Identity, _inverseFrameMatrix = Matrix.Identity;

        private Vector3 _bMin, _bMax;
        internal int _nodeIndex, _weightCount, _refCount, _headerLen, _mdl0Offset, _stringOffset;

        [Category("Bone"), Browsable(false)]
        public Matrix Matrix { get { return _frameMatrix; } }
        [Category("Bone"), Browsable(false)]
        public Matrix InverseMatrix { get { return _inverseFrameMatrix; } }
        [Category("Bone"), Browsable(false), TypeConverter(typeof(MatrixStringConverter))]
        public Matrix BindMatrix { get { return _bindMatrix; } set { _bindMatrix = value; SignalPropertyChange(); } }
        [Category("Bone"), Browsable(false), TypeConverter(typeof(MatrixStringConverter))]
        public Matrix InverseBindMatrix { get { return _inverseBindMatrix; } set { _inverseBindMatrix = value; SignalPropertyChange(); } }

        [Browsable(false)]
        public int NodeIndex { get { return _nodeIndex; } }
        [Browsable(false)]
        public int ReferenceCount { get { return _refCount; } set { _refCount = value; } }
        [Browsable(false)]
        public bool IsPrimaryNode { get { return true; } }

        private BoneWeight[] _weightRef;
        [Browsable(false)]
        public BoneWeight[] Weights { get { return _weightRef == null ? _weightRef = new BoneWeight[] { new BoneWeight(this, 1.0f) } : _weightRef; } }

        [Category("Bone"), Browsable(false)]
        public int HeaderLen { get { return _headerLen; } }
        [Category("Bone"), Browsable(false)]
        public int MDL0Offset { get { return _mdl0Offset; } }
        [Category("Bone"), Browsable(false)]
        public int StringOffset { get { return _stringOffset; } }

        [Category("Bone")]
        public bool Visible
        {
            get { return _flags1.HasFlag(BoneFlags.Visible); }
            set
            {
                if (value)
                    _flags1 |= BoneFlags.Visible;
                else
                    _flags1 &= ~BoneFlags.Visible;
            }
        }
        [Category("Bone")]
        public bool SegScaleCompApply
        {
            get { return _flags1.HasFlag(BoneFlags.SegScaleCompApply); }
            set
            {
                if (value)
                    _flags1 |= BoneFlags.SegScaleCompApply;
                else
                    _flags1 &= ~BoneFlags.SegScaleCompApply;
            }
        }
        [Category("Bone")]
        public bool SegScaleCompParent
        {
            get { return _flags1.HasFlag(BoneFlags.SegScaleCompParent); }
            set
            {
                if (value)
                    _flags1 |= BoneFlags.SegScaleCompParent;
                else
                    _flags1 &= ~BoneFlags.SegScaleCompParent;
            }
        }
        [Category("Bone")]
        public bool ClassicScale
        {
            get { return !_flags1.HasFlag(BoneFlags.ClassicScaleOff); }
            set
            {
                if (!value)
                    _flags1 |= BoneFlags.ClassicScaleOff;
                else
                    _flags1 &= ~BoneFlags.ClassicScaleOff;
            }
        }
        public int _boneIndex;
        [Category("Bone")]
        public int BoneIndex { get { return _boneIndex; } }
        [Category("Bone"), Browsable(false)]
        public int NodeId { get { return _nodeIndex; } }
        [Category("Bone"), Browsable(false)]
        public BoneFlags Flags { get { return _flags1; } set { _flags1 = (BoneFlags)(int)value; SignalPropertyChange(); } }

        [Category("Bone")]
        public bool HasBillboardParent
        {
            get { return _flags1.HasFlag(BoneFlags.HasBillboardParent); }
            set
            {
                if (value)
                    _flags1 |= BoneFlags.HasBillboardParent;
                else
                    _flags1 &= ~BoneFlags.HasBillboardParent;
            }
        }
        [Category("Bone")]
        public BillboardFlags BillboardSetting 
        {
            get { return _flags2; } 
            set 
            {
                if (_flags2 != 0 && Model._billboardBones.Contains(this))
                    Model._billboardBones.Remove(this);
                _flags2 = (BillboardFlags)(int)value;
                if (_flags2 != 0 && _flags1.HasFlag(BoneFlags.HasGeometry) && !Model._billboardBones.Contains(this))
                    Model._billboardBones.Add(this);
                SignalPropertyChange();
            }
        }
        [Category("Bone")]
        public uint BillboardRefNodeId { get { return _bbNodeId; } set { _bbNodeId = value; SignalPropertyChange(); } }
        
        [Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Scale 
        {
            get { return _bindState._scale; } 
            set 
            {
                _bindState.Scale = value;

                if (value == new Vector3(1))
                    _flags1 |= BoneFlags.FixedScale;
                else
                    _flags1 &= ~BoneFlags.FixedScale;

                if (value._x == value._y && value._y == value._z)
                    _flags1 |= BoneFlags.ScaleEqual;
                else
                    _flags1 &= ~BoneFlags.ScaleEqual;

                //RecalcBindState();
                //Model.CalcBindMatrices();
                
                if (Parent is MDL0BoneNode)
                {
                    if ((BindMatrix == ((MDL0BoneNode)Parent).BindMatrix) && (InverseBindMatrix == ((MDL0BoneNode)Parent).InverseBindMatrix))
                        _flags1 |= BoneFlags.NoTransform;
                    else
                        _flags1 &= ~BoneFlags.NoTransform;
                }
                else if (BindMatrix == Matrix.Identity && InverseBindMatrix == Matrix.Identity)
                    _flags1 |= BoneFlags.NoTransform;
                else
                    _flags1 &= ~BoneFlags.NoTransform;

                SignalPropertyChange();
            }
        }

        //[Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        //public Quaternion QuaternionRotation { get { return _bindState._quaternion; } set { _bindState.QuaternionRotate = value; flagsChanged = true; SignalPropertyChange(); } }
        
        [Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Rotation 
        {
            get { return _bindState._rotate; }
            set
            {
                _bindState.Rotate = value;

                if (value == new Vector3())
                    _flags1 |= BoneFlags.FixedRotation;
                else
                    _flags1 &= ~BoneFlags.FixedRotation;

                //RecalcBindState();
                //Model.CalcBindMatrices();

                if (Parent is MDL0BoneNode)
                {
                    if ((BindMatrix == ((MDL0BoneNode)Parent).BindMatrix) && (InverseBindMatrix == ((MDL0BoneNode)Parent).InverseBindMatrix))
                        _flags1 |= BoneFlags.NoTransform;
                    else
                        _flags1 &= ~BoneFlags.NoTransform;
                }
                else if (BindMatrix == Matrix.Identity && InverseBindMatrix == Matrix.Identity)
                    _flags1 |= BoneFlags.NoTransform;
                else
                    _flags1 &= ~BoneFlags.NoTransform;

                SignalPropertyChange();
            }
        }
        [Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Translation 
        {
            get { return _bindState._translate; }
            set
            {
                _bindState.Translate = value;

                if (value == new Vector3())
                    _flags1 |= BoneFlags.FixedTranslation;
                else
                    _flags1 &= ~BoneFlags.FixedTranslation;

                //RecalcBindState();
                //Model.CalcBindMatrices();

                if (Parent is MDL0BoneNode)
                {
                    if ((BindMatrix == ((MDL0BoneNode)Parent).BindMatrix) && (InverseBindMatrix == ((MDL0BoneNode)Parent).InverseBindMatrix))
                        _flags1 |= BoneFlags.NoTransform;
                    else
                        _flags1 &= ~BoneFlags.NoTransform;
                }
                else if (BindMatrix == Matrix.Identity && InverseBindMatrix == Matrix.Identity)
                    _flags1 |= BoneFlags.NoTransform;
                else
                    _flags1 &= ~BoneFlags.NoTransform;

                SignalPropertyChange(); 
            }
        }

        [Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 BoxMin { get { return _bMin; } set { _bMin = value; SignalPropertyChange(); } }
        [Category("Bone"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 BoxMax { get { return _bMax; } set { _bMax = value; SignalPropertyChange(); } }

        //[Category("Bone")]
        //public int ParentOffset { get { return Header->_parentOffset / 0xD0; } }
        //[Category("Bone")]
        //public int FirstChildOffset { get { return Header->_firstChildOffset / 0xD0; } }
        //[Category("Bone")]
        //public int NextOffset { get { return Header->_nextOffset / 0xD0; } }
        //[Category("Bone")]
        //public int PrevOffset { get { return Header->_prevOffset / 0xD0; } }
        //[Category("Bone")]
        //public int Part2Offset { get { return Header->_part2Offset; } }

        //[Category("Kinect Settings"), Browsable(true)]
        //public SkeletonJoint Joint
        //{
        //    get { return _joint; }
        //    set { _joint = value; }
        //}
        //public SkeletonJoint _joint;

        [Category("User Data"), TypeConverter(typeof(ExpandableObjectCustomConverter))]
        public UserDataCollection UserEntries { get { return _userEntries; } set { _userEntries = value; SignalPropertyChange(); } }
        internal UserDataCollection _userEntries = new UserDataCollection();
        
        internal override void GetStrings(StringTable table)
        {
            table.Add(Name);

            foreach (MDL0BoneNode n in Children)
                n.GetStrings(table);

            foreach (UserDataClass s in _userEntries)
                table.Add(s._name);
        }

        //Initialize should only be called from parent group during parse.
        //Bones need not be imported/exported anyways
        protected override bool OnInitialize()
        {
            MDL0Bone* header = Header;

            SetSizeInternal(header->_headerLen);

            //Assign true parent using parent header offset
            int offset = header->_parentOffset;
            //Offsets are always < 0, because parent entries are listed before children
            if (offset < 0)
            {
                //Get address of parent header
                MDL0Bone* pHeader = (MDL0Bone*)((byte*)header + offset);
                //Search bone list for matching header
                foreach (MDL0BoneNode bone in _parent._children)
                    if (pHeader == bone.Header)
                    { _parent = bone; break; } //Assign parent and break
            }

            //Conditional name assignment
            if ((_name == null) && (header->_stringOffset != 0))
                _name = header->ResourceString;

            //Assign fields
            _flags1 = (BoneFlags)(uint)header->_flags;
            _flags2 = (BillboardFlags)(uint)header->_bbFlags;
            _bbNodeId = header->_bbNodeId;
            _nodeIndex = header->_nodeId;
            _boneIndex = header->_index;
            _headerLen = header->_headerLen;
            _mdl0Offset = header->_mdl0Offset;
            _stringOffset = header->_stringOffset;

            if (_flags2 != 0 && _flags1.HasFlag(BoneFlags.HasGeometry))
                Model._billboardBones.Add(this); //Update mesh in T-Pose

            _permanentID = header->_index;

            _bindState = _frameState = new FrameState(header->_scale, header->_rotation, header->_translation);
            (_bindState._quaternion = new Quaternion()).FromEuler(header->_rotation);
            _bindMatrix = _frameMatrix = header->_transform;
            _inverseBindMatrix = _inverseFrameMatrix = header->_transformInv;

            _bMin = header->_boxMin;
            _bMax = header->_boxMax;

            (_userEntries = new UserDataCollection()).Read(header->UserDataAddress);
            
            //We don't want to process children because not all have been parsed yet.
            //Child assigning will be handled by the parent group.
            return false;
        }

        //Use MoveRaw without processing children.
        //Prevents addresses from changing before completion.
        //internal override void MoveRaw(VoidPtr address, int length)
        //{
        //    Memory.Move(address, WorkingSource.Address, (uint)length);
        //    DataSource newsrc = new DataSource(address, length);
        //    if (_compression == CompressionType.None)
        //    {
        //        _replSrc.Close();
        //        _replUncompSrc.Close();
        //        _replSrc = _replUncompSrc = newsrc;
        //    }
        //    else
        //    {
        //        _replSrc.Close();
        //        _replSrc = newsrc;
        //    }
        //}

        protected override int OnCalculateSize(bool force)
        {
            int len = 0xD0;
            len += _userEntries.GetSize();
            return len;
        }

        public override void RemoveChild(ResourceNode child)
        {
            base.RemoveChild(child);
            Moved = true;
        }

        public void RecalcOffsets(MDL0Bone* header, VoidPtr address, int length)
        {
            MDL0BoneNode bone;
            int index = 0, offset;
            
            //Sub-entries
            if (_userEntries.Count > 0)
            {
                header->_userDataOffset = 0xD0;
                _userEntries.Write(address + 0xD0);
            }
            else
                header->_userDataOffset = 0;

            //Set first child
            if (_children.Count > 0)
                header->_firstChildOffset = length;
            else
                header->_firstChildOffset = 0;

            if (_parent != null)
            {
                index = _parent._children.IndexOf(this);

                //Parent
                if (_parent is MDL0BoneNode)
                    header->_parentOffset = (int)_parent.WorkingUncompressed.Address - (int)address;
                else
                    header->_parentOffset = 0;

                //Prev
                if (index == 0)
                    header->_prevOffset = 0;
                else
                {
                    //Link to prev
                    bone = _parent._children[index - 1] as MDL0BoneNode;
                    offset = (int)bone.Header - (int)address;
                    header->_prevOffset = offset;
                    bone.Header->_nextOffset = -offset;
                }

                //Next
                if (index == (_parent._children.Count - 1))
                    header->_nextOffset = 0;
            }
        }

        public void CalcFlags()
        {
            _flags1 = BoneFlags.Visible;

            if ((Scale._x == Scale._y) && (Scale._y == Scale._z))
                _flags1 += (int)BoneFlags.ScaleEqual;
            if (_refCount > 0)
                _flags1 += (int)BoneFlags.HasGeometry;
            if (Scale == new Vector3(1))
                _flags1 += (int)BoneFlags.FixedScale;
            if (Rotation == new Vector3(0))
                _flags1 += (int)BoneFlags.FixedRotation;
            if (Translation == new Vector3(0))
                _flags1 += (int)BoneFlags.FixedTranslation;

            if (Parent is MDL0BoneNode)
            {
                if ((BindMatrix == ((MDL0BoneNode)Parent).BindMatrix) && (InverseBindMatrix == ((MDL0BoneNode)Parent).InverseBindMatrix))
                    _flags1 += (int)BoneFlags.NoTransform;
            }
            else if (BindMatrix == Matrix.Identity && InverseBindMatrix == Matrix.Identity)
                _flags1 += (int)BoneFlags.NoTransform;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            MDL0Bone* header = (MDL0Bone*)address;

            RecalcOffsets(header, address, length);

            if (_refCount > 0 || InfluencedObjects.Length > 0)
                _flags1 |= BoneFlags.HasGeometry;
            else
                _flags1 &= ~BoneFlags.HasGeometry;

            header->_headerLen = length;
            header->_index = _boneIndex = _entryIndex;
            header->_nodeId = _nodeIndex;
            header->_flags = (uint)_flags1;
            header->_bbFlags = (uint)_flags2;
            header->_bbNodeId = _bbNodeId;
            header->_scale = _bindState._scale;
            header->_rotation = _bindState._rotate;
            header->_translation = _bindState._translate;
            header->_boxMin = _bMin;
            header->_boxMax = _bMax;
            header->_transform = (bMatrix43)_bindMatrix;
            header->_transformInv = (bMatrix43)_inverseBindMatrix;

            _moved = false;
        }

        protected internal override void PostProcess(VoidPtr mdlAddress, VoidPtr dataAddress, StringTable stringTable)
        {
            MDL0Bone* header = (MDL0Bone*)dataAddress;
            header->_mdl0Offset = (int)mdlAddress - (int)dataAddress;
            header->_stringOffset = (int)stringTable[Name] + 4 - (int)dataAddress;

            _userEntries.PostProcess(dataAddress + 0xD0, stringTable);
        }

        //internal void GetBindState()
        //{
        //    if (_parent is MDL0BoneNode)
        //    {
        //        _bindState._transform = _bindMatrix / ((MDL0BoneNode)_parent)._bindMatrix;
        //        _bindState._iTransform = _inverseBindMatrix / ((MDL0BoneNode)_parent)._inverseBindMatrix;
        //    }
        //    else
        //    {
        //        _bindState._transform = _bindMatrix;
        //        _bindState._iTransform = _inverseBindMatrix;
        //    }

        //    foreach (MDL0BoneNode bone in Children)
        //        bone.GetBindState();
        //}

        //public Vector3 WorldPosition { get { return _frameMatrix * new Vector3(); } }
        //public FrameState LocalState
        //{
        //    get 
        //    {
        //        return Parent is MDL0BoneNode ? (((MDL0BoneNode)Parent)._inverseFrameMatrix * _frameMatrix).Derive() : _frameState;
        //    }
        //}
        //public FrameState WorldState
        //{
        //    get
        //    {
        //        return Parent is MDL0BoneNode ? (((MDL0BoneNode)Parent)._frameMatrix * _inverseFrameMatrix).Derive() : _frameState;
        //    }
        //}

        //Change has been made to bind state, need to recalculate matrices
        internal void RecalcBindState()
        {
            if (_parent is MDL0BoneNode)
            {
                _bindMatrix = ((MDL0BoneNode)_parent)._bindMatrix * _bindState._transform;
                _inverseBindMatrix = _bindState._iTransform * ((MDL0BoneNode)_parent)._inverseBindMatrix;
            }
            else
            {
                _bindMatrix = _bindState._transform;
                _inverseBindMatrix = _bindState._iTransform;
            }
            
            foreach (MDL0BoneNode bone in Children)
                bone.RecalcBindState();
        }
        internal void RecalcFrameState()
        {
            if (_parent is MDL0BoneNode)
            {
                _frameMatrix = ((MDL0BoneNode)_parent)._frameMatrix * _frameState._transform;
                _inverseFrameMatrix = _frameState._iTransform * ((MDL0BoneNode)_parent)._inverseFrameMatrix;

                //_frameMatrix = ((MDL0BoneNode)_parent)._frameMatrix * _frameState._quatTransform;
                //_inverseFrameMatrix = _frameState._quatiTransform * ((MDL0BoneNode)_parent)._inverseFrameMatrix;
            }
            else
            {
                _frameMatrix = _frameState._transform;
                _inverseFrameMatrix = _frameState._iTransform;

                //_frameMatrix = _frameState._quatTransform;
                //_inverseFrameMatrix = _frameState._quatiTransform;
            }
            MuliplyRotation();
            foreach (MDL0BoneNode bone in Children)
                bone.RecalcFrameState();
        }

        public void MuliplyRotation()
        {
            if (Model._mainWindow != null)
            {
                Vector3 center = _frameMatrix.GetPoint();
                Vector3 cam = Model._mainWindow.modelPanel1._camera.GetPoint();
                Vector3 scale = new Vector3(1);
                Vector3 rot = new Vector3();
                Vector3 trans = new Vector3();

                if (BillboardSetting == BillboardFlags.PerspectiveSTD)
                    rot = center.LookatAngles(cam) * Maths._rad2degf;

                _frameMatrix *= Matrix.TransformMatrix(scale, rot, trans);
                _inverseFrameMatrix *= Matrix.ReverseTransformMatrix(scale, rot, trans);
            }

            //foreach (MDL0BoneNode bone in Children)
            //    bone.MuliplyRotation();
        }

        internal unsafe List<MDL0BoneNode> ChildTree(List<MDL0BoneNode> list)
        {
            list.Add(this);
            foreach (MDL0BoneNode c in _children)
                c.ChildTree(list);
            
            return list;
        }

        internal Vector3 RecursiveScale()
        {
            if (_parent is MDL0GroupNode)
                return _frameState._scale;
            
            return _frameState._scale * ((MDL0BoneNode)_parent).RecursiveScale();
        }

        #region Rendering

        public static Color DefaultBoneColor = Color.FromArgb(0, 0, 128);
        public static Color DefaultNodeColor = Color.FromArgb(0, 128, 0);

        internal Color _boneColor = Color.Transparent;
        internal Color _nodeColor = Color.Transparent;

        public const float _nodeRadius = 0.20f;

        public bool _render = true;
        internal unsafe void Render(TKContext ctx, ModelEditControl _mainWindow)
        {
            if (!_render)
                return;

            if (_boneColor != Color.Transparent)
                GL.Color4(_boneColor.R, _boneColor.G, _boneColor.B, _boneColor.A);
            else
                GL.Color4(DefaultBoneColor.R, DefaultBoneColor.G, DefaultBoneColor.B, DefaultBoneColor.A);

            Vector3 v = _frameState._translate;

            GL.Begin(BeginMode.Lines);

            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3((float*)&v);

            GL.End();

            GL.PushMatrix();

            GL.Translate(v._x, v._y, v._z);

            //Render node
            GLDisplayList ndl = ctx.FindOrCreate<GLDisplayList>("BoneNodeOrb", CreateNodeOrb);
            if (_nodeColor != Color.Transparent)
                GL.Color4(_nodeColor.R, _nodeColor.G, _nodeColor.B, _nodeColor.A);
            else
                GL.Color4(DefaultNodeColor.R, DefaultNodeColor.G, DefaultNodeColor.B, DefaultNodeColor.A);
            
            ndl.Call();
            
            DrawNodeOrients();

            GL.Translate(-v._x, -v._y, -v._z);

            //Transform Bones
            fixed (Matrix* m = &_frameState._transform)
                GL.MultMatrix((float*)m);

            if (BillboardSetting != 0)
            {
                Vector3 center = _frameMatrix.GetPoint();
                Vector3 cam = _mainWindow.modelPanel1._camera.GetPoint();
                Matrix m2 = new Matrix();
                Vector3 scale = new Vector3(1);
                Vector3 rot = new Vector3();
                Vector3 trans = new Vector3();

                if (BillboardSetting == BillboardFlags.PerspectiveSTD)
                    rot = center.LookatAngles(cam) * Maths._rad2degf;

                m2 = Matrix.TransformMatrix(scale, rot, trans);
                GL.PushMatrix();
                GL.MultMatrix((float*)&m2);
            }

            //Render children
            foreach (MDL0BoneNode n in Children)
                n.Render(ctx, _mainWindow);

            if (BillboardSetting != 0)
                GL.PopMatrix();

            GL.PopMatrix();
        }

        internal void ApplyCHR0(CHR0Node node, int index)
        {
            CHR0EntryNode e;

            if ((node == null) || (index == 0)) //Reset to bind pose
                _frameState = _bindState;
            else if ((e = node.FindChild(Name, false) as CHR0EntryNode) != null) //Set to anim pose
                _frameState = new FrameState(e.GetAnimFrame(index - 1));
            else //Set to neutral pose
                _frameState = _bindState;

            foreach (MDL0BoneNode b in Children)
                b.ApplyCHR0(node, index);
        }

        public static GLDisplayList CreateNodeOrb(TKContext ctx)
        {
            GLDisplayList circle = ctx.GetRingList();
            GLDisplayList orb = new GLDisplayList();

            orb.Begin();
            GL.PushMatrix();

            GL.Scale(_nodeRadius, _nodeRadius, _nodeRadius);
            circle.Call();
            GL.Rotate(90.0f, 0.0f, 1.0f, 0.0f);
            circle.Call();
            GL.Rotate(90.0f, 1.0f, 0.0f, 0.0f);
            circle.Call();

            GL.PopMatrix();
            orb.End();
            return orb;
        }

        public static void DrawNodeOrients()
        {
            GL.Begin(BeginMode.Lines);

            GL.Color4(1.0f, 0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(_nodeRadius * 2, 0.0f, 0.0f);

            GL.Color4(0.0f, 1.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, _nodeRadius * 2, 0.0f);

            GL.Color4(0.0f, 0.0f, 1.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, _nodeRadius * 2);

            GL.End();
        }

        internal override void Bind(TKContext ctx)
        {
            _render = true;
            _boneColor = Color.Transparent;
            _nodeColor = Color.Transparent;
        }

        #endregion
    }
}
