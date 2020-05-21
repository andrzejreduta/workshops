using Exercises._01_Types;

namespace Exercises._03_LambdaExpressions
{
    public interface IPricingService
    {
        Offer RecalculateOffer(Offer offer, PricingPolicy pricingPolicy);
    }
}