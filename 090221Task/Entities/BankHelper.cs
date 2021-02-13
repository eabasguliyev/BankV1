using System;

namespace _090221Task.Entities
{
    public static class BankHelper
    {
        public static void PrintWorkers(Worker[] workers)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {workers[i].Name} {workers[i].Surname}");
            }
            Console.ResetColor();
        }

        public static string[] NameSplit(string fullname)
        {
            return fullname.Split(' ');
        }

        public static bool CheckDebt(double debt, double amount)
        {
            if (debt - amount >= 0)
                return true;
            return false;
        }

        public static bool CheckBankPercentage(double newBankPercent)
        {
            if (newBankPercent < 0 || newBankPercent > 1)
                return false;
            return true;
        }
    }
}