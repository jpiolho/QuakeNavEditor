using QuakeNavEditor.Extensions;
using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public abstract class LinkNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} link to node ({DestinationNode.X.ToString(CultureInfo.InvariantCulture)}, {DestinationNode.Y.ToString(CultureInfo.InvariantCulture)}, {DestinationNode.Z.ToString(CultureInfo.InvariantCulture)})";

        public Vector3 DestinationNode { get; set; }


        protected NavLink GetLink(NavFile nav)
        {
            var node = GetNode(nav);

            var link = node.OutgoingLinks.FirstOrDefault(link => Vector3.Distance(nav.Nodes[link.Destination].Position, DestinationNode) <= 1);

            if (link == null)
                throw new NavPatchException($"Could not find link from ({Node.ToReadableString(", ")}) towards destination node ({DestinationNode.ToReadableString(", ")})");

            return link;
        }
    }
}
