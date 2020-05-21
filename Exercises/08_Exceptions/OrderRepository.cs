using System;

namespace Exercises._08_Exceptions
{
    public class OrderRepository
    {
        private readonly IDatabase _db;

        public OrderRepository(IDatabase db) => _db = db;

        public Order GetBy(Guid id)
        {
            for (var i = 0; i <= 4; i++)
            {
                try
                {
                    return _db.Get<Order>(id);
                }
                catch (DbUnavailableException e)
                {
                    continue;
                }
            }
            throw new DbUnavailableException();
        }

        public void Save(Order order) => _db.Save(order);
    }
}