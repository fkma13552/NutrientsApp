using System;
using NutrientsApp.Entities.Abstract;
using ServiceStack.DataAnnotations;

namespace NutrientsApp.Entities
{
    [Alias("NutrientComponents")]
    [Schema("dbo")]
    public class NutrientComponentEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}