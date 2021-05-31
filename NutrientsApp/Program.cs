using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NutrientsApp.Data;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services;

namespace NutrientsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            
            string connectionString = config.GetConnectionString("NutrientsDb");
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            using (MyContext context = new MyContext())
            {
                //Recipes
                RecipeEntity salad = new RecipeEntity
                {
                    Id = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    Name = "Salad with eggs and celery",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };
                RecipeEntity cordonbleu = new RecipeEntity
                {
                    Id = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    Name = "Chicken Cordon bleu",
                    HowTo = "1.Cut 2.Slice 3.Add 4.Eat"
                };
                ProductEntity eggs = new ProductEntity
                {
                    Id = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    Name = "Eggs",
                };
                ProductEntity celery = new ProductEntity
                {
                    Id = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    Name = "Celery",
                };
                NutrientComponentEntity prot = new NutrientComponentEntity
                {
                    Id = new Guid("accbd89c-319d-4e85-8ccc-0040dce8b3b8"),
                    Name = "Proteins"
                };
                NutrientComponentEntity fat = new NutrientComponentEntity
                {
                    Id = new Guid("7bc7b7f4-1d39-4469-944c-d31f7b6d5db0"),
                    Name = "Fats"
                };
                NutrientComponentEntity carbo = new NutrientComponentEntity
                {
                    Id = new Guid("d70049b2-db82-4442-9bec-fb4d303f6644"),
                    Name = "Carbohydrates"
                };

                ProductNutrientEntity first = new ProductNutrientEntity
                {
                    Id = new Guid("3ff1fe2b-3aa3-4314-9c26-8213aa9bf187"),
                    NutrientId = new Guid("accbd89c-319d-4e85-8ccc-0040dce8b3b8"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountPerHundred = 13
                };
                
                ProductNutrientEntity sec = new ProductNutrientEntity
                {
                    Id = new Guid("0a73f606-8189-4409-b7c9-901cdb2695ab"),
                    NutrientId = new Guid("7bc7b7f4-1d39-4469-944c-d31f7b6d5db0"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountPerHundred = 10
                };
                
                ProductNutrientEntity three = new ProductNutrientEntity
                {
                    Id = new Guid("b2a96375-9ebc-4984-95b7-217f75cc7b88"),
                    NutrientId = new Guid("d70049b2-db82-4442-9bec-fb4d303f6644"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountPerHundred = 8
                };
                
                ProductNutrientEntity four = new ProductNutrientEntity
                {
                    Id = new Guid("867f18a3-e641-4a41-b40b-16cfdb88e7c4"),
                    NutrientId = new Guid("accbd89c-319d-4e85-8ccc-0040dce8b3b8"),
                    ProductId = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    AmountPerHundred = 2
                };
                
                ProductNutrientEntity five = new ProductNutrientEntity
                {
                    Id = new Guid("085d5d2e-1f96-451e-a615-dce72bf7ebc6"),
                    NutrientId = new Guid("7bc7b7f4-1d39-4469-944c-d31f7b6d5db0"),
                    ProductId = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    AmountPerHundred = 0
                };
                
                ProductNutrientEntity six = new ProductNutrientEntity
                {
                    Id = new Guid("c9f02f30-bc3e-4ac7-b2fd-f931d06569cb"),
                    NutrientId = new Guid("d70049b2-db82-4442-9bec-fb4d303f6644"),
                    ProductId = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    AmountPerHundred = 0
                };
                
                //Ingredients
                IngredientEntity eggsi = new IngredientEntity
                {
                    Id = new Guid("63cce819-6480-4b2c-a598-0dffa75c6f15"),
                    RecipeId = new Guid("44d2bf66-0401-4e1e-9699-e8b88c054a20"),
                    ProductId = new Guid("a2c31b00-678e-4e6c-ad82-68f7876bd7d2"),
                    AmountInGrams = 200
                };
                IngredientEntity celeryi = new IngredientEntity
                {
                    Id = new Guid("4f369b8f-06ce-4980-9c10-1957d301d913"),
                    RecipeId = new Guid("9f7e5878-9bac-4acc-ab81-05ba9dc1f81a"),
                    ProductId = new Guid("50d3330f-2aa2-462b-8625-09ecaf6b797d"),
                    AmountInGrams = 150
                };

                context.Recipes.Add(salad);
                context.Recipes.Add(cordonbleu);
                context.Products.Add(eggs);
                context.Products.Add(celery);
                context.NutrientComponents.Add(prot);
                context.NutrientComponents.Add(fat);
                context.NutrientComponents.Add(carbo);
                context.ProductNutrients.Add(first);
                context.ProductNutrients.Add(sec);
                context.ProductNutrients.Add(three);
                context.ProductNutrients.Add(four);
                context.ProductNutrients.Add(five);
                context.ProductNutrients.Add(six);
                context.Ingredients.Add(eggsi);
                context.Ingredients.Add(celeryi);
                context.SaveChanges();
            }
            
            /*IList<Recipe> choiceList = new List<Recipe>();
            IList<Recipe> recipesList = recipesService.GetAll();
            
            //Userexp
            Console.WriteLine("Hello World! Choose recipes number");
            for (int i = 0; i < recipesList.Count; i++)
            {
                Console.WriteLine(i + 1 + "." + recipesList[i].ToString());
            }
            Console.WriteLine();

            Boolean notExit = true;
            Console.WriteLine("To finish entering press <Y>, enter value (only numbers) and then enter <Enter>");
            while (notExit)
            {
                var pressedKey = Console.ReadKey().KeyChar;
                if (pressedKey.ToString() != "y")
                {
                    if (char.IsDigit(pressedKey))
                    {
                        int choice = 0;
                        var validNumber = Int32.TryParse(pressedKey.ToString() + Console.ReadLine(), out choice);
                        if (choice <= recipesList.Count && choice > 0)
                        {
                            choiceList.Add(recipesList[choice - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }                                      
                }
                else
                {
                    notExit = !notExit;
                }
            }

            int prot = 0;
            int fats = 0;
            int carb = 0;
            int vitm = 0;
            int minr = 0;

            if (choiceList.Count != 0)
            {
                foreach (var i in choiceList)
                {
                    prot += recipesService.GetRecipeProteins(i);
                    fats += recipesService.GetRecipeFats(i);
                    carb += recipesService.GetRecipeCarbohydrates(i);
                    vitm += recipesService.GetRecipeVitamins(i);
                    minr += recipesService.GetRecipeMinerals(i);
                }
            }

            Console.WriteLine("our ration has: " + prot + "g proteins " + fats + "g fats " + carb +
                "g carbohydrates " + vitm + "g vitamins " + minr + "g minerals ");*/
        }

        //Hello My friend
    }
}
