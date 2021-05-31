using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public RecipesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productNutrientsService = new ProductNutrientsService(unitOfWork);
        }

        public void AddRecipe(Recipe recipe)
        {
            _unitOfWork.RecipesRepository.Create(recipe.ToEntity());
        }

        public void DeleteRecipeById(Guid id)
        {
            _unitOfWork.RecipesRepository.DeleteById(id);
        }

        public IList<Recipe> GetAll()
        {
            return _unitOfWork.RecipesRepository.GetAll().Select(r => r.ToDomain()).ToList();
        }

        public IDictionary<string, int> GetRecipeNutrients(Recipe recipe)
        {
            IList<IngredientEntity> ingredients = _unitOfWork.IngredientsRepository.GetAllItemsFromRecipe(recipe.ToEntity());
            IDictionary<string, int> dictionaryToReturn = new Dictionary<string, int>();
            
            foreach (IngredientEntity ingredient in ingredients)
            {
                IDictionary<string, int> nutrients = _productNutrientsService.GetProductNutrients(ingredient.ProductId);
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

        public Recipe GetRecipeById(Guid id)
        {
            return _unitOfWork.RecipesRepository.GetById(id).ToDomain();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _unitOfWork.RecipesRepository.Update(recipe.ToEntity());
        }

        
    }
}
