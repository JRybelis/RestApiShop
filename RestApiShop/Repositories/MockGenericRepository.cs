using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Base;
using RestApiShop.Interfaces;

namespace RestApiShop.Repositories
{
    public class MockGenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        public Task<List<T>> GetAll()
        {
            return Task.FromResult(new List<T>()
            {
                new T()
                {
                    Name = "TestName"
                }
            });
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

        public Task<T> GetByName(string itemName)
        {
            return null;
        }

        public Task UpdateItemQuantity(Item entity, int quantity)
        {
            return Task.CompletedTask;
        }
    }
}
