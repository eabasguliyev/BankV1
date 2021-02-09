using System;

namespace _090221Task.AbstractClasses
{
    public abstract class Human:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
Name: {Name}
Surname: {Surname}
Age: {Age}";
        }
    }
}