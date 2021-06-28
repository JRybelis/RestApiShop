using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public List<ShopDto> GetAll()
        {
            var entities = _context.Shops.ToList();    
            var dtos = _mapper.Map<List<ShopDto>>(entities);

            return dtos;
        }

        [HttpGet("{id}")]
        public ShopDto GetById(int id)
        {
            var entity = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            var dto = _mapper.Map<ShopDto>(entity);

            return dto;
        }

        [HttpPost]
        public void Create(ShopDto shop)
        {
            var dto = _mapper.Map<Shop>(shop);

            _context.Shops.Add(dto);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(ShopPutDto shop)
        {
            var dto = _mapper.Map<Shop>(shop);

            _context.Shops.Update(dto);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);

            if (shop == null)
            {
                throw new KeyNotFoundException();
            }
            
            _context.Shops.Remove(shop);
            _context.SaveChanges();
        }
    }
}
