﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BrawlLib.Imaging;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class STPMNode : ARCEntryNode
    {
        internal STPM* Header { get { return (STPM*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.STPM; } }

        protected override bool OnInitialize()
        {
            base.OnInitialize();

            if (_name == null)
                _name = "STPM";

            return Header->_count > 0;
        }

        protected override void OnPopulate()
        {
            for (int i = 0; i < Header->_count; i++)
                new STPMEntryNode().Initialize(this, new DataSource((*Header)[i], 260));
        }

        protected override int OnCalculateSize(bool force)
        {
            return 0x10 + Children.Count * 4 + Children.Count * 260;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            STPM* header = (STPM*)address;
            *header = new STPM(Children.Count);
            for (int i = 0; i < Children.Count; i++)
            {
                uint offset = (uint)(0x10 + ((i + 1) * 4) + (i * 260));
                *(buint*)((VoidPtr)address + 0x10 + i * 4) = offset;
                Children[i].Rebuild((VoidPtr)address + offset, 260, true);
            }
        }

        internal static ResourceNode TryParse(DataSource source) { return ((STPM*)source.Address)->_tag == STPM.Tag ? new STPMNode() : null; }
    }

    public unsafe class STPMEntryNode : ResourceNode
    {
        internal STPMEntry* Header { get { return (STPMEntry*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        public byte echo, id2;
        public ushort id;

        public STPMValueManager _values = new STPMValueManager(null);

        public class STPMValueManager
        {
            public UnsafeBuffer _values;
            public STPMValueManager(VoidPtr address)
            {
                _values = new UnsafeBuffer(64 * 4);
                if (address == null)
                {
                    byte* pOut = (byte*)_values.Address;
                    for (int i = 0; i < 64 * 4; i++)
                        *pOut++ = 0;
                }
                else
                {
                    byte* pIn = (byte*)address;
                    byte* pOut = (byte*)_values.Address;
                    for (int i = 0; i < 64 * 4; i++)
                        *pOut++ = *pIn++;
                }
            }
            ~STPMValueManager() { _values.Dispose(); }
            public float GetFloat(int index) { return ((bfloat*)_values.Address)[index]; }
            public void SetFloat(int index, float value) { ((bfloat*)_values.Address)[index] = value; }
            public int GetInt(int index) { return ((bint*)_values.Address)[index]; }
            public void SetInt(int index, int value) { ((bint*)_values.Address)[index] = value; }
            public RGBAPixel GetRGBA(int index) { return ((RGBAPixel*)_values.Address)[index]; }
            public void SetRGBA(int index, RGBAPixel value) { ((RGBAPixel*)_values.Address)[index] = value; }
            public byte GetByte(int index, int index2) { return ((byte*)_values.Address)[index * 4 + index2]; }
            public void SetByte(int index, int index2, byte value) { ((byte*)_values.Address)[index * 4 + index2] = value; }
        }

        [Category("STPM Data")]
        public byte Echo { get { return echo; } set { echo = value; SignalPropertyChange(); } }
        [Category("STPM Data")]
        public ushort Id1 { get { return id; } set { id = value; SignalPropertyChange(); } }
        [Category("STPM Data")]
        public byte Id2 { get { return id2; } set { id2 = value; SignalPropertyChange(); } }
        
        [Category("STPM Values")]
        public float Value1 { get { return _values.GetFloat(0); } set { _values.SetFloat(0, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value2 { get { return _values.GetFloat(1); } set { _values.SetFloat(1, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value3 { get { return _values.GetFloat(2); } set { _values.SetFloat(2, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value4 { get { return _values.GetFloat(3); } set { _values.SetFloat(3, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public RGBAPixel Value5 { get { return _values.GetRGBA(4); } set { _values.SetRGBA(4, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float ShadowVerticalAngle { get { return _values.GetFloat(5); } set { _values.SetFloat(5, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float ShadowHorizontalAngle { get { return _values.GetFloat(6); } set { _values.SetFloat(6, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value8 { get { return _values.GetFloat(7); } set { _values.SetFloat(7, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value9 { get { return _values.GetFloat(8); } set { _values.SetFloat(8, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float CameraAngle { get { return _values.GetFloat(9); } set { _values.SetFloat(9, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float MinimumZ { get { return _values.GetFloat(10); } set { _values.SetFloat(10, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float MaximumZ { get { return _values.GetFloat(11); } set { _values.SetFloat(11, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float MinimumTilt { get { return _values.GetFloat(12); } set { _values.SetFloat(12, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float MaximumTilt { get { return _values.GetFloat(13); } set { _values.SetFloat(13, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value15 { get { return _values.GetFloat(14); } set { _values.SetFloat(14, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value16 { get { return _values.GetFloat(15); } set { _values.SetFloat(15, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value17 { get { return _values.GetFloat(16); } set { _values.SetFloat(16, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value18 { get { return _values.GetFloat(17); } set { _values.SetFloat(17, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value19 { get { return _values.GetFloat(18); } set { _values.SetFloat(18, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value20 { get { return _values.GetFloat(19); } set { _values.SetFloat(19, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value21 { get { return _values.GetFloat(20); } set { _values.SetFloat(20, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value22 { get { return _values.GetFloat(21); } set { _values.SetFloat(21, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value23 { get { return _values.GetFloat(22); } set { _values.SetFloat(22, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float PauseCamX { get { return _values.GetFloat(23); } set { _values.SetFloat(23, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float PauseCamY { get { return _values.GetFloat(24); } set { _values.SetFloat(24, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float PauseCamZ { get { return _values.GetFloat(25); } set { _values.SetFloat(25, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float PauseCamAngle { get { return _values.GetFloat(26); } set { _values.SetFloat(26, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value28 { get { return _values.GetFloat(27); } set { _values.SetFloat(27, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value29 { get { return _values.GetFloat(28); } set { _values.SetFloat(28, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value30 { get { return _values.GetFloat(29); } set { _values.SetFloat(29, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value31 { get { return _values.GetFloat(30); } set { _values.SetFloat(30, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value32 { get { return _values.GetFloat(31); } set { _values.SetFloat(31, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value33 { get { return _values.GetFloat(32); } set { _values.SetFloat(32, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value34 { get { return _values.GetFloat(33); } set { _values.SetFloat(33, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float FixedCamX { get { return _values.GetFloat(34); } set { _values.SetFloat(34, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float FixedCamY { get { return _values.GetFloat(35); } set { _values.SetFloat(35, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float FixedCamZ { get { return _values.GetFloat(36); } set { _values.SetFloat(36, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value38 { get { return _values.GetFloat(37); } set { _values.SetFloat(37, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float FixedHorizontalAngle { get { return _values.GetFloat(38); } set { _values.SetFloat(38, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float FixedVerticalAngle { get { return _values.GetFloat(39); } set { _values.SetFloat(39, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value41 { get { return _values.GetFloat(40); } set { _values.SetFloat(40, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value42 { get { return _values.GetFloat(41); } set { _values.SetFloat(41, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value43 { get { return _values.GetFloat(42); } set { _values.SetFloat(42, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value44 { get { return _values.GetFloat(43); } set { _values.SetFloat(43, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value45 { get { return _values.GetFloat(44); } set { _values.SetFloat(44, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value46 { get { return _values.GetFloat(45); } set { _values.SetFloat(45, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value47 { get { return _values.GetFloat(46); } set { _values.SetFloat(46, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value48 { get { return _values.GetFloat(47); } set { _values.SetFloat(47, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value49 { get { return _values.GetFloat(48); } set { _values.SetFloat(48, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public byte Value50a { get { return _values.GetByte(49, 0); } set { _values.SetByte(49, 0, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public byte Value50b { get { return _values.GetByte(49, 1); } set { _values.SetByte(49, 1, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public byte Value50c { get { return _values.GetByte(49, 2); } set { _values.SetByte(49, 2, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public byte Value50d { get { return _values.GetByte(49, 3); } set { _values.SetByte(49, 3, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value51 { get { return _values.GetFloat(50); } set { _values.SetFloat(50, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value52 { get { return _values.GetFloat(51); } set { _values.SetFloat(51, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value53 { get { return _values.GetFloat(52); } set { _values.SetFloat(52, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public float Value54 { get { return _values.GetFloat(53); } set { _values.SetFloat(53, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value55 { get { return _values.GetInt(54); } set { _values.SetInt(54, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value56 { get { return _values.GetInt(55); } set { _values.SetInt(55, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value57 { get { return _values.GetInt(56); } set { _values.SetInt(56, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value58 { get { return _values.GetInt(57); } set { _values.SetInt(57, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value59 { get { return _values.GetInt(58); } set { _values.SetInt(58, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value60 { get { return _values.GetInt(59); } set { _values.SetInt(59, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value61 { get { return _values.GetInt(60); } set { _values.SetInt(60, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value62 { get { return _values.GetInt(61); } set { _values.SetInt(61, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value63 { get { return _values.GetInt(62); } set { _values.SetInt(62, value); SignalPropertyChange(); } }
        [Category("STPM Values")]
        public int Value64 { get { return _values.GetInt(63); } set { _values.SetInt(63, value); SignalPropertyChange(); } }
        
        protected override bool OnInitialize()
        {
            base.OnInitialize();

            id = Header->_id;
            echo = Header->_echo;
            id2 = Header->_id2;

            if (_name == null)
                _name = "STPMEntry" + id;

            _values = new STPMValueManager((VoidPtr)Header + 4);

            return false;
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            STPMEntry* header = (STPMEntry*)address;
            *header = new STPMEntry(id, echo, id2);
            byte* pOut = (byte*)header + 4;
            byte* pIn = (byte*)_values._values.Address;
            for (int i = 0; i < 64 * 4; i++)
                *pOut++ = *pIn++;
        }
    }
}
