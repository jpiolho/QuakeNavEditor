using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Nav
{
    [Flags]
    public enum NavNodeFlags
    {
        None = 0,
        Teleporter = 1 << 0,
        Pusher = 1 << 1,
        ElevatorTop = 1 << 2,
        ElevatorBottom = 1 << 3,
        Underwater = 1 << 4,
        Hazard = 1 << 5
    }
}
