using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _090221Task.AbstractClasses;
using _090221Task.Exceptions;
using _090221Task.Interfaces;

namespace _090221Task.Entities
{
    public class Manager:Employee, IOrganize, IControl
    {
        public void Organize(Worker[] workers)
        {
            Console.WriteLine($"Employees on the list must be in the manager’s meeting room at {DateTime.Now.AddHours(1)} p.m.");
            BankHelper.PrintWorkers(workers);
        }

        public double CalculateSalaries(Worker[] workers)
        {
            if (workers == null)
                throw new ArgumentNullException(nameof(workers));

            if (workers.Length == 0)
                throw new NotEmployeeException("There is no worker!");

            double salaries = 0;

            foreach (var worker in workers)
            {
                salaries += worker.Salary;
            }

            return salaries;
        }

        public void Control(Worker[] workers)
        {
            if (workers == null)
                throw new ArgumentNullException(nameof(workers));

            if (workers.Length == 0)
                throw new NotEmployeeException("There is no worker!");

            var flag = false;

            foreach (var worker in workers)
            {
                if (Position == worker.Position)
                {
                    flag = true;
                    Console.WriteLine($"Worker: {worker.Name} {worker.Surname}");
                    try
                    {
                        worker.ShowOperations();
                    }
                    catch (NotOperationException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
            }

            if (!flag)
                throw new NotEmployeeException($"There is no worker for this position -> {Position}");
        }
    }
}
