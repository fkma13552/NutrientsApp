using System;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Data.UnitOfWork.Abstract;
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
        public void AddIngredient(Ingredient ingredient)
        {
            _unitOfWork.IngredientsRepository.Create(ingredient.ToEntity());
        }

        public void DeleteIngredientById(Guid id)
        {
            _unitOfWork.IngredientsRepository.DeleteById(id);
        }

        public Ingredient GetIngredientById(Guid id)
        {
            return _unitOfWork.IngredientsRepository.GetById(id).ToDomain();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            _unitOfWork.IngredientsRepository.Update(ingredient.ToEntity());
        }
    }
}
