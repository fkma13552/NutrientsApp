using System.Data.Entity;
using NutrientsApp.Entities;

namespace NutrientsApp.Data
{
    public class NutrientsContext : DbContext
    {
        static NutrientsContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        
    }
}