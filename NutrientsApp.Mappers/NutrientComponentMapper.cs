using NutrientsApp.Domain;
using NutrientsApp.Entities;

namespace NutrientsApp.Mappers
{
    public static class NutrientComponentMapper
    {
        public static NutrientComponent ToDomain(this NutrientComponentEntity nutrientComponentEntity)
        {
            return new NutrientComponent
            {
                Id = nutrientComponentEntity.Id,
                Name = nutrientComponentEntity.Name
            };
        }

        public static NutrientComponentEntity ToEntity(this NutrientComponent nutrientComponent)
        {
            return new NutrientComponentEntity
            {
                Id = nutrientComponent.Id,
                Name = nutrientComponent.Name
            };
        }
    }
}