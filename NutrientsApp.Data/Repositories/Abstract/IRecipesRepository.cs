using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories.Abstract
{
    public interface IRecipesRepository<T> : IRepository<T> where T : IRecipeEntity
    { 
        IList<IngredientEntity> GetIngredients(T recipeEntity);

    }
}
