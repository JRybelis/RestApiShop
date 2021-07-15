using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestApiShop.Controllers;
using RestApiShop.Data;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities.ShopItems;
using RestApiShop.Interfaces;
using RestApiShop.Mappings;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class VegetableControllerTests
    {
        [Fact]
        public async Task ControllerAppliesDiscountGet()
        {
            //Arrange

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var discountService = new DiscountService();
            var priceCalculationService = new PriceCalculationService<VegetableDto>(discountService);

            var autoFixture = new Fixture();
            var vegetable = autoFixture.Build<Vegetable>().With(v => v.Quantity, 1).Create();
            
            var repository = new Mock<IGenericRepository<Vegetable>>();
            repository.Setup(r => r.GetAll()).ReturnsAsync(new List<Vegetable>()
            {
                new Vegetable()
                {
                    Price = 3M
                }
            });

            var vegetableController = new VegetableController(mapper, repository.Object, priceCalculationService);
            var vegetableDto = new VegetableDto()
            {
                Name = "TestVegetable",
                Price = 3.00M,
                ShopId = 1
            };

            //Arrange end
            //Act

            await vegetableController.Upsert(vegetableDto);
            var results = await vegetableController.GetAll();

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

