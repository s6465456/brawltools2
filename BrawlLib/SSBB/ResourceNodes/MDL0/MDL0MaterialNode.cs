using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using BrawlLib.OpenGL;
using System.Drawing;
using System.IO;
using BrawlLib.Imaging;
using BrawlLib.Wii.Graphics;
using BrawlLib.Wii.Models;
using System.Windows.Forms;
using BrawlLib.IO;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class MDL0MaterialNode : MDL0EntryNode
    {
        internal MDL0Material* Header { get { return (MDL0Material*)WorkingUncompressed.Address; } }

        public override ResourceType ResourceType { get { return ResourceType.MDL0Material; } }

        public MDL0PolygonNode[] Objects { get { if (!isMetal) return _polygons.ToArray(); else return MetalMaterial != null ? MetalMaterial._polygons.ToArray() : null; } }
        internal List<MDL0PolygonNode> _polygons = new List<MDL0PolygonNode>();

        MatModeBlock* mode;

        public UserDataClass[] UserEntries { get { return _part2Entries.ToArray(); } set { _part2Entries = value.ToList<UserDataClass>(); SignalPropertyChange(); } }
        internal List<UserDataClass> _part2Entries = new List<UserDataClass>();

        internal int _dataLen, _index, _matRefOffset = 1044, _part2Offset = 0, _dlOffset, _mdl0Offset, _stringOffset;
        internal byte _numTextures, _numLights, _indirectMethod1, _indirectMethod2, _indirectMethod3, _indirectMethod4;
        public sbyte _normMapRefLight1, _normMapRefLight2, _normMapRefLight3, _normMapRefLight4, _lSet, _fSet;
        internal int _furDataOffset;
        internal uint _usageFlags;
        public byte _ssc;
        internal byte _clip;
        public byte _transp;
        internal byte _pad1;
        internal CullMode _cull;

        //In order of appearance in display list:
        //Mode block
        internal AlphaFunction _alphaFunc = AlphaFunction.Default;
        internal ZMode _zMode = ZMode.Default;
        //Mask, does not allow changing the dither/update bits
        internal BlendMode _blendMode = BlendMode.Default;
        internal ConstantAlpha _constantAlpha = ConstantAlpha.Default;
        //Tev Color Block
        internal MatTevColorBlock _tevColorBlock = MatTevColorBlock.Default;
        //Pad 4
        //Tev Konstant Block
        internal MatTevKonstBlock _tevKonstBlock = MatTevKonstBlock.Default;
        //Pad 24
        //Indirect texture scale for CMD stages
        internal MatIndMtxBlock _indMtx = MatIndMtxBlock.Default;
        //XF Texture matrix info

        [Browsable(false)]
        public XFData[] XFCommands { get { return XFCmds.ToArray(); } }
        internal List<XFData> XFCmds = new List<XFData>();

        [Category("TEV Konstant Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 KReg0Color { get { return new GXColorS10() { R = _tevKonstBlock.TevReg0Lo.RB, A = _tevKonstBlock.TevReg0Lo.AG, B = _tevKonstBlock.TevReg0Hi.RB, G = _tevKonstBlock.TevReg0Hi.AG }; } set { if (!CheckIfMetal()) { _tevKonstBlock.TevReg0Lo.RB = value.R; _tevKonstBlock.TevReg0Lo.AG = value.A; _tevKonstBlock.TevReg0Hi.RB = value.B; _tevKonstBlock.TevReg0Hi.AG = value.G; } } }
        [Category("TEV Konstant Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 KReg1Color { get { return new GXColorS10() { R = _tevKonstBlock.TevReg1Lo.RB, A = _tevKonstBlock.TevReg1Lo.AG, B = _tevKonstBlock.TevReg1Hi.RB, G = _tevKonstBlock.TevReg1Hi.AG }; } set { if (!CheckIfMetal()) { _tevKonstBlock.TevReg1Lo.RB = value.R; _tevKonstBlock.TevReg1Lo.AG = value.A; _tevKonstBlock.TevReg1Hi.RB = value.B; _tevKonstBlock.TevReg1Hi.AG = value.G; } } }
        [Category("TEV Konstant Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 KReg2Color { get { return new GXColorS10() { R = _tevKonstBlock.TevReg2Lo.RB, A = _tevKonstBlock.TevReg2Lo.AG, B = _tevKonstBlock.TevReg2Hi.RB, G = _tevKonstBlock.TevReg2Hi.AG }; } set { if (!CheckIfMetal()) { _tevKonstBlock.TevReg2Lo.RB = value.R; _tevKonstBlock.TevReg2Lo.AG = value.A; _tevKonstBlock.TevReg2Hi.RB = value.B; _tevKonstBlock.TevReg2Hi.AG = value.G; } } }
        [Category("TEV Konstant Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 KReg3Color { get { return new GXColorS10() { R = _tevKonstBlock.TevReg3Lo.RB, A = _tevKonstBlock.TevReg3Lo.AG, B = _tevKonstBlock.TevReg3Hi.RB, G = _tevKonstBlock.TevReg3Hi.AG }; } set { if (!CheckIfMetal()) { _tevKonstBlock.TevReg3Lo.RB = value.R; _tevKonstBlock.TevReg3Lo.AG = value.A; _tevKonstBlock.TevReg3Hi.RB = value.B; _tevKonstBlock.TevReg3Hi.AG = value.G; } } }

        [Category("TEV Color Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 CReg0Color 
        { 
            get { return new GXColorS10() { R = _tevColorBlock.TevReg1Lo.RB, A = _tevColorBlock.TevReg1Lo.AG, B = _tevColorBlock.TevReg1Hi0.RB, G = _tevColorBlock.TevReg1Hi0.AG }; }
            set
            {
                if (!CheckIfMetal())
                {
                    _tevColorBlock.TevReg1Lo.RB = value.R;
                    _tevColorBlock.TevReg1Lo.AG = value.A;

                    //Hi values are always the same...
                    _tevColorBlock.TevReg1Hi0.RB =
                    _tevColorBlock.TevReg1Hi1.RB =
                    _tevColorBlock.TevReg1Hi2.RB = value.B;
                    _tevColorBlock.TevReg1Hi0.AG =
                    _tevColorBlock.TevReg1Hi1.AG =
                    _tevColorBlock.TevReg1Hi2.AG = value.G;
                }
            } 
        }
        [Category("TEV Color Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 CReg1Color 
        { 
            get { return new GXColorS10() { R = _tevColorBlock.TevReg2Lo.RB, A = _tevColorBlock.TevReg2Lo.AG, B = _tevColorBlock.TevReg2Hi0.RB, G = _tevColorBlock.TevReg2Hi0.AG }; }
            set
            {
                if (!CheckIfMetal())
                {
                    _tevColorBlock.TevReg2Lo.RB = value.R;
                    _tevColorBlock.TevReg2Lo.AG = value.A;

                    //Hi values are always the same...
                    _tevColorBlock.TevReg2Hi0.RB =
                    _tevColorBlock.TevReg2Hi1.RB =
                    _tevColorBlock.TevReg2Hi2.RB = value.B;
                    _tevColorBlock.TevReg2Hi0.AG =
                    _tevColorBlock.TevReg2Hi1.AG =
                    _tevColorBlock.TevReg2Hi2.AG = value.G;
                }
            } 
        }
        [Category("TEV Color Block"), TypeConverter(typeof(GXColorS10StringConverter))]
        public GXColorS10 CReg2Color 
        { 
            get { return new GXColorS10() { R = _tevColorBlock.TevReg3Lo.RB, A = _tevColorBlock.TevReg3Lo.AG, B = _tevColorBlock.TevReg3Hi0.RB, G = _tevColorBlock.TevReg3Hi0.AG }; } 
            set 
            { 
                if (!CheckIfMetal()) 
                { 
                    _tevColorBlock.TevReg3Lo.RB = value.R; 
                    _tevColorBlock.TevReg3Lo.AG = value.A; 

                    //Hi values are always the same...
                    _tevColorBlock.TevReg3Hi0.RB =
                    _tevColorBlock.TevReg3Hi1.RB =
                    _tevColorBlock.TevReg3Hi2.RB = value.B; 
                    _tevColorBlock.TevReg3Hi0.AG =
                    _tevColorBlock.TevReg3Hi1.AG =
                    _tevColorBlock.TevReg3Hi2.AG = value.G; 
                } 
            } 
        }

        //[Category("TEV Color Block")]
        //public ColorReg Reg1Lo { get { return _tevColorBlock.TevReg1Lo; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg1Hi0 { get { return _tevColorBlock.TevReg1Hi0; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg1Hi1 { get { return _tevColorBlock.TevReg1Hi1; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg1Hi2 { get { return _tevColorBlock.TevReg1Hi2; } }

        //[Category("TEV Color Block")]
        //public ColorReg Reg2Lo { get { return _tevColorBlock.TevReg2Lo; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg2Hi0 { get { return _tevColorBlock.TevReg2Hi0; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg2Hi1 { get { return _tevColorBlock.TevReg2Hi1; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg2Hi2 { get { return _tevColorBlock.TevReg2Hi2; } }

        //[Category("TEV Color Block")]
        //public ColorReg Reg3Lo { get { return _tevColorBlock.TevReg3Lo; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg3Hi0 { get { return _tevColorBlock.TevReg3Hi0; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg3Hi1 { get { return _tevColorBlock.TevReg3Hi1; } }
        //[Category("TEV Color Block")]
        //public ColorReg Reg3Hi2 { get { return _tevColorBlock.TevReg3Hi2; } }
        
        #region Shader linkage
        internal MDL0ShaderNode _shader;
        [Browsable(false)]
        public MDL0ShaderNode ShaderNode
        {
            get { return _shader; }
            set
            {
                if (_shader == value)
                    return;
                if (_shader != null)
                    _shader._materials.Remove(this);
                if ((_shader = value) != null)
                    _shader._materials.Add(this);
                if (_shader != null)
                    ActiveShaderStages = _shader.stages;
            }
        }
        [Browsable(true), TypeConverter(typeof(DropDownListShaders))]
        public string Shader
        {
            get { return _shader == null ? null : _shader._name; }
            set
            {
                if (CheckIfMetal())
                    return;

                if (String.IsNullOrEmpty(value))
                    ShaderNode = null;
                else
                {
                    MDL0ShaderNode node = Model.FindChild(String.Format("Shaders/{0}", value), false) as MDL0ShaderNode;
                    if (node != null)
                        ShaderNode = node;
                }
            }
        }
        #endregion

        [Category("Alpha Function")]
        public byte Ref0 { get { return _alphaFunc.ref0; } set { if (!CheckIfMetal()) _alphaFunc.ref0 = value; } }
        [Category("Alpha Function")]
        public AlphaCompare Comp0 { get { return _alphaFunc.Comp0; } set { if (!CheckIfMetal()) _alphaFunc.Comp0 = value;  } }
        [Category("Alpha Function")]
        public AlphaOp Logic { get { return _alphaFunc.Logic; } set { if (!CheckIfMetal()) _alphaFunc.Logic = value;  } }
        [Category("Alpha Function")]
        public byte Ref1 { get { return _alphaFunc.ref1; } set { if (!CheckIfMetal()) _alphaFunc.ref1 = value;  } }
        [Category("Alpha Function")]
        public AlphaCompare Comp1 { get { return _alphaFunc.Comp1; } set { if (!CheckIfMetal()) _alphaFunc.Comp1 = value;  } }

        [Category("Z Mode")]
        public bool EnableDepthTest { get { return _zMode.EnableDepthTest; } set { if (!CheckIfMetal()) _zMode.EnableDepthTest = value;  } }
        [Category("Z Mode")]
        public bool EnableDepthUpdate { get { return _zMode.EnableDepthUpdate; } set { if (!CheckIfMetal()) _zMode.EnableDepthUpdate = value;  } }
        [Category("Z Mode")]
        public GXCompare DepthFunction { get { return _zMode.DepthFunction; } set { if (!CheckIfMetal()) _zMode.DepthFunction = value;  } }

        [Category("Blend Mode")] //Allows textures to be opaque. Cannot be used with Alpha Function
        public bool EnableBlend { get { return _blendMode.EnableBlend; } set { if (!CheckIfMetal()) { _blendMode.EnableBlend = value; _usageFlags = value ? 0x80000000 : 0; } } }
        [Category("Blend Mode")]
        public bool EnableBlendLogic { get { return _blendMode.EnableLogicOp; } set { if (!CheckIfMetal()) _blendMode.EnableLogicOp = value;  } }
        
        //These are disabled via mask
        //[Category("Blend Mode")]
        //public bool EnableDither { get { return _blendMode.EnableDither; } }
        //[Category("Blend Mode")]
        //public bool EnableColorUpdate { get { return _blendMode.EnableColorUpdate; } }
        //[Category("Blend Mode")]
        //public bool EnableAlphaUpdate { get { return _blendMode.EnableAlphaUpdate; } }

        [Category("Blend Mode")]
        public BlendFactor SrcFactor { get { return _blendMode.SrcFactor; } set { if (!CheckIfMetal()) _blendMode.SrcFactor = value;  } }
        [Category("Blend Mode")]
        public GXLogicOp BlendLogicOp { get { return _blendMode.LogicOp; } set { if (!CheckIfMetal()) _blendMode.LogicOp = value;  } }
        [Category("Blend Mode")]
        public BlendFactor DstFactor { get { return _blendMode.DstFactor; } set { if (!CheckIfMetal()) _blendMode.DstFactor = value;  } }

        [Category("Blend Mode")]
        public bool Subtract { get { return _blendMode.Subtract; } set { if (!CheckIfMetal()) _blendMode.Subtract = value;  } }

        [Category("Constant Alpha")]
        public bool Enabled { get { return _constantAlpha.Enable != 0; } set { if (!CheckIfMetal()) _constantAlpha.Enable = (byte)(value ? 1 : 0); } }
        [Category("Constant Alpha")]
        public byte Value { get { return _constantAlpha.Value; } set { if (!CheckIfMetal()) _constantAlpha.Value = value; } }

        //[Category("Material"), Browsable(false)]
        //public int TotalLen { get { return _dataLen; } }
        //[Category("Material"), Browsable(false)]
        //public int MDL0Offset { get { return _mdl0Offset; } }
        //[Category("Material"), Browsable(false)]
        //public int StringOffset { get { return _stringOffset; } }
        [Category("Material")]
        public int ID { get { return _index; } }

        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex0ScaleS { get { return (IndTexScale)_indMtx.SS0val.S_Scale0; } set { if (!CheckIfMetal()) _indMtx.SS0val.S_Scale0 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex0ScaleT { get { return (IndTexScale)_indMtx.SS0val.T_Scale0; } set { if (!CheckIfMetal()) _indMtx.SS0val.T_Scale0 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex1ScaleS { get { return (IndTexScale)_indMtx.SS0val.S_Scale1; } set { if (!CheckIfMetal()) _indMtx.SS0val.S_Scale1 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex1ScaleT { get { return (IndTexScale)_indMtx.SS0val.T_Scale1; } set { if (!CheckIfMetal()) _indMtx.SS0val.T_Scale1 = value; } }
        
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex2ScaleS { get { return (IndTexScale)_indMtx.SS1val.S_Scale0; } set { if (!CheckIfMetal()) _indMtx.SS1val.S_Scale0 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex2ScaleT { get { return (IndTexScale)_indMtx.SS1val.T_Scale0; } set { if (!CheckIfMetal()) _indMtx.SS1val.T_Scale0 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex3ScaleS { get { return (IndTexScale)_indMtx.SS1val.S_Scale1; } set { if (!CheckIfMetal()) _indMtx.SS1val.S_Scale1 = value; } }
        [Category("Indirect Texture Scale"), Browsable(true)]
        public IndTexScale IndirectTex3ScaleT { get { return (IndTexScale)_indMtx.SS1val.T_Scale1; } set { if (!CheckIfMetal()) _indMtx.SS1val.T_Scale1 = value; } }
        
        //Usage flags. Each set of 4 bits represents one texture layer.
        [Category("Texture Flags"), Browsable(false)]
        public string LayerFlags { get { return _layerFlags.ToString("X"); } }//set { if (!CheckIfMetal()) _layerFlags = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);  } }
        public uint _layerFlags;
        [Category("Texture Flags")]
        public TexMatrixMode TexMatrixFlags { get { return (TexMatrixMode)_texMtxFlags; } set { if (!CheckIfMetal()) _texMtxFlags = (uint)value; } }
        public uint _texMtxFlags;

        [Flags]
        public enum LightingChannelFlags
        {
            MatColor_Color = 0x1,
            MatColor_Alpha = 0x2,
            AmbColor_Color = 0x4,
            AmbColor_Alpha = 0x8,
            ChanCtrl_Color = 0x10,
            ChanCtrl_Alpha = 0x20
        }
        
        [Category("Lighting Channel 1")]
        public LightingChannelFlags C1Flags { get { return (LightingChannelFlags)flags0; } set { if (!CheckIfMetal()) flags0 = (uint)value; } }
        public uint flags0;
        [Category("Lighting Channel 1"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel C1MaterialColor { get { return c00; } set { if (!CheckIfMetal()) c00 = value; } }
        public RGBAPixel c00;
        [Category("Lighting Channel 1"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel C1AmbientColor { get { return c01; } set { if (!CheckIfMetal()) c01 = value; } }
        public RGBAPixel c01;

        [Category("Lighting Channel 1")]
        public GXColorSrc C1ColorMaterialSource { get { return (GXColorSrc)(_colorCtrl0C[0] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl0C[0] = ((int)value != 0); } }
        [Category("Lighting Channel 1")]
        public bool C1ColorEnabled { get { return _colorCtrl0C[1]; } set { if (!CheckIfMetal()) _colorCtrl0C[1] = value; } }
        [Category("Lighting Channel 1")]
        public GXColorSrc C1ColorAmbientSource { get { return (GXColorSrc)(_colorCtrl0C[6] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl0C[6] = ((int)value != 0); } }
        [Category("Lighting Channel 1")]
        public GXDiffuseFn C1ColorDiffuseFunction { get { return (GXDiffuseFn)(_colorCtrl0C[7, 2]); } set { if (!CheckIfMetal()) _colorCtrl0C[7, 2] = ((uint)value); } }
        [Category("Lighting Channel 1")]
        public GXAttnFn C1ColorAttenuation 
        {
            get
            {
                if (!_colorCtrl0C[9])
                    return GXAttnFn.None;
                else
                    return (GXAttnFn)(_colorCtrl0C[10] ? 1 : 0);
            } 
            set 
            {
                if (!CheckIfMetal())
                {
                    if (value != GXAttnFn.None)
                    {
                        _colorCtrl0C[9] = true;
                        _colorCtrl0C[10] = ((int)value) != 0;
                    }
                    else
                    {
                        _colorCtrl0C[9] = false;
                        _colorCtrl0C[10] = false;
                    }
                }
            }
        }
        [Category("Lighting Channel 1")]
        public MatChanLights C1ColorLights
        {
            get
            {
                return (MatChanLights)(_colorCtrl0C[2, 4] | (_colorCtrl0C[11, 4] << 4));
            }
            set
            {
                if (!CheckIfMetal())
                {
                    uint val = (uint)value;
                    _colorCtrl0C[2, 4] = (val & 0xF);
                    _colorCtrl0C[11, 4] = ((val >> 4) & 0xF);
                }
            }
        }

        [Category("Lighting Channel 1")]
        public GXColorSrc C1AlphaMaterialSource { get { return (GXColorSrc)(_colorCtrl0A[0] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl0A[0] = ((int)value != 0); } }
        [Category("Lighting Channel 1")]
        public bool C1AlphaEnabled { get { return _colorCtrl0A[1]; } set { if (!CheckIfMetal()) _colorCtrl0A[1] = value; } }
        [Category("Lighting Channel 1")]
        public GXColorSrc C1AlphaAmbientSource { get { return (GXColorSrc)(_colorCtrl0A[6] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl0A[6] = ((int)value != 0); } }
        [Category("Lighting Channel 1")]
        public GXDiffuseFn C1AlphaDiffuseFunction { get { return (GXDiffuseFn)(_colorCtrl0A[7, 2]); } set { if (!CheckIfMetal()) _colorCtrl0A[7, 2] = ((uint)value); } }
        [Category("Lighting Channel 1")]
        public GXAttnFn C1AlphaAttenuation
        {
            get
            {
                if (!_colorCtrl0A[9])
                    return GXAttnFn.None;
                else
                    return (GXAttnFn)(_colorCtrl0A[10] ? 1 : 0);
            }
            set
            {
                if (!CheckIfMetal())
                {
                    if (value != GXAttnFn.None)
                    {
                        _colorCtrl0A[9] = true;
                        _colorCtrl0A[10] = ((int)value) != 0;
                    }
                    else
                    {
                        _colorCtrl0A[9] = false;
                        _colorCtrl0A[10] = false;
                    }
                }
            }
        }
        [Category("Lighting Channel 1")]
        public MatChanLights C1AlphaLights
        {
            get
            {
                return (MatChanLights)(_colorCtrl0A[2, 4] | (_colorCtrl0A[11, 4] << 4));
            }
            set
            {
                if (!CheckIfMetal())
                {
                    uint val = (uint)value;
                    _colorCtrl0A[2, 4] = (val & 0xF);
                    _colorCtrl0A[11, 4] = ((val >> 4) & 0xF);
                }
            }
        }

        //0000 0000 0000 0000 0000 0000 0000 0001   Material Source (GXColorSrc)
        //0000 0000 0000 0000 0000 0000 0000 0010   Light Enabled
        //0000 0000 0000 0000 0000 0000 0011 1100   Light 0123
        //0000 0000 0000 0000 0000 0000 0100 0000   Ambient Source (GXColorSrc)
        //0000 0000 0000 0000 0000 0001 1000 0000   Diffuse Func
        //0000 0000 0000 0000 0000 0010 0000 0000   Attenuation Enable
        //0000 0000 0000 0000 0000 0100 0000 0000   Attenuation Function (0 = Specular)
        //0000 0000 0000 0000 0111 1000 0000 0000   Light 4567

        public enum GXColorSrc
        {
            Register,
            Vertex
        }

        [Flags]
        public enum MatChanLights
        {
            None = 0x0,
            Light0 = 0x1,
            Light1 = 0x2,
            Light2 = 0x4,
            Light3 = 0x8,
            Light4 = 0x10,
            Light5 = 0x20,
            Light6 = 0x40,
            Light7 = 0x80,
        }

        public enum GXDiffuseFn
        {
            Disabled,
            Enabled,
            Clamped
        }

        public enum GXAttnFn
        {
            Specular,
            Spotlight,
            None
        }

        [Category("Lighting Channel 2")]
        public LightingChannelFlags C2Flags { get { return (LightingChannelFlags)flags1; } set { if (!CheckIfMetal()) flags1 = (uint)value; } }
        public uint flags1;
        [Category("Lighting Channel 2"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel C2MaterialColor { get { return c10; } set { if (!CheckIfMetal()) c10 = value; } }
        public RGBAPixel c10;
        [Category("Lighting Channel 2"), TypeConverter(typeof(RGBAStringConverter))]
        public RGBAPixel C2AmbientColor { get { return c11; } set { if (!CheckIfMetal()) c11 = value; } }
        public RGBAPixel c11;

        [Category("Lighting Channel 2")]
        public GXColorSrc C2ColorMaterialSource { get { return (GXColorSrc)(_colorCtrl1C[0] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl1C[0] = ((int)value != 0); } }
        [Category("Lighting Channel 2")]
        public bool C2ColorEnabled { get { return _colorCtrl1C[1]; } set { if (!CheckIfMetal()) _colorCtrl1C[1] = value; } }
        [Category("Lighting Channel 2")]
        public GXColorSrc C2ColorAmbientSource { get { return (GXColorSrc)(_colorCtrl1C[6] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl1C[6] = ((int)value != 0); } }
        [Category("Lighting Channel 2")]
        public GXDiffuseFn C2ColorDiffuseFunction { get { return (GXDiffuseFn)(_colorCtrl1C[7, 2]); } set { if (!CheckIfMetal()) _colorCtrl1C[7, 2] = ((uint)value); } }
        [Category("Lighting Channel 2")]
        public GXAttnFn C2ColorAttenuation
        {
            get
            {
                if (!_colorCtrl1C[9])
                    return GXAttnFn.None;
                else
                    return (GXAttnFn)(_colorCtrl1C[10] ? 1 : 0);
            }
            set
            {
                if (!CheckIfMetal())
                {
                    if (value != GXAttnFn.None)
                    {
                        _colorCtrl1C[9] = true;
                        _colorCtrl1C[10] = ((int)value) != 0;
                    }
                    else
                    {
                        _colorCtrl1C[9] = false;
                        _colorCtrl1C[10] = false;
                    }
                }
            }
        }
        [Category("Lighting Channel 2")]
        public MatChanLights C2ColorLights
        {
            get
            {
                return (MatChanLights)(_colorCtrl1C[2, 4] | (_colorCtrl1C[11, 4] << 4));
            }
            set
            {
                if (!CheckIfMetal())
                {
                    uint val = (uint)value;
                    _colorCtrl1C[2, 4] = (val & 0xF);
                    _colorCtrl1C[11, 4] = ((val >> 4) & 0xF);
                }
            }
        }

        [Category("Lighting Channel 2")]
        public GXColorSrc C2AlphaMaterialSource { get { return (GXColorSrc)(_colorCtrl1A[0] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl1A[0] = ((int)value != 0); } }
        [Category("Lighting Channel 2")]
        public bool C2AlphaEnabled { get { return _colorCtrl1A[1]; } set { if (!CheckIfMetal()) _colorCtrl1A[1] = value; } }
        [Category("Lighting Channel 2")]
        public GXColorSrc C2AlphaAmbientSource { get { return (GXColorSrc)(_colorCtrl1A[6] ? 1 : 0); } set { if (!CheckIfMetal()) _colorCtrl1A[6] = ((int)value != 0); } }
        [Category("Lighting Channel 2")]
        public GXDiffuseFn C2AlphaDiffuseFunction { get { return (GXDiffuseFn)(_colorCtrl1A[7, 2]); } set { if (!CheckIfMetal()) _colorCtrl1A[7, 2] = ((uint)value); } }
        [Category("Lighting Channel 2")]
        public GXAttnFn C2AlphaAttenuation
        {
            get
            {
                if (!_colorCtrl1A[9])
                    return GXAttnFn.None;
                else
                    return (GXAttnFn)(_colorCtrl1A[10] ? 1 : 0);
            }
            set
            {
                if (!CheckIfMetal())
                {
                    if (value != GXAttnFn.None)
                    {
                        _colorCtrl1A[9] = true;
                        _colorCtrl1A[10] = ((int)value) != 0;
                    }
                    else
                    {
                        _colorCtrl1A[9] = false;
                        _colorCtrl1A[10] = false;
                    }
                }
            }
        }
        [Category("Lighting Channel 2")]
        public MatChanLights C2AlphaLights
        {
            get
            {
                return (MatChanLights)(_colorCtrl1A[2, 4] | (_colorCtrl1A[11, 4] << 4));
            }
            set
            {
                if (!CheckIfMetal())
                {
                    uint val = (uint)value;
                    _colorCtrl1A[2, 4] = (val & 0xF);
                    _colorCtrl1A[11, 4] = ((val >> 4) & 0xF);
                }
            }
        }

        public Bin32 _colorCtrl0C, _colorCtrl0A, _colorCtrl1C, _colorCtrl1A;

        //For compatibility
        [Browsable(false)]
        public byte e00 { get { return (byte)_colorCtrl0C[0, 8]; } set { _colorCtrl0C[0, 8] = value; } }
        [Browsable(false)]
        public byte e01 { get { return (byte)_colorCtrl0C[8, 8]; } set { _colorCtrl0C[8, 8] = value; } }
        [Browsable(false)]
        public byte e02 { get { return (byte)_colorCtrl0A[0, 8]; } set { _colorCtrl0A[0, 8] = value; } }
        [Browsable(false)]
        public byte e03 { get { return (byte)_colorCtrl0A[8, 8]; } set { _colorCtrl0A[8, 8] = value; } }
        [Browsable(false)]
        public byte e10 { get { return (byte)_colorCtrl1C[0, 8]; } set { _colorCtrl1C[0, 8] = value; } }
        [Browsable(false)]
        public byte e11 { get { return (byte)_colorCtrl1C[8, 8]; } set { _colorCtrl1C[8, 8] = value; } }
        [Browsable(false)]
        public byte e12 { get { return (byte)_colorCtrl1A[0, 8]; } set { _colorCtrl1A[0, 8] = value; } }
        [Browsable(false)]
        public byte e13 { get { return (byte)_colorCtrl1A[8, 8]; } set { _colorCtrl1A[8, 8] = value; } }
        
        [Category("Material")]
        public bool XLUMaterial { get { return (_usageFlags & 0x80000000) == 0x80000000; } set { if (!CheckIfMetal()) { if (value == false) { _usageFlags &= ~0x80000000; _blendMode.EnableBlend = false; } else { _usageFlags |= 0x80000000; } } } }
        
        //[Category("Material")]
        //public byte Texgens { get { return _numTextures; } }//set { if (!CheckIfMetal()) _numTextures = value;  } }
        [Category("Material")]
        public byte LightChannels { get { return _numLights; } set { if (!CheckIfMetal()) _numLights = (value > 2 ? (byte)2 : value < 0 ? (byte)0 : value); } }
        [Category("Material")]
        public byte ActiveShaderStages { get { return _ssc; } set { if (!CheckIfMetal()) _ssc = (value > ShaderNode.stages ? (byte)ShaderNode.stages : value < 1 ? (byte)1 : value); } }
        [Category("Material")]
        public byte IndirectTextures { get { return _clip; } set { if (!CheckIfMetal()) _clip = (value > 4 ? (byte)4 : value < 0 ? (byte)0 : value); } }
        [Category("Material")]
        public CullMode CullMode { get { return _cull; } set { if (!CheckIfMetal()) _cull = value;  } }
        [Category("Material")]
        public bool EnableAlphaFunction { get { return _transp != 1; } set { if (!CheckIfMetal()) _transp = (byte)(value ? 0 : 1); } }
        [Category("SCN0 References")]
        public sbyte LightSet { get { return _lSet; } set { if (!CheckIfMetal()) { _lSet = value; if (MetalMaterial != null) MetalMaterial.UpdateAsMetal(); } } }
        [Category("SCN0 References")]
        public sbyte FogSet { get { return _fSet; } set { if (!CheckIfMetal()) { _fSet = value; if (MetalMaterial != null) MetalMaterial.UpdateAsMetal(); } } }
        //[Category("Material")]
        //public byte Pad { get { return _unk1; } }//set { if (!CheckIfMetal()) { _unk1 = value; if (MetalMaterial != null) MetalMaterial.UpdateAsMetal(); } } }

        public enum IndirectMethod
        {
            Warp = 0,
            NormalMap,
            NormalMapSpecular,
            Fur,
            Reserved0,
            Reserved1,
            User0,
            User1
        }
        
        [Category("Material")]
        public IndirectMethod IndirectMethod1 { get { return (IndirectMethod)_indirectMethod1; } set { if (!CheckIfMetal()) _indirectMethod1 = (byte)value; } }
        [Category("Material")]
        public IndirectMethod IndirectMethod2 { get { return (IndirectMethod)_indirectMethod2; } set { if (!CheckIfMetal()) _indirectMethod2 = (byte)value; } }
        [Category("Material")]
        public IndirectMethod IndirectMethod3 { get { return (IndirectMethod)_indirectMethod3; } set { if (!CheckIfMetal()) _indirectMethod3 = (byte)value; } }
        [Category("Material")]
        public IndirectMethod IndirectMethod4 { get { return (IndirectMethod)_indirectMethod4; } set { if (!CheckIfMetal()) _indirectMethod4 = (byte)value; } }

        [Category("SCN0 References")]
        public sbyte NormMapRefLight1 { get { return _normMapRefLight1; } set { if (!CheckIfMetal()) _normMapRefLight1 = value; } }
        [Category("SCN0 References")]
        public sbyte NormMapRefLight2 { get { return _normMapRefLight2; } set { if (!CheckIfMetal()) _normMapRefLight1 = value; } }
        [Category("SCN0 References")]
        public sbyte NormMapRefLight3 { get { return _normMapRefLight3; } set { if (!CheckIfMetal()) _normMapRefLight1 = value; } }
        [Category("SCN0 References")]
        public sbyte NormMapRefLight4 { get { return _normMapRefLight4; } set { if (!CheckIfMetal()) _normMapRefLight1 = value; } }
        
        //[Category("Material")]
        //public int NumTextures { get { return Header->_numTextures; } }
        //[Category("Material"), Browsable(false)]
        //public int ShaderOffset { get { return Header->_shaderOffset; } }
        //[Category("Material"), Browsable(false)]
        //public int MaterialRefOffset { get { return _matRefOffset; } }
        //[Category("Material"), Browsable(false)]
        //public int UserDataOffset { get { return _part2Offset; } }
        //[Category("Material"), Browsable(false)]
        //public int DisplayListOffset { get { return _dlOffset; } }
        //[Category("Material")]
        //public int Pad { get { return _pad2; } }
        
        public void Render(GLContext ctx)
        {
            //if (!ShaderNode.rendered)
            //ShaderNode.Render(ctx, this);

            #region LayerRendering

            ////Write struct variables
            //shader += "struct VS_OUTPUT {\n";
            //shader += "  float4 pos : POSITION;\n";
            //shader += "  float4 colors_0 : COLOR0;\n";
            //shader += "  float4 colors_1 : COLOR1;\n";

            ////if (xfregs.numTexGen.numTexGens < 7) {
            ////    for (unsigned int i = 0; i < xfregs.numTexGen.numTexGens; ++i)
            ////        WRITE(p, "  float3 tex%d : TEXCOORD%d;\n", i, i);
            ////    WRITE(p, "  float4 clipPos : TEXCOORD%d;\n", xfregs.numTexGen.numTexGens);
            ////    if(g_ActiveConfig.bEnablePixelLighting && g_ActiveConfig.backend_info.bSupportsPixelLighting)
            ////        WRITE(p, "  float4 Normal : TEXCOORD%d;\n", xfregs.numTexGen.numTexGens + 1);
            ////} else {
            ////    // clip position is in w of first 4 texcoords
            ////    if(g_ActiveConfig.bEnablePixelLighting && g_ActiveConfig.backend_info.bSupportsPixelLighting)
            ////    {
            ////        for (int i = 0; i < 8; ++i)
            ////            WRITE(p, "  float4 tex%d : TEXCOORD%d;\n", i, i);
            ////    }
            ////    else
            ////    {
            ////        for (unsigned int i = 0; i < xfregs.numTexGen.numTexGens; ++i)
            ////            WRITE(p, "  float%d tex%d : TEXCOORD%d;\n", i < 4 ? 4 : 3 , i, i);
            ////    }
            ////}	
            ////WRITE(p, "};\n");

            ////Write code
            //for (int i = 0; i < m.Children.Count; i++)
            //{
            //    MDL0MaterialRefNode mr = m.Children[i] as MDL0MaterialRefNode;
            //    XFTexMtxInfo texinfo = mr.TexMtxFlags;

            //    shader += "{\n";
            //    shader += "coord = float4(0.0f, 0.0f, 1.0f, 1.0f);\n";
            //    switch (texinfo.SourceRow)
            //    {
            //        case TexSourceRow.Geometry:
            //            if (texinfo.InputForm == TexInputForm.ABC1)
            //                shader += "coord = rawpos;\n"; // pos.w is 1
            //            break;
            //        case TexSourceRow.Normals:
            //            //if (components & VB_HAS_NRM0) 
            //            //{
            //            if (texinfo.InputForm == TexInputForm.ABC1)
            //                shader += "coord = float4(rawnorm0.xyz, 1.0f);\n";
            //            //}
            //            break;
            //        case TexSourceRow.Colors:
            //            if (texinfo.TexGenType == TexTexgenType.Color0 || texinfo.TexGenType == TexTexgenType.Color1) ;
            //            break;
            //        case TexSourceRow.BinormalsT:
            //            //if (components & VB_HAS_NRM1) 
            //            //{
            //            if (texinfo.InputForm == TexInputForm.ABC1)
            //                shader += "coord = float4(rawnorm1.xyz, 1.0f);\n";
            //            //}
            //            break;
            //        case TexSourceRow.BinormalsB:
            //            //if (components & VB_HAS_NRM2) 
            //            //{
            //            if (texinfo.InputForm == TexInputForm.ABC1)
            //                shader += "coord = float4(rawnorm2.xyz, 1.0f);\n";
            //            //}
            //            break;
            //        default:
            //            if (texinfo.SourceRow <= TexSourceRow.TexCoord7)
            //                //if (components & (VB_HAS_UV0 << (texinfo.SourceRow - TexSourceRow.TexCoord0)))
            //                shader += String.Format("coord = float4(tex{0}.x, tex{0}.y, 1.0f, 1.0f);\n", texinfo.SourceRow - TexSourceRow.TexCoord0);
            //            break;
            //    }

            //    // first transformation
            //    switch (texinfo.TexGenType)
            //    {
            //        case TexTexgenType.EmbossMap: //Calculate tex coords into bump map

            //            //No BT support yet
            //            //if (components & (VB_HAS_NRM1|VB_HAS_NRM2))
            //            //{
            //            // transform the light dir into tangent space
            //            //shader += "ldir = normalize("I_LIGHTS".lights[%d].pos.xyz - pos.xyz);\n", texinfo.embosslightshift);
            //            //shader += "o.tex%d.xyz = o.tex%d.xyz + float3(dot(ldir, _norm1), dot(ldir, _norm2), 0.0f);\n", i, texinfo.embosssourceshift);
            //            //}
            //            //else
            //            //{
            //            //if (0); // should have normals
            //            shader += String.Format("o.tex{0}.xyz = o.tex{1}.xyz;\n", i, texinfo.EmbossSource);
            //            //}

            //            break;
            //        case TexTexgenType.Color0:
            //            if (texinfo.SourceRow == TexSourceRow.Colors)
            //                shader += String.Format("o.tex{0}.xyz = float3(o.colors_0.x, o.colors_0.y, 1);\n", i);
            //            break;
            //        case TexTexgenType.Color1:
            //            if (texinfo.SourceRow == TexSourceRow.Colors) ;
            //            shader += String.Format("o.tex{0}.xyz = float3(o.colors_1.x, o.colors_1.y, 1);\n", i);
            //            break;
            //        case TexTexgenType.Regular:
            //        default:
            //            //if (components & (VB_HAS_TEXMTXIDX0 << i)) 
            //            {
            //                if (texinfo.Projection == TexProjection.STQ)
            //                    shader += String.Format("o.tex{0}.xyz = float3(dot(coord, " + I_TRANSFORMMATRICES + ".T[tex{0}.z].t), dot(coord, " + I_TRANSFORMMATRICES + ".T[tex{0}.z+1].t), dot(coord, " + I_TRANSFORMMATRICES + ".T[tex{0}.z+2].t));\n", i);
            //                else
            //                    shader += String.Format("o.tex{0}.xyz = float3(dot(coord, " + I_TRANSFORMMATRICES + ".T[tex{0}.z].t), dot(coord, " + I_TRANSFORMMATRICES + ".T[tex{0}.z+1].t), 1);\n", i);
            //            }
            //            //else 
            //            //{
            //            //    if (texinfo.Projection == TexProjection.STQ)
            //            //        shader += String.Format("o.tex%d.xyz = float3(dot(coord, "+I_TEXMATRICES+".T[%d].t), dot(coord, "+I_TEXMATRICES+".T[%d].t), dot(coord, "+I_TEXMATRICES+".T[%d].t));\n", i, 3*i, 3*i+1, 3*i+2);
            //            //    else
            //            //        shader += String.Format("o.tex%d.xyz = float3(dot(coord, "+I_TEXMATRICES+".T[%d].t), dot(coord, "+I_TEXMATRICES+".T[%d].t), 1);\n", i, 3*i, 3*i+1);
            //            //}
            //            break;
            //    }

            //    //if (mr.DualTexFlags.NormalEnable == 1 && texinfo.TexGenType == TexTexgenType.Regular) { // only works for regular tex gen types?
            //    //    const PostMtxInfo& postInfo = xfregs.postMtxInfo[i];

            //    //    int postidx = postInfo.index;
            //    //    shader += "float4 P0 = "I_POSTTRANSFORMMATRICES".T[%d].t;\n"
            //    //        "float4 P1 = "I_POSTTRANSFORMMATRICES".T[%d].t;\n"
            //    //        "float4 P2 = "I_POSTTRANSFORMMATRICES".T[%d].t;\n",
            //    //        postidx&0x3f, (postidx+1)&0x3f, (postidx+2)&0x3f);

            //    //    //if (texGenSpecialCase) {
            //    //    //    // no normalization
            //    //    //    // q of input is 1
            //    //    //    // q of output is unknown

            //    //    //    // multiply by postmatrix
            //    //    //    shader += "o.tex%d.xyz = float3(dot(P0.xy, o.tex%d.xy) + P0.z + P0.w, dot(P1.xy, o.tex%d.xy) + P1.z + P1.w, 0.0f);\n", i, i, i);
            //    //    }
            //    //    else
            //    //    {
            //    //        if (postInfo.normalize)
            //    //            shader += "o.tex%d.xyz = normalize(o.tex%d.xyz);\n", i, i);

            //    //        // multiply by postmatrix
            //    //        shader += "o.tex%d.xyz = float3(dot(P0.xyz, o.tex%d.xyz) + P0.w, dot(P1.xyz, o.tex%d.xyz) + P1.w, dot(P2.xyz, o.tex%d.xyz) + P2.w);\n", i, i, i, i);
            //    //    }
            //    //}

            //    shader += "}\n";
            //}

            #endregion

            if (Model._mainWindow != null && Model._mainWindow._scn0 != null && (LightSet >= 0 || FogSet >= 0))
            {
                ModelEditControl m = Model._mainWindow;
                SCN0Node scn = m._scn0;
                int animFrame = m._animFrame;
                SCN0GroupNode fog;
                if (FogSet >= 0 && (fog = scn.GetFolder<SCN0FogNode>()) != null && fog.Children.Count > FogSet)
                {
                    SCN0FogNode f = fog.Children[FogSet] as SCN0FogNode;
                    ctx.glEnable(GLEnableCap.Fog);
                    uint mode = 0;
                    switch (f.Type)
                    {
                        case FogType.OrthographicExp:
                        case FogType.PerspectiveExp:
                            mode = (uint)FogMode.Exp;
                            break;
                        case FogType.OrthographicExp2:
                        case FogType.PerspectiveExp2:
                            mode = (uint)FogMode.Exp2;
                            break;
                        case FogType.OrthographicLinear:
                        case FogType.PerspectiveLinear:
                            mode = (uint)FogMode.Linear;
                            break;
                        case FogType.OrthographicRevExp:
                        case FogType.PerspectiveRevExp:
                            mode = (uint)FogMode.Linear;
                            break;
                        case FogType.OrthographicRevExp2:
                        case FogType.PerspectiveRevExp2:
                            mode = (uint)FogMode.Linear;
                            break;
                    }
                    ctx.glFog(FogParameter.FogMode, mode);
                    float* l = stackalloc float[4];
                    if (f.ColorsArr.Length == 1)
                    {
                        l[0] = (float)f.Colors[0].R / 255f;
                        l[1] = (float)f.Colors[0].G / 255f;
                        l[2] = (float)f.Colors[0].B / 255f;
                        l[3] = (float)f.Colors[0].A / 255f;
                    }
                    else if (animFrame - 1 < f.ColorsArr.Length)
                    {
                        l[0] = (float)f.Colors[animFrame - 1].R / 255f;
                        l[1] = (float)f.Colors[animFrame - 1].G / 255f;
                        l[2] = (float)f.Colors[animFrame - 1].B / 255f;
                        l[3] = (float)f.Colors[animFrame - 1].A / 255f;
                    }
                    ctx.glFog(FogParameter.FogColor, l);
                    //ctx.glFog(FogParameter.FogDensity, 0.05f);
                    ctx.glHint(GLHintTarget.FOG_HINT, GLHintMode.NICEST);
                    ctx.glFog(FogParameter.FogStart, f._startKeys.GetFrameValue(animFrame - 1));
                    ctx.glFog(FogParameter.FogEnd, f._endKeys.GetFrameValue(animFrame - 1));
                }
                else
                    ctx.glDisable((uint)GLEnableCap.Fog);
            }
            else
            {
                ctx.glDisable((uint)GLEnableCap.Fog);

            }
        }

        public bool updating = false;
        public void UpdateAsMetal()
        {
            if (!isMetal)
                return;

            updating = true;
            if (ShaderNode != null && ShaderNode._autoMetal && ShaderNode.texCount == Children.Count)
            { 
                //ShaderNode.DefaultAsMetal(Children.Count); 
            }
            else
            {
                bool found = false;
                foreach (MDL0ShaderNode s in Model._shadGroup.Children)
                {
                    if (s._autoMetal && s.texCount == Children.Count)
                    {
                        ShaderNode = s;
                        found = true;
                    }
                    else
                    {
                        if (s.stages == 4)
                        {
                            foreach (MDL0MaterialNode y in s._materials)
                                if (!y.isMetal || y.Children.Count != Children.Count)
                                    goto NotFound;
                            ShaderNode = s;
                            found = true;
                            goto End;
                        NotFound:
                            continue;
                        }
                    }
                }
            End:
                if (!found)
                {
                    MDL0ShaderNode shader = new MDL0ShaderNode();
                    Model._shadGroup.AddChild(shader);
                    shader.DefaultAsMetal(Children.Count);
                    ShaderNode = shader;
                }
            }

            if (MetalMaterial != null)
            {
                Name = MetalMaterial.Name + "_ExtMtl";
                _ssc = 4;

                if (Children.Count - 1 != MetalMaterial.Children.Count)
                {
                    //Remove all children
                    for (int i = 0; i < Children.Count; i++)
                    {
                        ((MDL0MaterialRefNode)Children[i]).TextureNode = null;
                        ((MDL0MaterialRefNode)Children[i]).PaletteNode = null;
                        RemoveChild(Children[i--]);
                    }

                    //Start over
                    for (int i = 0; i <= MetalMaterial.Children.Count; i++)
                    {
                        MDL0MaterialRefNode mr = new MDL0MaterialRefNode();

                        AddChild(mr);
                        mr.Texture = "metal00";
                        mr._index1 = mr._index2 = i;

                        mr._texFlags.TexScale = new Vector2(1);
                        mr._bindState._scale = new Vector3(1);
                        mr._texMatrix.TexMtx = Matrix43.Identity;
                        mr._texMatrix.SCNCamera = -1;
                        mr._texMatrix.SCNLight = -1;
                        mr._texMatrix.Identity = 1;

                        if (i == MetalMaterial.Children.Count)
                        {
                            mr._minFltr = 5;
                            mr._magFltr = 1;
                            mr._lodBias = -2;
                            mr.HasTextureMatrix = true;
                            mr._projection = (int)TexProjection.STQ;
                            mr._inputForm = (int)TexInputForm.ABC1;
                            mr._sourceRow = (int)TexSourceRow.Normals;
                            mr.Normalize = true;
                            mr.MapMode = (MDL0MaterialRefNode.MappingMethod)1;
                        }
                        else
                        {
                            mr._projection = (int)TexProjection.ST;
                            mr._inputForm = (int)TexInputForm.AB11;
                            mr._sourceRow = (int)TexSourceRow.TexCoord0 + i;
                            mr.Normalize = false;
                            mr.MapMode = (MDL0MaterialRefNode.MappingMethod)0;
                        }

                        mr._texGenType = (int)TexTexgenType.Regular;
                        mr._embossSource = 4;
                        mr._embossLight = 2;

                        mr.getTexMtxVal();
                    }

                    flags0 = 63;
                    c00.R = c00.G = c00.B = 128; c00.A = 255;
                    c01.R = c01.G = c01.B = c01.A = 255;
                    e01 = e03 = 2; 
                    e00 = e02 = 7;
                    flags1 = 63;
                    c10.R = c10.G = c10.B = c10.A = 255;
                    e10 = e11 = e12 = 2;

                    _lSet = MetalMaterial._lSet;
                    _fSet = MetalMaterial._fSet;
                    _pad1 = MetalMaterial._pad1;

                    _cull = MetalMaterial._cull;
                    _numLights = 2;
                    EnableAlphaFunction = false;
                    _normMapRefLight1 =
                    _normMapRefLight2 =
                    _normMapRefLight3 =
                    _normMapRefLight4 = -1;

                    SignalPropertyChange();
                }
            }
            updating = false;
        }

        public bool CheckIfMetal()
        {
            if (Model._autoMetal)
            {
                if (!updating)
                {
                    if (isMetal)
                        if (MessageBox.Show(null, "This model is currently set to automatically modify metal materials.\nYou cannot make changes unless you turn it off.\nDo you want to turn it off?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            Model._autoMetal = false;
                        else
                            return true;
                }
            }

            SignalPropertyChange();
            return false;
        }

        [Browsable(false)]
        public bool isMetal { get { return Name.EndsWith("_ExtMtl"); } }

        [Browsable(false)]
        public MDL0MaterialNode MetalMaterial
        {
            get
            {
                foreach (MDL0MaterialNode t in Model._matList)
                {
                    if (!isMetal)
                    {
                        if (t.Name.StartsWith(Name) && t.isMetal)
                            return t;
                    }
                    else if (Name.StartsWith(t.Name) && !t.isMetal) return t;
                }
                return null;
            }
        }

        protected override bool OnInitialize()
        {
            MDL0Material* header = Header;

            if ((_name == null) && (header->_stringOffset != 0))
                _name = header->ResourceString;

            XFCmds.Clear();

            //Get XF Commands
            byte* pData = (byte*)header->DisplayLists(Model._version) + 0xE0;
        Top:
            if (*pData++ == 0x10)
            {
                XFData dat = new XFData();
                int count = (ushort)*(bushort*)pData; pData += 2;
                dat.addr = (XFMemoryAddr)(ushort)*(bushort*)pData; pData += 2;
                dat.values = new List<uint>();
                for (int i = 0; i < count + 1; i++) 
                {
                    dat.values.Add(*(buint*)pData); 
                    pData += 4; 
                }
                XFCmds.Add(dat);
                goto Top;
            }

            _mdl0Offset = header->_mdl0Offset;
            _stringOffset = header->_stringOffset;

            _dataLen = header->_dataLen;
            _index = header->_index;
            _numTextures = header->_numTexGens;
            _numLights = header->_numLightChans;
            _usageFlags = header->_usageFlags;

            _indirectMethod1 = header->_indirectMethod1;
            _indirectMethod2 = header->_indirectMethod2;
            _indirectMethod3 = header->_indirectMethod3;
            _indirectMethod4 = header->_indirectMethod4;
            
            _normMapRefLight1 = header->_normMapRefLight1;
            _normMapRefLight2 = header->_normMapRefLight2;
            _normMapRefLight3 = header->_normMapRefLight3;
            _normMapRefLight4 = header->_normMapRefLight4;

            _ssc = header->_activeTEVStages;
            _clip = header->_numIndTexStages;
            _transp = header->_enableAlphaTest;

            _lSet = header->_lightSet;
            _fSet = header->_fogSet;
            _pad1 = header->_pad1;

            _cull = (CullMode)(int)header->_cull;

            if ((-header->_mdl0Offset + (int)header->DisplayListOffset(Model._version)) % 0x20 != 0)
            {
                Model._errors.Add("Material " + Index + " has an improper align offset.");
                SignalPropertyChange();
            }

            _matRefOffset = header->_matRefOffset;

            if (Model._version > 9)
            {
                _part2Offset = header->_dlOffset;
                _dlOffset = header->_dlOffsetv10p;
                _furDataOffset = header->_userDataOffset;
            }
            else
            {
                _part2Offset = header->_userDataOffset;
                _dlOffset = header->_dlOffset;
                _furDataOffset = 0;
            }

            mode = header->DisplayLists(Model._version);
            _alphaFunc = mode->AlphaFunction;
            _zMode = mode->ZMode;
            _blendMode = mode->BlendMode;
            _constantAlpha = mode->ConstantAlpha;

            _tevColorBlock = *header->TevColorBlock(Model._version);
            _tevKonstBlock = *header->TevKonstBlock(Model._version);
            _indMtx = *header->IndMtxBlock(Model._version);

            MDL0TexSRTData* TexMatrices = header->TexMatrices(Model._version);

            _layerFlags = TexMatrices->_layerFlags;
            _texMtxFlags = TexMatrices->_mtxFlags;

            MDL0MaterialLighting* Light = header->Light(Model._version);

            c00 = Light->c00;
            c01 = Light->c01;
            flags0 = Light->flags0;
            _colorCtrl0C = new Bin32(Light->_colorCtrl00);
            _colorCtrl0A = new Bin32(Light->_colorCtrl01);
            c10 = Light->c10;
            c11 = Light->c11;
            flags1 = Light->flags1;
            _colorCtrl1C = new Bin32(Light->_colorCtrl10);
            _colorCtrl1A = new Bin32(Light->_colorCtrl11);

            UserData* part2 = header->UserData(Model._version);
            if (part2 != null)
            {
                ResourceGroup* group = part2->Group;
                ResourceEntry* pEntry = &group->_first + 1;
                int count = group->_numEntries;
                for (int i = 0; i < count; i++)
                {
                    UserDataEntry* entry = (UserDataEntry*)((VoidPtr)group + pEntry->_dataOffset);
                    UserDataClass d = new UserDataClass() { _name = new String((sbyte*)group + pEntry->_stringOffset) };
                    VoidPtr addr = (VoidPtr)entry + entry->_dataOffset;
                    d._type = entry->Type;
                    for (int x = 0; x < entry->_entryCount; x++)
                    {
                        switch (entry->Type)
                        {
                            case UserValueType.Float:
                                d._entries.Add(((float)*(bfloat*)addr).ToString());
                                addr += 4;
                                break;
                            case UserValueType.Int:
                                d._entries.Add(((int)*(bint*)addr).ToString());
                                addr += 4;
                                break;
                            case UserValueType.String:
                                string s = new String((sbyte*)addr);
                                d._entries.Add(s);
                                addr += s.Length + 1;
                                break;
                        }
                    }
                    _part2Entries.Add(d);
                }
            }

            if (_replaced)
                foreach (MDL0MaterialRefNode m in Children)
                    m._replaced = true;

            Populate();
            return true;
        }

        protected override void OnPopulate()
        {
            MDL0TextureRef* first = Header->First;
            for (int i = 0; i < Header->_numTextures; i++)
                new MDL0MaterialRefNode().Initialize(this, first++, MDL0TextureRef.Size);
        }

        internal override void GetStrings(StringTable table)
        {
            table.Add(Name);

            foreach (UserDataClass s in _part2Entries)
                table.Add(s._name);

            foreach (MDL0MaterialRefNode n in Children)
                n.GetStrings(table);
        }

        public int _dataAlign = 0, _mdlOffset = 0;
        protected override int OnCalculateSize(bool force)
        {
            int temp, size;

            //Add header and tex matrices size at start
            if (Model._version >= 10)
                size = 0x418;
            else
                size = 0x414;

            //Add children size
            size += Children.Count * MDL0TextureRef.Size;

            //Add part 2 entries, if there are any
            if (_part2Entries.Count > 0)
            {
                size += 0x18 + (_part2Entries.Count * 0x2C);
                foreach (UserDataClass c in _part2Entries)
                    foreach (string s in c._entries)
                        if (c.DataType == UserValueType.Float)
                            size += 4;
                        else if (c.DataType == UserValueType.Int)
                            size += 4;
                        else if (c.DataType == UserValueType.String)
                            size += s.Length + 1;
            }
            
            temp = size; //Set temp align offset

            //Align data to an offset divisible by 0x20 using data length.
            size = size.Align(0x10) + _dataAlign;
            if ((size + _mdlOffset) % 0x20 != 0)
                if (size - 0x10 >= temp)
                    size -= 0x10;
                else
                    size += 0x10;

            //Reset data alignment
            _dataAlign = 0;

            //Add display list and XF flags
            size += 0x180;

            return size;
        }

        public bool New = false;
        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            MDL0Material* header = (MDL0Material*)address;

            ushort i1 = 0x1040, i2 = 0x1050; int mtx = 0;

            //Set offsets
            header->_dataLen = _dataLen = length;

            if (Model._version >= 10)
            {
                header->_dlOffset = 0; //Fur Data not supported
                header->_dlOffsetv10p = length - 0x180;
                if (Children.Count > 0)
                    header->_matRefOffset = 1048;
                else
                    header->_matRefOffset = 0;
            }
            else
            {
                header->_dlOffset = length - 0x180;
                if (Children.Count > 0)
                    header->_matRefOffset = 1044;
                else
                    header->_matRefOffset = 0;
            }

            //Check for part2 entries
            if (_part2Entries.Count > 0)
            {
                _part2Offset = header->_matRefOffset + Children.Count * 0x34;
                if (Model._version == 11 || Model._version == 10)
                    header->_dlOffset = _part2Offset;
                else
                    header->_userDataOffset = _part2Offset;
                
                UserData* part2 = header->UserData(Model._version);
                if (part2 != null)
                {
                    part2->_totalLen = 0x1C + _part2Entries.Count * 0x2C;
                    ResourceGroup* pGroup = part2->Group;
                    *pGroup = new ResourceGroup(_part2Entries.Count);
                    ResourceEntry* pEntry = &pGroup->_first + 1;
                    byte* pData = (byte*)pGroup + pGroup->_totalSize;
                    int id = 0;
                    foreach (UserDataClass s in _part2Entries)
                    {
                        (pEntry++)->_dataOffset = (int)pData - (int)pGroup;
                        UserDataEntry* p = (UserDataEntry*)pData;
                        *p = new UserDataEntry(s._entries.Count, s._type, id++);
                        pData += 0x18;
                        for (int i = 0; i < s._entries.Count; i++)
                            if (s.DataType == UserValueType.Float)
                            {
                                float x;
                                if (!float.TryParse(s._entries[i], out x))
                                    x = 0;
                                *(bfloat*)pData = x;
                                pData += 4;
                            }
                            else if (s.DataType == UserValueType.Int)
                            {
                                int x;
                                if (!int.TryParse(s._entries[i], out x))
                                    x = 0;
                                *(bint*)pData = x;
                                pData += 4;
                            }
                            else if (s.DataType == UserValueType.String)
                            {
                                if (s._entries[i] == null)
                                    s._entries[i] = "";

                                int len = s._entries[i].Length;
                                int ceil = len + 1;

                                sbyte* ptr = (sbyte*)pData;

                                for (int x = 0; x < len; )
                                    ptr[x] = (sbyte)s._entries[i][x++];

                                for (int x = len; x < ceil; )
                                    ptr[x++] = 0;

                                pData += s._entries[i].Length + 1;
                            }
                        p->_totalLen = (int)pData - (int)p;
                    }
                }
            }
            else
                _part2Offset = header->_userDataOffset = 0;

            //Set defaults if the model is an import or the material was created
            if (Model._isImport || New)
            {
                if (Model._importOptions._mdlType == 0 || New)
                {
                    _lSet = 20;
                    _fSet = 4;
                    _normMapRefLight1 =
                    _normMapRefLight2 =
                    _normMapRefLight3 =
                    _normMapRefLight4 = -1;
                    _ssc = 3;

                    _cull = CullMode.Cull_Inside;
                    _numLights = 1;

                    flags0 = 63;
                    c00.R = c00.G = c00.B = c00.A = 255;
                    c01.R = c01.G = c01.B = c01.A = 255;
                    e01 = e03 = 3;
                    e00 = e02 = 7;
                    flags1 = 15; c10.A = 255;
                }
                else
                {
                    _lSet = 1;
                    _fSet = 0;
                    _normMapRefLight1 =
                    _normMapRefLight2 =
                    _normMapRefLight3 =
                    _normMapRefLight4 = -1;
                    _ssc = 1;
                    _cull = CullMode.Cull_Inside;
                    _numLights = 1;

                    flags0 = 63;
                    c00.R = c00.G = c00.B = c00.A = 255;
                    c01.R = c01.G = c01.B = c01.A = 255;
                    e01 = 3; e03 = 1;
                    e00 = e02 = 7;
                    flags1 = 15; c10.A = 255;
                }

                //Set default texgen flags
                for (int i = 0; i < Children.Count; i++)
                {
                    MDL0MaterialRefNode node = ((MDL0MaterialRefNode)Children[i]);

                    //Tex Mtx
                    XFData dat = new XFData();
                    dat.addr = (XFMemoryAddr)i1++;
                    XFTexMtxInfo tex = new XFTexMtxInfo();
                    tex._data = (uint)(0 | 
                        ((int)TexProjection.ST << 1) |
                        ((int)TexInputForm.AB11 << 2) |
                        ((int)TexTexgenType.Regular << 4) |
                        ((int)(0x5) << 7) |
                        (4 << 10) | 
                        (2 << 13));
                    dat.values.Add(tex._data); 
                    XFCmds.Add(dat);
                    node.TexMtxFlags = tex;

                    //Dual Tex
                    dat = new XFData();
                    dat.addr = (XFMemoryAddr)i2++;
                    XFDualTex dtex = new XFDualTex(mtx, 0); mtx += 3;
                    dat.values.Add(dtex.Value);
                    XFCmds.Add(dat);
                    node.DualTexFlags = dtex;
                    node.getValues();
                    node._texFlags.TexScale = new Vector2(1);
                    node._bindState._scale = new Vector3(1);
                    node._texMatrix.TexMtx = Matrix43.Identity;
                    node._texMatrix.SCNCamera = -1;
                    node._texMatrix.SCNLight = -1;
                    node._texMatrix.MapMode = 0;
                    node._texMatrix.Identity = 1;
                }
            }

            //Set header values
            header->_numTextures = Children.Count;
            header->_numTexGens = _numTextures = (byte)Children.Count;
            header->_index = _index = Index;
            header->_numLightChans = _numLights;
            header->_activeTEVStages = (byte)_ssc;
            header->_numIndTexStages = _clip;
            header->_enableAlphaTest = _transp;

            header->_lightSet = _lSet;
            header->_fogSet = _fSet;
            header->_pad1 = _pad1;

            header->_cull = (int)_cull;
            header->_usageFlags = _usageFlags;

            header->_indirectMethod1 = _indirectMethod1;
            header->_indirectMethod2 = _indirectMethod2;
            header->_indirectMethod3 = _indirectMethod3;
            header->_indirectMethod4 = _indirectMethod4;

            header->_normMapRefLight1 = _normMapRefLight1;
            header->_normMapRefLight2 = _normMapRefLight2;
            header->_normMapRefLight3 = _normMapRefLight3;
            header->_normMapRefLight4 = _normMapRefLight4;

            //Generate layer flags and write texture matrices
            MDL0TexSRTData* TexSettings = header->TexMatrices(Model._version);
            *TexSettings = MDL0TexSRTData.Default;

            _layerFlags = 0;
            for (int i = Children.Count - 1; i >= 0; i--)
            {
                MDL0MaterialRefNode node = (MDL0MaterialRefNode)Children[i];

                node._flags |= TexFlags.Enabled;

                node._texFlags.TexScale = new Vector2(node._bindState._scale._x, node._bindState._scale._y);
                node._texFlags.TexRotation = node._bindState._rotate._x;
                node._texFlags.TexTranslation = new Vector2(node._bindState._translate._x, node._bindState._translate._y);

                //Check for non-default values
                if (node._texFlags.TexScale != new Vector2(1))
                    node._flags &= 0xF - TexFlags.FixedScale;
                else
                    node._flags |= TexFlags.FixedScale;

                if (node._texFlags.TexRotation != 0)
                    node._flags &= 0xF - TexFlags.FixedRot;
                else
                    node._flags |= TexFlags.FixedRot;

                if (node._texFlags.TexTranslation != new Vector2(0))
                    node._flags &= 0xF - TexFlags.FixedTrans;
                else
                    node._flags |= TexFlags.FixedTrans;

                TexSettings->SetTexFlags(node._texFlags, node.Index);
                TexSettings->SetTexMatrices(node._texMatrix, node.Index);

                _layerFlags = ((_layerFlags << 4) | (byte)node._flags);
            }

            TexSettings->_layerFlags = _layerFlags;
            TexSettings->_mtxFlags = _texMtxFlags;

            //Write lighting flags
            MDL0MaterialLighting* Light = header->Light(Model._version);

            Light->c00 = c00;
            Light->c01 = c01;
            Light->flags0 = flags0;
            Light->_colorCtrl00 = _colorCtrl0C.data;
            Light->_colorCtrl01 = _colorCtrl0A.data;

            Light->c10 = c10;
            Light->c11 = c11;
            Light->flags1 = flags1;
            Light->_colorCtrl10 = _colorCtrl1C.data;
            Light->_colorCtrl11 = _colorCtrl1A.data;

            //The shader offset will be written later

            //Rebuild references
            MDL0TextureRef* mRefs = header->First;
            foreach (MDL0MaterialRefNode n in Children)
                n.Rebuild(mRefs++, 0x34, force);
            
            //Set Display Lists
            *header->TevKonstBlock(Model._version) = _tevKonstBlock;
            *header->TevColorBlock(Model._version) = _tevColorBlock;
            *header->IndMtxBlock(Model._version) = _indMtx;

            mode = header->DisplayLists(Model._version);
            *mode = MatModeBlock.Default;
            if (Model._isImport)
            {
                _alphaFunc = mode->AlphaFunction;
                _zMode = mode->ZMode;
                _blendMode = mode->BlendMode;
                _constantAlpha = mode->ConstantAlpha;
            }
            else
            {
                mode->AlphaFunction = _alphaFunc;
                mode->ZMode = _zMode;
                mode->BlendMode = _blendMode;
                mode->ConstantAlpha = _constantAlpha;
            }

            //Write XF flags
            byte* xfData = (byte*)header->DisplayLists(Model._version) + 0xE0;
            i1 = 0x1040; i2 = 0x1050; mtx = 0;
            foreach (MDL0MaterialRefNode mr in Children)
            {
                //Tex Mtx
                *xfData++ = 0x10;
                *(bushort*)xfData = 0; xfData += 2;
                *(bushort*)xfData = (ushort)i1++;  xfData += 2;
                *(buint*)xfData = mr.TexMtxFlags._data; xfData += 4;

                //Dual Tex
                *xfData++ = 0x10;
                *(bushort*)xfData = 0; xfData += 2;
                *(bushort*)xfData = (ushort)i2++; xfData += 2;
                *(buint*)xfData = new XFDualTex(mtx, mr.DualTexFlags.NormalEnable).Value;
                mtx += 3; xfData += 4;
            }
            
            New = false;
        }

        protected internal override void PostProcess(VoidPtr mdlAddress, VoidPtr dataAddress, StringTable stringTable)
        {
            MDL0Material* header = (MDL0Material*)dataAddress;
            header->_mdl0Offset = (int)mdlAddress - (int)dataAddress;
            header->_stringOffset = (int)stringTable[Name] + 4 - (int)dataAddress;
            header->_index = Index;

            UserData* part2 = header->UserData(Model._version);
            if (part2 != null && _part2Entries.Count != 0)
            {
                ResourceGroup* group = part2->Group;
                group->_first = new ResourceEntry(0xFFFF, 0, 0, 0, 0);
                ResourceEntry* rEntry = group->First;

                for (int i = 0, x = 1; i < group->_numEntries; i++)
                {
                    UserDataEntry* entry = (UserDataEntry*)((int)group + (rEntry++)->_dataOffset);
                    ResourceEntry.Build(group, x++, entry, (BRESString*)stringTable[_part2Entries[i]._name]);
                    entry->ResourceStringAddress = stringTable[_part2Entries[i]._name] + 4;
                }
            }

            MDL0TextureRef* first = header->First;
            foreach (MDL0MaterialRefNode n in Children)
                n.PostProcess(mdlAddress, first++, stringTable);
        }
        
        public override void Remove()
        {
            ShaderNode = null;
            base.Remove();
        }
        internal override void Bind(GLContext ctx) 
        {
            //Polygons will bind the mat refs

            //foreach (MDL0MaterialRefNode m in Children)
            //    m.Bind(ctx);
        }
        internal override void Unbind(GLContext ctx) 
        {
            foreach (MDL0MaterialRefNode m in Children) 
                m.Unbind(ctx); 
        }

        internal void ApplySRT0(SRT0Node node, int index)
        {
            SRT0EntryNode e;

            if (node == null || index == 0)
                foreach (MDL0MaterialRefNode r in Children)
                    r.ApplySRT0Texture(null, 0);
            else if ((e = node.FindChild(Name, false) as SRT0EntryNode) != null)
            {
                foreach (SRT0TextureNode t in e.Children)
                    if (t._textureIndex < Children.Count)
                        ((MDL0MaterialRefNode)Children[t._textureIndex]).ApplySRT0Texture(t, index);
            }
            else
                foreach (MDL0MaterialRefNode r in Children)
                    r.ApplySRT0Texture(null, 0);
        }

        internal unsafe void ApplyPAT0(PAT0Node node, int index)
        {
            PAT0EntryNode e;

            if (node == null || index == 0)
                foreach (MDL0MaterialRefNode r in Children)
                    r.ApplyPAT0Texture(null, 0);
            else if ((e = node.FindChild(Name, false) as PAT0EntryNode) != null)
            {
                foreach (PAT0TextureNode t in e.Children)
                    if (t._textureIndex < Children.Count)
                        ((MDL0MaterialRefNode)Children[t._textureIndex]).ApplyPAT0Texture(t, index);
            }
            else
                foreach (MDL0MaterialRefNode r in Children)
                    r.ApplyPAT0Texture(null, 0);
        }

        public override void RemoveChild(ResourceNode child)
        {
            base.RemoveChild(child);

            if (!updating && Model._autoMetal && MetalMaterial != null && !this.isMetal)
                MetalMaterial.UpdateAsMetal();
        }
        public override unsafe void Export(string outPath)
        {
            StringTable table = new StringTable();
            GetStrings(table);
            int dataLen = OnCalculateSize(true);
            int totalLen = dataLen + table.GetTotalSize();

            using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.RandomAccess))
            {
                stream.SetLength(totalLen);
                using (FileMap map = FileMap.FromStream(stream))
                {
                    Rebuild(map.Address, dataLen, false);
                    table.WriteTable(map.Address + dataLen);
                    PostProcess(map.Address, map.Address, table);
                }
            }
        }
    }
}
