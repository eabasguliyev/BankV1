namespace _090221Task.AbstractClasses
{
    public abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $@"{base.ToString()}
Position: {Position}
Salary: {Salary}";
        }
    }
}