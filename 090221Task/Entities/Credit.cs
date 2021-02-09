using _090221Task.AbstractClasses;

namespace _090221Task.Entities
{
    public class Credit:Entity
    {
        public Client Client { get; set; }
        public double Amount { get; set; }
        public double  Percent { get; set; }
        public int Months { get; set; }
        public double Payment { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
{Client.ToString()}
Amount: {Amount}
Percent: {Percent}
Months: {Months}
Payment: {Payment}";
        }

        public void CalculatePercent()
        {

        }
    }
}
