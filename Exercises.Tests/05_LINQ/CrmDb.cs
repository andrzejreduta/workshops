using System;
using System.Collections.Generic;

namespace Exercises._05_LINQ
{
    internal static class CrmDb
    {
        private static readonly object Lock = new object();
        private static bool _hasSeedData;

        public static void EnsureSeedData(CrmDbContext dbContext)
        {
            lock (Lock)
            {
                if (_hasSeedData)
                    return;
                dbContext.Customers.AddRange(CreateSeedData());
                dbContext.SaveChanges();
                _hasSeedData = true;
            }
        }

        private static IEnumerable<Customer> CreateSeedData()
        {
            for (var i = 1; i <= 20; i++)
            {
                yield return new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = $"Testowy {i}",
                    AddedOn = new DateTime(2020, 1, i),
                    Address = new Address
                    {
                        Street = $"Testowa {i}",
                        City = GetCity(i)
                    }
                };
            }
        }

        private static string GetCity(int index) => (index % 5) switch
        {
            0 => "Warszawa",
            1 => "Kraków",
            2 => "Poznań",
            3 => "Gdańsk",
            4 => "Wrocław"
        };
    }
}