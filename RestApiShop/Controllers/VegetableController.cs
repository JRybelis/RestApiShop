using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Vegetable;
using Core.Entities.ShopItems;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Interfaces;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Vegetable> _repository;
        private readonly PriceCalculationService<VegetableDto> _priceCalculationService;


        public VegetableController(IMapper mapper, IGenericRepository<Vegetable> repository, PriceCalculationService<VegetableDto> priceCalculationService)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculationService = priceCalculationService;
        }

        [HttpGet]
        public async Task<List<VegetableDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<VegetableDto>>(entities);

            dtos.ForEach(d => d.Price = _priceCalculationService.ApplyDiscount(d, 1));
            
            return dtos;
        }

        [HttpGet("{id}")]
        public async Task<VegetableDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<VegetableDto>(entity);
        }

        [HttpPost]
        public async Task Upsert(VegetableDto dto)
        {
            var entity = _mapper.Map<Vegetable>(dto);
            await _repository.Upsert(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        [HttpPost("/buy")]
        public async Task<decimal> Buy(string itemName, int quantity)
        {
            var item = await _repository.GetByName(itemName);
            var itemDto = _mapper.Map<VegetableDto>(item);

            await _repository.UpdateItemQuantity(item, quantity);

            return _priceCalculationService.ApplyDiscount(itemDto, quantity);
        }
    }

}