using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using BrawlLib.SSBBTypes;

namespace Ikarus
{
    /// <summary>
    /// Stores files when editing a character.
    /// </summary>
    public class CharInfoFiles
    {
        public ARCNode[] _models = new ARCNode[12];
        public ARCNode _movesetArc;
        public ARCNode _motionEtcArc;
        public ARCNode _entry;
        public ARCNode _final;

        public BRESNode _animations = null;
        public MoveDefNode _moveset = null;

        public bool _parametersChanged = false;
        public Dictionary<string, SectionParamInfo> _parameters = null;
        public Dictionary<int, Dictionary<ARCFileType, List<ARCEntryNode>>> _characterEtcFiles;
        public Dictionary<int, Dictionary<ARCFileType, List<ARCEntryNode>>> _characterFiles;
        
        int _charId;

        public void Load(CharInfoFilePaths paths, int id)
        {
            _charId = id;

            if (!String.IsNullOrEmpty(paths._movesetArc) && _movesetArc == null)
                FileManager.AddFile(_movesetArc = NodeFactory.FromFile(null, paths._movesetArc) as ARCNode);

            if (!String.IsNullOrEmpty(paths._motionEtcArc) && _motionEtcArc == null)
                FileManager.AddFile(_motionEtcArc = NodeFactory.FromFile(null, paths._motionEtcArc) as ARCNode);

            if (!String.IsNullOrEmpty(paths._entry) && _entry == null)
                FileManager.AddFile(_entry = NodeFactory.FromFile(null, paths._entry) as ARCNode);

            if (!String.IsNullOrEmpty(paths._final) && _final == null)
                FileManager.AddFile(_final = NodeFactory.FromFile(null, paths._final) as ARCNode);
            
            for (int i = 0; i < 12; i++)
                if (!String.IsNullOrEmpty(paths._models[i]) && _models[i] == null)
                    FileManager.AddFile(_models[i] = NodeFactory.FromFile(null, paths._models[i]) as ARCNode);

            if (_models[0] != null)
            {
                _characterFiles = new Dictionary<int, Dictionary<ARCFileType, List<ARCEntryNode>>>();
                ARCNode etc = _models[0];
                foreach (ARCEntryNode e in etc.Children)
                {
                    int grp = e.GroupID;

                    if (!_characterFiles.ContainsKey(grp))
                        _characterFiles[grp] = new Dictionary<ARCFileType, List<ARCEntryNode>>();

                    ARCFileType type = e.FileType;

                    if (!_characterFiles[grp].ContainsKey(type))
                        _characterFiles[grp].Add(type, new List<ARCEntryNode>());

                    _characterFiles[grp][type].Add(e);
                }
            }

            if (_motionEtcArc != null)
            {
                _characterEtcFiles = new Dictionary<int, Dictionary<ARCFileType, List<ARCEntryNode>>>();
                ARCNode etc = _motionEtcArc.Children[0] as ARCNode;
                foreach (ARCEntryNode e in etc.Children)
                {
                    int grp = e.GroupID;

                    if (!_characterEtcFiles.ContainsKey(grp))
                        _characterEtcFiles[grp] = new Dictionary<ARCFileType, List<ARCEntryNode>>();

                    ARCFileType type = e.FileType;

                    if (!_characterEtcFiles[grp].ContainsKey(type))
                        _characterEtcFiles[grp].Add(type, new List<ARCEntryNode>());

                    _characterEtcFiles[grp][type].Add(e);
                }
            }

            LoadParameters();
        }

        public void Unload()
        {
            if (_movesetArc != null && !_movesetArc.IsDirty)
            {
                FileManager.RemoveFile(_movesetArc);
                _movesetArc = null;
            }

            if (_motionEtcArc != null && !_motionEtcArc.IsDirty)
            {
                FileManager.RemoveFile(_motionEtcArc);
                _motionEtcArc = null;

                _characterEtcFiles.Clear();
            }

            if (_entry != null && !_entry.IsDirty)
            {
                FileManager.RemoveFile(_entry);
                _entry = null;
            }

            if (_final != null && !_final.IsDirty)
            {
                FileManager.RemoveFile(_final);
                _final = null;
            }

            for (int i = 0; i < 12; i++)
                if (_models[i] != null && !_models[i].IsDirty)
                {
                    FileManager.RemoveFile(_models[i]);
                    _models[i] = null;
                }

            if (_parametersChanged)
                SaveParameters();
        }

