using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.OpenGL;
using OpenTK.Graphics.OpenGL;
using BrawlLib.Imaging;

namespace BrawlLib.Wii.Graphics
{
    public class ShaderGenerator
    {
        private static string tempShader;
        public static string GeneratePixelShader(MDL0ObjectNode obj)
        {
            Reset();

            MDL0MaterialNode mat = obj.UsableMaterialNode;
            MDL0ShaderNode shader = mat.ShaderNode;

            foreach (MDL0MaterialRefNode r in mat.Children)
                w("uniform sampler2D Texture{0};\n", r.TextureCoordId);

            w("uniform vec4 C1Amb;\n");
            w("uniform vec4 C2Amb;\n");
            w("uniform vec4 C1Mat;\n");
            w("uniform vec4 C2Mat;\n");

            w("void main(void)\n{\n");

            w("vec4 creg0;\n");
            w("vec4 creg1;\n");
            w("vec4 creg2;\n");
            w("vec4 prev;\n");

            //foreach (MDL0MaterialRefNode r in mat.Children)
            //    w("uniform sampler2D Texture{0};\n", r.Index);

            //foreach (TEVStage stage in shader.Children)
            //    if (stage.Index < mat.ActiveShaderStages)
            //        w(stage.Write(mat));
            //    else break;

            //if (shader._stages > 0)
            //{
            //    w("prev.rgb = {0};\n", tevCOutputTable[(int)((TEVStage)shader.Children[shader._stages - 1]).ColorRegister]);
            //    w("prev.a = {0};\n", tevAOutputTable[(int)((TEVStage)shader.Children[shader._stages - 1]).AlphaRegister]);
            //}

            w("gl_FragColor = texture2D(Texture0, gl_TexCoord[0].st);");

            w("\n}");

            return tempShader;
        }

        public static string GenerateVertexShader(MDL0ObjectNode obj)
        {
            Reset();

            MDL0MaterialNode mat = obj.UsableMaterialNode;
            MDL0ShaderNode shader = mat.ShaderNode;

            if (obj._manager._faceData[0] != null)
                w("layout (location = 0) in vec3 Position;\n");
            if (obj._manager._faceData[1] != null)
                w("layout (location = 0) in vec3 Normal;\n");
            for (int i = 0; i < 2; i++)
                if (obj._manager._faceData[i + 2] != null)
                    w("layout (location = {1}) in vec4 Color{0};\n", i, i + 2);
            for (int i = 0; i < 8; i++)
                if (obj._manager._faceData[i + 4] != null)
                    w("layout (location = {1}) in vec2 UV{0};\n", i, i + 4);

            w("void main(void)\n{\n");

            w("gl_TexCoord[0] = gl_MultiTexCoord0;");

            w("gl_Position = gl_ModelViewProjectionMatrix * Position;");
            w("gl_Normal = Normal;");

            w("\n}");

            return tempShader;
        }

        public void SetUniforms(MDL0ObjectNode obj)
        {
            MDL0MaterialNode mat = obj.UsableMaterialNode;

            int pHandle = obj._shaderProgramHandle;
            int u = -1;

            u = GL.GetUniformLocation(pHandle, "C1Amb");
            if (u > -1) 
                GL.Uniform4(u, 
                mat.C1AmbientColor.R * RGBAPixel.ColorFactor,
                mat.C1AmbientColor.G * RGBAPixel.ColorFactor,
                mat.C1AmbientColor.B * RGBAPixel.ColorFactor,
                mat.C1AmbientColor.A * RGBAPixel.ColorFactor);

            u = GL.GetUniformLocation(pHandle, "C2Amb");
            if (u > -1) 
                GL.Uniform4(u, 
                mat.C2AmbientColor.R * RGBAPixel.ColorFactor,
                mat.C2AmbientColor.G * RGBAPixel.ColorFactor,
                mat.C2AmbientColor.B * RGBAPixel.ColorFactor,
                mat.C2AmbientColor.A * RGBAPixel.ColorFactor);

            u = GL.GetUniformLocation(pHandle, "C1Mat");
            if (u > -1)
                GL.Uniform4(u,
                mat.C1MaterialColor.R * RGBAPixel.ColorFactor,
                mat.C1MaterialColor.G * RGBAPixel.ColorFactor,
                mat.C1MaterialColor.B * RGBAPixel.ColorFactor,
                mat.C1MaterialColor.A * RGBAPixel.ColorFactor);

            u = GL.GetUniformLocation(pHandle, "C2Mat");
            if (u > -1)
                GL.Uniform4(u,
                mat.C2MaterialColor.R * RGBAPixel.ColorFactor,
                mat.C2MaterialColor.G * RGBAPixel.ColorFactor,
                mat.C2MaterialColor.B * RGBAPixel.ColorFactor,
                mat.C2MaterialColor.A * RGBAPixel.ColorFactor);
        }

