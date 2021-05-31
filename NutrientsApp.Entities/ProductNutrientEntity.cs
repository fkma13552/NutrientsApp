using System;
using NutrientsApp.Entities.Abstract;
using ServiceStack.DataAnnotations;

namespace NutrientsApp.Entities
{
    [Alias("ProductNutrients")]
    [Schema("dbo")]
    public class ProductNutrientEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid NutrientId { get; set; }
        public int AmountPerHundred { get; set; }
        
        [Reference]
        public ProductEntity Product { get; set; }
        
        [Reference]
        public NutrientComponentEntity Nutrient { get; set; }
    }
}