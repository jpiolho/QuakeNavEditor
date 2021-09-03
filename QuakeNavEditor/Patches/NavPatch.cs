using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public abstract class NavPatch
    {
        [JsonIgnore]
        public abstract string PatchId { get; }
        [JsonIgnore]
        public abstract string PatchDescription { get; }

        public abstract void Apply(NavigationGraph nav);
    }
}
