using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlLib.Modeling
{
    class TriangleConverter
    {
        public static PrimitiveGroup[] GroupPrimitives(Triangle[] triangles)
        {
            List<PrimitiveGroup> groups = new List<PrimitiveGroup>();

            PrimitiveGroup group = new PrimitiveGroup();
            Tristrip strip = new Tristrip();
            
            List<Tristrip> strips = new List<Tristrip>();
            for (int x = 0; x < triangles.Length; x++)
            {
                Triangle current = triangles[x];
                if (current._grouped) continue;
                if (Recursive(ref strip, triangles, current, true))
                {
                    //We have a complete tristrip.
                    strips.Add(strip);
                }
            }

            return groups.ToArray();
        }

        //012 132 234
        //012 321 234
        public static bool Recursive(ref Tristrip strip, Triangle[] triangles, Triangle current, bool first)
        {
            Facepoint one = current._y;
            Facepoint two = current._z;
            bool found = false;
            for (int x = 0; x < triangles.Length; x++)
            {
                Triangle compare = triangles[x];
                if (compare._grouped || compare == current)
                    continue;
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (compare._x._vertexIndex == two._vertexIndex && 
                            compare._y._vertexIndex == one._vertexIndex &&
                            compare._x.NodeID == two.NodeID &&
                            compare._y.NodeID == one.NodeID)
                        {
                            if (first)
                            {
                                current._grouped = true;
                                strip._temp.Add(current);
                                strip._points.Add(current._x);
                                strip._points.Add(current._y);
                                strip._points.Add(current._z);
                            }

                            strip._temp.Add(compare);
                            strip._points.Add(compare._z);
                            compare._grouped = true;
                            current = compare;
                            found = true;
                            break;
                        }
                        else
                            compare = compare.RotateUp();
                    }
                }
                if (found) break;
            }
            if (found)
            {
                Recursive(ref strip, triangles, current, false);
                return true;
            }
            return false;
        }
    }
}
