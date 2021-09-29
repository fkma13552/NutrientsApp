using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IProductNutrientsService
    {
        public Task<IDictionary<string, int>> GetProductNutrients(Guid id);
    }
}