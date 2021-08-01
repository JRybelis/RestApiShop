using System.Linq;
using Core.Entities.ShopItems;
using RestApiShop.Data;

namespace EfCoreUnitTests
{
    public static class DataSeeder
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Vegetables.Any())
            {
                context.Vegetables.Add(new Vegetable()
                {
                    Name = "Default"
                });

                context.SaveChangesAsync();
            }
        }
    }
}
