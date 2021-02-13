using System;
using _090221Task.AbstractClasses;
using _090221Task.DataStructures;
using _090221Task.Exceptions;

namespace _090221Task.Entities
{
    public class Worker:Employee
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CustomList<Operation> Operations { get; private set; }

        public Worker()
        {
            Operations = new CustomList<Operation>();
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Start time: {StartTime:G}
End Time: {EndTime:G}";
        }

        public void ShowOperations()
        {
            if (Operations.Empty)
                throw new NotOperationException("There is no operation.");

            foreach (var operation in Operations)
            {
                Console.WriteLine(operation);
                Console.WriteLine();
            }
        }
    }
}
