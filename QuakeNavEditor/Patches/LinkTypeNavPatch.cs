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
    public class LinkTypeNavPatch : LinkNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "link_type";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set type to {Type}";

        public NavLinkType Type { get; set; }


        public override void Apply(NavFile nav)
        {
            var link = GetLink(nav);
            link.Type = Type;
        }

    }
}
