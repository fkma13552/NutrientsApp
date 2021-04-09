using System;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientsRepository<IngredientEntity> IngredientsRepository { get; }
        IProductsRepository<ProductEntity> ProductsRepository { get; }
        IRecipesRepository<RecipeEntity> RecipesRepository { get; }
        void Complete();
    }
}