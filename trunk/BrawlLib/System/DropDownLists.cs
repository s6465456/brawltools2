using System;
using System.ComponentModel;
using System.Globalization;
using BrawlLib.SSBB.ResourceNodes;

namespace System
{
    public class DropDownListMaterials : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._matList);
        } 
    }

    public class DropDownListTextures : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._texList);
        }
    }

    public class DropDownListShaders : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._shadList);
        }
    }

    public class DropDownListBones : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._linker.BoneCache);
        }
    }

    public class DropDownListBonesMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MoveDefEntryNode).Model;
            if (model != null)
                return new StandardValuesCollection(model._linker.BoneCache);
            return null;
        }
    }

    public class DropDownListRequirementsMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = (context.Instance as MoveDefEntryNode).Root.iRequirements;
            if (values != null)
                return new StandardValuesCollection(values);
            return null;
        }
    }

    public class DropDownListGFXFilesMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = (context.Instance as MoveDefEntryNode).Root.iGFXFiles;
            if (values != null)
                return new StandardValuesCollection(values);
            return null;
        }
    }

    public class DropDownListExtNodesMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ResourceNode[] values = (context.Instance as MoveDefEntryNode).Root._externalRefs.ToArray();
            if (values != null)
                return new StandardValuesCollection(values);
            return null;
        }
    }

    public class DropDownListEnumMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = (context.Instance as MoveDefEventValueEnumNode).Enums;
            if (values != null)
                return new StandardValuesCollection(values);
            return null;
        }
    }

    public class DropDownListSCN0Ambience : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            SCN0Node node = (context.Instance as SCN0EntryNode).Parent.Parent as SCN0Node;
            ResourceNode n = node.FindChild("AmbLights(NW4R)", false);
            if (n != null)
                return new StandardValuesCollection(n.Children);
            else return null;
        }
    }

    public class DropDownListColors : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._colorList);
        }
    }

    public class DropDownListVertices : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._vertList);
        }
    }

    public class DropDownListNormals : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._normList);
        }
    }

    public class DropDownListUVs : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MDL0EntryNode).Model;
            return new StandardValuesCollection(model._uvList);
        }
    }

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
}
