using Microsoft.EntityFrameworkCore;
using NutrientsApp.Entities;

namespace NutrientsApp.Data
{
    public class NutrientsContext : DbContext
    {
        public NutrientsContext(DbContextOptions<NutrientsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        
    }
}