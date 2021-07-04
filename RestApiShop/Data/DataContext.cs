using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Entities;

namespace RestApiShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            if (!Shops.Any())
            {
                Shops.Add(new Shop()
                {
                    Name = "Default Shop"
                });
                SaveChanges();
            }

            if (!CrockeryItems.Any())
            {
                CrockeryItems.Add(new Crockery()
                {
                    Name = "Default crockery set",
                    ShopId = 2
                });
                SaveChanges();
            }

            if (!Fruits.Any())
            {
                Fruits.Add(new Fruit()
                {
                    Name = "Random fruit",
                    ShopId = 2
                });
                SaveChanges();
            }

            if (!Vegetables.Any())
            {
                Vegetables.Add(new Vegetable()
                {
                    Name = "Random vegetable",
                    ShopId = 2
                });
                SaveChanges();
            }
        }
        
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Crockery> CrockeryItems { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BaseEntity>()
            //    .HasKey(s => s.Id);
            
            //modelBuilder.Entity<BaseEntity>()
            //    .Property(e => e.Name).HasMaxLength(51).IsRequired();

            modelBuilder.Entity<Shop>()
                .HasKey(s => s.Id);
            
            modelBuilder.Entity<Crockery>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Fruit>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Vegetable>()
                .HasKey(v => v.Id);
            
            
            modelBuilder.Entity<Shop>()
                .Property(s => s.Name)
                .HasMaxLength(51)
                .IsRequired();

            modelBuilder.Entity<Crockery>()
                .Property(c => c.Name)
                .HasMaxLength(51)
                .IsRequired();

            modelBuilder.Entity<Fruit>()
                .Property(f => f.Name)
                .HasMaxLength(51)
                .IsRequired();

            modelBuilder.Entity<Vegetable>()
                .Property(v => v.Name)
                .HasMaxLength(51)
                .IsRequired();


            modelBuilder.Entity<Crockery>()
                .Property(c => c.Price)
                .IsRequired()
                .HasPrecision(9, 2);

            modelBuilder.Entity<Fruit>()
                .Property(f => f.Price)
                .IsRequired()
                .HasPrecision(9, 2);

            modelBuilder.Entity<Vegetable>()
                .Property(v => v.Price)
                .IsRequired()
                .HasPrecision(9, 2);


            modelBuilder.Entity<Shop>()
                .HasMany(s => s.CrockeryItems)
                .WithOne(c => c.Shop)
                .HasForeignKey(c => c.ShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Fruits)
                .WithOne(f => f.Shop)
                .HasForeignKey(f => f.ShopId);

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Vegetables)
                .WithOne(v => v.Shop)
                .HasForeignKey(v => v.ShopId);
        }

    }
}
