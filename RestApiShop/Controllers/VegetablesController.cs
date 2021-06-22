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
        private readonly DataService _dataService;

        public VegetablesController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<Vegetable> GetAll()
        {
            return _dataService.Vegetables;
        }

        [HttpGet("{id}")]
        public Vegetable GetById(int id)
        {
            var vegetable = _dataService.Vegetables.FirstOrDefault(v => v.Id == id);

            if (vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            return vegetable;
        }

        [HttpPost]
        public void Create(Vegetable vegetable)
        {
            _dataService.Vegetables.Add(vegetable);
        }

        [HttpPut]
        public void Update(Vegetable vegetable)
        {
            var vegetableToUpdate = _dataService.Vegetables.FirstOrDefault(v => v.Id == vegetable.Id);

            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Vegetables[vegetable.Id] = vegetable;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vegetable = _dataService.Vegetables.FirstOrDefault(v => v.Id == id);

            if (vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Vegetables.Remove(vegetable);
        }
    }

}