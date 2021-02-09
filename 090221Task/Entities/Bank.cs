namespace _090221Task.Entities
{
    public class Bank
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public decimal Profit { get; set; }
        
        public decimal Percentage { get; set; }
        public Ceo Ceo { get; set; }
        public Worker[] Workers { get; set; }
        public Manager[] Managers { get; set; }
        public Client[] Clients { get; set; }
        public Credit[] Credits { get; set; }

        public void CalculateProfit()
        {

        }

        public void ShowClientCredit(string fullname)
        {

        }

        public void PayCredit(Client client, double money)
        {

        }

        public void ShowAllCredit()
        {

        }
    }
}
