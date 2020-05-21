using System;
using System.Threading.Tasks;
using Exercises._01_Types;
using FluentAssertions;
using Xunit;

namespace Exercises._10_AsyncAwait
{
    public class CalculateCurrentPriceHandlerTests
    {
        private readonly CalculatePriceHandler _handler;

        public CalculateCurrentPriceHandlerTests()
        {
            _handler = new CalculatePriceHandler(new ISupplierService[]
            {
                new SupplierAbcService(),
                new SupplierDefService(),
                new SupplierGhiService(),
            });
        }

        [Fact]
        public async Task TakeFirstOfferPolicyIsSupported()
        {
            var price = await _handler.Handle(Guid.NewGuid(), PriceCalculationPolicy.TakeFirstOffer);
            price.Should().Be(Money.Of(24m, Currency.PLN));
        }
        
        [Fact]
        public async Task TakeBestOfferPolicyIsSupported()
        {
            var price = await _handler.Handle(Guid.NewGuid(), PriceCalculationPolicy.TakeBestOffer);
            price.Should().Be(Money.Of(9.6m, Currency.PLN));
        }

        private class SupplierAbcService : ISupplierService
        {
            public async Task<Money> GetPriceFor(ProductId productId)
            {
                await Task.Delay(100);
                return Money.Of(10, Currency.PLN);
            }
        }

        private class SupplierDefService : ISupplierService
        {
            public async Task<Money> GetPriceFor(ProductId productId)
            {
                await Task.Delay(50);
                return Money.Of(20, Currency.PLN);
            }
        }

        private class SupplierGhiService : ISupplierService
        {
            public async Task<Money> GetPriceFor(ProductId productId)
            {
                await Task.Delay(200);
                return Money.Of(8, Currency.PLN);
            }
        }
    }
}