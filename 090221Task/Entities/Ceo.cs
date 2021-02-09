using System;
using _090221Task.AbstractClasses;
using _090221Task.Interfaces;

namespace _090221Task.Entities
{
    public class Ceo : Employee, IOrganize, IMeeting, IControl
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public void ChangePercentage(decimal percent, ref decimal bankPercentage)
        {
            bankPercentage = percent;
        }

        public void Organize()
        {
            throw new NotImplementedException();
        }

        public void MakeMeeting()
        {
            throw new NotImplementedException();
        }

        public void Control(Worker[] workers)
        {
            if (workers == null)
                throw new ArgumentNullException(nameof(workers));

            foreach (var worker in workers)
            {

                if(worker.Operations == null)
                    Console.WriteLine("This worker does not have any operation");

            }
        }
    }
}