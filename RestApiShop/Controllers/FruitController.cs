using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Entities.Base;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ShopItemController
    {
        public FruitController(IMapper mapper, GenericRepository<Item> repository, PriceCalculationService priceCalculation) : base(mapper, repository, priceCalculation)
        {
        }
    }
}