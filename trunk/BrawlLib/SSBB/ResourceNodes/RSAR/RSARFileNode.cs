using System;
using BrawlLib.SSBBTypes;
using System.IO;
using BrawlLib.IO;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RSARFileNode : RSAREntryNode
    {
        internal INFOFileHeader* Header { get { return (INFOFileHeader*)WorkingUncompressed.Address; } }
        internal DataSource _audioSource;

        public List<RSARGroupNode> _groups = new List<RSARGroupNode>();
        [Browsable(false)]
        public RSARGroupNode[] Groups { get { return _groups.ToArray(); } }

        public string[] GroupRefs { get { return _groups.Select(x => x.TreePath).ToArray(); } }

        public List<string> _references = new List<string>();
        public string[] EntryRefs { get { return _references.ToArray(); } }

        public List<RSARSoundNode> _rsarSoundEntries = new List<RSARSoundNode>();
        [Browsable(false)]
        public RSARSoundNode[] Sounds { get { return _rsarSoundEntries.ToArray(); } }
        public void AddSoundRef(RSARSoundNode n)
        {
            if (!_rsarSoundEntries.Contains(n))
            {
                _rsarSoundEntries.Add(n);
                _references.Add(n.TreePath);
            }
        }
        public void RemoveSoundRef(RSARSoundNode n)
        {
            if (_rsarSoundEntries.Contains(n))
            {
                _rsarSoundEntries.Remove(n);
                _references.Remove(n.TreePath);
            }
        }

        internal string _extPath;
        internal int _fileIndex;
        internal LabelItem[] _labels;

        public uint _extFileSize = 0;

        [Category("File Node"), Browsable(true)]
        public int FileNodeIndex { get { return _fileIndex; } }
        [Browsable(true)]
        public string ExtPath { get { return _extPath; } set { _extPath = value; SignalPropertyChange(); } }
        [Browsable(true)]
        public string FullExtPath
        {
            get { return ExtPath == null ? null : RootNode._origPath.Substring(0, RootNode._origPath.LastIndexOf('\\')) + "\\" + ExtPath.Replace('/', '\\'); }
            set { _extPath = value.Substring(RootNode._origPath.Substring(0, RootNode._origPath.LastIndexOf('\\')).Length + 1).Replace('\\', '/'); SignalPropertyChange(); } 
        }
        [Browsable(true), TypeConverter(typeof(ExpandableObjectCustomConverter))]
        public FileInfo ExternalFileInfo
        {
            get { return FullExtPath == null ? null : new FileInfo(FullExtPath); }
        }

        [Category("Data"), Browsable(true)]
        public string InfoHeaderOffset { get { if (RSARNode != null) return ((uint)(_infoHdr - (VoidPtr)RSARNode.Header)).ToString("X"); else return null; } }
        public VoidPtr _infoHdr;

        [Category("Data"), Browsable(true)]
        public string AudioLength { get { return _audioSource.Length.ToString("X"); } }
        [Category("Data"), Browsable(true)]
        public string AudioOffset { get { if (RSARNode != null) return ((uint)(_audioSource.Address - (VoidPtr)RSARNode.Header)).ToString("X"); else return null; } }
        [Category("Data"), Browsable(true)]
        public string DataLength { get { return WorkingUncompressed.Length.ToString("X"); } }

        protected virtual void GetStrings(LabelBuilder builder) { }

        public void GetExtSize()
        {
            if (ExternalFileInfo.Exists)
                _extFileSize = (uint)ExternalFileInfo.Length;
        }

        protected override bool OnInitialize()
        {
            _groups = new List<RSARGroupNode>();
            if (_name == null)
                if (_parent == null)
                    _name = Path.GetFileNameWithoutExtension(_origPath);
                else
                    _name = String.Format("[{0}] {1}", _fileIndex, ResourceType.ToString());
            return false;
        }

        public VoidPtr _rebuildAudioAddr = null;
        public int _headerLen = 0, _audioLen = 0;

        public override unsafe void Export(string outPath)
        {
            LabelBuilder labl;
            int lablLen, size;
            VoidPtr addr;

            if (_audioSource != DataSource.Empty)
            {
                //Get strings
                labl = new LabelBuilder();
                GetStrings(labl);
                lablLen = (labl.Count == 0) ? 0 : labl.GetSize();
                size = WorkingUncompressed.Length + lablLen + _audioSource.Length;

                using (FileStream stream = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.SetLength(size);
                    using (FileMap map = FileMap.FromStreamInternal(stream, FileMapProtect.ReadWrite, 0, size))
                    {
                        addr = map.Address;

                        //Write header
                        Memory.Move(addr, WorkingUncompressed.Address, (uint)WorkingUncompressed.Length);

                        //Write strings
                        addr += WorkingUncompressed.Length;
                        if (lablLen > 0)
                            labl.Write(addr);
                        addr += lablLen;

                        //Write data
                        Memory.Move(addr, _audioSource.Address, (uint)_audioSource.Length);
                    }
                }
            }
            else
                base.Export(outPath);
        }
    }
}
