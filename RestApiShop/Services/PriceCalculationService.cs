using System.Diagnostics;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Services
{
    public class PriceCalculationService<TDto> where TDto : ShopItemDto
    {
        private readonly DiscountService _discountService;

        public PriceCalculationService(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public decimal ApplyDiscount(TDto tDto, int quantity
            )
        {
            if (tDto.Price.HasValue)
            {
                tDto.Price -= _discountService.CalculateDiscount(tDto.Price.Value, quantity);
            }

            Debug.Assert(tDto.Price != null, "tDto.Price != null");
            return tDto.Price.Value;
        }
    }
}
