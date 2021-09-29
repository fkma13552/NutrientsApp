using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IIngredientsRepository<T>: IRepository<T> where T: IngredientEntity
    {
        Task<IList<IngredientEntity>> GetAllItemsFromRecipe(Guid recipeId);
    }
}
