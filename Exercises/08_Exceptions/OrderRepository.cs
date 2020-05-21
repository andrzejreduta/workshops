using System;

namespace Exercises._08_Exceptions
{
    public class OrderRepository
    {
        private readonly IDatabase _db;

        public OrderRepository(IDatabase db) => _db = db;

        public Order GetBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order) => _db.Save(order);
    }
}