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
            if (obj is Entity entity)
            {
                if (entity.Id == Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Equals(Entity other)
        {
            return other != null &&
                   Id == other.Id;
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
