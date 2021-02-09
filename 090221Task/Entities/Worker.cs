using System;
using _090221Task.AbstractClasses;
using _090221Task.Exception;

namespace _090221Task.Entities
{
    public class Worker:Employee
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Operation[] Operations { get; set; }

        public void AddOperation()
        {
            //tamamla
        }

        public void ShowOperations()
        {
            if (Operations == null)
                throw new NotOperationException("There is no operation.");

            foreach (var operation in Operations)
            {
                Console.WriteLine(operation);
            }

        }
    }
}
