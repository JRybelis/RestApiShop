using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Dtos.Base;
using RestApiShop.Entities.Base;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : GenericControllerBase<ShopItemDto, Item>
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Item> _repository;
        private readonly PriceCalculationService _priceCalculation;

        public ShopItemController(IMapper mapper, GenericRepository<Item> repository, PriceCalculationService priceCalculation) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculation = priceCalculation;
        }

        [HttpGet]
        public override async Task<IEnumerable<ShopItemDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ShopItemDto>>(entities);
            var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));
            return updatedDtos;
        }
    }
}
