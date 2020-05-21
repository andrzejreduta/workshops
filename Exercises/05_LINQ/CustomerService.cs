using System;
using System.Collections.Generic;

namespace Exercises._05_LINQ
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository) => _customerRepository = customerRepository;

        public IEnumerable<string> GetThreeRecentlyAddedCustomersFromWarsaw()
        {
            throw new NotImplementedException();
        }
    }
}