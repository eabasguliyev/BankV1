using System;

namespace _090221Task.AbstractClasses
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}