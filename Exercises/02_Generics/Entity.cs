using System;

namespace Exercises._02_Generics
{
    public class Entity
    {
        public Guid Id { get; }
        public bool IsDeleted { get; private set; }

        protected Entity(Guid id) => Id = id;

        public void Delete() => IsDeleted = true;
    }
}