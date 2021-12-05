using System;

namespace BackupsExtra.Tool
{
    public class BackupsExtraException : Exception
    {
        public BackupsExtraException(string message)
            : base(message)
        {
        }
    }
}