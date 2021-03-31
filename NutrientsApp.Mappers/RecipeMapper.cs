using NutrientsApp.Entities;
using NutrientsApp.Domain;

namespace NutrientsApp.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeEntity ToEntity(this Recipe recipe)
        {
            return new RecipeEntity
            {
                Id = recipe.Id,
                Name = recipe.Name,
                HowTo = recipe.HowTo

            };
        }

        public static Recipe ToDomain(this RecipeEntity recipeEntity)
        {
            return new Recipe
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                HowTo = recipeEntity.HowTo
            };
        }

    }
}
