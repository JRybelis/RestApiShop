using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Data;
using RestApiShop.Models;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Shop> GetAll()
        {
            return _context.Shops.ToList();
        }

        [HttpGet("{id}")]
        public Shop GetById(int id)
        {
            return _context.Shops.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Post(Shop shop)
        {
            _context.Add(shop);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Shop shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                _context.SaveChanges();
            }
        }
    }
}
