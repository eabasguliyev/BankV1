using System;

namespace _090221Task.Exceptions
{
    class ListEmptyException:ApplicationException
    {
        public ListEmptyException(string message):base(message)
        {
            
        }
    }
}
