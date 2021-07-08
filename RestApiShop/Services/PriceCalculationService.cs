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

        public TDto ApplyDiscount(TDto tDto)
        {
            if (tDto.Price.HasValue)
            {
                tDto.Price -= _discountService.CalculateDiscount(tDto.Price.Value);
            }
            return tDto;
        }
    }
}
