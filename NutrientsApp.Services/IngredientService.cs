using System;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.Data.Repositories.Abstract;
using NutrientsApp.Entities;
using NutrientsApp.Mappers;


namespace NutrientsApp.Services{
    
    public class IngredientService : IIngredientsService
    {

        private readonly IIngredientsRepository<IngredientEntity> _ingredientsRepository;

        public IngredientService(IIngredientsRepository<IngredientEntity> ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredientsRepository.Create(ingredient.ToEntity());
        }

        public void DeleteIngredientById(Guid id)
        {
            _ingredientsRepository.DeleteById(id);
        }

        public Ingredient GetIngredientById(Guid id)
        {
            return _ingredientsRepository.GetById(id).ToDomain();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            _ingredientsRepository.Update(ingredient.ToEntity());
        }
    }
}
