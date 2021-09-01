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
    public abstract class NavPatch
    {
        [JsonIgnore]
        public abstract string PatchId { get; }
        [JsonIgnore]
        public abstract string PatchDescription { get; }

        public abstract void Apply(NavFile nav);
    }
}
