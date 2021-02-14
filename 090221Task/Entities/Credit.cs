using _090221Task.AbstractClasses;
using _090221Task.Exceptions;
using _090221Task.HelperClasses;

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
            return $@"Credit ID: {base.ToString()}
{Client.ToString()}
Amount: {Amount}
Percent: {Percent}
Months: {Months}
Payment: {Payment}
Payment per month: {PaymentPerMonth}
Debt: {Debt}";
        }

        public void PayCredit(double amount)
        {
            if (!BankHelper.CheckDebt(Debt, amount))
                throw new PaymentException("Amount is greater than debt.!");

            Debt -= amount;
        }

        public bool isDebt => Debt != 0;

        public void CalculatePayment()
        {
            var payment = CalculatePercent(Amount, Percent) + Amount;
            var paymentPerMonth = payment / Months;

            Payment = payment;
            Debt = Payment;
            PaymentPerMonth = paymentPerMonth;
        }
        public double CalculatePercent(double amount, double percent)
        {
            return amount * percent;
        }
    }
}
