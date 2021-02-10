using System;

namespace _090221Task.Exceptions
{
    class BankPercentException:ApplicationException
    {
        public double BankPercentage { get; set; }
        public BankPercentException(double bankPercentage)
        {
            BankPercentage = bankPercentage;
        }
        public BankPercentException(string message):base(message)
        {

        }
    }
}
