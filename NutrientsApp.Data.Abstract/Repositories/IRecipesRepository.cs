using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IRecipesRepository<T> : IRepository<T> where T : RecipeEntity
    { 
        IList<IngredientEntity> GetIngredients(T recipeEntity);

    }
}
