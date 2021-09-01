using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Extensions
{
    public static class RectangleExtensions
    {
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));
        }

        public static PointF Center(this RectangleF rectangle)
        {
            return new PointF(rectangle.X + (rectangle.Width / 2f), rectangle.Y + (rectangle.Height / 2f));
        }
    }
}
