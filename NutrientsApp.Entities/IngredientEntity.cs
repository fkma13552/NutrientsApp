using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities.Abstract;
using ServiceStack.DataAnnotations;

namespace NutrientsApp.Entities
{
    [Alias("Ingredients")]
    [Schema("dbo")]
    public class IngredientEntity: IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        
        [Reference]
        public ProductEntity Product { get; set; }
        public Guid RecipeId { get; set; }
        [Reference]
        public RecipeEntity Recipe { get; set; }
        public int AmountInGrams { get; set; }
        
    }
}
