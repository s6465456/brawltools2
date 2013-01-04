using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlLib.SSBB.ResourceNodes
{
    public class ObjectParser
    {
        private RELSectionNode ClassSection;

        Dictionary<Relocation, RELType> _types = new Dictionary<Relocation, RELType>();
        List<RELObjectNode> _objects = new List<RELObjectNode>();

        public RELType[] Types { get { return _types.Values.ToArray(); } }
        public RELObjectNode[] Objects { get { return _objects.ToArray(); } }

        public ObjectParser() { }

        public unsafe void Parse(RELSectionNode section)
        {
            if ((ClassSection = section) == null)
                return;

            for (Relocation rel = ClassSection[0]; rel != null; rel = rel.Next)
                ParseDeclaration(rel);

            for (Relocation rel = ClassSection[0]; rel != null; rel = rel.Next)
                ParseObject(ref rel);
        }

        private unsafe RELType ParseDeclaration(Relocation rel)
        {
            RELType type = null;
            string name = null;

            if (_types.TryGetValue(rel, out type))
                return type;

            if (rel.Command == null || rel.Command._targetSection != ClassSection)
                return null;

            name = new string((sbyte*)(rel._data.BaseAddress + rel.FormalValue));

            if (String.IsNullOrEmpty(name))
                return null;

            type = new RELType(name);

            // Get inheritances if any.
            if (rel.Next.Command != null)
                for (Relocation r = rel.Next.Command.TargetRelocation;
                     r != null && r.Command != null;
                     r = r.NextAt(2))
                {
                    RELType inheritance = ParseDeclaration(r.Command.TargetRelocation);
                    if (inheritance != null)
                    {
                        type.Inheritance.Add(new InheritanceItemNode(inheritance, r.Next.RawValue));
                        inheritance.Inherited = true;
                    }
                    else break;
                }

            rel.Tags.Add(type.FormalName + " Declaration");
            rel.Next.Tags.Add(type.FormalName + "->Inheritances");

            _types.Add(rel, type);
            return type;
        }

        private unsafe RELObjectNode ParseObject(ref Relocation rel)
        {
            if (rel.Command == null || rel.Command._targetSection != ClassSection)
                return null;

            RELType declaration = null;

            if (!_types.TryGetValue(rel.Command.TargetRelocation, out declaration) || declaration.Inherited)
                return null;

            RELObjectNode obj = new RELObjectNode(declaration);
            obj.Parent = ClassSection;
            new RELGroupNode() { _name = "Inheritance" }.Parent = obj;
            foreach (InheritanceItemNode n in declaration.Inheritance)
                n.Parent = obj.Children[0];
            new RELGroupNode() { _name = "Functions" }.Parent = obj;

            Relocation baseRel = rel;

            int methodIndex = 0;
            int setIndex = 0;

            // Read object methods.
            while (rel.Command != null && (rel.Command._targetSection != ClassSection || rel.OffsetValue == baseRel.OffsetValue))
            {
                if (rel.OffsetValue != baseRel.OffsetValue)
                {
                    new RELMethodNode() { _name = String.Format("Function[{0}][{1}]", setIndex, methodIndex) }.Initialize(obj.Children[1], rel.Target.Address, 0);
                    methodIndex++;
                }
                else
                {
                    if (rel.Next.RawValue != 0)
                        setIndex++;

                    methodIndex = 0;
                    rel = rel.Next;
                }
                rel = rel.Next;
            }

            baseRel.Tags.Add(obj.Type.FullName);

            _objects.Add(obj);
            return obj;
        }
    }
}
