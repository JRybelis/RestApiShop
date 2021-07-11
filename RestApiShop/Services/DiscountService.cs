namespace RestApiShop.Services
{
    public class DiscountService
    {
        private int _discountPercentage;

        public decimal CalculateDiscount(decimal price, int? quantity)
        {
            _discountPercentage = quantity switch
            {
                >= 5 => 20,
                < 5 and > 0 => 10,
                _ => _discountPercentage
            };

            return price / 100 * _discountPercentage;
        }
    }

}
