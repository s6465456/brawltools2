using System;
using System.Collections.Generic;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Modeling;
using System.Windows.Forms;

namespace BrawlLib.Wii.Models
{
    /// <summary>
    /// Managed collection of influences. Only influences with references should be used.
    /// It is up to the implementation to properly manage this collection.
    /// </summary>
    public class InfluenceManager
    {
        internal List<Influence> _influences = new List<Influence>();
        public List<Influence> Influences { get { return _influences; } }

        public void RemoveBone(MDL0BoneNode bone)
        {
            for (int i = 0; i < _influences.Count; i++)
                _influences[i].RemoveBone2(bone);
        }

        public Influence AddOrCreate(Influence inf)
        {
            //Search for influence in list. If it exists, return it.
            foreach (Influence i in _influences)
                if (i.Equals(inf))
                    return i;

            //Not found, add it to the list.
            _influences.Add(inf);
            return inf;
        }

        public int Count { get { return _influences.Count; } }
        public int CountPrimary
        {
            get
            {
                int count = 0;
                foreach (Influence i in _influences)
                    if (i.IsPrimaryNode)
                        count++;
                return count;
            }
        }
        public int CountWeighted
        {
            get
            {
                int count = 0;
                foreach (Influence i in _influences)
                    if (i.IsWeighted)
                        count++;
                return count;
            }
        }

        //Increases reference count
        public Influence AddOrCreateInf(Influence inf)
        {
            Influence i = AddOrCreate(inf);
            i._refCount++;
            return i;
        }

        public void Remove(Influence inf)
        {
            for (int i = 0; i < _influences.Count; i++)
                if (object.ReferenceEquals(_influences[i], inf))
                {
                    if (inf._refCount-- <= 0)
                        _influences.RemoveAt(i);
                    break;
                }
        }

        //Get all weighted influences
        public Influence[] GetWeighted()
        {
            List<Influence> list = new List<Influence>(_influences.Count);
            foreach (Influence i in _influences)
                if (i.IsWeighted)
                    list.Add(i);

            return list.ToArray();
        }

        //Remove all influences without references
        public void Clean()
        {
            int i = 0;
            while (i < _influences.Count)
            {
                if (_influences[i]._refCount <= 0)
                    _influences.RemoveAt(i);
                else
                    i++;
            }
        }

        //Sorts influences
        public void Sort()
        {
            _influences.Sort(Influence.Compare);
        }
    }

    public class Influence : IMatrixNode
    {
        public override string ToString() { return ""; }

        internal List<IMatrixNodeUser> _references = new List<IMatrixNodeUser>();
        internal int _refCount;
        internal int _index;
        internal int _permanentID;
        internal Matrix _matrix;
        internal Matrix _invMatrix;
        internal List<BoneWeight> _weights;

        public List<BoneWeight> Weights { get { return _weights; } }
        public List<IMatrixNodeUser> References { get { return _references; } }

        public void RemoveBone2(MDL0BoneNode bone)
        {
            foreach (BoneWeight w in _weights)
                if (w.Bone == bone)
                    w.Bone = bone.Parent as MDL0BoneNode;
        }

        public void RemoveBone(MDL0BoneNode bone)
        {
            List<BoneWeight> list = new List<BoneWeight>();

            int removed = 0;

            foreach (BoneWeight w in _weights)
                if (w.Bone != bone)
                    list.Add(w);
                else
                    removed++;

            if (removed == 0)
                return;

            _weights = list;

            Normalize();
        }

        public void Normalize()
        {
            float total = 0;
            foreach (BoneWeight b in Weights)
                total += b.Weight;
            foreach (BoneWeight b in Weights)
                b.Weight = b.Weight / total;
        }

        public int ReferenceCount { get { return _refCount; } set { _refCount = value; } }
        public int NodeIndex { get { return _index; } }
        public int PermanentID { get { return _permanentID; } }

        public Matrix Matrix { get { return _matrix; } }
        public Matrix InverseBindMatrix { get { return _invMatrix; } }

        public bool IsPrimaryNode { get { return false; } }

        public bool IsWeighted { get { return _weights.Count > 1; } }
        public MDL0BoneNode Bone { get { return _weights[0].Bone; } }

        public Influence() { _weights = new List<BoneWeight>(); }
        public Influence(List<BoneWeight> weights) { _weights = weights; }
        public Influence(MDL0BoneNode bone) { _weights = new List<BoneWeight> { new BoneWeight(bone) }; }

        public void CalcMatrix()
        {
            if (IsWeighted)
            {
                _matrix = new Matrix();
                foreach (BoneWeight w in _weights)
                    if (w.Bone != null)
                        _matrix += (w.Bone.Matrix * w.Bone.InverseBindMatrix) * w.Weight;
            }
            else if (_weights.Count == 1)
            {
                if (Bone != null)
                {
                    _matrix = Bone.Matrix;
                    _invMatrix = Bone.InverseBindMatrix;
                }
            }
            else
                _matrix = _invMatrix = Matrix.Identity;
        }
        public static int Compare(Influence i1, Influence i2)
        {
            if (i1._weights.Count < i2._weights.Count)
                return -1;
            if (i1._weights.Count > i2._weights.Count)
                return 1;

            if (i1._refCount > i2._refCount)
                return -1;
            if (i1._refCount < i2._refCount)
                return 1;

            return 0;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Influence)
                return Equals(obj as Influence);
            return false;
        }
        public bool Equals(Influence inf)
        {
            bool found;

            if (object.ReferenceEquals(this, inf))
                return true;

            if (_weights.Count != inf._weights.Count)
                return false;

            foreach (BoneWeight w1 in _weights)
            {
                found = false;
                foreach (BoneWeight w2 in inf._weights) { if (w1 == w2) { found = true; break; } }
                if (!found)
                    return false;
            }
            return true;
        }
        public static bool operator ==(Influence i1, Influence i2) { return i1.Equals(i2); }
        public static bool operator !=(Influence i1, Influence i2) { return !i1.Equals(i2); }
    }

    public class BoneWeight
    {
        public override string ToString() { return Bone.Name + " - " + Weight * 100.0f + "%"; }

        //public MDL0BoneNode Bone 
        //{
        //    get { return _bone; } 
        //    set 
        //    {
        //        if (_bone == value)
        //            return;
        //        if (_bone != null)
        //            _bone._weights.Remove(this);
        //        if ((_bone = value) != null)
        //            _bone._weights.Add(this);
        //    } 
        //}
        public MDL0BoneNode Bone;
        public float Weight;

        public BoneWeight() : this(null, 1.0f) { }
        public BoneWeight(MDL0BoneNode bone) : this(bone, 1.0f) { }
        public BoneWeight(MDL0BoneNode bone, float weight) { Bone = bone; Weight = weight; }

        public static bool operator ==(BoneWeight b1, BoneWeight b2) { try { return (b1.Bone == b2.Bone) && (b1.Weight - b2.Weight < 0.0001); } catch { return false; } }
        public static bool operator !=(BoneWeight b1, BoneWeight b2) { return !(b1 == b2); }
        public override bool Equals(object obj)
        {
            if (obj is BoneWeight)
                return this == (BoneWeight)obj;
            return false;
        }
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
