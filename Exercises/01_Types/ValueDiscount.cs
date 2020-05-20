namespace Exercises._01_Types
{
    public class ValueDiscount : IPricingPolicy
    {
        private readonly decimal _discountValue;
        
        public ValueDiscount(decimal discountValue) => _discountValue = discountValue;

        public Money Apply(Money price) => Money.Of(price.Value - _discountValue, price.Currency);
    }
}