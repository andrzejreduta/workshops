using System;

namespace Exercises._01_Types
{
    public readonly struct Money
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public static Money Zero(Currency currency) => new Money(0, currency);

        public static Money Of(decimal value, Currency currency) => new Money(value, currency);

        private Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            CheckCurrencies(this, other);
            return Money.Of(Value + other.Value, Currency);
        }

        public static Money operator *(Money money, decimal multiplier) => Of(money.Value * multiplier, money.Currency);
        public static Money operator +(Money x, Money y) => x.Add(y);

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