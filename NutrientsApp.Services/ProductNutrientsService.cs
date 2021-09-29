using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.Services
{
    public class ProductNutrientsService : IProductNutrientsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductNutrientsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDictionary<string, int>> GetProductNutrients(Guid id)
        {
            IDictionary<string, int> dictionaryToReturn = 
                await _unitOfWork.ProductNutrientsRepository.GetProductNutrients(id);
            foreach (string nutrient in await _unitOfWork.NutrientComponentsRepository.GetAllComponentsNames())
            {
                if (!dictionaryToReturn.ContainsKey(nutrient))
                {
                    dictionaryToReturn.Add(nutrient, 0);
                }
            }

            return dictionaryToReturn;
        }
        
    }
}