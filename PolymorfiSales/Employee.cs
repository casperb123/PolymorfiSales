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

        public override string ToString()
        {
            return $"{base.ToString()} Name: {Name}";
        }

        public bool Equals(Employee other)
        {
            if (other is null) return false;

            return base.Equals(other)
                && Name == other.Name;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            unchecked
            {
                hash = (hash * 31) + base.GetHashCode();
                hash = (hash * 31) + (Name == null ? 0 : Name.GetHashCode());
            }
            return hash;
        }
    }
}
