using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;

namespace BrawlLib.SSBBTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct REFF
    {
        //Header + string is aligned to 4 bytes

        public const uint Tag = 0x46464552;

        public SSBBCommonHeader _header;
        public uint _tag; //Same as header
        public bint _dataLength; //Size of second REFF block. (file size - 0x18)
        public bint _dataOffset; //Offset from itself. Begins first entry
        public bint _unk1; //0
        public bint _unk2; //0
        public bshort _stringLen;
        public bshort _unk3; //0

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public string IdString
        {
            get { return new String((sbyte*)Address + 0x28); }
            set
            {
                int len = value.Length + 1;
                _stringLen = (short)len;

                byte* dPtr = (byte*)Address + 0x28;
                fixed (char* sPtr = value)
                {
                    for (int i = 0; i < len; i++)
                        *dPtr++ = (byte)sPtr[i];
                }

                //Align to 4 bytes
                while ((len++ & 3) != 0)
                    *dPtr++ = 0;

                //Set data offset
                _dataOffset = 0x18 + len - 1;
            }
        }

        public REFTypeObjectTable* Table { get { return (REFTypeObjectTable*)(Address + 0x18 + _dataOffset); } }
    }

    public unsafe struct REFTypeObjectTable
    {
        //Table size is aligned to 4 bytes
        //All entry offsets are relative to this offset

        public bint _length;
        public bshort _entries;
        public bshort _unk1;

        public VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public REFTypeObjectEntry* First { get { return (REFTypeObjectEntry*)(Address + 8); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct REFTypeObjectEntry
    {
        public bshort _strLen;
        public string Name
        {
            get { return new String((sbyte*)Address + 2); }
            set
            {
                int len = value.Length + 1;
                _strLen = (short)len;//.Align(4);

                byte* dPtr = (byte*)Address + 2;
                fixed (char* sPtr = value)
                {
                    for (int i = 0; i < len; i++)
                        *dPtr++ = (byte)sPtr[i];
                }

                //Align to 4 bytes
                //while ((len++ & 3) != 0)
                //    *dPtr++ = 0;
            }
        }

        public int DataOffset
        {
            get { return (int)*(buint*)((byte*)Address + 2 + _strLen); }
            set { *(buint*)((byte*)Address + 2 + _strLen) = (uint)value; }
        }

        public int DataLength
        {
            get { return (int)*(buint*)((byte*)Address + 2 + _strLen + 4); }
            set { *(buint*)((byte*)Address + 2 + _strLen + 4) = (uint)value; }
        }

        private VoidPtr Address { get { fixed (void* p = &this)return p; } }

        public REFTypeObjectEntry* Next { get { return (REFTypeObjectEntry*)(Address + 10 + _strLen); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct REFFDataHeader
    {
        public buint _unknown; //0
        public buint _headerSize;

        public EmitterDesc _descriptor;

        public ParticleParameterHeader* _params { get { return (ParticleParameterHeader*)(Address + _headerSize + 8); } }

        public bshort* _ptclTrackCount { get { return (bshort*)((VoidPtr)_params + _params->headersize + 4); } }
        public bshort* _ptclInitTrackCount { get { return _ptclTrackCount + 1; } }
        public bshort* _emitTrackCount { get { return (bshort*)((VoidPtr)_ptclTrackCount + 4 + *_ptclTrackCount * 8); } }
        public bshort* _emitInitTrackCount { get { return _emitTrackCount + 1; } }

        public buint* _ptclTrack { get { return (buint*)((VoidPtr)_ptclTrackCount + 4); } }
        public buint* _emitTrack { get { return (buint*)((VoidPtr)_emitTrackCount + 4); } }

        public VoidPtr _postFieldInfo { get { return (VoidPtr)_emitTrackCount + 4 + *_emitTrackCount * 8; } }
        
        private VoidPtr Address { get { fixed (void* p = &this)return p; } }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct EmitterDesc
    {
        [Flags]
        public enum EmitterCommonFlag : uint
        {
            SYNCLIFE = 0x1,
            INVISIBLE = 0x2,
            MAXLIFE = 0x4,
            INHERIT_PTCL_SCALE = 0x20,
            INHERIT_PTCL_ROTATE = 0x40,
            INHERIT_CHILD_E_SCALE = 0x80,
            INHERIT_CHILD_E_ROTATE = 0x100,
            DISABLE_CALC = 0x200,
            INHERIT_PTCL_PIVOT = 0x400,
            INHERIT_CHILD_PIVOT = 0x800,
            INHERIT_CHILD_P_SCALE = 0x1000,
            INHERIT_CHILD_P_ROTATE = 0x2000,
            RELOCATE_COMPLETE = 0x80000000,
        }

        public enum EmitFormType
        {
            Disc = 0,
            Line = 1,
            Cube = 5,
            Cylinder = 7,
            Sphere = 8,
            Point = 9,
            Torus = 10
        }

        public buint commonFlag; // EmitterCommonFlag
        public buint emitFlag; // EmitFormType - value & 0xFF
        public bushort emitLife;
        public bushort ptclLife;
        public sbyte ptclLifeRandom;
        public sbyte inheritChildPtclTranslate;

        public sbyte emitEmitIntervalRandom;
        public sbyte emitEmitRandom;
        public bfloat emitEmit;
        public bushort emitEmitStart;
        public bushort emitEmitPast;
        public bushort emitEmitInterval;

        public sbyte inheritPtclTranslate;
        public sbyte inheritChildEmitTranslate;

        public bfloat commonParam1;
        public bfloat commonParam2;
        public bfloat commonParam3;
        public bfloat commonParam4;
        public bfloat commonParam5;
        public bfloat commonParam6;
        public bushort emitEmitDiv;

        public sbyte velInitVelocityRandom;
        public sbyte velMomentumRandom;
        public bfloat velPowerRadiationDir;
        public bfloat velPowerYAxis;
        public bfloat velPowerRandomDir;
        public bfloat velPowerNormalDir;
        public bfloat velDiffusionEmitterNormal;
        public bfloat velPowerSpecDir;
        public bfloat velDiffusionSpecDir;
        public BVec3 velSpecDir;

        public BVec3 scale;
        public BVec3 rotate;
        public BVec3 translate;

        public byte lodNear;
        public byte lodFar;
        public byte lodMinEmit;
        public byte lodAlpha;

        public buint randomSeed;

        public fixed byte userdata[8];

        public EmitterDrawSetting drawSetting;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct EmitterDrawSetting
    {
        [Flags]
        public enum DrawFlag
        {
            DRAWFLAG_ZCOMPARE_ENABLE = 0x0001, // 0x0001
            DRAWFLAG_ZUPDATE = 0x0002, // 0x0002
            DRAWFLAG_ZCOMPARE_BEFORETEX = 0x0004, // 0x0004
            DRAWFLAG_CLIPING_DISABLE = 0x0008, // 0x0008
            DRAWFLAG_USE_TEXTURE1 = 0x0010, // 0x0010
            DRAWFLAG_USE_TEXTURE2 = 0x0020, // 0x0020
            DRAWFLAG_USE_INDIRECT = 0x0040, // 0x0040
            DRAWFLAG_PROJ_TEXTURE1 = 0x0080, // 0x0080
            DRAWFLAG_PROJ_TEXTURE2 = 0x0100, // 0x0100
            DRAWFLAG_PROJ_INDIRECT = 0x0200, // 0x0200
            DRAWFLAG_INVISIBLE = 0x0400, // 0x0400 1: Does not render
            DRAWFLAG_DRAWORDER_DESC = 0x0800, // 0x0800 0: normal order, 1: reverse order
            DRAWFLAG_FOG_ENABLE = 0x1000, // 0x1000
            DRAWFLAG_XYLINKSIZE = 0x2000, // 0x2000
            DRAWFLAG_XYLINKSCALE = 0x4000  // 0x4000
        }

        public bushort mFlags;     // DrawFlag

        public byte mACmpComp0;
        public byte mACmpComp1;
        public byte mACmpOp;

        public byte mNumTevs;   // TEV uses stages 1 through NW4R_EF_MAXTEV
        public byte mFlagClamp; // Obsolete

        [Flags]
        public enum IndirectTargetStage
        {
            IND_TARGET_STAGE0 = 1,
            IND_TARGET_STAGE1 = 2,
            IND_TARGET_STAGE2 = 4,
            IND_TARGET_STAGE3 = 8
        }
        public byte mIndirectTargetStage;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TevStageColor
        {
            public byte mA;         // GXTevColorArg
            public byte mB;         // GXTevColorArg
            public byte mC;         // GXTevColorArg
            public byte mD;         // GXTevColorArg
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TevStageAlpha
        {
            public byte mA;         // GXTevAlphaArg
            public byte mB;         // GXTevAlphaArg
            public byte mC;         // GXTevAlphaArg
            public byte mD;         // GXTevAlphaArg
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TevStageColorOp
        {
            public byte mOp;        // GXTevOp
            public byte mBias;      // GXTevBias
            public byte mScale;     // GXTevScale
            public byte mClamp;     // GXBool
            public byte mOutReg;    // GXTevRegID
        }
        public fixed byte mTevTexture[4];
        public TevStageColor mTevColor1;        
        public TevStageColor mTevColor2;
        public TevStageColor mTevColor3;
        public TevStageColor mTevColor4;
        public TevStageColorOp mTevColorOp1;
        public TevStageColorOp mTevColorOp2;
        public TevStageColorOp mTevColorOp3;
        public TevStageColorOp mTevColorOp4;
        public TevStageAlpha mTevAlpha1;
        public TevStageAlpha mTevAlpha2;
        public TevStageAlpha mTevAlpha3;
        public TevStageAlpha mTevAlpha4;
        public TevStageColorOp mTevAlphaOp1;
        public TevStageColorOp mTevAlphaOp2;
        public TevStageColorOp mTevAlphaOp3;
        public TevStageColorOp mTevAlphaOp4;

        public fixed byte mTevKColorSel[4];  // Constant register selector: GXTevKColorSel
        public fixed byte mTevKAlphaSel[4];  // Constant register selector: GXTevKAlphaSel
        public struct BlendMode
        {
            public byte mType;                      // GXBlendMode
            public byte mSrcFactor;                 // GXBlendFactor
            public byte mDstFactor;                 // GXBlendFactor
            public byte mOp;                        // GXLogicOp
        }
        BlendMode mBlendMode;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ColorInput
        {
            public enum RasColor
            {
                RASCOLOR_NULL = 0,      // No request
                RASCOLOR_LIGHTING = 1   // Color lit by lighting
            }
            public enum TevColor
            {
                TEVCOLOR_NULL = 0,      // No request
                TEVCOLOR1_1 = 1,        // Layer 1 primary color
                TEVCOLOR1_2 = 2,        // Layer 1 Secondary Color
                TEVCOLOR2_1 = 3,        // Layer 2 primary color
                TEVCOLOR2_2 = 4,        // Layer 2 Secondary Color
                TEVCOLOR1_MULT = 5,     // Layer 1 primary color x secondary color
                TEVCOLOR2_MULT = 6      // Layer 2 primary color x secondary color
            }

            public byte mRasColor;                  // Rasterize color (only channel 0): RasColor
            public fixed byte mTevColor[3];               // TEV register TevColor
            public fixed byte mTevKColor[4];              // Constant register TevColor
        }
        ColorInput mColorInput;
        ColorInput mAlphaInput;

        public byte mZCompareFunc;          // GXCompare

        // Alpha Swing
        public enum AlphaFlickType
        {
            ALPHAFLICK_NONE = 0,
            ALPHAFLICK_TRIANGLE,
            ALPHAFLICK_SAWTOOTH1,
            ALPHAFLICK_SAWTOOTH2,
            ALPHAFLICK_SQUARE,
            ALPHAFLICK_SINE
        }
        public byte mAlphaFlickType;        // AlphaFlickType
        public bushort mAlphaFlickCycle;
        public byte mAlphaFlickRandom;
        public byte mAlphaFlickAmplitude;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Lighting
        {
            public enum Mode
            {
                LIGHTING_MODE_OFF = 0,
                LIGHTING_MODE_SIMPLE,
                LIGHTING_MODE_HARDWARE
            }
            public enum Type
            {
                LIGHTING_TYPE_NONE = 0,
                LIGHTING_TYPE_AMBIENT,
                LIGHTING_TYPE_POINT
            }
            public byte mMode;                  // Mode
            public byte mType;                  // Type
            public RGBAPixel mAmbient;
            public RGBAPixel mDiffuse;
            public bfloat mRadius;
            public BVec3 mPosition;
        }
        Lighting mLighting;

        public fixed float mIndTexOffsetMtx[6]; //2x3 Matrix
        public sbyte mIndTexScaleExp;

        public sbyte pivotX;
        public sbyte pivotY;
        public byte padding;

        // Expression
        //
        // Stored in ptcltype member.
        public enum Type
        {
            TYPE_POINT = 0,
            TYPE_LINE,
            TYPE_FREE,
            TYPE_BILLBOARD,
            TYPE_DIRECTIONAL,
            TYPE_STRIPE,
            TYPE_SMOOTH_STRIPE,
            NUM_OF_TYPE
        }

        // Expression assistance -- everything except billboards
        //
        // Stored in typeOption member.
        public enum Assist
        {
            ASSIST_NORMAL = 0,              // Render single Quad to Face surface
            ASSIST_CROSS,                   // Add Quads so they are orthogonal to Normals.
            NUM_OF_ASSIST
        }

        // Expression assistance -- billboards
        //
        // Stored in typeOption member.
        public enum BillboardAssist
        {
            BILLBOARD_ASSIST_NORMAL = 0,        // Normal
            BILLBOARD_ASSIST_Y,                 // Y-axis billboard
            BILLBOARD_ASSIST_DIRECTIONAL,       // Billboard using the movement direction as its axis
            BILLBOARD_ASSIST_NORMAL_WO_ROLL,    // Normal (no roll)
            NUM_OF_BILLBOARD_ASSIST
        }

        // Expression assistance -- stripes
        public enum StripeAssist
        {
            STRIPE_ASSIST_NORMAL = 0,           // Normal.
            STRIPE_ASSIST_CROSS,                // Add a surface orthogonal to the Normal.
            STRIPE_ASSIST_BILLBOARD,            // Always faces the screen.
            STRIPE_ASSIST_TUBE,                 // Expression of a tube shape.
            NUM_OF_STRIPE_ASSIST
        }

        // Movement direction (Y-axis) -- everything except billboard
        //
        // Stored in typeDir member.
        public enum Ahead
        {
            AHEAD_SPEED = 0,                    // Velocity vector direction
            AHEAD_EMITTER_CENTER,               // Relative position from the center of emitter
            AHEAD_EMITTER_DESIGN,               // Emitter specified direction
            AHEAD_PARTICLE,                     // Difference in location from the previous particle
            AHEAD_USER,                         // User specified (unused)
            AHEAD_NO_DESIGN,                    // Unspecified
            AHEAD_PARTICLE_BOTH,                // Difference in position with both neighboring particles
            AHEAD_NO_DESIGN2,                   // Unspecified (initialized as the world Y-axis)
            NUM_OF_AHEAD
        }

        // Movement direction (Y-axis) -- billboards
        //
        // Stored in typeDir member.
        public enum BillboardAhead
        {
            BILLBOARD_AHEAD_SPEED = 0,              // Velocity vector direction
            BILLBOARD_AHEAD_EMITTER_CENTER,         // Relative position from the center of emitter
            BILLBOARD_AHEAD_EMITTER_DESIGN,         // Emitter specified direction
            BILLBOARD_AHEAD_PARTICLE,               // Difference in location from the previous particle
            BILLBOARD_AHEAD_PARTICLE_BOTH,          // Difference in position with both neighboring particles
            NUM_OF_BILLBOARD_AHEAD
        }

        // Rotational axis to take into account when rendering
        //
        // Stored in typeAxis member.
        public enum RotateAxis
        {
            ROTATE_AXIS_X = 0,          // X-axis rotation only
            ROTATE_AXIS_Y,              // Y-axis rotation only
            ROTATE_AXIS_Z,              // Z-axis rotation only
            ROTATE_AXIS_XYZ,            // 3-axis rotation
            NUM_OF_ROTATE_AXIS
        }

        // Base surface (polygon render surface)
        //
        // Stored in typeReference.
        public enum Face
        {
            FACE_XY = 0,
            FACE_XZ,
            NUM_OF_FACE
        }

        // Stripe terminal connections
        //
        // Stored in typeOption2.
        public enum StripeConnect
        {
            STRIPE_CONNECT_NONE = 0,    // Does not connect
            STRIPE_CONNECT_RING,        // Both ends connected
            STRIPE_CONNECT_EMITTER,     // Connect between the newest particle and the emitter
            STRIPE_CONNECT__MASK = 0x07 // StripeConnect mask
        }

        // Initial value of the reference axis for stripes
        //
        // Stored in typeOption2.
        [Flags]
        public enum StripeInitialPrevAxis
        {
            STRIPE_INITIAL_PREV_AXIS_EMITTER_AXIS_X = 1 << 3,   // X-axis of the emitter
            STRIPE_INITIAL_PREV_AXIS_EMITTER_AXIS_Y = 0 << 3,   // Y-axis of the emitter (assigned to 0 for compatibility)
            STRIPE_INITIAL_PREV_AXIS_EMITTER_AXIS_Z = 2 << 3,   // Z-axis of the emitter
            STRIPE_INITIAL_PREV_AXIS_EMITTER_XYZ = 3 << 3,      // Direction in emitter coordinates (1, 1, 1)
            STRIPE_INITIAL_PREV_AXIS__MASK = 0x07 << 3          // Bitmask
        }

        // Method of applying texture to stripes
        //
        // Stored in typeOption2.
        [Flags]
        public enum StripeTexmapType
        {
            STRIPE_TEXMAP_TYPE_STRETCH = 0 << 6,    // Stretch the texture along the stripe's entire length.
            STRIPE_TEXMAP_TYPE_REPEAT = 1 << 6,     // Repeats the texture for each segment.
            STRIPE_TEXMAP_TYPE__MASK = 0x03 << 6
        }

        // Directional axis processing
        //
        // Stored in typeOption2.
        [Flags]
        public enum DirectionalPivot
        {
            DIRECTIONAL_PIVOT_NOP = 0 << 0,         // No processing
            DIRECTIONAL_PIVOT_BILLBOARD = 1 << 0,   // Convert into a billboard, with the movement direction as its axis
            DIRECTIONAL_PIVOT__MASK = 0x03 << 0
        }

        public byte ptcltype;                   // enum Type

        public byte typeOption;                 // Expression assistance
        // Billboard:
        //   enum BillboardAssist
        // Linear stripe/smooth stripe:
        //   enum StripeAssist
        // Other:
        //   enum Assist

        public byte typeDir;                    // Movement direction
        // Other:
        //   enum Ahead
        // Billboard:
        //   enum BillboardAhead

        public byte typeAxis;                   // enum RotateAxis

        public byte typeOption0;                // Various types of parameters corresponding to the particle shapes
        // Directional:
        //   Change vertical (Y) based on speed : 0=off, 1=on
        // Linear stripe/smooth stripe:
        //   Number of vertices in the tube (3+)

        public byte typeOption1;                // Various types of parameters corresponding to the particle shapes
        // Directional:
        //   enum Face
        // Smooth stripe
        //   Number of interpolation divisions (1+)

        public byte typeOption2;                // Various types of parameters corresponding to the particle shapes
        // Linear stripe/smooth stripe:
        //   enum StripeConnect
        //   | enum StripeInitialPrevAxis
        //   | enum StripeTexmapType
        // Directional:
        //   enum DirectionalPivot
        public byte padding4;
        public bfloat zOffset;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParticleParameterHeader
    {
        public buint headersize;
        public ParticleParameterDesc paramDesc;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ParticleParameterDesc
    {
        public RGBAPixel mColor11;
        public RGBAPixel mColor12;
        public RGBAPixel mColor21;
        public RGBAPixel mColor22;

        public BVec2 size;
        public BVec2 scale;
        public BVec3 rotate;

        public BVec2 textureScale1;
        public BVec2 textureScale2;
        public BVec2 textureScale3;

        public BVec3 textureRotate;

        public BVec2 textureTranslate1;
        public BVec2 textureTranslate2;
        public BVec2 textureTranslate3;

        //These three are texture data pointers
        public uint mTexture1;    // 0..1: stage0,1, 2: Indirect
        public uint mTexture2;
        public uint mTexture3;

        public bushort textureWrap;
        public byte textureReverse;

        public byte mACmpRef0;
        public byte mACmpRef1;

        public byte rotateOffsetRandomX;
        public byte rotateOffsetRandomY;
        public byte rotateOffsetRandomZ;

        public BVec3 rotateOffset;

        public bushort textureNames; //align to 4 bytes
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TextureData
    {
        public bushort width;
        public bushort height;
        public buint dataSize; // If changed, this will be corrupted when relocated. Cannot be changed or referenced.
        public byte format;
        public byte pltFormat;
        public bushort pltEntries;
        public buint pltSize; // If changed, this will be corrupted when relocated. Cannot be changed or referenced.
        public byte mipmap;
        public byte min_filt;
        public byte mag_filt;
        public byte reserved1;
        public bfloat lod_bias;
    }
    public enum AnimCurveTarget
    {
        //1111 0000 0000 0000   Secondary Flag (F when unused)
        //0000 1111 0000 0000   Primary Flag
        //0000 0000 1111 1111   Enum

        /* Update target: ParticleParam*/
        // curveFlag = 0(u8) or 3(f32)
        Color0Primary = 0x0300,
        Alpha0Primary = 0x0303,
        Color0Secondary = 0x0304,
        Alpha0Secondary = 0x0307,
        Color1Primary = 0x0308,
        Alpha1Primary = 0x030B,
        Color1Secondary = 0x030C,
        Alpha1Secondary = 0x030F,
        Size = 0x0310,
        Scale = 0x0318,
        ACMPref0 = 0x0377,
        ACMPref1 = 0x0378,
        Tex1Scale = 0x032C,
        Tex1Rotate = 0x0344,
        Tex1Translate = 0x0350,
        Tex2Scale = 0x0334,
        Tex2Rotate = 0x0348,
        Tex2Translate = 0x0358,
        TexIndirectScale = 0x033C,
        TexIndirectRotate = 0x034C,
        TexIndirectTranslate = 0x0360,
        
        // curveFlag = 6 (3 when baking)
        Rotate = 0xF320,

        //curveFlag = 4
        Texture1 = 0xF468,
        Texture2 = 0xF46C,
        TextureIndirect = 0xF470,
        
        /* Update target: child*/
        //curveFlag = 5
        Child = 0xF500,

        /* Update target: Field*/
        //curveFlag = 7
        FieldGravity = 0xF700,
        FieldSpeed = 0xF701,
        FieldMagnet = 0xF702,
        FieldNewton = 0xF703,
        FieldVortex = 0xF704,
        FieldSpin = 0xF706,
        FieldRandom = 0xF707,
        FieldTail = 0xF708,

        /* Update target: PostFieldInfo::AnimatableParams*/
        //curveFlag = 2
        PostfieldSize = 0xF200,
        PostfieldRotate = 0xF20C,
        PostfieldTranslate = 0xF218,

        /* Update target: EmitterParam*/
        //curveFlag = 11 (all f32)
        EmitCommonParam = 0xFB2C,
        EmitScale = 0xFB7C,
        EmitRotate = 0xFB88,
        EmitTranslate = 0xFB70,
        EmitSpeedOrig = 0xFB48,
        EmitSpeedYAxis = 0xFB4C,
        EmitSpeedRandom = 0xFB50,
        EmitSpeedNormal = 0xFB54,
        EmitSpeedSpecDir = 0xFB5C,
        EmitEmission = 0xFB08
    }

    public enum AnimCurveType
    {
        ParticleByte = 0,
        ParticleFloat = 3,
        ParticleRotate = 6,
        ParticleTexture = 4,
        Child = 5,
        Field = 7,
        PostField = 2,
        EmitterFloat = 11
    }
    [Flags]
    public enum AnimCurveHeaderProcessFlagType
    {
        SyncRAnd = 0x04,
        Stop = 0x08,
        EmitterTiming = 0x10,
        InfiniteLoop = 0x20,
        Turn = 0x40,
        Fitting = 0x80
    }
    public struct AnimCurveHeader
    {
        public byte magic;
        public byte kindType;
        public byte curveFlag;
        public byte kindEnable;
        public byte processFlag;
        public byte loopCount;
        public bushort randomSeed;
        public bushort frameLength;
        public bushort padding;
        public buint keyTable;
        public buint rangeTable;
        public buint randomTable;
        public buint nameTable;
        public buint infoTable;
    }
    public struct AnimCurveTableHeader
    {
        public bushort count;
        public bushort pad;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PostFieldInfo
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AnimatableParams
        {
            public BVec3 mSize;
            public BVec3 mRotate;
            public BVec3 mTranslate;
        }
        public AnimatableParams mAnimatableParams;

        public enum ControlSpeedType
        {
            None = 0,
            Limit = 1,
            Terminate = 2
        }
        public bfloat mReferenceSpeed;
        public byte mControlSpeedType;

        public enum CollisionShapeType
        {
            Plane = 0,
            Rectangle = 1,
            Circle = 2,
            Cube = 3,
            Sphere = 4,
            Cylinder = 5
        }
        public byte mCollisionShapeType;
        public enum ShapeOption
        {
            XZ = 0x00,
            XY = 0x01,
            YZ = 0x02,
            Whole = 0x40,
            Top = 0x41,
            Bottom = 0x42,
            None = 0x50
        }
        public enum ShapeOptionPlane
        {
            XZ = 0,
            XY = 1,
            YZ = 2
        }
        public enum ShapeOptionSphere
        {
            Whole = 0,
            Top = 1,
            Bottom = 2
        }
        public byte mCollisionShapeOption; // ShapeOptionPlane | ShapeOptionSphere
        public enum CollisionType
        {
            Border = 0, // Border
            Inner = 1, // Inside, +X, +Y, +Z
            Outer = 2 // Outside, -X, -Y, -Z
        }
        public byte mCollisionType;

        [Flags]
        public enum CollisionOption
        {
            EmitterOriented = 0x1, // Emitter center
            Bounce = 0x2, // Reflection
            ControlSpeed = 0x8, // When speed is controlled in some way other than through reflection or wraparound
            CreateChildPtcl = 0x10, // Child creation (particle creation)
            CreateChildEmit = 0x20, // Child creation (emitter creation)
            Delete = 0x40 // Delete
        }
        public bushort mCollisionOption;

        public bushort mStartFrame;

        public BVec3 mSpeedFactor; // (1,1,1) if not controlled

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ChildOption
        {
            EmitterInheritSetting mInheritSetting;
            public bushort mNameIdx;
        }
        public ChildOption mChildOption;

        [Flags]
        public enum WrapOption
        {
            Enable = 1, // If 0, the Wrap feature is not used
            
            CenterOrigin = 0 << 1, // Center of the global origin
            CenterEmitter = 1 << 1 // Emitter center
        }
        public byte mWrapOption; // Bitwise OR of enum WrapOption

        public fixed byte padding[3];

        public BVec3 mWrapScale;
        public BVec3 mWrapRotate;
        public BVec3 mWrapTranslate;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EmitterInheritSetting
    {
        public enum EmitterInheritSettingFlag
        {
            FollowEmitter = 1,
            InheritRotate = 2
        }

        public bshort speed;
        public byte scale;
        public byte alpha;
        public byte color;
        public byte weight;
        public byte type;
        public byte flag;
        public byte alphaFuncPri;
        public byte alphaFuncSec;
    }
}