        private int _selectedModelIndex = 0;
        public int SelectedModelIndex 
        { 
            get { return _selectedModelIndex; } 
            set
            {
                _selectedModelIndex = value;
                if (_moveset != null)
                    _moveset._model = _models[_selectedModelIndex].Children[0].Children[0].Children[0] as MDL0Node;
            }
        }
        public MDL0Node SelectedModel { get { return GetModel(_selectedModelIndex); } }
        public MDL0Node GetModel(int index) { return _models[index].Children[0].Children[0].Children[0] as MDL0Node; }
        public BRESNode Animations { get { if (_animations != null) return _animations; return _motionEtcArc == null || _motionEtcArc.Children.Count < 2 || _motionEtcArc.Children[1] == null ? null : _animations = _motionEtcArc.Children[1].Children[0] as BRESNode; } }
        public MoveDefNode Moveset
        {
            get
            {
                if (_moveset != null)
                {
                    _moveset._model = _models[_selectedModelIndex].Children[0].Children[0].Children[0] as MDL0Node;
                    return _moveset;
                }
                if (_movesetArc == null) return null;
                if (_movesetArc.Children.Count == 0) return null;
                ARCEntryNode entry = _movesetArc.Children[0] as ARCEntryNode;
                (_moveset = new MoveDefNode((CharName)_charId) { _name = "Fit" + ((CharFolder)_charId).ToString() }).Initialize(null, entry.WorkingUncompressed.Address, entry.WorkingUncompressed.Length);
                if (_moveset != null)
                {
                    if (_models[_selectedModelIndex] != null)
                        _moveset._model = _models[_selectedModelIndex].Children[0].Children[0].Children[0] as MDL0Node;
                    _moveset.Populate(0);
                }
                return _moveset;
            }
        }

        public void LoadParameters()
        {
            _parameters = new Dictionary<string, SectionParamInfo>();
            string loc = Application.StartupPath + "/MovesetData/CharSpecific/Fit" + ((CharFolder)(int)_charId).ToString() + ".txt";
            string n = "", attrName = "";
            if (File.Exists(loc))
                using (StreamReader sr = new StreamReader(loc))
                    while (!sr.EndOfStream)
                    {
                        n = sr.ReadLine();
                        SectionParamInfo info = new SectionParamInfo();
                        info._newName = sr.ReadLine();
                        info._attributes = new List<AttributeInfo>();
                        while (true && !sr.EndOfStream)
                        {
                            if (String.IsNullOrEmpty(attrName = sr.ReadLine()))
                                break;
                            else
                            {
                                AttributeInfo i = new AttributeInfo();
                                i._name = attrName;
                                i._description = sr.ReadLine();
                                i._type = int.Parse(sr.ReadLine());
                                info._attributes.Add(i);
                                sr.ReadLine();
                            }
                        }
                        if (!_parameters.ContainsKey(n))
                            _parameters.Add(n, info);
                    }
        }

        public void SaveParameters()
        {
            string Params = Application.StartupPath + "/MovesetData/CharSpecific/fit" + ((CharFolder)(int)_charId).ToString() + ".txt";

            if (!Directory.Exists(Application.StartupPath + "/MovesetData/CharSpecific"))
                Directory.CreateDirectory(Application.StartupPath + "/MovesetData/CharSpecific");

            bool go = true;
            if (File.Exists(Params))
                if (MessageBox.Show("Do you want to overwrite Fit" + ((CharFolder)_charId).ToString() + ".txt in the MovesetData/CharSpecific folder?", "Overwrite Permission", MessageBoxButtons.YesNo) == DialogResult.No)
                    go = false;
            if (go)
                using (StreamWriter file = new StreamWriter(Params))
                {
                    foreach (var i in _parameters)
                    {
                        file.WriteLine(i.Key);
                        file.WriteLine(i.Value._newName);
                        foreach (AttributeInfo a in i.Value._attributes)
                        {
                            file.WriteLine(a._name);
                            file.WriteLine(a._description);
                            file.WriteLine(a._type);
                            file.WriteLine();
                        }
                        file.WriteLine();
                    }
                }
        }
    }

    /// <summary>
    /// Stores paths to character files to be loaded when in use.
    /// Loading files only when we need to read them saves memory.
    /// </summary>
    public class CharInfoFilePaths
    {
        public string[] _models = new string[12];
        public string _movesetArc;
        public string _motionEtcArc;
        public string _entry;
        public string _final;

