using System;
using _090221Task.Entities;
using _090221Task.Enums;

namespace _090221Task
{
    public static class ManagerSide
    {
        public static void Start(Manager manager, Bank bank)
        {
            Console.Title = $"{bank.Name}: Manager";
            var managerMenuLoop = true;

            while (managerMenuLoop)
            {
                ConsoleScreen.PrintMenu(ConsoleScreen.ManagerMenuOptions);

                var choice = ConsoleScreen.Input(ConsoleScreen.ManagerMenuOptions.Length);

                Console.Clear();

                switch ((ManagerMenuOptions)choice)
                {
                    case ManagerMenuOptions.Info:
                    {
                        Console.WriteLine(manager);
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ManagerMenuOptions.Control:
                    {
                        try
                        {
                            manager.Control(bank.Workers.Data);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ManagerMenuOptions.Organize:
                    {
                        try
                        {
                            bank.Ceo.Organize(bank.Workers.Data);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ManagerMenuOptions.CalculateSalaries:
                    {
                        try
                        {
                            var totalSalaries = manager.CalculateSalaries(bank.Workers.Data);

                            Console.WriteLine($"Total salaries is {totalSalaries:C2}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ManagerMenuOptions.Back:
                    {
                        managerMenuLoop = false;
                        break;
                    }
                }
            }
        }
    }
}