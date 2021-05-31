using System;
using System.Collections.Generic;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IProductNutrientsRepository<T> : IRepository<T> where T : ProductNutrientEntity
    {
        IDictionary<string, int> GetProductNutrients(Guid id);
    }
}