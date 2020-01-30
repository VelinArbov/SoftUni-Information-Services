

using System;

namespace SIS.HTTP.Exceptions
{
    public class HttpServerException : Exception
    {

        public HttpServerException(string message)
        :base(message)
        {
            
        }
    }
}
