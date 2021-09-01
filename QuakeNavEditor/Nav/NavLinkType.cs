using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    public enum NavLinkType : ushort
    {
        Walk = 0,
        LongJump = 1,
        Teleport = 2,
        WalkOffLedge = 3,
        Pusher = 4,
        BarrierJump = 5,
        Elevator = 6,
        Train = 7,
        ManualJump = 8,
        Unknown = 9
    }
}
