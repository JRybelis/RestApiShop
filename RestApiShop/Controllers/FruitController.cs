using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Data;
using RestApiShop.Dtos.Fruit;
using RestApiShop.Entities;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FruitController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        [HttpGet]
        public List<FruitDto> GetAll()
        {
            var entities = _context.Fruits.ToList();
            var dtos = _mapper.Map<List<FruitDto>>(entities);

            return dtos;
        }

        [HttpGet("{id}")]
        public FruitDto GetById(int id)
        {
            var entity = _context.Fruits.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            var dto = _mapper.Map<FruitDto>(entity);

            return dto;
        }

        [HttpPost]
        public void Create(FruitDto fruit)
        {
            var dto = _mapper.Map<Fruit>(fruit);

            _context.Fruits.Add(dto);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(FruitPutDto fruit)
        {
            var dto = _mapper.Map<Fruit>(fruit);

           _context.Fruits.Update(dto);
           _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Fruits.Remove(fruit);
            _context.SaveChanges();
        }
    }

}