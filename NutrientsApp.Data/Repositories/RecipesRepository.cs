using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Repositories
{
    public class RecipesRepository : Repository<RecipeEntity>, IRecipesRepository<RecipeEntity>
    {

        private NutrientsContext _context;

        public RecipesRepository(NutrientsContext context) : base(context)
        {
            _context = context;
        }

        public IList<IngredientEntity> GetIngredients(RecipeEntity recipeEntity)
        {
            return _context.Ingredients.Where(ing => ing.RecipeId == recipeEntity.Id).ToList();
        }
    }
}
