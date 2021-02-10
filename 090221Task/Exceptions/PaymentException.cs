using System;

namespace _090221Task.Exceptions
{
    class PaymentException:ApplicationException
    {
        public PaymentException(string message):base(message)
        {
            
        }
    }
}
