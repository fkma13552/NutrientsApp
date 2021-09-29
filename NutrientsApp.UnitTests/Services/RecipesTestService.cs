using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using NutrientsApp.Data.Abstract.UnitOfWork;
using NutrientsApp.Data.ImplEf.UnitOfWork;
using NutrientsApp.Domain;
using NutrientsApp.Entities;
using NutrientsApp.Services;
using NutrientsApp.Services.Abstract;

namespace NutrientsApp.UnitTests
{
    public class RecipesTestService
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IProductNutrientsService> _productNutrientsService;
        
        [SetUp]
        public void Setup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _productNutrientsService = new Mock<IProductNutrientsService>();
        }
        
        [Test]
        public async Task TestGetRecipeNutrients_Success()
        {
            //Arrange
            SetupTestGetRecipeNutrients(WithIngredientList(), WithNutrientsDictionary());
            
            //Act
            var service = WithRecipesService();
            var result = await service.GetRecipeNutrients(Guid.NewGuid());

            //Assert
            result.Should().HaveCount(3);
            result.Should().ContainKey("Proteins");
            result.Should().ContainKey("Fats");
            result.Should().ContainKey("Carbohydrates");
        }
        
        [Test]
        public async Task TestGetAll_Success()
        {
            //Arrange
            SetupTestGetAll(WithRecipesEntities());
            
            //Act
            var service = WithRecipesService();
            var result = await service.GetAll();

            //Assert
            result.Should().HaveCount(3);
        }
        
        [Test]
        public async Task TestGetRecipeById_Success()
        {
            //Arrange
            SetupTestGetRecipeById(WithRecipeEntity());
            
            //Act
            var service = WithRecipesService();
            var result = await service.GetRecipeById(Guid.NewGuid());

            //Assert
            result.Should().BeOfType<Recipe>();
        }
        
        [TearDown]
        public void TearDown()
        {
            _unitOfWork.Verify();
            _productNutrientsService.Verify();
        }


        #region Setup

        private void SetupTestGetRecipeNutrients(IList<IngredientEntity> ingredients, IDictionary<string, int> nutrients)
        {
            _unitOfWork
                .Setup(a => a.IngredientsRepository.GetAllItemsFromRecipe(It.IsAny<Guid>()))
                .ReturnsAsync(ingredients)
                .Verifiable();
            _productNutrientsService
                .Setup(a => a.GetProductNutrients(It.IsAny<Guid>()))
                .ReturnsAsync(nutrients)
                .Verifiable();
        }
        
        private void SetupTestGetAll(IList<RecipeEntity> recipes)
        {
            _unitOfWork
                .Setup(a => a.RecipesRepository.GetAll())
                .ReturnsAsync(recipes)
                .Verifiable();
        }
        
        private void SetupTestGetRecipeById(RecipeEntity recipe)
        {
            _unitOfWork
                .Setup(a => a.RecipesRepository.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(recipe)
                .Verifiable();
        }

        #endregion

        #region With

        private IRecipesService WithRecipesService()
        {
            return new RecipesService(_unitOfWork.Object, _productNutrientsService.Object);
        }

        private IList<IngredientEntity> WithIngredientList()
        {
            var ingr = new List<IngredientEntity>();
            ingr.Add(new IngredientEntity()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                RecipeId = Guid.NewGuid(),
                AmountInGrams = 300
            });
            ingr.Add(new IngredientEntity()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                RecipeId = Guid.NewGuid(),
                AmountInGrams = 100
            });
            ingr.Add(new IngredientEntity()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                RecipeId = Guid.NewGuid(),
                AmountInGrams = 200
            });

            return ingr;
        }

        private IDictionary<string, int> WithNutrientsDictionary()
        {
            var nutrients = new Dictionary<string, int>();
            nutrients.Add("Proteins", 20);
            nutrients.Add("Carbohydrates", 40);
            nutrients.Add("Fats", 20);
            return nutrients;
        }
        
        private IList<RecipeEntity> WithRecipesEntities()
        {
            var recipes = new List<RecipeEntity>();
            recipes.Add(new RecipeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Blah blah blah",
                HowTo = "Instructions"
            });
            recipes.Add(new RecipeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Blah blah blah",
                HowTo = "Instructions"
            });
            recipes.Add(new RecipeEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Blah blah blah",
                HowTo = "Instructions"
            });

            return recipes;
        }
        
        private RecipeEntity WithRecipeEntity()
        {
            return new RecipeEntity() {Id = Guid.NewGuid(), Name = "Blah Blah", HowTo = "Instructions"};
        }

        
        #endregion
        
        
    }
}