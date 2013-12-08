﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using System.Audio;
using System.Globalization;
using System.Threading;

namespace Ikarus
{
    public static partial class Manager
    {
        static Manager()
        {
            LoadEvents();
            LoadOtherData();
        }

        public static string RootPath { get { return Program.RootPath; } }

        public static string[] _supportedCharacters = Enum.GetNames(typeof(CharName));
        //public static CharName[] _supportedCharacters = new CharName[]
        //{
        //    CharName.Link,
        //    CharName.Mario,
        //    CharName.Pit,
        //    CharName.ZeroSuitSamus
        //};

        //This is the character that will be loaded at startup
        private static CharName _targetChar = CharName.Mario;
        private static CharacterInfo _selected = null;
        private static MovesetFile _cmnMoveset;
        private static RSARNode _rsar;

        private static ARCNode _cmnMovesetArc;
        private static ARCNode _cmnEffectsArc;
        
        public static bool InSubspaceEmissary { get { return _inSSE; } set { _inSSE = value; } }
        private static bool _inSSE = false;

        public static AudioProvider _audioProvider;

        //Stores every file opened by the program
        private static List<ResourceNode> _openedFiles = new List<ResourceNode>();
        public static List<ResourceNode> OpenedFiles { get { return _openedFiles; } }
        private static BindingList<string> _openedFilePaths = new BindingList<string>();
        public static BindingList<string> OpenedFilePaths { get { return _openedFilePaths; } }

