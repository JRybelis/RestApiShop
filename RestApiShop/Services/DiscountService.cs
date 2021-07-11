using System;

namespace RestApiShop.Services
{
    public class DiscountService
    {
        private int _discountPercentage;

        public decimal CalculateDiscount(decimal price, int? quantity)
        {
            try
            {
                _discountPercentage = quantity switch
                {
                    >= 5 => 20,
                    < 5 and > 0 => 10,
                    _ => _discountPercentage
                };
            }
            
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            return price / 100 * _discountPercentage;
        }
    }

}
