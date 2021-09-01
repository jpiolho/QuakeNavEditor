using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public class CommentNavPatch : NavPatch
    {
        [JsonIgnore]
        public override string PatchId => "comment";
        [JsonIgnore]
        public override string PatchDescription => $"// {Comment}";

        public string Comment { get; set; }


        public override void Apply(NavFile nav) { }
    }
}
