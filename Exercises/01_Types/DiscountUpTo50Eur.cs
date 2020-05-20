namespace Exercises._01_Types
{
    public class DiscountUpTo50Eur : ConditionalPricingPolicy
    {
        public DiscountUpTo50Eur() : base(new ValueDiscount(1)) { }
        
        protected override bool CheckCondition(Money price) => price.Currency == Currency.EUR && price.Value < 50;
    }
}