        /// <summary>
        /// Attempts to retrieve a resource from the given relative path, whether its been opened or not already.
        /// Returns null if a file could not be found.
        /// </summary>
        public static T TryGet<T>(bool searchDir, bool searchOpened, params string[] relativePaths) where T : ResourceNode
        {
            if (String.IsNullOrEmpty(Manager.RootPath))
                return null;

            foreach (string relativePath in relativePaths)
            {
                string path = Manager.RootPath.Replace("\\", "/") + relativePath;

                int i = -1;
                if (searchOpened)
                    i = Array.FindIndex(Manager.OpenedFilePaths.ToArray(), x => x.Equals(path, StringComparison.OrdinalIgnoreCase));

                if (i >= 0)
                    return Manager.OpenedFiles[i] as T;
                else if (searchDir && File.Exists(path = path.Replace("/", "\\")))
                {
                    T r = NodeFactory.FromFile(null, path) as T;
                    if (r != null)
                        AddFile(r);
                    return r;
                }
            }
            return null;
        }
        public static bool FileExists(bool searchDir, bool searchOpened, params string[] relativePaths)
        {
            if (String.IsNullOrEmpty(Manager.RootPath))
                return false;

            foreach (string relativePath in relativePaths)
            {
                string path = Manager.RootPath.Replace("\\", "/") + relativePath;
                if (searchOpened && Array.FindIndex(Manager.OpenedFilePaths.ToArray(), x => x.Equals(path, StringComparison.OrdinalIgnoreCase)) >= 0)
                    return true;
                else if (searchDir && File.Exists(path = path.Replace("/", "\\")))
                    return true;
            }
            return false;
        }
        public static int GetFileIndex(string relativePath)
        {
            if (String.IsNullOrEmpty(Manager.RootPath))
                return -1;

            string path = Manager.RootPath.Replace("\\", "/") + relativePath;
            return Manager.OpenedFilePaths.IndexOf(path);
            //return Array.FindIndex(Manager.OpenedFilePaths.ToArray(), x => x.Equals(path, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Contains information for the selected character.
        /// </summary>
        public static CharacterInfo SelectedInfo 
        {
            get { return _selected; } 
            private set
            {
                if (value == _selected)
                    return;

                if (_selected != null)
                    _selected.Close();

                _selected = value;

                MainForm.Instance._mainControl.comboCharacters.SelectedIndex = Array.IndexOf(_supportedCharacters, _targetChar.ToString());
            } 
        }
        
        public static CharName TargetCharacter
        {
            get { return _targetChar; }
            set
            {
                if (_targetChar == value)
                    return;

                SelectedInfo = new CharacterInfo(_targetChar = value);

                if (TargetCharacterChanged != null)
                    TargetCharacterChanged(null, EventArgs.Empty);
            }
        }

        internal static void ModelIndexChanged()
        {
            MDL0Node model = null;
            if (SelectedInfo != null)
            {
                SelectedInfo.ModelIndexChanged();
                model = SelectedInfo.SelectedModel;
            }
            MainForm.Instance._mainControl._resetCam = false;
            MainForm.Instance._mainControl.TargetModel = model;
            RunTime.ResetSubactionVariables();
            MainForm.Instance._mainControl.UpdateModel();
        }

        public static TextInfo TextInfo { get { return Thread.CurrentThread.CurrentCulture.TextInfo; } }

        //Nodes specific to the selected character
        public static BRESNode Animations { get { return _selected == null ? null : _selected.Animations; } }
        public static MovesetFile Moveset { get { return _selected == null ? null : _selected.Moveset; } }

        public static unsafe MDL0Node TargetModel { get { return SelectedInfo == null ? null : SelectedInfo.SelectedModel; } }

        public static ARCNode Common5 { get { return _cmnEffectsArc == null ? _cmnEffectsArc = TryGet<ARCNode>(true, true, "/system/common5.pac", "/system/common5_en.pac") : _cmnEffectsArc; } }
        public static ARCNode CommonMovesetArc { get { return _cmnMovesetArc == null ? _cmnMovesetArc = TryGet<ARCNode>(true, true, "/fighter/Fighter.pac") : _cmnMovesetArc; } }
        public static RSARNode SoundArchive 
        {
            get 
            {
                if (_rsar != null)
                    return _rsar;
                else
                    _rsar = TryGet<RSARNode>(true, true, "/sound/smashbros_sound.brsar");
                if (_rsar != null)
                {
                    _audioProvider = AudioProvider.Create(null);
                    _audioProvider.Attach(MainForm.Instance);
                }
                return _rsar;
            }
        }

        public static MovesetFile CommonMoveset
        {
            get
            {
                if (_cmnMoveset != null)
                    return _cmnMoveset;
                if (CommonMovesetArc == null) return null;
                if (CommonMovesetArc.Children.Count == 0) return null;
                ARCEntryNode entry = CommonMovesetArc.Children[0] as ARCEntryNode;
                (_cmnMoveset = new MovesetFile(CharName.None)).Initialize(null, entry.WorkingUncompressed);
                return _cmnMoveset;
            }
        }

        public static RawParamList GetGlobalICs()
        {
            if (CommonMoveset == null)
                return null;
            return _inSSE ? CommonMoveset.DataCommon._globalsseICs : CommonMoveset.DataCommon._globalICs;
        }
        public static RawParamList GetICs()
        {
            if (CommonMoveset == null)
                return null;
            return _inSSE ? CommonMoveset.DataCommon._sseICs : CommonMoveset.DataCommon._ICs;
        }
        public static AttributeList GetAttributes()
        {
            if (Moveset == null || Moveset.Data == null)
                return null;
            return _inSSE ? Moveset.Data._sseAttributes : Moveset.Data._attributes;
        }

        #region File Management
        public static void AddFile(ResourceNode r)
        {
            string path = r._origPath.Substring(Program.RootPath.Length).Replace('\\', '/');
            if (!_openedFilePaths.Contains(path))
            {
                _openedFiles.Add(r);
                _openedFilePaths.Add(path);

                RunTime.Log("Loaded " + path);
            }
        }
        public static void RemoveFile(ResourceNode r)
        {
            if (r == null)
                return;

            string path = r._origPath.Substring(Program.RootPath.Length).Replace('\\', '/');
            if (_openedFilePaths.Contains(path))
            {
                _openedFiles.Remove(r);
                _openedFilePaths.Remove(path);
                r.Dispose();

                RunTime.Log("Closed " + path);
            }
        }
        internal static void RemoveFile(int x)
        {
            if (x >= 0 && x < _openedFilePaths.Count)
            {
                _openedFiles[x].Dispose();
                RunTime.Log("Closed " + _openedFilePaths[x]);

                _openedFiles.RemoveAt(x);
                _openedFilePaths.RemoveAt(x);
            }
        }
        public static ResourceNode GetFile(int i)
        {
            if (i >= 0 && i < _openedFiles.Count)
                return _openedFiles[i];
            return null;
        }
        #endregion

        internal static void CloseRoot()
        {
            SelectedInfo = null;

            if (RootChanged != null)
                RootChanged(null, EventArgs.Empty);
        }

        public static void OpenRoot(string path)
        {
            SelectedInfo = new CharacterInfo(TargetCharacter);

            if (RootChanged != null)
                RootChanged(null, EventArgs.Empty);
        }

        public static event EventHandler RootChanged;
        public static event EventHandler TargetCharacterChanged;

        public static EventInformation GetEventInfo(long id)
        {
            if (Events.ContainsKey(id))
                return Events[id];

            return new EventInformation(id, id.ToString("X"), "No Description Available.", null, null);
        }
    }
}
