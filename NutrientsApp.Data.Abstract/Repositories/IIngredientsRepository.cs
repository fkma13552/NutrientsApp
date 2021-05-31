using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IIngredientsRepository<T>: IRepository<T> where T: IngredientEntity
    {
        IList<T> GetAllItemsFromRecipe(RecipeEntity recipeEntity);
    }
}
