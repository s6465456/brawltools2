﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.SSBB.ResourceNodes;

namespace Ikarus
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct MovesetHeader
    {
        public bint _fileSize;
        public bint _lookupOffset;
        public bint _lookupEntryCount;
        public bint _dataTableEntryCount; //Has string entry
        public bint _externalSubRoutineCount; //Has string entry
        public int _pad1, _pad2, _pad3;

        //From here begins file data. All offsets are relative to this location (0x20).
        public VoidPtr BaseAddress { get { return Address + 0x20; } }

        public bint* LookupEntries { get { return (bint*)(Address + _lookupOffset + 0x20); } }
        
        public sStringEntry* DataTable { get { return (sStringEntry*)(Address + _lookupOffset + 0x20 + _lookupEntryCount * 4); } }
        public sStringEntry* ExternalSubRoutines { get { return (sStringEntry*)(Address + _lookupOffset + 0x20 + _lookupEntryCount * 4 + _dataTableEntryCount * 8); } }
        
        //for DataTable and ExternalSubRoutines
        public sStringTable* StringTable { get { return (sStringTable*)((Address + _lookupOffset + 0x20) + (_lookupEntryCount * 4) + (_dataTableEntryCount * 8) + (_externalSubRoutineCount * 8)); } }
        
        private VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DataHeader
    {
        public const int Size = 124;
        
        public bint SubactionFlagsStart;
        public bint ModelVisibilityStart;
        public bint AttributeStart;
        public bint SSEAttributeStart;

        public bint MiscSectionOffset;
        public bint CommonActionFlagsStart;
        public bint ActionFlagsStart;
        public bint Unknown7;

        public bint ActionInterrupts;
        public bint EntryActionsStart;
        public bint ExitActionsStart;
        public bint ActionPreStart;

        public bint SubactionMainStart;
        public bint SubactionGFXStart;
        public bint SubactionSFXStart;
        public bint SubactionOtherStart;

        public bint BoneFloats1;
        public bint BoneFloats2;
        public bint BoneRef1;
        public bint BoneRef2;

        public bint EntryActionOverrides;
        public bint ExitActionOverrides;
        public bint Unknown22;
        public bint BoneFloats3;

        public bint Unknown24;
        public bint StaticArticlesStart;
        public bint EntryArticleStart;
        
        public bint Unknown27;
        public bint Unknown28;
        public buint Flags1;
        public bint Flags2; //Sometimes -1

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public int this[int i]
        {
            get { return ((bint*)Address)[i]; }
            set { ((bint*)Address)[i] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct CommonHeader
    {
        public bint GlobalICs;
        public bint SSEGlobalICs;
        public bint ICs;
        public bint SSEICs;
        public bint EntryActions;
        public bint ExitActions;
        public bint FlashOverlayArray;
        public bint Unknown7;
        public bint Unknown8;
        public bint Unknown9;
        public bint Unknown10;
        public bint Unknown11;
        public bint Unknown12;
        public bint Unknown13;
        public bint Unknown14;
        public bint Unknown15;
        public bint Unknown16;
        public bint Unknown17;
        public bint Unknown18;
        public bint FlashOverlays;
        public bint ScreenTints;
        public bint LegBones;
        public bint Unknown22;
        public bint Unknown23;
        public bint Unknown24;
        public bint Unknown25;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public int this[int i]
        {
            get { return ((bint*)Address)[i]; }
            set { ((bint*)Address)[i] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct AnimParamHeader
    {
        public bint SubactionFlags;
        public bint SubactionFlagsCount;
        public bint ActionFlags;
        public bint ActionFlagsCount;
        public bint Unknown4;
        public bint Unknown5;
        public bint Unknown6;
        public bint Unknown7;
        public bint Unknown8;
        public bint Unknown9;
        public bint Unknown10;
        public bint Unknown11;
        public bint Hurtboxes;
        public bint Unknown13;
        public bint CollisionData;
        public bint Unknown15;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public int this[int i]
        {
            get { return ((bint*)Address)[i]; }
            set { ((bint*)Address)[i] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SubParamHeader
    {
        public bint Unknown0;
        public bint Unknown1;
        public bint Unknown2;
        public bint Unknown3;
        public bint Unknown4;
        public bint Unknown5;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public int this[int i]
        {
            get { return ((bint*)Address)[i]; }
            set { ((bint*)Address)[i] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sStringTable
    {
        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public string GetString(int offset)
        {
            return new String((sbyte*)Address + offset);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sStringEntry
    {
        public bint _dataOffset;
        public bint _stringOffset; //Base is string table
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sPatternPowerMul
    {
        public bfloat _unk1;
        public bfloat _unk2;
        public bfloat _unk3;
        public bfloat _unk4;

        public bfloat _unk5;
        public bfloat _unk6;
        public bfloat _unk7;
        public bfloat _unk8;

        public bfloat _unk9;
        public bfloat _unk10;
        
        //Four action nodes in a row start here
        public byte _first;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sPatternPowerMulEntry
    {
        public sEvent _event1;
        public sEvent _event2;
        public bint _pad1;
        public bint _pad2;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCommonUnk7Entry
    {
        public sListOffset _list;
        public bshort _unk3;
        public bshort _unk4;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCommonUnk7EntryListEntry
    {
        public bfloat _unk1;
        public bfloat _unk2;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCommonUnknown11Entry
    {
        public bint _unk1;
        public sListOffset _list;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sActionOverride
    {
        public bint _actionID;
        public bint _commandListOffset;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sArticle
    {
        public const int Size = 56;

        public bint _id;
        public bint _arcGroup;
        public bint _boneID;
        public bint _actionFlagsStart;

        public bint _subactionFlagsStart;
        public bint _actionsStart;
        public bint _subactionMainStart;
        public bint _subactionGFXStart;

        public bint _subactionSFXStart;
        public bint _modelVisibility;
        public bint _collisionData;
        public bint _unknownD2;

        public bint _unknownD3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscUnknown10
    {
        public const int Size = 28;

        public bint _haveNBoneIndex1;
        public bint _haveNBoneIndex2;
        public bint _throwNBoneIndex;
        public sListOffset _list;
        public bint _pad; //0
        public bint _haveNBoneIndex3;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscUnknown10Entry
    {
        public const int Size = 16;

        public bint _unk1;
        public bint _unk2;
        public bint _pad1;
        public bint _pad2;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sDataBoneRef2
    {
        public const int Size = 24;

        public bint _handNBoneIndex1;
        public bint _handNBoneIndex2;
        public bint _handNBoneIndex3;
        public bint _handNBoneIndex4;
        
        public bint _count;
        public bint _offset;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscUnknown7
    {
        public byte unk1;
        public byte unk2;
        public byte unk3;
        public byte unk4;

        public byte unk5;
        public byte unk6;
        public byte unk7;
        public byte unk8;

        public bfloat unk9;
        public bfloat unk10;

        public bfloat unk11;
        public bfloat unk12;
        public bfloat unk13;
        public bfloat unk14;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscUnknown12
    {
        public bint _unk1; //0x2B
        public bint _unk2; //0x64
        public bint _unk3; //-1
        public bint _unk4; //-1

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public unsafe struct sMiscUnknown1
    //{
    //    public bint _unk1;
    //    public bint _unk2;
    //    public bint _unk3;
    //    public bint _unk4;
    //    public bint _unk5;
    //    public bint _unk6;
    //    public bint _unk7;
    //    public bint _unk8;

    //    public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    //}

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscUnknown9
    {
        public bint _unk1;
        public sListOffset _list;
        public bfloat _unk2;
        public bfloat _unk3;
        public bint _unk4;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCollData0
    {
        public int type; //0
        public sListOffset _list;
        public bfloat unk1;
        public bfloat unk2;
        public bfloat unk3;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCollData1
    {
        public int type; //1
        public bfloat unk1;
        public bfloat unk2;
        public bfloat unk3;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCollData2
    {
        public int type; //2
        public bint flags; //Usually 1
        public bfloat unk1;
        public bfloat unk2;
        public bfloat unk3;
        public bfloat unk4; //Exists only if flags == 3

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sSubActionFlags
    {
        public byte _inTranslationTime;
        public AnimationFlags _flags;
        public short pad;

        //String spacing == (String length + 1).Align(4)
        public bint _stringOffset;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sSubActionString
    {
        public sbyte _data;

        private void* Address { get { fixed (void* p = &this)return p; } }
        public sbyte* Data { get { return (sbyte*)Address; } }

        public int Length { get { return Value.Length; } }

        public string Value
        {
            get { return new String(Data); }
            set
            {
                if (value == null)
                    value = "";

                int len = value.Length;
                int ceil = (len + 1).Align(4);

                sbyte* ptr = Data;

                for (int i = 0; i < len; )
                    ptr[i] = (sbyte)value[i++];

                for (int i = len; i < ceil; )
                    ptr[i++] = 0;
            }
        }
        public sSubActionString* Next { get { return (sSubActionString*)((byte*)Address + (Length + 1).Align(4)); } }
        public sSubActionString* End { get { sSubActionString* p = (sSubActionString*)Address; while (p->Length != 0) p = p->Next; return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sReferenceString
    {
        public sbyte _data;

        private void* Address { get { fixed (void* p = &this)return p; } }
        public sbyte* Data { get { return (sbyte*)Address; } }

        public int Length { get { return Value.Length; } }

        public string Value
        {
            get { return new String(Data); }
            set
            {
                if (value == null)
                    value = "";

                int len = value.Length;
                int ceil = (len + 1);

                sbyte* ptr = Data;

                for (int i = 0; i < len; )
                    ptr[i] = (sbyte)value[i++];

                for (int i = len; i < ceil; )
                    ptr[i++] = 0;
            }
        }
        public sReferenceString* Next { get { return (sReferenceString*)((byte*)Address + (Length + 1)); } }
        public sReferenceString* End { get { sReferenceString* p = (sReferenceString*)Address; while (p->Length != 0) p = p->Next; return p; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sEvent
    {
        public byte _nameSpace;
        public byte _id;
        public byte _numArguments;
        public byte _unk1;
        public buint _argumentOffset;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sParameter
    {
        public bint _type;
        public bint _data;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sDataMisc
    {
        public const int Size = 0x4C;

        public bint UnknownSection1Offset;
        public bint FinalSmashAuraOffset;
        public bint FinalSmashAuraCount;
        public bint HurtBoxOffset;
        public bint HurtBoxCount;
        public bint LedgegrabOffset;
        public bint LedgegrabCount;
        public bint UnknownSection2Offset;
        public bint UnknownSection2Count;
        public bint BoneRef2Offset;
        public bint UnknownSection3Offset;
        public bint SoundDataOffset;
        public bint UnknownSection5Offset;
        public bint MultiJumpOffset;
        public bint GlideOffset;
        public bint CrawlOffset;
        public bint CollisionDataOffset;
        public bint TetherOffset;
        public bint UnknownSection12Offset;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
        public int this[int i]
        {
            get { return ((bint*)Address)[i]; }
            set { ((bint*)Address)[i] = value; }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sModelDisplayDefaults
    {
        public bint _switchIndex;
        public bint _defaultGroup;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMiscFSAura
    {
        public const int Size = 0x14;

        public bint _boneIndex;
        public bfloat _x;
        public bfloat _y;
        public bfloat _width;
        public bfloat _height;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sModelDisplay
    {
        public bint _entryOffset;
        public bint _entryCount;
        public bint _defaultsOffset;
        public bint _defaultsCount;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sDataUnknown22
    {
        public bint _unk1;
        public bint _unk2;
        public bint _actionOffset;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sItemAnchor
    {
        public const int Size = 0x1C;

        public bint _boneIndex;
        public BVec3 _translation;
        public BVec3 _rotation;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sDataUnknown23
    {
        public const int Size = 0x20;

        public bint _boneIndex;
        public bfloat _unk1;
        public bfloat _unk2;
        public bfloat _unk3;

        public bfloat _unk4;
        public bfloat _unk5;
        public bfloat _unk6;
        public bfloat _unk7;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sActionFlags
    {
        public bint _flags1; //Sometimes -1
        public bint _flags2; //Sometimes -1
        public bint _flags3; //Sometimes -1
        public bint _flags4;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sHurtBox
    {
        public BVec3 _offset;
        public BVec3 _stretch;
        public bfloat _radius;
        public HurtBoxFlags _flags;
        
        public VoidPtr Address { get { fixed (void* ptr = &this) return ptr; } }
    }

    public enum HurtBoxZone : byte
    {
        Low = 0,
        Middle = 1,
        High = 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HurtBoxFlags
    {
        //0000 0000 0000 0001   Enabled
        //0000 0000 0000 0110   Unused
        //0000 0000 0001 1000   Zone
        //0000 0000 0110 0000   Region
        //1111 1111 1000 0000   Bone Index

        byte dat0, dat1, pad0, pad1;
        
        public int BoneIndex { get { return (int)((((dat1 >> 7) & 1) | (int)dat0 << 1) & 0x1FF); } set { dat0 = (byte)(value >> 1); dat1 = (byte)((dat1 & 0x7F) | ((value & 1) << 7)); } }
        public HurtBoxZone Zone { get { return (HurtBoxZone)((dat1 >> 3) & 3); } set { dat1 = (byte)((dat1 & 0xE7) | (((byte)value & 3) << 3)); } }
        public bool Enabled { get { return (dat1 & 1) != 0; } set { dat1 = (byte)((dat1 & 0xFE) | ((byte)(value ? 1 : 0) & 1)); } }
        public int Region { get { return ((dat1 >> 5) & 3); } set { dat1 = (byte)((dat1 & 0x9F) | (((byte)value & 3) << 5)); } }
        public int Unk { get { return ((dat1 >> 1) & 3); } set { dat1 = (byte)((dat1 & 0xF9) | (((byte)value & 3) << 1)); } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sLedgegrab
    {
        public BVec2 _xy;
        public bfloat _width;
        public bfloat _height;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sMultiJump
    {
        public bfloat _unk1;
        public bfloat _unk2;
        public bfloat _unk3;
        public bfloat _horizontalBoost;

        //all can be either int or fixed float...
        //where are the flags?
        public bint _hopListOffset;
        public bint _unkListOffset;
        public bint _turnFrameOffset;
        
        public bool hopFixed { get { if ((((int)_hopListOffset) >> 24 & 0xFF) != 0) return true; return false; } }
        public bool unkFixed { get { if ((((int)_unkListOffset) >> 24 & 0xFF) != 0) return true; return false; } }
        public bool turnFixed { get { if ((((int)_turnFrameOffset) >> 24 & 0xFF) != 0) return true; return false; } }

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sCrawl
    {
        public bfloat _forward;
        public bfloat _backward;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sTether
    {
        public bint _numHangFrame;
        public bfloat _unk1;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct sListOffset
    {
        public bint _startOffset;
        public bint _listCount;

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
