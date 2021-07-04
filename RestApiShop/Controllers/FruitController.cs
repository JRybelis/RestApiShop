using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Fruit;
using RestApiShop.Entities;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : GenericControllerBase<FruitDto, Fruit>
    {
        public FruitController(IMapper mapper, GenericRepository<Fruit> repository) : base(mapper, repository)
        {
            
        }
    }
}