using System.Linq;
using RestApiShop.Data;
using RestApiShop.Entities.ShopItems;

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
