using System;
using FluentAssertions;
using Xunit;

namespace Exercises._08_Exceptions
{
    public class OrderRepositoryTests
    {
        private readonly FakeDatabase _database;
        private readonly OrderRepository _repository;

        public OrderRepositoryTests()
        {
            _database = new FakeDatabase();
            _repository = new OrderRepository(_database);
        }

        [Fact]
        public void CanGetOrderIfDbIsAvailable()
        {
            var id = Guid.NewGuid();
            _database.Save(Order.Restore(id, OrderStatus.Placed));
            var order = _repository.GetBy(id);
            order.Should().NotBeNull();
            order.Id.Should().Be(id);
            order.Status.Should().Be(OrderStatus.Placed);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        public void CanGetOrderIfDbIsUnavailableAvailableUpToThreeTimes(int failedAttempts, bool success)
        {
            var id = Guid.NewGuid();
            _database.FailedAttempts = failedAttempts;
            _database.Save(Order.Restore(id, OrderStatus.Placed));
            if (success)
            {
                var order = _repository.GetBy(id);
                order.Should().NotBeNull();
                order.Id.Should().Be(id);
                order.Status.Should().Be(OrderStatus.Placed);
            }
            else
            {
                Action action = () => _repository.GetBy(id);
                action.Should().ThrowExactly<DbUnavailableException>();
            }
        }

        [Fact]
        public void RecordNotFoundIsThrownIfThereAreNoEntityWithGivenId()
        {
            var id = Guid.NewGuid();
            Action action = () => _repository.GetBy(id);
            action.Should().ThrowExactly<RecordNotFoundException>();
        }
    }
}