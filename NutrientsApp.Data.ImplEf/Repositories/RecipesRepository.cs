using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<IngredientEntity>> GetIngredients(Guid recipeId)
        {
            return await _context.Ingredients.Where(ing => ing.RecipeId == recipeId).ToListAsync();
        }
    }
}
