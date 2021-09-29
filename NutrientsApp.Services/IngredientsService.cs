using System;
using System.Threading.Tasks;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Mappers;


namespace NutrientsApp.Services{
    
    public class IngredientService : IIngredientsService
    {

        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddIngredient(Ingredient ingredient)
        {
            await _unitOfWork.IngredientsRepository.Create(ingredient.ToEntity());
        }

        public async Task DeleteIngredientById(Guid id)
        {
            await _unitOfWork.IngredientsRepository.DeleteById(id);
        }

        public async Task<Ingredient> GetIngredientById(Guid id)
        {
            var ingr = await _unitOfWork.IngredientsRepository.GetById(id);
            return ingr.ToDomain();
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            await _unitOfWork.IngredientsRepository.Update(ingredient.ToEntity());
        }
    }
}
