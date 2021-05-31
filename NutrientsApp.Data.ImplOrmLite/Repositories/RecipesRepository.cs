using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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


        public IList<IngredientEntity> GetIngredients(RecipeEntity recipeEntity)
        {
            using (IDbConnection db = _factory.Open())
            {
                return db.Select<IngredientEntity>(db.From<IngredientEntity>()
                    .Where(i => i.RecipeId == recipeEntity.Id));
            }
        }
    }
}
