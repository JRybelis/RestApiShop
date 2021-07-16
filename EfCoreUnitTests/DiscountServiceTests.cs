using System;
using FluentAssertions;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class DiscountServiceTests
    {
        [Theory]
        [InlineData(3M, typeof(new DiscountService()), 5)]
        [InlineData(4M, typeof(new DiscountService()), 2)]
        [InlineData()] 
        public void CalculateDiscount_GivenRegularPrice_CalculatesCorrectDiscount(decimal price, DiscountService discountService, int quantity)
        {
            // Arrange
            var price = 3.0M;
            var discountService = new DiscountService();

            // Act
            var returnedDiscount = discountService.CalculateDiscount(price, 5);

            // Assert
            returnedDiscount.Should().Be(0.6M);
        }
    }
}
