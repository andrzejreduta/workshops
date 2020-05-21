using System;
using Exercises._02_Generics;

namespace Exercises._08_Exceptions
{
    public interface IDatabase
    {
        T Get<T>(Guid id) where T : Entity;
        void Save<T>(T entity) where T : Entity;
    }
}