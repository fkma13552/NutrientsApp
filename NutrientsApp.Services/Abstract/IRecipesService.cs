using System;
using System.Collections.Generic;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IRecipesService
    {
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        Recipe GetRecipeById(Guid id);
        void DeleteRecipeById(Guid id);
        IList<Recipe> GetAll();
        public int GetRecipeProteins(Recipe recipe);
        public int GetRecipeCarbohydrates(Recipe recipe);
        public int GetRecipeFats(Recipe recipe);
        public int GetRecipeVitamins(Recipe recipe);
        public int GetRecipeMinerals(Recipe recipe);
    }
}
