using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.IO;
using System.ComponentModel;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class DOLNode : ModuleNode
    {
        internal DOLHeader* Header { get { return (DOLHeader*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }

        DOLHeader hdr;

        [Category("DOLphin Static Module")]
        public string Text0Offset { get { return ((uint)hdr.Text0Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text1Offset { get { return ((uint)hdr.Text1Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text2Offset { get { return ((uint)hdr.Text2Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text3Offset { get { return ((uint)hdr.Text3Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text4Offset { get { return ((uint)hdr.Text4Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text5Offset { get { return ((uint)hdr.Text5Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text6Offset { get { return ((uint)hdr.Text6Offset).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string Data0Offset { get { return ((uint)hdr.Data0Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data1Offset { get { return ((uint)hdr.Data1Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data2Offset { get { return ((uint)hdr.Data2Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data3Offset { get { return ((uint)hdr.Data3Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data4Offset { get { return ((uint)hdr.Data4Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data5Offset { get { return ((uint)hdr.Data5Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data6Offset { get { return ((uint)hdr.Data6Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data7Offset { get { return ((uint)hdr.Data7Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data8Offset { get { return ((uint)hdr.Data8Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data9Offset { get { return ((uint)hdr.Data9Offset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data10Offset { get { return ((uint)hdr.Data10Offset).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string Text0LoadAddr { get { return ((uint)hdr.Text0LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text1LoadAddr { get { return ((uint)hdr.Text1LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text2LoadAddr { get { return ((uint)hdr.Text2LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text3LoadAddr { get { return ((uint)hdr.Text3LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text4LoadAddr { get { return ((uint)hdr.Text4LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text5LoadAddr { get { return ((uint)hdr.Text5LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text6LoadAddr { get { return ((uint)hdr.Text6LoadAddr).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string Data0LoadAddr { get { return ((uint)hdr.Data0LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data1LoadAddr { get { return ((uint)hdr.Data1LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data2LoadAddr { get { return ((uint)hdr.Data2LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data3LoadAddr { get { return ((uint)hdr.Data3LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data4LoadAddr { get { return ((uint)hdr.Data4LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data5LoadAddr { get { return ((uint)hdr.Data5LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data6LoadAddr { get { return ((uint)hdr.Data6LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data7LoadAddr { get { return ((uint)hdr.Data7LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data8LoadAddr { get { return ((uint)hdr.Data8LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data9LoadAddr { get { return ((uint)hdr.Data9LoadAddr).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data10LoadAddr { get { return ((uint)hdr.Data10LoadAddr).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string Text0Size { get { return ((uint)hdr.Text0Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text1Size { get { return ((uint)hdr.Text1Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text2Size { get { return ((uint)hdr.Text2Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text3Size { get { return ((uint)hdr.Text3Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text4Size { get { return ((uint)hdr.Text4Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text5Size { get { return ((uint)hdr.Text5Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Text6Size { get { return ((uint)hdr.Text6Size).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string Data0Size { get { return ((uint)hdr.Data0Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data1Size { get { return ((uint)hdr.Data1Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data2Size { get { return ((uint)hdr.Data2Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data3Size { get { return ((uint)hdr.Data3Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data4Size { get { return ((uint)hdr.Data4Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data5Size { get { return ((uint)hdr.Data5Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data6Size { get { return ((uint)hdr.Data6Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data7Size { get { return ((uint)hdr.Data7Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data8Size { get { return ((uint)hdr.Data8Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data9Size { get { return ((uint)hdr.Data9Size).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string Data10Size { get { return ((uint)hdr.Data10Size).ToString("X"); } }

        [Category("DOLphin Static Module")]
        public string bssOffset { get { return ((uint)hdr.bssOffset).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string bssSize { get { return ((uint)hdr.bssSize).ToString("X"); } }
        [Category("DOLphin Static Module")]
        public string EntryPoint { get { return ((uint)hdr.entryPoint).ToString("X"); } }
        
        public override bool OnInitialize()
        {
            _name = Path.GetFileName(_origPath);
            hdr = *Header;
            return true;
        }

        public override void OnPopulate()
        {
            for (int i = 0; i < 7; i++)
                if (Header->TextOffset(i) > 0)
                    new DOLCodeNode() { _name = "Text" + i }.Initialize(this, (VoidPtr)Header + Header->TextOffset(i), (int)Header->TextSize(i));

            for (int i = 0; i < 11; i++)
                if (Header->DataOffset(i) > 0)
                    new RawDataNode("Data" + i).Initialize(this, (VoidPtr)Header + Header->DataOffset(i), (int)Header->DataSize(i));
        }
    }

    public unsafe class ModuleNode : ARCEntryNode
    {

    }

    public class DOLCodeNode : ModuleDataNode
    {
        public override bool OnInitialize()
        {
            Init((uint)WorkingUncompressed.Length, true, WorkingUncompressed.Address);
            return false;
        }
    }
}
