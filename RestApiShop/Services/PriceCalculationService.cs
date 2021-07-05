using RestApiShop.Dtos.Base;

namespace RestApiShop.Services
{
    public class PriceCalculationService
    {
        private readonly DiscountService _discountService;

        public PriceCalculationService(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public ShopItemDto ApplyDiscount(ShopItemDto shopItemDto)
        {
            if (shopItemDto.Price.HasValue)
            {
                shopItemDto.Price -= _discountService.CalculateDiscount(shopItemDto.Price.Value);
            }
            return shopItemDto;
        }
    }
}
