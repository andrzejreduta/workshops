using System;
using Exercises._01_Types;
using FluentAssertions;
using Xunit;

namespace Exercises._03_LambdaExpressions
{
    public class CustomConditionalPricingPolicyTests
    {
        [Theory]
        [InlineData("0", true, "0")]
        [InlineData("0", false, "0")]
        [InlineData("25", true, "22.5")]
        [InlineData("25", false, "25")]
        public void DiscountIsAppliedIfConditionInMet(string price, bool conditionResult, string discountedPrice)
        {
            var pricingPolicy = CreateTestedPolicy(conditionResult);
            pricingPolicy.Apply(Money.Of(decimal.Parse(price), Currency.PLN))
                .Should().Be(Money.Of(decimal.Parse(discountedPrice), Currency.PLN));
        }
        
        private static IPricingPolicy CreateTestedPolicy(bool conditionResult)
        {
            var policyType = TestHelpers.GetType("CustomConditionalPricingPolicy");
            var constructor = policyType.GetConstructor(new[] {typeof(IPricingPolicy), typeof(Func<Money, bool>)});
            constructor.Should()
                .NotBeNull("CustomConditionalPricingPolicy should have constructor with IPricingPolicy and Func<Money, bool> arguments");
            Func<Money,bool> condition = price => conditionResult;
            return (IPricingPolicy) constructor.Invoke(new object[]
            {
                new PercentageDiscount(0.1m),
                condition
            });
        }
    }
}