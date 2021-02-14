using System;
using System.Configuration;
using _090221Task.AbstractClasses;
using _090221Task.DataStructures;
using _090221Task.Exceptions;
using _090221Task.HelperClasses;
using _090221Task.Logger;

namespace _090221Task.Entities
{
    public class Bank
    {
        public string Name { get; set; }
        public double Budget { get; set; }
        public double TotalProfit { get; set; }

        public double Income { get; set; }
        
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
Profit: {TotalProfit:C2}
Income: {Income:C2}";
        }

        public Bank()
        {
            Workers = new CustomList<Worker>();
            Managers = new CustomList<Manager>();
            Clients = new CustomList<Client>();
            Credits = new CustomList<Credit>();
        }

        public void GiveCredit(Credit credit)
        {
            if (!BankHelper.CheckBankBudget(credit.Amount, Budget))
                throw new NotEnoughMoneyException("There is not enough money in the bank!");

            credit.CalculatePayment();
            Budget -= credit.Amount;
            Credits.Add(credit);
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

            TotalProfit = profit;
        }

        public void ShowClientCredits(Client client)
        {
            if(Credits.Data == null)
                throw new NotCreditException(
                    $"There is no credit associated this client-> {client.Name} {client.Surname}");

            var flag = false;
            foreach (var credit in Credits.Data)
            {
                if (credit.Client.Name == client.Name && credit.Client.Surname == client.Surname)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(credit);
                    flag = true;
                }
            }

            if (!flag)
                throw new NotCreditException(
                    $"There is no credit associated this client-> {client.Name} {client.Surname}");
        }

        public void PayCredit(Credit credit, double money)
        {
            try
            {
                credit.PayCredit(money);
                Income += money;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e.Message);
            }
        }

        public Credit GetCredit(Client client, Guid id, out int creditIndex)
        {
            if (Credits.Length == 0)
                throw new NotCreditException($"There is no credit in the bank!");

            var index = Array.FindIndex(Credits.Data,
                credit => credit.Id == id);

            if (index < 0)
                throw new NotCreditException($"There is no credit association this client -> {client.Name} {client.Surname}");

            creditIndex = index;
            return Credits[index];
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

        public void ShortInfoClients()
        {
            if (Clients.Data == null)
                throw new NotClientException("There is no client!");

            foreach (var client in Clients.Data) 
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Id: {client.Id}");
                Console.WriteLine($"Name: {client.Name} {client.Surname}");
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
