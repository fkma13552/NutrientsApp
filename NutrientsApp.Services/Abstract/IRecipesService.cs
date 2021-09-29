using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IRecipesService
    {
        Task AddRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task<Recipe> GetRecipeById(Guid id);
        Task DeleteRecipeById(Guid id);
        Task<IList<Recipe>> GetAll();
        public Task<IDictionary<string, int>> GetRecipeNutrients(Guid recipeId);
    }
}
