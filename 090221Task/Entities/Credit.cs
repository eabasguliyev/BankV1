using System;
using _090221Task.AbstractClasses;
using _090221Task.Exception;
using _090221Task.Interfaces;

namespace _090221Task.Entities
{
    public class Credit:Entity
    {
        public Client Client { get; set; }
        public double Amount { get; set; }
        public double  Percent { get; set; }
        public int Months { get; set; }
        public double Payment { get; set; }
        public double Debt { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
{Client.ToString()}
Amount: {Amount}
Percent: {Percent}
Months: {Months}
Payment: {Payment}";
        }

        public void PayCredit(double amount)
        {
            if (!BankHelper.CheckDebt(Debt, amount))
                throw new PaymentException("There is no debt!");

            Debt -= amount;
        }

        public void CalculatePercent()
        {
            Payment = Amount * (Percent / 100.0);
        }
    }
}
