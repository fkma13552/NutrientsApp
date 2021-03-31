using System;

namespace NutrientsApp.Domain
{
    public class Product
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
