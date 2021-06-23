using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Models;

namespace RestApiShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Crockery> CrockeryItems { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (!Shops.Any())
            //{
            //    Shops.Add(new Shop()
            //    {
            //        Name = "Default Shop"
            //    });
            //}
        }

    }
}
