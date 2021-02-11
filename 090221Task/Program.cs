using System;
using _090221Task.Entities;
using _090221Task.Enums;

namespace _090221Task
{
    static class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank()
            {
                Name = "Bank of America",
                Percentage = 0.2,
                Budget = 1_000_000
            };

            bank.Ceo = new Ceo()
            {
                Name = "Debra",
                Surname = "Hayes",
                Age = 36,
                Salary = 2000,
                Position = "CEO"
            };


            Console.Title = "Bank";

            var mainMenuLoop = true;

            while (mainMenuLoop)
            {
                ConsoleScreen.PrintMenu(ConsoleScreen.MainMenuOptions);

                var choice = ConsoleScreen.Input(ConsoleScreen.MainMenuOptions.Length);

                Console.Clear();

                switch ((MainMenuOptions)choice)
                {
                    case MainMenuOptions.BankInfo:
                    {
                        Console.WriteLine(bank);
                        ConsoleScreen.Clear();
                        break;
                    }
                    case MainMenuOptions.Ceo:
                    {
                        CeoSide.Start(bank);
                        break;
                    }
                    case MainMenuOptions.Managers:
                    {
                        break;
                    }
                    case MainMenuOptions.Workers:
                    {
                        break;
                    }
                    case MainMenuOptions.Exit:
                    {
                        mainMenuLoop = false;
                        break;
                    }
                }
            }
        }
    }
}
