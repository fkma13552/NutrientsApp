using System;
using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.ImplEf.Repositories
{
    public class IngredientsRepository : Repository<IngredientEntity>, IIngredientsRepository<IngredientEntity>
    {
        private MyContext _context;
        public IngredientsRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IList<IngredientEntity> GetAllItemsFromRecipe(RecipeEntity recipeEntity)
        {
            return _context.Ingredients.Where(ing => ing.RecipeId == recipeEntity.Id).ToList();
        }
    }
}
