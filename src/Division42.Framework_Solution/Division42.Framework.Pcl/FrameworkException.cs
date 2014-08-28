using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Division42.Framework.Pcl
{
    public class FrameworkException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public FrameworkException()
        {
        }

        public FrameworkException(string message) : base(message)
        {
        }

        public FrameworkException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
