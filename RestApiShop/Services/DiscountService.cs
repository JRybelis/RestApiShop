namespace RestApiShop.Services
{
    public class DiscountService
    {
        private const int DiscountPercentage = 10;

        public decimal CalculateDiscount(decimal price)
        {
            return price / 100 * DiscountPercentage;
        }

        public decimal CalculatePriceAfterDiscount(decimal price)
        {
            return price - CalculateDiscount(price);
        }
    }
}
