using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IProductNutrientsRepository<T> : IRepository<T> where T : ProductNutrientEntity
    {
        Task<IDictionary<string, int>> GetProductNutrients(Guid id);
    }
}