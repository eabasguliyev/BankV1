using System;

namespace _090221Task.Exceptions
{
    class NotEmployeeException : ApplicationException
    {
        public NotEmployeeException(string message):base(message)
        {
            
        }
    }
}
