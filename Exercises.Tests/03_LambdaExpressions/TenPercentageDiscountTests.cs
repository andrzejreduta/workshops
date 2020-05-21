using System;
using Exercises._01_Types;
using FluentAssertions;
using Xunit;

namespace Exercises._03_LambdaExpressions
{
    public class TenPercentageDiscountTests
    {
        [Theory]
        [InlineData("0", "0")]
        [InlineData("10", "9")]
        [InlineData("25", "22.5")]
        public void TenPercentageDiscountExists(string price, string discountedPrice)
        {
            var pricingPolicy = (PricingPolicy) Delegate.CreateDelegate(
                typeof(PricingPolicy), 
                typeof(PricingPolicies), 
                "TenPercentageDiscount");
            pricingPolicy(Money.Of(decimal.Parse(price), Currency.PLN))
                .Should().Be(Money.Of(decimal.Parse(discountedPrice), Currency.PLN));
        }
    }
}