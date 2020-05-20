using System;
using System.Globalization;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace Exercises._01_Types
{
    public class DiscountUpTo50EurTests
    {
        [Theory]
        [InlineData("49.99", "48.99")]
        [InlineData("1", "0")]
        [InlineData("0", "-1")]
        [InlineData("-10", "-11")]
        public void DiscountIsAppliedForPricesUpTo50Eur(string value, string discountedValue)
        {
            var pricingPolicy = CreateTestedPolicy();
            var discountedPrice = pricingPolicy.Apply(Money.Of(decimal.Parse(value, CultureInfo.InvariantCulture), Currency.EUR));

            discountedPrice.Value.Should().Be(decimal.Parse(discountedValue, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("50")]
        [InlineData("100")]
        [InlineData("100000")]
        public void DiscountIsNotAppliedForPricesOver50Eur(string value)
        {
            var pricingPolicy = CreateTestedPolicy();
            var discountedPrice = pricingPolicy.Apply(Money.Of(decimal.Parse(value, CultureInfo.InvariantCulture), Currency.EUR));

            discountedPrice.Value.Should().Be(decimal.Parse(value, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("49.99", Currency.PLN)]
        [InlineData("49.99", Currency.USD)]
        [InlineData("1", Currency.PLN)]
        [InlineData("1", Currency.USD)]
        [InlineData("0", Currency.PLN)]
        [InlineData("0", Currency.USD)]
        [InlineData("-1", Currency.PLN)]
        [InlineData("-1", Currency.USD)]
        public void DiscountIsNotAppliedForPricesInPlnOrUsd(string value, Currency currency)
        {
            var pricingPolicy = CreateTestedPolicy();
            var discountedPrice = pricingPolicy.Apply(Money.Of(decimal.Parse(value, CultureInfo.InvariantCulture), currency));

            discountedPrice.Value.Should().Be(decimal.Parse(value, CultureInfo.InvariantCulture));
        }

        private static IPricingPolicy CreateTestedPolicy()
        {
            var policyType = TestHelpers.GetType("DiscountUpTo50Eur");
            var constructors = policyType.GetConstructors(BindingFlags.Public);
            constructors.Should().HaveCount(0, "DiscountUpTo50Eur should have only default constructor");
            return (IPricingPolicy) Activator.CreateInstance(policyType);
        }
    }
}