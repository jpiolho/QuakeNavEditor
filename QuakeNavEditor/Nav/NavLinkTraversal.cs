using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    [Serializable]
    public class NavLinkTraversal
    {
        public Vector3 NodeExit { get; set; }
        public Vector3 JumpStart { get; set; }
        public Vector3 JumpEnd { get; set; }
    }
}
