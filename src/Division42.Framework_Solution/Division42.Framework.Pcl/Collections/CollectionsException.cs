using System;

namespace Division42.Framework.Collections
{
    public class CollectionsException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CollectionsException()
        {
        }

        public CollectionsException(string message)
            : base(message)
        {
        }

        public CollectionsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}