using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiShop.Dtos.Base;
using RestApiShop.Entities.Base;
using RestApiShop.Repositories;

namespace RestApiShop.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public  class GenericControllerBase<TDto, TEntity> : ControllerBase where TDto : ObjectDto where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TEntity> _repository;
        
        public GenericControllerBase(IMapper mapper, IGenericRepository<TEntity> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            [HttpGet]
            public virtual async Task<IEnumerable<TDto>> GetAll()
            {
                var entities = await _repository.GetAll();
                
                return _mapper.Map<IEnumerable<TDto>>(entities);
            }
        
            [HttpGet("{id}")]
            public async Task<TDto> GetById(int id)
            {
                var entity = await _repository.GetById(id);

                return _mapper.Map<TDto>(entity);
            }

            [HttpPost]
            public async Task Upsert(TDto dto)
            {
                var entity = _mapper.Map<TEntity>(dto);

                await _repository.Upsert(entity);
            }
        
            [HttpDelete("{id}")]
            public async Task Delete(int id)
            {
                await _repository.Delete(id);
            }
        }
    
}
