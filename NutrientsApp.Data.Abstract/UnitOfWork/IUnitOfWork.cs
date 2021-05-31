using System;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientsRepository<IngredientEntity> IngredientsRepository { get; }
        IProductsRepository<ProductEntity> ProductsRepository { get; }
        IRecipesRepository<RecipeEntity> RecipesRepository { get; }
        INutrientComponentsRepository<NutrientComponentEntity> NutrientComponentsRepository { get; }
        IProductNutrientsRepository<ProductNutrientEntity> ProductNutrientsRepository { get; }
        void Complete();
    }
}