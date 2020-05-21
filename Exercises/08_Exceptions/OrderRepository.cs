using System;

namespace Exercises._08_Exceptions
{
    public class OrderRepository
    {
        private readonly IDatabase _db;

        public OrderRepository(IDatabase db) => _db = db;

        public Order GetBy(Guid id)
        {

            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    return _db.Get<Order>(id);
                }
                catch (DbUnavailableException ex)
                {
                    
                }
            }
            throw new DbUnavailableException();
            
            //throw new NotImplementedException();
        }

        public void Save(Order order) => _db.Save(order);
    }
}