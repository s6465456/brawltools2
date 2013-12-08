using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace BrawlLib.Modeling
{
    class TriangleConverter
    {
        public static bool UseTristrips = false;
        public static List<PrimitiveGroup> GroupPrimitives(List<FacepointTriangle> t)
        {
            List<PrimitiveGroup> groups = new List<PrimitiveGroup>();

            List<FacepointTriangle> triangles = new List<FacepointTriangle>();
            foreach (FacepointTriangle x in t)
                triangles.Add(x);

            PrimitiveGroup group = new PrimitiveGroup();

            bool NewGroup = true;
            PrimitiveGroup grp = new PrimitiveGroup();
            if (UseTristrips)
            {
                List<FacepointTristrip> strips = new List<FacepointTristrip>();

            Top:
                FacepointTristrip strip = new FacepointTristrip();
                for (int x = 0; x < triangles.Count; x++)
                {
                    FacepointTriangle current = triangles[x];
                    if (Recursive(ref strip, ref triangles, current, true))
                    {
                        strips.Add(strip);
                        goto Top;
                    }
                }

                //Group strips first
                for (int i = 0; i < strips.Count; i++)
                {
                Top1:
                    if (NewGroup) //Create a new group of triangles and node ids
                    {
                        grp = new PrimitiveGroup();
                        NewGroup = false;
                    }
                    if (!(grp.TryAdd(strips[i]))) //Will add automatically if true
                    {
                        bool added = false;
                        foreach (PrimitiveGroup g in groups)
                            if (grp.TryAdd(strips[i]))
                            {
                                added = true;
                                break;
                            }
                        if (!added)
                        {
                            groups.Add(grp);
                            NewGroup = true;
                            goto Top1;
                        }
                    }
                    if (i == strips.Count - 1) //Last strip
                        groups.Add(grp);
                }
            }

            //Now group triangles
            //NewGroup = false;
            if (groups.Count > 0)
                grp = groups[0];
            else
                grp = new PrimitiveGroup();
            for (int i = 0; i < triangles.Count; i++)
            {
            Top2:
                if (NewGroup) //Create a new group of triangles and node ids
                {
                    grp = new PrimitiveGroup();
                    NewGroup = false;
                }
                if (!(grp.TryAdd(triangles[i]))) //Will add automatically if true
                {
                    bool added = false;
                    foreach (PrimitiveGroup g in groups)
                        if (grp.TryAdd(triangles[i]))
                        {
                            added = true;
                            break;
                        }
                    if (!added)
                    {
                        groups.Add(grp);
                        NewGroup = true;
                        goto Top2;
                    }
                }
                if (i == triangles.Count - 1) //Last triangle
                    groups.Add(grp);
            }

            return groups;
        }

        public static bool Recursive(ref FacepointTristrip strip, ref List<FacepointTriangle> triangles, FacepointTriangle current, bool first)
        {
            Facepoint one = current._y;
            Facepoint two = current._z;
            for (int x = 0; x < triangles.Count; x++)
            {
                FacepointTriangle compare = triangles[x];
                for (int i = 0; i < 3; i++)
                {
                    if (compare._x._vertex.Equals(two._vertex) &&
                        compare._y._vertex.Equals(one._vertex) && 
                        strip.CanAdd(compare))
                    {
                        triangles.RemoveAt(x);
                        if (first)
                        {
                            triangles.Remove(current);
                            strip.Initialize(current);
                        }

                        strip.Add(compare);

                        Recursive(ref strip, ref triangles, compare, false);
                        return true;
                    }
                    else
                        compare = compare.RotateUp();
                }
            }
            return false;
        }
    }
}
