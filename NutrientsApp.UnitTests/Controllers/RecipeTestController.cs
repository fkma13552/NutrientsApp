using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NutrientsApp.Domain;
using NutrientsApp.Services.Abstract;
using NutrientsApp.WebApi.Controllers;

namespace NutrientsApp.UnitTests
{
    public class RecipeTestController
    {
        private Mock<IRecipesService> _recipesService;
        
        [SetUp]
        public void Setup()
        {
            _recipesService = new Mock<IRecipesService>();
        }

        [Test]
        public async Task TestGet_Success()
        {
            //Arrange
            SetupGet(WithRecipesList());
            
            //Act
            var controller = WithController();
            var result = await controller.Get() as OkObjectResult;
            
            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        
        [Test]
        public async Task TestGet_Fail()
        {
            //Arrange
            SetupGet(WithEmptyList());
            
            //Act
            var controller = WithController();
            var result = await controller.Get() as NoContentResult;
            
            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(204);
        }

        [TearDown]
        public void TearDown()
        {
            _recipesService.Verify();
        }
        
        #region Setup

        private void SetupGet(IList<Recipe> recipes)
        {
            _recipesService
                .Setup(s => s.GetAll())
                .ReturnsAsync(recipes)
                .Verifiable();
        }
        
        #endregion

        #region With

        private RecipeController WithController()
        {
            return new RecipeController(_recipesService.Object);
        }
        private IList<Recipe> WithRecipesList()
        {
            var recipes = new List<Recipe>();
            recipes.Add(new Recipe(){Id = Guid.NewGuid(), Name = "Blah blah", HowTo = "Instruction"});
            recipes.Add(new Recipe(){Id = Guid.NewGuid(), Name = "Blah blah", HowTo = "Instruction"});
            recipes.Add(new Recipe(){Id = Guid.NewGuid(), Name = "Blah blah", HowTo = "Instruction"});
            return recipes;
        }

        private IList<Recipe> WithEmptyList()
        {
            var recipes = new List<Recipe>();
            return recipes;
        }

        #endregion
        
    }
}