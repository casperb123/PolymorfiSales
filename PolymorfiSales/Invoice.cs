using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorfiSales
{
    public class Invoice : Entity, IPayable, IEquatable<Invoice>
    {
        protected List<Product> products;

        public Invoice(int id, List<Product> products)
            :base(id)
        {
            Products = products;
        }

        public Invoice(List<Product> products)
            :this(default, products) { }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public decimal GetPaymentAmount()
        {
            decimal totalPrice = 0;
            Products.ForEach(p => totalPrice += p.Price * p.Quantity);

            return totalPrice;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Product Count: {Products.Count}";
        }

        public bool Equals(Invoice other)
        {
            if (other is null) return false;

            return base.Equals(other)
                && Products.SequenceEqual(other.Products);
        }

        public override int GetHashCode()
        {
            int hash = 19;
            unchecked
            {
                hash = (hash * 31) + base.GetHashCode();
                Products.ForEach(p => hash = (hash * 31) + (p == null ? 0 : p.GetHashCode()));
            }
            return hash;
        }
    }
}
