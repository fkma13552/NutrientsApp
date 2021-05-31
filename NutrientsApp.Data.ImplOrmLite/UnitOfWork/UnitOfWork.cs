using System;
using System.Data;
using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Data.ImplOrmLite.Repositories;
using NutrientsApp.Entities;
using ServiceStack.OrmLite;

namespace NutrientsApp.Data.ImplOrmLite.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IIngredientsRepository<IngredientEntity> _ingredientsRepository;
        private IRecipesRepository<RecipeEntity> _recipesRepository;
        private IProductsRepository<ProductEntity> _productsRepository;
        private INutrientComponentsRepository<NutrientComponentEntity> _nutrientComponentsRepository;
        private IProductNutrientsRepository<ProductNutrientEntity> _productNutrientsRepository;
        private OrmLiteConnectionFactory _factory;

        public UnitOfWork(OrmLiteConnectionFactory factory)
        {
            _factory = factory;
        }

        public IIngredientsRepository<IngredientEntity> IngredientsRepository
        {
            get
            {
                if (_ingredientsRepository == null)
                {
                    _ingredientsRepository = new IngredientsRepository(_factory);
                }

                return _ingredientsRepository;
            }
        }

        public IProductsRepository<ProductEntity> ProductsRepository
        {
            get
            {
                if (_productsRepository == null)
                {
                    _productsRepository = new ProductsRepository(_factory);
                }

                return _productsRepository;
            }
        }

        public IRecipesRepository<RecipeEntity> RecipesRepository
        {
            get
            {
                if (_recipesRepository == null)
                {
                    _recipesRepository = new RecipesRepository(_factory);
                }

                return _recipesRepository;
            }
        }

        public INutrientComponentsRepository<NutrientComponentEntity> NutrientComponentsRepository
        {
            get
            {
                if (_nutrientComponentsRepository == null)
                {
                    _nutrientComponentsRepository = new NutrientComponentsRepository(_factory);
                }

                return _nutrientComponentsRepository;
            }
        }

        public IProductNutrientsRepository<ProductNutrientEntity> ProductNutrientsRepository
        {
            get
            {
                if (_productNutrientsRepository == null)
                {
                    _productNutrientsRepository = new ProductNutrientsRepository(_factory);
                }

                return _productNutrientsRepository;
            }
        }


        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}