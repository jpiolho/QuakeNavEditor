using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public class NodeFlagsNavPatch : NodeNavPatch
    {
        [JsonIgnore]
        public override string PatchId => "node_flags";
        [JsonIgnore]
        public override string PatchDescription => $"{base.PatchDescription} set flags to {GetFlagText()}";

        public NavNodeFlags Flags { get; set; }



        private string GetFlagText()
        {
            var sb = new StringBuilder();
            foreach(var flag in Enum.GetValues<NavNodeFlags>())
            {
                if (flag == NavNodeFlags.None)
                    continue;

                // Only append if it has the flag
                if (Flags.HasFlag(flag))
                {
                    if (sb.Length > 0)
                        sb.Append(", ");

                    sb.Append(flag.ToString());
                }
            }

            return sb.ToString();
        }

        public override void Apply(NavFile nav)
        {
            var node = GetNode(nav);
            node.Flags = Flags;
        }

    }
}
