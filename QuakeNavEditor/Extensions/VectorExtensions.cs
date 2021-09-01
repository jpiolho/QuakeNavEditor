using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Extensions
{
    public static class VectorExtensions
    {
        public static string ToReadableString(this Vector3 vector,string separator)
        {
            return $"{vector.X.ToString(CultureInfo.InvariantCulture)}{separator}{vector.Y.ToString(CultureInfo.InvariantCulture)}{separator}{vector.Z.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
