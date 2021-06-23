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
    public class VegetablesController : ControllerBase
    {
        private readonly DataContext _context;

        public VegetablesController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Vegetable> GetAll()
        {
            return _context.Vegetables.ToList();
        }

        [HttpGet("{id}")]
        public Vegetable GetById(int id)
        {
            var vegetable = _context.Vegetables.FirstOrDefault(v => v.Id == id);

            if (vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            return vegetable;
        }

        [HttpPost]
        public void Create(Vegetable vegetable)
        {
            _context.Add(vegetable);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Vegetable vegetable)
        {
            _context.Vegetables.Update(vegetable);
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
            else
            {
                _context.Vegetables.Remove(vegetable);
                _context.SaveChanges();
            }
        }
    }

}