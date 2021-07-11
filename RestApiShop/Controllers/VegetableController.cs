using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<Vegetable> _repository;
        private readonly PurchasingService<VegetableDto> _purchasingService;


        public VegetableController(IMapper mapper, IGenericRepository<Vegetable> repository, PurchasingService<VegetableDto> purchasingService)
        {
            _mapper = mapper;
            _repository = repository;
            _purchasingService = purchasingService;
        }

        [HttpGet]
        public async Task<IEnumerable<VegetableDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<VegetableDto>>(entities);
            //var updatedDtos = dtos.Select(d => _priceCalculation.ApplyDiscount(d));

            //return updatedDtos;
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

            return _purchasingService.Buy(itemDto, quantity);
        }
    }

}