        public static readonly string[] tevCOutputTable = { "prev.rgb", "c0.rgb", "c1.rgb", "c2.rgb" };
        public static readonly string[] tevAOutputTable = { "prev.a", "c0.a", "c1.a", "c2.a" };
        public static readonly string[] tevIndAlphaSel = { "", "x", "y", "z" };
        public static readonly string[] tevIndAlphaScale = { "", "*32", "*16", "*8" };
        //public static readonly string[] tevIndAlphaScale = { "*(248.0f/255.0f)", "*(224.0f/255.0f)", "*(240.0f/255.0f)", "*(248.0f/255.0f)" };
        public static readonly string[] tevIndBiasField = { "", "x", "y", "xy", "z", "xz", "yz", "xyz" }; // indexed by bias
        public static readonly string[] tevIndBiasAdd = { "-128.0f", "1.0f", "1.0f", "1.0f" }; // indexed by fmt
        public static readonly string[] tevIndWrapStart = { "0.0f", "256.0f", "128.0f", "64.0f", "32.0f", "16.0f", "0.001f" };
        public static readonly string[] tevIndFmtScale = { "255.0f", "31.0f", "15.0f", "7.0f" };
        public static void Reset()
        {
            tempShader = "";
            tabs = 0;
        }

        private static int tabs = 0;
        private static string Tabs { get { string t = ""; for (int i = 0; i < tabs; i++) t += "\t"; return t; } }
        private static void w(string str, params object[] args)
        {
            if (args.Length == 0) 
                tabs -= Helpers.FindCount(str, 0, '}');

            bool s = false;
            int r = str.LastIndexOf("\n");
            if (r == str.Length - 1)
            {
                str = str.Substring(0, str.Length - 1);
                s = true;
            }
            str = str.Replace("\n", "\n" + Tabs);
            if (s) str += "\n";

            tempShader += Tabs + (args != null && args.Length > 0 ? String.Format(str, args) : str);
            
            if (args.Length == 0)
                tabs += Helpers.FindCount(str, 0, '{');
        }

        /*
            * gl_LightSource[] is a built-in array for all lights.
            struct gl_LightSourceParameters 
            {   
               vec4 ambient;              // Aclarri   
               vec4 diffuse;              // Dcli   
               vec4 specular;             // Scli   
               vec4 position;             // Ppli   
               vec4 halfVector;           // Derived: Hi   
               vec3 spotDirection;        // Sdli   
               float spotExponent;        // Srli   
               float spotCutoff;          // Crli                              
                                          // (range: [0.0,90.0], 180.0)   
               float spotCosCutoff;       // Derived: cos(Crli)                 
                                          // (range: [1.0,0.0],-1.0)   
               float constantAttenuation; // K0   
               float linearAttenuation;   // K1   
               float quadraticAttenuation;// K2  
            };    
            uniform gl_LightSourceParameters gl_LightSource[gl_MaxLights];
            *
            * access the values set with glMaterial using the GLSL built-in variables gl_FrontMateral and gl_BackMaterial.
            struct gl_MaterialParameters  
            {   
               vec4 emission;    // Ecm   
               vec4 ambient;     // Acm   
               vec4 diffuse;     // Dcm   
               vec4 specular;    // Scm   
               float shininess;  // Srm  
            };  
            uniform gl_MaterialParameters gl_FrontMaterial;  
            uniform gl_MaterialParameters gl_BackMaterial; 
            */
    }
}
