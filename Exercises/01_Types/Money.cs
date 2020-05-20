using System;

namespace Exercises._01_Types
{
    public struct Money
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; }

        public static Money Zero(Currency currency) => new Money(0, currency);

        public static Money Of(decimal value, Currency currency) => new Money(value, currency);

        private Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public void Add(Money other)
        {
            CheckCurrencies(this, other);
            Value += other.Value;
        }

        public static Money operator *(Money money, decimal multiplier) => Of(money.Value * multiplier, money.Currency);

        private static void CheckCurrencies(Money x, Money y)
        {
            if (x.Currency != y.Currency)
                throw new DomainException();
        }

        public bool Equals(Money other) => Value == other.Value && Currency == other.Currency;

        public override bool Equals(object obj) => obj is Money other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Value, (int) Currency);

        public override string ToString() => $"{Value.ToString("N2")} {Currency.ToString()}";
    }
}