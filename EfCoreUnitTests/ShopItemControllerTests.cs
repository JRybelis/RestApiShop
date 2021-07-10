using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Controllers;
using RestApiShop.Data;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Entities.ShopItems;
using RestApiShop.Mappings;
using RestApiShop.Repositories;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class CrockeryControllerTests
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
            var priceCalculationService = new PriceCalculationService<CrockeryDto>(discountService);
            var mockContext = new DataContext(GetInMemoryDbContextOptions());
            mockContext.Shops.Add(new Shop() {Id = 99});
            mockContext.SaveChanges();
            var repository = new GenericRepository<Crockery>(mockContext);
            var crockeryController = new CrockeryController(mapper, repository, priceCalculationService);
            var crockeryDto = new CrockeryDto()
            {
                Name = "TestCrockery",
                Price = 3.00M,
                ShopId = 1
            };

            //Arrange end
            //Act

            await crockeryController.Upsert(crockeryDto);
            var results = await crockeryController.GetAll();

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
