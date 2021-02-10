using System;

namespace _090221Task.Exception
{
    class NotEmployeeException : ApplicationException
    {
        public NotEmployeeException(string message):base(message)
        {
            
        }
    }
}
