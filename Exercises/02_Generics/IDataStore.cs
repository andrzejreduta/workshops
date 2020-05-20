using System;

namespace Exercises._02_Generics
{
    public interface IDataStore
    {
        Entity Get(Guid id);
        void Save(Entity entity);
        void Delete(Guid id);
    }
}