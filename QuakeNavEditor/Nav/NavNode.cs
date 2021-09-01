using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    public class NavNode
    {
        private const int MaximumConnections = 12;

        public Vector3 Position { get; set; }
        public NavNodeFlags Flags { get; set; }
        public int Radius { get; set; }

        public List<NavLink> OutgoingLinks { get; private set; } = new List<NavLink>(MaximumConnections);
    }
}
