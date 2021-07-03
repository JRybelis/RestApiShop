﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Entities;
using RestApiShop.Entities.Base;

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
            modelBuilder.Entity<Entity>()
                .HasKey(s => s.Id);
            
            modelBuilder.Entity<Entity>()
                .Property(e => e.Name).HasMaxLength(51).IsRequired();

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
