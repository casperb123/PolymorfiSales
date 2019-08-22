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
            return Equals((BaseSalariedEmployee)obj);
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
            return HashCode.Combine(base.GetHashCode(), Salary);
        }
    }
}
