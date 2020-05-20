using FluentAssertions;
using Xunit;

namespace Exercises._01_Types
{
    public class OfferTests
    {
        [Fact]
        public void TotalPriceIsSumOfAllItemPrices()
        {
            var offer = new Offer(Currency.PLN);
            offer.AddItem(
                ProductId.Of("34DA18AC-3FC6-431D-87E0-2DF8869760D3"),
                Money.Of(100, Currency.PLN));
            offer.AddItem(
                ProductId.Of("B2335ED7-13AF-47E2-8F83-7967D05366DF"),
                Money.Of(25.50m, Currency.PLN));

            offer.TotalPrice.Should().Be(Money.Of(125.50m, Currency.PLN));
        }

        [Fact]
        public void ToStringReturnProductsAndPrices()
        {
            var offer = new Offer(Currency.PLN);
            offer.AddItem(ProductId.Of("19E215BA-9E52-4933-9860-18BEE20B0068"), Money.Of(123.45m, Currency.PLN));
            offer.AddItem(ProductId.Of("5379199E-68F0-4464-8E89-28952F1DF1A9"), Money.Of(1.99m, Currency.PLN));
            offer.AddItem(ProductId.Of("FA6F52CE-0ABE-4073-9344-AE0F83E2A6B9"), Money.Of(1234567.00m, Currency.PLN));

            offer.ToString().Should().Be(@"19E215BA-9E52-4933-9860-18BEE20B0068: 123.45 PLN
5379199E-68F0-4464-8E89-28952F1DF1A9: 1.99 PLN
FA6F52CE-0ABE-4073-9344-AE0F83E2A6B9: 1,234,567.00 PLN
");
        }
    }
}