using System;
using _090221Task.AbstractClasses;

namespace _090221Task.Entities
{
    public class Operation:Entity
    {
        public string ProcessName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
