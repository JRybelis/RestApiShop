using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiShop.Dtos.Base;

namespace RestApiShop.Services
{
    public class PurchasingService<TDto> where TDto : ShopItemDto
    {
        private readonly PriceCalculationService<TDto> _priceCalculationService;

        public PurchasingService(PriceCalculationService<TDto> priceCalculationService)
        {
            _priceCalculationService = priceCalculationService;
        }

        public TDto Buy(TDto tDto, int quantity)
        {
            if (quantity < tDto.Quantity)
            {
                tDto.Quantity -= quantity;
                tDto.Price = _priceCalculationService.ApplyDiscount(tDto, tDto.Quantity);
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    $"Amount requested ({quantity}) cannot exceed the current stock level of {tDto.Name}: {tDto.Quantity}.");
            }
            
            return tDto;
        }
    }
}
