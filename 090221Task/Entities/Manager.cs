using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _090221Task.AbstractClasses;
using _090221Task.Interfaces;

namespace _090221Task.Entities
{
    public class Manager:Employee, IOrganize
    {
        public void Organize()
        {
            throw new NotImplementedException();
        }

        public void CalculateSalaries()
        {
            throw new NotImplementedException();
        }
    }
}
