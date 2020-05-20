namespace Exercises._01_Types
{
    public interface IPricingPolicy
    {
        Money Apply(Money price);
    }
}