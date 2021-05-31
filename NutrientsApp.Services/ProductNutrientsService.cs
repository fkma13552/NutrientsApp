using System;
using System.Collections.Generic;
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
        public IDictionary<string, int> GetProductNutrients(Guid id)
        {
            IDictionary<string, int> dictionaryToReturn =
                _unitOfWork.ProductNutrientsRepository.GetProductNutrients(id);
            foreach (string nutrient in _unitOfWork.NutrientComponentsRepository.GetAllComponentsNames())
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