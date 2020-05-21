using System;
using Microsoft.Extensions.Logging;

namespace Exercises._08_Exceptions
{
    public class CancelOrderHandler
    {
        private readonly OrderRepository _repository;
        private readonly ILogger _logger;

        public CancelOrderHandler(OrderRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Result Handle(Guid id)
        {
            try
            {
                var order = _repository.GetBy(id);
                order.Cancel();
                _repository.Save(order);
                return Result.Success;
            }
            catch (RecordNotFoundException)
            {
                _logger.Log(LogLevel.Warning, $"Missing order with id: {id}");
                return Result.Failure;
            }
            catch (DbUnavailableException dbUnavailableException)
            {
                _logger.Log(LogLevel.Error, dbUnavailableException, "Db is unavailable");
                return Result.Failure;
            }
            catch (Exception unexpectedException)
            {
                _logger.Log(LogLevel.Critical, unexpectedException, $"Bug in the code!!!");
                return Result.Failure;
            }
        }
    }
}