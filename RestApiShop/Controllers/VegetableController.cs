using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities.ShopItems;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : GenericControllerBase<VegetableDto, Vegetable>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Vegetable> _repository;
        private readonly PriceCalculationService<VegetableDto> _priceCalculation;

        public VegetableController(IMapper mapper, IGenericRepository<Vegetable> repository, PriceCalculationService<VegetableDto> priceCalculation) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculation = priceCalculation;
        }

        [HttpGet]
        public override async Task<IEnumerable<VegetableDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<VegetableDto>>(entities);
            var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));

            return updatedDtos;
        }
    }

}