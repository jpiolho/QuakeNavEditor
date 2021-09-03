using QuakeNavEditor.Extensions;
using QuakeNavSharp.Navigation;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches
{
    public abstract class NodeNavPatch : NavPatch
    {
        [JsonIgnore]
        public override string PatchDescription => $"Patch node at ({Node.X.ToString(CultureInfo.InvariantCulture)}, {Node.Y.ToString(CultureInfo.InvariantCulture)}, {Node.Z.ToString(CultureInfo.InvariantCulture)})";

        public Vector3 Node { get; set; }


        protected NavigationGraph.Node GetNode(NavigationGraph nav)
        {
            var node = nav.Nodes.FirstOrDefault(node => Vector3.Distance(Node, node.Origin) <= 1);

            if (node == null)
                throw new NavPatchException($"Could not find node at ({Node.ToReadableString(", ")})");

            return node;
        }
    }
}
