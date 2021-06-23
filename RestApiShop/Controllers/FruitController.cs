using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Data;
using RestApiShop.Models;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly DataContext _context;

        public FruitController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Fruit> GetAll()
        {
            return _context.Fruits.ToList();
        }

        [HttpGet("{id}")]
        public Fruit GetById(int id)
        {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            return fruit;
        }

        [HttpPost]
        public void Create(Fruit fruit)
        {
            _context.Add(fruit);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Fruit fruit)
        {
            _context.Fruits.Update(fruit);
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
            else
            {
                _context.Fruits.Remove(fruit);
                _context.SaveChanges();
            }
        }
    }

}