using System;

namespace LTE.Core
{
    public class LTException : Exception
    {
        public LTException()
        {

        }

        public LTException(string message)
            :base(message)
        {

        }

        public LTException(string messageFormat, params object[] args)
            :base(string.Format(messageFormat,args))
        {

        }
    }
}
