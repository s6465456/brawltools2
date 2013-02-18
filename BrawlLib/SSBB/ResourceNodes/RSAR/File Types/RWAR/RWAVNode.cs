
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
    public unsafe class RSARFileAudioNode : RSARFileEntryNode, IAudioSource
    {
        public override ResourceType ResourceType { get { return ResourceType.RSARFileAudioEntry; } }
        
        [Browsable(false)]
        public WaveInfo* Info 
        {
            get { return _info; }
            set 
            {
                _info = value;
                _encoding = _info->_format._encoding;
                _channels = _info->_format._channels;
                _looped = _info->_format._looped != 0;
                _sampleRate = _info->_sampleRate;
                _loopStart = _info->LoopSample;
                _numSamples = _info->NumSamples;
            }
        }
        WaveInfo* _info;

        public DataSource _audioSource;

        internal int _encoding;
        internal int _channels;
        internal bool _looped;
        internal int _sampleRate;
        internal int _loopStart;
        internal int _numSamples;

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

        internal IAudioStream stream;
        public IAudioStream CreateStream()
        {
            if (stream != null)
                return stream;
            if (Info->_format._encoding == 2)
                return stream = new ADPCMStream(Info, _audioSource.Address);
            else
                return stream = new PCMStream(Info, _audioSource.Address);
        }

        //public int GetSize(bool RWAR)
        //{
        //    if (RWAR)
        //    {
        //        if (!(this is RWAVNode))
        //        {

        //        }
        //        else
        //        {
        //            return WorkingUncompressed.Length;
        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        //public int CalcSizeAsRWAV()
        //{

        //}

        //public int CalcSizeAsRSARSound()
        //{

        //}

        //public void RebuildAsRWAV(VoidPtr address, int length)
        //{
            
        //}

        //public void RebuildAsRSARSound(VoidPtr address, int length)
        //{
            
        //}
    }

    public unsafe class RWAVNode : RSARFileAudioNode
    {
        internal RWAV* Header { get { return (RWAV*)WorkingUncompressed.Address; } }

        protected override bool OnInitialize()
        {
            if (_name == null)
                _name = String.Format("Audio[{0}]", Index);

            Info = &Header->Info->_info;

            _audioSource = new DataSource(Header->Data->Data, Header->Data->_header._length);

            SetSizeInternal(Header->_header._length);

            return false;
        }

        public override unsafe void Replace(string fileName)
        {
            if (fileName.EndsWith(".wav"))
            using (BrstmConverterDialog dlg = new BrstmConverterDialog())
            {
                dlg.Type = 2;
                dlg.AudioSource = fileName;
                if (dlg.ShowDialog(null) == DialogResult.OK)
                    ReplaceRaw(dlg.AudioData);
            }
            else
                base.Replace(fileName);

            stream = null;

            UpdateCurrentControl();
            SignalPropertyChange();
        }

        public override unsafe void Export(string outPath)
        {
            if (outPath.EndsWith(".wav"))
                WAV.ToFile(CreateStream(), outPath);
            else
                base.Export(outPath);
        }
    }
}