using System;
using System.Runtime.InteropServices;
using _090221Task.Entities;
using _090221Task.Enums;
using _090221Task.HelperClasses;
using _090221Task.Logger;
using _090221Task.Login;

namespace _090221Task
{
    public static class ClientSide
    {
        public static void Start(Client client, Bank bank)
        {
            Console.Title = $"{bank.Name}: Client";
            var clientMenuLoop = true;

            while (clientMenuLoop)
            {
                ConsoleScreen.PrintMenu(ConsoleScreen.ClientMenuOptions);

                var choice = ConsoleScreen.Input(ConsoleScreen.ClientMenuOptions.Length);

                Console.Clear();

                switch ((ClientMenuOptions)choice)
                {
                    case ClientMenuOptions.Info:
                    {
                        Console.WriteLine(client);
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ClientMenuOptions.PayCredit:
                    {
                        try
                        {
                            bank.ShowClientCredits(client);
                        }
                        catch (Exception e)
                        {
                            ConsoleLogger.Error(e.Message);
                            ConsoleScreen.Clear();
                            break;
                        }

                        Guid id = Guid.Empty;

                        Console.WriteLine("Enter id: ");

                        while (true)
                        {
                            try
                            {
                                id = Guid.Parse(LoginHelper.Input());
                                break;
                            }
                            catch (Exception)
                            {
                                ConsoleLogger.Error("Invalid guid format. Try again!");
                            }
                        }

                        Console.WriteLine("Amount: ");

                        var amount = WorkerSideHelper.InputAmount();

                        try
                        {
                            var credit = bank.GetCredit(client, id, out int creditIndex);
                            bank.PayCredit(credit, amount);

                            ConsoleLogger.Info("Operation is successfully.");
                            if (!credit.isDebt)
                            {
                                bank.Credits.Delete(creditIndex);
                                ConsoleLogger.Info("Debt is closed.");
                            }
                        }
                        catch (Exception e)
                        {
                            ConsoleLogger.Error(e.Message);
                        }
                        ConsoleScreen.Clear();
                        break;
                    }
                    case ClientMenuOptions.Back:
                    {
                        clientMenuLoop = false;
                        break;
                    }
                }
            }
        }
    }
}