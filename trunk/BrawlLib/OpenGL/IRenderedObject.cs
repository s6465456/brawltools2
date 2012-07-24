using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlLib.OpenGL
{
    public interface IRenderedObject
    {
        void Attach(GLContext context);
        void Detach(GLContext context);
        void Refesh(GLContext context);
        void Render(GLContext context, ModelEditControl mainWindow);
    }
}
