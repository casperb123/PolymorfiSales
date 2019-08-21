using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public class BaseSalariedEmployee : Employee, IEquatable<BaseSalariedEmployee>
    {
        protected decimal salary;

        public BaseSalariedEmployee(int id, decimal salary, string name)
            : base(id, name)
        {
            Salary = salary;
        }

        public BaseSalariedEmployee(decimal salary, string name)
            : this(default, salary, name) { }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override decimal Earnings()
        {
            return Salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseSalariedEmployee baseSalariedEmployee)
            {
                return Equals(baseSalariedEmployee);
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Salary: {Salary} | Name: {Name}";
        }

        public bool Equals(BaseSalariedEmployee other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Salary == other.Salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Salary);
        }
    }
}
