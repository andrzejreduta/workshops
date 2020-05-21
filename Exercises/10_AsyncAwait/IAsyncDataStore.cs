using System;
using System.Threading.Tasks;
using Exercises._02_Generics;

namespace Exercises._10_AsyncAwait
{
    public interface IAsyncDataStore
    {
        Task<Entity> Get(Guid id);
        Task Save(Entity entity);
        Task Delete(Guid id);
    }
}