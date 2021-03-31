using System;
using System.Collections.Generic;
using System.Linq;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Mappers;

namespace NutrientsApp.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository<RecipeEntity, IngredientEntity> _recipesRepository;

        private readonly IProductsService _productsService;
        
        public RecipesService(IRecipesRepository<RecipeEntity, IngredientEntity> recipesRepository, IProductsService productsService)
        {
            _recipesRepository = recipesRepository;
            _productsService = productsService;
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipesRepository.Create(recipe.ToEntity());
        }

        public void DeleteRecipeById(Guid id)
        {
            _recipesRepository.DeleteById(id);
        }

        public IList<Recipe> GetAll()
        {
            return _recipesRepository.GetAll().Select(r => r.ToDomain()).ToList();
        }

        public Recipe GetRecipeById(Guid id)
        {
            return _recipesRepository.GetById(id).ToDomain();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _recipesRepository.Update(recipe.ToEntity());
        }

        public int GetRecipeProteins(Recipe recipe)
        {
            IList<IngredientEntity> ing = _recipesRepository.GetIngredients(recipe.ToEntity());
            int p = 0;
            foreach (var entity in ing)
            {
                p += _productsService.GetProductById(entity.ProductId).Proteins * entity.AmountInGrams / 100;
            }

            return p;
        }

        public int GetRecipeCarbohydrates(Recipe recipe)
        {
            IList<IngredientEntity> ing = _recipesRepository.GetIngredients(recipe.ToEntity());
            int c = 0;
            foreach (var entity in ing)
            {
                c += _productsService.GetProductById(entity.ProductId).Carbohydrates * entity.AmountInGrams / 100;
            }

            return c;
        }

        public int GetRecipeFats(Recipe recipe)
        {
            IList<IngredientEntity> ing = _recipesRepository.GetIngredients(recipe.ToEntity());
            int f = 0;
            foreach (var entity in ing)
            {
                f += _productsService.GetProductById(entity.ProductId).Fats * entity.AmountInGrams / 100;
            }

            return f;
        }

        public int GetRecipeVitamins(Recipe recipe)
        {
            IList<IngredientEntity> ing = _recipesRepository.GetIngredients(recipe.ToEntity());
            int v = 0;
            foreach (var entity in ing)
            {
                v += _productsService.GetProductById(entity.ProductId).Vitamins * entity.AmountInGrams / 100;
            }

            return v;
        }

        public int GetRecipeMinerals(Recipe recipe)
        {
            IList<IngredientEntity> ing = _recipesRepository.GetIngredients(recipe.ToEntity());
            int m = 0;
            foreach (var entity in ing)
            {
                m += _productsService.GetProductById(entity.ProductId).Minerals * entity.AmountInGrams / 100;
            }

            return m;
        }
    }
}
