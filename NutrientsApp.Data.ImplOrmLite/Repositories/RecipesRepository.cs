using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class RecipesRepository : Repository<RecipeEntity>, IRecipesRepository<RecipeEntity>
    {

        private readonly OrmLiteConnectionFactory _factory;

        public RecipesRepository(OrmLiteConnectionFactory factory) : base(factory)
        {
            _factory = factory;
        }


        public async Task<IList<IngredientEntity>> GetIngredients(Guid recipeId)
        {
            using (IDbConnection db = await _factory.OpenAsync())
            {
                return await db.SelectAsync<IngredientEntity>(db.From<IngredientEntity>()
                    .Where(i => i.RecipeId == recipeId));
            }
        }
    }
}
