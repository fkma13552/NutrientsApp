using System;
using System.Threading.Tasks;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface INutrientComponentsService
    {
        public Task<NutrientComponent> GetNutrientById(Guid id);
    }
}