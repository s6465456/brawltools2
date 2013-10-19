using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BrawlLib.SSBB.ResourceNodes;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class DropDownListBonesMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            MDL0Node model = (context.Instance as MoveDefEntry).Model;
            if (model != null)
                return new StandardValuesCollection(model._linker.BoneCache.Select(n => n.ToString()).ToList());
            return null;
        }
    }

    public class DropDownListRequirementsMDef : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] values = FileManager.iRequirements;
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
            string[] values = FileManager.iGFXFiles;
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
            ResourceNode[] values = (context.Instance as MoveDefEntry)._root._referenceList.ToArray();
            if (values != null)
                return new StandardValuesCollection(values.Select(n => n.ToString()).ToList());
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
}
