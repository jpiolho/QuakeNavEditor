using QuakeNavEditor.Extensions;
using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches.Link
{
    public class LinkEdictNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_edict";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set edict min ({Edict.Mins.ToReadableString(", ")}) maxs ({Edict.Maxs.ToReadableString(", ")}) classname ({Edict.Classname}) targetname ({Edict.Targetname})";

        public NavLinkEdict Edict { get; set; }


        public override void Apply(NavFile nav)
        {
            var link = GetLink(nav);

            link.Edict = new NavLinkEdict();
            link.Edict.Mins = Edict.Mins;
            link.Edict.Maxs = Edict.Maxs;
            link.Edict.Classname = Edict.Classname;
            link.Edict.Targetname = Edict.Targetname;
        }

    }
}
