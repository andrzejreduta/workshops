namespace Exercises._01_Types
{
    public sealed class DiscountOver1000Pln : ConditionalPricingPolicy
    {
        public DiscountOver1000Pln(decimal discountValue) : base(new PercentageDiscount(discountValue)) { }
        protected override bool CheckCondition(Money price) => price.Currency == Currency.PLN && price.Value > 1000;
    }
}