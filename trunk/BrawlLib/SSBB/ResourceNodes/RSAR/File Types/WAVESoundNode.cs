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
        public bool _replaced = false;

        int _encoding;
        int _channels;
        bool _looped;
        int _sampleRate;
        int _loopStart;
        int _numSamples;
        uint _dataOffset;

        [Category("Audio Stream")]
        public WaveEncoding Encoding { get { return (WaveEncoding)_encoding; } }
        [Category("Audio Stream")]
        public int Channels { get { return _channels; } }
        [Category("Audio Stream")]
        public bool IsLooped { get { return _looped; } }
        [Category("Audio Stream")]
        public int SampleRate { get { return _sampleRate; } }
        [Category("Audio Stream")]
        public int LoopStartSample { get { return _loopStart; } }
        [Category("Audio Stream")]
        public int NumSamples { get { return _numSamples; } }
        [Category("Audio Stream")]
        public uint DataOffset { get { return _dataOffset; } }

        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = String.Format("Audio[{0}]", Index);

            _encoding = Header->_format._encoding;
            _channels = Header->_format._channels;
            _looped = Header->_format._looped != 0;
            _sampleRate = Header->_sampleRate;
            _loopStart = Header->_loopStartSample;
            _numSamples = Header->NumSamples;
            _dataOffset = Header->_dataLocation;

            if (!_replaced)
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
            if (fileName.EndsWith(".wav"))
            using (BrstmConverterDialog dlg = new BrstmConverterDialog())
            {
                dlg.RSAR = true;
                dlg.AudioSource = fileName;
                if (dlg.ShowDialog(null) == DialogResult.OK)
                {
                    //Name = Path.GetFileNameWithoutExtension(dlg.AudioSource);
                    _replaced = true;
                    ReplaceRaw(dlg.AudioData);
                    _replaced = false;
                }
            }
            else
                base.Replace(fileName);

            //Get the audio source
            _audioSource = new DataSource(WorkingUncompressed.Address + Header->_dataLocation, (int)(WorkingUncompressed.Length - Header->_dataLocation));

            //Cut out the audio samples from the imported data
            SetSizeInternal((int)Header->_dataLocation);

            stream = null;

            UpdateCurrentControl();
            SignalPropertyChange();
            ((RSARFileNode)_parent._parent).RSARNode.SignalPropertyChange();
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
    }
}
