using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ikarus
{
    public interface OffsetHolder
    {
        void Parse(MoveDefDataNode node, VoidPtr address);
        void Write(List<MoveDefEntryNode> entries, LookupManager lookup, VoidPtr basePtr, VoidPtr address);
        int Count { get; }
    }
    public unsafe class ExtraDataOffsets
    {
        public static OffsetHolder GetOffsets(CharName character)
        {
            switch (character)
            {
                case CharName.Mario: 
                    return new Mario();
                case CharName.Link: 
                    return new Link();
                case CharName.ZeroSuitSamus: 
                    return new ZerosuitSamus();
                case CharName.Pit: 
                    return new Pit();
            }
            return null;
        }

        public class Mario : OffsetHolder
        {
            public int Count { get { return Offsets.Count; } }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public unsafe struct Offsets
            {
                public const int Count = 10;

                public buint _params3;
                public buint _params4;
                public buint _params1;
                public buint _params5;
                public buint _params2;
                public buint _article2;
                public buint _article1;
                public buint _article3;
                public buint _article4;
                public buint _article5;

                public buint* Entries { get { return (buint*)Address; } }
                private VoidPtr Address { get { fixed (void* p = &this)return p; } }
                
                public int Size { get { return Count * 4; } }
            }

            public void Parse(MoveDefDataNode node, VoidPtr address)
            {
                Offsets* addr = (Offsets*)address;
                for (int i = 0; i < 5; i++)
                {
                    MoveDefSectionParamNode d = new MoveDefSectionParamNode(i) { offsetID = i, isExtra = true };
                    d.Initialize(node, node.BaseAddress + addr->Entries[i], 0);
                }
                for (int i = 5; i < 10; i++)
                {
                    MoveDefArticleNode entry = new MoveDefArticleNode() { offsetID = i, isExtra = true, Static = true, extraOffset = true };
                    entry.Initialize(node._articleGroup, node.BaseAddress + addr->Entries[i], 0);
                    node._articles.Add(entry._offset, entry);
                }
            }

            public void Write(List<MoveDefEntryNode> entries, LookupManager lookup, VoidPtr basePtr, VoidPtr address)
            {
                Offsets* addr = (Offsets*)address;
                int i = 0;
                foreach (MoveDefEntryNode e in entries)
                {
                    addr->Entries[i] = (uint)e._rebuildAddr - (uint)basePtr;
                    lookup.Add(&addr->Entries[i++]);
                }
            }
        }
        public class Link : OffsetHolder
        {
            public int Count { get { return Offsets.Count; } }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public unsafe struct Offsets
            {
                public const int Count = 20;

                public buint _params2;
                public buint _params4;
                public buint _params5;
                public buint _params3;
                public buint _params7;
                public buint _params1;
                public buint _params8;
                public FDefListOffset _hitDataList;
                public uint _count2;
                public buint _count3;
                public buint _article1;
                public buint _article1Count;
                public buint _article2;
                public buint _article2Count;
                public buint _article3;
                public buint _article4;
                public buint _article5;
                public buint _article6;
                public buint _article7;

                public buint* Entries { get { return (buint*)Address; } }
                private VoidPtr Address { get { fixed (void* p = &this)return p; } }

                public int Size { get { return Count * 4; } }
            }

            public void Parse(MoveDefDataNode node, VoidPtr address)
            {
                Offsets* addr = (Offsets*)address;
                for (int i = 0; i < 7; i++)
                {
                    MoveDefSectionParamNode d = new MoveDefSectionParamNode(i) { offsetID = i, isExtra = true };
                    d.Initialize(node, node.BaseAddress + addr->Entries[i], 0);
                }
                for (int i = 11; i < 20; i++)
                {
                    if (i != 12 && i != 14)
                    {
                        MoveDefArticleNode entry = new MoveDefArticleNode() { offsetID = i, isExtra = true, Static = true, extraOffset = true };
                        entry.Initialize(node._articleGroup, node.BaseAddress + addr->Entries[i], 0);
                        node._articles.Add(entry._offset, entry);
                    }
                }
            }

            public void Write(List<MoveDefEntryNode> entries, LookupManager lookup, VoidPtr basePtr, VoidPtr address)
            {

            }
        }
        public class ZerosuitSamus : OffsetHolder
        {
            public int Count { get { return Offsets.Count; } }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public unsafe struct Offsets
            {
                public const int Count = 12;

                public buint _params1;
                public buint _params2;
                public buint _params3;
                public buint _params4;
                public buint _article1;
                public buint _article2;
                public buint _article3;
                public buint _article4;
                public FDefListOffset _extraOffset8;
                public FDefListOffset _params5;

                public buint* Entries { get { return (buint*)Address; } }
                private VoidPtr Address { get { fixed (void* p = &this)return p; } }

                public int Size { get { return Count * 4; } }
            }

            public void Parse(MoveDefDataNode node, VoidPtr address)
            {
                Offsets* addr = (Offsets*)address;
                for (int i = 4; i < 8; i++)
                {
                    MoveDefArticleNode entry = new MoveDefArticleNode() { offsetID = i, isExtra = true, Static = true, extraOffset = true };
                    entry.Initialize(node._articleGroup, node.BaseAddress + addr->Entries[i], 0);
                    node._articles.Add(entry._offset, entry);
                }
            }

            public void Write(List<MoveDefEntryNode> entries, LookupManager lookup, VoidPtr basePtr, VoidPtr address)
            {

            }
        }
        public class Pit : OffsetHolder
        {
            public int Count { get { return Offsets.Count; } }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public unsafe struct Offsets
            {
                public const int Count = 13;

                public buint _params1;
                public buint _params2;
                public buint _params4;
                public buint _params5;
                public FDefListOffset _hitDataList1;
                public uint _unknown;
                public buint _specialHitDataList;
                public buint _params3;
                public buint _article1;
                public buint _article2;
                public buint _article3;
                public buint _article4;

                public buint* Entries { get { return (buint*)Address; } }
                private VoidPtr Address { get { fixed (void* p = &this)return p; } }

                public int Size { get { return Count * 4; } }
            }

            public void Parse(MoveDefDataNode node, VoidPtr address)
            {

            }

            public void Write(List<MoveDefEntryNode> entries, LookupManager lookup, VoidPtr basePtr, VoidPtr address)
            {

            }
        }
    }
}
