using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NutrientsApp.Entities.Abstract;
using ServiceStack.DataAnnotations;

namespace NutrientsApp.Entities
{
    [Alias("Recipes")]
    [Schema("dbo")]
    public class RecipeEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HowTo { get; set; }

    }
}
