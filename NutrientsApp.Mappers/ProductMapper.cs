using NutrientsApp.Entities;
using NutrientsApp.Domain;

namespace NutrientsApp.Mappers
{
    public static class ProductMapper
    {
        public static ProductEntity ToEntity(this Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Proteins = product.Proteins,
                Fats = product.Fats,
                Carbohydrates = product.Carbohydrates,
                Vitamins = product.Vitamins,
                Minerals = product.Minerals,
            };
        }

        public static Product ToDomain(this ProductEntity productEntity)
        {
            return new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Proteins = productEntity.Proteins,
                Fats = productEntity.Fats,
                Carbohydrates = productEntity.Carbohydrates,
                Vitamins = productEntity.Vitamins,
                Minerals = productEntity.Minerals,
            };
        }
    }
}
