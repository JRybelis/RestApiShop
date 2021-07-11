using System.Collections.Generic;
using System.Threading.Tasks;
using RestApiShop.Entities.Base;

namespace RestApiShop.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Upsert(T entity);
        Task Delete(int id);
        Task<T> GetByName(string itemName);
        Task UpdateItemQuantity(Item entity, int quantity);

    }
}