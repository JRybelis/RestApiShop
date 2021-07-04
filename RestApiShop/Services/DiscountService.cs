using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RestApiShop.Services
{
    public class DiscountService
    {
        private const int DiscountPercentage = 10;

        public decimal CalculateDiscount(decimal price)
        {
            return price / 100 * DiscountPercentage;
        }
    }
}
