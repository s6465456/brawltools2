using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.Imaging;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class REFFNode : ARCEntryNode
    {
        internal REFF* Header { get { return (REFF*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.REFF; } }

        private int _unk1, _unk2, _unk3, _dataLen, _dataOff;
        private int _TableLen;
        private short _TableEntries;
        private short _TableUnk1;

        [Category("REFF Data")]
        public int DataLength { get { return _dataLen; } }
        [Category("REFF Data")]
        public int DataOffset { get { return _dataOff; } }
        [Category("REFF Data")]
        public int Unknown1 { get { return _unk1; } set { _unk1 = value; SignalPropertyChange(); } }
        [Category("REFF Data")]
        public int Unknown2 { get { return _unk2; } set { _unk2 = value; SignalPropertyChange(); } }
        [Category("REFF Data")]
        public int Unknown3 { get { return _unk3; } set { _unk3 = value; SignalPropertyChange(); } }

        [Category("REFF Object Table")]
        public int Length { get { return _TableLen; } }
        [Category("REFF Object Table")]
        public short NumEntries { get { return _TableEntries; } }
        [Category("REFF Object Table")]
        public short Unk1 { get { return _TableUnk1; } set { _TableUnk1 = value; SignalPropertyChange(); } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            REFF* header = Header;

            _name = header->IdString;
            _dataLen = header->_dataLength;
            _dataOff = header->_dataOffset;
            _unk1 = header->_unk1;
            _unk2 = header->_unk2;
            _unk3 = header->_unk3;

            REFTypeObjectTable* objTable = header->Table;
            _TableLen = (int)objTable->_length;
            _TableEntries = (short)objTable->_entries;
            _TableUnk1 = (short)objTable->_unk1;

            return header->Table->_entries > 0;
        }

        protected override void OnPopulate()
        {
            REFTypeObjectTable* table = Header->Table;
            REFTypeObjectEntry* Entry = table->First;
            for (int i = 0; i < table->_entries; i++, Entry = Entry->Next)
                new REFFEntryNode() { _name = Entry->Name, _offset = (int)Entry->DataOffset, _length = (int)Entry->DataLength }.Initialize(this, new DataSource((byte*)table->Address + Entry->DataOffset, (int)Entry->DataLength));
        }
        int tableLen = 0;
        protected override int OnCalculateSize(bool force)
        {
            int size = 0x60;
            tableLen = 0x9;
            foreach (ResourceNode n in Children)
            {
                tableLen += n.Name.Length + 11;
                size += n.CalculateSize(force);
            }
            return size + (tableLen = tableLen.Align(4));
        }
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            REFF* header = (REFF*)address;
            header->_unk1 = 0;
            header->_unk2 = 0;
            header->_unk3 = 0;
            header->_dataLength = length - 0x18;
            header->_dataOffset = 0x48;
            header->_header._tag = header->_tag = REFF.Tag;
            header->_header._endian = -2;
            header->_header._version = 0x0700;
            header->_header._firstOffset = 0x10;
            header->_header._numEntries = 1;
            header->IdString = Name;

            REFTypeObjectTable* table = (REFTypeObjectTable*)((byte*)header + header->_dataOffset + 0x18);
            table->_entries = (short)Children.Count;
            table->_unk1 = 0;
            table->_length = tableLen;

            REFTypeObjectEntry* entry = table->First;
            int offset = tableLen;
            foreach (ResourceNode n in Children)
            {
                entry->Name = n.Name;
                entry->DataOffset = offset;
                entry->DataLength = n._calcSize - 0x20;
                n.Rebuild((VoidPtr)table + offset, n._calcSize, force);
                offset += n._calcSize;
                entry = entry->Next;
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((REFF*)source.Address)->_tag == REFF.Tag ? new REFFNode() : null; }
    }
    public unsafe class REFFEntryNode : ResourceNode
    {
        internal REFFDataHeader* Header { get { return (REFFDataHeader*)WorkingUncompressed.Address; } }

        [Category("REFF Entry")]
        public int REFFOffset { get { return _offset; } }
        [Category("REFF Entry")]
        public int DataLength { get { return _length; } }

        public int _offset;
        public int _length;

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            return true;
        }

        protected override void OnPopulate()
        {
            new REFFEmitterNode().Initialize(this, (VoidPtr)Header + 8, (int)Header->_headerSize);
            new REFFParticleNode().Initialize(this, (VoidPtr)Header->_params, (int)Header->_params->headersize);
            new REFFPostFieldInfoListNode()
            {
                _ptclTrackCount = *Header->_ptclTrackCount,
                _ptclInitTrackCount = *Header->_ptclInitTrackCount,
                _emitTrackCount = *Header->_emitTrackCount,
                _emitInitTrackCount = *Header->_emitInitTrackCount,
                _ptclTrackAddr = Header->_ptclTrack,
                _emitTrackAddr = Header->_emitTrack,
            }
            .Initialize(this, Header->_postFieldInfo, WorkingUncompressed.Length - ((int)Header->_postFieldInfo - (int)Header));
        }
    }

    public unsafe class REFFPostFieldInfoListNode : ResourceNode
    {
        internal VoidPtr First { get { return (VoidPtr)WorkingUncompressed.Address; } }
        public short _ptclTrackCount, _ptclInitTrackCount, _emitTrackCount, _emitInitTrackCount;
        public buint* _ptclTrackAddr, _emitTrackAddr;
        public List<uint> _ptclTrack, _emitTrack;

        [Category("Post Field Info Table")]
        public short PtclTrackCount { get { return _ptclTrackCount; } }
        [Category("Post Field Info Table")]
        public short PtclInitTrackCount { get { return _ptclInitTrackCount; } }
        [Category("Post Field Info Table")]
        public short EmitTrackCount { get { return _emitTrackCount; } }
        [Category("Post Field Info Table")]
        public short EmitInitTrackCount { get { return _emitInitTrackCount; } }

        protected override bool OnInitialize()
        {
            _name = "Animations";

            return PtclTrackCount > 0 || EmitTrackCount > 0;
        }

        protected override void OnPopulate()
        {
            int offset = 0;
            buint* addr = _ptclTrackAddr;
            addr += PtclTrackCount; //skip nulled pointers to size list
            for (int i = 0; i < PtclTrackCount; i++)
            {
                new REFFAnimationNode().Initialize(this, First + offset, (int)*addr);
                offset += (int)*addr++;
            }
        }
    }
    public unsafe class REFFAnimationNode : ResourceNode
    {
        internal AnimCurveHeader* Header { get { return (AnimCurveHeader*)WorkingUncompressed.Address; } }

        AnimCurveHeader hdr;

        [Category("Animation")]
        public byte Magic { get { return hdr.magic; } }
        [Category("Animation")]
        public byte KindType { get { return hdr.kindType; } }
        [Category("Animation")]
        public AnimCurveType CurveFlag { get { return (AnimCurveType)hdr.curveFlag; } }
        [Category("Animation")]
        public byte KindEnable { get { return hdr.kindEnable; } }
        [Category("Animation")]
        public AnimCurveHeaderProcessFlagType ProcessFlag { get { return (AnimCurveHeaderProcessFlagType)hdr.processFlag; } }
        [Category("Animation")]
        public byte LoopCount { get { return hdr.loopCount; } }

        [Category("Animation")]
        public ushort RandomSeed { get { return hdr.randomSeed; } }
        [Category("Animation")]
        public ushort FrameLength { get { return hdr.frameLength; } }
        [Category("Animation")]
        public ushort Padding { get { return hdr.padding; } }

        [Category("Animation")]
        public uint KeyTableSize { get { return hdr.keyTable; } }
        [Category("Animation")]
        public uint RangeTableSize { get { return hdr.rangeTable; } }
        [Category("Animation")]
        public uint RandomTableSize { get { return hdr.randomTable; } }
        [Category("Animation")]
        public uint NameTableSize { get { return hdr.nameTable; } }
        [Category("Animation")]
        public uint InfoTableSize { get { return hdr.infoTable; } }

        Random random = null;

        protected override bool OnInitialize()
        {
            hdr = *Header;
            _name = "AnimCurve" + Index;
            random = new Random(RandomSeed);
            if (CurveFlag == AnimCurveType.EmitterFloat || CurveFlag == AnimCurveType.Field || CurveFlag == AnimCurveType.PostField)
                MessageBox.Show(TreePath);
            return KeyTableSize > 4 || RangeTableSize > 4 || RandomTableSize > 4 || NameTableSize > 4 || InfoTableSize > 4;
        }

        protected override void OnPopulate()
        {
            if (KeyTableSize > 4)
                new REFFAnimCurveTableNode() { _name = "Key Table" }.Initialize(this, (VoidPtr)Header + 0x20, (int)KeyTableSize);
            if (RangeTableSize > 4)
                new REFFAnimCurveTableNode() { _name = "Range Table" }.Initialize(this, (VoidPtr)Header + 0x20 + KeyTableSize, (int)RangeTableSize);
            if (RandomTableSize > 4)
                new REFFAnimCurveTableNode() { _name = "Random Table" }.Initialize(this, (VoidPtr)Header + 0x20 + KeyTableSize + RangeTableSize, (int)RandomTableSize);
            if (NameTableSize > 4)
                new REFFAnimCurveNameTableNode() { _name = "Name Table" }.Initialize(this, (VoidPtr)Header + 0x20 + KeyTableSize + RangeTableSize + RandomTableSize, (int)NameTableSize);
            if (InfoTableSize > 4)
                new REFFAnimCurveTableNode() { _name = "Info Table" }.Initialize(this, (VoidPtr)Header + 0x20 + KeyTableSize + RangeTableSize + RandomTableSize + NameTableSize, (int)InfoTableSize);
        }
    }

    public unsafe class REFFAnimCurveNameTableNode : ResourceNode
    {
        internal AnimCurveTableHeader* Header { get { return (AnimCurveTableHeader*)WorkingUncompressed.Address; } }

        [Category("Name Table")]
        public string[] Names { get { return _names.ToArray(); } set { _names = value.ToList<string>(); SignalPropertyChange(); } }
        public List<string> _names = new List<string>();

        protected override bool OnInitialize()
        {
            _name = "Name Table";
            _names = new List<string>();
            bushort* addr = (bushort*)((VoidPtr)Header + 4 + Header->count * 4);
            for (int i = 0; i < Header->count; i++)
            {
                _names.Add(new String((sbyte*)addr + 2));
                addr = (bushort*)((VoidPtr)addr + 2 + *addr);
            }

            return false;
        }
    }

    public unsafe class REFFAnimCurveTableNode : ResourceNode
    {
        internal AnimCurveTableHeader* Header { get { return (AnimCurveTableHeader*)WorkingUncompressed.Address; } }

        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = "Table" + Index;
            return Header->count > 0;
        }

        protected override void OnPopulate()
        {
            VoidPtr addr = (VoidPtr)Header + 4;
            int s = (WorkingUncompressed.Length - 4) / Header->count;
            for (int i = 0; i < Header->count; i++)
                new MoveDefSectionParamNode() { _name = "Entry" + i }.Initialize(this, (VoidPtr)Header + 4 + i * s, s);
        }
    }

    public unsafe class REFFPostFieldInfoNode : ResourceNode
    {
        internal PostFieldInfo* Header { get { return (PostFieldInfo*)WorkingUncompressed.Address; } }

        PostFieldInfo hdr;

        [Category("Post Field Info")]
        public Vector3 Scale { get { return hdr.mAnimatableParams.mSize; } }
        [Category("Post Field Info")]
        public Vector3 Rotation { get { return hdr.mAnimatableParams.mRotate; } }
        [Category("Post Field Info")]
        public Vector3 Translation { get { return hdr.mAnimatableParams.mTranslate; } }
        [Category("Post Field Info")]
        public float ReferenceSpeed { get { return hdr.mReferenceSpeed; } }
        [Category("Post Field Info")]
        public PostFieldInfo.ControlSpeedType ControlSpeedType { get { return (PostFieldInfo.ControlSpeedType)hdr.mControlSpeedType; } }
        [Category("Post Field Info")]
        public PostFieldInfo.CollisionShapeType CollisionShapeType { get { return (PostFieldInfo.CollisionShapeType)hdr.mCollisionShapeType; } }
        [Category("Post Field Info")]
        public PostFieldInfo.ShapeOption ShapeOption { get { return CollisionShapeType == PostFieldInfo.CollisionShapeType.Sphere || CollisionShapeType == PostFieldInfo.CollisionShapeType.Plane ? (PostFieldInfo.ShapeOption)(((int)CollisionShapeType << 2) | hdr.mCollisionShapeOption) : PostFieldInfo.ShapeOption.None; } }
        [Category("Post Field Info")]
        public PostFieldInfo.CollisionType CollisionType { get { return (PostFieldInfo.CollisionType)hdr.mCollisionType; } }
        [Category("Post Field Info")]
        public PostFieldInfo.CollisionOption CollisionOption { get { return (PostFieldInfo.CollisionOption)(short)hdr.mCollisionOption; } }
        [Category("Post Field Info")]
        public ushort StartFrame { get { return hdr.mStartFrame; } }
        [Category("Post Field Info")]
        public Vector3 SpeedFactor { get { return hdr.mSpeedFactor; } }

        protected override bool OnInitialize()
        {
            _name = "Entry" + Index;
            hdr = *Header;
            return false;
        }

        protected override void OnPopulate()
        {
            base.OnPopulate();
        }
    }

    public unsafe class REFFParticleNode : ResourceNode
    {
        internal ParticleParameterHeader* Params { get { return (ParticleParameterHeader*)WorkingUncompressed.Address; } }

        ParticleParameterHeader hdr;
        ParticleParameterDesc desc;

        //[Category("Particle Parameters")]
        //public uint HeaderSize { get { return hdr.headersize; } }

        [Category("Particle Parameters"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel mColor11 { get { return desc.mColor11; } set { desc.mColor11 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel mColor12 { get { return desc.mColor12; } set { desc.mColor12 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel mColor21 { get { return desc.mColor21; } set { desc.mColor21 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel mColor22 { get { return desc.mColor22; } set { desc.mColor22 = value; SignalPropertyChange(); } }

        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 Size { get { return desc.size; } set { desc.size = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 Scale { get { return desc.scale; } set { desc.scale = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 Rotate { get { return desc.rotate; } set { desc.rotate = value; SignalPropertyChange(); } }

        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureScale1 { get { return desc.textureScale1; } set { desc.textureScale1 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureScale2 { get { return desc.textureScale2; } set { desc.textureScale2 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureScale3 { get { return desc.textureScale3; } set { desc.textureScale3 = value; SignalPropertyChange(); } }

        [Category("Particle Parameters"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 TextureRotate { get { return desc.textureRotate; } set { desc.textureRotate = value; SignalPropertyChange(); } }

        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureTranslate1 { get { return desc.textureTranslate1; } set { desc.textureTranslate1 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureTranslate2 { get { return desc.textureTranslate2; } set { desc.textureTranslate2 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters"), TypeConverter(typeof(Vector2StringConverter))]
        public Vector2 TextureTranslate3 { get { return desc.textureTranslate3; } set { desc.textureTranslate3 = value; SignalPropertyChange(); } }

        [Category("Particle Parameters")]
        public ushort TextureWrap { get { return desc.textureWrap; } set { desc.textureWrap = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public byte TextureReverse { get { return desc.textureReverse; } set { desc.textureReverse = value; SignalPropertyChange(); } }

        [Category("Particle Parameters")]
        public byte mACmpRef0 { get { return desc.mACmpRef0; } set { desc.mACmpRef0 = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public byte mACmpRef1 { get { return desc.mACmpRef1; } set { desc.mACmpRef1 = value; SignalPropertyChange(); } }

        [Category("Particle Parameters")]
        public byte RotateOffsetRandom1 { get { return desc.rotateOffsetRandomX; } set { desc.rotateOffsetRandomX = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public byte RotateOffsetRandom2 { get { return desc.rotateOffsetRandomY; } set { desc.rotateOffsetRandomY = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public byte RotateOffsetRandom3 { get { return desc.rotateOffsetRandomZ; } set { desc.rotateOffsetRandomZ = value; SignalPropertyChange(); } }

        [Category("Particle Parameters"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 RotateOffset { get { return desc.rotateOffset; } set { desc.rotateOffset = value; SignalPropertyChange(); } }

        [Category("Particle Parameters")]
        public string Texture1Name { get { return _textureNames[0]; } set { _textureNames[0] = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public string Texture2Name { get { return _textureNames[1]; } set { _textureNames[1] = value; SignalPropertyChange(); } }
        [Category("Particle Parameters")]
        public string Texture3Name { get { return _textureNames[2]; } set { _textureNames[2] = value; SignalPropertyChange(); } }

        public List<string> _textureNames = new List<string>(3);

        protected override bool OnInitialize()
        {
            _name = "Particle";
            hdr = *Params;
            desc = hdr.paramDesc;

            VoidPtr addr = Params->paramDesc.textureNames.Address;
            for (int i = 0; i < 3; i++)
            {
                if (*(bushort*)addr > 1)
                    _textureNames.Add(new String((sbyte*)(addr + 2)));
                else
                    _textureNames.Add(null);
                addr += 2 + *(bushort*)addr;
            }

            return false;
        }
    }
    public unsafe class REFFEmitterNode : ResourceNode
    {
        internal EmitterDesc* Descriptor { get { return (EmitterDesc*)WorkingUncompressed.Address; } }

        EmitterDesc desc;

        [Category("Emitter Descriptor")]
        public EmitterDesc.EmitterCommonFlag CommonFlag { get { return (EmitterDesc.EmitterCommonFlag)(uint)desc.commonFlag; } set { desc.commonFlag = (uint)value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public uint emitFlag { get { return desc.emitFlag; } set { desc.emitFlag = value; SignalPropertyChange(); } } // EmitFormType - value & 0xFF
        [Category("Emitter Descriptor")]
        public ushort emitLife { get { return desc.emitLife; } set { desc.emitLife = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public ushort ptclLife { get { return desc.ptclLife; } set { desc.ptclLife = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public sbyte ptclLifeRandom { get { return desc.ptclLifeRandom; } set { desc.ptclLifeRandom = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public sbyte inheritChildPtclTranslate { get { return desc.inheritChildPtclTranslate; } set { desc.inheritChildPtclTranslate = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor")]
        public sbyte emitEmitIntervalRandom { get { return desc.emitEmitIntervalRandom; } set { desc.emitEmitIntervalRandom = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public sbyte emitEmitRandom { get { return desc.emitEmitRandom; } set { desc.emitEmitRandom = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float emitEmit { get { return desc.emitEmit; } set { desc.emitEmit = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public ushort emitEmitStart { get { return desc.emitEmitStart; } set { desc.emitEmitStart = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public ushort emitEmitPast { get { return desc.emitEmitPast; } set { desc.emitEmitPast = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public ushort emitEmitInterval { get { return desc.emitEmitInterval; } set { desc.emitEmitInterval = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor")]
        public sbyte inheritPtclTranslate { get { return desc.inheritPtclTranslate; } set { desc.inheritPtclTranslate = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public sbyte inheritChildEmitTranslate { get { return desc.inheritChildEmitTranslate; } set { desc.inheritChildEmitTranslate = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor")]
        public float commonParam1 { get { return desc.commonParam1; } set { desc.commonParam1 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float commonParam2 { get { return desc.commonParam2; } set { desc.commonParam2 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float commonParam3 { get { return desc.commonParam3; } set { desc.commonParam3 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float commonParam4 { get { return desc.commonParam4; } set { desc.commonParam4 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float commonParam5 { get { return desc.commonParam5; } set { desc.commonParam5 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float commonParam6 { get { return desc.commonParam6; } set { desc.commonParam6 = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public ushort emitEmitDiv { get { return desc.emitEmitDiv; } set { desc.emitEmitDiv = value; SignalPropertyChange(); } } //aka orig tick

        [Category("Emitter Descriptor")]
        public sbyte velInitVelocityRandom { get { return desc.velInitVelocityRandom; } set { desc.velInitVelocityRandom = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public sbyte velMomentumRandom { get { return desc.velMomentumRandom; } set { desc.velMomentumRandom = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velPowerRadiationDir { get { return desc.velPowerRadiationDir; } set { desc.velPowerRadiationDir = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velPowerYAxis { get { return desc.velPowerYAxis; } set { desc.velPowerYAxis = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velPowerRandomDir { get { return desc.velPowerRandomDir; } set { desc.velPowerRandomDir = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velPowerNormalDir { get { return desc.velPowerNormalDir; } set { desc.velPowerNormalDir = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velDiffusionEmitterNormal { get { return desc.velDiffusionEmitterNormal; } set { desc.velDiffusionEmitterNormal = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velPowerSpecDir { get { return desc.velPowerSpecDir; } set { desc.velPowerSpecDir = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public float velDiffusionSpecDir { get { return desc.velDiffusionSpecDir; } set { desc.velDiffusionSpecDir = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 velSpecDir { get { return desc.velSpecDir; } set { desc.velSpecDir = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 scale { get { return desc.scale; } set { desc.scale = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 rotate { get { return desc.rotate; } set { desc.rotate = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor"), TypeConverter(typeof(Vector3StringConverter))]
        public Vector3 translate { get { return desc.translate; } set { desc.translate = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor")]
        public byte lodNear { get { return desc.lodNear; } set { desc.lodNear = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public byte lodFar { get { return desc.lodFar; } set { desc.lodFar = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public byte lodMinEmit { get { return desc.lodMinEmit; } set { desc.lodMinEmit = value; SignalPropertyChange(); } }
        [Category("Emitter Descriptor")]
        public byte lodAlpha { get { return desc.lodAlpha; } set { desc.lodAlpha = value; SignalPropertyChange(); } }

        [Category("Emitter Descriptor")]
        public uint randomSeed { get { return desc.randomSeed; } set { desc.randomSeed = value; SignalPropertyChange(); } }

        //[Category("Emitter Descriptor")]
        //public byte userdata1 { get { fixed (byte* dat = desc.userdata) return dat[0]; } set { fixed (byte* dat = desc.userdata) dat[0] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata2 { get { fixed (byte* dat = desc.userdata) return dat[1]; } set { fixed (byte* dat = desc.userdata) dat[1] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata3 { get { fixed (byte* dat = desc.userdata) return dat[2]; } set { fixed (byte* dat = desc.userdata) dat[2] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata4 { get { fixed (byte* dat = desc.userdata) return dat[3]; } set { fixed (byte* dat = desc.userdata) dat[3] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata5 { get { fixed (byte* dat = desc.userdata) return dat[4]; } set { fixed (byte* dat = desc.userdata) dat[4] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata6 { get { fixed (byte* dat = desc.userdata) return dat[5]; } set { fixed (byte* dat = desc.userdata) dat[5] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata7 { get { fixed (byte* dat = desc.userdata) return dat[6]; } set { fixed (byte* dat = desc.userdata) dat[6] = value; SignalPropertyChange(); } }
        //[Category("Emitter Descriptor")]
        //public byte userdata8 { get { fixed (byte* dat = desc.userdata) return dat[7]; } set { fixed (byte* dat = desc.userdata) dat[7] = value; SignalPropertyChange(); } }

        #region Draw Settings

        public EmitterDrawSetting.DrawFlag mFlags;

        public byte mACmpComp0;
        public byte mACmpComp1;
        public byte mACmpOp;

        public byte mNumTevs;
        public byte mFlagClamp;

        public EmitterDrawSetting.IndirectTargetStage mIndirectTargetStage;

        public byte cmA;
        public byte cmB;
        public byte cmC;
        public byte cmD;

        public byte amA;
        public byte amB;
        public byte amC;
        public byte amD;

        public byte mTevTexture1;
        public byte mTevTexture2;
        public byte mTevTexture3;
        public byte mTevTexture4;

        public byte c1mA;
        public byte c1mB;
        public byte c1mC;
        public byte c1mD;

        public byte c2mA;
        public byte c2mB;
        public byte c2mC;
        public byte c2mD;

        public byte c3mA;
        public byte c3mB;
        public byte c3mC;
        public byte c3mD;

        public byte c4mA;
        public byte c4mB;
        public byte c4mC;
        public byte c4mD;

        public byte c1mOp;
        public byte c1mBias;
        public byte c1mScale;
        public byte c1mClamp;
        public byte c1mOutReg;

        public byte c2mOp;
        public byte c2mBias;
        public byte c2mScale;
        public byte c2mClamp;
        public byte c2mOutReg;

        public byte c3mOp;
        public byte c3mBias;
        public byte c3mScale;
        public byte c3mClamp;
        public byte c3mOutReg;

        public byte c4mOp;
        public byte c4mBias;
        public byte c4mScale;
        public byte c4mClamp;
        public byte c4mOutReg;

        public byte a1mA;
        public byte a1mB;
        public byte a1mC;
        public byte a1mD;

        public byte a2mA;
        public byte a2mB;
        public byte a2mC;
        public byte a2mD;

        public byte a3mA;
        public byte a3mB;
        public byte a3mC;
        public byte a3mD;

        public byte a4mA;
        public byte a4mB;
        public byte a4mC;
        public byte a4mD;

        public byte a1mOp;
        public byte a1mBias;
        public byte a1mScale;
        public byte a1mClamp;
        public byte a1mOutReg;

        public byte a2mOp;
        public byte a2mBias;
        public byte a2mScale;
        public byte a2mClamp;
        public byte a2mOutReg;

        public byte a3mOp;
        public byte a3mBias;
        public byte a3mScale;
        public byte a3mClamp;
        public byte a3mOutReg;

        public byte a4mOp;
        public byte a4mBias;
        public byte a4mScale;
        public byte a4mClamp;
        public byte a4mOutReg;

        //public fixed byte mTevKColorSel[4];
        //public fixed byte mTevKAlphaSel[4];

        //BlendMode
        public byte mType;
        public byte mSrcFactor;
        public byte mDstFactor;
        public byte mOp;

        //Color
        public byte cmRasColor;
        //public fixed byte cmTevColor[3];
        //public fixed byte cmTevKColor[4];
        //Alpha
        public byte amRasColor;
        //public fixed byte amTevColor[3];
        //public fixed byte amTevKColor[4];

        public byte mZCompareFunc;
        public byte mAlphaFlickType;
        public ushort mAlphaFlickCycle;
        public byte mAlphaFlickRandom;
        public byte mAlphaFlickAmplitude;

        //mLighting 
        public byte mMode;
        public byte mlType;
        public RGBAPixel mAmbient;
        public RGBAPixel mDiffuse;
        public float mRadius;
        public Vector3 mPosition;

        //public fixed float mIndTexOffsetMtx[6]; //2x3 Matrix
        public sbyte mIndTexScaleExp;
        public sbyte pivotX;
        public sbyte pivotY;
        public byte padding;
        public byte ptcltype;
        public byte typeOption;
        public byte typeDir;
        public byte typeAxis;
        public byte typeOption0;
        public byte typeOption1;
        public byte typeOption2;
        public byte padding4;
        public float zOffset;

        #endregion

        EmitterDrawSetting drawSetting;

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            _name = "Emitter";

            desc = *Descriptor;
            drawSetting = desc.drawSetting;

            return false;
        }
    }
}
