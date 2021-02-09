using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _090221Task.AbstractClasses;

namespace _090221Task.Entities
{
    public class Client:Human
    {
        public string LiveAddress { get; set; }
        public string WorkAddress { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
Live Address: {LiveAddress}
Work Addrress: {WorkAddress}
Salary: {Salary}";
        }
    }
}
