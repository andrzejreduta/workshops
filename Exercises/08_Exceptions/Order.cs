using System;
using Exercises._02_Generics;

namespace Exercises._08_Exceptions
{
    public class Order : Entity
    {
        public OrderStatus Status { get; private set; }

        public static Order New() => new Order(Guid.NewGuid(), OrderStatus.New);
        public static Order Restore(Guid id, OrderStatus status) => new Order(id, status);
        
        private Order(Guid id, OrderStatus status) : base(id) => Status = status;

        public void Cancel()
        {
            //business logic
            Status = OrderStatus.Canceled;
        }
        
        //other behaviours
    }
}