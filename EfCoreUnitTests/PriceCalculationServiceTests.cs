using Core.Dtos.Vegetable;
using FluentAssertions;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class PriceCalculationServiceTests
    {
        [Fact]
        public void ApplyDiscount_GivenRegularPrice_CalculateCorrectFinalPrice()
        {
            var vegetable = new VegetableDto(){
                Price = 3.0M};
            //Arrange
            var discountService = new DiscountService();
            
            var priceCalculationService = new PriceCalculationService<VegetableDto>(discountService);

            //Act
            var discountedVegetablePrice = priceCalculationService.ApplyDiscount(vegetable, 1);

            //Assert
            discountedVegetablePrice.Should().Be(2.7M);
        }
    }
}
