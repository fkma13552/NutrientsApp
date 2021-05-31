using NutrientsApp.Data.Abstract.Repositories;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Data.ImplEf.Repositories;
using NutrientsApp.Entities;

namespace NutrientsApp.Data.ImplEf.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IIngredientsRepository<IngredientEntity> _ingredientsRepository;
        private IRecipesRepository<RecipeEntity> _recipesRepository;
        private IProductsRepository<ProductEntity> _productsRepository;
        private INutrientComponentsRepository<NutrientComponentEntity> _nutrientComponentsRepository;
        private IProductNutrientsRepository<ProductNutrientEntity> _productNutrientsRepository;
        private MyContext _context;

        public UnitOfWork(MyContext context)
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

        public INutrientComponentsRepository<NutrientComponentEntity> NutrientComponentsRepository
        {
            get
            {
                if (_nutrientComponentsRepository == null)
                {
                    _nutrientComponentsRepository = new NutrientComponentsRepository(_context);
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
                    _productNutrientsRepository = new ProductNutrientsRepository(_context);
                }

                return _productNutrientsRepository;
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