using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfiSales
{
    public abstract class Entity : IPersistable, IEquatable<Entity>
    {
        protected int id;

        public Entity() { }

        public Entity(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get { return id; }
        }

        public override bool Equals(object obj)
        {
            return Equals((Entity)obj);
        }

        public bool Equals(Entity other)
        {
            if (other is null) return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"ID: {Id}";
        }
    }
}
