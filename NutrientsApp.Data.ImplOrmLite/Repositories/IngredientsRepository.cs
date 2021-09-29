using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.Repositories
{
    public class IngredientsRepository : Repository<IngredientEntity>, IIngredientsRepository<IngredientEntity>
    {
        private readonly OrmLiteConnectionFactory _factory;
        public IngredientsRepository(OrmLiteConnectionFactory factory) : base(factory)
        {
            _factory = factory;
        }


        public async Task<IList<IngredientEntity>> GetAllItemsFromRecipe(Guid recipeId)
        {
            //SELECT * FROM Ingredients WHERE 
            using (IDbConnection db = await _factory.OpenAsync())
            {
                //return db.Select<IngredientEntity>("SELECT * FROM [Ingredients] WHERE RecipeId='{0}'", new {recipeEntity.Id});
                var a = await db.SelectAsync<IngredientEntity>(db.From<IngredientEntity>()
                    .Where((i => i.RecipeId == recipeId)));
                return a;
            }
        }
    }
}
