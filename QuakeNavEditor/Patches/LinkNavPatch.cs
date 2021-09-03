using QuakeNavEditor.Extensions;
using QuakeNavSharp.Navigation;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public abstract class LinkNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} link to node ({DestinationNode.X.ToString(CultureInfo.InvariantCulture)}, {DestinationNode.Y.ToString(CultureInfo.InvariantCulture)}, {DestinationNode.Z.ToString(CultureInfo.InvariantCulture)})";

        public Vector3 DestinationNode { get; set; }


        protected NavigationGraph.Link GetLink(NavigationGraph nav)
        {
            var node = GetNode(nav);

            var link = node.Links.FirstOrDefault(link => Vector3.Distance(link.Target.Origin, DestinationNode) <= 1);

            if (link == null)
                throw new NavPatchException($"Could not find link from ({Node.ToReadableString(", ")}) towards destination node ({DestinationNode.ToReadableString(", ")})");

            return link;
        }
    }
}
