using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    public class NavLink
    {
        public int Destination { get; set; }
        public NavLinkType Type { get; set; }

        public NavLinkTraversal Traversal { get; set; }
        public NavLinkEdict Edict { get; set; }
    }
}
