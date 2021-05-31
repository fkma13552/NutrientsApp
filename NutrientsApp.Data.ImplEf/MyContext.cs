using Microsoft.EntityFrameworkCore;
using NutrientsApp.Entities;

namespace NutrientsApp.Data
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R9KO1GP;Database=NutrientsAppDb;Trusted_Connection=True;", 
                x => x.MigrationsAssembly("NutrientsApp.Data.ImplEf"));
        }

        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<NutrientComponentEntity> NutrientComponents { get; set; }
        public DbSet<ProductNutrientEntity> ProductNutrients { get; set; }
    }
}