        public CharInfoFilePaths(string charFolder, CharFolder folder)
        {
            string dest = "Fit" + folder.ToString();
            string[] files = Directory.GetFiles(charFolder);
            List<string> opened = new List<string>();
            foreach (string s in files)
            {
                string name = Path.GetFileNameWithoutExtension(s);

                if (opened.Contains(name))
                    continue;

                string ext = Path.GetExtension(s);
                bool pac = String.Equals(ext, ".pac", StringComparison.OrdinalIgnoreCase);
                bool pcs = String.Equals(ext, ".pcs", StringComparison.OrdinalIgnoreCase);

                if (String.Equals(name, dest, StringComparison.OrdinalIgnoreCase) && pac)
                {
                    //Found the moveset file
                    _movesetArc = s;
                    opened.Add(name);
                    continue;
                }
                else if (String.Equals(name, dest + "MotionEtc", StringComparison.OrdinalIgnoreCase) && pac)
                {
                    //Found the animations and effects
                    _motionEtcArc = s;
                    opened.Add(name);
                    continue;
                }
                else if (String.Equals(name, dest + "Entry", StringComparison.OrdinalIgnoreCase) && pac)
                {
                    //Found the entry file
                    _entry = s;
                    opened.Add(name);
                    continue;
                }
                else if (String.Equals(name, dest + "Final", StringComparison.OrdinalIgnoreCase) && pac)
                {
                    //Found the final smash file
                    _final = s;
                    opened.Add(name);
                    continue;
                }
                else
                    for (int i = 0; i < 12; i++)
                        if (String.Equals(name, dest + i.ToString().PadLeft(2, '0'), StringComparison.OrdinalIgnoreCase) && (pac || pcs))
                        {
                            //Found a character color
                            _models[i] = s;
                            opened.Add(name);
                            break;
                        }
            }
        }
    }

    public class CharacterInfo
    {
        private int _charId;
        public CharName Name { get { return (CharName)_charId; } set { _charId = (int)value; } }
        public CharFolder Folder { get { return (CharFolder)_charId; } set { _charId = (int)value; } }
        
        public CharInfoFiles FileCollection { get { return _files; } }
        private CharInfoFiles _files = new CharInfoFiles();
        private CharInfoFilePaths _paths;
        
        public CharacterInfo(string path)
        {
            _charId = (int)Enum.Parse(typeof(CharFolder), path.Substring(path.LastIndexOf('\\') + 1), true);
            _paths = new CharInfoFilePaths(path, Folder);
        }

        public override string ToString() { return Name.ToString(); }

        public void LoadFiles() { _files.Load(_paths, _charId); }
        public void UnloadFiles() { _files.Unload(); }
    }

    public enum CharFolder
    {
        Captain = 0,
        Dedede,
        Diddy,
        Donkey,
        Falco,
        Fox = 5,
        Gamewatch,
        Ganon,
        GKoopa,
        Ike,
        Kirby = 10,
        Koopa,
        Link,
        Lucario,
        Lucas,
        Luigi = 15,
        Mario,
        Marth,
        Metaknight,
        Ness,
        Peach = 20,
        Pikachu,
        Pikmin,
        Pit,
        PokeFushigisou,
        PokeLizardon = 25,
        PokeTrainer,
        PokeZenigame,
        Popo,
        Purin,
        Robot = 30,
        Samus,
        Sheik,
        Snake,
        Sonic,
        SZerosuit = 35,
        ToonLink,
        Wario,
        WarioMan,
        Wolf,
        Yoshi = 40,
        ZakoBall,
        ZakoBoy,
        ZakoChild,
        ZakoGirl,
        Zelda = 45
    }
    public enum CharName
    {
        None = -1,
        CaptainFalcon = 0,
        KingDedede,
        DiddyKong,
        DonkeyKong,
        Falco,
        Fox = 5,
        MrGameNWatch,
        Ganondorf,
        GigaBowser,
        Ike,
        Kirby = 10,
        Bowser,
        Link,
        Lucario,
        Lucas,
        Luigi = 15,
        Mario,
        Marth,
        Metaknight,
        Ness,
        Peach = 20,
        Pikachu,
        Pikmin,
        Pit,
        Ivysaur,
        Charizard = 25,
        PokemonTrainer,
        Squirtle,
        Popo,
        Jigglypuff,
        ROB = 30,
        Samus,
        Sheik,
        Snake,
        Sonic,
        ZeroSuitSamus = 35,
        ToonLink,
        Wario,
        WarioMan,
        Wolf,
        Yoshi = 40,
        GreenAlloy,
        RedAlloy,
        YellowAlloy,
        BlueAlloy,
        Zelda = 45,
    }
}
