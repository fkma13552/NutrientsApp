using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities.Abstract;
using ServiceStack;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeleteById(Guid id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}