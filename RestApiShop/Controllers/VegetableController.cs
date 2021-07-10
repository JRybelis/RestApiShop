using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Data;
using RestApiShop.Dtos.Base;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities.ShopItems;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly IMapper _mapper;
        private DataContext _context;
        private readonly IGenericRepository<Vegetable> _repository;
        private readonly PriceCalculationService<VegetableDto> _priceCalculation;

        public VegetableController(IMapper mapper, IGenericRepository<Vegetable> repository, PriceCalculationService<VegetableDto> priceCalculation, DataContext context)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculation = priceCalculation;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<VegetableDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<VegetableDto>>(entities);
            var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));

            return updatedDtos;
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
        public decimal Buy(BuyItemDto buyItemDto)
        {
            var item = _context.Vegetables.FirstOrDefault(v => v.Name == buyItemDto.ItemName);
            var totalPrice = item.Price * buyItemDto.Quantity;

            return totalPrice;
        }
    }

}