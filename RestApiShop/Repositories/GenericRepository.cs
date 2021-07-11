using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApiShop.Data;
using RestApiShop.Entities.Base;

namespace RestApiShop.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity;
        }

        public async Task Upsert(T entity)
        {
            if (entity.Id != 0)
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _context.Remove(entity);    
            }
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByName(string itemName)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Name == itemName);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity;
        }
    }
}
