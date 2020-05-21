using System;
using System.Collections.Generic;
using Exercises._01_Types;
using FluentAssertions;
using Xunit;

namespace Exercises._04_Collections
{
    public class OfferTests
    {
        [Fact]
        public void OfferItemsAreReadOnly()
        {
            var offer = new Offer(Currency.PLN);
            Action action = () =>
            {
                var editableCollection = (ICollection<(ProductId ProductId, Money Price)>) offer.Items;
                editableCollection.Add((ProductId.New(), Money.Of(10, Currency.PLN)));
            };
            action.Should().Throw<Exception>();
        }
    }
}