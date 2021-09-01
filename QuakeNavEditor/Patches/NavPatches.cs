using QuakeNavEditor.Nav;
using QuakeNavEditor.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public class NavPatches
    {
        private static JsonSerializerOptions _jsonSerializerOptions;
        private static Dictionary<string, Type> _patchTypes;

        static NavPatches()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new Vector3JsonConverter());

            _patchTypes = new Dictionary<string, Type>();
            foreach(var type in typeof(NavPatch).Assembly.GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(NavPatch))))
            {
                var patch = (NavPatch)Activator.CreateInstance(type);
                _patchTypes[patch.PatchId] = type;
            }

        }

        public event EventHandler OnPatchesChanged;


        private List<NavPatch> _navPatches = new List<NavPatch>();
        public IReadOnlyList<NavPatch> Patches => _navPatches.AsReadOnly();


        public void AddPatches(params NavPatch[] patches) => AddPatches(patches.AsEnumerable());
        public void AddPatches(IEnumerable<NavPatch> patches)
        {
            _navPatches.AddRange(patches);
            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void InsertPatches(int index, params NavPatch[] patches) => InsertPatches(index,patches.AsEnumerable());
        public void InsertPatches(int index, IEnumerable<NavPatch> patches)
        {
            _navPatches.InsertRange(index, patches);
            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Move(int from,int to)
        {
            var patch = _navPatches[to];
            _navPatches[to] = _navPatches[from];
            _navPatches[from] = patch;

            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }


        public void RemoveAt(int index)
        {
            _navPatches.RemoveAt(index);
            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            _navPatches.Clear();
            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Apply(NavFile nav)
        {
            foreach(var patch in _navPatches)
                patch.Apply(nav);
        }

        public void SaveToStream(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("NAV2PATCH");
                writer.WriteLine("1"); // Version
            
                foreach (var patch in _navPatches)
                    writer.WriteLine($"{patch.PatchId}|{JsonSerializer.Serialize(patch,patch.GetType(), _jsonSerializerOptions)}");
            }
        }

        public void LoadFromStream(Stream stream)
        {
            _navPatches.Clear();

            using(var reader = new StreamReader(stream))
            {
                var magicNumber = reader.ReadLine();

                if (magicNumber != "NAV2PATCH")
                    throw new InvalidDataException($"File is not a navigation patch");

                var version = reader.ReadLine();
                if (version != "1")
                    throw new InvalidDataException($"Unsupported navigation patch version {version}");

                int lineNumber = 1;
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var idx = line.IndexOf('|');

                    if (idx == -1)
                        throw new InvalidDataException($"Corrupted patch at line {lineNumber}");

                    var id = line.Substring(0, idx);
                    var json = line.Substring(idx + 1);

                    if (!_patchTypes.TryGetValue(id, out var patchType))
                        throw new InvalidDataException($"Unknown patch id '{id}' at line {lineNumber}");

                    _navPatches.Add((NavPatch)JsonSerializer.Deserialize(json, patchType, _jsonSerializerOptions));

                    lineNumber++;
                }
            }

            OnPatchesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
