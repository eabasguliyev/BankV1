using System;

namespace _090221Task.Exceptions
{
    class NotEnoughMoneyException:ApplicationException
    {
        public NotEnoughMoneyException(string message):base(message)
        {
            
        }
    }
}
