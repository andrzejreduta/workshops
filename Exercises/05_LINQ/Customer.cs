using System;

namespace Exercises._05_LINQ
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public Address Address { get; set; }
    }
}