using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NutrientsApp.Data;
using NutrientsApp.Domain;
using NutrientsApp.Entities;

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
