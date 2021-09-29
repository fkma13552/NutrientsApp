using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IRepository<T> where T: IBaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);

        Task<T> GetById(Guid id);

        Task DeleteById(Guid id);

        Task<IList<T>> GetAll();
    }
}