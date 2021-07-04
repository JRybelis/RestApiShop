using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Controllers.Base;
using RestApiShop.Data;
using RestApiShop.Dtos.Vegetable;
using RestApiShop.Entities;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : GenericControllerBase<VegetableDto, Vegetable>
    {
        public VegetableController(IMapper mapper, GenericRepository<Vegetable> repository) : base(mapper, repository)
        {
            
        }
    }
}