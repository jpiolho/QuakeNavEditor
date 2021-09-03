using QuakeNavEditor.Extensions;
using QuakeNavSharp.Navigation;
using System.Text.Json.Serialization;

namespace QuakeNavEditor.Patches.Link
{
    public class LinkEdictNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_edict";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set edict min ({Edict.Mins.ToReadableString(", ")}) maxs ({Edict.Maxs.ToReadableString(", ")}) classname ({Edict.Classname}) targetname ({Edict.Targetname})";

        public NavigationGraph.Edict Edict { get; set; }


        public override void Apply(NavigationGraph nav)
        {
            var link = GetLink(nav);

            link.Edict = new NavigationGraph.Edict();
            link.Edict.Mins = Edict.Mins;
            link.Edict.Maxs = Edict.Maxs;
            link.Edict.Classname = Edict.Classname;
            link.Edict.Targetname = Edict.Targetname;
        }

    }
}
