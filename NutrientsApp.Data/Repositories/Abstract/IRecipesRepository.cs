using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories.Abstract
{
    public interface IRecipesRepository<T, K> : IRepository<T> where T : IRecipeEntity where K : IIngredientEntity
    { 
        IList<K> GetIngredients(T recipeEntity);

    }
}
