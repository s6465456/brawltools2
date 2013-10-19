using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using Ikarus;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MoveDefItemAnchorListNode : MoveDefEntry
    {
        internal FDefItemAnchor* First { get { return (FDefItemAnchor*)WorkingUncompressed.Address; } }
        int Count = 0;

        public override bool OnInitialize()
        {
            _extOverride = true;
            base.OnInitialize();

            //if (Size % 0x1C != 0 && Size % 0x1C != 4)
            //    Console.WriteLine(Size % 0x1C);
            
            Count = WorkingUncompressed.Length / 0x1C;
            return Count > 0;
        }

        public override void OnPopulate()
        {
            FDefItemAnchor* addr = First;
            for (int i = 0; i < Count; i++)
                new MoveDefItemAnchorNode() { _hasName = _offsetID == 16 }.Initialize(this, addr++, 28);

            if (_offsetID == 16)
            {
                Children[0]._name = "FranklinBadge/ScrewAttack";
                Children[1]._name = "LipStickFlower/BunnyHood";
                Children[2]._name = "SuperSpicyCurry";
            }
            //else if (offsetID == 17)
            //{

            //}
            //else if (offsetID == 23)
            //{

            //}
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return Children.Count * 0x1C;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefItemAnchor* data = (FDefItemAnchor*)address;
            foreach (MoveDefItemAnchorNode e in Children)
                e.Rebuild(data++, 0x1C, true);
        }
    }

    public unsafe class MoveDefItemAnchorNode : MoveDefEntry
    {
        internal FDefItemAnchor* Header { get { return (FDefItemAnchor*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        int _boneIndex;
        Vector3 _trans, _rot;

        public bool _hasName = false;
        
        [Browsable(false)]
        public MDL0BoneNode BoneNode
        {
            get { if (Model == null) return null; if (_boneIndex >= Model._linker.BoneCache.Length || _boneIndex < 0) return null; return (MDL0BoneNode)Model._linker.BoneCache[_boneIndex]; }
            set { _boneIndex = value.BoneIndex; Name = value.Name; }
        }

        [Category("Item Anchor"), Browsable(true), TypeConverter(typeof(DropDownListBonesMDef))]
        public string Bone
        {
            get { return BoneNode == null ? _boneIndex.ToString() : BoneNode.Name; }
            set
            {
                if (Model == null)
                    _boneIndex = Convert.ToInt32(value); 
                else
                    BoneNode = String.IsNullOrEmpty(value) ? BoneNode : Model.FindBone(value); 

                if (!_hasName)
                    Name = Bone;

                SignalPropertyChange();
            }
        }
        [Category("Item Anchor")]
        public Vector3 Translation { get { return _trans; } set { _trans = value; SignalPropertyChange(); } }
        [Category("Item Anchor")]
        public Vector3 Rotation { get { return _rot; } set { _rot = value; SignalPropertyChange(); } }
        
        public override bool OnInitialize()
        {
            _boneIndex = Header->_boneIndex;

            if (!_hasName)
                _name = Bone;

            _trans = Header->_translation;
            _rot = Header->_rotation;

            return false;
        }

        public override int OnCalculateSize(bool force)
        {
            _lookupCount = 0;
            return 0x1C;
        }

        public override void OnRebuild(VoidPtr address, int length, bool force)
        {
            _rebuildAddr = address;
            FDefItemAnchor* data = (FDefItemAnchor*)address;
            data->_boneIndex = _boneIndex;
            data->_translation = _trans;
            data->_rotation = _rot;
        }
    }
}
