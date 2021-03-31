using System;
using System.Collections.Generic;
using System.Text;
using NutrientsApp.Entities.Abstract;

namespace NutrientsApp.Entities
{
    public class ProductEntity: IProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int Vitamins { get; set; }
        public int Minerals { get; set; }

    }
}
