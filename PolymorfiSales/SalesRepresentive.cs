using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public class SalesRepresentive : BaseSalariedEmployee, IEquatable<SalesRepresentive>
    {
        protected decimal weeklySales;
        protected double commisionRate;

        public SalesRepresentive(int id, decimal salary, string name, double commisionRate, decimal weeklySales)
            :base(id, salary, name)
        {
            CommisionRate = commisionRate;
            WeeklySales = weeklySales;
        }

        public SalesRepresentive(decimal salary, string name, double commisionRate, decimal weeklySales)
            : this(default, salary, name, commisionRate, weeklySales) { }

        public double CommisionRate
        {
            get { return commisionRate; }
            set { commisionRate = value; }
        }

        public decimal WeeklySales
        {
            get { return weeklySales; }
            set { weeklySales = value; }
        }

        public override decimal Earnings()
        {
            return base.Earnings() + weeklySales * (decimal)CommisionRate / 100;
        }

        public override bool Equals(object obj)
        {
            if (obj is SalesRepresentive salesRepresentive)
            {
                if (salesRepresentive.Id == Id &&
                    salesRepresentive.Salary == Salary &&
                    salesRepresentive.Name == Name &&
                    salesRepresentive.CommisionRate == CommisionRate &&
                    salesRepresentive.WeeklySales == WeeklySales)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Salary: {Salary} | Name: {Name} | Commision Rate: {CommisionRate} | Weekly Sales: {WeeklySales}";
        }

        public bool Equals(SalesRepresentive other)
        {
            return other != null &&
                   base.Equals(other) &&
                   CommisionRate == other.CommisionRate &&
                   WeeklySales == other.WeeklySales;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CommisionRate, WeeklySales);
        }
    }
}
