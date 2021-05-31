using System;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface INutrientComponentsService
    {
        public NutrientComponent GetNutrientById(Guid id);
    }
}