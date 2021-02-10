using System;
using _090221Task.AbstractClasses;
using _090221Task.Exceptions;
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

        public double PaymentPerMonth { get; set; }

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

        public void CalculatePayment()
        {
            var payment = CalculatePercent(Amount, Percent);
            var paymentPerMonth = payment / Months;

            Payment = payment;
            Debt = Payment;
            PaymentPerMonth = paymentPerMonth;
        }
        public double CalculatePercent(double amount, double percent)
        {
            return amount * (percent / 100.0);
        }
    }
}
