using System;
using _090221Task.Entities;
using _090221Task.Logger;

namespace _090221Task.HelperClasses
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

        public static string InputFullname()
        {
            var fullname = String.Empty;

            while (true)
            {
                Console.WriteLine(">> ");
                fullname = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(fullname))
                {
                    if (fullname.Split(' ').Length >= 2)
                    {
                        return fullname;
                    }
                    else
                    {
                        ConsoleLogger.Error("Full name must be minimum contain two word!");
                    }
                }
                else
                {
                    ConsoleLogger.Error("Input can not be empty!");
                }
            }
        }

        public static double InputAmount()
        {
            var amount = 0.0;

            while (true)
            {
                try
                {
                    amount = Convert.ToDouble(Console.ReadLine());

                    if (amount > 0)
                        return amount;
                    
                    ConsoleLogger.Error("Input must be greater than zero.");
                }
                catch (Exception e)
                {
                    ConsoleLogger.Error("Input must be real numeric value.");
                }
            }
        }

        public static int InputMonths()
        {
            var months = 0;

            while (true)
            {
                try
                {
                    months = Convert.ToInt32(Console.ReadLine());

                    if (months > 0)
                        return months;

                    ConsoleLogger.Error("Input must be greater than zero.");
                }
                catch (Exception e)
                {
                    ConsoleLogger.Error("Input must be integral numeric value.");
                }
            }
        }
    }
}