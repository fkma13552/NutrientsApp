using System;
using System.Collections.Generic;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories.Abstract
{
    public interface IRepository<T> where T: IBaseEntity
    {
        void Create(T entity);
        void Update(T entity);

        T GetById(Guid id);

        void DeleteById(Guid id);

        IList<T> GetAll();
    }
}