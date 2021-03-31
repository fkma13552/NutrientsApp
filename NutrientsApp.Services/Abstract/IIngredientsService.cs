using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Domain;

namespace NutrientsApp.Services.Abstract
{
    public interface IIngredientsService
    {
        void AddIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        Ingredient GetIngredientById(Guid id);
        void DeleteIngredientById(Guid id);
    }
}
