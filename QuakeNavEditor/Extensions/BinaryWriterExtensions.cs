using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Extensions
{
    public static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer,Vector3 vector)
        {
            writer.Write((float)vector.X);
            writer.Write((float)vector.Y);
            writer.Write((float)vector.Z);
        }
    }
}
