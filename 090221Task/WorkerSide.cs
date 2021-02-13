using System;
using System.Runtime.InteropServices;
using _090221Task.Entities;
using _090221Task.Enums;

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