using QuakeNavEditor.Extensions;
using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches.Link
{
    public class LinkTraversalNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_traversal";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set traversal to node exit ({Traversal.NodeExit.ToReadableString(", ")}) jump start ({Traversal.JumpStart.ToReadableString(", ")}) jump end ({Traversal.JumpEnd.ToReadableString(", ")})";

        public NavLinkTraversal Traversal { get; set; }


        public override void Apply(NavFile nav)
        {
            var link = GetLink(nav);

            link.Traversal = new NavLinkTraversal();
            link.Traversal.NodeExit = Traversal.NodeExit;
            link.Traversal.JumpStart = Traversal.JumpStart;
            link.Traversal.JumpEnd = Traversal.JumpEnd;
        }

    }
}
