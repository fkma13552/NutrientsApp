using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities.Abstract;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly OrmLiteConnectionFactory _factory;

        public Repository(OrmLiteConnectionFactory factory)
        {
            _factory = factory;
        }


        public void Create(T entity)
        {
            using (IDbConnection db = _factory.Open())
            {
                db.Insert(entity);
            }
        }

        public void Update(T entity)
        {
            using (IDbConnection db = _factory.Open())
            {
                db.Update(entity);
            }
        }
        

        public T GetById(Guid id)
        {
            using (IDbConnection db = _factory.Open())
            {
                return db.SingleById<T>(id);
            }
        }

        public void DeleteById(Guid id)
        {
            using (IDbConnection db = _factory.Open())
            {
                db.DeleteById<T>(id);
            }
        }

        public IList<T> GetAll()
        {
            using (IDbConnection db = _factory.Open())
            {
                return db.Select(db.From<T>());
            }
        }
    }
}