using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public class NodeRadiusNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "node_radius";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set radius to {Radius}";

        public int Radius { get; set; }


        public override void Apply(NavigationGraph nav)
        {
            var node = GetNode(nav);
            node.Radius = (ushort)Radius;
        }

    }
}
