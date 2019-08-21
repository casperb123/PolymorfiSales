using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public class Product : Entity, IEquatable<Product>
    {
        protected string name;
        protected decimal price;
        protected int quantity;

        public Product(int id, int quantity, decimal price, string name)
            :base(id)
        {
            Quantity = quantity;
            Price = price;
            Name = name;
        }

        public Product(int quantity, decimal price, string name)
            : this(default, quantity, price, name) { }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                if (product.Name == Name && product.Price == Price && product.Quantity == Quantity)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Price: {Price} | Quantity: {Quantity}";
        }

        public bool Equals(Product other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Quantity == other.Quantity &&
                   Price == other.Price &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Quantity, Price, Name);
        }
    }
}
