using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Dtos.Crockery;
using RestApiShop.Entities;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrockeryController : GenericControllerBase<CrockeryDto, Crockery>
    {
        public CrockeryController(IMapper mapper, GenericRepository<Crockery> repository) : base(mapper, repository)
        {

        }
    }

}
