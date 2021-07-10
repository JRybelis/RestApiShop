using FluentAssertions;
using RestApiShop.Dtos.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class PriceCalculationServiceTests
    {
        [Fact]
        public void ApplyDiscount_GivenRegularPrice_CalculateCorrectFinalPrice()
        {
            var crockeryItem = new CrockeryDto(){
                Price = 3.0M};
            //Arrange
            var discountService = new DiscountService();
            
            var priceCalculationService = new PriceCalculationService<CrockeryDto>(discountService);

            //Act
            var discountedCrockeryItem = priceCalculationService.ApplyDiscount(crockeryItem);

            //Assert
            discountedCrockeryItem.Price.Should().Be(2.7M);
        }
    }
}
