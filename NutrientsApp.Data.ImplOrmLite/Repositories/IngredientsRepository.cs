using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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


        public IList<IngredientEntity> GetAllItemsFromRecipe(RecipeEntity recipeEntity)
        {
            //SELECT * FROM Ingredients WHERE 
            using (IDbConnection db = _factory.Open())
            {
                //return db.Select<IngredientEntity>("SELECT * FROM [Ingredients] WHERE RecipeId='{0}'", new {recipeEntity.Id});
                var a = db.Select<IngredientEntity>(db.From<IngredientEntity>().Where((i => i.RecipeId == recipeEntity.Id)));
                return a;
            }
        }
    }
}
