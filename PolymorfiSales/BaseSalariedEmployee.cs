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

        public override string ToString()
        {
            return $"{base.ToString()} Name: {Name} Salary: {Salary}";
        }

        public bool Equals(BaseSalariedEmployee other)
        {
            if (other is null) return false;

            return base.Equals(other)
                && Salary == other.Salary;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            unchecked
            {
                hash = (hash * 31) + base.GetHashCode();
                hash = (hash * 31) + Salary.GetHashCode();
            }
            return hash;
        }
    }
}
