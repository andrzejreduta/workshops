using Exercises._01_Types;

namespace Exercises._03_LambdaExpressions
{
    public class RecalculateOfferHandler
    {
        private readonly IPricingService _pricingService;

        public RecalculateOfferHandler(IPricingService pricingService) => _pricingService = pricingService;

        public Offer Handle(Offer offer) =>
            _pricingService.RecalculateOffer(offer, PricingPolicies.TenPercentageDiscount);
    }
}