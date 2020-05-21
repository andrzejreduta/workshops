using System;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Exercises._08_Exceptions
{
    public class CancelOrderHandlerTests
    {
        private readonly FakeLogger _logger;
        private readonly FakeDatabase _database;
        private readonly CancelOrderHandler _handler;

        public CancelOrderHandlerTests()
        {
            _logger = new FakeLogger();
            _database = new FakeDatabase();
            _handler = new CancelOrderHandler(new OrderRepository(_database), _logger);
        }

        [Fact]
        public void SuccessIsReturnedIfOrderIsCanceled()
        {
            var id = Guid.NewGuid();
            _database.Save(Order.Restore(id, OrderStatus.New));
            var result = _handler.Handle(id);
            result.Should().Be(Result.Success);
            _database.Get<Order>(id).Status.Should().Be(OrderStatus.Canceled);
        }

        [Fact]
        public void FailureIsReturnedIfOrderIsMissing()
        {
            var id = Guid.NewGuid();
            var result = _handler.Handle(id);
            result.Should().Be(Result.Failure);
        }

        [Fact]
        public void WarningIsLoggedIfOrderIsMissing()
        {
            var id = Guid.NewGuid();
            _handler.Handle(id);
            VerifyLog(LogLevel.Warning, $"Missing order with id: {id}");
        }

        [Fact]
        public void ErrorIsLoggedIfDbIsUnavailable()
        {
            var id = Guid.NewGuid();
            _database.FailedAttempts = 5;
            _handler.Handle(id).Should().Be(Result.Failure);
            VerifyLog<DbUnavailableException>(LogLevel.Error, "Db is unavailable");
        }

        [Fact]
        public void CriticalIsLoggedIfUnexpectedExceptionWasThrown()
        {
            var id = Guid.NewGuid();
            _database.UnexpectedError = true;
            _handler.Handle(id).Should().Be(Result.Failure);
            VerifyLog<NullReferenceException>(LogLevel.Critical, "Bug in the code!!!");
        }

        private void VerifyLog(LogLevel level, string message) =>
            _logger.Logs.Should().ContainSingle(l =>
                l.Level == level &&
                l.Exception == null &&
                l.Message == message);

        private void VerifyLog<TException>(LogLevel level, string message)=>
            _logger.Logs.Should().ContainSingle(l =>
                l.Level == level &&
                l.Exception is TException &&
                l.Message == message);
    }
}