using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;
using RestApiShop.Entities.Base;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : ShopItemController
    {
        public VegetableController(IMapper mapper, GenericRepository<Item> repository, PriceCalculationService priceCalculation) : base(mapper, repository, priceCalculation)
        {
                
        }
    }
}