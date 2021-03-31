using System;

namespace NutrientsApp.Entities.Abstract
{
    public interface IIngredientEntity: IBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid RecipeId { get; set; }
        public int AmountInGrams { get; set; }
    }
}