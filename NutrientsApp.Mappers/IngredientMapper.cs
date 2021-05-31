using NutrientsApp.Data;
using NutrientsApp.Entities;
using NutrientsApp.Domain;

namespace NutrientsApp.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientEntity ToEntity(this Ingredient ingredient)
        {
            return new IngredientEntity
            {
                Id = ingredient.Id,
                RecipeId = ingredient.RecipeId,
                ProductId = ingredient.ProductId,
                AmountInGrams = ingredient.AmountInGrams,
                Recipe = ingredient.Recipe.ToEntity(),
                Product = ingredient.Product.ToEntity()
            };
        }

        public static Ingredient ToDomain(this IngredientEntity ingredientEntity)
        {
            return new Ingredient
            {
                Id = ingredientEntity.Id,
                RecipeId = ingredientEntity.Id,
                ProductId = ingredientEntity.ProductId,
                AmountInGrams = ingredientEntity.AmountInGrams,
                Recipe = ingredientEntity.Recipe.ToDomain(),
                Product = ingredientEntity.Product.ToDomain()
            };
        }
    }
}
