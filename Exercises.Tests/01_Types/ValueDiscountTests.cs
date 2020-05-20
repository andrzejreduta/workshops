using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Exercises._01_Types
{
    public class ValueDiscountTests
    {
        [Theory]
        [InlineData("100", "1", "99")]
        [InlineData("2.5", "2.5", "0")]
        [InlineData("0", "10", "-10")]
        public void DiscountReducesPriceByCertainAmount(string price, string discountValue, string discountedPrice)
        {
            var pricingPolicy = CreateTestedPolicy(decimal.Parse(discountValue, CultureInfo.InvariantCulture));

            pricingPolicy.Apply(Money.Of(decimal.Parse(price, CultureInfo.InvariantCulture), Currency.PLN))
                .Should().Be(Money.Of(decimal.Parse(discountedPrice, CultureInfo.InvariantCulture), Currency.PLN));
        }

        private static IPricingPolicy CreateTestedPolicy(decimal discountValue)
        {
            var policyType = TestHelpers.GetType("ValueDiscount");
            var constructor = policyType.GetConstructor(new[] {typeof(decimal)});
            constructor.Should().NotBeNull("ValueDiscount should have constructor with single decimal argument");
            return (IPricingPolicy) constructor.Invoke(new object[] {discountValue});
        }
    }
}