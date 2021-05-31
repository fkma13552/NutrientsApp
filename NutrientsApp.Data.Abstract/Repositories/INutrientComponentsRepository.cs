using System.Collections.Generic;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface INutrientComponentsRepository<T> : IRepository<T> where T : NutrientComponentEntity
    {
        public IList<string> GetAllComponentsNames();
    }
}