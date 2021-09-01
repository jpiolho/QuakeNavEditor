using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuakeNavEditor.Patches
{
    public class NavPatchException : Exception
    {
        public NavPatchException()
        {
        }

        public NavPatchException(string message) : base(message)
        {
        }

        public NavPatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NavPatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
