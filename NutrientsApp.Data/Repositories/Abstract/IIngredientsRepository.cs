using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories.Abstract
{
    public interface IIngredientsRepository<T>: IRepository<T> where T: IIngredientEntity
    {
        IList<T> GetAllItemsFromRecipe(IRecipeEntity recipeEntity);
    }
}
