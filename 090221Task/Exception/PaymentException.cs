using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _090221Task.Exception
{
    class PaymentException:ApplicationException
    {
        public PaymentException(string message):base(message)
        {
            
        }
    }
}
