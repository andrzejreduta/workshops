using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Exercises._05_LINQ
{
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _customerRepository;
        
        public CustomerRepositoryTests()
        {
            var dbContext = new CrmDbContext();
            CrmDb.EnsureSeedData(dbContext);
            _customerRepository = new CustomerRepository(dbContext);
            dbContext.SaveChanges();
        }
        
        [Fact]
        public void InMemoryTransformationsTest()
        {
            var methodInfo = typeof(CustomerRepository).GetMethod("GetThreeRecentlyAddedCustomersFromWarsaw");
            methodInfo.Should()
                .NotBeNull("Missing GetThreeRecentlyAddedCustomersFromWarsaw method in CustomerRepository");
            ((IEnumerable<string>)methodInfo.Invoke(_customerRepository, new object[0]))
                .Should().ContainInOrder("Testowy 20", "Testowy 15", "Testowy 10");
        }
    }
}