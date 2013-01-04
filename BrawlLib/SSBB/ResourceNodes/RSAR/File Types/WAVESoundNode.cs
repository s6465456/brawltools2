using System;
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
        internal VoidPtr _offset;
    }

    public unsafe class WAVESoundNode : RSARFileEntryNode, IAudioSource
    {
        [Browsable(false)]
        public WaveInfo* Header { get { return (WaveInfo*)WorkingUncompressed.Address; } }
        public override ResourceType ResourceType { get { return ResourceType.RWSDWaveEntry; } }

        public DataSource _audioSource;

        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = String.Format("Audio[{0}]", Index);

            SetSizeInternal((WaveInfo.Size + Header->_format._channels * (4 + ChannelInfo.Size + (Header->_format._encoding == 2 ? ADPCMInfo.Size : 0))));

            return false;
        }

        public void GetAudio()
        {
            uint _audioLen;
            VoidPtr _dataAddr = ((RSARFileNode)_parent._parent)._audioSource.Address + Header->_dataLocation;
            if (Index != _parent.Children.Count - 1)
                _audioLen = ((WAVESoundNode)_parent.Children[Index + 1]).Header->_dataLocation - Header->_dataLocation;
            else
                _audioLen = (uint)((RSARFileNode)_parent._parent)._audioSource.Length - Header->_dataLocation;

            _audioSource = new DataSource(_dataAddr, (int)_audioLen);
        }

        IAudioStream stream;
        public IAudioStream CreateStream()
        {
            if (stream != null)
                return stream;
            if (Header->_format._encoding == 2)
                return stream = new ADPCMStream(Header, _audioSource.Address);
            else
                return stream = new PCMStream(Header, _audioSource.Address);
        }

        public override unsafe void Replace(string fileName)
        {
            //IAudioStream s = null;
            if (fileName.EndsWith(".wav"))
            using (BrstmConverterDialog dlg = new BrstmConverterDialog())
            {
                dlg.RSAR = true;
                dlg.AudioSource = fileName;
                if (dlg.ShowDialog(null) == DialogResult.OK)
                {
                    //Name = Path.GetFileNameWithoutExtension(dlg.AudioSource);
                    ReplaceRaw(dlg.AudioData);
                }
            }

            //if (fileName.EndsWith(".wav"))
            //    s = WAV.FromFile(fileName);
            else
                base.Replace(fileName);

            //if (s != null)
            //    try { ReplaceRaw(RSARWaveConverter.Encode(s, null)); }
            //    finally { s.Dispose(); }

            //Get the audio source
            _audioSource = new DataSource(WorkingUncompressed.Address + Header->_dataLocation, (int)(WorkingUncompressed.Length - Header->_dataLocation));

            //Cut out the audio samples from the imported data
            SetSizeInternal(WorkingUncompressed.Length - _audioSource.Length);

            stream = null;
        }

        public override unsafe void Export(string outPath)
        {
            if (outPath.EndsWith(".wav"))
                WAV.ToFile(CreateStream(), outPath);
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

        protected override int OnCalculateSize(bool force)
        {
            return base.OnCalculateSize(force);
        }

        protected internal override void OnRebuild(VoidPtr address, int length, bool force)
        {
            base.OnRebuild(address, length, force);
        }
    }
}
