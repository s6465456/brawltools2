﻿using System;
using BrawlLib.SSBBTypes;
using System.Audio;
using BrawlLib.Wii.Audio;
using System.IO;
using BrawlLib.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARFileEntryNode : ResourceNode
    {
        internal RSARNode RSARNode
        {
            get
            {
                ResourceNode n = this;
                while (((n = n.Parent) != null) && !(n is RSARNode)) ;
                return n as RSARNode;
            }
        }

        internal VoidPtr _offset;
    }

    public unsafe class WAVESoundNode : RSARFileAudioNode
    {
        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = String.Format("Audio[{0}]", Index);
            
            Info = *(WaveInfo*)WorkingUncompressed.Address;

            if (!_replaced)
                SetSizeInternal((WaveInfo.Size + Info._format._channels * (4 + ChannelInfo.Size + (Info._format._encoding == 2 ? ADPCMInfo.Size : 0))));

            return false;
        }

        public void GetAudio()
        {
            uint _audioLen;
            VoidPtr _dataAddr = ((RSARFileNode)Parent._parent)._audioSource.Address + Info._dataLocation;
            if (Index != Parent.Children.Count - 1)
                _audioLen = ((WAVESoundNode)Parent.Children[Index + 1]).Info._dataLocation - Info._dataLocation;
            else
                _audioLen = (uint)((RSARFileNode)Parent._parent)._audioSource.Length - Info._dataLocation;

            Init(_dataAddr, (int)_audioLen, (WaveInfo*)WorkingUncompressed.Address);
        }

        public override unsafe void Replace(string fileName)
        {
            if (fileName.EndsWith(".wav"))
            using (BrstmConverterDialog dlg = new BrstmConverterDialog())
            {
                dlg.Type = 1;
                dlg.AudioSource = fileName;
                if (dlg.ShowDialog(null) == DialogResult.OK)
                    ReplaceRaw(dlg.AudioData);
            }
            else
                base.Replace(fileName);

            Init(WorkingUncompressed.Address + Info._dataLocation, (int)(WorkingUncompressed.Length - Info._dataLocation), (WaveInfo*)WorkingUncompressed.Address);

            //Cut out the audio samples from the imported data
            SetSizeInternal((int)Info._dataLocation);

            UpdateCurrentControl();
            SignalPropertyChange();
            Parent.Parent.SignalPropertyChange();
            if (RSARNode != null)
                RSARNode.SignalPropertyChange();
        }

        public override unsafe void Export(string outPath)
        {
            if (outPath.EndsWith(".wav"))
                WAV.ToFile(CreateStreams()[0], outPath);
            else
            {
                if (_audioSource != DataSource.Empty)
                {
                    int size = WorkingUncompressed.Length + _audioSource.Length;
                    using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                    {
                        stream.SetLength(size);
                        using (FileMap map = FileMap.FromStreamInternal(stream, FileMapProtect.ReadWrite, 0, size))
                        {
                            VoidPtr addr = map.Address;

                            //Write header
                            Memory.Move(addr, WorkingUncompressed.Address, (uint)WorkingUncompressed.Length);

                            //Set the offset to the audio samples (_dataLocation)
                            *(bint*)(addr + 0x14) = WorkingUncompressed.Length;

                            addr += WorkingUncompressed.Length;

                            //Append audio samples to the end
                            Memory.Move(addr, _audioSource.Address, (uint)_audioSource.Length);
                        }
                    }
                }
                else
                    base.Export(outPath);
            }
        }
    }
}
