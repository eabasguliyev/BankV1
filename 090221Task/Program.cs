using System;
using System.Runtime.InteropServices;
using _090221Task.Entities;
using _090221Task.Enums;
using _090221Task.Exceptions;
using _090221Task.Login;

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
                Position = "CEO",
                Pin = "7777"
            };


            var worker2 = new Worker()
            {
                Name = "Herbert ",
                Surname = "Young",
                Age = 38,
                Salary = 750,
                Position = "Operator",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(8),
                Pin = "1111"
            };

            var worker1 = new Worker()
            {
                Name = "Nita",
                Surname = "McKnight",
                Age = 25,
                Salary = 800,
                Position = "Operator",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(8),
                Pin = "2222"
            };

            bank.Workers.Add(worker2);
            bank.Workers.Add(worker1);

            bank.Managers.Add(new Manager()
            {
                Name = "Erin",
                Surname = "Wynn",
                Age = 30,
                Salary = 900,
                Position = "Operator",
                Pin = "3333"
            });

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
                        var tmp = new Ceo[1] {bank.Ceo};

                        bank.ShortInfoEmployees(tmp);

                        while (true)
                        {
                            LoginHelper.GetLoginData(out Guid id, out string pin);

                            try
                            {
                                Login.Login.login(id, pin, tmp);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Login successfully!");
                                Console.ResetColor();
                                ConsoleScreen.Clear();

                                CeoSide.Start(bank);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                            }
                        }
                        break;
                    }
                    case MainMenuOptions.Managers:
                    {
                        bank.ShortInfoEmployees(bank.Managers.Data);

                        while (true)
                        {
                            LoginHelper.GetLoginData(out Guid id, out string pin);

                            try
                            {
                                var manager = Login.Login.login(id, pin, bank.Managers.Data) as Manager;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Login successfully!");
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                                
                                ManagerSide.Start(manager, bank);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                            }
                        }
                        break;
                    }
                    case MainMenuOptions.Workers:
                    {
                        bank.ShortInfoEmployees(bank.Workers.Data);

                        while (true)
                        {
                            LoginHelper.GetLoginData(out Guid id, out string pin);

                            try
                            {
                                var worker = Login.Login.login(id, pin, bank.Workers.Data) as Worker;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Login successfully!");
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                                
                                WorkerSide.Start(worker, bank);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(e.Message);
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                            }
                        }
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
