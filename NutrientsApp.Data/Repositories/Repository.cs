using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private NutrientsContext _context;
        private DbSet<T> _dbSet;

        public Repository(NutrientsContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void DeleteById(Guid id)
        {
            T entityToDelete = _dbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}