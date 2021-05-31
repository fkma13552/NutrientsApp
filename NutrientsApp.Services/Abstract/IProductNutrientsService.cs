using System;
using System.Collections.Generic;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IProductNutrientsService
    {
        public IDictionary<string, int> GetProductNutrients(Guid id);
    }
}