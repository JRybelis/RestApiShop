using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities.ShopItems;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : GenericControllerBase<CrockeryDto, Crockery>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Crockery> _repository;
        private readonly PriceCalculationService<CrockeryDto> _priceCalculation;

        public CrockeryController(IMapper mapper, IGenericRepository<Crockery> repository, PriceCalculationService<CrockeryDto> priceCalculation) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculation = priceCalculation;
        }

        [HttpGet]
        public override async Task<IEnumerable<CrockeryDto>> GetAll()
        {
        var entities = await _repository.GetAll();
        var dtos = _mapper.Map<IEnumerable<CrockeryDto>>(entities);
        var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));
        
        return updatedDtos;
        }
    }

}
