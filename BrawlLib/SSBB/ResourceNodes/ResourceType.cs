﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.SSBB.ResourceNodes
{
    //Lower byte is resource type (used for icon index)
    //Upper byte is entry type/flags
    public enum ResourceType : int
    {
        //Base types
        Unknown = 0x0000,
        Container = 0x0001,

        ARC = 0x0202,
        U8 = 0x1D23,
        U8Folder = 0x1C01,
        BRES = 0x0203,
        MSBin = 0x0204,
        EFLS = 0x0213,
        EFLSEntry = 0x1200,
        CollisionDef = 0x0214,
        REFF = 0x0215,
        REFT = 0x121C,
        REL = 0x1900,
        RELImport = 0x2900,
        MRG = 0x1501,
        AI = 0x0216,
        CE = 0x0A19,
        CEEntry = 0x0B00,
        CEEvent = 0x0C00,
        CEString = 0x0D00,
        AIPD = 0x0E17,
        ATKD = 0x0F18,
        REFTImage = 0x131E,

        TPL = 0x1321,
        TPLTexture = 0x231E,
        TPLPalette = 0x3322,

        TEX0 = 0x0305,
        PLT0 = 0x0306,
        MDL0 = 0x0307,
        CHR0 = 0x0308,
        CLR0 = 0x0309,
        VIS0 = 0x030A,
        SHP0 = 0x030B,
        SHP0Entry = 0x0600,
        SRT0 = 0x030C,
        SRT0Entry = 0x0400,
        SRT0Texture = 0x0500,
        PAT0 = 0x101D,
        PAT0Entry = 0x2000,
        PAT0Texture = 0x2100,
        PAT0TextureEntry = 0x2200,
        STPM = 0x0320,
        SCN0 = 0x031F,

        RSAR = 0x000D,
        RSTM = 0x000E,

        RSARFile = 0x0B0F,
        RSARSound = 0x0B00,
        RSARGroup = 0x0B10,
        RSARType = 0x0B11,
        RSARBank = 0x0B12,

        RWSD = 0x0A00,
        RWSDDataEntry = 0x1800,
        RSARFileAudioEntry = 0x0800,

        RBNK = 0x1B00,
        RSEQ = 0x0E00,

        //Generic types
        ARCEntry = 0x0200,

        BRESEntry = 0x0300,
        BRESGroup = 0x0301,

        MDL0Group = 0x0701,
        MDL0Bone = 0x1700,
        MDL0Object = 0x0700,
        MDL0Shader = 0x0C00,
        TEVStage = 0x0F00,
        MDL0Material = 0x0D00,

        CHR0Entry = 0x0800,
        CLR0Material = 0x0900,
        CLR0MaterialEntry = 0xA900,

        RSARFolder = 0x0B01,

        RSARFileSoundGroup = 0x1101,
        RWSDDataGroup = 0x1401,
        RSEQGroup = 0x1201,
        RBNKGroup = 0x1301,
        
        MDef = 0x101A,
        NoEdit = 0x1001,
        MDefActionGroup = 0x2001,
        MDefSubActionGroup = 0x2701,
        MDefMdlVisRef = 0x2601,
        MDefMdlVisSwitch = 0x2501,
        MDefMdlVisGroup = 0x2401,
        MDefActionList = 0x3101,
        MDefSubroutineList = 0x3201,
        MDefActionOverrideList = 0x3301,
        MDefHurtboxList = 0x3001,
        MDefRefList = 0x2801,
        Event = 0x101B,
        Parameter = 0x1000,
    }
}
