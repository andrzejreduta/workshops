using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises._05_LINQ
{
    public class CustomerRepository
    {
        private readonly CrmDbContext _dbContext;

        public CustomerRepository(CrmDbContext dbContext) => _dbContext = dbContext;

        public IEnumerable<Customer> GetAll() => _dbContext.Customers.ToList();
        
        public IEnumerable<string> GetThreeRecentlyAddedCustomersFromWarsaw() => _dbContext.Customers
            .Where(customer => customer.Address.City.Equals("Warszawa", StringComparison.InvariantCultureIgnoreCase))
            .OrderByDescending(customer => customer.AddedOn)
            .Take(3)
            .Select(customer => customer.Name);
    }
}