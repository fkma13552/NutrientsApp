using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities.Abstract;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly OrmLiteConnectionFactory _factory;

        public Repository(OrmLiteConnectionFactory factory)
        {
            _factory = factory;
        }


        public async Task Create(T entity)
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
                await db.InsertAsync(entity);
            }
        }

        public async Task Update(T entity)
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
                await db.UpdateAsync(entity);
            }
        }
        

        public async Task<T> GetById(Guid id)
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
                return await db.SingleByIdAsync<T>(id);
            }
        }

        public async Task DeleteById(Guid id)
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
               await db.DeleteByIdAsync<T>(id);
            }
        }

        public async Task<IList<T>> GetAll()
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
                return await db.SelectAsync(db.From<T>());
            }
        }
    }
}