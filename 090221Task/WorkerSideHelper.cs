using System;
using _090221Task.Entities;

namespace _090221Task
{
    public static class WorkerSideHelper
    {
        public static string InputOperationName()
        {
            var operationName = String.Empty;

            Console.WriteLine("Process name: ");

            while (true)
            {
                Console.Write(">> ");

                operationName = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(operationName))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Process name can not be empty!");
                Console.ResetColor();
            }

            return operationName;
        }
        public static Operation CreateNewOperation(string operationName)
        {
            return new Operation() { ProcessName = operationName };
        }

        /*
         *
         * public Client Client { get; set; }
        public double Amount { get; set; }
        public double  Percent { get; set; }
        public int Months { get; set; }
         */
        public static Credit CreateNewCredit(Client client, double amount, double percent, int months)
        {
            return new Credit() {Client = client, Amount = amount, Months = months, Percent = percent};
        }
    }
}