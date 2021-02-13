using System;

namespace _090221Task.Exceptions
{
    public class InvalidLoginException:ApplicationException
    {
        public InvalidLoginException(string message):base(message)
        {
            
        }
    }
}