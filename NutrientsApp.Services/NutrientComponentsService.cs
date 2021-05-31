using System;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Mappers;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.Services
{
    public class NutrientComponentsService : INutrientComponentsService
    {

        private readonly IUnitOfWork _unitOfWork;

        public NutrientComponentsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public NutrientComponent GetNutrientById(Guid id)
        {
            return _unitOfWork.NutrientComponentsRepository.GetById(id).ToDomain();
        }
    }
}