using System.Collections.Generic;
using System.Text;

namespace Exercises._01_Types
{
    public class Offer
    {
        private readonly List<(ProductId ProductId, Money Price)> _items =
            new List<(ProductId ProductId, Money Price)>();

        public IEnumerable<(ProductId ProductId, Money Price)> Items => _items;
        
        public Money TotalPrice { get; private set; }
        
        public Currency Currency => TotalPrice.Currency;

        public Offer(Currency currency) => TotalPrice = Money.Zero(currency);

        public void AddItem(ProductId productId, Money price)
        {
            _items.Add((productId, price));
            TotalPrice += price;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var (productId, price) in _items)
            {
                builder.AppendLine($"{productId.ToString()}: {price.ToString()}");
            }
            return builder.ToString();
        }
    }
}