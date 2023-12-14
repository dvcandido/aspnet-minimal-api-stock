using Microsoft.EntityFrameworkCore;

namespace Stock.Api.Models
{
    public class StockContext(DbContextOptions<StockContext> options) : DbContext(options)
    {
        public DbSet<Product> Product => Set<Product>();
        public DbSet<StockInput> StockInput => Set<StockInput>();
        public DbSet<StockOutput> StockOutput => Set<StockOutput>();
    }

}