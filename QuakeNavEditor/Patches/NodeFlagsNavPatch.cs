using QuakeNavSharp.Navigation;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public class NodeFlagsNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "node_flags";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set flags to {GetFlagText()}";

        public NavigationGraph.NodeFlags Flags { get; set; }



        private string GetFlagText()
        {
            return string.Join(", ", Enum.GetValues<NavigationGraph.NodeFlags>().Where(flag => flag != NavigationGraph.NodeFlags.None));
        }

        public override void Apply(NavigationGraph nav)
        {
            var node = GetNode(nav);
            node.Flags = Flags;
        }

    }
}
