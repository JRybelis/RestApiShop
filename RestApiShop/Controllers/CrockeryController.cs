using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Data;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Crockery> _repository;

        public CrockeryController(DataContext context, IMapper mapper, GenericRepository<Crockery> repository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public List<CrockeryDto> GetAll()
        {
            var entities = _context.CrockeryItems.Include(s => s.Shop).ToList();
            var dtos = _mapper.Map<List<CrockeryDto>>(entities);

            return dtos;
        }

        [HttpGet("{id}")]
        public CrockeryDto GetById(int id)
        {
            var entity = _context.CrockeryItems.Include(s => s.Shop).FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            var dto = _mapper.Map<CrockeryDto>(entity);

            return dto;
        }

        [HttpPost]
        public async Task Upsert(CrockeryDto dto)
        {
            var entity = _mapper.Map<Crockery>(dto);

            await _repository.Upsert(entity);
        }

        [HttpPut]
        public void Update(CrockeryPutDto crockeryPiece)
        {
            var dto = _mapper.Map<Crockery>(crockeryPiece);
            
            _context.CrockeryItems.Update(dto);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var crockeryItem = _context.CrockeryItems.FirstOrDefault(c => c.Id == id);
            
            if (crockeryItem == null)
            {
                throw new KeyNotFoundException();
            }

            _context.CrockeryItems.Remove(crockeryItem);
            _context.SaveChanges();
        }
    }

}
