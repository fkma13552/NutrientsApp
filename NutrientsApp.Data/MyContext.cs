using Microsoft.EntityFrameworkCore;
using NutrientsApp.Entities;

namespace NutrientsApp.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<NutrientComponentEntity> NutrientComponents { get; set; }
    }
}