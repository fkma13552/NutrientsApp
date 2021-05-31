using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities.Abstract;
using ServiceStack.DataAnnotations;

namespace NutrientsApp.Entities
{
    [Alias("Products")]
    [Schema("dbo")]
    public class ProductEntity: IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
