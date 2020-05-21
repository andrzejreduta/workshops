using FluentAssertions;
using Xunit;

namespace Exercises._05_LINQ
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            var dbContext = new CrmDbContext();
            CrmDb.EnsureSeedData(dbContext);
            var customerRepository = new CustomerRepository(dbContext);
            _customerService = new CustomerService(customerRepository);
        }

        [Fact]
        public void RecentlyAddedCustomersFromWarsawTest()
        {
            _customerService.GetThreeRecentlyAddedCustomersFromWarsaw().Should().ContainInOrder(
                "Testowy 20", "Testowy 15", "Testowy 10");
        }
    }
}