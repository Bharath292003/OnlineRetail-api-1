using Microsoft.EntityFrameworkCore;

namespace onlineRetail.Model
{
    public class CombineContext : DbContext

    {
        public CombineContext(DbContextOptions<CombineContext> options) : base(options)
        {


        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> product { get; set; }
    }
}
