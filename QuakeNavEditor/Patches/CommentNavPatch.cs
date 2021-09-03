using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public class CommentNavPatch : NavPatch
    {
        [JsonIgnore]
        public override string PatchId => "comment";
        [JsonIgnore]
        public override string PatchDescription => $"// {Comment}";

        public string Comment { get; set; }


        public override void Apply(NavigationGraph nav) { }
    }
}
