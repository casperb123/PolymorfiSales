using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public abstract class Employee : Entity, IPayable, IEquatable<Employee>
    {
        protected string name;

        public Employee(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public Employee(string name)
            :this(default, name) { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract decimal Earnings();

        public decimal GetPaymentAmount()
        {
            decimal earnings = Earnings();
            earnings *= 0.15m;

            return earnings;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee employee)
            {
                if (employee.Id == Id && employee.Name == Name)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name}";
        }

        public bool Equals(Employee other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
