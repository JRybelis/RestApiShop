using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiShop.Entities.Base;

namespace RestApiShop.Repositories
{
    public class MockGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll()
        {
            return null;
        }

        public Task<T> GetById(int id)
        {
            return null;
        }

        public Task Upsert(T entity)
        {
            return null;
        }

        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }
    }
}
