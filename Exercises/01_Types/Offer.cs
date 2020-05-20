using System.Collections.Generic;

namespace Exercises._01_Types
{
    public class Offer
    {
        private readonly List<(ProductId ProductId, Money Price)> _items =
            new List<(ProductId ProductId, Money Price)>();

        public IEnumerable<(ProductId ProductId, Money Price)> Items => _items;
        
        public Money TotalPrice { get; }
        
        public Currency Currency => TotalPrice.Currency;

        public Offer(Currency currency) => TotalPrice = Money.Zero(currency);

        public void AddItem(ProductId productId, Money price)
        {
            _items.Add((productId, price));
            TotalPrice.Add(price);
        }
    }
}