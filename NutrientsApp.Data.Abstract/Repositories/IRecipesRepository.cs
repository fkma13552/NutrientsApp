using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Abstract.Repositories
{
    public interface IRecipesRepository<T> : IRepository<T> where T : RecipeEntity
    { 
        Task<IList<IngredientEntity>> GetIngredients(Guid recipeGuid);

    }
}
