using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Exercises._01_Types;

namespace Exercises._10_AsyncAwait
{
    public class CalculatePriceHandler
    {
        private readonly ImmutableArray<ISupplierService> _suppliers;

        public CalculatePriceHandler(IEnumerable<ISupplierService> suppliers) =>
            _suppliers = suppliers.ToImmutableArray();

        public Task<Money> Handle(Guid productId, PriceCalculationPolicy calculationPolicy)
        {
            throw new NotImplementedException();
        }
    }
}