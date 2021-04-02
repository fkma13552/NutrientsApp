using System;
using System.Collections.Generic;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Entities
{
    public class RecipeEntity : IRecipeEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HowTo { get; set; }

    }
}
