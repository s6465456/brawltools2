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
        DOL = 0x5900,

        //Base types
        Unknown = 0x0000,
        Container = 0x0101,

        //Archives
        ARC = 0x0202,
        ARCEntry = 0x0300,
        U8 = 0x0423,
        U8Folder = 0x0501,
        BRES = 0x0603,
        BRESEntry = 0x0700,
        MRG = 0x0801,

        //Effects
        EFLS = 0x0913,
        EFLSEntry = 0x0A00,
        REFF = 0x0B15,
        REFFAnimationList = 0x0C00,
        REFFEntry = 0x0D24,
        REFT = 0x0E1C,
        REFTImage = 0x0F1E,

        //Modules
        REL = 0x1000,
        RELImport = 0x1100,
        RELSection = 0x1200,

        //Misc
        CollisionDef = 0x1314,
        MSBin = 0x1404,
        STPM = 0x1520,

        //AI
        AI = 0x1616,
        CE = 0x1719,
        CEEntry = 0x1800,
        CEEvent = 0x1900,
        CEString = 0x1A00,
        AIPD = 0x1B17,
        ATKD = 0x1C18,

        //Textures
        TPL = 0x1D21,
        TPLTexture = 0x1E1E,
        TPLPalette = 0x1F22,

        //BRRES Nodes
        TEX0 = 0x2005,
        PLT0 = 0x2106,

        MDL0 = 0x2207,
        MDL0Group = 0x2301,
        MDL0Bone = 0x2400,
        MDL0Object = 0x2500,
        MDL0Shader = 0x2600,
        TEVStage = 0x2700,
        MDL0Material = 0x2800,

        CHR0 = 0x2908,
        CHR0Entry = 0x2A00,

        CLR0 = 0x2B09,
        CLR0Material = 0x2C00,
        CLR0MaterialEntry = 0x2D00,

        VIS0 = 0x2E0A,
        SHP0 = 0x2F0B,
        SHP0Entry = 0x3000,
        SRT0 = 0x310C,
        SRT0Entry = 0x3200,
        SRT0Texture = 0x3300,
        PAT0 = 0x341D,
        PAT0Entry = 0x3500,
        PAT0Texture = 0x3600,
        PAT0TextureEntry = 0x3700,
        SCN0 = 0x381F,

        //Audio
        RSAR = 0x390D,
        RSTM = 0x3A0E,
        RWSD = 0x3B00,
        RBNK = 0x3C00,
        RSEQ = 0x3D00,
        RSARFile = 0x3E0F,
        RSARSound = 0x3F00,
        RSARGroup = 0x4010,
        RSARType = 0x4111,
        RSARBank = 0x4212,
        RWSDDataEntry = 0x4300,
        RSARFileAudioEntry = 0x4400,

        //Groups
        BRESGroup = 0x4501,
        RSARFolder = 0x4601,
        RSARFileSoundGroup = 0x4701,
        RWSDDataGroup = 0x4801,
        RSEQGroup = 0x4901,
        RBNKGroup = 0x4A01,
        
        MDef = 0x4B1A,
        NoEdit = 0x4C01,
        MDefActionGroup = 0x4D01,
        MDefSubActionGroup = 0x4E01,
        MDefMdlVisRef = 0x4F01,
        MDefMdlVisSwitch = 0x5001,
        MDefMdlVisGroup = 0x5101,
        MDefActionList = 0x5201,
        MDefSubroutineList = 0x5301,
        MDefActionOverrideList = 0x5401,
        MDefHurtboxList = 0x5501,
        MDefRefList = 0x5601,
        Event = 0x571B,
        Parameter = 0x5800,
    }
}
