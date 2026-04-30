using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Code).IsRequired();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.Stock).IsRequired();
                entity.HasIndex(p => p.Code).IsUnique();
            });
        }
    }
}