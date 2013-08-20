using System;
using System.IO;
using System.Xml;
using BrawlLib.OpenGL;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Modeling;
using System.Collections.Generic;
using BrawlLib.Imaging;
using BrawlLib.Wii.Models;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Reflection;
using System.Globalization;
using BrawlLib.Wii.Animations;

namespace BrawlLib.Modeling
{
    public unsafe partial class Collada
    {
        static XmlWriterSettings _writerSettings = new XmlWriterSettings() { Indent = true, IndentChars = "\t", NewLineChars = "\r\n", NewLineHandling = NewLineHandling.Replace };
        public static void Serialize(MDL0Node model, string outFile)
        {
            model.Populate();
            model.ApplyCHR(null, 0);

            using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 0x1000, FileOptions.SequentialScan))
            using (XmlWriter writer = XmlWriter.Create(stream, _writerSettings))
            {
                writer.Flush();
                stream.Position = 0;

                writer.WriteStartDocument();
                writer.WriteStartElement("COLLADA", "http://www.collada.org/2008/03/COLLADASchema");
                writer.WriteAttributeString("version", "1.4.1");

                writer.WriteStartElement("asset");
                writer.WriteStartElement("contributor");
                writer.WriteElementString("authoring_tool", Application.ProductName);
                writer.WriteEndElement();
                writer.WriteStartElement("unit");
                writer.WriteAttributeString("meter", "0.01");
                writer.WriteAttributeString("name", "centimeter");
                writer.WriteEndElement();
                writer.WriteElementString("up_axis", "Y_UP");
                writer.WriteEndElement();

                //Define images
                WriteImages(model, Path.GetDirectoryName(outFile), writer);

                //Define materials
                WriteMaterials(model, writer);

                //Define effects
                WriteEffects(model, writer);

                //Define geometry
                //Create a geometry object for each polygon
                WriteGeometry(model, writer);

                //Define controllers
                //Each weighted polygon needs a controller, which assigns weights to each vertex.
                WriteControllers(model, writer);

                //Define scenes
                writer.WriteStartElement("library_visual_scenes");
                writer.WriteStartElement("visual_scene");

                //Attach nodes/bones to scene, starting with TopN
                //Specify transform for each node
                //Weighted polygons must use instance_controller
                //Standard geometry uses instance_geometry

                writer.WriteAttributeString("id", "RootNode");
                writer.WriteAttributeString("name", "RootNode");

                //Define bones and geometry instances
                WriteNodes(model, writer);

                writer.WriteEndElement(); //visual scene
                writer.WriteEndElement(); //library visual scenes

                writer.WriteStartElement("scene");
                writer.WriteStartElement("instance_visual_scene");
                writer.WriteAttributeString("url", "#RootNode");
                writer.WriteEndElement(); //instance visual scene

                writer.WriteEndElement(); //scene
                writer.Close();
            }
        }

        private static void WriteImages(MDL0Node model, string path, XmlWriter writer)
        {
            if (model._texList == null)
                return;

            writer.WriteStartElement("library_images");

            foreach (MDL0TextureNode tex in model._texList)
            {
                writer.WriteStartElement("image");
                writer.WriteAttributeString("id", tex.Name + "-image");
                writer.WriteAttributeString("name", tex.Name);
                writer.WriteStartElement("init_from");

                string outPath = String.Format("{0}/{1}.png", path.Replace('\\', '/'), tex.Name);

                //Export image and set full path. Or, cheat...
                writer.WriteString(String.Format("file://{0}", outPath));

                writer.WriteEndElement(); //init_from
                writer.WriteEndElement(); //image
            }

            writer.WriteEndElement(); //library_images
        }

        private static unsafe void WriteMaterials(MDL0Node model, XmlWriter writer)
        {
            ResourceNode node = model._matGroup;
            if (node == null)
                return;

            writer.WriteStartElement("library_materials");

            foreach (MDL0MaterialNode mat in node.Children)
            {
                writer.WriteStartElement("material");
                writer.WriteAttributeString("id", mat._name);
                writer.WriteStartElement("instance_effect");
                writer.WriteAttributeString("url", String.Format("#{0}-fx", mat._name));
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static unsafe void WriteEffects(MDL0Node model, XmlWriter writer)
        {
            ResourceNode node = model._matGroup;
            if (node == null)
                return;

            writer.WriteStartElement("library_effects");

            foreach (MDL0MaterialNode mat in node.Children)
            {
                writer.WriteStartElement("effect");
                writer.WriteAttributeString("id", mat._name + "-fx");
                writer.WriteStartElement("profile_COMMON");
                writer.WriteStartElement("technique");
                writer.WriteAttributeString("sid", "standard");
                writer.WriteStartElement("phong");

                writer.WriteStartElement("diffuse");

                foreach (MDL0MaterialRefNode mr in mat._children)
                {
                    if (mr._texture != null)
                    {
                        writer.WriteStartElement("texture");
                        writer.WriteAttributeString("texture", mr._texture.Name + "-image");
                        writer.WriteAttributeString("texcoord", "TEXCOORD" + (mr.TextureCoordId < 0 ? 0 : mr.TextureCoordId));
                        writer.WriteEndElement(); //texture
                    }
                }

                writer.WriteEndElement(); //diffuse

                writer.WriteEndElement(); //phong
                writer.WriteEndElement(); //technique
                writer.WriteEndElement(); //profile
                writer.WriteEndElement(); //effect
            }

            writer.WriteEndElement(); //library
        }

        private static unsafe void WriteGeometry(MDL0Node model, XmlWriter writer)
        {
            ResourceNode grp = model._objGroup;
            if (grp == null)
                return;

            writer.WriteStartElement("library_geometries");

            foreach (MDL0ObjectNode poly in grp.Children)
            {
                PrimitiveManager manager = poly._manager;

                //Geometry
                writer.WriteStartElement("geometry");
                writer.WriteAttributeString("id", poly.Name);
                writer.WriteAttributeString("name", poly.Name);

                //Mesh
                writer.WriteStartElement("mesh");

                //Write vertex data first
                WriteVertices(poly._name, manager._vertices, poly.MatrixNode, writer);

                //Face assets
                for (int i = 0; i < 12; i++)
                {
                    if (manager._faceData[i] == null)
                        continue;

                    switch (i)
                    {
                        case 0:
                            break;

                        case 1:
                            WriteNormals(poly._name, writer, manager);
                            break;

                        case 2:
                        case 3:
                            WriteColors(poly._name, manager, i - 2, writer);
                            break;

                        default:
                            WriteUVs(poly._name, manager, i - 4, writer);
                            break;
                    }
                }

                //Vertices
                writer.WriteStartElement("vertices");
                writer.WriteAttributeString("id", poly.Name + "_Vertices");
                writer.WriteStartElement("input");
                writer.WriteAttributeString("semantic", "POSITION");
                writer.WriteAttributeString("source", "#" + poly.Name + "_Positions");
                writer.WriteEndElement(); //input
                writer.WriteEndElement(); //vertices

                //Faces
                if (manager._triangles != null)
                    WritePrimitive(poly, manager._triangles, writer);
                if (manager._lines != null)
                    WritePrimitive(poly, manager._lines, writer);
                if (manager._points != null)
                    WritePrimitive(poly, manager._points, writer);

                writer.WriteEndElement(); //mesh
                writer.WriteEndElement(); //geometry
            }

            writer.WriteEndElement();
        }

        private static void WriteVertices(string name, List<Vertex3> vertices, IMatrixNode singleBind, XmlWriter writer)
        {
            bool first = true;

            //Position source
            writer.WriteStartElement("source");
            writer.WriteAttributeString("id", name + "_Positions");

            //Array start
            writer.WriteStartElement("float_array");
            writer.WriteAttributeString("id", name + "_PosArr");
            writer.WriteAttributeString("count", (vertices.Count * 3).ToString());

            foreach (Vertex3 v in vertices)
            {
                if (first)
                    first = false;
                else
                    writer.WriteString(" ");

                Vector3 p = v.WeightedPosition;
                writer.WriteString(String.Format("{0} {1} {2}", p._x.ToString(CultureInfo.InvariantCulture.NumberFormat), p._y.ToString(CultureInfo.InvariantCulture.NumberFormat), p._z.ToString(CultureInfo.InvariantCulture.NumberFormat)));
            }

            writer.WriteEndElement(); //float_array

            //Technique
            writer.WriteStartElement("technique_common");

            writer.WriteStartElement("accessor");
            writer.WriteAttributeString("source", "#" + name + "_PosArr");
            writer.WriteAttributeString("count", vertices.Count.ToString());
            writer.WriteAttributeString("stride", "3");

            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "X");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "Y");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "Z");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param

            writer.WriteEndElement(); //accessor
            writer.WriteEndElement(); //technique_common

            writer.WriteEndElement(); //source
        }

        static Vector3[] _normals;
        static List<int> _normRemap;
        private static void WriteNormals(string name, XmlWriter writer, PrimitiveManager p)
        {
            bool first = true;
            ushort* pIndex = (ushort*)p._indices.Address;
            Vector3* pData = (Vector3*)p._faceData[1].Address;
            Vector3 v;

            HashSet<Vector3> list = new HashSet<Vector3>();
            for (int i = 0; i < p._pointCount; i++)
                list.Add(p._vertices[pIndex[i]].GetMatrix().GetRotationMatrix() * pData[i]);

            _normals = new Vector3[list.Count];
            list.CopyTo(_normals);

            int count = _normals.Length;
            _normRemap = new List<int>();
            for (int i = 0; i < p._pointCount; i++)
                _normRemap.Add(Array.IndexOf(_normals, p._vertices[pIndex[i]].GetMatrix().GetRotationMatrix() * pData[i]));

            //Position source
            writer.WriteStartElement("source");
            writer.WriteAttributeString("id", name + "_Normals");

            //Array start
            writer.WriteStartElement("float_array");
            writer.WriteAttributeString("id", name + "_NormArr");
            writer.WriteAttributeString("count", (count * 3).ToString());

            for (int i = 0; i < count; i++)
            {
                if (first)
                    first = false;
                else
                    writer.WriteString(" ");

                v = _normals[i];

                writer.WriteString(String.Format("{0} {1} {2}", v._x.ToString(CultureInfo.InvariantCulture.NumberFormat), v._y.ToString(CultureInfo.InvariantCulture.NumberFormat), v._z.ToString(CultureInfo.InvariantCulture.NumberFormat)));
            }

            writer.WriteEndElement(); //float_array

            //Technique
            writer.WriteStartElement("technique_common");

            writer.WriteStartElement("accessor");
            writer.WriteAttributeString("source", "#" + name + "_NormArr");
            writer.WriteAttributeString("count", count.ToString());
            writer.WriteAttributeString("stride", "3");

            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "X");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "Y");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "Z");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param

            writer.WriteEndElement(); //accessor
            writer.WriteEndElement(); //technique_common

            writer.WriteEndElement(); //source
        }
        static RGBAPixel[][] _colors = new RGBAPixel[2][];
        static List<int>[] _colorRemap = new List<int>[2];
        const float cFactor = 1.0f / 255.0f;
        private static void WriteColors(string name, PrimitiveManager p, int set, XmlWriter writer)
        {
            bool first = true;

            _colors[set] = p.GetColors(set, true);
            int count = _colors[set].Length;
            _colorRemap[set] = new List<int>();
            RGBAPixel* ptr = (RGBAPixel*)p._faceData[set + 2].Address;
            for (int i = 0; i < p._pointCount; i++)
                _colorRemap[set].Add(Array.IndexOf(_colors[set], ptr[i]));

            //Position source
            writer.WriteStartElement("source");
            writer.WriteAttributeString("id", name + "_Colors" + set.ToString());

            //Array start
            writer.WriteStartElement("float_array");
            writer.WriteAttributeString("id", name + "_ColorArr" + set.ToString());
            writer.WriteAttributeString("count", (count * 4).ToString());

            for (int i = 0; i < count; i++)
            {
                if (first)
                    first = false;
                else
                    writer.WriteString(" ");
                
                RGBAPixel r = _colors[set][i];

                writer.WriteString(String.Format("{0} {1} {2} {3}", r.R * cFactor, r.G * cFactor, r.B * cFactor, r.A * cFactor));
            }

            writer.WriteEndElement(); //int_array

            //Technique
            writer.WriteStartElement("technique_common");

            writer.WriteStartElement("accessor");
            writer.WriteAttributeString("source", "#" + name + "_ColorArr" + set.ToString());
            writer.WriteAttributeString("count", count.ToString());
            writer.WriteAttributeString("stride", "4");

            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "R");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "G");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "B");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "A");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param

            writer.WriteEndElement(); //accessor
            writer.WriteEndElement(); //technique_common

            writer.WriteEndElement(); //source
        }

        static Vector2[][] _uvs = new Vector2[8][];
        static List<int>[] _uvRemap = new List<int>[8];
        private static void WriteUVs(string name, PrimitiveManager p, int set, XmlWriter writer)
        {
            bool first = true;

            _uvs[set] = p.GetUVs(set, true);
            int count = _uvs[set].Length;
            _uvRemap[set] = new List<int>();
            Vector2* ptr = (Vector2*)p._faceData[set + 4].Address;
            for (int i = 0; i < p._pointCount; i++)
                _uvRemap[set].Add(Array.IndexOf(_uvs[set], ptr[i]));

            //Position source
            writer.WriteStartElement("source");
            writer.WriteAttributeString("id", name + "_UVs" + set.ToString());

            //Array start
            writer.WriteStartElement("float_array");
            writer.WriteAttributeString("id", name + "_UVArr" + set.ToString());
            writer.WriteAttributeString("count", (count * 2).ToString());

            for (int i = 0; i < count; i++)
            {
                if (first)
                    first = false;
                else
                    writer.WriteString(" ");

                //Reverse T component to a top-down form
                //writer.WriteString(String.Format("{0} {1}", pData->_x, 1.0 - pData->_y));
                //pData++;
                writer.WriteString(String.Format("{0} {1}", _uvs[set][i]._x.ToString(CultureInfo.InvariantCulture.NumberFormat), (1.0f - _uvs[set][i]._y).ToString(CultureInfo.InvariantCulture.NumberFormat)));
            }

            writer.WriteEndElement(); //int_array

            //Technique
            writer.WriteStartElement("technique_common");

            writer.WriteStartElement("accessor");
            writer.WriteAttributeString("source", "#" + name + "_UVArr" + set.ToString());
            writer.WriteAttributeString("count", count.ToString());
            writer.WriteAttributeString("stride", "2");

            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "S");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param
            writer.WriteStartElement("param");
            writer.WriteAttributeString("name", "T");
            writer.WriteAttributeString("type", "float");
            writer.WriteEndElement(); //param

            writer.WriteEndElement(); //accessor
            writer.WriteEndElement(); //technique_common

            writer.WriteEndElement(); //source
        }

        private static unsafe void WritePrimitive(MDL0ObjectNode poly, NewPrimitive prim, XmlWriter writer)
        {
            PrimitiveManager manager = poly._manager;
            int count;
            int elements = 0, stride = 0;
            int set;
            bool first;
            uint* pData = (uint*)prim._indices.Address;
            ushort* pVert = (ushort*)poly._manager._indices.Address;

            switch (prim._type)
            {
                case BeginMode.Triangles:
                    writer.WriteStartElement("triangles");
                    stride = 3;
                    break;

                case BeginMode.Lines:
                    writer.WriteStartElement("lines");
                    stride = 2;
                    break;

                case BeginMode.Points:
                    writer.WriteStartElement("points");
                    stride = 1;
                    break;
            }
            count = prim._elementCount / stride;

            if (poly.UsableMaterialNode != null)
                writer.WriteAttributeString("material", poly.UsableMaterialNode.Name);

            writer.WriteAttributeString("count", count.ToString());

            List<int> elementType = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                if (manager._faceData[i] == null)
                    continue;

                writer.WriteStartElement("input");

                switch (i)
                {
                    case 0:
                        writer.WriteAttributeString("semantic", "VERTEX");
                        writer.WriteAttributeString("source", "#" + poly._name + "_Vertices");
                        break;

                    case 1:
                        writer.WriteAttributeString("semantic", "NORMAL");
                        writer.WriteAttributeString("source", "#" + poly._name + "_Normals");
                        break;

                    case 2:
                    case 3:
                        set = i - 2;
                        writer.WriteAttributeString("semantic", "COLOR");
                        writer.WriteAttributeString("source", "#" + poly._name + "_Colors" + set.ToString());
                        writer.WriteAttributeString("set", set.ToString());
                        break;

                    default:
                        set = i - 4;
                        writer.WriteAttributeString("semantic", "TEXCOORD");
                        writer.WriteAttributeString("source", "#" + poly._name + "_UVs" + set.ToString());
                        writer.WriteAttributeString("set", set.ToString());
                        break;
                }

                writer.WriteAttributeString("offset", elements.ToString());
                writer.WriteEndElement(); //input

                elements++;
                elementType.Add(i);
            }

            for (int i = 0; i < count; i++)
            {
                writer.WriteStartElement("p");
                first = true;
                for (int x = 0; x < stride; x++)
                {
                    int index = (int)*pData++;
                    for (int y = 0; y < elements; y++)
                    {
                        if (first)
                            first = false;
                        else
                            writer.WriteString(" ");

                        if (elementType[y] < 4)
                            if (elementType[y] < 2)
                                if (elementType[y] == 0)
                                    writer.WriteString(pVert[index].ToString(CultureInfo.InvariantCulture.NumberFormat));
                                else
                                    writer.WriteString(_normRemap[index].ToString(CultureInfo.InvariantCulture.NumberFormat));
                            else
                                writer.WriteString(_colorRemap[elementType[y] - 2][index].ToString(CultureInfo.InvariantCulture.NumberFormat));
                        else
                            writer.WriteString(_uvRemap[elementType[y] - 4][index].ToString(CultureInfo.InvariantCulture.NumberFormat));
                    }
                }
                writer.WriteEndElement(); //p
            }

            writer.WriteEndElement(); //primitive
        }

        private static unsafe void WriteControllers(MDL0Node model, XmlWriter writer)
        {
            if (model._objList == null)
                return;

            writer.WriteStartElement("library_controllers");

            int g = 0;
            //List<MDL0BoneNode> boneSet = new List<MDL0BoneNode>();

            MDL0BoneNode[] bones = new MDL0BoneNode[model._linker.BoneCache.Length];
            model._linker.BoneCache.CopyTo(bones, 0);

            //foreach (MDL0BoneNode b in model._linker.BoneCache)
            //{
            //    b._nodeIndex = g++;
            //    boneSet.Add(b);
            //}

            HashSet<float> temp = new HashSet<float>();
            Matrix m;
            bool first;

            foreach (MDL0ObjectNode poly in model._objList)
            {
                List<Vertex3> verts = poly._manager._vertices;

                writer.WriteStartElement("controller");
                writer.WriteAttributeString("id", poly.Name + "_Controller");
                writer.WriteStartElement("skin");
                writer.WriteAttributeString("source", "#" + poly.Name);

                writer.WriteStartElement("bind_shape_matrix");

                //Set bind pose matrix
                //if (poly._singleBind != null)
                //    m = poly._singleBind.Matrix;
                //else
                    m = Matrix.Identity;

                writer.WriteString(WriteMatrix(m));

                writer.WriteEndElement();

                //Get list of used bones and weights

                //int index = 0;
                if (poly._matrixNode != null)
                {
                    foreach (BoneWeight w in poly._matrixNode.Weights)
                    {
                        //if (!boneSet.Contains(w.Bone))
                        //{
                        //    boneSet.Add(w.Bone);
                        //    w.Bone._nodeIndex = index++;
                        //}
                        //if (!weightSet.Contains(w.Weight))
                            temp.Add(w.Weight);
                    }
                }
                else
                {
                    foreach (Vertex3 v in verts)
                        foreach (BoneWeight w in v._matrixNode.Weights)
                        {
                            //if (!boneSet.Contains(w.Bone))
                            //{
                            //    boneSet.Add(w.Bone);
                            //    w.Bone._nodeIndex = index++;
                            //}
                            //if (!weightSet.Contains(w.Weight))
                                temp.Add(w.Weight);
                        }
                }

                float[] weightSet = new float[temp.Count];
                temp.CopyTo(weightSet);

                //Write joint source
                writer.WriteStartElement("source");
                writer.WriteAttributeString("id", poly.Name + "_Joints");

                //Node array
                writer.WriteStartElement("Name_array");
                writer.WriteAttributeString("id", poly.Name + "_JointArr");
                //writer.WriteAttributeString("count", boneSet.Count.ToString());
                writer.WriteAttributeString("count", bones.Length.ToString());

                first = true;
                //foreach (MDL0BoneNode b in boneSet)
                foreach (MDL0BoneNode b in bones)
                {
                    if (first)
                        first = false;
                    else
                        writer.WriteString(" ");
                    writer.WriteString(b.Name);
                }
                writer.WriteEndElement(); //Name_array

                //Technique
                writer.WriteStartElement("technique_common");
                writer.WriteStartElement("accessor");
                writer.WriteAttributeString("source", String.Format("#{0}_JointArr", poly.Name));
                //writer.WriteAttributeString("count", boneSet.Count.ToString());
                writer.WriteAttributeString("count", bones.Length.ToString());
                writer.WriteStartElement("param");
                writer.WriteAttributeString("name", "JOINT");
                writer.WriteAttributeString("type", "Name");
                writer.WriteEndElement(); //param
                writer.WriteEndElement(); //accessor
                writer.WriteEndElement(); //technique

                writer.WriteEndElement(); //joint source

                //Inverse matrices source
                writer.WriteStartElement("source");
                writer.WriteAttributeString("id", poly.Name + "_Matrices");

                writer.WriteStartElement("float_array");
                writer.WriteAttributeString("id", poly.Name + "_MatArr");
                //writer.WriteAttributeString("count", (boneSet.Count * 16).ToString());
                writer.WriteAttributeString("count", (bones.Length * 16).ToString());

                first = true;
                foreach (MDL0BoneNode b in bones)
                {
                    if (first)
                        first = false;
                    else
                        writer.WriteString(" ");
                    writer.WriteString(WriteMatrix(b.InverseBindMatrix));
                }
                writer.WriteEndElement(); //float_array

                //Technique
                writer.WriteStartElement("technique_common");
                writer.WriteStartElement("accessor");
                writer.WriteAttributeString("source", String.Format("#{0}_MatArr", poly.Name));
                //writer.WriteAttributeString("count", boneSet.Count.ToString());
                writer.WriteAttributeString("count", bones.Length.ToString());
                writer.WriteAttributeString("stride", "16");
                writer.WriteStartElement("param");
                writer.WriteAttributeString("type", "float4x4");
                writer.WriteEndElement(); //param
                writer.WriteEndElement(); //accessor
                writer.WriteEndElement(); //technique

                writer.WriteEndElement(); //source

                //Weights source
                writer.WriteStartElement("source");
                writer.WriteAttributeString("id", poly.Name + "_Weights");

                writer.WriteStartElement("float_array");
                writer.WriteAttributeString("id", poly.Name + "_WeightArr");
                writer.WriteAttributeString("count", weightSet.Length.ToString());
                first = true;

                foreach (float f in weightSet)
                {
                    if (first)
                        first = false;
                    else
                        writer.WriteString(" ");
                    writer.WriteValue(f);
                }
                writer.WriteEndElement();

                //Technique
                writer.WriteStartElement("technique_common");
                writer.WriteStartElement("accessor");
                writer.WriteAttributeString("source", String.Format("#{0}_WeightArr", poly.Name));
                writer.WriteAttributeString("count", weightSet.Length.ToString());
                writer.WriteStartElement("param");
                writer.WriteAttributeString("type", "float");
                writer.WriteEndElement(); //param
                writer.WriteEndElement(); //accessor
                writer.WriteEndElement(); //technique

                writer.WriteEndElement(); //source

                //Joint bindings
                writer.WriteStartElement("joints");
                writer.WriteStartElement("input");
                writer.WriteAttributeString("semantic", "JOINT");
                writer.WriteAttributeString("source", String.Format("#{0}_Joints", poly.Name));
                writer.WriteEndElement(); //input
                writer.WriteStartElement("input");
                writer.WriteAttributeString("semantic", "INV_BIND_MATRIX");
                writer.WriteAttributeString("source", String.Format("#{0}_Matrices", poly.Name));
                writer.WriteEndElement(); //input
                writer.WriteEndElement(); //joints

                //Vertex weights, one for each vertex in geometry
                writer.WriteStartElement("vertex_weights");
                writer.WriteAttributeString("count", verts.Count.ToString());
                writer.WriteStartElement("input");
                writer.WriteAttributeString("semantic", "JOINT");
                writer.WriteAttributeString("offset", "0");
                writer.WriteAttributeString("source", String.Format("#{0}_Joints", poly.Name));
                writer.WriteEndElement(); //input
                writer.WriteStartElement("input");
                writer.WriteAttributeString("semantic", "WEIGHT");
                writer.WriteAttributeString("offset", "1");
                writer.WriteAttributeString("source", String.Format("#{0}_Weights", poly.Name));
                writer.WriteEndElement(); //input

                writer.WriteStartElement("vcount");
                first = true;
                if (poly._matrixNode != null)
                    for (int i = 0; i < verts.Count; i++)
                    {
                        if (first)
                            first = false;
                        else
                            writer.WriteString(" ");
                        writer.WriteString(poly._matrixNode.Weights.Count.ToString(CultureInfo.InvariantCulture.NumberFormat));
                    }
                else
                    foreach (Vertex3 v in verts)
                    {
                        if (first)
                            first = false;
                        else
                            writer.WriteString(" ");
                        writer.WriteString(v._matrixNode.Weights.Count.ToString(CultureInfo.InvariantCulture.NumberFormat));
                    }
                
                writer.WriteEndElement(); //vcount

                writer.WriteStartElement("v");

                first = true;
                if (poly._matrixNode != null)
                    for (int i = 0; i < verts.Count; i++)
                        foreach (BoneWeight w in poly._matrixNode.Weights)
                        {
                            if (first)
                                first = false;
                            else
                                writer.WriteString(" ");
                            //writer.WriteString(w.Bone._nodeIndex.ToString());
                            writer.WriteString(Array.IndexOf(bones, w.Bone).ToString(CultureInfo.InvariantCulture.NumberFormat));
                            writer.WriteString(" ");
                            writer.WriteString(Array.IndexOf(weightSet, w.Weight).ToString(CultureInfo.InvariantCulture.NumberFormat));
                        }
                else
                    foreach (Vertex3 v in verts)
                        foreach (BoneWeight w in v._matrixNode.Weights)
                        {
                            if (first)
                                first = false;
                            else
                                writer.WriteString(" ");
                            //writer.WriteString(w.Bone._nodeIndex.ToString());
                            writer.WriteString(Array.IndexOf(bones, w.Bone).ToString(CultureInfo.InvariantCulture.NumberFormat));
                            writer.WriteString(" ");
                            writer.WriteString(Array.IndexOf(weightSet, w.Weight).ToString(CultureInfo.InvariantCulture.NumberFormat));
                        }
                    
                writer.WriteEndElement(); //v

                writer.WriteEndElement(); //vertex_weights

                writer.WriteEndElement(); //skin
                writer.WriteEndElement(); //controller

                //boneSet.Clear();
                //weightSet.Clear();
            }

            writer.WriteEndElement();
        }

        private static unsafe void WriteNodes(MDL0Node model, XmlWriter writer)
        {
            if (model._boneList != null)
                foreach (MDL0BoneNode bone in model._boneList)
                    WriteBone(bone, writer);

            if (model._objList != null)
                foreach (MDL0ObjectNode poly in model._objList)
                    //if (poly._singleBind == null) //Single bind objects will be written under their bone
                        WritePolyInstance(poly, writer);
        }

        private static unsafe void WriteBone(MDL0BoneNode bone, XmlWriter writer)
        {
            writer.WriteStartElement("node");
            writer.WriteAttributeString("id", bone._name);
            writer.WriteAttributeString("name", bone._name);
            writer.WriteAttributeString("sid", bone._name);
            writer.WriteAttributeString("type", "JOINT");

            writer.WriteStartElement("matrix");
            writer.WriteString(WriteMatrix(bone._bindState._transform));
            writer.WriteEndElement(); //matrix

            //Write single-bind geometry
            //foreach (MDL0PolygonNode poly in bone._infPolys)
            //    WritePolyInstance(poly, writer);

            foreach (MDL0BoneNode b in bone.Children)
                WriteBone(b, writer);

            writer.WriteEndElement(); //node
        }

        private static void WritePolyInstance(MDL0ObjectNode poly, XmlWriter writer)
        {
            writer.WriteStartElement("node");
            writer.WriteAttributeString("id", poly.Name);
            writer.WriteAttributeString("name", poly.Name);

            writer.WriteStartElement("instance_controller");
            writer.WriteAttributeString("url", String.Format("#{0}_Controller", poly.Name));
            
            writer.WriteStartElement("skeleton");
            writer.WriteString("#" + poly.Model._linker.BoneCache[0].Name);
            writer.WriteEndElement();

            if (poly.UsableMaterialNode != null)
            {
                writer.WriteStartElement("bind_material");
                writer.WriteStartElement("technique_common");
                writer.WriteStartElement("instance_material");
                writer.WriteAttributeString("symbol", poly.UsableMaterialNode.Name);
                writer.WriteAttributeString("target", "#" + poly.UsableMaterialNode.Name);

                foreach (MDL0MaterialRefNode mr in poly.UsableMaterialNode.Children)
                {
                    writer.WriteStartElement("bind_vertex_input");
                    writer.WriteAttributeString("semantic", "TEXCOORD" + (mr.TextureCoordId < 0 ? 0 : mr.TextureCoordId)); //Replace with true set id
                    writer.WriteAttributeString("input_semantic", "TEXCOORD");
                    writer.WriteAttributeString("input_set", (mr.TextureCoordId < 0 ? 0 : mr.TextureCoordId).ToString()); //Replace with true set id
                    writer.WriteEndElement(); //bind_vertex_input
                }

                writer.WriteEndElement(); //instance_material
                writer.WriteEndElement(); //technique_common
                writer.WriteEndElement(); //bind_material
            }

            writer.WriteEndElement(); //instance_geometry
            writer.WriteEndElement(); //node
        }

        private static unsafe string WriteMatrix(Matrix m)
        {
            string s = "";
            float* p = (float*)&m;
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                {
                    if ((x != 0) || (y != 0))
                        s += " ";
                    s += p[(x << 2) + y].ToString(CultureInfo.InvariantCulture.NumberFormat);
                }
            return s;
        }

        public static void Serialize(CHR0Node[] animations, float fps, bool bake, string outFile)
        {
            string[] types = new string[] { "scale", "rotate", "translate" };
            string[] axes = new string[] { "X", "Y", "Z" };
            bool first = true;

            using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 0x1000, FileOptions.SequentialScan))
            using (XmlWriter writer = XmlWriter.Create(stream, _writerSettings))
            {
                writer.Flush();
                stream.Position = 0;

                writer.WriteStartDocument();
                writer.WriteStartElement("COLLADA", "http://www.collada.org/2008/03/COLLADASchema");
                writer.WriteAttributeString("version", "1.4.1");

                writer.WriteStartElement("asset");
                writer.WriteStartElement("contributor");
                writer.WriteElementString("authoring_tool", Application.ProductName);
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("library_animations");
                {
                    foreach (CHR0Node animation in animations)
                    {
                        string animName = animation.Name;
                        
                        writer.WriteStartElement("animation");
                        writer.WriteAttributeString("name", animName);
                        writer.WriteAttributeString("id", animName);
                        {
                            foreach (CHR0EntryNode en in animation.Children)
                            {
                                string bone = en.Name;
                                KeyframeCollection keyframes = en.Keyframes;

                                for (int index = 0; index < 9; index++)
                                {
                                    KeyFrameMode mode = (KeyFrameMode)(index + 0x10);
                                    int keyFrameCount = keyframes[mode];

                                    if (keyFrameCount <= 0)
                                        continue;

                                    string type = types[index / 3];
                                    string axis = axes[index % 3];

                                    string name = String.Format("{0}_{1}{2}", bone, type, axis);

                                    //writer.WriteStartElement("animation");
                                    //writer.WriteAttributeString("id", name);
                                    {
                                        #region Input source
                                        writer.WriteStartElement("source");
                                        writer.WriteAttributeString("id", name + "_input");
                                        {
                                            writer.WriteStartElement("float_array");
                                            writer.WriteAttributeString("id", name + "_inputArr");
                                            writer.WriteAttributeString("count", keyFrameCount.ToString());
                                            {
                                                first = true;
                                                for (KeyframeEntry entry = keyframes._keyRoots[index]._next; (entry != keyframes._keyRoots[index]); entry = entry._next)
                                                {
                                                    if (first)
                                                        first = false;
                                                    else
                                                        writer.WriteString(" ");
                                                    writer.WriteString(((float)entry._index / fps).ToString(CultureInfo.InvariantCulture.NumberFormat));
                                                }
                                            }
                                            writer.WriteEndElement(); //float_array

                                            writer.WriteStartElement("technique_common");
                                            {
                                                writer.WriteStartElement("accessor");
                                                writer.WriteAttributeString("source", "#" + name + "_inputArr");
                                                writer.WriteAttributeString("count", keyFrameCount.ToString());
                                                writer.WriteAttributeString("stride", "1");
                                                {
                                                    writer.WriteStartElement("param");
                                                    writer.WriteAttributeString("name", "TIME");
                                                    writer.WriteAttributeString("type", "float");
                                                    writer.WriteEndElement(); //param
                                                }
                                                writer.WriteEndElement(); //accessor
                                            }
                                            writer.WriteEndElement(); //technique_common

                                            writer.WriteStartElement("technique");
                                            writer.WriteAttributeString("profile", "MAYA");
                                            {
                                                writer.WriteStartElement("pre_infinity");
                                                writer.WriteString("CONSTANT");
                                                writer.WriteEndElement(); //pre_infinity

                                                writer.WriteStartElement("post_infinity");
                                                writer.WriteString("CONSTANT");
                                                writer.WriteEndElement(); //post_infinity
                                            }
                                            writer.WriteEndElement(); //technique
                                        }
                                        writer.WriteEndElement(); //source
                                        #endregion

                                        #region Output source
                                        writer.WriteStartElement("source");
                                        writer.WriteAttributeString("id", name + "_output");
                                        {
                                            writer.WriteStartElement("float_array");
                                            writer.WriteAttributeString("id", name + "_outputArr");
                                            writer.WriteAttributeString("count", keyFrameCount.ToString());
                                            {
                                                first = true;
                                                for (KeyframeEntry entry = keyframes._keyRoots[index]._next; (entry != keyframes._keyRoots[index]); entry = entry._next)
                                                {
                                                    if (first)
                                                        first = false;
                                                    else
                                                        writer.WriteString(" ");
                                                    writer.WriteString(((float)entry._value).ToString(CultureInfo.InvariantCulture.NumberFormat));
                                                }
                                            }
                                            writer.WriteEndElement(); //float_array

                                            writer.WriteStartElement("technique_common");
                                            {
                                                writer.WriteStartElement("accessor");
                                                writer.WriteAttributeString("source", "#" + name + "_outputArr");
                                                writer.WriteAttributeString("count", keyFrameCount.ToString());
                                                writer.WriteAttributeString("stride", "1");
                                                {
                                                    writer.WriteStartElement("param");
                                                    writer.WriteAttributeString("name", "TRANSFORM");
                                                    writer.WriteAttributeString("type", "float");
                                                    writer.WriteEndElement(); //param
                                                }
                                                writer.WriteEndElement(); //accessor
                                            }
                                            writer.WriteEndElement(); //technique_common
                                        }
                                        writer.WriteEndElement(); //source
                                        #endregion

                                        #region In Tangent source
                                        writer.WriteStartElement("source");
                                        writer.WriteAttributeString("id", name + "_inTan");
                                        {
                                            writer.WriteStartElement("float_array");
                                            writer.WriteAttributeString("id", name + "_inTanArr");
                                            writer.WriteAttributeString("count", keyFrameCount.ToString());
                                            {
                                                first = true;
                                                for (KeyframeEntry entry = keyframes._keyRoots[index]._next; (entry != keyframes._keyRoots[index]); entry = entry._next)
                                                {
                                                    if (first)
                                                        first = false;
                                                    else
                                                        writer.WriteString(" ");
                                                    writer.WriteString(entry._tangent.ToString(CultureInfo.InvariantCulture.NumberFormat));
                                                }
                                            }
                                            writer.WriteEndElement(); //float_array

                                            writer.WriteStartElement("technique_common");
                                            {
                                                writer.WriteStartElement("accessor");
                                                writer.WriteAttributeString("source", "#" + name + "_inTanArr");
                                                writer.WriteAttributeString("count", keyFrameCount.ToString());
                                                writer.WriteAttributeString("stride", "1");
                                                {
                                                    writer.WriteStartElement("param");
                                                    writer.WriteAttributeString("name", "IN_TANGENT");
                                                    writer.WriteAttributeString("type", "float");
                                                    writer.WriteEndElement(); //param
                                                }
                                                writer.WriteEndElement(); //accessor
                                            }
                                            writer.WriteEndElement(); //technique_common
                                        }
                                        writer.WriteEndElement(); //source
                                        #endregion

                                        #region Out Tangent source
                                        writer.WriteStartElement("source");
                                        writer.WriteAttributeString("id", name + "_outTan");
                                        {
                                            writer.WriteStartElement("float_array");
                                            writer.WriteAttributeString("id", name + "_outTanArr");
                                            writer.WriteAttributeString("count", keyFrameCount.ToString());
                                            {
                                                first = true;
                                                for (KeyframeEntry entry = keyframes._keyRoots[index]._next; (entry != keyframes._keyRoots[index]); entry = entry._next)
                                                {
                                                    if (first)
                                                        first = false;
                                                    else
                                                        writer.WriteString(" ");
                                                    writer.WriteString(entry._tangent.ToString(CultureInfo.InvariantCulture.NumberFormat));
                                                }
                                            }
                                            writer.WriteEndElement(); //float_array

                                            writer.WriteStartElement("technique_common");
                                            {
                                                writer.WriteStartElement("accessor");
                                                writer.WriteAttributeString("source", "#" + name + "_outTanArr");
                                                writer.WriteAttributeString("count", keyFrameCount.ToString());
                                                writer.WriteAttributeString("stride", "1");
                                                {
                                                    writer.WriteStartElement("param");
                                                    writer.WriteAttributeString("name", "OUT_TANGENT");
                                                    writer.WriteAttributeString("type", "float");
                                                    writer.WriteEndElement(); //param
                                                }
                                                writer.WriteEndElement(); //accessor
                                            }
                                            writer.WriteEndElement(); //technique_common
                                        }
                                        writer.WriteEndElement(); //source
                                        #endregion

                                        #region Interpolation source
                                        writer.WriteStartElement("source");
                                        writer.WriteAttributeString("id", name + "_interp");
                                        {
                                            writer.WriteStartElement("Name_array");
                                            writer.WriteAttributeString("id", name + "_interpArr");
                                            writer.WriteAttributeString("count", keyFrameCount.ToString());
                                            {
                                                first = true;
                                                for (KeyframeEntry entry = keyframes._keyRoots[index]._next; (entry != keyframes._keyRoots[index]); entry = entry._next)
                                                {
                                                    if (first)
                                                        first = false;
                                                    else
                                                        writer.WriteString(" ");
                                                    writer.WriteString("HERMITE");
                                                }
                                            }
                                            writer.WriteEndElement(); //Name_array

                                            writer.WriteStartElement("technique_common");
                                            {
                                                writer.WriteStartElement("accessor");
                                                writer.WriteAttributeString("source", "#" + name + "_interpArr");
                                                writer.WriteAttributeString("count", keyFrameCount.ToString());
                                                writer.WriteAttributeString("stride", "1");
                                                {
                                                    writer.WriteStartElement("param");
                                                    writer.WriteAttributeString("name", "INTERPOLATION");
                                                    writer.WriteAttributeString("type", "Name");
                                                    writer.WriteEndElement(); //param
                                                }
                                                writer.WriteEndElement(); //accessor
                                            }
                                            writer.WriteEndElement(); //technique_common
                                        }
                                        writer.WriteEndElement(); //source
                                        #endregion

                                        #region Sampler
                                        writer.WriteStartElement("sampler");
                                        writer.WriteAttributeString("id", name + "_sampler");
                                        {
                                            writer.WriteStartElement("input");
                                            writer.WriteAttributeString("semantic", "INPUT");
                                            writer.WriteAttributeString("source", "#" + name + "_input");
                                            writer.WriteEndElement(); //input

                                            writer.WriteStartElement("input");
                                            writer.WriteAttributeString("semantic", "OUTPUT");
                                            writer.WriteAttributeString("source", "#" + name + "_output");
                                            writer.WriteEndElement(); //input

                                            writer.WriteStartElement("input");
                                            writer.WriteAttributeString("semantic", "IN_TANGENT");
                                            writer.WriteAttributeString("source", "#" + name + "_inTan");
                                            writer.WriteEndElement(); //input

                                            writer.WriteStartElement("input");
                                            writer.WriteAttributeString("semantic", "OUT_TANGEN");
                                            writer.WriteAttributeString("source", "#" + name + "_outTan");
                                            writer.WriteEndElement(); //input

                                            writer.WriteStartElement("input");
                                            writer.WriteAttributeString("semantic", "INTERPOLATION");
                                            writer.WriteAttributeString("source", "#" + name + "_interp");
                                            writer.WriteEndElement(); //input
                                        }
                                        writer.WriteEndElement(); //sampler
                                        #endregion

                                        writer.WriteStartElement("channel");
                                        writer.WriteAttributeString("source", "#" + name + "_sampler");
                                        writer.WriteAttributeString("target", String.Format("{0}/{1}.{2}", bone, type, axis));
                                        writer.WriteEndElement(); //channel
                                    }
                                    //writer.WriteEndElement(); //animation
                                }
                            }
                        }
                        writer.WriteEndElement(); //animation
                    }
                    writer.WriteEndElement(); //library_animations
                    writer.Close();
                }
            }
        }
    }
}
