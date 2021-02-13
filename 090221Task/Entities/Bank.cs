using System;
using _090221Task.AbstractClasses;
using _090221Task.DataStructures;
using _090221Task.Exceptions;

namespace _090221Task.Entities
{
    public class Bank
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public decimal Profit { get; set; }
        
        public double Percentage { get; set; }
        public Ceo Ceo { get; set; }
        public CustomList<Worker> Workers { get; private set; }
        public CustomList<Manager> Managers { get; private set; }
        public CustomList<Client> Clients { get; private set; }
        public CustomList<Credit> Credits { get; private set; }

        public override string ToString()
        {
            return $@"Name: {Name}
Budget: {Budget:C2}
Percentage: {Percentage:P1}
Profit: {Profit:C2}";
        }

        public Bank()
        {
            Workers = new CustomList<Worker>();
            Managers = new CustomList<Manager>();
            Clients = new CustomList<Client>();
            Credits = new CustomList<Credit>();
        }

        public void CalculateProfit()
        {
            if (Credits.Empty)
                throw new NotCreditException("There is no credit!");

            double profit = 0;

            foreach (var credit in Credits)
            {
                profit += ((Credit) credit).Payment;
            }

            Profit = Convert.ToDecimal(profit);
        }

        public void ShowClientCredit(string fullname)
        {
            var nameComponents = BankHelper.NameSplit(fullname);

            var index = Array.FindIndex(Credits.Data,
                credit => credit.Client.Name == nameComponents[0] && credit.Client.Surname == nameComponents[1]);

            if (index < 0)
                throw new NotCreditException($"There is no credit association this client -> {fullname}");

            Console.WriteLine(Credits[index]);
        }

        public void PayCredit(Client client, double money)
        {
            var index = Array.FindIndex(Credits.Data,
                credit => credit.Client.Name == client.Name && credit.Client.Surname == client.Surname);

            if (index < 0)
                throw new NotCreditException($"There is no credit association this client -> {client.Name} {client.Surname}");

            Credits[index].PayCredit(money);
        }

        public void ShowAllCredit()
        {
            if (Credits.Empty)
                throw new NotCreditException("There is no credit!");

            foreach (var credit in Credits)
            {
                Console.WriteLine(credit);
                Console.WriteLine();
            }
        }


        public void ShortInfoEmployees(Employee[] employees)
        {
            if (employees == null)
                throw new NotEmployeeException("There is no employee!");

            foreach (var employee in employees)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"Name: {employee.Name} {employee.Surname}");
                Console.WriteLine();
            }
        }
    }
}
