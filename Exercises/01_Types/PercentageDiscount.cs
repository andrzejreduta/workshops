using System;

namespace Exercises._01_Types
{
    public class PercentageDiscount : IPricingPolicy
    {
        private readonly decimal _discountValue;

        public PercentageDiscount(decimal discountValue)
        {
            if (discountValue < 0 || discountValue > 1)
                throw new ArgumentException("Discount must be between 0 and 1", nameof(discountValue));
            _discountValue = discountValue;
        }

        public Money Apply(Money price) => price * (1 - _discountValue);
    }
}