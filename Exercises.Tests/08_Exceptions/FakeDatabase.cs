using System;
using System.Collections.Generic;
using Exercises._02_Generics;

namespace Exercises._08_Exceptions
{
    internal class FakeDatabase : IDatabase
    {
        private readonly Dictionary<Guid, object> _entities = new Dictionary<Guid, object>();
        public int FailedAttempts { private get; set; }
        private int _attempts;

        public bool UnexpectedError { private get; set; }

        public T Get<T>(Guid id)
            where T : Entity
        {
            if (UnexpectedError)
                throw new NullReferenceException();
            if (_attempts++ < FailedAttempts)
                throw new DbUnavailableException();
            if (!_entities.TryGetValue(id, out var entity))
                throw new RecordNotFoundException();
            return (T) entity;
        }

        public void Save<T>(T entity)
            where T : Entity =>
            _entities[entity.Id] = entity;
    }
}