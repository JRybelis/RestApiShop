using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Repositories;
using RestApiShop.Services;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : GenericControllerBase<CrockeryDto, Crockery>
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Crockery> _repository;
        private readonly DiscountService _discountService;
        public CrockeryController(IMapper mapper, GenericRepository<Crockery> repository, DiscountService discountService) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
            _discountService = discountService;
        }

        [HttpGet]
        public override async Task<IEnumerable<CrockeryDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CrockeryDto>>(entities);

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
