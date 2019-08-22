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

        public override string ToString()
        {
            return $"{base.ToString()} Name: {Name} Price: {Price} Quantity: {Quantity}";
        }

        public bool Equals(Product other)
        {
            if (other is null) return false;

            return base.Equals(other)
                   && Name == other.Name
                   && Price == other.Price
                   && Quantity == other.Quantity;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            unchecked
            {
                hash = (hash * 31) + base.GetHashCode();
                hash = (hash * 31) + (Name == null ? 0 : Name.GetHashCode());
                hash = (hash * 31) + Price.GetHashCode();
                hash = (hash * 31) + Quantity.GetHashCode();
            }
            return hash;
        }
    }
}
