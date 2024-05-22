using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess.Entities;

namespace VendingMachine.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.Id, p.Name });

            base.OnModelCreating(modelBuilder);
        }

    }
}
