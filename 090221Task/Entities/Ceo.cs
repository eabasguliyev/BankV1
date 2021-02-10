using System;
using _090221Task.AbstractClasses;
using _090221Task.Exceptions;
using _090221Task.Interfaces;

namespace _090221Task.Entities
{
    public class Ceo : Employee, IOrganize, IMeeting, IControl
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public void ChangePercentage(double percent, ref double bankPercent)
        {
            var newBankPercent = bankPercent + percent;

            if (!BankHelper.CheckBankPercentage(newBankPercent))
                throw new BankPercentException(newBankPercent);

            bankPercent = percent;
        }

        public void Organize(Worker[] workers)
        {
            Console.WriteLine($"Employees on the list must be in the CEO’s meeting room at {DateTime.Now.AddHours(1)} p.m.");
            BankHelper.PrintWorkers(workers);
        }

        public void MakeMeeting(Worker[] workers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Meeting created.");
            Console.ResetColor();
            Console.WriteLine("Participants: ");

            BankHelper.PrintWorkers(workers);
        }

        public void Control(Worker[] workers)
        {
            if (workers == null)
                throw new ArgumentNullException(nameof(workers));

            if (workers.Length == 0)
                throw new NotEmployeeException("There is no worker!");


            foreach (var worker in workers)
            {
                Console.WriteLine($"Worker: {worker.Name} {worker.Surname}" );
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
    }
}