using System;
using System.Runtime.InteropServices;
using _090221Task.Entities;
using _090221Task.Enums;
using _090221Task.HelperClasses;
using _090221Task.Logger;

namespace _090221Task
{
    public static class WorkerSide
    {
        public static void Start(Worker worker, Bank bank)
        {
            Console.Title = $"{bank.Name}: Worker";
            var workerMenuLoop = true;

            while (workerMenuLoop)
            {
                ConsoleScreen.PrintMenu(ConsoleScreen.WorkerMenuOptions);

                var choice = ConsoleScreen.Input(ConsoleScreen.WorkerMenuOptions.Length);

                Console.Clear();

                switch ((WorkerMenuOptions)choice)
                {
                    case WorkerMenuOptions.Info:
                    {
                        Console.WriteLine(worker);
                        ConsoleScreen.Clear();
                        break;
                    }
                    case WorkerMenuOptions.AddOperation:
                    {
                        try
                        {
                            Console.WriteLine("-----------Operation-----------");
                            
                            var operationName = WorkerSideHelper.InputOperationName();
                            var newOperation = WorkerSideHelper.CreateNewOperation(operationName);
                            worker.Operations.Add(newOperation);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear();
                        break;
                    }
                    case WorkerMenuOptions.GiveCredit:
                    {
                        Console.WriteLine("Client fullname: ");

                        var fullname = WorkerSideHelper.InputFullname();
                        var nameComponents = BankHelper.NameSplit(fullname);


                        Client client = null;

                        try
                        {
                            var index = Array.FindIndex(bank.Clients.Data,
                                c => c.Name == nameComponents[0] && c.Surname == nameComponents[1]);
                            client = bank.Clients[index];
                        }
                        catch (Exception)
                        {
                            client = new Client() { Name = nameComponents[0], Surname = nameComponents[1], Pin = BankHelper.GenerateNewPin()};
                            ConsoleLogger.Error($"There is no client associated this name -> {fullname}. Created new client!\n Client PIN is \"{client.Pin}\"");
                            bank.Clients.Add(client);
                        }

                        Console.WriteLine("Amount: ");
                        var amount = WorkerSideHelper.InputAmount();

                        Console.WriteLine("Months: ");
                        var months = WorkerSideHelper.InputMonths();

                        var newCredit = WorkerSideHelper.CreateNewCredit(client, amount, bank.Percentage, months);

                        try
                        {
                            bank.GiveCredit(newCredit);

                            ConsoleLogger.Info("New credit given.");
                        }
                        catch (Exception e)
                        {
                            ConsoleLogger.Error(e.Message);
                        }

                        ConsoleScreen.Clear();
                        break;
                    }
                    case WorkerMenuOptions.Back:
                    {
                        workerMenuLoop = false;
                        break;
                    }
                }
            }
        }
    }
}