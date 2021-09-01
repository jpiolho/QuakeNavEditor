using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public class NodeRadiusNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "node_radius";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set radius to {Radius}";

        public int Radius { get; set; }


        public override void Apply(NavFile nav)
        {
            var node = GetNode(nav);
            node.Radius = Radius;
        }

    }
}
