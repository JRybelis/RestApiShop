using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Controllers.Base;
using RestApiShop.Data;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Entities.Base;
using RestApiShop.Mappings;
using RestApiShop.Repositories;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class ShopItemControllerTests
    {
        [Fact]
        public async Task Test()
        {
            //Arrange

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService(discountService);
            var mockContext = new DataContext(GetInMemoryDbContextOptions());
            mockContext.Shops.Add(new Shop() {Id = 1});
            var repository = new GenericRepository<Item>(mockContext);
            var shopItemController = new ShopItemController(mapper, repository, priceCalculationService);
            var crockeryDto = new CrockeryDto()
            {
                Name = "TestCrockery",
                Price = 3.00M,
                ShopId = 1
            };

            //Arrange end
            //Act

            await shopItemController.Upsert(crockeryDto);
            var results = await shopItemController.GetAll();

            //Assert

            results.Should().NotBeEmpty();
            results.First().Price.Should().Be(2.70M);

        }

        public static DbContextOptions<DataContext> GetInMemoryDbContextOptions(string dbName = "Test")
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
    }
}
