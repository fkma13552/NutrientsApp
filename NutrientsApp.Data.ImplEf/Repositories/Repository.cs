using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities.Abstract;

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