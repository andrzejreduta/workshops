using Exercises._01_Types;

namespace Exercises._03_LambdaExpressions
{
    public static class PricingPolicies
    {
        public static PricingPolicy DiscountOver1000Pln(decimal discountValue)
        {
            var percentageDiscount = new PercentageDiscount(discountValue);
            return price =>
            {
                if (price.Currency == Currency.PLN && price.Value > 1000)
                    return percentageDiscount.Apply(price);

                return price;
            };
        }

        public static Money TenPercentageDiscount(Money price) => price * 0.9m;
    }
}