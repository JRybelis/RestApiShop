using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Shop;
using RestApiShop.Entities;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : GenericControllerBase<ShopDto, Shop>
    {
        public ShopController(IMapper mapper, IGenericRepository<Shop> repository) : base(mapper, repository)
        {

        }
    }
}
