using NutrientsApp.Domain;
using NutrientsApp.Entities;

namespace NutrientsApp.Mappers
{
    public static class ProductNutrientMapper
    {
        public static ProductNutrientEntity ToEntity(this ProductNutrient productNutrient)
        {
            return new ProductNutrientEntity
            {
                Id = productNutrient.Id,
                NutrientId = productNutrient.NutrientId,
                ProductId = productNutrient.ProductId,
                AmountPerHundred = productNutrient.AmountPerHundred,
                Nutrient = productNutrient.Nutrient.ToEntity(),
                Product = productNutrient.Product.ToEntity()
            };
        }

        public static ProductNutrient ToDomain(this ProductNutrientEntity productNutrientEntity)
        {
            return new ProductNutrient
            {
                Id = productNutrientEntity.Id,
                NutrientId = productNutrientEntity.NutrientId,
                ProductId = productNutrientEntity.ProductId,
                AmountPerHundred = productNutrientEntity.AmountPerHundred,
                Nutrient = productNutrientEntity.Nutrient.ToDomain(),
                Product = productNutrientEntity.Product.ToDomain()
            };
        }
    }
}