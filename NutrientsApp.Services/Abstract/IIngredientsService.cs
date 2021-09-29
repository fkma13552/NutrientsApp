using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IIngredientsService
    {
        Task AddIngredient(Ingredient ingredient);
        Task UpdateIngredient(Ingredient ingredient);
        Task<Ingredient> GetIngredientById(Guid id);
        Task DeleteIngredientById(Guid id);
    }
}
