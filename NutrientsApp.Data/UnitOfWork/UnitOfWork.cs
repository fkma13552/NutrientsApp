using NutrientsApp.Data.Repositories;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Data.UnitOfWork.Abstract;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IIngredientsRepository<IngredientEntity> _ingredientsRepository;
        private IRecipesRepository<RecipeEntity> _recipesRepository;
        private IProductsRepository<ProductEntity> _productsRepository;
        private NutrientsContext _context;

        public UnitOfWork(NutrientsContext context)
        {
            _context = context;
        }

        public IIngredientsRepository<IngredientEntity> IngredientsRepository
        {
            get
            {
                if (_ingredientsRepository == null)
                {
                    _ingredientsRepository = new IngredientsRepository(_context);
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
                    _productsRepository = new ProductsRepository(_context);
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
                    _recipesRepository = new RecipesRepository(_context);
                }

                return _recipesRepository;
            }
        }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}