using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Data;
using RestApiShop.Dtos.Shop;
using RestApiShop.Entities;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public ShopController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShopDto>> GetAll()
        {
            var entities = await _context.Shops.ToListAsync();    
            var dtos = _mapper.Map<List<ShopDto>>(entities);

            return dtos;
        }

        [HttpGet("{id}")]
        public async Task<ShopDto> GetById(int id)
        {
            var entity = await _context.Shops.FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            var dto = _mapper.Map<ShopDto>(entity);

            return dto;
        }

        [HttpPost]
        public async Task Create(ShopDto shop)
        {
            var dto = _mapper.Map<Shop>(shop);

            _context.Shops.Add(dto);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(ShopPutDto shop)
        {
            var dto = _mapper.Map<Shop>(shop);

            _context.Shops.Update(dto);
            await _context.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var shop =  await _context.Shops.FirstOrDefaultAsync(s => s.Id == id);

            if (shop == null)
            {
                throw new KeyNotFoundException();
            }
            
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
        }
    }
}
