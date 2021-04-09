using System;
using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories
{
    public class IngredientsRepository : Repository<IngredientEntity>, IIngredientsRepository<IngredientEntity>
    {
        private NutrientsContext _context;
        public IngredientsRepository(NutrientsContext context) : base(context)
        {
            _context = context;
        }

        public IList<IngredientEntity> GetAllItemsFromRecipe(IRecipeEntity recipeEntity)
        {
            return _context.Ingredients.Where(ing => ing.RecipeId == recipeEntity.Id).ToList();
        }
    }
}
