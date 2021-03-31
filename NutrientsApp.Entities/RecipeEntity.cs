using System;
using System.Collections.Generic;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Entities
{
    public class RecipeEntity : IRecipeEntity
    {
        public Dictionary<Guid, IngredientEntity> ingredientList = new Dictionary<Guid, IngredientEntity>();

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HowTo { get; set; }

    }
}
