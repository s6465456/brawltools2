﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;

namespace System.IO
{
    public unsafe class GeckoStream
    {
        public SerialPort _port;
        public Stream _stream { get { return _port.BaseStream; } }
        public GeckoStream(SerialPort port)
        {
            (_port = port).Open();
        }
    }
}