using System;

namespace _090221Task.AbstractClasses
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}