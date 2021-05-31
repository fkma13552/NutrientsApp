using System;

namespace NutrientsApp.Domain
{
    public class ProductNutrient
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid NutrientId { get; set; }
        public int AmountPerHundred { get; set; }
        public NutrientComponent Nutrient { get; set; }
        public Product Product { get; set; }
    }
}