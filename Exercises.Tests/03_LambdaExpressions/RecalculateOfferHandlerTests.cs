using Exercises._01_Types;
using Moq;
using Xunit;

namespace Exercises._03_LambdaExpressions
{
    public class RecalculateOfferHandlerTests
    {
        private readonly Mock<IPricingService> _pricingServiceMock = new Mock<IPricingService>();
        
        [Fact]
        public void CorrectPricingPolicyIsUsed()
        {
            var handler = new RecalculateOfferHandler(_pricingServiceMock.Object);
            var offer = new Offer(Currency.PLN);
            handler.Handle(offer);
            _pricingServiceMock.Verify(s => s.RecalculateOffer(offer, PricingPolicies.TenPercentageDiscount));
        }
    }
}