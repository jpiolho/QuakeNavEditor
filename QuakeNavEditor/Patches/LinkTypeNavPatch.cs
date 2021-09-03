using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches.Link
{
    public class LinkTypeNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_type";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set type to {Type}";

        public NavigationGraph.LinkType Type { get; set; }


        public override void Apply(NavigationGraph nav)
        {
            var link = GetLink(nav);
            link.Type = Type;
        }

    }
}
