using System;

namespace _090221Task.Exceptions
{
    class NotCreditException : ApplicationException
    {
        public NotCreditException(string message):base(message)
        {
            
        }
    }
}
