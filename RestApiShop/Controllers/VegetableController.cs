using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : GenericControllerBase<VegetableDto, Vegetable>
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Vegetable> _repository;
        private readonly DiscountService _discountService;
        public VegetableController(IMapper mapper, GenericRepository<Vegetable> repository, DiscountService discountService) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _discountService = discountService;
        }

        [HttpGet]
        public override async Task<IEnumerable<VegetableDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<VegetableDto>>(entities);

            foreach (var dto in dtos)
            {
                if (dto.Price.HasValue)
                {
                    dto.Price = _discountService.CalculatePriceAfterDiscount(dto.Price.Value);
                }
            }

            return dtos;
        }
    }
}