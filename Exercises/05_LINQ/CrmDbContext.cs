using Microsoft.EntityFrameworkCore;

namespace Exercises._05_LINQ
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CrmDbContext()
            : base(new DbContextOptionsBuilder<CrmDbContext>()
                .UseInMemoryDatabase("Crm").Options) { }
    }
}