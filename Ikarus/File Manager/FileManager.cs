using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib.SSBBTypes;
using System.Audio;

namespace Ikarus
{
    public static partial class FileManager
    {
        static FileManager()
        {
            LoadEventDictionary();
            LoadOtherData();
        }

        public static CharName[] _supportedCharacters = new CharName[]
        {
            CharName.Link,
            CharName.Mario,
            CharName.Pit,
            CharName.ZeroSuitSamus
        };

        public static CharacterInfo[] _characters = new CharacterInfo[46];
        public static CharacterInfo GetInfo(CharName i) { return (int)i >= 0 && (int)i < 46 ? _characters[(int)i] : null; }
        public static void SetInfo(CharName i, CharacterInfo value) { if ((int)i >= 0 && (int)i < 46) _characters[(int)i] = value; }

        //Information for the selected character
        private static CharacterInfo _selected = null;
        public static CharacterInfo SelectedInfo 
        {
            get { return _selected; } 
            set 
            {
                if (value == _selected)
                    return;

                if (_selected != null)
                    _selected.UnloadFiles();

                if ((_selected = GetInfo(_targetChar)) != null)
                    _selected.LoadFiles();
            } 
        }
        private static CharName _targetChar = CharName.ZeroSuitSamus;
        public static CharName TargetCharacter
        {
            get { return _targetChar; }
            set
            {
                SelectedInfo = GetInfo(_targetChar = value);

                if (TargetCharacterChanged != null)
                    TargetCharacterChanged(null, EventArgs.Empty);
            }
        }

        //Nodes specific to the selected character
        public static BRESNode Animations { get { return _selected == null ? null : _selected.FileCollection.Animations; } }
        public static MoveDefNode Moveset { get { return _selected == null ? null : _selected.FileCollection.Moveset; } }

        //Nodes used by all characters
        private static MoveDefNode _cmnMoveset;
        private static ARCNode _cmnEffects;
        private static RSARNode _rsar;
        public static MoveDefNode CommonMoveset { get { return _cmnMoveset; } }
        public static ARCNode Common5 { get { return _cmnEffects; } }
        public static RSARNode SoundArchive { get { return _rsar; } }

        public static AudioProvider _audioProvider;

        //Stores every file opened by the program
        private static List<ResourceNode> _openedFiles = new List<ResourceNode>();
        public static List<ResourceNode> OpenedFiles { get { return _openedFiles; } }
        private static BindingList<string> _openedFilePaths = new BindingList<string>();
        public static BindingList<string> OpenedFilePaths { get { return _openedFilePaths; } }
        
        public static void AddFile(ResourceNode r)
        {
            string path = r._origPath.Substring(Program.RootPath.Length).Replace('\\', '/');
            if (!_openedFilePaths.Contains(path))
            {
                _openedFiles.Add(r);
                _openedFilePaths.Add(path);
            }
        }

        public static void RemoveFile(ResourceNode r)
        {
            string path = r._origPath.Substring(Program.RootPath.Length).Replace('\\', '/');
            if (_openedFilePaths.Contains(path))
            {
                _openedFiles.Remove(r);
                _openedFilePaths.Remove(path);
            }
        }

        public static ResourceNode GetFile(int i)
        {
            if (i >= 0 && i < _openedFiles.Count)
                return _openedFiles[i];
            return null;
        }

        public static void OpenRoot(string path)
        {
            //Load characters
            string fighter = path + "\\fighter";
            if (Directory.Exists(fighter))
                foreach (CharName n in _supportedCharacters)
                {
                    string s = ((CharFolder)(int)n).ToString();
                    if (Directory.Exists(fighter + "\\" + s))
                        OpenFighter(fighter + "\\" + ((CharFolder)(int)n).ToString());
                }

            //Load SFX and music
            string sound = path + "\\sound";
            if (Directory.Exists(sound))
            {
                string rsar = sound + "\\smashbros_sound.brsar";
                if (File.Exists(rsar))
                {
                    _rsar = NodeFactory.FromFile(null, rsar) as RSARNode;
                    AddFile(_rsar);
                    _audioProvider = AudioProvider.Create(null);
                    _audioProvider.Attach(MainForm.Instance);
                }
            }

            SelectedInfo = GetInfo(TargetCharacter);

            if (RootChanged != null)
                RootChanged(null, EventArgs.Empty);
        }

        public static void OpenFighter(string path)
        {
            if (String.IsNullOrEmpty(path))
                return;

            string name = path.Substring(path.LastIndexOf('\\') + 1);
            if (String.Equals(name, path))
                return;

            CharFolder c;
            if (!Enum.TryParse(name, out c))
                return;

            _characters[(int)c] = new CharacterInfo(path);
        }

        public static event EventHandler RootChanged;
        public static event EventHandler TargetCharacterChanged;
    }
}
