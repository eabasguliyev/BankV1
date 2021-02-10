using System;

namespace _090221Task.Exceptions
{
    class NotClientException : ApplicationException
    {
        public NotClientException(string message):base(message)
        {
            
        }
    }
}
