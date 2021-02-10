using System;

namespace _090221Task.Exception
{
    class NotClientException : ApplicationException
    {
        public NotClientException(string message):base(message)
        {
            
        }
    }
}
