using QuakeNavEditor.Extensions;
using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches.Link
{
    public class LinkTraversalNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_traversal";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set traversal to point1 ({Traversal.Point1.ToReadableString(", ")}) point2 ({Traversal.Point2.ToReadableString(", ")}) point3 ({Traversal.Point3.ToReadableString(", ")})";

        public NavigationGraph.Traversal Traversal { get; set; }


        public override void Apply(NavigationGraph nav)
        {
            var link = GetLink(nav);

            link.Traversal = new NavigationGraph.Traversal();
            link.Traversal.Point1 = Traversal.Point1;
            link.Traversal.Point2 = Traversal.Point2;
            link.Traversal.Point3 = Traversal.Point3;
        }

    }
}
