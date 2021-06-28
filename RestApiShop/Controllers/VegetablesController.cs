using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Data;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetablesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VegetablesController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        [HttpGet]
        public List<VegetableDto> GetAll()
        {
            var entities = _context.Vegetables.Include(s => s.Shop).ToList();
            var dtos = _mapper.Map<List<VegetableDto>>(entities);

            return dtos;
        }

        [HttpGet("{id}")]
        public VegetableDto GetById(int id)
        {
            var entity = _context.Vegetables.Include(s => s.Shop).FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            var dto = _mapper.Map<VegetableDto>(entity);
            
            return dto;
        }

        [HttpPost]
        public void Create(VegetableDto vegetable)
        {
            var dto = _mapper.Map<Vegetable>(vegetable);

            _context.Vegetables.Add(dto);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(VegetablePutDto vegetable)
        {
            var dto = _mapper.Map<Vegetable>(vegetable);

            _context.Vegetables.Update(dto);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vegetable = _context.Vegetables.FirstOrDefault(v => v.Id == id);

            if (vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Vegetables.Remove(vegetable);
            _context.SaveChanges();
        }
    }

}