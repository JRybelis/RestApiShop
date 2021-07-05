using System;
using FluentAssertions;
using RestApiShop.Services;
using Xunit;

namespace EfCoreUnitTests
{
    public class DiscountServiceTests
    {
        [Fact]
        public void CalculateDiscount_GivenRegularPrice_CalculatesCorrectDiscount()
        {
            // Arrange
            var price = 3.0M;
            var discountService = new DiscountService();

            // Act
            var returnedDiscount = discountService.CalculateDiscount(price);

            // Assert
            returnedDiscount.Should().Be(0.3M);
        }
    }
}
