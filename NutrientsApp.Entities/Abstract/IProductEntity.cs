using System;
using System.Collections.Generic;
using System.Text;

namespace NutrientsApp.Entities.Abstract
{
    public interface IProductEntity: IBaseEntity
    {
        public string Name { get; set; }
        public int Proteins { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int Vitamins { get; set; }
        public int Minerals { get; set; }
    }
}
