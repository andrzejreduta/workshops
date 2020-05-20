using System;

namespace Exercises._01_Types
{
    public readonly struct ProductId : IEquatable<ProductId>
    {
        public Guid Value { get; }

        public static ProductId New() => new ProductId(Guid.NewGuid());

        public static ProductId Of(string value) => Of(Guid.Parse(value));

        public static ProductId Of(Guid value) => new ProductId(value);

        private ProductId(Guid value) => Value = value;

        public bool Equals(ProductId other) => Value.Equals(other.Value);

        public override bool Equals(object obj) => obj is ProductId other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString().ToUpper();
    }
}