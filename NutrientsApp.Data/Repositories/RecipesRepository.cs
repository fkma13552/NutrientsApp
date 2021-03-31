using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Repositories
{
    public class RecipesRepository<K> : IRecipesRepository<RecipeEntity, K> where K : IngredientEntity
    {

        private static IDictionary<Guid, RecipeEntity> _recipeData;

        private IIngredientsRepository<K> _ingredientsRepository;

        private IProductsRepository<ProductEntity> _productsRepository;

        public RecipesRepository(IIngredientsRepository<K> repi, IProductsRepository<ProductEntity> repp)
        {
            _ingredientsRepository = repi;
            _productsRepository = repp;

            if (_recipeData == null)
            {
                _recipeData = new Dictionary<Guid, RecipeEntity>();
                //Recipes
                RecipeEntity salad = new RecipeEntity
                {
                    Id = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    Name = "Salad with eggs and celery",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };
                RecipeEntity cordonbleu = new RecipeEntity
                {
                    Id = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    Name = "Chicken Cordon bleu",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };
                RecipeEntity salad2 = new RecipeEntity
                {
                    Id = new Guid("2f6c003d-c7e2-403d-8eb6-91ad42de5b84"),
                    Name = "Salad with chicken and eggs",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };
                RecipeEntity studentik = new RecipeEntity
                {
                    Id = new Guid("7a53c548-533f-4a93-9cce-76240053cf8d"),
                    Name = "Crackers with ham and mayonnaise",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };

                Create(salad);
                Create(cordonbleu);
                Create(salad2);
                Create(studentik);
            }
        }


        public void Create(RecipeEntity entity)
        {
            _recipeData.Add(entity.Id, entity);
        }

        public void Update(RecipeEntity entity)
        {
            _recipeData[entity.Id] = entity;
        }

        public RecipeEntity GetById(Guid id)
        {
            return _recipeData[id];
        }

        public void DeleteById(Guid id)
        {
            _recipeData.Remove(id);
        }

        public IList<RecipeEntity> GetAll()
        {
            return _recipeData.Values.ToList();
        }

        IList<K> IRecipesRepository<RecipeEntity, K>.GetIngredients(RecipeEntity recipeEntity)
        {
            return _ingredientsRepository.GetAllItemsFromRecipe(recipeEntity);
        }
    }
}
