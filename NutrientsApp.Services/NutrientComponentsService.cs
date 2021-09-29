using System;
using System.Threading.Tasks;
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
        public async Task<NutrientComponent> GetNutrientById(Guid id)
        {
            var nutr = await _unitOfWork.NutrientComponentsRepository.GetById(id);
            return nutr.ToDomain();
        }
    }
}