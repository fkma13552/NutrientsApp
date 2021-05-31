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
                Name = product.Name
            };
        }

        public static Product ToDomain(this ProductEntity productEntity)
        {
            return new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name
            };
        }
    }
}
