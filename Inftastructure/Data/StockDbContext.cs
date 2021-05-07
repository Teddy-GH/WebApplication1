using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Item>()
                .HasIndex(x => x.Name)
                .IsUnique();
            builder.Entity<ItemCategory>()
                .HasIndex(x => x.Name)
                .IsUnique();
            builder.Entity<MeasureUnit>()
                .HasIndex(x => x.Name)
                .IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
