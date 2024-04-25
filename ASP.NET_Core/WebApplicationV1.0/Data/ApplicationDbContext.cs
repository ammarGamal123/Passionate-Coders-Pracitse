using Microsoft.EntityFrameworkCore;

namespace WebApplicationV1._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // I assign Product to be mapped in Products Table 
            modelBuilder.Entity<Product>().ToTable("Products").HasKey("Id");
        }
    }
}
