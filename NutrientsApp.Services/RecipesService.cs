using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Mappers;

namespace NutrientsApp.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductNutrientsService _productNutrientsService;
        
        public RecipesService(IUnitOfWork unitOfWork, IProductNutrientsService productNutrientsService)
        {
            _unitOfWork = unitOfWork;
            _productNutrientsService = productNutrientsService;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await _unitOfWork.RecipesRepository.Create(recipe.ToEntity());
        }

        public async Task DeleteRecipeById(Guid id)
        {
            await _unitOfWork.RecipesRepository.DeleteById(id);
        }

        public async Task<IList<Recipe>> GetAll()
        {
            var list = await _unitOfWork.RecipesRepository.GetAll();
               return list.Select(r => r.ToDomain()).ToList();
        }

        public async Task<IDictionary<string, int>> GetRecipeNutrients(Guid recipeId)
        {
            IList<IngredientEntity> ingredients = await _unitOfWork.IngredientsRepository.GetAllItemsFromRecipe(recipeId);
            IDictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
            
            foreach (IngredientEntity ingredient in ingredients)
            {
                IDictionary<string, int> nutrients = await _productNutrientsService.GetProductNutrients(ingredient.ProductId);
                foreach (KeyValuePair<string,int> kv in nutrients)
                {
                    if (dictionaryToReturn.ContainsKey(kv.Key))
                    {
                        dictionaryToReturn[kv.Key] += kv.Value * ingredient.AmountInGrams / 100;
                    }
                    else
                    {
                        dictionaryToReturn[kv.Key] = kv.Value * ingredient.AmountInGrams / 100;  
                    }
                    
                }
                
            }
            return dictionaryToReturn;
        }

        public async Task<Recipe> GetRecipeById(Guid id)
        {
            var recipe = await _unitOfWork.RecipesRepository.GetById(id);
            return recipe.ToDomain();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            await _unitOfWork.RecipesRepository.Update(recipe.ToEntity());
        }

        
    }
}
