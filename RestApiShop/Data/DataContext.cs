using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Entities;
using RestApiShop.Entities.Relational;

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
        public DbSet<ShopOwnerShop> ShopOwnerShops { get; set; }

        public DbSet<Crockery> CrockeryItems { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntityPrimaryKeys(modelBuilder);
            ConfigureEntityProperties(modelBuilder);
            ConfigureEntityRelationships(modelBuilder);
        }
        
        private static void ConfigureEntityPrimaryKeys(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Shop>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<ShopOwner>()
                .HasKey(so => so.Id);

            modelBuilder.Entity<ShopOwnerShop>()
                .HasKey(sos => new {sos.ShopId, sos.ShopOwnerId});
            
            modelBuilder.Entity<Crockery>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Fruit>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Vegetable>()
                .HasKey(v => v.Id);
        }

        private static void ConfigureEntityProperties(ModelBuilder modelBuilder)
        {
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

            
            modelBuilder.Entity<ShopOwner>()
                .Property(so => so.Forename)
                .IsRequired()
                .HasMaxLength(51);


            modelBuilder.Entity<ShopOwner>()
                .Property(so => so.Surname)
                .IsRequired()
                .HasMaxLength(51);
        }

        private static void ConfigureEntityRelationships(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<ShopOwnerShop>()
                .HasOne(s => s.ShopOwner)
                .WithMany(so => so.Shops)
                .HasForeignKey(s => s.ShopOwnerId);

            modelBuilder.Entity<ShopOwnerShop>()
                .HasOne(so => so.Shop)
                .WithMany(s => s.ShopOwners)
                .HasForeignKey(so => so.ShopId);

        }
    }   

}
