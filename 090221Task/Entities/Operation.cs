using System;
using _090221Task.AbstractClasses;

namespace _090221Task.Entities
{
    public class Operation:Entity
    {
        public string ProcessName { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
Process Name: {ProcessName}
Datetime: {DateTime}";
        }
    }
}
