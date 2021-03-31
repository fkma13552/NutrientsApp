using System;

namespace NutrientsApp.Domain
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid RecipeId { get; set; }
        public int AmountInGrams { get; set; }
        
    }
}

