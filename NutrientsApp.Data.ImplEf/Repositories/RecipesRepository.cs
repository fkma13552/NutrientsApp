using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class RecipesRepository : Repository<RecipeEntity>, IRecipesRepository<RecipeEntity>
    {

        private MyContext _context;

        public RecipesRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IList<IngredientEntity> GetIngredients(RecipeEntity recipeEntity)
        {
            return _context.Ingredients.Where(ing => ing.RecipeId == recipeEntity.Id).ToList();
        }
    }
}
