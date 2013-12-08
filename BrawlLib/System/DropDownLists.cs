﻿using System;
using System.ComponentModel;
using System.Globalization;
using BrawlLib.SSBB.ResourceNodes;
using System.Collections.Generic;
using System.Linq;
using BrawlLib.SSBBTypes;
using BrawlLib.Wii.Compression;

namespace System
{
    #region MDL0

    public class DropDownListOpaMaterials : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            List<ResourceNode> opaMats = new List<ResourceNode>();
            foreach (MDL0MaterialNode n in model._matList) if (!n.XLUMaterial) opaMats.Add(n);
            return new StandardValuesCollection(opaMats.Select(n => n.ToString()).ToList());
        } 
    }
    public class DropDownListXluMaterials : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            List<ResourceNode> xluMats = new List<ResourceNode>();
            foreach (MDL0MaterialNode n in model._matList) if (n.XLUMaterial) xluMats.Add(n);
            return new StandardValuesCollection(xluMats.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListTextures : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._texList.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListShaders : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._shadList.Select(n => n.ToString()).ToList());
        }
    }
    public class DropDownListBones : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._linker.BoneCache.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListColors : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._colorList.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListVertices : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._vertList.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListNormals : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._normList.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListUVs : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._uvList.Select(n => n.ToString()).ToList());
        }
    }

    public class DropDownListFurPos : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._furPosList.Select(n => n.ToString()).ToList());
        }
    }
    
    public class DropDownListFurVec : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._furVecList.Select(n => n.ToString()).ToList());
        }
    }

    #endregion

    #region SCN0

    public class DropDownListSCN0Ambience : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            SCN0Node node = (context.Instance as SCN0EntryNode).Parent.Parent as SCN0Node;
            ResourceNode n = node.FindChild("AmbLights(NW4R)", false);
            if (n != null)
                return new StandardValuesCollection(n.Children.Select(r => r.ToString()).ToList());
            else return null;
        }
    }

    public class DropDownListSCN0Light : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            SCN0Node node = (context.Instance as SCN0EntryNode).Parent.Parent as SCN0Node;
            ResourceNode n = node.FindChild("Lights(NW4R)", false);
            if (n != null)
                return new StandardValuesCollection(n.Children.Select(r => r.ToString()).ToList());
            else return null;
        }
    }

    #endregion

    #region PAT0

    public class DropDownListPAT0Textures : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            PAT0Node main = (context.Instance as PAT0TextureEntryNode).Parent.Parent.Parent as PAT0Node;
            return new StandardValuesCollection(main.Textures);
        }
    }

    public class DropDownListPAT0Palettes : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            PAT0Node main = (context.Instance as PAT0TextureEntryNode).Parent.Parent.Parent as PAT0Node;
            return new StandardValuesCollection(main.Palettes);
        }
    }

    #endregion

    #region RSAR

    public class DropDownListRSARFiles : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            RSAREntryNode n = context.Instance as RSAREntryNode;
            return new StandardValuesCollection(n.RSARNode._infoCache[1].Select(r => r.ToString()).ToList());
        }
    }

    public class DropDownListRWSDSounds : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            RSARFileEntryNode n = context.Instance as RSARFileEntryNode;
            return new StandardValuesCollection(n.Parent.Parent.Children[1].Children.Select(r => r.ToString()).ToList());
        }
    }

    public class DropDownListRSARInfoSound : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            RSARSoundNode n = context.Instance as RSARSoundNode;
            if (n.SoundNode == null) return null;
            return new StandardValuesCollection(n.SoundNode.Children[0].Children.Select(r => r.ToString()).ToList());
        }
    }
    
    public class DropDownListRSARInfoSeqLabls : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            RSARSoundNode n = context.Instance as RSARSoundNode;
            if (n.SoundNode == null || n.SoundType != RSARSoundNode.SndType.SEQ) return null;
            return new StandardValuesCollection(n.SoundNode.Children.Select(r => r.ToString()).ToList());
        }
    }

    public class DropDownListRBNKSounds : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ResourceNode n = context.Instance as RSAREntryNode;
            while (((n = n.Parent) != null) && !(n is RBNKNode)) ;
            return new StandardValuesCollection(n.Children[1].Children.Select(r => r.ToString()).ToList());
        }
    }

    #endregion

    #region REFF
    
    public class DropDownListReffAnimType : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFAnimationNode node = context.Instance as REFFAnimationNode;
            switch (node.CurveFlag)
            {
                case AnimCurveType.ParticleByte:
                case AnimCurveType.ParticleFloat:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetByteFloat)));
                case AnimCurveType.ParticleRotate:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetRotateFloat)));
                case AnimCurveType.ParticleTexture:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetPtclTex)));
                case AnimCurveType.Child:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetChild)));
                case AnimCurveType.Field:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetField)));
                case AnimCurveType.PostField:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetPostField)));
                case AnimCurveType.EmitterFloat:
                    return new StandardValuesCollection(Enum.GetNames(typeof(v9AnimCurveTargetEmitterFloat)));
            }
            return new StandardValuesCollection(null);
        }
    }

    public class DropDownListReffBillboardAssist : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType == BrawlLib.SSBBTypes.ReffType.Billboard)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.BillboardAssist)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffStripeAssist : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType >= BrawlLib.SSBBTypes.ReffType.Stripe)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.StripeAssist)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffAssist : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType != BrawlLib.SSBBTypes.ReffType.Billboard)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.Assist)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffBillboardDirection : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType == BrawlLib.SSBBTypes.ReffType.Billboard)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.BillboardAhead)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffDirection : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType != BrawlLib.SSBBTypes.ReffType.Billboard)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.Ahead)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffStripeConnect : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType >= BrawlLib.SSBBTypes.ReffType.Stripe)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.StripeConnect)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffStripeInitialPrevAxis : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType >= BrawlLib.SSBBTypes.ReffType.Stripe)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.StripeInitialPrevAxis)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffStripeTexmapType : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType >= BrawlLib.SSBBTypes.ReffType.Stripe)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.StripeTexmapType)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffDirectionalPivot : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType == BrawlLib.SSBBTypes.ReffType.Directional)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.DirectionalPivot)));
            return new StandardValuesCollection(null);
        }
    }
    public class DropDownListReffDirectionalFace : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            REFFEmitterNode9 node = context.Instance as REFFEmitterNode9;
            if (node.ParticleType == BrawlLib.SSBBTypes.ReffType.Directional)
                return new StandardValuesCollection(Enum.GetNames(typeof(BrawlLib.SSBBTypes.Face)));
            return new StandardValuesCollection(null);
        }
    }
    #endregion

    public class DropDownListCompression : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            foreach (int i in Compressor._supportedCompressionTypes)
                values.Add(((CompressionType)i).ToString());
            return new StandardValuesCollection(values);
        }
    }

    public class DropDownListRELModuleIDs : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(RELNode._idNames.Values.ToList());
        }
    }

    public class DropDownListARCEntry : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ARCEntryNode entry = context.Instance as ARCEntryNode;
            if (entry.Parent == null) return null;
            List<ARCEntryNode> list = entry.Parent.Children.Select(x => x as ARCEntryNode).ToList();
            list.Remove(entry);
            return new StandardValuesCollection(list);
        }
    }
}
