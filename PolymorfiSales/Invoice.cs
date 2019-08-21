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

        public override bool Equals(object obj)
        {
            if (obj is Invoice invoice)
            {
                if (invoice.Id == Id && invoice.Products.SequenceEqual(Products))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Products: {Products.ToString()}";
        }

        public bool Equals(Invoice other)
        {
            return other != null &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Products);
        }
    }
}
