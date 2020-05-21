using System;
using Exercises._01_Types;

namespace Exercises._03_LambdaExpressions
{
    public class CustomConditionalPricingPolicy : ConditionalPricingPolicy
    {
        private readonly Func<Money, bool> _condition;
        
        public CustomConditionalPricingPolicy(IPricingPolicy policy, Func<Money, bool> condition) : base(policy)
        {
            _condition = condition;
        }

        protected override bool CheckCondition(Money price) => _condition(price);
    }
}