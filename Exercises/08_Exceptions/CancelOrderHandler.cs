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
            throw new NotImplementedException();
        }
    }
}