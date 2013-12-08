﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using OpenTK.Graphics.OpenGL;

namespace Ikarus
{
    public static unsafe class Attributes
    {
        public static void PreRender()
        {
            AttributeList list = Manager.GetAttributes();
            if (list == null)
                return;

            float size = list.GetFloat(45);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Scale(size, size, size);
        }
        public static void PostRender()
        {
            AttributeList list = Manager.GetAttributes();
            if (list == null)
                return;


        }
    }
}
