using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface INutrientComponentsRepository<T> : IRepository<T> where T : NutrientComponentEntity
    {
        public Task<IList<string>> GetAllComponentsNames();
    }
}