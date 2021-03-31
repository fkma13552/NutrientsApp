using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Entities
{
    public class IngredientEntity: IIngredientEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid RecipeId { get; set; }
        public int AmountInGrams { get; set; }
        
    }
}
