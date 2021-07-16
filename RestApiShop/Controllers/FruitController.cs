using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Fruit;
using Core.Entities.ShopItems;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Interfaces;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : GenericControllerBase<FruitDto, Fruit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Fruit> _repository;
        private readonly PriceCalculationService<FruitDto> _priceCalculation;

        public FruitController(IMapper mapper, IGenericRepository<Fruit> repository,
            PriceCalculationService<FruitDto> priceCalculation) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculation = priceCalculation;
        }

        [HttpGet]

        public override async Task<IEnumerable<FruitDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<FruitDto>>(entities);
            //var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));

            //return updatedDtos;
            return dtos;
        }
    }
}
    