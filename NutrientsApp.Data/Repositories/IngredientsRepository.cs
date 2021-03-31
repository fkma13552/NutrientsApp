using System;
using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Data.Repositories
{
    public class IngredientsRepository : IIngredientsRepository<IngredientEntity>
    {
        private static IDictionary<Guid, IngredientEntity> _ingredientData;
        public IngredientsRepository()
        {
            if (_ingredientData == null)
            {
                _ingredientData = new Dictionary<Guid, IngredientEntity>();
                //Ingredients
                IngredientEntity eggs = new IngredientEntity
                {
                    Id = new Guid("63cce819-6480-4b2c-a598-0dffa75c6f15"),
                    RecipeId = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountInGrams = 200
                };
                IngredientEntity celery = new IngredientEntity
                {
                    Id = new Guid("4f369b8f-06ce-4980-9c10-1957d301d913"),
                    RecipeId = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    ProductId = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    AmountInGrams = 150
                };
                IngredientEntity mayonnaise = new IngredientEntity
                {
                    Id = new Guid("51566dc5-c2c2-453b-90d8-4095e08d2fcc"),
                    RecipeId = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    ProductId = new Guid("a95306b8-3e47-419e-95b2-b46da6043cd6"),
                    AmountInGrams = 150
                };
                IngredientEntity chicken = new IngredientEntity
                {
                    Id = new Guid("803047f7-874f-4dad-a95b-d42b5a019aa8"),
                    RecipeId = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    ProductId = new Guid("8b3c2722-cf42-4d53-846d-c48bbd2f7f9f"),
                    AmountInGrams = 200
                };
                IngredientEntity ham = new IngredientEntity
                {
                    Id = new Guid("d4e3af27-6f1d-4be9-8151-5f67f5c814b9"),
                    RecipeId = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    ProductId = new Guid("1bfdd3e3-5557-449f-b6c5-edd185d35fe0"),
                    AmountInGrams = 200
                };
                IngredientEntity cheese = new IngredientEntity
                {
                    Id = new Guid("d52cbb24-0536-4e51-9973-d95edf96b5be"),
                    RecipeId = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    ProductId = new Guid("91af8060-6a1d-4f79-86c9-1cb7ff2e34c2"),
                    AmountInGrams = 200
                };
                IngredientEntity crackers = new IngredientEntity
                {
                    Id = new Guid("08e136c9-a915-4749-a1c5-ec55be110c42"),
                    RecipeId = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    ProductId = new Guid("f633cd9b-2714-48ff-a22d-bd3eb048eb08"),
                    AmountInGrams = 100
                };
                IngredientEntity eggs2 = new IngredientEntity
                {
                    Id = new Guid("2ecd1bf3-9519-44d5-8336-9b8292fa587a"),
                    RecipeId = new Guid("7a53c548-533f-4a93-9cce-76240053cf8d"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountInGrams = 150
                };
                IngredientEntity ham2 = new IngredientEntity
                {
                    Id = new Guid("13fa8cb3-1a50-4ebe-8145-1c340f71066f"),
                    RecipeId = new Guid("7a53c548-533f-4a93-9cce-76240053cf8d"),
                    ProductId = new Guid("1bfdd3e3-5557-449f-b6c5-edd185d35fe0"),
                    AmountInGrams = 300
                };
                IngredientEntity mayonnaise2 = new IngredientEntity
                {
                    Id = new Guid("217fab5d-e7ff-4b9d-bee3-6f59e54466c6"),
                    RecipeId = new Guid("7a53c548-533f-4a93-9cce-76240053cf8d"),
                    ProductId = new Guid("a95306b8-3e47-419e-95b2-b46da6043cd6"),
                    AmountInGrams = 300
                };
                
                IngredientEntity crackers2 = new IngredientEntity
                {
                    Id = new Guid("bf1aafaf-48a3-49a4-af47-d1d7ff6e795b"),
                    RecipeId = new Guid("2f6c003d-c7e2-403d-8eb6-91ad42de5b84"),
                    ProductId = new Guid("f633cd9b-2714-48ff-a22d-bd3eb048eb08"),
                    AmountInGrams = 100
                };
                
                IngredientEntity eggs3 = new IngredientEntity
                {
                    Id = new Guid("3920265a-bb36-47ed-a6a6-b52427bc717d"),
                    RecipeId = new Guid("2f6c003d-c7e2-403d-8eb6-91ad42de5b84"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountInGrams = 150
                };
                
                Create(eggs);
                Create(celery);
                Create(mayonnaise);
                Create(chicken);
                Create(ham);
                Create(cheese);
                Create(crackers);
                Create(eggs2);
                Create(ham2);
                Create(mayonnaise2);
                Create(crackers2);
                Create(eggs3);
            }
            
        }
        
        public void Create(IngredientEntity entity)
        {
            _ingredientData.Add(entity.Id, entity);
        }

        public void Update(IngredientEntity entity)
        {
            _ingredientData[entity.Id] = entity;
        }

        public IngredientEntity GetById(Guid id)
        {
            return _ingredientData[id];
        }

        public void DeleteById(Guid id)
        {
            _ingredientData.Remove(id);
        }

        public IList<IngredientEntity> GetAll()
        {
            return _ingredientData.Values.ToList();
        }

        public IList<IngredientEntity> GetAllItemsFromRecipe(IRecipeEntity recipeEntity)
        {
            return GetAll().Where(ing => ing.RecipeId == recipeEntity.Id).ToList();
        }
    }
}
