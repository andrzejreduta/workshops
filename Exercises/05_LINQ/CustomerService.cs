using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises._05_LINQ
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository) => _customerRepository = customerRepository;

        public IEnumerable<string> GetThreeRecentlyAddedCustomersFromWarsaw() => _customerRepository
            .GetAll()
            .Where(customer => customer.Address.City.Equals("Warszawa", StringComparison.InvariantCultureIgnoreCase))
            .OrderByDescending(customer => customer.AddedOn)
            .Take(3)
            .Select(customer => customer.Name);

        public IEnumerable<string> GetThreeRecentlyAddedCustomersFromWarsaw2() => _customerRepository
            .GetThreeRecentlyAddedCustomersFromWarsaw(customer =>
                customer.Address.City.Equals("Warszawa", StringComparison.InvariantCultureIgnoreCase));
    }
}