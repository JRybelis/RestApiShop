using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Entities.Base;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : ShopItemController
    {
        public CrockeryController(IMapper mapper, GenericRepository<Item> repository, PriceCalculationService priceCalculation) : base(mapper, repository, priceCalculation)
        {
        }
            //    [HttpGet]
    //    public override async Task<IEnumerable<CrockeryDto>> GetAll()
    //    {
    //        var entities = await _repository.GetAll();
    //        var dtos = _mapper.Map<IEnumerable<CrockeryDto>>(entities);
    //        var updatedDtos = dtos.Select(d => _crockeryPriceCalculation.ApplyDiscount(d));
            
    //        return updatedDtos;
    //    }
    }

}
