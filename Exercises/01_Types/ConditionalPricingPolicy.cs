namespace Exercises._01_Types
{
    public abstract class ConditionalPricingPolicy : IPricingPolicy
    {
        private readonly IPricingPolicy _policy;

        protected ConditionalPricingPolicy(IPricingPolicy policy) => _policy = policy;

        public Money Apply(Money price) => CheckCondition(price)
            ? _policy.Apply(price)
            : price;

        protected abstract bool CheckCondition(Money price);
    }
}