using System;

namespace Exercises._02_Generics
{
    public class CrudRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IDataStore _dataStore;
        
        public CrudRepository(IDataStore dataStore) => _dataStore = dataStore;

        public void Create(TEntity entity) => _dataStore.Save(entity);
        
        public TEntity Read(Guid id) => (TEntity) _dataStore.Get(id); 
        
        public void Update(TEntity entity) => _dataStore.Save(entity);

        public void Delete(Guid id)
        {
            var entity = _dataStore.Get(id);
            entity.Delete();
            _dataStore.Save(entity);
        }
    }
}